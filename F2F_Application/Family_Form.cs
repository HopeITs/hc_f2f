using F2F_Application.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace F2F_Application
{
    public partial class Family_Form : Form
    {
        public Family_Form(Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            PowerLabel.ForeColor = Color.White;
            UpdateMode = false;
            UserMode = true;
            MyDataGridViewInitializationMethod();
            Beneficiaries_DataGridView.DoubleBuffered(true);
            //NonBeneficiaries_DataGridView.DoubleBuffered(true);

            //Hide_MenuItem.DropDown.Closing += Hide_MenuItem_Closing;
            //Show_MenuItem.DropDown.Closing += Show_MenuItem_Closing;

            materialTabSelector1.Dock = DockStyle.Top;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public Family_Form(int Family_ID, Main_Form main_form, bool IsPopUp)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.Family_ID = Family_ID;
            UpdateMode = true;
            MyDataGridViewInitializationMethod();
            Beneficiaries_DataGridView.DoubleBuffered(true);

            //NonBeneficiaries_DataGridView.DoubleBuffered(true);
            //Hide_MenuItem.DropDown.Closing += Hide_MenuItem_Closing;
            //Show_MenuItem.DropDown.Closing += Show_MenuItem_Closing;

            materialTabSelector1.Dock = DockStyle.Top;

            if (IsPopUp)
                this.FormBorderStyle = FormBorderStyle.Sizable;
            else
                this.FormBorderStyle = FormBorderStyle.None;
        }

        Main_Form main_form;
        int Family_ID = -1;
        bool UpdateMode;
        Family f; Categories c; Visits v; Person p;
        bool DataApproved = false;
        bool UserMode = false;
        DataRow SelectedDataRow;
        int NumOfUpdateTry;
        string CurrentFamilyVisitState;
        bool Deleted = false; bool toPopUp = false;
        bool CodeChecked = false;

        #region //IsDirty
        bool General_Information_IsDirty = false, Partner_DataGridView_IsDirty = false, FamilyVisitState_IsDirty = false, LivingWith_DataGridView_IsDirty = false,
            Income_DataGridView_IsDirty = false, Aid_DataGridView_IsDirty = false, Loss_DataGridView_IsDirty = false,
            Asset_DataGridView_IsDirty = false, Living_Information_IsDirty = false, PowerExpenses_DataGridView_IsDirty = false,
            LivingCondition_DataGridView_IsDirty = false, Expenses_DataGridView_IsDirty = false, Electrical_Devices_IsDirty = false,
            Aid_Information_IsDirty = false, Lighting_Information_IsDirty = false, CarAsset_DataGridView_IsDirty = false,
            LivingCondition_Information_IsDirty = false, BuildingCondition_Information_isDirty = false, Expenses_Information_IsDirty = false;
        #endregion

        #region //Data
        string Code, OtherVisitors, FamilyNumber, Note, FamilyNote, PartnerNote, WillNotReason, LivingWithNote, FamilyVisitState, Address, LandLine, MobileNumber, SellingFurnitureNote, Form_Name
            , DateOfEntry, EvaluationNote, InEvaluationBy,EvaluationDate, ApprovedBy,
            ApprovalDate, PDMBy, PDMDate, PVMBy, PVMDate, ComplaintDate, ComplaintBy, ComplaintNote
            , LivingWithNote2, home_description, Expenses_10,
             ElectricityNote, NoteAid_11, NoteAid_19, NoteAid_20, NoteAid_12, NoteAid_17_home, NoteAid_16_home,
            income_address_12;
        decimal LocationLatitude, LocationLongtitude, AmperNumber_7_Home, AmperNumber_17_Home;
        int Visit_ID, EntredBy, EntredBy2, Visitor1, Visitor2, RoomsNumber, PDM, PVM, Complaint, Approved, Parish_ID, Street_ID, IsDisplaced_ID, HomeType_ID, ExpensesAmount_10, aidamount_11, aidamount_20, aidamount_19, NumberOfAllMembers, Floor, BuildingNumber, expenses_amount_6_12_home, ExpensesAmount_2_Home, ExpensesAmount_3, ExpensesAmount_21, ExpensesAmount_19, ExpensesAmount_22,
            ExpensesAmount_20, ExpensesAmount_11, HeirsNumber, aidamount_5_3_home, expenses_amount_7_Home, 
            aidamount_4, aidsource_4, aidperiod_4, aidsource_16, aidperiod_16, SellingFurniture_type_1, SellingFurniture_type_2, aidamount_16, aidamount_14, aidamount_12, aidamount_17_Home, aidamount_16_Home,
            Expenses_1, expensestype_6_12_home_ID, ParishHomeID, aidsource_5_3_home_ID, aidperiod_5_3_home_ID, Beds_ID, LivingRoom_ID, LivingWithFamily, InEvaluation, HeatingCooling_1, HeatingCooling_2, HeatingCooling_3, HeatingCooling_4;
        int? Income_11, Expenses_7_Home, Expenses_17_Home, Expenses_16_Home, Electricity, LivingWithCode, LivingWithCode2, SellingFurniture, ElectricalDevices_1, ElectricalDevices_2, ElectricalDevices_3, BuildingCond_1, BuildingCond_2, BuildingCond_3, BuildingCond_5, BuildingCond_8,
            aidsource_11, aidsource_20, aidsource_19, aidsource_14, aidsource_12, aidsource_16_Home, aidsource_17_Home,
            aidperiod_11, aidperiod_20, aidperiod_19, aidperiod_14, aidperiod_12, aidperiod_16_Home, aidperiod_17_Home,
            IncomeRelation_12, aidamount_30, aidperiod_30,aid_11, aid_12, aid_20, aid_19, aid_14, aid_17_home, aid_16_home;
        string LivingWith_Query, Partner_Query, General_Query, Income_Query, Aid_Query, Loss_Query, Asset_Query, CarAsset_Query, LivingCondition_Query, Expenses_Query, ElectricalDevices_Query, Lighting_Query, BuildingCondition_Query;
        #endregion

        #region //Original
        string FamilyCode_TextBox_OriginalText, FamilyNumber_TextBox_OriginalText, Note_TextBox_OriginalText, FamilyNote_TextBox_OriginalText, PartnerNote_TextBox_OriginalText, WillNotReason_TextBox_OriginalText,
            Address_TextBox_OriginalText, LandLine_TextBox_OriginalText, MobileNumber_TextBox_OriginalText, LivingWithNote_TextBox_OriginalText, SellingFurnitureNote_TextBox_OriginalText,
            LocationLongtitude_TextBox_OriginalText, LocationLatitude_TextBox_OriginalText, BuildingNumber_TextBox_OriginalText, Floor_TextBox_OriginalText, RoomsNumber_TextBox_OriginalText,
            EntredBy_TextBox_OriginalText, DateOfEntry_TextBox_OriginalText, EvaluationNote_TextBox_OriginalText, InEvaluationBy_TextBox_OriginalText, ApprovedBy_TextBox_OriginalText,
            ApprovalDate_TextBox_OriginalText, PDMBy_TextBox_OriginalText, PDMDate_TextBox_OriginalText, PVMBy_TextBox__OriginalText, PVMDate_TextBox__OriginalText,
            NumberOfAllMembers_TextBox_OriginalText, LivingWithNote2_TextBox_OriginalText, expenses_amount_6_12_home_TextBox_OriginalText, home_description_TextBoxOriginalText,
            HeirsNumber_TextBox_OriginalText, aidamount_5_3_home_TextBox_OriginalText, expenses_amount_7_Home_TextBox_OriginalText, AmperNumber_7_Home_TextBox_OriginalText,
            aidamount_4_TextBox_OriginalText, AmperNumber_17_Home_TextBox_OriginalText, aidamount_16_TextBox_OriginalText, ElectricityNote_TextBox_OriginalText,
            ExpensesAmount_2_Home_TextBox_OriginalText, ExpensesAmount_3_TextBox_OriginalText, ExpensesAmount_21_TextBox_OriginalText, ExpensesAmount_19_TextBox_OriginalText, ExpensesAmount_22_TextBox_OriginalText,
            ExpensesAmount_20_TextBox_OriginalText, ExpensesAmount_11_TextBox_OriginalText, Expenses_10_TextBox_OriginalText,
            ExpensesAmount_10_TextBox__OriginalText, aidamount_11_TextBox_OriginalText, aidamount_20_TextBox_OriginalText, aidamount_19_TextBox_OriginalText,
            aidamount_14_TextBox_OriginalText, aidamount_12_TextBox_OriginalText, aidamount_17_Home_TextBox_OriginalText, aidamount_16_Home_TextBox_OriginalText,
            NoteAid_11_TextBox_OriginalText, NoteAid_19_TextBox_OriginalText, NoteAid_20_TextBox_OriginalText, NoteAid_12_TextBox_OriginalText, NoteAid_17_home_TextBox_OriginalText, NoteAid_16_home_TextBox_OriginalText,
            income_address_12_TextBox_OriginalText, aidamount_30_TextBox_OriginalText, PartnerNote_TextBox__OriginalText, ComplaintNote_TextBox_OriginalText, home_description_TextBox_OriginalText, ComplaintBy_TextBox_OriginalText, ComplaintDate_TextBox_OriginalText, EntredByOther_TextBox_OriginalText;
        #endregion

        private void Family_Form_Load(object sender, EventArgs e)
        {
            try
            {
                f = new Family(); c = new Categories(); v = new Visits(); p = new Person();
                VisitNameLabel.ForeColor = visitNoteLabel.ForeColor = VisitLabel.ForeColor = VisitInfoLabel.ForeColor = totalIncomeLabel.ForeColor = totalExpensesLabel.ForeColor = totalLabel.ForeColor = totalLabel2.ForeColor = totalLabel1.ForeColor = totalAidLabel.ForeColor = GeneralNoteLable.ForeColor = BeneficiaryLable.ForeColor = PartnersLabel.ForeColor = InEvaluation_RadioButton.ForeColor = InfoLabel.ForeColor = LivingConditionLabel.ForeColor = ExpensesLabel.ForeColor = AidsLable.ForeColor = RelativeAidLable.ForeColor = LightLable.ForeColor = AssetsLable.ForeColor = FurnitureLabel.ForeColor = IncomeLable.ForeColor = BuildingConditionLabel.ForeColor = ElectricalDevicesLabel.ForeColor = Color.White;
                VisitNameLabel.Font = visitNoteLabel.Font = VisitLabel.Font = VisitInfoLabel.Font = totalIncomeLabel.Font = totalExpensesLabel.Font = totalLabel1.Font = totalLabel2.Font = totalLabel.Font = totalAidLabel.Font = GeneralNoteLable.Font = BeneficiaryLable.Font = PartnersLabel.Font = InEvaluation_RadioButton.Font = InfoLabel.Font = LivingConditionLabel.Font = ExpensesLabel.Font = AidsLable.Font = RelativeAidLable.Font = LightLable.Font = AssetsLable.Font = FurnitureLabel.Font = IncomeLable.Font = BuildingConditionLabel.Font = ElectricalDevicesLabel.Font = new Font("Arial", 14);
                Bind_ComboBoxes(false);
                VisitNameLabel.Text = "";
                Set_Controls();

                if (UpdateMode)
                {
                    UserMode = false;
                    DataSet ds1 = f.Get_FamilyLastVisit(Family_ID);
                    if (ds1.Tables[0].Rows.Count == 0)
                    {
                        Visit_ID = -1;
                        VisitNameLabel.Text = "لم يزار بعد";
                    }
                    else Visit_ID = ds1.Tables[0].Rows[0].Field<int>("id");
                    ME_DataGridView.Visible = true;
                    panel1.Visible = true;
                    members_table.Visible = true;
                    FamilyHistory_Button.Visible = true;
                    Fill_Family(true, Visit_ID);
                    Bind_Members();
                    //Added By Mai
                    Bind_Visits("ME");
                    ME_DataGridView.ClearSelection();
                    if (ME_DataGridView.Rows.Count != 0)
                    {
                        foreach (DataGridViewRow row in ME_DataGridView.Rows)
                        {
                            if (row.Cells[0].Value != null && row.Cells[0].Value.Equals(Visit_ID))
                            {
                                int index = row.Index;
                                ME_DataGridView.CurrentCell = ME_DataGridView.Rows[index].Cells[1];
                                break;
                            }
                            if (row.Cells[0].Value == null)
                            {
                                secondtableLayoutPanel.Visible = false;
                            }
                        }
                    }
                    UserMode = true;
                }
                else if (!UpdateMode)
                {
                    //DateOfEntry_TextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    EntredByOther_TextBox.Text = Properties.Settings.Default.Username;
                    EntredBy_comboBox.Enabled = EntredBy2_comboBox.Enabled = true;
                    //NumberOfBeneficiary_TextBox.Text = "0";
                    NumberOfAllMembers_TextBox.Text = "0";
                    secondtableLayoutPanel.Visible = false;
                    members_table.Visible = false;
                    ME_DataGridView.Visible = false;
                    panel1.Visible = false;
                    FamilyHistory_Button.Visible = false;
                }
                Check_User_Role();

                if (Family_ID != -1)
                    Program.Family_Opened.Add(Family_ID);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Family_Form_Shown(object sender, EventArgs e)
        {
            try
            {
                materialTabControl1.Size = new Size(this.Width - 20, 3200);
                materialTabSelector1.Size = new Size(this.Width - 20, 50);

                Stop_Highlighting_Combobox();


            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }

            }
        }

        private void Family_Form_Enter(object sender, EventArgs e)
        {
            try
            {
                Stop_Highlighting_Combobox();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }

            }
        }

        private void Stop_Highlighting_Combobox()
        {
            Parish_ComboBox.SelectionLength = 0; Parish_ComboBox.SelectionStart = Parish_ComboBox.Text.Length;
            Street_ComboBox.SelectionLength = 0; Street_ComboBox.SelectionStart = Street_ComboBox.Text.Length;
            IsDisplaced_ComboBox.SelectionLength = 0; IsDisplaced_ComboBox.SelectionStart = IsDisplaced_ComboBox.Text.Length;
            HomeType_ComboBox.SelectionLength = 0; HomeType_ComboBox.SelectionStart = HomeType_ComboBox.Text.Length;
            Beds_ComboBox.SelectionLength = 0; Beds_ComboBox.SelectionStart = Beds_ComboBox.Text.Length;
            Livingroom_ComboBox.SelectionLength = 0; Livingroom_ComboBox.SelectionStart = Livingroom_ComboBox.Text.Length;
            //LivingWithCode_ComboBox.SelectionLength = 0; LivingWithCode_ComboBox.SelectionStart = LivingWithCode_ComboBox.Text.Length;

            //Added By Mai
            aidsource_4_ComboBox.SelectionLength = 0; aidsource_4_ComboBox.SelectionStart = aidsource_4_ComboBox.Text.Length;
            aidsource_16_ComboBox.SelectionLength = 0; aidsource_16_ComboBox.SelectionStart = aidsource_16_ComboBox.Text.Length;
            aidperiod_4_ComboBox.SelectionLength = 0; aidperiod_4_ComboBox.SelectionStart = aidperiod_4_ComboBox.Text.Length;
            aidperiod_16_ComboBox.SelectionLength = 0; aidperiod_16_ComboBox.SelectionStart = aidperiod_16_ComboBox.Text.Length;
            expensestype_6_12_home_ComboBox.SelectionLength = 0; expensestype_6_12_home_ComboBox.SelectionStart = expensestype_6_12_home_ComboBox.Text.Length;
            ParishHome_ComboBox.SelectionLength = 0; ParishHome_ComboBox.SelectionStart = ParishHome_ComboBox.Text.Length;
            aidsource_5_3_home_ComboBox.SelectionLength = 0; aidsource_5_3_home_ComboBox.SelectionStart = aidsource_5_3_home_ComboBox.Text.Length;
            aidperiod_5_3_home_ComboBox.SelectionLength = 0; aidperiod_5_3_home_ComboBox.SelectionStart = aidperiod_5_3_home_ComboBox.Text.Length;
            Expenses_1_comboBox.SelectionLength = 0; Expenses_1_comboBox.SelectionStart = Expenses_1_comboBox.Text.Length;
            aidsource_11_comboBox.SelectionLength = 0; aidsource_11_comboBox.SelectionStart = aidsource_11_comboBox.Text.Length;
            aidsource_12_comboBox.SelectionLength = 0; aidsource_12_comboBox.SelectionStart = aidsource_12_comboBox.Text.Length;
            aidsource_19_comboBox.SelectionLength = 0; aidsource_19_comboBox.SelectionStart = aidsource_19_comboBox.Text.Length;
            aidsource_17_home_comboBox.SelectionLength = 0; aidsource_17_home_comboBox.SelectionStart = aidsource_17_home_comboBox.Text.Length;
            aidsource_16_home_comboBox.SelectionLength = 0; aidsource_16_home_comboBox.SelectionStart = aidsource_16_home_comboBox.Text.Length;
            aidsource_20_comboBox.SelectionLength = 0; aidsource_20_comboBox.SelectionStart = aidsource_20_comboBox.Text.Length;
            aidsource_14_comboBox.SelectionLength = 0; aidsource_14_comboBox.SelectionStart = aidsource_14_comboBox.Text.Length;
            aidperiod_11_comboBox.SelectionLength = 0; aidperiod_11_comboBox.SelectionStart = aidperiod_11_comboBox.Text.Length;
            aidperiod_12_comboBox.SelectionLength = 0; aidperiod_12_comboBox.SelectionStart = aidperiod_12_comboBox.Text.Length;
            aidperiod_19_comboBox.SelectionLength = 0; aidperiod_19_comboBox.SelectionStart = aidperiod_19_comboBox.Text.Length;
            aidperiod_17_home_comboBox.SelectionLength = 0; aidperiod_17_home_comboBox.SelectionStart = aidperiod_17_home_comboBox.Text.Length;
            aidperiod_16_home_comboBox.SelectionLength = 0; aidperiod_16_home_comboBox.SelectionStart = aidperiod_16_home_comboBox.Text.Length;
            aidperiod_20_comboBox.SelectionLength = 0; aidperiod_20_comboBox.SelectionStart = aidperiod_20_comboBox.Text.Length;
            aidperiod_14_comboBox.SelectionLength = 0; aidperiod_14_comboBox.SelectionStart = aidperiod_14_comboBox.Text.Length;
            aidperiod_30_comboBox.SelectionLength = 0; aidperiod_30_comboBox.SelectionStart = aidperiod_30_comboBox.Text.Length;
            IncomeRelation_12_comboBox.SelectionLength = 0; IncomeRelation_12_comboBox.SelectionStart = IncomeRelation_12_comboBox.Text.Length;
            EntredBy_comboBox.SelectionLength = 0; EntredBy_comboBox.SelectionStart = EntredBy_comboBox.Text.Length;
            EntredBy2_comboBox.SelectionLength = 0; EntredBy2_comboBox.SelectionStart = EntredBy2_comboBox.Text.Length;
            Visitor1_comboBox.SelectionLength = 0; Visitor1_comboBox.SelectionStart = Visitor1_comboBox.Text.Length;
            Visitor2_comboBox.SelectionLength = 0; Visitor2_comboBox.SelectionStart = Visitor2_comboBox.Text.Length;
        }

        private void Check_User_Role()
        {
            if (Properties.Settings.Default.Role == "Viewer")
            {
                this.Visits_TabPage.Parent = null;
                this.Marks_TabPage.Parent = null;

                secondtableLayoutPanel.Enabled = false;
                //tableLayoutPanel3.Enabled = false;

                DistributionHistory_Button.Visible = false;
                //pictureBox2.Visible = false;
                //GoToFamily_Button.Visible = false;
                Delete_Button.Visible = false;
                //Save_Button.Visible = false;
                Update_Button.Visible = false;
                //history.Visible = false;
                //add.Visible = false;

                secondtableLayoutPanel.ContextMenuStrip = new ContextMenuStrip();
                //tableLayoutPanel1.ContextMenuStrip = new ContextMenuStrip();
                tableLayoutPanel5.ContextMenuStrip = new ContextMenuStrip();

                //Expenses_DataGridView.Visible = false;
                Income_DataGridView.Visible = false;
            }
            else if (Properties.Settings.Default.Role != "Admin" && Properties.Settings.Default.Role != "L0_Admin")
            {
                Delete_Button.Visible = false;
            }
        }

        private void Bind_ComboBoxes(bool KeepSelection)
        {
            List<string> From_Tables = new List<string> { "parish", "street", "hometype", "isdisplaced", "beds", "livingroom", "partner", "income", "aid", "aidsource", "aidperiod", "expenses", "expensestype", "loss", "asset", "buildingcondition", "electricaldavices", "cartype", "foodaverage", "relation", "visitor", "visitstate", "donor"};

            DataSet Tables = c.Select_Tables(From_Tables, true);
            DataTable dt00 = f.Get_LivingWith(Family_ID);
            //DataTable dt001 = f.Get_LivingWith(Family_ID);

            DataTable dt0 = Tables.Tables[0].Copy();
            DataTable dt01 = Tables.Tables[0].Copy();
            DataTable dt1 = Tables.Tables[1].Copy();
            DataTable dt2 = Tables.Tables[2].Copy();
            DataTable dt21 = Tables.Tables[2].Copy();
            DataTable dt22 = Tables.Tables[2].Copy();

            DataTable dt3 = Tables.Tables[3].Copy();
            DataTable dt4 = Tables.Tables[4].Copy();
            DataTable dt5 = Tables.Tables[5].Copy();
            DataTable dt51 = Tables.Tables[5].Copy();

            DataTable dt9 = Tables.Tables[9].Copy();
            DataTable dt91 = Tables.Tables[9].Copy();
            DataTable dt92 = Tables.Tables[9].Copy();
            DataTable dt93 = Tables.Tables[9].Copy();
            DataTable dt94 = Tables.Tables[9].Copy();
            DataTable dt95 = Tables.Tables[9].Copy();
            DataTable dt96 = Tables.Tables[9].Copy();
            DataTable dt97 = Tables.Tables[9].Copy();
            DataTable dt98 = Tables.Tables[9].Copy();
            DataTable dt99 = Tables.Tables[9].Copy();

            DataTable dt10 = Tables.Tables[10].Copy();
            DataTable dt101 = Tables.Tables[10].Copy();
            DataTable dt102 = Tables.Tables[10].Copy();
            DataTable dt103 = Tables.Tables[10].Copy();
            DataTable dt104 = Tables.Tables[10].Copy();
            DataTable dt105 = Tables.Tables[10].Copy();
            DataTable dt106 = Tables.Tables[10].Copy();
            DataTable dt107 = Tables.Tables[10].Copy();
            DataTable dt108 = Tables.Tables[10].Copy();
            DataTable dt109 = Tables.Tables[10].Copy();
            DataTable dt1010 = Tables.Tables[10].Copy();

            DataTable dt12 = Tables.Tables[12].Copy();
            DataTable dt121 = Tables.Tables[12].Copy();

            DataTable dt14 = Tables.Tables[14].Copy();
            DataTable dt17 = Tables.Tables[17].Copy();

            DataTable dt19 = Tables.Tables[19].Copy();
            DataTable dt18 = Tables.Tables[18].Copy();

            DataTable dt20 = Tables.Tables[20].Copy();
            DataTable dt201 = Tables.Tables[20].Copy();
            DataTable dt202 = Tables.Tables[20].Copy();
            DataTable dt203 = Tables.Tables[20].Copy();

            DataTable dt210 = Tables.Tables[21].Copy();
            DataTable dt211 = Tables.Tables[21].Copy();
            DataTable dt212 = Tables.Tables[21].Copy();
            DataTable dt213 = Tables.Tables[21].Copy();

            DataTable dt220 = Tables.Tables[22].Copy();
            DataTable dt221 = Tables.Tables[22].Copy();

            //Bing ComboBoxes
            Bind_ComboBox(Parish_ComboBox, dt0, KeepSelection);
            Bind_ComboBox(Street_ComboBox, dt1, KeepSelection);
            Bind_ComboBox(HomeType_ComboBox, dt2, KeepSelection);
            Bind_ComboBox(IsDisplaced_ComboBox, dt3, KeepSelection);
            Bind_ComboBox(Beds_ComboBox, dt4, KeepSelection);
            Bind_ComboBox(Livingroom_ComboBox, dt5, KeepSelection);
            Bind_ComboBox(aidsource_4_ComboBox, dt9, KeepSelection);
            Bind_ComboBox(aidsource_16_ComboBox, dt91, KeepSelection);
            Bind_ComboBox(aidperiod_4_ComboBox, dt10, KeepSelection);
            Bind_ComboBox(aidperiod_16_ComboBox, dt101, KeepSelection);
            Bind_ComboBox(Livingroom_ComboBox, dt51, KeepSelection);

            Bind_ComboBox(expensestype_6_12_home_ComboBox, dt12, KeepSelection);
            Bind_ComboBox(ParishHome_ComboBox, dt01, KeepSelection);
            Bind_ComboBox(aidsource_5_3_home_ComboBox, dt92, KeepSelection);
            Bind_ComboBox(aidperiod_5_3_home_ComboBox, dt102, KeepSelection);
            Bind_ComboBox(Expenses_1_comboBox, dt18, KeepSelection);

            Bind_ComboBox(aidsource_11_comboBox, dt93, KeepSelection);
            Bind_ComboBox(aidsource_12_comboBox, dt94, KeepSelection);
            Bind_ComboBox(aidsource_19_comboBox, dt95, KeepSelection);
            Bind_ComboBox(aidsource_17_home_comboBox, dt96, KeepSelection);
            Bind_ComboBox(aidsource_16_home_comboBox, dt97, KeepSelection);
            Bind_ComboBox(aidsource_20_comboBox, dt98, KeepSelection);
            Bind_ComboBox(aidsource_14_comboBox, dt99, KeepSelection);

            Bind_ComboBox(aidperiod_11_comboBox, dt103, KeepSelection);
            Bind_ComboBox(aidperiod_12_comboBox, dt104, KeepSelection);
            Bind_ComboBox(aidperiod_19_comboBox, dt105, KeepSelection);
            Bind_ComboBox(aidperiod_17_home_comboBox, dt106, KeepSelection);
            Bind_ComboBox(aidperiod_16_home_comboBox, dt107, KeepSelection);
            Bind_ComboBox(aidperiod_20_comboBox, dt108, KeepSelection);
            Bind_ComboBox(aidperiod_14_comboBox, dt109, KeepSelection);

            Bind_ComboBox(aidperiod_30_comboBox, dt1010, KeepSelection);
            Bind_ComboBox(IncomeRelation_12_comboBox, dt19, KeepSelection);
            Bind_ComboBox(EntredBy_comboBox, dt20, KeepSelection);
            Bind_ComboBox(EntredBy2_comboBox, dt201, KeepSelection);
            Bind_ComboBox(Visitor1_comboBox, dt202, KeepSelection);
            Bind_ComboBox(Visitor2_comboBox, dt203, KeepSelection);
            //Bind_ComboBox(DonorSchedule_ComboBox, dt230, KeepSelection);
            //Bind_ComboBox(Donor_ComboBox, dt231, KeepSelection);


            Bind_Gridview_ComboBox(this.Asset, dt14);
            Bind_Gridview_ComboBox(this.AssetHometype, dt21);
            Bind_Gridview_ComboBox(this.Expensestype_18_ComboBox, dt121);
            Bind_Gridview_ComboBox(this.AssetHometypeCar_ComboBox, dt22);
            Bind_Gridview_ComboBox(this.AssetTypeCar_ComboBox, dt17);
            Bind_Gridview_ComboBox(this.Income, Tables.Tables[7]);
            Bind_Gridview_ComboBox(this.Donor_ID, Tables.Tables[22]);
            Bind_Gridview_ComboBox(this.Partner_ID, Tables.Tables[6]);
            Bind_Gridview_ComboBox(this.ME_State, dt210);
            Bind_Gridview_ComboBox(this.Family_LivingWith_Code, dt00);
            Bind_Gridview_ComboBox(this.Story_State, dt211);
            Bind_Gridview_ComboBox(this.Video_State, dt212);
            Bind_Gridview_ComboBox(this.Followup_State, dt213);


            //Bing ComboBoxes in DataGridView
            //Bind_Gridview_ComboBox(this.Partner, Tables.Tables[6]);
            //Bind_Gridview_ComboBox(this.Income, Tables.Tables[7]);
            //Bind_Gridview_ComboBox(this.Aid, Tables.Tables[8]);

            //Bind_Gridview_ComboBox(this.Aid_Period, Tables.Tables[10]);
            //Bind_Gridview_ComboBox(this.Expenses, Tables.Tables[11]);
            //Bind_Gridview_ComboBox(this.Expenses_Type, Tables.Tables[12]);
            //Bind_Gridview_ComboBox(this.Loss, Tables.Tables[13]);
            //BuildingCondition_ComboBox(this.BuildingCondition, Tables.Tables[15]);

            Bind_Chickbox_List(Tables.Tables[16]);

        }

        private void Bind_ComboBox(ComboBox Combox_Name, DataTable dt, bool KeepSelection)
        {
            int SelectedValue = -1;

            if (Combox_Name.SelectedValue != null)
                SelectedValue = int.Parse(Combox_Name.SelectedValue.ToString());

            Combox_Name.DataSource = dt;
            Combox_Name.DisplayMember = "name";
            Combox_Name.ValueMember = "id";

            if (KeepSelection && SelectedValue != -1)
                Combox_Name.SelectedValue = SelectedValue;
            else
                Combox_Name.SelectedIndex = -1;

            Combox_Name.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);

            //if (type == "member")
            //{
            //    Category_ComboBox.Items.Add("N/A");
            //    Category_ComboBox.Items.Add("حالة الفرد");
            //    Category_ComboBox.Items.Add("الحالة الاجتماعية");
            //    Category_ComboBox.Items.Add("المرض");
            //    Category_ComboBox.Items.Add("العمل");
            //    Category_ComboBox.Items.Add("مشاريع صغيرة");
            //}
            //else
            //{
            //    Category_ComboBox.Items.Add("N/A");
            //    Category_ComboBox.Items.Add("الممتلكات");
            //    Category_ComboBox.Items.Add("السيارات");
            //    Category_ComboBox.Items.Add("الدخل");
            //}
            //Category_ComboBox.SelectedIndex = 0;
        }

        private void Bind_Gridview_ComboBox(DataGridViewComboBoxColumn Combox_Name, DataTable dt)
        {
            Combox_Name.DataSource = dt;
            Combox_Name.DisplayMember = "name";
            Combox_Name.ValueMember = "id";
        }

        private void Bind_Chickbox_List(DataTable dt)
        {
            UserMode = false;

            //ElectricalDevices_CheckedListBox.DataSource = dt;
            //ElectricalDevices_CheckedListBox.DisplayMember = "name";
            //ElectricalDevices_CheckedListBox.ValueMember = "id";

            //IsDirty_ElectricalDevices_CheckedListBox.DataSource = dt;
            //IsDirty_ElectricalDevices_CheckedListBox.DisplayMember = "name";
            //IsDirty_ElectricalDevices_CheckedListBox.ValueMember = "id";

            UserMode = true;
        }

        private void Set_Controls()
        {
            FamilyCode_TextBox_OriginalText = FamilyNumber_TextBox_OriginalText = Note_TextBox_OriginalText = FamilyNote_TextBox_OriginalText = PartnerNote_TextBox_OriginalText = WillNotReason_TextBox_OriginalText =
            Address_TextBox_OriginalText = LandLine_TextBox_OriginalText = MobileNumber_TextBox_OriginalText = LivingWithNote_TextBox_OriginalText = SellingFurnitureNote_TextBox_OriginalText =
            LocationLongtitude_TextBox_OriginalText = LocationLatitude_TextBox_OriginalText = BuildingNumber_TextBox_OriginalText = Floor_TextBox_OriginalText = RoomsNumber_TextBox_OriginalText =
            EntredBy_TextBox_OriginalText = DateOfEntry_TextBox_OriginalText = EvaluationNote_TextBox_OriginalText = InEvaluationBy_TextBox_OriginalText = ApprovedBy_TextBox_OriginalText =
            ApprovalDate_TextBox_OriginalText = PDMBy_TextBox_OriginalText = PDMDate_TextBox_OriginalText = PVMBy_TextBox__OriginalText = PVMDate_TextBox__OriginalText =
            ComplaintDate_TextBox_OriginalText = ComplaintBy_TextBox_OriginalText = EntredByOther_TextBox_OriginalText =
            NumberOfAllMembers_TextBox_OriginalText = LivingWithNote2_TextBox_OriginalText = expenses_amount_6_12_home_TextBox_OriginalText = home_description_TextBoxOriginalText =
            HeirsNumber_TextBox_OriginalText = aidamount_5_3_home_TextBox_OriginalText = expenses_amount_7_Home_TextBox_OriginalText = AmperNumber_7_Home_TextBox_OriginalText =
            aidamount_4_TextBox_OriginalText = AmperNumber_17_Home_TextBox_OriginalText = aidamount_16_TextBox_OriginalText = ElectricityNote_TextBox_OriginalText =
            ExpensesAmount_2_Home_TextBox_OriginalText = ExpensesAmount_3_TextBox_OriginalText = ExpensesAmount_21_TextBox_OriginalText = ExpensesAmount_19_TextBox_OriginalText = ExpensesAmount_22_TextBox_OriginalText =
            ExpensesAmount_20_TextBox_OriginalText = ExpensesAmount_11_TextBox_OriginalText = Expenses_10_TextBox_OriginalText =
            ExpensesAmount_10_TextBox__OriginalText = aidamount_11_TextBox_OriginalText = aidamount_20_TextBox_OriginalText = aidamount_19_TextBox_OriginalText =
            aidamount_14_TextBox_OriginalText = aidamount_12_TextBox_OriginalText = aidamount_17_Home_TextBox_OriginalText = aidamount_16_Home_TextBox_OriginalText =
            NoteAid_11_TextBox_OriginalText = NoteAid_19_TextBox_OriginalText = NoteAid_20_TextBox_OriginalText = NoteAid_12_TextBox_OriginalText = NoteAid_17_home_TextBox_OriginalText = NoteAid_16_home_TextBox_OriginalText =
            income_address_12_TextBox_OriginalText = aidamount_30_TextBox_OriginalText = PartnerNote_TextBox__OriginalText = home_description_TextBox_OriginalText = "";

            General_Information_IsDirty = Partner_DataGridView_IsDirty = FamilyVisitState_IsDirty = LivingWith_DataGridView_IsDirty =
            Income_DataGridView_IsDirty = Aid_DataGridView_IsDirty = Loss_DataGridView_IsDirty =
            Asset_DataGridView_IsDirty = Living_Information_IsDirty = PowerExpenses_DataGridView_IsDirty =
            LivingCondition_DataGridView_IsDirty = Expenses_DataGridView_IsDirty =
            Aid_Information_IsDirty = Lighting_Information_IsDirty = CarAsset_DataGridView_IsDirty =
            LivingCondition_Information_IsDirty = BuildingCondition_Information_isDirty = Expenses_Information_IsDirty = false;

            Code = FamilyNumber = Note = PartnerNote = FamilyNote = WillNotReason = LivingWithNote = FamilyVisitState = Address = LandLine = MobileNumber = Form_Name =
            OtherVisitors = DateOfEntry = EvaluationNote = InEvaluationBy = ApprovedBy =
            ApprovalDate = PDMBy = PDMDate = PVMBy = PVMDate = LivingWithNote2 = home_description = ElectricityNote = NoteAid_11 = NoteAid_19 = NoteAid_20 = NoteAid_12 = NoteAid_17_home = NoteAid_16_home =
            income_address_12 = Expenses_10 = "";

            AmperNumber_7_Home = AmperNumber_17_Home = -1;
            
            Visitor1 = Visitor2 = EntredBy = EntredBy2 = RoomsNumber = PDM = PVM = Complaint = Approved = Parish_ID = Street_ID = IsDisplaced_ID = HomeType_ID = ExpensesAmount_10 = aidamount_11 = aidamount_20 = aidamount_19 = NumberOfAllMembers = Floor = BuildingNumber = expenses_amount_6_12_home = ExpensesAmount_2_Home = ExpensesAmount_3 = ExpensesAmount_21 = ExpensesAmount_19 = ExpensesAmount_22 =
            ExpensesAmount_20 = ExpensesAmount_11 = HeirsNumber = aidamount_5_3_home = expenses_amount_7_Home = 
            aidamount_4 = aidsource_4 = aidperiod_4 = aidsource_16 = aidperiod_16 = SellingFurniture_type_1 = SellingFurniture_type_2 =  aidamount_16 = aidamount_14 = aidamount_12 = aidamount_17_Home = aidamount_16_Home =
            Expenses_1 = expensestype_6_12_home_ID = ParishHomeID = aidsource_5_3_home_ID = aidperiod_5_3_home_ID = Beds_ID = LivingRoom_ID = LivingWithFamily = InEvaluation = HeatingCooling_1 = HeatingCooling_2 = HeatingCooling_3 = HeatingCooling_4;
            Income_11 = Expenses_7_Home = Expenses_17_Home = Expenses_16_Home = Electricity = LivingWithCode = LivingWithCode2 = SellingFurniture = ElectricalDevices_1 = ElectricalDevices_2 = ElectricalDevices_3 = BuildingCond_1 = BuildingCond_2 = BuildingCond_3 = BuildingCond_5 = BuildingCond_8 =
            aidsource_11 = aidsource_20 = aidsource_19 = aidsource_14 = aidsource_12 = aidsource_16_Home = aidsource_17_Home =
            aidperiod_11 = aidperiod_20 = aidperiod_19 = aidperiod_14 = aidperiod_12 = aidperiod_16_Home = aidperiod_17_Home =
            IncomeRelation_12 = aidamount_30 = aidperiod_30 = aid_11 = aid_12 = aid_20 = aid_19 = aid_14 = aid_17_home = aid_16_home = -1;

            NumOfUpdateTry = 0;

            LivingWith_Query = Partner_Query = Income_Query = Aid_Query = Loss_Query = Asset_Query = CarAsset_Query = LivingCondition_Query = Expenses_Query = ElectricalDevices_Query = "";

            Receiver_Label.Visible = Receiver_TextBox.Visible = ApprovedBy_TextBox.Visible = ApprovalDate_Label.Visible = ApprovalDate_TextBox.Visible = PDMDate_TextBox.Visible = PDMBy_TextBox.Visible = PdmDate_Label.Visible = PVMDate_TextBox.Visible = PVMBy_TextBox.Visible = PvmDate_Label.Visible =
                ComplaintBy_TextBox.Visible = ComplaintDate_TextBox.Visible = ComplaintDate_Label.Visible = false;
            InEvaluationBy_TextBox.Visible = EvaluationDate_TextBox.Visible = InEvaluationLable.Visible = false;
            Delete_Button.Visible = Update_Button.Visible = DistributionHistory_Button.Visible = false;

            //WillNotReason_Label.Visible = WillNotReason_TextBox.Visible
            //LivingWith_Label.Visible = LivingWithCode_ComboBox.Visible = pictureBox2.Visible = LivingWithNote_Label.Visible = LivingWithNote_TextBox.Visible = GoToFamily_Button.Visible = false;
            //LivingWith2_Label.Visible = LivingWithCode2_ComboBox.Visible = pictureBox1.Visible = LivingWithNote2_Label.Visible = LivingWithNote2_TextBox.Visible = GoToFamily2_Button.Visible = false;

            //Done_RadioButton.Visible = false;

            //foreach (int i in IsDirty_ElectricalDevices_CheckedListBox.CheckedIndices)
            //{
            //    IsDirty_ElectricalDevices_CheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
            //}

            if (!UpdateMode)
            {
                this.Visits_TabPage.Parent = null;
                //this.Members_TabPage.Parent = null;
                this.Marks_TabPage.Parent = null;

                //Save_Button.Visible = true;
                SaveFamily_Button.Visible = true;
                Update_Button.Visible = false;
                UpdateFamily_Button.Visible = false;
                //WillNotReason_Label.Visible = false;
                //LivingWith_Label.Visible = LivingWithCode_ComboBox.Visible = pictureBox2.Visible = GoToFamily_Button.Visible = LivingWithNote_Label.Visible = LivingWithNote_TextBox.Visible = false;
                visitstate_Label.Visible = TotalMark_Label.Visible = mark_label.Visible = vstate_Label.Visible = false;
            }
            else if (UpdateMode)
            {
                this.Visits_TabPage.Parent = materialTabControl1;
                //this.Members_TabPage.Parent = materialTabControl1;
                this.Marks_TabPage.Parent = materialTabControl1;

                //Save_Button.Visible = false;
                SaveFamily_Button.Visible = false;

                Receiver_Label.Visible = Receiver_TextBox.Visible = EntredByOther_TextBox.Visible = EntredBy_Label.Visible =
                    Approved_RadioButton.Visible = PDM_RadioButton.Visible = PVM_RadioButton.Visible = true;

                Delete_Button.Visible = Update_Button.Visible = UpdateFamily_Button.Visible = DistributionHistory_Button.Visible = true;

                if (Yes_RadioButton.Checked)
                {
                    LivingWith_DataGridView.Enabled = true;
                    //LivingWith_Label.Visible = LivingWithCode_ComboBox.Visible = pictureBox2.Visible = GoToFamily_Button.Visible = LivingWithNote_Label.Visible = LivingWithNote_TextBox.Visible = true;
                    //LivingWith2_Label.Visible = LivingWithCode2_ComboBox.Visible = pictureBox1.Visible = GoToFamily2_Button.Visible = LivingWithNote2_Label.Visible = LivingWithNote2_TextBox.Visible = true;
                }
            }
        }

        private void Clear_Boxes()
        {
            // Clear Inserted data
            //UserMode = false;
            FamilyCode_TextBox.Clear();
            Note_TextBox.Clear();
            FamilyNote_TextBox.Clear();
            FamilyNumber_TextBox.Clear();
            NumberOfAllMembers_TextBox.Clear();
            Address_TextBox.Clear();
            LandLine_TextBox.Clear();
            MobileNumber_TextBox.Clear();
            ElectricityNote_TextBox.Clear();
            NoteAid_11_TextBox.Clear();
            NoteAid_19_TextBox.Clear();
            NoteAid_20_TextBox.Clear();
            NoteAid_12_TextBox.Clear();
            ComplaintNote_TextBox.Clear();
            NoteAid_17_home_TextBox.Clear();
            NoteAid_16_home_TextBox.Clear();
            income_address_12_TextBox.Clear();
            PartnerNote_TextBox.Clear();
            //LivingWithNote_TextBox.Clear();
            Expenses_10_TextBox.Clear();
            expenses_amount_7_Home_TextBox.Clear();
            AmperNumber_7_Home_TextBox.Clear();
            AmperNumber_17_Home_TextBox.Clear();
            aidamount_4_TextBox.Clear();
            aidamount_16_TextBox.Clear();
            //FamilyVisitState_TextBox.Clear();
            //SellingFurnitureNote_TextBox.Clear();
            RoomsNumber_TextBox.Clear();
            EntredByOther_TextBox.Clear();
            income_address_12_TextBox.Clear();
            //DateOfEntry_TextBox.Clear();
            EvaluationDate_TextBox.Clear();
            InEvaluationBy_TextBox.Clear();
            ApprovedBy_TextBox.Clear();
            ApprovalDate_TextBox.Clear();
            PDMBy_TextBox.Clear();
            PDMDate_TextBox.Clear();
            PVMBy_TextBox.Clear();
            PVMDate_TextBox.Clear();
            ComplaintBy_TextBox.Clear();
            ComplaintDate_TextBox.Clear();
            //LivingWithNote2_TextBox.Clear();
            home_description_TextBox.Clear();
            aidamount_30_TextBox.Clear();
            aidamount_11_TextBox.Clear();
            aidamount_20_TextBox.Clear();
            aidamount_19_TextBox.Clear();
            aidamount_14_TextBox.Clear();
            aidamount_12_TextBox.Clear();
            aidamount_17_Home_TextBox.Clear();
            aidamount_16_Home_TextBox.Clear();

            NoteAid_11_TextBox.Clear();
            NoteAid_20_TextBox.Clear();
            NoteAid_19_TextBox.Clear();
            NoteAid_12_TextBox.Clear();
            NoteAid_17_home_TextBox.Clear();
            NoteAid_16_home_TextBox.Clear();

            //WillNotReason_TextBox.Clear();
            //LivingWithNote_TextBox.Clear();
            Parish_ComboBox.SelectedIndex = 0;
            Street_ComboBox.SelectedIndex = 0;
            IsDisplaced_ComboBox.SelectedIndex = 0;
            HomeType_ComboBox.SelectedIndex = 0;
            Beds_ComboBox.SelectedIndex = 0;
            Livingroom_ComboBox.SelectedIndex = 0;

            aidsource_4_ComboBox.SelectedIndex = 0;
            aidsource_16_ComboBox.SelectedIndex = 0;
            aidperiod_4_ComboBox.SelectedIndex = 0;
            aidperiod_16_ComboBox.SelectedIndex = 0;
            Livingroom_ComboBox.SelectedIndex = 0;
            //LivingWithCode_ComboBox.SelectedIndex = -1;
            //LivingWithCode2_ComboBox.SelectedIndex = -1;

            expensestype_6_12_home_ComboBox.SelectedIndex = 0;
            ParishHome_ComboBox.SelectedIndex = 0;
            aidsource_5_3_home_ComboBox.SelectedIndex = 0;
            aidperiod_5_3_home_ComboBox.SelectedIndex = 0;
            Expenses_1_comboBox.SelectedIndex = 0;

            aidsource_11_comboBox.SelectedIndex = 0;
            aidsource_12_comboBox.SelectedIndex = 0;
            aidsource_19_comboBox.SelectedIndex = 0;
            aidsource_17_home_comboBox.SelectedIndex = 0;
            aidsource_16_home_comboBox.SelectedIndex = 0;
            aidsource_20_comboBox.SelectedIndex = 0;
            aidsource_14_comboBox.SelectedIndex = 0;

            aidperiod_11_comboBox.SelectedIndex = 0;
            aidperiod_12_comboBox.SelectedIndex = 0;
            aidperiod_19_comboBox.SelectedIndex = 0;
            aidperiod_17_home_comboBox.SelectedIndex = 0;
            aidperiod_16_home_comboBox.SelectedIndex = 0;
            aidperiod_20_comboBox.SelectedIndex = 0;
            aidperiod_14_comboBox.SelectedIndex = 0;

            aidperiod_30_comboBox.SelectedIndex = 0;
            IncomeRelation_12_comboBox.SelectedIndex = 0;
            EntredBy_comboBox.SelectedIndex = 0;
            EntredBy2_comboBox.SelectedIndex = 0;

            Visitor1_comboBox.SelectedIndex = 0;
            Visitor2_comboBox.SelectedIndex = 0;

            ExpensesAmount_3_TextBox.Clear();
            ExpensesAmount_19_TextBox.Clear();
            ExpensesAmount_20_TextBox.Clear();
            ExpensesAmount_21_TextBox.Clear();
            ExpensesAmount_22_TextBox.Clear();
            ExpensesAmount_11_TextBox.Clear();
            ExpensesAmount_2_Home_TextBox.Clear();

            //Bind ComboBoxes in DataGridView
            //Bind_Gridview_ComboBox(this.Partner, Tables.Tables[6]);
            //Bind_Gridview_ComboBox(this.Income, Tables.Tables[7]);
            //Bind_Gridview_ComboBox(this.Aid, Tables.Tables[8]);

            //Bind_Gridview_ComboBox(this.Aid_Period, Tables.Tables[10]);
            //Bind_Gridview_ComboBox(this.Expenses, Tables.Tables[11]);
            //Bind_Gridview_ComboBox(this.Expenses_Type, Tables.Tables[12]);
            //Bind_Gridview_ComboBox(this.Loss, Tables.Tables[13]);

            Yes_RadioButton.Checked = false;
            No_RadioButton.Checked = false;
            ElectricalDevicesNonExist1.Checked = false;
            ElectricalDevicesNonExist2.Checked = false;
            ElectricalDevicesNonExist3.Checked = false;
            ElectricalDevicesExist1.Checked = false;
            ElectricalDevicesExist2.Checked = false;
            ElectricalDevicesExist3.Checked = false;
            ElectricalDevicesFail1.Checked = false;
            ElectricalDevicesFail2.Checked = false;
            ElectricalDevicesFail3.Checked = false;
            HeatingCoolingDevices_1.Checked = false;
            HeatingCoolingDevices_2.Checked = false;
            HeatingCoolingDevices_3.Checked = false;
            HeatingCoolingDevices_4.Checked = false;
            BuildingConditionNotExist1.Checked = false;
            BuildingConditionNotExist2.Checked = false;
            BuildingConditionNotExist3.Checked = false;
            BuildingConditionNotExist5.Checked = false;
            BuildingConditionNotExist8.Checked = false;
            BuildingConditionMed1.Checked = false;
            BuildingConditionMed2.Checked = false;
            BuildingConditionMed3.Checked = false;
            BuildingConditionMed5.Checked = false;
            BuildingConditionMed8.Checked = false;
            BuildingConditionHigh1.Checked = false;
            BuildingConditionHigh2.Checked = false;
            BuildingConditionHigh3.Checked = false;
            BuildingConditionHigh5.Checked = false;
            BuildingConditionHigh8.Checked = false;
            Expenses_7_Home_No_RadioButton.Checked = false;
            Expenses_7_Home_Yes_RadioButton.Checked = false;
            Expenses_17_Home_No_RadioButton.Checked = false;
            Expenses_17_Home_Yes_RadioButton.Checked = false;
            Expenses_16_Home_No_RadioButton.Checked = false;
            Expenses_16_Home_Yes_RadioButton.Checked = false;
            Electricity_Yes_RadioButton.Checked = false;
            Electricity_No_RadioButton.Checked = false;
            Income11_1_RadioButton.Checked = false;
            Income11_2_RadioButton.Checked = false;
            Income11_3_RadioButton.Checked = false;
            SellingFurniture_Yes_RadioButton.Checked = false;
            SellingFurniture_No_RadioButton.Checked = false;
            //SellingFurnitureNote_TextBox.Clear(); 
            //NotYet_RadioButton.Checked = false;
            //WillNot_RadioButton.Checked = false;
            //Refused_RadioButton.Checked = false;
            //Done_RadioButton.Checked = false;
            isAsset_yes_RadioButton.Checked = isAsset_no_RadioButton.Checked = false;
            asset_3_yes_RadioButton.Checked = asset_3_no_RadioButton.Checked = false;
            hasincome_yes_RadioButton.Checked = hasincome_no_RadioButton.Checked = false;

            Partner_DataGridView.Rows.Clear();
            Income_DataGridView.Rows.Clear();
            LivingWith_DataGridView.Rows.Clear();
            //Aid_DataGridView.Rows.Clear();
            //Loss_DataGridView.Rows.Clear();
            Asset_DataGridView.Rows.Clear();
            CarAsset_DataGridView.Rows.Clear();
            //LivingCondition_DataGridView.Rows.Clear();
            //Expenses_DataGridView.Rows.Clear();

            Approved_RadioButton.Checked = PDM_RadioButton.Checked = PVM_RadioButton.Checked = false;

            //foreach (int i in ElectricalDevices_CheckedListBox.CheckedIndices)
            //{
            //    ElectricalDevices_CheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
            //}

            //UserMode = true;
            // Clear Inserted data
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            try
            {
                //this.ActiveControl = Save_Button;

                //DataApproved = Check_Data(1);

                //if (DataApproved)
                //{
                //    Get_Data();
                //    Family_ID = f.Insert_Family(Code, FamilyNumber, LocationLatitude, LocationLongtitude, Note, PartnerNote, FamilyNote, ComplaintNote, EvaluationNote, LivingWithNote, Address, LandLine, MobileNumber,
                //    EntredBy, EntredBy2, OtherVisitors, DateOfEntry, InEvaluation, InEvaluationBy,EvaluationDate, LivingWithNote2, home_description, ElectricityNote, NoteAid_11, NoteAid_19, NoteAid_20, NoteAid_12, NoteAid_17_home, NoteAid_16_home,
                //    income_address_12, RoomsNumber, PDM, PDMBy, PDMDate, PVM, PVMBy, PVMDate, Complaint, ComplaintBy, ComplaintDate, Approved, ApprovedBy, ApprovalDate, Parish_ID, Street_ID, IsDisplaced_ID, HomeType_ID, ExpensesAmount_10, aidamount_11, aidamount_20, aidamount_19, Floor, BuildingNumber, expenses_amount_6_12_home, ExpensesAmount_2_Home, ExpensesAmount_3, ExpensesAmount_21, ExpensesAmount_19, ExpensesAmount_22,
                //    ExpensesAmount_20, ExpensesAmount_11, HeirsNumber, aidamount_5_3_home, expenses_amount_7_Home, AmperNumber_7_Home,
                //    aidamount_4, aidsource_4, aidperiod_4, aidsource_16, aidperiod_16, SellingFurniture_type_1, SellingFurniture_type_2, AmperNumber_17_Home, aidamount_16, aidamount_14, aidamount_12, aidamount_17_Home, aidamount_16_Home,
                //    Expenses_10, Expenses_1, expensestype_6_12_home_ID, ParishHomeID, aidsource_5_3_home_ID, aidperiod_5_3_home_ID, Beds_ID, LivingRoom_ID, LivingWithFamily, HeatingCooling_1, HeatingCooling_2, HeatingCooling_3, HeatingCooling_4,
                //    Income_11, Expenses_7_Home, Expenses_17_Home, Expenses_16_Home, Electricity, LivingWithCode, LivingWithCode2, SellingFurniture, ElectricalDevices_1, ElectricalDevices_2, ElectricalDevices_3, BuildingCond_1, BuildingCond_2, BuildingCond_3, BuildingCond_5, BuildingCond_8,
                //    aidsource_11, aidsource_20, aidsource_19, aidsource_14, aidsource_12, aidsource_16_Home, aidsource_17_Home,
                //    aidperiod_11, aidperiod_20, aidperiod_19, aidperiod_14, aidperiod_12, aidperiod_16_Home, aidperiod_17_Home,
                //    IncomeRelation_12, aidamount_30, aidperiod_30, Asset_Query, CarAsset_Query, Income_Query, Partner_Query, LivingWith_Query, Form_Name);

                //    UpdateMode = true;

                //    MessageBox.Show("تم إدخال العائلة " + Code + "  بنجاح", "Confirmation");

                //    Set_Controls();

                //    Fill_Family(true, Visit_ID);
                //}
            }

            catch (Exception ex)
            {
                LivingWith_Query = Partner_Query = Income_Query = Aid_Query = Asset_Query = CarAsset_Query = LivingCondition_Query = Expenses_Query = ElectricalDevices_Query = "";
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = Update_Button;

                DataApproved = Check_Data(1);

                if (DataApproved)
                {
                    if (UpdateMode)
                    {
                        if (!General_Information_IsDirty    && !Partner_DataGridView_IsDirty && 
                            !FamilyVisitState_IsDirty       && !LivingWith_DataGridView_IsDirty &&
                            !Income_DataGridView_IsDirty    && !Aid_Information_IsDirty && 
                            !CarAsset_DataGridView_IsDirty  && !Asset_DataGridView_IsDirty && 
                            !Lighting_Information_IsDirty   && !BuildingCondition_Information_isDirty && 
                            !Expenses_Information_IsDirty   && !Electrical_Devices_IsDirty && 
                            !LivingCondition_Information_IsDirty)
                        {
                            MessageBox.Show("لا يوجد أي تغييرات لحفظها ", "Error");
                            return;
                        }
                        else
                        {
                            Get_Data();
                            f.Update_FamilyDetails(Family_ID, FamilyCode_TextBox.Text
                                , General_Query, Partner_Query, LivingWith_Query
                                , FamilyVisitState, Income_Query, Aid_Query, Expenses_Query
                                , Asset_Query, CarAsset_Query, BuildingCondition_Query, LivingCondition_Query
                                , ElectricalDevices_Query, Lighting_Query, Form_Name);

                            MessageBox.Show("تم تعديل معلومات العائلة " + FamilyCode_TextBox.Text + "  بنجاح", "Confirmation");
                        }
                    }

                    //Set_Controls();

                    Fill_Family(true, Visit_ID);

                    Partner_DataGridView.Focus();
                }
            }
            catch (Exception ex)
            {
                Partner_Query = Income_Query = Aid_Query = Asset_Query = CarAsset_Query
                    = LivingCondition_Query = Expenses_Query = ElectricalDevices_Query 
                    = General_Query = Lighting_Query = "";
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private bool Check_Data(int type)
        {
            if (type == 0)
            {
                // fixed info
                if (string.IsNullOrWhiteSpace(FamilyCode_TextBox.Text))
                {
                    MessageBox.Show("لا يمكن ترك خانة رمز العائلة فارغة", "Error");
                    return false;
                }
                else if (FamilyCode_TextBox.Text.Length != 5)
                {
                    MessageBox.Show("رمز العائلة يجب أن يكون 5 خانات", "Error");
                    return false;
                }

                if (!CodeChecked && General_Information_IsDirty)
                {
                    if (!Check_family_Code())
                    {
                        return false;
                    }
                }



                int NumOfActive = 0;
                int VisibleRows = 0;
                for (int i = 0; i < Partner_DataGridView.Rows.Count - 1; i++)
                {
                    if (Partner_DataGridView.Rows[i].Cells["Partner_ID"].Value == null || Partner_DataGridView.Rows[i].Cells["Partner_ID"].Value.ToString() == ""
                        || Partner_DataGridView.Rows[i].Cells["Donor_ID"].Value == null || Partner_DataGridView.Rows[i].Cells["Donor_ID"].Value.ToString() == ""
                        || Partner_DataGridView.Rows[i].Cells["Family_State"].Value == null || Partner_DataGridView.Rows[i].Cells["Family_State"].Value.ToString() == "")
                    {
                        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم الشركاء", "Error");
                        return false;
                    }
                    if (Partner_DataGridView.Rows[i].Visible)
                    {
                        VisibleRows++;
                        if (Partner_DataGridView.Rows[i].Cells["Family_State"].Value.ToString() == "فعالة")
                        {
                            NumOfActive++;
                            if (NumOfActive > 1)
                            {
                                MessageBox.Show("لا يمكن قبول عائلة فعالة مع أكثر من شريك في نفس الوقت", "Error");
                                return false;
                            }
                        }
                    }
                }
                for (int i = 0; i < Partner_DataGridView.Rows.Count - 1; i++)
                {
                    if (Partner_DataGridView.Rows[i].Visible == true)
                    {
                        for (int j = i + 1; j < Partner_DataGridView.Rows.Count - 1; j++)
                        {
                            if (Partner_DataGridView.Rows[j].Visible == true && 
                                (int)Partner_DataGridView.Rows[i].Cells["Partner_ID"].Value == (int)Partner_DataGridView.Rows[j].Cells["Partner_ID"].Value &&
                                (int)Partner_DataGridView.Rows[i].Cells["Donor_ID"].Value == (int)Partner_DataGridView.Rows[j].Cells["Donor_ID"].Value)
                            {
                                MessageBox.Show("الرجاء التأكد من عدم وجود تكرار في جدول الشريك", "Error");
                                return false;
                            }
                        }
                    }
                }
                if (VisibleRows == 0)
                {
                    MessageBox.Show("الرجاء إدخال معلومات الشريك وحالة العائلة في قسم الشركاء", "Error");
                    return false;
                }
                if (string.IsNullOrEmpty(Street_ComboBox.Text) || Street_ComboBox.SelectedIndex < 0 || string.IsNullOrEmpty(Parish_ComboBox.Text) || Parish_ComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد الطائفة وموقع المنزل في قسم المعلومات العامة", "Error");
                    return false;
                }
                if (!Yes_RadioButton.Checked && !No_RadioButton.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد اذا ما كانت العائلة تسكن مع عائلة أخرى أم لا في قسم الوضع المعيشي", "Error");
                    return false;
                }

                //if (LivingWithCode_ComboBox.SelectedIndex != -1 && int.Parse(LivingWithCode_ComboBox.SelectedValue.ToString()) == Family_ID)
                //{
                //    MessageBox.Show("لا يمكن إختيار نفس العائلة ضمن قسم تسكن مع عائلة أخرى", "Error");
                //    return false;
                //}
                //if (LivingWithCode == 0 && LivingWithCode2_ComboBox.SelectedIndex == LivingWithCode_ComboBox.SelectedIndex && Family_ID != -1)
                //{
                //    MessageBox.Show("لا يمكن إختيار نفس العائلة مرتين ضمن قسم تسكن مع عائلة أخرى", "Error");
                //    return false;
                //}
                //if (LivingWithCode_ComboBox.SelectedIndex < 0 && !string.IsNullOrEmpty(LivingWithCode_ComboBox.Text))
                //{
                //    MessageBox.Show("لقد قمت بإدخال رمز لعائلة غير موجودة في القائمة المخصصة لـ تسكن من عائلة أخرى" + Environment.NewLine + "الرجاء اختيار عائلة من القائمة", "Error");
                //    return false;
                //}
            }
            else
            {
                if (Visit_ID == -1)
                {
                    MessageBox.Show("الرجاء التأكد من اختيار الزيارة للتعديل عليها والتأكد من حالتها أنها تمت ثم المحاولة مرة ثانية", "Error");
                    return false;
                }
                // Added by Judy to add VisitDetails Row if it is missing
                f.Check_FamilyVisitDetails(Family_ID,Visit_ID); 
                // ///////////////////////////////////////////////////////
                 

                if (string.IsNullOrEmpty(HomeType_ComboBox.Text) || string.IsNullOrEmpty(IsDisplaced_ComboBox.Text)
                || HomeType_ComboBox.SelectedIndex < 0 || IsDisplaced_ComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد السكن الحالي و النزوح في قسم الوضع المعيشي", "Error");
                    return false;
                }
                if (string.IsNullOrEmpty(Beds_ComboBox.Text) || Beds_ComboBox.SelectedIndex < 0
                    || string.IsNullOrEmpty(Livingroom_ComboBox.Text) || Livingroom_ComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد حالة الأسرّة و غرفة المعيشة في قسم الوضع المعيشي", "Error");
                    return false;
                }

                if (!Expenses_7_Home_Yes_RadioButton.Checked && !Expenses_7_Home_No_RadioButton.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد اذا ما كان هناك اشتراك أمبير", "Error");
                    return false;
                }
                if (!Expenses_16_Home_Yes_RadioButton.Checked && !Expenses_16_Home_No_RadioButton.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد اذا ما كان هناك بطارية", "Error");
                    return false;
                }
                if (!Expenses_17_Home_Yes_RadioButton.Checked && !Expenses_17_Home_No_RadioButton.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد اذا ما كان هناك طاقة شمسية", "Error");
                    return false;
                }
                if (!Electricity_Yes_RadioButton.Checked && !Electricity_No_RadioButton.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد اذا ما كانت تصل كهرباء الدولة للمنزل", "Error");
                    return false;
                }
                if (!SellingFurniture_Yes_RadioButton.Checked && !SellingFurniture_No_RadioButton.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد اذا ما كانت العائلة تبيع أغراض المنزل", "Error");
                    return false;
                }
                if (!Income11_1_RadioButton.Checked && !Income11_2_RadioButton.Checked && !Income11_3_RadioButton.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد اذا ما كانت العائلة تصرف من مدخراتها", "Error");
                    return false;
                }
                if (!ElectricalDevicesExist1.Checked && !ElectricalDevicesNonExist1.Checked && !ElectricalDevicesFail1.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد حالة البرّاد", "Error");
                    return false;
                }
                if (!ElectricalDevicesExist2.Checked && !ElectricalDevicesNonExist2.Checked && !ElectricalDevicesFail2.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد حالة الغسّالة", "Error");
                    return false;
                }
                if (!ElectricalDevicesExist3.Checked && !ElectricalDevicesNonExist3.Checked && !ElectricalDevicesFail3.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد حالة الفرن", "Error");
                    return false;
                }
                if (!BuildingConditionNotExist1.Checked && !BuildingConditionMed1.Checked && !BuildingConditionHigh1.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد الرطوبة", "Error");
                    return false;
                }
                if (!BuildingConditionNotExist2.Checked && !BuildingConditionMed2.Checked && !BuildingConditionHigh2.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد حالة الجدران", "Error");
                    return false;
                }
                if (!BuildingConditionNotExist3.Checked && !BuildingConditionMed3.Checked && !BuildingConditionHigh3.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد حالة الزجاج", "Error");
                    return false;
                }
                if (!BuildingConditionNotExist5.Checked && !BuildingConditionMed5.Checked && !BuildingConditionHigh5.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد حالة التمديدات الكهربائية", "Error");
                    return false;
                }
                if (!BuildingConditionNotExist8.Checked && !BuildingConditionMed8.Checked && !BuildingConditionHigh8.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد حالة التمديدات الصحية", "Error");
                    return false;
                }
                for (int i = 0; i < Asset_DataGridView.Rows.Count - 1; i++)
                {
                    if (Asset_DataGridView.Rows[i].Cells["Asset"].Value == null || Asset_DataGridView.Rows[i].Cells["Asset"].Value.ToString() == ""
                        || Asset_DataGridView.Rows[i].Cells["AssetHometype"].Value == null || Asset_DataGridView.Rows[i].Cells["AssetHometype"].Value.ToString() == "" || int.Parse(Asset_DataGridView.Rows[i].Cells["AssetHometype"].Value.ToString()) < 0)
                    {
                        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم ممتلكات العائلة", "Error");
                        return false;
                    }
                }

                for (int i = 0; i < CarAsset_DataGridView.Rows.Count - 1; i++)
                {
                    if (CarAsset_DataGridView.Rows[i].Cells["AssetTypeCar_ComboBox"].Value == null || CarAsset_DataGridView.Rows[i].Cells["AssetTypeCar_ComboBox"].Value.ToString() == ""
                        || CarAsset_DataGridView.Rows[i].Cells["AssetHometypeCar_ComboBox"].Value == null || CarAsset_DataGridView.Rows[i].Cells["AssetHometypeCar_ComboBox"].Value.ToString() == ""
                         || CarAsset_DataGridView.Rows[i].Cells["Expensestype_18_ComboBox"].Value == null || CarAsset_DataGridView.Rows[i].Cells["Expensestype_18_ComboBox"].Value.ToString() == "")
                    {
                        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم السيارة ضمن ممتلكات العائلة", "Error");
                        return false;
                    }
                }
                for (int i = 0; i < Income_DataGridView.Rows.Count - 1; i++)
                {
                    if (Income_DataGridView.Rows[i].Cells["Income"].Value == null || Income_DataGridView.Rows[i].Cells["Income"].Value.ToString() == ""
                        || Income_DataGridView.Rows[i].Cells["Income_Amount"].Value == null || Income_DataGridView.Rows[i].Cells["Income_Amount"].Value.ToString() == "")

                    {
                        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم الدخل الثابت", "Error");
                        return false;
                    }
                }
            }

            

            //for (int i = 0; i < LivingCondition_DataGridView.Rows.Count - 1; i++)
            //{
            //    if (LivingCondition_DataGridView.Rows[i].Cells["BuildingCondition"].Value == null || LivingCondition_DataGridView.Rows[i].Cells["BuildingCondition"].Value.ToString() == "")
            //    {
            //        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم الحالة الفنية للمنزل", "Error");
            //        return false;
            //    }
            //}
            //for (int i = 0; i < LivingCondition_DataGridView.Rows.Count - 1; i++)
            //{
            //    if (LivingCondition_DataGridView.Rows[i].Visible == true)
            //    {
            //        for (int j = i + 1; j < LivingCondition_DataGridView.Rows.Count - 1; j++)
            //        {
            //            if (LivingCondition_DataGridView.Rows[j].Visible == true && (int)LivingCondition_DataGridView.Rows[i].Cells["BuildingCondition"].Value == (int)LivingCondition_DataGridView.Rows[j].Cells["BuildingCondition"].Value)
            //            {
            //                MessageBox.Show("الرجاء التأكد من عدم وجود تكرار في جدول الحالة الفنية للمنزل", "Error");
            //                return false;
            //            }
            //        }
            //    }

            //}

            //if (!NotYet_RadioButton.Checked && !WillNot_RadioButton.Checked && !Refused_RadioButton.Checked && !Done_RadioButton.Checked)
            //{
            //    MessageBox.Show("الرجاء تحديد حالة الزيارة في قسم الزيارة", "Error");
            //    return false;
            //}

            //if (UpdateMode && FamilyVisitState_LayoutPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text != CurrentFamilyVisitState && (WillNot_RadioButton.Checked || Refused_RadioButton.Checked))
            //{
            //    DialogResult dialogResult = MessageBox.Show("سيتم مسح جميع الزيارات المجدولة مسبقاً" + Environment.NewLine + "هل تريد المتابعة؟؟", "Warning", MessageBoxButtons.YesNo);
            //    if (dialogResult != DialogResult.Yes)
            //    {
            //        return false;
            //    }
            //}



            //for (int i = 0; i < Expenses_DataGridView.Rows.Count - 1; i++)
            //{
            //    if (Expenses_DataGridView.Rows[i].Cells["Expenses"].Value == null || Expenses_DataGridView.Rows[i].Cells["Expenses"].Value.ToString() == ""
            //        || Expenses_DataGridView.Rows[i].Cells["Expenses_Type"].Value == null || Expenses_DataGridView.Rows[i].Cells["Expenses_Type"].Value.ToString() == ""
            //        || Expenses_DataGridView.Rows[i].Cells["Expenses_Amount"].Value == null || Expenses_DataGridView.Rows[i].Cells["Expenses_Amount"].Value.ToString() == "")
            //    {
            //        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم المصاريف", "Error");
            //        return false;
            //    }
            //}

            //for (int i = 0; i < Aid_DataGridView.Rows.Count - 1; i++)
            //{
            //    if (Aid_DataGridView.Rows[i].Cells["Aid"].Value == null || Aid_DataGridView.Rows[i].Cells["Aid"].Value.ToString() == ""
            //        || Aid_DataGridView.Rows[i].Cells["Aid_Source"].Value == null || Aid_DataGridView.Rows[i].Cells["Aid_Source"].Value.ToString() == ""
            //        || Aid_DataGridView.Rows[i].Cells["Aid_Amount"].Value == null || Aid_DataGridView.Rows[i].Cells["Aid_Amount"].Value.ToString() == ""
            //        || Aid_DataGridView.Rows[i].Cells["Aid_Period"].Value == null || Aid_DataGridView.Rows[i].Cells["Aid_Period"].Value.ToString() == "")

            //    {
            //        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم المساعدات التي تتلقاها العائلة", "Error");
            //        return false;
            //    }
            //}

            //for (int i = 0; i < Aid_DataGridView.Rows.Count - 1; i++)
            //{
            //    if (Aid_DataGridView.Rows[i].Visible == true)
            //    {
            //        for (int j = i + 1; j < Aid_DataGridView.Rows.Count - 1; j++)
            //        {
            //            if (Aid_DataGridView.Rows[j].Visible == true && (int)Aid_DataGridView.Rows[i].Cells["Aid"].Value == (int)Aid_DataGridView.Rows[j].Cells["Aid"].Value && (int)Aid_DataGridView.Rows[i].Cells["Aid_Source"].Value == (int)Aid_DataGridView.Rows[j].Cells["Aid_Source"].Value)
            //            {
            //                MessageBox.Show("الرجاء التأكد من عدم وجود تكرار في جدول المساعدات التي تتلقاها العائلة", "Error");
            //                return false;
            //            }
            //        }
            //    }
            //}

            //for (int i = 0; i < Loss_DataGridView.Rows.Count - 1; i++)
            //{
            //    if (Loss_DataGridView.Rows[i].Cells["Loss"].Value == null || Loss_DataGridView.Rows[i].Cells["Loss"].Value.ToString() == ""
            //        || Loss_DataGridView.Rows[i].Cells["L_Number"].Value == null || Loss_DataGridView.Rows[i].Cells["L_Number"].Value.ToString() == "" || int.Parse(Loss_DataGridView.Rows[i].Cells["L_Number"].Value.ToString()) <= 0)
            //    {
            //        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم خسارات الحرب", "Error");
            //        return false;
            //    }
            //}
            return true;
        }

        private void Get_Data()
        {
            #region
            if (!UpdateMode)
            {
                Code = FamilyCode_TextBox.Text == null ? "" : FamilyCode_TextBox.Text;
                EntredBy = EntredBy_comboBox.SelectedValue == null ? 0 : int.Parse(EntredBy_comboBox.SelectedValue.ToString());
                EntredBy2 = EntredBy2_comboBox.SelectedValue == null ? 0 : int.Parse(EntredBy2_comboBox.SelectedValue.ToString());
                OtherVisitors = EntredByOther_TextBox.Text == null ? "" : EntredByOther_TextBox.Text;

                InEvaluation = InEvaluation_RadioButton.Checked ? 1 : 0;
                InEvaluationBy = InEvaluationBy_TextBox.Text == null ? "" : InEvaluationBy_TextBox.Text;
                EvaluationNote = EvaluationNote_TextBox.Text == null ? "" : EvaluationNote_TextBox.Text;
                EvaluationDate = EvaluationDate_TextBox.Text == null ? "" : DateTime.Now.ToString("yyyy-MM-dd");

                Approved = Approved_RadioButton.Checked ? 1 : 0;
                ApprovedBy = ApprovedBy_TextBox.Text == null ? "" : ApprovedBy_TextBox.Text;
                ApprovalDate = ApprovalDate_TextBox.Text == null ? "" : DateTime.Now.ToString("yyyy-MM-dd");

                PDM = PDM_RadioButton.Checked ? 1 : 0;
                PDMBy = PDMBy_TextBox.Text == null ? "" : PDMBy_TextBox.Text;
                PDMDate = PDMDate_TextBox.Text == null ? "" : DateTime.Now.ToString("yyyy-MM-dd");

                PVM = PVM_RadioButton.Checked ? 1 : 0;
                PVMBy = PVMBy_TextBox.Text == null ? "" : PVMBy_TextBox.Text;
                PVMDate = PVMDate_TextBox.Text == null ? "" : DateTime.Now.ToString("yyyy-MM-dd");

                Complaint = Complaint_RadioButton.Checked ? 1 : 0;
                ComplaintBy = ComplaintBy_TextBox.Text == null ? "" : ComplaintBy_TextBox.Text;
                ComplaintDate = ComplaintDate_TextBox.Text == null ? "" : DateTime.Now.ToString("yyyy-MM-dd");
                ComplaintNote = ComplaintNote_TextBox.Text == null ? "" : ComplaintNote_TextBox.Text;

                FamilyNumber = FamilyNumber_TextBox.Text == null ? "" : FamilyNumber_TextBox.Text;
                Parish_ID = int.Parse(Parish_ComboBox.SelectedValue.ToString()) == null ? 0 : int.Parse(Parish_ComboBox.SelectedValue.ToString());
                LandLine = LandLine_TextBox.Text == null ? "" : LandLine_TextBox.Text;
                MobileNumber = MobileNumber_TextBox.Text == null ? "" : MobileNumber_TextBox.Text;
                Address = Address_TextBox.Text == null ? "" : Address_TextBox.Text;
                Street_ID = int.Parse(Street_ComboBox.SelectedValue.ToString()) == null ? 0 : int.Parse(Street_ComboBox.SelectedValue.ToString());
                LocationLatitude = LocationLatitude_TextBox.Text == "" ? 0 : decimal.Parse(LocationLatitude_TextBox.Text);
                LocationLongtitude = LocationLongtitude_TextBox.Text == "" ? 0 : decimal.Parse(LocationLongtitude_TextBox.Text);
                BuildingNumber = BuildingNumber_TextBox.Text == "" ? 0 : int.Parse(BuildingNumber_TextBox.Text);
                Floor = Floor_TextBox.Text == "" ? 0 : int.Parse(Floor_TextBox.Text);

                IsDisplaced_ID = IsDisplaced_ComboBox.SelectedValue == null ? 0 : int.Parse(IsDisplaced_ComboBox.SelectedValue.ToString());
                HomeType_ID = HomeType_ComboBox.SelectedValue == null ? 0 : int.Parse(HomeType_ComboBox.SelectedValue.ToString());
                RoomsNumber = RoomsNumber_TextBox.Text == "" ? 0 : int.Parse(RoomsNumber_TextBox.Text.ToString());

                if (LivingWithFamily_LayoutPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text == "نعم")
                {
                    LivingWithFamily = 1;
                    if (LivingWith_DataGridView_IsDirty)
                        for (int i = 0; i < LivingWith_DataGridView.Rows.Count - 1; i++)
                        {
                            int LivingWithID = LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_ID"].Value == null ? -1 : int.Parse(LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_ID"].Value.ToString());
                            string LivingWith_Note = LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Note"].Value == null ? "" : LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Note"].Value.ToString();
                            int? LivingCode;
                            if (LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Code"].Value == null)
                            {
                                LivingCode = null;
                            }
                            else LivingCode = int.Parse(LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Code"].Value.ToString());
                            if (LivingWith_DataGridView.Rows[i].Visible == false)
                            {
                                LivingWith_Query += "DELETE FROM family_livingwith WHERE (family_livingwith.family_id1 = " + LivingCode + " and family_livingwith.note = " + LivingWith_Note + ")  or (family_livingwith.family_id2 = " + LivingCode + " and family_livingwith.note = " + LivingWith_Note + ");";
                                LivingWith_Query += "Update family set LivingWithFamily = 0 where family.id = @Family_ID;";
                            }
                            if (LivingWith_DataGridView.Rows[i].Visible == false)
                            {
                                LivingWith_Query += "DELETE FROM family_livingwith WHERE (family_livingwith.family_id1 = " + LivingCode + " and family_livingwith.note = " + LivingWith_Note + ")  or (family_livingwith.family_id2 = " + LivingCode + " and family_livingwith.note = " + LivingWith_Note + ");";
                              
                                //LivingWith_Query += "DELETE FROM family_livingwith WHERE id = '" + LivingWithID + "';";
                                LivingWith_Query += "Update family set LivingWithFamily = 0 where family.id = @Family_ID;";
                            }
                            //else if (LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_Code"].Value != null && LivingWith_DataGridView.Rows[i].Cells["LivingWith_IsDirty"].Value != null)
                            //{
                            //if (LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_ID"].Value != null)
                            //{
                            //    LivingWith_Query += "UPDATE family_livingwith set family_id2 = '" + LivingCode + "', note = '" + LivingWith_Note + "' where id = '" + LivingWithID + "';";
                            //    LivingWith_Query += "Update family set LivingWithFamily = 1 where family.id = @Family_ID;";
                            //    LivingWith_Query += "Update family set LivingWithFamily = 1 where family.id = " + LivingCode +";";
                            //    //LivingWith_Query += "update family as f1 inner join( select id from family where code = '"+ LivingCode + "') as f2 set f1.LivingWithFamily = 1 where f1.code = '"+ LivingCode + "';";
                            //}
                            if (LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_ID"].Value == null)
                            {
                                LivingWith_Query += "INSERT INTO family_livingwith (family_id1, family_id2, note) VALUES (@family_id, '" + LivingCode + "', '" + LivingWith_Note + "');";
                                if (i != 0)
                                {
                                    for (int j = 0; j < LivingWith_DataGridView.Rows.Count - 1; j++)
                                    {
                                        if (j != i)
                                        {
                                            int? LivingCodePrevious;
                                            if (LivingWith_DataGridView.Rows[j].Cells["Family_livingWith_Code"].Value == null)
                                            {
                                                LivingCodePrevious = null;
                                            }
                                            else LivingCodePrevious = int.Parse(LivingWith_DataGridView.Rows[j].Cells["Family_livingWith_Code"].Value.ToString());
                                            //string LivingWith_NotePrevious = LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Note"].Value == null ? "" : LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Note"].Value.ToString();
                                            LivingWith_Query += "INSERT INTO family_livingwith (family_id1, family_id2, note) VALUES ('" + LivingCode + "', '" + LivingCodePrevious + "', '" + LivingWith_Note + "');";
                                            LivingWith_Query += "Update family set LivingWithFamily = 1 where family.id = " + LivingCodePrevious + ";";
                                        }
                                    }
                                }

                                LivingWith_Query += "Update family set LivingWithFamily = 1 where family.id = @Family_ID;";
                                LivingWith_Query += "Update family set LivingWithFamily = 1 where family.id = " + LivingCode + ";";
                                //LivingWith_Query += "update family as f1 inner join( select id from family where code = '" + LivingCode + "') as f2 set f1.LivingWithFamily = 1 where f1.code = '" + LivingCode + "';";
                            }
                            //}
                        }
                }
                else
                {
                    LivingWithFamily = 0;
                    LivingWith_DataGridView.Rows.Clear();

                }

                expenses_amount_6_12_home = expenses_amount_6_12_home_TextBox.Text == "" ? 0 : int.Parse(expenses_amount_6_12_home_TextBox.Text.ToString());
                expensestype_6_12_home_ID = expensestype_6_12_home_ComboBox.SelectedValue == null ? 0 : int.Parse(expensestype_6_12_home_ComboBox.SelectedValue.ToString());
                home_description = home_description_TextBox.Text == "" ? "" : home_description_TextBox.Text;
                ParishHomeID = ParishHome_ComboBox.SelectedValue == null ? 0 : int.Parse(ParishHome_ComboBox.SelectedValue.ToString());
                HeirsNumber = HeirsNumber_TextBox.Text == "" ? 0 : int.Parse(HeirsNumber_TextBox.Text);
                aidsource_5_3_home_ID = aidsource_5_3_home_ComboBox.SelectedValue == null ? 0 : int.Parse(aidsource_5_3_home_ComboBox.SelectedValue.ToString());
                aidamount_5_3_home = aidamount_5_3_home_TextBox.Text == "" ? 0 : int.Parse(aidamount_5_3_home_TextBox.Text.ToString());
                aidperiod_5_3_home_ID = aidperiod_5_3_home_ComboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_5_3_home_ComboBox.SelectedValue.ToString());

                if (ElectricalDevicesNonExist1.Checked)
                     ElectricalDevices_1 = 0;
                else if (ElectricalDevicesExist1.Checked)
                     ElectricalDevices_1 = 1;
                else if (ElectricalDevicesFail1.Checked)
                     ElectricalDevices_1 = 2;
                else ElectricalDevices_1 = null;

                if (ElectricalDevicesNonExist2.Checked)
                     ElectricalDevices_2 = 0;
                else if (ElectricalDevicesExist2.Checked)
                     ElectricalDevices_2 = 1;
                else if (ElectricalDevicesFail2.Checked)
                     ElectricalDevices_2 = 2;
                else ElectricalDevices_2 = null;

                if (ElectricalDevicesNonExist3.Checked)
                     ElectricalDevices_3 = 0;
                else if (ElectricalDevicesExist3.Checked)
                     ElectricalDevices_3 = 1;
                else if (ElectricalDevicesFail3.Checked)
                     ElectricalDevices_3 = 2;
                else ElectricalDevices_3 = null;


                if (HeatingCoolingDevices_1.Checked) 
                     HeatingCooling_1 = 1;
                else HeatingCooling_1 = 0;

                if (HeatingCoolingDevices_2.Checked)
                     HeatingCooling_2 = 1;
                else HeatingCooling_2 = 0;

                if (HeatingCoolingDevices_3.Checked)
                     HeatingCooling_3 = 1;
                else HeatingCooling_3 = 0;

                if (HeatingCoolingDevices_4.Checked)
                {
                    HeatingCooling_4 = 1;
                }
                else
                {
                    HeatingCooling_4 = 0;
                }
                if (BuildingConditionNotExist1.Checked)
                {
                    BuildingCond_1 = 1;
                }
                else if (BuildingConditionMed1.Checked)
                {
                    BuildingCond_1 = 3;
                }
                else if (BuildingConditionHigh1.Checked)
                {
                    BuildingCond_1 = 2;
                }
                else
                {
                    BuildingCond_1 = null;
                }
                if (BuildingConditionNotExist2.Checked)
                {
                    BuildingCond_2 = 1;
                }
                else if (BuildingConditionMed2.Checked)
                {
                    BuildingCond_2 = 3;
                }
                else if (BuildingConditionHigh2.Checked)
                {
                    BuildingCond_2 = 2;
                }
                else
                {
                    BuildingCond_2 = null;
                }
                if (BuildingConditionNotExist3.Checked)
                {
                    BuildingCond_3 = 1;
                }
                else if (BuildingConditionMed3.Checked)
                {
                    BuildingCond_3 = 3;
                }
                else if (BuildingConditionHigh3.Checked)
                {
                    BuildingCond_3 = 2;
                }
                else
                {
                    BuildingCond_3 = null;
                }
                if (BuildingConditionNotExist5.Checked)
                {
                    BuildingCond_5 = 4;
                }
                else if (BuildingConditionMed5.Checked)
                {
                    BuildingCond_5 = 3;
                }
                else if (BuildingConditionHigh5.Checked)
                {
                    BuildingCond_5 = 5;
                }
                else
                {
                    BuildingCond_5 = null;
                }
                if (BuildingConditionNotExist8.Checked)
                {
                    BuildingCond_8 = 4;
                }
                else if (BuildingConditionMed8.Checked)
                {
                    BuildingCond_8 = 3;
                }
                else if (BuildingConditionHigh8.Checked)
                {
                    BuildingCond_8 = 5;
                }
                else
                {
                    BuildingCond_8 = null;
                }

                Beds_ID = Beds_ComboBox.SelectedValue == null ? 0 : int.Parse(Beds_ComboBox.SelectedValue.ToString());
                LivingRoom_ID = Livingroom_ComboBox.SelectedValue == null ? 0 : int.Parse(Livingroom_ComboBox.SelectedValue.ToString());

                if (Expenses_7_Home_Yes_RadioButton.Checked)
                {
                    Expenses_7_Home = 1;
                    expenses_amount_7_Home = expenses_amount_7_Home_TextBox.Text == "" ? 0 : int.Parse(expenses_amount_7_Home_TextBox.Text);
                    AmperNumber_7_Home = AmperNumber_7_Home_TextBox.Text == "" ? 0 : decimal.Parse(AmperNumber_7_Home_TextBox.Text);
                    if (int.Parse(aidsource_4_ComboBox.SelectedValue.ToString()) == null)
                        aidsource_4 = 0;
                    else aidsource_4 = int.Parse(aidsource_4_ComboBox.SelectedValue.ToString());
                    if (int.Parse(aidamount_4_TextBox.Text) == null)
                        aidamount_4 = 0;
                    else aidamount_4 = int.Parse(aidamount_4_TextBox.Text);
                    if (int.Parse(aidperiod_4_ComboBox.SelectedValue.ToString()) == null)
                        aidperiod_4 = 0;
                    else aidperiod_4 = int.Parse(aidperiod_4_ComboBox.SelectedValue.ToString());

                }
                else if (Expenses_7_Home_No_RadioButton.Checked)
                {
                    Expenses_7_Home = 0;
                }
                else
                {
                    Expenses_7_Home = null;
                }
                if (Expenses_17_Home_Yes_RadioButton.Checked)
                {
                    Expenses_17_Home = 1;
                    if (AmperNumber_17_Home_TextBox.Text == "")
                        AmperNumber_17_Home = 0;
                    else AmperNumber_17_Home = decimal.Parse(AmperNumber_17_Home_TextBox.Text.ToString());
                    if (aidsource_16_ComboBox.SelectedValue == null)
                        aidsource_16 = 0;
                    else aidsource_16 = int.Parse(aidsource_16_ComboBox.SelectedValue.ToString());
                    if (aidamount_16_TextBox.Text == "")
                        aidamount_16 = 0;
                    else aidamount_16 = int.Parse(aidamount_16_TextBox.Text);
                    if (aidperiod_16_ComboBox.SelectedValue == null)
                        aidperiod_16 = 0;
                    else aidperiod_16 = int.Parse(aidperiod_16_ComboBox.SelectedValue.ToString());
                }
                else if (Expenses_17_Home_No_RadioButton.Checked)
                {
                    Expenses_17_Home = 0;
                }
                else
                {
                    Expenses_17_Home = null;
                }
                if (Expenses_16_Home_Yes_RadioButton.Checked)
                {
                    Expenses_16_Home = 1;
                }
                else if (Expenses_16_Home_No_RadioButton.Checked)
                {
                    Expenses_16_Home = 0;
                }
                else
                {
                    Expenses_16_Home = null;
                }
                if (Electricity_Yes_RadioButton.Checked)
                {
                    Electricity = 1;
                    ElectricityNote = "";
                }
                else if (Electricity_No_RadioButton.Checked)
                {
                    Electricity = 0;
                    ElectricityNote = ElectricityNote_TextBox.Text;
                }
                else
                {
                    Electricity = null;
                }

                if (SellingFurniture_Yes_RadioButton.Checked)
                {
                    SellingFurniture = 1;
                    if (SellingFurniture_type_id_1.Checked)
                    {
                        SellingFurniture_type_1 = 1;
                    }
                    else
                    {
                        SellingFurniture_type_1 = 0;
                    }
                    if (SellingFurniture_type_id_2.Checked)
                    {
                        SellingFurniture_type_2 = 1;
                    }
                    else
                    {
                        SellingFurniture_type_2 = 0;
                    }
                }
                else if (SellingFurniture_No_RadioButton.Checked)
                {
                    SellingFurniture = 0;
                }
                else
                {
                    SellingFurniture = null;
                }

                if (Income11_1_RadioButton.Checked)
                {
                    Income_11 = 1;
                }
                else if (Income11_2_RadioButton.Checked)
                {
                    Income_11 = 2;
                }
                else if (Income11_3_RadioButton.Checked)
                {
                    Income_11 = 3;
                }
                else Income_11 = null;

                for (int i = 0; i < Asset_DataGridView.Rows.Count - 1; i++)
                {
                    int isLoss;
                    int Asset_VisitName = Visit_ID;
                    int AssetHometype = Asset_DataGridView.Rows[i].Cells["AssetHometype"].Value == null ? 0 : int.Parse(Asset_DataGridView.Rows[i].Cells["AssetHometype"].Value.ToString());
                    string AssetAddress = Asset_DataGridView.Rows[i].Cells["AssetAddress"].Value == null ? "" : Asset_DataGridView.Rows[i].Cells["AssetAddress"].Value.ToString();
                    int AssetIncome4 = Asset_DataGridView.Rows[i].Cells["Income_4"].Value == null ? 0 : int.Parse(Asset_DataGridView.Rows[i].Cells["Income_4"].Value.ToString());
                    int AssetExpenses_amount_6 = Asset_DataGridView.Rows[i].Cells["expenses_amount_6_asset"].Value == null ? 0 : int.Parse(Asset_DataGridView.Rows[i].Cells["expenses_amount_6_asset"].Value.ToString());
                    int AssetExpenses_amount_12 = Asset_DataGridView.Rows[i].Cells["expenses_amount_12_asset"].Value == null ? 0 : int.Parse(Asset_DataGridView.Rows[i].Cells["expenses_amount_12_asset"].Value.ToString());
                    int AssetHeirsNumber = Asset_DataGridView.Rows[i].Cells["AssetHeirsNumber"].Value == null ? 0 : int.Parse(Asset_DataGridView.Rows[i].Cells["AssetHeirsNumber"].Value.ToString());
                    string Loss_Note = Asset_DataGridView.Rows[i].Cells["LossNote"].Value == null ? "" : Asset_DataGridView.Rows[i].Cells["LossNote"].Value.ToString();
                    if (Asset_DataGridView.Rows[i].Cells["LossNote"].Value != null)
                    {
                        isLoss = 1;
                    }
                    else isLoss = 0;
                    Asset_Query += "(@family_id,'" + (int)Asset_DataGridView.Rows[i].Cells["Asset"].Value + "', '" + Asset_VisitName + "', '" + AssetHometype + "', '" + AssetExpenses_amount_6 + "', '" + AssetExpenses_amount_12 + "', '" + AssetIncome4 + "', '" + AssetHeirsNumber + "', '" + AssetAddress + "', '" + isLoss + "', '" + Loss_Note + "')";
                    if (i < Asset_DataGridView.Rows.Count - 2)
                        Asset_Query += ",";
                }
                for (int i = 0; i < CarAsset_DataGridView.Rows.Count - 1; i++)
                {
                    int isLoss;
                    int CarAsset_VisitName = Visit_ID;
                    int CarAssetHometype = CarAsset_DataGridView.Rows[i].Cells["AssetHometypeCar_ComboBox"].Value == null ? 0 : int.Parse(CarAsset_DataGridView.Rows[i].Cells["AssetHometypeCar_ComboBox"].Value.ToString());
                    string CarAssetNote = CarAsset_DataGridView.Rows[i].Cells["AssetNoteCar"].Value == null ? "" : CarAsset_DataGridView.Rows[i].Cells["AssetNoteCar"].Value.ToString();
                    string CarAssetRelease = CarAsset_DataGridView.Rows[i].Cells["AssetRelease"].Value == null ? "" : CarAsset_DataGridView.Rows[i].Cells["AssetRelease"].Value.ToString();
                    int CarAssetType = CarAsset_DataGridView.Rows[i].Cells["AssetTypeCar_ComboBox"].Value == null ? 0 : int.Parse(CarAsset_DataGridView.Rows[i].Cells["AssetTypeCar_ComboBox"].Value.ToString());
                    int CarAssetExpenses_amount_18 = CarAsset_DataGridView.Rows[i].Cells["ExpensesAmount_18"].Value == null ? 0 : int.Parse(CarAsset_DataGridView.Rows[i].Cells["ExpensesAmount_18"].Value.ToString());
                    int CarAssetExpensestype_18 = CarAsset_DataGridView.Rows[i].Cells["Expensestype_18_ComboBox"].Value == null ? 0 : int.Parse(CarAsset_DataGridView.Rows[i].Cells["Expensestype_18_ComboBox"].Value.ToString());
                    string CarLoss_Note = CarAsset_DataGridView.Rows[i].Cells["LossNoteCar"].Value == null ? "" : CarAsset_DataGridView.Rows[i].Cells["LossNoteCar"].Value.ToString();
                    if (CarAsset_DataGridView.Rows[i].Cells["LossNoteCar"].Value != null)
                    {
                        isLoss = 1;
                    }
                    else isLoss = 0;
                    CarAsset_Query += "(@family_id,'" + CarAsset_VisitName + "', '" + CarAssetHometype + "', '" + CarAssetNote + "', '" + CarAssetRelease + "', '" + CarAssetType + "', '" + CarAssetExpensestype_18 + "', '" + CarAssetExpenses_amount_18 + "', '" + isLoss + "', '" + CarLoss_Note + "')";
                    if (i < CarAsset_DataGridView.Rows.Count - 2)
                        CarAsset_Query += ",";
                }
                for (int i = 0; i < Income_DataGridView.Rows.Count - 1; i++)
                {
                    int CarAsset_VisitName = Visit_ID;
                    int IncomeAmount = Income_DataGridView.Rows[i].Cells["Income_Amount"].Value == null ? 0 : int.Parse(Income_DataGridView.Rows[i].Cells["Income_Amount"].Value.ToString());
                    string Income_Note = Income_DataGridView.Rows[i].Cells["IncomeNote"].Value == null ? "" : Income_DataGridView.Rows[i].Cells["IncomeNote"].Value.ToString();
                    Income_Query += "(@family_id,'" + int.Parse(Income_DataGridView.Rows[i].Cells["Income"].Value.ToString()) + "', '" + CarAsset_VisitName + "', '" + IncomeAmount + "', '" + Income_Note + "')";
                    if (i < Income_DataGridView.Rows.Count - 2)
                        Income_Query += ",";
                }

                if (Expenses_1_comboBox.SelectedValue == null)
                    Expenses_1 = 0;
                else Expenses_1 = int.Parse(Expenses_1_comboBox.SelectedValue.ToString());
                if (ExpensesAmount_3_TextBox.Text == "")
                    ExpensesAmount_3 = 0;
                else ExpensesAmount_3 = int.Parse(ExpensesAmount_3_TextBox.Text);
                if (ExpensesAmount_19_TextBox.Text == "")
                    ExpensesAmount_19 = 0;
                else ExpensesAmount_19 = int.Parse(ExpensesAmount_19_TextBox.Text);
                if (ExpensesAmount_21_TextBox.Text == "")
                    ExpensesAmount_21 = 0;
                else ExpensesAmount_21 = int.Parse(ExpensesAmount_21_TextBox.Text);
                if (ExpensesAmount_22_TextBox.Text == "")
                    ExpensesAmount_22 = 0;
                else ExpensesAmount_22 = int.Parse(ExpensesAmount_22_TextBox.Text);
                if (ExpensesAmount_11_TextBox.Text == "")
                    ExpensesAmount_11 = 0;
                else ExpensesAmount_11 = int.Parse(ExpensesAmount_11_TextBox.Text);
                if (ExpensesAmount_2_Home_TextBox.Text == "")
                    ExpensesAmount_2_Home = 0;
                else ExpensesAmount_2_Home = int.Parse(ExpensesAmount_2_Home_TextBox.Text);
                if (Expenses_10_TextBox.Text == "")
                    Expenses_10 = "";
                else Expenses_10 = Expenses_10_TextBox.Text;
                if (ExpensesAmount_10_TextBox.Text == "")
                    ExpensesAmount_10 = 0;
                else ExpensesAmount_10 = int.Parse(ExpensesAmount_10_TextBox.Text);
                if (ExpensesAmount_20_TextBox.Text == "")
                    ExpensesAmount_20 = 0;
                else ExpensesAmount_20 = int.Parse(ExpensesAmount_20_TextBox.Text);

                if (aidsource_11_comboBox.SelectedValue == null)
                {
                    aidsource_11 = 0;
                    aid_11 = 0;
                }
                else
                {
                    aidsource_11 = int.Parse(aidsource_11_comboBox.SelectedValue.ToString());
                    aid_11 = 1;
                }
                if (aidsource_20_comboBox.SelectedValue == null)
                    aidsource_20 = 0;
                else aidsource_20 = int.Parse(aidsource_20_comboBox.SelectedValue.ToString());
                if (aidsource_19_comboBox.SelectedValue == null)
                    aidsource_19 = 0;
                else aidsource_19 = int.Parse(aidsource_19_comboBox.SelectedValue.ToString());
                if (aidsource_14_comboBox.SelectedValue == null)
                    aidsource_14 = 0;
                else aidsource_14 = int.Parse(aidsource_14_comboBox.SelectedValue.ToString());
                if (aidsource_12_comboBox.SelectedValue == null)
                {
                    aidsource_12 = 0;
                    aid_12 = 0;
                }

                else {
                    aidsource_12 = int.Parse(aidsource_12_comboBox.SelectedValue.ToString());
                    aid_12 = 1;
                }
                
                if (aidsource_17_home_comboBox.SelectedValue == null)
                    aidsource_17_Home = 0;
                else aidsource_17_Home = int.Parse(aidsource_17_home_comboBox.SelectedValue.ToString());
                if (aidsource_16_home_comboBox.SelectedValue == null)
                    aidsource_16_Home = 0;
                else aidsource_16_Home = int.Parse(aidsource_16_home_comboBox.SelectedValue.ToString());

                if (aidperiod_11_comboBox.SelectedValue == null)
                    aidperiod_11 = 0;
                else aidperiod_11 = int.Parse(aidperiod_11_comboBox.SelectedValue.ToString());
                if (aidperiod_20_comboBox.SelectedValue == null)
                {
                    aidperiod_20 = 0;
                    aid_20 = 0;
                }
                else
                {
                    aidperiod_20 = int.Parse(aidperiod_20_comboBox.SelectedValue.ToString());
                    aid_20 = 1;
                }
                if (aidperiod_19_comboBox.SelectedValue == null)
                {
                    aidperiod_19 = 0;
                    aid_19 = 0;
                }
                else
                {
                    aidperiod_19 = int.Parse(aidperiod_19_comboBox.SelectedValue.ToString());
                    aid_19 = 1;
                }
                if (aidperiod_14_comboBox.SelectedValue == null)
                {
                    aidperiod_14 = 0;
                    aid_14 = 0;
                }

                else
                {
                    aidperiod_14 = int.Parse(aidperiod_14_comboBox.SelectedValue.ToString());
                    aid_14 = 1;
                }
                if (aidperiod_12_comboBox.SelectedValue == null)
                    aidperiod_12 = 0;
                else aidperiod_12 = int.Parse(aidperiod_12_comboBox.SelectedValue.ToString());
                if (aidperiod_17_home_comboBox.SelectedValue == null)
                {
                    aidperiod_17_Home = 0;
                    aid_17_home = 0;
                }
                else
                {
                    aidperiod_17_Home = int.Parse(aidperiod_17_home_comboBox.SelectedValue.ToString());
                    aid_17_home = 1;
                }
                if (aidperiod_16_home_comboBox.SelectedValue == null)
                {
                    aid_16_home = 0;
                    aidperiod_16_Home = 0;
                }
                else
                {
                    aidperiod_16_Home = int.Parse(aidperiod_16_home_comboBox.SelectedValue.ToString());
                    aid_16_home = 1;
                }

                if (aidamount_11_TextBox.Text == "")
                    aidamount_11 = 0;
                else aidamount_11 = int.Parse(aidamount_11_TextBox.Text.ToString());
                if (aidamount_20_TextBox.Text == "")
                    aidamount_20 = 0;
                else aidamount_20 = int.Parse(aidamount_20_TextBox.Text.ToString());
                if (aidamount_19_TextBox.Text == "")
                    aidamount_19 = 0;
                else aidamount_19 = int.Parse(aidamount_19_TextBox.Text.ToString());
                if (aidamount_14_TextBox.Text == "")
                    aidamount_14 = 0;
                else aidamount_14 = int.Parse(aidamount_14_TextBox.Text.ToString());
                if (aidamount_12_TextBox.Text == "")
                    aidamount_12 = 0;
                else aidamount_12 = int.Parse(aidamount_12_TextBox.Text.ToString());
                if (aidamount_17_Home_TextBox.Text == "")
                    aidamount_17_Home = 0;
                else aidamount_17_Home = int.Parse(aidamount_17_Home_TextBox.Text.ToString());
                if (aidamount_16_Home_TextBox.Text == "")
                    aidamount_16_Home = 0;
                else aidamount_16_Home = int.Parse(aidamount_16_Home_TextBox.Text.ToString());

                if (NoteAid_11_TextBox.Text != "")
                    NoteAid_11 = NoteAid_11_TextBox.Text;
                if (NoteAid_19_TextBox.Text != "")
                    NoteAid_19 = NoteAid_19_TextBox.Text;
                if (NoteAid_20_TextBox.Text != "")
                    NoteAid_20 = NoteAid_20_TextBox.Text;
                if (NoteAid_12_TextBox.Text != "")
                    NoteAid_12 = NoteAid_12_TextBox.Text;
                if (NoteAid_17_home_TextBox.Text != "")
                    NoteAid_17_home = NoteAid_17_home_TextBox.Text;
                if (NoteAid_16_home_TextBox.Text != "")
                    NoteAid_16_home = NoteAid_16_home_TextBox.Text;

                IncomeRelation_12 = IncomeRelation_12_comboBox.SelectedValue == null ? 0 : int.Parse(IncomeRelation_12_comboBox.SelectedValue.ToString());
                income_address_12 = income_address_12_TextBox.Text;
                aidamount_30 = aidamount_30_TextBox.Text == "" ? 0 : int.Parse(aidamount_30_TextBox.Text);
                aidperiod_30 = aidperiod_30_comboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_30_comboBox.SelectedValue.ToString());

                Note = Note_TextBox.Text == null ? "" : Note_TextBox.Text;
                FamilyNote = FamilyNote_TextBox.Text == null ? "" : FamilyNote_TextBox.Text;
                PartnerNote = PartnerNote_TextBox.Text == null ? "" : PartnerNote_TextBox.Text;
                EvaluationDate = EvaluationDate_TextBox.Text == null ? "" : EvaluationDate_TextBox.Text;

                for (int i = 0; i < Partner_DataGridView.Rows.Count - 1; i++)
                {
                    Partner_Query += "(@family_id, (select partner_donor.id from partner_donor where donor_id = '" + (int)Partner_DataGridView.Rows[i].Cells["Donor_ID"].Value + "' and partner_id = '" + (int)Partner_DataGridView.Rows[i].Cells["Partner_ID"].Value + "')," + (Partner_DataGridView.Rows[i].Cells["Family_State"].Value.ToString() == "فعالة" ? 1 : 0) + ")";
                    if (i < Partner_DataGridView.Rows.Count - 2)
                        Partner_Query += ",";
                }

                //FamilyVisitState = FamilyVisitState_LayoutPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;

                //WillNotReason = "";
                //if (FamilyVisitState == "لن يزار" || FamilyVisitState == "رفض")
                //{
                //    WillNotReason = WillNotReason_TextBox.Text;
                //}

                //for (int i = 0; i < Income_DataGridView.Rows.Count - 1; i++)
                //{
                //    string Income_Note = Income_DataGridView.Rows[i].Cells["IncomeNote"].Value == null ? "" : Income_DataGridView.Rows[i].Cells["IncomeNote"].Value.ToString();
                //    Income_Query += "(@family_id,'" + (int)Income_DataGridView.Rows[i].Cells["Income"].Value + "', '" + decimal.Parse(Income_DataGridView.Rows[i].Cells["Income_Amount"].Value.ToString()) + "', '" + Income_Note + "')";
                //    if (i < Income_DataGridView.Rows.Count - 2)
                //        Income_Query += ",";
                //}
                //for (int i = 0; i < Aid_DataGridView.Rows.Count - 1; i++)
                //{
                //    string Aid_Note = Aid_DataGridView.Rows[i].Cells["AidNote"].Value == null ? "" : Aid_DataGridView.Rows[i].Cells["AidNote"].Value.ToString();
                //    Aid_Query += "(@family_id,'" + (int)Aid_DataGridView.Rows[i].Cells["Aid"].Value + "', '" + (int)Aid_DataGridView.Rows[i].Cells["Aid_Source"].Value + "','" + (int)Aid_DataGridView.Rows[i].Cells["Aid_Period"].Value + "', '" + decimal.Parse(Aid_DataGridView.Rows[i].Cells["Aid_Amount"].Value.ToString()) + "', '" + Aid_Note + "')";
                //    if (i < Aid_DataGridView.Rows.Count - 2)
                //        Aid_Query += ",";
                //}
                //for (int i = 0; i < Expenses_DataGridView.Rows.Count - 1; i++)
                //{
                //    string Expenses_Note = Expenses_DataGridView.Rows[i].Cells["ExpensesNote"].Value == null ? "" : Expenses_DataGridView.Rows[i].Cells["ExpensesNote"].Value.ToString();
                //    Expenses_Query += "(@family_id,'" + (int)Expenses_DataGridView.Rows[i].Cells["Expenses"].Value + "', '" + (int)Expenses_DataGridView.Rows[i].Cells["Expenses_Type"].Value + "', '" + decimal.Parse(Expenses_DataGridView.Rows[i].Cells["Expenses_Amount"].Value.ToString()) + "', '" + Expenses_Note + "')";
                //    if (i < Expenses_DataGridView.Rows.Count - 2)
                //        Expenses_Query += ",";
                //}
                //for (int i = 0; i < Loss_DataGridView.Rows.Count - 1; i++)
                //{
                //    string Loss_Note = Loss_DataGridView.Rows[i].Cells["LossNote"].Value == null ? "" : Loss_DataGridView.Rows[i].Cells["LossNote"].Value.ToString();
                //    Loss_Query += "(@family_id,'" + (int)Loss_DataGridView.Rows[i].Cells["Loss"].Value + "', '" + int.Parse(Loss_DataGridView.Rows[i].Cells["L_Number"].Value.ToString()) + "', '" + Loss_Note + "')";
                //    if (i < Loss_DataGridView.Rows.Count - 2)
                //        Loss_Query += ",";
                //}

                //SellingFurnitureNote = SellingFurnitureNote_TextBox.Text;

                //for (int i = 0; i < LivingCondition_DataGridView.Rows.Count - 1; i++)
                //{
                //    string BuildingCondition_Note = LivingCondition_DataGridView.Rows[i].Cells["BuildingConditionNote"].Value == null ? "" : LivingCondition_DataGridView.Rows[i].Cells["BuildingConditionNote"].Value.ToString();
                //    LivingCondition_Query += "(@family_id,'" + (int)LivingCondition_DataGridView.Rows[i].Cells["BuildingCondition"].Value + "', '" + BuildingCondition_Note + "')";
                //    if (i < LivingCondition_DataGridView.Rows.Count - 2)
                //        LivingCondition_Query += ",";
                //}

                //if (ElectricalDevices_1.Checked)
                //{
                //    ElectricalDevices_Query += "(@family_id,'0')";
                //}
                //else
                //{
                //    if (ElectricalDevices_CheckedListBox.CheckedItems.Count != 0)
                //    {
                //        int j = 0;
                //        foreach (object itemChecked in ElectricalDevices_CheckedListBox.CheckedItems)
                //        {
                //            DataRowView castedItem = itemChecked as DataRowView;

                //            ElectricalDevices_Query += "(@family_id,'" + (int)castedItem["ID"] + "')";

                //            if (j <= ElectricalDevices_CheckedListBox.CheckedItems.Count - 2)
                //                ElectricalDevices_Query += ",";

                //            j++;
                //        }
                //    }
                //}

                Form_Name = this.Name;
            }
            #endregion

            #region
            else if (UpdateMode)
            {
                if (General_Information_IsDirty)
                { 
                    EntredBy = EntredBy_comboBox.SelectedValue == null ? 0 : int.Parse(EntredBy_comboBox.SelectedValue.ToString());
                    EntredBy2 = EntredBy2_comboBox.SelectedValue == null ? 0 : int.Parse(EntredBy2_comboBox.SelectedValue.ToString());
                    OtherVisitors = EntredByOther_TextBox.Text == "" ? "" : EntredByOther_TextBox.Text;

                    Code = FamilyCode_TextBox.Text == "" ? "" : FamilyCode_TextBox.Text;
                    FamilyNumber = FamilyNumber_TextBox.Text == "" ? "" : FamilyNumber_TextBox.Text;
                    Note = Note_TextBox.Text == "" ? "" : Note_TextBox.Text;
                    FamilyNote = FamilyNote_TextBox.Text == "" ? "" : FamilyNote_TextBox.Text;
                    PartnerNote = PartnerNote_TextBox.Text == "" ? "" : PartnerNote_TextBox.Text;
                    ComplaintNote = ComplaintNote_TextBox.Text == "" ? "" : ComplaintNote_TextBox.Text;
                    EvaluationNote = EvaluationNote_TextBox.Text == "" ? "" : EvaluationNote_TextBox.Text;
                    Parish_ID = Parish_ComboBox.SelectedValue == null ? 0 : int.Parse(Parish_ComboBox.SelectedValue.ToString());
                    EvaluationDate = EvaluationDate_TextBox.Text == null ? "" : EvaluationDate_TextBox.Text;
                    HeirsNumber = HeirsNumber_TextBox.Text == "" ? 0 : int.Parse(HeirsNumber_TextBox.Text);
                    Street_ID = Street_ComboBox.SelectedValue == "" ? 0 : int.Parse(Street_ComboBox.SelectedValue.ToString());
                    LandLine = LandLine_TextBox.Text == "" ? "" : LandLine_TextBox.Text;
                    MobileNumber = MobileNumber_TextBox.Text == "" ? "" : MobileNumber_TextBox.Text;
                    Address = Address_TextBox.Text == "" ? "" : Address_TextBox.Text;
                    LocationLatitude = LocationLatitude_TextBox.Text == "" ? 0 :decimal.Parse(LocationLatitude_TextBox.Text);
                    LocationLongtitude = LocationLongtitude_TextBox.Text == "" ? 0 : decimal.Parse(LocationLongtitude_TextBox.Text);
                    BuildingNumber = BuildingNumber_TextBox.Text == "" ? 0 : int.Parse(BuildingNumber_TextBox.Text);
                    Floor = Floor_TextBox.Text == "" ? 0 : int.Parse(Floor_TextBox.Text);

                    if (SellingFurniture_Yes_RadioButton.Checked)
                    {
                        SellingFurniture = 1;
                        if (SellingFurniture_type_id_1.Checked)
                        {
                            SellingFurniture_type_1 = 1;
                        }
                        else
                        {
                            SellingFurniture_type_1 = 0;
                        }
                        if (SellingFurniture_type_id_2.Checked)
                        {
                            SellingFurniture_type_2 = 1;
                        }
                        else
                        {
                            SellingFurniture_type_2 = 0;
                        }
                    }
                    else if (SellingFurniture_No_RadioButton.Checked)
                    {
                        SellingFurniture = 0;
                    }
                    else
                    {
                        SellingFurniture = null;
                    }

                    if (Income11_1_RadioButton.Checked)
                    {
                        Income_11 = 1;
                    }
                    else if (Income11_2_RadioButton.Checked)
                    {
                        Income_11 = 2;
                    }
                    else if (Income11_3_RadioButton.Checked)
                    {
                        Income_11 = 3;
                    }
                    else Income_11 = null;

                    if (Code != "" || FamilyNumber != "" || Parish_ID != 0 || Street_ID != 0)
                    {
                        General_Query += "UPDATE family set code = '" + Code + "', family_number = '" + FamilyNumber + "', complaintnote = '" + ComplaintNote + "', parish_id = '" + Parish_ID + "',evaluationnote = '" + EvaluationNote +
                                                     "', street_ID = '" + Street_ID + "', landLine = '" + LandLine +
                                                     "', mobile = '" + MobileNumber + "', address = '" + Address +
                                                     "', location_latitude = '" + LocationLatitude + "',  location_longitude = '" + LocationLongtitude + "', building_number = '" + BuildingNumber + "',  floor = '" + Floor +
                                                     "', LivingWithFamily = '" + LivingWithFamily +
                                                     "', Note = '" + Note + "', partnernote = '" + PartnerNote +
                                                     "' where id = '" + Family_ID + "';";

                        General_Query += " Select family_visit.id as 'visit_id' from family_visit where family_visit.family_id = " + Family_ID + ";";

                        General_Query += " Update family_visitdetails set family_note = '" + FamilyNote + "',heirs_number = '" + HeirsNumber + "',SellingFurniture = '" + SellingFurniture + "',  `SellingFurniture_type_id/1` = '" + SellingFurniture_type_1 + "',  `SellingFurniture_type_id/2` = '" + SellingFurniture_type_2 + "', income_11 = '" + Income_11
                                      + "' where family_visitdetails.family_visit_id = " + Visit_ID + ";";

                        General_Query += " Update family_visit set visitor1_id = '" + EntredBy + "',visitor2_id = '" + EntredBy2 + "',othervisitors = '" + OtherVisitors
                                      + "' where family_visit.id = " + Visit_ID + ";";
                    }
                }

                if (LivingCondition_Information_IsDirty)
                {
                    IsDisplaced_ID = IsDisplaced_ComboBox.SelectedValue == null ? 0 : int.Parse(IsDisplaced_ComboBox.SelectedValue.ToString());
                    HomeType_ID = HomeType_ComboBox.SelectedValue == null ? 0 : int.Parse(HomeType_ComboBox.SelectedValue.ToString());
                    RoomsNumber = RoomsNumber_TextBox.Text == "" ? 0 : int.Parse(RoomsNumber_TextBox.Text.ToString());
                    home_description = home_description_TextBox.Text == "" ? "" : home_description_TextBox.Text;
                    ParishHomeID = ParishHome_ComboBox.SelectedValue == null ? 0 : int.Parse(ParishHome_ComboBox.SelectedValue.ToString());
                    aidsource_5_3_home_ID = aidsource_5_3_home_ComboBox.SelectedValue == null ? 0 : int.Parse(aidsource_5_3_home_ComboBox.SelectedValue.ToString());
                    aidamount_5_3_home = aidamount_5_3_home_TextBox.Text == "" ? 0 : int.Parse(aidamount_5_3_home_TextBox.Text.ToString());
                    aidperiod_5_3_home_ID = aidperiod_5_3_home_ComboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_5_3_home_ComboBox.SelectedValue.ToString());
                    Beds_ID = Beds_ComboBox.SelectedValue == null ? 0 : int.Parse(Beds_ComboBox.SelectedValue.ToString());
                    LivingRoom_ID = Livingroom_ComboBox.SelectedValue == null ? 0 : int.Parse(Livingroom_ComboBox.SelectedValue.ToString());
                    expenses_amount_6_12_home = expenses_amount_6_12_home_TextBox.Text == "" ? 0 : int.Parse(expenses_amount_6_12_home_TextBox.Text.ToString());
                    expensestype_6_12_home_ID = expensestype_6_12_home_ComboBox.SelectedValue == null ? 0 : int.Parse(expensestype_6_12_home_ComboBox.SelectedValue.ToString());

                    if (IsDisplaced_ID != 0 || HomeType_ID != 0 || Beds_ID != 0 || LivingRoom_ID != 0)
                        LivingCondition_Query += "UPDATE family_visitdetails set hometype_id = '" + HomeType_ID + "', isdisplaced_id = '" + IsDisplaced_ID + "', rooms_number = '" + RoomsNumber + "', home_description = '" + home_description +
                                                 "', parish_id_home = '" + ParishHomeID + "',  aidsource_5_3_home = '" + aidsource_5_3_home_ID + "', aid_amount_5_3_home = '" + aidamount_5_3_home + "', aidperiod_5_3_home = '" + aidperiod_5_3_home_ID +
                                                 "', beds_id = '" + Beds_ID + "', livingroom_id = '" + LivingRoom_ID +
                                                 "', expenses_amount_6_12_home = '" + expenses_amount_6_12_home + "',  expensestype_6_12_home = '" + expensestype_6_12_home_ID +
                                                 "' where family_visitdetails.family_visit_id = " + Visit_ID + "; ";
                    //LivingCondition_Query += "CALL Update_Living_With(@LivingWithFamily,@Family_ID,@LivingWithCode,@LivingWithNote);";
                }

                if (Partner_DataGridView_IsDirty)
                    for (int i = 0; i < Partner_DataGridView.Rows.Count - 1; i++)
                    {
                        if (Partner_DataGridView.Rows[i].Visible == false)
                            Partner_Query += "DELETE FROM family_partner WHERE id = '" + Partner_DataGridView.Rows[i].Cells["Family_Partner_ID"].Value + "';";
                        else if (Partner_DataGridView.Rows[i].Cells["Partner_IsDirty"].Value != null && (int)Partner_DataGridView.Rows[i].Cells["Partner_IsDirty"].Value == 1)
                        {
                            if (Partner_DataGridView.Rows[i].Cells["Family_Partner_ID"].Value != null)
                            {
                                Partner_Query += "UPDATE family_partner set partner_donor_id = (select partner_donor.id from partner_donor where donor_id = '" + (int)Partner_DataGridView.Rows[i].Cells["Donor_ID"].Value + "' and partner_id = '" + (int)Partner_DataGridView.Rows[i].Cells["Partner_ID"].Value + "') , IsActive = '" + (Partner_DataGridView.Rows[i].Cells["Family_State"].Value.ToString() == "فعالة" ? 1 : 0) + "' where id = '" + int.Parse(Partner_DataGridView.Rows[i].Cells["Family_Partner_ID"].Value.ToString()) + "';";
                            }
                            else
                            {   
                                Partner_Query += "INSERT INTO family_partner (family_id, partner_donor_id, IsActive) VALUES ('" + Family_ID + "', (select partner_donor.id from partner_donor where donor_id = '" + (int)Partner_DataGridView.Rows[i].Cells["Donor_ID"].Value + "' and partner_id = '" + (int)Partner_DataGridView.Rows[i].Cells["Partner_ID"].Value + "') ," + (Partner_DataGridView.Rows[i].Cells["Family_State"].Value.ToString() == "فعالة" ? 1 : 0) + ");";
                            }
                        }
                    }

                //if (FamilyVisitState_IsDirty)
                //{
                //    FamilyVisitState = FamilyVisitState_LayoutPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;

                //    WillNotReason = "";
                //    if (FamilyVisitState == "لن يزار" || FamilyVisitState == "رفض")
                //    {
                //        WillNotReason = WillNotReason_TextBox.Text;
                //    }
                //}
                
                if (Asset_DataGridView_IsDirty)
                {
                    for (int i = 0; i < Asset_DataGridView.Rows.Count - 1; i++)
                    {
                        if (Asset_DataGridView.Rows[i].Visible == false)
                        {
                            Asset_Query += "DELETE FROM family_assets WHERE id = '" + Asset_DataGridView.Rows[i].Cells["Family_asset_ID"].Value + "';";
                            Asset_Query += "UPDATE family_visitdetails set isAsset = 0 where family_visit_id = " + Visit_ID + ";";
                        }
                        else if (Asset_DataGridView.Rows[i].Cells["Asset_IsDirty"].Value != null && (int)Asset_DataGridView.Rows[i].Cells["Asset_IsDirty"].Value == 1)
                        {
                            int isLoss;
                            int Asset_VisitName = Visit_ID;
                            int AssetHometype = Asset_DataGridView.Rows[i].Cells["AssetHometype"].Value == null ? 0 : int.Parse(Asset_DataGridView.Rows[i].Cells["AssetHometype"].Value.ToString());
                            string AssetAddress = Asset_DataGridView.Rows[i].Cells["AssetAddress"].Value == null ? "" : Asset_DataGridView.Rows[i].Cells["AssetAddress"].Value.ToString();
                            int AssetIncome4 = Asset_DataGridView.Rows[i].Cells["Income_4"].Value == null ? 0 : int.Parse(Asset_DataGridView.Rows[i].Cells["Income_4"].Value.ToString());
                            int AssetExpenses_amount_6 = Asset_DataGridView.Rows[i].Cells["expenses_amount_6_asset"].Value == null ? 0 : int.Parse(Asset_DataGridView.Rows[i].Cells["expenses_amount_6_asset"].Value.ToString());
                            int AssetExpenses_amount_12 = Asset_DataGridView.Rows[i].Cells["expenses_amount_12_asset"].Value == null ? 0 : int.Parse(Asset_DataGridView.Rows[i].Cells["expenses_amount_12_asset"].Value.ToString());
                            int AssetHeirsNumber = Asset_DataGridView.Rows[i].Cells["AssetHeirsNumber"].Value == null ? 0 : int.Parse(Asset_DataGridView.Rows[i].Cells["AssetHeirsNumber"].Value.ToString());
                            string Loss_Note = Asset_DataGridView.Rows[i].Cells["LossNote"].Value == null ? "" : Asset_DataGridView.Rows[i].Cells["LossNote"].Value.ToString();
                            if (Loss_Note != "")
                            {
                                isLoss = 1;
                            }
                            else isLoss = 0;
                            if (Asset_DataGridView.Rows[i].Cells["Family_Asset_ID"].Value != null)
                            {
                                Asset_Query += "UPDATE family_assets set asset_id = '" + (int)Asset_DataGridView.Rows[i].Cells["Asset"].Value + "', visit_id = '" + Asset_VisitName + "', hometype_id_asset = '" + AssetHometype + "', expenses_amount_6_asset = '" + AssetExpenses_amount_6 + "', expenses_amount_12_asset = '" + AssetExpenses_amount_12 + "', income_4 = '" + AssetIncome4 + "', asset_heirs_number = '" + AssetHeirsNumber + "', asset_address = '" + AssetAddress + "', isLoss = '" + isLoss + "', isLoss_note = '" + Loss_Note + "' where id = '" + (int)Asset_DataGridView.Rows[i].Cells["Family_Asset_ID"].Value + "';";
                            }
                            else
                            {
                                Asset_Query += "INSERT INTO family_assets (family_id, asset_id,visit_id, hometype_id_asset,expenses_amount_6_asset,expenses_amount_12_asset,income_4,asset_heirs_number,asset_address,isLoss,isLoss_note) VALUES ('" + Family_ID + "', '" + (int)Asset_DataGridView.Rows[i].Cells["Asset"].Value + "', '" + Asset_VisitName + "', '" + AssetHometype + "', '" + AssetExpenses_amount_6 + "', '" + AssetExpenses_amount_12 + "', '" + AssetIncome4 + "', '" + AssetHeirsNumber + "', '" + AssetAddress + "', '" + isLoss + "', '" + Loss_Note + "');";
                            }
                        }
                        if (Asset_DataGridView.Rows.Count == 0 || isAsset_no_RadioButton.Checked)
                        {
                            Asset_Query += "UPDATE family_visitdetails set isAsset = 0 where family_visit_id = " + Visit_ID + ";";
                        }
                        else Asset_Query += "UPDATE family_visitdetails set isAsset = 1 where family_visit_id = " + Visit_ID + ";";
                        //else Asset_Query += "UPDATE family_visitdetails set isAsset = 1 where id = " + Family_ID + ";";
                    }
                    if (Asset_DataGridView.Rows.Count - 1 == 0)
                    {
                        Asset_Query += "DELETE FROM family_assets WHERE family_id = '" + Family_ID + "' And visit_id = " + Visit_ID + ";";
                        Asset_Query += "update family_visitdetails set isAsset = 0 where family_visit_id = " + Visit_ID + ";";
                    }
                }
                

                if (CarAsset_DataGridView_IsDirty)
                    for (int i = 0; i < CarAsset_DataGridView.Rows.Count - 1; i++)
                    {
                        if (CarAsset_DataGridView.Rows[i].Visible == false)
                            CarAsset_Query += "DELETE FROM family_cars WHERE id = '" + CarAsset_DataGridView.Rows[i].Cells["Family_CarAsset_ID"].Value + "';";
                        else if (CarAsset_DataGridView.Rows[i].Cells["CarAsset_IsDirty"].Value != null && (int)CarAsset_DataGridView.Rows[i].Cells["CarAsset_IsDirty"].Value == 1)
                        {
                            int isLoss;
                            int CarAsset_VisitName = Visit_ID;
                            int CarAssetHometype = CarAsset_DataGridView.Rows[i].Cells["AssetHometypeCar_ComboBox"].Value == null ? 0 : int.Parse(CarAsset_DataGridView.Rows[i].Cells["AssetHometypeCar_ComboBox"].Value.ToString());
                            string CarAssetNote = CarAsset_DataGridView.Rows[i].Cells["AssetNoteCar"].Value == null ? "" : CarAsset_DataGridView.Rows[i].Cells["AssetNoteCar"].Value.ToString();
                            string CarAssetRelease = CarAsset_DataGridView.Rows[i].Cells["AssetRelease"].Value == null ? "" : CarAsset_DataGridView.Rows[i].Cells["AssetRelease"].Value.ToString();
                            int CarAssetType = CarAsset_DataGridView.Rows[i].Cells["AssetTypeCar_ComboBox"].Value == null ? 0 : int.Parse(CarAsset_DataGridView.Rows[i].Cells["AssetTypeCar_ComboBox"].Value.ToString());
                            int CarAssetExpenses_amount_18 = CarAsset_DataGridView.Rows[i].Cells["ExpensesAmount_18"].Value == null ? 0 : int.Parse(CarAsset_DataGridView.Rows[i].Cells["ExpensesAmount_18"].Value.ToString());
                            int CarAssetExpensestype_18 = CarAsset_DataGridView.Rows[i].Cells["Expensestype_18_ComboBox"].Value == null ? 0 : int.Parse(CarAsset_DataGridView.Rows[i].Cells["Expensestype_18_ComboBox"].Value.ToString());
                            string CarLoss_Note = CarAsset_DataGridView.Rows[i].Cells["LossNoteCar"].Value == null ? "" : CarAsset_DataGridView.Rows[i].Cells["LossNoteCar"].Value.ToString();
                            if (CarLoss_Note != "")
                            {
                                isLoss = 1;
                            }
                            else isLoss = 0;
                            if (CarAsset_DataGridView.Rows[i].Cells["Family_CarAsset_ID"].Value != null)
                            {
                                CarAsset_Query += "UPDATE family_cars set asset_hometype_id = '" + CarAssetHometype + "', visit_id = '" + CarAsset_VisitName + "', asset_note = '" + CarAssetNote + "', asset_release = '" + CarAssetRelease + "', asset_type = '" + CarAssetType + "', expensestype_18 = '" + CarAssetExpensestype_18 + "', expenses_amount_18 = '" + CarAssetExpenses_amount_18 + "', loss_4 = '" + isLoss + "', loss_note_4 = '" + CarLoss_Note + "' where id = '" + (int)CarAsset_DataGridView.Rows[i].Cells["Family_CarAsset_ID"].Value + "';";
                            }
                            else
                            {
                                CarAsset_Query += "INSERT INTO family_cars (family_id, visit_id, asset_hometype_id, asset_note,asset_release,asset_type,expensestype_18,expenses_amount_18,loss_4,loss_note_4) VALUES ('" + Family_ID + "', '" + CarAsset_VisitName + "', '" + CarAssetHometype + "', '" + CarAssetNote + "', '" + CarAssetRelease + "', '" + CarAssetType + "', '" + CarAssetExpensestype_18 + "', '" + CarAssetExpenses_amount_18 + "', '" + isLoss + "', '" + CarLoss_Note + "');";
                            }
                        }
                        if (CarAsset_DataGridView.Rows.Count == 0 || asset_3_no_RadioButton.Checked)
                        {
                            //CarAsset_Query += "UPDATE family_visitdetails set asset_3 = 0 where id = " + Family_ID + ";";
                            CarAsset_Query += "UPDATE family_visitdetails set asset_3 = 0 where family_visit_id = " + Visit_ID + ";";
                        }
                        else CarAsset_Query += "UPDATE family_visitdetails set asset_3 = 1 where family_visit_id = " + Visit_ID + ";";
                        //else CarAsset_Query += "UPDATE family_visitdetails set asset_3 = 1 where id = " + Family_ID + ";";
                    }
                if (CarAsset_DataGridView.Rows.Count - 1 == 0)
                {
                    CarAsset_Query += "DELETE FROM family_cars WHERE family_id = '" + Family_ID + "' And visit_id = " + Visit_ID + ";";
                    CarAsset_Query += "update family_visitdetails set asset_3 = 0 where family_visit_id = " + Visit_ID + ";";
                }
                else CarAsset_Query += "UPDATE family_visitdetails set asset_3 = 1 where family_visit_id = " + Visit_ID + ";";
                if (Income_DataGridView_IsDirty)
                    for (int i = 0; i < Income_DataGridView.Rows.Count - 1; i++)
                    {
                        if (Income_DataGridView.Rows[i].Visible == false)
                            Income_Query += "DELETE FROM family_income WHERE id = '" + Income_DataGridView.Rows[i].Cells["Family_Income_ID"].Value + "';";
                        else if (Income_DataGridView.Rows[i].Cells["Income_IsDirty"].Value != null && (int)Income_DataGridView.Rows[i].Cells["Income_IsDirty"].Value == 1)
                        {
                            int Income_VisitName = Visit_ID;
                            int IncomeAmount = Income_DataGridView.Rows[i].Cells["Income_Amount"].Value == null ? 0 : int.Parse(Income_DataGridView.Rows[i].Cells["Income_Amount"].Value.ToString());
                            string Income_Note = Income_DataGridView.Rows[i].Cells["IncomeNote"].Value == null ? "" : Income_DataGridView.Rows[i].Cells["IncomeNote"].Value.ToString();
                            if (Income_DataGridView.Rows[i].Cells["Family_Income_ID"].Value != null)
                            {
                                Income_Query += "UPDATE family_income set income_id = '" + (int)Income_DataGridView.Rows[i].Cells["Income"].Value + "', income_amount = '" + IncomeAmount + "', visit_id = '" + Income_VisitName + "', income_note = '" + Income_Note + "' where id = '" + (int)Income_DataGridView.Rows[i].Cells["Family_Income_ID"].Value + "';";
                            }
                            else
                            {
                                Income_Query += "INSERT INTO family_income (family_id,visit_id, income_id, income_amount, income_note) VALUES ('" + Family_ID + "', '" + Income_VisitName + "', '" + (int)Income_DataGridView.Rows[i].Cells["Income"].Value + "', '" + IncomeAmount + "', '" + Income_Note + "');";
                            }
                        }
                        if (Income_DataGridView.Rows.Count == 0 || hasincome_no_RadioButton.Checked)
                        {
                            Income_Query += "UPDATE family_visitdetails set hasincome = 0 where family_visit_id = " + Visit_ID + ";";
                            //Income_Query += "UPDATE family_visitdetails set hasincome = 0 where id = " + Family_ID + ";";
                        }
                        else Income_Query += "UPDATE family_visitdetails set hasincome = 1 where family_visit_id = " + Visit_ID + ";";
                        //else Income_Query += "UPDATE family_visitdetails set hasincome = 1 where id = " + Family_ID + ";";
                    }
                if (Income_DataGridView.Rows.Count - 1 == 0)
                {
                    Income_Query += "DELETE FROM family_income WHERE family_id = '" + Family_ID + "' And visit_id = " + Visit_ID + ";";
                    Income_Query += "update family_visitdetails set hasincome = 0 where family_visit_id = " + Visit_ID + ";";
                }
                else Income_Query += "UPDATE family_visitdetails set hasincome = 1 where family_visit_id = " + Visit_ID + ";";

                if (Aid_Information_IsDirty)
                {
                    if (aidsource_11_comboBox.SelectedValue == null)
                    {
                        aidsource_11 = 0;
                        aid_11 = 0;
                    }
                    else
                    {
                        aidsource_11 = int.Parse(aidsource_11_comboBox.SelectedValue.ToString());
                        aid_11 = 1;
                    }
                    if (aidsource_20_comboBox.SelectedValue == null)
                        aidsource_20 = 0;
                    else aidsource_20 = int.Parse(aidsource_20_comboBox.SelectedValue.ToString());
                    if (aidsource_19_comboBox.SelectedValue == null)
                        aidsource_19 = 0;
                    else aidsource_19 = int.Parse(aidsource_19_comboBox.SelectedValue.ToString());
                    if (aidsource_14_comboBox.SelectedValue == null)
                        aidsource_14 = 0;
                    else aidsource_14 = int.Parse(aidsource_14_comboBox.SelectedValue.ToString());
                    if (aidsource_12_comboBox.SelectedValue == null)
                    {
                        aidsource_12 = 0;
                        aid_12 = 0;
                    }
                    else
                    {
                        aidsource_12 = int.Parse(aidsource_12_comboBox.SelectedValue.ToString());
                        aid_12 = 1;
                    }
                    if (aidsource_17_home_comboBox.SelectedValue == null)
                        aidsource_17_Home = 0;
                    else aidsource_17_Home = int.Parse(aidsource_17_home_comboBox.SelectedValue.ToString());
                    if (aidsource_16_home_comboBox.SelectedValue == null)
                        aidsource_16_Home = 0;
                    else aidsource_16_Home = int.Parse(aidsource_16_home_comboBox.SelectedValue.ToString());


                    if (aidperiod_11_comboBox.SelectedValue == null)
                        aidperiod_11 = 0;
                    else aidperiod_11 = int.Parse(aidperiod_11_comboBox.SelectedValue.ToString());
                    if (aidperiod_20_comboBox.SelectedValue == null)
                        aidperiod_20 = 0;
                    else aidperiod_20 = int.Parse(aidperiod_20_comboBox.SelectedValue.ToString());
                    if (aidperiod_19_comboBox.SelectedValue == null)
                        aidperiod_19 = 0;
                    else aidperiod_19 = int.Parse(aidperiod_19_comboBox.SelectedValue.ToString());
                    if (aidperiod_14_comboBox.SelectedValue == null)
                        aidperiod_14 = 0;
                    else aidperiod_14 = int.Parse(aidperiod_14_comboBox.SelectedValue.ToString());
                    if (aidperiod_12_comboBox.SelectedValue == null)
                        aidperiod_12 = 0;
                    else aidperiod_12 = int.Parse(aidperiod_12_comboBox.SelectedValue.ToString());
                    if (aidperiod_17_home_comboBox.SelectedValue == null)
                        aidperiod_17_Home = 0;
                    else aidperiod_17_Home = int.Parse(aidperiod_17_home_comboBox.SelectedValue.ToString());
                    if (aidperiod_16_home_comboBox.SelectedValue == null)
                        aidperiod_16_Home = 0;
                    else aidperiod_16_Home = int.Parse(aidperiod_16_home_comboBox.SelectedValue.ToString());


                    if (aidamount_11_TextBox.Text == "")
                        aidamount_11 = 0;
                    else aidamount_11 = int.Parse(aidamount_11_TextBox.Text.ToString());
                    if (aidamount_20_TextBox.Text == "")
                        aidamount_20 = 0;
                    else aidamount_20 = int.Parse(aidamount_20_TextBox.Text.ToString());
                    if (aidamount_19_TextBox.Text == "")
                        aidamount_19 = 0;
                    else aidamount_19 = int.Parse(aidamount_19_TextBox.Text.ToString());
                    if (aidamount_14_TextBox.Text == "")
                        aidamount_14 = 0;
                    else aidamount_14 = int.Parse(aidamount_14_TextBox.Text.ToString());
                    if (aidamount_12_TextBox.Text == "")
                        aidamount_12 = 0;
                    else aidamount_12 = int.Parse(aidamount_12_TextBox.Text.ToString());
                    if (aidamount_17_Home_TextBox.Text == "")
                        aidamount_17_Home = 0;
                    else aidamount_17_Home = int.Parse(aidamount_17_Home_TextBox.Text.ToString());
                    if (aidamount_16_Home_TextBox.Text == "")
                        aidamount_16 = 0;
                    else aidamount_16_Home = int.Parse(aidamount_16_Home_TextBox.Text.ToString());

                    if (NoteAid_11_TextBox.Text != "")
                        NoteAid_11 = NoteAid_11_TextBox.Text;
                    if (NoteAid_19_TextBox.Text != "")
                        NoteAid_19 = NoteAid_19_TextBox.Text;
                    if (NoteAid_20_TextBox.Text != "")
                        NoteAid_20 = NoteAid_20_TextBox.Text;
                    if (NoteAid_12_TextBox.Text != "")
                        NoteAid_12 = NoteAid_12_TextBox.Text;
                    if (NoteAid_17_home_TextBox.Text != "")
                        NoteAid_17_home = NoteAid_17_home_TextBox.Text;
                    if (NoteAid_16_home_TextBox.Text != "")
                        NoteAid_16_home = NoteAid_16_home_TextBox.Text;

                    IncomeRelation_12 = IncomeRelation_12_comboBox.SelectedValue == null ? 0 : int.Parse(IncomeRelation_12_comboBox.SelectedValue.ToString());
                    income_address_12 = income_address_12_TextBox.Text;
                    aidamount_30 = aidamount_30_TextBox.Text == "" ? 0 : int.Parse(aidamount_30_TextBox.Text);
                    aidperiod_30 = aidperiod_30_comboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_30_comboBox.SelectedValue.ToString());

                    Aid_Query += "UPDATE family_visitdetails set aid_11 = "+ aid_11 +",aid_12 = "+ aid_12 +", aid_20 = "+ aid_20 +", aid_19 = " + aid_19 + ", aid_14 = " + aid_14 + ",aid_17_home = " + aid_17_home + " ,aid_16_home = " + aid_16_home + " ,aidsource_11 = '" + aidsource_11 + "', aidsource_20 = '" + aidsource_20 + "', aidsource_19 = '" + aidsource_19 + "', aidsource_14 = '" + aidsource_14 + "', aidsource_12 = '" + aidsource_12 + "',  aidsource_17_home = '" + aidsource_17_Home + "', aidsource_16_home = '" + aidsource_16_Home +
                                               "', aidperiod_11 = '" + aidperiod_11 + "', aidperiod_20 = '" + aidperiod_20 + "', aidperiod_19 = '" + aidperiod_19 + "', aidperiod_14 = '" + aidperiod_14 + "', aidperiod_12 = '" + aidperiod_12 + "',  aidperiod_17_home = '" + aidperiod_17_Home + "', aidperiod_16_home = '" + aidperiod_16_Home +
                                               "', aid_amount_11 = '" + aidamount_11 + "', aid_amount_20 = '" + aidamount_20 + "', aid_amount_19 = '" + aidamount_19 + "', aid_amount_14 = '" + aidamount_14 + "', aid_amount_12 = '" + aidamount_12 + "',  aid_amount_17_home = '" + aidamount_17_Home + "', aid_amount_16_home = '" + aidamount_16_Home +
                                               "', aid_note_11 = '" + NoteAid_11 + "', aid_note_20 = '" + NoteAid_20 + "', aid_note_19 = '" + NoteAid_19 + "', aid_note_12 = '" + NoteAid_12 + "', aid_note_17_home = '" + NoteAid_17_home + "',  aid_note_16_home = '" + NoteAid_16_home +
                                               "', income_relation_id_12 = '" + IncomeRelation_12 + "', income_address_12 = '" + income_address_12 + "', aid_amount_30 = '" + aidamount_30 + "', aidperiod_30 = '" + aidperiod_30 +
                                               "' where family_visitdetails.family_visit_id = " + Visit_ID + "; ";


                }

                if (Expenses_Information_IsDirty)
                {
                    if (Expenses_1_comboBox.SelectedValue == null)
                        Expenses_1 = 0;
                    else Expenses_1 = int.Parse(Expenses_1_comboBox.SelectedValue.ToString());
                    if (ExpensesAmount_3_TextBox.Text == "")
                        ExpensesAmount_3 = 0;
                    else ExpensesAmount_3 = int.Parse(ExpensesAmount_3_TextBox.Text);
                    if (ExpensesAmount_19_TextBox.Text == "")
                        ExpensesAmount_19 = 0;
                    else ExpensesAmount_19 = int.Parse(ExpensesAmount_19_TextBox.Text);
                    if (ExpensesAmount_21_TextBox.Text == "")
                        ExpensesAmount_21 = 0;
                    else ExpensesAmount_21 = int.Parse(ExpensesAmount_21_TextBox.Text);
                    if (ExpensesAmount_22_TextBox.Text == "")
                        ExpensesAmount_22 = 0;
                    else ExpensesAmount_22 = int.Parse(ExpensesAmount_22_TextBox.Text);
                    if (ExpensesAmount_11_TextBox.Text == "")
                        ExpensesAmount_11 = 0;
                    else ExpensesAmount_11 = int.Parse(ExpensesAmount_11_TextBox.Text);
                    if (ExpensesAmount_2_Home_TextBox.Text == "")
                        ExpensesAmount_2_Home = 0;
                    else ExpensesAmount_2_Home = int.Parse(ExpensesAmount_2_Home_TextBox.Text);
                    if (Expenses_10_TextBox.Text == "")
                        Expenses_10 = "";
                    else Expenses_10 = Expenses_10_TextBox.Text;
                    if (ExpensesAmount_10_TextBox.Text == "")
                        ExpensesAmount_10 = 0;
                    else ExpensesAmount_10 = int.Parse(ExpensesAmount_10_TextBox.Text);
                    if (ExpensesAmount_20_TextBox.Text == "")
                        ExpensesAmount_20 = 0;
                    else ExpensesAmount_20 = int.Parse(ExpensesAmount_20_TextBox.Text);
                    Expenses_Query += "UPDATE family_visitdetails set expenses_1 = '" + Expenses_1 + "', expenses_amount_3 = '" + ExpensesAmount_3 + "', expenses_amount_19 = '" + ExpensesAmount_19 + "', expenses_amount_20 = '" + ExpensesAmount_20 + "', expenses_amount_2_home = '" + ExpensesAmount_2_Home + "',  expenses_amount_21 = '" + ExpensesAmount_21 + "', expenses_amount_22 = '" + ExpensesAmount_22 + "', expenses_amount_11 = '" + ExpensesAmount_11 + "', expenses_10 = '" + Expenses_10 + "', expenses_amount_10 = '" + ExpensesAmount_10 
                        + "' where family_visitdetails.family_visit_id = " + Visit_ID + "; ";
                }

                if (Lighting_Information_IsDirty)
                {
                    if (Expenses_7_Home_Yes_RadioButton.Checked)
                    {
                        Expenses_7_Home = 1;
                        expenses_amount_7_Home = expenses_amount_7_Home_TextBox.Text == "" ? 0 : int.Parse(expenses_amount_7_Home_TextBox.Text);
                        AmperNumber_7_Home = AmperNumber_7_Home_TextBox.Text == "" ? 0 : decimal.Parse(AmperNumber_7_Home_TextBox.Text);
                        if (int.Parse(aidsource_4_ComboBox.SelectedValue.ToString()) == null)
                            aidsource_4 = 0;
                        else aidsource_4 = int.Parse(aidsource_4_ComboBox.SelectedValue.ToString());
                        if (aidamount_4_TextBox.Text == "")
                            aidamount_4 = 0;
                        else aidamount_4 = int.Parse(aidamount_4_TextBox.Text);
                        if (int.Parse(aidperiod_4_ComboBox.SelectedValue.ToString()) == null)
                            aidperiod_4 = 0;
                        else aidperiod_4 = int.Parse(aidperiod_4_ComboBox.SelectedValue.ToString());
                    }
                    else if (Expenses_7_Home_No_RadioButton.Checked)
                    {
                        Expenses_7_Home = 0;
                    }
                    else
                    {
                        Expenses_7_Home = null;
                    }
                    if (Expenses_17_Home_Yes_RadioButton.Checked)
                    {
                        Expenses_17_Home = 1;
                        if (AmperNumber_17_Home_TextBox.Text == "")
                            AmperNumber_17_Home = 0;
                        else AmperNumber_17_Home = decimal.Parse(AmperNumber_17_Home_TextBox.Text.ToString());
                        if (aidsource_16_ComboBox.SelectedValue == null)
                            aidsource_16 = 0;
                        else aidsource_16 = int.Parse(aidsource_16_ComboBox.SelectedValue.ToString());
                        if (aidamount_16_TextBox.Text == "")
                            aidamount_16 = 0;
                        else aidamount_16 = int.Parse(aidamount_16_TextBox.Text);
                        if (aidperiod_16_ComboBox.SelectedValue == null)
                            aidperiod_16 = 0;
                        else aidperiod_16 = int.Parse(aidperiod_16_ComboBox.SelectedValue.ToString());
                    }
                    else if (Expenses_17_Home_No_RadioButton.Checked)
                    {
                        Expenses_17_Home = 0;
                    }
                    else
                    {
                        Expenses_17_Home = null;
                    }
                    if (Expenses_16_Home_Yes_RadioButton.Checked)
                    {
                        Expenses_16_Home = 1;
                    }
                    else if (Expenses_16_Home_No_RadioButton.Checked)
                    {
                        Expenses_16_Home = 0;
                    }
                    else
                    {
                        Expenses_16_Home = null;
                    }

                    if (Electricity_Yes_RadioButton.Checked)
                    {
                        Electricity = 1;
                        ElectricityNote = "";
                    }
                    else if (Electricity_No_RadioButton.Checked)
                    {
                        Electricity = 0;
                        ElectricityNote = ElectricityNote_TextBox.Text;
                    }
                    else
                    {
                        Electricity = null;
                    }
                     
                    Lighting_Query += " UPDATE family_visitdetails set " +
                        "  expenses_7_home = '"         + Expenses_7_Home + "'" +
                        ", amper_number_7_home = '"     + AmperNumber_7_Home + "'" +
                        ", expenses_amount_7_home = '"  + expenses_amount_7_Home + "'" +
                        ", aidsource_4 = '"      + aidsource_4 + "'" +
                        ", aid_amount_4 = '"    + aidamount_4 + "'" +
                        ", aidperiod_4 = '"      + aidperiod_4 + "'" +
                        ", expenses_17_home = '" + Expenses_17_Home + "'" +
                        ", amper_number_17_home = '"    + AmperNumber_17_Home + "'" +
                        ", aidsource_16 = '"    + aidsource_16 + "'" +
                        ", aid_amount_16 = '"   + aidamount_16 + "'" +
                        ", aidperiod_16 = '"    + aidperiod_16 + "'" +
                        ", expenses_16_home = '"       + Expenses_16_Home + "'" +
                        ", isElectricity = '"          + Electricity + "'" +
                        ", electricity_note = '"       + ElectricityNote + "'" +
                        " where family_visitdetails.family_visit_id = " + Visit_ID + "; "; 
                }

                if (BuildingCondition_Information_isDirty)
                {
                    if (BuildingConditionNotExist1.Checked)
                    {
                        BuildingCond_1 = 1;
                    }
                    else if (BuildingConditionMed1.Checked)
                    {
                        BuildingCond_1 = 3;
                    }
                    else if (BuildingConditionHigh1.Checked)
                    {
                        BuildingCond_1 = 2;
                    }
                    else
                    {
                        BuildingCond_1 = null;
                    }
                    if (BuildingConditionNotExist2.Checked)
                    {
                        BuildingCond_2 = 1;
                    }
                    else if (BuildingConditionMed2.Checked)
                    {
                        BuildingCond_2 = 3;
                    }
                    else if (BuildingConditionHigh2.Checked)
                    {
                        BuildingCond_2 = 2;
                    }
                    else
                    {
                        BuildingCond_2 = null;
                    }
                    if (BuildingConditionNotExist3.Checked)
                    {
                        BuildingCond_3 = 1;
                    }
                    else if (BuildingConditionMed3.Checked)
                    {
                        BuildingCond_3 = 3;
                    }
                    else if (BuildingConditionHigh3.Checked)
                    {
                        BuildingCond_3 = 2;
                    }
                    else
                    {
                        BuildingCond_3 = null;
                    }
                    if (BuildingConditionNotExist5.Checked)
                    {
                        BuildingCond_5 = 4;
                    }
                    else if (BuildingConditionMed5.Checked)
                    {
                        BuildingCond_5 = 3;
                    }
                    else if (BuildingConditionHigh5.Checked)
                    {
                        BuildingCond_5 = 5;
                    }
                    else
                    {
                        BuildingCond_5 = null;
                    }
                    if (BuildingConditionNotExist8.Checked)
                    {
                        BuildingCond_8 = 4;
                    }
                    else if (BuildingConditionMed8.Checked)
                    {
                        BuildingCond_8 = 3;
                    }
                    else if (BuildingConditionHigh8.Checked)
                    {
                        BuildingCond_8 = 5;
                    }
                    else
                    {
                        BuildingCond_8 = null;
                    }

                    if (BuildingCond_1 != 0 || BuildingCond_2 != 0 || BuildingCond_3 != 0 || BuildingCond_5 != 0 || BuildingCond_8 != 0)
                    {
                        BuildingCondition_Query += "UPDATE family_visitdetails set buildingcondition_1 = '" + BuildingCond_1 + "', buildingcondition_2 = '" + BuildingCond_2 + "', buildingcondition_3 = '" + BuildingCond_3 + "', buildingcondition_5 = '" + BuildingCond_5 +
                                                     "', buildingcondition_8 = '" + BuildingCond_8 + "' where family_visitdetails.family_visit_id = " + Visit_ID + "; ";
                    }
                }

                if (Electrical_Devices_IsDirty)
                {
                    if (ElectricalDevicesNonExist1.Checked)
                    {
                        ElectricalDevices_1 = 0;
                    }
                    else if (ElectricalDevicesExist1.Checked)
                    {
                        ElectricalDevices_1 = 1;
                    }
                    else if (ElectricalDevicesFail1.Checked)
                    {
                        ElectricalDevices_1 = 2;
                    }
                    else
                    {
                        ElectricalDevices_1 = null;
                    }

                    if (ElectricalDevicesNonExist2.Checked)
                    {
                        ElectricalDevices_2 = 0;
                    }
                    else if (ElectricalDevicesExist2.Checked)
                    {
                        ElectricalDevices_2 = 1;
                    }
                    else if (ElectricalDevicesFail2.Checked)
                    {
                        ElectricalDevices_2 = 2;
                    }
                    else
                    {
                        ElectricalDevices_2 = null;
                    }
                    if (ElectricalDevicesNonExist3.Checked)
                    {
                        ElectricalDevices_3 = 0;
                    }
                    else if (ElectricalDevicesExist3.Checked)
                    {
                        ElectricalDevices_3 = 1;
                    }
                    else if (ElectricalDevicesFail3.Checked)
                    {
                        ElectricalDevices_3 = 2;
                    }
                    else
                    {
                        ElectricalDevices_3 = null;
                    }
                    if (HeatingCoolingDevices_1.Checked)
                    {
                        HeatingCooling_1 = 1;
                    }
                    else
                    {
                        HeatingCooling_1 = 0;
                    }
                    if (HeatingCoolingDevices_2.Checked)
                    {
                        HeatingCooling_2 = 1;
                    }
                    else
                    {
                        HeatingCooling_2 = 0;
                    }
                    if (HeatingCoolingDevices_3.Checked)
                    {
                        HeatingCooling_3 = 1;
                    }
                    else
                    {
                        HeatingCooling_3 = 0;
                    }
                    if (HeatingCoolingDevices_4.Checked)
                    {
                        HeatingCooling_4 = 1;
                    }
                    else
                    {
                        HeatingCooling_4 = 0;
                    }
                    if (ElectricalDevices_1 != -1 || ElectricalDevices_2 != -1 || ElectricalDevices_3 != -1 || HeatingCooling_1 != -1 || HeatingCooling_2 != -1 || HeatingCooling_3 != -1 || HeatingCooling_4 != -1)
                    {
                        ElectricalDevices_Query += "UPDATE family_visitdetails set `electricaldevices_1` = '" + ElectricalDevices_1 + "', `electricaldevices_2` = '" + ElectricalDevices_2 + "', `electricaldevices_3` = '" + ElectricalDevices_3 +
                                                   "', `heating_cooling_devices/1` = '" + HeatingCooling_1 + "', `heating_cooling_devices/2` = '" + HeatingCooling_2 + "',  `heating_cooling_devices/3` = '" + HeatingCooling_3 + "', `heating_cooling_devices/4` = '" + HeatingCooling_4 +
                                                   "' where family_visitdetails.family_visit_id = " + Visit_ID + "; ";
                    }
                }

                if (LivingWith_DataGridView_IsDirty)
                {
                    if (LivingWithFamily_LayoutPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text == "نعم")
                    {
                        LivingWithFamily = 1;
                        if (LivingWith_DataGridView_IsDirty)
                            for (int i = 0; i < LivingWith_DataGridView.Rows.Count - 1; i++)
                            {
                                //int LivingWithID =  int.Parse(LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_ID"].Value.ToString());
                                string LivingWith_Note = LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Note"].Value == null ? "" : LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Note"].Value.ToString();
                                int? LivingCode;
                                if (LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Code"].Value == null)
                                {
                                    LivingCode = null;
                                }
                                else LivingCode = int.Parse(LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Code"].Value.ToString());
                                if (LivingWith_DataGridView.Rows[i].Visible == false)
                                {
                                    LivingWith_Query += "DELETE FROM family_livingwith WHERE (family_livingwith.family_id1 = '" + LivingCode + "' and family_livingwith.note = '" + LivingWith_Note + "')  or (family_livingwith.family_id2 = '" + LivingCode + "' and family_livingwith.note = '" + LivingWith_Note + "');";
                                    LivingWith_Query += "Update family set LivingWithFamily = 0 where family.id = @Family_ID;";
                                }
                                //else if (LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_Code"].Value != null && LivingWith_DataGridView.Rows[i].Cells["LivingWith_IsDirty"].Value != null)
                                //{
                                //if (LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_ID"].Value != null)
                                //{
                                //    LivingWith_Query += "UPDATE family_livingwith set family_id2 = '" + LivingCode + "', note = '" + LivingWith_Note + "' where id = '" + LivingWithID + "';";
                                //    LivingWith_Query += "Update family set LivingWithFamily = 1 where family.id = @Family_ID;";
                                //    LivingWith_Query += "Update family set LivingWithFamily = 1 where family.id = " + LivingCode +";";
                                //    //LivingWith_Query += "update family as f1 inner join( select id from family where code = '"+ LivingCode + "') as f2 set f1.LivingWithFamily = 1 where f1.code = '"+ LivingCode + "';";
                                //}
                                if (LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_ID"].Value == null)
                                {
                                    LivingWith_Query += "INSERT INTO family_livingwith (family_id1, family_id2, note) VALUES ('" + Family_ID + "', '" + LivingCode + "', '" + LivingWith_Note + "');";
                                    if (i != 0)
                                    {
                                        for (int j = 0; j < LivingWith_DataGridView.Rows.Count - 1; j++)
                                        {
                                            if (j != i)
                                            {
                                                int? LivingCodePrevious;
                                                if (LivingWith_DataGridView.Rows[j].Cells["Family_livingWith_Code"].Value == null)
                                                {
                                                    LivingCodePrevious = null;
                                                }
                                                else LivingCodePrevious = int.Parse(LivingWith_DataGridView.Rows[j].Cells["Family_livingWith_Code"].Value.ToString());
                                                LivingWith_Query += "INSERT INTO family_livingwith (family_id1, family_id2, note) VALUES ('" + LivingCode + "', '" + LivingCodePrevious + "', '" + LivingWith_Note + "');";
                                                LivingWith_Query += "Update family set LivingWithFamily = 1 where family.id = '" + LivingCodePrevious + "';";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    LivingWith_Query += "Update family_livingwith set note = '" + LivingWith_Note + "' where family_id1 = '" + LivingCode + "' or family_id2 = '" + LivingCode + "';";
                                }
                                LivingWith_Query += "Update family set LivingWithFamily = 1 where family.id = @Family_ID;";
                                LivingWith_Query += "Update family set LivingWithFamily = 1 where family.id = '" + LivingCode + "';";
                                //LivingWith_Query += "update family as f1 inner join( select id from family where code = '" + LivingCode + "') as f2 set f1.LivingWithFamily = 1 where f1.code = '" + LivingCode + "';";
                            }
                        //}
                    }
                    //if (string.IsNullOrEmpty(LivingWithCode_ComboBox.Text) || LivingWithCode_ComboBox.SelectedIndex < 0)
                    //    LivingWithCode = null;
                    //else
                    //    LivingWithCode = int.Parse(LivingWithCode_ComboBox.SelectedValue.ToString());

                    //LivingWithNote = LivingWithNote_TextBox.Text;
                    //if (string.IsNullOrEmpty(LivingWithCode2_ComboBox.Text) || LivingWithCode2_ComboBox.SelectedIndex < 0)
                    //    LivingWithCode2 = null;
                    //else
                    //    LivingWithCode2 = int.Parse(LivingWithCode2_ComboBox.SelectedValue.ToString());

                    //LivingWithNote2 = LivingWithNote2_TextBox.Text;
                }
                else
                {
                    LivingWithFamily = 0;
                    for (int i = 0; i < LivingWith_DataGridView.Rows.Count - 1; i++)
                    {
                        int LivingWithID = LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_ID"].Value == null ? -1 : int.Parse(LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_ID"].Value.ToString());
                        string LivingWith_Note = LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Note"].Value == null ? "" : LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Note"].Value.ToString();
                        int? LivingCode;
                        if (LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Code"].Value == null)
                        {
                            LivingCode = null;
                        }
                        else LivingCode = int.Parse(LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Code"].Value.ToString());
                        if (LivingWith_DataGridView.Rows[i].Visible == false)
                        {
                            LivingWith_Query += "DELETE FROM family_livingwith WHERE (family_livingwith.family_id1 = " + LivingCode + " and family_livingwith.note = " + LivingWith_Note + ")  or (family_livingwith.family_id2 = " + LivingCode + " and family_livingwith.note = " + LivingWith_Note + ");";
                            LivingWith_Query += "Update family set LivingWithFamily = 0 where family.id = @Family_ID;";
                        }
                    }
                    LivingWith_DataGridView.Rows.Clear();
                }
                Form_Name = this.Name;
            }
            #endregion
        }

        private void InEvaluation_RadioButton_Click(object sender, EventArgs e)
        {
            try
            {
                InEvaluation_RadioButton.Checked = !InEvaluation_RadioButton.Checked;

                if (UserMode)
                {
                    int inEvaluation = InEvaluation_RadioButton.Checked == true ? 1 : 0;
                    f.Update_Family_Evaluation(Family_ID, FamilyCode_TextBox.Text, inEvaluation,EvaluationDate_TextBox.Text, this.Name);
                    //to hide/show controls
                    if (!InEvaluation_RadioButton.Checked)
                    {
                        InEvaluationBy_TextBox.Visible = InEvaluationLable.Visible = EvaluationDate_TextBox.Visible = false;
                        InEvaluationBy_TextBox.Text = EvaluationDate_TextBox.Text = "";
                    }
                    else
                    {
                        InEvaluationBy_TextBox.Visible = InEvaluationLable.Visible = EvaluationDate_TextBox.Visible = true;
                        InEvaluationBy_TextBox.Text = Properties.Settings.Default.Username;
                        EvaluationDate_TextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    MessageBox.Show("تم تعديل الحالة بنجاح", "Confirmation");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void getFamilyStatistics()
        {
            int aid_11 = aidamount_11_TextBox.Text == "" ? 0 : int.Parse(aidamount_11_TextBox.Text);
            int aid_12 = aidamount_12_TextBox.Text == "" ? 0 : int.Parse(aidamount_12_TextBox.Text);
            int aid_14 = aidamount_14_TextBox.Text == "" ? 0 : int.Parse(aidamount_14_TextBox.Text);
            int aid_19 = aidamount_19_TextBox.Text == "" ? 0 : int.Parse(aidamount_19_TextBox.Text);
            int aid_20 = aidamount_20_TextBox.Text == "" ? 0 : int.Parse(aidamount_20_TextBox.Text);
            int aid_17_Home = aidamount_17_Home_TextBox.Text == "" ? 0 : int.Parse(aidamount_17_Home_TextBox.Text);
            int aid_16_Home = aidamount_16_Home_TextBox.Text == "" ? 0 : int.Parse(aidamount_16_Home_TextBox.Text);
            int totalAid = aid_11 + aid_12 + aid_14 + aid_19 + aid_20 + aid_17_Home + aid_16_Home;
            if (totalAid == 0)
            {
                totalAidLabel.Text = "0";
            }
            else
            {
                totalAidLabel.Text = totalAid.ToString();
            }

            int Expenses_3 = ExpensesAmount_3_TextBox.Text == "" ? 0 : int.Parse(ExpensesAmount_3_TextBox.Text);
            int Expenses_19 = ExpensesAmount_19_TextBox.Text == "" ? 0 : int.Parse(ExpensesAmount_19_TextBox.Text);
            int Expenses_20 = ExpensesAmount_20_TextBox.Text == "" ? 0 : int.Parse(ExpensesAmount_20_TextBox.Text);
            int Expenses_21 = ExpensesAmount_21_TextBox.Text == "" ? 0 : int.Parse(ExpensesAmount_21_TextBox.Text);
            int Expenses_22 = ExpensesAmount_22_TextBox.Text == "" ? 0 : int.Parse(ExpensesAmount_22_TextBox.Text);
            int Expenses_11 = ExpensesAmount_11_TextBox.Text == "" ? 0 : int.Parse(ExpensesAmount_11_TextBox.Text);
            int Expenses_2_Home = ExpensesAmount_2_Home_TextBox.Text == "" ? 0 : int.Parse(ExpensesAmount_2_Home_TextBox.Text);

            int totalExpenses = Expenses_3 + Expenses_19 + Expenses_20 + Expenses_21 + Expenses_22 + Expenses_11 + Expenses_2_Home;
            if (totalExpenses == 0)
            {
                totalExpensesLabel.Text = "0";
            }
            else totalExpensesLabel.Text = totalExpenses.ToString();
        }

        private void NotYet_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (NotYet_RadioButton.Checked)
                //{
                //    Done_RadioButton.Visible = false; WillNotReason_Label.Visible = WillNotReason_TextBox.Visible = false;
                //}

                if (UserMode)
                    FamilyVisitState_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        //private void WillNot_RadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (WillNot_RadioButton.Checked)
        //        {
        //            //Done_RadioButton.Visible = false; WillNotReason_Label.Visible = WillNotReason_TextBox.Visible = true;
        //        }

        //        if (UserMode)
        //            FamilyVisitState_IsDirty = true;
        //    }

        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
        //    }
        //}

        private void Refused_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (Refused_RadioButton.Checked)
                //{
                //    Done_RadioButton.Visible = false; WillNotReason_Label.Visible = WillNotReason_TextBox.Visible = true;
                //}

                if (UserMode)
                    FamilyVisitState_IsDirty = true;
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Done_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //{
                //    if (Done_RadioButton.Checked)
                //    {
                //        WillNotReason_Label.Visible = WillNotReason_TextBox.Visible = false;
                //    }
                //}

                //if (UserMode)
                //{
                //    if (!Done_RadioButton.Checked)
                //    {
                //        UserMode = false;
                //        MessageBox.Show("لا يمكن تغيير حالة الزيارة لعائلة تمت زيارتها مسبقاً" + Environment.NewLine + "يجب مسح جميع الزيارات حتى تتمكن من تغيير حالة الزيارة للعائلة", "Error");
                //        Done_RadioButton.Checked = true;
                //        UserMode = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Income_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == Income_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == Income_DataGridView.Columns["Income_DeleteRow"].Index)
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

        private void Aid_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex == Aid_DataGridView.NewRowIndex || e.RowIndex < 0)
            //        return;

            //    if (e.ColumnIndex == Aid_DataGridView.Columns["Aid_DeleteRow"].Index)
            //    {
            //        Image image = null;
            //        image = Properties.Resources.Trash_Small_L;
            //        e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            //        var size = image.Size;
            //        var location = new Point((e.CellBounds.Width - size.Width) / 2, (e.CellBounds.Height - size.Height) / 2);
            //        location.Offset(e.CellBounds.Location);
            //        e.Graphics.DrawImage(image, location);

            //        e.Handled = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void Loss_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                //if (e.RowIndex == Loss_DataGridView.NewRowIndex || e.RowIndex < 0)
                //    return;

                //if (e.ColumnIndex == Loss_DataGridView.Columns["Loss_DeleteRow"].Index)
                //{
                //    Image image = null;
                //    image = Properties.Resources.Trash_Small_L;
                //    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                //    var size = image.Size;
                //    var location = new Point((e.CellBounds.Width - size.Width) / 2, (e.CellBounds.Height - size.Height) / 2);
                //    location.Offset(e.CellBounds.Location);
                //    e.Graphics.DrawImage(image, location);

                //    e.Handled = true;
                //}
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Asset_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == Asset_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == Asset_DataGridView.Columns["Asset_DeleteRow"].Index)
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

        private void Partner_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == Partner_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == Partner_DataGridView.Columns["Partner_DeleteRow"].Index)
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

        private void Expenses_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex == Expenses_DataGridView.NewRowIndex || e.RowIndex < 0)
            //        return;

            //    if (e.ColumnIndex == Expenses_DataGridView.Columns["Expenses_DeleteRow"].Index)
            //    {
            //        Image image = null;
            //        image = Properties.Resources.Trash_Small_L;
            //        e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            //        var size = image.Size;
            //        var location = new Point((e.CellBounds.Width - size.Width) / 2, (e.CellBounds.Height - size.Height) / 2);
            //        location.Offset(e.CellBounds.Location);
            //        e.Graphics.DrawImage(image, location);

            //        e.Handled = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void BuildingCondition_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex == LivingCondition_DataGridView.NewRowIndex || e.RowIndex < 0)
            //        return;

            //    if (e.ColumnIndex == LivingCondition_DataGridView.Columns["BuildingCondition_DeleteRow"].Index)
            //    {
            //        Image image = null;
            //        image = Properties.Resources.Trash_Small_L;
            //        e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            //        var size = image.Size;
            //        var location = new Point((e.CellBounds.Width - size.Width) / 2, (e.CellBounds.Height - size.Height) / 2);
            //        location.Offset(e.CellBounds.Location);
            //        e.Graphics.DrawImage(image, location);

            //        e.Handled = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void Family_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing && !Deleted && !toPopUp)
                {
                    //this.ActiveControl = Save_Button;

                    if (General_Information_IsDirty || Partner_DataGridView_IsDirty || FamilyVisitState_IsDirty || LivingWith_DataGridView_IsDirty ||
                            Income_DataGridView_IsDirty || Aid_Information_IsDirty || CarAsset_DataGridView_IsDirty ||
                            Asset_DataGridView_IsDirty || Lighting_Information_IsDirty || BuildingCondition_Information_isDirty || Expenses_Information_IsDirty || Electrical_Devices_IsDirty
                            || LivingCondition_Information_IsDirty)
                    {
                        if (MessageBox.Show("يوجد بعض التعديلات غير المحفوظة، هل تود حفظها قبل إغلاق الصفحة؟؟", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (UpdateMode)
                            {
                                Update_Button.PerformClick();
                                //if (Visit_Details_IsDirty && materialTabControl1.SelectedTab == Visits_TabPage)
                                //{
                                //    VisitUpdate_Button.PerformClick();
                                //}
                            }
                            //else
                            //    Save_Button.PerformClick();

                            //e.Cancel = true;
                            //return;
                        }
                        else
                        {
                            // continue closing;
                        }
                    }

                    if (UpdateMode)
                    {
                        DataTable dt = p.Check_Receiver(Family_ID, -1);
                        if (dt == null)
                        {
                            if (MessageBox.Show("لم يتم تحديد مستلم لهذه العائلة بعد" + Environment.NewLine + "هل تريد مغادرة الصفحة بالرغم من ذلك؟؟", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                // continue closing;
                            }
                            else
                            {
                                e.Cancel = true;
                                //return;
                            }
                        }
                    }
                }
                Program.Family_Opened.Remove(Family_ID);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = Delete_Button;
                DialogResult dialogResult = MessageBox.Show("سيتم حذف العائلة بشكل كامل!!", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    f.Delete_Family(Family_ID, FamilyCode_TextBox.Text, this.Name);

                    MessageBox.Show("تم حذف العائلة " + Code + "  بنجاح", "Confirmation");
                    Deleted = true;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("Cannot delete or update a parent row"))
                    MessageBox.Show("لا يمكن حذف هذه العائلة بسبب ارتباطها إما بتوزيعة قديمة أو بعائلة أخرى", "Error");
                else
                    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Income_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == Income_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (!Income_DataGridView.Rows[e.RowIndex].Cells["Income_VisitName"].Value.Equals(VisitNameLabel.Text))
                {
                    MessageBox.Show("يُرجى الذهاب إلى الزيارة للتعديل");
                    return;
                }

                //Check if click is on specific column 
                if (e.ColumnIndex == Income_DataGridView.Columns["Income_DeleteRow"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Income_DataGridView.Rows[e.RowIndex].Cells["Family_Income_ID"].Value != null)
                        {
                            Income_DataGridView_IsDirty = true;
                            Income_DataGridView.Rows[e.RowIndex].Cells["Income_IsDirty"].Value = "1";
                            Income_DataGridView.Rows[e.RowIndex].Visible = false;
                        }
                        else
                        {
                            Income_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Aid_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    //if click is on new row or header row
            //    if (e.RowIndex == Aid_DataGridView.NewRowIndex || e.RowIndex < 0)
            //        return;
            //    //Check if click is on specific column 
            //    if (e.ColumnIndex == Aid_DataGridView.Columns["Aid_DeleteRow"].Index)
            //    {
            //        DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            if (Aid_DataGridView.Rows[e.RowIndex].Cells["Family_Aid_ID"].Value != null)
            //            {
            //                Aid_DataGridView_IsDirty = true;
            //                Aid_DataGridView.Rows[e.RowIndex].Cells["Aid_IsDirty"].Value = "1";
            //                Aid_DataGridView.Rows[e.RowIndex].Visible = false;
            //            }
            //            else
            //            {
            //                Aid_DataGridView.Rows.RemoveAt(e.RowIndex);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void Loss_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    //if click is on new row or header row
            //    if (e.RowIndex == Loss_DataGridView.NewRowIndex || e.RowIndex < 0)
            //        return;
            //    //Check if click is on specific column 
            //    if (e.ColumnIndex == Loss_DataGridView.Columns["Loss_DeleteRow"].Index)
            //    {
            //        DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            if (Loss_DataGridView.Rows[e.RowIndex].Cells["Family_Loss_ID"].Value != null)
            //            {
            //                Loss_DataGridView_IsDirty = true;
            //                Loss_DataGridView.Rows[e.RowIndex].Cells["Loss_IsDirty"].Value = "1";
            //                Loss_DataGridView.Rows[e.RowIndex].Visible = false;
            //            }
            //            else
            //            {
            //                Loss_DataGridView.Rows.RemoveAt(e.RowIndex);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void Asset_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == Asset_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                //Check if click is on specific column 
                if (e.ColumnIndex == Asset_DataGridView.Columns["Asset_DeleteRow"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Asset_DataGridView.Rows[e.RowIndex].Cells["Family_asset_ID"].Value != null)
                        {
                            Asset_DataGridView_IsDirty = true;
                            Asset_DataGridView.Rows[e.RowIndex].Cells["Asset_IsDirty"].Value = "1";
                            Asset_DataGridView.Rows[e.RowIndex].Visible = false;
                        }
                        else
                        {
                            Asset_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Partner_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == Partner_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;
                //Check if click is on specific column 
                if (e.ColumnIndex == Partner_DataGridView.Columns["Partner_DeleteRow"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Partner_DataGridView.Rows[e.RowIndex].Cells["Family_Partner_ID"].Value != null)
                        {
                            Partner_DataGridView_IsDirty = true;
                            Partner_DataGridView.Rows[e.RowIndex].Cells["Partner_IsDirty"].Value = "1";
                            Partner_DataGridView.Rows[e.RowIndex].Visible = false;
                        }
                        else
                        {
                            Partner_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Expenses_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    //if click is on new row or header row
            //    if (e.RowIndex == Expenses_DataGridView.NewRowIndex || e.RowIndex < 0)
            //        return;
            //    //Check if click is on specific column 
            //    if (e.ColumnIndex == Expenses_DataGridView.Columns["Expenses_DeleteRow"].Index)
            //    {
            //        DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            if (Expenses_DataGridView.Rows[e.RowIndex].Cells["Family_Expenses_ID"].Value != null)
            //            {
            //                Expenses_DataGridView_IsDirty = true;
            //                Expenses_DataGridView.Rows[e.RowIndex].Cells["Expenses_IsDirty"].Value = "1";
            //                Expenses_DataGridView.Rows[e.RowIndex].Visible = false;
            //            }
            //            else
            //            {
            //                Expenses_DataGridView.Rows.RemoveAt(e.RowIndex);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void LivingCondition_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    //if click is on new row or header row
            //    if (e.RowIndex == LivingCondition_DataGridView.NewRowIndex || e.RowIndex < 0)
            //        return;
            //    //Check if click is on specific column 
            //    if (e.ColumnIndex == LivingCondition_DataGridView.Columns["LivingCondition_DeleteRow"].Index)
            //    {
            //        DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            if (LivingCondition_DataGridView.Rows[e.RowIndex].Cells["Family_LivingCondition_ID"].Value != null)
            //            {
            //                //LivingCondition_DataGridView = true;
            //                LivingCondition_DataGridView.Rows[e.RowIndex].Cells["LivingCondition_IsDirty"].Value = "1";
            //                LivingCondition_DataGridView.Rows[e.RowIndex].Visible = false;
            //            }
            //            else
            //            {
            //                LivingCondition_DataGridView.Rows.RemoveAt(e.RowIndex);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void Asset_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                //if (UserMode)
                //{
                //    if (Asset_DataGridView.Rows[e.RowIndex - 1].Cells["Family_Asset_ID"].Value == null || Asset_DataGridView.Rows[e.RowIndex - 1].Cells["Family_Asset_ID"].Value.ToString() == "")
                //    {
                //        Asset_DataGridView.Rows[e.RowIndex - 1].Cells["Family_Asset_ID"].Value = 1;
                //    }
                //}

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Loss_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                //if (UserMode)
                //{
                //    if (Loss_DataGridView.Rows[e.RowIndex - 1].Cells["L_Number"].Value == null || Loss_DataGridView.Rows[e.RowIndex - 1].Cells["L_Number"].Value.ToString() == "")
                //    {
                //        Loss_DataGridView.Rows[e.RowIndex - 1].Cells["L_Number"].Value = 1;
                //    }
                //}

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Expenses_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    //if (Expenses_DataGridView.Rows[e.RowIndex - 1].Cells["Expenses_Type"].Value == null || Expenses_DataGridView.Rows[e.RowIndex - 1].Cells["Expenses_Type"].Value.ToString() == "")
                    //{
                    //    Expenses_DataGridView.Rows[e.RowIndex - 1].Cells["Expenses_Type"].Value = 1;
                    //}
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

        private void DistributionHistory_Button_Click(object sender, EventArgs e)
        {
            try
            {
                History_Form NewHistory_Form = new History_Form("FamilyDistributions", Family_ID, main_form);
                NewHistory_Form.ShowDialog();
            }
            catch (Exception ex)
            { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                UserMode = false;
                if (materialTabControl1.SelectedTab.Name == "Family_TabPage")
                {
                    materialTabControl1.Size = new Size(this.Width - 20, 6000);
                    materialTabSelector1.Size = new Size(this.Width, 50);
                    DialogResult dialogResult = MessageBox.Show("هل تريد حذف جميع البيانات غير المحفوظة؟؟", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Bind_ComboBoxes(false);
                        Clear_Boxes();
                        Set_Controls();

                        if (UpdateMode)
                        {
                            Fill_Family(true, Visit_ID);
                            Bind_Members();
                        }
                    }
                    else
                    {
                        Bind_ComboBoxes(true);
                    }
                }
                //else if (materialTabControl1.SelectedTab.Name == "Members_TabPage")
                //{
                //    materialTabControl1.Size = new Size(this.Width - 20, 800);

                //    Bind_Members();
                //}
                else if (materialTabControl1.SelectedTab.Name == "Visits_TabPage")
                {
                    materialTabControl1.Size = new Size(this.Width - 20, 800);

                    Visit_Clear_Boxes();
                    Details_Panel.Hide();
                    Bind_Visits("All");
                }
                else if (materialTabControl1.SelectedTab.Name == "Marks_TabPage")
                {
                    materialTabControl1.Size = new Size(this.Width - 20, 2100);
                    //Bind_Marks();
                }
                UserMode = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void newFamilyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Form Family_Form = new Family_Form(main_form);
                main_form.showNewTab(Family_Form, "Family");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void showAsPopupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //this.ActiveControl = Save_Button;

                if (General_Information_IsDirty || Partner_DataGridView_IsDirty || FamilyVisitState_IsDirty
                    || Income_DataGridView_IsDirty || Aid_Information_IsDirty || CarAsset_DataGridView_IsDirty
                    || Asset_DataGridView_IsDirty || Lighting_Information_IsDirty || BuildingCondition_Information_isDirty || Expenses_Information_IsDirty || Electrical_Devices_IsDirty
                    || LivingCondition_Information_IsDirty || Visit_Details_IsDirty)
                {
                    if (MessageBox.Show("يوجد بعض التعديلات غير المحفوظة، هل تود حفظها قبل إغلاق الصفحة؟؟", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (UpdateMode)
                        {
                            Update_Button.PerformClick();
                            if (Visit_Details_IsDirty && materialTabControl1.SelectedTab == Visits_TabPage)
                            {
                                VisitUpdate_Button.PerformClick();
                            }
                        }
                        //else
                        //    Save_Button.PerformClick();
                    }
                }

                Form Family_Form = new Family_Form(Family_ID, main_form, true);
                Family_Form.Show();
                toPopUp = true;
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Income_DataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == Income_DataGridView.Columns["Income_Amount"].Index)
                {
                    Income_DataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Format = "N0";
                    Income_DataGridView.Columns[e.ColumnIndex].ValueType = typeof(Decimal);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Aid_DataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == Aid_DataGridView.Columns["Aid_Amount"].Index)
            //    {
            //        Aid_DataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Format = "N0";
            //        Aid_DataGridView.Columns[e.ColumnIndex].ValueType = typeof(Decimal);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void Expenses_DataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == Expenses_DataGridView.Columns["Expenses_Amount"].Index)
            //    {
            //        Expenses_DataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Format = "N0";
            //        Expenses_DataGridView.Columns[e.ColumnIndex].ValueType = typeof(Decimal);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }


        #region //IsDirty

        private void FamilyCode_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                FamilyCode_TextBox_OriginalText = FamilyCode_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void FamilyCode_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UpdateMode)
                {
                    if (FamilyCode_TextBox_OriginalText != FamilyCode_TextBox.Text)
                    {
                        if (NumOfUpdateTry == 0)
                        {
                            MessageBox.Show("لا يجب تغيير رمز العائلة مطلقاً بعد إدخاله" + Environment.NewLine + "سيتم استعادة الرمز القديم واذا كنت متأكداً من ضرورة تغييره قم بالتعديل مرة أخرى", "Alert");
                            NumOfUpdateTry = 1;
                            FamilyCode_TextBox.Text = FamilyCode_TextBox_OriginalText;
                        }
                        else
                        {
                            General_Information_IsDirty = true;
                            Check_family_Code();
                        }
                    }
                }
                else
                {
                    if (FamilyCode_TextBox_OriginalText != FamilyCode_TextBox.Text)
                    {
                        General_Information_IsDirty = true;
                        Check_family_Code();
                    }
                }


            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private bool Check_family_Code()
        {
            bool Ok = false;
            CodeChecked = false;
            if (!string.IsNullOrWhiteSpace(FamilyCode_TextBox.Text))
            {
                DataTable dt = f.Check_FamilyCode(FamilyCode_TextBox.Text, Family_ID);

                if (dt != null)
                {
                    MessageBox.Show("رمز العائلة المدخل مستخدم مسبقاً" + Environment.NewLine + "لن تسطيع حفظ معلومات هذه العائلة قبل تغيير الرمز", "Alert");
                    //Save_Button.Enabled = false;
                    Update_Button.Enabled = false;
                    CodeChecked = true; Ok = false;
                }
                else
                {
                    //Save_Button.Enabled = true;
                    Update_Button.Enabled = true;
                    CodeChecked = true; Ok = true;
                }
            }

            return Ok;
        }

        private bool Check_family_VisitDetails()
        {
            bool Ok = false;
            CodeChecked = false;
            if (Visit_ID != -1)
            {
                f.Check_FamilyVisitDetails(Family_ID, Visit_ID);
            }

            return Ok;
        }

        private void Parish_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

            try
            {
                if (UserMode)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Street_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Address_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Address_TextBox_OriginalText != Address_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Address_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                Address_TextBox_OriginalText = Address_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LandLine_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                LandLine_TextBox_OriginalText = LandLine_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void MobileNumber_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                MobileNumber_TextBox_OriginalText = MobileNumber_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void MobileNumber_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (MobileNumber_TextBox_OriginalText != MobileNumber_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Note_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                Note_TextBox_OriginalText = Note_TextBox.Text;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Note_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Note_TextBox_OriginalText != Note_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void PartnerNote_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                PartnerNote_TextBox_OriginalText = PartnerNote_TextBox.Text;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void PartnerNote_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (PartnerNote_TextBox_OriginalText != PartnerNote_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void EvaluationNote_TextBox_Enter_1(object sender, EventArgs e)
        {
            try
            {
                EvaluationNote_TextBox_OriginalText = EvaluationNote_TextBox.Text;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void EvaluationNote_TextBox_Leave_1(object sender, EventArgs e)
        {
            try
            {
                if (EvaluationNote_TextBox_OriginalText != EvaluationNote_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Partner_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Partner_DataGridView_IsDirty = true;
                Partner_DataGridView.Rows[e.RowIndex].Cells["Partner_IsDirty"].Value = 1;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        //private void WillNotReason_TextBox_Enter(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        WillNotReason_TextBox_OriginalText = WillNotReason_TextBox.Text;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
        //    }
        //}

        //private void WillNotReason_TextBox_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (WillNotReason_TextBox_OriginalText != WillNotReason_TextBox.Text)
        //            FamilyVisitState_IsDirty = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
        //    }
        //}

        private void Income_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Income_DataGridView_IsDirty = true;
                Income_DataGridView.Rows[e.RowIndex].Cells["Income_IsDirty"].Value = 1;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Aid_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    Aid_DataGridView_IsDirty = true;
            //    Aid_DataGridView.Rows[e.RowIndex].Cells["Aid_IsDirty"].Value = 1;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void Loss_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Loss_DataGridView_IsDirty = true;
                //Loss_DataGridView.Rows[e.RowIndex].Cells["Loss_IsDirty"].Value = 1;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Asset_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Asset_DataGridView_IsDirty = true;
                Asset_DataGridView.Rows[e.RowIndex].Cells["Asset_IsDirty"].Value = 1;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LivingCondition_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    LivingCondition_DataGridView_IsDirty = true;
            //    LivingCondition_DataGridView.Rows[e.RowIndex].Cells["LivingCondition_IsDirty"].Value = 1;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void Expenses_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    Expenses_DataGridView_IsDirty = true;
            //    Expenses_DataGridView.Rows[e.RowIndex].Cells["Expenses_IsDirty"].Value = 1;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void IsDisplaced_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LivingCondition_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
         
        private void LivingWithNote_TextBox_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    LivingWithNote_TextBox_OriginalText = LivingWithNote_TextBox.Text;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void LivingWithNote_TextBox_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (LivingWithNote_TextBox_OriginalText != LivingWithNote_TextBox.Text)
            //    {
            //        General_Information_IsDirty = true;
            //        LivingWithNote2_TextBox.Visible = LivingWithNote2_Label.Visible = LivingWith2_Label.Visible = LivingWithCode2_ComboBox.Visible = pictureBox1.Visible = GoToFamily2_Button.Visible = true;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void SellingFurnitureNote_TextBox_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    SellingFurnitureNote_TextBox_OriginalText = SellingFurnitureNote_TextBox.Text;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void SellingFurnitureNote_TextBox_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (SellingFurnitureNote_TextBox_OriginalText != SellingFurnitureNote_TextBox.Text)
            //        Living_Information_IsDirty = true;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ClearSellingFurniture_PictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                UserMode = false;
                SellingFurniture_Yes_RadioButton.Checked = false;
                SellingFurniture_No_RadioButton.Checked = false;
                Living_Information_IsDirty = true;
                UserMode = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void HomeType_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LivingCondition_Information_IsDirty = true;
                if (HomeType_ComboBox.SelectedIndex == 2 || HomeType_ComboBox.SelectedIndex == 4 || HomeType_ComboBox.SelectedIndex == 5 || HomeType_ComboBox.SelectedIndex == 6 || HomeType_ComboBox.SelectedIndex == 7 || HomeType_ComboBox.SelectedIndex == 11)
                {
                    LivingPanel.Enabled = true;
                }
                else
                {
                    LivingPanel.Enabled = false;
                    aidsource_5_3_home_ComboBox.SelectedValue = 0;
                    aidamount_5_3_home_TextBox.Text = "";
                    aidperiod_5_3_home_ComboBox.SelectedValue = 0;
                    home_description_TextBox.Text = "";
                    HeirsNumber_TextBox.Text = "";

                    ParishHome_ComboBox.SelectedValue = 0;
                    expensestype_6_12_home_ComboBox.SelectedValue = 0;
                    expenses_amount_6_12_home_TextBox.Text = "";
                }
                if (HomeType_ComboBox.SelectedIndex == 8)
                {
                    HeirsNumber_Label.Visible = HeirsNumber_TextBox.Visible = true;
                }
                else
                {
                    HeirsNumber_Label.Visible = HeirsNumber_TextBox.Visible = false;
                    HeirsNumber_TextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Beds_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LivingCondition_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }



        private void SellingFurniture_Yes_RadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SellingFurniture_No_RadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void livingroom_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void All_Devices_RadioButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (!ElectricalDevicesNonExist2.Checked)
                        ElectricalDevicesNonExist2.Checked = true;
                    else
                        ElectricalDevicesNonExist2.Checked = false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void All_Devices_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (ElectricalDevices_1.Checked)
            //    {
            //        ElectricalDevices_CheckedListBox.Visible = false;
            //        foreach (int i in ElectricalDevices_CheckedListBox.CheckedIndices)
            //        {
            //            ElectricalDevices_CheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
            //            IsDirty_ElectricalDevices_CheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
            //        }
            //    }
            //    else if (!ElectricalDevices_1.Checked)
            //        ElectricalDevices_CheckedListBox.Visible = true;

            //    if (UserMode)
            //        Electrical_Devices_IsDirty = true;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void ElectricalDevices_CheckedListBox_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < ElectricalDevices_CheckedListBox.Items.Count; i++)
            //{
            //    if (ElectricalDevices_CheckedListBox.GetItemRectangle(i).Contains(ElectricalDevices_CheckedListBox.PointToClient(MousePosition)))
            //    {
            //        switch (ElectricalDevices_CheckedListBox.GetItemCheckState(i))
            //        {
            //            case CheckState.Checked:
            //            ElectricalDevices_CheckedListBox.SetItemChecked(i, false);
            //            break;
            //            case CheckState.Indeterminate:
            //            case CheckState.Unchecked:
            //            ElectricalDevices_CheckedListBox.SetItemChecked(i, true);
            //            break;
            //        }

            //    }

            //}
        }

        private void ElectricalDevices_CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //if (UserMode)
            //{
            //    Electrical_Devices_IsDirty = true;
            //    if (UpdateMode)
            //    {
            //        IsDirty_ElectricalDevices_CheckedListBox.SetItemChecked(e.Index, !IsDirty_ElectricalDevices_CheckedListBox.GetItemChecked(e.Index));
            //    }
            //}
        }

        #endregion

        private void Fill_Family(bool firstLoad, int visit_id)
        {
            UserMode = false;
            Set_Controls();

            Clear_Boxes();
            if (firstLoad)
            {
                DataSet ds1 = f.Get_FamilyLastVisit(Family_ID);
                if (ds1.Tables[0].Rows.Count != 0)
                    Visit_ID = ds1.Tables[0].Rows[0].Field<int>("id");
                else
                {
                    Visit_ID = -1;
                    visitstate_Label.Text = "لم يزار بعد";
                }
            }
            else { Visit_ID = visit_id; }
            
            DataSet ds = f.Get_Family(Family_ID, Visit_ID);

            VisitNameLabel.UseMnemonic = false;
            if (Visit_ID != -1)
            {
                visitstate_Label.Text = ds.Tables[7].Rows[0].Field<string>("visitstate") == null ? "" : ds.Tables[7].Rows[0].Field<string>("visitstate");
                if (ds.Tables[10].Rows.Count != 0)
                    TotalMark_Label.Text = ds.Tables[10].Rows[0].Field<decimal>("Final_Mark") == null ? "" : ds.Tables[10].Rows[0].Field<decimal>("Final_Mark").ToString();
                if (ds.Tables[6].Rows.Count != 0)
                {
                    VisitNameLabel.Text = ds.Tables[6].Rows[0].Field<string>("visit_name") == null ? "" : ds.Tables[6].Rows[0].Field<string>("visit_name");
                    EntredBy_comboBox.SelectedValue = ds.Tables[6].Rows[0].Field<int>("visitor1_id");
                    EntredBy2_comboBox.SelectedValue = ds.Tables[6].Rows[0].Field<int>("visitor2_id");
                    EntredByOther_TextBox.Text = ds.Tables[6].Rows[0].Field<string>("othervisitors");
                }
            }

            FamilyCode_TextBox.Text = FamilyCode_TextBox3.Text = ds.Tables[0].Rows[0].Field<string>("code") == null ? "" : ds.Tables[0].Rows[0].Field<string>("code");
            FamilyNumber_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("family_number") == null ? "" : ds.Tables[0].Rows[0].Field<string>("family_number");
            try
            {
                if (ds.Tables[8].Rows[0]["NumberOfAllMembers"] != DBNull.Value)
                    NumberOfAllMembers_TextBox.Text = ds.Tables[8].Rows[0].Field<int>("NumberOfAllMembers").ToString();
            }
            catch
            {
                NumberOfAllMembers_TextBox.Text = "0";
            }
            //if (ds.Tables[9].Rows[0]["NumberOfBeneficiaries"] != DBNull.Value)
            //    NumberOfBeneficiary_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("NumberOfBeneficiaries").ToString();
            if (ds.Tables[0].Rows[0]["location_latitude"] != DBNull.Value)
                LocationLatitude_TextBox.Text = ds.Tables[0].Rows[0].Field<decimal>("location_latitude").ToString();
            if (ds.Tables[0].Rows[0]["location_longitude"] != DBNull.Value)
                LocationLongtitude_TextBox.Text = ds.Tables[0].Rows[0].Field<decimal>("location_longitude").ToString();
            if (ds.Tables[0].Rows[0]["address"] != DBNull.Value)
                Address_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("address");
            if (ds.Tables[0].Rows[0]["building_number"] != DBNull.Value)
                BuildingNumber_TextBox.Text = ds.Tables[0].Rows[0].Field<int>("building_number").ToString();
            if (ds.Tables[0].Rows[0]["floor"] != DBNull.Value)
                Floor_TextBox.Text = ds.Tables[0].Rows[0].Field<int>("floor").ToString();
            
            if (ds.Tables[9].Rows.Count != 0)
            {
                #region // LivingInfo
                if (ds.Tables[9].Rows[0]["family_note"] != DBNull.Value)
                    FamilyNote_TextBox.Text = ds.Tables[9].Rows[0].Field<string>("family_note");
                if (ds.Tables[9].Rows[0]["rooms_number"] != DBNull.Value)
                    RoomsNumber_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("rooms_number").ToString();
                if (ds.Tables[9].Rows[0]["isdisplaced_id"] != DBNull.Value)
                    IsDisplaced_ComboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("isdisplaced_id");
                if (ds.Tables[9].Rows[0]["hometype_id"] != DBNull.Value)
                {
                    HomeType_ComboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("hometype_id");
                    if (ds.Tables[9].Rows[0].Field<int>("hometype_id") == 2 || ds.Tables[9].Rows[0].Field<int>("hometype_id") == 4
                     || ds.Tables[9].Rows[0].Field<int>("hometype_id") == 5 || ds.Tables[9].Rows[0].Field<int>("hometype_id") == 6)
                    {
                        LivingPanel.Enabled = true;
                    }
                    else
                    {
                        LivingPanel.Enabled = false;
                    }
                    if (ds.Tables[9].Rows[0].Field<int>("hometype_id") == 8)
                    {
                        HeirsNumber_Label.Visible = HeirsNumber_TextBox.Visible = true;
                    }
                    else
                    {
                        HeirsNumber_Label.Visible = HeirsNumber_TextBox.Visible = false;
                    }
                }

                if (ds.Tables[9].Rows[0]["beds_id"] != DBNull.Value)
                    Beds_ComboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("beds_id");
                if (ds.Tables[9].Rows[0]["livingroom_id"] != DBNull.Value)
                    Livingroom_ComboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("livingroom_id");

                if (ds.Tables[9].Rows[0]["expenses_7_home"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("expenses_7_home") == 0)
                    {
                        Expenses_7_Home_No_RadioButton.Checked = true;
                        aidsource_4_ComboBox.SelectedValue = 0;
                        aidsource_4_ComboBox.Enabled = false;
                        aidperiod_4_ComboBox.SelectedValue = 0;
                        aidperiod_4_ComboBox.Enabled = false;
                        aidamount_4_TextBox.Text = "";
                        aidamount_4_TextBox.Enabled = false;
                        expenses_amount_7_Home_TextBox.Text = "";
                        expenses_amount_7_Home_TextBox.Enabled = false;
                        AmperNumber_7_Home_TextBox.Text = "";
                        AmperNumber_7_Home_TextBox.Visible = false;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("expenses_7_home") == 1)
                    {
                        Expenses_7_Home_Yes_RadioButton.Checked = true;
                        aidsource_4_ComboBox.Enabled = true;
                        aidperiod_4_ComboBox.Enabled = true;
                        aidamount_4_TextBox.Enabled = true;
                        expenses_amount_7_Home_TextBox.Enabled = true;
                        AmperNumber_7_Home_TextBox.Visible = true;
                    }
                }
                if (ds.Tables[9].Rows[0]["expenses_16_home"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("expenses_16_home") == 0)
                    {
                        Expenses_16_Home_No_RadioButton.Checked = true;

                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("expenses_16_home") == 1)
                    {
                        Expenses_16_Home_Yes_RadioButton.Checked = true;
                    }
                }

                if (ds.Tables[9].Rows[0]["expenses_17_home"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("expenses_17_home") == 1)
                    {
                        Expenses_17_Home_Yes_RadioButton.Checked = true;
                        aidsource_16_ComboBox.Visible = true;
                        aidperiod_16_ComboBox.Visible = true;
                        aidamount_16_TextBox.Visible = true;
                        AmperNumber_17_Home_TextBox.Visible = true;

                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("expenses_17_home") == 0)
                    {
                        Expenses_17_Home_No_RadioButton.Checked = true;
                        AmperNumber_17_Home_TextBox.Text = "";
                        aidsource_16_ComboBox.SelectedValue = 0;
                        aidperiod_16_ComboBox.SelectedValue = 0;
                        aidamount_16_TextBox.Text = "";
                        aidsource_16_ComboBox.Visible = false;
                        aidperiod_16_ComboBox.Visible = false;
                        aidamount_16_TextBox.Visible = false;
                        AmperNumber_17_Home_TextBox.Visible = false;

                    }
                }

                if (ds.Tables[9].Rows[0]["aidperiod_4"] != DBNull.Value)
                    aidperiod_4_ComboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidperiod_4").ToString();
                if (ds.Tables[9].Rows[0]["aidperiod_16"] != DBNull.Value)
                    aidperiod_16_ComboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidperiod_16").ToString();

                if (ds.Tables[9].Rows[0]["expenses_amount_6_12_home"] != DBNull.Value)
                    expenses_amount_6_12_home_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("expenses_amount_6_12_home").ToString();
                if (ds.Tables[9].Rows[0]["expensestype_6_12_home"] != DBNull.Value)
                    expensestype_6_12_home_ComboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("expensestype_6_12_home");
                if (ds.Tables[9].Rows[0]["parish_id_home"] != DBNull.Value)
                    ParishHome_ComboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("parish_id_home");
                if (ds.Tables[9].Rows[0]["home_description"] != DBNull.Value)
                    home_description_TextBox.Text = ds.Tables[9].Rows[0].Field<string>("home_description");
                if (ds.Tables[9].Rows[0]["heirs_number"] != DBNull.Value)
                    HeirsNumber_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("heirs_number").ToString();
                if (ds.Tables[9].Rows[0]["aid_amount_5_3_home"] != DBNull.Value)
                    aidamount_5_3_home_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("aid_amount_5_3_home").ToString();
                if (ds.Tables[9].Rows[0]["aidperiod_5_3_home"] != DBNull.Value)
                    aidperiod_5_3_home_ComboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidperiod_5_3_home").ToString();
                if (ds.Tables[9].Rows[0]["aidsource_5_3_home"] != DBNull.Value)
                    aidsource_5_3_home_ComboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidsource_5_3_home").ToString();
                if (ds.Tables[9].Rows[0]["expenses_amount_7_home"] != DBNull.Value)
                    expenses_amount_7_Home_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("expenses_amount_7_home").ToString();
                if (ds.Tables[9].Rows[0]["amper_number_7_home"] != DBNull.Value)
                    AmperNumber_7_Home_TextBox.Text = ds.Tables[9].Rows[0].Field<decimal>("amper_number_7_home").ToString();
                if (ds.Tables[9].Rows[0]["amper_number_17_home"] != DBNull.Value)
                    AmperNumber_17_Home_TextBox.Text = ds.Tables[9].Rows[0].Field<decimal>("amper_number_17_home").ToString();
                if (ds.Tables[9].Rows[0]["aid_amount_4"] != DBNull.Value)
                    aidamount_4_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("aid_amount_4").ToString();
                if (ds.Tables[9].Rows[0]["aid_amount_16"] != DBNull.Value)
                    aidamount_16_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("aid_amount_16").ToString();
                if (ds.Tables[9].Rows[0]["aidsource_4"] != DBNull.Value)
                    aidsource_4_ComboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidsource_4").ToString();
                if (ds.Tables[9].Rows[0]["aidsource_16"] != DBNull.Value)
                    aidsource_16_ComboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidsource_16").ToString();
                if (ds.Tables[9].Rows[0]["expenses_16_home"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("expenses_16_home") == 1)
                    {
                        Expenses_16_Home_Yes_RadioButton.Checked = true;
                    }
                    else
                    {
                        Expenses_16_Home_No_RadioButton.Checked = true;
                    }
                }

                if (ds.Tables[9].Rows[0]["isElectricity"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("isElectricity") == 1)
                    {
                        Electricity_Yes_RadioButton.Checked = true;
                        ElectricityNote_TextBox.Visible = false;
                    }
                    else
                    {
                        Electricity_No_RadioButton.Checked = true;
                        ElectricityNote_TextBox.Visible = true;

                    }
                }
                if (ds.Tables[9].Rows[0]["electricity_note"] != DBNull.Value)
                    ElectricityNote_TextBox.Text = ds.Tables[9].Rows[0].Field<string>("electricity_note");

                if (ds.Tables[9].Rows[0]["SellingFurniture"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("SellingFurniture") == 1)
                    {
                        SellingFurniture_Yes_RadioButton.Checked = true;
                        SellingFurniturePanel.Visible = true;
                    }
                    else
                    {
                        SellingFurniture_No_RadioButton.Checked = true;
                        SellingFurniturePanel.Visible = false;
                    }
                }
                if (ds.Tables[9].Rows[0]["SellingFurniture_type_id/1"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("SellingFurniture_type_id/1") == 1)
                        SellingFurniture_type_id_1.Checked = true;
                    else
                        SellingFurniture_type_id_1.Checked = false;
                }
                if (ds.Tables[9].Rows[0]["SellingFurniture_type_id/2"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("SellingFurniture_type_id/2") == 1)
                        SellingFurniture_type_id_2.Checked = true;
                    else
                        SellingFurniture_type_id_2.Checked = false;
                }
                if (ds.Tables[9].Rows[0]["income_11"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("income_11") == 1)
                        Income11_1_RadioButton.Checked = true;
                    else if (ds.Tables[9].Rows[0].Field<int>("income_11") == 2)
                        Income11_2_RadioButton.Checked = true;
                    else
                        Income11_3_RadioButton.Checked = true;
                }
                #endregion
                #region // Electrical Devices
                if (ds.Tables[9].Rows[0]["electricaldevices_1"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("electricaldevices_1") == 0)
                    {
                        ElectricalDevicesNonExist1.Checked = true;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("electricaldevices_1") == 1)
                    {
                        ElectricalDevicesExist1.Checked = true;
                    }
                    else
                    {
                        ElectricalDevicesFail1.Checked = true;
                    }
                }
                if (ds.Tables[9].Rows[0]["electricaldevices_2"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("electricaldevices_2") == 0)
                    {
                        ElectricalDevicesNonExist2.Checked = true;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("electricaldevices_2") == 1)
                    {
                        ElectricalDevicesExist2.Checked = true;
                    }
                    else
                    {
                        ElectricalDevicesFail2.Checked = true;
                    }
                }
                if (ds.Tables[9].Rows[0]["electricaldevices_3"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("electricaldevices_3") == 0)
                    {
                        ElectricalDevicesNonExist3.Checked = true;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("electricaldevices_3") == 1)
                    {
                        ElectricalDevicesExist3.Checked = true;
                    }
                    else
                    {
                        ElectricalDevicesFail3.Checked = true;
                    }
                }
                if (ds.Tables[9].Rows[0]["heating_cooling_devices/1"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("heating_cooling_devices/1") == 1)
                    {
                        HeatingCoolingDevices_1.Checked = true;
                    }
                }
                if (ds.Tables[9].Rows[0]["heating_cooling_devices/2"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("heating_cooling_devices/2") == 1)
                    {
                        HeatingCoolingDevices_2.Checked = true;
                    }
                }
                if (ds.Tables[9].Rows[0]["heating_cooling_devices/3"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("heating_cooling_devices/3") == 1)
                    {
                        HeatingCoolingDevices_3.Checked = true;
                    }
                }
                if (ds.Tables[9].Rows[0]["heating_cooling_devices/4"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("heating_cooling_devices/4") == 1)
                    {
                        HeatingCoolingDevices_4.Checked = true;
                    }
                }

                #endregion
                #region //Building Conditions
                if (ds.Tables[9].Rows[0]["buildingcondition_1"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_1") == 1)
                    {
                        BuildingConditionNotExist1.Checked = true;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_1") == 3)
                    {
                        BuildingConditionMed1.Checked = true;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_1") == 2)
                    {
                        BuildingConditionHigh1.Checked = true;
                    }
                }
                if (ds.Tables[9].Rows[0]["buildingcondition_2"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_2") == 1)
                    {
                        BuildingConditionNotExist2.Checked = true;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_2") == 3)
                    {
                        BuildingConditionMed2.Checked = true;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_2") == 2)
                    {
                        BuildingConditionHigh2.Checked = true;
                    }
                }
                if (ds.Tables[9].Rows[0]["buildingcondition_3"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_3") == 1)
                    {
                        BuildingConditionNotExist3.Checked = true;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_3") == 3)
                    {
                        BuildingConditionMed3.Checked = true;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_3") == 2)
                    {
                        BuildingConditionHigh3.Checked = true;
                    }
                }
                if (ds.Tables[9].Rows[0]["buildingcondition_5"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_5") == 4)
                    {
                        BuildingConditionNotExist5.Checked = true;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_5") == 3)
                    {
                        BuildingConditionMed5.Checked = true;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_5") == 5)
                    {
                        BuildingConditionHigh5.Checked = true;
                    }
                }
                if (ds.Tables[9].Rows[0]["buildingcondition_8"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_8") == 4)
                    {
                        BuildingConditionNotExist8.Checked = true;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_8") == 3)
                    {
                        BuildingConditionMed8.Checked = true;
                    }
                    else if (ds.Tables[9].Rows[0].Field<int>("buildingcondition_8") == 5)
                    {
                        BuildingConditionHigh8.Checked = true;
                    }
                }
                #endregion
                #region //Aid
                if (ds.Tables[9].Rows[0]["aid_amount_11"] != DBNull.Value)
                    aidamount_11_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("aid_amount_11").ToString();
                if (ds.Tables[9].Rows[0]["aidsource_11"] != DBNull.Value)
                    aidsource_11_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidsource_11");
                else aidsource_11_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["aidperiod_11"] != DBNull.Value)
                    aidperiod_11_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidperiod_11");
                else aidperiod_11_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["aid_amount_19"] != DBNull.Value)
                    aidamount_19_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("aid_amount_19").ToString();
                else aidsource_19_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["aidsource_19"] != DBNull.Value)
                    aidsource_19_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidsource_19");
                if (ds.Tables[9].Rows[0]["aidperiod_19"] != DBNull.Value)
                    aidperiod_19_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidperiod_19");
                else aidperiod_19_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["aid_amount_20"] != DBNull.Value)
                    aidamount_20_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("aid_amount_20").ToString();
                if (ds.Tables[9].Rows[0]["aidsource_20"] != DBNull.Value)
                    aidsource_20_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidsource_20");
                else aidsource_20_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["aidperiod_20"] != DBNull.Value)
                    aidperiod_20_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidperiod_20");
                else aidperiod_20_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["aid_amount_14"] != DBNull.Value)
                    aidamount_14_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("aid_amount_14").ToString();
                if (ds.Tables[9].Rows[0]["aidsource_14"] != DBNull.Value)
                    aidsource_14_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidsource_14");
                else aidsource_14_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["aidperiod_14"] != DBNull.Value)
                    aidperiod_14_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidperiod_14");
                else aidperiod_14_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["aid_amount_12"] != DBNull.Value)
                    aidamount_12_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("aid_amount_12").ToString();
                if (ds.Tables[9].Rows[0]["aidsource_12"] != DBNull.Value)
                    aidsource_12_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidsource_12");
                else aidsource_12_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["aidperiod_12"] != DBNull.Value)
                    aidperiod_12_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidperiod_12");
                else aidperiod_12_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["aid_amount_17_home"] != DBNull.Value)
                    aidamount_17_Home_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("aid_amount_17_home").ToString();
                if (ds.Tables[9].Rows[0]["aid_amount_16_home"] != DBNull.Value)
                    aidamount_16_Home_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("aid_amount_16_home").ToString();
                if (ds.Tables[9].Rows[0]["aid_note_11"] != DBNull.Value)
                    NoteAid_11_TextBox.Text = ds.Tables[9].Rows[0].Field<string>("aid_note_11");
                if (ds.Tables[9].Rows[0]["aid_note_12"] != DBNull.Value)
                    NoteAid_12_TextBox.Text = ds.Tables[9].Rows[0].Field<string>("aid_note_12");
                if (ds.Tables[9].Rows[0]["aid_note_20"] != DBNull.Value)
                    NoteAid_20_TextBox.Text = ds.Tables[9].Rows[0].Field<string>("aid_note_20");
                if (ds.Tables[9].Rows[0]["aid_note_19"] != DBNull.Value)
                    NoteAid_19_TextBox.Text = ds.Tables[9].Rows[0].Field<string>("aid_note_19");
                //if (ds.Tables[0].Rows[0]["aid_note_14"] != DBNull.Value)
                //    NoteAid_12_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("aid_note_14");
                if (ds.Tables[9].Rows[0]["aid_note_17_home"] != DBNull.Value)
                    NoteAid_17_home_TextBox.Text = ds.Tables[9].Rows[0].Field<string>("aid_note_17_home");
                if (ds.Tables[9].Rows[0]["aid_note_16_home"] != DBNull.Value)
                    NoteAid_16_home_TextBox.Text = ds.Tables[9].Rows[0].Field<string>("aid_note_16_home");

                if (ds.Tables[9].Rows[0]["aidsource_17_home"] != DBNull.Value)
                    aidsource_17_home_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidsource_17_home");
                else aidsource_17_home_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["aidsource_16_home"] != DBNull.Value)
                    aidsource_16_home_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidsource_16_home");
                else aidsource_16_home_comboBox.SelectedValue = 0;

                if (ds.Tables[9].Rows[0]["aidperiod_17_home"] != DBNull.Value)
                    aidperiod_17_home_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidperiod_17_home");
                else aidperiod_17_home_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["aidperiod_16_home"] != DBNull.Value)
                    aidperiod_16_home_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidperiod_16_home");
                else aidperiod_16_home_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["income_relation_id_12"] != DBNull.Value)
                    IncomeRelation_12_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("income_relation_id_12").ToString();
                if (ds.Tables[9].Rows[0]["income_address_12"] != DBNull.Value)
                    income_address_12_TextBox.Text = ds.Tables[9].Rows[0].Field<string>("income_address_12");
                if (ds.Tables[9].Rows[0]["aid_amount_30"] != DBNull.Value)
                    aidamount_30_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("aid_amount_30").ToString();
                if (ds.Tables[9].Rows[0]["aidperiod_30"] != DBNull.Value)
                    aidperiod_30_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("aidperiod_30").ToString();
                else aidperiod_30_comboBox.SelectedValue = 0;
                #endregion
                #region //Expenses
                if (ds.Tables[9].Rows[0]["expenses_1"] != DBNull.Value)
                    Expenses_1_comboBox.SelectedValue = ds.Tables[9].Rows[0].Field<int>("expenses_1");
                else Expenses_1_comboBox.SelectedValue = 0;
                if (ds.Tables[9].Rows[0]["expenses_amount_3"] != DBNull.Value)
                    ExpensesAmount_3_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("expenses_amount_3").ToString();
                if (ds.Tables[9].Rows[0]["expenses_amount_19"] != DBNull.Value)
                    ExpensesAmount_19_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("expenses_amount_19").ToString();
                if (ds.Tables[9].Rows[0]["expenses_amount_20"] != DBNull.Value)
                    ExpensesAmount_20_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("expenses_amount_20").ToString();
                if (ds.Tables[9].Rows[0]["expenses_amount_11"] != DBNull.Value)
                    ExpensesAmount_11_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("expenses_amount_11").ToString();
                if (ds.Tables[9].Rows[0]["expenses_amount_21"] != DBNull.Value)
                    ExpensesAmount_21_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("expenses_amount_21").ToString();
                if (ds.Tables[9].Rows[0]["expenses_amount_22"] != DBNull.Value)
                    ExpensesAmount_22_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("expenses_amount_22").ToString();
                if (ds.Tables[9].Rows[0]["expenses_amount_2_home"] != DBNull.Value)
                    ExpensesAmount_2_Home_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("expenses_amount_2_home").ToString();
                if (ds.Tables[9].Rows[0]["expenses_10"] != DBNull.Value)
                    Expenses_10_TextBox.Text = ds.Tables[9].Rows[0].Field<string>("expenses_10");
                if (ds.Tables[9].Rows[0]["expenses_amount_10"] != DBNull.Value)
                    ExpensesAmount_10_TextBox.Text = ds.Tables[9].Rows[0].Field<int>("expenses_amount_10").ToString();
                #endregion
                getFamilyStatistics();

            }
            if (ds.Tables[1].Rows.Count != 0)
            {
                if (ds.Tables[1].Rows[0]["Receiver_Name"] != DBNull.Value)
                    Receiver_TextBox.Text = string.IsNullOrWhiteSpace(ds.Tables[1].Rows[0].Field<string>("Receiver_Name")) ? "لم يتم تحديد المستلم بعد" : ds.Tables[1].Rows[0].Field<string>("Receiver_Name");
            }

            if (ds.Tables[0].Rows[0]["parish_id"] != DBNull.Value)
                Parish_ComboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("parish_id");
            if (ds.Tables[0].Rows[0]["landline"] != DBNull.Value)
                LandLine_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("landline").ToString();
            if (ds.Tables[0].Rows[0]["mobile"] != DBNull.Value)
                MobileNumber_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("mobile");
            if (ds.Tables[0].Rows[0]["street_id"] != DBNull.Value)
                Street_ComboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("street_id");

            //LivingWith
            if (ds.Tables[11].Rows.Count != 0)
            {
                Yes_RadioButton.Checked = true;
                No_RadioButton.Checked = false;

                for (int i = 0; i < ds.Tables[11].Rows.Count; i++)
                {
                    LivingWith_DataGridView.Rows.Add();
                    if (ds.Tables[11].Rows[i]["id"] != DBNull.Value)
                        LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_ID"].Value = ds.Tables[11].Rows[i].Field<int>("id");
                    
                    if (ds.Tables[11].Rows[0]["المستلم"] != DBNull.Value)
                        LivingWith_DataGridView.Rows[i].Cells["family_Headofhousehold"].Value = ds.Tables[11].Rows[i].Field<string>("المستلم");
                    
                    if (ds.Tables[11].Rows[i]["note"] != DBNull.Value)
                        LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Note"].Value = ds.Tables[11].Rows[i].Field<string>("note");
                    if (ds.Tables[11].Rows[i]["family_id"] != DBNull.Value)
                        LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_Code"].Value = ds.Tables[11].Rows[i].Field<int>("family_id");
                    if (LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_ID"].Value != null)
                    {
                        LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_Code"].ReadOnly = true;
                    }
                }
            }
            else
            {
                Yes_RadioButton.Checked = false;
                No_RadioButton.Checked = true;
            }

            if (ds.Tables[9].Rows.Count != 0)
            {
                //Assets
                if (ds.Tables[9].Rows[0]["isAsset"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0]["isAsset"].ToString() == "1") isAsset_yes_RadioButton.Checked = true;
                    else isAsset_no_RadioButton.Checked = true;
                }
                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    Asset_DataGridView.Rows.Add();
                    Asset_DataGridView.Columns[0].ReadOnly = true;
                    if (ds.Tables[2].Rows[i]["asset_id"] != DBNull.Value)
                        Asset_DataGridView.Rows[i].Cells["Asset"].Value = ds.Tables[2].Rows[i].Field<int>("asset_id");
                    if (ds.Tables[2].Rows[i]["visit_name"] != DBNull.Value)
                        Asset_DataGridView.Rows[i].Cells["Asset_VisitName"].Value = ds.Tables[2].Rows[i].Field<string>("visit_name");
                    if (ds.Tables[2].Rows[i]["hometype_id_asset"] != DBNull.Value)
                        Asset_DataGridView.Rows[i].Cells["AssetHometype"].Value = ds.Tables[2].Rows[i].Field<int>("hometype_id_asset");
                    if (ds.Tables[2].Rows[i]["asset_address"] != DBNull.Value)
                        Asset_DataGridView.Rows[i].Cells["AssetAddress"].Value = ds.Tables[2].Rows[i].Field<string>("asset_address");
                    if (ds.Tables[2].Rows[i]["income_4"] != DBNull.Value)
                        Asset_DataGridView.Rows[i].Cells["Income_4"].Value = ds.Tables[2].Rows[i].Field<int>("income_4");
                    if (ds.Tables[2].Rows[i]["expenses_amount_6_asset"] != DBNull.Value)
                        Asset_DataGridView.Rows[i].Cells["expenses_amount_6_asset"].Value = ds.Tables[2].Rows[i].Field<int>("expenses_amount_6_asset");
                    if (ds.Tables[2].Rows[i]["expenses_amount_12_asset"] != DBNull.Value)
                        Asset_DataGridView.Rows[i].Cells["expenses_amount_12_asset"].Value = ds.Tables[2].Rows[i].Field<int>("expenses_amount_12_asset");
                    if (ds.Tables[2].Rows[i]["asset_heirs_number"] != DBNull.Value)
                        Asset_DataGridView.Rows[i].Cells["AssetHeirsNumber"].Value = ds.Tables[2].Rows[i].Field<int>("asset_heirs_number");
                    if (ds.Tables[2].Rows[i]["isLoss_note"] != DBNull.Value)
                        Asset_DataGridView.Rows[i].Cells["LossNote"].Value = ds.Tables[2].Rows[i].Field<string>("isLoss_note");
                    if (ds.Tables[2].Rows[i]["id"] != DBNull.Value)
                        Asset_DataGridView.Rows[i].Cells["Family_Asset_ID"].Value = ds.Tables[2].Rows[i].Field<int>("id");

                    if (!Asset_DataGridView.Rows[i].Cells["Asset_VisitName"].Value.Equals(VisitNameLabel.Text))
                    {
                        Asset_DataGridView.Rows[i].ReadOnly = true;
                    }
                    //Asset_DataGridView.Rows[i].Cells["A_Number"].Value = ds.Tables[6].Rows[i].Field<int>("A_Number");
                    //Asset_DataGridView.Rows[i].Cells["AssetNote"].Value = ds.Tables[2].Rows[i].Field<string>("note");
                }

                //Car Assets
                if (ds.Tables[9].Rows[0]["asset_3"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0]["asset_3"].ToString() == "1") asset_3_yes_RadioButton.Checked = true;
                    else asset_3_no_RadioButton.Checked = true;
                }
                for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                {
                    CarAsset_DataGridView.Rows.Add();
                    CarAsset_DataGridView.Columns[0].ReadOnly = true;
                    if (ds.Tables[3].Rows[i]["visit_name"] != DBNull.Value)
                        CarAsset_DataGridView.Rows[i].Cells["CarAsset_VisitName"].Value = ds.Tables[3].Rows[i].Field<string>("visit_name");
                    if (ds.Tables[3].Rows[i]["asset_hometype_id"] != DBNull.Value)
                        CarAsset_DataGridView.Rows[i].Cells["AssetHometypeCar_ComboBox"].Value = ds.Tables[3].Rows[i].Field<int>("asset_hometype_id");
                    if (ds.Tables[3].Rows[i]["asset_release"] != DBNull.Value)
                        CarAsset_DataGridView.Rows[i].Cells["AssetRelease"].Value = ds.Tables[3].Rows[i].Field<int>("asset_release");
                    if (ds.Tables[3].Rows[i]["asset_note"] != DBNull.Value)
                        CarAsset_DataGridView.Rows[i].Cells["AssetNoteCar"].Value = ds.Tables[3].Rows[i].Field<string>("asset_note");
                    if (ds.Tables[3].Rows[i]["asset_type"] != DBNull.Value)
                        CarAsset_DataGridView.Rows[i].Cells["AssetTypeCar_ComboBox"].Value = ds.Tables[3].Rows[i].Field<int>("asset_type");
                    if (ds.Tables[3].Rows[i]["expensestype_18"] != DBNull.Value)
                        CarAsset_DataGridView.Rows[i].Cells["Expensestype_18_ComboBox"].Value = ds.Tables[3].Rows[i].Field<int>("expensestype_18");
                    if (ds.Tables[3].Rows[i]["expenses_amount_18"] != DBNull.Value)
                        CarAsset_DataGridView.Rows[i].Cells["ExpensesAmount_18"].Value = ds.Tables[3].Rows[i].Field<int>("expenses_amount_18");
                    if (ds.Tables[3].Rows[i]["loss_note_4"] != DBNull.Value)
                        CarAsset_DataGridView.Rows[i].Cells["LossNoteCar"].Value = ds.Tables[3].Rows[i].Field<string>("loss_note_4");
                    if (ds.Tables[3].Rows[i]["id"] != DBNull.Value)
                        CarAsset_DataGridView.Rows[i].Cells["Family_CarAsset_ID"].Value = ds.Tables[3].Rows[i].Field<int>("id");
                    if (!CarAsset_DataGridView.Rows[i].Cells["CarAsset_VisitName"].Value.Equals(VisitNameLabel.Text))
                    {
                        CarAsset_DataGridView.Rows[i].ReadOnly = true;
                    }
                }

                //Income
                if (ds.Tables[9].Rows[0]["hasincome"] != DBNull.Value)
                {
                    if (ds.Tables[9].Rows[0]["hasincome"].ToString() == "1") hasincome_yes_RadioButton.Checked = true;
                    else hasincome_no_RadioButton.Checked = true;
                }
                int total_income = 0;
                for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                {
                    Income_DataGridView.Rows.Add();
                    Income_DataGridView.Columns[0].ReadOnly = true;
                    if (ds.Tables[4].Rows[i]["visit_name"] != DBNull.Value)
                        Income_DataGridView.Rows[i].Cells["Income_VisitName"].Value = ds.Tables[4].Rows[i].Field<string>("visit_name");
                    if (ds.Tables[4].Rows[i]["income_id"] != DBNull.Value)
                        Income_DataGridView.Rows[i].Cells["Income"].Value = ds.Tables[4].Rows[i].Field<int>("income_id");
                    if (ds.Tables[4].Rows[i]["Income_Amount"] != DBNull.Value)
                        Income_DataGridView.Rows[i].Cells["Income_Amount"].Value = ds.Tables[4].Rows[i].Field<int>("income_amount");
                    if (ds.Tables[4].Rows[i]["income_note"] != DBNull.Value)
                        Income_DataGridView.Rows[i].Cells["IncomeNote"].Value = ds.Tables[4].Rows[i].Field<string>("income_note");
                    Income_DataGridView.Rows[i].Cells["Family_Income_ID"].Value = ds.Tables[4].Rows[i].Field<int>("id");
                    total_income += int.Parse(Income_DataGridView.Rows[i].Cells["Income_Amount"].Value.ToString());

                    if (!Income_DataGridView.Rows[i].Cells["Income_VisitName"].Value.Equals(VisitNameLabel.Text))
                    {
                        Income_DataGridView.Rows[i].ReadOnly = true;
                    }
                }
                if (total_income == 0)
                {
                    totalIncomeLabel.Text = "0";
                }
                else totalIncomeLabel.Text = total_income.ToString();
            }


            if (ds.Tables[0].Rows[0]["Approved"] != DBNull.Value)
            {
                Approved_RadioButton.Checked = ds.Tables[0].Rows[0].Field<int>("Approved") == 1 ? true : false;

                if (ds.Tables[0].Rows[0].Field<int>("Approved") == 1)
                {
                    Approved_RadioButton.Checked = true;

                    ApprovalDate_TextBox.Visible = ApprovalDate_Label.Visible = ApprovedBy_TextBox.Visible = true;

                    ApprovedBy_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("approvedby");


                    if (ds.Tables[0].Rows[0]["approvaldate"] != DBNull.Value)
                        ApprovalDate_TextBox.Text = ds.Tables[0].Rows[0].Field<DateTime>("approvaldate").ToShortDateString();
                    else
                        ApprovalDate_TextBox.Text = "";
                }
                else
                {
                    Approved_RadioButton.Checked = false;

                    ApprovalDate_TextBox.Visible = ApprovalDate_Label.Visible = ApprovedBy_TextBox.Visible = false;

                    ApprovalDate_TextBox.Text = null;
                    ApprovedBy_TextBox.Text = "";
                }
            }

            if (ds.Tables[0].Rows[0]["PDM"] != DBNull.Value)
            {
                if (ds.Tables[0].Rows[0].Field<int>("PDM") == 1)
                {
                    PDM_RadioButton.Checked = true;
                    PDMBy_TextBox.Visible = PdmDate_Label.Visible = PDMDate_TextBox.Visible = true;

                    PDMBy_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("pdmby");

                    if (ds.Tables[0].Rows[0]["pdmdate"] != DBNull.Value)
                        PDMDate_TextBox.Text = ds.Tables[0].Rows[0].Field<DateTime>("pdmdate").ToShortDateString();
                    else
                        PDMDate_TextBox.Text = "";
                }
                else
                {
                    PDM_RadioButton.Checked = false;

                    PDMBy_TextBox.Visible = PdmDate_Label.Visible = PDMDate_TextBox.Visible = false;
                    PDMBy_TextBox.Text = PDMDate_TextBox.Text = "";
                }
            }

            if (ds.Tables[0].Rows[0]["PVM"] != DBNull.Value)
            {
                if (ds.Tables[0].Rows[0].Field<int>("PVM") == 1)
                {
                    PVM_RadioButton.Checked = true;

                    PVMBy_TextBox.Visible = PvmDate_Label.Visible = PVMDate_TextBox.Visible = true;

                    PVMBy_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("pvmby");

                    if (ds.Tables[0].Rows[0]["pvmdate"] != DBNull.Value)
                        PVMDate_TextBox.Text = ds.Tables[0].Rows[0].Field<DateTime>("pvmdate").ToShortDateString();
                    else
                        PVMDate_TextBox.Text = "";
                }
                else
                {
                    PVM_RadioButton.Checked = false;

                    PVMBy_TextBox.Visible = PvmDate_Label.Visible = PVMDate_TextBox.Visible = false;

                    PVMBy_TextBox.Text = PVMDate_TextBox.Text = "";
                }
            }

            if (ds.Tables[0].Rows[0]["Complaint"] != DBNull.Value)
            {
                if (ds.Tables[0].Rows[0].Field<int>("Complaint") == 1)
                {
                    Complaint_RadioButton.Checked = true;

                    ComplaintBy_TextBox.Visible = ComplaintDate_Label.Visible = ComplaintDate_TextBox.Visible = true;

                    ComplaintBy_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("complaintby");

                    if (ds.Tables[0].Rows[0]["complaintdate"] != DBNull.Value)
                        ComplaintDate_TextBox.Text = ds.Tables[0].Rows[0].Field<DateTime>("complaintdate").ToShortDateString();
                    else
                        ComplaintDate_TextBox.Text = "";
                }
                else
                {
                    Complaint_RadioButton.Checked = false;

                    ComplaintBy_TextBox.Visible = ComplaintDate_Label.Visible = ComplaintDate_TextBox.Visible = false;

                    ComplaintBy_TextBox.Text = ComplaintDate_TextBox.Text = "";
                }
            }

            if (ds.Tables[0].Rows[0]["Note"] != DBNull.Value)
                Note_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("Note");
            if (ds.Tables[0].Rows[0]["partnernote"] != DBNull.Value)
                PartnerNote_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("partnernote");
            if (ds.Tables[0].Rows[0]["complaintnote"] != DBNull.Value)
                ComplaintNote_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("complaintnote");
            if (ds.Tables[0].Rows[0]["evaluationnote"] != DBNull.Value)
                EvaluationNote_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("evaluationnote");

            //foreach (RadioButton RB in FamilyVisitState_LayoutPanel.Controls.OfType<RadioButton>())
            //{
            //    if (RB.Text == ds.Tables[0].Rows[0].Field<string>("VisitState"))
            //    {
            //        RB.Checked = true;
            //        break;
            //    }
            //}
            //if (ds.Tables[0].Rows[0].Field<string>("VisitState") == "لن يزار" || ds.Tables[0].Rows[0].Field<string>("VisitState") == "رفض")
            //{
            //    WillNotReason_Label.Visible = WillNotReason_TextBox.Visible = true;
            //    WillNotReason_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("Visist_WillNot_Reason");
            //}
            //else if (ds.Tables[0].Rows[0].Field<string>("VisitState") == "مزار")
            //{
            //   Done_RadioButton.Visible = true;
            //}
            //CurrentFamilyVisitState = ds.Tables[0].Rows[0].Field<string>("VisitState");
            //if (ds.Tables[0].Rows[0]["living_with_family_id"] != DBNull.Value)
            //    LivingWithCode_ComboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("living_with_family_id");
            //if (ds.Tables[0].Rows[0]["living_with_family_note"] != DBNull.Value)
            //    LivingWithNote_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("living_with_family_note");
            //if (ds.Tables[0].Rows[0]["living_with_family2_id"] != DBNull.Value)
            //    LivingWithCode2_ComboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("living_with_family2_id");
            //if (ds.Tables[0].Rows[0]["living_with_family2_note"] != DBNull.Value)
            //    LivingWithNote2_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("living_with_family2_note");
            //if (ds.Tables[0].Rows[0]["LivingWithFamily"] != DBNull.Value)
            //{
            //    if (ds.Tables[0].Rows[0].Field<int>("LivingWithFamily") == 1)
            //    {
            //        Yes_RadioButton.Checked = true;
            //        LivingWith_DataGridView.ReadOnly = false;
            //        //LivingWith_Label.Visible = LivingWithCode_ComboBox.Visible = pictureBox2.Visible = GoToFamily_Button.Visible = LivingWithNote_Label.Visible = LivingWithNote_TextBox.Visible = true;
            //        //LivingWith2_Label.Visible = LivingWithCode2_ComboBox.Visible = pictureBox1.Visible = GoToFamily2_Button.Visible = LivingWithNote2_Label.Visible = LivingWithNote2_TextBox.Visible = true;

            //    }
            //    else
            //    {
            //        No_RadioButton.Checked = true;
            //        LivingWith_DataGridView.ReadOnly = true;
            //        LivingWith_DataGridView.Rows.Clear();

            //        //LivingWith_Label.Visible = LivingWithCode_ComboBox.Visible = pictureBox2.Visible = GoToFamily_Button.Visible = LivingWithNote_Label.Visible = LivingWithNote_TextBox.Visible = false;
            //        //LivingWith2_Label.Visible = LivingWithCode2_ComboBox.Visible = pictureBox1.Visible = GoToFamily2_Button.Visible = LivingWithNote2_Label.Visible = LivingWithNote2_TextBox.Visible = false;
            //    }
            //    //if (LivingWithNote_TextBox.Text == "" && LivingWithCode2_ComboBox.SelectedIndex == -1)
            //    //{
            //    //    LivingWithNote2_TextBox.Visible = LivingWithNote2_Label.Visible = LivingWith2_Label.Visible = LivingWithCode2_ComboBox.Visible = pictureBox1.Visible = GoToFamily2_Button.Visible = false;
            //    //}
            //    //else
            //    //{
            //    //    LivingWithNote2_TextBox.Visible = LivingWithNote2_Label.Visible = LivingWith2_Label.Visible = LivingWithCode2_ComboBox.Visible = pictureBox1.Visible = GoToFamily2_Button.Visible = true;
            //    //}
            //}

            if (ds.Tables[0].Rows[0]["InEvaluation"] != DBNull.Value)
            {
                InEvaluation_RadioButton.Checked = ds.Tables[0].Rows[0].Field<int>("InEvaluation") == 1 ? true : false;
                if (InEvaluation_RadioButton.Checked)
                {
                    InEvaluationBy_TextBox.Visible = InEvaluationLable.Visible = EvaluationDate_TextBox.Visible = true;
                    InEvaluationBy_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("InEvaluationBy");
                    if (ds.Tables[0].Rows[0]["evaluationdate"] != DBNull.Value)
                        EvaluationDate_TextBox.Text = ds.Tables[0].Rows[0].Field<DateTime>("evaluationdate").ToShortDateString();
                    else
                        EvaluationDate_TextBox.Text = "";
                }
                else
                {
                    InEvaluationBy_TextBox.Visible = InEvaluationLable.Visible = EvaluationDate_TextBox.Visible = false;
                }
            }

            //if (ds.Tables[0].Rows[0].Field<int>("InEvaluation") == 1 && ds.Tables[0].Rows[0].Field<Int64>("NumberOfBeneficiaries") != 0)
            //{
            //    this.Marks_TabPage.Parent = materialTabControl1;

            //}
            //else
            //{
            //    this.Marks_TabPage.Parent = null;
            //}

            //Partner_DataGridView.Rows.Clear(); Income_DataGridView.Rows.Clear(); Aid_DataGridView.Rows.Clear(); Loss_DataGridView.Rows.Clear(); Asset_DataGridView.Rows.Clear(); LivingCondition_DataGridView.Rows.Clear(); Expenses_DataGridView.Rows.Clear();
            
            Partner_DataGridView.Rows.Clear();
            for (int i = 0; i < ds.Tables[5].Rows.Count; i++)
            {
                Partner_DataGridView.Rows.Add();
                Partner_DataGridView.Rows[i].Cells["Donor_ID"].Value = ds.Tables[5].Rows[i].Field<int>("donor_id");
                Partner_DataGridView.Rows[i].Cells["Partner_ID"].Value = ds.Tables[5].Rows[i].Field<int>("partner_id");
                Partner_DataGridView.Rows[i].Cells["Family_State"].Value = ds.Tables[5].Rows[i].Field<int>("IsActive") == 1 ? "فعالة" : "غير فعالة";
                Partner_DataGridView.Rows[i].Cells["Family_Partner_ID"].Value = ds.Tables[5].Rows[i].Field<int>("id");
            }

            //for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
            //{
            //    Aid_DataGridView.Rows.Add();
            //    Aid_DataGridView.Rows[i].Cells["Aid"].Value = ds.Tables[3].Rows[i].Field<int>("aid_id");
            //    Aid_DataGridView.Rows[i].Cells["Aid_Source"].Value = ds.Tables[3].Rows[i].Field<int>("aidsource_id");
            //    Aid_DataGridView.Rows[i].Cells["Aid_Period"].Value = ds.Tables[3].Rows[i].Field<int>("aidperid_id");
            //    Aid_DataGridView.Rows[i].Cells["Aid_Amount"].Value = ds.Tables[3].Rows[i].Field<decimal>("amount");
            //    Aid_DataGridView.Rows[i].Cells["AidNote"].Value = ds.Tables[3].Rows[i].Field<string>("note");
            //    Aid_DataGridView.Rows[i].Cells["Family_Aid_ID"].Value = ds.Tables[3].Rows[i].Field<int>("id");
            //}

            //string[] power = { "أمبير", "طاقة شمسية", "بطارية", "مولدة", "كهرباء" };
            //PowerExpenses_DataGridView.Columns["PowerName"].ReadOnly = true;
            //for (int j = 0; j < power.Length-1; j++)
            //{
            //    PowerExpenses_DataGridView.Rows.Add();
            //    PowerExpenses_DataGridView.Rows[j].Cells[0].Value = power[j];
            //}

            //string[] expenses = { "حيوانات أليفة", "دخان", "مواصلات", "المنظفات", "فواتير المياه", "فواتير الهاتف" };
            //Expenses_DataGridView.Columns["Expenses"].ReadOnly = true;
            //Expenses_DataGridView.Columns["Expenses_Type"].ReadOnly = true;

            //for (int j = 0; j < 5; j++)
            //{
            //    Expenses_DataGridView.Rows.Add();
            //    Expenses_DataGridView.Rows[j].Cells[0].Value = expenses[j];
            //}


            //for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
            //{
            //    Expenses_DataGridView.Rows.Add();
            //    Expenses_DataGridView.Rows[i].Cells["Expenses"].Value = ds.Tables[4].Rows[i].Field<int>("expenses_id");
            //    Expenses_DataGridView.Rows[i].Cells["Expenses_Type"].Value = ds.Tables[4].Rows[i].Field<int>("expensestype_id");
            //    Expenses_DataGridView.Rows[i].Cells["Expenses_Amount"].Value = ds.Tables[4].Rows[i].Field<decimal>("amount");
            //    Expenses_DataGridView.Rows[i].Cells["ExpensesNote"].Value = ds.Tables[4].Rows[i].Field<string>("note");
            //    Expenses_DataGridView.Rows[i].Cells["Family_Expenses_ID"].Value = ds.Tables[4].Rows[i].Field<int>("id");
            //}

            //for (int i = 0; i < ds.Tables[5].Rows.Count; i++)
            //{
            //    Loss_DataGridView.Rows.Add();
            //    Loss_DataGridView.Rows[i].Cells["Loss"].Value = ds.Tables[5].Rows[i].Field<int>("loss_id");
            //    Loss_DataGridView.Rows[i].Cells["L_Number"].Value = ds.Tables[5].Rows[i].Field<int>("L_Number");
            //    Loss_DataGridView.Rows[i].Cells["LossNote"].Value = ds.Tables[5].Rows[i].Field<string>("note");
            //    Loss_DataGridView.Rows[i].Cells["Family_Loss_ID"].Value = ds.Tables[5].Rows[i].Field<int>("id");
            //}



            //for (int i = 0; i < ds.Tables[7].Rows.Count; i++)
            //{
            //    LivingCondition_DataGridView.Rows.Add();
            //    LivingCondition_DataGridView.Rows[i].Cells["LivingCondition"].Value = ds.Tables[7].Rows[i].Field<int>("buildingcondition_id");
            //    LivingCondition_DataGridView.Rows[i].Cells["BuildingConditionNote"].Value = ds.Tables[7].Rows[i].Field<string>("note");
            //    LivingCondition_DataGridView.Rows[i].Cells["Family_BuildingCondition_ID"].Value = ds.Tables[7].Rows[i].Field<int>("id");
            //}

            //if (ds.Tables[8].Rows.Count > 0)
            //{
            //    if (ds.Tables[8].Rows[0].Field<int>("electricaldavices_id") == 0)
            //    {
            //        ElectricalDevices_1.Checked = true;
            //    }
            //    else
            //    {
            //        for (int i = 0; i < ds.Tables[8].Rows.Count; i++)
            //        {
            //            string value = ds.Tables[8].Rows[i].Field<string>("name");
            //            int index = ElectricalDevices_CheckedListBox.FindString(value);
            //            ElectricalDevices_CheckedListBox.SetItemChecked(index, true);
            //        }
            //    }
            //}
            UserMode = true;
        }

        private void DistributionHistory_Button_MouseEnter(object sender, EventArgs e)
        {
            DistributionHistory_Button.BackgroundImage = F2F_Application.Properties.Resources.button2_1;

        }

        private void DistributionHistory_Button_MouseLeave(object sender, EventArgs e)
        {
            DistributionHistory_Button.BackgroundImage = F2F_Application.Properties.Resources.button2;

        }

        private void Delete_Button_MouseEnter(object sender, EventArgs e)
        {
            Delete_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Delete_Button_MouseLeave(object sender, EventArgs e)
        {
            Delete_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        //private void Save_Button_MouseEnter(object sender, EventArgs e)
        //{
        //    Save_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1; 
        //}
        //private void Save_Button_MouseLeave(object sender, EventArgs e)
        //{
        //    Save_Button.BackgroundImage = F2F_Application.Properties.Resources.button1; 
        //}

        private void Update_Button_MouseEnter(object sender, EventArgs e)
        {
            Update_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Update_Button_MouseLeave(object sender, EventArgs e)
        {
            Update_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        #region KeyPress
        private void LandLine_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void MobileNumber_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void MyDataGridViewInitializationMethod()
        {
            //PowerExpenses_DataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(PowerExpenses_DataGridView_EditingControlShowing);
            //Loss_DataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Loss_DataGridView_EditingControlShowing);
            Asset_DataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Asset_DataGridView_EditingControlShowing);
            //Expenses_DataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Expenses_DataGridView_EditingControlShowing);
            Income_DataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Income_DataGridView_EditingControlShowing);
            //Aid_DataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Aid_DataGridView_EditingControlShowing);
        }

        private void Loss_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Loss_DataGridView_Control_KeyPress);
        }

        private void Asset_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Asset_DataGridView_Control_KeyPress);
        }

        private void Expenses_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Expenses_DataGridView_Control_KeyPress);
        }

        private void Income_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Income_DataGridView_Control_KeyPress);
        }

        private void Aid_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Aid_DataGridView_Control_KeyPress);
        }

        private void Loss_DataGridView_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && Loss_DataGridView.CurrentCellAddress.X == 1)
            //{
            //    e.Handled = true;
            //}
        }

        private void Asset_DataGridView_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && Asset_DataGridView.CurrentCellAddress.X == 1)
            {
                e.Handled = true;
            }
        }

        private void Expenses_DataGridView_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && Expenses_DataGridView.CurrentCellAddress.X == 2)
            //{
            //    e.Handled = true;
            //}
        }

        private void Income_DataGridView_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && Income_DataGridView.CurrentCellAddress.X == 1)
            {
                e.Handled = true;
            }
        }

        private void Aid_DataGridView_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && Aid_DataGridView.CurrentCellAddress.X == 2)
            //{
            //    e.Handled = true;
            //}
        }

        #endregion

        private void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                ComboBox cb = (ComboBox)e.Control;
                cb.DrawMode = DrawMode.OwnerDrawVariable;
                cb.DrawItem -= ComboBox_DrawItem;
                cb.DrawItem += ComboBox_DrawItem;

                cb.DropDownStyle = ComboBoxStyle.DropDown;
                cb.AutoCompleteMode = AutoCompleteMode.Suggest;
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



        // --------------Members_TabPage--------------

        private void Members_TabPage_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Family_ID == -1)
            //    {
            //        MessageBox.Show("الرجاء إدخال وحفظ معلومات العائلة أولاً", "Error");
            //        materialTabControl1.SelectedTab = Family_TabPage;
            //        return;
            //    }

            //    materialTabControl1.Size = new Size(this.Width - 20, 950);

            //    Bind_Members();
            //    Check_User_Role_Members();
            //}

            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //    MessageBox.Show("لن يتم هذه الصفحة بسبب الخطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
            //    this.Close();
            //}
        }

        private void Check_User_Role_Members()
        {
            if (Properties.Settings.Default.Role == "Viewer")
            {
                Beneficiaries_DataGridView.Columns["Beneficiaries_MovePerson"].Visible = false;
                //NonBeneficiaries_DataGridView.Columns["NonBeneficiaries_MovePerson"].Visible = false;
            }
        }

        public void Bind_Members()
        {
            DataSet ds = f.Get_Family_Members(Family_ID);

            NumberOfBeneficiaries_TextBox1.Text = ds.Tables[0].Rows[0].Field<Int64>("NumberOfBeneficiaries").ToString();
            NumberOfWorkers_TextBox1.Text = ds.Tables[0].Rows[0].Field<Int64>("NumberOfWorkers").ToString();
            NumberOfStudents_TextBox1.Text = ds.Tables[0].Rows[0].Field<Int64>("NumberOfStudents").ToString();
            NumberOfOld_TextBox1.Text = ds.Tables[0].Rows[0].Field<Int64>("NumberOfOld").ToString();
            NumberOfPatient_TextBox1.Text = ds.Tables[0].Rows[0].Field<Int64>("NumberOfPatient").ToString();

            Beneficiaries_DataGridView.ColumnHeadersVisible = false;
            Beneficiaries_DataGridView.DataSource = null;
            Beneficiaries_DataGridView.Columns.Clear();
            Beneficiaries_DataGridView.DataSource = ds.Tables[1];
            Beneficiaries_DataGridView.ColumnHeadersVisible = true;

            Beneficiaries_DataGridView.Columns["Person ID"].Visible = false;


            //NonBeneficiaries_DataGridView.ColumnHeadersVisible = false;
            //NonBeneficiaries_DataGridView.DataSource = null;
            //NonBeneficiaries_DataGridView.Columns.Clear();
            //NonBeneficiaries_DataGridView.DataSource = ds.Tables[2];
            //NonBeneficiaries_DataGridView.ColumnHeadersVisible = true;

            //NonBeneficiaries_DataGridView.Columns["Person ID"].Visible = false;

            Add_GridView_Buttons();

            Bind_Show_Hide_ToolStrip();

        }

        private void Add_GridView_Buttons()
        {
            DataGridViewButtonColumn button1 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn button2 = new DataGridViewButtonColumn();

            button1.Name = "MovePerson";
            button1.HeaderText = "نقل الشخص";
            //button.Text = "Button";
            button1.UseColumnTextForButtonValue = true; //dont forget this line
            button1.FlatStyle = FlatStyle.Flat;

            button2.Name = "MovePerson";
            button2.HeaderText = "نقل الشخص";
            //button.Text = "Button";
            button2.UseColumnTextForButtonValue = true; //dont forget this line
            button2.FlatStyle = FlatStyle.Flat;

            this.Beneficiaries_DataGridView.Columns.Add(button1);
            //this.NonBeneficiaries_DataGridView.Columns.Add(button2);

        }

        private void EvaluationNote_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                EvaluationNote_TextBox_OriginalText = EvaluationDate_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void EvaluationNote_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (EvaluationNote_TextBox_OriginalText != EvaluationDate_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NumberOfAllMembers_TextBox_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    NumberOfAllMembers_TextBox_OriginalText = NumberOfAllMembers_TextBox.Text;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void NumberOfAllMembers_TextBox_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (NumberOfAllMembers_TextBox_OriginalText != NumberOfAllMembers_TextBox.Text)
            //        General_Information_IsDirty = true;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void LandLine_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (LandLine_TextBox_OriginalText != LandLine_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LocationLongtitude_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                LocationLatitude_TextBox_OriginalText = LocationLatitude_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LocationLongtitude_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (LocationLongtitude_TextBox_OriginalText != LocationLongtitude_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LocationLatitude_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                LocationLatitude_TextBox_OriginalText = LocationLatitude_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingNumber_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                BuildingNumber_TextBox_OriginalText = BuildingNumber_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingNumber_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (BuildingNumber_TextBox_OriginalText != BuildingNumber_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Floor_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                Floor_TextBox_OriginalText = Floor_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void Floor_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Floor_TextBox_OriginalText != Floor_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void RoomsNumber_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                RoomsNumber_TextBox_OriginalText = RoomsNumber_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void RoomsNumber_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (RoomsNumber_TextBox_OriginalText != RoomsNumber_TextBox.Text)
                    LivingCondition_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LivingWithCode_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    General_Information_IsDirty = true;
                    //LivingWithNote2_TextBox.Visible = LivingWithNote2_Label.Visible = LivingWith2_Label.Visible = LivingWithCode2_ComboBox.Visible = pictureBox1.Visible = GoToFamily2_Button.Visible = true;
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LivingWithCode2_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LivingWithNote2_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                //LivingWithNote2_TextBox_OriginalText = LivingWithNote2_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LivingWithNote2_TextBox_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    LivingWithNote2_TextBox_OriginalText = LivingWithNote2_TextBox.Text;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void expenses_amount_6_12_home_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                expenses_amount_6_12_home_TextBox_OriginalText = expenses_amount_6_12_home_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void expenses_amount_6_12_home_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expenses_amount_6_12_home_TextBox_OriginalText != expenses_amount_6_12_home_TextBox.Text)
                    LivingCondition_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void expensestype_6_12_home_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LivingCondition_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void home_description_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (home_description_TextBox_OriginalText != home_description_TextBox.Text)
                    LivingCondition_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ParishHome_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LivingCondition_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void HeirsNumber_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                HeirsNumber_TextBox_OriginalText = HeirsNumber_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void HeirsNumber_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (HeirsNumber_TextBox_OriginalText != HeirsNumber_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_5_3_home_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LivingCondition_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_5_3_home_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aidamount_5_3_home_TextBox_OriginalText = aidamount_5_3_home_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_5_3_home_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aidamount_5_3_home_TextBox_OriginalText != aidamount_5_3_home_TextBox.Text)
                    LivingCondition_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_5_3_home_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LivingCondition_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ElectricalDevicesExist1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (ElectricalDevicesExist1.Checked)
                    {
                        Electrical_Devices_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
            //bool ElectricalDevicesExist1_RadioButton_OriginalState = ElectricalDevicesExist1.Checked;
            //try
            //{
            //    ElectricalDevicesExist1.Checked = !ElectricalDevicesExist1.Checked;

            //    if (UserMode)
            //    {
            //        //int ed1 = ElectricalDevicesExist1.Checked == true ? 1 : 0;
            //        Electrical_Devices_IsDirty = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ElectricalDevicesExist1.Checked = ElectricalDevicesExist1_RadioButton_OriginalState;
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void ElectricalDevicesNonExist1_CheckedChanged(object sender, EventArgs e)
        {
            //bool ElectricalDevicesNonExist1_RadioButton_OriginalState = ElectricalDevicesNonExist1.Checked;
            //try
            //{
            //    ElectricalDevicesNonExist1.Checked = !ElectricalDevicesNonExist1.Checked;

            //    if (UserMode)
            //    {
            //        //int ed1 = ElectricalDevicesNonExist1.Checked == true ? 1 : 0;
            //        Electrical_Devices_IsDirty = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ElectricalDevicesNonExist1.Checked = ElectricalDevicesNonExist1_RadioButton_OriginalState;
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
            try
            {
                if (UserMode)
                {
                    if (ElectricalDevicesNonExist1.Checked)
                    {
                        Electrical_Devices_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ElectricalDevicesFail1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (ElectricalDevicesFail1.Checked)
                    {
                        Electrical_Devices_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
            //bool ElectricalDevicesFail1_RadioButton_OriginalState = ElectricalDevicesFail1.Checked;
            //try
            //{
            //    ElectricalDevicesFail1.Checked = !ElectricalDevicesFail1.Checked;

            //    if (UserMode)
            //    {
            //        //int edf1 = ElectricalDevicesFail1.Checked == true ? 1 : 0;
            //        Electrical_Devices_IsDirty = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ElectricalDevicesFail1.Checked = ElectricalDevicesFail1_RadioButton_OriginalState;
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void ElectricalDevicesExist2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (ElectricalDevicesExist2.Checked)
                    {
                        Electrical_Devices_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void ElectricalDevicesNonExist2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (ElectricalDevicesNonExist2.Checked)
                    {
                        Electrical_Devices_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void ElectricalDevicesFail2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (ElectricalDevicesFail2.Checked)
                    {
                        Electrical_Devices_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ElectricalDevicesExist3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (ElectricalDevicesExist3.Checked)
                    {
                        Electrical_Devices_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ElectricalDevicesNonExist3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (ElectricalDevicesNonExist3.Checked)
                    {
                        Electrical_Devices_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ElectricalDevicesFail3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (ElectricalDevicesFail3.Checked)
                    {
                        Electrical_Devices_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void HeatingCoolingDevices_1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (HeatingCoolingDevices_1.Checked)
                    {
                        Electrical_Devices_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void HeatingCoolingDevices_2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (HeatingCoolingDevices_2.Checked)
                    {
                        Electrical_Devices_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void HeatingCoolingDevices_3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (HeatingCoolingDevices_3.Checked)
                    {
                        Electrical_Devices_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void HeatingCoolingDevices_4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (HeatingCoolingDevices_4.Checked)
                    {
                        Electrical_Devices_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionNotExist1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionNotExist1.Checked)
                        BuildingCondition_Information_isDirty = true;
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionMed1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionMed1.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionHigh1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionHigh1.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionNotExist2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionNotExist2.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionNotExist3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionNotExist3.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionMed2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionMed2.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionMed3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionMed3.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionHigh2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionHigh2.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionHigh3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionHigh3.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionNotExist5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionNotExist5.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LandLine_TextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void BuildingNumber_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void Floor_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void RoomsNumber_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void expenses_amount_6_12_home_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void HeirsNumber_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aidamount_5_3_home_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void expenses_amount_7_Home_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void AmperNumber_7_Home_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            //    && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            //{
            //    e.Handled = true;
            //}

            // Allow decimal point (both . and , depending on culture) & Prevent multiple decimal points in the text
            var c = e.KeyChar;
            var t = (sender as TextBox).Text;
            e.Handled = !char.IsControl(c) && !char.IsDigit(c) && !" -+/".Contains(c) && (c != '.' || t.Contains("."));
        }

        private void AmperNumber_17_Home_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            //    && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            //{
            //    e.Handled = true;
            //}

            // Allow decimal point (both . and , depending on culture) & Prevent multiple decimal points in the text
            var c = e.KeyChar;
            var t = (sender as TextBox).Text;
            e.Handled = !char.IsControl(c) && !char.IsDigit(c) && !" -+/".Contains(c) && (c != '.' || t.Contains("."));
        }

        private void aidamount_4_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aidamount_16_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void ExpensesAmount_3_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void ExpensesAmount_19_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void ExpensesAmount_20_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void ExpensesAmount_2_Home_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void ExpensesAmount_21_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void ExpensesAmount_22_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void ExpensesAmount_11_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void ExpensesAmount_10_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aidamount_11_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aidamount_20_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aidamount_19_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aidamount_14_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void Complaint_RadioButton_Click(object sender, EventArgs e)
        {
            try
            {
                Complaint_RadioButton.Checked = !Complaint_RadioButton.Checked;
                if (UserMode)
                {
                    int Complaint = Complaint_RadioButton.Checked == true ? 1 : 0;
                    f.Update_Family_Complaint(Family_ID, FamilyCode_TextBox.Text, Complaint, this.Name);

                    //to hide/show controls
                    if (!Complaint_RadioButton.Checked)
                    {
                        ComplaintBy_TextBox.Visible = ComplaintDate_Label.Visible = ComplaintDate_TextBox.Visible = false;
                        ComplaintBy_TextBox.Text = ComplaintDate_TextBox.Text = "";
                    }
                    else
                    {
                        ComplaintBy_TextBox.Visible = ComplaintDate_Label.Visible = ComplaintDate_TextBox.Visible = true;
                        ComplaintBy_TextBox.Text = Properties.Settings.Default.Username;
                        ComplaintDate_TextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    MessageBox.Show("تم تعديل الحالة بنجاح", "Confirmation");

                    /*
                    LivingWithCode_ComboBoxtrols();

                    Fill_Family();
                    */
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ME_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void UpdateFamily_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = UpdateFamily_Button;

                DataApproved = Check_Data(0);

                if (DataApproved)
                {
                    if (UpdateMode)
                    {
                        if (!General_Information_IsDirty && 
                            !Partner_DataGridView_IsDirty && 
                            !LivingWith_DataGridView_IsDirty)
                        {
                            MessageBox.Show("لا يوجد أي تغييرات لحفظها ", "Error");
                            return;
                        }
                        else
                        {
                            Get_Data();
                            f.Update_Family(Family_ID, FamilyCode_TextBox.Text
                                , General_Query, Partner_Query, LivingWith_Query
                                //, FamilyVisitState, Income_Query, Aid_Query, Expenses_Query, Asset_Query, CarAsset_Query
                                //, BuildingCondition_Query, LivingCondition_Query, ElectricalDevices_Query, Lighting_Query
                                , Form_Name);

                            MessageBox.Show("تم تعديل معلومات العائلة " + FamilyCode_TextBox.Text + "  بنجاح", "Confirmation");
                        }
                    }
                    Set_Controls();
                    Fill_Family(true, Visit_ID);
                }
            }
            catch (Exception ex)
            {
                LivingWith_Query = Partner_Query = Income_Query = Aid_Query = Asset_Query = CarAsset_Query 
                    = LivingCondition_Query = Expenses_Query = ElectricalDevices_Query = General_Query = Lighting_Query = "";
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ComplaintNote_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                ComplaintNote_TextBox_OriginalText = ComplaintNote_TextBox.Text;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ComplaintNote_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ComplaintNote_TextBox_OriginalText != ComplaintNote_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void SaveFamily_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = SaveFamily_Button;
                DataApproved = Check_Data(0);
                
                if (DataApproved)
                {
                    Get_Data();
                    Family_ID = f.Insert_Family(
                          Code, FamilyNumber, LocationLatitude, LocationLongtitude, Address
                        , Floor, BuildingNumber, Note, PartnerNote, ComplaintNote, EvaluationNote
                        , LivingWithFamily ,LivingWithNote, LivingWithNote2 
                        , LandLine, MobileNumber
                        , InEvaluation, InEvaluationBy, EvaluationDate
                        , Approved, ApprovedBy, ApprovalDate
                        , PDM, PDMBy, PDMDate, PVM, PVMBy, PVMDate, Complaint, ComplaintBy, ComplaintDate
                        , Parish_ID, Street_ID, Partner_Query, LivingWith_Query, Form_Name);

                    //, FamilyNote 
                    //, EntredBy, EntredBy2, OtherVisitors, DateOfEntry
                    //, home_description, ElectricityNote , NoteAid_11, NoteAid_19, NoteAid_20, NoteAid_12
                    //, NoteAid_17_home, NoteAid_16_home, income_address_12, RoomsNumber 
                    //, IsDisplaced_ID, HomeType_ID, ExpensesAmount_10, aidamount_11
                    //, aidamount_20, aidamount_19, expenses_amount_6_12_home, ExpensesAmount_2_Home
                    //, ExpensesAmount_3, ExpensesAmount_21, ExpensesAmount_19, ExpensesAmount_22
                    //, ExpensesAmount_20, ExpensesAmount_11, HeirsNumber, aidamount_5_3_home, expenses_amount_7_Home
                    //, AmperNumber_7_Home, aidamount_4, aidsource_4, aidperiod_4, aidsource_16, aidperiod_16
                    //, SellingFurniture_type_1, SellingFurniture_type_2, AmperNumber_17_Home, aidamount_16, aidamount_14
                    //, aidamount_12, aidamount_17_Home, aidamount_16_Home, Expenses_10, Expenses_1, expensestype_6_12_home_ID
                    //, ParishHomeID, aidsource_5_3_home_ID, aidperiod_5_3_home_ID, Beds_ID, LivingRoom_ID
                    //, HeatingCooling_1, HeatingCooling_2, HeatingCooling_3, HeatingCooling_4, Income_11, Expenses_7_Home
                    //, Expenses_17_Home, Expenses_16_Home, Electricity, LivingWithCode, LivingWithCode2, SellingFurniture
                    //, ElectricalDevices_1, ElectricalDevices_2, ElectricalDevices_3, BuildingCond_1, BuildingCond_2
                    //, BuildingCond_3, BuildingCond_5, BuildingCond_8, aidsource_11, aidsource_20, aidsource_19
                    //, aidsource_14, aidsource_12, aidsource_16_Home, aidsource_17_Home, aidperiod_11, aidperiod_20
                    //, aidperiod_19, aidperiod_14, aidperiod_12, aidperiod_16_Home, aidperiod_17_Home, IncomeRelation_12
                    //, aidamount_30, aidperiod_30
                    //, Asset_Query, CarAsset_Query, Income_Query

                    UpdateMode = true; 
                    MessageBox.Show("تم إدخال العائلة " + Code + "  بنجاح", "Confirmation");

                    Set_Controls();
                    members_table.Visible = true;
                    ME_DataGridView.Visible = true;
                    FamilyHistory_Button.Visible = true;
                    panel1.Visible = true;
                    Fill_Family(true, Visit_ID);
                }
            }

            catch (Exception ex)
            {
                LivingWith_Query = Partner_Query = Income_Query = Aid_Query = Asset_Query = CarAsset_Query = LivingCondition_Query = Expenses_Query = ElectricalDevices_Query = Partner_Query = "";
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void UpdateFamily_Button_MouseEnter(object sender, EventArgs e)
        {
            UpdateFamily_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;
        }

        private void SaveFamily_Button_MouseEnter(object sender, EventArgs e)
        {
            SaveFamily_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;
        }

        private void UpdateFamily_Button_MouseLeave(object sender, EventArgs e)
        {
            UpdateFamily_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;
        }

        private void SaveFamily_Button_MouseLeave(object sender, EventArgs e)
        {
            SaveFamily_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;
        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EntredBy_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LivingWith_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LivingWith_DataGridView_IsDirty = true;
                LivingWith_DataGridView.Rows[e.RowIndex].Cells["LivingWith_IsDirty"].Value = 1;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LivingWith_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == LivingWith_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == LivingWith_DataGridView.Columns["Family_LivingWith_Delete"].Index)
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
                if (e.ColumnIndex == LivingWith_DataGridView.Columns["Family_GoToFamily"].Index)
                {
                    Image image = null;
                    image = Properties.Resources.Password_Show;
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

        private void LivingWith_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void LivingWith_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                ComboBox cb = (ComboBox)e.Control;
                cb.DrawMode = DrawMode.OwnerDrawVariable;
                cb.DrawItem -= ComboBox_DrawItem;
                cb.DrawItem += ComboBox_DrawItem;

                cb.DropDownStyle = ComboBoxStyle.DropDown;
                cb.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
        }

        private void Story_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void ME_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
         
        private void ME_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
         
        private void Video_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
         
        private void Followup_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void asset_3_yes_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    CarAsset_DataGridView_IsDirty = true;
                    if (asset_3_yes_RadioButton.Checked)
                    {
                        CarAsset_DataGridView.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void hasincome_yes_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    Income_DataGridView_IsDirty = true;
                    if (hasincome_yes_RadioButton.Checked)
                    {
                        Income_DataGridView.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void isAsset_no_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    Asset_DataGridView_IsDirty = true;
                    if (isAsset_no_RadioButton.Checked)
                    {
                        while (Asset_DataGridView.Rows.Count > 1)
                        {
                            Asset_DataGridView.Rows.RemoveAt(0);
                        }
                        Asset_DataGridView.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void isAsset_yes_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    Asset_DataGridView_IsDirty = true;
                    if (isAsset_yes_RadioButton.Checked)
                    {
                        Asset_DataGridView.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void asset_3_no_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    CarAsset_DataGridView_IsDirty = true;
                    if (asset_3_no_RadioButton.Checked)
                    {
                        while (CarAsset_DataGridView.Rows.Count > 1)
                        {
                            CarAsset_DataGridView.Rows.RemoveAt(0);
                        }
                        CarAsset_DataGridView.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void hasincome_no_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    Income_DataGridView_IsDirty = true;
                    if (hasincome_no_RadioButton.Checked)
                    {
                        while (Income_DataGridView.Rows.Count > 1)
                        {
                            Income_DataGridView.Rows.RemoveAt(0);
                        }
                        Income_DataGridView.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Street_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void LivingWith_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == LivingWith_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;
                //Check if click is on specific column 
                if (e.ColumnIndex == LivingWith_DataGridView.Columns["Family_LivingWith_Delete"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (LivingWith_DataGridView.Rows[e.RowIndex].Cells["Family_LivingWith_ID"].Value != null)
                        {
                            int? Family_LivingWith_Code = null;
                            LivingWith_DataGridView_IsDirty = true;
                            LivingWith_DataGridView.Rows[e.RowIndex].Cells["LivingWith_IsDirty"].Value = "1";
                            LivingWith_DataGridView.Rows[e.RowIndex].Visible = false;
                            int Family_LivingWith_ID = int.Parse(LivingWith_DataGridView.Rows[e.RowIndex].Cells["Family_LivingWith_ID"].Value.ToString());
                            if(LivingWith_DataGridView.Rows[e.RowIndex].Cells["Family_LivingWith_Code"].Value == null)
                            {
                                Family_LivingWith_Code = Family_ID;
                            }
                            else
                            {
                                 Family_LivingWith_Code = int.Parse(LivingWith_DataGridView.Rows[e.RowIndex].Cells["Family_LivingWith_Code"].Value.ToString());
                            }
                            string Family_LivingWith_Note = LivingWith_DataGridView.Rows[e.RowIndex].Cells["Family_LivingWith_Note"].Value == null ? "" : LivingWith_DataGridView.Rows[e.RowIndex].Cells["Family_LivingWith_Note"].Value.ToString();
                            f.Delete_LivingWith(Family_LivingWith_Code, Family_LivingWith_Note, this.Name);
                            if (LivingWith_DataGridView.Rows.Count == 0)
                            {
                                LivingWithFamily = 0;
                            }
                            //MessageBox.Show("تم الحذف  بنجاح", "Confirmation");
                        }
                        else
                        {
                            LivingWith_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
                if (e.ColumnIndex == LivingWith_DataGridView.Columns["Family_GoToFamily"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("الذهاب إلى العائلة؟", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int Family_ID = -1;
                        if (LivingWith_DataGridView.Rows[e.RowIndex].Cells["Family_LivingWith_Code"].Value != null)
                        {

                            Family_ID = int.Parse(LivingWith_DataGridView.Rows[e.RowIndex].Cells["Family_LivingWith_Code"].Value.ToString());
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
                        else
                        {
                            MessageBox.Show("الرجاء إدخال رمز العائلة أولاً");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void EntredBy2_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void EntredByOther_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                EntredByOther_TextBox_OriginalText = EntredByOther_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void EntredByOther_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (EntredByOther_TextBox_OriginalText != EntredByOther_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_12_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aidamount_17_Home_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aidamount_16_Home_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void LivingWithCode_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LivingWithCode2_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void aidamount_30_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }


        private void test_Click(object sender, EventArgs e)
        {

        }

        private void BuildingConditionNotExist8_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionNotExist8.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void FamilyNote_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                FamilyNote_TextBox_OriginalText = FamilyNote_TextBox.Text;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void FamilyNote_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (FamilyNote_TextBox_OriginalText != FamilyNote_TextBox.Text)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionMed5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionMed5.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Asset_DataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == Asset_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (!Asset_DataGridView.Rows[e.RowIndex].Cells["Asset_VisitName"].Value.Equals(VisitNameLabel.Text))
                {
                    MessageBox.Show("يُرجى الذهاب إلى الزيارة للتعديل");
                    return;
                }


                //Check if click is on specific column 
                if (e.ColumnIndex == Asset_DataGridView.Columns["Asset_DeleteRow"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Asset_DataGridView.Rows[e.RowIndex].Cells["Family_Asset_ID"].Value != null)
                        {
                            Asset_DataGridView_IsDirty = true;
                            Asset_DataGridView.Rows[e.RowIndex].Cells["Asset_IsDirty"].Value = "1";
                            Asset_DataGridView.Rows[e.RowIndex].Visible = false;
                        }
                        else
                        {
                            Asset_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionMed8_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionMed8.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionHigh5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionHigh5.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void BuildingConditionHigh8_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (BuildingConditionHigh8.Checked)
                    {
                        BuildingCondition_Information_isDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Livingroom_ComboBox_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            try
            {
                LivingCondition_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void expenses_amount_7_Home_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                expenses_amount_7_Home_TextBox_OriginalText = expenses_amount_7_Home_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }


        }

        private void expenses_amount_7_Home_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expenses_amount_7_Home_TextBox_OriginalText != expenses_amount_7_Home_TextBox.Text)
                    Lighting_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void AmperNumber_7_Home_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                AmperNumber_7_Home_TextBox_OriginalText = AmperNumber_7_Home_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void AmperNumber_7_Home_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (AmperNumber_7_Home_TextBox_OriginalText != AmperNumber_7_Home_TextBox.Text)
                    Lighting_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_4_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aidamount_4_TextBox_OriginalText = aidamount_4_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_4_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aidamount_4_TextBox_OriginalText != aidamount_4_TextBox.Text)
                    Lighting_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_16_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aidamount_16_TextBox_OriginalText = aidamount_16_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_16_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aidamount_16_TextBox_OriginalText != aidamount_16_TextBox.Text)
                    Lighting_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_4_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    Lighting_Information_IsDirty = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_16_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Lighting_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_4_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Lighting_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_16_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Lighting_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Expenses_16_Home_Yes_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Expenses_16_Home_Yes_RadioButton.Checked)
                    {
                        Lighting_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Expenses_16_Home_No_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Expenses_16_Home_No_RadioButton.Checked)
                    {
                        Lighting_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void SellingFurniture_Yes_RadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (SellingFurniture_Yes_RadioButton.Checked)
                    {
                        SellingFurniturePanel.Visible = true;
                        //SellingFurniture_type_id_1.Visible = true;
                        //SellingFurniture_type_id_2.Visible = true;
                        //SellingFurniture_type_id_1.Checked = false;
                        //SellingFurniture_type_id_2.Checked = false;
                        General_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void SellingFurniture_No_RadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (SellingFurniture_No_RadioButton.Checked)
                    {
                        SellingFurniturePanel.Visible = false;

                        //SellingFurniture_type_id_1.Visible = false;
                        //SellingFurniture_type_id_2.Visible = false;
                        //SellingFurniture_type_id_1.Checked = false;
                        //SellingFurniture_type_id_2.Checked = false;
                        General_Information_IsDirty = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ElectricityNote_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                ElectricityNote_TextBox_OriginalText = ElectricityNote_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }


        }

        private void ElectricityNote_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (ElectricityNote_TextBox_OriginalText != ElectricityNote_TextBox.Text)
                        Lighting_Information_IsDirty = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void SellingFurniture_type_id_2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (SellingFurniture_type_id_2.Checked)
                    {
                        General_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Income11_1_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Income11_1_RadioButton.Checked)
                    {
                        General_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Income11_2_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Income11_2_RadioButton.Checked)
                    {
                        General_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Income11_3_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Income11_3_RadioButton.Checked)
                    {
                        General_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void CarAsset_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == CarAsset_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (!CarAsset_DataGridView.Rows[e.RowIndex].Cells["CarAsset_VisitName"].Value.Equals(VisitNameLabel.Text))
                {
                    MessageBox.Show("يُرجى الذهاب إلى الزيارة للتعديل");
                    return;
                }


                //Check if click is on specific column 
                if (e.ColumnIndex == CarAsset_DataGridView.Columns["CarAsset_DeleteRow"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (CarAsset_DataGridView.Rows[e.RowIndex].Cells["Family_CarAsset_ID"].Value != null)
                        {
                            CarAsset_DataGridView_IsDirty = true;
                            CarAsset_DataGridView.Rows[e.RowIndex].Cells["CarAsset_IsDirty"].Value = "1";
                            CarAsset_DataGridView.Rows[e.RowIndex].Visible = false;
                        }
                        else
                        {
                            CarAsset_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void CarAsset_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CarAsset_DataGridView_IsDirty = true;
                CarAsset_DataGridView.Rows[e.RowIndex].Cells["CarAsset_IsDirty"].Value = 1;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void CarAsset_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == CarAsset_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == CarAsset_DataGridView.Columns["CarAsset_DeleteRow"].Index)
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

        private void CarAsset_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void CarAsset_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                ComboBox cb = (ComboBox)e.Control;
                cb.DrawMode = DrawMode.OwnerDrawVariable;
                cb.DrawItem -= ComboBox_DrawItem;
                cb.DrawItem += ComboBox_DrawItem;

                cb.DropDownStyle = ComboBoxStyle.DropDown;
                cb.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
        }

        private void CarAsset_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                //if (UserMode)
                //{
                //    if (Asset_DataGridView.Rows[e.RowIndex - 1].Cells["Family_CarAsset_ID"].Value == null || Asset_DataGridView.Rows[e.RowIndex - 1].Cells["Family_CarAsset_ID"].Value.ToString() == "")
                //    {
                //        Asset_DataGridView.Rows[e.RowIndex - 1].Cells["Family_CarAsset_ID"].Value = 1;
                //    }
                //}

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Expenses_1_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_2_Home_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                ExpensesAmount_2_Home_TextBox_OriginalText = ExpensesAmount_2_Home_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void ExpensesAmount_2_Home_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ExpensesAmount_2_Home_TextBox_OriginalText != ExpensesAmount_2_Home_TextBox.Text)
                    Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_3_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ExpensesAmount_3_TextBox_OriginalText != ExpensesAmount_3_TextBox.Text)
                    Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_21_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ExpensesAmount_21_TextBox_OriginalText != ExpensesAmount_21_TextBox.Text)
                    Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_19_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ExpensesAmount_19_TextBox_OriginalText != ExpensesAmount_19_TextBox.Text)
                    Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_22_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ExpensesAmount_22_TextBox_OriginalText != ExpensesAmount_22_TextBox.Text)
                    Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_20_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ExpensesAmount_20_TextBox_OriginalText != ExpensesAmount_20_TextBox.Text)
                    Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_11_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ExpensesAmount_11_TextBox_OriginalText != ExpensesAmount_11_TextBox.Text)
                    Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_3_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                ExpensesAmount_3_TextBox_OriginalText = ExpensesAmount_3_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_21_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                ExpensesAmount_21_TextBox_OriginalText = ExpensesAmount_21_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_19_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                ExpensesAmount_19_TextBox_OriginalText = ExpensesAmount_19_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_22_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                ExpensesAmount_22_TextBox_OriginalText = ExpensesAmount_22_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_20_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                ExpensesAmount_20_TextBox_OriginalText = ExpensesAmount_20_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_11_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                ExpensesAmount_11_TextBox_OriginalText = ExpensesAmount_11_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Expenses_10_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                Expenses_10_TextBox_OriginalText = Expenses_10_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_10_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                ExpensesAmount_10_TextBox__OriginalText = ExpensesAmount_10_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Expenses_10_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Expenses_10_TextBox_OriginalText != Expenses_10_TextBox.Text)
                    Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ExpensesAmount_10_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ExpensesAmount_10_TextBox__OriginalText != ExpensesAmount_10_TextBox.Text)
                    Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Income_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                //if (UserMode)
                //{
                //    if (Income_DataGridView.Rows[e.RowIndex - 1].Cells["Family_Income_ID"].Value == null || Income_DataGridView.Rows[e.RowIndex - 1].Cells["Family_Income_ID"].Value.ToString() == "")
                //    {
                //        Income_DataGridView.Rows[e.RowIndex - 1].Cells["Family_Income_ID"].Value = 1;
                //    }
                //}

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_11_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_20_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_19_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_14_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_12_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_17_home_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_16_home_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_11_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_20_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_19_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_14_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_12_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_17_home_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_16_home_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_11_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aidamount_11_TextBox_OriginalText = aidamount_11_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void aidamount_20_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aidamount_20_TextBox_OriginalText = aidamount_20_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_19_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aidamount_19_TextBox_OriginalText = aidamount_19_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_14_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aidamount_14_TextBox_OriginalText = aidamount_14_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_12_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aidamount_12_TextBox_OriginalText = aidamount_12_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_17_Home_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aidamount_17_Home_TextBox_OriginalText = aidamount_17_Home_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_16_Home_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aidamount_16_Home_TextBox_OriginalText = aidamount_16_Home_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NoteAid_11_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                NoteAid_11_TextBox_OriginalText = NoteAid_11_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NoteAid_20_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                NoteAid_20_TextBox_OriginalText = NoteAid_20_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NoteAid_19_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                NoteAid_19_TextBox_OriginalText = NoteAid_19_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NoteAid_12_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                NoteAid_12_TextBox_OriginalText = NoteAid_12_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NoteAid_17_home_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                NoteAid_17_home_TextBox_OriginalText = NoteAid_17_home_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NoteAid_16_home_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                NoteAid_16_home_TextBox_OriginalText = NoteAid_16_home_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_11_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aidamount_11_TextBox_OriginalText != aidamount_11_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_20_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aidamount_20_TextBox_OriginalText != aidamount_20_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_19_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aidamount_19_TextBox_OriginalText != aidamount_19_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_14_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aidamount_14_TextBox_OriginalText != aidamount_14_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_12_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aidamount_12_TextBox_OriginalText != aidamount_12_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_17_Home_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aidamount_17_Home_TextBox_OriginalText != aidamount_17_Home_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_16_Home_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aidamount_16_Home_TextBox_OriginalText != aidamount_16_Home_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NoteAid_11_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (NoteAid_11_TextBox_OriginalText != NoteAid_11_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NoteAid_20_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (NoteAid_20_TextBox_OriginalText != NoteAid_20_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NoteAid_19_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (NoteAid_19_TextBox_OriginalText != NoteAid_19_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NoteAid_12_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (NoteAid_12_TextBox_OriginalText != NoteAid_12_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NoteAid_17_home_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (NoteAid_17_home_TextBox_OriginalText != NoteAid_17_home_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NoteAid_16_home_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (NoteAid_16_home_TextBox_OriginalText != NoteAid_16_home_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void IncomeRelation_12_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_30_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void income_address_12_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                income_address_12_TextBox_OriginalText = income_address_12_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_30_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aidamount_30_TextBox_OriginalText = aidamount_30_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void income_address_12_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (income_address_12_TextBox_OriginalText != income_address_12_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidamount_30_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aidamount_30_TextBox_OriginalText != aidamount_30_TextBox.Text)
                    Aid_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Expenses_7_Home_Yes_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Expenses_7_Home_Yes_RadioButton.Checked)
                    {
                        aidsource_4_ComboBox.Enabled = true;
                        aidperiod_4_ComboBox.Enabled = true;
                        aidamount_4_TextBox.Enabled = true;
                        expenses_amount_7_Home_TextBox.Enabled = true;
                        AmperNumber_7_Home_TextBox.Visible = true;
                        Lighting_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Expenses_17_Home_Yes_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Expenses_17_Home_Yes_RadioButton.Checked)
                    {
                        //aidsource_16_ComboBox.SelectedValue = -1;
                        //aidperiod_16_ComboBox.SelectedValue = -1;
                        //aidamount_16_Home_TextBox.Text = "";
                        //AmperNumber_17_Home_TextBox.Text = "";
                        aidsource_16_ComboBox.Visible = true;
                        aidperiod_16_ComboBox.Visible = true;
                        aidamount_16_TextBox.Visible = true;
                        AmperNumber_17_Home_TextBox.Visible = true;
                        Lighting_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Expenses_17_Home_No_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Expenses_17_Home_No_RadioButton.Checked)
                    {
                        aidsource_16_ComboBox.SelectedValue = 0;
                        aidperiod_16_ComboBox.SelectedValue = 0;
                        aidamount_16_TextBox.Text = "";
                        AmperNumber_17_Home_TextBox.Text = "";
                        aidsource_16_ComboBox.Visible = false;
                        aidperiod_16_ComboBox.Visible = false;
                        aidamount_16_TextBox.Visible = false;
                        AmperNumber_17_Home_TextBox.Visible = false;
                        Lighting_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Expenses_7_Home_No_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Expenses_17_Home_No_RadioButton.Checked)
                    {
                        aidsource_4_ComboBox.SelectedValue = 0;
                        aidsource_4_ComboBox.Enabled = false;
                        aidperiod_4_ComboBox.SelectedValue = 0;
                        aidperiod_4_ComboBox.Enabled = false;
                        aidamount_4_TextBox.Text = "";
                        aidamount_4_TextBox.Enabled = false;
                        expenses_amount_7_Home_TextBox.Text = "";
                        expenses_amount_7_Home_TextBox.Enabled = false;
                        AmperNumber_7_Home_TextBox.Text = "";
                        AmperNumber_7_Home_TextBox.Visible = false;
                        Lighting_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void SellingFurniture_type_id_1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (SellingFurniture_type_id_1.Checked)
                    {
                        General_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void home_description_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                home_description_TextBox_OriginalText = home_description_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void Beneficiaries_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == Beneficiaries_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == Beneficiaries_DataGridView.Columns["MovePerson"].Index)
                {
                    Image image = null;
                    image = Properties.Resources.Move;
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                    var size = image.Size;
                    var location = new Point((e.CellBounds.Width - size.Width) / 2, (e.CellBounds.Height - size.Height) / 2);
                    location.Offset(e.CellBounds.Location);
                    e.Graphics.DrawImage(image, location);

                    e.Handled = true;
                }
                foreach (DataGridViewRow R in Beneficiaries_DataGridView.Rows)
                {
                    if (Convert.ToString(R.Cells["حالة المستفيد"].Value) == "مفقود" || Convert.ToString(R.Cells["حالة المستفيد"].Value) == "مسافر" || Convert.ToString(R.Cells["حالة المستفيد"].Value) == "متوفي" || Convert.ToString(R.Cells["حالة المستفيد"].Value) == "شهيد" || Convert.ToString(R.Cells["حالة المستفيد"].Value) == "زواج" || Convert.ToString(R.Cells["حالة المستفيد"].Value) == "غير مقيم/منفصل" || Convert.ToString(R.Cells["حالة المستفيد"].Value) == "غير مقيم/مطلق")
                    {
                        R.Cells["حالة المستفيد"].Style.BackColor = Color.Red; //Color.FromArgb(125, 0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Beneficiaries_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == Beneficiaries_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;
                //Check if click is on specific column 
                if (e.ColumnIndex == Beneficiaries_DataGridView.Columns["MovePerson"].Index)
                {
                    int Person_ID = -1;
                    string Person_Name = "";
                    if (Beneficiaries_DataGridView.RowCount > 0 && Beneficiaries_DataGridView.CurrentRow != null)
                    {
                        SelectedDataRow = ((DataRowView)Beneficiaries_DataGridView.CurrentRow.DataBoundItem).Row;
                        if (SelectedDataRow["المستلم"].ToString() == "نعم")
                        {
                            MessageBox.Show("لا يمكن نقل المستلم من عائلة لأخرى", "Error");
                        }
                        else
                        {
                            if (SelectedDataRow != null)
                            {
                                if (SelectedDataRow["Person ID"] != null || SelectedDataRow["Person ID"] != DBNull.Value)
                                {
                                    Person_ID = int.Parse(SelectedDataRow["Person ID"].ToString());
                                    Person_Name = SelectedDataRow["اسم الشخص"].ToString();
                                }
                            }
                            if (Person_ID != -1)
                            {
                                Move_Person_Form Move_Person_Form = new Move_Person_Form(main_form, FamilyCode_TextBox.Text, Family_ID, Person_Name, Person_ID);
                                Move_Person_Form.ShowDialog();

                                Bind_Members();
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
        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
        //private void NonBeneficiaries_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{
        //    try
        //    {
        //        if (e.RowIndex == NonBeneficiaries_DataGridView.NewRowIndex || e.RowIndex < 0)
        //            return;

        //        if (e.ColumnIndex == NonBeneficiaries_DataGridView.Columns["MovePerson"].Index)
        //        {
        //            Image image = null;
        //            image = Properties.Resources.Move;
        //            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
        //            var size = image.Size;
        //            var location = new Point((e.CellBounds.Width - size.Width) / 2, (e.CellBounds.Height - size.Height) / 2);
        //            location.Offset(e.CellBounds.Location);
        //            e.Graphics.DrawImage(image, location);

        //            e.Handled = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
        //    }
        //}

        //private void NonBeneficiaries_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        //if click is on new row or header row
        //        if (e.RowIndex == NonBeneficiaries_DataGridView.NewRowIndex || e.RowIndex < 0)
        //            return;
        //        //Check if click is on specific column 
        //        if (e.ColumnIndex == NonBeneficiaries_DataGridView.Columns["MovePerson"].Index)
        //        {
        //            int Person_ID = -1;
        //            string Person_Name = "";
        //            if (NonBeneficiaries_DataGridView.RowCount > 0 && NonBeneficiaries_DataGridView.CurrentRow != null)
        //            {
        //                SelectedDataRow = ((DataRowView)NonBeneficiaries_DataGridView.CurrentRow.DataBoundItem).Row;
        //                if (SelectedDataRow["المستلم"].ToString() == "نعم")
        //                {
        //                    MessageBox.Show("لا يمكن نقل المستلم من عائلة لأخرى", "Error");
        //                }
        //                else
        //                {
        //                    if (SelectedDataRow != null)
        //                    {
        //                        if (SelectedDataRow["Person ID"] != null || SelectedDataRow["Person ID"] != DBNull.Value)
        //                        {
        //                            Person_ID = int.Parse(SelectedDataRow["Person ID"].ToString());
        //                            Person_Name = SelectedDataRow["اسم الشخص"].ToString();
        //                        }
        //                    }
        //                    if (Person_ID != -1)
        //                    {
        //                        Move_Person_Form Move_Person_Form = new Move_Person_Form(main_form, FamilyCode_TextBox.Text, Family_ID, Person_Name, Person_ID);
        //                        Move_Person_Form.ShowDialog();

        //                        Bind_Members();
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
        //    }
        //}

        private void AddPerson_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Form Person_Form = new Person_Form(Family_ID, Visit_ID, VisitNameLabel.Text, FamilyCode_TextBox.Text, main_form);
                //main_form.showNewTab(Person_Form, "Member");
                Person_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }
        private void AddVisit_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Form Visit_Form = new AddVisits_Form(main_form, Family_ID);
                Visit_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }



        private void FamilyHistory_Button_Click(object sender, EventArgs e)
        {
            try
            {
                History_Form NewHistory_Form = new History_Form("FamilyMembers", Family_ID, main_form);
                NewHistory_Form.ShowDialog();
            }
            catch (Exception ex)
            { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }

        }

        private void Beneficiaries_DataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int Person_ID = -1;
                if (Beneficiaries_DataGridView.RowCount > 0 && Beneficiaries_DataGridView.CurrentRow != null)
                {
                    SelectedDataRow = ((DataRowView)Beneficiaries_DataGridView.CurrentRow.DataBoundItem).Row;
                    if (SelectedDataRow != null)
                    {
                        if (SelectedDataRow["Person ID"] != null || SelectedDataRow["Person ID"] != DBNull.Value)
                            Person_ID = int.Parse(SelectedDataRow["Person ID"].ToString());
                    }
                    if (Person_ID != -1)
                    {
                        if (Program.Check_Opened("Person", Person_ID))
                        {
                            MessageBox.Show("لا يمكن فتح صفحة الشخص نفسه أكثر من مرة");
                        }
                        else
                        {
                            Form Person_Form = new Person_Form(Person_ID, Family_ID, Visit_ID, VisitNameLabel.Text, FamilyCode_TextBox.Text, main_form);
                            main_form.showNewTab(Person_Form, "Member");
                            materialTabControl1.Size = new Size(this.Width - 20, 5000);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        //private void NonBeneficiaries_DataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    try
        //    {
        //        int Person_ID = -1;
        //        if (NonBeneficiaries_DataGridView.RowCount > 0 && NonBeneficiaries_DataGridView.CurrentRow != null)
        //        {
        //            SelectedDataRow = ((DataRowView)NonBeneficiaries_DataGridView.CurrentRow.DataBoundItem).Row;
        //            if (SelectedDataRow != null)
        //            {
        //                if (SelectedDataRow["Person ID"] != null || SelectedDataRow["Person ID"] != DBNull.Value)
        //                    Person_ID = int.Parse(SelectedDataRow["Person ID"].ToString());
        //            }
        //            if (Person_ID != -1)
        //            {

        //                if (Program.Check_Opened("Person", Person_ID))
        //                {
        //                    MessageBox.Show("لا يمكن فتح صفحة الشخص نفسه أكثر من مرة");
        //                }
        //                else
        //                {
        //                    Form Person_Form = new Person_Form(Person_ID, Family_ID, main_form);
        //                    main_form.showNewTab(Person_Form, "Member");
        //                }
        //                /*
        //                Form Person_Form = new Person_Form(Person_ID, Family_ID, main_form);
        //                main_form.showNewTab(Person_Form, "Member");*/
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
        //    }
        //}

        protected override Point ScrollToControl(Control activeControl) //STOP AUTO SCROLL
        {
            Point pt = this.AutoScrollPosition;
            return pt;
        }

        private void FamilyHistory_Button_MouseEnter(object sender, EventArgs e)
        {
            FamilyHistory_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;
        }

        private void FamilyHistory_Button_MouseLeave(object sender, EventArgs e)
        {
            FamilyHistory_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        private void AddPerson_Button_MouseEnter(object sender, EventArgs e)
        {
            AddPerson_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1; 
        }

        private void AddPerson_Button_MouseLeave(object sender, EventArgs e)
        {
            AddPerson_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        private void AddVisit_Button_MouseEnter(object sender, EventArgs e)
        {
            AddVisit_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;
        }

        private void AddVisit_Button_MouseLeave(object sender, EventArgs e)
        {
            AddVisit_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        private void Bind_Show_Hide_ToolStrip()
        {
            ToolStripMenuItem Hide_Columns = Show_Hide_ToolStrip.DropDownItems[0] as ToolStripMenuItem;
            ToolStripMenuItem Show_Columns = Show_Hide_ToolStrip.DropDownItems[1] as ToolStripMenuItem;

            Show_Columns.DropDownItems.Clear();
            Hide_Columns.DropDownItems.Clear();

            foreach (DataGridViewColumn C in Beneficiaries_DataGridView.Columns)
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
                Beneficiaries_DataGridView.Columns[e.ClickedItem.Text].Visible = false;
                //NonBeneficiaries_DataGridView.Columns[e.ClickedItem.Text].Visible = false;

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
                Beneficiaries_DataGridView.Columns[e.ClickedItem.Text].Visible = true;
                //NonBeneficiaries_DataGridView.Columns[e.ClickedItem.Text].Visible = true;

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
                if (Show_Hide_ToolStrip.DropDownItems.Count > 0)
                {
                    if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                    {
                        e.Cancel = true;
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
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // --------------Visits_TabPage--------------

        DateTimePicker DatePicker1, DatePicker2, DatePicker3, DatePicker4, DatePicker5;
        TextBox MEReason;

        string Selected_Visit_Type = "", Selected_Visit_Name = "", Selected_Visit_Reason = "";

        int Selected_Family_Visit_ID = -1; int Selected_Family_Visitstate = -1; int Selected_Row_Index = -1; int Seelcted_Visitor1_ID = -1; int Selected_Visitor2_ID = -1;
        bool Visit_DataApproved = false;
        int BeginEdit_RowIndex = -1, BeginEdit_ColumnIndex = -1; int BeginEdit2_RowIndex = -1, BeginEdit2_ColumnIndex = -1;
        bool UpdateWithFill = true;

        #region //Visit_IsDirty
        bool Visit_Details_IsDirty = false, Team_IsDirty = false;

        private void Main_TableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Approved_RadioButton_Click(object sender, EventArgs e)
        {
            bool Approved_RadioButton_OriginalState = Approved_RadioButton.Checked;

            try
            {
                Approved_RadioButton.Checked = !Approved_RadioButton.Checked;

                if (UserMode)
                {
                    int Approved = Approved_RadioButton.Checked == true ? 1 : 0;
                    f.Update_Family_Approval(Family_ID, FamilyCode_TextBox.Text, Approved, this.Name);
                    //to hide/show controls
                    if (!Approved_RadioButton.Checked)
                    {
                        ApprovedBy_TextBox.Visible = ApprovalDate_Label.Visible = ApprovalDate_TextBox.Visible = false;
                        ApprovedBy_TextBox.Text = "";
                        ApprovalDate_TextBox.Text = null;
                    }
                    else
                    {
                        ApprovedBy_TextBox.Visible = ApprovalDate_Label.Visible = ApprovalDate_TextBox.Visible = true;
                        ApprovedBy_TextBox.Text = Properties.Settings.Default.Username;
                        ApprovalDate_TextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    MessageBox.Show("تم تعديل الحالة بنجاح", "Confirmation");

                    /*
                    Set_Controls();

                    Fill_Family();
                    */
                }
            }
            catch (Exception ex)
            {
                Approved_RadioButton.Checked = Approved_RadioButton_OriginalState;
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void PVM_RadioButton_Click(object sender, EventArgs e)
        {
            bool PVM_RadioButton_OriginalState = PVM_RadioButton.Checked;

            try
            {
                PVM_RadioButton.Checked = !PVM_RadioButton.Checked;

                if (UserMode)
                {
                    int PVM = PVM_RadioButton.Checked == true ? 1 : 0;
                    f.Update_Family_PVM(Family_ID, FamilyCode_TextBox.Text, PVM, this.Name);

                    //to hide/show controls
                    if (!PVM_RadioButton.Checked)
                    {
                        PVMBy_TextBox.Visible = PvmDate_Label.Visible = PVMDate_TextBox.Visible = false;
                        PVMBy_TextBox.Text = PVMDate_TextBox.Text = "";
                    }
                    else
                    {
                        PVMBy_TextBox.Visible = PvmDate_Label.Visible = PVMDate_TextBox.Visible = true;
                        PVMBy_TextBox.Text = Properties.Settings.Default.Username;
                        PVMDate_TextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }

                    MessageBox.Show("تم تعديل الحالة بنجاح", "Confirmation");

                    /*
                    Set_Controls();

                    Fill_Family();
                    */
                }
            }
            catch (Exception ex)
            {
                PVM_RadioButton.Checked = PVM_RadioButton_OriginalState;
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void PDM_RadioButton_Click(object sender, EventArgs e)
        {
            bool PDM_RadioButton_OriginalState = PDM_RadioButton.Checked;

            try
            {
                PDM_RadioButton.Checked = !PDM_RadioButton.Checked;
                if (UserMode)
                {
                    int PDM = PDM_RadioButton.Checked == true ? 1 : 0;
                    f.Update_Family_PDM(Family_ID, FamilyCode_TextBox.Text, PDM, this.Name);

                    //to hide/show controls
                    if (!PDM_RadioButton.Checked)
                    {
                        PDMBy_TextBox.Visible = PdmDate_Label.Visible = PDMDate_TextBox.Visible = false;
                        PDMBy_TextBox.Text = PDMDate_TextBox.Text = "";
                    }
                    else
                    {
                        PDMBy_TextBox.Visible = PdmDate_Label.Visible = PDMDate_TextBox.Visible = true;
                        PDMBy_TextBox.Text = Properties.Settings.Default.Username;
                        PDMDate_TextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    MessageBox.Show("تم تعديل الحالة بنجاح", "Confirmation");

                    /*
                    Set_Controls();

                    Fill_Family();
                    */
                }
            }
            catch (Exception ex)
            {
                PDM_RadioButton.Checked = PDM_RadioButton_OriginalState;
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void GoToFamily_Button_Click(object sender, EventArgs e)
        {

        }

        private void PowerExpenses_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    //if click is on new row or header row
            //    if (e.RowIndex == PowerExpenses_DataGridView.NewRowIndex || e.RowIndex < 0)
            //        return;

            //    //Check if click is on specific column 
            //    if (e.ColumnIndex == PowerExpenses_DataGridView.Columns["PowerExpenses_DeleteRow"].Index)
            //    {
            //        DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            if (PowerExpenses_DataGridView.Rows[e.RowIndex].Cells["Family_asset_ID"].Value != null)
            //            {
            //                PowerExpenses_DataGridView_IsDirty = true;
            //                PowerExpenses_DataGridView.Rows[e.RowIndex].Cells["Asset_IsDirty"].Value = "1";
            //                PowerExpenses_DataGridView.Rows[e.RowIndex].Visible = false;
            //            }
            //            else
            //            {
            //                PowerExpenses_DataGridView.Rows.RemoveAt(e.RowIndex);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void PowerExpenses_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PowerExpenses_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void PowerExpenses_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void PowerExpenses_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void GoToLocation_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.com/maps/search/?api=1&query=" + LocationLatitude_TextBox.Text + "," + LocationLongtitude_TextBox.Text + "");
        }

        private void GoToFamily_Button_Click_1(object sender, EventArgs e)
        {
            try
            {
                //int Family_ID = -1;
                //if (LivingWithCode_ComboBox.SelectedValue != null)
                //{
                //    Family_ID = int.Parse(LivingWithCode_ComboBox.SelectedValue.ToString());
                //    if (Program.Check_Opened("Family", Family_ID))
                //    {
                //        MessageBox.Show("لا يمكن فتح صفحة العائلة نفسها أكثر من مرة");
                //    }
                //    else
                //    {
                //        Form Family_Form = new Family_Form(Family_ID, main_form, false);
                //        main_form.showNewTab(Family_Form, "Family");
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("الرجاء إدخال رمز العائلة أولاً");
                //}

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    LivingWithCode_ComboBox.SelectedIndex = -1;
            //    LivingWithCode_ComboBox.Text = "";
            //    Living_Information_IsDirty = true;
            //    LivingWithNote2_TextBox.Visible = LivingWithNote2_Label.Visible = LivingWith2_Label.Visible = LivingWithCode2_ComboBox.Visible = pictureBox1.Visible = GoToFamily2_Button.Visible = false;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void GoToFamily2_Button_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int Family_ID = -1;
            //    if (LivingWithCode2_ComboBox.SelectedValue != null)
            //    {
            //        Family_ID = int.Parse(LivingWithCode2_ComboBox.SelectedValue.ToString());
            //        if (Program.Check_Opened("Family", Family_ID))
            //        {
            //            MessageBox.Show("لا يمكن فتح صفحة العائلة نفسها أكثر من مرة");
            //        }
            //        else
            //        {
            //            Form Family_Form = new Family_Form(Family_ID, main_form, false);
            //            main_form.showNewTab(Family_Form, "Family");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("الرجاء إدخال رمز العائلة أولاً");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void Address_TextBox_Enter_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    LivingWithCode2_ComboBox.SelectedIndex = -1;
            //    LivingWithCode2_ComboBox.Text = "";
            //    Living_Information_IsDirty = true;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void Yes_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Yes_RadioButton.Checked)
                    {
                        //LivingWithNote_TextBox.Visible = LivingWithNote_Label.Visible = LivingWith_Label.Visible = LivingWithCode_ComboBox.Visible = pictureBox2.Visible = GoToFamily_Button.Visible = true;
                        LivingWith_DataGridView_IsDirty = true;
                        LivingWith_DataGridView.ReadOnly = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void No_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (No_RadioButton.Checked)
                    {
                        LivingWith_DataGridView.ReadOnly = true;
                        for (int i = 0; i < LivingWith_DataGridView.Rows.Count - 1; i++)
                        {
                            int LivingWithID = LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_ID"].Value == null ? -1 : int.Parse(LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_ID"].Value.ToString());
                            int LivingCode = int.Parse(LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Code"].Value.ToString()) == null ? -1 : int.Parse(LivingWith_DataGridView.Rows[i].Cells["Family_livingWith_Code"].Value.ToString());
                            string Family_LivingWith_Note = LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_Note"].Value == null ? "" : LivingWith_DataGridView.Rows[i].Cells["Family_LivingWith_Note"].Value.ToString();
                            f.Delete_LivingWith(LivingCode, Family_LivingWith_Note, this.Name);
                        }
                        LivingWith_DataGridView.Rows.Clear();
                        LivingWith_DataGridView_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }




        private void Electricity_Yes_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Electricity_Yes_RadioButton.Checked)
                    {
                        ElectricityNote_TextBox.Visible = ElectricityNote_Lable.Visible = false;
                        ElectricityNote_TextBox.Clear();
                        Lighting_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Electricity_No_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Electricity_No_RadioButton.Checked)
                    {
                        ElectricityNote_TextBox.Visible = ElectricityNote_Lable.Visible = true;
                        Lighting_Information_IsDirty = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        #endregion

        #region //Visit_Data
        string VisitReason, VisitDate, Story, Link1, Link2, Link3;
        int VisitState;

        //string Team_Query;
        #endregion

        #region //Visit_Original
        string VisitReason_TextBox_OriginalText, Story_TextBox_OriginalText;
        #endregion

        private void Visits_TabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                if (Family_ID == -1)
                {
                    MessageBox.Show("الرجاء إدخال وحفظ معلومات العائلة أولاً", "Error");
                    materialTabControl1.SelectedTab = Family_TabPage;
                    return;
                }
                else if (CurrentFamilyVisitState == "رفض" || CurrentFamilyVisitState == "لن يزار")
                {
                    MessageBox.Show("لا يمكن ادخال او تعديل زيارت العائلة في حالة كان حالة الزيارة (رفض) أو (لن يزار)" + Environment.NewLine + "قم بتغيير حالة الزيارة إلى (لم يزر بعد) أولاً ثم حاول مجدداً", "Error");
                    materialTabControl1.SelectedTab = Family_TabPage;
                    return;
                }
                materialTabControl1.Size = new Size(this.Width - 20, 800);

                Details_Panel.Hide();
                Bind_Visits("All");
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم هذه الصفحة بسبب الخطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }
        private void Visits_TabPage_Leave(object sender, EventArgs e)
        {
            if (Visit_Details_IsDirty)
            {
                if (MessageBox.Show("يوجد بعض التعديلات غير المحفوظة، هل تود حفظها قبل مغادرة هذه الصفحة؟؟", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    UpdateWithFill = false;
                    VisitUpdate_Button.PerformClick();
                    UpdateWithFill = true;
                }
                else
                {
                    Visit_Set_Controls();
                }
            }

        }
        private void Bind_Visits(string Visit_Type)
        {
            UserMode = false;

            DataSet ds = v.Get_Family_Visits(Family_ID, Visit_Type);
            DataTable ME_dt = null, Story_dt = null, Video_dt = null, Followup_dt = null, Team_dt = null;

            if (Visit_Type == "All")
            {
                ME_dt = ds.Tables[0];
                Story_dt = ds.Tables[1];
                Video_dt = ds.Tables[2];
                Followup_dt = ds.Tables[3];
                //Team_dt = ds.Tables[4];
            }
            else
            {
                if (Visit_Type == "ME")
                {
                    if (ds.Tables[0].Rows.Count != 0)
                        ME_dt = ds.Tables[0];
                    else
                    {
                        ME_dt = null;
                        ME_DataGridView.Rows.Clear();
                        secondtableLayoutPanel.Visible = false;
                    }
                    //Team_dt = ds.Tables[1];
                }
                else if (Visit_Type == "Story")
                {
                    Story_dt = ds.Tables[0];
                    //Team_dt = ds.Tables[1];
                }
                else if (Visit_Type == "Video")
                {
                    Video_dt = ds.Tables[0];
                    //Team_dt = ds.Tables[1];
                }
                else if (Visit_Type == "Followup")
                {
                    Followup_dt = ds.Tables[0];
                    //Team_dt = ds.Tables[1];
                }
            }

            if (ME_dt != null)
            {
                ME_DataGridView.Rows.Clear();

                foreach (DataGridViewColumn c in ME_DataGridView.Columns)
                {
                    if (c.Name == "ME_Name")
                        c.ReadOnly = true;
                }
                for (int i = 0; i < ME_dt.Rows.Count; i++)
                {
                    ME_DataGridView.Rows.Add();
                    ME_DataGridView.Rows[i].Cells["ME_Family_Visit_ID"].Value = ME_dt.Rows[i].Field<int>("id");
                    ME_DataGridView.Rows[i].Cells["ME_Name"].Value = ME_dt.Rows[i].Field<string>("visit_name");
                    if (ME_dt.Rows[i]["Scedualed_Visit_date"] != DBNull.Value)
                    {
                        DateTime Date1 = DateTime.Parse(ME_dt.Rows[i].Field<DateTime>("Scedualed_Visit_date").ToString(), CultureInfo.CurrentCulture);
                        ME_DataGridView.Rows[i].Cells["ME_Scedualed_Date"].Value = Date1.ToShortDateString();
                    }
                    if (ME_dt.Rows[i]["Visit_date"] != DBNull.Value)
                    {
                        DateTime Date2 = DateTime.Parse(ME_dt.Rows[i].Field<DateTime>("Visit_date").ToString(), CultureInfo.CurrentCulture);
                        ME_DataGridView.Rows[i].Cells["ME_Date"].Value = Date2.ToShortDateString();
                    }
                    ME_DataGridView.Rows[i].Cells["ME_State"].Value = ME_dt.Rows[i].Field<int>("visitstate_id");
                    ME_DataGridView.Rows[i].Cells["ME_Reason"].Value = ME_dt.Rows[i].Field<string>("canceled_reason");
                    ME_DataGridView.Rows[i].Cells["ME_Story"].Value = ME_dt.Rows[i].Field<string>("story");
                    ME_DataGridView.Rows[i].Cells["ME_Link1"].Value = ME_dt.Rows[i].Field<string>("link1");
                    ME_DataGridView.Rows[i].Cells["ME_Link2"].Value = ME_dt.Rows[i].Field<string>("link2");
                    ME_DataGridView.Rows[i].Cells["ME_Link3"].Value = ME_dt.Rows[i].Field<string>("link3");

                    //ME_DataGridView.Rows[i].Cells["ME_Visit_Team"].Value = ME_dt.Rows[i].Field<string>("visit_team");

                }
            }

            if (Story_dt != null)
            {
                Story_DataGridView.Rows.Clear();
                foreach (DataGridViewColumn c in Story_DataGridView.Columns)
                {
                    if (c.Name != "Story_Scedualed_Date")
                        c.ReadOnly = true;
                }
                for (int i = 0; i < Story_dt.Rows.Count; i++)
                {
                    Story_DataGridView.Rows.Add();
                    Story_DataGridView.Rows[i].Cells["Story_Family_Visit_ID"].Value = Story_dt.Rows[i].Field<int>("id");
                    Story_DataGridView.Rows[i].Cells["Story_Name"].Value = Story_dt.Rows[i].Field<string>("visit_name");
                    if (Story_dt.Rows[i]["Scedualed_Visit_date"] != DBNull.Value)
                    {
                        DateTime Date1 = DateTime.Parse(Story_dt.Rows[i].Field<DateTime>("Scedualed_Visit_date").ToString(), CultureInfo.CurrentCulture);
                        Story_DataGridView.Rows[i].Cells["Story_Scedualed_Date"].Value = Date1.ToShortDateString();
                    }
                    Story_DataGridView.Rows[i].Cells["Story_State"].Value = Story_dt.Rows[i].Field<int?>("visitstate");
                    Story_DataGridView.Rows[i].Cells["Story_Visitor1_ID"].Value = Story_dt.Rows[i].Field<int?>("visitor1_id");
                    Story_DataGridView.Rows[i].Cells["Story_Visitor2_ID"].Value = Story_dt.Rows[i].Field<int?>("visitor2_id");
                    Story_DataGridView.Rows[i].Cells["Story_Canceled_Reason"].Value = Story_dt.Rows[i].Field<string>("canceled_reason");
                    Story_DataGridView.Rows[i].Cells["Story_Story"].Value = Story_dt.Rows[i].Field<string>("story");
                    Story_DataGridView.Rows[i].Cells["Story_Link1"].Value = Story_dt.Rows[i].Field<string>("link1");
                    Story_DataGridView.Rows[i].Cells["Story_Link2"].Value = Story_dt.Rows[i].Field<string>("link2");
                    Story_DataGridView.Rows[i].Cells["Story_Link3"].Value = Story_dt.Rows[i].Field<string>("link3");
                    if (Story_dt.Rows[i]["Visit_date"] != DBNull.Value)
                    {
                        DateTime Date1 = DateTime.Parse(Story_dt.Rows[i].Field<DateTime>("Visit_date").ToString(), CultureInfo.CurrentCulture);
                        Story_DataGridView.Rows[i].Cells["Story_Visit_Date"].Value = Date1.ToShortDateString();
                    }
                    //Story_DataGridView.Rows[i].Cells["Story_Visit_Team"].Value = Story_dt.Rows[i].Field<string>("visit_team");
                }
            }

            if (Video_dt != null)
            {
                Video_DataGridView.Rows.Clear();
                foreach (DataGridViewColumn c in Video_DataGridView.Columns)
                {
                    if (c.Name != "Video_Scedualed_Date")
                        c.ReadOnly = true;
                }
                for (int i = 0; i < Video_dt.Rows.Count; i++)
                {
                    Video_DataGridView.Rows.Add();
                    Video_DataGridView.Rows[i].Cells["Video_Family_Visit_ID"].Value = Video_dt.Rows[i].Field<int>("id");
                    Video_DataGridView.Rows[i].Cells["Video_Name"].Value = Video_dt.Rows[i].Field<string>("visit_name");
                    if (Video_dt.Rows[i]["Scedualed_Visit_date"] != DBNull.Value)
                    {
                        DateTime Date1 = DateTime.Parse(Video_dt.Rows[i].Field<DateTime>("Scedualed_Visit_date").ToString(), CultureInfo.CurrentCulture);
                        Video_DataGridView.Rows[i].Cells["Video_Scedualed_Date"].Value = Date1.ToShortDateString();
                    }
                    Video_DataGridView.Rows[i].Cells["Video_State"].Value = Video_dt.Rows[i].Field<int?>("visitstate");
                    Video_DataGridView.Rows[i].Cells["Video_Canceled_Reason"].Value = Video_dt.Rows[i].Field<string>("canceled_reason");
                    Video_DataGridView.Rows[i].Cells["Video_Visitor1_ID"].Value = Video_dt.Rows[i].Field<int?>("visitor1_id");
                    Video_DataGridView.Rows[i].Cells["Video_Visitor2_ID"].Value = Video_dt.Rows[i].Field<int?>("visitor2_id");
                    Video_DataGridView.Rows[i].Cells["Video_Story"].Value = Video_dt.Rows[i].Field<string>("story");
                    Video_DataGridView.Rows[i].Cells["Video_Link1"].Value = Video_dt.Rows[i].Field<string>("link1");
                    Video_DataGridView.Rows[i].Cells["Video_Link2"].Value = Video_dt.Rows[i].Field<string>("link2");
                    Video_DataGridView.Rows[i].Cells["Video_Link3"].Value = Video_dt.Rows[i].Field<string>("link3");
                    if (Video_dt.Rows[i]["Visit_date"] != DBNull.Value)
                    {
                        DateTime Date1 = DateTime.Parse(Video_dt.Rows[i].Field<DateTime>("Visit_date").ToString(), CultureInfo.CurrentCulture);
                        Video_DataGridView.Rows[i].Cells["Video_Visit_Date"].Value = Date1.ToShortDateString();
                    }
                    //Video_DataGridView.Rows[i].Cells["Video_Visit_Team"].Value = Video_dt.Rows[i].Field<string>("visit_team");
                }
            }

            if (Followup_dt != null)
            {
                Followup_DataGridView.Rows.Clear();

                foreach (DataGridViewColumn c in Followup_DataGridView.Columns)
                {
                    if (c.Name != "Followup_Scedualed_Date")
                        c.ReadOnly = true;
                }
                for (int i = 0; i < Followup_dt.Rows.Count; i++)
                {
                    Followup_DataGridView.Rows.Add();
                    Followup_DataGridView.Rows[i].Cells["Followup_Family_Visit_ID"].Value = Followup_dt.Rows[i].Field<int>("id");
                    Followup_DataGridView.Rows[i].Cells["Followup_Name"].Value = Followup_dt.Rows[i].Field<string>("visit_name");
                    if (Followup_dt.Rows[i]["Scedualed_Visit_date"] != DBNull.Value)
                    {
                        DateTime Date1 = DateTime.Parse(Followup_dt.Rows[i].Field<DateTime>("Scedualed_Visit_date").ToString(), CultureInfo.CurrentCulture);
                        Followup_DataGridView.Rows[i].Cells["Followup_Scedualed_Date"].Value = Date1.ToShortDateString();
                    }
                    Followup_DataGridView.Rows[i].Cells["Followup_State"].Value = Followup_dt.Rows[i].Field<int?>("visitstate");
                    Followup_DataGridView.Rows[i].Cells["Followup_Visitor1_ID"].Value = Followup_dt.Rows[i].Field<int?>("visitor1_id");
                    Followup_DataGridView.Rows[i].Cells["Followup_Visitor2_ID"].Value = Followup_dt.Rows[i].Field<int?>("visitor2_id");
                    Followup_DataGridView.Rows[i].Cells["Followup_Canceled_Reason"].Value = Followup_dt.Rows[i].Field<string>("canceled_reason");
                    Followup_DataGridView.Rows[i].Cells["Followup_Story"].Value = Followup_dt.Rows[i].Field<string>("story");
                    Followup_DataGridView.Rows[i].Cells["Followup_Link1"].Value = Followup_dt.Rows[i].Field<string>("link1");
                    Followup_DataGridView.Rows[i].Cells["Followup_Link2"].Value = Followup_dt.Rows[i].Field<string>("link2");
                    Followup_DataGridView.Rows[i].Cells["Followup_Link3"].Value = Followup_dt.Rows[i].Field<string>("link3");
                    if (Followup_dt.Rows[i]["Visit_date"] != DBNull.Value)
                    {
                        DateTime Date1 = DateTime.Parse(Followup_dt.Rows[i].Field<DateTime>("Visit_date").ToString(), CultureInfo.CurrentCulture);
                        Followup_DataGridView.Rows[i].Cells["Followup_Visit_Date"].Value = Date1.ToShortDateString();
                    }
                    //Followup_DataGridView.Rows[i].Cells["Followup_Visit_Team"].Value = Followup_dt.Rows[i].Field<string>("visit_team");
                }
            }

            DatePicker1 = new DateTimePicker();
            DatePicker1.ShowUpDown = false;
            DatePicker1.Format = DateTimePickerFormat.Short;
            DatePicker1.Visible = false;
            Rectangle oRectangle1 = ME_DataGridView.GetCellDisplayRectangle(3, 0, true);
            DatePicker1.Size = new Size(oRectangle1.Width, oRectangle1.Height);
            DatePicker1.Location = new Point(oRectangle1.X, oRectangle1.Y);
            DatePicker1.RightToLeftLayout = true;
            ME_DataGridView.Controls.Add(DatePicker1);
            DatePicker1.Leave += this.DatePickerChange1;

            DatePicker2 = new DateTimePicker();
            DatePicker2.ShowUpDown = false;
            DatePicker2.Format = DateTimePickerFormat.Short;
            DatePicker2.Visible = false;
            Rectangle oRectangle2 = Story_DataGridView.GetCellDisplayRectangle(3, 0, true);
            DatePicker2.Size = new Size(oRectangle2.Width, oRectangle2.Height);
            DatePicker2.Location = new Point(oRectangle2.X, oRectangle2.Y);
            DatePicker2.RightToLeftLayout = true;
            Story_DataGridView.Controls.Add(DatePicker2);
            DatePicker2.Leave += this.DatePickerChange2;

            DatePicker3 = new DateTimePicker();
            DatePicker3.ShowUpDown = false;
            DatePicker3.Format = DateTimePickerFormat.Short;
            DatePicker3.Visible = false;
            Rectangle oRectangle3 = Video_DataGridView.GetCellDisplayRectangle(3, 0, true);
            DatePicker3.Size = new Size(oRectangle3.Width, oRectangle3.Height);
            DatePicker3.Location = new Point(oRectangle3.X, oRectangle3.Y);
            DatePicker3.RightToLeftLayout = true;
            Video_DataGridView.Controls.Add(DatePicker3);
            DatePicker3.Leave += this.DatePickerChange3;

            DatePicker4 = new DateTimePicker();
            DatePicker4.ShowUpDown = false;
            DatePicker4.Format = DateTimePickerFormat.Short;
            DatePicker4.Visible = false;
            Rectangle oRectangle4 = Followup_DataGridView.GetCellDisplayRectangle(3, 0, true);
            DatePicker4.Size = new Size(oRectangle4.Width, oRectangle4.Height);
            DatePicker4.Location = new Point(oRectangle4.X, oRectangle4.Y);
            DatePicker4.RightToLeftLayout = true;
            Followup_DataGridView.Controls.Add(DatePicker4);
            DatePicker4.Leave += this.DatePickerChange4;

            DatePicker5 = new DateTimePicker();
            DatePicker5.ShowUpDown = false;
            DatePicker5.Format = DateTimePickerFormat.Short;
            DatePicker5.Visible = false;
            Rectangle oRectangle5 = ME_DataGridView.GetCellDisplayRectangle(3, 0, true);
            DatePicker5.Size = new Size(oRectangle5.Width, oRectangle5.Height);
            DatePicker5.Location = new Point(oRectangle5.X, oRectangle5.Y);
            DatePicker5.RightToLeftLayout = true;
            ME_DataGridView.Controls.Add(DatePicker5);
            DatePicker5.Leave += this.DatePickerChange5;

            MEReason = new TextBox();
            MEReason.Visible = false;
            Rectangle oRectangle6 = ME_DataGridView.GetCellDisplayRectangle(3, 0, true);
            MEReason.Size = new Size(oRectangle6.Width, oRectangle6.Height);
            MEReason.Location = new Point(oRectangle6.X, oRectangle6.Y);
            ME_DataGridView.Controls.Add(MEReason);
            MEReason.Leave += this.MEReasonChange;


            //VisitTeam_CheckedListBox.DataSource = Team_dt;
            //VisitTeam_CheckedListBox.DisplayMember = "name";
            //VisitTeam_CheckedListBox.ValueMember = "id";

            //IsDirty_VisitTeam_CheckedListBox.DataSource = Team_dt;
            //IsDirty_VisitTeam_CheckedListBox.DisplayMember = "name";
            //IsDirty_VisitTeam_CheckedListBox.ValueMember = "id";

            UserMode = true;
        }
        private void Visit_Set_Controls()
        {
            Visit_Details_IsDirty = Team_IsDirty = false;
            VisitReason = VisitDate = Story = Link1 = Link2 = Link3 = "";
            VisitState = 0;
            VisitReason_TextBox_OriginalText = Story_TextBox_OriginalText = "";
            Visitor1 = Visitor2 = 0;
            UpdateWithFill = true;
        }
        private void Show_Hide_Controls()
        {
            VisitReason_Label.Visible = VisitReason_TextBox.Visible = false;
            VisitDate_Label.Visible = VisitDate_DatePicker.Visible = VisitTeam_Label.Visible = Visitor1_comboBox.Visible = Visitor2_comboBox.Visible = false;

            VisitFiles_Label.Visible = File1_Label.Visible = File1_Add_Buttom.Visible = File1_linkLabel.Visible =
                File2_Label.Visible = File2_Add_Buttom.Visible = File2_linkLabel.Visible =
                File3_Label.Visible = File3_Add_Buttom.Visible = File3_linkLabel.Visible =
                Story_Label.Visible = Story_TextBox.Visible = false;

            if (VisitCanceled_RadioButton.Checked)
            {
                VisitReason_Label.Visible = VisitReason_TextBox.Visible = true;
            }

            if (VisitDone_RadioButton.Checked)
            {
                VisitDate_Label.Visible = VisitDate_DatePicker.Visible = VisitTeam_Label.Visible = Visitor1_comboBox.Visible = Visitor2_comboBox.Visible = true;

                switch (Selected_Visit_Type)
                {
                    case "ME":

                        break;

                    case "Story":
                        VisitFiles_Label.Visible = File1_Label.Visible = File1_Add_Buttom.Visible = File1_linkLabel.Visible =
                            File2_Label.Visible = File2_Add_Buttom.Visible = File2_linkLabel.Visible =
                            File3_Label.Visible = File3_Add_Buttom.Visible = File3_linkLabel.Visible =
                            Story_Label.Visible = Story_TextBox.Visible = true;
                        break;

                    case "Video":
                        VisitFiles_Label.Visible = File1_Label.Visible = File1_Add_Buttom.Visible = File1_linkLabel.Visible = true;
                        break;

                    case "Followup":
                        break;
                }
            }
        }
        private void Visit_Clear_Boxes()
        {
            //UserMode = false;
            VisitScedualed_RadioButton.Checked = VisitCanceled_RadioButton.Checked = VisitDone_RadioButton.Checked = false;
            VisitReason_TextBox.Clear();

            VisitDate_DatePicker.CustomFormat = " ";
            VisitDate_DatePicker.Format = DateTimePickerFormat.Custom;
            Visitor1_comboBox.SelectedIndex = 0;
            Visitor2_comboBox.SelectedIndex = 0;

            //foreach (int i in VisitTeam_CheckedListBox.CheckedIndices)
            //{
            //    VisitTeam_CheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
            //}
            //foreach (int i in IsDirty_VisitTeam_CheckedListBox.CheckedIndices)
            //{
            //    IsDirty_VisitTeam_CheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
            //}
            Story_TextBox.Clear();
            File1_linkLabel.Links.Clear(); File2_linkLabel.Links.Clear(); File3_linkLabel.Links.Clear();

            //UserMode = true;
        }
        private void DatePickerChange4(object sender, EventArgs e)
        {
            try
            {
                DateTime Date = DateTime.Parse(DatePicker4.Value.ToString(), CultureInfo.CurrentCulture);
                Followup_DataGridView.Rows[BeginEdit_RowIndex].Cells[BeginEdit_ColumnIndex].Value = Date.ToShortDateString();
                DatePicker4.Visible = false;
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void DatePickerChange5(object sender, EventArgs e)
        {
            try
            {
                DateTime Date = DateTime.Parse(DatePicker5.Value.ToString(), CultureInfo.CurrentCulture);
                ME_DataGridView.Rows[BeginEdit_RowIndex].Cells[BeginEdit_ColumnIndex].Value = Date.ToShortDateString();
                DatePicker5.Visible = false;
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void MEReasonChange(object sender, EventArgs e)
        {
            try
            {
                ME_DataGridView.Rows[BeginEdit_RowIndex].Cells[BeginEdit_ColumnIndex].Value = MEReason;
                MEReason.Visible = false;
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void DatePickerChange3(object sender, EventArgs e)
        {
            try
            {
                DateTime Date = DateTime.Parse(DatePicker3.Value.ToString(), CultureInfo.CurrentCulture);
                Video_DataGridView.Rows[BeginEdit_RowIndex].Cells[BeginEdit_ColumnIndex].Value = Date.ToShortDateString();
                DatePicker3.Visible = false;
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void DatePickerChange2(object sender, EventArgs e)
        {
            try
            {
                DateTime Date = DateTime.Parse(DatePicker2.Value.ToString(), CultureInfo.CurrentCulture);
                Story_DataGridView.Rows[BeginEdit_RowIndex].Cells[BeginEdit_ColumnIndex].Value = Date.ToShortDateString();
                DatePicker2.Visible = false;
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }
        private void DatePickerChange1(object sender, EventArgs e)
        {
            try
            {
                DateTime Date = DateTime.Parse(DatePicker1.Value.ToString(), CultureInfo.CurrentCulture);
                ME_DataGridView.Rows[BeginEdit_RowIndex].Cells[BeginEdit_ColumnIndex].Value = Date.ToShortDateString();
                DatePicker1.Visible = false;
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        #region datagrid functions
        private void ME_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == ME_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == ME_DataGridView.Columns["ME_Delete"].Index)
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
                foreach (DataGridViewRow R in ME_DataGridView.Rows)
                {
                    if (Convert.ToInt64(R.Cells["ME_State"].Value) == 2 || Convert.ToInt64(R.Cells["ME_State"].Value) == 4)
                    {

                        ME_State.FlatStyle = FlatStyle.Flat;
                        R.Cells["ME_State"].Style.BackColor = Color.Red; //Color.FromArgb(125, 0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void ME_DataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Added By Mai
            try
            {
                UserMode = false;
                Selected_Row_Index = e.RowIndex;
                Selected_Family_Visit_ID = -1;

                if (ME_DataGridView.Rows[e.RowIndex].Cells["ME_Family_Visit_ID"].Value != null && ME_DataGridView.Rows[e.RowIndex].Cells["ME_Family_Visit_ID"].Value != DBNull.Value)
                    Selected_Family_Visit_ID = int.Parse(ME_DataGridView.Rows[e.RowIndex].Cells["ME_Family_Visit_ID"].Value.ToString());
                
                if(ME_DataGridView.Rows[e.RowIndex].Cells["ME_State"].Value != null && ME_DataGridView.Rows[e.RowIndex].Cells["ME_State"].Value != DBNull.Value)
                    Selected_Family_Visitstate = int.Parse(ME_DataGridView.Rows[e.RowIndex].Cells["ME_State"].Value.ToString());

                if (Selected_Family_Visit_ID != -1)
                {
                    Visit_ID = Selected_Family_Visit_ID;
                    if (Selected_Family_Visitstate == 1)
                    {
                        MessageBox.Show("الرجاء إدخال تاريخ الزيارة أولاً ليتم ملء المعلومات");
                        Bind_Visits("ME");
                    }
                    else if (Selected_Family_Visitstate == 2 || Selected_Family_Visitstate == 4)
                    {
                        MessageBox.Show("الزيارة الملغاة ليس لديها معلومات");
                        secondtableLayoutPanel.Visible = false;
                    }
                    else
                    {
                        Fill_Family(false, Selected_Family_Visit_ID);
                        secondtableLayoutPanel.Visible = true;
                    }
                }
                UserMode = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void ME_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    //if click is on new row or header row
                    if (e.RowIndex < 0 || e.ColumnIndex < 0)
                        return;

                    //if (ME_DataGridView.Columns[e.ColumnIndex].Name == "ME_Scedualed_Date")
                    //{
                    if (ME_DataGridView.Columns[e.ColumnIndex].Name == "ME_Scedualed_Date")
                    {
                        DatePicker1 = new DateTimePicker();
                        DatePicker1.ShowUpDown = false;
                        DatePicker1.Format = DateTimePickerFormat.Short;
                        DatePicker1.Visible = true;
                        Rectangle oRectangle1 = ME_DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                        DatePicker1.Size = new Size(oRectangle1.Width, oRectangle1.Height);
                        DatePicker1.Location = new Point(oRectangle1.X, oRectangle1.Y);
                        DatePicker1.RightToLeftLayout = true;
                        ME_DataGridView.Controls.Add(DatePicker1);
                        DatePicker1.Leave += this.DatePickerChange1;
                    }

                    if (ME_DataGridView.Columns[e.ColumnIndex].Name == "ME_Date")
                    {
                        DatePicker5 = new DateTimePicker();
                        DatePicker5.ShowUpDown = false;
                        DatePicker5.Format = DateTimePickerFormat.Short;
                        DatePicker5.Visible = true;
                        Rectangle oRectangle5 = ME_DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                        DatePicker5.Size = new Size(oRectangle5.Width, oRectangle5.Height);
                        DatePicker5.Location = new Point(oRectangle5.X, oRectangle5.Y);
                        DatePicker5.RightToLeftLayout = true;
                        ME_DataGridView.Controls.Add(DatePicker5);
                        DatePicker5.Leave += this.DatePickerChange5;
                    }

                    DatePicker2 = new DateTimePicker();
                    DatePicker2.ShowUpDown = false;
                    DatePicker2.Format = DateTimePickerFormat.Short;
                    DatePicker2.Visible = false;
                    Rectangle oRectangle2 = Story_DataGridView.GetCellDisplayRectangle(3, 0, true);
                    DatePicker2.Size = new Size(oRectangle2.Width, oRectangle2.Height);
                    DatePicker2.Location = new Point(oRectangle2.X, oRectangle2.Y);
                    DatePicker2.RightToLeftLayout = true;
                    Story_DataGridView.Controls.Add(DatePicker2);
                    DatePicker2.Leave += this.DatePickerChange2;

                    DatePicker3 = new DateTimePicker();
                    DatePicker3.ShowUpDown = false;
                    DatePicker3.Format = DateTimePickerFormat.Short;
                    DatePicker3.Visible = false;
                    Rectangle oRectangle3 = Video_DataGridView.GetCellDisplayRectangle(3, 0, true);
                    DatePicker3.Size = new Size(oRectangle3.Width, oRectangle3.Height);
                    DatePicker3.Location = new Point(oRectangle3.X, oRectangle3.Y);
                    DatePicker3.RightToLeftLayout = true;
                    Video_DataGridView.Controls.Add(DatePicker3);
                    DatePicker3.Leave += this.DatePickerChange3;

                    DatePicker4 = new DateTimePicker();
                    DatePicker4.ShowUpDown = false;
                    DatePicker4.Format = DateTimePickerFormat.Short;
                    DatePicker4.Visible = false;
                    Rectangle oRectangle4 = Followup_DataGridView.GetCellDisplayRectangle(3, 0, true);
                    DatePicker4.Size = new Size(oRectangle4.Width, oRectangle4.Height);
                    DatePicker4.Location = new Point(oRectangle4.X, oRectangle4.Y);
                    DatePicker4.RightToLeftLayout = true;
                    Followup_DataGridView.Controls.Add(DatePicker4);
                    DatePicker4.Leave += this.DatePickerChange4;



                    //DatePicker1.Visible = false;
                    //DatePicker5.Visible = false;

                    if (ME_DataGridView.Rows[e.RowIndex].Cells["ME_Family_Visit_ID"].Value != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("تأكيد التعديل", "Warning", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            DatePicker1.Visible = false;
                            DatePicker5.Visible = false;
                            if (ME_DataGridView.Rows[e.RowIndex].Cells["ME_Scedualed_Date"].Value == null || string.IsNullOrWhiteSpace(ME_DataGridView.Rows[e.RowIndex].Cells["ME_Scedualed_Date"].Value.ToString()))
                            {
                                MessageBox.Show("لا يمكن ترك التاريخ أو الوقت فارغاً ", "Error");
                                return;
                            }
                            else
                            {
                                string UK_Date = "", UK_Date3 = "";
                                int Family_Visit_ID = int.Parse(ME_DataGridView.Rows[e.RowIndex].Cells["ME_Family_Visit_ID"].Value.ToString());
                                string Visit_Name = ME_DataGridView.Rows[e.RowIndex].Cells["ME_Name"].Value.ToString();
                                int Visit_State = int.Parse(ME_DataGridView.Rows[e.RowIndex].Cells["ME_State"].Value.ToString());
                                string ME_Scedualed_Date = ME_DataGridView.Rows[e.RowIndex].Cells["ME_Scedualed_Date"].Value == null ? "" : DateTime.Parse(ME_DataGridView.Rows[e.RowIndex].Cells["ME_Scedualed_Date"].Value.ToString()).ToString("yyyy-MM-dd");
                                string ME_Date = ME_DataGridView.Rows[e.RowIndex].Cells["ME_Date"].Value == null ? "" : DateTime.Parse(ME_DataGridView.Rows[e.RowIndex].Cells["ME_Date"].Value.ToString()).ToString("yyyy-MM-dd");

                                string reason = ME_DataGridView.Rows[e.RowIndex].Cells["ME_Reason"].Value == null ? "" : ME_DataGridView.Rows[e.RowIndex].Cells["ME_Reason"].Value.ToString();

                                //v.Update_Visite_Schedualed_Date(Family_Visit_ID, Visit_Name, UK_Date, UK_Date3, this.Name);
                                // سيتم استخدام هذا التابع مؤقتاً
                                //v.Update_Temporary_ME_Visit_Schedualed_Date(Family_Visit_ID, Family_ID, Visit_Name, UK_Date, this.Name);

                                //Added By Mai
                                if (Visit_State == 2 || Visit_State == 4)
                                {
                                    if (ME_Date != null)
                                    {
                                        MessageBox.Show("الزيارة الملغاة لا يمكن إدخال تاريخ زيارة لها");
                                        ME_Date = null;
                                        v.Update_ME_Visit(Family_Visit_ID, Family_ID, Visit_Name, Visit_State, ME_Scedualed_Date, ME_Date, reason, this.Name);
                                    }
                                }
                                else if (ME_Scedualed_Date != null)
                                {
                                    if (ME_Date == null)
                                    {
                                        MessageBox.Show("يجب إدخال تاريخ الزيارة أولاً");
                                    }
                                    else if (Convert.ToDateTime(ME_Date) < Convert.ToDateTime(ME_Scedualed_Date))
                                    {
                                        MessageBox.Show("لا يمكن أن يكون تاريخ الزيارة قبل تاريخ الجدولة");
                                    }
                                    //تمت
                                    else
                                    {
                                        v.Update_ME_Visit(Family_Visit_ID, Family_ID, Visit_Name, 3, ME_Scedualed_Date, ME_Date, reason, this.Name);
                                        secondtableLayoutPanel.Visible = true;
                                    }
                                }
                                else
                                {
                                    v.Update_ME_Visit(Family_Visit_ID, Family_ID, Visit_Name, 1, ME_Scedualed_Date, ME_Date, reason, this.Name);
                                }
                                MessageBox.Show("تم تعديل الزيارة بنجاح", "Confirmation");
                              
                            }
                        }
                    }
                    else
                    {
                        if (ME_DataGridView.Rows[e.RowIndex].Cells["ME_Scedualed_Date"].Value == null || string.IsNullOrWhiteSpace(ME_DataGridView.Rows[e.RowIndex].Cells["ME_Scedualed_Date"].Value.ToString()))
                        {
                            MessageBox.Show("لا يمكن ترك التاريخ أو الوقت فارغاً ", "Error");
                            return;
                        }
                        else
                        {
                            string Visit_Name = ME_DataGridView.Rows[e.RowIndex].Cells["ME_Name"].Value.ToString();
                            DateTime Date2 = DateTime.Parse(ME_DataGridView.Rows[e.RowIndex].Cells["ME_Scedualed_Date"].Value.ToString());
                            string UK_Date = Date2.ToString("yyyy-MM-dd");
                            string UK_Date2 = "";
                            if (ME_DataGridView.Rows[e.RowIndex].Cells["ME_Date"].Value != null)
                            {
                                DateTime Date3 = DateTime.Parse(ME_DataGridView.Rows[e.RowIndex].Cells["ME_Date"].Value.ToString());
                                UK_Date2 = Date3.ToString("yyyy-MM-dd");
                            }
                            v.Insert_Visit(Family_ID, "M&E", Visit_Name, "مجدولة", UK_Date, UK_Date2, this.Name);

                            // سيتم استخدام هذا التابع مؤقتاً
                            //v.Insert_Temporary_ME_Visit(Family_ID, "M&E", Visit_Name, "تمت", UK_Date, this.Name);
                            MessageBox.Show("تم إدخال زيارة جديدة بنجاح", "Confirmation");
                            
                        }
                    }
                    DatePicker1.Visible = false;
                    DatePicker5.Visible = false;
                    Bind_Visits("ME");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }  
        private void ME_DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(ME_DataGridView.Rows.Count-1 == 0)
            {
                ME_DataGridView.Rows.Add();
                ME_DataGridView.Rows[0].Cells["ME_Name"].Value = "M&E - 0";
                //MessageBox.Show("الرجاء إدخال الزيارات السابقة التي لم تتم !!");

                //if (ME_DataGridView.Columns[e.ColumnIndex].Name == "ME_Scedualed_Date")
                //{
                //    DatePicker1 = new DateTimePicker();
                //    DatePicker1.ShowUpDown = false;
                //    DatePicker1.Format = DateTimePickerFormat.Short;
                //    DatePicker1.Visible = true;
                //    Rectangle oRectangle1 = ME_DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                //    DatePicker1.Size = new Size(oRectangle1.Width, oRectangle1.Height);
                //    DatePicker1.Location = new Point(oRectangle1.X, oRectangle1.Y);
                //    DatePicker1.RightToLeftLayout = true;
                //    ME_DataGridView.Controls.Add(DatePicker1);
                //    DatePicker1.Leave += this.DatePickerChange1;
                //}

                //if (ME_DataGridView.Columns[e.ColumnIndex].Name == "ME_Date")
                //{
                //    DatePicker5 = new DateTimePicker();
                //    DatePicker5.ShowUpDown = false;
                //    DatePicker5.Format = DateTimePickerFormat.Short;
                //    DatePicker5.Visible = true;
                //    Rectangle oRectangle5 = ME_DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                //    DatePicker5.Size = new Size(oRectangle5.Width, oRectangle5.Height);
                //    DatePicker5.Location = new Point(oRectangle5.X, oRectangle5.Y);
                //    DatePicker5.RightToLeftLayout = true;
                //    ME_DataGridView.Controls.Add(DatePicker5);
                //    DatePicker5.Leave += this.DatePickerChange5;
                //}
                if (ME_DataGridView.Columns[e.ColumnIndex].Name == "ME_Scedualed_Date")
                {
                    //DatePicker1.Location = ME_DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                    //DatePicker1.Visible = true;
                    if (ME_DataGridView.CurrentCell.Value != DBNull.Value && ME_DataGridView.CurrentCell.Value != null)
                    {
                        DateTime Date = DateTime.Parse(ME_DataGridView.CurrentCell.Value.ToString());
                        DatePicker1.Value = DateTime.Parse(Date.ToShortDateString(), CultureInfo.CurrentCulture);
                    }
                    else { }
                }
                //Added By Mai
                if (ME_DataGridView.Columns[e.ColumnIndex].Name == "ME_Date")
                {
                    DatePicker5.Location = ME_DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                    DatePicker5.Visible = true;
                    if (ME_DataGridView.CurrentCell.Value != DBNull.Value && ME_DataGridView.CurrentCell.Value != null)
                    {
                        DateTime Date = DateTime.Parse(ME_DataGridView.CurrentCell.Value.ToString());
                        DatePicker5.Value = DateTime.Parse(Date.ToShortDateString(), CultureInfo.CurrentCulture);

                    }
                    else
                    {

                    }
                }

            }
            else
            {
                if (ME_DataGridView.Columns[e.ColumnIndex].Name == "ME_Scedualed_Date")
                {
                    if (ME_DataGridView.Rows[e.RowIndex].Cells["ME_Family_Visit_ID"].Value == null)
                    {
                        int index = ME_DataGridView.Rows.Count - 2;
                            string visitname = ME_DataGridView.Rows[index].Cells["ME_Name"].Value.ToString();
                            int visitnumber = int.Parse(visitname[visitname.Length - 1].ToString());
                            int newvisitnumber = visitnumber + 1;
                            ME_DataGridView.Rows[e.RowIndex].Cells["ME_Name"].Value = "M&E - " + newvisitnumber;
                    }
                    BeginEdit_RowIndex = e.RowIndex; BeginEdit_ColumnIndex = e.ColumnIndex;
                     
                    if (ME_DataGridView.CurrentCell.Value != DBNull.Value && ME_DataGridView.CurrentCell.Value != null) 
                    {
                        DatePicker1.Location = ME_DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                        DatePicker1.Visible = true;
                        DateTime Date = DateTime.Parse(ME_DataGridView.CurrentCell.Value.ToString());
                        DatePicker1.Value = DateTime.Parse(Date.ToShortDateString(), CultureInfo.CurrentCulture);
                    }
                    else
                    {

                    }
                }
                //Added By Mai
                if (ME_DataGridView.Columns[e.ColumnIndex].Name == "ME_Date")
                {
                    if (ME_DataGridView.Rows[e.RowIndex].Cells["ME_Family_Visit_ID"].Value == null)
                     ME_DataGridView.Rows[e.RowIndex].Cells["ME_Name"].Value = "M&E - " + ME_DataGridView.Rows.Count.ToString();

                    if (ME_DataGridView.CurrentCell.Value != DBNull.Value && ME_DataGridView.CurrentCell.Value != null)
                    {
                        BeginEdit_RowIndex = e.RowIndex; BeginEdit_ColumnIndex = e.ColumnIndex;
                        DatePicker5.Location = ME_DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                        DatePicker5.Visible = true;
                        DateTime Date = DateTime.Parse(ME_DataGridView.CurrentCell.Value.ToString());
                        DatePicker5.Value = DateTime.Parse(Date.ToShortDateString(), CultureInfo.CurrentCulture);
                    }
                    else
                    {

                    }
                }
            }
            
            
            //if (ME_DataGridView.Columns[e.ColumnIndex].Name == "ME_Reason")
            //{
            //    if (ME_DataGridView.Rows[e.RowIndex].Cells["ME_Family_Visit_ID"].Value == null)
            //        ME_DataGridView.Rows[e.RowIndex].Cells["ME_Name"].Value = "M&E - " + ME_DataGridView.Rows.Count.ToString();
            //}
        }
        private void ME_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == ME_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;
                //Check if click is on specific column 
                if (e.ColumnIndex == ME_DataGridView.Columns["ME_Delete"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (ME_DataGridView.Rows[e.RowIndex].Cells["ME_Family_Visit_ID"].Value != null)
                        {
                            int Family_Visit_ID = int.Parse(ME_DataGridView.Rows[e.RowIndex].Cells["ME_Family_Visit_ID"].Value.ToString());
                            string Visit_Name = ME_DataGridView.Rows[e.RowIndex].Cells["ME_Name"].Value.ToString();
                            v.Delete_Visit(Family_Visit_ID, Family_ID, Visit_Name, this.Name);
                            MessageBox.Show("تم حذف الزيارة بنجاح", "Confirmation");
                            Bind_Visits("ME");
                            secondtableLayoutPanel.Visible = false;
                        }
                        else
                        {
                            ME_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("لا يمكن حذف الزيارة لوجود معلومات مرتبطة بها عند الأفراد والعائلة");
                //if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }       
        
        
        private void Story_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == Story_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == Story_DataGridView.Columns["Story_Delete"].Index)
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
        private void Story_DataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                UserMode = false;
                materialTabControl1.Size = new Size(this.Width - 20, 1100);

                Selected_Visit_Type = "Story";
                Selected_Row_Index = e.RowIndex;
                Selected_Family_Visit_ID = int.Parse(Story_DataGridView.Rows[e.RowIndex].Cells["Story_Family_Visit_ID"].Value.ToString());
                Selected_Visit_Name = Story_DataGridView.Rows[e.RowIndex].Cells["Story_Name"].Value.ToString();

                Visit_Clear_Boxes();

                //VisitName_Label.Text = Story_DataGridView.Rows[e.RowIndex].Cells["Story_Name"].Value.ToString();

                foreach (RadioButton RB in VisitState_LayoutPanel.Controls.OfType<RadioButton>())
                {
                    string story_state = "";
                    if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_State"].Value.ToString() == "3")
                        story_state = "تمت";
                    else if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_State"].Value.ToString() == "2")
                        story_state = "ملغاة";
                    else if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_State"].Value.ToString() == "1")
                        story_state = "مجدولة";
                    if (String.Equals(RB.Text, story_state))
                    {
                        RB.Checked = true;
                        break;
                    }
                }

                if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_Canceled_Reason"].Value != null)
                    VisitReason_TextBox.Text = Story_DataGridView.Rows[e.RowIndex].Cells["Story_Canceled_Reason"].Value.ToString();

                if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_Visitor1_ID"].Value != null)
                    Visitor1_comboBox.SelectedValue = int.Parse(Story_DataGridView.Rows[e.RowIndex].Cells["Story_Visitor1_ID"].Value.ToString());

                if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_Visitor2_ID"].Value != null)
                    Visitor2_comboBox.SelectedValue = int.Parse(Story_DataGridView.Rows[e.RowIndex].Cells["Story_Visitor2_ID"].Value.ToString());

                if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_Visit_Date"].Value == null)
                {
                    VisitDate_DatePicker.CustomFormat = " ";
                    VisitDate_DatePicker.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    VisitDate_DatePicker.CustomFormat = "yyyy-MM-dd";

                    DateTime Date1 = DateTime.Parse((Story_DataGridView.Rows[e.RowIndex].Cells["Story_Visit_Date"].Value).ToString(), CultureInfo.CurrentCulture);
                    VisitDate_DatePicker.Value = Date1;
                }

                if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_link1"].Value != null) File1_linkLabel.Links.Add(0, 5, Story_DataGridView.Rows[e.RowIndex].Cells["Story_link1"].Value.ToString());
                if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_link2"].Value != null) File2_linkLabel.Links.Add(0, 5, Story_DataGridView.Rows[e.RowIndex].Cells["Story_link2"].Value.ToString());
                if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_link3"].Value != null) File3_linkLabel.Links.Add(0, 5, Story_DataGridView.Rows[e.RowIndex].Cells["Story_link3"].Value.ToString());

                if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_Story"].Value != null) Story_TextBox.Text = Story_DataGridView.Rows[e.RowIndex].Cells["Story_Story"].Value.ToString();
                Visit_Set_Controls();
                Details_Panel.Show();
                UserMode = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void Story_DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (Story_DataGridView.Columns[e.ColumnIndex].Name == "Story_Scedualed_Date")
            {
                if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_Family_Visit_ID"].Value == null)
                    Story_DataGridView.Rows[e.RowIndex].Cells["Story_Name"].Value = "Story - " + Story_DataGridView.Rows.Count.ToString();

                BeginEdit_RowIndex = e.RowIndex; BeginEdit_ColumnIndex = e.ColumnIndex;
                DatePicker2.Location = Story_DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                DatePicker2.Visible = true;
                if (Story_DataGridView.CurrentCell.Value != DBNull.Value && Story_DataGridView.CurrentCell.Value != null)
                {
                    DateTime Date = DateTime.Parse(Story_DataGridView.CurrentCell.Value.ToString());
                    DatePicker2.Value = DateTime.Parse(Date.ToShortDateString(), CultureInfo.CurrentCulture);
                }
                else
                {

                }
            }
        }
        private void Story_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    //if click is on new row or header row
                    if (e.RowIndex < 0 || e.ColumnIndex < 0)
                        return;

                    if (Story_DataGridView.Columns[e.ColumnIndex].Name == "Story_Scedualed_Date")
                    {
                        DatePicker2.Visible = false;

                        if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_Family_Visit_ID"].Value != null)
                        {
                            DialogResult dialogResult = MessageBox.Show("تأكيد التعديل", "Warning", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_Scedualed_Date"].Value == null || string.IsNullOrWhiteSpace(Story_DataGridView.Rows[e.RowIndex].Cells["Story_Scedualed_Date"].Value.ToString()))
                                {
                                    MessageBox.Show("لا يمكن ترك التاريخ أو الوقت فارغاً ", "Error");
                                    return;
                                }
                                else
                                {
                                    int Family_Visit_ID = int.Parse(Story_DataGridView.Rows[e.RowIndex].Cells["Story_Family_Visit_ID"].Value.ToString());
                                    string Visit_Name = Story_DataGridView.Rows[e.RowIndex].Cells["Story_Name"].Value.ToString();
                                    DateTime Date2 = DateTime.Parse(Story_DataGridView.Rows[e.RowIndex].Cells["Story_Scedualed_Date"].Value.ToString());
                                    string UK_Date = Date2.ToString("yyyy-MM-dd", new CultureInfo("en-GB"));
                                    //v.Update_Visite_Schedualed_Date(Family_Visit_ID, Family_ID, Visit_Name, UK_Date, this.Name);
                                    MessageBox.Show("تم تعديل التاريخ بنجاح", "Confirmation");
                                }
                            }
                        }
                        else
                        {
                            if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_Scedualed_Date"].Value == null || string.IsNullOrWhiteSpace(Story_DataGridView.Rows[e.RowIndex].Cells["Story_Scedualed_Date"].Value.ToString()))
                            {
                                MessageBox.Show("لا يمكن ترك التاريخ أو الوقت فارغاً ", "Error");
                                return;
                            }
                            else
                            {
                                string Visit_Name = Story_DataGridView.Rows[e.RowIndex].Cells["Story_Name"].Value.ToString();
                                DateTime Date2 = DateTime.Parse(Story_DataGridView.Rows[e.RowIndex].Cells["Story_Scedualed_Date"].Value.ToString());
                                string UK_Date = Date2.ToString("yyyy-MM-dd", new CultureInfo("en-GB"));
                                v.Insert_Visit(Family_ID, "Story", Visit_Name, "مجدولة", UK_Date, "", this.Name);
                                MessageBox.Show("تم إدخال زيارة جديدة بنجاح", "Confirmation");
                            }
                        }
                        Bind_Visits("Story");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void Story_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == Story_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;
                //Check if click is on specific column 
                if (e.ColumnIndex == Story_DataGridView.Columns["Story_Delete"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Story_DataGridView.Rows[e.RowIndex].Cells["Story_Family_Visit_ID"].Value != null)
                        {
                            int Family_Visit_ID = int.Parse(Story_DataGridView.Rows[e.RowIndex].Cells["Story_Family_Visit_ID"].Value.ToString());
                            string Visit_Name = Story_DataGridView.Rows[e.RowIndex].Cells["Story_Name"].Value.ToString();
                            v.Delete_Visit(Family_Visit_ID, Family_ID, Visit_Name, this.Name);
                            MessageBox.Show("تم حذف الزيارة بنجاح", "Confirmation");

                            Bind_Visits("Story");
                            Details_Panel.Hide();
                        }
                        else
                        {
                            Story_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }        
        
        private void Video_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == Video_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == Video_DataGridView.Columns["Video_Delete"].Index)
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
        private void Video_DataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                UserMode = false;
                materialTabControl1.Size = new Size(this.Width - 20, 1100);
                Selected_Visit_Type = "Video";
                Selected_Row_Index = e.RowIndex;
                Selected_Family_Visit_ID = int.Parse(Video_DataGridView.Rows[e.RowIndex].Cells["Video_Family_Visit_ID"].Value.ToString());
                Selected_Visit_Name = Video_DataGridView.Rows[e.RowIndex].Cells["Video_Name"].Value.ToString();
                Visit_Clear_Boxes();

                //VisitName_Label.Text = Video_DataGridView.Rows[e.RowIndex].Cells["Video_Name"].Value.ToString();

                foreach (RadioButton RB in VisitState_LayoutPanel.Controls.OfType<RadioButton>())
                {
                    string video_state = "";
                    if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_State"].Value.ToString() == "3")
                        video_state = "تمت";
                    else if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_State"].Value.ToString() == "2")
                        video_state = "ملغاة";
                    else if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_State"].Value.ToString() == "1")
                        video_state = "مجدولة";
                    if (String.Equals(RB.Text, video_state))
                    {
                        RB.Checked = true;
                        break;
                    }
                }

                if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_Canceled_Reason"].Value != null)
                    VisitReason_TextBox.Text = Video_DataGridView.Rows[e.RowIndex].Cells["Video_Canceled_Reason"].Value.ToString();

                if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_Visit_Date"].Value == null)
                {
                    VisitDate_DatePicker.CustomFormat = " ";
                    VisitDate_DatePicker.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    VisitDate_DatePicker.CustomFormat = "yyyy-MM-dd";

                    DateTime Date1 = DateTime.Parse((Video_DataGridView.Rows[e.RowIndex].Cells["Video_Visit_Date"].Value).ToString(), CultureInfo.CurrentCulture);
                    VisitDate_DatePicker.Value = Date1;
                }

                if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_Visitor1_ID"].Value != null)
                    Visitor1_comboBox.SelectedValue = int.Parse(Video_DataGridView.Rows[e.RowIndex].Cells["Video_Visitor1_ID"].Value.ToString());

                if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_Visitor2_ID"].Value != null)
                    Visitor2_comboBox.SelectedValue = int.Parse(Video_DataGridView.Rows[e.RowIndex].Cells["Video_Visitor2_ID"].Value.ToString());
                if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_link1"].Value != null) File1_linkLabel.Links.Add(0, 5, Video_DataGridView.Rows[e.RowIndex].Cells["Video_link1"].Value.ToString());
                if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_link2"].Value != null) File2_linkLabel.Links.Add(0, 5, Video_DataGridView.Rows[e.RowIndex].Cells["Video_link2"].Value.ToString());
                if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_link3"].Value != null) File3_linkLabel.Links.Add(0, 5, Video_DataGridView.Rows[e.RowIndex].Cells["Video_link3"].Value.ToString());

                if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_Story"].Value != null) Story_TextBox.Text = Video_DataGridView.Rows[e.RowIndex].Cells["Video_Story"].Value.ToString();
                Visit_Set_Controls();
                Details_Panel.Show();
                UserMode = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }        
        private void Video_DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {



            if (Video_DataGridView.Columns[e.ColumnIndex].Name == "Video_Scedualed_Date")
            {
                if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_Family_Visit_ID"].Value == null)
                    Video_DataGridView.Rows[e.RowIndex].Cells["Video_Name"].Value = "Video - " + Video_DataGridView.Rows.Count.ToString();

                BeginEdit_RowIndex = e.RowIndex; BeginEdit_ColumnIndex = e.ColumnIndex;
                DatePicker3.Location = Video_DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                DatePicker3.Visible = true;
                if (Video_DataGridView.CurrentCell.Value != DBNull.Value && Video_DataGridView.CurrentCell.Value != null)
                {
                    DateTime Date = DateTime.Parse(Video_DataGridView.CurrentCell.Value.ToString());
                    DatePicker3.Value = DateTime.Parse(Date.ToShortDateString(), CultureInfo.CurrentCulture);
                }
                else
                {

                }
            }
        }
        private void Video_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    //if click is on new row or header row
                    if (e.RowIndex < 0 || e.ColumnIndex < 0)
                        return;

                    if (Video_DataGridView.Columns[e.ColumnIndex].Name == "Video_Scedualed_Date")
                    {
                        DatePicker3.Visible = false;

                        if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_Family_Visit_ID"].Value != null)
                        {
                            DialogResult dialogResult = MessageBox.Show("تأكيد التعديل", "Warning", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_Scedualed_Date"].Value == null || string.IsNullOrWhiteSpace(Video_DataGridView.Rows[e.RowIndex].Cells["Video_Scedualed_Date"].Value.ToString()))
                                {
                                    MessageBox.Show("لا يمكن ترك التاريخ أو الوقت فارغاً ", "Error");
                                    return;
                                }
                                else
                                {
                                    int Family_Visit_ID = int.Parse(Video_DataGridView.Rows[e.RowIndex].Cells["Video_Family_Visit_ID"].Value.ToString());
                                    string Visit_Name = Video_DataGridView.Rows[e.RowIndex].Cells["Video_Name"].Value.ToString();
                                    DateTime Date2 = DateTime.Parse(Video_DataGridView.Rows[e.RowIndex].Cells["Video_Scedualed_Date"].Value.ToString());
                                    string UK_Date = Date2.ToString("yyyy-MM-dd", new CultureInfo("en-GB"));
                                    v.Update_Visite_Schedualed_Date(Family_Visit_ID, Family_ID, Visit_Name, UK_Date, this.Name);
                                    MessageBox.Show("تم تعديل التاريخ بنجاح", "Confirmation");
                                }
                            }
                        }
                        else
                        {
                            if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_Scedualed_Date"].Value == null || string.IsNullOrWhiteSpace(Video_DataGridView.Rows[e.RowIndex].Cells["Video_Scedualed_Date"].Value.ToString()))
                            {
                                MessageBox.Show("لا يمكن ترك التاريخ أو الوقت فارغاً ", "Error");
                                return;
                            }
                            else
                            {
                                string Visit_Name = Video_DataGridView.Rows[e.RowIndex].Cells["Video_Name"].Value.ToString();
                                DateTime Date2 = DateTime.Parse(Video_DataGridView.Rows[e.RowIndex].Cells["Video_Scedualed_Date"].Value.ToString());
                                string UK_Date = Date2.ToString("yyyy-MM-dd", new CultureInfo("en-GB"));
                                v.Insert_Visit(Family_ID, "Video", Visit_Name, "مجدولة", UK_Date, "", this.Name);
                                MessageBox.Show("تم إدخال زيارة جديدة بنجاح", "Confirmation");
                            }
                        }
                        Bind_Visits("Video");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }        
        private void Video_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == Video_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;
                //Check if click is on specific column 
                if (e.ColumnIndex == Video_DataGridView.Columns["Video_Delete"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Video_DataGridView.Rows[e.RowIndex].Cells["Video_Family_Visit_ID"].Value != null)
                        {
                            int Family_Visit_ID = int.Parse(Video_DataGridView.Rows[e.RowIndex].Cells["Video_Family_Visit_ID"].Value.ToString());
                            string Visit_Name = Video_DataGridView.Rows[e.RowIndex].Cells["Video_Name"].Value.ToString();
                            v.Delete_Visit(Family_Visit_ID, Family_ID, Visit_Name, this.Name);
                            MessageBox.Show("تم حذف الزيارة بنجاح", "Confirmation");

                            Bind_Visits("Video");
                            Details_Panel.Hide();
                        }
                        else
                        {
                            Video_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }        

        private void Followup_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == Followup_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == Followup_DataGridView.Columns["Followup_Delete"].Index)
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
        private void Followup_DataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                UserMode = false;
                materialTabControl1.Size = new Size(this.Width - 20, 1100);
                Selected_Visit_Type = "Followup";
                Selected_Row_Index = e.RowIndex;
                Selected_Family_Visit_ID = int.Parse(Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Family_Visit_ID"].Value.ToString());
                Selected_Visit_Name = Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Name"].Value.ToString();
                Visit_Clear_Boxes();

                //VisitName_Label.Text = Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Name"].Value.ToString();

                foreach (RadioButton RB in VisitState_LayoutPanel.Controls.OfType<RadioButton>())
                {
                    string follow_state = "";
                    if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_State"].Value.ToString() == "3")
                        follow_state = "تمت";
                    else if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_State"].Value.ToString() == "2")
                        follow_state = "ملغاة";
                    else if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_State"].Value.ToString() == "1")
                        follow_state = "مجدولة";
                    if (String.Equals(RB.Text, follow_state))
                    {
                        RB.Checked = true;
                        break;
                    }
                }

                if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Canceled_Reason"].Value != null)
                    VisitReason_TextBox.Text = Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Canceled_Reason"].Value.ToString();

                if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Visit_Date"].Value == null)
                {
                    VisitDate_DatePicker.CustomFormat = " ";
                    VisitDate_DatePicker.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    VisitDate_DatePicker.CustomFormat = "yyyy-MM-dd";

                    DateTime Date1 = DateTime.Parse((Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Visit_Date"].Value).ToString(), CultureInfo.CurrentCulture);
                    VisitDate_DatePicker.Value = Date1;
                }
                if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Visitor1_ID"].Value != null)
                    Visitor1_comboBox.SelectedValue = int.Parse(Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Visitor1_ID"].Value.ToString());

                if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Visitor2_ID"].Value != null)
                    Visitor2_comboBox.SelectedValue = int.Parse(Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Visitor2_ID"].Value.ToString());
                if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_link1"].Value != null) File1_linkLabel.Links.Add(0, 5, Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_link1"].Value.ToString());
                if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_link2"].Value != null) File2_linkLabel.Links.Add(0, 5, Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_link2"].Value.ToString());
                if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_link3"].Value != null) File3_linkLabel.Links.Add(0, 5, Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_link3"].Value.ToString());

                if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Story"].Value != null) Story_TextBox.Text = Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Story"].Value.ToString();
                Visit_Set_Controls();
                Details_Panel.Show();
                UserMode = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void Followup_DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            if (Followup_DataGridView.Columns[e.ColumnIndex].Name == "Followup_Scedualed_Date")
            {
                if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Family_Visit_ID"].Value == null)
                    Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Name"].Value = "Follow-up - " + Followup_DataGridView.Rows.Count.ToString();

                BeginEdit_RowIndex = e.RowIndex; BeginEdit_ColumnIndex = e.ColumnIndex;
                DatePicker4.Location = Followup_DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                DatePicker4.Visible = true;
                if (Followup_DataGridView.CurrentCell.Value != DBNull.Value && Followup_DataGridView.CurrentCell.Value != null)
                {
                    DateTime Date = DateTime.Parse(Followup_DataGridView.CurrentCell.Value.ToString());
                    DatePicker4.Value = DateTime.Parse(Date.ToShortDateString(), CultureInfo.CurrentCulture);
                }
                else
                {

                }
            }
        }
        private void Followup_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    //if click is on new row or header row
                    if (e.RowIndex < 0 || e.ColumnIndex < 0)
                        return;

                    if (Followup_DataGridView.Columns[e.ColumnIndex].Name == "Followup_Scedualed_Date")
                    {
                        DatePicker4.Visible = false;

                        if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Family_Visit_ID"].Value != null)
                        {
                            DialogResult dialogResult = MessageBox.Show("تأكيد التعديل", "Warning", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Scedualed_Date"].Value == null || string.IsNullOrWhiteSpace(Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Scedualed_Date"].Value.ToString()))
                                {
                                    MessageBox.Show("لا يمكن ترك التاريخ أو الوقت فارغاً ", "Error");
                                    return;
                                }
                                else
                                {
                                    int Family_Visit_ID = int.Parse(Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Family_Visit_ID"].Value.ToString());
                                    string Visit_Name = Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Name"].Value.ToString();
                                    DateTime Date2 = DateTime.Parse(Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Scedualed_Date"].Value.ToString());
                                    string UK_Date = Date2.ToString("yyyy-MM-dd", new CultureInfo("en-GB"));
                                    v.Update_Visite_Schedualed_Date(Family_Visit_ID, Family_ID, Visit_Name, UK_Date, this.Name);
                                    MessageBox.Show("تم تعديل التاريخ بنجاح", "Confirmation");
                                }
                            }
                        }
                        else
                        {
                            if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Scedualed_Date"].Value == null || string.IsNullOrWhiteSpace(Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Scedualed_Date"].Value.ToString()))
                            {
                                MessageBox.Show("لا يمكن ترك التاريخ أو الوقت فارغاً ", "Error");
                                return;
                            }
                            else
                            {
                                string Visit_Name = Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Name"].Value.ToString();
                                DateTime Date2 = DateTime.Parse(Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Scedualed_Date"].Value.ToString());
                                string UK_Date = Date2.ToString("yyyy-MM-dd", new CultureInfo("en-GB"));
                                v.Insert_Visit(Family_ID, "Follow-up", Visit_Name, "مجدولة", UK_Date, "", this.Name);
                                MessageBox.Show("تم إدخال زيارة جديدة بنجاح", "Confirmation");
                            }
                        }
                        Bind_Visits("Followup");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void Followup_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == Followup_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;
                //Check if click is on specific column 
                if (e.ColumnIndex == Followup_DataGridView.Columns["Followup_Delete"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Family_Visit_ID"].Value != null)
                        {
                            int Family_Visit_ID = int.Parse(Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Family_Visit_ID"].Value.ToString());
                            string Visit_Name = Followup_DataGridView.Rows[e.RowIndex].Cells["Followup_Name"].Value.ToString();
                            v.Delete_Visit(Family_Visit_ID, Family_ID, Visit_Name, this.Name);
                            MessageBox.Show("تم حذف الزيارة بنجاح", "Confirmation");

                            Bind_Visits("Followup");
                            Details_Panel.Hide();
                        }
                        else
                        {
                            Followup_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        #endregion

        private void VisitScedualed_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (VisitScedualed_RadioButton.Checked)
                {
                    Show_Hide_Controls();

                    if (UserMode)
                        Visit_Details_IsDirty = true;
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void VisitCanceled_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (VisitCanceled_RadioButton.Checked)
                {
                    Show_Hide_Controls();


                    if (UserMode)
                        Visit_Details_IsDirty = true;
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void VisitDone_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (VisitDone_RadioButton.Checked)
                {
                    Show_Hide_Controls();


                    if (UserMode)
                        Visit_Details_IsDirty = true;
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void VisitReason_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                VisitReason_TextBox_OriginalText = VisitReason_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void VisitReason_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VisitReason_TextBox_OriginalText != VisitReason_TextBox.Text)
                    Visit_Details_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void VisitDate_DatePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                VisitDate_DatePicker.CustomFormat = "yyyy-MM-dd";

                if (UserMode)
                    Visit_Details_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void Story_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                Story_TextBox_OriginalText = Story_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void Story_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Story_TextBox_OriginalText != Story_TextBox.Text)
                    Visit_Details_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        //private void VisitTeam_CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    if (UserMode)
        //    {
        //        Visit_Details_IsDirty = true;
        //        Team_IsDirty = true;

        //        IsDirty_VisitTeam_CheckedListBox.SetItemChecked(e.Index, !IsDirty_VisitTeam_CheckedListBox.GetItemChecked(e.Index));
        //    }
        //}
        //private void VisitTeam_CheckedListBox_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < VisitTeam_CheckedListBox.Items.Count; i++)
        //    {
        //        if (VisitTeam_CheckedListBox.GetItemRectangle(i).Contains(VisitTeam_CheckedListBox.PointToClient(MousePosition)))
        //        {
        //            switch (VisitTeam_CheckedListBox.GetItemCheckState(i))
        //            {
        //                case CheckState.Checked:
        //                    VisitTeam_CheckedListBox.SetItemChecked(i, false);
        //                    break;
        //                case CheckState.Indeterminate:
        //                case CheckState.Unchecked:
        //                    VisitTeam_CheckedListBox.SetItemChecked(i, true);
        //                    break;
        //            }
        //        }

        //    }
        //}
        private void VisitUpdate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = VisitUpdate_Button;

                Visit_DataApproved = Check_Visit_Data();

                if (Visit_DataApproved)
                {

                    if (!Visit_Details_IsDirty)
                    {
                        MessageBox.Show("لا يوجد أي تغييرات لحفظها ", "Error");
                        return;
                    }
                    else
                    {
                        Get_Visit_Data();

                        v.Update_Visit_Details(Selected_Family_Visit_ID, VisitState, VisitDate, VisitReason, Story, Link1, Link2, Link3, Visitor1, Visitor2, Family_ID, Selected_Visit_Name, this.Name);

                        MessageBox.Show("تم تعديل معلومات الزيارة بنجاح", "Confirmation");
                        DatePicker1.Visible = false;
                        DatePicker5.Visible = false;
                        if (UpdateWithFill)
                        {
                            Bind_Visits(Selected_Visit_Type);

                            switch (Selected_Visit_Type)
                            {
                                case "ME":
                                    ME_DataGridView_RowHeaderMouseDoubleClick(ME_DataGridView, new DataGridViewCellMouseEventArgs(-1, Selected_Row_Index, 0, 0, e as MouseEventArgs));
                                    break;
                                case "Story":
                                    Story_DataGridView_RowHeaderMouseDoubleClick(ME_DataGridView, new DataGridViewCellMouseEventArgs(-1, Selected_Row_Index, 0, 0, e as MouseEventArgs));
                                    break;
                                case "Video":
                                    Video_DataGridView_RowHeaderMouseDoubleClick(ME_DataGridView, new DataGridViewCellMouseEventArgs(-1, Selected_Row_Index, 0, 0, e as MouseEventArgs));
                                    break;
                                case "Followup":
                                    Followup_DataGridView_RowHeaderMouseDoubleClick(ME_DataGridView, new DataGridViewCellMouseEventArgs(-1, Selected_Row_Index, 0, 0, e as MouseEventArgs));
                                    break;
                            }
                        }
                        else
                        {
                            Visit_Set_Controls();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Team_Query = "";
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void Get_Visit_Data()
        {
            if (Visit_Details_IsDirty)
            {
                if (VisitScedualed_RadioButton.Checked)
                {
                    VisitState = 1;
                    VisitReason = "";
                    VisitDate = "";
                    Story = "";
                    Link1 = "";
                    Link2 = "";
                    Link3 = "";
                    Visitor1 = 0;
                    Visitor2 = 0;
                    //Team_Query = "DELETE FROM family_visit_visitor WHERE family_visit_id = @Family_Visit_ID;";
                }
                else if (VisitCanceled_RadioButton.Checked)
                {
                    VisitState = 2;
                    VisitReason = VisitReason_TextBox.Text == "" ? null : VisitReason_TextBox.Text;
                    VisitDate = "";
                    Story = "";
                    Link1 = "";
                    Link2 = "";
                    Link3 = "";
                    Visitor1 = 0;
                    Visitor2 = 0;
                    //Team_Query = "DELETE FROM family_visit_visitor WHERE family_visit_id = @Family_Visit_ID;";
                }
                else if (VisitDone_RadioButton.Checked)
                {
                    VisitState = 3;
                    VisitReason = "";
                    VisitDate = VisitDate_DatePicker.Value.ToString("yyyy-MM-dd", new CultureInfo("en-GB"));
                    Story = Story_TextBox.Text;
                    Link1 = "";
                    Link2 = "";
                    Link3 = "";
                    Visitor1 = Visitor1_comboBox.SelectedValue == null ? 0 : int.Parse(Visitor1_comboBox.SelectedValue.ToString());
                    Visitor2 = Visitor2_comboBox.SelectedValue == null ? 0 : int.Parse(Visitor2_comboBox.SelectedValue.ToString());

                    Form_Name = this.Name;
                }
            }
        }
        private bool Check_Visit_Data()
        {
            if (VisitDone_RadioButton.Checked)
            {
                if (string.IsNullOrWhiteSpace(VisitDate_DatePicker.Text))
                {
                    MessageBox.Show("الرجاء تحديد تاريخ إتمام الزيارة", "Error");
                    return false;
                }
                //if (VisitTeam_CheckedListBox.CheckedItems.Count < 1)
                //{
                //    MessageBox.Show("الرجاء تحديد تاريخ فريق الزيارة", "Error");
                //    return false;
                //}
            }

            return true;
        }
        private void AddVisitor_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Visitor_Form Visitor_Form = new Visitor_Form(main_form);
                Visitor_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void VisitUpdate_Button_MouseLeave(object sender, EventArgs e)
        {
            VisitUpdate_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }
        private void VisitUpdate_Button_MouseEnter(object sender, EventArgs e)
        {
            VisitUpdate_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        // --------------Marks_TabPage--------------

        private void Marks_TabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                if (Family_ID == -1)
                {
                    MessageBox.Show("الرجاء إدخال وحفظ معلومات العائلة أولاً", "Error");
                    materialTabControl1.SelectedTab = Family_TabPage;
                    return;
                }

                materialTabControl1.Size = new Size(this.Width - 20, 2290);

                //Bind_Marks();
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم هذه الصفحة بسبب الخطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }
        //private void Bind_Marks()
        //{

        //    DataTable dt = f.Get_Family_Marks(Family_ID);

        //    DataRowView SelectedDataRow = dt.DefaultView[0];

        //    //SelectedDataRow = ((DataRowView)FamilyMarks_DataGridView.CurrentRow.DataBoundItem).Row;


        //    FamilyCode_Label.Text = SelectedDataRow["رمز العائلة"].ToString();
        //    FinalMark_Label.Text = SelectedDataRow["العلامة النهائية"].ToString();

        //    WorkersNum_Label.Text = SelectedDataRow["عدد العاملين"].ToString();
        //    WorkersPercentage_Label.Text = SelectedDataRow["عامل نسبة العاملين"].ToString();
        //    MembersNum_Label.Text = SelectedDataRow["عدد المستفيدين"].ToString();
        //    MembersIncomePercentage_Label.Text = SelectedDataRow["عامل نسبة دخل/أفراد"].ToString();

        //    MembersIncome_Lable.Text = string.Format("{0:N0}", decimal.Parse(SelectedDataRow["دخل الأفراد"].ToString()));
        //    FixedIncome_Label.Text = string.Format("{0:N0}", decimal.Parse(SelectedDataRow["الدخل الثابت"].ToString()));
        //    AllExpenses_label.Text = string.Format("{0:N0}", decimal.Parse(SelectedDataRow["المصاريف"].ToString()));
        //    IncomeExpensesMark_Label.Text = SelectedDataRow["علامة الدخل والمصاريف"].ToString();

        //    Savings_Label.Text = string.Format("{0:N0}", decimal.Parse(SelectedDataRow["المدخرات"].ToString()));
        //    SavingsMarks_Label.Text = SelectedDataRow["علامة المدخرات"].ToString();


        //    if (int.Parse(SelectedDataRow["الممتلكات"].ToString()) == 0)
        //    {
        //        LossAsset_Label.Text = "الفرق بين الأملاك و الخسائر: لا يتم إحتسابها في حال عدد الأملاك = 0";
        //        LossAsset_Label.ForeColor = Color.FromArgb(125, 0, 0);
        //    }
        //    else
        //    {
        //        LossAsset_Label.Text = "الفرق بين الأملاك و الخسائر:";
        //        LossAsset_Label.ForeColor = Color.Black;
        //    }
        //    AssetNum_Label.Text = SelectedDataRow["الممتلكات"].ToString();
        //    AssetMark_Label.Text = SelectedDataRow["علامة الممتلكات"].ToString();
        //    AidNum_Label.Text = SelectedDataRow["المساعدات"].ToString();
        //    AidMark_Label.Text = SelectedDataRow["علامة المساعدات"].ToString();
        //    HouseNum_Label.Text = SelectedDataRow["فرق عدد المنازل أملاك - خسارات"].ToString();
        //    HouseMark_Label.Text = SelectedDataRow["علامة فرق عدد المنازل"].ToString();
        //    ShopNum_Label.Text = SelectedDataRow["فرق عدد المحلات أملاك - خسارات"].ToString();
        //    ShopMark_Label.Text = SelectedDataRow["علامة فرق عدد المحلات"].ToString();
        //    VehicleNum_Label.Text = SelectedDataRow["فرق عدد المركبات أملاك - خسارات"].ToString();
        //    VehicleMark_Label.Text = SelectedDataRow["علامة فرق عدد المركبات"].ToString();
        //    LandNum_Label.Text = SelectedDataRow["فرق عدد الأراضي أملاك - خسارات"].ToString();
        //    LandMark_Label.Text = SelectedDataRow["علامة فرق عدد الأراضي"].ToString();
        //    FactoryNum_Label.Text = SelectedDataRow["فرق عدد المعامل أملاك - خسارات"].ToString();
        //    FactoryMark_Label.Text = SelectedDataRow["علامة فرق عدد المعامل"].ToString();
        //    AssetLossMark_Label.Text = SelectedDataRow["علامة أملاك - مساعدات - خسارات"].ToString();

        //    YoungFamily_Label.Text = SelectedDataRow["عائلة فتية"].ToString();
        //    YoungFamilyMark_Label.Text = SelectedDataRow["علامة فتوة العائلة"].ToString();
        //    ReceiverState_Label.Text = SelectedDataRow["حالة رب الأسرة"].ToString();
        //    ReceiverStateMark_Label.Text = SelectedDataRow["علامة رب الأسرة"].ToString();
        //    MembesrNum_Label.Text = SelectedDataRow["عدد المستفيدين"].ToString();
        //    MembesrMark_Label.Text = SelectedDataRow["علامة المستفيدين"].ToString();
        //    BabiesNum_Label.Text = SelectedDataRow["عدد الأطفال"].ToString();
        //    BabiesMark_Label.Text = SelectedDataRow["علامة الأطفال"].ToString();
        //    ChildrenNum_Label.Text = SelectedDataRow["عدد القاصرين"].ToString();
        //    ChildrenMark_Label.Text = SelectedDataRow["علامة القاصرين"].ToString();
        //    ElderliesNum_Label.Text = SelectedDataRow["عدد المسنين"].ToString();
        //    ElderliesMark_Label.Text = SelectedDataRow["علامة المسنين"].ToString();
        //    WithFatalDiseasesNum_Label.Text = SelectedDataRow["يعانون أمراض مميتة"].ToString();
        //    FatalDiseasesMark_Label.Text = SelectedDataRow["علامة الأمراض المميتة"].ToString();
        //    WithDisabilityNum_Label.Text = SelectedDataRow["ذوي إحتياجات خاصة"].ToString();
        //    DisabilityMark_Label.Text = SelectedDataRow["علامة الإحتياجات الخاصة"].ToString();
        //    SoldierNum_Label.Text = SelectedDataRow["عدد العسكريين"].ToString();
        //    SoldierMark_Label.Text = SelectedDataRow["علامة العسكريين"].ToString();
        //    StudentsNum_Label.Text = SelectedDataRow["عدد الطلاب"].ToString();
        //    StudentsMark_Label.Text = SelectedDataRow["علامة الطلاب"].ToString();
        //    GovEducationNum_Label.Text = SelectedDataRow["الدراسة الحكومية"].ToString();
        //    GovEducationMark_Label.Text = SelectedDataRow["علامة الدراسة الحكومية"].ToString();
        //    NonGovEducationNum_Label.Text = SelectedDataRow["الدراسة غير الجكومية - مدفوعة"].ToString();
        //    NonGovEducationMark_Label.Text = SelectedDataRow["علامة الدراسة غير الحكومية"].ToString();
        //    WithDiseasesNum_Label.Text = SelectedDataRow["عدد المرضى - مرض عادي"].ToString();
        //    DiseasesMark_Label.Text = SelectedDataRow["علامة المرضى"].ToString();


        //    FamilyMembersTotalMark_Label.Text = SelectedDataRow["علامة أفراد الأسرة"].ToString();


        //    IsDisplaced_Label.Text = SelectedDataRow["النزوح"].ToString();
        //    IsDisplacedMark_Label.Text = SelectedDataRow["علامة النزوح"].ToString();
        //    HomeType_Label.Text = SelectedDataRow["السكن الحالي"].ToString();
        //    HomeTypeMark_Label.Text = SelectedDataRow["علامة السكن الحالي"].ToString();
        //    BuildingCondition_Label.Text = SelectedDataRow["الحالة الفنية للمنزل"].ToString();
        //    BuildingConditionMark_Label.Text = SelectedDataRow["علامة حالة المنزل"].ToString();
        //    Livingroom_label.Text = SelectedDataRow["غرفة المعيشة"].ToString();
        //    LivingroomMark_label.Text = SelectedDataRow["علامة غرفة المعيشة"].ToString();
        //    Beds_Label.Text = SelectedDataRow["الأسرّة"].ToString();
        //    BedsMark_Label.Text = SelectedDataRow["علامة الأسرّة"].ToString();
        //    ElectricalDavices_Label.Text = SelectedDataRow["الأجهزة الكهربائية"].ToString();
        //    ElectricalDavicesMark_Label.Text = SelectedDataRow["علامة الأجهزة الكهربائية"].ToString();
        //    LivingWithFamily_Label.Text = SelectedDataRow["تسكن مع عائلة أخرى"].ToString();
        //    LivingWithFamilyMark_Label.Text = SelectedDataRow["علامة السكن مع عائلة أخرى"].ToString();
        //    SellingFurniture_Label.Text = SelectedDataRow["بيع أغراض المنزل"].ToString();
        //    SellingFurnitureMark_Label.Text = SelectedDataRow["علامة بيع أغراض المنزل"].ToString();
        //    LivingMark_Label.Text = SelectedDataRow["علامة المعيشة"].ToString();
        //}
    }
}
