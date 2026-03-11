using F2F_Application.Classes;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class User_Form : MaterialForm
    {
        public User_Form(Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(activeScreenDimensions.Width, activeScreenDimensions.Height);
        }

        Main_Form main_form;
        Bitmap Unknown_User = Properties.Resources.Unknown_User;
        User u;
        Thread myTh;
        byte[] PicArr;
        string imageFilePath, imageName;
        bool DataApproved = false;
        bool UserMode;

        private void User_Form_Load(object sender, EventArgs e)
        {
            try
            {
                u = new User();
                Bind_User_DataGridView();
                Bind_Role_Combobox(false);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void CallDialog()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            DialogResult res = open.ShowDialog();
            if (res == DialogResult.OK)
            {
                imageFilePath = open.FileName;
                imageName = Path.GetFileName(open.FileName);
                ProfilePicture_pictureBox.ImageLocation = imageFilePath;

                FileStream fs = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
            }
        }

        private bool Check_Data()
        {
            if (Username_textBox.Text == "")
            {
                MessageBox.Show("لا يمكن ترك خانة إسم المستخدم فارغة", "Error");
                return false;
            }
            if (Password_textBox.Text == "")
            {
                MessageBox.Show("لا يمكن ترك خانة كلمة السر فارغة", "Error");
                return false;
            }
            if (Role_comboBox1.Text == "")
            {
                MessageBox.Show("يجب إختيار صلاحيات المستخدم (Role)", "Error");
                return false;
            }
            return true;
        }

        private void Bind_User_DataGridView()
        {
            DataTable dt;
            if (Properties.Settings.Default.Role == "L0_Admin")
            {
                dt = u.Select_Users(true);
            }
            else
            {
                dt = u.Select_Users(false);
            }
            User_DataGridView.Rows.Clear();
            UserMode = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                User_DataGridView.Rows.Add();
                User_DataGridView.Rows[i].Cells["User_ID"].Value = dt.Rows[i].Field<int>("ID");
                User_DataGridView.Rows[i].Cells["UserName"].Value = dt.Rows[i].Field<string>("Username");
                User_DataGridView.Rows[i].Cells["Password"].Value = dt.Rows[i].Field<string>("Password");
                User_DataGridView.Rows[i].Cells["Role"].Value = dt.Rows[i].Field<int>("Role_id");
                User_DataGridView.Rows[i].Cells["Pic"].Value = dt.Rows[i].Field<byte[]>("Picture");
            }

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)User_DataGridView.Columns["Pic"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            UserMode = true;
        }

        private void AddImage_button_Click(object sender, EventArgs e)
        {
            try
            {
                //CheckUserPermission();
                myTh = new Thread(new ThreadStart(CallDialog));
                myTh.SetApartmentState(ApartmentState.STA);
                myTh.Start();
                myTh.Join();
            }
            catch (Exception ex)
            { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }
        }

        private void Bind_Role_Combobox(bool KeepSelection)
        {
            int SelectedValue = -1;
            if (Role_comboBox1.SelectedValue != null)
                SelectedValue = int.Parse(Role_comboBox1.SelectedValue.ToString());

            DataTable dt;

            dt = u.Select_Roles(Properties.Settings.Default.Role);


            Role_comboBox1.DataSource = dt;
            Role_comboBox1.DisplayMember = "Name";
            Role_comboBox1.ValueMember = "ID";
            if (KeepSelection && SelectedValue != -1)
                Role_comboBox1.SelectedValue = SelectedValue;
            else
                Role_comboBox1.SelectedIndex = -1;

            Role_comboBox1.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);

            this.Role.DataSource = dt;
            this.Role.DisplayMember = "name";
            this.Role.ValueMember = "id";
        }

        private void User_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == User_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == User_DataGridView.Columns["Delete"].Index)
                {
                    Image image = null;
                    image = Properties.Resources.Trash_Small_L;
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                    var size = image.Size;
                    var location = new Point((e.CellBounds.Width - size.Width) / 2, (e.CellBounds.Height - size.Height) / 2);
                    location.Offset(e.CellBounds.Location);
                    e.Graphics.DrawImage(image, location);

                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void User_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void User_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    //if click is on new row or header row
                    if (e.RowIndex < 0 || e.ColumnIndex < 0)
                        return;

                    DialogResult dialogResult = MessageBox.Show("تأكيد التعديل", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (User_DataGridView.Rows[e.RowIndex].Cells["UserName"].Value == null || string.IsNullOrWhiteSpace(User_DataGridView.Rows[e.RowIndex].Cells["UserName"].Value.ToString())
                            || User_DataGridView.Rows[e.RowIndex].Cells["Password"].Value == null || string.IsNullOrWhiteSpace(User_DataGridView.Rows[e.RowIndex].Cells["Password"].Value.ToString()))
                        {
                            MessageBox.Show("لا يمكن ترك اسم المستخدم أو كلمة الدخول فارغاً", "Error");
                            return;
                        }
                        else
                        {
                            int ID = int.Parse(User_DataGridView.Rows[e.RowIndex].Cells["User_ID"].Value.ToString());
                            string User_Name = User_DataGridView.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
                            string Password = User_DataGridView.Rows[e.RowIndex].Cells["Password"].Value.ToString();
                            int Role_ID = int.Parse(User_DataGridView.Rows[e.RowIndex].Cells["Role"].Value.ToString());
                            u.Update_User(ID, User_Name, Password, Role_ID, this.Name);
                            MessageBox.Show("تم التعديل بنجاح", "Confirmation");
                        }
                    }
                    Set_Controls();
                }
            }
            catch (Exception ex)
            {
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void User_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                //Check if click is on specific column 
                if (User_DataGridView.Columns[e.ColumnIndex].Name == "Pic")
                {
                    myTh = new Thread(new ThreadStart(CallDialog));
                    myTh.SetApartmentState(ApartmentState.STA);
                    myTh.Start();
                    myTh.Join();

                    DialogResult dialogResult = MessageBox.Show("تأكيد التعديل", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int ID = int.Parse(User_DataGridView.Rows[e.RowIndex].Cells["User_ID"].Value.ToString());
                        string Username = User_DataGridView.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
                        if (ProfilePicture_pictureBox.Image != Unknown_User)
                        {
                            PicArr = ImageToByte(ProfilePicture_pictureBox.Image);
                        }
                        else
                        {
                            PicArr = null;
                        }
                        u.Update_Profile_Pic(ID, Username, PicArr, this.Name);
                        MessageBox.Show("تم التعديل بنجاح", "Confirmation");
                    }
                    Set_Controls();
                }
            }
            catch (Exception ex)
            {
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void User_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                //Check if click is on specific column 
                if (User_DataGridView.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    if (User_DataGridView.Rows.Count <= 1)
                    {
                        MessageBox.Show("لا يمكن حذف جميع المستخدمين", "Error");
                        Set_Controls();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int ID = int.Parse(User_DataGridView.Rows[e.RowIndex].Cells["User_ID"].Value.ToString());
                            string User_Name = User_DataGridView.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                            u.Delete_User(ID, User_Name, this.Name);
                            MessageBox.Show("تم الحذف بنجاح", "Confirmation");
                        }
                        Set_Controls();
                    }
                }
            }
            catch (Exception ex)
            {
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void DeleteImage_button_Click(object sender, EventArgs e)
        {
            try
            {
                //CheckUserPermission();
                ProfilePicture_pictureBox.Image = Unknown_User;
            }
            catch (Exception ex)
            { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }
        }

        private void Insert_button_Click(object sender, EventArgs e)
        {
            try
            {
                DataApproved = false;
                DataApproved = Check_Data();
                if (DataApproved)
                {
                    //////////////////// Convert_Picture(); ////////////////////
                    if (ProfilePicture_pictureBox.Image != Unknown_User)
                    {
                        PicArr = ImageToByte(ProfilePicture_pictureBox.Image);
                    }
                    else
                    {
                        PicArr = null;
                    }
                    string User_Name = Username_textBox.Text;
                    string Password = Password_textBox.Text;
                    int Role_ID = int.Parse(Role_comboBox1.SelectedValue.ToString());
                    u.Insert_User(User_Name, Password, Role_ID, PicArr, this.Name);
                    MessageBox.Show("تم الإدخال بنجاح", "Confirmation");

                    Set_Controls();
                }

            }
            catch (Exception ex)
            {
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Set_Controls()
        {
            Username_textBox.Clear(); Password_textBox.Clear();
            Role_comboBox1.SelectedIndex = -1;
            ProfilePicture_pictureBox.Image = Unknown_User;
            UserMode = true;
            Bind_User_DataGridView();
        }

        private void User_DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == User_DataGridView.NewRowIndex || e.RowIndex < 0)
                return;

            if (User_DataGridView.Columns[e.ColumnIndex].Name == "Pic")
            {
                User_DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "نقرتين لتغيير الصورة";
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("هل تريد حذف جميع البيانات غير المحفوظة؟؟", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Username_textBox.Clear(); Password_textBox.Clear();
                        ProfilePicture_pictureBox.Image = Unknown_User;
                        Bind_Role_Combobox(false);
                        UserMode = true;
                        Bind_User_DataGridView();
                    }
                    else
                    {
                        Bind_Role_Combobox(true);
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                }
            }
        }

        private void Insert_button_MouseLeave(object sender, EventArgs e)
        {
            Insert_button.BackgroundImage = F2F_Application.Properties.Resources.button1;
        }

        private void Insert_button_MouseEnter(object sender, EventArgs e)
        {
            Insert_button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void AddImage_button_MouseEnter(object sender, EventArgs e)
        {
            AddImage_button.BackgroundImage = F2F_Application.Properties.Resources.Plus_2;

        }

        private void AddImage_button_MouseLeave(object sender, EventArgs e)
        {
            AddImage_button.BackgroundImage = F2F_Application.Properties.Resources.Plus_1;

        }

        private void DeleteImage_button_MouseEnter(object sender, EventArgs e)
        {
            DeleteImage_button.BackgroundImage = F2F_Application.Properties.Resources.Trash_2;

        }

        private void DeleteImage_button_MouseLeave(object sender, EventArgs e)
        {
            DeleteImage_button.BackgroundImage = F2F_Application.Properties.Resources.Trash_1;

        }

        private void User_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                ComboBox cb = (ComboBox)e.Control;
                cb.DrawMode = DrawMode.OwnerDrawVariable;
                cb.DrawItem -= ComboBox_DrawItem;
                cb.DrawItem += ComboBox_DrawItem;
            }
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background.
            e.DrawBackground();

            SolidBrush brush = new SolidBrush(Color.FromArgb(42, 158, 158));

            if (e.Index >= 0)
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }

                object Ob = ((ComboBox)sender).Items[e.Index];
                // Draw the text.
                e.Graphics.DrawString(((ComboBox)sender).GetItemText(((ComboBox)sender).Items[e.Index]), e.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
            }
        }
    }
}

