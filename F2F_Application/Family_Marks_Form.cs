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
    public partial class Family_Marks_Form : Form
    {
        public Family_Marks_Form(Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;

            FamilyMarks_DataGridView.DoubleBuffered(true);
        }

        Main_Form main_form;
        int Family_ID = -1;
        int markType = 0;
        string visitName = "";
        string Family_Code;
        Family f;
        BindingSource bs = new BindingSource();
        DataRow SelectedDataRow;
        string Original_Filter_String = "";
        DataSet ds_mark;
        bool user_mode;


        private void Family_Marks_Form_Load(object sender, EventArgs e)
        {
            try
            {
                user_mode = false;

                f = new Family();
                ds_mark = new DataSet();
                //Main_TableLayoutPanel.Size = new Size(this.Width, 1200);
                //splitContainer1.Size = new Size(this.Width - 20, 1200);
                //splitContainer1.SplitterDistance = splitContainer1.Width / 2;

                splitContainer1.SplitterDistance = 0;
                splitContainer1.Panel1.Visible = false;
                 
                //Clear_Boxes();
                bs.ListChanged += bs_ListChanged;
                markType_ComboBox.Items.Add("تقرير مبسط");
                markType_ComboBox.Items.Add("تقرير تفصيلي");
                markType_ComboBox.SelectedIndex = markType;

                Bind_ComboBoxes(false);
                visitName = "M&E - 3";

                Bind_FamilyMarks_DataGridView();

                user_mode = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            NumOfRows1.Text = FamilyMarks_DataGridView.Rows.Count.ToString();
        }

        private void Bind_ComboBoxes(bool KeepSelection)
        {
            string query = "";

            Program.buildConnection();

            MySqlCommand sc = new MySqlCommand();

            // and visit_name <> 'M&E - 0' 
            query += "SELECT f.visit_name as 'name', (@i := @i + 1) AS 'id' " +
                        "FROM(SELECT DISTINCT(`visit_name`) FROM family_visit WHERE `visittype_id` = 3 GROUP BY family_visit.visit_name) as f,(SELECT @i:= 0) params; ";
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
 
        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void Calculate_Family_Marks()
        {
            DialogResult dialogResult = MessageBox.Show("سيستغرق الأمر بضع ثواني، الرجاء الانتظار حتى انتهاء عملية تحديث العلامات.", "Warning", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                f.Calculate_Family_Marks();
            }
        }

        private void Bind_FamilyMarks_DataGridView()
        {
            //if (markType == 0) bs.DataSource = ds_mark.Tables[1];
            //else bs.DataSource = ds_mark.Tables[2];
            ds_mark = f.Get_Family_Marks(visitName, markType);

            bs.DataSource = ds_mark.Tables[0];
            FamilyMarks_DataGridView.ColumnHeadersVisible = false;
            FamilyMarks_DataGridView.DataSource = null;
            FamilyMarks_DataGridView.Columns.Clear();
            FamilyMarks_DataGridView.DataSource = bs;
            FamilyMarks_DataGridView.ColumnHeadersVisible = true;
            
            foreach (DataGridViewColumn c in FamilyMarks_DataGridView.Columns)
                //if (c.Name != "رمز العائلة" && c.Name != "الشريك" && c.Name != "حالة العائلة"
                //    && c.Name != "العلامة النهائية" && c.Name != "عدد المستفيدين" && c.Name != "المبلغ المستحق")
                //    c.Visible = false;
            FamilyMarks_DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NumOfRows1.Text = FamilyMarks_DataGridView.Rows.Count.ToString();
            SearchToolBar.SetColumns(FamilyMarks_DataGridView.Columns);

            bs.Filter = Original_Filter_String = bs.Sort = "";
        }

        private void FamilyMarks_DataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //Fill_Family_Marks();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Fill_Family_Marks()
        {
            SelectedDataRow = ((DataRowView)FamilyMarks_DataGridView.CurrentRow.DataBoundItem).Row;
            Family_ID = int.Parse(SelectedDataRow["Family_ID"].ToString());

            FamilyCode_Label.Text = SelectedDataRow["رمز العائلة"].ToString();
            FinalMark_Label.Text = SelectedDataRow["العلامة النهائية"].ToString();

            WorkersNum_Label.Text = SelectedDataRow["عدد العاملين"].ToString();
            WorkersPercentage_Label.Text = SelectedDataRow["عامل نسبة العاملين"].ToString();
            MembersNum_Label.Text = SelectedDataRow["عدد المستفيدين"].ToString();
            MembersIncomePercentage_Label.Text = SelectedDataRow["عامل نسبة دخل/أفراد"].ToString();

            MembersIncome_Lable.Text = string.Format("{0:N0}", decimal.Parse(SelectedDataRow["دخل الأفراد"].ToString()));
            FixedIncome_Label.Text = string.Format("{0:N0}", decimal.Parse(SelectedDataRow["الدخل الثابت"].ToString()));
            AllExpenses_label.Text = string.Format("{0:N0}", decimal.Parse(SelectedDataRow["المصاريف"].ToString()));
            IncomeExpensesMark_Label.Text = SelectedDataRow["علامة الدخل والمصاريف"].ToString();

            Savings_Label.Text = string.Format("{0:N0}", decimal.Parse(SelectedDataRow["المدخرات"].ToString()));
            SavingsMarks_Label.Text = SelectedDataRow["علامة المدخرات"].ToString();


            if (int.Parse(SelectedDataRow["الممتلكات"].ToString()) == 0)
            {
                LossAsset_Label.Text = "الفرق بين الأملاك و الخسائر: لا يتم إحتسابها في حال عدد الأملاك = 0";
                LossAsset_Label.ForeColor = Color.FromArgb(125, 0, 0);
            }
            else
            {
                LossAsset_Label.Text = "الفرق بين الأملاك و الخسائر:";
                LossAsset_Label.ForeColor = Color.Black;
            }
            AssetNum_Label.Text = SelectedDataRow["الممتلكات"].ToString();
            AssetMark_Label.Text = SelectedDataRow["علامة الممتلكات"].ToString();
            AidNum_Label.Text = SelectedDataRow["المساعدات"].ToString();
            AidMark_Label.Text = SelectedDataRow["علامة المساعدات"].ToString();
            HouseNum_Label.Text = SelectedDataRow["فرق عدد المنازل أملاك - خسارات"].ToString();
            HouseMark_Label.Text = SelectedDataRow["علامة فرق عدد المنازل"].ToString();
            ShopNum_Label.Text = SelectedDataRow["فرق عدد المحلات أملاك - خسارات"].ToString();
            ShopMark_Label.Text = SelectedDataRow["علامة فرق عدد المحلات"].ToString();
            VehicleNum_Label.Text = SelectedDataRow["فرق عدد المركبات أملاك - خسارات"].ToString();
            VehicleMark_Label.Text = SelectedDataRow["علامة فرق عدد المركبات"].ToString();
            LandNum_Label.Text = SelectedDataRow["فرق عدد الأراضي أملاك - خسارات"].ToString();
            LandMark_Label.Text = SelectedDataRow["علامة فرق عدد الأراضي"].ToString();
            FactoryNum_Label.Text = SelectedDataRow["فرق عدد المعامل أملاك - خسارات"].ToString();
            FactoryMark_Label.Text = SelectedDataRow["علامة فرق عدد المعامل"].ToString();
            AssetLossMark_Label.Text = SelectedDataRow["علامة أملاك - مساعدات - خسارات"].ToString();

            YoungFamily_Label.Text = SelectedDataRow["عائلة فتية"].ToString();
            YoungFamilyMark_Label.Text = SelectedDataRow["علامة فتوة العائلة"].ToString();
            ReceiverState_Label.Text = SelectedDataRow["حالة رب الأسرة"].ToString();
            ReceiverStateMark_Label.Text = SelectedDataRow["علامة رب الأسرة"].ToString();
            MembesrNum_Label.Text = SelectedDataRow["عدد المستفيدين"].ToString();
            MembesrMark_Label.Text = SelectedDataRow["علامة المستفيدين"].ToString();
            BabiesNum_Label.Text = SelectedDataRow["عدد الأطفال"].ToString();
            BabiesMark_Label.Text = SelectedDataRow["علامة الأطفال"].ToString();
            ChildrenNum_Label.Text = SelectedDataRow["عدد القاصرين"].ToString();
            ChildrenMark_Label.Text = SelectedDataRow["علامة القاصرين"].ToString();
            ElderliesNum_Label.Text = SelectedDataRow["عدد المسنين"].ToString();
            ElderliesMark_Label.Text = SelectedDataRow["علامة المسنين"].ToString();
            WithFatalDiseasesNum_Label.Text = SelectedDataRow["يعانون أمراض مميتة"].ToString();
            FatalDiseasesMark_Label.Text = SelectedDataRow["علامة الأمراض المميتة"].ToString();
            WithDisabilityNum_Label.Text = SelectedDataRow["ذوي إحتياجات خاصة"].ToString();
            DisabilityMark_Label.Text = SelectedDataRow["علامة الإحتياجات الخاصة"].ToString();
            SoldierNum_Label.Text = SelectedDataRow["عدد العسكريين"].ToString();
            SoldierMark_Label.Text = SelectedDataRow["علامة العسكريين"].ToString();
            StudentsNum_Label.Text = SelectedDataRow["عدد الطلاب"].ToString();
            StudentsMark_Label.Text = SelectedDataRow["علامة الطلاب"].ToString();
            GovEducationNum_Label.Text = SelectedDataRow["الدراسة الحكومية"].ToString();
            GovEducationMark_Label.Text = SelectedDataRow["علامة الدراسة الحكومية"].ToString();
            NonGovEducationNum_Label.Text = SelectedDataRow["الدراسة غير الجكومية - مدفوعة"].ToString();
            NonGovEducationMark_Label.Text = SelectedDataRow["علامة الدراسة غير الحكومية"].ToString();
            WithDiseasesNum_Label.Text = SelectedDataRow["عدد المرضى - مرض عادي"].ToString();
            DiseasesMark_Label.Text = SelectedDataRow["علامة المرضى"].ToString();


            FamilyMembersTotalMark_Label.Text = SelectedDataRow["علامة أفراد الأسرة"].ToString();


            IsDisplaced_Label.Text = SelectedDataRow["النزوح"].ToString();
            IsDisplacedMark_Label.Text = SelectedDataRow["علامة النزوح"].ToString();
            HomeType_Label.Text = SelectedDataRow["السكن الحالي"].ToString();
            HomeTypeMark_Label.Text = SelectedDataRow["علامة السكن الحالي"].ToString();
            BuildingCondition_Label.Text = SelectedDataRow["الحالة الفنية للمنزل"].ToString();
            BuildingConditionMark_Label.Text = SelectedDataRow["علامة حالة المنزل"].ToString();
            Livingroom_label.Text = SelectedDataRow["غرفة المعيشة"].ToString();
            LivingroomMark_label.Text = SelectedDataRow["علامة غرفة المعيشة"].ToString();
            Beds_Label.Text = SelectedDataRow["الأسرّة"].ToString();
            BedsMark_Label.Text = SelectedDataRow["علامة الأسرّة"].ToString();
            ElectricalDavices_Label.Text = SelectedDataRow["الأجهزة الكهربائية"].ToString();
            ElectricalDavicesMark_Label.Text = SelectedDataRow["علامة الأجهزة الكهربائية"].ToString();
            LivingWithFamily_Label.Text = SelectedDataRow["تسكن مع عائلة أخرى"].ToString();
            LivingWithFamilyMark_Label.Text = SelectedDataRow["علامة السكن مع عائلة أخرى"].ToString();
            SellingFurniture_Label.Text = SelectedDataRow["بيع أغراض المنزل"].ToString();
            SellingFurnitureMark_Label.Text = SelectedDataRow["علامة بيع أغراض المنزل"].ToString();
            LivingMark_Label.Text = SelectedDataRow["علامة المعيشة"].ToString();
        }

        private void Clear_Boxes()
        {
            Family_ID = -1;

            FamilyCode_Label.Text = "";
            FinalMark_Label.Text = "";
            WorkersNum_Label.Text = "";
            MembersNum_Label.Text = "";
            WorkersPercentage_Label.Text = "";
            MembersIncomePercentage_Label.Text = "";
            MembersIncome_Lable.Text = "";
            FixedIncome_Label.Text = "";
            AllExpenses_label.Text = "";
            IncomeExpensesMark_Label.Text = "";

            Savings_Label.Text = "";
            SavingsMarks_Label.Text = "";


            LossAsset_Label.Text = "الفرق بين الأملاك و الخسائر:";
            AssetNum_Label.Text = "";
            AssetMark_Label.Text = "";
            AidNum_Label.Text = "";
            AidMark_Label.Text = "";
            HouseNum_Label.Text = "";
            HouseMark_Label.Text = "";
            ShopNum_Label.Text = "";
            ShopMark_Label.Text = "";
            VehicleNum_Label.Text = "";
            VehicleMark_Label.Text = "";
            LandNum_Label.Text = "";
            LandMark_Label.Text = "";
            FactoryNum_Label.Text = "";
            FactoryMark_Label.Text = "";
            AssetLossMark_Label.Text = "";

            YoungFamily_Label.Text = "";
            YoungFamilyMark_Label.Text = "";
            ReceiverState_Label.Text = "";
            ReceiverStateMark_Label.Text = "";
            MembesrNum_Label.Text = "";
            MembesrMark_Label.Text = "";
            BabiesNum_Label.Text = "";
            BabiesMark_Label.Text = "";
            ChildrenNum_Label.Text = "";
            ChildrenMark_Label.Text = "";
            ElderliesNum_Label.Text = "";
            ElderliesMark_Label.Text = "";
            WithFatalDiseasesNum_Label.Text = "";
            FatalDiseasesMark_Label.Text = "";
            WithDisabilityNum_Label.Text = "";
            DisabilityMark_Label.Text = "";
            SoldierNum_Label.Text = "";
            SoldierMark_Label.Text = "";
            StudentsNum_Label.Text = "";
            StudentsMark_Label.Text = "";
            GovEducationNum_Label.Text = "";
            GovEducationMark_Label.Text = "";
            NonGovEducationNum_Label.Text = "";
            NonGovEducationMark_Label.Text = "";
            //WorkerNum_Label.Text = "";
            //WorkerMark_Label.Text = "";
            WithDiseasesNum_Label.Text = "";
            DiseasesMark_Label.Text = "";
            //MembersNum_Label.Text = "";
            //MembersMark_Label.Text = "";
            FamilyMembersTotalMark_Label.Text = "";


            IsDisplaced_Label.Text = "";
            IsDisplacedMark_Label.Text = "";
            HomeType_Label.Text = "";
            HomeTypeMark_Label.Text = "";
            BuildingCondition_Label.Text = "";
            BuildingConditionMark_Label.Text = "";
            Livingroom_label.Text = "";
            LivingroomMark_label.Text = "";
            Beds_Label.Text = "";
            BedsMark_Label.Text = "";
            ElectricalDavices_Label.Text = "";
            ElectricalDavicesMark_Label.Text = "";
            LivingWithFamily_Label.Text = "";
            LivingWithFamilyMark_Label.Text = "";
            LivingMark_Label.Text = "";
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                Bind_FamilyMarks_DataGridView();
                Clear_Boxes();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Family_ID == -1)
                {
                    MessageBox.Show("الرجاء تحديد العائلة أولا", "Error");
                    return;
                }
                else
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
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        protected override Point ScrollToControl(Control activeControl) //STOP AUTO SCROLL
        {
            Point pt = this.AutoScrollPosition;
            return pt;
        }

        private void FamilyMarks_DataGridView_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            try
            {
                bs.Sort = FamilyMarks_DataGridView.SortString;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void FamilyMarks_DataGridView_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            try
            {
                Original_Filter_String = FamilyMarks_DataGridView.FilterString;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void FamilyMarks_DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            NumOfSelected1.Text = FamilyMarks_DataGridView.SelectedRows.Count.ToString();

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
                        int VisibleColumnsCount = FamilyMarks_DataGridView.Columns.GetColumnCount(DataGridViewElementStates.Visible);
                        int i = 0;
                        foreach (DataGridViewColumn C in FamilyMarks_DataGridView.Columns)
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

        private void ToolStripMenuItem_SimpleReport_Click(object sender, EventArgs e)
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

                    foreach (DataGridViewColumn c in FamilyMarks_DataGridView.Columns)
                    {
                        if (c.Visible == false)
                            dt.Columns.RemoveAt(dt.Columns.IndexOf(dt.Columns[c.Name]));
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

        private void ToolStripMenuItem_FullReport_Click(object sender, EventArgs e)
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

        private void Export_ToolStrip_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                Export_ToolStrip.ShowDropDown();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void viewChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string[] selectedColumns = new[] { "رمز العائلة", "العلامة النهائية" };
                DataTable Source = ((DataTable)bs.DataSource).DefaultView.ToTable(false, selectedColumns);

                MarksChart_Form MarksChart_Form = new MarksChart_Form(main_form, Source);
                MarksChart_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }

            }
        }

        private void markType_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (user_mode)
                {
                    if (markType_ComboBox.SelectedIndex == 0)
                    {
                        //تقرير مبسط
                        markType = 0;
                        FamilyMarks_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    else
                    {
                        //تقرير تفصيلي
                        markType = 1;
                        FamilyMarks_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        for (int i = 0; i < FamilyMarks_DataGridView.ColumnCount; i++)
                        {
                            DataGridViewColumn column = FamilyMarks_DataGridView.Columns[i];
                            column.Width = 100;
                        }

                    }

                    Bind_FamilyMarks_DataGridView();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Main_TableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Visits_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (user_mode)
                {
                    if (Visits_ComboBox.Text != "")
                        visitName = Visits_ComboBox.Text;
                    
                    Bind_FamilyMarks_DataGridView();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LoadData_toolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Calculate_Family_Marks();
                Bind_FamilyMarks_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
    }
}
