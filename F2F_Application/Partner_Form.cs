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
    public partial class Partner_Form : MaterialForm
    {
        public Partner_Form(Main_Form main_form)
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
        Partner pa; Categories c;
        Thread myTh;
        byte[] PicArr;
        string imageFilePath, imageName;
        bool DataApproved = false;
        bool UserMode;

        private void NewPartnerForm_Load(object sender, EventArgs e)
        {
            try
            {
                pa = new Partner();
                c = new Categories();
                Bind_Group_Combobox(false);
                Bind_Partner_DataGridView();

                Partnergroup_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Bind_Partner_DataGridView()
        {
            DataTable dt;
            dt = pa.Select_Partners();
            Partner_DataGridView.Rows.Clear();
            UserMode = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Partner_DataGridView.Rows.Add();
                Partner_DataGridView.Rows[i].Cells["Partner_ID"].Value = dt.Rows[i].Field<int>("ID");
                Partner_DataGridView.Rows[i].Cells["Partner"].Value = dt.Rows[i].Field<string>("name");
                Partner_DataGridView.Rows[i].Cells["Partner_EN"].Value = dt.Rows[i].Field<string>("name_en");
                Partner_DataGridView.Rows[i].Cells["Group"].Value = dt.Rows[i].Field<int>("partnergroup_id");
                Partner_DataGridView.Rows[i].Cells["Logo"].Value = dt.Rows[i].Field<byte[]>("logo");
            }

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)Partner_DataGridView.Columns["Logo"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            UserMode = true;
        }

        public void Bind_Group_Combobox(bool KeepSelection)
        {
            int SelectedValue = -1;
            if (Partnergroup_ComboBox.SelectedValue != null)
                SelectedValue = int.Parse(Partnergroup_ComboBox.SelectedValue.ToString());

            DataTable dt = new DataTable();
            dt = c.Select_Table("partnergroups", "", true, false);
            Partnergroup_ComboBox.DataSource = dt;
            Partnergroup_ComboBox.DisplayMember = "name";
            Partnergroup_ComboBox.ValueMember = "id";
            if (KeepSelection && SelectedValue != -1)
                Partnergroup_ComboBox.SelectedValue = SelectedValue;
            else
                Partnergroup_ComboBox.SelectedIndex = -1;

            Group.DataSource = dt;
            Group.DisplayMember = "name";
            Group.ValueMember = "id";
        }

        private void DeleteImage_button_Click(object sender, EventArgs e)
        {
            try
            {
                //CheckUserPermission();
                Logo_pictureBox.Image = Unknown_User;
            }
            catch (Exception ex)
            { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }
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
                Logo_pictureBox.ImageLocation = imageFilePath;

                FileStream fs = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                //PicArr = br.ReadBytes((int)fs.Length);
            }
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

        private bool Check_Data()
        {
            if (string.IsNullOrWhiteSpace(PartnerName_TextBox.Text))
            {
                MessageBox.Show("لا يمكن ترك اسم الشريك أو الرمز فارغاً", "Error");
                return false;
            }

            if (string.IsNullOrEmpty(Partnergroup_ComboBox.Text) || Partnergroup_ComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("الرجاء اختيار المجموعة", "Error");
                return false;
            }

            return true;
        }

        private void Partner_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == Partner_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == Partner_DataGridView.Columns["Delete"].Index)
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

        private void Insert_button_Click(object sender, EventArgs e)
        {
            try
            {
                DataApproved = false;
                DataApproved = Check_Data();
                if (DataApproved)
                {
                    //////////////////// Convert_Picture(); ////////////////////
                    if (Logo_pictureBox.Image != Unknown_User)
                    {
                        PicArr = ImageToByte(Logo_pictureBox.Image);
                    }
                    else
                    {
                        PicArr = null;
                    }
                    ////////////////////////////////////////////////////////////

                    pa.Insert_Partner(PartnerName_TextBox.Text, PartnerNameEN_TextBox.Text, int.Parse(Partnergroup_ComboBox.SelectedValue.ToString()), PicArr, this.Name);

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
            PartnerName_TextBox.Clear(); PartnerNameEN_TextBox.Clear();
            Partnergroup_ComboBox.SelectedIndex = -1;
            Logo_pictureBox.Image = Unknown_User;
            UserMode = true;
            Bind_Partner_DataGridView();
        }

        private void Partner_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                //Check if click is on specific column 
                if (Partner_DataGridView.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int ID = int.Parse(Partner_DataGridView.Rows[e.RowIndex].Cells["Partner_ID"].Value.ToString());
                        string Partner_Name = Partner_DataGridView.Rows[e.RowIndex].Cells["Partner"].Value.ToString();
                        pa.Delete_Partner(ID, Partner_Name, this.Name);
                        MessageBox.Show("تم الحذف بنجاح", "Confirmation");
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
                if (ex.Message.Contains("Cannot delete or update a parent row"))
                    MessageBox.Show("لا يمكن حذف هذا الشريك بسبب ارتباطه مع عائلات أو توزيعات", "Error");
                else
                    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Partner_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
                        if (Partner_DataGridView.Rows[e.RowIndex].Cells["Partner"].Value == null || string.IsNullOrWhiteSpace(Partner_DataGridView.Rows[e.RowIndex].Cells["Partner"].Value.ToString()))
                        {
                            MessageBox.Show("لا يمكن ترك اسم الشريك أو الرمز فارغاً", "Error");
                            return;
                        }
                        if (Partner_DataGridView.Rows[e.RowIndex].Cells["Group"].Value == null || Partner_DataGridView.Rows[e.RowIndex].Cells["Group"].Value.ToString() == "")
                        {
                            MessageBox.Show("الرجاء اختيار المجموعة", "Error");
                            return;
                        }
                        else
                        {
                            int ID = int.Parse(Partner_DataGridView.Rows[e.RowIndex].Cells["Partner_ID"].Value.ToString());
                            string Partner_Name = Partner_DataGridView.Rows[e.RowIndex].Cells["Partner"].Value.ToString();
                            string Partner_Name_EN = Partner_DataGridView.Rows[e.RowIndex].Cells["Partner_EN"].Value.ToString();
                            int Partnergroup_ID = int.Parse(Partner_DataGridView.Rows[e.RowIndex].Cells["Group"].Value.ToString());

                            pa.Update_Partner(ID, Partner_Name, Partner_Name_EN, Partnergroup_ID, this.Name);
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

        private void Partner_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                //Check if click is on specific column 
                if (Partner_DataGridView.Columns[e.ColumnIndex].Name == "Logo")
                {
                    myTh = new Thread(new ThreadStart(CallDialog));
                    myTh.SetApartmentState(ApartmentState.STA);
                    myTh.Start();
                    myTh.Join();

                    DialogResult dialogResult = MessageBox.Show("تأكيد التعديل", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int ID = int.Parse(Partner_DataGridView.Rows[e.RowIndex].Cells["Partner_ID"].Value.ToString());
                        string PartnerName = Partner_DataGridView.Rows[e.RowIndex].Cells["Partner"].Value.ToString();
                        if (Logo_pictureBox.Image != Unknown_User)
                        {
                            PicArr = ImageToByte(Logo_pictureBox.Image);
                        }
                        else
                        {
                            PicArr = null;
                        }
                        pa.Update_Partner_Logo(ID, PartnerName, PicArr, this.Name);
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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("هل تريد حذف جميع البيانات غير المحفوظة؟؟", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Bind_Group_Combobox(false);
                    PartnerName_TextBox.Clear();
                    Logo_pictureBox.Image = Unknown_User;
                    UserMode = true;
                    Bind_Partner_DataGridView();
                }
                else
                {
                    Bind_Group_Combobox(true);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Partner_DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == Partner_DataGridView.NewRowIndex || e.RowIndex < 0)
                return;

            if (Partner_DataGridView.Columns[e.ColumnIndex].Name == "Logo")
            {
                Partner_DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "نقرتين لتغيير الشعار";
            }
        }

        private void Insert_button_MouseEnter(object sender, EventArgs e)
        {
            Insert_button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Insert_button_MouseLeave(object sender, EventArgs e)
        {
            Insert_button.BackgroundImage = F2F_Application.Properties.Resources.button1;

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

        private void Partner_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
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

        private void PartnerNameEN_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z')) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
    }
}
