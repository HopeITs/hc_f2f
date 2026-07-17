using ClosedXML.Excel;
using F2F_Application.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;


namespace F2F_Application
{
    public partial class Search_Form : Form
    {
        public Search_Form(Main_Form main_form, string SearchFor)
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

        string FilterQuery = "";

        string Original_Filter_String = ""; string Original_Sort_String = "";

        List<string> SelectedFilterTables = new List<string>();
        List<string> AdditionalColumnsTables = new List<string>();
        List<string> AdditionalColumnsTables_ArabicName = new List<string>();

        List<string> Family_HiddenColumns = new List<string>();
        List<string> Member_HiddenColumns = new List<string>();
        List<string> Partner_HiddenColumns = new List<string>();
        List<string> Distribution_HiddenColumns = new List<string>();

        private void Search_Form_Load(object sender, EventArgs e)
        {
            try
            {
                s = new Search();
                c = new Categories();
                Set_Additional_Filters();


                //UserMode = false;
                if (SearchFor == "Family")
                { Family_RadioButton.Checked = true; SearchFor = "Family"; Bind_AdditionalColumns_CheckedListBox(); }
                else if (SearchFor == "Member")
                { Person_RadioButton.Checked = true; SearchFor = "Member"; Bind_AdditionalColumns_CheckedListBox(); }
                else if (SearchFor == "Partner")
                { Partner_RadioButton.Checked = true; SearchFor = "Partner"; }
                else if (SearchFor == "Distribution")
                { Distribution_RadioButton.Checked = true; SearchFor = "Distribution"; }

                Bind_Search_DataGridView();
                //UserMode = true;


                //Main_TableLayoutPanel.Size = new Size(this.Width, 1006);
                Categories_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
                Filter1_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
                Filter2_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);

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
            if (Properties.Settings.Default.Role == "Viewer")
            {
                Distribution_RadioButton.Enabled = false;
                Export_Exel.Enabled = false;
            }
            else if (Properties.Settings.Default.Role == "Data")
            {
                Partner_RadioButton.Visible = false;
                Distribution_RadioButton.Visible = false;
            }
        }

        private void Search_Form_Shown(object sender, EventArgs e)
        {
            if (Search_DataGridView.Columns["Logo"] != null)
                Search_DataGridView.SetFilterAndSortEnabled(Search_DataGridView.Columns["Logo"], false);

        }

