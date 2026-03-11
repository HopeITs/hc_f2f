using F2F_Application.Classes;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using GMap.NET.WindowsForms.ToolTips;

namespace F2F_Application
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme("007a7a", "004b4b", "0e9595", "2e9a9a", TextShade.WHITE);

            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MyColorTable());
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            statisticsToolStripMenuItem.Visible = false;

        }

        private Point image_Location = new Point(22, 7);
        private Point image_HitArea = new Point(20, 2);
        int tabCount = 0;
        bool UserMode = false;
        User u;
        Family f;
        GMapOverlay markers;
       
        public class MyColorTable : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground
            {
                get
                {
                    return Color.White;
                }
            }

            /*
            public override Color ImageMarginGradientBegin
            {
                get
                {
                    return Color.Blue;
                }
            }

            public override Color ImageMarginGradientMiddle
            {
                get
                {
                    return Color.Blue;
                }
            }

            public override Color ImageMarginGradientEnd
            {
                get
                {
                    return Color.Blue;
                }
            }
            */

            public override Color MenuBorder
            {
                get
                {
                    return Color.DarkSlateGray;
                }
            }

            public override Color MenuItemBorder
            {
                get
                {
                    return Color.Transparent;
                }
            }

            public override Color MenuItemSelected
            {
                get
                {
                    return Color.FromArgb(46, 154, 154);
                }
            }

            /*
            public override Color MenuStripGradientBegin
            {
                get
                {
                    return Color.Red;
                }
            }
            
            public override Color MenuStripGradientEnd
            {
                get
                {
                    return Color.Red;
                }
            }
            */

            public override Color MenuItemSelectedGradientBegin
            {
                get
                {
                    return Color.FromArgb(46, 154, 154);
                }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get
                {
                    return Color.FromArgb(46, 154, 154);
                }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get
                {
                    return Color.FromArgb(46, 154, 154);

                }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get
                {
                    return Color.FromArgb(46, 154, 154);

                }
            }
        }

        class ReSize
        {

            private bool Above, Right, Under, Left, Right_above, Right_under, Left_under, Left_above;


            int Thickness = 6;  //Thickness of border  u can cheang it
            int Area = 8;     //Thickness of Angle border 


            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="thickness">set thickness of form border</param>
            public ReSize(int thickness)
            {
                Thickness = thickness;
            }

            /// <summary>
            /// Constructor set thickness of form border=1
            /// </summary>
            public ReSize()
            {
                Thickness = 10;
            }

            //Get Mouse Position
            public string getMosuePosition(Point mouse, Form form)
            {
                bool above_underArea = mouse.X > Area && mouse.X < form.ClientRectangle.Width - Area; /* |\AngleArea(Left_Above)\(=======above_underArea========)/AngleArea(Right_Above)/| */ //Area===>(==)
                bool right_left_Area = mouse.Y > Area && mouse.Y < form.ClientRectangle.Height - Area;

                bool _Above = mouse.Y <= Thickness;  //Mouse in Above All Area
                bool _Right = mouse.X >= form.ClientRectangle.Width - Thickness;
                bool _Under = mouse.Y >= form.ClientRectangle.Height - Thickness;
                bool _Left = mouse.X <= Thickness;

                Above = _Above && (above_underArea); if (Above) return "a";   /*Mouse in Above All Area WithOut Angle Area */
                Right = _Right && (right_left_Area); if (Right) return "r";
                Under = _Under && (above_underArea); if (Under) return "u";
                Left = _Left && (right_left_Area); if (Left) return "l";


                Right_above =/*Right*/ (_Right && (!right_left_Area)) && /*Above*/ (_Above && (!above_underArea)); if (Right_above) return "ra";     /*if Mouse  Right_above */
                Right_under =/* Right*/((_Right) && (!right_left_Area)) && /*Under*/(_Under && (!above_underArea)); if (Right_under) return "ru";     //if Mouse  Right_under 
                Left_under = /*Left*/((_Left) && (!right_left_Area)) && /*Under*/ (_Under && (!above_underArea)); if (Left_under) return "lu";      //if Mouse  Left_under
                Left_above = /*Left*/((_Left) && (!right_left_Area)) && /*Above*/(_Above && (!above_underArea)); if (Left_above) return "la";      //if Mouse  Left_above

                return "";

            }
        }

        ReSize resize = new ReSize();     // ReSize Class "/\" To Help Resize Form <None Style>


        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            //this if you want to draw   (if)

            //Color theColor = Color.FromArgb(10, 20, 20, 20);
            //theColor = Color.DarkBlue;
            int BORDER_SIZE = 4;
            //ControlPaint.DrawBorder(e.Graphics, ClientRectangle,theColor, BORDER_SIZE, ButtonBorderStyle.Dashed,theColor, BORDER_SIZE, ButtonBorderStyle.Dashed,theColor, BORDER_SIZE, ButtonBorderStyle.Dashed,theColor, BORDER_SIZE, ButtonBorderStyle.Dashed);


            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            //ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            //e.Graphics.FillRectangle(Brushes.DarkBlue, rc);



            base.OnPaint(e);
        }


        //set MinimumSize to Form
        public override Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }
            set
            {
                Screen ActiveScreen = Screen.FromControl(this);
                base.MinimumSize = new Size(ActiveScreen.WorkingArea.Width * 2 / 3, ActiveScreen.WorkingArea.Height * 2 / 3);
            }
        }

        //
        //override  WndProc  
        //
        protected override void WndProc(ref Message m)
        {
            //****************************************************************************

            int x = (int)(m.LParam.ToInt64() & 0xFFFF);               //get x mouse position
            int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);   //get y mouse position  you can gave (x,y) it from "MouseEventArgs" too
            Point pt = PointToClient(new Point(x, y));

            if (m.Msg == 0x84)
            {
                switch (resize.getMosuePosition(pt, this))
                {
                    case "l": m.Result = (IntPtr)10; return;  // the Mouse on Left Form
                    case "r": m.Result = (IntPtr)11; return;  // the Mouse on Right Form
                    case "a": m.Result = (IntPtr)12; return;
                    case "la": m.Result = (IntPtr)13; return;
                    case "ra": m.Result = (IntPtr)14; return;
                    case "u": m.Result = (IntPtr)15; return;
                    case "lu": m.Result = (IntPtr)16; return;
                    case "ru": m.Result = (IntPtr)17; return; // the Mouse on Right_Under Form
                    case "": m.Result = pt.Y < 32 /*mouse on title Bar*/ ? (IntPtr)2 : (IntPtr)1; return;
                }
            }
            else if (m.Msg == 0x00A3)
            {
                Resize_button.PerformClick();
                return;
            }

            base.WndProc(ref m);
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            try
            {
                u = new User();
                f = new Family();
                
                using (Login_Form login_Form = new Login_Form(this, false))
                {
                    DialogResult res = login_Form.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        Resize_button.PerformClick();

                        Username_Label.Text = "User: " + Properties.Settings.Default.Username;
                        Username_Label.BackColor = Color.Transparent;
                        Username_Label.ForeColor = Color.White;

                        Version_Label.Text += Application.ProductVersion;

                        menuStrip1.ForeColor = Color.White;
                        Version_Label.ForeColor = Color.White;

                        SetPanelBackground();
                        Check_User_Role();
                    }
                    else
                    {
                        if (Properties.Settings.Default.LogedIn)
                        {
                            //Do Nothing
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                    UserMode = true;
                }
                
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to connect to the server"))
                    MessageBox.Show("Unable to connect to the server please try again or check your connection", "Error");
                else
                { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }
            }
        }

        

        private void addFamilyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form Family_Form = new Family_Form(this);
                showNewTab(Family_Form, "Family");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        public void showNewTab(Form cform, string HeaderText)
        {
            tabCount = tabCount + 1;
            cform.Text = HeaderText;
            cform.TopLevel = false;
            cform.ControlBox = false;
            cform.FormBorderStyle = FormBorderStyle.None;
            cform.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(cform);
            AddForm(cform);

        }

        private List<Form> _childForms = new List<Form>();

        void AddForm(Form toAdd)
        {
            _childForms.Add(toAdd);
            Home_Panel.Visible = false;

            toAdd.Closed += (sender, e) =>
            {
                _childForms.Remove(toAdd);

                if (_childForms.Count == 0) Home_Panel.Visible = true;
            };
        }

        private void SetPanelBackground()
        {
            Program.buildConnection();
            byte[] arr = null;
            string query = "SELECT `Image` FROM `backgrounds` where `Name` = 'home'";
            MySqlCommand sc = new MySqlCommand(query, Program.MyConn);
            MySqlDataReader reader = sc.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                if (reader[0] != DBNull.Value)
                {
                    arr = (byte[])(reader[0]);

                    MemoryStream ms = new MemoryStream(arr);

                    Home_Panel.BackgroundImage = Image.FromStream(ms);
                    Home_Panel.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }
            reader.Close();
            Program.MyConn.Close();
        }

        private void Check_User_Role()
        {
            tabControl1.TabPages.Clear();
            Program.Family_Opened.Clear(); Program.Person_Opened.Clear(); Program.Distribution_Opened.Clear();
            Home_Panel.Visible = true;

            //reset all
            ToolStripItem[] FamilyItems = GetAllChildren(menuStrip1.Items["familyToolStripMenuItem"]);
            ToolStripItem[] PartnerItems = GetAllChildren(menuStrip1.Items["partnerToolStripMenuItem"]);
            ToolStripItem[] DistributionItems = GetAllChildren(menuStrip1.Items["distributionToolStripMenuItem"]);
            ToolStripItem[] ToolsItems = GetAllChildren(menuStrip1.Items["toolsToolStripMenuItem"]);
            ToolStripItem[] ReportsItems = GetAllChildren(menuStrip1.Items["reportsToolStripMenuItem"]);

            for (int i = 0; i < FamilyItems.Length; i++)
                FamilyItems[i].Visible = true;

            for (int i = 0; i < PartnerItems.Length; i++)
                PartnerItems[i].Visible = true;

            for (int i = 0; i < FamilyItems.Length; i++)
                FamilyItems[i].Visible = true;

            for (int i = 0; i < DistributionItems.Length; i++)
                DistributionItems[i].Visible = true;

            for (int i = 0; i < ToolsItems.Length; i++)
                ToolsItems[i].Visible = true;
            
            for (int i = 0; i < ReportsItems.Length; i++)
                ReportsItems[i].Visible = true;

            DataBase_comboBox.Visible = false;

            if (Properties.Settings.Default.Online)
                Online_checkbox.Checked = true;

            if (Properties.Settings.Default.Role == "L0_Admin") //ADDED BY SARY
            {
                DataBase_comboBox.Visible = true;
                Bind_DataBase_comboBox();
            }
            else if (Properties.Settings.Default.Role == "Admin") //admin
            {
                //DO NOTHING
            }
            else if (Properties.Settings.Default.Role == "Data")
            {
                segmentsGroupsToolStripMenuItem.Visible = false;
                reportsToolStripMenuItem.Visible = false;
                distributionToolStripMenuItem.Visible = false;
                partnerToolStripMenuItem.Visible = false;
                //toolsToolStripMenuItem.Visible = false;
                userToolStripMenuItem.Visible = false;
                dataToolStripMenuItem.Visible = false;
                showMapToolStripMenuItem1.Visible = false;
                categoriesToolStripMenuItem.Visible = false;
                logToolStripMenuItem.Visible = false;
                usersStatisticToolStripMenuItem.Visible = false;
                searchDistributionToolStripMenuItem1.Visible = false;
                searchPartnerToolStripMenuItem1.Visible = false;
                familyMarksToolStripMenuItem.Visible = false;
                statisticsToolStripMenuItem.Visible = false;
            }
            else if (Properties.Settings.Default.Role == "Viewer")
            {
                familyToolStripMenuItem.Visible = false;
                segmentsGroupsToolStripMenuItem.Visible = false;
                reportsToolStripMenuItem.Visible = false;
                distributionToolStripMenuItem.Visible = false;
                partnerToolStripMenuItem.Visible = false;
                statisticsToolStripMenuItem.Visible = false;

                foreach (ToolStripItem Itm in ToolsItems)
                    if (Itm.Name == "searchToolStripMenuItem")
                        Itm.Visible = true;
                    else
                        Itm.Visible = false;

                toolsToolStripMenuItem.Visible = true;
            }
            else
            {
                for (int i = 0; i < menuStrip1.Items.Count; i++)
                {
                    menuStrip1.Items[i].Visible = false;
                }
            }
        }



        private ToolStripItem[] GetAllChildren(ToolStripItem item)
        {
            List<ToolStripItem> Items = new List<ToolStripItem> { item };
            if (item is ToolStripMenuItem)
                foreach (ToolStripItem i in ((ToolStripMenuItem)item).DropDownItems)
                    Items.AddRange(GetAllChildren(i));
            else if (item is ToolStripSplitButton)
                foreach (ToolStripItem i in ((ToolStripSplitButton)item).DropDownItems)
                    Items.AddRange(GetAllChildren(i));
            else if (item is ToolStripDropDownButton)
                foreach (ToolStripItem i in ((ToolStripDropDownButton)item).DropDownItems)
                    Items.AddRange(GetAllChildren(i));
            return Items.ToArray();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing) //To Enable colsing the program with the code
                {
                    if (MessageBox.Show("Are you sure you want to close the Application ?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        u.Update_Logedin(Properties.Settings.Default.User_ID, 0, 0, "");
                        // continue closing;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch
            {

            }

        }

        string destpath = "";
        private void SaveCallDialog()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Backup file|*.sql";
            saveFileDialog1.Title = "Save a backup for database:";
            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                // If the file name is not an empty string open it for saving.  
                if (saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.  
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                    destpath = saveFileDialog1.FileName;
                    fs.Close();
                }
            }
        }

        private void OpenCallDialog()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select a backup file:";
            open.Filter = "Backup file|*.sql";
            DialogResult res = open.ShowDialog();
            if (res == DialogResult.OK)
            {
                destpath = open.FileName;
            }
        }

        private void backupDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //export from offline
                Thread myTh = new Thread(new ThreadStart(SaveCallDialog));
                myTh.SetApartmentState(ApartmentState.STA);
                myTh.Start();
                myTh.Join();
                MySqlConnection conn = new MySqlConnection(Program.ConnectionString);
                MySqlCommand cmd = new MySqlCommand();
                MySqlBackup mb = new MySqlBackup(cmd);

                cmd.Connection = conn;
                conn.Open();
                mb.ExportToFile(destpath);
                conn.Close();

                MessageBox.Show("Backup succeeded", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }
        }

        private void restoreDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //export from offline
                Thread myTh = new Thread(new ThreadStart(OpenCallDialog));
                myTh.SetApartmentState(ApartmentState.STA);
                myTh.Start();
                myTh.Join();
                MySqlConnection conn = new MySqlConnection(Program.ConnectionString);
                MySqlCommand cmd = new MySqlCommand();
                MySqlBackup mb = new MySqlBackup(cmd);

                cmd.Connection = conn;
                conn.Open();
                mb.ImportFromFile(destpath);
                conn.Close();

                MessageBox.Show("Restore succeeded", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                User_Form User_Form = new User_Form(this);
                User_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Username_Label_Click(object sender, EventArgs e)
        {
            try
            {
                Login_Form login_Form = new Login_Form(this, true);
                if (login_Form.ShowDialog() == DialogResult.OK)
                {
                    Username_Label.Text = "User: " + Properties.Settings.Default.Username;
                    Check_User_Role();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Username_Label_MouseHover(object sender, EventArgs e)
        {
            Username_Label.BackColor = Color.LightBlue;
        }

        private void Username_Label_MouseLeave(object sender, EventArgs e)
        {
            Username_Label.BackColor = Color.Transparent;
            Username_Label.ForeColor = Color.White;
        }

        private void DataBase_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string Selected_F2F = DataBase_comboBox.GetItemText(DataBase_comboBox.SelectedItem);
                Properties.Settings.Default.Selected_F2F = Selected_F2F;

                Program.set_ConnectionString();
                MessageBox.Show("تم الانتقال للعمل على قاعدة بيانات مركز  " + Selected_F2F, "Confirmation");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bind_DataBase_comboBox()
        {
            DataBase_comboBox.Items.Clear();
            DataBase_comboBox.Items.AddRange(Program.User_In_Database.ToArray());
            DataBase_comboBox.SelectedItem = Properties.Settings.Default.Selected_F2F;
        }

        private void Online_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Online_checkbox.Checked)
                    {
                        Properties.Settings.Default.Online = true;
                        Program.set_ConnectionString();
                        MessageBox.Show("تم الانتقال للعمل على قاعدة بيانات Online", "Confirmation");
                    }
                    else
                    {
                        Properties.Settings.Default.Online = false;
                        Program.set_ConnectionString();
                        MessageBox.Show("تم الانتقال للعمل على قاعدة بيانات محلية", "Confirmation");
                    }
                }


            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addPartnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Partner_Form NewPartner_Form = new Partner_Form(this);
                NewPartner_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Categories_Form Categories_Form = new Categories_Form(this);
                Categories_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void addDistributionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Distribution_Form Distribution_Form = new Distribution_Form(this);
                showNewTab(Distribution_Form, "Distribution");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void segmentsGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SegmentsGroup_Form NewSegmentsGroup_Form = new SegmentsGroup_Form(this);
                NewSegmentsGroup_Form.Show();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void segmentsGroupsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SegmentsGroup_Form NewSegmentsGroup_Form = new SegmentsGroup_Form(this);
                NewSegmentsGroup_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Report_Form Report_Form = new Report_Form(this);
                showNewTab(Report_Form, "Report");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void distributionScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Schedule_Form Schedule_Form = new Schedule_Form(this);
                showNewTab(Schedule_Form, "Distribution Schedule");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void searchFamilyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form Search_Form = new Search_Form(this, "Family");
                showNewTab(Search_Form, "Search");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void familyMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Family_Marks_Form Family_Marks_Form = new Family_Marks_Form(this);
                showNewTab(Family_Marks_Form, "Family Marks");
            }
            catch (Exception ex)
            { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }

        }

        private void searchPartnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form Search_Form = new Search_Form(this, "Partner");
                showNewTab(Search_Form, "Search");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void searchDistributionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form Search_Form = new Search_Form(this, "Distribution");
                showNewTab(Search_Form, "Search");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void searchPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form Search_Form = new Search_Form(this, "Member");
                showNewTab(Search_Form, "Search");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void partnerDistributionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form Partner_Distribution_Form = new Partner_Distribution_Form(this);
                showNewTab(Partner_Distribution_Form, "Partner - Distribution");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background.
            e.DrawBackground();

            SolidBrush brush = new SolidBrush(Color.FromArgb(42, 158, 158));
            SolidBrush Text_brush;

            if (e.Index >= 0)
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                    Text_brush = new SolidBrush(Color.FromArgb(230, 230, 230));
                }
                else
                {
                    Text_brush = new SolidBrush(Color.FromArgb(147, 147, 147));
                }

                object Ob = ((ComboBox)sender).Items[e.Index];
                // Draw the text.
                e.Graphics.DrawString(((ComboBox)sender).GetItemText(((ComboBox)sender).Items[e.Index]), e.Font, Text_brush, e.Bounds.X, e.Bounds.Y);
            }

        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form Log_Form = new Log_Form(this);
                showNewTab(Log_Form, "Log");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Resize_button_Click(object sender, EventArgs e)
        {
            Screen ActiveScreen = Screen.FromControl(this);
            this.MinimumSize = new Size(ActiveScreen.WorkingArea.Width * 2 / 3, ActiveScreen.WorkingArea.Height * 2 / 3);
            this.MaximumSize = ActiveScreen.WorkingArea.Size;
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.Size = this.MaximumSize;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = this.MinimumSize;
            }
        }

        private void Minimize_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void usersStatisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Users_Statistic_Form Users_Statistic_Form = new Users_Statistic_Form(this);
                Users_Statistic_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Close_button_MouseEnter(object sender, EventArgs e)
        {
            Close_button.BackgroundImage = F2F_Application.Properties.Resources.close_1;

        }

        private void Close_button_MouseLeave(object sender, EventArgs e)
        {
            Close_button.BackgroundImage = F2F_Application.Properties.Resources.close;

        }

        private void Resize_button_MouseEnter(object sender, EventArgs e)
        {
            Resize_button.BackgroundImage = F2F_Application.Properties.Resources.maximize_1;

        }

        private void Resize_button_MouseLeave(object sender, EventArgs e)
        {
            Resize_button.BackgroundImage = F2F_Application.Properties.Resources.maximize;

        }

        private void Minimize_button_MouseEnter(object sender, EventArgs e)
        {
            Minimize_button.BackgroundImage = F2F_Application.Properties.Resources.minimize_1;

        }

        private void Minimize_button_MouseLeave(object sender, EventArgs e)
        {
            Minimize_button.BackgroundImage = F2F_Application.Properties.Resources.minimize;

        }

        private void updateHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            News_Form News_Form = new News_Form();
            News_Form.ShowDialog();
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FeedBack_Form NewIdea_Form = new FeedBack_Form();
                NewIdea_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }


        private void FamilyMap_Paint(object sender, PaintEventArgs e)
        {
            try
            {

            }
            catch (ArgumentOutOfRangeException)
            {
                // discard - it's a bug in the original control.
            }
        }

        private void showMApToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showMapToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void showMapToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Form Family_Map = new Family_Map();
                showNewTab(Family_Map, "Map");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void searchVisitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form Search_Visit = new Search_Visit(this, "Family");
                showNewTab(Search_Visit, "Search Visit");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void searchFamilyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Form Search_Form = new Search_Form(this, "Family");
                showNewTab(Search_Form, "Search");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void searchMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form Search_Form = new Search_Form(this, "Member");
                showNewTab(Search_Form, "Search");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void searchVisitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Form Search_Visit = new Search_Visit(this, "Family");
                //Form Search_Visit = new Search_Visit(this, "Member");
                showNewTab(Search_Visit, "Search Visit");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void searchPartnerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Form Search_Form = new Search_Form(this, "Partner");
                showNewTab(Search_Form, "Search");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void searchDistributionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Form Search_Form = new Search_Form(this, "Distribution");
                showNewTab(Search_Form, "Search");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void discriminationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Discrimination_Form Discrimination_Form = new Discrimination_Form(this,"");
                showNewTab(Discrimination_Form, "Members by Age-Gender ");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void signaturelistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DistributionDiffer_Form DistributionDiffer_Form = new DistributionDiffer_Form(this);
                showNewTab(DistributionDiffer_Form, "Distributions Differences");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void distributionsComarisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DistributionDiffer_Form DistributionDiffer_Form = new DistributionDiffer_Form(this);
                showNewTab(DistributionDiffer_Form, "Distributions Comparison");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void segmentsGroupsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                SegmentsGroup_Form NewSegmentsGroup_Form = new SegmentsGroup_Form(this);
                NewSegmentsGroup_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form Statistics_Form = new Statistics_Form(this, "Statistics");
                showNewTab(Statistics_Form, "Statistics");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void distributionsByAgeGenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DistribtionAgeGender_Form DistribtionAgeGender_Form = new DistribtionAgeGender_Form(this);
                showNewTab(DistribtionAgeGender_Form, "Distribution by Age-Gender ");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
    }
}
