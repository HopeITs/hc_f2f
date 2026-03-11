using ClosedXML.Excel;
using F2F_Application.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Schedule_Form : Form
    {
        public Schedule_Form(Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        Main_Form main_form;
        Distribution d; Partner P; Categories c;

        private void Schedule_Form_Load(object sender, EventArgs e)
        {
            try
            {
                d = new Distribution();
                P = new Partner();
                c = new Categories();
                Bind_ComboBox(DonorSchedule_ComboBox, false);
                Bind_Schedule_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم هذه الصفحة بسبب الخطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }
        private void Bind_ComboBox(ComboBox Combox_Name, bool KeepSelection)
        {
            List<string> From_Tables = new List<string> { "donor" };
            DataSet Tables = c.Select_Tables(From_Tables, true);
            DataTable dt = Tables.Tables[0];

            int SelectedValue = 0;

            if (Combox_Name.SelectedValue != null)
                SelectedValue = int.Parse(Combox_Name.SelectedValue.ToString());

            Combox_Name.DisplayMember = "name";
            Combox_Name.ValueMember = "id";
            Combox_Name.DataSource = dt;
            

            if (KeepSelection && SelectedValue != 0)
                Combox_Name.SelectedValue = SelectedValue;
            else
                Combox_Name.SelectedIndex = 0;

            Combox_Name.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void Bind_Schedule_DataGridView()
        {
            int Donor_ID = DonorSchedule_ComboBox.SelectedIndex == -1 ? 0 : int.Parse(DonorSchedule_ComboBox.SelectedValue.ToString());
            string Year = dateTimePicker1.Value.ToString("yyyy", new CultureInfo("en-GB"));
            DataTable dt = d.Get_Work_Schedule(Year,Donor_ID);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("لا يوجد توزيعات لعرضها في هذا العام", "Error");
                Schedule_DataGridView.DataSource = null;
            }
            else
            {
                Schedule_DataGridView.ColumnHeadersVisible = false;
                Schedule_DataGridView.DataSource = null;
                Schedule_DataGridView.Columns.Clear();
                Schedule_DataGridView.DataSource = dt;
                Schedule_DataGridView.ColumnHeadersVisible = true;
            }
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            try
            {
                Bind_Schedule_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Schedule_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == Schedule_DataGridView.NewRowIndex || e.RowIndex < 0 || Schedule_DataGridView.Columns[e.ColumnIndex].HeaderText == "Partner"
                    || Schedule_DataGridView.Columns[e.ColumnIndex].HeaderText == "Donor")
                    return;
                if (Schedule_DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && !string.IsNullOrWhiteSpace(Schedule_DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    string Partner_Name = Schedule_DataGridView.Rows[e.RowIndex].Cells["Partner"].Value.ToString();
                    string Donor_Name = Schedule_DataGridView.Rows[e.RowIndex].Cells["Donor"].Value.ToString();
                    string Distribution_Name = Schedule_DataGridView.Columns[e.ColumnIndex].HeaderText;
                    DataTable dt = P.Get_Partner_Distribution_ID(Partner_Name,Donor_Name, Distribution_Name);

                    int partner_donor_id = dt.Rows[0].Field<int>("partner_donor_id");
                    int Distribution_ID = dt.Rows[0].Field<int>("distribution_id");
                    int Partner_Distribution_ID = dt.Rows[0].Field<int>("partner_distribution_id");

                    Partner_Distribution_Date_Form Partner_Distribution_Date_Form = new Partner_Distribution_Date_Form(partner_donor_id, Distribution_ID, Partner_Distribution_ID, main_form);
                    DialogResult dialogResult = Partner_Distribution_Date_Form.ShowDialog();
                    if (dialogResult == DialogResult.Yes)
                    {
                        Bind_Schedule_DataGridView();
                    }
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
                Bind_Schedule_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Schedule_DataGridView_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex == Schedule_DataGridView.NewRowIndex || e.RowIndex < 0)
                return;

            if (Schedule_DataGridView.Columns[e.ColumnIndex].HeaderText != "Partner")
            {
                e.ToolTipText = "نقرتين لعرض وتعديل التواريخ";
            }
        }

        private void Excel_Button_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel |*.xlsx";
                saveFileDialog1.Title = "Export as Excel";
                DialogResult res = saveFileDialog1.ShowDialog();
                string filepath = "";

                if (res == DialogResult.OK)
                {
                    // If the file name is not an empty string open it for saving.  
                    if (!string.IsNullOrWhiteSpace(saveFileDialog1.FileName))
                    {
                        System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                        filepath = saveFileDialog1.FileName;
                        fs.Close();
                    }
                }

                if (!string.IsNullOrWhiteSpace(filepath))
                {

                    XLWorkbook wb = new XLWorkbook();

                    DataTable dt = ((DataTable)Schedule_DataGridView.DataSource).DefaultView.ToTable();

                    wb.Worksheets.Add(dt, "Work Schedule - " + dateTimePicker1.Text);
                    wb.SaveAs(filepath);
                    wb.Dispose();
                    Process.Start(filepath);

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void Excel_Button_MouseEnter(object sender, EventArgs e)
        {
            Excel_Button.BackgroundImage = F2F_Application.Properties.Resources.Export_2;

        }

        private void Excel_Button_MouseLeave(object sender, EventArgs e)
        {
            Excel_Button.BackgroundImage = F2F_Application.Properties.Resources.Export_1;

        }

        private void DonorSchedule_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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
        //private void Bind_Donor_ComoBox()
        //{
        //    int SelectedDonorValue = 0;
        //    if (DonorSchedule_ComboBox.SelectedValue != null)
        //        SelectedDonorValue = int.Parse(DonorSchedule_ComboBox.SelectedValue.ToString());

        //    DataTable dt = c.Select_Table("donor", "", true, false);
        //    DonorSchedule_ComboBox.DataSource = dt;
        //    DonorSchedule_ComboBox.DisplayMember = "name";
        //    DonorSchedule_ComboBox.ValueMember = "id";
        //    if (SelectedDonorValue != 0)
        //        DonorSchedule_ComboBox.SelectedValue = SelectedDonorValue;
        //    else
        //        DonorSchedule_ComboBox.SelectedIndex = 0;
        //}

        private void DonorSchedule_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Bind_Schedule_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
    }
}