        public void Bind_Search_DataGridView()
        {
            bs.Filter = bs.Sort = Original_Sort_String = Original_Filter_String = "";
            Search_DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // Unfreeze and disconnect before swapping BindingSource data.
            // Changing bs.DataSource while the grid is still bound (with Frozen columns)
            // inserts new unfrozen columns before a still-frozen shared column (e.g. رمز العائلة)
            // and throws: frozen columns must form a contiguous block.
            Search_DataGridView.ColumnHeadersVisible = false;
            foreach (DataGridViewColumn col in Search_DataGridView.Columns)
                col.Frozen = false;
            Search_DataGridView.DataSource = null;
            Search_DataGridView.Columns.Clear();

            if (SearchFor == "Family")
            {
                DataTable dt = s.Get_Families(FilterQuery, AdditionalColumnsTables, AdditionalColumnsTables_ArabicName);
                bs.DataSource = dt;
                Search_DataGridView.DataSource = bs;
                Search_DataGridView.ColumnHeadersVisible = true;

                Search_DataGridView.Columns["رمز العائلة"].Frozen = true;
                
                Search_DataGridView.Columns["Family ID"].Visible = false;
                Search_DataGridView.Columns["Family_Visit_ID"].Visible = false;
                Search_DataGridView.Columns["عدد الأسرّة"].Visible = false;
                Search_DataGridView.Columns["غرفة المعيشة"].Visible = false;
                Search_DataGridView.Columns["عدد الغرف"].Visible = false;
                Search_DataGridView.Columns["هل تبيع أغراض المنزل؟"].Visible = false;
                Search_DataGridView.Columns["هل يوجد سيارة؟"].Visible = false;
                Search_DataGridView.Columns["هل يوجد ممتلكات إضافية؟"].Visible = false;
                Search_DataGridView.Columns["هل يوجد دخل ثابت؟"].Visible = false;

                //if (Search_DataGridView.Rows.Count > 0)
                //{
                //    Search_DataGridView.CurrentCell = Search_DataGridView.Rows[0].Cells["رمز العائلة"];
                //} 
                //if (Family_HiddenColumns.Count != 0)
                //{
                //    foreach (string CName in Family_HiddenColumns)
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
            else if (SearchFor == "Member")
            {
                DataTable dt = s.Get_Persons(FilterQuery, AdditionalColumnsTables, AdditionalColumnsTables_ArabicName);
                bs.DataSource = dt;
                Search_DataGridView.DataSource = bs;
                Search_DataGridView.ColumnHeadersVisible = true;
                // Get_Persons aliases DOB as المواليد (not تاريخ الميلاد)
                if (Search_DataGridView.Columns["المواليد"] != null)
                    Search_DataGridView.SetFilterDateAndTimeEnabled(Search_DataGridView.Columns["المواليد"], true);
                Search_DataGridView.Columns["Person ID"].Visible = false;
                Search_DataGridView.Columns["Family ID"].Visible = false;
                Search_DataGridView.Columns["Visit ID"].Visible = false;

                //Search_DataGridView.Columns["رمز العائلة"].Visible = false;
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
            else if (SearchFor == "Partner")
            {
                DataTable dt = s.Get_Partners();
                bs.DataSource = dt;
                Search_DataGridView.DataSource = bs;
                Search_DataGridView.ColumnHeadersVisible = true;

                Search_DataGridView.Columns["Partner ID"].Visible = false;

                if (Search_DataGridView.Rows.Count > 0)
                {
                    Search_DataGridView.CurrentCell = Search_DataGridView.Rows[0].Cells["الشريك"];
                }

                Search_DataGridView.SetFilterAndSortEnabled(Search_DataGridView.Columns["Logo"], false);
                Search_DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

                if (Partner_HiddenColumns.Count != 0)
                {
                    foreach (string CName in Family_HiddenColumns)
                    {
                        foreach (DataGridViewColumn C in Search_DataGridView.Columns)
                        {
                            if (C.Name == CName)
                            {
                                C.Visible = false;
                            }
                        }
                    }
                }
            }
            else if (SearchFor == "Distribution")
            {
                DataTable dt = s.Get_Distribution();
                bs.DataSource = dt;
                Search_DataGridView.DataSource = bs;
                Search_DataGridView.ColumnHeadersVisible = true;
                Search_DataGridView.Columns["Distribution ID"].Visible = false;
                Search_DataGridView.Columns["partner_donor_id"].Visible = false;

                Search_DataGridView.Columns["شهر التوزيعة"].DefaultCellStyle.Format = "MM/yyyy";
                if (Search_DataGridView.Rows.Count > 0)
                {
                    Search_DataGridView.CurrentCell = Search_DataGridView.Rows[0].Cells["التوزيعة"];
                }

                if (Distribution_HiddenColumns.Count != 0)
                {
                    foreach (string CName in Family_HiddenColumns)
                    {
                        foreach (DataGridViewColumn C in Search_DataGridView.Columns)
                        {
                            if (C.Name == CName)
                            {
                                C.Visible = false;
                            }
                        }
                    }
                }
            }
            else
            {
                Search_DataGridView.ColumnHeadersVisible = true;
            }
            Search_DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Bind_Show_Hide_ToolStrip();
            NumOfRows1.Text = Search_DataGridView.Rows.Count.ToString();
            SearchToolBar.SetColumns(Search_DataGridView.Columns);
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
                            if (SelectedDataRow["Family ID"] != null || SelectedDataRow["Family ID"] != DBNull.Value)
                                Family_ID = int.Parse(SelectedDataRow["Family ID"].ToString());
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
                            if (SelectedDataRow["Family ID"] != null || SelectedDataRow["Family ID"] != DBNull.Value)
                                Family_ID = int.Parse(SelectedDataRow["Family ID"].ToString());
                            if (SelectedDataRow["Person ID"] != null || SelectedDataRow["Person ID"] != DBNull.Value)
                                Person_ID = int.Parse(SelectedDataRow["Person ID"].ToString());
                            if (SelectedDataRow["Visit ID"] != null || SelectedDataRow["Visit ID"] != DBNull.Value)
                                Visit_ID = int.Parse(SelectedDataRow["Visit ID"].ToString());
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
                                Form Person_Form = new Person_Form(Person_ID, Family_ID, Visit_ID, Visit_Name , Family_Code ,main_form);
                                main_form.showNewTab(Person_Form, "Member");
                            }
                            /*
                            Form Person_Form = new Person_Form(Person_ID, Family_ID, main_form);
                            main_form.showNewTab(Person_Form, "Member");*/
                        }
                    }
                }

