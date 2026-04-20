using ClosedXML.Excel;
using F2F_Application.Classes;
using MaterialSkinPlus.Controls;
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
    public partial class DistribtionAgeGender_Form : Form
    {
        public DistribtionAgeGender_Form(Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;

            //dataGridView1.DoubleBuffered(true);

            //Excel_Button.Visible = false;
        }
        Main_Form main_form;

        Financial f;
        Categories c;
        Report r;
        Distribution d;
        bool UserMode;

        private void DistribtionAgeGender_Load(object sender, EventArgs e)
        {
            try
            {
                f = new Financial();
                c = new Categories();
                r = new Report();
                d = new Distribution() ;
                Bind_Partner_ComboBox();
                Bind_Donor_ComoBox();
                materialLabel13.ForeColor = Color.White;
                materialLabel10.ForeColor = Color.FromArgb(0, 75, 75);
                materialLabel11.ForeColor = Color.FromArgb(0, 75, 75);
                materialLabel8.ForeColor = Color.FromArgb(0, 75, 75);
                materialLabel9.ForeColor = Color.FromArgb(0, 75, 75);
                materialLabel12.ForeColor = Color.FromArgb(0, 75, 75);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }
        private void Discrimination_Form_Shown(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(this.Width - 10, 1050);

        }
        //private void Bind_Donor_ComoBox()
        //{
        //    int SelectedDonorValue = 0;
        //    if (Donor_ComboBox.SelectedValue != null)
        //        SelectedDonorValue = int.Parse(Donor_ComboBox.SelectedValue.ToString());

        //    DataTable dt = c.Select_Table("donor", "", true, false);
        //    UserMode = false;
        //    Donor_ComboBox.DisplayMember = "name";
        //    Donor_ComboBox.ValueMember = "id";
        //    Donor_ComboBox.DataSource = dt;

        //    if (SelectedDonorValue != 0)
        //        Donor_ComboBox.SelectedValue = SelectedDonorValue;
        //    else
        //        Donor_ComboBox.SelectedIndex = 0;
        //    UserMode = true;
        //}


        private void Bind_Partner_ComboBox()
        {
            int SelectedValue = -1;
            if (Partner_ComboBox.SelectedValue != null)
                SelectedValue = int.Parse(Partner_ComboBox.SelectedValue.ToString());

            DataTable dt = c.Select_Table("partner", "", true, false);
            UserMode = false;
            Partner_ComboBox.DataSource = dt;
            Partner_ComboBox.DisplayMember = "name";
            Partner_ComboBox.ValueMember = "id";
            if (SelectedValue != -1)
                Partner_ComboBox.SelectedValue = SelectedValue;
            else
                Partner_ComboBox.SelectedIndex = -1;
            UserMode = true;
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

        private void Bind_Distribution_ComboBox()
        {
            int SelectedValue = -1;
            if (Distribution_ComboBox.SelectedValue != null)
                SelectedValue = int.Parse(Distribution_ComboBox.SelectedValue.ToString());

            UserMode = false;
            string Date = dateTimePicker1.Value.ToString("dd/MM/yyyy", new CultureInfo("en-GB"));

            DataTable dt = d.Get_All_Distributions(Date);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("لا يوجد توزيعات لعرضها في هذا العام", "Error");
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
            UserMode = true;
        }

        //private void Bind_Partner_ComboBox()
        //{
        //    int SelectedDonorValue = 0;
        //    if (Partner_ComboBox.SelectedValue != null)
        //        SelectedDonorValue = int.Parse(Partner_ComboBox.SelectedValue.ToString());

        //    DataTable dt = c.Select_Table("partner", "", true, false);
        //    UserMode = false;
        //    Partner_ComboBox.DisplayMember = "name";
        //    Partner_ComboBox.ValueMember = "id";
        //    Partner_ComboBox.DataSource = dt;

        //    if (SelectedDonorValue != 0)
        //        Partner_ComboBox.SelectedValue = SelectedDonorValue;
        //    else
        //        Partner_ComboBox.SelectedIndex = 0;
        //    UserMode = true;
        //}

        private void Donor_ComboBox_Leave(object sender, EventArgs e)
        {

        }

        //private void Bind_Distribution_ComboBox()
        //{
        //    int SelectedValue = -1;
        //    if (Distribution_ComboBox.SelectedValue != null)
        //        SelectedValue = int.Parse(Distribution_ComboBox.SelectedValue.ToString());

        //    UserMode = false;
        //    string Date = dateTimePicker1.Value.ToString("dd/MM/yyyy", new CultureInfo("en-GB"));
        //    int Donor = int.Parse(Donor_ComboBox.SelectedValue.ToString());
        //    int Partner = int.Parse(Partner_ComboBox.SelectedValue.ToString());

        //    DataTable dt = r.Get_Distributions(Date, Donor, Partner);

        //    if (dt.Rows.Count <= 0)
        //    {
        //        MessageBox.Show("لا يوجد توزيعات لعرضها ", "Error");
        //        Distribution_ComboBox.DataSource = null;
        //        toddlersMale.Text = nottoddlersMale.Text = toddlersFemale.Text = nottoddlersFemale.Text = totalToddlers.Text = nottotalToddlers.Text =
        //        youthMale.Text = notyouthfemale.Text = youthFemale.Text = notYouthMale.Text = totalyouth.Text = nottotal.Text =
        //            youthmale60.Text = notyouthfemale60.Text = youthfemale60.Text = notyouthmale60.Text = totalyouth60.Text = nottotalyouth60.Text =
        //            elderliesMale.Text = notelderliesMale.Text = elderliesFemale.Text = notelderliesFemale.Text = elderliesTotal.Text = notelderliestotal.Text =
        //            elderliesMale60.Text = notelderliesMale60.Text = elderliesFemale60.Text = notelderliesFemale60.Text = totalelderlies60.Text = nottotalelderlies60.Text
        //        = childrenMale.Text = notchildrenMale.Text = childrenFemale.Text = notchildrenFemale.Text = totalChildren.Text = nottotalChildren.Text = below18Male.Text =
        //        notbelow18Male.Text = below18Female.Text = notbelow18Female.Text = totalBelow18.Text = nottotalBelow18.Text = below19Male.Text = notbelow19Male.Text = below19Female.Text =
        //        notbelow19Female.Text = totalBelow19.Text = nottotalBelow19.Text = totalMale.Text = nottotalMale.Text = totalFemale.Text = nottotalFemale.Text = total.Text = nottotal.Text = "";
        //        UserMode = true;
        //    }
        //    else
        //    {
        //        Distribution_ComboBox.DataSource = null;
        //        Distribution_ComboBox.DataSource = dt;
        //        Distribution_ComboBox.DisplayMember = "name";
        //        Distribution_ComboBox.ValueMember = "id";
        //        if (SelectedValue != -1)
        //            Distribution_ComboBox.SelectedValue = SelectedValue;
        //        else
        //            Distribution_ComboBox.SelectedIndex = -1;
        //    }
        //    Distribution_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
        //    UserMode = true;
        //}

        private void Distribution_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void Excel_Button_MouseEnter(object sender, EventArgs e)
        {
            //Excel_Button.BackgroundImage = F2F_Application.Properties.Resources.Export_2;

        }

        private void Excel_Button_MouseLeave(object sender, EventArgs e)
        {
            //Excel_Button.BackgroundImage = F2F_Application.Properties.Resources.Export_1;

        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            //if (e.ColumnIndex > 1)
            //{
            //    if (e.RowIndex >= dataGridView1.Rows.Count - 1)
            //    {
            //        if (e.Value != null && e.Value != DBNull.Value && e.Value != "")
            //        {
            //            decimal value = decimal.Parse(e.Value.ToString());

            //            e.Value = value.ToString("C2", CultureInfo.GetCultureInfo("en-US"));

            //            e.FormattingApplied = true;
            //        }
            //    }
            //    else if (e.RowIndex >= dataGridView1.Rows.Count - 3)
            //    {
            //        if (e.Value != null && e.Value != DBNull.Value && e.Value != "")
            //        {
            //            decimal value = decimal.Parse(e.Value.ToString());

            //            e.Value = value.ToString("N2");

            //            e.FormattingApplied = true;
            //        }
            //    }
            //}
        }
        private void Donor_ComboBox_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    //Bind_Partner_Distribution();
                    Bind_Distribution_ComboBox();
                    Bind_Donor_ComoBox();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        //private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Temporarily suspend user-mode to avoid auto-fill side-effects
        //        UserMode = false;

        //        // Clear current distribution selection and datasource so the combo resets
        //        Distribution_ComboBox.DataSource = null;
        //        Distribution_ComboBox.SelectedIndex = -1;
        //        // SelectedValue = 0 may be useful where code expects numeric 0 for "N/A"
        //        try { Distribution_ComboBox.SelectedValue = 0; } catch { /* ignore if not applicable */ }

        //        UserMode = true;

        //        // Re-bind list for the new date (will leave selection empty)
        //        Bind_Distribution_ComboBox();

        //        // If you added an Apply button, keep it disabled until user chooses a distribution
        //        //if (this.Controls.ContainsKey("Apply_Button"))
        //        //    Apply_Button.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL"))
        //            MessageBox.Show("please check your network and try again", "Error");
        //        else if (ex.Message.Contains("host"))
        //            MessageBox.Show("please check the server or your network connection and try again", "Error");
        //        else
        //            MessageBox.Show(ex.Message, "Error");
        //    }
        //}


        private void Fill_Data()
        {
            DataSet ds = new DataSet();
            if (Distribution_ComboBox.SelectedIndex != -1)
            {
                ds = r.Get_Families_Distribution_Report((int)Distribution_ComboBox.SelectedValue, (int)Donor_ComboBox.SelectedValue, (int)Partner_ComboBox.SelectedValue);
                toddlersMale.Text = ds.Tables[0].Rows[0]["count"].ToString();
                nottoddlersMale.Text = ds.Tables[1].Rows[0]["count"].ToString();
                toddlersFemale.Text = ds.Tables[2].Rows[0]["count"].ToString();
                nottoddlersFemale.Text = ds.Tables[3].Rows[0]["count"].ToString();
                totalToddlers.Text = ds.Tables[4].Rows[0]["count"].ToString();
                nottotalToddlers.Text = ds.Tables[5].Rows[0]["count"].ToString();


                childrenMale.Text = ds.Tables[6].Rows[0]["count"].ToString();
                notchildrenMale.Text = ds.Tables[7].Rows[0]["count"].ToString();
                childrenFemale.Text = ds.Tables[8].Rows[0]["count"].ToString();
                notchildrenFemale.Text = ds.Tables[9].Rows[0]["count"].ToString();
                totalChildren.Text = ds.Tables[10].Rows[0]["count"].ToString();
                nottotalChildren.Text = ds.Tables[11].Rows[0]["count"].ToString();

                youthMale.Text = ds.Tables[12].Rows[0]["count"].ToString();
                notYouthMale.Text = ds.Tables[13].Rows[0]["count"].ToString();
                youthFemale.Text = ds.Tables[14].Rows[0]["count"].ToString();
                notyouthfemale.Text = ds.Tables[15].Rows[0]["count"].ToString();
                totalyouth.Text = ds.Tables[16].Rows[0]["count"].ToString();
                nottotalyouth.Text = ds.Tables[17].Rows[0]["count"].ToString();

                elderliesMale.Text = ds.Tables[18].Rows[0]["count"].ToString();
                notelderliesMale.Text = ds.Tables[19].Rows[0]["count"].ToString();
                elderliesFemale.Text = ds.Tables[20].Rows[0]["count"].ToString();
                notelderliesFemale.Text = ds.Tables[21].Rows[0]["count"].ToString();
                elderliesTotal.Text = ds.Tables[22].Rows[0]["count"].ToString();
                notelderliestotal.Text = ds.Tables[23].Rows[0]["count"].ToString();

                totalMale.Text = ds.Tables[24].Rows[0]["count"].ToString();
                nottotalMale.Text = ds.Tables[25].Rows[0]["count"].ToString();
                totalFemale.Text = ds.Tables[26].Rows[0]["count"].ToString();
                nottotalFemale.Text = ds.Tables[27].Rows[0]["count"].ToString();
                total.Text = ds.Tables[28].Rows[0]["count"].ToString();
                nottotal.Text = ds.Tables[29].Rows[0]["count"].ToString();

                below18Male.Text = ds.Tables[30].Rows[0]["count"].ToString();
                notbelow18Male.Text = ds.Tables[31].Rows[0]["count"].ToString();
                below18Female.Text = ds.Tables[32].Rows[0]["count"].ToString();
                notbelow18Female.Text = ds.Tables[33].Rows[0]["count"].ToString();
                totalBelow18.Text = ds.Tables[34].Rows[0]["count"].ToString();
                nottotalBelow18.Text = ds.Tables[35].Rows[0]["count"].ToString();

                below19Male.Text = ds.Tables[36].Rows[0]["count"].ToString();
                notbelow19Male.Text = ds.Tables[37].Rows[0]["count"].ToString();
                below19Female.Text = ds.Tables[38].Rows[0]["count"].ToString();
                notbelow19Female.Text = ds.Tables[39].Rows[0]["count"].ToString();
                totalBelow19.Text = ds.Tables[40].Rows[0]["count"].ToString();
                nottotalBelow19.Text = ds.Tables[41].Rows[0]["count"].ToString();

                youthmale60.Text = ds.Tables[42].Rows[0]["count"].ToString();
                notyouthmale60.Text = ds.Tables[43].Rows[0]["count"].ToString();
                youthfemale60.Text = ds.Tables[44].Rows[0]["count"].ToString();
                notyouthfemale60.Text = ds.Tables[45].Rows[0]["count"].ToString();
                totalyouth60.Text = ds.Tables[46].Rows[0]["count"].ToString();
                nottotalyouth60.Text = ds.Tables[47].Rows[0]["count"].ToString();

                elderliesMale60.Text = ds.Tables[48].Rows[0]["count"].ToString();
                notelderliesMale60.Text = ds.Tables[49].Rows[0]["count"].ToString();
                elderliesFemale60.Text = ds.Tables[50].Rows[0]["count"].ToString();
                notelderliesFemale60.Text = ds.Tables[51].Rows[0]["count"].ToString();
                totalelderlies60.Text = ds.Tables[52].Rows[0]["count"].ToString();
                nottotalelderlies60.Text = ds.Tables[53].Rows[0]["count"].ToString();

                //below18Male.Text = ds.Tables[12].Rows[0]["count"].ToString();
                //notbelow18Male.Text = ds.Tables[13].Rows[0]["count"].ToString();
                //below18Female.Text = ds.Tables[14].Rows[0]["count"].ToString();
                //notbelow18Female.Text = ds.Tables[15].Rows[0]["count"].ToString();
                //totalBelow18.Text = ds.Tables[16].Rows[0]["count"].ToString();
                //nottotalBelow18.Text = ds.Tables[17].Rows[0]["count"].ToString();

                //below19Male.Text = ds.Tables[18].Rows[0]["count"].ToString();
                //notbelow19Male.Text = ds.Tables[19].Rows[0]["count"].ToString();
                //below19Female.Text = ds.Tables[20].Rows[0]["count"].ToString();
                //notbelow19Female.Text = ds.Tables[21].Rows[0]["count"].ToString();
                //totalBelow19.Text = ds.Tables[22].Rows[0]["count"].ToString();
                //nottotalBelow19.Text = ds.Tables[23].Rows[0]["count"].ToString();

                //dataGridView1.DataSource = null;
                //dataGridView1.Columns.Clear();
                //dataGridView1.DataSource = ds.Tables[1];

                //dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

                //dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.Font =
                //dataGridView1.Rows[dataGridView1.Rows.Count - 2].DefaultCellStyle.Font =
                //dataGridView1.Rows[dataGridView1.Rows.Count - 3].DefaultCellStyle.Font =
                //dataGridView1.Rows[dataGridView1.Rows.Count - 4].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);


                //dataGridView1.Columns[dataGridView1.Columns.Count - 2].HeaderText = ">= " + dataGridView1.Columns[dataGridView1.Columns.Count - 2].HeaderText;
            }

        }

        private void Donor_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void Partner_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void Partner_ComboBox_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 1)
            {
                //if (e.RowIndex >= dataGridView1.Rows.Count - 1)
                //{
                //    if (e.Value != null && e.Value != DBNull.Value && e.Value != "")
                //    {
                //        decimal value = decimal.Parse(e.Value.ToString());

                //        e.Value = value.ToString("C2", CultureInfo.GetCultureInfo("en-US"));

                //        e.FormattingApplied = true;
                //    }
                //}
                //else if (e.RowIndex >= dataGridView1.Rows.Count - 3)
                //{
                //    if (e.Value != null && e.Value != DBNull.Value && e.Value != "")
                //    {
                //        decimal value = decimal.Parse(e.Value.ToString());

                //        e.Value = value.ToString("N2");

                //        e.FormattingApplied = true;
                //    }
                //}
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
                    var labels = LivingPanel.Controls.OfType<Label>().ToList();
                    var w = wb.Worksheets.Add("Sheet1");
                    // Write labels to the worksheet
                    // Calculate the position of labels in the Excel sheet
                    foreach (var label in labels)
                    {
                        // Convert the label's position in the panel to Excel row and column
                        int row = label.Top / 20 + 1; // Approximate conversion
                        int column = label.Left / 100 + 1; // Approximate conversion

                        // Calculate column span based on the label's width
                        int colSpan = label.Width / 100; // Approximate conversion

                        // Set the value in the appropriate cell
                        var cell = w.Cell(row, column);
                        cell.Value = label.Text;

                        // Merge cells if the label spans multiple columns
                        if (colSpan > 1)
                        {
                            var range = w.Range(row, column, row, column + colSpan - 1);
                            range.Merge();

                            // Set borders for the entire merged range
                            range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            range.Style.Border.OutsideBorderColor = XLColor.Black;
                        }
                        else
                        {
                            // Set borders for the single cell
                            cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            cell.Style.Border.OutsideBorderColor = XLColor.Black;
                        }

                        // Optionally, format the cell to match label appearance
                        var cellStyle = cell.Style;
                        cellStyle.Font.Bold = label.Font.Bold;
                        cellStyle.Font.Italic = label.Font.Italic;
                        cellStyle.Font.FontSize = label.Font.Size;
                        cellStyle.Font.FontName = label.Font.FontFamily.Name;

                        // Set the background color
                        cellStyle.Fill.BackgroundColor = XLColor.FromColor(label.BackColor);

                        // Set text alignment
                        switch (label.TextAlign)
                        {
                            case System.Drawing.ContentAlignment.TopLeft:
                            case System.Drawing.ContentAlignment.MiddleLeft:
                            case System.Drawing.ContentAlignment.BottomLeft:
                                cellStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                                break;
                            case System.Drawing.ContentAlignment.TopCenter:
                            case System.Drawing.ContentAlignment.MiddleCenter:
                            case System.Drawing.ContentAlignment.BottomCenter:
                                cellStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                break;
                            case System.Drawing.ContentAlignment.TopRight:
                            case System.Drawing.ContentAlignment.MiddleRight:
                            case System.Drawing.ContentAlignment.BottomRight:
                                cellStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                break;
                        }

                        switch (label.TextAlign)
                        {
                            case System.Drawing.ContentAlignment.TopLeft:
                            case System.Drawing.ContentAlignment.TopCenter:
                            case System.Drawing.ContentAlignment.TopRight:
                                cellStyle.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                                break;
                            case System.Drawing.ContentAlignment.MiddleLeft:
                            case System.Drawing.ContentAlignment.MiddleCenter:
                            case System.Drawing.ContentAlignment.MiddleRight:
                                cellStyle.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                break;
                            case System.Drawing.ContentAlignment.BottomLeft:
                            case System.Drawing.ContentAlignment.BottomCenter:
                            case System.Drawing.ContentAlignment.BottomRight:
                                cellStyle.Alignment.Vertical = XLAlignmentVerticalValues.Bottom;
                                break;
                        }

                    }

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

        private void Donor_ComboBox_Leave_1(object sender, EventArgs e)
        {
            try
            {
                //if (Donor_ComboBox.SelectedIndex == 0 && Partner_ComboBox.SelectedIndex != 0)
                //{
                //    MessageBox.Show("الرجاء اختيار ممول");
                //    Distribution_ComboBox.DataSource = null;
                //    toddlersMale.Text = nottoddlersMale.Text = toddlersFemale.Text = nottoddlersFemale.Text = totalToddlers.Text = nottotalToddlers.Text
                //    = childrenMale.Text = notchildrenMale.Text = childrenFemale.Text = notchildrenFemale.Text = totalChildren.Text = nottotalChildren.Text = youthMale.Text =
                //    notyouthMale.Text = youthFemale.Text = notyouthFemale.Text = totalYouth.Text = nottotalYouth.Text = elderliesMale.Text = notelderliesMale.Text = elderliesFemale.Text =
                //    notelderliesFemale.Text = totalElderlies.Text = nottotalElderlies.Text = totalMale.Text = nottotalMale.Text = totalFemale.Text = nottotalFemale.Text = total.Text = nottotal.Text = "";
                //}
                //else
                //{
                Bind_Distribution_ComboBox();
                //}
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Donor_ComboBox_VisibleChanged_1(object sender, EventArgs e)
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

        private void Partner_ComboBox_Leave_1(object sender, EventArgs e)
        {
            if (Donor_ComboBox.SelectedIndex == 0 && Partner_ComboBox.SelectedIndex != 0)
            {
                MessageBox.Show("الرجاء اختيار ممول أولاً !!");
                Distribution_ComboBox.DataSource = null;
                toddlersMale.Text = nottoddlersMale.Text = toddlersFemale.Text = nottoddlersFemale.Text = totalToddlers.Text = nottotalToddlers.Text
                = childrenMale.Text = notchildrenMale.Text = childrenFemale.Text = notchildrenFemale.Text = totalChildren.Text = nottotalChildren.Text =
                below18Male.Text = notbelow18Male.Text = below18Female.Text = notbelow18Female.Text = totalBelow18.Text = nottotalBelow18.Text =
                below19Male.Text = notbelow19Male.Text = below19Female.Text = notbelow19Female.Text = totalBelow19.Text = nottotalBelow19.Text =
                totalMale.Text = nottotalMale.Text = totalFemale.Text = nottotalFemale.Text = total.Text = nottotal.Text =
                elderliesMale.Text = notelderliesMale.Text = elderliesFemale.Text = notelderliesFemale.Text = elderliesTotal.Text = notelderliestotal.Text =
                elderliesMale60.Text = notelderliesMale60.Text = elderliesFemale60.Text = notelderliesFemale60.Text = totalelderlies60.Text = nottotalelderlies60.Text =
                youthmale60.Text = youthfemale60.Text = youthMale.Text = youthFemale.Text = notYouthMale.Text = notyouthfemale.Text =
                notyouthmale60.Text = notyouthfemale60.Text = "";


            }
            else
            {
                Bind_Distribution_ComboBox();
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

        private void Distribution_ComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                   // Fill_Data();
                    //Excel_Button.Visible = true;

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Donor_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateFamily_Button_Click(object sender, EventArgs e)
        {
            Fill_Data();
        }
    }
}
