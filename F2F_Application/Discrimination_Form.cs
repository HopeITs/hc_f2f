using ClosedXML.Excel;
using F2F_Application.Classes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Sec;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Discrimination_Form : Form
    {
        public Discrimination_Form(Main_Form main_form, string SearchFor)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.SearchFor = SearchFor;
            bs.ListChanged += bs_ListChanged;
            Search_DataGridView.DoubleBuffered(true);
            Hide_MenuItem.DropDown.Closing += Hide_MenuItem_Closing;
            Show_MenuItem.DropDown.Closing += Show_MenuItem_Closing;
            //dataGridView1.DoubleBuffered(true);

            //Excel_Button.Visible = false;
        }
        Main_Form main_form;

        Financial f;
        Categories c;
        Report r; Distribution d;
        bool UserMode;
        string SearchFor;
        string Original_Filter_String = ""; string Original_Sort_String = "";
        BindingSource bs = new BindingSource();
        DataRow SelectedDataRow;
        List<string> Search_HiddenColumns = new List<string>();

        DataSet ds1 = new DataSet();

        private void Discrimination_Load(object sender, EventArgs e)
        {
            try
            {
                f = new Financial();
                c = new Categories();
                r = new Report();
                d = new Distribution();
                Bind_Partner_ComboBox();
                Bind_ComboBoxes(false);
                Bind_Distribution_ComboBox();
                Bind_Visit_ComboBox();
                Set_Control();


                //materialLabel13.ForeColor = Color.White;
                //materialLabel10.ForeColor = Color.FromArgb(0, 75, 75);
                //materialLabel11.ForeColor = Color.FromArgb(0, 75, 75);
                //materialLabel8.ForeColor = Color.FromArgb(0, 75, 75);
                //materialLabel9.ForeColor = Color.FromArgb(0, 75, 75);
                //materialLabel12.ForeColor = Color.FromArgb(0, 75, 75);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Hide_MenuItem_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            try
            {
                if (Hide_MenuItem.DropDownItems.Count > 0)
                {
                    if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                    {
                        e.Cancel = true;
                    }
                }
                SearchToolBar.SetColumns(Search_DataGridView.Columns);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void Show_MenuItem_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            try
            {
                if (Show_MenuItem.DropDownItems.Count > 0)
                {
                    if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                    {
                        e.Cancel = true;
                    }
                }
                SearchToolBar.SetColumns(Search_DataGridView.Columns);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void bs_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            NumOfRows1.Text = Search_DataGridView.Rows.Count.ToString();
        }

        private void Set_Control()
        {
            Excel_Button.Visible = false;
            Donor_ComboBox.SelectedIndex = 0;
            Partner_ComboBox.SelectedIndex = 0;
            Power_ComboBox.SelectedIndex = 0;
            Rehab_ComboBox.SelectedIndex = 0;
            //Distriburion_ComboBox.SelectedIndex = 0;
        }

        private void Discrimination_Form_Shown(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(this.Width - 10, 1050);

        }

        private void Bind_Donor_ComboBox()
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

        private void Bind_ComboBoxes(bool KeepSelection)
        {
            List<string> From_Tables = new List<string> { "donor", "partner", "aidsource" };

            DataSet Tables = c.Select_Tables(From_Tables, true);

            DataTable dt = Tables.Tables[0].Copy();
            DataTable dt1 = Tables.Tables[1].Copy();
            DataTable dt2 = Tables.Tables[2].Copy();
            DataTable dt21 = Tables.Tables[2].Copy();

            Bind_ComboBox(Donor_ComboBox, dt, KeepSelection);
            Bind_ComboBox(Partner_ComboBox, dt1, KeepSelection);
            Bind_ComboBox(Power_ComboBox, dt2, KeepSelection);
            Bind_ComboBox(Rehab_ComboBox, dt21, KeepSelection);
        }

        private void Bind_Distribution_ComboBox()
        {
            int SelectedValue = -1;
            if (Distriburion_ComboBox.SelectedValue != null)
                SelectedValue = int.Parse(Distriburion_ComboBox.SelectedValue.ToString());

            UserMode = false;
            string Date = dateTimePicker1.Value.ToString("dd/MM/yyyy", new CultureInfo("en-GB"));

            DataTable Dist_dt = d.Get_All_Distributions(Date);

            if (Dist_dt.Rows.Count <= 0)
            {
                Distriburion_ComboBox.DataSource = null;
                UserMode = true;
            }
            else
            {
                Distriburion_ComboBox.DataSource = null;
                Distriburion_ComboBox.DataSource = Dist_dt;
                Distriburion_ComboBox.DisplayMember = "name";
                Distriburion_ComboBox.ValueMember = "id";
                if (SelectedValue != -1)
                    Distriburion_ComboBox.SelectedValue = SelectedValue;
                else
                {
                    Distriburion_ComboBox.SelectedIndex = -1;
                    Distriburion_ComboBox.SelectedValue = 0;
                }
            }
            UserMode = true;
        }

        private void Bind_ComboBox(ComboBox Combox_Name, DataTable dt, bool KeepSelection)
        {
            Combox_Name.DataSource = dt;
            Combox_Name.DisplayMember = "name";
            Combox_Name.ValueMember = "id";
            int SelectedValue = Combox_Name.Items.Count - 1;

            if (Combox_Name.SelectedValue != null)
                SelectedValue = int.Parse(Combox_Name.SelectedValue.ToString());

            if (KeepSelection && SelectedValue != Combox_Name.Items.Count - 1)
                Combox_Name.SelectedValue = SelectedValue;
            else
                Combox_Name.SelectedIndex = Combox_Name.Items.Count - 1;

            Combox_Name.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
        }

        private void Bind_Visit_ComboBox()
        {
            string query = "";

            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            //select DISTINCT(`visit_name`) as 'name' , ROW_NUMBER() OVER(ORDER BY visit_name) AS 'id' FROM `family_visit` WHERE `visittype_id` = 3 and visit_name<> 'M&E - 0' GROUP by visit_name order by visit_name;
            query += "SELECT 'N/A' AS name, 0 AS id UNION ALL SELECT f.visit_name as 'name', (@i := @i + 1) AS 'id' " +
                        "FROM(SELECT DISTINCT(`visit_name`) FROM family_visit WHERE `visittype_id` = 3 and visit_name <> 'M&E - 0' GROUP BY family_visit.visit_name) as f,(SELECT @i:= 0) params; ";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();
            DataTable dt0 = dt;
            //Bing ComboBoxes
            Bind_ComboBox(Visits_ComboBox, dt0, false);
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

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        protected override Point ScrollToControl(Control activeControl) //STOP AUTO SCROLL
        {
            Point pt = this.AutoScrollPosition;
            return pt;
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

        private void Fill_Data()
        {
            bs.Filter = bs.Sort = Original_Sort_String = Original_Filter_String = "";
            Search_DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            string VisitName = Visits_ComboBox.Text;
            int Donor_ID = Convert.ToInt32(Donor_ComboBox.SelectedValue.ToString());
            int Partner_ID = Convert.ToInt32(Partner_ComboBox.SelectedValue.ToString());
            int Distriburion_ID = -1;
            if (Distriburion_ComboBox.SelectedValue != null)
                Distriburion_ID = Convert.ToInt32(Distriburion_ComboBox.SelectedValue.ToString());

            int IsSolar = -1;
            if (PowerYes_RadioButton.Checked)
                IsSolar = 1;
            else if (PowerNo_RadioButton.Checked)
                IsSolar = 0;

            int SolarDonor_ID = Convert.ToInt32(Power_ComboBox.SelectedValue.ToString());

            int IsRenovation = -1;
            if (RehabYes_RadioButton.Checked)
                IsRenovation = 1;
            else if (RehabNo_RadioButton.Checked)
                IsRenovation = 0;


            int RenovationDonor_ID = Convert.ToInt32(Rehab_ComboBox.SelectedValue.ToString());

            ds1 = r.Get_MemberAgeGender_Report(VisitName, Donor_ID, Partner_ID, IsSolar, SolarDonor_ID, IsRenovation, RenovationDonor_ID, Distriburion_ID);


            bs.DataSource = ds1.Tables[0];
            Search_DataGridView.ColumnHeadersVisible = false;
            Search_DataGridView.DataSource = null;
            Search_DataGridView.Columns.Clear();
            Search_DataGridView.DataSource = bs;
            Search_DataGridView.ColumnHeadersVisible = true;

            Search_DataGridView.Columns["Family_id"].Visible = false;
            Search_DataGridView.Columns["Donor_id"].Visible = false;
            Search_DataGridView.Columns["SolarAid_id"].Visible = false;
            Search_DataGridView.Columns["RenovationAid_id"].Visible = false;
            Search_DataGridView.Columns["Partner_id"].Visible = false;

            Search_DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Bind_Show_Hide_ToolStrip();
            NumOfRows1.Text = Search_DataGridView.Rows.Count.ToString();
            SearchToolBar.SetColumns(Search_DataGridView.Columns);



        }

        private void Bind_Show_Hide_ToolStrip()
        {
            ToolStripMenuItem Hide_Columns = Show_Hide_ToolStrip.DropDownItems[0] as ToolStripMenuItem;
            ToolStripMenuItem Show_Columns = Show_Hide_ToolStrip.DropDownItems[1] as ToolStripMenuItem;

            Show_Columns.DropDownItems.Clear();
            Hide_Columns.DropDownItems.Clear();

            foreach (DataGridViewColumn C in Search_DataGridView.Columns)
            {
                if (!C.Name.Contains("ID"))
                    if (C.Visible)
                        Hide_Columns.DropDownItems.Add(C.Name);
                    else
                        Show_Columns.DropDownItems.Add(C.Name);
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

                    DataTable dt1 = ((DataTable)Discrimination_DataGridView.DataSource).DefaultView.ToTable();
                    //DataTable dt2 = ((DataTable)dataGridView2.DataSource).DefaultView.ToTable();


                    wb.Worksheets.Add(dt1, "Sheet_1");
                    //wb.Worksheets.Add(dt2, "Sheet_2");

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


        private void UpdateFamily_Button_Click(object sender, EventArgs e)
        {
            Fill_Data();
            Excel_Button.Visible = true;

        }

        private void Visits_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void Power_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void Rehab_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void Export_Exel_Click(object sender, EventArgs e)
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

                    DataTable dt = ((DataTable)bs.DataSource).DefaultView.ToTable();

                    foreach (ToolStripItem tsi in (Show_Hide_ToolStrip.DropDownItems[1] as ToolStripMenuItem).DropDownItems)
                    {
                        dt.Columns.RemoveAt(dt.Columns.IndexOf(dt.Columns[tsi.Text]));
                    }

                    wb.Worksheets.Add(dt, "Extrcted Data");
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

        private void Search_DataGridView_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            try
            {
                bs.Sort = Search_DataGridView.SortString;
                Original_Sort_String = Search_DataGridView.SortString;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Search_DataGridView_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            try
            {
                Original_Filter_String = Search_DataGridView.FilterString;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Search_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void Show_Hide_ToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                Show_Hide_ToolStrip.ShowDropDown();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void SearchToolBar_Search(object sender, Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(e.ValueToSearch))
                {
                    bs.Filter = Original_Filter_String;
                }
                else
                {
                    string NewFilter = "";


                    if (e.ColumnToSearch != null)
                    {
                        //convert(JobNumber, 'System.String')
                        if (e.WholeWord)
                            NewFilter += "convert(`" + e.ColumnToSearch.Name + "`,'System.String') = '" + e.ValueToSearch + "'";
                        else
                            NewFilter += "convert(`" + e.ColumnToSearch.Name + "`,'System.String') like '%" + e.ValueToSearch + "%'";
                    }
                    else
                    {
                        //Colunms.GetRowCount(DataGridViewElementStates.Visible);
                        int VisibleColumnsCount = Search_DataGridView.Columns.GetColumnCount(DataGridViewElementStates.Visible);
                        int i = 0;
                        foreach (DataGridViewColumn C in Search_DataGridView.Columns)
                        {
                            if (C.Visible == true)
                            {
                                if (e.WholeWord)
                                    NewFilter += "convert(`" + C.Name + "`,'System.String') = '" + e.ValueToSearch + "'";
                                else
                                    NewFilter += "convert(`" + C.Name + "`,'System.String') like '%" + e.ValueToSearch + "%'";

                                if (i < VisibleColumnsCount - 1)
                                    NewFilter += " or ";

                                i++;
                            }
                        }
                    }
                    string All_Filters = Original_Filter_String == "" ? NewFilter : Original_Filter_String + " and (" + NewFilter + ")";
                    bs.Filter = All_Filters;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Search_DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            NumOfSelected1.Text = Search_DataGridView.SelectedRows.Count.ToString();
        }

        private void Search_DataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int Family_ID = -1;
            if (Search_DataGridView.RowCount > 0 && Search_DataGridView.CurrentRow != null)
            {
                SelectedDataRow = ((DataRowView)Search_DataGridView.CurrentRow.DataBoundItem).Row;
                if (SelectedDataRow != null)
                {
                    if (SelectedDataRow["family_id"] != null || SelectedDataRow["family_id"] != DBNull.Value)
                        Family_ID = int.Parse(SelectedDataRow["family_id"].ToString());
                }
                if (Family_ID != -1)
                {
                    if (Program.Check_Opened("Family", Family_ID))
                    {
                        MessageBox.Show("لا يمكن فتح صفحة العائلة نفسها أكثر من مرة");
                    }
                    else
                    {
                        Form Family_Form = new Family_Form(Family_ID, main_form, false);
                        main_form.showNewTab(Family_Form, "Family");
                    }

                }
            }
        }

        private void Hide_MenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Hide_MenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                Search_DataGridView.Columns[e.ClickedItem.Text].Visible = false;
                Search_HiddenColumns.Add(e.ClickedItem.Text);
                Bind_Show_Hide_ToolStrip();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Show_MenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                Search_DataGridView.Columns[e.ClickedItem.Text].Visible = true;

                Search_HiddenColumns.RemoveAt(Search_HiddenColumns.IndexOf(e.ClickedItem.Text));

                Bind_Show_Hide_ToolStrip();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Caclc_totals()
        {

            if (Search_DataGridView.DataSource != null && Search_DataGridView.RowCount > 0
                && ds1.Tables[1] != null && ds1.Tables[1].Rows.Count > 0)
            {
                var filteredRows = Search_DataGridView.Rows.Cast<DataGridViewRow>()
                            .Where(row => row.Visible)
                            .GroupBy(row => row.Cells["Family_id"].Value)
                            .Select(group => group.First())
                .ToList();

                DataTable filteredTable = ds1.Tables[0].Clone();

                filteredRows.ForEach(row =>
                {
                    DataRow newRow = filteredTable.NewRow();
                    for (int i = 0; i < Search_DataGridView.Columns.Count; i++)
                    {
                        newRow[i] = row.Cells[i].Value;
                    }
                    filteredTable.Rows.Add(newRow);
                });


                DataTable sumTable = new DataTable();
                DataRow sumRow = sumTable.NewRow();


                foreach (DataColumn column in filteredTable.Columns)
                {
                    sumTable.Columns.Add(column.ColumnName, column.DataType);
                }


                foreach (DataColumn column in filteredTable.Columns)
                {
                    if (!column.ColumnName.Contains("_id") &&
                        (column.DataType == typeof(int) ||
                        column.DataType == typeof(Int64) ||
                        column.DataType == typeof(double) ||
                        column.DataType == typeof(decimal) ||
                        column.DataType == typeof(float)
                        )
                        )
                    {
                        var sum = filteredTable.AsEnumerable().Sum(row => Convert.ToDecimal(row[column]));
                        sumRow[column.ColumnName] = sum;
                    }
                    else
                    {
                        sumRow[column.ColumnName] = DBNull.Value;
                    }
                }

                sumTable.Rows.Add(sumRow);



                DataTable AgeRange = ds1.Tables[1];


                DataTable dataTable = new DataTable();



                dataTable.Columns.Add("العمر", typeof(string));
                dataTable.Columns.Add("الذكور المستفيدين", typeof(Int64));
                dataTable.Columns.Add("الاناث المستفيدات", typeof(Int64));
                dataTable.Columns.Add("الذكور غير المستفيدين", typeof(Int64));
                dataTable.Columns.Add("الاناث غير المستفيدات", typeof(Int64));
                dataTable.Columns.Add("المجموع", typeof(Int64));



                for (int i = 0; i < AgeRange.Rows.Count; i++)
                {
                    DataRow newRow = dataTable.NewRow();
                    Int64 Total = 0;
                    string AvgRange_Name = AgeRange.Rows[i]["Name"].ToString();
                    foreach (DataColumn dtDc in dataTable.Columns)
                    {
                        if (dtDc.ColumnName == "العمر")
                        {
                            newRow[dtDc] = AvgRange_Name;
                        }
                        else
                        {
                            string dataTableCol_Name = dtDc.ColumnName.ToString();
                            foreach (DataColumn stDc in sumTable.Columns)
                            {
                                if (stDc.ColumnName.Contains(dataTableCol_Name))
                                {
                                    Int64 Sums = Convert.ToInt64(sumTable.Rows[0][stDc]);

                                    if (stDc.ColumnName.Contains(dataTableCol_Name) && stDc.ColumnName.Contains(AvgRange_Name))
                                    {
                                        newRow[dtDc] = Sums;

                                        Total += Sums;
                                    }
                                }
                            }
                        }
                    }
                    newRow["المجموع"] = Total;
                    dataTable.Rows.Add(newRow);
                }

                DataRow SumRow = dataTable.NewRow();

                foreach (DataColumn dtDc in dataTable.Columns)
                {
                    if (dtDc.ColumnName == "العمر")
                    {
                        SumRow[dtDc] = "الإجمالي";
                    }
                    else
                    {
                        var sum = dataTable.AsEnumerable().Sum(row => Convert.ToDecimal(row[dtDc.ColumnName]));
                        SumRow[dtDc] = sum;
                    }
                }

                dataTable.Rows.Add(SumRow);


                Discrimination_DataGridView.DataSource = null;
                Discrimination_DataGridView.Columns.Clear();
                Discrimination_DataGridView.DataSource = dataTable;
            }

            else
            {
                Discrimination_DataGridView.DataSource = null;
                Discrimination_DataGridView.Columns.Clear();
            }

        }

        private void Search_DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                Caclc_totals();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Bind_Distribution_ComboBox();
                ;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Distriburion_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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
