using ClosedXML.Excel;
using F2F_Application.Classes;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Report_Form : Form
    {
        public Report_Form(Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;

            dataGridView1.DoubleBuffered(true);
            dataGridView2.DoubleBuffered(true);

            Excel_Button.Visible = false;
        }

        Main_Form main_form;
        Financial f; Categories c;
        bool UserMode;

        private void Report_Load(object sender, EventArgs e)
        {
            try
            {
                f = new Financial();
                c = new Categories();
                //Bind_Distribution_ComboBox();
                Bind_Donor_ComoBox();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Report_Form_Shown(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(this.Width - 10, 1050);

        }

        private void Bind_Donor_ComoBox()
        {
            int SelectedDonorValue = 0;
            if (Donor_ComboBox.SelectedValue != null)
                SelectedDonorValue = int.Parse(Donor_ComboBox.SelectedValue.ToString());

            DataTable dt = c.Select_Table("donor", "", true, false);
            UserMode = false;
            Donor_ComboBox.DisplayMember = "name";
            Donor_ComboBox.ValueMember = "id";
            Donor_ComboBox.DataSource = dt;

            if (SelectedDonorValue != 0)
                Donor_ComboBox.SelectedValue = SelectedDonorValue;
            else
                Donor_ComboBox.SelectedIndex = 0;
            UserMode = true;
        }

        private void Fill_Data()
        {
            DataSet ds = new DataSet();
            if(Distribution_ComboBox.SelectedIndex != -1)
            {
                if (PerGroup_RadioButton.Checked)
                {
                    ds = f.Get_Financial_Report((int)Distribution_ComboBox.SelectedValue, true);
                }
                else if (!PerGroup_RadioButton.Checked)
                {
                    ds = f.Get_Financial_Report((int)Distribution_ComboBox.SelectedValue, false);
                }
                //dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = ds.Tables[1];
                //dataGridView1.ColumnHeadersVisible = true;

                //dataGridView2.ColumnHeadersVisible = false;
                dataGridView2.DataSource = null;
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = ds.Tables[0];
                //dataGridView2.ColumnHeadersVisible = true;

                dataGridView1.Columns["Group Name"].AutoSizeMode = dataGridView2.Columns["Group Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                dataGridView2.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

                dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.Font =
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].DefaultCellStyle.Font =
                    dataGridView1.Rows[dataGridView1.Rows.Count - 3].DefaultCellStyle.Font =
                    dataGridView1.Rows[dataGridView1.Rows.Count - 4].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);


                dataGridView2.Columns[dataGridView2.Columns.Count - 1].DefaultCellStyle.Font =
                    dataGridView2.Columns[dataGridView2.Columns.Count - 2].DefaultCellStyle.Font =
                    dataGridView2.Columns[dataGridView2.Columns.Count - 3].DefaultCellStyle.Font = new Font(dataGridView2.Font, FontStyle.Bold);


                dataGridView1.Columns[dataGridView1.Columns.Count - 2].HeaderText = ">= " + dataGridView1.Columns[dataGridView1.Columns.Count - 2].HeaderText;
                dataGridView2.Columns[dataGridView2.Columns.Count - 4].HeaderText = ">= " + dataGridView2.Columns[dataGridView2.Columns.Count - 4].HeaderText;

            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = dataGridView2.DataSource = null;
                UserMode = false;
                Distribution_ComboBox.SelectedIndex = -1;
                UserMode = true;
                Distribution_ComboBox.DataSource = null;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            try
            {
                //Bind_Distribution_ComboBox();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Bind_Distribution_ComboBox()
        {
            int SelectedValue = -1;
            if (Distribution_ComboBox.SelectedValue != null)
                SelectedValue = int.Parse(Distribution_ComboBox.SelectedValue.ToString());

            UserMode = false;
            string Date = dateTimePicker1.Value.ToString("dd/MM/yyyy", new CultureInfo("en-GB"));
            int Donor = int.Parse(Donor_ComboBox.SelectedValue.ToString());

            DataTable dt = f.Get_Approved_Distributions(Date,Donor);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("لا يوجد توزيعات لعرضها ", "Error");
                Distribution_ComboBox.DataSource = null;
                UserMode = true;
            }
            else
            {
                Distribution_ComboBox.DataSource = null;
                Distribution_ComboBox.DataSource = dt;
                Distribution_ComboBox.DisplayMember = "name";
                Distribution_ComboBox.ValueMember = "id";
                if (SelectedValue != -1)
                    Distribution_ComboBox.SelectedValue = SelectedValue;
                else
                    Distribution_ComboBox.SelectedIndex = -1;
            }
            Distribution_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            UserMode = true;
        }

        private void Distribution_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    Fill_Data();
                    Excel_Button.Visible = true;

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

        protected override Point ScrollToControl(Control activeControl) //STOP AUTO SCROLL
        {
            Point pt = this.AutoScrollPosition;
            return pt;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tableLayoutPanel1.Size = new Size(this.Width - 10, 1050);
                Bind_Distribution_ComboBox();
                Fill_Data();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
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

                    DataTable dt1 = ((DataTable)dataGridView1.DataSource).DefaultView.ToTable();
                    DataTable dt2 = ((DataTable)dataGridView2.DataSource).DefaultView.ToTable();


                    wb.Worksheets.Add(dt1, "Sheet_1");
                    wb.Worksheets.Add(dt2, "Sheet_2");

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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex > 1)
            {
                if (e.RowIndex >= dataGridView1.Rows.Count - 1)
                {
                    if (e.Value != null && e.Value != DBNull.Value && e.Value != "")
                    {
                        decimal value = decimal.Parse(e.Value.ToString());

                        e.Value = value.ToString("C2", CultureInfo.GetCultureInfo("en-US"));

                        e.FormattingApplied = true;
                    }
                }
                else if (e.RowIndex >= dataGridView1.Rows.Count - 3)
                {
                    if (e.Value != null && e.Value != DBNull.Value && e.Value != "")
                    {
                        decimal value = decimal.Parse(e.Value.ToString());

                        e.Value = value.ToString("N2");

                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 1)
            {
                if (e.ColumnIndex == dataGridView2.Columns.Count - 2)
                {

                    if (e.Value != null && e.Value != DBNull.Value && e.Value != "")
                    {
                        decimal value = decimal.Parse(e.Value.ToString());

                        e.Value = value.ToString("C2", CultureInfo.GetCultureInfo("en-US"));

                        e.FormattingApplied = true;
                    }
                }
                else
                {
                    if (e.Value != null && e.Value != DBNull.Value && e.Value != "")
                    {
                        decimal value = decimal.Parse(e.Value.ToString());

                        e.Value = value.ToString("N2");

                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void PerGroup_RadioButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (!PerGroup_RadioButton.Checked)
                        PerGroup_RadioButton.Checked = true;
                    else
                        PerGroup_RadioButton.Checked = false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void PerGroup_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Distribution_ComboBox.SelectedIndex >= 0)
                    Fill_Data();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Donor_ComboBox_Leave(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = dataGridView2.DataSource = null;
                Bind_Distribution_ComboBox();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Donor_ComboBox_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = dataGridView2.DataSource = null;
                UserMode = false;
                Distribution_ComboBox.SelectedIndex = -1;
                UserMode = true;
                Distribution_ComboBox.DataSource = null;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Donor_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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
