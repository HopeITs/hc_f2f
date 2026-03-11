using F2F_Application.Classes;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Partner_Distribution_Date_Form : MaterialForm
    {
        public Partner_Distribution_Date_Form(int Partner_ID, int Distribution_ID, int Partner_Distribution_ID, Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.Partner_ID = Partner_ID;
            this.Distribution_ID = Distribution_ID;
            this.Partner_Distribution_ID = Partner_Distribution_ID;
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(activeScreenDimensions.Width, activeScreenDimensions.Height);
        }
        Main_Form main_form;
        int Partner_ID, Distribution_ID, Partner_Distribution_ID;
        Partner p;
        bool DataApproved = false;
        DateTimePicker DatePicker2, TimePicker2;
        bool UserMode;
        int BeginEdit_RowIndex = -1, BeginEdit_ColumnIndex = -1;

        private void Partner_Distribution_Time_Form_Load(object sender, EventArgs e)
        {
            try
            {
                p = new Partner();
                Set_Controls();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم هذه الصفحة بسبب الخطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Set_Controls()
        {
            DatePicker.Value = DateTime.Now;
            TimePicker.Value = DateTime.Now;
            Bind_Date_DataGridView();
        }

        private void Bind_Date_DataGridView()
        {
            UserMode = false;
            DataTable dt = p.Get_Partner_Distribution_Dates(Partner_Distribution_ID);
            Date_DataGridView.Rows.Clear();
            Date_DataGridView.AllowUserToAddRows = true;

            DatePicker2 = new DateTimePicker();
            DatePicker2.ShowUpDown = false;
            /*
            DatePicker2.CustomFormat = "dd/MM/yyyy";
            DatePicker2.Format = DateTimePickerFormat.Custom;*/
            DatePicker2.Format = DateTimePickerFormat.Short;
            DatePicker2.Visible = false;
            Rectangle oRectangle1 = Date_DataGridView.GetCellDisplayRectangle(3, 0, true);
            DatePicker2.Size = new Size(oRectangle1.Width, oRectangle1.Height);
            DatePicker2.Location = new Point(oRectangle1.X, oRectangle1.Y);
            //DatePicker2.RightToLeft = RightToLeft.Yes;
            DatePicker2.RightToLeftLayout = true;
            Date_DataGridView.Controls.Add(DatePicker2);
            DatePicker2.Leave += this.DatePickerChange2;


            TimePicker2 = new DateTimePicker();
            TimePicker2.ShowUpDown = true;
            /*
            TimePicker2.CustomFormat = "hh:mm tt";
            TimePicker2.Format = DateTimePickerFormat.Custom;*/
            TimePicker2.Format = DateTimePickerFormat.Time;
            TimePicker2.Visible = false;
            Rectangle oRectangle2 = Date_DataGridView.GetCellDisplayRectangle(2, 0, true);
            TimePicker2.Size = new Size(oRectangle2.Width, oRectangle2.Height);
            TimePicker2.Location = new Point(oRectangle2.X, oRectangle2.Y);
            //TimePicker2.RightToLeft = RightToLeft.Yes;
            TimePicker2.RightToLeftLayout = true;
            Date_DataGridView.Controls.Add(TimePicker2);
            TimePicker2.Leave += this.TimePickerChange2;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Date_DataGridView.Rows.Add();
                Date_DataGridView.Rows[i].Cells["partner_distribution_date_id"].Value = dt.Rows[i].Field<int>("id");
                DateTime Date = DateTime.Parse(dt.Rows[i].Field<DateTime>("date").ToString(), CultureInfo.CurrentCulture);
                Date_DataGridView.Rows[i].Cells["Date"].Value = Date.ToShortDateString();
                DateTime Time = DateTime.Parse(dt.Rows[i].Field<string>("time").ToString(), CultureInfo.CurrentCulture);
                Date_DataGridView.Rows[i].Cells["Time"].Value = Time.ToShortTimeString();
            }

            Date_DataGridView.AllowUserToAddRows = false;
            UserMode = true;
        }

        private void DatePickerChange2(object sender, EventArgs e)
        {
            try
            {
                DateTime Date = DateTime.Parse(DatePicker2.Text, CultureInfo.CurrentCulture);
                Date_DataGridView.Rows[BeginEdit_RowIndex].Cells[BeginEdit_ColumnIndex].Value = Date.ToShortDateString();
                DatePicker2.Visible = false;
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void TimePickerChange2(object sender, EventArgs e)
        {
            try
            {
                DateTime Date = DateTime.Parse(TimePicker2.Text, CultureInfo.CurrentCulture);
                Date_DataGridView.Rows[BeginEdit_RowIndex].Cells[BeginEdit_ColumnIndex].Value = Date.ToShortTimeString();
                TimePicker2.Visible = false;
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Date_DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (Date_DataGridView.Columns[e.ColumnIndex].HeaderText == "التاريخ")
                {
                    BeginEdit_RowIndex = e.RowIndex; BeginEdit_ColumnIndex = e.ColumnIndex;

                    DatePicker2.Location = Date_DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    DatePicker2.Visible = true;
                    if (Date_DataGridView.CurrentCell.Value != DBNull.Value && Date_DataGridView.CurrentCell.Value != null)
                    {
                        DateTime Date = DateTime.Parse(Date_DataGridView.CurrentCell.Value.ToString());
                        DatePicker2.Value = DateTime.Parse(Date.ToShortDateString(), CultureInfo.CurrentCulture);
                    }
                    else
                    {

                    }
                }
                else if (Date_DataGridView.Columns[e.ColumnIndex].HeaderText == "الوقت")
                {
                    BeginEdit_RowIndex = e.RowIndex; BeginEdit_ColumnIndex = e.ColumnIndex;

                    TimePicker2.Location = Date_DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    TimePicker2.Visible = true;
                    if (Date_DataGridView.CurrentCell.Value != DBNull.Value && Date_DataGridView.CurrentCell.Value != null)
                    {
                        DateTime Time = DateTime.Parse(Date_DataGridView.CurrentCell.Value.ToString());
                        TimePicker2.Value = DateTime.Parse(Time.ToShortTimeString(), CultureInfo.CurrentCulture);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Date_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void Date_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == Date_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == Date_DataGridView.Columns["Delete"].Index)
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

        private void Partner_Distribution_Date_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void Date_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    //if click is on new row or header row
                    if (e.RowIndex < 0 || e.ColumnIndex < 0)
                        return;

                    if (Date_DataGridView.Columns[e.ColumnIndex].HeaderText == "التاريخ")
                    {
                        //Date_DataGridView.CurrentCell.Value = DatePicker2.Text;

                        DatePicker2.Visible = false;
                    }
                    else if (Date_DataGridView.Columns[e.ColumnIndex].HeaderText == "الوقت")
                    {
                        //Date_DataGridView.CurrentCell.Value = TimePicker2.Text;

                        TimePicker2.Visible = false;
                    }

                    DialogResult dialogResult = MessageBox.Show("تأكيد التعديل", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Date_DataGridView.Rows[e.RowIndex].Cells["Date"].Value == null || string.IsNullOrWhiteSpace(Date_DataGridView.Rows[e.RowIndex].Cells["Date"].Value.ToString())
                            || Date_DataGridView.Rows[e.RowIndex].Cells["Time"].Value == null || string.IsNullOrWhiteSpace(Date_DataGridView.Rows[e.RowIndex].Cells["Time"].Value.ToString()))
                        {
                            MessageBox.Show("لا يمكن ترك التاريخ أو الوقت فارغاً فارغة", "Error");
                            return;
                        }
                        else
                        {
                            int ID = int.Parse(Date_DataGridView.Rows[e.RowIndex].Cells["partner_distribution_date_id"].Value.ToString());
                            DateTime Date = DateTime.Parse(Date_DataGridView.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                            string UK_Date = Date.ToString("dd/MM/yyyy", new CultureInfo("en-GB"));
                            DateTime Time = DateTime.Parse(Date_DataGridView.Rows[e.RowIndex].Cells["Time"].Value.ToString());
                            string UK_Time = Time.ToString("hh:mm tt", new CultureInfo("en-GB"));

                            p.Update_Partner_Distribution_Date(ID, Partner_ID, Distribution_ID, UK_Date, UK_Time, this.Name);
                            MessageBox.Show("تم تعديل التاريخ بنجاح", "Confirmation");
                        }
                    }
                    Set_Controls();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Set_Controls();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
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

        private void Insert_button_Click(object sender, EventArgs e)
        {
            try
            {
                DataApproved = false;
                DataApproved = Check_Data();
                if (DataApproved)
                {
                    DateTime Date = DateTime.Parse(DatePicker.Value.ToString());
                    string UK_Date = Date.ToString("dd/MM/yyyy", new CultureInfo("en-GB")); ;
                    DateTime Time = DateTime.Parse(TimePicker.Value.ToString());
                    string UK_Time = Time.ToString("hh:mm tt", new CultureInfo("en-GB"));
                    p.Insert_Partner_Distribution_Date(Partner_ID, Distribution_ID, Partner_Distribution_ID, UK_Date, UK_Time, this.Name);
                    MessageBox.Show("تم إدخال التاريخ بنجاح", "Confirmation");

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

        private bool Check_Data()
        {
            if (DatePicker.Value == null)
            {
                MessageBox.Show("لا يمكن ترك التاريخ فارغاً", "Error");
                return false;
            }
            if (TimePicker.Value == null)
            {
                MessageBox.Show("لا يمكن ترك التاريخ فارغاً", "Error");
                return false;
            }
            return true;
        }

        private void Date_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                //Check if click is on specific column 
                if (Date_DataGridView.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int ID = int.Parse(Date_DataGridView.Rows[e.RowIndex].Cells["partner_distribution_date_id"].Value.ToString());
                        p.Delete_Partner_Distribution_Date(ID, Partner_ID, Distribution_ID, this.Name);
                        MessageBox.Show("تم حذف التاريخ بنجاح", "Confirmation");
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
    }
}
