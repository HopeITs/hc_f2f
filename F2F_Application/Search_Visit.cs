using ClosedXML.Excel;
using F2F_Application.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Search_Visit : Form
    {
        public Search_Visit(Main_Form main_form, string SearchFor)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.SearchFor = SearchFor;
            bs.ListChanged += bs_ListChanged;
            Search_DataGridView.DoubleBuffered(true);
            Hide_MenuItem.DropDown.Closing += Hide_MenuItem_Closing;
            Show_MenuItem.DropDown.Closing += Show_MenuItem_Closing;
        }
        string SearchFor, CurrentTable;
        Search s; Main_Form main_form;
        DataRow SelectedDataRow;
        BindingSource bs = new BindingSource();
        Categories c;
        int tick1 = 0;
        bool UserMode = true;
        bool showResult = false;
        string Original_Filter_String = ""; string Original_Sort_String = "";

        List<string> SelectedFilterTables = new List<string>();
        List<string> AdditionalColumnsTables = new List<string>();
        List<string> AdditionalColumnsTables_ArabicName = new List<string>();
        
        List<string> Family_HiddenColumns = new List<string>();
        List<string> Member_HiddenColumns = new List<string>();

        private void Search_Visit_Load(object sender, EventArgs e)
        {
            try
            {
                s = new Search();
                c = new Categories();
                
                UserMode = false;
                if (SearchFor == "Family")
                { Family_RadioButton.Checked = true; SearchFor = "Family";  }
                else if (SearchFor == "Member")
                { Person_RadioButton.Checked = true; SearchFor = "Member"; }

                Bind_ComboBoxes(false);
                BindCategoryCombobox("Family");
                Bind_Search_DataGridView("M&E - 3","N/A",showResult);
                UserMode = true;
                showLast.Visible = false;
                Check_User_Role();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Check_User_Role()
        {
            //if (Properties.Settings.Default.Role == "Viewer")
            //{
            //    Distribution_RadioButton.Enabled = false;
            //    Export_Exel.Enabled = false;
            //}
            //else if (Properties.Settings.Default.Role == "Data")
            //{
            //    Partner_RadioButton.Visible = false;
            //    Distribution_RadioButton.Visible = false;
            //}
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic Category = Category_ComboBox.SelectedIndex;
                Bind_Search_DataGridView("M&E - 3","N/A", showResult);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void resetViewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Family_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode && Family_RadioButton.Checked)
                {
                    SearchFor = "Family";
                    dynamic Item = Visits_ComboBox.SelectedIndex;
                    dynamic Category = Category_ComboBox.SelectedItem;
                    Category_ComboBox.Items.Clear();
                    BindCategoryCombobox("Family");
                    if (Item == 0)
                    {
                        Bind_Search_DataGridView("M&E - 1",Category, showResult);

                    }
                    else if (Item == 1)
                    {
                        Bind_Search_DataGridView("M&E - 2", Category, showResult);

                    }
                    else if (Item == 2)
                    {
                        Bind_Search_DataGridView("M&E - 3", Category, showResult);

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BindCategoryCombobox(string type)
        {
            if (type == "member")
            {
                Category_ComboBox.Items.Add("N/A");
                Category_ComboBox.Items.Add("حالة الفرد");
                Category_ComboBox.Items.Add("الحالة الاجتماعية");
                Category_ComboBox.Items.Add("المرض");
                Category_ComboBox.Items.Add("العمل");
                Category_ComboBox.Items.Add("مشاريع صغيرة");
            }
            else {
                Category_ComboBox.Items.Add("N/A");
                Category_ComboBox.Items.Add("الممتلكات");
                Category_ComboBox.Items.Add("السيارات");
                Category_ComboBox.Items.Add("الدخل");
            }
            Category_ComboBox.SelectedIndex = 0;
        }

        private void Person_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Category_ComboBox.Items.Clear();
                BindCategoryCombobox("member");
                if (UserMode && Person_RadioButton.Checked)
                {

                    SearchFor = "Member";

                    dynamic Item = Visits_ComboBox.SelectedIndex;
                    dynamic Category = Category_ComboBox.SelectedItem;
                    if (Item == 0)
                    {
                        Bind_Search_DataGridView("M&E - 1", Category, showResult);

                    }
                    else if (Item == 1)
                    {
                        Bind_Search_DataGridView("M&E - 2", Category, showResult);

                    }
                    else if (Item == 2)
                    {
                        Bind_Search_DataGridView("M&E - 3", Category, showResult);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        
        public void Bind_Search_DataGridView(string visitname, string Category, bool showResult)
        {
            bs.Filter = bs.Sort = Original_Sort_String = Original_Filter_String = "";
            Search_DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            if (SearchFor == "Family")
            {
                DataTable dt = s.Get_Families_Visit(visitname,Category, showResult);
                bs.DataSource = dt;
                Search_DataGridView.ColumnHeadersVisible = false;
                Search_DataGridView.DataSource = null;
                Search_DataGridView.Columns.Clear();
                Search_DataGridView.DataSource = bs;
                Search_DataGridView.ColumnHeadersVisible = true;

                Search_DataGridView.Columns["family_id"].Visible = false;
                Search_DataGridView.Columns["visit_id"].Visible = false;

                //Search_DataGridView.Columns["رمز العائلة"].Frozen = true;
                
                //Search_DataGridView.Columns["الزيارة"].Frozen = true; 
            }
            else if (SearchFor == "Member")
            {
                DataTable dt = s.Get_Person_Visit(visitname, Category, showResult);
                bs.DataSource = dt;
                Search_DataGridView.ColumnHeadersVisible = false;
                Search_DataGridView.DataSource = null;
                Search_DataGridView.Columns.Clear();
                Search_DataGridView.DataSource = bs;
                Search_DataGridView.ColumnHeadersVisible = true;
                //Search_DataGridView.SetFilterDateAndTimeEnabled(Search_DataGridView.Columns["تاريخ الميلاد"], true);

                Search_DataGridView.Columns["family_id"].Visible = false;
                Search_DataGridView.Columns["person_id"].Visible = false;

                if(Category.Equals("حالة الفرد") || Category.Equals("الحالة الاجتماعية"))
                {
                    
                }
                else
                {
                    Search_DataGridView.Columns["visit_id"].Visible = false;
                }

                //Search_DataGridView.Columns["رمز العائلة"].Frozen = true;
                //Search_DataGridView.Columns["الشريك"].Frozen = true;
                //Search_DataGridView.Columns["الممول"].Frozen = true;
                //Search_DataGridView.Columns["الحالة"].Frozen = true;
                //Search_DataGridView.Columns["الزيارة"].Frozen = true;
                //Search_DataGridView.Columns["حالة الزيارة"].Frozen = true;
                //Search_DataGridView.Columns["الاسم الثلاثي"].Frozen = true;


                //if (Search_DataGridView.Rows.Count > 0)
                //{
                //    Search_DataGridView.CurrentCell = Search_DataGridView.Rows[0].Cells["اسم الشخص"];
                //}
                //if (Member_HiddenColumns.Count != 0)
                //{
                //    foreach (string CName in Member_HiddenColumns)
                //    {
                //        foreach (DataGridViewColumn C in Search_DataGridView.Columns)
                //        {
                //            if (C.Name == CName)
                //            {
                //                C.Visible = false;
                //            }
                //        }
                //    }
                //}
            }

            Search_DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Bind_Show_Hide_ToolStrip();
            NumOfRows1.Text = Search_DataGridView.Rows.Count.ToString();
            SearchToolBar.SetColumns(Search_DataGridView.Columns);
        }

        private void Search_Visit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
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

        private void Bind_ComboBoxes(bool KeepSelection)
        {
            string query = "";

            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();
            //select DISTINCT(`visit_name`) as 'name' , ROW_NUMBER() OVER(ORDER BY visit_name) AS 'id' FROM `family_visit` WHERE `visittype_id` = 3 and visit_name<> 'M&E - 0' GROUP by visit_name order by visit_name;
            query += "SELECT f.visit_name as 'name', (@i := @i + 1) AS 'id' "+ 
                        "FROM(SELECT DISTINCT(`visit_name`) FROM family_visit WHERE `visittype_id` = 3 and visit_name <> 'M&E - 0' GROUP BY family_visit.visit_name) as f,(SELECT @i:= 0) params; ";

            sc.CommandText = query;
            sc.Connection = Program.MyConn;

            MySqlDataAdapter da = new MySqlDataAdapter(sc);
            DataTable dt = new DataTable();

            da.Fill(dt);
            Program.MyFirstConn.Close();
            DataTable dt0 = dt;
            //Bing ComboBoxes
            Bind_ComboBox(Visits_ComboBox, dt0, KeepSelection);
        }


        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void Visits_ComboBox_DrawItem_1(object sender, DrawItemEventArgs e)
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

        private void Visits_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    dynamic Item = Visits_ComboBox.SelectedIndex;
                    dynamic Category = Category_ComboBox.SelectedItem;
                    if (Item == 0)
                    {
                        Bind_Search_DataGridView("M&E - 1", Category, showResult);

                    }
                    else if (Item == 1)
                    {
                        Bind_Search_DataGridView("M&E - 2", Category, showResult);

                    }
                    else if (Item == 2)
                    {
                        Bind_Search_DataGridView("M&E - 3", Category, showResult);

                    }

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        

        private void Bind_ComboBox(ComboBox Combox_Name, DataTable dt, bool KeepSelection)
        {
            Combox_Name.DataSource = dt;
            Combox_Name.DisplayMember = "name";
            Combox_Name.ValueMember = "id";
            int SelectedValue = Combox_Name.Items.Count-1;
        
            if (Combox_Name.SelectedValue != null)
                SelectedValue = int.Parse(Combox_Name.SelectedValue.ToString());
            
            if (KeepSelection && SelectedValue != Combox_Name.Items.Count - 1)
                Combox_Name.SelectedValue = SelectedValue;
            else
                Combox_Name.SelectedIndex = Combox_Name.Items.Count - 1;

            Combox_Name.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
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

        private void Hide_MenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                Search_DataGridView.Columns[e.ClickedItem.Text].Visible = false;
                if (SearchFor == "Family")
                {
                    Family_HiddenColumns.Add(e.ClickedItem.Text);
                }
                else if (SearchFor == "Member")
                {
                    Member_HiddenColumns.Add(e.ClickedItem.Text);
                }

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
                if (SearchFor == "Family")
                {
                    Family_HiddenColumns.RemoveAt(Family_HiddenColumns.IndexOf(e.ClickedItem.Text));
                }
                else if (SearchFor == "Member")
                {
                    Member_HiddenColumns.RemoveAt(Member_HiddenColumns.IndexOf(e.ClickedItem.Text));
                }
                Bind_Show_Hide_ToolStrip();
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

        private void Search_DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            NumOfSelected1.Text = Search_DataGridView.SelectedRows.Count.ToString();
        }

        private void Search_DataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (SearchFor == "Family")
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
                            /*
                            Form Family_Form = new Family_Form(Family_ID, main_form);
                            main_form.showNewTab(Family_Form, "Family");*/
                        }
                    }
                }
                else if (SearchFor == "Member")
                {
                    int Family_ID = -1;
                    int Person_ID = -1;
                    int Visit_ID = -1;
                    string Visit_Name = "";
                    string Family_Code = "";
                    if (Search_DataGridView.RowCount > 0 && Search_DataGridView.CurrentRow != null)
                    {
                        SelectedDataRow = ((DataRowView)Search_DataGridView.CurrentRow.DataBoundItem).Row;
                        if (SelectedDataRow != null)
                        {
                            if (SelectedDataRow["family_id"] != null || SelectedDataRow["family_id"] != DBNull.Value)
                                Family_ID = int.Parse(SelectedDataRow["family_id"].ToString());
                            if (SelectedDataRow["person_id"] != null || SelectedDataRow["person_id"] != DBNull.Value)
                                Person_ID = int.Parse(SelectedDataRow["person_id"].ToString());
                            if (SelectedDataRow["visit_id"] != null || SelectedDataRow["visit_id"] != DBNull.Value)
                                Visit_ID = int.Parse(SelectedDataRow["visit_id"].ToString());
                            if (SelectedDataRow["الزيارة"] != null || SelectedDataRow["الزيارة"] != DBNull.Value)
                                Visit_Name = SelectedDataRow["الزيارة"].ToString();
                            if (SelectedDataRow["رمز العائلة"] != null || SelectedDataRow["رمز العائلة"] != DBNull.Value)
                                Family_Code = SelectedDataRow["رمز العائلة"].ToString();
                        }
                        if (Family_ID != -1 && Person_ID != -1)
                        {
                            if (Program.Check_Opened("Person", Person_ID))
                            {
                                MessageBox.Show("لا يمكن فتح صفحة الشخص نفسه أكثر من مرة");
                            }
                            else
                            {
                                Form Person_Form = new Person_Form(Person_ID, Family_ID, Visit_ID, Visit_Name, Family_Code, main_form);
                                main_form.showNewTab(Person_Form, "Member");
                            }
                            /*
                            Form Person_Form = new Person_Form(Person_ID, Family_ID, main_form);
                            main_form.showNewTab(Person_Form, "Member");*/
                        }
                    }
                }
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

        private void Category_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void Category_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    dynamic Category = Category_ComboBox.SelectedItem;
                    dynamic Item = Visits_ComboBox.SelectedIndex;
                    if (Item == 0)
                    {
                        Bind_Search_DataGridView("M&E - 1", Category, showResult);

                    }
                    else if (Item == 1)
                    {
                        Bind_Search_DataGridView("M&E - 2", Category, showResult);

                    }
                    else if (Item == 2)
                    {
                        Bind_Search_DataGridView("M&E - 3", Category, showResult);

                    }
                    if(Category != "N/A")
                    {
                        showLast.Visible = true;
                    }
                    else showLast.Visible = false;
                    if (Category == "حالة الفرد" || Category == "الحالة الاجتماعية")
                    {
                        Visits_ComboBox.Visible = false;
                        label2.Visible = false;
                    }
                    else
                    {
                        Visits_ComboBox.Visible = true;
                        label2.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void showLast_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    dynamic Category = Category_ComboBox.SelectedItem;
                    dynamic Item = Visits_ComboBox.SelectedIndex;
                    if (showLast.Checked) showResult = true;
                    else showResult = false;
                    if (Item == 0)
                    {
                        Bind_Search_DataGridView("M&E - 1", Category, showResult);

                    }
                    else if (Item == 1)
                    {
                        Bind_Search_DataGridView("M&E - 2", Category, showResult);

                    }
                    else if (Item == 2)
                    {
                        Bind_Search_DataGridView("M&E - 3", Category, showResult);

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
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
    }
}