                else if (SearchFor == "Partner")
                {

                    int Partner_ID = -1;
                    string Partner_Name = "";
                    if (Search_DataGridView.RowCount > 0 && Search_DataGridView.CurrentRow != null)
                    {
                        SelectedDataRow = ((DataRowView)Search_DataGridView.CurrentRow.DataBoundItem).Row;
                        if (SelectedDataRow != null)
                        {
                            if (SelectedDataRow["Partner ID"] != null || SelectedDataRow["Partner ID"] != DBNull.Value)
                            {
                                Partner_ID = int.Parse(SelectedDataRow["Partner ID"].ToString());
                                Partner_Name = SelectedDataRow["الشريك"].ToString();
                            }
                        }
                        //if (Partner_ID != -1)
                        //{
                        //    Form Partner_Distribution_Form = new Partner_Distribution_Form(Partner_ID, Partner_Name, main_form);
                        //    main_form.showNewTab(Partner_Distribution_Form, "Partner_Distribution");
                        //}
                    }

                }

                else if (SearchFor == "Distribution")
                {
                    int Distribution_ID = -1;
                    if (Search_DataGridView.RowCount > 0 && Search_DataGridView.CurrentRow != null)
                    {
                        SelectedDataRow = ((DataRowView)Search_DataGridView.CurrentRow.DataBoundItem).Row;
                        if (SelectedDataRow != null)
                        {
                            if (SelectedDataRow["Distribution ID"] != null || SelectedDataRow["Distribution ID"] != DBNull.Value)
                            {
                                Distribution_ID = int.Parse(SelectedDataRow["Distribution ID"].ToString());
                            }
                        }
                        if (Distribution_ID != -1)
                        {

                            if (Program.Check_Opened("Distribution", Distribution_ID))
                            {
                                MessageBox.Show("لا يمكن فتح صفحة التوزيعة نفسها أكثر من مرة");
                            }
                            else
                            {
                                Form Distribution_Form = new Distribution_Form(Distribution_ID, main_form);
                                main_form.showNewTab(Distribution_Form, "Distribution");
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Family_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode && Family_RadioButton.Checked)
                {
                    SearchFor = "Family";
                    Set_Additional_Filters();

                    Bind_Search_DataGridView();
                    Bind_AdditionalColumns_CheckedListBox();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Person_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode && Person_RadioButton.Checked)
                {

                    SearchFor = "Member";
                    Set_Additional_Filters();

                    Bind_Search_DataGridView();
                    Bind_AdditionalColumns_CheckedListBox();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Partner_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode && Partner_RadioButton.Checked)
                {

                    SearchFor = "Partner";
                    Set_Additional_Filters();

                    Bind_Search_DataGridView();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Distribution_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode && Distribution_RadioButton.Checked)
                {

                    SearchFor = "Distribution";
                    Set_Additional_Filters();

                    Bind_Search_DataGridView();
                }
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

        protected override Point ScrollToControl(Control activeControl) //STOP AUTO SCROLL
        {
            Point pt = this.AutoScrollPosition;
            return pt;
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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bind_Search_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
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

        private void toolStripMenuItem2_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
                else if (SearchFor == "Partner")
                {
                    Partner_HiddenColumns.Add(e.ClickedItem.Text);
                }
                else if (SearchFor == "Distribution")
                {
                    Distribution_HiddenColumns.Add(e.ClickedItem.Text);
                }

                Bind_Show_Hide_ToolStrip();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void toolStripMenuItem3_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
                else if (SearchFor == "Partner")
                {
                    Partner_HiddenColumns.RemoveAt(Partner_HiddenColumns.IndexOf(e.ClickedItem.Text));
                }
                else if (SearchFor == "Distribution")
                {
                    Distribution_HiddenColumns.RemoveAt(Distribution_HiddenColumns.IndexOf(e.ClickedItem.Text));
                }
                Bind_Show_Hide_ToolStrip();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Show_Hide_ToolStrip_ButtonClick(object sender, EventArgs e)
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

        private void bs_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            NumOfRows1.Text = Search_DataGridView.Rows.Count.ToString();
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

                /*
                bool restartsearch = true;
                int startColumn = 0;
                int startRow = 0;
                if (!e.FromBegin)
                {
                    bool endcol; bool endrow;

                    endcol = Search_DataGridView.CurrentCell.ColumnIndex + 1 >= Search_DataGridView.ColumnCount;
                    endrow = Search_DataGridView.CurrentCell.RowIndex + 1 >= Search_DataGridView.RowCount;

                    if (endcol && endrow)
                    {
                        startColumn = Search_DataGridView.CurrentCell.ColumnIndex;
                        startRow = Search_DataGridView.CurrentCell.RowIndex;
                    }
                    else
                    {
                        startColumn = endcol ? 0 : Search_DataGridView.CurrentCell.ColumnIndex + 1;
                        startRow = Search_DataGridView.CurrentCell.RowIndex + (endcol ? 1 : 0);
                    }
                }
                DataGridViewCell c = Search_DataGridView.FindCell(
                    e.ValueToSearch,
                    e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                    startRow,
                    startColumn,
                    e.WholeWord,
                    e.CaseSensitive);
                if (c == null && restartsearch)
                {
                    c = Search_DataGridView.FindCell(
                    e.ValueToSearch,
                    e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                    0,
                    0,
                    e.WholeWord,
                   e.CaseSensitive);
                }

                if (c != null)
                {
                    Search_DataGridView.CurrentCell = c;
                    if (e.FromBegin)
                        SearchToolBar.Items["button_frombegin"].PerformClick();
                }
                else
                    MessageBox.Show("لا يوجد نتائج لعرضها");

    */
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

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        #region //Additional Filters

        private void Add_Filters_PictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (splitContainer1.Panel1Collapsed)
                {
                    Search_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    splitContainer1.Panel1Collapsed = false;
                    toolTip1.SetToolTip(Add_Filters_PictureBox, "Hide additional filters");
                    Add_Filters_PictureBox.BackgroundImage = Properties.Resources.Minus1;
                }
                else
                {
                    Search_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    splitContainer1.Panel1Collapsed = true;
                    toolTip1.SetToolTip(Add_Filters_PictureBox, "Show additional filters");
                    Add_Filters_PictureBox.BackgroundImage = F2F_Application.Properties.Resources.Plus_1;

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        public void Bind_AdditionalColumns_CheckedListBox()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Name");
            dt.Columns.Add("tableName");

            if (SearchFor == "Family")
            {
                //dt.Rows.Add(new object[] { "الطائفة", "parish" });
                //dt.Rows.Add(new object[] { "المنطقة", "street" });
                dt.Rows.Add(new object[] { "نوع الملك", "	hometype" });
                //dt.Rows.Add(new object[] { "نوع السيارة", "cartype" });
                dt.Rows.Add(new object[] { "نوع الطعام", "foodaverage" });
                dt.Rows.Add(new object[] { "النزوح", "isdisplaced" });
                //dt.Rows.Add(new object[] { "الأسرّة", "beds" });
                //dt.Rows.Add(new object[] { "غرفة المعيشة", "livingroom" });
                //dt.Rows.Add(new object[] { "الحالة الفنية للمنزل", "buildingcondition" });
                //dt.Rows.Add(new object[] { "الأجهزة الكهربائية", "electricaldavices" });
                //dt.Rows.Add(new object[] { "الممتلكات", "asset" });
                //dt.Rows.Add(new object[] { "الدخل الثابت شهرياً", "income" });
                //dt.Rows.Add(new object[] { "المصاريف", "expenses" });
                //dt.Rows.Add(new object[] { "نوع المصروف", "expensestype" });
                //dt.Rows.Add(new object[] { "المساعدات", "aid" });
                //dt.Rows.Add(new object[] { "مصدر المساعدة", "aidsource" });
                //dt.Rows.Add(new object[] { "مدة المساعدة", "aidperiod" });
                //dt.Rows.Add(new object[] { "الخسارات", "loss" });
                
                
            }
            else if (SearchFor == "Member")
            {
                //dt.Rows.Add(new object[] { "الجنس", "sex" });
                //dt.Rows.Add(new object[] { "الصفة الأسرية", "relation" });
                dt.Rows.Add(new object[] { "الحالة الاجتماعية", "maritalstatus" });
                //dt.Rows.Add(new object[] { "الجنسية", "nationality" });
                //dt.Rows.Add(new object[] { "التحصيل العلمي", "education" });
                //dt.Rows.Add(new object[] { "نوع الدراسة", "educationtype" });
                //dt.Rows.Add(new object[] { "صنف المرض", "diseasecategory" });
                dt.Rows.Add(new object[] { "المرض", "disease" });
                dt.Rows.Add(new object[] { "العمل", "workexp" });
                dt.Rows.Add(new object[] { "الحالة", "personstate" });
                dt.Rows.Add(new object[] { "مشاريع صغيرة", "person_mp_aid" });
                //dt.Rows.Add(new object[] { "جهة العمل", "workfor" });
                //dt.Rows.Add(new object[] { "صفة الشخص", "workposition" });
                //dt.Rows.Add(new object[] { "نوع المحل", "workplace" });
                //dt.Rows.Add(new object[] { "نوع العمل", "worktype" });
                //dt.Rows.Add(new object[] { "الخبرة", "experience" });
            }

            UserMode = false;
            AdditionalColumns_CheckedListBox.Items.Clear();
            foreach (DataRow DR in dt.Rows)
            {
                AdditionalColumns_CheckedListBox.Items.Add(new { Name = DR["Name"], TableName = DR["TableName"] });
                AdditionalColumns_CheckedListBox.ValueMember = "TableName";
                AdditionalColumns_CheckedListBox.DisplayMember = "Name";
            }
            UserMode = true;

        }

        private void AdditionalColumns_CheckedListBox_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < AdditionalColumns_CheckedListBox.Items.Count; i++)
                {
                    if (AdditionalColumns_CheckedListBox.GetItemRectangle(i).Contains(AdditionalColumns_CheckedListBox.PointToClient(MousePosition)))
                    {
                        switch (AdditionalColumns_CheckedListBox.GetItemCheckState(i))
                        {
                            case CheckState.Checked:
                            {
                                AdditionalColumns_CheckedListBox.SetItemChecked(i, false);
                                dynamic Item = AdditionalColumns_CheckedListBox.Items[i];

                                int k = Categories_ComboBox.Items.Count - 1;

                                for (int j = k; j >= 0; j--)
                                {
                                    dynamic Category = Categories_ComboBox.Items[j];
                                    if (Category.Name == Item.Name && Category.TableName == Item.TableName)
                                        Categories_ComboBox.Items.RemoveAt(j);
                                }

                                if (CurrentTable == Item.Name)
                                {
                                    Filter1_ComboBox.Items.Clear();
                                    Categories_ComboBox.Text = "";
                                }

                                k = AdditionalFiltersID_CheckedListBox.Items.Count - 1;
                                for (int j = k; j >= 0; j--)
                                {
                                    dynamic item1 = AdditionalFiltersID_CheckedListBox.Items[j];
                                    if (item1.TableName == Item.TableName)
                                    {
                                        AdditionalFiltersID_CheckedListBox.Items.RemoveAt(j);
                                        AdditionalFilters_CheckedListBox.Items.RemoveAt(j);
                                    }
                                }
                            }
                            break;
                            case CheckState.Indeterminate:
                            case CheckState.Unchecked:
                            {
                                AdditionalColumns_CheckedListBox.SetItemChecked(i, true);
                                dynamic itemChecked = AdditionalColumns_CheckedListBox.Items[i];

                                Categories_ComboBox.DisplayMember = "Name";
                                Categories_ComboBox.ValueMember = "TableName";
                                Categories_ComboBox.Items.Add(new { Name = itemChecked.Name, TableName = itemChecked.TableName });
                            }
                            break;
                        }
                    }
                }
                Show_Hide_Components();
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Bind_Filters_ComboBox(string TableName)
        {
            DataTable dt = c.Select_Table(TableName, "", true, false);
            UserMode = false;

            Filter1_ComboBox.Items.Clear();
            Filter1_ComboBox.Text = "";


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool Add = true;
                if (AdditionalFilters_CheckedListBox.Items.Count > 0)
                {
                    foreach (dynamic Item in AdditionalFilters_CheckedListBox.Items)
                    {
                        if (Item.Name == dt.Rows[i]["Name"].ToString() && Item.TableName == CurrentTable)
                            Add = false;
                    }
                }
                if (Add)
                {
                    Filter1_ComboBox.DisplayMember = "Name";
                    Filter1_ComboBox.ValueMember = "ID";
                    Filter1_ComboBox.Items.Add(new { Name = dt.Rows[i][1], ID = dt.Rows[i][0].ToString() });
                }
            }
            UserMode = true;

            Filter1_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
        }

        private void Categories_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    dynamic Item = Categories_ComboBox.SelectedItem;
                    string Name = Item.Name;
                    string TableName = Item.TableName;

                    CurrentTable = TableName;

                    Bind_Filters_ComboBox(TableName);
                    Filter1_ComboBox.Visible = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        public void Set_Additional_Filters()
        {
            Search_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            splitContainer1.Panel1Collapsed = true;
            Add_Filters_PictureBox.Visible = false;

            AdditionalColumns_CheckedListBox.Items.Clear();
            AdditionalFilters_CheckedListBox.Items.Clear();
            AdditionalFiltersID_CheckedListBox.Items.Clear();
            Categories_ComboBox.Items.Clear();
            Filter1_ComboBox.Items.Clear();
            Filter2_ComboBox.Items.Clear();
            AdditionalColumnsTables.Clear();
            AdditionalColumnsTables_ArabicName.Clear();
            SelectedFilterTables.Clear();

            Filter1_ComboBox.Text = Filter2_ComboBox.Text = "";

            Filter_label.Visible = Cat_label.Visible = Categories_ComboBox.Visible =
                Filter1_ComboBox.Visible = Filter2_ComboBox.Visible = false;

            CurrentTable = "";
            FilterQuery = "";

            toolTip1.SetToolTip(Add_Filters_PictureBox, "Show Additional Filters");

            Add_Filters_PictureBox.BackgroundImage = Properties.Resources.Plus_1;

            if (SearchFor == "Family" || SearchFor == "Member")
            {
                Add_Filters_PictureBox.Visible = true;
            }
        }

        private void Show_Hide_Components()
        {
            if (AdditionalColumns_CheckedListBox.CheckedItems.Count != 0)
            {
                Filter_label.Visible = Cat_label.Visible = Categories_ComboBox.Visible = Filter1_ComboBox.Visible =
                    AdditionalFilters_CheckedListBox.Visible = true;
            }
            else
            {
                Filter_label.Visible = Cat_label.Visible = Categories_ComboBox.Visible = Filter1_ComboBox.Visible =
                    AdditionalFilters_CheckedListBox.Visible = false;
            }
        }

        private void Filter1_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    dynamic Item = Filter1_ComboBox.SelectedItem;
                    string SelectedName = Item.Name;
                    string ID = Item.ID;

                    AdditionalFilters_CheckedListBox.Items.Add(new { Name = SelectedName, TableName = CurrentTable });
                    AdditionalFilters_CheckedListBox.ValueMember = "TableName";
                    AdditionalFilters_CheckedListBox.DisplayMember = "Name";

                    AdditionalFiltersID_CheckedListBox.Items.Add(new { ID = ID, TableName = CurrentTable });
                    AdditionalFiltersID_CheckedListBox.ValueMember = "TableName";
                    AdditionalFiltersID_CheckedListBox.DisplayMember = "ID";

                    AdditionalFilters_CheckedListBox.ColumnWidth = mkStrWidth(AdditionalFilters_CheckedListBox) + 20;

                    UserMode = false;
                    AdditionalFilters_CheckedListBox.SetItemChecked(AdditionalFilters_CheckedListBox.Items.Count - 1, true);
                    AdditionalFiltersID_CheckedListBox.SetItemChecked(AdditionalFiltersID_CheckedListBox.Items.Count - 1, true);

                    Filter1_ComboBox.Items.RemoveAt(Filter1_ComboBox.SelectedIndex);

                    if (!Filter1_ComboBox.DroppedDown) Filter1_ComboBox.DroppedDown = true;
                    UserMode = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private int mkStrWidth(CheckedListBox clb)
        {
            int result = 0;
            using (Font fnt = new Font("Tajawal", 11))
            {
                foreach (dynamic Item in clb.Items)
                {
                    string str = Item.Name;
                    int width = TextRenderer.MeasureText(str, fnt).Width;
                    if (width > result)
                    {
                        result = width;
                    }
                }
            }
            return result;
        }

        private void Apply_Filters_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (AdditionalColumns_CheckedListBox.CheckedItems.Count != 0)
                {
                    SelectedFilterTables.Clear();
                    AdditionalColumnsTables.Clear();
                    AdditionalColumnsTables_ArabicName.Clear();
                    FilterQuery = " ";

                    foreach (dynamic item in AdditionalColumns_CheckedListBox.CheckedItems)
                    {
                        AdditionalColumnsTables.Add(item.TableName);
                        AdditionalColumnsTables_ArabicName.Add(item.Name);
                    }

                    foreach (dynamic item in AdditionalFiltersID_CheckedListBox.Items)
                    {
                        bool Add = true;
                        if (SelectedFilterTables.Count > 0)
                            foreach (string Name in SelectedFilterTables)
                                if (Name == item.TableName)
                                    Add = false;

                        if (Add == true)
                            SelectedFilterTables.Add(item.TableName);
                    }

                    if (SelectedFilterTables.Count > 0)
                    {
                        for (int i = 0; i < SelectedFilterTables.Count; i++)
                        {
                            int Last_Table_Item_Inex = -1;

                            for (int j = 0; j < AdditionalFiltersID_CheckedListBox.Items.Count; j++)
                            {
                                dynamic item = AdditionalFiltersID_CheckedListBox.Items[j];

                                if (item.TableName == SelectedFilterTables[i])
                                    Last_Table_Item_Inex = j;
                            }

                            FilterQuery += SelectedFilterTables[i] + ".id in (";
                            for (int j = 0; j < AdditionalFiltersID_CheckedListBox.Items.Count; j++)
                            {
                                dynamic item = AdditionalFiltersID_CheckedListBox.Items[j];

                                if (item.TableName == SelectedFilterTables[i])
                                    if (j < Last_Table_Item_Inex)
                                    {
                                        FilterQuery += item.ID + ", ";
                                    }
                                    else
                                    {
                                        FilterQuery += item.ID;
                                    }
                            }

                            if (i < SelectedFilterTables.Count - 1)
                                FilterQuery += ") and ";
                            else
                                FilterQuery += ")";
                        }
                    }
                    Bind_Search_DataGridView();
                }
                else
                {
                    MessageBox.Show("لم يتم إختيار أي فلتر لإضافته", "Error");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Clear_Filters_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Set_Additional_Filters();
                Bind_AdditionalColumns_CheckedListBox();
                Bind_Search_DataGridView();
            }


            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void resetViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Distribution_HiddenColumns.Clear();
                Partner_HiddenColumns.Clear();
                Member_HiddenColumns.Clear();
                Family_HiddenColumns.Clear();

                Bind_Search_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Apply_Filters_Button_MouseLeave(object sender, EventArgs e)
        {
            Apply_Filters_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        private void Apply_Filters_Button_MouseEnter(object sender, EventArgs e)
        {
            Apply_Filters_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Clear_Filters_Button_MouseEnter(object sender, EventArgs e)
        {
            Clear_Filters_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Clear_Filters_Button_MouseLeave(object sender, EventArgs e)
        {
            Clear_Filters_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        private void AdditionalFilters_CheckedListBox_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < AdditionalFilters_CheckedListBox.Items.Count; i++)
                {
                    if (AdditionalFilters_CheckedListBox.GetItemRectangle(i).Contains(AdditionalFilters_CheckedListBox.PointToClient(MousePosition)))
                    {
                        switch (AdditionalFilters_CheckedListBox.GetItemCheckState(i))
                        {
                            case CheckState.Checked:
                            {
                                AdditionalFilters_CheckedListBox.SetItemChecked(i, false);
                                dynamic Item = AdditionalFilters_CheckedListBox.Items[i];
                                dynamic Item1 = AdditionalFiltersID_CheckedListBox.Items[i];
                                if (CurrentTable == Item.TableName)
                                {
                                    Filter1_ComboBox.DisplayMember = "Name";
                                    Filter1_ComboBox.ValueMember = "ID";
                                    Filter1_ComboBox.Items.Add(new { Name = Item.Name, ID = Item1.ID });
                                }
                                AdditionalFilters_CheckedListBox.Items.RemoveAt(i);
                                AdditionalFiltersID_CheckedListBox.Items.RemoveAt(i);
                            }
                            break;
                            case CheckState.Indeterminate:
                            case CheckState.Unchecked:
                            AdditionalFilters_CheckedListBox.SetItemChecked(i, true);
                            break;
                        }

                    }

                }
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

        private void Add_Filters_PictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel1Collapsed)
            {
                Add_Filters_PictureBox.BackgroundImage = F2F_Application.Properties.Resources.Minus2;

            }
            else
            {
                Add_Filters_PictureBox.BackgroundImage = F2F_Application.Properties.Resources.Plus_2;

            }
        }

        private void Add_Filters_PictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel1Collapsed)
            {
                Add_Filters_PictureBox.BackgroundImage = F2F_Application.Properties.Resources.Minus1;

            }
            else
            {
                Add_Filters_PictureBox.BackgroundImage = F2F_Application.Properties.Resources.Plus_1;

            }
        }

        #endregion

        private void Search_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
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

        private void Search_DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (SearchFor == "Distribution")
            {
                if (e.RowIndex < 0)
                    return;

                if (Search_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبلغ الواجب توزيعه للعائلات"
                      || Search_DataGridView.Columns[e.ColumnIndex].HeaderText == "مجموع المبلغ الموزع للعائلات"
                      || Search_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبالغ الإدارية"
                      || Search_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبلغ المتبقي"
                      || Search_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبلغ الواجب تسليمه للكنيسة"
                      || Search_DataGridView.Columns[e.ColumnIndex].HeaderText == "مجموع المبالغ المسلمة للكنيسة")
                {
                    if (e.Value != null && e.Value != DBNull.Value && e.Value != "")
                    {
                        decimal value = decimal.Parse(e.Value.ToString());

                        e.Value = value.ToString("N0");

                        e.FormattingApplied = true;
                    }
                }
            }
        }

    }
}