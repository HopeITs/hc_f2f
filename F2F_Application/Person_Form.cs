using F2F_Application.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Person_Form : Form
    {
        public Person_Form(int Family_ID, int Visit_ID, string Visit_Name, string Family_Code, Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.Family_ID = Family_ID;
            this.Visit_ID = Visit_ID;
            this.Visit_Name = Visit_Name;
            MyDataGridViewInitializationMethod();
            FamilyCode_TextBox.Text = Family_Code;
            UpdateMode = false;
            UserMode = true;
            visit_TextBox.Text = Visit_Name;
        }

        public Person_Form(int Person_ID, int Family_ID, int Visit_ID, string Visit_Name, string Family_Code, Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.Family_ID = Family_ID;
            this.Person_ID = Person_ID;
            this.Visit_ID = Visit_ID;
            this.Visit_Name = Visit_Name;
            visit_TextBox.Text = Visit_Name;
            FamilyCode_TextBox.Text = Family_Code;
            MyDataGridViewInitializationMethod();
            UpdateMode = true;
        }

        Main_Form main_form;
        int Family_ID, Person_ID, Visit_ID;
        string Visit_Name;
        bool UpdateMode;
        Person p; Categories c; Visits v; Family f;
        bool DataApproved = false;
        bool UserMode = false;
        bool NationalityNumberChecked; bool ReciverChecked;

        #region //IsDirty
        bool General_Information_IsDirty = false, Receiver_IsDirty = false, State_IsDirty = false, Maritalstatus_IsDirty = false, Expenses_Information_IsDirty = false, Aids_Information_IsDirty = false
         , Military_Information_IsDirty, WorkExp_DataGridView_IsDirty = false, MP_DataGridView_IsDirty = false, Educated_Information_IsDirty = false, Education_DataGridView_IsDirty = false, Disease_DataGridView_IsDirty = false,
            Needs_IsDirty = false, PersonState_IsDirty = false, link_family = false;
        #endregion

        #region //Data
        string FirstName, FatherName, LastName, EName, EFatherName, ELastName, NationalityNumber, DOB, Form_Name, State_Note, Note, PersonNote, Stateyear,StateAddressNote, isAidAmount, isAidReason, OperationName_2, OperationName_1,
                EducationNote, EducationNote2, aidnote_29, needs_note, needs_courses;
        int Sex_ID, Nationality_ID, MaritalStatus_ID, State_ID, StateAddress_ID,IsEducated, IsStudent, IsReciever, Relation_ID,
            OperationValue_2, OperationValue_1, ExpensesAmount_9, ExpensesAmount_4, ExpensesAmount_5, ExpensesAmount_24,
            AidAmount_21, AidAmount_29, AidAmount_1, AidAmount_13, AidAmount_6, AidAmount_8, aidperiod_29, Expensestype_9, Expensestype_4, Expensestype_5, Expensestype_24, aidsource_21, aidsource_1, aidsource_13, aidsource_6, aidsource_8,
            aidperiod_21, aidperiod_1, aidperiod_13, aidperiod_6, aidperiod_8, aidperiod_10, aidsource_10, AidAmount_10, education_id_1,
            education_id_2, educationfield_id_1, educationfield_id_2, educationtype_id_1, educationtype_id_2, Expensestype_8, Expensestype_2, ExpensesAmount_8,
            ExpensesAmount_2, aidsource_2, aidsource_23, aidperiod_2, aidperiod_23, AidAmount_2, AidAmount_23,
            needs_0, needs_1, needs_2, needs_3, needs_4, needs_5, needs_6, needs_7, needs_8, needs_9, needs_10, needs_12;
        int? hasDisease, haswork, isMP, aidsource_29, isAid10;
        //int? Relation_ID;
        string WorkExp_Query, Education_Query, Disease_Query, Aid_Query, Expenses_Query, MP_Query, Military_Query, Receiver_Query, General_Query, Needs_Query;
        #endregion

        #region //Original
        string Name_TextBox_OriginalText, FatherName_TextBox_OriginalText, LastName_TextBox_OriginalText,
            EName_TextBox_OriginalText, EFatherName_TextBox_OriginalText, ELastName_TextBox_OriginalText,
            NationalityNumber_TextBox_OriginalText, State_Note_OriginalText, Note_TextBox_OriginalText, PersonNote_TextBox_OriginalText,
            Stateyear_TextBox_OriginalText, StateAddress_TextBox_OriginalText, StateAddressNote_TextBox_OriginalText,
            AidAmount_29_Textbox_OriginalText, AidNote_29_Textbox_OriginalText,
            expenses_amount_9_TextBox_OriginalText, expenses_amount_4_TextBox_OriginalText, expenses_amount_5_TextBox_OriginalText,
            expenses_amount_24_TextBox_OriginalText, aid_amount_21_TextBox_OriginalText, aid_amount_1_TextBox_OriginalText, aid_amount_13_TextBox_OriginalText,
            aid_amount_6_TextBox_OriginalText, aid_amount_8_TextBox_OriginalText, operation_name_2_TextBox_OriginalText, operation_value_2_TextBox_OriginalText,
            operation_name_1_TextBox_OriginalText, operation_value_1_TextBox_OriginalText, aid_amount_10_TextBox_OriginalText,
            educationnote_TextBox_OriginalText, educationnote2_TextBox_OriginalText, expenses_amount_2_TextBox_OriginalText,
            expenses_amount_8_TextBox_OriginalText, aid_amount_2_TextBox_OriginalText, aid_amount_23_TextBox_OriginalText,
            needs_courses_TextBox_OriginalText, needs_note_TextBox_OriginalText;
        #endregion

        private void Person_Form_Load(object sender, EventArgs e)
        {
            //await Task.Delay(700); 

            for (int i = 0; i < WorkExp_DataGridView.ColumnCount; i++)
            {
                DataGridViewColumn column = WorkExp_DataGridView.Columns[i];
                column.Width = 150;
            }
            Disease_DataGridView.Columns[0].ReadOnly = true;
            WorkExp_DataGridView.Columns[0].ReadOnly = true;
            MP_DataGridView.Columns[0].ReadOnly = true;

            InfoLable.ForeColor = VisitNameLabel.ForeColor = VisitInfoLabel.ForeColor = visit_Label.ForeColor = PGeneralNoteLable.ForeColor = NeedsLable.ForeColor = MPLable.ForeColor = ExpensesLable.ForeColor = AidLable.ForeColor = GeneralNoteLable.ForeColor = panel1.ForeColor = InfoInsideFamilyLable.ForeColor = StudyLable.ForeColor = IllnessLable.ForeColor = WorkLable.ForeColor = Color.White;
            InfoLable.Font = VisitNameLabel.Font = VisitInfoLabel.Font = visit_Label.Font = PGeneralNoteLable.Font = NeedsLable.Font = MPLable.Font = ExpensesLable.Font = AidLable.Font = GeneralNoteLable.Font = panel1.Font = InfoInsideFamilyLable.Font = StudyLable.Font = IllnessLable.Font = WorkLable.Font = new Font("Arial", 14);
            try
            {
                p = new Person(); c = new Categories(); v = new Visits(); f = new Family();
                this.dateTimePicker1.CustomFormat = " ";
                this.dateTimePicker1.Format = DateTimePickerFormat.Custom;

                Bind_ComboBoxes(false);

                if (UpdateMode)
                {
                    Fill_Person(Visit_ID);
                    visitLabel.Visible = false;
                    visit_TextBox.Visible = false;
                    UpdatePerson_Button.Visible = true;
                    Delete_Button.Visible = true;
                    SavePerson_Button.Visible = false;
                    //MELayoutPanel.Visible = true;
                    //SecondTableLayoutPanel.Visible = true;
                    //Update_Button.Visible = true;
                    Bind_Visits("ME");
                    MEFamily_DataGridView.ClearSelection();
                    if (MEFamily_DataGridView.Rows.Count != 0)
                    {
                        foreach (DataGridViewRow row in MEFamily_DataGridView.Rows)
                        {
                            foreach (DataGridViewColumn col in MEFamily_DataGridView.Columns)
                            {
                                MEFamily_DataGridView.Rows[row.Index].Cells[col.Index].Style.ForeColor = Color.Black;
                            }
                        }
                        foreach (DataGridViewRow row in MEFamily_DataGridView.Rows)
                        {
                            if (row.Cells[0].Value != null && row.Cells[0].Value.Equals(Visit_ID))
                            {
                                int index = row.Index;
                                MEFamily_DataGridView.CurrentCell = MEFamily_DataGridView.Rows[index].Cells[1];
                                MEFamily_DataGridView.Rows[index].Selected = true;
                                break;
                            }
                        }
                    }
                }
                if (!UpdateMode)
                {
                    visitLabel.Visible = false;
                    visit_TextBox.Visible = false;
                    SecondTableLayoutPanel.Visible = false;
                    SavePerson_Button.Visible = true;
                    UpdatePerson_Button.Visible = false;
                    Update_Button.Visible = false;
                    Delete_Button.Visible = false;
                    MELayoutPanel.Visible = false;
                }
                else
                {
                    visitLabel.Visible = true;
                    visit_TextBox.Visible = true;
                }
                Set_Controls();
                Check_User_Role();

                if (Person_ID != -1)
                    Program.Person_Opened.Add(Person_ID);

                //to scroll up when open the form
                FirstName_TextBox.Focus();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم هذه الصفحة بسبب الخطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        // --------------Visits_TabPage--------------

        DateTimePicker DatePicker1, DatePicker5;
        TextBox MEReason;

        string Selected_Visit_Type = "", Selected_Visit_Name = "", Selected_Visit_Reason = "";

        int Selected_Family_Visit_ID = -1; int Selected_Family_Visitstate = -1; int Selected_Row_Index = -1; int Seelcted_Visitor1_ID = -1; int Selected_Visitor2_ID = -1;
        bool Visit_DataApproved = false;
        int BeginEdit_RowIndex = -1, BeginEdit_ColumnIndex = -1; int BeginEdit2_RowIndex = -1, BeginEdit2_ColumnIndex = -1;
        bool UpdateWithFill = true;
        private void Bind_Visits(string Visit_Type)
        {
            UserMode = false;
            DataSet ds = v.Get_Family_Visits(Family_ID, Visit_Type);
            DataTable ME_dt = null;
            ME_dt = ds.Tables[0];

            if (ds.Tables[0].Rows.Count != 0)
                ME_dt = ds.Tables[0];
            else
            {
                ME_dt = null;
                MEFamily_DataGridView.Rows.Clear();
                SecondTableLayoutPanel.Visible = false;
            }

            if (ME_dt != null)
            {
                MEFamily_DataGridView.Rows.Clear();

                //foreach (DataGridViewColumn c in MEFamily_DataGridView.Columns)
                //{
                //    c.ReadOnly = true;
                //}
                for (int i = 0; i < ME_dt.Rows.Count; i++)
                {
                    MEFamily_DataGridView.Rows.Add();
                    MEFamily_DataGridView.Rows[i].Cells["ME_Family_Visit_ID"].Value = ME_dt.Rows[i].Field<int>("id");
                    MEFamily_DataGridView.Rows[i].Cells["ME_Name"].Value = ME_dt.Rows[i].Field<string>("visit_name");
                    if (ME_dt.Rows[i]["Scedualed_Visit_date"] != DBNull.Value)
                    {
                        DateTime Date1 = DateTime.Parse(ME_dt.Rows[i].Field<DateTime>("Scedualed_Visit_date").ToString(), CultureInfo.CurrentCulture);
                        MEFamily_DataGridView.Rows[i].Cells["ME_Scedualed_Date"].Value = Date1.ToShortDateString();
                    }
                    if (ME_dt.Rows[i]["Visit_date"] != DBNull.Value)
                    {
                        DateTime Date2 = DateTime.Parse(ME_dt.Rows[i].Field<DateTime>("Visit_date").ToString(), CultureInfo.CurrentCulture);
                        MEFamily_DataGridView.Rows[i].Cells["ME_Date"].Value = Date2.ToShortDateString();
                    }
                    MEFamily_DataGridView.Rows[i].Cells["ME_State"].Value = ME_dt.Rows[i].Field<int>("visitstate_id");
                    MEFamily_DataGridView.Rows[i].Cells["ME_Reason"].Value = ME_dt.Rows[i].Field<string>("canceled_reason");
                }
            }

            //DatePicker1 = new DateTimePicker();
            //DatePicker1.ShowUpDown = false;
            //DatePicker1.Format = DateTimePickerFormat.Short;
            //DatePicker1.Visible = false;
            //Rectangle oRectangle1 = MEFamily_DataGridView.GetCellDisplayRectangle(3, 0, true);
            //DatePicker1.Size = new Size(oRectangle1.Width, oRectangle1.Height);
            //DatePicker1.Location = new Point(oRectangle1.X, oRectangle1.Y);
            //DatePicker1.RightToLeftLayout = true;
            //MEFamily_DataGridView.Controls.Add(DatePicker1);

            //DatePicker5 = new DateTimePicker();
            //DatePicker5.ShowUpDown = false;
            //DatePicker5.Format = DateTimePickerFormat.Short;
            //DatePicker5.Visible = false;
            //Rectangle oRectangle5 = MEFamily_DataGridView.GetCellDisplayRectangle(3, 0, true);
            //DatePicker5.Size = new Size(oRectangle5.Width, oRectangle5.Height);
            //DatePicker5.Location = new Point(oRectangle5.X, oRectangle5.Y);
            //DatePicker5.RightToLeftLayout = true;
            //MEFamily_DataGridView.Controls.Add(DatePicker5);

            //MEReason = new TextBox();
            //MEReason.Visible = false;
            //Rectangle oRectangle6 = MEFamily_DataGridView.GetCellDisplayRectangle(3, 0, true);
            //MEReason.Size = new Size(oRectangle6.Width, oRectangle6.Height);
            //MEReason.Location = new Point(oRectangle6.X, oRectangle6.Y);
            //MEFamily_DataGridView.Controls.Add(MEReason);
            UserMode = true;
        }

        private void Person_Form_Shown(object sender, EventArgs e)
        {
            try
            {
                //Main_TableLayoutPanel.Size = new Size(this.Width - 10, 6000);

                Stop_Highlighting_Combobox();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }

            }
        }

        private void Person_Form_Enter(object sender, EventArgs e)
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
            Sex_ComboBox.SelectionLength = 0; Sex_ComboBox.SelectionStart = Sex_ComboBox.Text.Length;
            Nationality_ComboBox.SelectionLength = 0; Nationality_ComboBox.SelectionStart = Nationality_ComboBox.Text.Length;
            MaritalStatus_ComboBox.SelectionLength = 0; MaritalStatus_ComboBox.SelectionStart = MaritalStatus_ComboBox.Text.Length;
            State_ComboBox.SelectionLength = 0; State_ComboBox.SelectionStart = State_ComboBox.Text.Length;
            Relation_ComboBox.SelectionLength = 0; Relation_ComboBox.SelectionStart = Relation_ComboBox.Text.Length;
            expensestype_24_comboBox.SelectionLength = 0; expensestype_24_comboBox.SelectionStart = expensestype_24_comboBox.Text.Length;
            expensestype_4_comboBox.SelectionLength = 0; expensestype_4_comboBox.SelectionStart = expensestype_4_comboBox.Text.Length;
            expensestype_5_comboBox.SelectionLength = 0; expensestype_5_comboBox.SelectionStart = expensestype_5_comboBox.Text.Length;
            expensestype_9_comboBox.SelectionLength = 0; expensestype_9_comboBox.SelectionStart = expensestype_9_comboBox.Text.Length;
            AidPeriod_29_comboBox.SelectionLength = 0; AidPeriod_29_comboBox.SelectionStart = AidPeriod_29_comboBox.Text.Length;
            aidsource_21_comboBox.SelectionLength = 0; aidsource_21_comboBox.SelectionStart = aidsource_21_comboBox.Text.Length;
            aidsource_1_comboBox.SelectionLength = 0; aidsource_1_comboBox.SelectionStart = aidsource_1_comboBox.Text.Length;
            aidsource_13_comboBox.SelectionLength = 0; aidsource_13_comboBox.SelectionStart = aidsource_13_comboBox.Text.Length;
            aidsource_6_comboBox.SelectionLength = 0; aidsource_6_comboBox.SelectionStart = aidsource_6_comboBox.Text.Length;
            aidsource_8_comboBox.SelectionLength = 0; aidsource_8_comboBox.SelectionStart = aidsource_8_comboBox.Text.Length;
            aidperiod_21_comboBox.SelectionLength = 0; aidperiod_21_comboBox.SelectionStart = aidperiod_21_comboBox.Text.Length;
            aidperiod_1_comboBox.SelectionLength = 0; aidperiod_1_comboBox.SelectionStart = aidperiod_1_comboBox.Text.Length;
            aidperiod_13_comboBox.SelectionLength = 0; aidperiod_13_comboBox.SelectionStart = aidperiod_13_comboBox.Text.Length;
            aidperiod_6_comboBox.SelectionLength = 0; aidperiod_6_comboBox.SelectionStart = aidperiod_6_comboBox.Text.Length; aidsource_21_comboBox.SelectionLength = 0; aidsource_21_comboBox.SelectionStart = aidsource_21_comboBox.Text.Length;
            aidperiod_8_comboBox.SelectionLength = 0; aidperiod_8_comboBox.SelectionStart = aidperiod_8_comboBox.Text.Length;
            aidperiod_10_comboBox.SelectionLength = 0; aidperiod_10_comboBox.SelectionStart = aidperiod_10_comboBox.Text.Length;
            aidsource_10_comboBox.SelectionLength = 0; aidsource_10_comboBox.SelectionStart = aidsource_10_comboBox.Text.Length;
            expensestype_8_comboBox.SelectionLength = 0; expensestype_8_comboBox.SelectionStart = expensestype_8_comboBox.Text.Length;
            expensestype_2_comboBox.SelectionLength = 0; expensestype_2_comboBox.SelectionStart = expensestype_2_comboBox.Text.Length;
            aidsource_2_comboBox.SelectionLength = 0; aidsource_2_comboBox.SelectionStart = aidsource_2_comboBox.Text.Length;
            aidsource_23_comboBox.SelectionLength = 0; aidsource_23_comboBox.SelectionStart = aidsource_23_comboBox.Text.Length;
            aidperiod_2_comboBox.SelectionLength = 0; aidperiod_2_comboBox.SelectionStart = aidperiod_2_comboBox.Text.Length;
            aidperiod_23_comboBox.SelectionLength = 0; aidperiod_23_comboBox.SelectionStart = aidperiod_23_comboBox.Text.Length;
            education_id_1_comboBox.SelectionLength = 0; education_id_1_comboBox.SelectionStart = education_id_1_comboBox.Text.Length;
            education_id_2_comboBox.SelectionLength = 0; education_id_2_comboBox.SelectionStart = education_id_2_comboBox.Text.Length;
            educationtype_id_1_comboBox.SelectionLength = 0; educationtype_id_1_comboBox.SelectionStart = educationtype_id_1_comboBox.Text.Length;
            educationtype_id_2_comboBox.SelectionLength = 0; educationtype_id_2_comboBox.SelectionStart = educationtype_id_2_comboBox.Text.Length;
            educationfield_id_1_comboBox.SelectionLength = 0; educationfield_id_1_comboBox.SelectionStart = educationfield_id_1_comboBox.Text.Length;
            educationfield_id_2_comboBox.SelectionLength = 0; educationfield_id_2_comboBox.SelectionStart = educationfield_id_2_comboBox.Text.Length;
        }

        private void Check_User_Role()
        {
            if (Properties.Settings.Default.Role == "Viewer")
            {

                //Main_TableLayoutPanel.Enabled = false;
                StateHistory_Button.Visible = MaritalHistory_Button.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                Delete_Button.Visible = false;
                //Save_Button.Visible = false;
                Update_Button.Visible = false;

                //Main_TableLayoutPanel.ContextMenuStrip = new ContextMenuStrip();
            }
            else if (Properties.Settings.Default.Role != "Admin" && Properties.Settings.Default.Role != "L0_Admin")
            {
                Delete_Button.Visible = false;
            }
        }

        private void Bind_ComboBoxes(bool KeepSelection)
        {
            List<string> From_Tables = new List<string> { "sex", "nationality", "maritalstatus", "relation", "personstate", "workexp", "workposition", "workplace", "workfor", "experience", "education", "educationtype", "diseasecategory", "expensestype", "aidperiod", "disease", "aidsource", "aidperiod", "work_type", "educationfield", "visitstate","stateaddress" };
            DataSet Tables = c.Select_Tables(From_Tables, true);
            DataTable dt0 = Tables.Tables[0].Copy();
            DataTable dt1 = Tables.Tables[1].Copy();
            DataTable dt2 = Tables.Tables[2].Copy();
            DataTable dt3 = Tables.Tables[3].Copy();
            DataTable dt4 = Tables.Tables[4].Copy();
            DataTable dt5 = Tables.Tables[5].Copy();
            DataTable dt6 = Tables.Tables[6].Copy();
            DataTable dt7 = Tables.Tables[7].Copy();
            DataTable dt8 = Tables.Tables[8].Copy();
            DataTable dt9 = Tables.Tables[9].Copy();
            DataTable dt10 = Tables.Tables[10].Copy();
            DataTable dt101 = Tables.Tables[10].Copy();
            DataTable dt11 = Tables.Tables[11].Copy();
            DataTable dt111 = Tables.Tables[11].Copy();
            DataTable dt12 = Tables.Tables[12].Copy();
            DataTable dt13 = Tables.Tables[13].Copy();
            DataTable dt131 = Tables.Tables[13].Copy();
            DataTable dt132 = Tables.Tables[13].Copy();
            DataTable dt133 = Tables.Tables[13].Copy();
            DataTable dt134 = Tables.Tables[13].Copy();
            DataTable dt135 = Tables.Tables[13].Copy();
            DataTable dt136 = Tables.Tables[13].Copy();
            DataTable dt137 = Tables.Tables[13].Copy();
            DataTable dt138 = Tables.Tables[13].Copy();
            DataTable dt139 = Tables.Tables[13].Copy();
            DataTable dt1310 = Tables.Tables[13].Copy();
            DataTable dt1311 = Tables.Tables[13].Copy();


            DataTable dt14 = Tables.Tables[14].Copy();
            DataTable dt15 = Tables.Tables[15].Copy();
            DataTable dt16 = Tables.Tables[16].Copy();
            DataTable dt161 = Tables.Tables[16].Copy();
            DataTable dt162 = Tables.Tables[16].Copy();
            DataTable dt163 = Tables.Tables[16].Copy();
            DataTable dt164 = Tables.Tables[16].Copy();
            DataTable dt165 = Tables.Tables[16].Copy();
            DataTable dt166 = Tables.Tables[16].Copy();
            DataTable dt167 = Tables.Tables[16].Copy();
            DataTable dt168 = Tables.Tables[16].Copy();
            DataTable dt169 = Tables.Tables[16].Copy();
            DataTable dt1610 = Tables.Tables[16].Copy();

            DataTable dt17 = Tables.Tables[17].Copy();
            DataTable dt171 = Tables.Tables[17].Copy();
            DataTable dt172 = Tables.Tables[17].Copy();
            DataTable dt173 = Tables.Tables[17].Copy();
            DataTable dt174 = Tables.Tables[17].Copy();
            DataTable dt175 = Tables.Tables[17].Copy();
            DataTable dt176 = Tables.Tables[17].Copy();
            DataTable dt177 = Tables.Tables[17].Copy();
            DataTable dt178 = Tables.Tables[17].Copy();
            DataTable dt179 = Tables.Tables[17].Copy();
            DataTable dt1710 = Tables.Tables[17].Copy();
            DataTable dt18 = Tables.Tables[18].Copy();
            DataTable dt19 = Tables.Tables[19].Copy();
            DataTable dt191 = Tables.Tables[19].Copy();
            DataTable dt192 = Tables.Tables[21].Copy();


            //Bing ComboBoxes
            Bind_ComboBox(Sex_ComboBox, dt0, KeepSelection);
            Bind_ComboBox(Nationality_ComboBox, dt1, KeepSelection);
            Bind_ComboBox(MaritalStatus_ComboBox, dt2, KeepSelection);
            Bind_ComboBox(Relation_ComboBox, dt3, KeepSelection);
            Bind_ComboBox(State_ComboBox, dt4, KeepSelection);
            Bind_ComboBox(expensestype_24_comboBox, dt13, KeepSelection);
            Bind_ComboBox(expensestype_4_comboBox, dt131, KeepSelection);
            Bind_ComboBox(expensestype_5_comboBox, dt132, KeepSelection);
            Bind_ComboBox(expensestype_9_comboBox, dt133, KeepSelection);

            Bind_ComboBox(AidPeriod_29_comboBox, dt14, KeepSelection);

            Bind_ComboBox(aidsource_21_comboBox, dt16, KeepSelection);
            Bind_ComboBox(aidsource_1_comboBox, dt161, KeepSelection);
            Bind_ComboBox(aidsource_13_comboBox, dt162, KeepSelection);
            Bind_ComboBox(aidsource_6_comboBox, dt163, KeepSelection);
            Bind_ComboBox(aidsource_8_comboBox, dt164, KeepSelection);

            Bind_ComboBox(aidperiod_21_comboBox, dt17, KeepSelection);
            Bind_ComboBox(aidperiod_1_comboBox, dt171, KeepSelection);
            Bind_ComboBox(aidperiod_13_comboBox, dt172, KeepSelection);
            Bind_ComboBox(aidperiod_6_comboBox, dt173, KeepSelection);
            Bind_ComboBox(aidperiod_8_comboBox, dt174, KeepSelection);
            Bind_ComboBox(aidperiod_10_comboBox, dt175, KeepSelection);

            Bind_ComboBox(aidsource_10_comboBox, dt165, KeepSelection);

            Bind_ComboBox(expensestype_8_comboBox, dt134, KeepSelection);
            Bind_ComboBox(expensestype_2_comboBox, dt135, KeepSelection);
            Bind_ComboBox(aidsource_2_comboBox, dt166, KeepSelection);
            Bind_ComboBox(aidsource_23_comboBox, dt167, KeepSelection);
            Bind_ComboBox(aidperiod_2_comboBox, dt176, KeepSelection);
            Bind_ComboBox(aidperiod_23_comboBox, dt177, KeepSelection);

            Bind_ComboBox(StateAddress_ComboBox, dt192, KeepSelection);

            //Bing ComboBoxes in DataGridView
            Bind_Gridview_ComboBox(this.workexp_id, dt5);
            Bind_Gridview_ComboBox(this.workposition_id, dt6);
            Bind_Gridview_ComboBox(this.workplace_id, dt7);
            Bind_Gridview_ComboBox(this.workfor_id, dt8);
            Bind_Gridview_ComboBox(this.experience_id, dt9);
            Bind_Gridview_ComboBox(this.worktype_id, dt18);
            Bind_Gridview_ComboBox(this.expensestype_6, dt136);
            Bind_Gridview_ComboBox(this.expensestype_16, dt137);
            Bind_Gridview_ComboBox(this.expensestype_15, dt138);
            Bind_Gridview_ComboBox(this.expensestype_17, dt139);
            Bind_Gridview_ComboBox(this.expensestype_23, dt1310);

            Bind_Gridview_ComboBox(aidsource_5_mp, dt168);
            Bind_Gridview_ComboBox(aidsource_17_mp, dt169);
            Bind_Gridview_ComboBox(aidsource_22_mp, dt1610);
            Bind_Gridview_ComboBox(aidperiod_5_mp, dt178);
            Bind_Gridview_ComboBox(aidperiod_17_mp, dt179);
            Bind_Gridview_ComboBox(aidperiod_22_mp, dt1710);
            Bind_Gridview_ComboBox(expensestype_12_mp, dt1311);
            Bind_Gridview_ComboBox(this.ME_State, Tables.Tables[20]);

            Bind_ComboBox(this.education_id_1_comboBox, dt10, KeepSelection);
            Bind_ComboBox(this.education_id_2_comboBox, dt101, KeepSelection);
            Bind_ComboBox(this.educationtype_id_1_comboBox, dt11, KeepSelection);
            Bind_ComboBox(this.educationtype_id_2_comboBox, dt111, KeepSelection);
            Bind_ComboBox(this.educationfield_id_1_comboBox, dt19, KeepSelection);
            Bind_ComboBox(this.educationfield_id_2_comboBox, dt191, KeepSelection);

            Bind_Gridview_ComboBox(this.Disease_Category, dt12);
            Bind_Gridview_ComboBox(this.Disease, dt15);
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
        }

        private void Bind_Gridview_ComboBox(DataGridViewComboBoxColumn Combox_Name, DataTable dt)
        {
            Combox_Name.DataSource = dt;
            Combox_Name.DisplayMember = "name";
            Combox_Name.ValueMember = "id";
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void Set_Controls()
        {
            Name_TextBox_OriginalText = FatherName_TextBox_OriginalText = LastName_TextBox_OriginalText =
            EName_TextBox_OriginalText = EFatherName_TextBox_OriginalText = ELastName_TextBox_OriginalText =
            NationalityNumber_TextBox_OriginalText = State_Note_OriginalText = Note_TextBox_OriginalText = PersonNote_TextBox_OriginalText =
            Stateyear_TextBox_OriginalText = StateAddress_TextBox_OriginalText= StateAddressNote_TextBox_OriginalText = AidAmount_29_Textbox_OriginalText = AidNote_29_Textbox_OriginalText =
            expenses_amount_9_TextBox_OriginalText = expenses_amount_4_TextBox_OriginalText = expenses_amount_5_TextBox_OriginalText =
            expenses_amount_24_TextBox_OriginalText = aid_amount_21_TextBox_OriginalText = aid_amount_1_TextBox_OriginalText = aid_amount_13_TextBox_OriginalText =
            aid_amount_6_TextBox_OriginalText = aid_amount_8_TextBox_OriginalText = operation_name_2_TextBox_OriginalText = operation_value_2_TextBox_OriginalText =
            operation_name_1_TextBox_OriginalText = operation_value_1_TextBox_OriginalText = aid_amount_10_TextBox_OriginalText =
            educationnote_TextBox_OriginalText = educationnote2_TextBox_OriginalText = expenses_amount_2_TextBox_OriginalText =
            expenses_amount_8_TextBox_OriginalText = aid_amount_2_TextBox_OriginalText = aid_amount_23_TextBox_OriginalText
            = needs_note_TextBox_OriginalText = needs_note_TextBox_OriginalText = "";

            General_Information_IsDirty = Receiver_IsDirty = WorkExp_DataGridView_IsDirty = Educated_Information_IsDirty =
            Education_DataGridView_IsDirty = Disease_DataGridView_IsDirty = Expenses_Information_IsDirty = Aids_Information_IsDirty =
            Military_Information_IsDirty = MP_DataGridView_IsDirty = Needs_IsDirty = State_IsDirty  = Maritalstatus_IsDirty = link_family = false;

            FirstName = FatherName = LastName = EName = EFatherName = ELastName = NationalityNumber = DOB = Form_Name = State_Note = Note = Stateyear  = isAidAmount = isAidReason = OperationName_2 = OperationName_1 =
            EducationNote = EducationNote2 = needs_note = needs_courses = PersonNote = "";

            Sex_ID = Nationality_ID = MaritalStatus_ID = State_ID = StateAddress_ID = IsEducated = IsStudent = IsReciever = Relation_ID =
            OperationValue_2 = OperationValue_1 = ExpensesAmount_9 = ExpensesAmount_4 = ExpensesAmount_5 = ExpensesAmount_24 =
            AidAmount_21 = AidAmount_1 = AidAmount_13 = AidAmount_6 = AidAmount_8 = aidperiod_29 = Expensestype_9 = Expensestype_4 = Expensestype_5 = Expensestype_24 =
            aidsource_21 = aidsource_1 = aidsource_13 = aidsource_6 = aidsource_8 =
            aidperiod_21 = aidperiod_1 = aidperiod_13 = aidperiod_6 = aidperiod_8 = aidsource_10 = AidAmount_10 = education_id_1 =
            education_id_2 = educationfield_id_1 = educationfield_id_2 = educationtype_id_1 = educationtype_id_2 = Expensestype_8 = Expensestype_2 = ExpensesAmount_8 =
            ExpensesAmount_2 = aidsource_2 = aidsource_23 = aidperiod_2 = aidperiod_23 = AidAmount_2 = AidAmount_23 = 0;
            aidsource_29 = hasDisease = isMP = isAid10 = 0;
            WorkExp_Query = Education_Query = Disease_Query = Aid_Query = Expenses_Query = MP_Query = Military_Query = "";

            //Education_DataGridView.Enabled = false;
            //IsStudent_RadioButton.Visible = false;

            //State_Note_Label.Visible = false;
            //State_Note_TextBox.Visible = false;

            if (!UpdateMode)
            {
                //Save_Button.Visible = true;
                SavePerson_Button.Visible = true;
                Delete_Button.Visible = UpdatePerson_Button.Visible
                    = Update_Button.Visible
                    = StateHistory_Button.Visible = MaritalHistory_Button.Visible = false;
                State_TextBox.Visible = State_Label.Visible = false;
                Relation_ComboBox.Visible = Relation_Label.Visible = false;
                State_ComboBox.Visible = State_Label1.Visible = false;
                StateYear_Lable.Visible = Stateyear_TextBox.Visible = true;
                StateAddress_Lable.Visible = StateAddress_ComboBox.Visible = true;
                StateAddressNote_Lable.Visible = StateAddressNote_TextBox.Visible = true;
                isAidAmount_Lable.Visible = AidAmount_29_Textbox.Visible = false;
                isAidPeriod_Lable.Visible = AidPeriod_29_comboBox.Visible = false;
                AidNote_29_Lable.Visible = AidNote_29_Textbox.Visible = false;
                needs_courses_TextBox.Visible = needs_note_TextBox.Visible = false;
                visit_TextBox.Visible = visitLabel.Visible = false;
            }
            else if (UpdateMode)
            {
                //Save_Button.Visible = false;
                SavePerson_Button.Visible= false; 
                Delete_Button.Visible = UpdatePerson_Button.Visible = Update_Button.Visible = true;
                    StateHistory_Button.Visible = MaritalHistory_Button.Visible = true;

                State_TextBox.Visible = State_Label.Visible = true;
                visit_TextBox.Visible = visitLabel.Visible = true;
                if (Receiver_RadioButton.Checked)
                {
                    Relation_ComboBox.Visible = Relation_Label.Visible = false;
                    State_ComboBox.Visible = State_Label1.Visible = false;
                }
                else
                {
                    Relation_ComboBox.Visible = Relation_Label.Visible = true;
                    State_ComboBox.Visible = State_Label1.Visible = true;
                }
                //if (!string.IsNullOrWhiteSpace(State_Note_TextBox.Text))
                //{
                //    State_Note_Label.Visible = true;
                //    State_Note_TextBox.Visible = true;
                //}
                if (Educated_RadioButton.Checked)
                {
                    //Education_DataGridView.Enabled = true;
                    IsStudent_RadioButton.Visible = true;
                }
                else
                {
                    //Education_DataGridView.Enabled = false;
                    IsStudent_RadioButton.Visible = false;
                }
            }
        }

        private void Clear_Boxes()
        {
            // Clear Inserted data
            //UserMode = false;

            FamilyCode_TextBox.Clear();
            State_TextBox.Clear();

            FirstName_TextBox.Clear();
            FatherName_TextBox.Clear();
            LastName_TextBox.Clear();
            NationalityNumber_TextBox.Clear();
            EName_TextBox.Clear();
            EFatherName_TextBox.Clear();
            ELastName_TextBox.Clear();
            Stateyear_TextBox.Clear();
            StateAddressNote_TextBox.Clear();
            AidAmount_29_Textbox.Clear();
            AidNote_29_Textbox.Clear();
            expenses_amount_9_TextBox.Clear();
            expenses_amount_4_TextBox.Clear();
            expenses_amount_5_TextBox.Clear();
            expenses_amount_24_TextBox.Clear();
            aid_amount_21_TextBox.Clear();
            aid_amount_1_TextBox.Clear();
            aid_amount_13_TextBox.Clear();
            aid_amount_6_TextBox.Clear();
            aid_amount_8_TextBox.Clear();
            operation_name_2_TextBox.Clear();
            operation_value_2_TextBox.Clear();
            operation_name_1_TextBox.Clear();
            operation_value_1_TextBox.Clear();
            aid_amount_10_TextBox.Clear();
            aid_amount_10_TextBox.Clear();
            educationnote_TextBox.Clear();
            educationnote2_TextBox.Clear();
            expenses_amount_8_Textbox.Clear();
            expenses_amount_2_TextBox.Clear();
            needs_note_TextBox.Clear();
            needs_courses_TextBox.Clear();
            aid_amount_2_TextBox.Clear();
            aid_amount_23_TextBox.Clear();
            needs_note_TextBox.Clear();
            needs_courses_TextBox.Clear();
            PersonNote_TextBox.Clear();

            Sex_ComboBox.SelectedIndex = 0;
            Nationality_ComboBox.SelectedIndex = 0;
            MaritalStatus_ComboBox.SelectedIndex = 0;
            AidPeriod_29_comboBox.SelectedIndex = 0;
            expensestype_9_comboBox.SelectedIndex = 0;
            expensestype_4_comboBox.SelectedIndex = 0;
            expensestype_5_comboBox.SelectedIndex = 0;
            expensestype_24_comboBox.SelectedIndex = 0;
            aidsource_21_comboBox.SelectedIndex = 0;
            aidsource_1_comboBox.SelectedIndex = 0;
            aidsource_13_comboBox.SelectedIndex = 0;
            aidsource_6_comboBox.SelectedIndex = 0;
            aidsource_8_comboBox.SelectedIndex = 0;
            aidperiod_21_comboBox.SelectedIndex = 0;
            aidperiod_1_comboBox.SelectedIndex = 0;
            aidperiod_13_comboBox.SelectedIndex = 0;
            aidperiod_6_comboBox.SelectedIndex = 0;
            aidperiod_8_comboBox.SelectedIndex = 0;
            aidsource_10_comboBox.SelectedIndex = 0;
            aidperiod_10_comboBox.SelectedIndex = 0;
            education_id_1_comboBox.SelectedIndex = 0;
            education_id_2_comboBox.SelectedIndex = 0;
            educationfield_id_1_comboBox.SelectedIndex = 0;
            educationfield_id_2_comboBox.SelectedIndex = 0;
            educationtype_id_1_comboBox.SelectedIndex = 0;
            educationtype_id_2_comboBox.SelectedIndex = 0;
            expensestype_8_comboBox.SelectedIndex = 0;
            expensestype_2_comboBox.SelectedIndex = 0;
            aidsource_2_comboBox.SelectedIndex = 0;
            aidsource_23_comboBox.SelectedIndex = 0;
            aidperiod_2_comboBox.SelectedIndex = 0;
            aidperiod_23_comboBox.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;

            State_ComboBox.SelectedIndex = 0;
            StateAddress_ComboBox.SelectedIndex = 0;
            Relation_ComboBox.SelectedIndex = 0;


            Receiver_RadioButton.Checked = false;
            NotReceiver_RadioButton.Checked = false;

            Educated_RadioButton.Checked = false;
            NotEducated_RadioButton.Checked = false;
            IsStudent_RadioButton.Checked = false;
            NotStudent_RadioButton.Checked = false;

            aid_No_10_RadioButton.Checked = false;
            aid_Yes_10_RadioButton.Checked = false;
            mp_No_RadioButton.Checked = false;
            mp_Yes_RadioButton.Checked = false;
            hasdisease_No_RadioButton.Checked = false;
            hasdisease_Yes_RadioButton.Checked = false;

            aidsource_29_No_RadioButton.Checked = false;
            aidsource_29_Yes_RadioButton.Checked = false;

            needs_0_checkBox.Checked = false;
            needs_1_checkBox.Checked = false;
            needs_2_checkBox.Checked = false;
            needs_3_checkBox.Checked = false;
            needs_4_checkBox.Checked = false;
            needs_5_checkBox.Checked = false;
            needs_6_checkBox.Checked = false;
            needs_7_checkBox.Checked = false;
            needs_8_checkBox.Checked = false;
            needs_9_checkBox.Checked = false;
            needs_10_checkBox.Checked = false;
            needs_12_checkBox.Checked = false;



            //State_Note_TextBox.Clear();

            WorkExp_DataGridView.Rows.Clear();
            MP_DataGridView.Rows.Clear();

            //Education_DataGridView.Rows.Clear();
            Disease_DataGridView.Rows.Clear();

            this.dateTimePicker1.CustomFormat = " ";
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;

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

                //    if (!UpdateMode)
                //    {
                //        Person_ID = p.Insert_Person(Family_ID, Visit_ID, FirstName, FatherName, LastName
                //            , EName, EFatherName, ELastName, IsReciever, Relation_ID, DOB, Sex_ID, Nationality_ID, MaritalStatus_ID, NationalityNumber, State_ID, Stateyear, StateAddress, aidsource_29, AidAmount_29, aidperiod_29, aidnote_29, hasDisease, ExpensesAmount_9, Expensestype_9, aidsource_21, AidAmount_21, aidperiod_21, aidsource_1, AidAmount_1, aidperiod_1, aidsource_13, AidAmount_13, aidperiod_13, OperationName_2, OperationValue_2, OperationName_1, OperationValue_1, ExpensesAmount_5, Expensestype_5, aidsource_8, AidAmount_8, aidperiod_8, ExpensesAmount_4, Expensestype_4, aidsource_6, AidAmount_6, aidperiod_6, ExpensesAmount_24, Expensestype_24, haswork, isMP, isAid10, aidsource_10, AidAmount_10, aidperiod_10, IsEducated, education_id_1, EducationNote, educationfield_id_1, educationtype_id_1, education_id_2, EducationNote2, educationfield_id_2, educationtype_id_2, IsStudent, ExpensesAmount_8, Expensestype_8, ExpensesAmount_2, Expensestype_2, aidsource_2, AidAmount_2, aidperiod_2, aidsource_23, AidAmount_23, aidperiod_23, Note, PersonNote,
                //        needs_0, needs_1, needs_2, needs_3, needs_4, needs_5, needs_6, needs_7, needs_8, needs_9, needs_10, needs_12, needs_courses, needs_note,
                //        WorkExp_Query, MP_Query, Disease_Query, Form_Name);
                //        //Person_ID = p.Insert_Person(Family_ID, FirstName, FatherName, LastName, EName, EFatherName, ELastName, NationalityNumber, Note, DOB,
                //        //    IsEducated, IsStudent, Sex_ID, Nationality_ID, MaritalStatus_ID, Relation_ID, State_ID, IsReciever,
                //        //   WorkExp_Query, Education_Query, Disease_Query, Form_Name);

                //        UpdateMode = true;

                //        MessageBox.Show("تم إدخال شخص جديد بنجاح", "Confirmation");
                //    }

                //    Set_Controls();

                //    Fill_Person(Visit_ID);
                //}
            }
            catch (Exception ex)
            {
                WorkExp_Query = Education_Query = Disease_Query = "";
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
                        if ( !General_Information_IsDirty
                            && !Receiver_IsDirty 
                            && !Military_Information_IsDirty

                            && !Aids_Information_IsDirty 
                            && !Expenses_Information_IsDirty

                            && !Educated_Information_IsDirty
                            && !MP_DataGridView_IsDirty 
                            && !WorkExp_DataGridView_IsDirty 
                            && !Disease_DataGridView_IsDirty 
                            && !Needs_IsDirty)
                        {
                            MessageBox.Show("لا يوجد أي تغييرات لحفظها ", "Error");
                            return;
                        }
                        else
                        {
                            Get_Data();
                            p.Update_PersonDetails(Person_ID, Visit_ID, FirstName_TextBox.Text, Family_ID
                                , General_Query, Receiver_Query, Expenses_Query, Aid_Query, Military_Query
                                , WorkExp_Query, MP_Query, Education_Query, Disease_Query, Needs_Query
                                , Form_Name);

                            MessageBox.Show("تم تعديل المعلومات بنجاح", "Confirmation");
                        }
                    }
                    Set_Controls();
                    Fill_Person(Visit_ID);
                    MEFamily_DataGridView.Visible = true;
                    visit_Label.Visible = true;
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
        private bool Check_Data(int type)
        {
            if (type == 0)
            {
                // fixed info
                if (string.IsNullOrWhiteSpace(FirstName_TextBox.Text) || string.IsNullOrWhiteSpace(LastName_TextBox.Text) || string.IsNullOrWhiteSpace(FatherName_TextBox.Text) || string.IsNullOrWhiteSpace(dateTimePicker1.Text))
                {
                    MessageBox.Show("تأكد من إدخال الاسم والكنية واسم الأب والمواليد في قسم معلومات الشخص", "Error");
                    return false;
                }

                if (!NationalityNumberChecked && General_Information_IsDirty)
                {
                    if (!Check_Nationality_Number())
                        return false;
                }

                if (   string.IsNullOrEmpty(Sex_ComboBox.Text)           || Sex_ComboBox.SelectedIndex < 0 
                    || string.IsNullOrEmpty(Nationality_ComboBox.Text)   || Nationality_ComboBox.SelectedIndex < 0
                    || string.IsNullOrEmpty(MaritalStatus_ComboBox.Text) || MaritalStatus_ComboBox.SelectedIndex < 0 )
                {
                    MessageBox.Show("الرجاء التأكد من تحديد جنس الشخص وجنسيته و وضعه الإجتماعي في قسم معلومات الشخص", "Error");
                    return false;
                }
                
                if (!Receiver_RadioButton.Checked && !NotReceiver_RadioButton.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد اذا ما كان الشخص مستلم أم لا في قسم معلومات الشخص ضمن العائلة", "Error");
                    return false;
                }
                
                if (NotReceiver_RadioButton.Checked && (string.IsNullOrEmpty(State_ComboBox.Text) || State_ComboBox.SelectedIndex < 0))
                {
                    MessageBox.Show("الرجاء التأكد من تحديد الحالة في قسم معلومات الشخص ضمن العائلة", "Error");
                    return false;
                }
                
                if (NotReceiver_RadioButton.Checked && (string.IsNullOrEmpty(Relation_ComboBox.Text) || Relation_ComboBox.SelectedIndex <= 0))
                {
                    MessageBox.Show("الرجاء التأكد من تحديد العلاقة في قسم معلومات الشخص ضمن العائلة", "Error");
                    return false;
                }

                if (!ReciverChecked && Receiver_IsDirty && Receiver_RadioButton.Checked)
                {
                    if (!Check_Reciver())
                        return false;
                }
            }
            else
            { 
                if (Visit_ID == -1)
                {
                    MessageBox.Show("الرجاء التأكد من اختيار الزيارة للتعديل عليها ثم المحاولة مرة ثانية", "Error");
                    return false;
                }
                // Added by Judy to add VisitDetails Row if it is missing
                p.Check_PersonVisitDetails(Family_ID, Person_ID, Visit_ID);
                // ///////////////////////////////////////////////////////

                if (!haswork_Yes_RadioButton.Checked && !haswork_No_RadioButton.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد اذا كان هناك عمل حالي أم لا", "Error");
                    return false;
                } 

                int VisibleRows = 0;
                if (haswork_Yes_RadioButton.Checked)
                {
                    for (int i = 0; i < WorkExp_DataGridView.Rows.Count - 1; i++)
                    {
                        if (WorkExp_DataGridView.Rows[i].Cells["workexp_id"].Value == null || WorkExp_DataGridView.Rows[i].Cells["workexp_id"].Value.ToString() == ""
                            || WorkExp_DataGridView.Rows[i].Cells["workfor_id"].Value == null || WorkExp_DataGridView.Rows[i].Cells["workfor_id"].Value.ToString() == ""
                            //|| WorkExp_DataGridView.Rows[i].Cells["worktype_id"].Value == null || WorkExp_DataGridView.Rows[i].Cells["worktype_id"].Value.ToString() == ""
                            || WorkExp_DataGridView.Rows[i].Cells["workposition_id"].Value == null || WorkExp_DataGridView.Rows[i].Cells["workposition_id"].Value.ToString() == ""
                            || WorkExp_DataGridView.Rows[i].Cells["experience_id"].Value == null || WorkExp_DataGridView.Rows[i].Cells["experience_id"].Value.ToString() == "")
                            //|| WorkExp_DataGridView.Rows[i].Cells["workexpamount"].Value == null || WorkExp_DataGridView.Rows[i].Cells["workexpamount"].Value.ToString() == "")
                        {
                            MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم العمل", "Error");
                            return false;
                        }
                        if (WorkExp_DataGridView.Rows[i].Visible)
                        {
                            VisibleRows++;
                        }
                    }
                    if (WorkExp_DataGridView.Rows.Count - 1 == 0)
                    {
                        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم العمل", "Error");
                        return false;
                    }
                }

                if (!mp_Yes_RadioButton.Checked && !mp_No_RadioButton.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد اذا كان الشخص مستفيد من مشاريع صغيرة أم لا", "Error");
                    return false;
                }

                VisibleRows = 0;
                if (mp_Yes_RadioButton.Checked)
                {
                    for (int i = 0; i < MP_DataGridView.Rows.Count - 1; i++)
                    {
                        if (MP_DataGridView.Rows[i].Cells["mp_fundyear"].Value == null || MP_DataGridView.Rows[i].Cells["mp_fundyear"].Value.ToString() == "")
                        {
                            MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم المشاريع الصغيرة", "Error");
                            return false;
                        }
                        if (MP_DataGridView.Rows[i].Visible)
                        {
                            VisibleRows++;
                        }
                    }
                    if (MP_DataGridView.Rows.Count - 1 == 0)
                    {
                        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم المشاريع الصغيرة", "Error");
                        return false;
                    }
                }

                if (!Educated_RadioButton.Checked && !NotEducated_RadioButton.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد اذا كان الشخص متعلم أم لا", "Error");
                    return false;
                }

                if (Educated_RadioButton.Checked)
                {
                    if (education_id_1_comboBox.SelectedIndex < 0 || educationtype_id_1_comboBox.SelectedIndex < 0)
                    {
                        MessageBox.Show("الرجاء التأكد من إدخال معلومات التعليم في قسم التعليم", "Error");
                        return false;
                    }
                }

                if (!hasdisease_Yes_RadioButton.Checked && !hasdisease_No_RadioButton.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد اذا كان هناك مرض أم لا", "Error");
                    return false;
                }
                
                VisibleRows = 0;
                if (hasdisease_Yes_RadioButton.Checked)
                {
                    for (int i = 0; i < Disease_DataGridView.Rows.Count - 1; i++)
                    {
                        if (Disease_DataGridView.Rows[i].Cells["Disease"].Value == null || Disease_DataGridView.Rows[i].Cells["Disease"].Value.ToString() == "")
                        {
                            MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم الأمراض", "Error");
                            return false;
                        }
                        if (Disease_DataGridView.Rows[i].Visible)
                        {
                            VisibleRows++;
                        }
                    }
                }

                if (Sex_ID == 1 && !aid_Yes_10_RadioButton.Checked && !aid_No_10_RadioButton.Checked)
                {
                    MessageBox.Show("الرجاء التأكد من تحديد اذا كان هناك مساعدة في بدل عسكرية", "Error");
                    return false;
                }
                if (aid_Yes_10_RadioButton.Checked)
                {
                    if (aidsource_10_comboBox.SelectedIndex < 0)
                    {
                        MessageBox.Show("الرجاء التأكد من إدخال المعلومات في قسم المساعدة في بدل العسكرية", "Error");
                        return false;
                    }
                }

            }

            //for (int i = 0; i < Education_DataGridView.Rows.Count - 1; i++)
            //{
            //    if (Education_DataGridView.Rows[i].Cells["Education_Type"].Value == null || Education_DataGridView.Rows[i].Cells["Education_Type"].Value.ToString() == "" ||
            //    Education_DataGridView.Rows[i].Cells["Education"].Value == null || Education_DataGridView.Rows[i].Cells["Education"].Value.ToString() == "")
            //    {
            //        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم التعليم", "Error");
            //        return false;
            //    }
            //    if (Education_DataGridView.Rows[i].Visible)
            //    {
            //        VisibleRows++;
            //    }
            //}
            //if (Educated_RadioButton.Checked)
            //{
            //    if (VisibleRows == 0)
            //    {
            //        MessageBox.Show("الرجاء التأكد من إدخال معلومات التعليم في قسم التعليم", "Error");
            //        return false;
            //    }
            //}

            //VisibleRows = 0;
            //for (int i = 0; i < Disease_DataGridView.Rows.Count - 1; i++)
            //{
            //    if (Disease_DataGridView.Rows[i].Cells["Disease_Category"].Value == null || Disease_DataGridView.Rows[i].Cells["Disease_Category"].Value.ToString() == ""
            //        || Disease_DataGridView.Rows[i].Cells["Disease"].Value == null || Disease_DataGridView.Rows[i].Cells["Disease"].Value.ToString() == "")
            //    {
            //        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في قسم الأمراض", "Error");
            //        return false;
            //    }
            //}
            //for (int i = 0; i < Disease_DataGridView.Rows.Count - 1; i++)
            //{
            //    if (Disease_DataGridView.Rows[i].Visible == true)
            //    {
            //        for (int j = i + 1; j < Disease_DataGridView.Rows.Count - 1; j++)
            //        {
            //            if (Disease_DataGridView.Rows[j].Visible == true && (int)Disease_DataGridView.Rows[i].Cells["Disease_Category"].Value == (int)Disease_DataGridView.Rows[j].Cells["Disease_Category"].Value && (int)Disease_DataGridView.Rows[i].Cells["Disease"].Value == (int)Disease_DataGridView.Rows[j].Cells["Disease"].Value)
            //            {
            //                MessageBox.Show("الرجاء التأكد من عدم وجود تكرار في جدول الأمراض", "Error");
            //                return false;
            //            }
            //        }
            //    }
            //}
            return true;
        }
        private void Get_Data()
        {
            #region
            if (!UpdateMode)
            {
                FirstName = FirstName_TextBox.Text;
                FatherName = FatherName_TextBox.Text;
                LastName = LastName_TextBox.Text;
                EName = EName_TextBox.Text;
                EFatherName = EFatherName_TextBox.Text;
                ELastName = ELastName_TextBox.Text;
                NationalityNumber = NationalityNumber_TextBox.Text;
                Note = Note_TextBox.Text;
                PersonNote = PersonNote_TextBox.Text;

                #region needs
                if (needs_0_checkBox.Checked)
                    needs_0 = 1;
                else needs_0 = 0;
                if (needs_1_checkBox.Checked)
                    needs_1 = 1;
                else needs_1 = 0;
                if (needs_2_checkBox.Checked)
                    needs_2 = 1;
                else needs_2 = 0;
                if (needs_3_checkBox.Checked)
                    needs_3 = 1;
                else needs_3 = 0;
                if (needs_4_checkBox.Checked)
                    needs_4 = 1;
                else needs_4 = 0;
                if (needs_5_checkBox.Checked)
                    needs_5 = 1;
                else needs_5 = 0;
                if (needs_6_checkBox.Checked)
                    needs_6 = 1;
                else needs_6 = 0;
                if (needs_7_checkBox.Checked)
                    needs_7 = 1;
                else needs_7 = 0;
                if (needs_8_checkBox.Checked)
                    needs_8 = 1;
                else needs_8 = 0;
                if (needs_9_checkBox.Checked)
                    needs_9 = 1;
                else needs_9 = 0;
                if (needs_10_checkBox.Checked)
                    needs_10 = 1;
                else needs_10 = 0;
                if (needs_12_checkBox.Checked)
                    needs_12 = 1;
                else needs_12 = 0;
                #endregion
                 
                needs_courses = needs_courses_TextBox.Text;
                needs_note = needs_note_TextBox.Text;

                if (string.IsNullOrWhiteSpace(dateTimePicker1.Text))
                {
                    DOB = "";
                }
                else
                {
                    DOB = dateTimePicker1.Value.ToString("yyyy-MM-dd", new CultureInfo("en-GB"));  //Convert to UK format
                }
                Sex_ID = int.Parse(Sex_ComboBox.SelectedValue.ToString());
                Nationality_ID = int.Parse(Nationality_ComboBox.SelectedValue.ToString());


                OperationValue_2 = operation_value_2_TextBox.Text == "" ? 0 : int.Parse(operation_value_2_TextBox.Text);
                OperationValue_1 = operation_value_1_TextBox.Text == "" ? 0 : int.Parse(operation_value_1_TextBox.Text);
                ExpensesAmount_9 = expenses_amount_9_TextBox.Text == "" ? 0 : int.Parse(expenses_amount_9_TextBox.Text);
                ExpensesAmount_4 = expenses_amount_4_TextBox.Text == "" ? 0 : int.Parse(expenses_amount_4_TextBox.Text);
                ExpensesAmount_5 = expenses_amount_5_TextBox.Text == "" ? 0 : int.Parse(expenses_amount_5_TextBox.Text);
                ExpensesAmount_24 = expenses_amount_2_TextBox.Text == "" ? 0 : int.Parse(expenses_amount_2_TextBox.Text);
                AidAmount_21 = aid_amount_21_TextBox.Text == "" ? 0 : int.Parse(aid_amount_21_TextBox.Text);
                AidAmount_1 = aid_amount_1_TextBox.Text == "" ? 0 : int.Parse(aid_amount_1_TextBox.Text);
                AidAmount_13 = aid_amount_13_TextBox.Text == "" ? 0 : int.Parse(aid_amount_13_TextBox.Text);
                AidAmount_6 = aid_amount_6_TextBox.Text == "" ? 0 : int.Parse(aid_amount_6_TextBox.Text);
                AidAmount_8 = aid_amount_8_TextBox.Text == "" ? 0 : int.Parse(aid_amount_8_TextBox.Text);
                Expensestype_9 = expensestype_9_comboBox.SelectedValue == null ? 0 : int.Parse(expensestype_9_comboBox.SelectedValue.ToString());
                Expensestype_4 = expensestype_4_comboBox.SelectedValue == null ? 0 : int.Parse(expensestype_4_comboBox.SelectedValue.ToString());
                Expensestype_5 = expensestype_5_comboBox.SelectedValue == null ? 0 : int.Parse(expensestype_5_comboBox.SelectedValue.ToString());
                Expensestype_24 = expensestype_24_comboBox.SelectedValue == null ? 0 : int.Parse(expensestype_24_comboBox.SelectedValue.ToString());
                aidperiod_21 = aidperiod_21_comboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_21_comboBox.SelectedValue.ToString());
                aidperiod_1 = aidperiod_1_comboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_1_comboBox.SelectedValue.ToString());
                aidperiod_13 = aidperiod_13_comboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_13_comboBox.SelectedValue.ToString());
                aidperiod_6 = aidperiod_6_comboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_6_comboBox.SelectedValue.ToString());
                aidperiod_8 = aidperiod_8_comboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_8_comboBox.SelectedValue.ToString());
                aidsource_2 = aidsource_2_comboBox.SelectedValue == null ? 0 : int.Parse(aidsource_2_comboBox.SelectedValue.ToString());
                aidsource_23 = aidsource_23_comboBox.SelectedValue == null ? 0 : int.Parse(aidsource_23_comboBox.SelectedValue.ToString());
                aidperiod_2 = aidperiod_2_comboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_2_comboBox.SelectedValue.ToString());
                aidperiod_23 = aidperiod_23_comboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_23_comboBox.SelectedValue.ToString());
                aidperiod_10 = aidperiod_10_comboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_10_comboBox.SelectedValue.ToString());
                aidsource_21 = aidsource_21_comboBox.SelectedValue == null ? 0 : int.Parse(aidsource_21_comboBox.SelectedValue.ToString());
                aidsource_1 = aidsource_1_comboBox.SelectedValue == null ? 0 : int.Parse(aidsource_1_comboBox.SelectedValue.ToString());
                aidsource_13 = aidsource_13_comboBox.SelectedValue == null ? 0 : int.Parse(aidsource_13_comboBox.SelectedValue.ToString());
                aidsource_6 = aidsource_6_comboBox.SelectedValue == null ? 0 : int.Parse(aidsource_6_comboBox.SelectedValue.ToString());
                aidsource_8 = aidsource_8_comboBox.SelectedValue == null ? 0 : int.Parse(aidsource_8_comboBox.SelectedValue.ToString());
                aidsource_10 = aidsource_10_comboBox.SelectedValue == null ? 0 : int.Parse(aidsource_10_comboBox.SelectedValue.ToString());
                ExpensesAmount_2 = expenses_amount_2_TextBox.Text == "" ? 0 : int.Parse(expenses_amount_2_TextBox.Text);
                AidAmount_2 = aid_amount_2_TextBox.Text == "" ? 0 : int.Parse(aid_amount_2_TextBox.Text);
                AidAmount_23 = aid_amount_23_TextBox.Text == "" ? 0 : int.Parse(aid_amount_23_TextBox.Text);
                AidAmount_10 = aid_amount_10_TextBox.Text == "" ? 0 : int.Parse(aid_amount_10_TextBox.Text);
                ExpensesAmount_8 = expenses_amount_8_Textbox.Text == "" ? 0 : int.Parse(expenses_amount_8_Textbox.Text);
                Expensestype_8 = expensestype_8_comboBox.SelectedValue == null ? 0 : int.Parse(expensestype_8_comboBox.SelectedValue.ToString());
                Expensestype_2 = expensestype_2_comboBox.SelectedValue == null ? 0 : int.Parse(expensestype_2_comboBox.SelectedValue.ToString());
                educationtype_id_1 = educationtype_id_1_comboBox.SelectedValue == null ? 0 : int.Parse(educationtype_id_1_comboBox.SelectedValue.ToString());
                educationtype_id_2 = educationtype_id_2_comboBox.SelectedValue == null ? 0 : int.Parse(educationtype_id_2_comboBox.SelectedValue.ToString());
                educationfield_id_1 = educationfield_id_1_comboBox.SelectedValue == null ? 0 : int.Parse(educationfield_id_1_comboBox.SelectedValue.ToString());
                educationfield_id_2 = educationfield_id_2_comboBox.SelectedValue == null ? 0 : int.Parse(educationfield_id_2_comboBox.SelectedValue.ToString());
                aidperiod_29 = AidPeriod_29_comboBox.SelectedValue == null ? 0 : int.Parse(AidPeriod_29_comboBox.SelectedValue.ToString());
                education_id_1 = education_id_1_comboBox.SelectedValue == null ? 0 : int.Parse(education_id_1_comboBox.SelectedValue.ToString());
                education_id_2 = education_id_2_comboBox.SelectedValue == null ? 0 : int.Parse(education_id_2_comboBox.SelectedValue.ToString());
                EducationNote = educationnote_TextBox.Text;
                EducationNote2 = educationnote2_TextBox.Text;
                if (aid_No_10_RadioButton.Checked)
                {
                    isAid10 = 0;
                }
                else if (aid_Yes_10_RadioButton.Checked)
                {
                    isAid10 = 10;
                }
                else
                {
                    isAid10 = null;
                }


                MaritalStatus_ID = int.Parse(MaritalStatus_ComboBox.SelectedValue.ToString());

                if (Receiver_LayoutPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text == "نعم")
                {
                    IsReciever = 1;
                    Relation_ID = 0; //N/A
                    State_ID = 1; //مقيم
                    State_ComboBox.SelectedIndex = 0;
                    
                    //Stateyear = "";
                    //StateAddress = "";

                    // State_ComboBox.SelectedItem = State_ComboBox.Items.IndexOf("مقيم");
                    // State_ID = int.Parse(State_ComboBox.SelectedValue.ToString()); 
                }
                else
                {
                    IsReciever = 0;
                    Relation_ID = int.Parse(Relation_ComboBox.SelectedValue.ToString());
                    State_ID = int.Parse(State_ComboBox.SelectedValue.ToString());


                }

                Stateyear = Stateyear_TextBox.Text;
                StateAddress_ID = int.Parse(StateAddress_ComboBox.SelectedValue.ToString());
                StateAddressNote = StateAddressNote_TextBox.Text;
                AidAmount_29 = AidAmount_29_Textbox.Text == "" ? 0 : int.Parse(AidAmount_29_Textbox.Text);
                aidnote_29 = AidNote_29_Textbox.Text;
                OperationName_2 = operation_name_2_TextBox.Text;
                OperationName_1 = operation_name_1_TextBox.Text;

                if (aidsource_29_Yes_RadioButton.Checked)
                {
                    aidsource_29 = 29;
                }
                else if (aidsource_29_No_RadioButton.Checked)
                {
                    aidsource_29 = 0;
                }
                else
                {
                    aidsource_29 = null;
                }
                 
                if (haswork_No_RadioButton.Checked)
                {
                    haswork = 0;
                }
                else if (haswork_Yes_RadioButton.Checked)
                {
                    haswork = 1;
                }
                else
                {
                    haswork = null;
                }

                for (int i = 0; i < WorkExp_DataGridView.Rows.Count - 1; i++)
                {
                    int workexp_id = WorkExp_DataGridView.Rows[i].Cells["workexp_id"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["workexp_id"].Value.ToString());
                    int workfor_id = WorkExp_DataGridView.Rows[i].Cells["workfor_id"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["workfor_id"].Value.ToString());
                    int worktype_id = WorkExp_DataGridView.Rows[i].Cells["worktype_id"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["worktype_id"].Value.ToString());
                    int workposition_id = WorkExp_DataGridView.Rows[i].Cells["workposition_id"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["workposition_id"].Value.ToString());
                    int experience_id = WorkExp_DataGridView.Rows[i].Cells["experience_id"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["experience_id"].Value.ToString());
                    int workexpamount = WorkExp_DataGridView.Rows[i].Cells["workexpamount"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["workexpamount"].Value.ToString());
                    string workname = WorkExp_DataGridView.Rows[i].Cells["workname"].Value == null ? "" : WorkExp_DataGridView.Rows[i].Cells["workname"].Value.ToString();
                    int workplace_id = WorkExp_DataGridView.Rows[i].Cells["workplace_id"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["workplace_id"].Value.ToString());
                    int expenses_amount_6 = WorkExp_DataGridView.Rows[i].Cells["expenses_amount_6"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expenses_amount_6"].Value.ToString());
                    int expensestype_6 = WorkExp_DataGridView.Rows[i].Cells["expensestype_6"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expensestype_6"].Value.ToString());
                    int expensesAmperNumber_7 = WorkExp_DataGridView.Rows[i].Cells["expensesAmperNumber_7"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expensesAmperNumber_7"].Value.ToString());
                    int expenses_amount_7 = WorkExp_DataGridView.Rows[i].Cells["expenses_amount_7"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expenses_amount_7"].Value.ToString());
                    int expenses_amount_15 = WorkExp_DataGridView.Rows[i].Cells["expenses_amount_15"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expenses_amount_15"].Value.ToString());
                    int expensestype_15 = WorkExp_DataGridView.Rows[i].Cells["expensestype_15"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expensestype_15"].Value.ToString());
                    int expenses_amount_16 = WorkExp_DataGridView.Rows[i].Cells["expenses_amount_16"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expenses_amount_16"].Value.ToString());
                    int expensestype_16 = WorkExp_DataGridView.Rows[i].Cells["expensestype_16"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expensestype_16"].Value.ToString());
                    int expenses_amount_17 = WorkExp_DataGridView.Rows[i].Cells["expenses_amount_17"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expenses_amount_17"].Value.ToString());
                    int expensestype_17 = WorkExp_DataGridView.Rows[i].Cells["expensestype_17"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expensestype_17"].Value.ToString());
                    int expenses_amount_23 = WorkExp_DataGridView.Rows[i].Cells["expenses_amount_23"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expenses_amount_23"].Value.ToString());
                    int expensestype_23 = WorkExp_DataGridView.Rows[i].Cells["expensestype_23"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expensestype_23"].Value.ToString());
                    string Work_Note = WorkExp_DataGridView.Rows[i].Cells["workexpnote"].Value == null ? "" : WorkExp_DataGridView.Rows[i].Cells["workexpnote"].Value.ToString();
                    if (workposition_id != 2 && workposition_id != 3 && workposition_id != 6)
                    {
                        workplace_id = expensestype_15 = expensestype_16 = expensestype_17 = expensestype_23 = 0;
                        expensesAmperNumber_7 = expenses_amount_7 = expenses_amount_15 = expenses_amount_16 = expenses_amount_17 = expenses_amount_23 = 0;
                    }
                    if (workplace_id != 1)
                    {
                        expenses_amount_6 = expensestype_6 = 0;
                    }


                    WorkExp_Query += "(@person_id,'" + workexp_id + "', '" + workfor_id + "', '" + worktype_id + "', '" + workposition_id + "', '" + experience_id + "', '" + workexpamount + "', '" + workname + "', '" + workplace_id + "', '" + expenses_amount_6 + "', '" + expensestype_6 +
                        "', '" + expensesAmperNumber_7 + "', '" + expenses_amount_7 + "', '" + expenses_amount_15 + "', '" + expensestype_15 +
                        "', '" + expenses_amount_16 + "', '" + expensestype_16 + "', '" + expenses_amount_17 + "', '" + expensestype_17 +
                        "', '" + expenses_amount_23 + "', '" + expensestype_23 + "', '" + Work_Note + "')";
                    if (i < WorkExp_DataGridView.Rows.Count - 2)
                        WorkExp_Query += ",";
                }

                if (Educated_RadioButton.Checked)
                {
                    IsEducated = 1;
                }
                else if (NotEducated_RadioButton.Checked)
                {
                    IsEducated = 0;
                    IsStudent = 0;
                }
                if (IsStudent_RadioButton.Checked)
                {
                    IsStudent = 1;
                }
                else if (NotStudent_RadioButton.Checked)
                {
                    IsStudent = 0;
                }
                
                if (hasdisease_No_RadioButton.Checked)
                {
                    hasDisease = 0;
                }
                else if (hasdisease_Yes_RadioButton.Checked)
                {
                    hasDisease = 1;
                }
                else
                {
                    hasDisease = null;
                }
                for (int i = 0; i < Disease_DataGridView.Rows.Count - 1; i++)
                {
                    string Disease_Note = Disease_DataGridView.Rows[i].Cells["DiseaseNote"].Value == null ? "" : Disease_DataGridView.Rows[i].Cells["DiseaseNote"].Value.ToString();
                    Disease_Query += "(@person_id,'" + (int)Disease_DataGridView.Rows[i].Cells["Disease"].Value + "', '" + Disease_Note + "')";
                    if (i < Disease_DataGridView.Rows.Count - 2)
                        Disease_Query += ",";
                }


                if (mp_No_RadioButton.Checked)
                {
                    isMP = 0;
                }
                else if (mp_Yes_RadioButton.Checked)
                {
                    isMP = 1;
                }
                else
                {
                    isMP = null;
                }
                for (int i = 0; i < MP_DataGridView.Rows.Count - 1; i++)
                {
                    string mp_fundyear = MP_DataGridView.Rows[i].Cells["mp_fundyear"].Value == null ? "" : MP_DataGridView.Rows[i].Cells["mp_fundyear"].Value.ToString();
                    int aidsource_5_mp = MP_DataGridView.Rows[i].Cells["aidsource_5_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aidsource_5_mp"].Value.ToString());
                    int aid_amount_5_mp = MP_DataGridView.Rows[i].Cells["aid_amount_5_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aid_amount_5_mp"].Value.ToString());
                    int aidperiod_5_mp = MP_DataGridView.Rows[i].Cells["aidperiod_5_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aidperiod_5_mp"].Value.ToString());
                    int aidsource_17_mp = MP_DataGridView.Rows[i].Cells["aidsource_17_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aidsource_17_mp"].Value.ToString());
                    int aid_amount_17_mp = MP_DataGridView.Rows[i].Cells["aid_amount_17_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aid_amount_17_mp"].Value.ToString());
                    int aidperiod_17_mp = MP_DataGridView.Rows[i].Cells["aidperiod_17_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aidperiod_17_mp"].Value.ToString());
                    int aidsource_22_mp = MP_DataGridView.Rows[i].Cells["aidsource_22_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aidsource_22_mp"].Value.ToString());
                    int aid_amount_22_mp = MP_DataGridView.Rows[i].Cells["aid_amount_22_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aid_amount_22_mp"].Value.ToString());
                    int aidperiod_22_mp = MP_DataGridView.Rows[i].Cells["aidperiod_22_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aidperiod_22_mp"].Value.ToString());
                    int expenses_amount_12_mp = MP_DataGridView.Rows[i].Cells["expenses_amount_12_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["expenses_amount_12_mp"].Value.ToString());
                    int expensestype_12_mp = MP_DataGridView.Rows[i].Cells["expensestype_12_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["expensestype_12_mp"].Value.ToString());


                    MP_Query += "(@person_id,'" + mp_fundyear + "', '" + aidsource_5_mp + "', '" + aid_amount_5_mp + "', '" + aidperiod_5_mp + "', '" + aidsource_17_mp + "', '" + aid_amount_17_mp + "', '" + aidperiod_17_mp + "', '" + aidsource_22_mp + "', '" + aid_amount_22_mp + "', '" + aidperiod_22_mp +
                            "', '" + expenses_amount_12_mp + "', '" + expensestype_12_mp + "')";
                    if (i < MP_DataGridView.Rows.Count - 2)
                        MP_Query += ",";
                }
                if (aid_No_10_RadioButton.Checked)
                {
                    isAid10 = 0;
                }
                else if (aid_Yes_10_RadioButton.Checked)
                {
                    isAid10 = 10;
                }
                else
                {
                    isAid10 = null;
                }

                Form_Name = this.Name;
            }
            #endregion
            #region
            else if (UpdateMode)
            {
                if (General_Information_IsDirty)
                {
                    FirstName = FirstName_TextBox.Text;
                    FatherName = FatherName_TextBox.Text;
                    LastName = LastName_TextBox.Text;
                    EName = EName_TextBox.Text;
                    EFatherName = EFatherName_TextBox.Text;
                    ELastName = ELastName_TextBox.Text;
                    NationalityNumber = NationalityNumber_TextBox.Text;
                    Note = Note_TextBox.Text;
                     
                    if (string.IsNullOrWhiteSpace(dateTimePicker1.Text))
                        DOB = "";
                    else DOB = dateTimePicker1.Value.ToString("yyyy-MM-dd", new CultureInfo("en-GB"));  //Convert to UK format

                    Sex_ID = int.Parse(Sex_ComboBox.SelectedValue.ToString());
                    Nationality_ID = int.Parse(Nationality_ComboBox.SelectedValue.ToString());
                    if (FirstName != ""         || FatherName != ""  || LastName != "" 
                     || EName != ""             || EFatherName != "" || ELastName != ""
                     || NationalityNumber != "" || Note != ""        || DOB != "" 
                     || Sex_ID != 0             || Nationality_ID != 0)
                    {
                        General_Query += "UPDATE person set first_name = '" + Program.CleanString(FirstName) 
                            + "', father_name = '"   + Program.CleanString(FatherName) 
                            + "', last_name = '"     + Program.CleanString(LastName)
                            + "', first_name_e = '"  + Program.CleanString(EName)
                            + "', last_name_e = '"   + Program.CleanString(ELastName) 
                            + "', father_name_e = '" + Program.CleanString(EFatherName) 
                            + "', national_Number = '" + NationalityNumber 
                            + "', Note = '" + Note
                            + "', DOB = '" + DOB 
                            + "', sex_id = '" + Sex_ID 
                            + "', nationality_id = '" + Nationality_ID
                            + "' where id = '" + Person_ID + "';"; 
                    }
                }

                if (Receiver_IsDirty || State_IsDirty)
                { 
                    if (Receiver_LayoutPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text == "نعم")
                    {
                        IsReciever = 1;
                        Relation_ID = 0; // N/A
                        State_ComboBox.SelectedIndex = 0;
                        State_ID = 1;
                        
                        //Stateyear = "";
                        //StateAddress = "";
                    }
                    else
                    {
                        IsReciever = 0;
                        Relation_ID = int.Parse(Relation_ComboBox.SelectedValue.ToString());
                        State_ID = int.Parse(State_ComboBox.SelectedValue.ToString());
                        
                        //Stateyear = Stateyear_TextBox.Text;
                        //StateAddress = StateAddress_TextBox.Text; 
                    }
                    Stateyear = Stateyear_TextBox.Text;
                    StateAddress_ID = int.Parse(StateAddress_ComboBox.SelectedValue.ToString());
                    StateAddressNote = StateAddressNote_TextBox.Text;
                    //Save History
                    

                    if (aidsource_29_Yes_RadioButton.Checked)
                    {
                        aidsource_29 = 29;
                        AidAmount_29 = int.Parse(AidAmount_29_Textbox.Text);
                        aidperiod_29 = int.Parse(AidPeriod_29_comboBox.SelectedValue.ToString());
                    }
                    else if (aidsource_29_No_RadioButton.Checked)
                    {
                        aidsource_29 = 0;
                        aidnote_29 = AidNote_29_Textbox.Text;
                    }
                     
                    Receiver_Query += "UPDATE person_state set current_state = 0 where person_id = " + Person_ID + " and family_id = " + Family_ID + ";";
                    Receiver_Query += "INSERT INTO person_state(family_id, person_id, personstate_id, stateaddress_id,State_Note, personstate_year" +
                                        " , aidsource_29,aid_amount_29,aidperiod_29,aid_note_29,current_state,date) " +
                                        "VALUES( " + Family_ID + ","  + Person_ID + ","  + State_ID +
                                        ","
                                        + StateAddress_ID +
                                        ",'"
                                        + StateAddressNote +
                                        "', '" 
                                        + Stateyear +
                                        "', " 
                                        + aidsource_29 +
                                        ", '" 
                                        + AidAmount_29 +
                                        "', " 
                                        + aidperiod_29 +
                                        ", '" 
                                        + aidnote_29 
                                        + "', 1 ,DATE(NOW()));";

                    if (State_IsDirty)
                    {
                        Receiver_Query += "INSERT INTO familymembersnumber (family_id, NumberOfBeneficiaries, NumberOfAllMembers, Note, date) VALUES "
                                           + " (@Family_ID, "
                                           + " (SELECT COUNT(person_family.id) AS 'NumberOfBeneficiaries' " +
                                                    " FROM person_family " +
                                                    " Left JOIN person_state on person_family.person_id = person_state.person_id " +
                                                    " left JOIN personstate on person_state.personstate_id = personstate.id " +

                                                    " WHERE person_family.family_id = @Family_ID " +
                                                    " and person_state.family_id = @Family_ID  " +
                                                    " and person_state.current_state = '1' " +
                                                    " and LOWER(personstate.type) = LOWER('Active') " +
                                                    " and person_state.family_id = @Family_ID),"
                                           + " (SELECT COUNT(person_family.id) AS 'NumberOfAllMembers' " +
                                                    " FROM person_family " +
                                                    " WHERE person_family.family_id = @Family_ID),"
                                           + " CONCAT('Person state updated Person_ID: ', @Person_ID),"
                                           + " DATE(NOW()));";
                    }
                    if (link_family)
                    {
                        Receiver_Query += "INSERT INTO person_family (family_id, person_id, relation_id, isReceiver) VALUES(" + Family_ID + "," + Person_ID + ", '" + Relation_ID + "', '" + IsReciever + "');";
                        link_family = false;
                    }
                    else
                    {
                        Receiver_Query += "UPDATE person_family SET isReceiver = '" + IsReciever + "' ,relation_id = '" + Relation_ID + "' WHERE person_id = " + Person_ID + " and family_id = " + Family_ID + ";";
                    }

                }

                if (Maritalstatus_IsDirty)
                {
                    if (int.Parse(MaritalStatus_ComboBox.SelectedValue.ToString()) != 0)
                        MaritalStatus_ID = int.Parse(MaritalStatus_ComboBox.SelectedValue.ToString());

                    Receiver_Query += "UPDATE person_maritalstatus set current_state = 0 where person_id = " + Person_ID + ";";
                    Receiver_Query += "INSERT INTO person_maritalstatus(person_id, maritalstatus_id, current_state, date) VALUES(" + Person_ID + ", " + MaritalStatus_ID + ", 1 ,DATE(NOW()));";
                }

                if (Expenses_Information_IsDirty)
                {
                    ExpensesAmount_9 = expenses_amount_9_TextBox.Text == "" ? 0 :int.Parse(expenses_amount_9_TextBox.Text);
                    ExpensesAmount_4 = expenses_amount_4_TextBox.Text == "" ? 0 : int.Parse(expenses_amount_4_TextBox.Text);
                    ExpensesAmount_5 = expenses_amount_5_TextBox.Text == "" ? 0 : int.Parse(expenses_amount_5_TextBox.Text);
                    ExpensesAmount_24 = expenses_amount_24_TextBox.Text == "" ? 0 : int.Parse(expenses_amount_24_TextBox.Text);
                    Expensestype_9 = int.Parse(expensestype_9_comboBox.SelectedValue.ToString());
                    Expensestype_4 = int.Parse(expensestype_4_comboBox.SelectedValue.ToString());
                    Expensestype_5 = int.Parse(expensestype_5_comboBox.SelectedValue.ToString());
                    Expensestype_24 = int.Parse(expensestype_24_comboBox.SelectedValue.ToString());

                    Expenses_Query += "UPDATE person_visitdetails set expenses_amount_9 = '" + ExpensesAmount_9 + "', expenses_amount_4 = '" + ExpensesAmount_4 + "', expenses_amount_5 = '" + ExpensesAmount_5 + "', expenses_amount_24 = '" + ExpensesAmount_24
                                                    + "', expensestype_9 = '" + Expensestype_9 + "', expensestype_4 = '" + Expensestype_4 + "', expensestype_5 = '" + Expensestype_5 + "', expensestype_24 = '" + Expensestype_24
                                                    + "' where person_id = '" + Person_ID
                                                    + "' and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                }
                if (Aids_Information_IsDirty)
                {
                    aidsource_21 = int.Parse(aidsource_21_comboBox.SelectedValue.ToString());
                    aidsource_1 = int.Parse(aidsource_1_comboBox.SelectedValue.ToString());
                    aidsource_13 = int.Parse(aidsource_13_comboBox.SelectedValue.ToString());
                    aidsource_6 = int.Parse(aidsource_6_comboBox.SelectedValue.ToString());
                    aidsource_8 = int.Parse(aidsource_8_comboBox.SelectedValue.ToString());
                    aidperiod_21 = int.Parse(aidperiod_21_comboBox.SelectedValue.ToString());
                    aidperiod_1 = int.Parse(aidperiod_1_comboBox.SelectedValue.ToString());
                    aidperiod_13 = int.Parse(aidperiod_13_comboBox.SelectedValue.ToString());
                    aidperiod_6 = int.Parse(aidperiod_6_comboBox.SelectedValue.ToString());
                    aidperiod_8 = int.Parse(aidperiod_8_comboBox.SelectedValue.ToString());
                    AidAmount_21 = aid_amount_21_TextBox.Text == "" ? 0 : int.Parse(aid_amount_21_TextBox.Text);
                    AidAmount_1 = aid_amount_1_TextBox.Text == "" ? 0 : int.Parse(aid_amount_1_TextBox.Text);
                    AidAmount_13 = aid_amount_13_TextBox.Text == "" ? 0 : int.Parse(aid_amount_13_TextBox.Text);
                    AidAmount_6 = aid_amount_6_TextBox.Text == "" ? 0 : int.Parse(aid_amount_6_TextBox.Text);
                    AidAmount_8 = aid_amount_8_TextBox.Text == "" ? 0 : int.Parse(aid_amount_8_TextBox.Text);
                    OperationName_2 = operation_name_2_TextBox.Text;
                    OperationName_1 = operation_name_1_TextBox.Text;
                    OperationValue_1 = operation_value_1_TextBox.Text == "" ? 0 : int.Parse(operation_value_1_TextBox.Text); ;
                    OperationValue_2 = operation_value_2_TextBox.Text == "" ? 0 : int.Parse(operation_value_2_TextBox.Text); ;

                    Aid_Query += "UPDATE person_visitdetails set aidsource_21 = '" + aidsource_21 + "', aidsource_1 = '" + aidsource_1 + "', aidsource_13 = '" + aidsource_13 + "', aidsource_6 = '" + aidsource_6
                                                                      + "', aidsource_8 = '" + aidsource_8 + "', aidperiod_21 = '" + aidperiod_21 + "', aidperiod_1 = '" + aidperiod_1 + "', aidperiod_13 = '" + aidperiod_13
                                                                      + "', aidperiod_6 = '" + aidperiod_6 + "', aidperiod_8 = '" + aidperiod_8 + "', aid_amount_21 = '" + AidAmount_21 + "', aid_amount_1 = '" + AidAmount_1 + "', aid_amount_13 = '" + AidAmount_13
                                                                      + "', aid_amount_6 = '" + AidAmount_6 + "', aid_amount_8 = '" + AidAmount_8
                                                                      + "', operation_name_2 = '" + OperationName_2 + "', operation_value_2 = '" + OperationValue_2
                                                                      + "', operation_name_1 = '" + OperationName_1 + "', operation_value_1 = '" + OperationValue_1
                                                                      + "' where person_id = '" + Person_ID
                                                                      + "' and person_visitdetails.family_visit_id = " + Visit_ID + ";";

                }
                if (Military_Information_IsDirty)
                {
                    if (aid_Yes_10_RadioButton.Checked)
                    {
                        isAid10 = 10;
                    }
                    else if (aid_No_10_RadioButton.Checked)
                    {
                        isAid10 = 0;
                    }
                    aidsource_10 = aidsource_10_comboBox.SelectedValue == null ? 0 : int.Parse(aidsource_10_comboBox.SelectedValue.ToString());
                    AidAmount_10 = aid_amount_10_TextBox.Text == "" ? 0 : int.Parse(aid_amount_10_TextBox.Text);
                    aidperiod_10 = aidperiod_10_comboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_10_comboBox.SelectedValue.ToString());
                    Military_Query += "UPDATE person_visitdetails set aid_10 = '" + isAid10 + "', aidsource_10 = '" + aidsource_10 + "', aid_amount_10 = '" + AidAmount_10 + "', aidperiod_10 = '" + aidperiod_10
                                                                    + "' where person_visitdetails.person_id = '" + Person_ID
                                                                    + "' and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                }
                if (WorkExp_DataGridView_IsDirty)
                {
                    if (haswork_Yes_RadioButton.Checked)
                    {
                        haswork = 1;
                    }
                    else if (haswork_No_RadioButton.Checked)
                    {
                        haswork = 0;
                    }
                    for (int i = 0; i < WorkExp_DataGridView.Rows.Count - 1; i++)
                    {
                        if (WorkExp_DataGridView.Rows[i].Visible == false)
                        {
                            WorkExp_Query += "DELETE FROM person_workexp WHERE id = '" + WorkExp_DataGridView.Rows[i].Cells["Person_Work_ID"].Value + "';";
                            WorkExp_Query += "update person_visitdetails set haswork = " + haswork + " where person_visitdetails.person_id = " + Person_ID
                                           + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                        }
                        else if (WorkExp_DataGridView.Rows[i].Cells["Work_IsDirty"].Value != null && (int)WorkExp_DataGridView.Rows[i].Cells["Work_IsDirty"].Value == 1)
                        {
                            int Work_VisitName = Visit_ID;
                            int workexp_id = WorkExp_DataGridView.Rows[i].Cells["workexp_id"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["workexp_id"].Value.ToString());
                            int workfor_id = WorkExp_DataGridView.Rows[i].Cells["workfor_id"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["workfor_id"].Value.ToString());
                            int worktype_id = WorkExp_DataGridView.Rows[i].Cells["worktype_id"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["worktype_id"].Value.ToString());
                            int workposition_id = WorkExp_DataGridView.Rows[i].Cells["workposition_id"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["workposition_id"].Value.ToString());
                            int experience_id = WorkExp_DataGridView.Rows[i].Cells["experience_id"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["experience_id"].Value.ToString());
                            int workexpamount = WorkExp_DataGridView.Rows[i].Cells["workexpamount"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["workexpamount"].Value.ToString());
                            string workname = WorkExp_DataGridView.Rows[i].Cells["workname"].Value == null ? "" : WorkExp_DataGridView.Rows[i].Cells["workname"].Value.ToString();
                            int workplace_id = WorkExp_DataGridView.Rows[i].Cells["workplace_id"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["workplace_id"].Value.ToString());
                            int expenses_amount_6 = WorkExp_DataGridView.Rows[i].Cells["expenses_amount_6"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expenses_amount_6"].Value.ToString());
                            int expensestype_6 = WorkExp_DataGridView.Rows[i].Cells["expensestype_6"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expensestype_6"].Value.ToString());
                            int expensesAmperNumber_7 = WorkExp_DataGridView.Rows[i].Cells["expensesAmperNumber_7"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expensesAmperNumber_7"].Value.ToString());
                            int expenses_amount_7 = WorkExp_DataGridView.Rows[i].Cells["expenses_amount_7"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expenses_amount_7"].Value.ToString());
                            int expenses_amount_15 = WorkExp_DataGridView.Rows[i].Cells["expenses_amount_15"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expenses_amount_15"].Value.ToString());
                            int expensestype_15 = WorkExp_DataGridView.Rows[i].Cells["expensestype_15"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expensestype_15"].Value.ToString());
                            int expenses_amount_16 = WorkExp_DataGridView.Rows[i].Cells["expenses_amount_16"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expenses_amount_16"].Value.ToString());
                            int expensestype_16 = WorkExp_DataGridView.Rows[i].Cells["expensestype_16"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expensestype_16"].Value.ToString());
                            int expenses_amount_17 = WorkExp_DataGridView.Rows[i].Cells["expenses_amount_17"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expenses_amount_17"].Value.ToString());
                            int expensestype_17 = WorkExp_DataGridView.Rows[i].Cells["expensestype_17"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expensestype_17"].Value.ToString());
                            int expenses_amount_23 = WorkExp_DataGridView.Rows[i].Cells["expenses_amount_23"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expenses_amount_23"].Value.ToString());
                            int expensestype_23 = WorkExp_DataGridView.Rows[i].Cells["expensestype_23"].Value == null ? 0 : int.Parse(WorkExp_DataGridView.Rows[i].Cells["expensestype_23"].Value.ToString());
                            string Work_Note = WorkExp_DataGridView.Rows[i].Cells["workexpnote"].Value == null ? "" : WorkExp_DataGridView.Rows[i].Cells["workexpnote"].Value.ToString();
                            if (WorkExp_DataGridView.Rows[i].Cells["Person_Work_ID"].Value != null)
                            {
                                WorkExp_Query += "UPDATE person_workexp set workexp_id = '" + workexp_id + "', visit_id = '" + Work_VisitName + "', workfor_id = '" + workfor_id + "', worktype_id = '" + worktype_id + "', workposition_id = '" + workposition_id
                                                                      + "', experience_id = '" + experience_id + "', workexpamount = '" + workexpamount + "', workname = '" + workname + "', workplace_id = '" + workplace_id
                                                                      + "', expenses_amount_6 = '" + expenses_amount_6 + "', expensestype_6 = '" + expensestype_6 + "', expensesAmperNumber_7 = '" + expensesAmperNumber_7 + "', expenses_amount_7 = '" + expenses_amount_7
                                                                      + "', expenses_amount_15 = '" + expenses_amount_15 + "', expensestype_15 = '" + expensestype_15 + "', expenses_amount_16 = '" + expenses_amount_16 + "', expensestype_16 = '" + expensestype_16
                                                                      + "', expenses_amount_17 = '" + expenses_amount_17 + "', expensestype_17 = '" + expensestype_17 + "', expenses_amount_23 = '" + expenses_amount_23 + "', expensestype_23 = '" + expensestype_23
                                                                      + "', workexpnote = '" + Work_Note
                                                                      + "' where id = " + (int)WorkExp_DataGridView.Rows[i].Cells["Person_Work_ID"].Value + ";";
                                WorkExp_Query += "update person_visitdetails set haswork = " + haswork + " where person_visitdetails.person_id = " + Person_ID + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                            }
                            else
                            {
                                WorkExp_Query += "INSERT INTO person_workexp (person_id,visit_id, workexp_id, workposition_id, workfor_id, worktype_id, workexpamount, experience_id, workname, workplace_id, expenses_amount_6, expensestype_6, workexpnote, expenses_amount_7, expensesAmperNumber_7, expenses_amount_15, expensestype_15, expenses_amount_16, expensestype_16, expenses_amount_17, expensestype_17, expenses_amount_23, expensestype_23) " +
                                    "VALUES ('" + Person_ID + "', '" + Work_VisitName + "', '" + workexp_id + "', '" + workposition_id + "','" + workfor_id + "','" + worktype_id + "','" + workexpamount + "','" + experience_id + "','" + workname + "', '" + workplace_id + "', '"
                                                + expenses_amount_6 + "','" + expensestype_6 + "', '" + Work_Note + "' ,'" + expenses_amount_7 + "', '" + expensesAmperNumber_7 + "', '" +
                                                +expenses_amount_15 + "','" + expensestype_15 + "', '"
                                                + expenses_amount_16 + "','" + expensestype_16 + "', '"
                                                + expenses_amount_17 + "','" + expensestype_17 + "', '"
                                                + expenses_amount_23 + "','" + expensestype_23 + "');";
                                WorkExp_Query += "update person_visitdetails set haswork = " + haswork + " where person_visitdetails.person_id = " + Person_ID + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";

                            }
                        }
                    }
                    if (WorkExp_DataGridView.Rows.Count - 1 == 0)
                    {
                        WorkExp_Query += "DELETE FROM person_workexp WHERE person_id = '" + Person_ID + "' and visit_id = " + Visit_ID + ";";
                        WorkExp_Query += "update person_visitdetails set haswork = " + haswork + " where person_visitdetails.person_id = " + Person_ID + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                    }
                }
                if (Educated_Information_IsDirty)
                {
                    if (Educated_RadioButton.Checked)
                    {
                        IsEducated = 1;
                        education_id_1 = education_id_1_comboBox.SelectedValue == null ? 0 : int.Parse(education_id_1_comboBox.SelectedValue.ToString());
                        education_id_2 = education_id_2_comboBox.SelectedValue == null ? 0 : int.Parse(education_id_2_comboBox.SelectedValue.ToString());
                        educationtype_id_1 = educationtype_id_1_comboBox.SelectedValue == null ? 0 : int.Parse(educationtype_id_1_comboBox.SelectedValue.ToString());
                        educationtype_id_2 = educationtype_id_2_comboBox.SelectedValue == null ? 0 : int.Parse(educationtype_id_2_comboBox.SelectedValue.ToString());
                        educationfield_id_1 = educationfield_id_1_comboBox.SelectedValue == null ? 0 : int.Parse(educationfield_id_1_comboBox.SelectedValue.ToString());
                        educationfield_id_2 = educationfield_id_2_comboBox.SelectedValue == null ? 0 : int.Parse(educationfield_id_2_comboBox.SelectedValue.ToString());
                        EducationNote = educationnote_TextBox.Text;
                        EducationNote2 = educationnote2_TextBox.Text;
                    }
                    else if (NotEducated_RadioButton.Checked)
                    {
                        IsEducated = 0;
                        IsStudent = 0;
                        education_id_1 = 0;
                        education_id_2 = 0;
                        educationtype_id_1 = 0;
                        educationtype_id_2 = 0;
                        educationfield_id_1 = 0;
                        educationfield_id_2 = 0;
                        EducationNote = "";
                        EducationNote2 = "";
                    }
                    if (IsStudent_RadioButton.Checked)
                    {
                        IsStudent = 1;
                    }
                    else if (NotStudent_RadioButton.Checked)
                    {
                        IsStudent = 0;
                    }
                    
                    Expensestype_8 = expensestype_8_comboBox.SelectedValue == null ? 0 : int.Parse(expensestype_8_comboBox.SelectedValue.ToString());
                    Expensestype_2 = expensestype_2_comboBox.SelectedValue == null ? 0 : int.Parse(expensestype_2_comboBox.SelectedValue.ToString());
                    ExpensesAmount_8 = expenses_amount_8_Textbox.Text == "" ? 0 : int.Parse(expenses_amount_8_Textbox.Text.ToString());
                    ExpensesAmount_2 = expenses_amount_2_TextBox.Text == "" ? 0 : int.Parse(expenses_amount_2_TextBox.Text.ToString());

                    aidsource_2 = aidsource_2_comboBox.SelectedValue == null ? 0 : int.Parse(aidsource_2_comboBox.SelectedValue.ToString());
                    aidsource_23 = aidsource_23_comboBox.SelectedValue == null ? 0 : int.Parse(aidsource_23_comboBox.SelectedValue.ToString());
                    aidperiod_2 = aidperiod_2_comboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_2_comboBox.SelectedValue.ToString());
                    aidperiod_23 = aidperiod_23_comboBox.SelectedValue == null ? 0 : int.Parse(aidperiod_23_comboBox.SelectedValue.ToString());
                    AidAmount_2 = aid_amount_2_TextBox.Text == "" ? 0 : int.Parse(aid_amount_2_TextBox.Text);
                    AidAmount_23 = aid_amount_23_TextBox.Text == "" ? 0 : int.Parse(aid_amount_23_TextBox.Text);

                    
                     Education_Query += "UPDATE person set isEducated = '" + IsEducated + "', educationtype_id = '" + educationtype_id_1 + "', educationtype_id_2 = '" + educationtype_id_2
                                    + "', educationfield_id = '" + educationfield_id_1 + "', educationfield_id_2 = '" + educationfield_id_2
                                    + "', education_id = '" + education_id_1 + "', education_id_2 = '" + education_id_2
                                    + "', educationnote = '" + EducationNote + "', educationnote2 = '" + EducationNote2
                                    + "' where id = '" + Person_ID + "';";
                   

                   
                        Education_Query += "UPDATE person_visitdetails set isStudent = '" + IsStudent + "', expensestype_8 = '" + Expensestype_8 + "', expensestype_2 = '" + Expensestype_2
                                    + "', expenses_amount_8 = '" + ExpensesAmount_8 + "', expenses_amount_2 = '" + ExpensesAmount_2
                                    + "', aidsource_2 = '" + aidsource_2 + "', aidsource_23 = '" + aidsource_23
                                    + "', aidperiod_2 = '" + aidperiod_2 + "', aidperiod_23 = '" + aidperiod_23
                                    + "', aid_amount_2 = '" + AidAmount_2 + "', aid_amount_23 = '" + AidAmount_23
                                    + "' where person_id = '" + Person_ID + "' and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                   
                }
                if (MP_DataGridView_IsDirty)
                {
                    if (mp_Yes_RadioButton.Checked)
                    {
                        isMP = 1;
                    }
                    else if (mp_No_RadioButton.Checked)
                    {
                        isMP = 0;
                    }
                    for (int i = 0; i < MP_DataGridView.Rows.Count - 1; i++)
                    {
                        if (MP_DataGridView.Rows[i].Visible == false)
                        {
                            MP_Query += "DELETE FROM person_mp_aid WHERE id = '" + MP_DataGridView.Rows[i].Cells["Person_MP_ID"].Value + "';";
                            MP_Query += "update person_visitdetails set hasmicroproject = " + isMP + " where person_visitdetails.person_id = " + Person_ID + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                        }
                        else if (MP_DataGridView.Rows[i].Cells["MP_IsDirty"].Value != null && (int)MP_DataGridView.Rows[i].Cells["MP_IsDirty"].Value == 1)
                        {
                            int MP_VisitName = Visit_ID;
                            string mp_fundyear = MP_DataGridView.Rows[i].Cells["mp_fundyear"].Value == null ? "" : MP_DataGridView.Rows[i].Cells["mp_fundyear"].Value.ToString();
                            int aidsource_5_mp = MP_DataGridView.Rows[i].Cells["aidsource_5_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aidsource_5_mp"].Value.ToString());
                            int aid_amount_5_mp = MP_DataGridView.Rows[i].Cells["aid_amount_5_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aid_amount_5_mp"].Value.ToString());
                            int aidperiod_5_mp = MP_DataGridView.Rows[i].Cells["aidperiod_5_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aidperiod_5_mp"].Value.ToString());
                            int aidsource_17_mp = MP_DataGridView.Rows[i].Cells["aidsource_17_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aidsource_17_mp"].Value.ToString());
                            int aid_amount_17_mp = MP_DataGridView.Rows[i].Cells["aid_amount_17_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aid_amount_17_mp"].Value.ToString());
                            int aidperiod_17_mp = MP_DataGridView.Rows[i].Cells["aidperiod_17_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aidperiod_17_mp"].Value.ToString());
                            int aidsource_22_mp = MP_DataGridView.Rows[i].Cells["aidsource_22_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aidsource_22_mp"].Value.ToString());
                            int aid_amount_22_mp = MP_DataGridView.Rows[i].Cells["aid_amount_22_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aid_amount_22_mp"].Value.ToString());
                            int aidperiod_22_mp = MP_DataGridView.Rows[i].Cells["aidperiod_22_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["aidperiod_22_mp"].Value.ToString());
                            int expenses_amount_12_mp = MP_DataGridView.Rows[i].Cells["expenses_amount_12_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["expenses_amount_12_mp"].Value.ToString());
                            int expensestype_12_mp = MP_DataGridView.Rows[i].Cells["expensestype_12_mp"].Value == null ? 0 : int.Parse(MP_DataGridView.Rows[i].Cells["expensestype_12_mp"].Value.ToString());

                            if (MP_DataGridView.Rows[i].Cells["Person_MP_ID"].Value != null)
                            {
                                MP_Query += "UPDATE person_mp_aid set visit_id = " + MP_VisitName + ", mp_fundyear = '" + mp_fundyear + "', aidsource_5_mp = '" + aidsource_5_mp + "', aid_amount_5_mp = '" + aid_amount_5_mp + "', aidperiod_5_mp = '" + aidperiod_5_mp
                                                                      + "', aidsource_17_mp = '" + aidsource_17_mp + "', aid_amount_17_mp = '" + aid_amount_17_mp + "', aidperiod_17_mp = '" + aidperiod_17_mp + "', aidsource_22_mp = '" + aidsource_22_mp
                                                                      + "', aid_amount_22_mp = '" + aid_amount_22_mp + "', aidperiod_22_mp = '" + aidperiod_22_mp + "', expenses_amount_12_mp = '" + expenses_amount_12_mp + "', expensestype_12_mp = '" + expensestype_12_mp
                                                                      + "' where id = '" + int.Parse(MP_DataGridView.Rows[i].Cells["Person_MP_ID"].Value.ToString()) + "';";
                                MP_Query += "update person_visitdetails set hasmicroproject = " + isMP + " where person_visitdetails.person_id = " + Person_ID + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                            }
                            else
                            {
                                MP_Query += "INSERT INTO person_mp_aid (person_id,visit_id, mp_fundyear, aidsource_5_mp, aid_amount_5_mp, aidperiod_5_mp, aidsource_17_mp, aid_amount_17_mp, aidperiod_17_mp, aidsource_22_mp, aid_amount_22_mp, aidperiod_22_mp, expenses_amount_12_mp, expensestype_12_mp) VALUES ('" + Person_ID + "', '" + MP_VisitName + "', '" + mp_fundyear + "', '" + aidsource_5_mp + "', '" + aid_amount_5_mp + "','" + aidperiod_5_mp + "','" + aidsource_17_mp + "','" + aid_amount_17_mp + "','" + aidperiod_17_mp + "', '" + aidsource_22_mp + "','" + aid_amount_22_mp + "', '"
                                                + aidperiod_22_mp + "','" + expenses_amount_12_mp + "', '" + expensestype_12_mp + "');";
                                MP_Query += "update person_visitdetails set hasmicroproject = " + isMP + " where person_visitdetails.person_id = " + Person_ID + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                            }
                        }
                    }
                    if (MP_DataGridView.Rows.Count - 1 == 0)
                    {
                        MP_Query += "DELETE FROM person_mp_aid WHERE person_id = '" + Person_ID + "' and visit_id = " + Visit_ID + ";";
                        MP_Query += "update person_visitdetails set hasmicroproject = " + isMP + " where person_visitdetails.person_id = " + Person_ID + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                    }
                }
                if (Disease_DataGridView_IsDirty)
                {
                    if (hasdisease_Yes_RadioButton.Checked)
                    {
                        hasDisease = 1;
                    }
                    else if (hasdisease_No_RadioButton.Checked)
                    {
                        hasDisease = 0;
                    }
                    for (int i = 0; i < Disease_DataGridView.Rows.Count - 1; i++)
                    {
                        if (Disease_DataGridView.Rows[i].Visible == false)
                        {
                            Disease_Query += "DELETE FROM person_disease WHERE id = '" + Disease_DataGridView.Rows[i].Cells["Person_Disease_ID"].Value + "';";
                            Disease_Query += "update person_visitdetails set hasdisease = " + hasDisease + " where person_visitdetails.person_id = " + Person_ID + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                        }
                        else if (Disease_DataGridView.Rows[i].Cells["Disease_IsDirty"].Value != null && (int)Disease_DataGridView.Rows[i].Cells["Disease_IsDirty"].Value == 1)
                        {
                            int Disease_VisitName = Visit_ID;
                            string Disease_Note = Disease_DataGridView.Rows[i].Cells["DiseaseNote"].Value == null ? "" : Disease_DataGridView.Rows[i].Cells["DiseaseNote"].Value.ToString();
                            if (Disease_DataGridView.Rows[i].Cells["Person_Disease_ID"].Value != null)
                            {
                                Disease_Query += "UPDATE person_disease set visit_id = " + Disease_VisitName + ", disease_id = '" + (int)Disease_DataGridView.Rows[i].Cells["Disease"].Value + "', disease_Note = '" + Disease_Note + "' where id = '" + (int)Disease_DataGridView.Rows[i].Cells["Person_Disease_ID"].Value + "';";
                                Disease_Query += "update person_visitdetails set hasdisease = " + hasDisease + " where person_visitdetails.person_id = " + Person_ID + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                            }
                            else
                            {
                                Disease_Query += "INSERT INTO person_disease (person_id,visit_id, disease_id, disease_Note) VALUES ('" + Person_ID + "', '" + Disease_VisitName + "', '" + (int)Disease_DataGridView.Rows[i].Cells["Disease"].Value + "', '" + Disease_Note + "');";
                                Disease_Query += "update person_visitdetails set hasdisease = " + hasDisease + " where person_visitdetails.person_id = " + Person_ID + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                            }
                        }
                    }
                    if (Disease_DataGridView.Rows.Count - 1 == 0)
                    {
                        Disease_Query += "DELETE FROM person_disease WHERE person_id = '" + Person_ID + "' and visit_id = "+ Visit_ID +";";
                        Disease_Query += "update person_visitdetails set hasdisease = " + hasDisease + " where person_visitdetails.person_id = " + Person_ID + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                    }
                }
                if (Needs_IsDirty)
                {
                    needs_0 = needs_0_checkBox.Checked ? 1 : 0;
                    needs_1 = needs_1_checkBox.Checked ? 1 : 0;
                    needs_2 = needs_2_checkBox.Checked ? 1 : 0;
                    needs_3 = needs_3_checkBox.Checked ? 1 : 0;
                    needs_4 = needs_4_checkBox.Checked ? 1 : 0;
                    needs_5 = needs_5_checkBox.Checked ? 1 : 0;
                    needs_6 = needs_6_checkBox.Checked ? 1 : 0;
                    needs_7 = needs_7_checkBox.Checked ? 1 : 0;
                    needs_8 = needs_8_checkBox.Checked ? 1 : 0;
                    needs_9 = needs_9_checkBox.Checked ? 1 : 0;
                    needs_10 = needs_10_checkBox.Checked ? 1 : 0;
                    needs_12 = needs_12_checkBox.Checked ? 1 : 0;

                    needs_courses = needs_courses_TextBox.Text;
                    needs_note = needs_note_TextBox.Text;

                    Needs_Query = " update person_visitdetails set `needs/0` = " + needs_0 
                        + ",`needs/1` =" + needs_1 + ",`needs/2` =" + needs_2 + ",`needs/3` =" + needs_3 
                        + ",`needs/4` =" + needs_4 + ",`needs/5` =" + needs_5 + ",`needs/6` =" + needs_6 
                        + ",`needs/7` =" + needs_7 + ",`needs/8` =" + needs_8 + ",`needs/9` =" + needs_9 
                        + ",`needs/10` =" + needs_10 + ",`needs/12` =" + needs_12
                        + ",needs_special_courses = '" + needs_courses + "',needs_note = '" + needs_note + "'"
                        + " where person_visitdetails.person_id = " + Person_ID 
                        + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";

                    PersonNote = PersonNote_TextBox.Text;
                    Needs_Query += " UPDATE person_visitdetails set person_visitdetails.person_note = '" + PersonNote
                    + "' Where person_id = " + Person_ID
                    + " and person_visitdetails.family_visit_id = " + Visit_ID + ";";
                }
                 

                //if (Education_DataGridView_IsDirty)
                //{
                //    for (int i = 0; i < Education_DataGridView.Rows.Count - 1; i++)
                //    {
                //        if (Education_DataGridView.Rows[i].Visible == false)
                //            Education_Query += "DELETE FROM person_education WHERE id = '" + Education_DataGridView.Rows[i].Cells["Person_Education_ID"].Value + "';";
                //        else if (Education_DataGridView.Rows[i].Cells["Education_IsDirty"].Value != null && (int)Education_DataGridView.Rows[i].Cells["Education_IsDirty"].Value == 1)
                //        {
                //            string Education_Note = Education_DataGridView.Rows[i].Cells["EducationNote"].Value == null ? "" : Education_DataGridView.Rows[i].Cells["EducationNote"].Value.ToString();
                //            if (Education_DataGridView.Rows[i].Cells["Education_Type"].Value == null)
                //            {
                //                if (Education_DataGridView.Rows[i].Cells["Person_Education_ID"].Value != null)
                //                {
                //                    Education_Query += "UPDATE person_education set education_id = '" + (int)Education_DataGridView.Rows[i].Cells["Education"].Value + "', note = '" + Education_Note + "' where id = '" + (int)Education_DataGridView.Rows[i].Cells["Person_Education_ID"].Value + "';";
                //                }
                //                else
                //                {
                //                    Education_Query += "INSERT INTO person_education (person_id, education_id, note) VALUES ('" + Person_ID + "', '" + (int)Education_DataGridView.Rows[i].Cells["Education"].Value + "', '" + Education_Note + "');";
                //                }
                //            }
                //            else
                //            {
                //                if (Education_DataGridView.Rows[i].Cells["Person_Education_ID"].Value != null)
                //                {
                //                    Education_Query += "UPDATE person_education set education_id = '" + (int)Education_DataGridView.Rows[i].Cells["Education"].Value + "', educationtype_id = '" + (int)Education_DataGridView.Rows[i].Cells["Education_Type"].Value + "', note = '" + Education_Note + "' where id = '" + (int)Education_DataGridView.Rows[i].Cells["Person_Education_ID"].Value + "';";
                //                }
                //                else
                //                {
                //                    Education_Query += "INSERT INTO person_education (person_id, education_id, educationtype_id, note) VALUES ('" + Person_ID + "', '" + (int)Education_DataGridView.Rows[i].Cells["Education"].Value + "', '" + (int)Education_DataGridView.Rows[i].Cells["Education_Type"].Value + "', '" + Education_Note + "');";
                //                }
                //            }
                //        }
                //    }
                //}

                Form_Name = this.Name;
            }
            #endregion
        }
        private void Disease_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == Disease_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;
                if (e.ColumnIndex == Disease_DataGridView.Columns["Disease_DeleteRow"].Index)
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
        private void Education_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex == Education_DataGridView.NewRowIndex || e.RowIndex < 0)
            //        return;

            //    if (e.ColumnIndex == Education_DataGridView.Columns["Education_DeleteRow"].Index)
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
        private void WorkExp_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == WorkExp_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == WorkExp_DataGridView.Columns["Work_DeleteRow"].Index)
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
        private void Person_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    //this.ActiveControl = Save_Button;
                    this.ActiveControl = Update_Button;

                    if (General_Information_IsDirty || Receiver_IsDirty || Expenses_Information_IsDirty 
                        || Aids_Information_IsDirty || Military_Information_IsDirty || MP_DataGridView_IsDirty 
                        || WorkExp_DataGridView_IsDirty || Educated_Information_IsDirty || Education_DataGridView_IsDirty 
                        || Disease_DataGridView_IsDirty)
                    {
                        if (MessageBox.Show("يوجد بعض التعديلات غير المحفوظة، هل تود حفظها قبل إغلاق الصفحة؟؟", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (UpdateMode)
                                Update_Button.PerformClick();
                            else
                            {
                                //Save_Button.PerformClick();
                                SavePerson_Button.PerformClick();
                            }
                            //e.Cancel = true;
                            //return;
                        }
                        else
                        {
                            // continue closing;
                        }
                    }
                }
                Program.Person_Opened.Remove(Person_ID);

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
                DialogResult dialogResult = MessageBox.Show("سيتم حذف الشخص بشكل كامل!!", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    p.Delete_Person(Person_ID, FirstName_TextBox.Text, Family_ID, this.Name);

                    MessageBox.Show("تم حذف الشخص بنجاح", "Confirmation");
                    this.Close();
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
        private void Disease_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == Disease_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                //Check if click is on specific column 
                if (e.ColumnIndex == Disease_DataGridView.Columns["Disease_DeleteRow"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Disease_DataGridView.Rows[e.RowIndex].Cells["Person_Disease_ID"].Value != null)
                        {
                            Disease_DataGridView_IsDirty = true;
                            Disease_DataGridView.Rows[e.RowIndex].Cells["Disease_IsDirty"].Value = "1";
                            Disease_DataGridView.Rows[e.RowIndex].Visible = false;
                        }
                        else
                        {
                            Disease_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void Education_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    //if click is on new row or header row
            //    if (e.RowIndex == Education_DataGridView.NewRowIndex || e.RowIndex < 0)
            //        return;

            //    //Check if click is on specific column 
            //    if (e.ColumnIndex == Education_DataGridView.Columns["Education_DeleteRow"].Index)
            //    {
            //        DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            if (Education_DataGridView.Rows[e.RowIndex].Cells["Person_Education_ID"].Value != null)
            //            {
            //                Education_DataGridView_IsDirty = true;
            //                Education_DataGridView.Rows[e.RowIndex].Cells["Education_IsDirty"].Value = "1";
            //                Education_DataGridView.Rows[e.RowIndex].Visible = false;
            //            }
            //            else
            //            {
            //                Education_DataGridView.Rows.RemoveAt(e.RowIndex);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }
        private void WorkExp_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == WorkExp_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                //Check if click is on specific column 
                if (e.ColumnIndex == WorkExp_DataGridView.Columns["Work_DeleteRow"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (WorkExp_DataGridView.Rows[e.RowIndex].Cells["Person_Work_ID"].Value != null)
                        {
                            WorkExp_DataGridView_IsDirty = true;
                            WorkExp_DataGridView.Rows[e.RowIndex].Cells["Work_IsDirty"].Value = "1";
                            WorkExp_DataGridView.Rows[e.RowIndex].Visible = false;
                        }
                        else
                        {
                            WorkExp_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void Disease_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == Disease_DataGridView.Columns["Disease_Category"].Index)
                {
                    if (Disease_DataGridView.Rows[e.RowIndex].Cells["Disease_Category"].Value != null)
                    {
                        int Disease_Category_ID = (int)Disease_DataGridView.Rows[e.RowIndex].Cells["Disease_Category"].Value;
                        Disease_DataGridView.Rows[e.RowIndex].Cells["Disease"] = Load_Disease_ComboBox(Disease_Category_ID);
                    }
                }

                Disease_DataGridView_IsDirty = true;
                Disease_DataGridView.Rows[e.RowIndex].Cells["Disease_IsDirty"].Value = 1;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private DataGridViewComboBoxCell Load_Disease_ComboBox(int Disease_Category_ID)
        {
            DataTable dt = c.Select_Table("disease", " diseasecategory.id = '" + Disease_Category_ID + "'", true, false);

            DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();

            cell.DataSource = dt;
            cell.DisplayMember = "name";
            cell.ValueMember = "id";
            cell.FlatStyle = FlatStyle.Flat;
            return cell;
        }
        #region //IsDirty
        private void Name_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                Name_TextBox_OriginalText = FirstName_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Name_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Name_TextBox_OriginalText != FirstName_TextBox.Text)
                        General_Information_IsDirty = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void FatherName_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                FatherName_TextBox_OriginalText = FatherName_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void FatherName_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    if (FatherName_TextBox_OriginalText != FatherName_TextBox.Text)
                        General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LastName_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                LastName_TextBox_OriginalText = LastName_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void LastName_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    if (LastName_TextBox_OriginalText != LastName_TextBox.Text)
                        General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NationalityNumber_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                NationalityNumber_TextBox_OriginalText = NationalityNumber_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NationalityNumber_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(NationalityNumber_TextBox.Text))
                {
                    if (NationalityNumber_TextBox.Text.Length != 11)
                        MessageBox.Show("انتبه" + Environment.NewLine + Environment.NewLine + "عدد خانات الرقم الوطني لا تساوي 11", "Alert");

                }

                Check_Nationality_Number();

                if (NationalityNumber_TextBox_OriginalText != NationalityNumber_TextBox.Text)
                {
                    if (UserMode)
                        General_Information_IsDirty = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void EName_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                EName_TextBox_OriginalText = EName_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void EName_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    if (EName_TextBox_OriginalText != EName_TextBox.Text)
                        General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void EFatherName_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                EFatherName_TextBox_OriginalText = EFatherName_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void EFatherName_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    if (EFatherName_TextBox_OriginalText != EFatherName_TextBox.Text)
                        General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ELastName_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                ELastName_TextBox_OriginalText = ELastName_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void ELastName_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    if (ELastName_TextBox_OriginalText != ELastName_TextBox.Text)
                        General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Sex_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void Nationality_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void MaritalStatus_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Maritalstatus_IsDirty = true;
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
                dateTimePicker1.CustomFormat = "yyyy-MM-dd";
                if (UserMode)
                    General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    this.dateTimePicker1.CustomFormat = " ";
                    this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    General_Information_IsDirty = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Relation_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Receiver_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void State_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    State_IsDirty = true;
                
                if (
                    (int)State_ComboBox.SelectedValue == 1
                    || (int)State_ComboBox.SelectedValue == 3
                    || (int)State_ComboBox.SelectedValue == 4
                    || (int)State_ComboBox.SelectedValue == 5)
                {
                    isAid_Lable.Visible =
                    isAid_Panel.Visible = 
                    aidsource_29_No_RadioButton.Visible =
                    aidsource_29_Yes_RadioButton.Visible =
                    AidAmount_29_Textbox.Visible =
                    AidPeriod_29_comboBox.Visible =
                    AidNote_29_Textbox.Visible = 
                    AidNote_29_Lable.Visible =
                    isAidPeriod_Lable.Visible =
                    isAidAmount_Lable.Visible = false;

                    UserMode = false;
                    aidsource_29 = 0;
                    aidsource_29_Yes_RadioButton.Checked = aidsource_29_No_RadioButton.Checked = false;
                    AidAmount_29_Textbox.Text = AidPeriod_29_comboBox.Text = AidNote_29_Textbox.Text = "";
                    UserMode = true;
                }
                else 
                {
                    isAid_Lable.Visible =
                    isAid_Panel.Visible = 
                    aidsource_29_No_RadioButton.Visible  =
                    aidsource_29_Yes_RadioButton.Visible =
                    AidAmount_29_Textbox.Visible    = 
                    AidPeriod_29_comboBox.Visible   = 
                    AidNote_29_Textbox.Visible      =  
                    AidNote_29_Lable.Visible = 
                    isAidPeriod_Lable.Visible = 
                    isAidAmount_Lable.Visible = true; 
                }  
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void State_ComboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            if (string.Equals(e.Value?.ToString(), "N/A", StringComparison.Ordinal))
                e.Value = "رب الأسرة";
        }

        private void State_Note_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                //State_Note_OriginalText = State_Note_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void State_Note_TextBox_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (State_Note_OriginalText != State_Note_TextBox.Text)
            //        Receiver_IsDirty = true;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }


        private void Receiver_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode && Receiver_RadioButton.Checked)
                {
                    Check_Reciver();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NotReceiver_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode && NotReceiver_RadioButton.Checked)
                {
                    State_ComboBox.SelectedIndex = 0;
                    Relation_ComboBox.SelectedIndex = 0;
                    
                    Relation_ComboBox.Visible        = Relation_Label.Visible 
                        = State_ComboBox.Visible     = State_Label1.Visible 
                        = StateYear_Lable.Visible    = Stateyear_TextBox.Visible 
                        = StateAddress_Lable.Visible = StateAddress_ComboBox.Visible
                        = StateAddressNote_Lable.Visible = StateAddressNote_TextBox.Visible
                        = isAid_Lable.Visible        = isAid_Panel.Visible
                        = aidsource_29_Yes_RadioButton.Visible = aidsource_29_No_RadioButton.Visible
                        = aidsource_29_Yes_RadioButton.Checked = aidsource_29_No_RadioButton.Checked
                        = isAidAmount_Lable.Visible  = AidAmount_29_Textbox.Visible
                        = isAidPeriod_Lable.Visible  = AidPeriod_29_comboBox.Visible
                        = AidNote_29_Lable.Visible   = AidNote_29_Textbox.Visible 
                        = true;

                    Receiver_IsDirty = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Educated_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                       Educated_Information_IsDirty = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NotEducated_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (NotEducated_RadioButton.Checked)
                    {

                        Educated_Information_IsDirty = true;
                        educatedPanel.Enabled = false;
                        studentPanel.Enabled = false;
                        student1Panel.Enabled = false;
                        IsStudent_tableLayoutPanel.Enabled = false;
                        educationfield_id_1_comboBox.SelectedValue = educationtype_id_1_comboBox.SelectedValue = educationfield_id_2_comboBox.SelectedValue = educationtype_id_2_comboBox.SelectedValue
                        = education_id_1_comboBox.SelectedValue = education_id_2_comboBox.SelectedValue = expensestype_2_comboBox.SelectedValue = expensestype_8_comboBox.SelectedValue = 0;
                        educationnote2_TextBox.Text = educationnote_TextBox.Text = expenses_amount_2_TextBox.Text = expenses_amount_8_Textbox.Text = "";

                        aidsource_2_comboBox.SelectedValue = aidsource_23_comboBox.SelectedValue =
                        aidperiod_2_comboBox.SelectedValue = aidperiod_23_comboBox.SelectedValue = 0;
                        expenses_amount_8_Textbox.Text = expenses_amount_2_TextBox.Text =
                        aid_amount_2_TextBox.Text = aid_amount_23_TextBox.Text = "";
                    }
                    else
                    {
                        educatedPanel.Enabled = true;
                        studentPanel.Enabled = true;
                        IsStudent_tableLayoutPanel.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_29_Yes_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (aidsource_29_Yes_RadioButton.Checked)
                    {
                        aidsource_29 = 29;
                        AidNote_29_Lable.Visible = AidNote_29_Textbox.Visible = false;
                        AidNote_29_Textbox.Text = "";
                        isAidAmount_Lable.Visible = AidAmount_29_Textbox.Visible = isAidPeriod_Lable.Visible 
                            = AidPeriod_29_comboBox.Visible = true;

                        Receiver_IsDirty = true;
                    }
                    else
                    {
                        isAidAmount_Lable.Visible = AidAmount_29_Textbox.Visible = isAidPeriod_Lable.Visible 
                            = AidPeriod_29_comboBox.Visible = false;
                        AidAmount_29_Textbox.Text = "";
                        AidPeriod_29_comboBox.SelectedValue = 0;
                        AidNote_29_Lable.Visible = AidNote_29_Textbox.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void educationnote2_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                educationnote2_TextBox_OriginalText = educationnote2_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void educationnote2_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (educationnote2_TextBox_OriginalText != educationnote2_TextBox.Text)
                    Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Stateyear_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void AidAmount_29_Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void expenses_amount_9_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void expenses_amount_4_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void expenses_amount_5_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void expenses_amount_24_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aid_amount_21_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aid_amount_1_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aid_amount_13_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aid_amount_6_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aid_amount_8_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void operation_value_2_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void operation_value_1_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aid_amount_10_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void expenses_amount_8_Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void expenses_amount_2_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void aid_amount_2_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }
         
        private void SavePerson_Button_MouseEnter(object sender, EventArgs e)
        {
            SavePerson_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;
        }

        private void StateAddress_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void StateAddress_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Receiver_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void StateAddressNote_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                StateAddressNote_TextBox_OriginalText = StateAddressNote_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void StateAddressNote_TextBox_Leave(object sender, EventArgs e)
        {
            if (UserMode)
                if (StateAddressNote_TextBox_OriginalText != StateAddressNote_TextBox.Text)
                    Receiver_IsDirty = true;
        }

        private void SavePerson_Button_MouseLeave(object sender, EventArgs e)
        {
            SavePerson_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;
        }
         
        private void MEFamily_DataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Added By Mai
            try
            {
                UserMode = false;
                Visit_ID = int.Parse(MEFamily_DataGridView.Rows[e.RowIndex].Cells["ME_Family_Visit_ID"].Value.ToString());
                Fill_Person(Visit_ID);
                UserMode = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void MEFamily_DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void aid_amount_23_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
                && (e.KeyChar != '/') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void UpdatePerson_Button_MouseEnter(object sender, EventArgs e)
        {
            UpdatePerson_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;
        }

        private void UpdatePerson_Button_MouseLeave(object sender, EventArgs e)
        {
            UpdatePerson_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;
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
                if (UserMode)
                    if (Note_TextBox_OriginalText != Note_TextBox.Text)
                        General_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void UpdatePerson_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = UpdatePerson_Button;
                DataApproved = Check_Data(0);
                if (DataApproved)
                {
                    if (UpdateMode)
                    {
                        if (!General_Information_IsDirty 
                            && !Receiver_IsDirty 
                            && !State_IsDirty 
                            && !Educated_Information_IsDirty  
                            && !Maritalstatus_IsDirty)
                        {
                            MessageBox.Show("لا يوجد أي تغييرات لحفظها ", "Error");
                            return;
                        }
                        else
                        {
                            Get_Data();
                            p.Update_Person(Person_ID, FirstName_TextBox.Text, Family_ID
                                , General_Query, Education_Query, Receiver_Query, Form_Name);
                                
                            MessageBox.Show("تم تعديل المعلومات بنجاح", "Confirmation");
                        }
                    }
                    Fill_Person(Visit_ID);
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

        private void SavePerson_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = SavePerson_Button;

                DataApproved = Check_Data(0);

                if (DataApproved)
                {
                    Get_Data();

                    if (!UpdateMode)
                    {
                        Person_ID = p.Insert_Person(Family_ID, Visit_ID
                            , Program.CleanString(FirstName), Program.CleanString(FatherName) , Program.CleanString(LastName)
                            , Program.CleanString(EName)    , Program.CleanString(EFatherName), Program.CleanString(ELastName)
                            , IsReciever, Relation_ID
                            , DOB, Sex_ID, Nationality_ID
                            , MaritalStatus_ID, NationalityNumber
                            , State_ID, Stateyear, StateAddress_ID, StateAddressNote, aidsource_29, AidAmount_29, aidperiod_29, aidnote_29
                            , hasDisease, ExpensesAmount_9, Expensestype_9, aidsource_21, AidAmount_21, aidperiod_21
                            , aidsource_1, AidAmount_1, aidperiod_1, aidsource_13, AidAmount_13, aidperiod_13
                            , OperationName_2, OperationValue_2, OperationName_1, OperationValue_1
                            , ExpensesAmount_5, Expensestype_5, aidsource_8, AidAmount_8, aidperiod_8
                            , ExpensesAmount_4, Expensestype_4, aidsource_6, AidAmount_6, aidperiod_6 
                            , ExpensesAmount_24, Expensestype_24
                            , haswork, isMP, isAid10, aidsource_10, AidAmount_10, aidperiod_10
                            , IsEducated, education_id_1, EducationNote, educationfield_id_1, educationtype_id_1, education_id_2, EducationNote2, educationfield_id_2, educationtype_id_2
                            , IsStudent, ExpensesAmount_8, Expensestype_8, ExpensesAmount_2, Expensestype_2, aidsource_2, AidAmount_2, aidperiod_2, aidsource_23, AidAmount_23, aidperiod_23, Note, PersonNote
                            , needs_0, needs_1, needs_2, needs_3, needs_4, needs_5, needs_6, needs_7, needs_8, needs_9, needs_10, needs_12, needs_courses, needs_note
                            , WorkExp_Query, MP_Query, Disease_Query, Form_Name);
                        
                        //Person_ID = p.Insert_Person(Family_ID, FirstName, FatherName, LastName, EName, EFatherName, ELastName, NationalityNumber, Note, DOB,
                        //    IsEducated, IsStudent, Sex_ID, Nationality_ID, MaritalStatus_ID, Relation_ID, State_ID, IsReciever,
                        //   WorkExp_Query, Education_Query, Disease_Query, Form_Name);

                        UpdateMode = true;

                        MessageBox.Show("تم إدخال شخص جديد بنجاح", "Confirmation");
                    }

                    Set_Controls();
                    SecondTableLayoutPanel.Visible = true;
                    SavePerson_Button.Visible = false;
                    UpdatePerson_Button.Visible = true;
                    Fill_Person(Visit_ID);
                }
            }
            catch (Exception ex)
            {
                WorkExp_Query = Education_Query = Disease_Query = "";
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void haswork_Yes_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (haswork_Yes_RadioButton.Checked)
                    {

                        WorkExp_DataGridView_IsDirty = true;
                        WorkExp_DataGridView.Enabled = true;

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void haswork_No_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (haswork_No_RadioButton.Checked)
                    {

                        WorkExp_DataGridView_IsDirty = true;
                        WorkExp_DataGridView.Enabled = false;
                        while (WorkExp_DataGridView.Rows.Count > 1)
                        {
                            WorkExp_DataGridView.Rows.RemoveAt(0);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_courses_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (needs_courses_TextBox_OriginalText != needs_courses_TextBox.Text)
                        Needs_IsDirty = true;
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_note_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (needs_note_TextBox_OriginalText != needs_note_TextBox.Text)
                        Needs_IsDirty = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_1_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Needs_IsDirty = true;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_8_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Needs_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_3_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Needs_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_4_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Needs_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_6_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Needs_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_5_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Needs_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_7_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Needs_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_9_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Needs_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_10_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Needs_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_12_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Needs_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_2_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (needs_2_checkBox.Checked)
                {
                    needs_courses_TextBox.Visible = true;
                }
                else needs_courses_TextBox.Visible = false;
                if (UserMode)
                    Needs_IsDirty = true;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_0_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (needs_0_checkBox.Checked)
                {
                    needs_note_TextBox.Visible = true;
                }
                else
                {
                    needs_note_TextBox.Visible = false;
                }
                if (UserMode)
                    Needs_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Sex_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Sex_ComboBox.SelectedIndex == 0)
            {
                aid10_military_tableLayoutPanel.Enabled = true;
            }
            else
            {
                aid10_military_tableLayoutPanel.Enabled = false;
            }
        }

        private void needs_courses_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                needs_courses_TextBox_OriginalText = needs_courses_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void needs_note_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                needs_note_TextBox_OriginalText = needs_note_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_29_No_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (aidsource_29_No_RadioButton.Checked)
                    {
                        AidNote_29_Lable.Visible = AidNote_29_Textbox.Visible = true;
                        isAidAmount_Lable.Visible = AidAmount_29_Textbox.Visible = isAidPeriod_Lable.Visible = AidPeriod_29_comboBox.Visible = false;

                        Receiver_IsDirty = true;
                    }
                    else
                    {
                        isAidAmount_Lable.Visible = AidAmount_29_Textbox.Visible = isAidPeriod_Lable.Visible = AidPeriod_29_comboBox.Visible = true;
                        AidNote_29_Lable.Visible = AidNote_29_Textbox.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Stateyear_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                Stateyear_TextBox_OriginalText = Stateyear_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Stateyear_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    if (Stateyear_TextBox_OriginalText != Stateyear_TextBox.Text)
                        Receiver_IsDirty = true;
                Check_personstate_year();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        public void Check_personstate_year()
        {
            string input = Stateyear_TextBox.Text;
            int minValue = 1900; // Set the minimum value

            Regex regex = new Regex(@"^(?!0000)\d{4}$");

            // Check if the input is a valid 4-digit number
            if (regex.IsMatch(input))
            {
                // Parse the input to an integer
                if (int.TryParse(input, out int number))
                {
                    // Check if the number is above the minimum value
                    if (number < minValue)
                    {
                        MessageBox.Show("الرجاء إدخال رقم أكبر من {minValue} !!");
                        Stateyear_TextBox.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show(" الرجاء إدخال رقم مؤلف من اربع خانات ما عدا 0000");
                Stateyear_TextBox.Text = "";
            }
        }

        private void StateAddress_TextBox_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    StateAddress_TextBox_OriginalText = StateAddress_TextBox.Text;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void StateAddress_TextBox_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (UserMode)
            //        if (StateAddress_TextBox_OriginalText != StateAddress_TextBox.Text)
            //            Receiver_IsDirty = true;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            //}
        }

        private void AidAmount_29_Textbox_Enter(object sender, EventArgs e)
        {
            try
            {
                AidAmount_29_Textbox_OriginalText = AidAmount_29_Textbox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void AidAmount_29_Textbox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    if (AidAmount_29_Textbox_OriginalText != AidAmount_29_Textbox.Text)
                        Receiver_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void AidPeriod_29_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    Receiver_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void AidNote_29_Textbox_Enter(object sender, EventArgs e)
        {
            try
            {
                AidNote_29_Textbox_OriginalText = AidNote_29_Textbox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void AidNote_29_Textbox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    if (AidNote_29_Textbox_OriginalText != AidNote_29_Textbox.Text)
                        Receiver_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void hasdisease_Yes_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (UserMode)
            {
                if (hasdisease_Yes_RadioButton.Checked)
                {

                    Disease_DataGridView_IsDirty = true;
                    Disease_DataGridView.Enabled = true;

                }
            }
        }

        private void hasdisease_No_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (UserMode)
            {
                if (hasdisease_No_RadioButton.Checked)
                {

                    Disease_DataGridView_IsDirty = true;
                    //for (int i = Disease_DataGridView.Rows.Count - 1; i >= 0; i--)
                    //{
                    //    Disease_DataGridView.Rows.RemoveAt(Disease_DataGridView.Rows[i].Index);
                    //}
                    //Disease_DataGridView.Rows.Clear();
                    //Disease_DataGridView.Columns.Clear();
                    while (Disease_DataGridView.Rows.Count > 1)
                    {
                        Disease_DataGridView.Rows.RemoveAt(0);
                    }
                    Disease_DataGridView.Enabled = false;

                }
            }
        }

        private void expenses_amount_9_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                expenses_amount_9_TextBox_OriginalText = expenses_amount_9_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void expenses_amount_9_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expenses_amount_9_TextBox_OriginalText != expenses_amount_9_TextBox.Text)
                    Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void expenses_amount_4_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                expenses_amount_4_TextBox_OriginalText = expenses_amount_4_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void expenses_amount_4_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expenses_amount_4_TextBox_OriginalText != expenses_amount_4_TextBox.Text)
                    Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void expenses_amount_5_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                expenses_amount_5_TextBox_OriginalText = expenses_amount_5_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void expenses_amount_5_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expenses_amount_5_TextBox_OriginalText != expenses_amount_5_TextBox.Text)
                    Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void expenses_amount_24_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                expenses_amount_24_TextBox_OriginalText = expenses_amount_24_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void expenses_amount_24_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expenses_amount_24_TextBox_OriginalText != expenses_amount_24_TextBox.Text)
                    Expenses_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void expensestype_9_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void expensestype_4_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void expensestype_5_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void expensestype_24_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void aidsource_21_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_1_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_13_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_6_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_8_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_21_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_1_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_13_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_6_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_8_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_21_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aid_amount_21_TextBox_OriginalText = aid_amount_21_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_21_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aid_amount_21_TextBox_OriginalText != aid_amount_21_TextBox.Text)
                    Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_1_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aid_amount_1_TextBox_OriginalText = aid_amount_1_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_1_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aid_amount_1_TextBox_OriginalText != aid_amount_1_TextBox.Text)
                    Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_13_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aid_amount_13_TextBox_OriginalText != aid_amount_13_TextBox.Text)
                    Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_6_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aid_amount_6_TextBox_OriginalText != aid_amount_6_TextBox.Text)
                    Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_8_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aid_amount_8_TextBox_OriginalText != aid_amount_8_TextBox.Text)
                    Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_13_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aid_amount_13_TextBox_OriginalText = aid_amount_13_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_6_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aid_amount_6_TextBox_OriginalText = aid_amount_6_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_8_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aid_amount_8_TextBox_OriginalText = aid_amount_8_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void operation_name_2_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                operation_name_2_TextBox_OriginalText = operation_name_2_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void operation_name_1_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                operation_name_1_TextBox_OriginalText = operation_name_1_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void operation_value_2_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                operation_value_2_TextBox_OriginalText = operation_value_2_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void operation_value_1_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                operation_value_1_TextBox_OriginalText = operation_value_1_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void operation_name_2_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (operation_name_2_TextBox_OriginalText != operation_name_2_TextBox.Text)
                    Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void operation_name_1_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (operation_name_1_TextBox_OriginalText != operation_name_1_TextBox.Text)
                    Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void operation_value_2_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (operation_value_2_TextBox_OriginalText != operation_value_2_TextBox.Text)
                    Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void operation_value_1_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (operation_value_1_TextBox_OriginalText != operation_value_1_TextBox.Text)
                    Aids_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Disease_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    //if (Disease_DataGridView.Rows[e.RowIndex - 1].Cells["Person_Disease_ID"].Value == null || Disease_DataGridView.Rows[e.RowIndex - 1].Cells["Person_Disease_ID"].Value.ToString() == "")
                    //{
                    //    Disease_DataGridView.Rows[e.RowIndex - 1].Cells["Person_Disease_ID"].Value = 1;
                    //}
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void WorkExp_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                //if (UserMode)
                //{
                //    if (WorkExp_DataGridView.Rows[e.RowIndex - 1].Cells["Person_Work_ID"].Value == null || WorkExp_DataGridView.Rows[e.RowIndex - 1].Cells["Person_Work_ID"].Value.ToString() == "")
                //    {
                //        WorkExp_DataGridView.Rows[e.RowIndex - 1].Cells["Person_Work_ID"].Value = 1;
                //    }
                //}

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void MP_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                //if (UserMode)
                //{
                //    if (MP_DataGridView.Rows[e.RowIndex - 1].Cells["Person_MP_ID"].Value == null || MP_DataGridView.Rows[e.RowIndex - 1].Cells["Person_MP_ID"].Value.ToString() == "")
                //    {
                //        MP_DataGridView.Rows[e.RowIndex - 1].Cells["Person_MP_ID"].Value = 1;
                //    }
                //}

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void MP_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

        private void MP_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void MP_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MP_DataGridView_IsDirty = true;
                MP_DataGridView.Rows[e.RowIndex].Cells["MP_IsDirty"].Value = 1;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void MP_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == MP_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == MP_DataGridView.Columns["MP_DeleteRow"].Index)
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

        private void MP_DataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == MP_DataGridView.Columns["aid_amount_5_mp"].Index)
                {
                    MP_DataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Format = "N0";
                    MP_DataGridView.Columns[e.ColumnIndex].ValueType = typeof(Decimal);
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void MP_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == MP_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                //Check if click is on specific column 
                if (e.ColumnIndex == MP_DataGridView.Columns["MP_DeleteRow"].Index)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (MP_DataGridView.Rows[e.RowIndex].Cells["Person_MP_ID"].Value != null)
                        {
                            MP_DataGridView_IsDirty = true;
                            MP_DataGridView.Rows[e.RowIndex].Cells["MP_IsDirty"].Value = "1";
                            MP_DataGridView.Rows[e.RowIndex].Visible = false;
                        }
                        else
                        {
                            MP_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_Yes_10_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (aid_Yes_10_RadioButton.Checked)
                    {
                        Military_Information_IsDirty = true;
                        militaryPanel.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_No_10_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (aid_No_10_RadioButton.Checked)
                {
                    militaryPanel.Enabled = false;
                    aidperiod_10_comboBox.SelectedValue = 0;
                    aidsource_10_comboBox.SelectedValue = 0;
                    aid_amount_10_TextBox.Text = "";
                }
                if (UserMode)
                    Military_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_10_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Military_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_10_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aid_amount_10_TextBox_OriginalText = aid_amount_10_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_10_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aid_amount_10_TextBox_OriginalText != aid_amount_10_TextBox.Text)
                    Military_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_10_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Military_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void education_id_1_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void education_id_2_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void educationnote_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                educationnote_TextBox_OriginalText = educationnote_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void educationnote_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (educationnote_TextBox_OriginalText != educationnote_TextBox.Text)
                    Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void educationfield_id_1_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void educationfield_id_2_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void educationtype_id_1_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void educationtype_id_2_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void mp_Yes_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (mp_Yes_RadioButton.Checked)
                    {
                        MP_DataGridView_IsDirty = true;
                        MP_DataGridView.Enabled = true;

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void mp_No_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (mp_No_RadioButton.Checked)
                    {
                        MP_DataGridView_IsDirty = true;
                        MP_DataGridView.Enabled = false;
                        while (MP_DataGridView.Rows.Count > 1)
                        {
                            MP_DataGridView.Rows.RemoveAt(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void IsStudent_RadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (IsStudent_RadioButton.Checked)
                {
                    studentPanel.Enabled = true;
                    student1Panel.Enabled = true;
                    //Education_DataGridView.Enabled = true;
                    //IsStudent_RadioButton.Visible = true;
                }
                if (UserMode)
                    Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NotStudent_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (NotStudent_RadioButton.Checked)
                {
                    studentPanel.Enabled = false;
                    student1Panel.Enabled = false;
                    expensestype_2_comboBox.SelectedValue = expensestype_8_comboBox.SelectedValue =
                    aidsource_2_comboBox.SelectedValue = aidsource_23_comboBox.SelectedValue =
                    aidperiod_2_comboBox.SelectedValue = aidperiod_23_comboBox.SelectedValue = 0;
                    expenses_amount_8_Textbox.Text = expenses_amount_2_TextBox.Text =
                    aid_amount_2_TextBox.Text = aid_amount_23_TextBox.Text = "";
                    //Education_DataGridView.Enabled = true;
                    //IsStudent_RadioButton.Visible = true;
                }
                if (UserMode)
                    Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void expensestype_8_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void expensestype_2_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void expenses_amount_8_Textbox_Enter(object sender, EventArgs e)
        {
            try
            {
                expenses_amount_8_TextBox_OriginalText = expenses_amount_8_Textbox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void expenses_amount_2_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                expenses_amount_2_TextBox_OriginalText = expenses_amount_2_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void expenses_amount_8_Textbox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expenses_amount_8_TextBox_OriginalText != expenses_amount_8_Textbox.Text)
                    Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void expenses_amount_2_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expenses_amount_2_TextBox_OriginalText != expenses_amount_2_TextBox.Text)
                    Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_2_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidsource_23_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_2_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aidperiod_23_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_2_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aid_amount_2_TextBox_OriginalText = aid_amount_2_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_23_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                aid_amount_23_TextBox_OriginalText = aid_amount_23_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_2_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aid_amount_2_TextBox_OriginalText != aid_amount_2_TextBox.Text)
                    Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void aid_amount_23_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (aid_amount_23_TextBox_OriginalText != aid_amount_23_TextBox.Text)
                    Educated_Information_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void IsStudent_RadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                UserMode = false;
                foreach (RadioButton r in IsEducated_LayoutPanel.Controls.OfType<RadioButton>())
                    r.Checked = false;

                IsStudent_RadioButton.Checked = false;

                DialogResult dialogResult = MessageBox.Show("هل تريد حذف جميع معلومات التعليم؟", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //for (int i = 0; i < Education_DataGridView.Rows.Count - 1; i++)
                    //{
                    //    if (Education_DataGridView.Rows[i].Cells["Person_Education_ID"].Value != null)
                    //    {
                    //        Education_DataGridView_IsDirty = true;
                    //        Education_DataGridView.Rows[i].Cells["Education_IsDirty"].Value = "1";
                    //        Education_DataGridView.Rows[i].Visible = false;
                    //    }
                    //    else
                    //    {
                    //        Education_DataGridView.Rows.RemoveAt(i);
                    //    }
                    //}
                    UserMode = true;
                    Educated_Information_IsDirty = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void WorkExp_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                WorkExp_DataGridView_IsDirty = true;
                WorkExp_DataGridView.Rows[e.RowIndex].Cells["Work_IsDirty"].Value = 1;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void WorkExp_DataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == WorkExp_DataGridView.Columns["workexpamount"].Index)
                {
                    WorkExp_DataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Format = "N0";
                    WorkExp_DataGridView.Columns[e.ColumnIndex].ValueType = typeof(Decimal);
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Education_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Education_DataGridView_IsDirty = true;
                //Education_DataGridView.Rows[e.RowIndex].Cells["Education_IsDirty"].Value = 1;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void PersonNote_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                    if (PersonNote_TextBox_OriginalText != PersonNote_TextBox.Text)
                        Needs_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void PersonNote_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                PersonNote_TextBox_OriginalText = PersonNote_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        #endregion

        private bool Check_Nationality_Number()
        {
            bool Ok = false;
            NationalityNumberChecked = false;

            if (!string.IsNullOrWhiteSpace(NationalityNumber_TextBox.Text))
            {

                DataTable dt = p.Check_Nationality_Number(NationalityNumber_TextBox.Text, Person_ID);
                if (dt != null && Family_ID != dt.Rows[0].Field<int>("Family_ID"))
                {
                    NationalityNumberChecked = true;
                    DialogResult dialogResult = MessageBox.Show("الرقم الوطني مستخدم من قبل باسم " + dt.Rows[0].Field<string>("Name") + " هل تريد الاستمرار باستخدام نفس الرقم؟؟", "Alert", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //Save_Button.Enabled = true;
                        Update_Button.Enabled = true;

                        Ok = true;
                        int person_id = dt.Rows[0].Field<int>("Person_ID");
                        int family_id = dt.Rows[0].Field<int>("Family_ID");
                        
                        string personstate_type = dt.Rows[0].Field<string>("personstate_type");
                        DataSet ds = p.Get_Person(person_id, family_id, null);
                        if(family_id != Family_ID)
                        {
                            link_family = true;
                        }
                        if(!String.Equals(personstate_type, "Active"))
                        {
                            SecondTableLayoutPanel.Visible = false;
                            MELayoutPanel.Visible = false;
                        }
                        if (ds.Tables[1].Rows[0]["code"] != DBNull.Value)
                            FamilyCode_TextBox.Text = ds.Tables[1].Rows[0].Field<string>("code");
                        if (ds.Tables[0].Rows[0]["first_Name"] != DBNull.Value)
                            FirstName_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("first_Name");
                        if (ds.Tables[0].Rows[0]["father_name"] != DBNull.Value)
                            FatherName_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("father_name");
                        if (ds.Tables[0].Rows[0]["last_name"] != DBNull.Value)
                            LastName_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("last_name");
                        if (ds.Tables[0].Rows[0]["first_name_e"] != DBNull.Value)
                            EName_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("first_name_e");
                        if (ds.Tables[0].Rows[0]["father_name_e"] != DBNull.Value)
                            EFatherName_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("father_name_e");
                        if (ds.Tables[0].Rows[0]["last_name_e"] != DBNull.Value)
                            ELastName_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("last_name_e");
                        if (ds.Tables[0].Rows[0]["sex_id"] != DBNull.Value)
                            Sex_ComboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("sex_id");
                        if (ds.Tables[0].Rows[0].Field<int>("sex_id") == 2)
                        {
                            militaryPanel.Enabled = false;
                            aid10_military_tableLayoutPanel.Enabled = false;
                        }
                        if (ds.Tables[0].Rows[0]["national_Number"] != DBNull.Value)
                            NationalityNumber_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("national_Number");
                        if (ds.Tables[0].Rows[0]["nationality_id"] != DBNull.Value)
                            Nationality_ComboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("nationality_id");
                        if (ds.Tables[0].Rows[0]["DOB"] == DBNull.Value)
                        {
                            this.dateTimePicker1.CustomFormat = " ";
                            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
                        }
                        else
                        {
                            dateTimePicker1.Value = DateTime.Parse(ds.Tables[0].Rows[0].Field<DateTime>("DOB").ToShortDateString(), CultureInfo.CurrentCulture);
                        }
                        if (ds.Tables[0].Rows[0]["isEducated"] != DBNull.Value)
                        {
                            if (ds.Tables[0].Rows[0].Field<int>("isEducated") == 1)
                            {
                                Educated_RadioButton.Checked = true;
                                educatedPanel.Enabled = true;
                            }
                            else if (ds.Tables[0].Rows[0].Field<int>("isEducated") == 0)
                            {
                                NotEducated_RadioButton.Checked = true;
                                educatedPanel.Enabled = false;
                            }
                        }
                        if (ds.Tables[0].Rows[0]["education_id"] != DBNull.Value)
                            education_id_1_comboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("education_id");
                        if (ds.Tables[0].Rows[0]["education_id_2"] != DBNull.Value)
                            education_id_2_comboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("education_id_2");
                        if (ds.Tables[0].Rows[0]["educationnote"] != DBNull.Value)
                            educationnote_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("educationnote");
                        if (ds.Tables[0].Rows[0]["educationnote2"] != DBNull.Value)
                            educationnote2_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("educationnote2");
                        if (ds.Tables[0].Rows[0]["educationfield_id"] != DBNull.Value)
                            educationfield_id_1_comboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("educationfield_id");
                        if (ds.Tables[0].Rows[0]["educationfield_id_2"] != DBNull.Value)
                            educationfield_id_2_comboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("educationfield_id_2");
                        if (ds.Tables[0].Rows[0]["educationtype_id"] != DBNull.Value)
                            educationtype_id_1_comboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("educationtype_id");
                        if (ds.Tables[0].Rows[0]["educationtype_id_2"] != DBNull.Value)
                            educationtype_id_2_comboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("educationtype_id_2");
                        Note_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("Note");
                        SavePerson_Button.Visible = false;
                        UpdatePerson_Button.Visible = true;
                        Delete_Button.Visible = true;
                        UpdateMode = true;
                        Person_ID = person_id;
                        
                    }
                    else
                    {
                        MessageBox.Show("لن تسطيع حفظ معلومات هذا الشخص قبل تغيير الرقم الوطني", "Alert");
                        //Save_Button.Enabled = false;
                        Update_Button.Enabled = false;
                        Ok = false;
                    }
                }
                else if (dt != null && Family_ID == dt.Rows[0].Field<int>("Family_ID"))
                {
                    NationalityNumberChecked = true;
                    MessageBox.Show("لا يمكن استخدام نفس الرقم الوطني لشخيصن من نفس العائلة" + Environment.NewLine + "الرقم الوطني مستخدم من قبل باسم " + dt.Rows[0].Field<string>("Name") + Environment.NewLine + "لن تسطيع حفظ معلومات هذا الشخص قبل تغيير الرقم الوطني", "Alert");
                    //Save_Button.Enabled = false;
                    Update_Button.Enabled = false;
                    Ok = false;
                }
                else
                {
                    NationalityNumberChecked = true;
                    //Save_Button.Enabled = true;
                    Update_Button.Enabled = true;
                    Ok = true;
                }
            }
            else
            {
                //Save_Button.Enabled = true;
                Update_Button.Enabled = true;
                Ok = true;
                NationalityNumberChecked = true;
            }

            return Ok;
        }
        private bool Check_Reciver()
        {
            bool Ok = false;
            ReciverChecked = false;

            //نجرب نحفظ الحالة السابقة 
            //مشان اذا في مشكلة وفي مستلم تاني ما يمحيلو كلشي لهالمستفيد
             
            DataTable dt = p.Check_Receiver(Family_ID, Person_ID);
            if (dt != null)
            {
                ReciverChecked = true;
                MessageBox.Show("تم تعيين " + dt.Rows[0].Field<string>("Name") + " كمستلم لهذه العائلة، لا يمكن تحديد مستلم آخر", "Error");
                
                UserMode = false;
                Receiver_RadioButton.Checked = false; 
                NotReceiver_RadioButton.Checked = true;

                UserMode = true;
                Ok = false;
            }
            else
            {
                ReciverChecked = true;

                State_ComboBox.SelectedIndex = State_ComboBox.FindString("مقيم");

                Relation_ComboBox.Visible       = Relation_Label.Visible
                    = State_ComboBox.Visible    = State_Label1.Visible
                    = isAid_Lable.Visible       = isAid_Panel.Visible
                    = aidsource_29_Yes_RadioButton.Visible = aidsource_29_No_RadioButton.Visible
                    = aidsource_29_Yes_RadioButton.Checked = aidsource_29_No_RadioButton.Checked 
                    = isAidAmount_Lable.Visible = AidAmount_29_Textbox.Visible 
                    = isAidPeriod_Lable.Visible = AidPeriod_29_comboBox.Visible 
                    = AidNote_29_Lable.Visible = AidNote_29_Textbox.Visible
                    = false;

                Relation_ComboBox.SelectedValue = 0; // N/A
                State_ComboBox.SelectedValue = 1; //مقيم
                StateAddress_ComboBox.SelectedValue = 0;
                Stateyear_TextBox.Text  = StateAddressNote_TextBox.Text  =  "";

                aidsource_29 = 0;
                AidPeriod_29_comboBox.SelectedValue = 0; // N/A
                AidAmount_29_Textbox.Text = AidNote_29_Textbox.Text = "";

                Receiver_IsDirty = true;
                Ok = true;
            }

            return Ok;
        }
        private void Fill_Person(int? visit_id)
        {
            UserMode = false;
            if (MEFamily_DataGridView.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in MEFamily_DataGridView.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.Equals(visit_id))
                    {
                        int index = row.Index;
                        MEFamily_DataGridView.CurrentCell = MEFamily_DataGridView.Rows[index].Cells[1];
                        break;
                    }
                }
            }
            Set_Controls();
            Clear_Boxes();
            //VisitNameLabel.Text = Visit_Name;
            DataSet ds = p.Get_Person(Person_ID, Family_ID, visit_id);
            VisitNameLabel.UseMnemonic = false;
            
            if (ds.Tables[5].Rows.Count != 0)
            {
                if (ds.Tables[5].Rows[0]["visit_name"] != DBNull.Value)
                    VisitNameLabel.Text = ds.Tables[5].Rows[0].Field<string>("visit_name");
            }
            if (ds.Tables[1].Rows[0]["code"] != DBNull.Value)
                FamilyCode_TextBox.Text = ds.Tables[1].Rows[0].Field<string>("code");
            if (ds.Tables[0].Rows[0]["first_Name"] != DBNull.Value)
                FirstName_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("first_Name");
            if (ds.Tables[0].Rows[0]["father_name"] != DBNull.Value)
                FatherName_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("father_name");
            if (ds.Tables[0].Rows[0]["last_name"] != DBNull.Value)
                LastName_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("last_name");
            if (ds.Tables[0].Rows[0]["first_name_e"] != DBNull.Value)
                EName_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("first_name_e");
            if (ds.Tables[0].Rows[0]["father_name_e"] != DBNull.Value)
                EFatherName_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("father_name_e");
            if (ds.Tables[0].Rows[0]["last_name_e"] != DBNull.Value)
                ELastName_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("last_name_e");
            if (ds.Tables[0].Rows[0]["sex_id"] != DBNull.Value)
                Sex_ComboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("sex_id");
            if (ds.Tables[0].Rows[0].Field<int>("sex_id") == 2)
            {
                militaryPanel.Enabled = false;
                aid10_military_tableLayoutPanel.Enabled = false;
            }
            if (ds.Tables[0].Rows[0]["national_Number"] != DBNull.Value)
                NationalityNumber_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("national_Number");
            if (ds.Tables[0].Rows[0]["nationality_id"] != DBNull.Value)
                Nationality_ComboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("nationality_id");
            
            if (ds.Tables[0].Rows[0]["DOB"] == DBNull.Value)
            {
                this.dateTimePicker1.CustomFormat = " ";
                this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dateTimePicker1.Value = DateTime.Parse(ds.Tables[0].Rows[0].Field<DateTime>("DOB").ToShortDateString(), CultureInfo.CurrentCulture);
            }
            
            if (ds.Tables[0].Rows[0]["isEducated"] != DBNull.Value)
            {
                if (ds.Tables[0].Rows[0].Field<int>("isEducated") == 1)
                {
                    Educated_RadioButton.Checked = true;
                    educatedPanel.Enabled = true;
                }
                else if (ds.Tables[0].Rows[0].Field<int>("isEducated") == 0)
                {
                    NotEducated_RadioButton.Checked = true;
                    educatedPanel.Enabled = false;
                }
            }
            if (ds.Tables[0].Rows[0]["education_id"] != DBNull.Value)
                education_id_1_comboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("education_id");
            if (ds.Tables[0].Rows[0]["education_id_2"] != DBNull.Value)
                education_id_2_comboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("education_id_2");
            if (ds.Tables[0].Rows[0]["educationnote"] != DBNull.Value)
                educationnote_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("educationnote");
            if (ds.Tables[0].Rows[0]["educationnote2"] != DBNull.Value)
                educationnote2_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("educationnote2");
            if (ds.Tables[0].Rows[0]["educationfield_id"] != DBNull.Value)
                educationfield_id_1_comboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("educationfield_id");
            if (ds.Tables[0].Rows[0]["educationfield_id_2"] != DBNull.Value)
                educationfield_id_2_comboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("educationfield_id_2");
            if (ds.Tables[0].Rows[0]["educationtype_id"] != DBNull.Value)
                educationtype_id_1_comboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("educationtype_id");
            if (ds.Tables[0].Rows[0]["educationtype_id_2"] != DBNull.Value)
                educationtype_id_2_comboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("educationtype_id_2");
            Note_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("Note");

            if (ds.Tables[0].Rows[0]["personstate"] != DBNull.Value)
                State_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("personstate").ToString();
            if (ds.Tables[8].Rows[0]["maritalstatus_id"] != DBNull.Value)
                MaritalStatus_ComboBox.SelectedValue = ds.Tables[8].Rows[0].Field<int>("maritalstatus_id");
            if (ds.Tables[6].Rows[0]["relation_id"] != DBNull.Value)
                Relation_ComboBox.SelectedValue = ds.Tables[6].Rows[0].Field<int>("relation_id");
            if (ds.Tables[0].Rows[0]["personstate_year"] != DBNull.Value)
                Stateyear_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("personstate_year").ToString();
            if (ds.Tables[0].Rows[0]["State_Note"] != DBNull.Value)
                StateAddressNote_TextBox.Text = ds.Tables[0].Rows[0].Field<string>("State_Note").ToString();
            if (ds.Tables[0].Rows[0]["personstate_id"] != DBNull.Value)
                State_ComboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("personstate_id");
            if (ds.Tables[0].Rows[0]["stateaddress_id"] != DBNull.Value)
                StateAddress_ComboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("stateaddress_id");
            if ((int)State_ComboBox.SelectedValue != 0 && (int)State_ComboBox.SelectedValue != 1 && (int)State_ComboBox.SelectedValue != 6 && (int)State_ComboBox.SelectedValue != 8 && (int)State_ComboBox.SelectedValue != 12)
            {
                //MELayoutPanel.Visible = false;
                //SecondTableLayoutPanel.Visible = false;
                Update_Button.Visible = false;
                isAid_Lable.Visible = true;
                isAid_Panel.Visible = true;
                aidsource_29_No_RadioButton.Visible = true;
                aidsource_29_Yes_RadioButton.Visible = true;
                AidNote_29_Lable.Visible = true;
                isAidPeriod_Lable.Visible = true;
                isAidAmount_Lable.Visible = true;
                AidNote_29_Textbox.Visible = true;
                AidPeriod_29_comboBox.Visible = true;
                AidAmount_29_Textbox.Visible = true;
            }
            else
            {
                //MELayoutPanel.Visible = true;
                //SecondTableLayoutPanel.Visible = true;
                Update_Button.Visible = true;
                isAid_Lable.Visible = false;
                isAid_Panel.Visible = false;
                aidsource_29_No_RadioButton.Visible = false;
                aidsource_29_Yes_RadioButton.Visible = false;
                AidNote_29_Lable.Visible = false;
                isAidPeriod_Lable.Visible = false;
                isAidAmount_Lable.Visible = false;
                AidNote_29_Textbox.Visible = false;
                AidPeriod_29_comboBox.Visible = false;
                AidAmount_29_Textbox.Visible = false;
            }

            if ((int)State_ComboBox.SelectedValue != 1 && (int)State_ComboBox.SelectedValue != 6 && (int)State_ComboBox.SelectedValue != 8 && (int)State_ComboBox.SelectedValue != 12)
            {
                if (ds.Tables[0].Rows[0]["aidsource_29"] != DBNull.Value)
                {
                    if (ds.Tables[0].Rows[0].Field<int>("aidsource_29") == 29)
                    {
                        AidAmount_29_Textbox.Text = ds.Tables[0].Rows[0].Field<int>("aid_amount_29").ToString();
                        AidPeriod_29_comboBox.SelectedValue = ds.Tables[0].Rows[0].Field<int>("aidperiod_29").ToString();
                        aidsource_29_Yes_RadioButton.Checked = true;
                        AidPeriod_29_comboBox.Visible = isAidPeriod_Lable.Visible = AidAmount_29_Textbox.Visible = isAidAmount_Lable.Visible = true;
                        AidNote_29_Textbox.Visible = AidNote_29_Lable.Visible = false;
                    }
                    else
                    {
                        AidAmount_29_Textbox.Text = "";
                        AidPeriod_29_comboBox.SelectedValue = 0;
                        AidNote_29_Textbox.Text = ds.Tables[0].Rows[0].Field<string>("aid_note_29");
                        aidsource_29_No_RadioButton.Checked = true;
                        AidPeriod_29_comboBox.Visible = isAidPeriod_Lable.Visible = AidAmount_29_Textbox.Visible = isAidAmount_Lable.Visible = false;
                        AidNote_29_Textbox.Visible = AidNote_29_Lable.Visible = true;
                    }
                }
                else
                {
                    AidPeriod_29_comboBox.Visible = isAidPeriod_Lable.Visible = AidAmount_29_Textbox.Visible = isAidAmount_Lable.Visible = false;
                    AidNote_29_Textbox.Visible = AidNote_29_Lable.Visible = false;
                }
            }

            if (ds.Tables[7].Rows.Count != 0)
            {
                //Expenses
                if (ds.Tables[7].Rows[0]["expenses_amount_9"] != DBNull.Value)
                    expenses_amount_9_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("expenses_amount_9").ToString();
                if (ds.Tables[7].Rows[0]["expenses_amount_4"] != DBNull.Value)
                    expenses_amount_4_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("expenses_amount_4").ToString();
                if (ds.Tables[7].Rows[0]["expenses_amount_5"] != DBNull.Value)
                    expenses_amount_5_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("expenses_amount_5").ToString();
                if (ds.Tables[7].Rows[0]["expenses_amount_24"] != DBNull.Value)
                    expenses_amount_24_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("expenses_amount_24").ToString();
                if (ds.Tables[7].Rows[0]["expensestype_9"] != DBNull.Value)
                    expensestype_9_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("expensestype_9").ToString();
                if (ds.Tables[7].Rows[0]["expensestype_4"] != DBNull.Value)
                    expensestype_4_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("expensestype_4").ToString();
                if (ds.Tables[7].Rows[0]["expensestype_5"] != DBNull.Value)
                    expensestype_5_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("expensestype_5").ToString();
                if (ds.Tables[7].Rows[0]["expensestype_24"] != DBNull.Value)
                    expensestype_24_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("expensestype_24").ToString();
                
                if (ds.Tables[7].Rows[0]["hasdisease"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("hasdisease") == 1)
                    {
                        hasdisease_Yes_RadioButton.Checked = true;
                    }
                    else
                    {
                        hasdisease_No_RadioButton.Checked = true;
                        Disease_DataGridView.Enabled = false;
                    }
                }
                //Aids
                if (ds.Tables[7].Rows[0]["aid_amount_21"] != DBNull.Value)
                    aid_amount_21_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("aid_amount_21").ToString();
                if (ds.Tables[7].Rows[0]["aid_amount_1"] != DBNull.Value)
                    aid_amount_1_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("aid_amount_1").ToString();
                if (ds.Tables[7].Rows[0]["aid_amount_13"] != DBNull.Value)
                    aid_amount_13_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("aid_amount_13").ToString();
                if (ds.Tables[7].Rows[0]["aid_amount_8"] != DBNull.Value)
                    aid_amount_8_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("aid_amount_8").ToString();
                if (ds.Tables[7].Rows[0]["aid_amount_6"] != DBNull.Value)
                    aid_amount_6_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("aid_amount_6").ToString();

                if (ds.Tables[7].Rows[0]["hasmicroproject"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("hasmicroproject") == 1)
                    {
                        mp_Yes_RadioButton.Checked = true;
                    }
                    else
                    {
                        mp_No_RadioButton.Checked = true;
                        MP_DataGridView.Enabled = false;
                    }
                }

                if (ds.Tables[7].Rows[0]["aid_10"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("aid_10") == 10)
                    {
                        aid_Yes_10_RadioButton.Checked = true;
                    }
                    else
                    {
                        aid_No_10_RadioButton.Checked = true;
                    }
                    if (ds.Tables[7].Rows[0]["aidperiod_10"] != DBNull.Value)
                        aidperiod_10_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("aidperiod_10");
                    if (ds.Tables[7].Rows[0]["aidsource_10"] != DBNull.Value)
                        aidsource_10_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("aidsource_10");
                    if (ds.Tables[7].Rows[0]["aid_amount_10"] != DBNull.Value)
                        aid_amount_10_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("aid_amount_10").ToString();
                }
                if (ds.Tables[7].Rows[0]["isStudent"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("isStudent") == 1)
                    {
                        IsStudent_RadioButton.Checked = true;

                    }
                    else if (ds.Tables[7].Rows[0].Field<int>("isStudent") == 0)
                    {
                        NotStudent_RadioButton.Checked = true;
                    }
                }

                if (ds.Tables[7].Rows[0]["expenses_amount_2"] != DBNull.Value)
                    expenses_amount_2_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("expenses_amount_2").ToString();
                if (ds.Tables[7].Rows[0]["expensestype_2"] != DBNull.Value)
                    expensestype_2_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("expensestype_2");
                if (ds.Tables[7].Rows[0]["expenses_amount_8"] != DBNull.Value)
                    expenses_amount_8_Textbox.Text = ds.Tables[7].Rows[0].Field<int>("expenses_amount_8").ToString();
                if (ds.Tables[7].Rows[0]["expensestype_8"] != DBNull.Value)
                    expensestype_8_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("expensestype_8");
                if (ds.Tables[7].Rows[0]["aid_amount_8"] != DBNull.Value)
                    aid_amount_8_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("aid_amount_8").ToString();
                if (ds.Tables[7].Rows[0]["aidsource_23"] != DBNull.Value)
                    aidsource_23_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("aidsource_23");
                if (ds.Tables[7].Rows[0]["aid_amount_23"] != DBNull.Value)
                    aid_amount_23_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("aid_amount_23").ToString();
                if (ds.Tables[7].Rows[0]["aidperiod_23"] != DBNull.Value)
                    aidperiod_23_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("aidperiod_23");
                if (ds.Tables[7].Rows[0]["aidsource_2"] != DBNull.Value)
                    aidsource_2_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("aidsource_2");
                if (ds.Tables[7].Rows[0]["aid_amount_2"] != DBNull.Value)
                    aid_amount_2_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("aid_amount_2").ToString();
                if (ds.Tables[7].Rows[0]["aidperiod_2"] != DBNull.Value)
                    aidperiod_2_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("aidperiod_2");

                #region Needs
                //Needs
                if (ds.Tables[7].Rows[0]["needs/1"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("needs/1") == 1)
                    {
                        needs_1_checkBox.Checked = true;
                    }
                    else
                    {
                        needs_1_checkBox.Checked = false;
                    }
                }
                else
                {
                    needs_1_checkBox.Checked = false;
                }
                if (ds.Tables[7].Rows[0]["needs/2"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("needs/2") == 1)
                    {
                        needs_2_checkBox.Checked = true;
                        needs_2_checkBox.Checked = true;
                        needs_courses_TextBox.Visible = true;
                        needs_courses_TextBox.Text = ds.Tables[7].Rows[0].Field<string>("needs_special_courses");
                    }
                    else
                    {
                        needs_2_checkBox.Checked = false;
                        needs_2_checkBox.Checked = false;
                        needs_courses_TextBox.Visible = false;
                    }
                }
                else
                {
                    needs_2_checkBox.Checked = false;
                }
                if (ds.Tables[7].Rows[0]["needs/3"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("needs/3") == 1)
                    {
                        needs_3_checkBox.Checked = true;
                    }
                    else
                    {
                        needs_3_checkBox.Checked = false;
                    }
                }
                else
                {
                    needs_3_checkBox.Checked = false;
                }
                if (ds.Tables[7].Rows[0]["needs/4"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("needs/4") == 1)
                    {
                        needs_4_checkBox.Checked = true;
                    }
                    else
                    {
                        needs_4_checkBox.Checked = false;
                    }
                }
                else
                {
                    needs_4_checkBox.Checked = false;
                }
                if (ds.Tables[7].Rows[0]["needs/5"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("needs/5") == 1)
                    {
                        needs_5_checkBox.Checked = true;
                    }
                    else
                    {
                        needs_5_checkBox.Checked = false;
                    }
                }
                else
                {
                    needs_5_checkBox.Checked = false;
                }
                if (ds.Tables[7].Rows[0]["needs/6"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("needs/6") == 1)
                    {
                        needs_6_checkBox.Checked = true;
                    }
                    else
                    {
                        needs_6_checkBox.Checked = false;
                    }
                }
                else
                {
                    needs_6_checkBox.Checked = false;
                }
                if (ds.Tables[7].Rows[0]["needs/7"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("needs/7") == 1)
                    {
                        needs_7_checkBox.Checked = true;
                    }
                    else
                    {
                        needs_7_checkBox.Checked = false;
                    }
                }
                else
                {
                    needs_7_checkBox.Checked = false;
                }
                if (ds.Tables[7].Rows[0]["needs/8"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("needs/8") == 1)
                    {
                        needs_8_checkBox.Checked = true;
                    }
                    else
                    {
                        needs_8_checkBox.Checked = false;
                    }
                }
                else
                {
                    needs_8_checkBox.Checked = false;
                }
                if (ds.Tables[7].Rows[0]["needs/9"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("needs/9") == 1)
                    {
                        needs_9_checkBox.Checked = true;
                    }
                    else
                    {
                        needs_9_checkBox.Checked = false;
                    }
                }
                else
                {
                    needs_9_checkBox.Checked = false;
                }
                if (ds.Tables[7].Rows[0]["needs/10"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("needs/10") == 1)
                    {
                        needs_10_checkBox.Checked = true;
                    }
                    else
                    {
                        needs_10_checkBox.Checked = false;
                    }
                }
                else
                {
                    needs_10_checkBox.Checked = false;
                }
                if (ds.Tables[7].Rows[0]["needs/12"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("needs/12") == 1)
                    {
                        needs_12_checkBox.Checked = true;
                    }
                    else
                    {
                        needs_12_checkBox.Checked = false;
                    }
                }
                else
                {
                    needs_12_checkBox.Checked = false;
                }
                if (ds.Tables[7].Rows[0]["needs/0"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("needs/0") == 1)
                    {
                        needs_0_checkBox.Checked = true;
                        needs_note_TextBox.Visible = true;
                        needs_note_TextBox.Text = ds.Tables[7].Rows[0].Field<string>("needs_note");
                    }
                    else
                    {
                        needs_0_checkBox.Checked = false;
                        needs_note_TextBox.Visible = false;

                    }
                }
                else
                {
                    needs_0_checkBox.Checked = false;
                }

                #endregion

                DataTable dt1 = ds.Tables[7].Copy();
                DataTable dt2 = ds.Tables[7].Copy();
                DataTable dt3 = ds.Tables[7].Copy();

                aidsource_1_comboBox.SelectedValue = aidsource_13_comboBox.SelectedValue = aidsource_6_comboBox.SelectedValue = aidsource_8_comboBox.SelectedValue = 0;


                if (dt1.Rows[0]["aidsource_21"] != DBNull.Value)
                {
                    string temp = dt1.Rows[0].Field<int>("aidsource_21").ToString();
                    aidsource_21_comboBox.SelectedValue = temp;
                }
                if (ds.Tables[7].Rows[0]["aidsource_1"] != DBNull.Value)
                {
                    aidsource_1_comboBox.SelectedValue = dt2.Rows[0].Field<int>("aidsource_1").ToString();
                }
                if (ds.Tables[7].Rows[0]["aidsource_13"] != DBNull.Value)
                {
                    aidsource_13_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("aidsource_13").ToString();

                }
                if (ds.Tables[7].Rows[0]["aidsource_6"] != DBNull.Value)
                {
                    aidsource_6_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("aidsource_6").ToString();
                }
                if (ds.Tables[7].Rows[0]["aidsource_8"] != DBNull.Value)
                {
                    aidsource_8_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("aidsource_8").ToString();
                }

                if (ds.Tables[7].Rows[0]["aidperiod_21"] != DBNull.Value)
                    aidperiod_21_comboBox.SelectedValue = dt1.Rows[0].Field<int>("aidperiod_21").ToString();
                if (ds.Tables[7].Rows[0]["aidperiod_1"] != DBNull.Value)
                    aidperiod_1_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("aidperiod_1").ToString();
                if (ds.Tables[7].Rows[0]["aidperiod_13"] != DBNull.Value)
                    aidperiod_13_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("aidperiod_13").ToString();
                if (ds.Tables[7].Rows[0]["aidperiod_6"] != DBNull.Value)
                    aidperiod_6_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("aidperiod_6").ToString();
                if (ds.Tables[7].Rows[0]["aidperiod_8"] != DBNull.Value)
                    aidperiod_8_comboBox.SelectedValue = ds.Tables[7].Rows[0].Field<int>("aidperiod_8").ToString();

                if (ds.Tables[7].Rows[0]["operation_name_2"] != DBNull.Value)
                {
                    operation_name_2_TextBox.Text = ds.Tables[7].Rows[0].Field<string>("operation_name_2");
                }
                if (ds.Tables[7].Rows[0]["operation_value_2"] != DBNull.Value)
                {
                    operation_value_2_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("operation_value_2").ToString();
                }
                if (ds.Tables[7].Rows[0]["operation_name_1"] != DBNull.Value)
                {
                    operation_name_1_TextBox.Text = ds.Tables[7].Rows[0].Field<string>("operation_name_1");
                }
                if (ds.Tables[7].Rows[0]["operation_value_1"] != DBNull.Value)
                {
                    operation_value_1_TextBox.Text = ds.Tables[7].Rows[0].Field<int>("operation_value_1").ToString();
                }

                if (ds.Tables[7].Rows[0]["haswork"] != DBNull.Value)
                {
                    if (ds.Tables[7].Rows[0].Field<int>("haswork") == 1)
                    {
                        haswork_Yes_RadioButton.Checked = true;
                    }
                    else
                    {
                        haswork_No_RadioButton.Checked = true;
                        WorkExp_DataGridView.Enabled = false;
                    }
                }

                if (ds.Tables[7].Rows[0]["person_note"] != DBNull.Value)
                    PersonNote_TextBox.Text = ds.Tables[7].Rows[0].Field<string>("person_note");
            }

            if (ds.Tables[6].Rows.Count != 0)
            {
                if (ds.Tables[6].Rows[0]["isReceiver"] != DBNull.Value)
                {
                    if (ds.Tables[6].Rows[0].Field<int>("isReceiver") == 1)
                    {
                        Receiver_RadioButton.Checked = true;
                        Relation_ComboBox.Visible = Relation_Label.Visible
                            //= StateAddress_Lable.Visible  = StateAddress_TextBox.Visible = StateYear_Lable.Visible = Stateyear_TextBox.Visible 
                            = isAid_Lable.Visible = isAidAmount_Lable.Visible = AidAmount_29_Textbox.Visible = isAidPeriod_Lable.Visible = AidPeriod_29_comboBox.Visible = isAid_Panel.Visible = State_ComboBox.Visible = State_Label1.Visible = AidNote_29_Lable.Visible = AidNote_29_Textbox.Visible = false;
                    }
                    else
                    {
                        NotReceiver_RadioButton.Checked = true;
                        Relation_ComboBox.Visible = Relation_Label.Visible
                            //= StateAddress_Lable.Visible = StateAddress_TextBox.Visible = StateYear_Lable.Visible = Stateyear_TextBox.Visible 
                            = isAid_Panel.Visible = State_ComboBox.Visible = State_Label1.Visible = true;
                    }
                }
            }

            Disease_DataGridView.Rows.Clear();
            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            {
                Disease_DataGridView.Rows.Add();
                Disease_DataGridView.Columns[0].ReadOnly = true;
                if (ds.Tables[2].Rows[0]["visit_name"] != DBNull.Value)
                    Disease_DataGridView.Rows[i].Cells["Disease_VisitName"].Value = ds.Tables[2].Rows[i].Field<string>("visit_name");
                
                if (ds.Tables[2].Rows[0]["diseasecategory_id"] != DBNull.Value)
                {
                    int Disease_Category_ID = ds.Tables[2].Rows[i].Field<int>("diseasecategory_id");
                    Disease_DataGridView.Rows[i].Cells["Disease_Category"].Value = Disease_Category_ID;
                }

                if (ds.Tables[2].Rows[i]["disease_id"] != DBNull.Value)
                {
                    int Disease_ID = ds.Tables[2].Rows[i].Field<int>("disease_id");
                    Disease_DataGridView.Rows[i].Cells["Disease"].Value = Disease_ID;
                }
                else Disease_DataGridView.Rows[i].Cells["Disease"].Value = 0;


                if (ds.Tables[2].Rows[0]["disease_Note"] != DBNull.Value)
                    Disease_DataGridView.Rows[i].Cells["DiseaseNote"].Value = ds.Tables[2].Rows[i].Field<string>("disease_Note");
                
                Disease_DataGridView.Rows[i].Cells["Person_Disease_ID"].Value = ds.Tables[2].Rows[i].Field<int>("id");
                
                if (!Disease_DataGridView.Rows[i].Cells["Disease_VisitName"].Value.Equals(VisitNameLabel.Text))
                {
                    Disease_DataGridView.Rows[i].ReadOnly = true;
                }
            }

            WorkExp_DataGridView.Rows.Clear();
            for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
            {
                WorkExp_DataGridView.Rows.Add();
                WorkExp_DataGridView.Columns[0].ReadOnly = true;
                WorkExp_DataGridView.Rows[i].Cells["Person_Work_ID"].Value = ds.Tables[3].Rows[i].Field<int>("id");
                if (ds.Tables[3].Rows[i]["visit_name"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["Work_VisitName"].Value = ds.Tables[3].Rows[i].Field<string>("visit_name");
                if (ds.Tables[3].Rows[i]["workexp_id"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["workexp_id"].Value = ds.Tables[3].Rows[i].Field<int>("workexp_id");
                if (ds.Tables[3].Rows[i]["workexpamount"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["workexpamount"].Value = ds.Tables[3].Rows[i].Field<int>("workexpamount");
                if (ds.Tables[3].Rows[i]["workposition_id"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["workposition_id"].Value = ds.Tables[3].Rows[i].Field<int>("workposition_id");
                if (ds.Tables[3].Rows[i]["workplace_id"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["workplace_id"].Value = ds.Tables[3].Rows[i].Field<int>("workplace_id");
                if (ds.Tables[3].Rows[i]["workfor_id"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["workfor_id"].Value = ds.Tables[3].Rows[i].Field<int>("workfor_id");
                if (ds.Tables[3].Rows[i]["experience_id"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["experience_id"].Value = ds.Tables[3].Rows[i].Field<int>("experience_id");
                if (ds.Tables[3].Rows[i]["worktype_id"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["worktype_id"].Value = ds.Tables[3].Rows[i].Field<int>("worktype_id");
                if (ds.Tables[3].Rows[i]["workname"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["workname"].Value = ds.Tables[3].Rows[i].Field<string>("workname");
                if (ds.Tables[3].Rows[i]["workexpnote"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["workexpnote"].Value = ds.Tables[3].Rows[i].Field<string>("workexpnote");
                if (ds.Tables[3].Rows[i]["expenses_amount_6"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["expenses_amount_6"].Value = ds.Tables[3].Rows[i].Field<int>("expenses_amount_6").ToString();
                if (ds.Tables[3].Rows[i]["expensestype_6"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["expensestype_6"].Value = ds.Tables[3].Rows[i].Field<int>("expensestype_6");
                if (ds.Tables[3].Rows[i]["expenses_amount_7"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["expenses_amount_7"].Value = ds.Tables[3].Rows[i].Field<int>("expenses_amount_7").ToString();
                if (ds.Tables[3].Rows[i]["expensesAmperNumber_7"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["expensesAmperNumber_7"].Value = ds.Tables[3].Rows[i].Field<int>("expensesAmperNumber_7");
                if (ds.Tables[3].Rows[i]["expenses_amount_15"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["expenses_amount_15"].Value = ds.Tables[3].Rows[i].Field<int>("expenses_amount_15").ToString();
                if (ds.Tables[3].Rows[i]["expensestype_15"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["expensestype_15"].Value = ds.Tables[3].Rows[i].Field<int>("expensestype_15");
                if (ds.Tables[3].Rows[i]["expenses_amount_16"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["expenses_amount_16"].Value = ds.Tables[3].Rows[i].Field<int>("expenses_amount_16").ToString();
                if (ds.Tables[3].Rows[i]["expensestype_16"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["expensestype_16"].Value = ds.Tables[3].Rows[i].Field<int>("expensestype_16");
                if (ds.Tables[3].Rows[i]["expenses_amount_17"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["expenses_amount_17"].Value = ds.Tables[3].Rows[i].Field<int>("expenses_amount_17").ToString();
                if (ds.Tables[3].Rows[i]["expensestype_17"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["expensestype_17"].Value = ds.Tables[3].Rows[i].Field<int>("expensestype_17");
                if (ds.Tables[3].Rows[i]["expenses_amount_23"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["expenses_amount_23"].Value = ds.Tables[3].Rows[i].Field<int>("expenses_amount_23").ToString();
                if (ds.Tables[3].Rows[i]["expensestype_23"] != DBNull.Value)
                    WorkExp_DataGridView.Rows[i].Cells["expensestype_23"].Value = ds.Tables[3].Rows[i].Field<int>("expensestype_23");
                if (!WorkExp_DataGridView.Rows[i].Cells["Work_VisitName"].Value.Equals(VisitNameLabel.Text))
                {
                    WorkExp_DataGridView.Rows[i].ReadOnly = true;
                }
            }

            MP_DataGridView.Rows.Clear();
            for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
            {
                MP_DataGridView.Rows.Add();
                MP_DataGridView.Columns[0].ReadOnly = true;
                MP_DataGridView.Rows[i].Cells["Person_MP_ID"].Value = ds.Tables[4].Rows[i].Field<int>("id");
                if (ds.Tables[4].Rows[i]["visit_name"] != DBNull.Value)
                    MP_DataGridView.Rows[i].Cells["MP_VisitName"].Value = ds.Tables[4].Rows[i].Field<string>("visit_name");
                if (ds.Tables[4].Rows[i]["mp_fundyear"] != DBNull.Value)
                    MP_DataGridView.Rows[i].Cells["mp_fundyear"].Value = ds.Tables[4].Rows[i].Field<int>("mp_fundyear");
                if (!ds.Tables[4].Rows[i].IsNull("aidsource_5_mp"))
                {
                    MP_DataGridView.Rows[i].Cells["aidsource_5_mp"].Value = ds.Tables[4].Rows[i].Field<int>("aidsource_5_mp");
                }
                if (ds.Tables[4].Rows[i]["aid_amount_5_mp"] != DBNull.Value)
                    MP_DataGridView.Rows[i].Cells["aid_amount_5_mp"].Value = ds.Tables[4].Rows[i].Field<int>("aid_amount_5_mp");
                if (ds.Tables[4].Rows[i]["aidperiod_5_mp"] != DBNull.Value)
                    MP_DataGridView.Rows[i].Cells["aidperiod_5_mp"].Value = ds.Tables[4].Rows[i].Field<int>("aidperiod_5_mp");
                if (ds.Tables[4].Rows[i]["aidsource_17_mp"] != DBNull.Value)
                    MP_DataGridView.Rows[i].Cells["aidsource_17_mp"].Value = ds.Tables[4].Rows[i].Field<int>("aidsource_17_mp");
                if (ds.Tables[4].Rows[i]["aid_amount_17_mp"] != DBNull.Value)
                    MP_DataGridView.Rows[i].Cells["aid_amount_17_mp"].Value = ds.Tables[4].Rows[i].Field<int>("aid_amount_17_mp");
                if (ds.Tables[4].Rows[i]["aidperiod_17_mp"] != DBNull.Value)
                    MP_DataGridView.Rows[i].Cells["aidperiod_17_mp"].Value = ds.Tables[4].Rows[i].Field<int>("aidperiod_17_mp");
                if (ds.Tables[4].Rows[i]["aidsource_22_mp"] != DBNull.Value)
                    MP_DataGridView.Rows[i].Cells["aidsource_22_mp"].Value = ds.Tables[4].Rows[i].Field<int>("aidsource_22_mp");
                if (ds.Tables[4].Rows[i]["aid_amount_22_mp"] != DBNull.Value)
                    MP_DataGridView.Rows[i].Cells["aid_amount_22_mp"].Value = ds.Tables[4].Rows[i].Field<int>("aid_amount_22_mp");
                if (ds.Tables[4].Rows[i]["aidperiod_22_mp"] != DBNull.Value)
                    MP_DataGridView.Rows[i].Cells["aidperiod_22_mp"].Value = ds.Tables[4].Rows[i].Field<int>("aidperiod_22_mp");
                if (ds.Tables[4].Rows[i]["expenses_amount_12_mp"] != DBNull.Value)
                    MP_DataGridView.Rows[i].Cells["expenses_amount_12_mp"].Value = ds.Tables[4].Rows[i].Field<int>("expenses_amount_12_mp");
                if (ds.Tables[4].Rows[i]["expensestype_12_mp"] != DBNull.Value)
                    MP_DataGridView.Rows[i].Cells["expensestype_12_mp"].Value = ds.Tables[4].Rows[i].Field<int>("expensestype_12_mp");
                if (!MP_DataGridView.Rows[i].Cells["MP_VisitName"].Value.Equals(VisitNameLabel.Text))
                {
                    MP_DataGridView.Rows[i].ReadOnly = true;
                }
            }
             
            UserMode = true;
        }
        private void StateHistory_Button_Click(object sender, EventArgs e)
        {
            try
            {
                History_Form NewHistory_Form = new History_Form("PersonState", Person_ID, main_form);
                NewHistory_Form.ShowDialog();
            }
            catch (Exception ex)
            { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }
        }
        private void MaritalHistory_Button_Click(object sender, EventArgs e)
        {
            try
            {
                History_Form NewHistory_Form = new History_Form("PersonMaritalState", Person_ID, main_form);
                NewHistory_Form.ShowDialog();
            }
            catch (Exception ex)
            { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }

        }

        private void IsStudent_RadioButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (!IsStudent_RadioButton.Checked)
                        IsStudent_RadioButton.Checked = true;
                    else
                        IsStudent_RadioButton.Checked = false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        #region KeyPress
        private void NationalityNumber_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Arabic_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"^[\u0621-\u063A\u0641-\u064A\u064B-\u0655]") && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void English_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z')) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void MyDataGridViewInitializationMethod()
        {
            WorkExp_DataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(WorkExp_DataGridView_EditingControlShowing);
        }

        private void WorkExp_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(WorkExp_DataGridView_Control_KeyPress);
        }

        private void WorkExp_DataGridView_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && WorkExp_DataGridView.CurrentCellAddress.X == 1)
            {
                e.Handled = true;
            }
        }

        #endregion
        protected override Point ScrollToControl(Control activeControl) //STOP AUTO SCROLL
        {
            Point pt = this.AutoScrollPosition;
            return pt;
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Main_TableLayoutPanel.Size = new Size(this.Width - 10, 6000);
                DialogResult dialogResult = MessageBox.Show("هل تريد حذف جميع البيانات غير المحفوظة؟؟", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Bind_ComboBoxes(false);
                    Clear_Boxes();
                    if (UpdateMode)
                    {
                        Fill_Person(Visit_ID);
                    }
                    Set_Controls();
                }
                else
                {
                    Bind_ComboBoxes(true);
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void newPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form Person_Form = new Person_Form(Family_ID, Visit_ID, Visit_Name, FamilyCode_TextBox.Text, main_form);
                main_form.showNewTab(Person_Form, "Member");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void showFamilyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
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
                //Family_Form.ShowDialog();
                main_form.showNewTab(Family_Form, "Family");*/
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void StateHistory_Button_MouseEnter(object sender, EventArgs e)
        {
            StateHistory_Button.BackgroundImage = F2F_Application.Properties.Resources.button2_1;

        }
        private void StateHistory_Button_MouseLeave(object sender, EventArgs e)
        {
            StateHistory_Button.BackgroundImage = F2F_Application.Properties.Resources.button2;

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
        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
    }
}














