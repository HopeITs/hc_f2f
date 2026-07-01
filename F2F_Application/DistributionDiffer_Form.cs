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
using System.Drawing;

namespace F2F_Application
{
    public partial class DistributionDiffer_Form : Form
    {
        public DistributionDiffer_Form(Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            
        }

        Main_Form main_form;

        Financial f;
        Categories c;
        Report r;
        bool UserMode;
        string current_distribution, prev_distribution;
        private void DistributionDiffer_Form_Load(object sender, EventArgs e)
        {
            try
            {
                f = new Financial();
                c = new Categories();
                r = new Report();
                Bind_Partner_ComboBox();
                Bind_Donor_ComoBox();
                materialLabel14.ForeColor = Color.White;
                label5.Visible = label6.Visible = total_current.Visible = total_current_value.Visible = total_prev.Visible = total_prev_value.Visible = showCurrent.Visible = showPrev.Visible = Excel_Button.Visible = false;
                current_distribution = prev_distribution = "";
              
                foreach (DataGridViewColumn column in Differ_DataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }
                
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
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

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void Bind_Partner_ComboBox()
        {
            int SelectedDonorValue = 0;
            if (Partner_ComboBox.SelectedValue != null)
                SelectedDonorValue = int.Parse(Partner_ComboBox.SelectedValue.ToString());

            DataTable dt = c.Select_Table("partner", "", true, false);
            UserMode = false;
            Partner_ComboBox.DisplayMember = "name";
            Partner_ComboBox.ValueMember = "id";
            Partner_ComboBox.DataSource = dt;

            if (SelectedDonorValue != 0)
                Partner_ComboBox.SelectedValue = SelectedDonorValue;
            else
                Partner_ComboBox.SelectedIndex = 0;
            UserMode = true;
        }

        private void Donor_ComboBox_Leave(object sender, EventArgs e)
        {
            try
            {
                Bind_Distribution_ComboBox();
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
            int Partner = int.Parse(Partner_ComboBox.SelectedValue.ToString());

            DataTable dt = r.Get_Distributions(Date, Donor, Partner);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("لا يوجد توزيعات لعرضها ", "Error");
                Distribution_ComboBox.DataSource = null;
                Differ_DataGridView.Rows.Clear();
                //Partner_ComboBox.DataSource = null;
                Differ_DataGridView.Columns[0].HeaderText = "موجودة في الحالية وغير موجودة في السابقة";
                Differ_DataGridView.Columns[1].HeaderText = "موجودة في السابقة وغير موجودة في الحالية";
                Differ_DataGridView.DataSource = null;
                label5.Visible = label6.Visible = total_current.Visible = total_current_value.Visible = total_prev.Visible = total_prev_value.Visible = showCurrent.Visible = showPrev.Visible = Excel_Button.Visible = false;


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
        

        private void Donor_ComboBox_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.DataSource = null;
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

        private void Partner_ComboBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if(Donor_ComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("الرجاء اختيار ممول !!");
                }
                else
                {
                    Bind_Distribution_ComboBox();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void Distribution_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void Distribution_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    Fill_Data();
                }
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

        private void Partner_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void Fill_Data()
        {
            DataSet ds1 = new DataSet();
            DataTable dt1, dt2;
            dt1 = dt2 = null;
            if (Distribution_ComboBox.SelectedIndex != -1)
            {
                Differ_DataGridView.Rows.Clear();
                Differ_DataGridView.DataSource = null;
                ds1 = r.Get_Differ_Report((int)Distribution_ComboBox.SelectedValue, (int)Donor_ComboBox.SelectedValue, (int)Partner_ComboBox.SelectedValue);

               
                if(ds1.Tables[0] != null)
                {
                    dt1 = ds1.Tables[0];
                    
                }
                if (ds1.Tables[1] != null)
                {
                     dt2 = ds1.Tables[1];
                }
                
                DataTable dt3 = ds1.Tables[2];
                DataTable dt4 = ds1.Tables[3];
                DataTable dt5 = ds1.Tables[4];
                DataTable dt6 = ds1.Tables[5];
                
                // Determine the number of rows to display (maximum of both datasets)
                int maxRowCount = Math.Max(dt1.Rows.Count, dt2.Rows.Count);

                
                // Populate DataGridView

                for (int i = 0; i < maxRowCount; i++)
                    {
                        if (i < dt1.Rows.Count && i < dt2.Rows.Count)
                        {
                            Differ_DataGridView.Rows.Add(dt1.Rows[i][0], dt2.Rows[i][0]);  // Adjust column index as per your DataTable structure
                        }
                        else if (i < dt1.Rows.Count || dt2.Rows.Count == 0)
                        {
                            Differ_DataGridView.Rows.Add(dt1.Rows[i][0], "");  // Fill with empty string for missing rows in dt2
                        }
                        else if (i < dt2.Rows.Count || dt1.Rows.Count == 0)
                        {
                            Differ_DataGridView.Rows.Add("", dt2.Rows[i][0]);  // Fill with empty string for missing rows in dt1
                        }
                        else
                        {
                            Differ_DataGridView.Rows.Add("", "");  // Fallback case for completely unmatched rows
                        }
                    
                }
                int Partner_ID = int.Parse(Partner_ComboBox.SelectedValue.ToString());

                if(Partner_ID != 0)
                {
                    current_distribution = dt3.Rows[0]["current_dist"].ToString();
                    prev_distribution = dt4.Rows[0]["prev_dist"].ToString();
                    Differ_DataGridView.Columns[0].HeaderText = $" موجودة في {current_distribution}   وغير موجودة في {prev_distribution}                                                 المجموع ( {dt1.Rows.Count} )";
                    Differ_DataGridView.Columns[1].HeaderText = $" موجودة في {prev_distribution}  وغير موجودة في {current_distribution}                                المجموع ( {dt2.Rows.Count} )";

                    total_current.Text = ": " + dt3.Rows[0]["current_dist"].ToString();
                    total_prev.Text = ": " + dt4.Rows[0]["prev_dist"].ToString();
                    total_current_value.Text = dt5.Rows.Count.ToString();
                    total_prev_value.Text = dt6.Rows.Count.ToString();
                    label5.Visible = label6.Visible = total_current.Visible = total_current_value.Visible = total_prev.Visible = total_prev_value.Visible = showCurrent.Visible = showPrev.Visible = Excel_Button.Visible = true;
                }
                else
                {
                    Differ_DataGridView.Columns[0].HeaderText = "موجودة في الحالية وغير موجودة في السابقة";
                    Differ_DataGridView.Columns[1].HeaderText = "موجودة في السابقة وغير موجودة في الحالية";
                    //label5.Visible = label6.Visible = total_current.Visible = total_current_value.Visible = total_prev.Visible = total_prev_value.Visible = showCurrent.Visible = showPrev.Visible = false;
                    label5.Visible = label6.Visible = total_current.Visible = total_current_value.Visible = total_prev.Visible = total_prev_value.Visible = true;
                        showCurrent.Visible = showPrev.Visible = false;
                    Excel_Button.Visible = true;
                    current_distribution = dt3.Rows[0]["current_dist"].ToString();
                    prev_distribution = dt4.Rows[0]["prev_dist"].ToString();
                    total_current.Text = ": " + dt3.Rows[0]["current_dist"].ToString();
                    total_prev.Text = ": " + dt4.Rows[0]["prev_dist"].ToString();
                    total_current_value.Text = dt5.Rows.Count.ToString();
                    total_prev_value.Text = dt6.Rows.Count.ToString();
                    Differ_DataGridView.Columns[0].HeaderText = $" موجودة في {current_distribution}   وغير موجودة في {prev_distribution}                                                 المجموع ( {dt1.Rows.Count} )";
                    Differ_DataGridView.Columns[1].HeaderText = $" موجودة في {prev_distribution}  وغير موجودة في {current_distribution}                                المجموع ( {dt2.Rows.Count} )";

                }


                //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                //{
                //    Differ_DataGridView.Rows.Add();
                //    Differ_DataGridView.Rows[i].Cells["Family_ID"].Value = ds1.Tables[0].Rows[i]["Family_ID"].ToString();
                //    Differ_DataGridView.Rows[i].Cells["Family_ID_Prev"].Value = ds1.Tables[1].Rows[i]["Family_ID_Prev"].ToString();
                //}
                //Differ_DataGridView.DataSource = ds1.Tables[0];

                //dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

                //dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.Font =
                //dataGridView1.Rows[dataGridView1.Rows.Count - 2].DefaultCellStyle.Font =
                //dataGridView1.Rows[dataGridView1.Rows.Count - 3].DefaultCellStyle.Font =
                //dataGridView1.Rows[dataGridView1.Rows.Count - 4].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);


                //dataGridView1.Columns[dataGridView1.Columns.Count - 2].HeaderText = ">= " + dataGridView1.Columns[dataGridView1.Columns.Count - 2].HeaderText;

            }
            Differ_DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      
          
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.DataSource = null;
                UserMode = false;
                Distribution_ComboBox.SelectedIndex = -1;
                UserMode = true;
                Distribution_ComboBox.DataSource = null;
                Bind_Distribution_ComboBox();
               
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.DataSource = null;
                UserMode = false;
                Distribution_ComboBox.SelectedIndex = -1;
                UserMode = true;
                Distribution_ComboBox.DataSource = null;
                Bind_Distribution_ComboBox();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Donor_ComboBox_DrawItem_1(object sender, DrawItemEventArgs e)
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

        private void Partner_ComboBox_DrawItem_1(object sender, DrawItemEventArgs e)
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

        private void Distribution_ComboBox_DrawItem_1(object sender, DrawItemEventArgs e)
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

        private void Distribution_ComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    Fill_Data();
                    //Excel_Button.Visible = true;

                }
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

                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Sheet1");

                        // Add column headers
                        for (int i = 0; i < Differ_DataGridView.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = Differ_DataGridView.Columns[i].HeaderText;
                        }

                        // Add rows
                        int excelRow = 2;
                        for (int i = 0; i < Differ_DataGridView.Rows.Count; i++)
                        {
                            if (Differ_DataGridView.Rows[i].IsNewRow)
                                continue;

                            for (int j = 0; j < Differ_DataGridView.Columns.Count; j++)
                            {
                                object cellValue = Differ_DataGridView.Rows[i].Cells[j].Value;
                                worksheet.Cell(excelRow, j + 1).Value = cellValue == null || cellValue == DBNull.Value ? "" : cellValue.ToString();
                            }
                            excelRow++;
                        }

                        workbook.SaveAs(filepath);

                        workbook.Dispose();
                        Process.Start(filepath);

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
       
        private void ApplyLabelStyles(Label label, IXLCell cell)
        {
            var style = cell.Style;
            style.Font.FontName = label.Font.FontFamily.Name;
            style.Font.FontSize = label.Font.Size;
            style.Font.Bold = label.Font.Bold;
            style.Font.Italic = label.Font.Italic;
            style.Font.Underline = label.Font.Underline ? XLFontUnderlineValues.Single : XLFontUnderlineValues.None;
            style.Font.FontColor = XLColor.FromColor(label.ForeColor);
            style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
            style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            style.Border.TopBorder = XLBorderStyleValues.Thin;
            style.Border.TopBorderColor = XLColor.Black;
            style.Border.BottomBorder = XLBorderStyleValues.Thin;
            style.Border.BottomBorderColor = XLColor.Black;
            style.Border.LeftBorder = XLBorderStyleValues.Thin;
            style.Border.LeftBorderColor = XLColor.Black;
            style.Border.RightBorder = XLBorderStyleValues.Thin;
            style.Border.RightBorderColor = XLColor.Black;
            

        }
       
        private void showPrev_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                int Distribution_ID = int.Parse(Distribution_ComboBox.SelectedValue.ToString());
                int Approved = 1;
                int Partner_ID = int.Parse(Partner_ComboBox.SelectedValue.ToString());
                int Donor_ID = int.Parse(Donor_ComboBox.SelectedValue.ToString());
                DataRowView selectedPartner = Partner_ComboBox.SelectedItem as DataRowView;
                string Partner_Name = selectedPartner["Name"].ToString();
                DataRowView selectedDonor = Donor_ComboBox.SelectedItem as DataRowView;
                string Donor_Name = selectedDonor["Name"].ToString();
                ds = r.Get_Differ_Report(Distribution_ID, Donor_ID, Partner_ID);
                DataTable dt = ds.Tables[3];
                string Date = dt.Rows[0]["date"].ToString();
                string Month = dt.Rows[0]["month"].ToString();
                int Partner_Distribution_ID = (int)dt.Rows[0]["partner_distribution_id"];
                int Distribution_ID_Prev = (int)dt.Rows[0]["id"];
                Signitaure_List_Form Signitaure_List_Form = new Signitaure_List_Form(Partner_ID, Donor_ID, Partner_Name, Donor_Name, Month, Date, Distribution_ID_Prev, Partner_Distribution_ID, Approved, main_form);
                DialogResult dialogResult = Signitaure_List_Form.ShowDialog();
            }
            catch (Exception ex)
            { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }

        }
        

        private void Differ_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        

        private void Differ_DataGridView_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

       
        

        

        private void showCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                int Partner_ID = int.Parse(Partner_ComboBox.SelectedValue.ToString());
                if(Partner_ID != 0)
                {

                
                DataSet ds = new DataSet();
                int Distribution_ID = int.Parse(Distribution_ComboBox.SelectedValue.ToString());
                int Approved = 1;
                
                int Donor_ID = int.Parse(Donor_ComboBox.SelectedValue.ToString());
                DataRowView selectedPartner = Partner_ComboBox.SelectedItem as DataRowView;
                string Partner_Name = selectedPartner["Name"].ToString();
                DataRowView selectedDonor = Donor_ComboBox.SelectedItem as DataRowView;
                string Donor_Name = selectedDonor["Name"].ToString();
                ds = r.Get_Differ_Report(Distribution_ID, Donor_ID, Partner_ID);
                DataTable dt = ds.Tables[2];
                string Date = dt.Rows[0]["date"].ToString();
                string Month = dt.Rows[0]["month"].ToString();
                int Partner_Distribution_ID = (int)dt.Rows[0]["partner_distribution_id"];
                Signitaure_List_Form Signitaure_List_Form = new Signitaure_List_Form(Partner_ID, Donor_ID, Partner_Name, Donor_Name, Month, Date, Distribution_ID, Partner_Distribution_ID, Approved, main_form);
                DialogResult dialogResult = Signitaure_List_Form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("يجب اختيار شريك لرؤية العائلات المرتبطة بهذه التوزيعة");
                }
            }
            catch (Exception ex)
            { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }
           
        }
    }
  
}
