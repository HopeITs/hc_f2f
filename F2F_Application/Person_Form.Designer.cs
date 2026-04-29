using System.Windows.Forms;

namespace F2F_Application
{
    partial class Person_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.materialContextMenuStrip1 = new MaterialSkinPlus.Controls.MaterialContextMenuStrip();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newPersonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showFamilyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MEFamily_DataGridView = new System.Windows.Forms.DataGridView();
            this.ME_Family_Visit_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ME_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ME_Scedualed_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ME_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ME_State = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ME_Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ME_Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ME_Canceled_Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ME_Story = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ME_Link1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ME_Link2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ME_Link3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ME_Visit_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ME_Visit_Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.SecondTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.Update_Button = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ExpensesLable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.expensestype_24_comboBox = new System.Windows.Forms.ComboBox();
            this.expensestype_5_comboBox = new System.Windows.Forms.ComboBox();
            this.materialLabel161 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel23 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel24 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel25 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel26 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel27 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.expensestype_9_comboBox = new System.Windows.Forms.ComboBox();
            this.expensestype_4_comboBox = new System.Windows.Forms.ComboBox();
            this.expenses_amount_9_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.expenses_amount_4_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.expenses_amount_5_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.materialLabel62 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.expenses_amount_24_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.panel5 = new System.Windows.Forms.Panel();
            this.IllnessLable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.Disease_DataGridView = new System.Windows.Forms.DataGridView();
            this.Disease_VisitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disease_Category = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Disease = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DiseaseNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disease_DeleteRow = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Person_Disease_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disease_IsDirty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel8 = new System.Windows.Forms.Panel();
            this.AidLable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.aidperiod_8_comboBox = new System.Windows.Forms.ComboBox();
            this.aidperiod_13_comboBox = new System.Windows.Forms.ComboBox();
            this.aidperiod_21_comboBox = new System.Windows.Forms.ComboBox();
            this.aidperiod_1_comboBox = new System.Windows.Forms.ComboBox();
            this.aid_amount_21_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.aid_amount_1_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.aid_amount_13_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.materialLabel22 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel28 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel29 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel33 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel30 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel31 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel34 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel35 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel32 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.aidperiod_6_comboBox = new System.Windows.Forms.ComboBox();
            this.aidsource_21_comboBox = new System.Windows.Forms.ComboBox();
            this.aidsource_6_comboBox = new System.Windows.Forms.ComboBox();
            this.aidsource_8_comboBox = new System.Windows.Forms.ComboBox();
            this.aid_amount_6_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.aid_amount_8_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.aidsource_1_comboBox = new System.Windows.Forms.ComboBox();
            this.aidsource_13_comboBox = new System.Windows.Forms.ComboBox();
            this.materialLabel36 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel37 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel39 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel38 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.operation_name_2_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.operation_name_1_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.materialLabel41 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.operation_value_2_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.materialLabel1 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.operation_value_1_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.materialLabel64 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.aid10_military_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.aid_No_10_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.aid_Yes_10_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.militaryPanel = new System.Windows.Forms.TableLayoutPanel();
            this.materialLabel65 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel67 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel66 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.aid_amount_10_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.aidsource_10_comboBox = new System.Windows.Forms.ComboBox();
            this.aidperiod_10_comboBox = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.StudyLable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.hasdisease_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.hasdisease_Yes_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.hasdisease_No_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.haswork_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.haswork_No_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.haswork_Yes_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.materialLabel43 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.WorkLable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.WorkExp_DataGridView = new System.Windows.Forms.DataGridView();
            this.Work_VisitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workexp_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.workfor_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.worktype_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.workposition_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.experience_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.workexpamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workplace_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.expenses_amount_6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expensestype_6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.expensesAmperNumber_7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expenses_amount_7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expenses_amount_15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expensestype_15 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.expenses_amount_16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expensestype_16 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.expenses_amount_17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expensestype_17 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.expenses_amount_23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expensestype_23 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.workexpnote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Work_DeleteRow = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Person_Work_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Work_IsDirty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.has_mp_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mp_No_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.mp_Yes_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.materialLabel51 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.MPLable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.MP_DataGridView = new System.Windows.Forms.DataGridView();
            this.MP_VisitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mp_fundyear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aidsource_5_mp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aid_amount_5_mp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aidperiod_5_mp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aidsource_17_mp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aid_amount_17_mp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aidperiod_17_mp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aidsource_22_mp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aid_amount_22_mp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aidperiod_22_mp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.expenses_amount_12_mp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expensestype_12_mp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MP_DeleteRow = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Person_MP_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MP_IsDirty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.materialRadioButton2 = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.materialRadioButton1 = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.IsStudent_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NotStudent_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.IsStudent_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.materialLabel70 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.studentPanel = new System.Windows.Forms.TableLayoutPanel();
            this.expensestype_2_comboBox = new System.Windows.Forms.ComboBox();
            this.materialLabel72 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel71 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel73 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel75 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel74 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.expenses_amount_8_Textbox = new System.Windows.Forms.TextBox();
            this.expenses_amount_2_TextBox = new System.Windows.Forms.TextBox();
            this.expensestype_8_comboBox = new System.Windows.Forms.ComboBox();
            this.student1Panel = new System.Windows.Forms.TableLayoutPanel();
            this.aidperiod_23_comboBox = new System.Windows.Forms.ComboBox();
            this.materialLabel76 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel77 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel79 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel78 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel81 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel80 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.aid_amount_2_TextBox = new System.Windows.Forms.TextBox();
            this.aid_amount_23_TextBox = new System.Windows.Forms.TextBox();
            this.aidsource_2_comboBox = new System.Windows.Forms.ComboBox();
            this.aidsource_23_comboBox = new System.Windows.Forms.ComboBox();
            this.aidperiod_2_comboBox = new System.Windows.Forms.ComboBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.NeedsLable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.needs_1_checkBox = new System.Windows.Forms.CheckBox();
            this.needs_8_checkBox = new System.Windows.Forms.CheckBox();
            this.needs_3_checkBox = new System.Windows.Forms.CheckBox();
            this.needs_4_checkBox = new System.Windows.Forms.CheckBox();
            this.needs_6_checkBox = new System.Windows.Forms.CheckBox();
            this.needs_7_checkBox = new System.Windows.Forms.CheckBox();
            this.needs_courses_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.needs_9_checkBox = new System.Windows.Forms.CheckBox();
            this.needs_10_checkBox = new System.Windows.Forms.CheckBox();
            this.needs_0_checkBox = new System.Windows.Forms.CheckBox();
            this.needs_12_checkBox = new System.Windows.Forms.CheckBox();
            this.needs_note_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.panel6 = new System.Windows.Forms.Panel();
            this.GeneralNoteLable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel21 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.VisitNameLabel = new System.Windows.Forms.Label();
            this.VisitInfoLabel = new MaterialSkinPlus.Controls.MaterialLabel();
            this.needs_5_checkBox = new System.Windows.Forms.CheckBox();
            this.needs_2_checkBox = new System.Windows.Forms.CheckBox();
            this.PersonNote_TextBox = new System.Windows.Forms.TextBox();
            this.MELayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.visit_Label = new MaterialSkinPlus.Controls.MaterialLabel();
            this.FirstLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.StateAddressNote_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.StateAddressNote_Lable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.Note_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.materialLabel47 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.Receiver_LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Receiver_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.NotReceiver_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.materialLabel48 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel49 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Stateyear_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.NationalityNumber_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.materialLabel52 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.StateYear_Lable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel53 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.Nationality_ComboBox = new System.Windows.Forms.ComboBox();
            this.Sex_ComboBox = new System.Windows.Forms.ComboBox();
            this.ELastName_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.LastName_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.EFatherName_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.EName_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.FatherName_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.materialLabel54 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.FirstName_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.materialLabel55 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel56 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel57 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel58 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel59 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel16 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.FamilyCode_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.State_Label1 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.State_ComboBox = new System.Windows.Forms.ComboBox();
            this.materialLabel20 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.MaritalStatus_ComboBox = new System.Windows.Forms.ComboBox();
            this.Relation_Label = new MaterialSkinPlus.Controls.MaterialLabel();
            this.Relation_ComboBox = new System.Windows.Forms.ComboBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.PGeneralNoteLable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.educatedPanel = new System.Windows.Forms.TableLayoutPanel();
            this.educationnote2_TextBox = new System.Windows.Forms.TextBox();
            this.educationtype_id_1_comboBox = new System.Windows.Forms.ComboBox();
            this.materialLabel2 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel10 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel17 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel40 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel42 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.education_id_1_comboBox = new System.Windows.Forms.ComboBox();
            this.education_id_2_comboBox = new System.Windows.Forms.ComboBox();
            this.educationfield_id_1_comboBox = new System.Windows.Forms.ComboBox();
            this.educationfield_id_2_comboBox = new System.Windows.Forms.ComboBox();
            this.educationtype_id_2_comboBox = new System.Windows.Forms.ComboBox();
            this.educationnote_TextBox = new System.Windows.Forms.TextBox();
            this.materialLabel12 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InfoLable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.InfoInsideFamilyLable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.materialLabel19 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.IsEducated_LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Educated_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.NotEducated_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.AidAmount_29_Textbox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.AidPeriod_29_comboBox = new System.Windows.Forms.ComboBox();
            this.isAid_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.aidsource_29_Yes_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.aidsource_29_No_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.AidNote_29_Textbox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.materialLabel5 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.visitLabel = new MaterialSkinPlus.Controls.MaterialLabel();
            this.visit_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.State_Label = new MaterialSkinPlus.Controls.MaterialLabel();
            this.State_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.SavePerson_Button = new System.Windows.Forms.Button();
            this.UpdatePerson_Button = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.StateHistory_Button = new System.Windows.Forms.Button();
            this.MaritalHistory_Button = new System.Windows.Forms.Button();
            this.AidNote_29_Lable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.isAid_Lable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.isAidAmount_Lable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.isAidPeriod_Lable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.StateAddress_Lable = new MaterialSkinPlus.Controls.MaterialLabel();
            this.StateAddress_ComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.materialContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MEFamily_DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.PersonPanel.SuspendLayout();
            this.SecondTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Disease_DataGridView)).BeginInit();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.aid10_military_tableLayoutPanel.SuspendLayout();
            this.militaryPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.hasdisease_tableLayoutPanel.SuspendLayout();
            this.haswork_tableLayoutPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkExp_DataGridView)).BeginInit();
            this.has_mp_tableLayoutPanel.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MP_DataGridView)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.IsStudent_tableLayoutPanel.SuspendLayout();
            this.studentPanel.SuspendLayout();
            this.student1Panel.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel12.SuspendLayout();
            this.MELayoutPanel.SuspendLayout();
            this.panel11.SuspendLayout();
            this.FirstLayoutPanel.SuspendLayout();
            this.Receiver_LayoutPanel.SuspendLayout();
            this.panel13.SuspendLayout();
            this.educatedPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.IsEducated_LayoutPanel.SuspendLayout();
            this.isAid_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem1,
            this.newPersonToolStripMenuItem1,
            this.showFamilyToolStripMenuItem1});
            this.materialContextMenuStrip1.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(169, 76);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(168, 24);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // newPersonToolStripMenuItem1
            // 
            this.newPersonToolStripMenuItem1.Name = "newPersonToolStripMenuItem1";
            this.newPersonToolStripMenuItem1.Size = new System.Drawing.Size(168, 24);
            this.newPersonToolStripMenuItem1.Text = "New Member";
            this.newPersonToolStripMenuItem1.Click += new System.EventHandler(this.newPersonToolStripMenuItem_Click);
            // 
            // showFamilyToolStripMenuItem1
            // 
            this.showFamilyToolStripMenuItem1.Name = "showFamilyToolStripMenuItem1";
            this.showFamilyToolStripMenuItem1.Size = new System.Drawing.Size(168, 24);
            this.showFamilyToolStripMenuItem1.Text = "Show Family";
            this.showFamilyToolStripMenuItem1.Click += new System.EventHandler(this.showFamilyToolStripMenuItem_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 100;
            // 
            // MEFamily_DataGridView
            // 
            this.MEFamily_DataGridView.AllowUserToDeleteRows = false;
            this.MEFamily_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.MEFamily_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.MEFamily_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MEFamily_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.MEFamily_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.MEFamily_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MEFamily_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MEFamily_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.MEFamily_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MEFamily_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ME_Family_Visit_ID,
            this.ME_Name,
            this.ME_Scedualed_Date,
            this.ME_Date,
            this.ME_State,
            this.ME_Reason,
            this.ME_Delete,
            this.ME_Canceled_Reason,
            this.ME_Story,
            this.ME_Link1,
            this.ME_Link2,
            this.ME_Link3,
            this.ME_Visit_Date,
            this.ME_Visit_Team});
            this.MELayoutPanel.SetColumnSpan(this.MEFamily_DataGridView, 10);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MEFamily_DataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.MEFamily_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MEFamily_DataGridView.EnableHeadersVisualStyles = false;
            this.MEFamily_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.MEFamily_DataGridView.Location = new System.Drawing.Point(23, 54);
            this.MEFamily_DataGridView.Name = "MEFamily_DataGridView";
            this.MEFamily_DataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MEFamily_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MEFamily_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.MEFamily_DataGridView.RowHeadersWidth = 51;
            this.MEFamily_DataGridView.RowTemplate.Height = 24;
            this.MEFamily_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MEFamily_DataGridView.Size = new System.Drawing.Size(1192, 122);
            this.MEFamily_DataGridView.TabIndex = 46;
            this.toolTip1.SetToolTip(this.MEFamily_DataGridView, "لانشاء زيارة جديدة قم باخال تاريخ جدولة جديد");
            this.MEFamily_DataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MEFamily_DataGridView_RowHeaderMouseClick);
            this.MEFamily_DataGridView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MEFamily_DataGridView_RowHeaderMouseDoubleClick);
            // 
            // ME_Family_Visit_ID
            // 
            this.ME_Family_Visit_ID.HeaderText = "InDatabase";
            this.ME_Family_Visit_ID.MinimumWidth = 6;
            this.ME_Family_Visit_ID.Name = "ME_Family_Visit_ID";
            this.ME_Family_Visit_ID.Visible = false;
            // 
            // ME_Name
            // 
            this.ME_Name.HeaderText = "الزيارة";
            this.ME_Name.MinimumWidth = 6;
            this.ME_Name.Name = "ME_Name";
            // 
            // ME_Scedualed_Date
            // 
            this.ME_Scedualed_Date.HeaderText = "تاريخ جدولة الزيارة";
            this.ME_Scedualed_Date.MinimumWidth = 6;
            this.ME_Scedualed_Date.Name = "ME_Scedualed_Date";
            // 
            // ME_Date
            // 
            this.ME_Date.HeaderText = "تاريخ الزيارة";
            this.ME_Date.MinimumWidth = 6;
            this.ME_Date.Name = "ME_Date";
            // 
            // ME_State
            // 
            this.ME_State.HeaderText = "حالة الزيارة";
            this.ME_State.MinimumWidth = 6;
            this.ME_State.Name = "ME_State";
            this.ME_State.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ME_State.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ME_Reason
            // 
            this.ME_Reason.HeaderText = "السبب";
            this.ME_Reason.MinimumWidth = 6;
            this.ME_Reason.Name = "ME_Reason";
            // 
            // ME_Delete
            // 
            this.ME_Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ME_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ME_Delete.HeaderText = "";
            this.ME_Delete.MinimumWidth = 50;
            this.ME_Delete.Name = "ME_Delete";
            this.ME_Delete.Width = 50;
            // 
            // ME_Canceled_Reason
            // 
            this.ME_Canceled_Reason.HeaderText = "Canceled_Reason";
            this.ME_Canceled_Reason.MinimumWidth = 6;
            this.ME_Canceled_Reason.Name = "ME_Canceled_Reason";
            this.ME_Canceled_Reason.Visible = false;
            // 
            // ME_Story
            // 
            this.ME_Story.HeaderText = "Story";
            this.ME_Story.MinimumWidth = 6;
            this.ME_Story.Name = "ME_Story";
            this.ME_Story.Visible = false;
            // 
            // ME_Link1
            // 
            this.ME_Link1.HeaderText = "Link1";
            this.ME_Link1.MinimumWidth = 6;
            this.ME_Link1.Name = "ME_Link1";
            this.ME_Link1.Visible = false;
            // 
            // ME_Link2
            // 
            this.ME_Link2.HeaderText = "Link2";
            this.ME_Link2.MinimumWidth = 6;
            this.ME_Link2.Name = "ME_Link2";
            this.ME_Link2.Visible = false;
            // 
            // ME_Link3
            // 
            this.ME_Link3.HeaderText = "Link3";
            this.ME_Link3.MinimumWidth = 6;
            this.ME_Link3.Name = "ME_Link3";
            this.ME_Link3.Visible = false;
            // 
            // ME_Visit_Date
            // 
            this.ME_Visit_Date.HeaderText = "Visit_Date";
            this.ME_Visit_Date.MinimumWidth = 6;
            this.ME_Visit_Date.Name = "ME_Visit_Date";
            this.ME_Visit_Date.Visible = false;
            // 
            // ME_Visit_Team
            // 
            this.ME_Visit_Team.HeaderText = "Visit_Team";
            this.ME_Visit_Team.MinimumWidth = 6;
            this.ME_Visit_Team.Name = "ME_Visit_Team";
            this.ME_Visit_Team.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox2.BackgroundImage = global::F2F_Application.Properties.Resources.Exit_D;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(-215, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 79;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "مسح جميع معلومات التعليم");
            this.pictureBox2.Visible = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::F2F_Application.Properties.Resources.Exit_D;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(345, 382);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(12, 1);
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "مسح تاريخ الميلاد");
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::F2F_Application.Properties.Resources.Exit_D;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(489, 373);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 18);
            this.pictureBox3.TabIndex = 80;
            this.pictureBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox3, "مسح تاريخ الميلاد");
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // PersonPanel
            // 
            this.PersonPanel.AutoScroll = true;
            this.PersonPanel.AutoSize = true;
            this.PersonPanel.Controls.Add(this.SecondTableLayoutPanel);
            this.PersonPanel.Controls.Add(this.MELayoutPanel);
            this.PersonPanel.Controls.Add(this.FirstLayoutPanel);
            this.PersonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonPanel.Location = new System.Drawing.Point(0, 0);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(1262, 673);
            this.PersonPanel.TabIndex = 3;
            // 
            // SecondTableLayoutPanel
            // 
            this.SecondTableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.SecondTableLayoutPanel.ColumnCount = 12;
            this.SecondTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SecondTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SecondTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SecondTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SecondTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SecondTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.16F));
            this.SecondTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.84F));
            this.SecondTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SecondTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SecondTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SecondTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SecondTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.SecondTableLayoutPanel.ContextMenuStrip = this.materialContextMenuStrip1;
            this.SecondTableLayoutPanel.Controls.Add(this.tableLayoutPanel10, 4, 66);
            this.SecondTableLayoutPanel.Controls.Add(this.panel7, 1, 11);
            this.SecondTableLayoutPanel.Controls.Add(this.tableLayoutPanel3, 1, 13);
            this.SecondTableLayoutPanel.Controls.Add(this.panel5, 1, 4);
            this.SecondTableLayoutPanel.Controls.Add(this.Disease_DataGridView, 1, 6);
            this.SecondTableLayoutPanel.Controls.Add(this.panel8, 1, 18);
            this.SecondTableLayoutPanel.Controls.Add(this.tableLayoutPanel4, 1, 20);
            this.SecondTableLayoutPanel.Controls.Add(this.materialLabel36, 9, 25);
            this.SecondTableLayoutPanel.Controls.Add(this.materialLabel37, 9, 26);
            this.SecondTableLayoutPanel.Controls.Add(this.materialLabel39, 8, 25);
            this.SecondTableLayoutPanel.Controls.Add(this.materialLabel38, 8, 26);
            this.SecondTableLayoutPanel.Controls.Add(this.operation_name_2_TextBox, 6, 25);
            this.SecondTableLayoutPanel.Controls.Add(this.operation_name_1_TextBox, 6, 26);
            this.SecondTableLayoutPanel.Controls.Add(this.tableLayoutPanel5, 3, 25);
            this.SecondTableLayoutPanel.Controls.Add(this.tableLayoutPanel6, 3, 26);
            this.SecondTableLayoutPanel.Controls.Add(this.materialLabel64, 9, 43);
            this.SecondTableLayoutPanel.Controls.Add(this.aid10_military_tableLayoutPanel, 7, 43);
            this.SecondTableLayoutPanel.Controls.Add(this.militaryPanel, 1, 44);
            this.SecondTableLayoutPanel.Controls.Add(this.panel4, 1, 47);
            this.SecondTableLayoutPanel.Controls.Add(this.materialLabel3, 10, 3);
            this.SecondTableLayoutPanel.Controls.Add(this.hasdisease_tableLayoutPanel, 8, 3);
            this.SecondTableLayoutPanel.Controls.Add(this.haswork_tableLayoutPanel, 7, 27);
            this.SecondTableLayoutPanel.Controls.Add(this.materialLabel43, 9, 27);
            this.SecondTableLayoutPanel.Controls.Add(this.panel3, 1, 28);
            this.SecondTableLayoutPanel.Controls.Add(this.WorkExp_DataGridView, 1, 29);
            this.SecondTableLayoutPanel.Controls.Add(this.has_mp_tableLayoutPanel, 7, 35);
            this.SecondTableLayoutPanel.Controls.Add(this.materialLabel51, 9, 35);
            this.SecondTableLayoutPanel.Controls.Add(this.panel9, 1, 36);
            this.SecondTableLayoutPanel.Controls.Add(this.MP_DataGridView, 1, 37);
            this.SecondTableLayoutPanel.Controls.Add(this.tableLayoutPanel8, 1, 46);
            this.SecondTableLayoutPanel.Controls.Add(this.tableLayoutPanel9, 1, 43);
            this.SecondTableLayoutPanel.Controls.Add(this.tableLayoutPanel2, 1, 10);
            this.SecondTableLayoutPanel.Controls.Add(this.IsStudent_tableLayoutPanel, 8, 48);
            this.SecondTableLayoutPanel.Controls.Add(this.materialLabel70, 10, 48);
            this.SecondTableLayoutPanel.Controls.Add(this.studentPanel, 1, 49);
            this.SecondTableLayoutPanel.Controls.Add(this.student1Panel, 1, 53);
            this.SecondTableLayoutPanel.Controls.Add(this.panel10, 1, 57);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_1_checkBox, 9, 58);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_8_checkBox, 7, 58);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_3_checkBox, 5, 58);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_4_checkBox, 3, 58);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_6_checkBox, 1, 58);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_7_checkBox, 7, 59);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_courses_TextBox, 7, 60);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_9_checkBox, 5, 59);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_10_checkBox, 3, 59);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_0_checkBox, 3, 60);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_12_checkBox, 1, 59);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_note_TextBox, 1, 60);
            this.SecondTableLayoutPanel.Controls.Add(this.panel6, 1, 62);
            this.SecondTableLayoutPanel.Controls.Add(this.materialLabel21, 10, 63);
            this.SecondTableLayoutPanel.Controls.Add(this.panel12, 1, 1);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_5_checkBox, 9, 59);
            this.SecondTableLayoutPanel.Controls.Add(this.needs_2_checkBox, 9, 60);
            this.SecondTableLayoutPanel.Controls.Add(this.PersonNote_TextBox, 1, 63);
            this.SecondTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SecondTableLayoutPanel.ForeColor = System.Drawing.Color.Black;
            this.SecondTableLayoutPanel.Location = new System.Drawing.Point(0, 1460);
            this.SecondTableLayoutPanel.Name = "SecondTableLayoutPanel";
            this.SecondTableLayoutPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SecondTableLayoutPanel.RowCount = 69;
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.SecondTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SecondTableLayoutPanel.Size = new System.Drawing.Size(1241, 2923);
            this.SecondTableLayoutPanel.TabIndex = 50;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.SecondTableLayoutPanel.SetColumnSpan(this.tableLayoutPanel10, 4);
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.Controls.Add(this.Update_Button, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(383, 2775);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.SecondTableLayoutPanel.SetRowSpan(this.tableLayoutPanel10, 2);
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(474, 78);
            this.tableLayoutPanel10.TabIndex = 126;
            // 
            // Update_Button
            // 
            this.Update_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Update_Button.BackColor = System.Drawing.Color.Transparent;
            this.Update_Button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Update_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Update_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Update_Button.FlatAppearance.BorderSize = 0;
            this.Update_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Update_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Update_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Update_Button.Location = new System.Drawing.Point(186, 18);
            this.Update_Button.MaximumSize = new System.Drawing.Size(102, 42);
            this.Update_Button.MinimumSize = new System.Drawing.Size(102, 42);
            this.Update_Button.Name = "Update_Button";
            this.Update_Button.Size = new System.Drawing.Size(102, 42);
            this.Update_Button.TabIndex = 127;
            this.Update_Button.Text = "UPDATE";
            this.Update_Button.UseVisualStyleBackColor = false;
            this.Update_Button.Click += new System.EventHandler(this.Update_Button_Click);
            this.Update_Button.MouseEnter += new System.EventHandler(this.Update_Button_MouseEnter);
            this.Update_Button.MouseLeave += new System.EventHandler(this.Update_Button_MouseLeave);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.SecondTableLayoutPanel.SetColumnSpan(this.panel7, 10);
            this.panel7.Controls.Add(this.ExpensesLable);
            this.panel7.ForeColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(23, 465);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1194, 36);
            this.panel7.TabIndex = 134;
            // 
            // ExpensesLable
            // 
            this.ExpensesLable.Depth = 0;
            this.ExpensesLable.Dock = System.Windows.Forms.DockStyle.Right;
            this.ExpensesLable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.ExpensesLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ExpensesLable.Location = new System.Drawing.Point(953, 0);
            this.ExpensesLable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.ExpensesLable.Name = "ExpensesLable";
            this.ExpensesLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ExpensesLable.Size = new System.Drawing.Size(241, 36);
            this.ExpensesLable.TabIndex = 3;
            this.ExpensesLable.Text = "المصاريف:";
            this.ExpensesLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.SecondTableLayoutPanel.SetColumnSpan(this.tableLayoutPanel3, 10);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.expensestype_24_comboBox, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.expensestype_5_comboBox, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.materialLabel161, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.materialLabel23, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.materialLabel24, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.materialLabel25, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.materialLabel26, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.materialLabel27, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.expensestype_9_comboBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.expensestype_4_comboBox, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.expenses_amount_9_TextBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.expenses_amount_4_TextBox, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.expenses_amount_5_TextBox, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.materialLabel62, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.expenses_amount_24_TextBox, 1, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(23, 549);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.SecondTableLayoutPanel.SetRowSpan(this.tableLayoutPanel3, 4);
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1194, 162);
            this.tableLayoutPanel3.TabIndex = 55;
            // 
            // expensestype_24_comboBox
            // 
            this.expensestype_24_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.expensestype_24_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.expensestype_24_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.expensestype_24_comboBox.BackColor = System.Drawing.Color.White;
            this.expensestype_24_comboBox.FormattingEnabled = true;
            this.expensestype_24_comboBox.Location = new System.Drawing.Point(4, 133);
            this.expensestype_24_comboBox.Name = "expensestype_24_comboBox";
            this.expensestype_24_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expensestype_24_comboBox.Size = new System.Drawing.Size(390, 32);
            this.expensestype_24_comboBox.TabIndex = 63;
            this.expensestype_24_comboBox.SelectionChangeCommitted += new System.EventHandler(this.expensestype_24_comboBox_SelectionChangeCommitted);
            // 
            // expensestype_5_comboBox
            // 
            this.expensestype_5_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.expensestype_5_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.expensestype_5_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.expensestype_5_comboBox.BackColor = System.Drawing.Color.White;
            this.expensestype_5_comboBox.FormattingEnabled = true;
            this.expensestype_5_comboBox.Location = new System.Drawing.Point(4, 100);
            this.expensestype_5_comboBox.Name = "expensestype_5_comboBox";
            this.expensestype_5_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expensestype_5_comboBox.Size = new System.Drawing.Size(390, 32);
            this.expensestype_5_comboBox.TabIndex = 61;
            this.expensestype_5_comboBox.SelectionChangeCommitted += new System.EventHandler(this.expensestype_5_comboBox_SelectionChangeCommitted);
            // 
            // materialLabel161
            // 
            this.materialLabel161.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel161.AutoSize = true;
            this.materialLabel161.BackColor = System.Drawing.Color.Gainsboro;
            this.materialLabel161.Depth = 0;
            this.materialLabel161.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel161.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel161.Location = new System.Drawing.Point(795, 1);
            this.materialLabel161.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel161.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel161.Name = "materialLabel161";
            this.materialLabel161.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel161.Size = new System.Drawing.Size(398, 31);
            this.materialLabel161.TabIndex = 221;
            this.materialLabel161.Text = "نوع المصروف";
            this.materialLabel161.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel23
            // 
            this.materialLabel23.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel23.AutoSize = true;
            this.materialLabel23.BackColor = System.Drawing.Color.Gainsboro;
            this.materialLabel23.Depth = 0;
            this.materialLabel23.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel23.Location = new System.Drawing.Point(398, 1);
            this.materialLabel23.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel23.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel23.Name = "materialLabel23";
            this.materialLabel23.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel23.Size = new System.Drawing.Size(396, 31);
            this.materialLabel23.TabIndex = 222;
            this.materialLabel23.Text = "قيمة المصروف";
            this.materialLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel24
            // 
            this.materialLabel24.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel24.AutoSize = true;
            this.materialLabel24.BackColor = System.Drawing.Color.Gainsboro;
            this.materialLabel24.Depth = 0;
            this.materialLabel24.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel24.Location = new System.Drawing.Point(1, 1);
            this.materialLabel24.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel24.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel24.Name = "materialLabel24";
            this.materialLabel24.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel24.Size = new System.Drawing.Size(396, 31);
            this.materialLabel24.TabIndex = 223;
            this.materialLabel24.Text = "مدة المصروف";
            this.materialLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel25
            // 
            this.materialLabel25.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel25.AutoSize = true;
            this.materialLabel25.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel25.Depth = 0;
            this.materialLabel25.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel25.Location = new System.Drawing.Point(795, 33);
            this.materialLabel25.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel25.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel25.Name = "materialLabel25";
            this.materialLabel25.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel25.Size = new System.Drawing.Size(398, 31);
            this.materialLabel25.TabIndex = 224;
            this.materialLabel25.Text = "أدوية";
            this.materialLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel26
            // 
            this.materialLabel26.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel26.AutoSize = true;
            this.materialLabel26.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel26.Depth = 0;
            this.materialLabel26.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel26.Location = new System.Drawing.Point(795, 65);
            this.materialLabel26.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel26.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel26.Name = "materialLabel26";
            this.materialLabel26.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel26.Size = new System.Drawing.Size(398, 31);
            this.materialLabel26.TabIndex = 225;
            this.materialLabel26.Text = "حفاضات";
            this.materialLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel27
            // 
            this.materialLabel27.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel27.AutoSize = true;
            this.materialLabel27.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel27.Depth = 0;
            this.materialLabel27.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel27.Location = new System.Drawing.Point(795, 97);
            this.materialLabel27.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel27.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel27.Name = "materialLabel27";
            this.materialLabel27.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel27.Size = new System.Drawing.Size(398, 31);
            this.materialLabel27.TabIndex = 226;
            this.materialLabel27.Text = "حليب";
            this.materialLabel27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expensestype_9_comboBox
            // 
            this.expensestype_9_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.expensestype_9_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.expensestype_9_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.expensestype_9_comboBox.BackColor = System.Drawing.Color.White;
            this.expensestype_9_comboBox.FormattingEnabled = true;
            this.expensestype_9_comboBox.Location = new System.Drawing.Point(4, 36);
            this.expensestype_9_comboBox.Name = "expensestype_9_comboBox";
            this.expensestype_9_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expensestype_9_comboBox.Size = new System.Drawing.Size(390, 32);
            this.expensestype_9_comboBox.TabIndex = 57;
            this.expensestype_9_comboBox.SelectionChangeCommitted += new System.EventHandler(this.expensestype_9_comboBox_SelectionChangeCommitted);
            // 
            // expensestype_4_comboBox
            // 
            this.expensestype_4_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.expensestype_4_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.expensestype_4_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.expensestype_4_comboBox.BackColor = System.Drawing.Color.White;
            this.expensestype_4_comboBox.FormattingEnabled = true;
            this.expensestype_4_comboBox.Location = new System.Drawing.Point(4, 68);
            this.expensestype_4_comboBox.Name = "expensestype_4_comboBox";
            this.expensestype_4_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expensestype_4_comboBox.Size = new System.Drawing.Size(390, 32);
            this.expensestype_4_comboBox.TabIndex = 59;
            this.expensestype_4_comboBox.SelectionChangeCommitted += new System.EventHandler(this.expensestype_4_comboBox_SelectionChangeCommitted);
            // 
            // expenses_amount_9_TextBox
            // 
            this.expenses_amount_9_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.expenses_amount_9_TextBox.Depth = 0;
            this.expenses_amount_9_TextBox.Hint = "";
            this.expenses_amount_9_TextBox.Location = new System.Drawing.Point(401, 36);
            this.expenses_amount_9_TextBox.MaxLength = 32767;
            this.expenses_amount_9_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.expenses_amount_9_TextBox.Name = "expenses_amount_9_TextBox";
            this.expenses_amount_9_TextBox.PasswordChar = '\0';
            this.expenses_amount_9_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expenses_amount_9_TextBox.SelectedText = "";
            this.expenses_amount_9_TextBox.SelectionLength = 0;
            this.expenses_amount_9_TextBox.SelectionStart = 0;
            this.expenses_amount_9_TextBox.Size = new System.Drawing.Size(390, 31);
            this.expenses_amount_9_TextBox.TabIndex = 56;
            this.expenses_amount_9_TextBox.TabStop = false;
            this.expenses_amount_9_TextBox.UseSystemPasswordChar = false;
            this.expenses_amount_9_TextBox.Enter += new System.EventHandler(this.expenses_amount_9_TextBox_Enter);
            this.expenses_amount_9_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.expenses_amount_9_TextBox_KeyPress);
            this.expenses_amount_9_TextBox.Leave += new System.EventHandler(this.expenses_amount_9_TextBox_Leave);
            // 
            // expenses_amount_4_TextBox
            // 
            this.expenses_amount_4_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.expenses_amount_4_TextBox.Depth = 0;
            this.expenses_amount_4_TextBox.Hint = "";
            this.expenses_amount_4_TextBox.Location = new System.Drawing.Point(401, 68);
            this.expenses_amount_4_TextBox.MaxLength = 32767;
            this.expenses_amount_4_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.expenses_amount_4_TextBox.Name = "expenses_amount_4_TextBox";
            this.expenses_amount_4_TextBox.PasswordChar = '\0';
            this.expenses_amount_4_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expenses_amount_4_TextBox.SelectedText = "";
            this.expenses_amount_4_TextBox.SelectionLength = 0;
            this.expenses_amount_4_TextBox.SelectionStart = 0;
            this.expenses_amount_4_TextBox.Size = new System.Drawing.Size(390, 31);
            this.expenses_amount_4_TextBox.TabIndex = 58;
            this.expenses_amount_4_TextBox.TabStop = false;
            this.expenses_amount_4_TextBox.UseSystemPasswordChar = false;
            this.expenses_amount_4_TextBox.Enter += new System.EventHandler(this.expenses_amount_4_TextBox_Enter);
            this.expenses_amount_4_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.expenses_amount_4_TextBox_KeyPress);
            this.expenses_amount_4_TextBox.Leave += new System.EventHandler(this.expenses_amount_4_TextBox_Leave);
            // 
            // expenses_amount_5_TextBox
            // 
            this.expenses_amount_5_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.expenses_amount_5_TextBox.Depth = 0;
            this.expenses_amount_5_TextBox.Hint = "";
            this.expenses_amount_5_TextBox.Location = new System.Drawing.Point(401, 100);
            this.expenses_amount_5_TextBox.MaxLength = 32767;
            this.expenses_amount_5_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.expenses_amount_5_TextBox.Name = "expenses_amount_5_TextBox";
            this.expenses_amount_5_TextBox.PasswordChar = '\0';
            this.expenses_amount_5_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expenses_amount_5_TextBox.SelectedText = "";
            this.expenses_amount_5_TextBox.SelectionLength = 0;
            this.expenses_amount_5_TextBox.SelectionStart = 0;
            this.expenses_amount_5_TextBox.Size = new System.Drawing.Size(390, 31);
            this.expenses_amount_5_TextBox.TabIndex = 60;
            this.expenses_amount_5_TextBox.TabStop = false;
            this.expenses_amount_5_TextBox.UseSystemPasswordChar = false;
            this.expenses_amount_5_TextBox.Enter += new System.EventHandler(this.expenses_amount_5_TextBox_Enter);
            this.expenses_amount_5_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.expenses_amount_5_TextBox_KeyPress);
            this.expenses_amount_5_TextBox.Leave += new System.EventHandler(this.expenses_amount_5_TextBox_Leave);
            // 
            // materialLabel62
            // 
            this.materialLabel62.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel62.AutoSize = true;
            this.materialLabel62.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel62.Depth = 0;
            this.materialLabel62.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel62.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel62.Location = new System.Drawing.Point(795, 129);
            this.materialLabel62.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel62.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel62.Name = "materialLabel62";
            this.materialLabel62.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel62.Size = new System.Drawing.Size(398, 32);
            this.materialLabel62.TabIndex = 233;
            this.materialLabel62.Text = "مقدم رعاية";
            this.materialLabel62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expenses_amount_24_TextBox
            // 
            this.expenses_amount_24_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.expenses_amount_24_TextBox.Depth = 0;
            this.expenses_amount_24_TextBox.Hint = "";
            this.expenses_amount_24_TextBox.Location = new System.Drawing.Point(401, 132);
            this.expenses_amount_24_TextBox.MaxLength = 32767;
            this.expenses_amount_24_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.expenses_amount_24_TextBox.Name = "expenses_amount_24_TextBox";
            this.expenses_amount_24_TextBox.PasswordChar = '\0';
            this.expenses_amount_24_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expenses_amount_24_TextBox.SelectedText = "";
            this.expenses_amount_24_TextBox.SelectionLength = 0;
            this.expenses_amount_24_TextBox.SelectionStart = 0;
            this.expenses_amount_24_TextBox.Size = new System.Drawing.Size(390, 31);
            this.expenses_amount_24_TextBox.TabIndex = 62;
            this.expenses_amount_24_TextBox.TabStop = false;
            this.expenses_amount_24_TextBox.UseSystemPasswordChar = false;
            this.expenses_amount_24_TextBox.Enter += new System.EventHandler(this.expenses_amount_24_TextBox_Enter);
            this.expenses_amount_24_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.expenses_amount_24_TextBox_KeyPress);
            this.expenses_amount_24_TextBox.Leave += new System.EventHandler(this.expenses_amount_24_TextBox_Leave);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.SecondTableLayoutPanel.SetColumnSpan(this.panel5, 10);
            this.panel5.Controls.Add(this.IllnessLable);
            this.panel5.ForeColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(23, 171);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1194, 36);
            this.panel5.TabIndex = 41;
            // 
            // IllnessLable
            // 
            this.IllnessLable.Depth = 0;
            this.IllnessLable.Dock = System.Windows.Forms.DockStyle.Right;
            this.IllnessLable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.IllnessLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.IllnessLable.Location = new System.Drawing.Point(953, 0);
            this.IllnessLable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.IllnessLable.Name = "IllnessLable";
            this.IllnessLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.IllnessLable.Size = new System.Drawing.Size(241, 36);
            this.IllnessLable.TabIndex = 3;
            this.IllnessLable.Text = "الحالة الصحية:";
            this.IllnessLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Disease_DataGridView
            // 
            this.Disease_DataGridView.AllowUserToDeleteRows = false;
            this.Disease_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.Disease_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Disease_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Disease_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Disease_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.Disease_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Disease_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Disease_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Disease_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Disease_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Disease_VisitName,
            this.Disease_Category,
            this.Disease,
            this.DiseaseNote,
            this.Disease_DeleteRow,
            this.Person_Disease_ID,
            this.Disease_IsDirty});
            this.SecondTableLayoutPanel.SetColumnSpan(this.Disease_DataGridView, 10);
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Disease_DataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.Disease_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Disease_DataGridView.EnableHeadersVisualStyles = false;
            this.Disease_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Disease_DataGridView.Location = new System.Drawing.Point(23, 255);
            this.Disease_DataGridView.Name = "Disease_DataGridView";
            this.Disease_DataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Disease_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Disease_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Disease_DataGridView.RowHeadersVisible = false;
            this.Disease_DataGridView.RowHeadersWidth = 51;
            this.SecondTableLayoutPanel.SetRowSpan(this.Disease_DataGridView, 4);
            this.Disease_DataGridView.RowTemplate.Height = 24;
            this.Disease_DataGridView.Size = new System.Drawing.Size(1194, 162);
            this.Disease_DataGridView.TabIndex = 54;
            this.Disease_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Disease_DataGridView_CellContentClick);
            this.Disease_DataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Disease_DataGridView_CellEndEdit);
            this.Disease_DataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.Disease_DataGridView_CellPainting);
            this.Disease_DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView_DataError);
            this.Disease_DataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridView_EditingControlShowing);
            this.Disease_DataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Disease_DataGridView_RowsAdded);
            // 
            // Disease_VisitName
            // 
            this.Disease_VisitName.HeaderText = "الزيارة";
            this.Disease_VisitName.MinimumWidth = 6;
            this.Disease_VisitName.Name = "Disease_VisitName";
            // 
            // Disease_Category
            // 
            this.Disease_Category.FillWeight = 111.9289F;
            this.Disease_Category.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Disease_Category.HeaderText = "صنف المرض";
            this.Disease_Category.MinimumWidth = 6;
            this.Disease_Category.Name = "Disease_Category";
            // 
            // Disease
            // 
            this.Disease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Disease.HeaderText = "المرض";
            this.Disease.MinimumWidth = 6;
            this.Disease.Name = "Disease";
            // 
            // DiseaseNote
            // 
            this.DiseaseNote.FillWeight = 111.9289F;
            this.DiseaseNote.HeaderText = "الوصف";
            this.DiseaseNote.MinimumWidth = 6;
            this.DiseaseNote.Name = "DiseaseNote";
            this.DiseaseNote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DiseaseNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Disease_DeleteRow
            // 
            this.Disease_DeleteRow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Disease_DeleteRow.FillWeight = 76.14214F;
            this.Disease_DeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Disease_DeleteRow.HeaderText = "";
            this.Disease_DeleteRow.MinimumWidth = 50;
            this.Disease_DeleteRow.Name = "Disease_DeleteRow";
            this.Disease_DeleteRow.Width = 50;
            // 
            // Person_Disease_ID
            // 
            this.Person_Disease_ID.HeaderText = "InDatabase";
            this.Person_Disease_ID.MinimumWidth = 6;
            this.Person_Disease_ID.Name = "Person_Disease_ID";
            this.Person_Disease_ID.Visible = false;
            // 
            // Disease_IsDirty
            // 
            this.Disease_IsDirty.HeaderText = "IsDirty";
            this.Disease_IsDirty.MinimumWidth = 6;
            this.Disease_IsDirty.Name = "Disease_IsDirty";
            this.Disease_IsDirty.Visible = false;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.SecondTableLayoutPanel.SetColumnSpan(this.panel8, 10);
            this.panel8.Controls.Add(this.AidLable);
            this.panel8.ForeColor = System.Drawing.Color.Black;
            this.panel8.Location = new System.Drawing.Point(23, 759);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1194, 36);
            this.panel8.TabIndex = 136;
            // 
            // AidLable
            // 
            this.AidLable.Depth = 0;
            this.AidLable.Dock = System.Windows.Forms.DockStyle.Right;
            this.AidLable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.AidLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AidLable.Location = new System.Drawing.Point(953, 0);
            this.AidLable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.AidLable.Name = "AidLable";
            this.AidLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AidLable.Size = new System.Drawing.Size(241, 36);
            this.AidLable.TabIndex = 3;
            this.AidLable.Text = "المساعدات:";
            this.AidLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.SecondTableLayoutPanel.SetColumnSpan(this.tableLayoutPanel4, 10);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.aidperiod_8_comboBox, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.aidperiod_13_comboBox, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.aidperiod_21_comboBox, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.aidperiod_1_comboBox, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.aid_amount_21_TextBox, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.aid_amount_1_TextBox, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.aid_amount_13_TextBox, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.materialLabel22, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.materialLabel28, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.materialLabel29, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.materialLabel33, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.materialLabel30, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.materialLabel31, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.materialLabel34, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.materialLabel35, 3, 4);
            this.tableLayoutPanel4.Controls.Add(this.materialLabel32, 3, 5);
            this.tableLayoutPanel4.Controls.Add(this.aidperiod_6_comboBox, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.aidsource_21_comboBox, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.aidsource_6_comboBox, 2, 4);
            this.tableLayoutPanel4.Controls.Add(this.aidsource_8_comboBox, 2, 5);
            this.tableLayoutPanel4.Controls.Add(this.aid_amount_6_TextBox, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.aid_amount_8_TextBox, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.aidsource_1_comboBox, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.aidsource_13_comboBox, 2, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(23, 843);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.SecondTableLayoutPanel.SetRowSpan(this.tableLayoutPanel4, 5);
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1194, 204);
            this.tableLayoutPanel4.TabIndex = 64;
            // 
            // aidperiod_8_comboBox
            // 
            this.aidperiod_8_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aidperiod_8_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.aidperiod_8_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.aidperiod_8_comboBox.BackColor = System.Drawing.Color.White;
            this.aidperiod_8_comboBox.FormattingEnabled = true;
            this.aidperiod_8_comboBox.Location = new System.Drawing.Point(4, 172);
            this.aidperiod_8_comboBox.Name = "aidperiod_8_comboBox";
            this.aidperiod_8_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidperiod_8_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidperiod_8_comboBox.TabIndex = 79;
            this.aidperiod_8_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidperiod_8_comboBox_SelectionChangeCommitted);
            // 
            // aidperiod_13_comboBox
            // 
            this.aidperiod_13_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aidperiod_13_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.aidperiod_13_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.aidperiod_13_comboBox.BackColor = System.Drawing.Color.White;
            this.aidperiod_13_comboBox.FormattingEnabled = true;
            this.aidperiod_13_comboBox.Location = new System.Drawing.Point(4, 103);
            this.aidperiod_13_comboBox.Name = "aidperiod_13_comboBox";
            this.aidperiod_13_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidperiod_13_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidperiod_13_comboBox.TabIndex = 73;
            this.aidperiod_13_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidperiod_13_comboBox_SelectionChangeCommitted);
            // 
            // aidperiod_21_comboBox
            // 
            this.aidperiod_21_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aidperiod_21_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.aidperiod_21_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.aidperiod_21_comboBox.BackColor = System.Drawing.Color.White;
            this.aidperiod_21_comboBox.FormattingEnabled = true;
            this.aidperiod_21_comboBox.Location = new System.Drawing.Point(4, 37);
            this.aidperiod_21_comboBox.Name = "aidperiod_21_comboBox";
            this.aidperiod_21_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidperiod_21_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidperiod_21_comboBox.TabIndex = 67;
            this.aidperiod_21_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidperiod_21_comboBox_SelectionChangeCommitted);
            // 
            // aidperiod_1_comboBox
            // 
            this.aidperiod_1_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aidperiod_1_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.aidperiod_1_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.aidperiod_1_comboBox.BackColor = System.Drawing.Color.White;
            this.aidperiod_1_comboBox.FormattingEnabled = true;
            this.aidperiod_1_comboBox.Location = new System.Drawing.Point(4, 70);
            this.aidperiod_1_comboBox.Name = "aidperiod_1_comboBox";
            this.aidperiod_1_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidperiod_1_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidperiod_1_comboBox.TabIndex = 70;
            this.aidperiod_1_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidperiod_1_comboBox_SelectionChangeCommitted);
            // 
            // aid_amount_21_TextBox
            // 
            this.aid_amount_21_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aid_amount_21_TextBox.Depth = 0;
            this.aid_amount_21_TextBox.Hint = "";
            this.aid_amount_21_TextBox.Location = new System.Drawing.Point(302, 37);
            this.aid_amount_21_TextBox.MaxLength = 32767;
            this.aid_amount_21_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.aid_amount_21_TextBox.Name = "aid_amount_21_TextBox";
            this.aid_amount_21_TextBox.PasswordChar = '\0';
            this.aid_amount_21_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aid_amount_21_TextBox.SelectedText = "";
            this.aid_amount_21_TextBox.SelectionLength = 0;
            this.aid_amount_21_TextBox.SelectionStart = 0;
            this.aid_amount_21_TextBox.Size = new System.Drawing.Size(291, 31);
            this.aid_amount_21_TextBox.TabIndex = 66;
            this.aid_amount_21_TextBox.TabStop = false;
            this.aid_amount_21_TextBox.UseSystemPasswordChar = false;
            this.aid_amount_21_TextBox.Enter += new System.EventHandler(this.aid_amount_21_TextBox_Enter);
            this.aid_amount_21_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aid_amount_21_TextBox_KeyPress);
            this.aid_amount_21_TextBox.Leave += new System.EventHandler(this.aid_amount_21_TextBox_Leave);
            // 
            // aid_amount_1_TextBox
            // 
            this.aid_amount_1_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aid_amount_1_TextBox.Depth = 0;
            this.aid_amount_1_TextBox.Hint = "";
            this.aid_amount_1_TextBox.Location = new System.Drawing.Point(302, 70);
            this.aid_amount_1_TextBox.MaxLength = 32767;
            this.aid_amount_1_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.aid_amount_1_TextBox.Name = "aid_amount_1_TextBox";
            this.aid_amount_1_TextBox.PasswordChar = '\0';
            this.aid_amount_1_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aid_amount_1_TextBox.SelectedText = "";
            this.aid_amount_1_TextBox.SelectionLength = 0;
            this.aid_amount_1_TextBox.SelectionStart = 0;
            this.aid_amount_1_TextBox.Size = new System.Drawing.Size(291, 31);
            this.aid_amount_1_TextBox.TabIndex = 69;
            this.aid_amount_1_TextBox.TabStop = false;
            this.aid_amount_1_TextBox.UseSystemPasswordChar = false;
            this.aid_amount_1_TextBox.Enter += new System.EventHandler(this.aid_amount_1_TextBox_Enter);
            this.aid_amount_1_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aid_amount_1_TextBox_KeyPress);
            this.aid_amount_1_TextBox.Leave += new System.EventHandler(this.aid_amount_1_TextBox_Leave);
            // 
            // aid_amount_13_TextBox
            // 
            this.aid_amount_13_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aid_amount_13_TextBox.Depth = 0;
            this.aid_amount_13_TextBox.Hint = "";
            this.aid_amount_13_TextBox.Location = new System.Drawing.Point(302, 103);
            this.aid_amount_13_TextBox.MaxLength = 32767;
            this.aid_amount_13_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.aid_amount_13_TextBox.Name = "aid_amount_13_TextBox";
            this.aid_amount_13_TextBox.PasswordChar = '\0';
            this.aid_amount_13_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aid_amount_13_TextBox.SelectedText = "";
            this.aid_amount_13_TextBox.SelectionLength = 0;
            this.aid_amount_13_TextBox.SelectionStart = 0;
            this.aid_amount_13_TextBox.Size = new System.Drawing.Size(291, 31);
            this.aid_amount_13_TextBox.TabIndex = 72;
            this.aid_amount_13_TextBox.TabStop = false;
            this.aid_amount_13_TextBox.UseSystemPasswordChar = false;
            this.aid_amount_13_TextBox.Enter += new System.EventHandler(this.aid_amount_13_TextBox_Enter);
            this.aid_amount_13_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aid_amount_13_TextBox_KeyPress);
            this.aid_amount_13_TextBox.Leave += new System.EventHandler(this.aid_amount_13_TextBox_Leave);
            // 
            // materialLabel22
            // 
            this.materialLabel22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel22.AutoSize = true;
            this.materialLabel22.BackColor = System.Drawing.Color.Gainsboro;
            this.materialLabel22.Depth = 0;
            this.materialLabel22.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel22.Location = new System.Drawing.Point(895, 1);
            this.materialLabel22.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel22.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel22.Name = "materialLabel22";
            this.materialLabel22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel22.Size = new System.Drawing.Size(298, 32);
            this.materialLabel22.TabIndex = 221;
            this.materialLabel22.Text = "المساعدة";
            this.materialLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel28
            // 
            this.materialLabel28.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel28.AutoSize = true;
            this.materialLabel28.BackColor = System.Drawing.Color.Gainsboro;
            this.materialLabel28.Depth = 0;
            this.materialLabel28.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel28.Location = new System.Drawing.Point(597, 1);
            this.materialLabel28.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel28.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel28.Name = "materialLabel28";
            this.materialLabel28.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel28.Size = new System.Drawing.Size(297, 32);
            this.materialLabel28.TabIndex = 222;
            this.materialLabel28.Text = "الجهة الداعمة";
            this.materialLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel29
            // 
            this.materialLabel29.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel29.AutoSize = true;
            this.materialLabel29.BackColor = System.Drawing.Color.Gainsboro;
            this.materialLabel29.Depth = 0;
            this.materialLabel29.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel29.Location = new System.Drawing.Point(299, 1);
            this.materialLabel29.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel29.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel29.Name = "materialLabel29";
            this.materialLabel29.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel29.Size = new System.Drawing.Size(297, 32);
            this.materialLabel29.TabIndex = 223;
            this.materialLabel29.Text = "قيمة المساعدة";
            this.materialLabel29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel33
            // 
            this.materialLabel33.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel33.AutoSize = true;
            this.materialLabel33.BackColor = System.Drawing.Color.Gainsboro;
            this.materialLabel33.Depth = 0;
            this.materialLabel33.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel33.Location = new System.Drawing.Point(1, 1);
            this.materialLabel33.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel33.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel33.Name = "materialLabel33";
            this.materialLabel33.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel33.Size = new System.Drawing.Size(297, 32);
            this.materialLabel33.TabIndex = 233;
            this.materialLabel33.Text = "عدد مرات المساعدة";
            this.materialLabel33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel30
            // 
            this.materialLabel30.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel30.AutoSize = true;
            this.materialLabel30.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel30.Depth = 0;
            this.materialLabel30.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel30.Location = new System.Drawing.Point(895, 34);
            this.materialLabel30.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel30.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel30.Name = "materialLabel30";
            this.materialLabel30.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel30.Size = new System.Drawing.Size(298, 32);
            this.materialLabel30.TabIndex = 224;
            this.materialLabel30.Text = "علب أدوية";
            this.materialLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel31
            // 
            this.materialLabel31.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel31.AutoSize = true;
            this.materialLabel31.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel31.Depth = 0;
            this.materialLabel31.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel31.Location = new System.Drawing.Point(895, 67);
            this.materialLabel31.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel31.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel31.Name = "materialLabel31";
            this.materialLabel31.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel31.Size = new System.Drawing.Size(298, 32);
            this.materialLabel31.TabIndex = 225;
            this.materialLabel31.Text = "قيمة الأدوية";
            this.materialLabel31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel34
            // 
            this.materialLabel34.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel34.AutoSize = true;
            this.materialLabel34.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel34.Depth = 0;
            this.materialLabel34.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel34.Location = new System.Drawing.Point(895, 100);
            this.materialLabel34.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel34.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel34.Name = "materialLabel34";
            this.materialLabel34.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel34.Size = new System.Drawing.Size(298, 32);
            this.materialLabel34.TabIndex = 234;
            this.materialLabel34.Text = "عمليات";
            this.materialLabel34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel35
            // 
            this.materialLabel35.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel35.AutoSize = true;
            this.materialLabel35.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel35.Depth = 0;
            this.materialLabel35.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel35.Location = new System.Drawing.Point(895, 133);
            this.materialLabel35.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel35.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel35.Name = "materialLabel35";
            this.materialLabel35.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel35.Size = new System.Drawing.Size(298, 32);
            this.materialLabel35.TabIndex = 235;
            this.materialLabel35.Text = "حفاضات";
            this.materialLabel35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel32
            // 
            this.materialLabel32.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel32.AutoSize = true;
            this.materialLabel32.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel32.Depth = 0;
            this.materialLabel32.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel32.Location = new System.Drawing.Point(895, 166);
            this.materialLabel32.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel32.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel32.Name = "materialLabel32";
            this.materialLabel32.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel32.Size = new System.Drawing.Size(298, 37);
            this.materialLabel32.TabIndex = 226;
            this.materialLabel32.Text = "حليب";
            this.materialLabel32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aidperiod_6_comboBox
            // 
            this.aidperiod_6_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aidperiod_6_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.aidperiod_6_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.aidperiod_6_comboBox.BackColor = System.Drawing.Color.White;
            this.aidperiod_6_comboBox.FormattingEnabled = true;
            this.aidperiod_6_comboBox.Location = new System.Drawing.Point(4, 136);
            this.aidperiod_6_comboBox.Name = "aidperiod_6_comboBox";
            this.aidperiod_6_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidperiod_6_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidperiod_6_comboBox.TabIndex = 76;
            this.aidperiod_6_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidperiod_6_comboBox_SelectionChangeCommitted);
            // 
            // aidsource_21_comboBox
            // 
            this.aidsource_21_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aidsource_21_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.aidsource_21_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.aidsource_21_comboBox.BackColor = System.Drawing.Color.White;
            this.aidsource_21_comboBox.FormattingEnabled = true;
            this.aidsource_21_comboBox.Location = new System.Drawing.Point(600, 37);
            this.aidsource_21_comboBox.Name = "aidsource_21_comboBox";
            this.aidsource_21_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidsource_21_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidsource_21_comboBox.TabIndex = 65;
            this.aidsource_21_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidsource_21_comboBox_SelectionChangeCommitted);
            // 
            // aidsource_6_comboBox
            // 
            this.aidsource_6_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aidsource_6_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.aidsource_6_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.aidsource_6_comboBox.BackColor = System.Drawing.Color.White;
            this.aidsource_6_comboBox.FormattingEnabled = true;
            this.aidsource_6_comboBox.Location = new System.Drawing.Point(600, 136);
            this.aidsource_6_comboBox.Name = "aidsource_6_comboBox";
            this.aidsource_6_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidsource_6_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidsource_6_comboBox.TabIndex = 74;
            this.aidsource_6_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidsource_6_comboBox_SelectionChangeCommitted);
            // 
            // aidsource_8_comboBox
            // 
            this.aidsource_8_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aidsource_8_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.aidsource_8_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.aidsource_8_comboBox.BackColor = System.Drawing.Color.White;
            this.aidsource_8_comboBox.FormattingEnabled = true;
            this.aidsource_8_comboBox.Location = new System.Drawing.Point(600, 172);
            this.aidsource_8_comboBox.Name = "aidsource_8_comboBox";
            this.aidsource_8_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidsource_8_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidsource_8_comboBox.TabIndex = 77;
            this.aidsource_8_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidsource_8_comboBox_SelectionChangeCommitted);
            // 
            // aid_amount_6_TextBox
            // 
            this.aid_amount_6_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aid_amount_6_TextBox.Depth = 0;
            this.aid_amount_6_TextBox.Hint = "";
            this.aid_amount_6_TextBox.Location = new System.Drawing.Point(302, 136);
            this.aid_amount_6_TextBox.MaxLength = 32767;
            this.aid_amount_6_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.aid_amount_6_TextBox.Name = "aid_amount_6_TextBox";
            this.aid_amount_6_TextBox.PasswordChar = '\0';
            this.aid_amount_6_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aid_amount_6_TextBox.SelectedText = "";
            this.aid_amount_6_TextBox.SelectionLength = 0;
            this.aid_amount_6_TextBox.SelectionStart = 0;
            this.aid_amount_6_TextBox.Size = new System.Drawing.Size(291, 31);
            this.aid_amount_6_TextBox.TabIndex = 75;
            this.aid_amount_6_TextBox.TabStop = false;
            this.aid_amount_6_TextBox.UseSystemPasswordChar = false;
            this.aid_amount_6_TextBox.Enter += new System.EventHandler(this.aid_amount_6_TextBox_Enter);
            this.aid_amount_6_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aid_amount_6_TextBox_KeyPress);
            this.aid_amount_6_TextBox.Leave += new System.EventHandler(this.aid_amount_6_TextBox_Leave);
            // 
            // aid_amount_8_TextBox
            // 
            this.aid_amount_8_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aid_amount_8_TextBox.Depth = 0;
            this.aid_amount_8_TextBox.Hint = "";
            this.aid_amount_8_TextBox.Location = new System.Drawing.Point(302, 169);
            this.aid_amount_8_TextBox.MaxLength = 32767;
            this.aid_amount_8_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.aid_amount_8_TextBox.Name = "aid_amount_8_TextBox";
            this.aid_amount_8_TextBox.PasswordChar = '\0';
            this.aid_amount_8_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aid_amount_8_TextBox.SelectedText = "";
            this.aid_amount_8_TextBox.SelectionLength = 0;
            this.aid_amount_8_TextBox.SelectionStart = 0;
            this.aid_amount_8_TextBox.Size = new System.Drawing.Size(291, 31);
            this.aid_amount_8_TextBox.TabIndex = 78;
            this.aid_amount_8_TextBox.TabStop = false;
            this.aid_amount_8_TextBox.UseSystemPasswordChar = false;
            this.aid_amount_8_TextBox.Enter += new System.EventHandler(this.aid_amount_8_TextBox_Enter);
            this.aid_amount_8_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aid_amount_8_TextBox_KeyPress);
            this.aid_amount_8_TextBox.Leave += new System.EventHandler(this.aid_amount_8_TextBox_Leave);
            // 
            // aidsource_1_comboBox
            // 
            this.aidsource_1_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aidsource_1_comboBox.FormattingEnabled = true;
            this.aidsource_1_comboBox.Location = new System.Drawing.Point(600, 70);
            this.aidsource_1_comboBox.Name = "aidsource_1_comboBox";
            this.aidsource_1_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidsource_1_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidsource_1_comboBox.TabIndex = 68;
            this.aidsource_1_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidsource_1_comboBox_SelectionChangeCommitted);
            // 
            // aidsource_13_comboBox
            // 
            this.aidsource_13_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aidsource_13_comboBox.FormattingEnabled = true;
            this.aidsource_13_comboBox.Location = new System.Drawing.Point(600, 103);
            this.aidsource_13_comboBox.Name = "aidsource_13_comboBox";
            this.aidsource_13_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidsource_13_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidsource_13_comboBox.TabIndex = 71;
            this.aidsource_13_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidsource_13_comboBox_SelectionChangeCommitted);
            // 
            // materialLabel36
            // 
            this.materialLabel36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel36.AutoSize = true;
            this.SecondTableLayoutPanel.SetColumnSpan(this.materialLabel36, 2);
            this.materialLabel36.Depth = 0;
            this.materialLabel36.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel36.Location = new System.Drawing.Point(983, 1058);
            this.materialLabel36.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel36.Name = "materialLabel36";
            this.materialLabel36.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel36.Size = new System.Drawing.Size(234, 26);
            this.materialLabel36.TabIndex = 133;
            this.materialLabel36.Text = "هل بحاجة عملية؟";
            // 
            // materialLabel37
            // 
            this.materialLabel37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel37.AutoSize = true;
            this.SecondTableLayoutPanel.SetColumnSpan(this.materialLabel37, 2);
            this.materialLabel37.Depth = 0;
            this.materialLabel37.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel37.Location = new System.Drawing.Point(983, 1100);
            this.materialLabel37.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel37.Name = "materialLabel37";
            this.materialLabel37.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel37.Size = new System.Drawing.Size(234, 26);
            this.materialLabel37.TabIndex = 134;
            this.materialLabel37.Text = "هل بحاجة مستلزمات طبية؟";
            // 
            // materialLabel39
            // 
            this.materialLabel39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel39.AutoSize = true;
            this.materialLabel39.Depth = 0;
            this.materialLabel39.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel39.Location = new System.Drawing.Point(863, 1050);
            this.materialLabel39.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel39.Name = "materialLabel39";
            this.materialLabel39.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel39.Size = new System.Drawing.Size(114, 42);
            this.materialLabel39.TabIndex = 25;
            this.materialLabel39.Text = "وصف الحاجة:";
            // 
            // materialLabel38
            // 
            this.materialLabel38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel38.AutoSize = true;
            this.materialLabel38.Depth = 0;
            this.materialLabel38.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel38.Location = new System.Drawing.Point(863, 1092);
            this.materialLabel38.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel38.Name = "materialLabel38";
            this.materialLabel38.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel38.Size = new System.Drawing.Size(114, 42);
            this.materialLabel38.TabIndex = 137;
            this.materialLabel38.Text = "وصف الحاجة:";
            // 
            // operation_name_2_TextBox
            // 
            this.operation_name_2_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondTableLayoutPanel.SetColumnSpan(this.operation_name_2_TextBox, 2);
            this.operation_name_2_TextBox.Depth = 0;
            this.operation_name_2_TextBox.Hint = "";
            this.operation_name_2_TextBox.Location = new System.Drawing.Point(625, 1055);
            this.operation_name_2_TextBox.MaxLength = 32767;
            this.operation_name_2_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.operation_name_2_TextBox.Name = "operation_name_2_TextBox";
            this.operation_name_2_TextBox.PasswordChar = '\0';
            this.operation_name_2_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.operation_name_2_TextBox.SelectedText = "";
            this.operation_name_2_TextBox.SelectionLength = 0;
            this.operation_name_2_TextBox.SelectionStart = 0;
            this.operation_name_2_TextBox.Size = new System.Drawing.Size(232, 31);
            this.operation_name_2_TextBox.TabIndex = 80;
            this.operation_name_2_TextBox.TabStop = false;
            this.operation_name_2_TextBox.UseSystemPasswordChar = false;
            this.operation_name_2_TextBox.Enter += new System.EventHandler(this.operation_name_2_TextBox_Enter);
            this.operation_name_2_TextBox.Leave += new System.EventHandler(this.operation_name_2_TextBox_Leave);
            // 
            // operation_name_1_TextBox
            // 
            this.operation_name_1_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondTableLayoutPanel.SetColumnSpan(this.operation_name_1_TextBox, 2);
            this.operation_name_1_TextBox.Depth = 0;
            this.operation_name_1_TextBox.Hint = "";
            this.operation_name_1_TextBox.Location = new System.Drawing.Point(625, 1097);
            this.operation_name_1_TextBox.MaxLength = 32767;
            this.operation_name_1_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.operation_name_1_TextBox.Name = "operation_name_1_TextBox";
            this.operation_name_1_TextBox.PasswordChar = '\0';
            this.operation_name_1_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.operation_name_1_TextBox.SelectedText = "";
            this.operation_name_1_TextBox.SelectionLength = 0;
            this.operation_name_1_TextBox.SelectionStart = 0;
            this.operation_name_1_TextBox.Size = new System.Drawing.Size(232, 31);
            this.operation_name_1_TextBox.TabIndex = 82;
            this.operation_name_1_TextBox.TabStop = false;
            this.operation_name_1_TextBox.UseSystemPasswordChar = false;
            this.operation_name_1_TextBox.Enter += new System.EventHandler(this.operation_name_1_TextBox_Enter);
            this.operation_name_1_TextBox.Leave += new System.EventHandler(this.operation_name_1_TextBox_Leave);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.SecondTableLayoutPanel.SetColumnSpan(this.tableLayoutPanel5, 3);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.98916F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.31165F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.97019F));
            this.tableLayoutPanel5.Controls.Add(this.materialLabel41, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.operation_value_2_TextBox, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(263, 1053);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(356, 36);
            this.tableLayoutPanel5.TabIndex = 81;
            // 
            // materialLabel41
            // 
            this.materialLabel41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel41.AutoSize = true;
            this.materialLabel41.Depth = 0;
            this.materialLabel41.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel41.Location = new System.Drawing.Point(290, 0);
            this.materialLabel41.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel41.Name = "materialLabel41";
            this.materialLabel41.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel41.Size = new System.Drawing.Size(63, 36);
            this.materialLabel41.TabIndex = 80;
            this.materialLabel41.Text = "القيمة:";
            // 
            // operation_value_2_TextBox
            // 
            this.operation_value_2_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.operation_value_2_TextBox.Depth = 0;
            this.operation_value_2_TextBox.Hint = "";
            this.operation_value_2_TextBox.Location = new System.Drawing.Point(59, 3);
            this.operation_value_2_TextBox.MaxLength = 32767;
            this.operation_value_2_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.operation_value_2_TextBox.Name = "operation_value_2_TextBox";
            this.operation_value_2_TextBox.PasswordChar = '\0';
            this.operation_value_2_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.operation_value_2_TextBox.SelectedText = "";
            this.operation_value_2_TextBox.SelectionLength = 0;
            this.operation_value_2_TextBox.SelectionStart = 0;
            this.operation_value_2_TextBox.Size = new System.Drawing.Size(225, 31);
            this.operation_value_2_TextBox.TabIndex = 81;
            this.operation_value_2_TextBox.TabStop = false;
            this.operation_value_2_TextBox.UseSystemPasswordChar = false;
            this.operation_value_2_TextBox.Enter += new System.EventHandler(this.operation_value_2_TextBox_Enter);
            this.operation_value_2_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.operation_value_2_TextBox_KeyPress);
            this.operation_value_2_TextBox.Leave += new System.EventHandler(this.operation_value_2_TextBox_Leave);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.SecondTableLayoutPanel.SetColumnSpan(this.tableLayoutPanel6, 3);
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.98916F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.04065F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.24119F));
            this.tableLayoutPanel6.Controls.Add(this.materialLabel1, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.operation_value_1_TextBox, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(263, 1095);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(356, 36);
            this.tableLayoutPanel6.TabIndex = 83;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(289, 0);
            this.materialLabel1.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel1.Size = new System.Drawing.Size(64, 36);
            this.materialLabel1.TabIndex = 80;
            this.materialLabel1.Text = "القيمة:";
            // 
            // operation_value_1_TextBox
            // 
            this.operation_value_1_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.operation_value_1_TextBox.Depth = 0;
            this.operation_value_1_TextBox.Hint = "";
            this.operation_value_1_TextBox.Location = new System.Drawing.Point(59, 3);
            this.operation_value_1_TextBox.MaxLength = 32767;
            this.operation_value_1_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.operation_value_1_TextBox.Name = "operation_value_1_TextBox";
            this.operation_value_1_TextBox.PasswordChar = '\0';
            this.operation_value_1_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.operation_value_1_TextBox.SelectedText = "";
            this.operation_value_1_TextBox.SelectionLength = 0;
            this.operation_value_1_TextBox.SelectionStart = 0;
            this.operation_value_1_TextBox.Size = new System.Drawing.Size(224, 31);
            this.operation_value_1_TextBox.TabIndex = 83;
            this.operation_value_1_TextBox.TabStop = false;
            this.operation_value_1_TextBox.UseSystemPasswordChar = false;
            this.operation_value_1_TextBox.Enter += new System.EventHandler(this.operation_value_1_TextBox_Enter);
            this.operation_value_1_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.operation_value_1_TextBox_KeyPress);
            this.operation_value_1_TextBox.Leave += new System.EventHandler(this.operation_value_1_TextBox_Leave);
            // 
            // materialLabel64
            // 
            this.materialLabel64.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel64.AutoSize = true;
            this.SecondTableLayoutPanel.SetColumnSpan(this.materialLabel64, 2);
            this.materialLabel64.Depth = 0;
            this.materialLabel64.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel64.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel64.Location = new System.Drawing.Point(983, 1806);
            this.materialLabel64.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel64.Name = "materialLabel64";
            this.materialLabel64.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel64.Size = new System.Drawing.Size(234, 42);
            this.materialLabel64.TabIndex = 249;
            this.materialLabel64.Text = "هل تمت المساعدة ببدل عسكرية؟";
            // 
            // aid10_military_tableLayoutPanel
            // 
            this.aid10_military_tableLayoutPanel.ColumnCount = 2;
            this.SecondTableLayoutPanel.SetColumnSpan(this.aid10_military_tableLayoutPanel, 2);
            this.aid10_military_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.aid10_military_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.aid10_military_tableLayoutPanel.Controls.Add(this.aid_No_10_RadioButton, 0, 0);
            this.aid10_military_tableLayoutPanel.Controls.Add(this.aid_Yes_10_RadioButton, 1, 0);
            this.aid10_military_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aid10_military_tableLayoutPanel.Location = new System.Drawing.Point(743, 1809);
            this.aid10_military_tableLayoutPanel.Name = "aid10_military_tableLayoutPanel";
            this.aid10_military_tableLayoutPanel.RowCount = 1;
            this.aid10_military_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.aid10_military_tableLayoutPanel.Size = new System.Drawing.Size(234, 36);
            this.aid10_military_tableLayoutPanel.TabIndex = 92;
            // 
            // aid_No_10_RadioButton
            // 
            this.aid_No_10_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.aid_No_10_RadioButton.AutoSize = true;
            this.aid_No_10_RadioButton.Depth = 0;
            this.aid_No_10_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.aid_No_10_RadioButton.Location = new System.Drawing.Point(75, 3);
            this.aid_No_10_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.aid_No_10_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.aid_No_10_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.aid_No_10_RadioButton.Name = "aid_No_10_RadioButton";
            this.aid_No_10_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aid_No_10_RadioButton.Ripple = true;
            this.aid_No_10_RadioButton.Size = new System.Drawing.Size(42, 30);
            this.aid_No_10_RadioButton.TabIndex = 94;
            this.aid_No_10_RadioButton.TabStop = true;
            this.aid_No_10_RadioButton.Text = "لا";
            this.aid_No_10_RadioButton.UseVisualStyleBackColor = true;
            this.aid_No_10_RadioButton.CheckedChanged += new System.EventHandler(this.aid_No_10_RadioButton_CheckedChanged);
            // 
            // aid_Yes_10_RadioButton
            // 
            this.aid_Yes_10_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.aid_Yes_10_RadioButton.AutoSize = true;
            this.aid_Yes_10_RadioButton.Depth = 0;
            this.aid_Yes_10_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.aid_Yes_10_RadioButton.Location = new System.Drawing.Point(173, 3);
            this.aid_Yes_10_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.aid_Yes_10_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.aid_Yes_10_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.aid_Yes_10_RadioButton.Name = "aid_Yes_10_RadioButton";
            this.aid_Yes_10_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aid_Yes_10_RadioButton.Ripple = true;
            this.aid_Yes_10_RadioButton.Size = new System.Drawing.Size(61, 30);
            this.aid_Yes_10_RadioButton.TabIndex = 93;
            this.aid_Yes_10_RadioButton.TabStop = true;
            this.aid_Yes_10_RadioButton.Text = "نعم";
            this.aid_Yes_10_RadioButton.UseVisualStyleBackColor = true;
            this.aid_Yes_10_RadioButton.CheckedChanged += new System.EventHandler(this.aid_Yes_10_RadioButton_CheckedChanged);
            // 
            // militaryPanel
            // 
            this.militaryPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.militaryPanel.ColumnCount = 3;
            this.SecondTableLayoutPanel.SetColumnSpan(this.militaryPanel, 10);
            this.militaryPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.militaryPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.militaryPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.militaryPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.militaryPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.militaryPanel.Controls.Add(this.materialLabel65, 2, 0);
            this.militaryPanel.Controls.Add(this.materialLabel67, 1, 0);
            this.militaryPanel.Controls.Add(this.materialLabel66, 0, 0);
            this.militaryPanel.Controls.Add(this.aid_amount_10_TextBox, 1, 1);
            this.militaryPanel.Controls.Add(this.aidsource_10_comboBox, 2, 1);
            this.militaryPanel.Controls.Add(this.aidperiod_10_comboBox, 0, 1);
            this.militaryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.militaryPanel.Location = new System.Drawing.Point(23, 1851);
            this.militaryPanel.Name = "militaryPanel";
            this.militaryPanel.RowCount = 2;
            this.SecondTableLayoutPanel.SetRowSpan(this.militaryPanel, 2);
            this.militaryPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.militaryPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.militaryPanel.Size = new System.Drawing.Size(1194, 78);
            this.militaryPanel.TabIndex = 95;
            // 
            // materialLabel65
            // 
            this.materialLabel65.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel65.AutoSize = true;
            this.materialLabel65.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel65.Depth = 0;
            this.materialLabel65.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel65.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel65.Location = new System.Drawing.Point(795, 1);
            this.materialLabel65.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel65.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel65.Name = "materialLabel65";
            this.materialLabel65.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel65.Size = new System.Drawing.Size(398, 37);
            this.materialLabel65.TabIndex = 125;
            this.materialLabel65.Text = "الجهة الداعمة";
            this.materialLabel65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel67
            // 
            this.materialLabel67.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel67.AutoSize = true;
            this.materialLabel67.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel67.Depth = 0;
            this.materialLabel67.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel67.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel67.Location = new System.Drawing.Point(398, 1);
            this.materialLabel67.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel67.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel67.Name = "materialLabel67";
            this.materialLabel67.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel67.Size = new System.Drawing.Size(396, 37);
            this.materialLabel67.TabIndex = 127;
            this.materialLabel67.Text = "قيمة المساعدة";
            this.materialLabel67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel66
            // 
            this.materialLabel66.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel66.AutoSize = true;
            this.materialLabel66.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel66.Depth = 0;
            this.materialLabel66.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel66.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel66.Location = new System.Drawing.Point(1, 1);
            this.materialLabel66.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel66.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel66.Name = "materialLabel66";
            this.materialLabel66.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel66.Size = new System.Drawing.Size(396, 37);
            this.materialLabel66.TabIndex = 126;
            this.materialLabel66.Text = "مدة المساعدة";
            this.materialLabel66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aid_amount_10_TextBox
            // 
            this.aid_amount_10_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.aid_amount_10_TextBox.Depth = 0;
            this.aid_amount_10_TextBox.Hint = "";
            this.aid_amount_10_TextBox.Location = new System.Drawing.Point(401, 42);
            this.aid_amount_10_TextBox.MaxLength = 32767;
            this.aid_amount_10_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.aid_amount_10_TextBox.Name = "aid_amount_10_TextBox";
            this.aid_amount_10_TextBox.PasswordChar = '\0';
            this.aid_amount_10_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aid_amount_10_TextBox.SelectedText = "";
            this.aid_amount_10_TextBox.SelectionLength = 0;
            this.aid_amount_10_TextBox.SelectionStart = 0;
            this.aid_amount_10_TextBox.Size = new System.Drawing.Size(390, 31);
            this.aid_amount_10_TextBox.TabIndex = 97;
            this.aid_amount_10_TextBox.TabStop = false;
            this.aid_amount_10_TextBox.UseSystemPasswordChar = false;
            this.aid_amount_10_TextBox.Enter += new System.EventHandler(this.aid_amount_10_TextBox_Enter);
            this.aid_amount_10_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aid_amount_10_TextBox_KeyPress);
            this.aid_amount_10_TextBox.Leave += new System.EventHandler(this.aid_amount_10_TextBox_Leave);
            // 
            // aidsource_10_comboBox
            // 
            this.aidsource_10_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aidsource_10_comboBox.FormattingEnabled = true;
            this.aidsource_10_comboBox.Location = new System.Drawing.Point(798, 42);
            this.aidsource_10_comboBox.Name = "aidsource_10_comboBox";
            this.aidsource_10_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidsource_10_comboBox.Size = new System.Drawing.Size(392, 32);
            this.aidsource_10_comboBox.TabIndex = 96;
            this.aidsource_10_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidsource_10_comboBox_SelectionChangeCommitted);
            // 
            // aidperiod_10_comboBox
            // 
            this.aidperiod_10_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aidperiod_10_comboBox.FormattingEnabled = true;
            this.aidperiod_10_comboBox.Location = new System.Drawing.Point(4, 42);
            this.aidperiod_10_comboBox.Name = "aidperiod_10_comboBox";
            this.aidperiod_10_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidperiod_10_comboBox.Size = new System.Drawing.Size(390, 32);
            this.aidperiod_10_comboBox.TabIndex = 98;
            this.aidperiod_10_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidperiod_10_comboBox_SelectionChangeCommitted);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.SecondTableLayoutPanel.SetColumnSpan(this.panel4, 10);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.StudyLable);
            this.panel4.Location = new System.Drawing.Point(23, 1977);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1194, 36);
            this.panel4.TabIndex = 30;
            // 
            // StudyLable
            // 
            this.StudyLable.Depth = 0;
            this.StudyLable.Dock = System.Windows.Forms.DockStyle.Right;
            this.StudyLable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.StudyLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StudyLable.Location = new System.Drawing.Point(1123, 0);
            this.StudyLable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.StudyLable.Name = "StudyLable";
            this.StudyLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StudyLable.Size = new System.Drawing.Size(71, 36);
            this.StudyLable.TabIndex = 2;
            this.StudyLable.Text = "التعليم";
            this.StudyLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(1103, 126);
            this.materialLabel3.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel3.Size = new System.Drawing.Size(81, 42);
            this.materialLabel3.TabIndex = 133;
            this.materialLabel3.Text = "هل لديك أمراض؟";
            // 
            // hasdisease_tableLayoutPanel
            // 
            this.hasdisease_tableLayoutPanel.ColumnCount = 2;
            this.SecondTableLayoutPanel.SetColumnSpan(this.hasdisease_tableLayoutPanel, 2);
            this.hasdisease_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hasdisease_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hasdisease_tableLayoutPanel.Controls.Add(this.hasdisease_Yes_RadioButton, 1, 0);
            this.hasdisease_tableLayoutPanel.Controls.Add(this.hasdisease_No_RadioButton, 0, 0);
            this.hasdisease_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hasdisease_tableLayoutPanel.Location = new System.Drawing.Point(863, 129);
            this.hasdisease_tableLayoutPanel.Name = "hasdisease_tableLayoutPanel";
            this.hasdisease_tableLayoutPanel.RowCount = 1;
            this.hasdisease_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hasdisease_tableLayoutPanel.Size = new System.Drawing.Size(234, 36);
            this.hasdisease_tableLayoutPanel.TabIndex = 51;
            // 
            // hasdisease_Yes_RadioButton
            // 
            this.hasdisease_Yes_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.hasdisease_Yes_RadioButton.AutoSize = true;
            this.hasdisease_Yes_RadioButton.Depth = 0;
            this.hasdisease_Yes_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.hasdisease_Yes_RadioButton.Location = new System.Drawing.Point(173, 3);
            this.hasdisease_Yes_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.hasdisease_Yes_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.hasdisease_Yes_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.hasdisease_Yes_RadioButton.Name = "hasdisease_Yes_RadioButton";
            this.hasdisease_Yes_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.hasdisease_Yes_RadioButton.Ripple = true;
            this.hasdisease_Yes_RadioButton.Size = new System.Drawing.Size(61, 30);
            this.hasdisease_Yes_RadioButton.TabIndex = 52;
            this.hasdisease_Yes_RadioButton.TabStop = true;
            this.hasdisease_Yes_RadioButton.Text = "نعم";
            this.hasdisease_Yes_RadioButton.UseVisualStyleBackColor = true;
            this.hasdisease_Yes_RadioButton.CheckedChanged += new System.EventHandler(this.hasdisease_Yes_RadioButton_CheckedChanged);
            // 
            // hasdisease_No_RadioButton
            // 
            this.hasdisease_No_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.hasdisease_No_RadioButton.AutoSize = true;
            this.hasdisease_No_RadioButton.Depth = 0;
            this.hasdisease_No_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.hasdisease_No_RadioButton.Location = new System.Drawing.Point(75, 3);
            this.hasdisease_No_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.hasdisease_No_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.hasdisease_No_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.hasdisease_No_RadioButton.Name = "hasdisease_No_RadioButton";
            this.hasdisease_No_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.hasdisease_No_RadioButton.Ripple = true;
            this.hasdisease_No_RadioButton.Size = new System.Drawing.Size(42, 30);
            this.hasdisease_No_RadioButton.TabIndex = 53;
            this.hasdisease_No_RadioButton.TabStop = true;
            this.hasdisease_No_RadioButton.Text = "لا";
            this.hasdisease_No_RadioButton.UseVisualStyleBackColor = true;
            this.hasdisease_No_RadioButton.CheckedChanged += new System.EventHandler(this.hasdisease_No_RadioButton_CheckedChanged);
            // 
            // haswork_tableLayoutPanel
            // 
            this.haswork_tableLayoutPanel.ColumnCount = 2;
            this.SecondTableLayoutPanel.SetColumnSpan(this.haswork_tableLayoutPanel, 2);
            this.haswork_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.haswork_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.haswork_tableLayoutPanel.Controls.Add(this.haswork_No_RadioButton, 0, 0);
            this.haswork_tableLayoutPanel.Controls.Add(this.haswork_Yes_RadioButton, 1, 0);
            this.haswork_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.haswork_tableLayoutPanel.Location = new System.Drawing.Point(743, 1137);
            this.haswork_tableLayoutPanel.Name = "haswork_tableLayoutPanel";
            this.haswork_tableLayoutPanel.RowCount = 1;
            this.haswork_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.haswork_tableLayoutPanel.Size = new System.Drawing.Size(234, 36);
            this.haswork_tableLayoutPanel.TabIndex = 84;
            // 
            // haswork_No_RadioButton
            // 
            this.haswork_No_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.haswork_No_RadioButton.AutoSize = true;
            this.haswork_No_RadioButton.Depth = 0;
            this.haswork_No_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.haswork_No_RadioButton.Location = new System.Drawing.Point(75, 3);
            this.haswork_No_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.haswork_No_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.haswork_No_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.haswork_No_RadioButton.Name = "haswork_No_RadioButton";
            this.haswork_No_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.haswork_No_RadioButton.Ripple = true;
            this.haswork_No_RadioButton.Size = new System.Drawing.Size(42, 30);
            this.haswork_No_RadioButton.TabIndex = 86;
            this.haswork_No_RadioButton.TabStop = true;
            this.haswork_No_RadioButton.Text = "لا";
            this.haswork_No_RadioButton.UseVisualStyleBackColor = true;
            this.haswork_No_RadioButton.CheckedChanged += new System.EventHandler(this.haswork_No_RadioButton_CheckedChanged);
            // 
            // haswork_Yes_RadioButton
            // 
            this.haswork_Yes_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.haswork_Yes_RadioButton.AutoSize = true;
            this.haswork_Yes_RadioButton.Depth = 0;
            this.haswork_Yes_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.haswork_Yes_RadioButton.Location = new System.Drawing.Point(173, 3);
            this.haswork_Yes_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.haswork_Yes_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.haswork_Yes_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.haswork_Yes_RadioButton.Name = "haswork_Yes_RadioButton";
            this.haswork_Yes_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.haswork_Yes_RadioButton.Ripple = true;
            this.haswork_Yes_RadioButton.Size = new System.Drawing.Size(61, 30);
            this.haswork_Yes_RadioButton.TabIndex = 85;
            this.haswork_Yes_RadioButton.TabStop = true;
            this.haswork_Yes_RadioButton.Text = "نعم";
            this.haswork_Yes_RadioButton.UseVisualStyleBackColor = true;
            this.haswork_Yes_RadioButton.CheckedChanged += new System.EventHandler(this.haswork_Yes_RadioButton_CheckedChanged);
            // 
            // materialLabel43
            // 
            this.materialLabel43.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel43.AutoSize = true;
            this.SecondTableLayoutPanel.SetColumnSpan(this.materialLabel43, 2);
            this.materialLabel43.Depth = 0;
            this.materialLabel43.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel43.Location = new System.Drawing.Point(983, 1142);
            this.materialLabel43.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel43.Name = "materialLabel43";
            this.materialLabel43.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel43.Size = new System.Drawing.Size(234, 26);
            this.materialLabel43.TabIndex = 135;
            this.materialLabel43.Text = "هل لديك عمل حالي؟";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.SecondTableLayoutPanel.SetColumnSpan(this.panel3, 10);
            this.panel3.Controls.Add(this.WorkLable);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(23, 1179);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1194, 36);
            this.panel3.TabIndex = 19;
            // 
            // WorkLable
            // 
            this.WorkLable.Depth = 0;
            this.WorkLable.Dock = System.Windows.Forms.DockStyle.Right;
            this.WorkLable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.WorkLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.WorkLable.Location = new System.Drawing.Point(1114, 0);
            this.WorkLable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.WorkLable.Name = "WorkLable";
            this.WorkLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.WorkLable.Size = new System.Drawing.Size(80, 36);
            this.WorkLable.TabIndex = 2;
            this.WorkLable.Text = "العمل";
            this.WorkLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WorkExp_DataGridView
            // 
            this.WorkExp_DataGridView.AllowUserToDeleteRows = false;
            this.WorkExp_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.WorkExp_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.WorkExp_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.WorkExp_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.WorkExp_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WorkExp_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WorkExp_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.WorkExp_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WorkExp_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Work_VisitName,
            this.workexp_id,
            this.workfor_id,
            this.worktype_id,
            this.workposition_id,
            this.experience_id,
            this.workexpamount,
            this.workname,
            this.workplace_id,
            this.expenses_amount_6,
            this.expensestype_6,
            this.expensesAmperNumber_7,
            this.expenses_amount_7,
            this.expenses_amount_15,
            this.expensestype_15,
            this.expenses_amount_16,
            this.expensestype_16,
            this.expenses_amount_17,
            this.expensestype_17,
            this.expenses_amount_23,
            this.expensestype_23,
            this.workexpnote,
            this.Work_DeleteRow,
            this.Person_Work_ID,
            this.Work_IsDirty});
            this.SecondTableLayoutPanel.SetColumnSpan(this.WorkExp_DataGridView, 10);
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.WorkExp_DataGridView.DefaultCellStyle = dataGridViewCellStyle12;
            this.WorkExp_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkExp_DataGridView.EnableHeadersVisualStyles = false;
            this.WorkExp_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.WorkExp_DataGridView.Location = new System.Drawing.Point(23, 1221);
            this.WorkExp_DataGridView.Name = "WorkExp_DataGridView";
            this.WorkExp_DataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.WorkExp_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WorkExp_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.WorkExp_DataGridView.RowHeadersVisible = false;
            this.WorkExp_DataGridView.RowHeadersWidth = 51;
            this.SecondTableLayoutPanel.SetRowSpan(this.WorkExp_DataGridView, 5);
            this.WorkExp_DataGridView.RowTemplate.Height = 24;
            this.WorkExp_DataGridView.Size = new System.Drawing.Size(1194, 204);
            this.WorkExp_DataGridView.TabIndex = 87;
            this.WorkExp_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WorkExp_DataGridView_CellContentClick);
            this.WorkExp_DataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.WorkExp_DataGridView_CellEndEdit);
            this.WorkExp_DataGridView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.WorkExp_DataGridView_CellLeave);
            this.WorkExp_DataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.WorkExp_DataGridView_CellPainting);
            this.WorkExp_DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView_DataError);
            this.WorkExp_DataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridView_EditingControlShowing);
            this.WorkExp_DataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.WorkExp_DataGridView_RowsAdded);
            // 
            // Work_VisitName
            // 
            this.Work_VisitName.HeaderText = "الزيارة";
            this.Work_VisitName.MinimumWidth = 6;
            this.Work_VisitName.Name = "Work_VisitName";
            this.Work_VisitName.Width = 125;
            // 
            // workexp_id
            // 
            this.workexp_id.FillWeight = 111.9289F;
            this.workexp_id.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.workexp_id.HeaderText = "العمل";
            this.workexp_id.MinimumWidth = 6;
            this.workexp_id.Name = "workexp_id";
            this.workexp_id.Width = 71;
            // 
            // workfor_id
            // 
            this.workfor_id.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.workfor_id.HeaderText = "جهة العمل";
            this.workfor_id.MinimumWidth = 6;
            this.workfor_id.Name = "workfor_id";
            this.workfor_id.Width = 64;
            // 
            // worktype_id
            // 
            this.worktype_id.HeaderText = "نوع العمل";
            this.worktype_id.MinimumWidth = 6;
            this.worktype_id.Name = "worktype_id";
            this.worktype_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.worktype_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.worktype_id.Width = 64;
            // 
            // workposition_id
            // 
            this.workposition_id.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.workposition_id.HeaderText = "صفة الشخص";
            this.workposition_id.MinimumWidth = 6;
            this.workposition_id.Name = "workposition_id";
            this.workposition_id.Width = 63;
            // 
            // experience_id
            // 
            this.experience_id.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.experience_id.HeaderText = "الخبرة";
            this.experience_id.MinimumWidth = 6;
            this.experience_id.Name = "experience_id";
            this.experience_id.Width = 64;
            // 
            // workexpamount
            // 
            dataGridViewCellStyle11.Format = "N0";
            this.workexpamount.DefaultCellStyle = dataGridViewCellStyle11;
            this.workexpamount.HeaderText = "الأجر الشهري";
            this.workexpamount.MinimumWidth = 6;
            this.workexpamount.Name = "workexpamount";
            this.workexpamount.Width = 64;
            // 
            // workname
            // 
            this.workname.HeaderText = "اسم المحل/المؤسسة";
            this.workname.MinimumWidth = 6;
            this.workname.Name = "workname";
            this.workname.Width = 63;
            // 
            // workplace_id
            // 
            this.workplace_id.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.workplace_id.HeaderText = "نوع المحل";
            this.workplace_id.MinimumWidth = 6;
            this.workplace_id.Name = "workplace_id";
            this.workplace_id.Width = 64;
            // 
            // expenses_amount_6
            // 
            this.expenses_amount_6.HeaderText = "قيمة الآجار";
            this.expenses_amount_6.MinimumWidth = 6;
            this.expenses_amount_6.Name = "expenses_amount_6";
            this.expenses_amount_6.Width = 64;
            // 
            // expensestype_6
            // 
            this.expensestype_6.HeaderText = "نوع الآجار";
            this.expensestype_6.MinimumWidth = 6;
            this.expensestype_6.Name = "expensestype_6";
            this.expensestype_6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.expensestype_6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.expensestype_6.Width = 63;
            // 
            // expensesAmperNumber_7
            // 
            this.expensesAmperNumber_7.HeaderText = "عدد الأمبيرات";
            this.expensesAmperNumber_7.MinimumWidth = 6;
            this.expensesAmperNumber_7.Name = "expensesAmperNumber_7";
            this.expensesAmperNumber_7.Width = 64;
            // 
            // expenses_amount_7
            // 
            this.expenses_amount_7.HeaderText = "مصروف الأمبيرات";
            this.expenses_amount_7.MinimumWidth = 6;
            this.expenses_amount_7.Name = "expenses_amount_7";
            this.expenses_amount_7.Width = 63;
            // 
            // expenses_amount_15
            // 
            this.expenses_amount_15.HeaderText = "مصروف المولدة";
            this.expenses_amount_15.MinimumWidth = 6;
            this.expenses_amount_15.Name = "expenses_amount_15";
            this.expenses_amount_15.Width = 64;
            // 
            // expensestype_15
            // 
            this.expensestype_15.HeaderText = "نوع مصروف المولدة";
            this.expensestype_15.MinimumWidth = 6;
            this.expensestype_15.Name = "expensestype_15";
            this.expensestype_15.Width = 64;
            // 
            // expenses_amount_16
            // 
            this.expenses_amount_16.HeaderText = "مصروف البطارية";
            this.expenses_amount_16.MinimumWidth = 6;
            this.expenses_amount_16.Name = "expenses_amount_16";
            this.expenses_amount_16.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.expenses_amount_16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.expenses_amount_16.Width = 63;
            // 
            // expensestype_16
            // 
            this.expensestype_16.HeaderText = "نوع مصروف البطارية";
            this.expensestype_16.MinimumWidth = 6;
            this.expensestype_16.Name = "expensestype_16";
            this.expensestype_16.Width = 64;
            // 
            // expenses_amount_17
            // 
            this.expenses_amount_17.HeaderText = "مصروف الطاقة";
            this.expenses_amount_17.MinimumWidth = 6;
            this.expenses_amount_17.Name = "expenses_amount_17";
            this.expenses_amount_17.Width = 64;
            // 
            // expensestype_17
            // 
            this.expensestype_17.HeaderText = "نوع مصروف الطاقة";
            this.expensestype_17.MinimumWidth = 6;
            this.expensestype_17.Name = "expensestype_17";
            this.expensestype_17.Width = 63;
            // 
            // expenses_amount_23
            // 
            this.expenses_amount_23.HeaderText = "مصروف الكهرباء";
            this.expenses_amount_23.MinimumWidth = 6;
            this.expenses_amount_23.Name = "expenses_amount_23";
            this.expenses_amount_23.Width = 64;
            // 
            // expensestype_23
            // 
            this.expensestype_23.HeaderText = "نوع مصروف الكهرباء";
            this.expensestype_23.MinimumWidth = 6;
            this.expensestype_23.Name = "expensestype_23";
            this.expensestype_23.Width = 64;
            // 
            // workexpnote
            // 
            this.workexpnote.FillWeight = 111.9289F;
            this.workexpnote.HeaderText = "الوصف";
            this.workexpnote.MinimumWidth = 6;
            this.workexpnote.Name = "workexpnote";
            this.workexpnote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.workexpnote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.workexpnote.Width = 71;
            // 
            // Work_DeleteRow
            // 
            this.Work_DeleteRow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Work_DeleteRow.FillWeight = 76.14214F;
            this.Work_DeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Work_DeleteRow.HeaderText = "";
            this.Work_DeleteRow.MinimumWidth = 50;
            this.Work_DeleteRow.Name = "Work_DeleteRow";
            this.Work_DeleteRow.Width = 50;
            // 
            // Person_Work_ID
            // 
            this.Person_Work_ID.HeaderText = "InDatabase";
            this.Person_Work_ID.MinimumWidth = 6;
            this.Person_Work_ID.Name = "Person_Work_ID";
            this.Person_Work_ID.Visible = false;
            this.Person_Work_ID.Width = 131;
            // 
            // Work_IsDirty
            // 
            this.Work_IsDirty.HeaderText = "IsDirty";
            this.Work_IsDirty.MinimumWidth = 6;
            this.Work_IsDirty.Name = "Work_IsDirty";
            this.Work_IsDirty.Visible = false;
            this.Work_IsDirty.Width = 87;
            // 
            // has_mp_tableLayoutPanel
            // 
            this.has_mp_tableLayoutPanel.ColumnCount = 2;
            this.SecondTableLayoutPanel.SetColumnSpan(this.has_mp_tableLayoutPanel, 2);
            this.has_mp_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.has_mp_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.has_mp_tableLayoutPanel.Controls.Add(this.mp_No_RadioButton, 0, 0);
            this.has_mp_tableLayoutPanel.Controls.Add(this.mp_Yes_RadioButton, 1, 0);
            this.has_mp_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.has_mp_tableLayoutPanel.Location = new System.Drawing.Point(743, 1473);
            this.has_mp_tableLayoutPanel.Name = "has_mp_tableLayoutPanel";
            this.has_mp_tableLayoutPanel.RowCount = 1;
            this.has_mp_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.has_mp_tableLayoutPanel.Size = new System.Drawing.Size(234, 36);
            this.has_mp_tableLayoutPanel.TabIndex = 88;
            // 
            // mp_No_RadioButton
            // 
            this.mp_No_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.mp_No_RadioButton.AutoSize = true;
            this.mp_No_RadioButton.Depth = 0;
            this.mp_No_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.mp_No_RadioButton.Location = new System.Drawing.Point(75, 3);
            this.mp_No_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.mp_No_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mp_No_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.mp_No_RadioButton.Name = "mp_No_RadioButton";
            this.mp_No_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mp_No_RadioButton.Ripple = true;
            this.mp_No_RadioButton.Size = new System.Drawing.Size(42, 30);
            this.mp_No_RadioButton.TabIndex = 90;
            this.mp_No_RadioButton.TabStop = true;
            this.mp_No_RadioButton.Text = "لا";
            this.mp_No_RadioButton.UseVisualStyleBackColor = true;
            this.mp_No_RadioButton.CheckedChanged += new System.EventHandler(this.mp_No_RadioButton_CheckedChanged);
            // 
            // mp_Yes_RadioButton
            // 
            this.mp_Yes_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.mp_Yes_RadioButton.AutoSize = true;
            this.mp_Yes_RadioButton.Depth = 0;
            this.mp_Yes_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.mp_Yes_RadioButton.Location = new System.Drawing.Point(173, 3);
            this.mp_Yes_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.mp_Yes_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mp_Yes_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.mp_Yes_RadioButton.Name = "mp_Yes_RadioButton";
            this.mp_Yes_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mp_Yes_RadioButton.Ripple = true;
            this.mp_Yes_RadioButton.Size = new System.Drawing.Size(61, 30);
            this.mp_Yes_RadioButton.TabIndex = 89;
            this.mp_Yes_RadioButton.TabStop = true;
            this.mp_Yes_RadioButton.Text = "نعم";
            this.mp_Yes_RadioButton.UseVisualStyleBackColor = true;
            this.mp_Yes_RadioButton.CheckedChanged += new System.EventHandler(this.mp_Yes_RadioButton_CheckedChanged);
            // 
            // materialLabel51
            // 
            this.materialLabel51.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel51.AutoSize = true;
            this.SecondTableLayoutPanel.SetColumnSpan(this.materialLabel51, 2);
            this.materialLabel51.Depth = 0;
            this.materialLabel51.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel51.Location = new System.Drawing.Point(983, 1470);
            this.materialLabel51.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel51.Name = "materialLabel51";
            this.materialLabel51.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel51.Size = new System.Drawing.Size(234, 42);
            this.materialLabel51.TabIndex = 248;
            this.materialLabel51.Text = "هل استفاد من مشاريع صغيرة؟";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.SecondTableLayoutPanel.SetColumnSpan(this.panel9, 10);
            this.panel9.Controls.Add(this.MPLable);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(23, 1515);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1194, 36);
            this.panel9.TabIndex = 33;
            // 
            // MPLable
            // 
            this.MPLable.Depth = 0;
            this.MPLable.Dock = System.Windows.Forms.DockStyle.Right;
            this.MPLable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.MPLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MPLable.Location = new System.Drawing.Point(970, 0);
            this.MPLable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.MPLable.Name = "MPLable";
            this.MPLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MPLable.Size = new System.Drawing.Size(224, 36);
            this.MPLable.TabIndex = 2;
            this.MPLable.Text = "المشاريع الصغيرة";
            this.MPLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MP_DataGridView
            // 
            this.MP_DataGridView.AllowUserToDeleteRows = false;
            this.MP_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            this.MP_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14;
            this.MP_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MP_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.MP_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.MP_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MP_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MP_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.MP_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MP_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MP_VisitName,
            this.mp_fundyear,
            this.aidsource_5_mp,
            this.aid_amount_5_mp,
            this.aidperiod_5_mp,
            this.aidsource_17_mp,
            this.aid_amount_17_mp,
            this.aidperiod_17_mp,
            this.aidsource_22_mp,
            this.aid_amount_22_mp,
            this.aidperiod_22_mp,
            this.expenses_amount_12_mp,
            this.expensestype_12_mp,
            this.MP_DeleteRow,
            this.Person_MP_ID,
            this.MP_IsDirty});
            this.SecondTableLayoutPanel.SetColumnSpan(this.MP_DataGridView, 10);
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MP_DataGridView.DefaultCellStyle = dataGridViewCellStyle16;
            this.MP_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MP_DataGridView.EnableHeadersVisualStyles = false;
            this.MP_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.MP_DataGridView.Location = new System.Drawing.Point(23, 1557);
            this.MP_DataGridView.Name = "MP_DataGridView";
            this.MP_DataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MP_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MP_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.MP_DataGridView.RowHeadersVisible = false;
            this.MP_DataGridView.RowHeadersWidth = 51;
            this.SecondTableLayoutPanel.SetRowSpan(this.MP_DataGridView, 5);
            this.MP_DataGridView.RowTemplate.Height = 24;
            this.MP_DataGridView.Size = new System.Drawing.Size(1194, 204);
            this.MP_DataGridView.TabIndex = 91;
            this.MP_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MP_DataGridView_CellContentClick);
            this.MP_DataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.MP_DataGridView_CellEndEdit);
            this.MP_DataGridView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.MP_DataGridView_CellLeave);
            this.MP_DataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.MP_DataGridView_CellPainting);
            this.MP_DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.MP_DataGridView_DataError);
            this.MP_DataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.MP_DataGridView_EditingControlShowing);
            this.MP_DataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.MP_DataGridView_RowsAdded);
            // 
            // MP_VisitName
            // 
            this.MP_VisitName.HeaderText = "الزيارة";
            this.MP_VisitName.MinimumWidth = 6;
            this.MP_VisitName.Name = "MP_VisitName";
            // 
            // mp_fundyear
            // 
            this.mp_fundyear.FillWeight = 80.83756F;
            this.mp_fundyear.HeaderText = "سنة التمويل";
            this.mp_fundyear.MinimumWidth = 6;
            this.mp_fundyear.Name = "mp_fundyear";
            // 
            // aidsource_5_mp
            // 
            this.aidsource_5_mp.FillWeight = 80.83756F;
            this.aidsource_5_mp.HeaderText = "جهة المساعدة بالآجار";
            this.aidsource_5_mp.MinimumWidth = 6;
            this.aidsource_5_mp.Name = "aidsource_5_mp";
            // 
            // aid_amount_5_mp
            // 
            this.aid_amount_5_mp.FillWeight = 80.83756F;
            this.aid_amount_5_mp.HeaderText = "قيمة المساعدة بالآجار";
            this.aid_amount_5_mp.MinimumWidth = 6;
            this.aid_amount_5_mp.Name = "aid_amount_5_mp";
            // 
            // aidperiod_5_mp
            // 
            this.aidperiod_5_mp.FillWeight = 80.83756F;
            this.aidperiod_5_mp.HeaderText = "مدة المساعدة بالآجار";
            this.aidperiod_5_mp.MinimumWidth = 6;
            this.aidperiod_5_mp.Name = "aidperiod_5_mp";
            this.aidperiod_5_mp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aidperiod_5_mp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // aidsource_17_mp
            // 
            this.aidsource_17_mp.FillWeight = 80.83756F;
            this.aidsource_17_mp.HeaderText = "جهة المساعدة بالترميم";
            this.aidsource_17_mp.MinimumWidth = 6;
            this.aidsource_17_mp.Name = "aidsource_17_mp";
            this.aidsource_17_mp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aidsource_17_mp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // aid_amount_17_mp
            // 
            this.aid_amount_17_mp.FillWeight = 80.83756F;
            this.aid_amount_17_mp.HeaderText = "قيمة المساعدة بالترميم";
            this.aid_amount_17_mp.MinimumWidth = 6;
            this.aid_amount_17_mp.Name = "aid_amount_17_mp";
            // 
            // aidperiod_17_mp
            // 
            this.aidperiod_17_mp.FillWeight = 80.83756F;
            this.aidperiod_17_mp.HeaderText = "مدة المساعدة بالترميم";
            this.aidperiod_17_mp.MinimumWidth = 6;
            this.aidperiod_17_mp.Name = "aidperiod_17_mp";
            this.aidperiod_17_mp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aidperiod_17_mp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // aidsource_22_mp
            // 
            this.aidsource_22_mp.FillWeight = 80.83756F;
            this.aidsource_22_mp.HeaderText = "جهة المساعدة بالآلات";
            this.aidsource_22_mp.MinimumWidth = 6;
            this.aidsource_22_mp.Name = "aidsource_22_mp";
            // 
            // aid_amount_22_mp
            // 
            this.aid_amount_22_mp.FillWeight = 80.83756F;
            this.aid_amount_22_mp.HeaderText = "قيمة المساعدة بالآلات";
            this.aid_amount_22_mp.MinimumWidth = 6;
            this.aid_amount_22_mp.Name = "aid_amount_22_mp";
            this.aid_amount_22_mp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aid_amount_22_mp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // aidperiod_22_mp
            // 
            this.aidperiod_22_mp.FillWeight = 80.83756F;
            this.aidperiod_22_mp.HeaderText = "مدة المساعدة بالآلات";
            this.aidperiod_22_mp.MinimumWidth = 6;
            this.aidperiod_22_mp.Name = "aidperiod_22_mp";
            // 
            // expenses_amount_12_mp
            // 
            this.expenses_amount_12_mp.FillWeight = 80.83756F;
            this.expenses_amount_12_mp.HeaderText = "مصروف القسط";
            this.expenses_amount_12_mp.MinimumWidth = 6;
            this.expenses_amount_12_mp.Name = "expenses_amount_12_mp";
            // 
            // expensestype_12_mp
            // 
            this.expensestype_12_mp.FillWeight = 80.83756F;
            this.expensestype_12_mp.HeaderText = "نوع مصروف القسط";
            this.expensestype_12_mp.MinimumWidth = 6;
            this.expensestype_12_mp.Name = "expensestype_12_mp";
            this.expensestype_12_mp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.expensestype_12_mp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MP_DeleteRow
            // 
            this.MP_DeleteRow.FillWeight = 76.14214F;
            this.MP_DeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MP_DeleteRow.HeaderText = "";
            this.MP_DeleteRow.MinimumWidth = 50;
            this.MP_DeleteRow.Name = "MP_DeleteRow";
            // 
            // Person_MP_ID
            // 
            this.Person_MP_ID.HeaderText = "InDatabase";
            this.Person_MP_ID.MinimumWidth = 6;
            this.Person_MP_ID.Name = "Person_MP_ID";
            this.Person_MP_ID.Visible = false;
            // 
            // MP_IsDirty
            // 
            this.MP_IsDirty.HeaderText = "IsDirty";
            this.MP_IsDirty.MinimumWidth = 6;
            this.MP_IsDirty.Name = "MP_IsDirty";
            this.MP_IsDirty.Visible = false;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.SecondTableLayoutPanel.SetColumnSpan(this.tableLayoutPanel8, 2);
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(23, 1970);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(234, 1);
            this.tableLayoutPanel8.TabIndex = 249;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.SecondTableLayoutPanel.SetColumnSpan(this.tableLayoutPanel9, 2);
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(23, 1844);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(234, 1);
            this.tableLayoutPanel9.TabIndex = 250;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.SecondTableLayoutPanel.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.materialRadioButton2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.materialRadioButton1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(23, 423);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(34, 1);
            this.tableLayoutPanel2.TabIndex = 133;
            // 
            // materialRadioButton2
            // 
            this.materialRadioButton2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.materialRadioButton2.AutoSize = true;
            this.materialRadioButton2.Depth = 0;
            this.materialRadioButton2.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialRadioButton2.Location = new System.Drawing.Point(0, 0);
            this.materialRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton2.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialRadioButton2.Name = "materialRadioButton2";
            this.materialRadioButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialRadioButton2.Ripple = true;
            this.materialRadioButton2.Size = new System.Drawing.Size(17, 1);
            this.materialRadioButton2.TabIndex = 32;
            this.materialRadioButton2.TabStop = true;
            this.materialRadioButton2.Text = "لا";
            this.materialRadioButton2.UseVisualStyleBackColor = true;
            // 
            // materialRadioButton1
            // 
            this.materialRadioButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.materialRadioButton1.AutoSize = true;
            this.materialRadioButton1.Depth = 0;
            this.materialRadioButton1.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialRadioButton1.Location = new System.Drawing.Point(17, 0);
            this.materialRadioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton1.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialRadioButton1.Name = "materialRadioButton1";
            this.materialRadioButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialRadioButton1.Ripple = true;
            this.materialRadioButton1.Size = new System.Drawing.Size(17, 1);
            this.materialRadioButton1.TabIndex = 31;
            this.materialRadioButton1.TabStop = true;
            this.materialRadioButton1.Text = "نعم";
            this.materialRadioButton1.UseVisualStyleBackColor = true;
            // 
            // IsStudent_tableLayoutPanel
            // 
            this.IsStudent_tableLayoutPanel.ColumnCount = 2;
            this.SecondTableLayoutPanel.SetColumnSpan(this.IsStudent_tableLayoutPanel, 2);
            this.IsStudent_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.IsStudent_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.IsStudent_tableLayoutPanel.Controls.Add(this.NotStudent_RadioButton, 0, 0);
            this.IsStudent_tableLayoutPanel.Controls.Add(this.IsStudent_RadioButton, 1, 0);
            this.IsStudent_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IsStudent_tableLayoutPanel.Location = new System.Drawing.Point(863, 2019);
            this.IsStudent_tableLayoutPanel.Name = "IsStudent_tableLayoutPanel";
            this.IsStudent_tableLayoutPanel.RowCount = 1;
            this.IsStudent_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IsStudent_tableLayoutPanel.Size = new System.Drawing.Size(234, 36);
            this.IsStudent_tableLayoutPanel.TabIndex = 99;
            // 
            // NotStudent_RadioButton
            // 
            this.NotStudent_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NotStudent_RadioButton.AutoSize = true;
            this.NotStudent_RadioButton.Depth = 0;
            this.NotStudent_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.NotStudent_RadioButton.Location = new System.Drawing.Point(75, 3);
            this.NotStudent_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.NotStudent_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.NotStudent_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.NotStudent_RadioButton.Name = "NotStudent_RadioButton";
            this.NotStudent_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NotStudent_RadioButton.Ripple = true;
            this.NotStudent_RadioButton.Size = new System.Drawing.Size(42, 30);
            this.NotStudent_RadioButton.TabIndex = 100;
            this.NotStudent_RadioButton.TabStop = true;
            this.NotStudent_RadioButton.Text = "لا";
            this.NotStudent_RadioButton.UseVisualStyleBackColor = true;
            this.NotStudent_RadioButton.CheckedChanged += new System.EventHandler(this.NotStudent_RadioButton_CheckedChanged);
            // 
            // IsStudent_RadioButton
            // 
            this.IsStudent_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.IsStudent_RadioButton.AutoSize = true;
            this.IsStudent_RadioButton.Depth = 0;
            this.IsStudent_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.IsStudent_RadioButton.Location = new System.Drawing.Point(173, 3);
            this.IsStudent_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.IsStudent_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.IsStudent_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.IsStudent_RadioButton.Name = "IsStudent_RadioButton";
            this.IsStudent_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.IsStudent_RadioButton.Ripple = true;
            this.IsStudent_RadioButton.Size = new System.Drawing.Size(61, 30);
            this.IsStudent_RadioButton.TabIndex = 99;
            this.IsStudent_RadioButton.TabStop = true;
            this.IsStudent_RadioButton.Text = "نعم";
            this.IsStudent_RadioButton.UseVisualStyleBackColor = true;
            this.IsStudent_RadioButton.CheckedChanged += new System.EventHandler(this.IsStudent_RadioButton_CheckedChanged_1);
            // 
            // materialLabel70
            // 
            this.materialLabel70.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel70.AutoSize = true;
            this.materialLabel70.Depth = 0;
            this.materialLabel70.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel70.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel70.Location = new System.Drawing.Point(1103, 2024);
            this.materialLabel70.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel70.Name = "materialLabel70";
            this.materialLabel70.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel70.Size = new System.Drawing.Size(95, 26);
            this.materialLabel70.TabIndex = 80;
            this.materialLabel70.Text = "هل طالب؟";
            // 
            // studentPanel
            // 
            this.studentPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.studentPanel.ColumnCount = 3;
            this.SecondTableLayoutPanel.SetColumnSpan(this.studentPanel, 10);
            this.studentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.studentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.studentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.studentPanel.Controls.Add(this.expensestype_2_comboBox, 0, 2);
            this.studentPanel.Controls.Add(this.materialLabel72, 2, 0);
            this.studentPanel.Controls.Add(this.materialLabel71, 1, 0);
            this.studentPanel.Controls.Add(this.materialLabel73, 0, 0);
            this.studentPanel.Controls.Add(this.materialLabel75, 2, 1);
            this.studentPanel.Controls.Add(this.materialLabel74, 2, 2);
            this.studentPanel.Controls.Add(this.expenses_amount_8_Textbox, 1, 1);
            this.studentPanel.Controls.Add(this.expenses_amount_2_TextBox, 1, 2);
            this.studentPanel.Controls.Add(this.expensestype_8_comboBox, 0, 1);
            this.studentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentPanel.Location = new System.Drawing.Point(23, 2061);
            this.studentPanel.Name = "studentPanel";
            this.studentPanel.RowCount = 3;
            this.SecondTableLayoutPanel.SetRowSpan(this.studentPanel, 3);
            this.studentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.studentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.studentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.studentPanel.Size = new System.Drawing.Size(1194, 120);
            this.studentPanel.TabIndex = 101;
            // 
            // expensestype_2_comboBox
            // 
            this.expensestype_2_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expensestype_2_comboBox.FormattingEnabled = true;
            this.expensestype_2_comboBox.Location = new System.Drawing.Point(4, 82);
            this.expensestype_2_comboBox.Name = "expensestype_2_comboBox";
            this.expensestype_2_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expensestype_2_comboBox.Size = new System.Drawing.Size(390, 32);
            this.expensestype_2_comboBox.TabIndex = 105;
            this.expensestype_2_comboBox.SelectionChangeCommitted += new System.EventHandler(this.expensestype_2_comboBox_SelectionChangeCommitted);
            // 
            // materialLabel72
            // 
            this.materialLabel72.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel72.AutoSize = true;
            this.materialLabel72.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel72.Depth = 0;
            this.materialLabel72.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel72.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel72.Location = new System.Drawing.Point(795, 1);
            this.materialLabel72.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel72.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel72.Name = "materialLabel72";
            this.materialLabel72.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel72.Size = new System.Drawing.Size(398, 38);
            this.materialLabel72.TabIndex = 127;
            this.materialLabel72.Text = "نوع المصروف";
            this.materialLabel72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel71
            // 
            this.materialLabel71.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel71.AutoSize = true;
            this.materialLabel71.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel71.Depth = 0;
            this.materialLabel71.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel71.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel71.Location = new System.Drawing.Point(398, 1);
            this.materialLabel71.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel71.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel71.Name = "materialLabel71";
            this.materialLabel71.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel71.Size = new System.Drawing.Size(396, 38);
            this.materialLabel71.TabIndex = 126;
            this.materialLabel71.Text = "قيمة المصروف";
            this.materialLabel71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel73
            // 
            this.materialLabel73.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel73.AutoSize = true;
            this.materialLabel73.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel73.Depth = 0;
            this.materialLabel73.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel73.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel73.Location = new System.Drawing.Point(1, 1);
            this.materialLabel73.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel73.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel73.Name = "materialLabel73";
            this.materialLabel73.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel73.Size = new System.Drawing.Size(396, 38);
            this.materialLabel73.TabIndex = 128;
            this.materialLabel73.Text = "مدة المصروف";
            this.materialLabel73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel75
            // 
            this.materialLabel75.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel75.AutoSize = true;
            this.materialLabel75.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel75.Depth = 0;
            this.materialLabel75.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel75.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel75.Location = new System.Drawing.Point(795, 40);
            this.materialLabel75.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel75.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel75.Name = "materialLabel75";
            this.materialLabel75.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel75.Size = new System.Drawing.Size(398, 38);
            this.materialLabel75.TabIndex = 130;
            this.materialLabel75.Text = "القسط الدراسي";
            this.materialLabel75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel74
            // 
            this.materialLabel74.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel74.AutoSize = true;
            this.materialLabel74.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel74.Depth = 0;
            this.materialLabel74.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel74.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel74.Location = new System.Drawing.Point(795, 79);
            this.materialLabel74.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel74.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel74.Name = "materialLabel74";
            this.materialLabel74.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel74.Size = new System.Drawing.Size(398, 40);
            this.materialLabel74.TabIndex = 129;
            this.materialLabel74.Text = "المواصلات";
            this.materialLabel74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expenses_amount_8_Textbox
            // 
            this.expenses_amount_8_Textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expenses_amount_8_Textbox.Location = new System.Drawing.Point(401, 43);
            this.expenses_amount_8_Textbox.Name = "expenses_amount_8_Textbox";
            this.expenses_amount_8_Textbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expenses_amount_8_Textbox.Size = new System.Drawing.Size(390, 28);
            this.expenses_amount_8_Textbox.TabIndex = 102;
            this.expenses_amount_8_Textbox.Enter += new System.EventHandler(this.expenses_amount_8_Textbox_Enter);
            this.expenses_amount_8_Textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.expenses_amount_8_Textbox_KeyPress);
            this.expenses_amount_8_Textbox.Leave += new System.EventHandler(this.expenses_amount_8_Textbox_Leave);
            // 
            // expenses_amount_2_TextBox
            // 
            this.expenses_amount_2_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expenses_amount_2_TextBox.Location = new System.Drawing.Point(401, 82);
            this.expenses_amount_2_TextBox.Name = "expenses_amount_2_TextBox";
            this.expenses_amount_2_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expenses_amount_2_TextBox.Size = new System.Drawing.Size(390, 28);
            this.expenses_amount_2_TextBox.TabIndex = 104;
            this.expenses_amount_2_TextBox.Enter += new System.EventHandler(this.expenses_amount_2_TextBox_Enter);
            this.expenses_amount_2_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.expenses_amount_2_TextBox_KeyPress);
            this.expenses_amount_2_TextBox.Leave += new System.EventHandler(this.expenses_amount_2_TextBox_Leave);
            // 
            // expensestype_8_comboBox
            // 
            this.expensestype_8_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expensestype_8_comboBox.FormattingEnabled = true;
            this.expensestype_8_comboBox.Location = new System.Drawing.Point(4, 43);
            this.expensestype_8_comboBox.Name = "expensestype_8_comboBox";
            this.expensestype_8_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.expensestype_8_comboBox.Size = new System.Drawing.Size(390, 32);
            this.expensestype_8_comboBox.TabIndex = 103;
            this.expensestype_8_comboBox.SelectionChangeCommitted += new System.EventHandler(this.expensestype_8_comboBox_SelectionChangeCommitted);
            // 
            // student1Panel
            // 
            this.student1Panel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.student1Panel.ColumnCount = 4;
            this.SecondTableLayoutPanel.SetColumnSpan(this.student1Panel, 10);
            this.student1Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.student1Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.student1Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.student1Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.student1Panel.Controls.Add(this.aidperiod_23_comboBox, 0, 2);
            this.student1Panel.Controls.Add(this.materialLabel76, 3, 0);
            this.student1Panel.Controls.Add(this.materialLabel77, 2, 0);
            this.student1Panel.Controls.Add(this.materialLabel79, 1, 0);
            this.student1Panel.Controls.Add(this.materialLabel78, 0, 0);
            this.student1Panel.Controls.Add(this.materialLabel81, 3, 1);
            this.student1Panel.Controls.Add(this.materialLabel80, 3, 2);
            this.student1Panel.Controls.Add(this.aid_amount_2_TextBox, 1, 1);
            this.student1Panel.Controls.Add(this.aid_amount_23_TextBox, 1, 2);
            this.student1Panel.Controls.Add(this.aidsource_2_comboBox, 2, 1);
            this.student1Panel.Controls.Add(this.aidsource_23_comboBox, 2, 2);
            this.student1Panel.Controls.Add(this.aidperiod_2_comboBox, 0, 1);
            this.student1Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.student1Panel.Location = new System.Drawing.Point(23, 2229);
            this.student1Panel.Name = "student1Panel";
            this.student1Panel.RowCount = 3;
            this.SecondTableLayoutPanel.SetRowSpan(this.student1Panel, 3);
            this.student1Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.student1Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.student1Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.student1Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.student1Panel.Size = new System.Drawing.Size(1194, 120);
            this.student1Panel.TabIndex = 106;
            // 
            // aidperiod_23_comboBox
            // 
            this.aidperiod_23_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aidperiod_23_comboBox.FormattingEnabled = true;
            this.aidperiod_23_comboBox.Location = new System.Drawing.Point(4, 82);
            this.aidperiod_23_comboBox.Name = "aidperiod_23_comboBox";
            this.aidperiod_23_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidperiod_23_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidperiod_23_comboBox.TabIndex = 112;
            this.aidperiod_23_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidperiod_23_comboBox_SelectionChangeCommitted);
            // 
            // materialLabel76
            // 
            this.materialLabel76.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel76.AutoSize = true;
            this.materialLabel76.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel76.Depth = 0;
            this.materialLabel76.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel76.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel76.Location = new System.Drawing.Point(895, 1);
            this.materialLabel76.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel76.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel76.Name = "materialLabel76";
            this.materialLabel76.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel76.Size = new System.Drawing.Size(298, 38);
            this.materialLabel76.TabIndex = 130;
            this.materialLabel76.Text = "المساعدة";
            this.materialLabel76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel77
            // 
            this.materialLabel77.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel77.AutoSize = true;
            this.materialLabel77.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel77.Depth = 0;
            this.materialLabel77.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel77.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel77.Location = new System.Drawing.Point(597, 1);
            this.materialLabel77.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel77.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel77.Name = "materialLabel77";
            this.materialLabel77.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel77.Size = new System.Drawing.Size(297, 38);
            this.materialLabel77.TabIndex = 131;
            this.materialLabel77.Text = "الجهة الداعمة";
            this.materialLabel77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel79
            // 
            this.materialLabel79.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel79.AutoSize = true;
            this.materialLabel79.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel79.Depth = 0;
            this.materialLabel79.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel79.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel79.Location = new System.Drawing.Point(299, 1);
            this.materialLabel79.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel79.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel79.Name = "materialLabel79";
            this.materialLabel79.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel79.Size = new System.Drawing.Size(297, 38);
            this.materialLabel79.TabIndex = 133;
            this.materialLabel79.Text = "قيمة المساعدة";
            this.materialLabel79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel78
            // 
            this.materialLabel78.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel78.AutoSize = true;
            this.materialLabel78.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel78.Depth = 0;
            this.materialLabel78.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel78.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel78.Location = new System.Drawing.Point(1, 1);
            this.materialLabel78.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel78.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel78.Name = "materialLabel78";
            this.materialLabel78.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel78.Size = new System.Drawing.Size(297, 38);
            this.materialLabel78.TabIndex = 134;
            this.materialLabel78.Text = "عدد مرات المساعدة";
            this.materialLabel78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel81
            // 
            this.materialLabel81.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel81.AutoSize = true;
            this.materialLabel81.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel81.Depth = 0;
            this.materialLabel81.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel81.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel81.Location = new System.Drawing.Point(895, 40);
            this.materialLabel81.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel81.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel81.Name = "materialLabel81";
            this.materialLabel81.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel81.Size = new System.Drawing.Size(298, 38);
            this.materialLabel81.TabIndex = 136;
            this.materialLabel81.Text = "القسط المدرسي";
            this.materialLabel81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel80
            // 
            this.materialLabel80.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel80.AutoSize = true;
            this.materialLabel80.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel80.Depth = 0;
            this.materialLabel80.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel80.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel80.Location = new System.Drawing.Point(895, 79);
            this.materialLabel80.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel80.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel80.Name = "materialLabel80";
            this.materialLabel80.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel80.Size = new System.Drawing.Size(298, 40);
            this.materialLabel80.TabIndex = 135;
            this.materialLabel80.Text = "دعم طلابي";
            this.materialLabel80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aid_amount_2_TextBox
            // 
            this.aid_amount_2_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aid_amount_2_TextBox.Location = new System.Drawing.Point(302, 43);
            this.aid_amount_2_TextBox.Name = "aid_amount_2_TextBox";
            this.aid_amount_2_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aid_amount_2_TextBox.Size = new System.Drawing.Size(291, 28);
            this.aid_amount_2_TextBox.TabIndex = 108;
            this.aid_amount_2_TextBox.Enter += new System.EventHandler(this.aid_amount_2_TextBox_Enter);
            this.aid_amount_2_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aid_amount_2_TextBox_KeyPress);
            this.aid_amount_2_TextBox.Leave += new System.EventHandler(this.aid_amount_2_TextBox_Leave);
            // 
            // aid_amount_23_TextBox
            // 
            this.aid_amount_23_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aid_amount_23_TextBox.Location = new System.Drawing.Point(302, 82);
            this.aid_amount_23_TextBox.Name = "aid_amount_23_TextBox";
            this.aid_amount_23_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aid_amount_23_TextBox.Size = new System.Drawing.Size(291, 28);
            this.aid_amount_23_TextBox.TabIndex = 111;
            this.aid_amount_23_TextBox.Enter += new System.EventHandler(this.aid_amount_23_TextBox_Enter);
            this.aid_amount_23_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aid_amount_23_TextBox_KeyPress);
            this.aid_amount_23_TextBox.Leave += new System.EventHandler(this.aid_amount_23_TextBox_Leave);
            // 
            // aidsource_2_comboBox
            // 
            this.aidsource_2_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aidsource_2_comboBox.FormattingEnabled = true;
            this.aidsource_2_comboBox.Location = new System.Drawing.Point(600, 43);
            this.aidsource_2_comboBox.Name = "aidsource_2_comboBox";
            this.aidsource_2_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidsource_2_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidsource_2_comboBox.TabIndex = 107;
            this.aidsource_2_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidsource_2_comboBox_SelectionChangeCommitted);
            // 
            // aidsource_23_comboBox
            // 
            this.aidsource_23_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aidsource_23_comboBox.FormattingEnabled = true;
            this.aidsource_23_comboBox.Location = new System.Drawing.Point(600, 82);
            this.aidsource_23_comboBox.Name = "aidsource_23_comboBox";
            this.aidsource_23_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidsource_23_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidsource_23_comboBox.TabIndex = 110;
            this.aidsource_23_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidsource_23_comboBox_SelectionChangeCommitted);
            // 
            // aidperiod_2_comboBox
            // 
            this.aidperiod_2_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aidperiod_2_comboBox.FormattingEnabled = true;
            this.aidperiod_2_comboBox.Location = new System.Drawing.Point(4, 43);
            this.aidperiod_2_comboBox.Name = "aidperiod_2_comboBox";
            this.aidperiod_2_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidperiod_2_comboBox.Size = new System.Drawing.Size(291, 32);
            this.aidperiod_2_comboBox.TabIndex = 109;
            this.aidperiod_2_comboBox.SelectionChangeCommitted += new System.EventHandler(this.aidperiod_2_comboBox_SelectionChangeCommitted);
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.SecondTableLayoutPanel.SetColumnSpan(this.panel10, 10);
            this.panel10.Controls.Add(this.NeedsLable);
            this.panel10.Location = new System.Drawing.Point(23, 2397);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1194, 36);
            this.panel10.TabIndex = 143;
            // 
            // NeedsLable
            // 
            this.NeedsLable.Depth = 0;
            this.NeedsLable.Dock = System.Windows.Forms.DockStyle.Right;
            this.NeedsLable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.NeedsLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.NeedsLable.Location = new System.Drawing.Point(970, 0);
            this.NeedsLable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.NeedsLable.Name = "NeedsLable";
            this.NeedsLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NeedsLable.Size = new System.Drawing.Size(224, 36);
            this.NeedsLable.TabIndex = 2;
            this.NeedsLable.Text = "الحاجات المجتمعية";
            this.NeedsLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // needs_1_checkBox
            // 
            this.needs_1_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.needs_1_checkBox.AutoSize = true;
            this.SecondTableLayoutPanel.SetColumnSpan(this.needs_1_checkBox, 2);
            this.needs_1_checkBox.Location = new System.Drawing.Point(983, 2443);
            this.needs_1_checkBox.Name = "needs_1_checkBox";
            this.needs_1_checkBox.Size = new System.Drawing.Size(234, 28);
            this.needs_1_checkBox.TabIndex = 113;
            this.needs_1_checkBox.Text = "حاجات اجتماعية (أنشطة - نوادي)";
            this.needs_1_checkBox.UseVisualStyleBackColor = true;
            this.needs_1_checkBox.CheckedChanged += new System.EventHandler(this.needs_1_checkBox_CheckedChanged);
            // 
            // needs_8_checkBox
            // 
            this.needs_8_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.needs_8_checkBox.AutoSize = true;
            this.needs_8_checkBox.Location = new System.Drawing.Point(743, 2443);
            this.needs_8_checkBox.Name = "needs_8_checkBox";
            this.needs_8_checkBox.Size = new System.Drawing.Size(114, 28);
            this.needs_8_checkBox.TabIndex = 114;
            this.needs_8_checkBox.Text = "دورات لغات";
            this.needs_8_checkBox.UseVisualStyleBackColor = true;
            this.needs_8_checkBox.CheckedChanged += new System.EventHandler(this.needs_8_checkBox_CheckedChanged);
            // 
            // needs_3_checkBox
            // 
            this.needs_3_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.needs_3_checkBox.AutoSize = true;
            this.needs_3_checkBox.Location = new System.Drawing.Point(503, 2443);
            this.needs_3_checkBox.Name = "needs_3_checkBox";
            this.needs_3_checkBox.Size = new System.Drawing.Size(116, 28);
            this.needs_3_checkBox.TabIndex = 115;
            this.needs_3_checkBox.Text = "ICDL";
            this.needs_3_checkBox.UseVisualStyleBackColor = true;
            this.needs_3_checkBox.CheckedChanged += new System.EventHandler(this.needs_3_checkBox_CheckedChanged);
            // 
            // needs_4_checkBox
            // 
            this.needs_4_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.needs_4_checkBox.AutoSize = true;
            this.needs_4_checkBox.Location = new System.Drawing.Point(263, 2443);
            this.needs_4_checkBox.Name = "needs_4_checkBox";
            this.needs_4_checkBox.Size = new System.Drawing.Size(114, 28);
            this.needs_4_checkBox.TabIndex = 116;
            this.needs_4_checkBox.Text = "English";
            this.needs_4_checkBox.UseVisualStyleBackColor = true;
            this.needs_4_checkBox.CheckedChanged += new System.EventHandler(this.needs_4_checkBox_CheckedChanged);
            // 
            // needs_6_checkBox
            // 
            this.needs_6_checkBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.needs_6_checkBox.AutoSize = true;
            this.needs_6_checkBox.Location = new System.Drawing.Point(24, 2443);
            this.needs_6_checkBox.Name = "needs_6_checkBox";
            this.needs_6_checkBox.Size = new System.Drawing.Size(113, 28);
            this.needs_6_checkBox.TabIndex = 117;
            this.needs_6_checkBox.Text = "أجهزة دراسية";
            this.needs_6_checkBox.UseVisualStyleBackColor = true;
            this.needs_6_checkBox.CheckedChanged += new System.EventHandler(this.needs_6_checkBox_CheckedChanged);
            // 
            // needs_7_checkBox
            // 
            this.needs_7_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.needs_7_checkBox.AutoSize = true;
            this.needs_7_checkBox.Location = new System.Drawing.Point(743, 2485);
            this.needs_7_checkBox.Name = "needs_7_checkBox";
            this.needs_7_checkBox.Size = new System.Drawing.Size(114, 28);
            this.needs_7_checkBox.TabIndex = 119;
            this.needs_7_checkBox.Text = "مكان ملائم للدراسة";
            this.needs_7_checkBox.UseVisualStyleBackColor = true;
            this.needs_7_checkBox.CheckedChanged += new System.EventHandler(this.needs_7_checkBox_CheckedChanged);
            // 
            // needs_courses_TextBox
            // 
            this.needs_courses_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondTableLayoutPanel.SetColumnSpan(this.needs_courses_TextBox, 2);
            this.needs_courses_TextBox.Depth = 0;
            this.needs_courses_TextBox.Hint = "";
            this.needs_courses_TextBox.Location = new System.Drawing.Point(743, 2525);
            this.needs_courses_TextBox.MaxLength = 32767;
            this.needs_courses_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.needs_courses_TextBox.Name = "needs_courses_TextBox";
            this.needs_courses_TextBox.PasswordChar = '\0';
            this.needs_courses_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.needs_courses_TextBox.SelectedText = "";
            this.needs_courses_TextBox.SelectionLength = 0;
            this.needs_courses_TextBox.SelectionStart = 0;
            this.needs_courses_TextBox.Size = new System.Drawing.Size(234, 31);
            this.needs_courses_TextBox.TabIndex = 124;
            this.needs_courses_TextBox.TabStop = false;
            this.needs_courses_TextBox.UseSystemPasswordChar = false;
            this.needs_courses_TextBox.Enter += new System.EventHandler(this.needs_courses_TextBox_Enter);
            this.needs_courses_TextBox.Leave += new System.EventHandler(this.needs_courses_TextBox_Leave);
            // 
            // needs_9_checkBox
            // 
            this.needs_9_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.needs_9_checkBox.AutoSize = true;
            this.needs_9_checkBox.Location = new System.Drawing.Point(503, 2485);
            this.needs_9_checkBox.Name = "needs_9_checkBox";
            this.needs_9_checkBox.Size = new System.Drawing.Size(116, 28);
            this.needs_9_checkBox.TabIndex = 120;
            this.needs_9_checkBox.Text = "دعم مواهب";
            this.needs_9_checkBox.UseVisualStyleBackColor = true;
            this.needs_9_checkBox.CheckedChanged += new System.EventHandler(this.needs_9_checkBox_CheckedChanged);
            // 
            // needs_10_checkBox
            // 
            this.needs_10_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.needs_10_checkBox.AutoSize = true;
            this.needs_10_checkBox.Location = new System.Drawing.Point(263, 2485);
            this.needs_10_checkBox.Name = "needs_10_checkBox";
            this.needs_10_checkBox.Size = new System.Drawing.Size(114, 28);
            this.needs_10_checkBox.TabIndex = 121;
            this.needs_10_checkBox.Text = "دعم نفسي تخصصي";
            this.needs_10_checkBox.UseVisualStyleBackColor = true;
            this.needs_10_checkBox.CheckedChanged += new System.EventHandler(this.needs_10_checkBox_CheckedChanged);
            // 
            // needs_0_checkBox
            // 
            this.needs_0_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.needs_0_checkBox.AutoSize = true;
            this.needs_0_checkBox.Location = new System.Drawing.Point(263, 2527);
            this.needs_0_checkBox.Name = "needs_0_checkBox";
            this.needs_0_checkBox.Size = new System.Drawing.Size(114, 28);
            this.needs_0_checkBox.TabIndex = 263;
            this.needs_0_checkBox.Text = "غير ذلك";
            this.needs_0_checkBox.UseVisualStyleBackColor = true;
            this.needs_0_checkBox.CheckedChanged += new System.EventHandler(this.needs_0_checkBox_CheckedChanged);
            // 
            // needs_12_checkBox
            // 
            this.needs_12_checkBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.needs_12_checkBox.AutoSize = true;
            this.needs_12_checkBox.Location = new System.Drawing.Point(23, 2485);
            this.needs_12_checkBox.Name = "needs_12_checkBox";
            this.needs_12_checkBox.Size = new System.Drawing.Size(114, 28);
            this.needs_12_checkBox.TabIndex = 122;
            this.needs_12_checkBox.Text = "مساحة للإبداع";
            this.needs_12_checkBox.UseVisualStyleBackColor = true;
            this.needs_12_checkBox.CheckedChanged += new System.EventHandler(this.needs_12_checkBox_CheckedChanged);
            // 
            // needs_note_TextBox
            // 
            this.needs_note_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondTableLayoutPanel.SetColumnSpan(this.needs_note_TextBox, 2);
            this.needs_note_TextBox.Depth = 0;
            this.needs_note_TextBox.Hint = "";
            this.needs_note_TextBox.Location = new System.Drawing.Point(23, 2525);
            this.needs_note_TextBox.MaxLength = 32767;
            this.needs_note_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.needs_note_TextBox.Name = "needs_note_TextBox";
            this.needs_note_TextBox.PasswordChar = '\0';
            this.needs_note_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.needs_note_TextBox.SelectedText = "";
            this.needs_note_TextBox.SelectionLength = 0;
            this.needs_note_TextBox.SelectionStart = 0;
            this.needs_note_TextBox.Size = new System.Drawing.Size(234, 31);
            this.needs_note_TextBox.TabIndex = 43;
            this.needs_note_TextBox.TabStop = false;
            this.needs_note_TextBox.UseSystemPasswordChar = false;
            this.needs_note_TextBox.Enter += new System.EventHandler(this.needs_note_TextBox_Enter);
            this.needs_note_TextBox.Leave += new System.EventHandler(this.needs_note_TextBox_Leave);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.SecondTableLayoutPanel.SetColumnSpan(this.panel6, 10);
            this.panel6.Controls.Add(this.GeneralNoteLable);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(23, 2607);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1194, 36);
            this.panel6.TabIndex = 19;
            // 
            // GeneralNoteLable
            // 
            this.GeneralNoteLable.Depth = 0;
            this.GeneralNoteLable.Dock = System.Windows.Forms.DockStyle.Right;
            this.GeneralNoteLable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.GeneralNoteLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.GeneralNoteLable.Location = new System.Drawing.Point(988, 0);
            this.GeneralNoteLable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.GeneralNoteLable.Name = "GeneralNoteLable";
            this.GeneralNoteLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GeneralNoteLable.Size = new System.Drawing.Size(206, 36);
            this.GeneralNoteLable.TabIndex = 2;
            this.GeneralNoteLable.Text = "ملاحظات عامة:";
            this.GeneralNoteLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel21
            // 
            this.materialLabel21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialLabel21.AutoSize = true;
            this.materialLabel21.Depth = 0;
            this.materialLabel21.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel21.Location = new System.Drawing.Point(1103, 2646);
            this.materialLabel21.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel21.Name = "materialLabel21";
            this.materialLabel21.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SecondTableLayoutPanel.SetRowSpan(this.materialLabel21, 2);
            this.materialLabel21.Size = new System.Drawing.Size(86, 84);
            this.materialLabel21.TabIndex = 131;
            this.materialLabel21.Text = "ملاحظات الفريق:";
            // 
            // panel12
            // 
            this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.SecondTableLayoutPanel.SetColumnSpan(this.panel12, 10);
            this.panel12.Controls.Add(this.VisitNameLabel);
            this.panel12.Controls.Add(this.VisitInfoLabel);
            this.panel12.Location = new System.Drawing.Point(23, 45);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1194, 36);
            this.panel12.TabIndex = 264;
            // 
            // VisitNameLabel
            // 
            this.VisitNameLabel.AutoSize = true;
            this.VisitNameLabel.Location = new System.Drawing.Point(1225, 13);
            this.VisitNameLabel.Name = "VisitNameLabel";
            this.VisitNameLabel.Size = new System.Drawing.Size(0, 24);
            this.VisitNameLabel.TabIndex = 6;
            // 
            // VisitInfoLabel
            // 
            this.VisitInfoLabel.Depth = 0;
            this.VisitInfoLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.VisitInfoLabel.Font = new System.Drawing.Font("Tajawal", 11F);
            this.VisitInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VisitInfoLabel.Location = new System.Drawing.Point(953, 0);
            this.VisitInfoLabel.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.VisitInfoLabel.Name = "VisitInfoLabel";
            this.VisitInfoLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.VisitInfoLabel.Size = new System.Drawing.Size(241, 36);
            this.VisitInfoLabel.TabIndex = 5;
            this.VisitInfoLabel.Text = "معلومات الزيارة:";
            this.VisitInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // needs_5_checkBox
            // 
            this.needs_5_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.needs_5_checkBox.AutoSize = true;
            this.needs_5_checkBox.Location = new System.Drawing.Point(983, 2485);
            this.needs_5_checkBox.Name = "needs_5_checkBox";
            this.needs_5_checkBox.Size = new System.Drawing.Size(114, 28);
            this.needs_5_checkBox.TabIndex = 118;
            this.needs_5_checkBox.Text = "تدريب مهني";
            this.needs_5_checkBox.UseVisualStyleBackColor = true;
            this.needs_5_checkBox.CheckedChanged += new System.EventHandler(this.needs_5_checkBox_CheckedChanged);
            // 
            // needs_2_checkBox
            // 
            this.needs_2_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.needs_2_checkBox.AutoSize = true;
            this.needs_2_checkBox.Location = new System.Drawing.Point(983, 2527);
            this.needs_2_checkBox.Name = "needs_2_checkBox";
            this.needs_2_checkBox.Size = new System.Drawing.Size(114, 28);
            this.needs_2_checkBox.TabIndex = 123;
            this.needs_2_checkBox.Text = "دورات تعليمية متخصصة";
            this.needs_2_checkBox.UseVisualStyleBackColor = true;
            this.needs_2_checkBox.CheckedChanged += new System.EventHandler(this.needs_2_checkBox_CheckedChanged);
            // 
            // PersonNote_TextBox
            // 
            this.SecondTableLayoutPanel.SetColumnSpan(this.PersonNote_TextBox, 9);
            this.PersonNote_TextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.PersonNote_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonNote_TextBox.Location = new System.Drawing.Point(23, 2649);
            this.PersonNote_TextBox.Multiline = true;
            this.PersonNote_TextBox.Name = "PersonNote_TextBox";
            this.PersonNote_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SecondTableLayoutPanel.SetRowSpan(this.PersonNote_TextBox, 2);
            this.PersonNote_TextBox.Size = new System.Drawing.Size(1074, 78);
            this.PersonNote_TextBox.TabIndex = 125;
            this.PersonNote_TextBox.Enter += new System.EventHandler(this.PersonNote_TextBox_Enter);
            this.PersonNote_TextBox.Leave += new System.EventHandler(this.PersonNote_TextBox_Leave);
            // 
            // MELayoutPanel
            // 
            this.MELayoutPanel.ColumnCount = 12;
            this.MELayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MELayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01603F));
            this.MELayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01603F));
            this.MELayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01603F));
            this.MELayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01603F));
            this.MELayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01603F));
            this.MELayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.855759F));
            this.MELayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01603F));
            this.MELayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01603F));
            this.MELayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01603F));
            this.MELayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01603F));
            this.MELayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.MELayoutPanel.Controls.Add(this.MEFamily_DataGridView, 1, 1);
            this.MELayoutPanel.Controls.Add(this.panel11, 1, 0);
            this.MELayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MELayoutPanel.Location = new System.Drawing.Point(0, 1281);
            this.MELayoutPanel.Name = "MELayoutPanel";
            this.MELayoutPanel.RowCount = 2;
            this.MELayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.49162F));
            this.MELayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.50838F));
            this.MELayoutPanel.Size = new System.Drawing.Size(1241, 179);
            this.MELayoutPanel.TabIndex = 46;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.MELayoutPanel.SetColumnSpan(this.panel11, 10);
            this.panel11.Controls.Add(this.visit_Label);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(23, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1192, 45);
            this.panel11.TabIndex = 44;
            // 
            // visit_Label
            // 
            this.visit_Label.Depth = 0;
            this.visit_Label.Dock = System.Windows.Forms.DockStyle.Right;
            this.visit_Label.Font = new System.Drawing.Font("Tajawal", 11F);
            this.visit_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visit_Label.Location = new System.Drawing.Point(951, 0);
            this.visit_Label.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.visit_Label.Name = "visit_Label";
            this.visit_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.visit_Label.Size = new System.Drawing.Size(241, 45);
            this.visit_Label.TabIndex = 4;
            this.visit_Label.Text = "الزيارات:";
            this.visit_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FirstLayoutPanel
            // 
            this.FirstLayoutPanel.BackColor = System.Drawing.Color.White;
            this.FirstLayoutPanel.ColumnCount = 12;
            this.FirstLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.FirstLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.53133F));
            this.FirstLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.351713F));
            this.FirstLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.590492F));
            this.FirstLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.69841F));
            this.FirstLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.939014F));
            this.FirstLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.757108F));
            this.FirstLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.95405F));
            this.FirstLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.106098F));
            this.FirstLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.510509F));
            this.FirstLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.51422F));
            this.FirstLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.FirstLayoutPanel.ContextMenuStrip = this.materialContextMenuStrip1;
            this.FirstLayoutPanel.Controls.Add(this.StateAddressNote_TextBox, 5, 14);
            this.FirstLayoutPanel.Controls.Add(this.StateAddressNote_Lable, 7, 14);
            this.FirstLayoutPanel.Controls.Add(this.Note_TextBox, 1, 23);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel47, 10, 5);
            this.FirstLayoutPanel.Controls.Add(this.Receiver_LayoutPanel, 8, 12);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel48, 10, 6);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel49, 10, 7);
            this.FirstLayoutPanel.Controls.Add(this.dateTimePicker1, 5, 8);
            this.FirstLayoutPanel.Controls.Add(this.Stateyear_TextBox, 5, 13);
            this.FirstLayoutPanel.Controls.Add(this.NationalityNumber_TextBox, 8, 8);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel52, 10, 12);
            this.FirstLayoutPanel.Controls.Add(this.StateYear_Lable, 7, 13);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel53, 10, 8);
            this.FirstLayoutPanel.Controls.Add(this.Nationality_ComboBox, 5, 7);
            this.FirstLayoutPanel.Controls.Add(this.Sex_ComboBox, 8, 7);
            this.FirstLayoutPanel.Controls.Add(this.ELastName_TextBox, 2, 6);
            this.FirstLayoutPanel.Controls.Add(this.LastName_TextBox, 2, 5);
            this.FirstLayoutPanel.Controls.Add(this.EFatherName_TextBox, 5, 6);
            this.FirstLayoutPanel.Controls.Add(this.EName_TextBox, 8, 6);
            this.FirstLayoutPanel.Controls.Add(this.FatherName_TextBox, 5, 5);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel54, 4, 5);
            this.FirstLayoutPanel.Controls.Add(this.FirstName_TextBox, 8, 5);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel55, 7, 5);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel56, 7, 8);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel57, 4, 6);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel58, 7, 6);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel59, 7, 7);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel16, 9, 1);
            this.FirstLayoutPanel.Controls.Add(this.FamilyCode_TextBox, 8, 1);
            this.FirstLayoutPanel.Controls.Add(this.State_Label1, 10, 13);
            this.FirstLayoutPanel.Controls.Add(this.State_ComboBox, 8, 13);
            this.FirstLayoutPanel.Controls.Add(this.pictureBox1, 3, 8);
            this.FirstLayoutPanel.Controls.Add(this.pictureBox3, 4, 8);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel20, 7, 12);
            this.FirstLayoutPanel.Controls.Add(this.MaritalStatus_ComboBox, 5, 12);
            this.FirstLayoutPanel.Controls.Add(this.Relation_Label, 4, 12);
            this.FirstLayoutPanel.Controls.Add(this.Relation_ComboBox, 2, 12);
            this.FirstLayoutPanel.Controls.Add(this.panel13, 1, 22);
            this.FirstLayoutPanel.Controls.Add(this.Delete_Button, 5, 26);
            this.FirstLayoutPanel.Controls.Add(this.educatedPanel, 1, 18);
            this.FirstLayoutPanel.Controls.Add(this.panel1, 1, 3);
            this.FirstLayoutPanel.Controls.Add(this.panel2, 1, 10);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel19, 10, 17);
            this.FirstLayoutPanel.Controls.Add(this.IsEducated_LayoutPanel, 8, 17);
            this.FirstLayoutPanel.Controls.Add(this.AidAmount_29_Textbox, 5, 15);
            this.FirstLayoutPanel.Controls.Add(this.AidPeriod_29_comboBox, 2, 15);
            this.FirstLayoutPanel.Controls.Add(this.isAid_Panel, 8, 15);
            this.FirstLayoutPanel.Controls.Add(this.AidNote_29_Textbox, 8, 16);
            this.FirstLayoutPanel.Controls.Add(this.materialLabel5, 10, 23);
            this.FirstLayoutPanel.Controls.Add(this.visitLabel, 7, 1);
            this.FirstLayoutPanel.Controls.Add(this.visit_TextBox, 5, 1);
            this.FirstLayoutPanel.Controls.Add(this.State_Label, 3, 1);
            this.FirstLayoutPanel.Controls.Add(this.State_TextBox, 2, 1);
            this.FirstLayoutPanel.Controls.Add(this.SavePerson_Button, 6, 25);
            this.FirstLayoutPanel.Controls.Add(this.UpdatePerson_Button, 7, 26);
            this.FirstLayoutPanel.Controls.Add(this.button3, 2, 21);
            this.FirstLayoutPanel.Controls.Add(this.StateHistory_Button, 1, 13);
            this.FirstLayoutPanel.Controls.Add(this.MaritalHistory_Button, 1, 12);
            this.FirstLayoutPanel.Controls.Add(this.AidNote_29_Lable, 10, 16);
            this.FirstLayoutPanel.Controls.Add(this.isAid_Lable, 10, 15);
            this.FirstLayoutPanel.Controls.Add(this.isAidAmount_Lable, 7, 15);
            this.FirstLayoutPanel.Controls.Add(this.isAidPeriod_Lable, 4, 15);
            this.FirstLayoutPanel.Controls.Add(this.StateAddress_Lable, 10, 14);
            this.FirstLayoutPanel.Controls.Add(this.StateAddress_ComboBox, 8, 14);
            this.FirstLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FirstLayoutPanel.ForeColor = System.Drawing.Color.Black;
            this.FirstLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.FirstLayoutPanel.Name = "FirstLayoutPanel";
            this.FirstLayoutPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FirstLayoutPanel.RowCount = 28;
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.FirstLayoutPanel.Size = new System.Drawing.Size(1241, 1281);
            this.FirstLayoutPanel.TabIndex = 2;
            // 
            // StateAddressNote_TextBox
            // 
            this.FirstLayoutPanel.SetColumnSpan(this.StateAddressNote_TextBox, 2);
            this.StateAddressNote_TextBox.Depth = 0;
            this.StateAddressNote_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StateAddressNote_TextBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.StateAddressNote_TextBox.Hint = "";
            this.StateAddressNote_TextBox.Location = new System.Drawing.Point(515, 633);
            this.StateAddressNote_TextBox.MaxLength = 32767;
            this.StateAddressNote_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.StateAddressNote_TextBox.Name = "StateAddressNote_TextBox";
            this.StateAddressNote_TextBox.PasswordChar = '\0';
            this.StateAddressNote_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StateAddressNote_TextBox.SelectedText = "";
            this.StateAddressNote_TextBox.SelectionLength = 0;
            this.StateAddressNote_TextBox.SelectionStart = 0;
            this.StateAddressNote_TextBox.Size = new System.Drawing.Size(170, 31);
            this.StateAddressNote_TextBox.TabIndex = 24;
            this.StateAddressNote_TextBox.TabStop = false;
            this.StateAddressNote_TextBox.UseSystemPasswordChar = false;
            this.StateAddressNote_TextBox.Enter += new System.EventHandler(this.StateAddressNote_TextBox_Enter);
            this.StateAddressNote_TextBox.Leave += new System.EventHandler(this.StateAddressNote_TextBox_Leave);
            // 
            // StateAddressNote_Lable
            // 
            this.StateAddressNote_Lable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StateAddressNote_Lable.AutoSize = true;
            this.StateAddressNote_Lable.Depth = 0;
            this.StateAddressNote_Lable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.StateAddressNote_Lable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateAddressNote_Lable.Location = new System.Drawing.Point(691, 639);
            this.StateAddressNote_Lable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.StateAddressNote_Lable.Name = "StateAddressNote_Lable";
            this.StateAddressNote_Lable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StateAddressNote_Lable.Size = new System.Drawing.Size(113, 26);
            this.StateAddressNote_Lable.TabIndex = 23;
            this.StateAddressNote_Lable.Text = "وصف المكان";
            // 
            // Note_TextBox
            // 
            this.FirstLayoutPanel.SetColumnSpan(this.Note_TextBox, 9);
            this.Note_TextBox.Depth = 0;
            this.Note_TextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Note_TextBox.Hint = "";
            this.Note_TextBox.Location = new System.Drawing.Point(23, 1046);
            this.Note_TextBox.MaxLength = 32767;
            this.Note_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.Note_TextBox.Name = "Note_TextBox";
            this.Note_TextBox.PasswordChar = '\0';
            this.Note_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Note_TextBox.SelectedText = "";
            this.Note_TextBox.SelectionLength = 0;
            this.Note_TextBox.SelectionStart = 0;
            this.Note_TextBox.Size = new System.Drawing.Size(1052, 31);
            this.Note_TextBox.TabIndex = 42;
            this.Note_TextBox.TabStop = false;
            this.Note_TextBox.UseSystemPasswordChar = false;
            this.Note_TextBox.Enter += new System.EventHandler(this.Note_TextBox_Enter);
            this.Note_TextBox.Leave += new System.EventHandler(this.Note_TextBox_Leave);
            // 
            // materialLabel47
            // 
            this.materialLabel47.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel47.AutoSize = true;
            this.materialLabel47.Depth = 0;
            this.materialLabel47.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel47.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel47.Location = new System.Drawing.Point(1081, 234);
            this.materialLabel47.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel47.Name = "materialLabel47";
            this.materialLabel47.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel47.Size = new System.Drawing.Size(63, 26);
            this.materialLabel47.TabIndex = 21;
            this.materialLabel47.Text = "الاسم:";
            // 
            // Receiver_LayoutPanel
            // 
            this.Receiver_LayoutPanel.ColumnCount = 2;
            this.FirstLayoutPanel.SetColumnSpan(this.Receiver_LayoutPanel, 2);
            this.Receiver_LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Receiver_LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Receiver_LayoutPanel.Controls.Add(this.Receiver_RadioButton, 1, 0);
            this.Receiver_LayoutPanel.Controls.Add(this.NotReceiver_RadioButton, 0, 0);
            this.Receiver_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Receiver_LayoutPanel.Font = new System.Drawing.Font("Janna LT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Receiver_LayoutPanel.Location = new System.Drawing.Point(870, 543);
            this.Receiver_LayoutPanel.Name = "Receiver_LayoutPanel";
            this.Receiver_LayoutPanel.RowCount = 1;
            this.Receiver_LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Receiver_LayoutPanel.Size = new System.Drawing.Size(205, 39);
            this.Receiver_LayoutPanel.TabIndex = 15;
            // 
            // Receiver_RadioButton
            // 
            this.Receiver_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Receiver_RadioButton.AutoSize = true;
            this.Receiver_RadioButton.Depth = 0;
            this.Receiver_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.Receiver_RadioButton.Location = new System.Drawing.Point(144, 4);
            this.Receiver_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.Receiver_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Receiver_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.Receiver_RadioButton.Name = "Receiver_RadioButton";
            this.Receiver_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Receiver_RadioButton.Ripple = true;
            this.Receiver_RadioButton.Size = new System.Drawing.Size(61, 30);
            this.Receiver_RadioButton.TabIndex = 16;
            this.Receiver_RadioButton.TabStop = true;
            this.Receiver_RadioButton.Text = "نعم";
            this.Receiver_RadioButton.UseVisualStyleBackColor = true;
            this.Receiver_RadioButton.CheckedChanged += new System.EventHandler(this.Receiver_RadioButton_CheckedChanged);
            // 
            // NotReceiver_RadioButton
            // 
            this.NotReceiver_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NotReceiver_RadioButton.AutoSize = true;
            this.NotReceiver_RadioButton.Depth = 0;
            this.NotReceiver_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.NotReceiver_RadioButton.Location = new System.Drawing.Point(60, 4);
            this.NotReceiver_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.NotReceiver_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.NotReceiver_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.NotReceiver_RadioButton.Name = "NotReceiver_RadioButton";
            this.NotReceiver_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NotReceiver_RadioButton.Ripple = true;
            this.NotReceiver_RadioButton.Size = new System.Drawing.Size(42, 30);
            this.NotReceiver_RadioButton.TabIndex = 17;
            this.NotReceiver_RadioButton.TabStop = true;
            this.NotReceiver_RadioButton.Text = "لا";
            this.NotReceiver_RadioButton.UseVisualStyleBackColor = true;
            this.NotReceiver_RadioButton.CheckedChanged += new System.EventHandler(this.NotReceiver_RadioButton_CheckedChanged);
            // 
            // materialLabel48
            // 
            this.materialLabel48.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel48.AutoSize = true;
            this.materialLabel48.Depth = 0;
            this.materialLabel48.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel48.Location = new System.Drawing.Point(1081, 279);
            this.materialLabel48.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel48.Name = "materialLabel48";
            this.materialLabel48.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel48.Size = new System.Drawing.Size(62, 26);
            this.materialLabel48.TabIndex = 7;
            this.materialLabel48.Text = "Name:";
            // 
            // materialLabel49
            // 
            this.materialLabel49.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel49.AutoSize = true;
            this.materialLabel49.Depth = 0;
            this.materialLabel49.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel49.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel49.Location = new System.Drawing.Point(1081, 324);
            this.materialLabel49.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel49.Name = "materialLabel49";
            this.materialLabel49.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel49.Size = new System.Drawing.Size(70, 26);
            this.materialLabel49.TabIndex = 57;
            this.materialLabel49.Text = "الجنس:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstLayoutPanel.SetColumnSpan(this.dateTimePicker1, 2);
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(515, 363);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(170, 41);
            this.dateTimePicker1.TabIndex = 13;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Stateyear_TextBox
            // 
            this.FirstLayoutPanel.SetColumnSpan(this.Stateyear_TextBox, 2);
            this.Stateyear_TextBox.Depth = 0;
            this.Stateyear_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Stateyear_TextBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.Stateyear_TextBox.Hint = "";
            this.Stateyear_TextBox.Location = new System.Drawing.Point(515, 588);
            this.Stateyear_TextBox.MaxLength = 32767;
            this.Stateyear_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.Stateyear_TextBox.Name = "Stateyear_TextBox";
            this.Stateyear_TextBox.PasswordChar = '\0';
            this.Stateyear_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Stateyear_TextBox.SelectedText = "";
            this.Stateyear_TextBox.SelectionLength = 0;
            this.Stateyear_TextBox.SelectionStart = 0;
            this.Stateyear_TextBox.Size = new System.Drawing.Size(170, 31);
            this.Stateyear_TextBox.TabIndex = 22;
            this.Stateyear_TextBox.TabStop = false;
            this.Stateyear_TextBox.UseSystemPasswordChar = false;
            this.Stateyear_TextBox.Enter += new System.EventHandler(this.Stateyear_TextBox_Enter);
            this.Stateyear_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Stateyear_TextBox_KeyPress);
            this.Stateyear_TextBox.Leave += new System.EventHandler(this.Stateyear_TextBox_Leave);
            // 
            // NationalityNumber_TextBox
            // 
            this.NationalityNumber_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstLayoutPanel.SetColumnSpan(this.NationalityNumber_TextBox, 2);
            this.NationalityNumber_TextBox.Depth = 0;
            this.NationalityNumber_TextBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.NationalityNumber_TextBox.Hint = "";
            this.NationalityNumber_TextBox.Location = new System.Drawing.Point(870, 367);
            this.NationalityNumber_TextBox.MaxLength = 32767;
            this.NationalityNumber_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.NationalityNumber_TextBox.Name = "NationalityNumber_TextBox";
            this.NationalityNumber_TextBox.PasswordChar = '\0';
            this.NationalityNumber_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NationalityNumber_TextBox.SelectedText = "";
            this.NationalityNumber_TextBox.SelectionLength = 0;
            this.NationalityNumber_TextBox.SelectionStart = 0;
            this.NationalityNumber_TextBox.Size = new System.Drawing.Size(205, 31);
            this.NationalityNumber_TextBox.TabIndex = 12;
            this.NationalityNumber_TextBox.TabStop = false;
            this.NationalityNumber_TextBox.UseSystemPasswordChar = false;
            this.NationalityNumber_TextBox.Enter += new System.EventHandler(this.NationalityNumber_TextBox_Enter);
            this.NationalityNumber_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NationalityNumber_TextBox_KeyPress);
            this.NationalityNumber_TextBox.Leave += new System.EventHandler(this.NationalityNumber_TextBox_Leave);
            // 
            // materialLabel52
            // 
            this.materialLabel52.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel52.AutoSize = true;
            this.materialLabel52.Depth = 0;
            this.materialLabel52.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel52.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel52.Location = new System.Drawing.Point(1081, 549);
            this.materialLabel52.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel52.Name = "materialLabel52";
            this.materialLabel52.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel52.Size = new System.Drawing.Size(82, 26);
            this.materialLabel52.TabIndex = 73;
            this.materialLabel52.Text = "المستلم:";
            // 
            // StateYear_Lable
            // 
            this.StateYear_Lable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StateYear_Lable.AutoSize = true;
            this.StateYear_Lable.Depth = 0;
            this.StateYear_Lable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.StateYear_Lable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateYear_Lable.Location = new System.Drawing.Point(691, 594);
            this.StateYear_Lable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.StateYear_Lable.Name = "StateYear_Lable";
            this.StateYear_Lable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StateYear_Lable.Size = new System.Drawing.Size(98, 26);
            this.StateYear_Lable.TabIndex = 22;
            this.StateYear_Lable.Text = "سنة الحالة:";
            // 
            // materialLabel53
            // 
            this.materialLabel53.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel53.AutoSize = true;
            this.materialLabel53.Depth = 0;
            this.materialLabel53.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel53.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel53.Location = new System.Drawing.Point(1081, 369);
            this.materialLabel53.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel53.Name = "materialLabel53";
            this.materialLabel53.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel53.Size = new System.Drawing.Size(110, 26);
            this.materialLabel53.TabIndex = 1;
            this.materialLabel53.Text = "الرقم الوطني";
            // 
            // Nationality_ComboBox
            // 
            this.Nationality_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Nationality_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Nationality_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Nationality_ComboBox.BackColor = System.Drawing.Color.White;
            this.FirstLayoutPanel.SetColumnSpan(this.Nationality_ComboBox, 2);
            this.Nationality_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Nationality_ComboBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.Nationality_ComboBox.FormattingEnabled = true;
            this.Nationality_ComboBox.Location = new System.Drawing.Point(515, 318);
            this.Nationality_ComboBox.Name = "Nationality_ComboBox";
            this.Nationality_ComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Nationality_ComboBox.Size = new System.Drawing.Size(170, 42);
            this.Nationality_ComboBox.TabIndex = 11;
            this.Nationality_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            this.Nationality_ComboBox.SelectionChangeCommitted += new System.EventHandler(this.Nationality_ComboBox_SelectionChangeCommitted);
            // 
            // Sex_ComboBox
            // 
            this.Sex_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Sex_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Sex_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Sex_ComboBox.BackColor = System.Drawing.Color.White;
            this.FirstLayoutPanel.SetColumnSpan(this.Sex_ComboBox, 2);
            this.Sex_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Sex_ComboBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.Sex_ComboBox.FormattingEnabled = true;
            this.Sex_ComboBox.Location = new System.Drawing.Point(870, 318);
            this.Sex_ComboBox.Name = "Sex_ComboBox";
            this.Sex_ComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Sex_ComboBox.Size = new System.Drawing.Size(205, 42);
            this.Sex_ComboBox.TabIndex = 10;
            this.Sex_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            this.Sex_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Sex_ComboBox_SelectedIndexChanged);
            this.Sex_ComboBox.SelectionChangeCommitted += new System.EventHandler(this.Sex_ComboBox_SelectionChangeCommitted);
            // 
            // ELastName_TextBox
            // 
            this.ELastName_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstLayoutPanel.SetColumnSpan(this.ELastName_TextBox, 2);
            this.ELastName_TextBox.Depth = 0;
            this.ELastName_TextBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.ELastName_TextBox.Hint = "";
            this.ELastName_TextBox.Location = new System.Drawing.Point(173, 277);
            this.ELastName_TextBox.MaxLength = 32767;
            this.ELastName_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.ELastName_TextBox.Name = "ELastName_TextBox";
            this.ELastName_TextBox.PasswordChar = '\0';
            this.ELastName_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ELastName_TextBox.SelectedText = "";
            this.ELastName_TextBox.SelectionLength = 0;
            this.ELastName_TextBox.SelectionStart = 0;
            this.ELastName_TextBox.Size = new System.Drawing.Size(184, 31);
            this.ELastName_TextBox.TabIndex = 9;
            this.ELastName_TextBox.TabStop = false;
            this.ELastName_TextBox.UseSystemPasswordChar = false;
            this.ELastName_TextBox.Enter += new System.EventHandler(this.ELastName_TextBox_Enter);
            this.ELastName_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.English_TextBox_KeyPress);
            this.ELastName_TextBox.Leave += new System.EventHandler(this.ELastName_TextBox_Leave);
            // 
            // LastName_TextBox
            // 
            this.LastName_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstLayoutPanel.SetColumnSpan(this.LastName_TextBox, 2);
            this.LastName_TextBox.Depth = 0;
            this.LastName_TextBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.LastName_TextBox.Hint = "";
            this.LastName_TextBox.Location = new System.Drawing.Point(173, 232);
            this.LastName_TextBox.MaxLength = 32767;
            this.LastName_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.LastName_TextBox.Name = "LastName_TextBox";
            this.LastName_TextBox.PasswordChar = '\0';
            this.LastName_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LastName_TextBox.SelectedText = "";
            this.LastName_TextBox.SelectionLength = 0;
            this.LastName_TextBox.SelectionStart = 0;
            this.LastName_TextBox.Size = new System.Drawing.Size(184, 31);
            this.LastName_TextBox.TabIndex = 6;
            this.LastName_TextBox.TabStop = false;
            this.LastName_TextBox.UseSystemPasswordChar = false;
            this.LastName_TextBox.Enter += new System.EventHandler(this.LastName_TextBox_Enter);
            this.LastName_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Arabic_TextBox_KeyPress);
            this.LastName_TextBox.Leave += new System.EventHandler(this.LastName_TextBox_Leave);
            // 
            // EFatherName_TextBox
            // 
            this.EFatherName_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstLayoutPanel.SetColumnSpan(this.EFatherName_TextBox, 2);
            this.EFatherName_TextBox.Depth = 0;
            this.EFatherName_TextBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.EFatherName_TextBox.Hint = "";
            this.EFatherName_TextBox.Location = new System.Drawing.Point(515, 277);
            this.EFatherName_TextBox.MaxLength = 32767;
            this.EFatherName_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.EFatherName_TextBox.Name = "EFatherName_TextBox";
            this.EFatherName_TextBox.PasswordChar = '\0';
            this.EFatherName_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EFatherName_TextBox.SelectedText = "";
            this.EFatherName_TextBox.SelectionLength = 0;
            this.EFatherName_TextBox.SelectionStart = 0;
            this.EFatherName_TextBox.Size = new System.Drawing.Size(170, 31);
            this.EFatherName_TextBox.TabIndex = 8;
            this.EFatherName_TextBox.TabStop = false;
            this.EFatherName_TextBox.UseSystemPasswordChar = false;
            this.EFatherName_TextBox.Enter += new System.EventHandler(this.EFatherName_TextBox_Enter);
            this.EFatherName_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.English_TextBox_KeyPress);
            this.EFatherName_TextBox.Leave += new System.EventHandler(this.EFatherName_TextBox_Leave);
            // 
            // EName_TextBox
            // 
            this.EName_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstLayoutPanel.SetColumnSpan(this.EName_TextBox, 2);
            this.EName_TextBox.Depth = 0;
            this.EName_TextBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.EName_TextBox.Hint = "";
            this.EName_TextBox.Location = new System.Drawing.Point(870, 277);
            this.EName_TextBox.MaxLength = 32767;
            this.EName_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.EName_TextBox.Name = "EName_TextBox";
            this.EName_TextBox.PasswordChar = '\0';
            this.EName_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EName_TextBox.SelectedText = "";
            this.EName_TextBox.SelectionLength = 0;
            this.EName_TextBox.SelectionStart = 0;
            this.EName_TextBox.Size = new System.Drawing.Size(205, 31);
            this.EName_TextBox.TabIndex = 7;
            this.EName_TextBox.TabStop = false;
            this.EName_TextBox.UseSystemPasswordChar = false;
            this.EName_TextBox.Enter += new System.EventHandler(this.EName_TextBox_Enter);
            this.EName_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.English_TextBox_KeyPress);
            this.EName_TextBox.Leave += new System.EventHandler(this.EName_TextBox_Leave);
            // 
            // FatherName_TextBox
            // 
            this.FatherName_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstLayoutPanel.SetColumnSpan(this.FatherName_TextBox, 2);
            this.FatherName_TextBox.Depth = 0;
            this.FatherName_TextBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.FatherName_TextBox.Hint = "";
            this.FatherName_TextBox.Location = new System.Drawing.Point(515, 232);
            this.FatherName_TextBox.MaxLength = 32767;
            this.FatherName_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.FatherName_TextBox.Name = "FatherName_TextBox";
            this.FatherName_TextBox.PasswordChar = '\0';
            this.FatherName_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FatherName_TextBox.SelectedText = "";
            this.FatherName_TextBox.SelectionLength = 0;
            this.FatherName_TextBox.SelectionStart = 0;
            this.FatherName_TextBox.Size = new System.Drawing.Size(170, 31);
            this.FatherName_TextBox.TabIndex = 5;
            this.FatherName_TextBox.TabStop = false;
            this.FatherName_TextBox.UseSystemPasswordChar = false;
            this.FatherName_TextBox.Enter += new System.EventHandler(this.FatherName_TextBox_Enter);
            this.FatherName_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Arabic_TextBox_KeyPress);
            this.FatherName_TextBox.Leave += new System.EventHandler(this.FatherName_TextBox_Leave);
            // 
            // materialLabel54
            // 
            this.materialLabel54.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel54.AutoSize = true;
            this.materialLabel54.Depth = 0;
            this.materialLabel54.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel54.Location = new System.Drawing.Point(363, 234);
            this.materialLabel54.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel54.Name = "materialLabel54";
            this.materialLabel54.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel54.Size = new System.Drawing.Size(58, 26);
            this.materialLabel54.TabIndex = 8;
            this.materialLabel54.Text = "الكنية:";
            // 
            // FirstName_TextBox
            // 
            this.FirstName_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstLayoutPanel.SetColumnSpan(this.FirstName_TextBox, 2);
            this.FirstName_TextBox.Depth = 0;
            this.FirstName_TextBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.FirstName_TextBox.Hint = "";
            this.FirstName_TextBox.Location = new System.Drawing.Point(870, 232);
            this.FirstName_TextBox.MaxLength = 32767;
            this.FirstName_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.FirstName_TextBox.Name = "FirstName_TextBox";
            this.FirstName_TextBox.PasswordChar = '\0';
            this.FirstName_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FirstName_TextBox.SelectedText = "";
            this.FirstName_TextBox.SelectionLength = 0;
            this.FirstName_TextBox.SelectionStart = 0;
            this.FirstName_TextBox.Size = new System.Drawing.Size(205, 31);
            this.FirstName_TextBox.TabIndex = 4;
            this.FirstName_TextBox.TabStop = false;
            this.FirstName_TextBox.UseSystemPasswordChar = false;
            this.FirstName_TextBox.Enter += new System.EventHandler(this.Name_TextBox_Enter);
            this.FirstName_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Arabic_TextBox_KeyPress);
            this.FirstName_TextBox.Leave += new System.EventHandler(this.Name_TextBox_Leave);
            // 
            // materialLabel55
            // 
            this.materialLabel55.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel55.AutoSize = true;
            this.materialLabel55.Depth = 0;
            this.materialLabel55.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel55.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel55.Location = new System.Drawing.Point(691, 234);
            this.materialLabel55.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel55.Name = "materialLabel55";
            this.materialLabel55.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel55.Size = new System.Drawing.Size(90, 26);
            this.materialLabel55.TabIndex = 8;
            this.materialLabel55.Text = "اسم الأب:";
            // 
            // materialLabel56
            // 
            this.materialLabel56.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel56.AutoSize = true;
            this.materialLabel56.Depth = 0;
            this.materialLabel56.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel56.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel56.Location = new System.Drawing.Point(691, 369);
            this.materialLabel56.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel56.Name = "materialLabel56";
            this.materialLabel56.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel56.Size = new System.Drawing.Size(107, 26);
            this.materialLabel56.TabIndex = 59;
            this.materialLabel56.Text = "تاريخ الميلاد:";
            // 
            // materialLabel57
            // 
            this.materialLabel57.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel57.AutoSize = true;
            this.materialLabel57.Depth = 0;
            this.materialLabel57.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel57.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel57.Location = new System.Drawing.Point(363, 279);
            this.materialLabel57.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel57.Name = "materialLabel57";
            this.materialLabel57.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel57.Size = new System.Drawing.Size(100, 26);
            this.materialLabel57.TabIndex = 8;
            this.materialLabel57.Text = "Last Name:";
            // 
            // materialLabel58
            // 
            this.materialLabel58.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel58.AutoSize = true;
            this.materialLabel58.Depth = 0;
            this.materialLabel58.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel58.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel58.Location = new System.Drawing.Point(691, 279);
            this.materialLabel58.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel58.Name = "materialLabel58";
            this.materialLabel58.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel58.Size = new System.Drawing.Size(119, 26);
            this.materialLabel58.TabIndex = 8;
            this.materialLabel58.Text = "Father Name:";
            // 
            // materialLabel59
            // 
            this.materialLabel59.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel59.AutoSize = true;
            this.materialLabel59.Depth = 0;
            this.materialLabel59.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel59.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel59.Location = new System.Drawing.Point(691, 324);
            this.materialLabel59.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel59.Name = "materialLabel59";
            this.materialLabel59.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel59.Size = new System.Drawing.Size(80, 26);
            this.materialLabel59.TabIndex = 58;
            this.materialLabel59.Text = "الجنسية:";
            // 
            // materialLabel16
            // 
            this.materialLabel16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel16.AutoSize = true;
            this.materialLabel16.Depth = 0;
            this.materialLabel16.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel16.Location = new System.Drawing.Point(979, 54);
            this.materialLabel16.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel16.Name = "materialLabel16";
            this.materialLabel16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel16.Size = new System.Drawing.Size(95, 26);
            this.materialLabel16.TabIndex = 12;
            this.materialLabel16.Text = "رمز العائلة:";
            // 
            // FamilyCode_TextBox
            // 
            this.FamilyCode_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FamilyCode_TextBox.Depth = 0;
            this.FamilyCode_TextBox.Enabled = false;
            this.FamilyCode_TextBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.FamilyCode_TextBox.Hint = "";
            this.FamilyCode_TextBox.Location = new System.Drawing.Point(870, 52);
            this.FamilyCode_TextBox.MaxLength = 32767;
            this.FamilyCode_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.FamilyCode_TextBox.Name = "FamilyCode_TextBox";
            this.FamilyCode_TextBox.PasswordChar = '\0';
            this.FamilyCode_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FamilyCode_TextBox.SelectedText = "";
            this.FamilyCode_TextBox.SelectionLength = 0;
            this.FamilyCode_TextBox.SelectionStart = 0;
            this.FamilyCode_TextBox.Size = new System.Drawing.Size(103, 31);
            this.FamilyCode_TextBox.TabIndex = 1;
            this.FamilyCode_TextBox.TabStop = false;
            this.FamilyCode_TextBox.UseSystemPasswordChar = false;
            // 
            // State_Label1
            // 
            this.State_Label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.State_Label1.AutoSize = true;
            this.State_Label1.Depth = 0;
            this.State_Label1.Font = new System.Drawing.Font("Tajawal", 11F);
            this.State_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.State_Label1.Location = new System.Drawing.Point(1081, 594);
            this.State_Label1.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.State_Label1.Name = "State_Label1";
            this.State_Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.State_Label1.Size = new System.Drawing.Size(59, 26);
            this.State_Label1.TabIndex = 65;
            this.State_Label1.Text = "الحالة:";
            // 
            // State_ComboBox
            // 
            this.State_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.State_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.State_ComboBox.BackColor = System.Drawing.Color.White;
            this.FirstLayoutPanel.SetColumnSpan(this.State_ComboBox, 2);
            this.State_ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.State_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.State_ComboBox.Font = new System.Drawing.Font("Janna LT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.State_ComboBox.FormattingEnabled = true;
            this.State_ComboBox.Location = new System.Drawing.Point(870, 588);
            this.State_ComboBox.Name = "State_ComboBox";
            this.State_ComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.State_ComboBox.Size = new System.Drawing.Size(205, 42);
            this.State_ComboBox.TabIndex = 21;
            this.State_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            this.State_ComboBox.SelectionChangeCommitted += new System.EventHandler(this.State_ComboBox_SelectionChangeCommitted);
            // 
            // materialLabel20
            // 
            this.materialLabel20.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel20.AutoSize = true;
            this.materialLabel20.Depth = 0;
            this.materialLabel20.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel20.Location = new System.Drawing.Point(691, 549);
            this.materialLabel20.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel20.Name = "materialLabel20";
            this.materialLabel20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel20.Size = new System.Drawing.Size(142, 26);
            this.materialLabel20.TabIndex = 60;
            this.materialLabel20.Text = "الحالة الإجتماعية:";
            // 
            // MaritalStatus_ComboBox
            // 
            this.MaritalStatus_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.MaritalStatus_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.MaritalStatus_ComboBox.BackColor = System.Drawing.Color.White;
            this.FirstLayoutPanel.SetColumnSpan(this.MaritalStatus_ComboBox, 2);
            this.MaritalStatus_ComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.MaritalStatus_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.MaritalStatus_ComboBox.Font = new System.Drawing.Font("Janna LT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaritalStatus_ComboBox.FormattingEnabled = true;
            this.MaritalStatus_ComboBox.Location = new System.Drawing.Point(515, 543);
            this.MaritalStatus_ComboBox.Name = "MaritalStatus_ComboBox";
            this.MaritalStatus_ComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MaritalStatus_ComboBox.Size = new System.Drawing.Size(170, 42);
            this.MaritalStatus_ComboBox.TabIndex = 18;
            this.MaritalStatus_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            this.MaritalStatus_ComboBox.SelectionChangeCommitted += new System.EventHandler(this.MaritalStatus_ComboBox_SelectionChangeCommitted);
            // 
            // Relation_Label
            // 
            this.Relation_Label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Relation_Label.AutoSize = true;
            this.Relation_Label.Depth = 0;
            this.Relation_Label.Font = new System.Drawing.Font("Tajawal", 11F);
            this.Relation_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Relation_Label.Location = new System.Drawing.Point(363, 549);
            this.Relation_Label.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.Relation_Label.Name = "Relation_Label";
            this.Relation_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Relation_Label.Size = new System.Drawing.Size(129, 26);
            this.Relation_Label.TabIndex = 63;
            this.Relation_Label.Text = "الصفة الأسرية:";
            // 
            // Relation_ComboBox
            // 
            this.Relation_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Relation_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Relation_ComboBox.BackColor = System.Drawing.Color.White;
            this.FirstLayoutPanel.SetColumnSpan(this.Relation_ComboBox, 2);
            this.Relation_ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Relation_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Relation_ComboBox.Font = new System.Drawing.Font("Janna LT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relation_ComboBox.FormattingEnabled = true;
            this.Relation_ComboBox.Location = new System.Drawing.Point(173, 543);
            this.Relation_ComboBox.Name = "Relation_ComboBox";
            this.Relation_ComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Relation_ComboBox.Size = new System.Drawing.Size(184, 42);
            this.Relation_ComboBox.TabIndex = 19;
            this.Relation_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            this.Relation_ComboBox.SelectionChangeCommitted += new System.EventHandler(this.Relation_ComboBox_SelectionChangeCommitted);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.FirstLayoutPanel.SetColumnSpan(this.panel13, 10);
            this.panel13.Controls.Add(this.PGeneralNoteLable);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(23, 993);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1190, 39);
            this.panel13.TabIndex = 36;
            // 
            // PGeneralNoteLable
            // 
            this.PGeneralNoteLable.Depth = 0;
            this.PGeneralNoteLable.Dock = System.Windows.Forms.DockStyle.Right;
            this.PGeneralNoteLable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.PGeneralNoteLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PGeneralNoteLable.Location = new System.Drawing.Point(949, 0);
            this.PGeneralNoteLable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.PGeneralNoteLable.Name = "PGeneralNoteLable";
            this.PGeneralNoteLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PGeneralNoteLable.Size = new System.Drawing.Size(241, 39);
            this.PGeneralNoteLable.TabIndex = 3;
            this.PGeneralNoteLable.Text = "ملاحظات عامة:";
            this.PGeneralNoteLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Delete_Button
            // 
            this.Delete_Button.BackColor = System.Drawing.Color.Transparent;
            this.Delete_Button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Delete_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Delete_Button.FlatAppearance.BorderSize = 0;
            this.Delete_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Delete_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Delete_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Delete_Button.Location = new System.Drawing.Point(515, 1173);
            this.Delete_Button.MaximumSize = new System.Drawing.Size(102, 42);
            this.Delete_Button.MinimumSize = new System.Drawing.Size(102, 42);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(102, 42);
            this.Delete_Button.TabIndex = 45;
            this.Delete_Button.Text = "DELETE";
            this.Delete_Button.UseVisualStyleBackColor = false;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            this.Delete_Button.MouseEnter += new System.EventHandler(this.Delete_Button_MouseEnter);
            this.Delete_Button.MouseLeave += new System.EventHandler(this.Delete_Button_MouseLeave);
            // 
            // educatedPanel
            // 
            this.educatedPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.educatedPanel.ColumnCount = 5;
            this.FirstLayoutPanel.SetColumnSpan(this.educatedPanel, 10);
            this.educatedPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.educatedPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.educatedPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.educatedPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.educatedPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.educatedPanel.Controls.Add(this.educationnote2_TextBox, 2, 2);
            this.educatedPanel.Controls.Add(this.educationtype_id_1_comboBox, 0, 1);
            this.educatedPanel.Controls.Add(this.materialLabel2, 3, 0);
            this.educatedPanel.Controls.Add(this.materialLabel7, 2, 0);
            this.educatedPanel.Controls.Add(this.materialLabel10, 1, 0);
            this.educatedPanel.Controls.Add(this.materialLabel17, 4, 0);
            this.educatedPanel.Controls.Add(this.materialLabel40, 4, 1);
            this.educatedPanel.Controls.Add(this.materialLabel42, 4, 2);
            this.educatedPanel.Controls.Add(this.education_id_1_comboBox, 3, 1);
            this.educatedPanel.Controls.Add(this.education_id_2_comboBox, 3, 2);
            this.educatedPanel.Controls.Add(this.educationfield_id_1_comboBox, 1, 1);
            this.educatedPanel.Controls.Add(this.educationfield_id_2_comboBox, 1, 2);
            this.educatedPanel.Controls.Add(this.educationtype_id_2_comboBox, 0, 2);
            this.educatedPanel.Controls.Add(this.educationnote_TextBox, 2, 1);
            this.educatedPanel.Controls.Add(this.materialLabel12, 0, 0);
            this.educatedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.educatedPanel.Location = new System.Drawing.Point(23, 813);
            this.educatedPanel.Name = "educatedPanel";
            this.educatedPanel.RowCount = 3;
            this.FirstLayoutPanel.SetRowSpan(this.educatedPanel, 3);
            this.educatedPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.educatedPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.educatedPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.educatedPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.educatedPanel.Size = new System.Drawing.Size(1190, 129);
            this.educatedPanel.TabIndex = 33;
            // 
            // educationnote2_TextBox
            // 
            this.educationnote2_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.educationnote2_TextBox.Location = new System.Drawing.Point(544, 88);
            this.educationnote2_TextBox.Name = "educationnote2_TextBox";
            this.educationnote2_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.educationnote2_TextBox.Size = new System.Drawing.Size(263, 28);
            this.educationnote2_TextBox.TabIndex = 39;
            this.educationnote2_TextBox.Enter += new System.EventHandler(this.educationnote2_TextBox_Enter);
            this.educationnote2_TextBox.Leave += new System.EventHandler(this.educationnote2_TextBox_Leave);
            // 
            // educationtype_id_1_comboBox
            // 
            this.educationtype_id_1_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.educationtype_id_1_comboBox.FormattingEnabled = true;
            this.educationtype_id_1_comboBox.Location = new System.Drawing.Point(4, 46);
            this.educationtype_id_1_comboBox.Name = "educationtype_id_1_comboBox";
            this.educationtype_id_1_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.educationtype_id_1_comboBox.Size = new System.Drawing.Size(263, 32);
            this.educationtype_id_1_comboBox.TabIndex = 37;
            this.educationtype_id_1_comboBox.SelectionChangeCommitted += new System.EventHandler(this.educationtype_id_1_comboBox_SelectionChangeCommitted);
            // 
            // materialLabel2
            // 
            this.materialLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(811, 1);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel2.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel2.Size = new System.Drawing.Size(269, 41);
            this.materialLabel2.TabIndex = 127;
            this.materialLabel2.Text = "الدراسة";
            this.materialLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel7
            // 
            this.materialLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(541, 1);
            this.materialLabel7.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel7.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel7.Size = new System.Drawing.Size(269, 41);
            this.materialLabel7.TabIndex = 126;
            this.materialLabel7.Text = "اسم المدرسة / الجامعة";
            this.materialLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel10
            // 
            this.materialLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(271, 1);
            this.materialLabel10.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel10.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel10.Size = new System.Drawing.Size(269, 41);
            this.materialLabel10.TabIndex = 128;
            this.materialLabel10.Text = "التحصيل العلمي";
            this.materialLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel17
            // 
            this.materialLabel17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel17.AutoSize = true;
            this.materialLabel17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel17.Depth = 0;
            this.materialLabel17.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel17.Location = new System.Drawing.Point(1081, 1);
            this.materialLabel17.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel17.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel17.Name = "materialLabel17";
            this.materialLabel17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel17.Size = new System.Drawing.Size(108, 41);
            this.materialLabel17.TabIndex = 129;
            this.materialLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel40
            // 
            this.materialLabel40.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel40.AutoSize = true;
            this.materialLabel40.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel40.Depth = 0;
            this.materialLabel40.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel40.Location = new System.Drawing.Point(1081, 43);
            this.materialLabel40.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel40.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel40.Name = "materialLabel40";
            this.materialLabel40.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel40.Size = new System.Drawing.Size(108, 41);
            this.materialLabel40.TabIndex = 131;
            this.materialLabel40.Text = "1";
            this.materialLabel40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel42
            // 
            this.materialLabel42.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel42.AutoSize = true;
            this.materialLabel42.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel42.Depth = 0;
            this.materialLabel42.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel42.Location = new System.Drawing.Point(1081, 85);
            this.materialLabel42.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel42.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel42.Name = "materialLabel42";
            this.materialLabel42.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel42.Size = new System.Drawing.Size(108, 43);
            this.materialLabel42.TabIndex = 132;
            this.materialLabel42.Text = "2";
            this.materialLabel42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // education_id_1_comboBox
            // 
            this.education_id_1_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.education_id_1_comboBox.DropDownWidth = 309;
            this.education_id_1_comboBox.FormattingEnabled = true;
            this.education_id_1_comboBox.Location = new System.Drawing.Point(814, 46);
            this.education_id_1_comboBox.Name = "education_id_1_comboBox";
            this.education_id_1_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.education_id_1_comboBox.Size = new System.Drawing.Size(263, 32);
            this.education_id_1_comboBox.TabIndex = 34;
            this.education_id_1_comboBox.SelectionChangeCommitted += new System.EventHandler(this.education_id_1_comboBox_SelectionChangeCommitted);
            // 
            // education_id_2_comboBox
            // 
            this.education_id_2_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.education_id_2_comboBox.DropDownWidth = 309;
            this.education_id_2_comboBox.FormattingEnabled = true;
            this.education_id_2_comboBox.Location = new System.Drawing.Point(814, 88);
            this.education_id_2_comboBox.Name = "education_id_2_comboBox";
            this.education_id_2_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.education_id_2_comboBox.Size = new System.Drawing.Size(263, 32);
            this.education_id_2_comboBox.TabIndex = 38;
            this.education_id_2_comboBox.SelectionChangeCommitted += new System.EventHandler(this.education_id_2_comboBox_SelectionChangeCommitted);
            // 
            // educationfield_id_1_comboBox
            // 
            this.educationfield_id_1_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.educationfield_id_1_comboBox.DropDownWidth = 309;
            this.educationfield_id_1_comboBox.FormattingEnabled = true;
            this.educationfield_id_1_comboBox.Location = new System.Drawing.Point(274, 46);
            this.educationfield_id_1_comboBox.Name = "educationfield_id_1_comboBox";
            this.educationfield_id_1_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.educationfield_id_1_comboBox.Size = new System.Drawing.Size(263, 32);
            this.educationfield_id_1_comboBox.TabIndex = 36;
            this.educationfield_id_1_comboBox.SelectionChangeCommitted += new System.EventHandler(this.educationfield_id_1_comboBox_SelectionChangeCommitted);
            // 
            // educationfield_id_2_comboBox
            // 
            this.educationfield_id_2_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.educationfield_id_2_comboBox.DropDownWidth = 309;
            this.educationfield_id_2_comboBox.FormattingEnabled = true;
            this.educationfield_id_2_comboBox.Location = new System.Drawing.Point(274, 88);
            this.educationfield_id_2_comboBox.Name = "educationfield_id_2_comboBox";
            this.educationfield_id_2_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.educationfield_id_2_comboBox.Size = new System.Drawing.Size(263, 32);
            this.educationfield_id_2_comboBox.TabIndex = 40;
            this.educationfield_id_2_comboBox.SelectionChangeCommitted += new System.EventHandler(this.educationfield_id_2_comboBox_SelectionChangeCommitted);
            // 
            // educationtype_id_2_comboBox
            // 
            this.educationtype_id_2_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.educationtype_id_2_comboBox.FormattingEnabled = true;
            this.educationtype_id_2_comboBox.Location = new System.Drawing.Point(4, 88);
            this.educationtype_id_2_comboBox.Name = "educationtype_id_2_comboBox";
            this.educationtype_id_2_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.educationtype_id_2_comboBox.Size = new System.Drawing.Size(263, 32);
            this.educationtype_id_2_comboBox.TabIndex = 41;
            this.educationtype_id_2_comboBox.SelectionChangeCommitted += new System.EventHandler(this.educationtype_id_2_comboBox_SelectionChangeCommitted);
            // 
            // educationnote_TextBox
            // 
            this.educationnote_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.educationnote_TextBox.Location = new System.Drawing.Point(544, 46);
            this.educationnote_TextBox.Name = "educationnote_TextBox";
            this.educationnote_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.educationnote_TextBox.Size = new System.Drawing.Size(263, 28);
            this.educationnote_TextBox.TabIndex = 35;
            this.educationnote_TextBox.Enter += new System.EventHandler(this.educationnote_TextBox_Enter);
            this.educationnote_TextBox.Leave += new System.EventHandler(this.educationnote_TextBox_Leave);
            // 
            // materialLabel12
            // 
            this.materialLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(1, 1);
            this.materialLabel12.Margin = new System.Windows.Forms.Padding(0);
            this.materialLabel12.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel12.Size = new System.Drawing.Size(269, 41);
            this.materialLabel12.TabIndex = 130;
            this.materialLabel12.Text = "نوع المدرسة / الجامعة";
            this.materialLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.FirstLayoutPanel.SetColumnSpan(this.panel1, 10);
            this.panel1.Controls.Add(this.InfoLable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(23, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1190, 39);
            this.panel1.TabIndex = 254;
            // 
            // InfoLable
            // 
            this.InfoLable.Depth = 0;
            this.InfoLable.Dock = System.Windows.Forms.DockStyle.Right;
            this.InfoLable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoLable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.InfoLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.InfoLable.Location = new System.Drawing.Point(1031, 0);
            this.InfoLable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.InfoLable.Name = "InfoLable";
            this.InfoLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.InfoLable.Size = new System.Drawing.Size(159, 39);
            this.InfoLable.TabIndex = 3;
            this.InfoLable.Text = "معلومات الشخص";
            this.InfoLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.FirstLayoutPanel.SetColumnSpan(this.panel2, 10);
            this.panel2.Controls.Add(this.InfoInsideFamilyLable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(23, 453);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1190, 39);
            this.panel2.TabIndex = 255;
            // 
            // InfoInsideFamilyLable
            // 
            this.InfoInsideFamilyLable.Depth = 0;
            this.InfoInsideFamilyLable.Dock = System.Windows.Forms.DockStyle.Right;
            this.InfoInsideFamilyLable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.InfoInsideFamilyLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.InfoInsideFamilyLable.Location = new System.Drawing.Point(836, 0);
            this.InfoInsideFamilyLable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.InfoInsideFamilyLable.Name = "InfoInsideFamilyLable";
            this.InfoInsideFamilyLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.InfoInsideFamilyLable.Size = new System.Drawing.Size(354, 39);
            this.InfoInsideFamilyLable.TabIndex = 4;
            this.InfoInsideFamilyLable.Text = "معلومات الشخص ضمن العائلة:";
            this.InfoInsideFamilyLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel19
            // 
            this.materialLabel19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel19.AutoSize = true;
            this.materialLabel19.Depth = 0;
            this.materialLabel19.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel19.Location = new System.Drawing.Point(1081, 774);
            this.materialLabel19.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel19.Name = "materialLabel19";
            this.materialLabel19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel19.Size = new System.Drawing.Size(104, 26);
            this.materialLabel19.TabIndex = 75;
            this.materialLabel19.Text = "هل  متعلم؟";
            // 
            // IsEducated_LayoutPanel
            // 
            this.IsEducated_LayoutPanel.ColumnCount = 2;
            this.FirstLayoutPanel.SetColumnSpan(this.IsEducated_LayoutPanel, 2);
            this.IsEducated_LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.IsEducated_LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.IsEducated_LayoutPanel.Controls.Add(this.Educated_RadioButton, 1, 0);
            this.IsEducated_LayoutPanel.Controls.Add(this.NotEducated_RadioButton, 0, 0);
            this.IsEducated_LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IsEducated_LayoutPanel.Location = new System.Drawing.Point(870, 768);
            this.IsEducated_LayoutPanel.Name = "IsEducated_LayoutPanel";
            this.IsEducated_LayoutPanel.RowCount = 1;
            this.IsEducated_LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IsEducated_LayoutPanel.Size = new System.Drawing.Size(205, 39);
            this.IsEducated_LayoutPanel.TabIndex = 30;
            // 
            // Educated_RadioButton
            // 
            this.Educated_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Educated_RadioButton.AutoSize = true;
            this.Educated_RadioButton.Depth = 0;
            this.Educated_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.Educated_RadioButton.Location = new System.Drawing.Point(144, 4);
            this.Educated_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.Educated_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Educated_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.Educated_RadioButton.Name = "Educated_RadioButton";
            this.Educated_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Educated_RadioButton.Ripple = true;
            this.Educated_RadioButton.Size = new System.Drawing.Size(61, 30);
            this.Educated_RadioButton.TabIndex = 31;
            this.Educated_RadioButton.TabStop = true;
            this.Educated_RadioButton.Text = "نعم";
            this.Educated_RadioButton.UseVisualStyleBackColor = true;
            this.Educated_RadioButton.CheckedChanged += new System.EventHandler(this.Educated_RadioButton_CheckedChanged);
            // 
            // NotEducated_RadioButton
            // 
            this.NotEducated_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NotEducated_RadioButton.AutoSize = true;
            this.NotEducated_RadioButton.Depth = 0;
            this.NotEducated_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.NotEducated_RadioButton.Location = new System.Drawing.Point(60, 4);
            this.NotEducated_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.NotEducated_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.NotEducated_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.NotEducated_RadioButton.Name = "NotEducated_RadioButton";
            this.NotEducated_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NotEducated_RadioButton.Ripple = true;
            this.NotEducated_RadioButton.Size = new System.Drawing.Size(42, 30);
            this.NotEducated_RadioButton.TabIndex = 32;
            this.NotEducated_RadioButton.TabStop = true;
            this.NotEducated_RadioButton.Text = "لا";
            this.NotEducated_RadioButton.UseVisualStyleBackColor = true;
            this.NotEducated_RadioButton.CheckedChanged += new System.EventHandler(this.NotEducated_RadioButton_CheckedChanged);
            // 
            // AidAmount_29_Textbox
            // 
            this.FirstLayoutPanel.SetColumnSpan(this.AidAmount_29_Textbox, 2);
            this.AidAmount_29_Textbox.Depth = 0;
            this.AidAmount_29_Textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AidAmount_29_Textbox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.AidAmount_29_Textbox.Hint = "";
            this.AidAmount_29_Textbox.Location = new System.Drawing.Point(515, 678);
            this.AidAmount_29_Textbox.MaxLength = 32767;
            this.AidAmount_29_Textbox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.AidAmount_29_Textbox.Name = "AidAmount_29_Textbox";
            this.AidAmount_29_Textbox.PasswordChar = '\0';
            this.AidAmount_29_Textbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AidAmount_29_Textbox.SelectedText = "";
            this.AidAmount_29_Textbox.SelectionLength = 0;
            this.AidAmount_29_Textbox.SelectionStart = 0;
            this.AidAmount_29_Textbox.Size = new System.Drawing.Size(170, 31);
            this.AidAmount_29_Textbox.TabIndex = 27;
            this.AidAmount_29_Textbox.TabStop = false;
            this.AidAmount_29_Textbox.UseSystemPasswordChar = false;
            this.AidAmount_29_Textbox.Enter += new System.EventHandler(this.AidAmount_29_Textbox_Enter);
            this.AidAmount_29_Textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AidAmount_29_Textbox_KeyPress);
            this.AidAmount_29_Textbox.Leave += new System.EventHandler(this.AidAmount_29_Textbox_Leave);
            // 
            // AidPeriod_29_comboBox
            // 
            this.AidPeriod_29_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.AidPeriod_29_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.AidPeriod_29_comboBox.BackColor = System.Drawing.Color.White;
            this.FirstLayoutPanel.SetColumnSpan(this.AidPeriod_29_comboBox, 2);
            this.AidPeriod_29_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AidPeriod_29_comboBox.Font = new System.Drawing.Font("Janna LT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AidPeriod_29_comboBox.FormattingEnabled = true;
            this.AidPeriod_29_comboBox.Location = new System.Drawing.Point(173, 678);
            this.AidPeriod_29_comboBox.Name = "AidPeriod_29_comboBox";
            this.AidPeriod_29_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AidPeriod_29_comboBox.Size = new System.Drawing.Size(184, 41);
            this.AidPeriod_29_comboBox.TabIndex = 28;
            this.AidPeriod_29_comboBox.SelectionChangeCommitted += new System.EventHandler(this.AidPeriod_29_comboBox_SelectionChangeCommitted);
            // 
            // isAid_Panel
            // 
            this.isAid_Panel.ColumnCount = 2;
            this.FirstLayoutPanel.SetColumnSpan(this.isAid_Panel, 2);
            this.isAid_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.isAid_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.isAid_Panel.Controls.Add(this.aidsource_29_Yes_RadioButton, 1, 0);
            this.isAid_Panel.Controls.Add(this.aidsource_29_No_RadioButton, 0, 0);
            this.isAid_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.isAid_Panel.Font = new System.Drawing.Font("Janna LT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isAid_Panel.Location = new System.Drawing.Point(870, 678);
            this.isAid_Panel.Name = "isAid_Panel";
            this.isAid_Panel.RowCount = 1;
            this.isAid_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.isAid_Panel.Size = new System.Drawing.Size(205, 39);
            this.isAid_Panel.TabIndex = 25;
            // 
            // aidsource_29_Yes_RadioButton
            // 
            this.aidsource_29_Yes_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.aidsource_29_Yes_RadioButton.AutoSize = true;
            this.aidsource_29_Yes_RadioButton.Depth = 0;
            this.aidsource_29_Yes_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.aidsource_29_Yes_RadioButton.Location = new System.Drawing.Point(144, 4);
            this.aidsource_29_Yes_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.aidsource_29_Yes_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.aidsource_29_Yes_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.aidsource_29_Yes_RadioButton.Name = "aidsource_29_Yes_RadioButton";
            this.aidsource_29_Yes_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidsource_29_Yes_RadioButton.Ripple = true;
            this.aidsource_29_Yes_RadioButton.Size = new System.Drawing.Size(61, 30);
            this.aidsource_29_Yes_RadioButton.TabIndex = 25;
            this.aidsource_29_Yes_RadioButton.TabStop = true;
            this.aidsource_29_Yes_RadioButton.Text = "نعم";
            this.aidsource_29_Yes_RadioButton.UseVisualStyleBackColor = true;
            this.aidsource_29_Yes_RadioButton.CheckedChanged += new System.EventHandler(this.aidsource_29_Yes_RadioButton_CheckedChanged);
            // 
            // aidsource_29_No_RadioButton
            // 
            this.aidsource_29_No_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.aidsource_29_No_RadioButton.AutoSize = true;
            this.aidsource_29_No_RadioButton.Depth = 0;
            this.aidsource_29_No_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.aidsource_29_No_RadioButton.Location = new System.Drawing.Point(60, 4);
            this.aidsource_29_No_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.aidsource_29_No_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.aidsource_29_No_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.aidsource_29_No_RadioButton.Name = "aidsource_29_No_RadioButton";
            this.aidsource_29_No_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.aidsource_29_No_RadioButton.Ripple = true;
            this.aidsource_29_No_RadioButton.Size = new System.Drawing.Size(42, 30);
            this.aidsource_29_No_RadioButton.TabIndex = 26;
            this.aidsource_29_No_RadioButton.TabStop = true;
            this.aidsource_29_No_RadioButton.Text = "لا";
            this.aidsource_29_No_RadioButton.UseVisualStyleBackColor = true;
            this.aidsource_29_No_RadioButton.CheckedChanged += new System.EventHandler(this.aidsource_29_No_RadioButton_CheckedChanged);
            // 
            // AidNote_29_Textbox
            // 
            this.FirstLayoutPanel.SetColumnSpan(this.AidNote_29_Textbox, 2);
            this.AidNote_29_Textbox.Depth = 0;
            this.AidNote_29_Textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AidNote_29_Textbox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.AidNote_29_Textbox.Hint = "";
            this.AidNote_29_Textbox.Location = new System.Drawing.Point(870, 723);
            this.AidNote_29_Textbox.MaxLength = 32767;
            this.AidNote_29_Textbox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.AidNote_29_Textbox.Name = "AidNote_29_Textbox";
            this.AidNote_29_Textbox.PasswordChar = '\0';
            this.AidNote_29_Textbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AidNote_29_Textbox.SelectedText = "";
            this.AidNote_29_Textbox.SelectionLength = 0;
            this.AidNote_29_Textbox.SelectionStart = 0;
            this.AidNote_29_Textbox.Size = new System.Drawing.Size(205, 31);
            this.AidNote_29_Textbox.TabIndex = 29;
            this.AidNote_29_Textbox.TabStop = false;
            this.AidNote_29_Textbox.UseSystemPasswordChar = false;
            this.AidNote_29_Textbox.Enter += new System.EventHandler(this.AidNote_29_Textbox_Enter);
            this.AidNote_29_Textbox.Leave += new System.EventHandler(this.AidNote_29_Textbox_Leave);
            // 
            // materialLabel5
            // 
            this.materialLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(1081, 1054);
            this.materialLabel5.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel5.Size = new System.Drawing.Size(132, 26);
            this.materialLabel5.TabIndex = 105;
            this.materialLabel5.Text = "ملاحظات الفرد:";
            // 
            // visitLabel
            // 
            this.visitLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.visitLabel.AutoSize = true;
            this.visitLabel.Depth = 0;
            this.visitLabel.Font = new System.Drawing.Font("Tajawal", 11F);
            this.visitLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visitLabel.Location = new System.Drawing.Point(691, 54);
            this.visitLabel.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.visitLabel.Name = "visitLabel";
            this.visitLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.visitLabel.Size = new System.Drawing.Size(57, 26);
            this.visitLabel.TabIndex = 77;
            this.visitLabel.Text = "الزيارة";
            // 
            // visit_TextBox
            // 
            this.visit_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstLayoutPanel.SetColumnSpan(this.visit_TextBox, 2);
            this.visit_TextBox.Depth = 0;
            this.visit_TextBox.Enabled = false;
            this.visit_TextBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.visit_TextBox.Hint = "";
            this.visit_TextBox.Location = new System.Drawing.Point(515, 52);
            this.visit_TextBox.MaxLength = 32767;
            this.visit_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.visit_TextBox.Name = "visit_TextBox";
            this.visit_TextBox.PasswordChar = '\0';
            this.visit_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.visit_TextBox.SelectedText = "";
            this.visit_TextBox.SelectionLength = 0;
            this.visit_TextBox.SelectionStart = 0;
            this.visit_TextBox.Size = new System.Drawing.Size(170, 31);
            this.visit_TextBox.TabIndex = 2;
            this.visit_TextBox.TabStop = false;
            this.visit_TextBox.UseSystemPasswordChar = false;
            // 
            // State_Label
            // 
            this.State_Label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.State_Label.AutoSize = true;
            this.FirstLayoutPanel.SetColumnSpan(this.State_Label, 2);
            this.State_Label.Depth = 0;
            this.State_Label.Font = new System.Drawing.Font("Tajawal", 11F);
            this.State_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.State_Label.Location = new System.Drawing.Point(261, 54);
            this.State_Label.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.State_Label.Name = "State_Label";
            this.State_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.State_Label.Size = new System.Drawing.Size(121, 26);
            this.State_Label.TabIndex = 76;
            this.State_Label.Text = "حالة الشخص:";
            // 
            // State_TextBox
            // 
            this.State_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.State_TextBox.Depth = 0;
            this.State_TextBox.Enabled = false;
            this.State_TextBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.State_TextBox.Hint = "";
            this.State_TextBox.Location = new System.Drawing.Point(173, 52);
            this.State_TextBox.MaxLength = 32767;
            this.State_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.State_TextBox.Name = "State_TextBox";
            this.State_TextBox.PasswordChar = '\0';
            this.State_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.State_TextBox.SelectedText = "";
            this.State_TextBox.SelectionLength = 0;
            this.State_TextBox.SelectionStart = 0;
            this.State_TextBox.Size = new System.Drawing.Size(82, 31);
            this.State_TextBox.TabIndex = 3;
            this.State_TextBox.TabStop = false;
            this.State_TextBox.UseSystemPasswordChar = false;
            // 
            // SavePerson_Button
            // 
            this.SavePerson_Button.BackColor = System.Drawing.Color.Transparent;
            this.SavePerson_Button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.SavePerson_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FirstLayoutPanel.SetColumnSpan(this.SavePerson_Button, 2);
            this.SavePerson_Button.FlatAppearance.BorderSize = 0;
            this.SavePerson_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SavePerson_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SavePerson_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SavePerson_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SavePerson_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.SavePerson_Button.Location = new System.Drawing.Point(622, 1128);
            this.SavePerson_Button.MaximumSize = new System.Drawing.Size(102, 42);
            this.SavePerson_Button.MinimumSize = new System.Drawing.Size(102, 42);
            this.SavePerson_Button.Name = "SavePerson_Button";
            this.SavePerson_Button.Size = new System.Drawing.Size(102, 42);
            this.SavePerson_Button.TabIndex = 43;
            this.SavePerson_Button.Text = "SAVE";
            this.SavePerson_Button.UseVisualStyleBackColor = false;
            this.SavePerson_Button.Click += new System.EventHandler(this.SavePerson_Button_Click);
            this.SavePerson_Button.MouseEnter += new System.EventHandler(this.SavePerson_Button_MouseEnter);
            this.SavePerson_Button.MouseLeave += new System.EventHandler(this.SavePerson_Button_MouseLeave);
            // 
            // UpdatePerson_Button
            // 
            this.UpdatePerson_Button.BackColor = System.Drawing.Color.Transparent;
            this.UpdatePerson_Button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.UpdatePerson_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UpdatePerson_Button.FlatAppearance.BorderSize = 0;
            this.UpdatePerson_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.UpdatePerson_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.UpdatePerson_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdatePerson_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePerson_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.UpdatePerson_Button.Location = new System.Drawing.Point(691, 1173);
            this.UpdatePerson_Button.MaximumSize = new System.Drawing.Size(102, 42);
            this.UpdatePerson_Button.MinimumSize = new System.Drawing.Size(102, 42);
            this.UpdatePerson_Button.Name = "UpdatePerson_Button";
            this.UpdatePerson_Button.Size = new System.Drawing.Size(102, 42);
            this.UpdatePerson_Button.TabIndex = 44;
            this.UpdatePerson_Button.Text = "UPDATE";
            this.UpdatePerson_Button.UseVisualStyleBackColor = false;
            this.UpdatePerson_Button.Visible = false;
            this.UpdatePerson_Button.Click += new System.EventHandler(this.UpdatePerson_Button_Click);
            this.UpdatePerson_Button.MouseEnter += new System.EventHandler(this.UpdatePerson_Button_MouseEnter);
            this.UpdatePerson_Button.MouseLeave += new System.EventHandler(this.UpdatePerson_Button_MouseLeave);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::F2F_Application.Properties.Resources.button2;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.button3.Location = new System.Drawing.Point(173, 948);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(12, 1);
            this.button3.TabIndex = 35;
            this.button3.Text = "تاريخ الحالة";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // StateHistory_Button
            // 
            this.StateHistory_Button.BackColor = System.Drawing.Color.Transparent;
            this.StateHistory_Button.BackgroundImage = global::F2F_Application.Properties.Resources.button2;
            this.StateHistory_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StateHistory_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StateHistory_Button.FlatAppearance.BorderSize = 0;
            this.StateHistory_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.StateHistory_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.StateHistory_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StateHistory_Button.Font = new System.Drawing.Font("Janna LT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StateHistory_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.StateHistory_Button.Location = new System.Drawing.Point(23, 588);
            this.StateHistory_Button.Name = "StateHistory_Button";
            this.StateHistory_Button.Size = new System.Drawing.Size(144, 39);
            this.StateHistory_Button.TabIndex = 24;
            this.StateHistory_Button.Text = "تاريخ الحالة";
            this.StateHistory_Button.UseVisualStyleBackColor = false;
            this.StateHistory_Button.Click += new System.EventHandler(this.StateHistory_Button_Click);
            // 
            // MaritalHistory_Button
            // 
            this.MaritalHistory_Button.BackColor = System.Drawing.Color.Transparent;
            this.MaritalHistory_Button.BackgroundImage = global::F2F_Application.Properties.Resources.button2;
            this.MaritalHistory_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MaritalHistory_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaritalHistory_Button.FlatAppearance.BorderSize = 0;
            this.MaritalHistory_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.MaritalHistory_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.MaritalHistory_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaritalHistory_Button.Font = new System.Drawing.Font("Janna LT", 8F, System.Drawing.FontStyle.Bold);
            this.MaritalHistory_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.MaritalHistory_Button.Location = new System.Drawing.Point(23, 543);
            this.MaritalHistory_Button.Name = "MaritalHistory_Button";
            this.MaritalHistory_Button.Size = new System.Drawing.Size(144, 39);
            this.MaritalHistory_Button.TabIndex = 20;
            this.MaritalHistory_Button.Text = "تاريخ الحالة الاجتماعية";
            this.MaritalHistory_Button.UseVisualStyleBackColor = false;
            this.MaritalHistory_Button.Click += new System.EventHandler(this.MaritalHistory_Button_Click);
            // 
            // AidNote_29_Lable
            // 
            this.AidNote_29_Lable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AidNote_29_Lable.AutoSize = true;
            this.AidNote_29_Lable.Depth = 0;
            this.AidNote_29_Lable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.AidNote_29_Lable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AidNote_29_Lable.Location = new System.Drawing.Point(1081, 729);
            this.AidNote_29_Lable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.AidNote_29_Lable.Name = "AidNote_29_Lable";
            this.AidNote_29_Lable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AidNote_29_Lable.Size = new System.Drawing.Size(69, 26);
            this.AidNote_29_Lable.TabIndex = 23;
            this.AidNote_29_Lable.Text = "السبب:";
            // 
            // isAid_Lable
            // 
            this.isAid_Lable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.isAid_Lable.AutoSize = true;
            this.isAid_Lable.Depth = 0;
            this.isAid_Lable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.isAid_Lable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.isAid_Lable.Location = new System.Drawing.Point(1081, 675);
            this.isAid_Lable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.isAid_Lable.Name = "isAid_Lable";
            this.isAid_Lable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isAid_Lable.Size = new System.Drawing.Size(87, 45);
            this.isAid_Lable.TabIndex = 132;
            this.isAid_Lable.Text = "هل يقدم مساعدة؟";
            // 
            // isAidAmount_Lable
            // 
            this.isAidAmount_Lable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.isAidAmount_Lable.AutoSize = true;
            this.isAidAmount_Lable.Depth = 0;
            this.isAidAmount_Lable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.isAidAmount_Lable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.isAidAmount_Lable.Location = new System.Drawing.Point(691, 684);
            this.isAidAmount_Lable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.isAidAmount_Lable.Name = "isAidAmount_Lable";
            this.isAidAmount_Lable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isAidAmount_Lable.Size = new System.Drawing.Size(137, 26);
            this.isAidAmount_Lable.TabIndex = 25;
            this.isAidAmount_Lable.Text = "قيمة المساعدة:";
            // 
            // isAidPeriod_Lable
            // 
            this.isAidPeriod_Lable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.isAidPeriod_Lable.AutoSize = true;
            this.isAidPeriod_Lable.Depth = 0;
            this.isAidPeriod_Lable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.isAidPeriod_Lable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.isAidPeriod_Lable.Location = new System.Drawing.Point(363, 684);
            this.isAidPeriod_Lable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.isAidPeriod_Lable.Name = "isAidPeriod_Lable";
            this.isAidPeriod_Lable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isAidPeriod_Lable.Size = new System.Drawing.Size(130, 26);
            this.isAidPeriod_Lable.TabIndex = 24;
            this.isAidPeriod_Lable.Text = "مدة المساعدة:";
            // 
            // StateAddress_Lable
            // 
            this.StateAddress_Lable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StateAddress_Lable.AutoSize = true;
            this.StateAddress_Lable.Depth = 0;
            this.StateAddress_Lable.Font = new System.Drawing.Font("Tajawal", 11F);
            this.StateAddress_Lable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StateAddress_Lable.Location = new System.Drawing.Point(1081, 639);
            this.StateAddress_Lable.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.StateAddress_Lable.Name = "StateAddress_Lable";
            this.StateAddress_Lable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StateAddress_Lable.Size = new System.Drawing.Size(115, 26);
            this.StateAddress_Lable.TabIndex = 23;
            this.StateAddress_Lable.Text = "مكان الإقامة:";
            // 
            // StateAddress_ComboBox
            // 
            this.StateAddress_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.StateAddress_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.StateAddress_ComboBox.BackColor = System.Drawing.Color.White;
            this.FirstLayoutPanel.SetColumnSpan(this.StateAddress_ComboBox, 2);
            this.StateAddress_ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StateAddress_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.StateAddress_ComboBox.Font = new System.Drawing.Font("Janna LT", 10.8F);
            this.StateAddress_ComboBox.FormattingEnabled = true;
            this.StateAddress_ComboBox.Location = new System.Drawing.Point(870, 633);
            this.StateAddress_ComboBox.Name = "StateAddress_ComboBox";
            this.StateAddress_ComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StateAddress_ComboBox.Size = new System.Drawing.Size(205, 42);
            this.StateAddress_ComboBox.TabIndex = 256;
            this.StateAddress_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.StateAddress_ComboBox_DrawItem);
            this.StateAddress_ComboBox.SelectionChangeCommitted += new System.EventHandler(this.StateAddress_ComboBox_SelectionChangeCommitted);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::F2F_Application.Properties.Resources.BackGround;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(1, 29733);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(0, 206);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // Person_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.PersonPanel);
            this.Controls.Add(this.pictureBox4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Person_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Person_Form_FormClosing);
            this.Load += new System.EventHandler(this.Person_Form_Load);
            this.Shown += new System.EventHandler(this.Person_Form_Shown);
            this.Enter += new System.EventHandler(this.Person_Form_Enter);
            this.materialContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MEFamily_DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.PersonPanel.ResumeLayout(false);
            this.SecondTableLayoutPanel.ResumeLayout(false);
            this.SecondTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Disease_DataGridView)).EndInit();
            this.panel8.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.aid10_military_tableLayoutPanel.ResumeLayout(false);
            this.aid10_military_tableLayoutPanel.PerformLayout();
            this.militaryPanel.ResumeLayout(false);
            this.militaryPanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.hasdisease_tableLayoutPanel.ResumeLayout(false);
            this.hasdisease_tableLayoutPanel.PerformLayout();
            this.haswork_tableLayoutPanel.ResumeLayout(false);
            this.haswork_tableLayoutPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WorkExp_DataGridView)).EndInit();
            this.has_mp_tableLayoutPanel.ResumeLayout(false);
            this.has_mp_tableLayoutPanel.PerformLayout();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MP_DataGridView)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.IsStudent_tableLayoutPanel.ResumeLayout(false);
            this.IsStudent_tableLayoutPanel.PerformLayout();
            this.studentPanel.ResumeLayout(false);
            this.studentPanel.PerformLayout();
            this.student1Panel.ResumeLayout(false);
            this.student1Panel.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.MELayoutPanel.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.FirstLayoutPanel.ResumeLayout(false);
            this.FirstLayoutPanel.PerformLayout();
            this.Receiver_LayoutPanel.ResumeLayout(false);
            this.Receiver_LayoutPanel.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.educatedPanel.ResumeLayout(false);
            this.educatedPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.IsEducated_LayoutPanel.ResumeLayout(false);
            this.IsEducated_LayoutPanel.PerformLayout();
            this.isAid_Panel.ResumeLayout(false);
            this.isAid_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkinPlus.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newPersonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showFamilyToolStripMenuItem1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Panel PersonPanel;
        private TableLayoutPanel SecondTableLayoutPanel;
        private Button UpdatePerson_Button;
        private Button SavePerson_Button;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField visit_TextBox;
        private MaterialSkinPlus.Controls.MaterialLabel visitLabel;
        private TableLayoutPanel tableLayoutPanel9;
        private MaterialSkinPlus.Controls.MaterialRadioButton haswork_No_RadioButton;
        private MaterialSkinPlus.Controls.MaterialRadioButton haswork_Yes_RadioButton;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel43;
        private TableLayoutPanel hasdisease_tableLayoutPanel;
        private MaterialSkinPlus.Controls.MaterialRadioButton hasdisease_Yes_RadioButton;
        private MaterialSkinPlus.Controls.MaterialRadioButton hasdisease_No_RadioButton;
        private TableLayoutPanel Receiver_LayoutPanel;
        private MaterialSkinPlus.Controls.MaterialRadioButton Receiver_RadioButton;
        private MaterialSkinPlus.Controls.MaterialRadioButton NotReceiver_RadioButton;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField NationalityNumber_TextBox;
        private DateTimePicker dateTimePicker1;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField LastName_TextBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField FatherName_TextBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField FirstName_TextBox;
        private ComboBox Nationality_ComboBox;
        private ComboBox Sex_ComboBox;
        private Panel panel7;
        private MaterialSkinPlus.Controls.MaterialLabel ExpensesLable;
        private TableLayoutPanel tableLayoutPanel3;
        private ComboBox expensestype_24_comboBox;
        private ComboBox expensestype_5_comboBox;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel161;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel23;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel24;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel25;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel26;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel27;
        private ComboBox expensestype_9_comboBox;
        private ComboBox expensestype_4_comboBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField expenses_amount_9_TextBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField expenses_amount_4_TextBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField expenses_amount_5_TextBox;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel62;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField expenses_amount_24_TextBox;
        private TableLayoutPanel isAid_Panel;
        private MaterialSkinPlus.Controls.MaterialRadioButton aidsource_29_Yes_RadioButton;
        private MaterialSkinPlus.Controls.MaterialRadioButton aidsource_29_No_RadioButton;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialSkinPlus.Controls.MaterialRadioButton materialRadioButton2;
        private MaterialSkinPlus.Controls.MaterialRadioButton materialRadioButton1;
        private MaterialSkinPlus.Controls.MaterialLabel isAid_Lable;
        private MaterialSkinPlus.Controls.MaterialLabel StateAddress_Lable;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField Stateyear_TextBox;
        private MaterialSkinPlus.Controls.MaterialLabel StateYear_Lable;
        private MaterialSkinPlus.Controls.MaterialLabel isAidAmount_Lable;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField AidAmount_29_Textbox;
        private MaterialSkinPlus.Controls.MaterialLabel isAidPeriod_Lable;
        private ComboBox AidPeriod_29_comboBox;
        private MaterialSkinPlus.Controls.MaterialLabel AidNote_29_Lable;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField AidNote_29_Textbox;
        private Panel panel5;
        private MaterialSkinPlus.Controls.MaterialLabel IllnessLable;
        private DataGridView Disease_DataGridView;
        private Panel panel8;
        private MaterialSkinPlus.Controls.MaterialLabel AidLable;
        private TableLayoutPanel tableLayoutPanel4;
        private ComboBox aidperiod_8_comboBox;
        private ComboBox aidperiod_13_comboBox;
        private ComboBox aidperiod_21_comboBox;
        private ComboBox aidperiod_1_comboBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField aid_amount_21_TextBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField aid_amount_1_TextBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField aid_amount_13_TextBox;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel22;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel28;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel29;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel33;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel30;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel31;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel34;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel35;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel32;
        private ComboBox aidperiod_6_comboBox;
        private ComboBox aidsource_21_comboBox;
        private ComboBox aidsource_6_comboBox;
        private ComboBox aidsource_8_comboBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField aid_amount_6_TextBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField aid_amount_8_TextBox;
        private ComboBox aidsource_1_comboBox;
        private ComboBox aidsource_13_comboBox;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel36;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel37;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel39;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel38;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField operation_name_2_TextBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField operation_name_1_TextBox;
        private TableLayoutPanel tableLayoutPanel5;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel41;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField operation_value_2_TextBox;
        private TableLayoutPanel tableLayoutPanel6;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel1;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField operation_value_1_TextBox;
        private Panel panel3;
        private MaterialSkinPlus.Controls.MaterialLabel WorkLable;
        private DataGridView WorkExp_DataGridView;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel51;
        private TableLayoutPanel tableLayoutPanel8;
        private MaterialSkinPlus.Controls.MaterialRadioButton mp_No_RadioButton;
        private MaterialSkinPlus.Controls.MaterialRadioButton mp_Yes_RadioButton;
        private Panel panel9;
        private MaterialSkinPlus.Controls.MaterialLabel MPLable;
        private DataGridView MP_DataGridView;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel64;
        private TableLayoutPanel aid10_military_tableLayoutPanel;
        private MaterialSkinPlus.Controls.MaterialRadioButton aid_No_10_RadioButton;
        private MaterialSkinPlus.Controls.MaterialRadioButton aid_Yes_10_RadioButton;
        private TableLayoutPanel militaryPanel;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel65;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel67;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel66;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField aid_amount_10_TextBox;
        private ComboBox aidsource_10_comboBox;
        private ComboBox aidperiod_10_comboBox;
        private Panel panel4;
        private PictureBox pictureBox2;
        private MaterialSkinPlus.Controls.MaterialLabel StudyLable;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel19;
        private TableLayoutPanel IsEducated_LayoutPanel;
        private MaterialSkinPlus.Controls.MaterialRadioButton NotEducated_RadioButton;
        private MaterialSkinPlus.Controls.MaterialRadioButton Educated_RadioButton;
        private TableLayoutPanel educatedPanel;
        private TextBox educationnote2_TextBox;
        private ComboBox educationtype_id_1_comboBox;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel2;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel7;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel10;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel12;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel17;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel40;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel42;
        private ComboBox education_id_1_comboBox;
        private ComboBox education_id_2_comboBox;
        private ComboBox educationfield_id_1_comboBox;
        private ComboBox educationfield_id_2_comboBox;
        private ComboBox educationtype_id_2_comboBox;
        private TextBox educationnote_TextBox;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel70;
        private TableLayoutPanel IsStudent_tableLayoutPanel;
        private MaterialSkinPlus.Controls.MaterialRadioButton NotStudent_RadioButton;
        private MaterialSkinPlus.Controls.MaterialRadioButton IsStudent_RadioButton;
        private TableLayoutPanel studentPanel;
        private ComboBox expensestype_2_comboBox;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel72;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel71;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel73;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel75;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel74;
        private TextBox expenses_amount_8_Textbox;
        private TextBox expenses_amount_2_TextBox;
        private ComboBox expensestype_8_comboBox;
        private TableLayoutPanel student1Panel;
        private ComboBox aidperiod_23_comboBox;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel76;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel77;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel79;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel78;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel81;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel80;
        private TextBox aid_amount_2_TextBox;
        private TextBox aid_amount_23_TextBox;
        private ComboBox aidsource_2_comboBox;
        private ComboBox aidsource_23_comboBox;
        private ComboBox aidperiod_2_comboBox;
        private Panel panel10;
        private MaterialSkinPlus.Controls.MaterialLabel NeedsLable;
        private Panel panel6;
        private MaterialSkinPlus.Controls.MaterialLabel GeneralNoteLable;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel21;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField needs_courses_TextBox;
        private CheckBox needs_6_checkBox;
        private CheckBox needs_12_checkBox;
        private CheckBox needs_4_checkBox;
        private CheckBox needs_10_checkBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField needs_note_TextBox;
        private CheckBox needs_0_checkBox;
        private CheckBox needs_3_checkBox;
        private CheckBox needs_9_checkBox;
        private CheckBox needs_8_checkBox;
        private CheckBox needs_7_checkBox;
        private CheckBox needs_1_checkBox;
        private CheckBox needs_5_checkBox;
        private CheckBox needs_2_checkBox;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel16;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField FamilyCode_TextBox;
        private MaterialSkinPlus.Controls.MaterialLabel State_Label;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField State_TextBox;
        private MaterialSkinPlus.Controls.MaterialLabel State_Label1;
        private ComboBox State_ComboBox;
        private MaterialSkinPlus.Controls.MaterialLabel Relation_Label;
        private ComboBox Relation_ComboBox;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel20;
        private ComboBox MaritalStatus_ComboBox;
        private Button Delete_Button;
        private TableLayoutPanel FirstLayoutPanel;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel47;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel48;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel49;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel52;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel53;
        private PictureBox pictureBox1;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel54;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel55;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel56;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel57;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel58;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel59;
        private Button button3;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField ELastName_TextBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField EFatherName_TextBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField EName_TextBox;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel3;
        private Button StateHistory_Button;
        private PictureBox pictureBox3;
        private TableLayoutPanel haswork_tableLayoutPanel;
        private TableLayoutPanel has_mp_tableLayoutPanel;
        private Panel panel13;
        private MaterialSkinPlus.Controls.MaterialLabel PGeneralNoteLable;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel5;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField Note_TextBox;
        private TableLayoutPanel MELayoutPanel;
        private DataGridViewTextBoxColumn Disease_VisitName;
        private DataGridViewComboBoxColumn Disease_Category;
        private DataGridViewComboBoxColumn Disease;
        private DataGridViewTextBoxColumn DiseaseNote;
        private DataGridViewButtonColumn Disease_DeleteRow;
        private DataGridViewTextBoxColumn Person_Disease_ID;
        private DataGridViewTextBoxColumn Disease_IsDirty;
        private DataGridViewTextBoxColumn Work_VisitName;
        private DataGridViewComboBoxColumn workexp_id;
        private DataGridViewComboBoxColumn workfor_id;
        private DataGridViewComboBoxColumn worktype_id;
        private DataGridViewComboBoxColumn workposition_id;
        private DataGridViewComboBoxColumn experience_id;
        private DataGridViewTextBoxColumn workexpamount;
        private DataGridViewTextBoxColumn workname;
        private DataGridViewComboBoxColumn workplace_id;
        private DataGridViewTextBoxColumn expenses_amount_6;
        private DataGridViewComboBoxColumn expensestype_6;
        private DataGridViewTextBoxColumn expensesAmperNumber_7;
        private DataGridViewTextBoxColumn expenses_amount_7;
        private DataGridViewTextBoxColumn expenses_amount_15;
        private DataGridViewComboBoxColumn expensestype_15;
        private DataGridViewTextBoxColumn expenses_amount_16;
        private DataGridViewComboBoxColumn expensestype_16;
        private DataGridViewTextBoxColumn expenses_amount_17;
        private DataGridViewComboBoxColumn expensestype_17;
        private DataGridViewTextBoxColumn expenses_amount_23;
        private DataGridViewComboBoxColumn expensestype_23;
        private DataGridViewTextBoxColumn workexpnote;
        private DataGridViewButtonColumn Work_DeleteRow;
        private DataGridViewTextBoxColumn Person_Work_ID;
        private DataGridViewTextBoxColumn Work_IsDirty;
        private DataGridViewTextBoxColumn MP_VisitName;
        private DataGridViewTextBoxColumn mp_fundyear;
        private DataGridViewComboBoxColumn aidsource_5_mp;
        private DataGridViewTextBoxColumn aid_amount_5_mp;
        private DataGridViewComboBoxColumn aidperiod_5_mp;
        private DataGridViewComboBoxColumn aidsource_17_mp;
        private DataGridViewTextBoxColumn aid_amount_17_mp;
        private DataGridViewComboBoxColumn aidperiod_17_mp;
        private DataGridViewComboBoxColumn aidsource_22_mp;
        private DataGridViewTextBoxColumn aid_amount_22_mp;
        private DataGridViewComboBoxColumn aidperiod_22_mp;
        private DataGridViewTextBoxColumn expenses_amount_12_mp;
        private DataGridViewComboBoxColumn expensestype_12_mp;
        private DataGridViewButtonColumn MP_DeleteRow;
        private DataGridViewTextBoxColumn Person_MP_ID;
        private DataGridViewTextBoxColumn MP_IsDirty;
        private DataGridView MEFamily_DataGridView;
        private DataGridViewTextBoxColumn ME_Family_Visit_ID;
        private DataGridViewTextBoxColumn ME_Name;
        private DataGridViewTextBoxColumn ME_Scedualed_Date;
        private DataGridViewTextBoxColumn ME_Date;
        private DataGridViewComboBoxColumn ME_State;
        private DataGridViewTextBoxColumn ME_Reason;
        private DataGridViewButtonColumn ME_Delete;
        private DataGridViewTextBoxColumn ME_Canceled_Reason;
        private DataGridViewTextBoxColumn ME_Story;
        private DataGridViewTextBoxColumn ME_Link1;
        private DataGridViewTextBoxColumn ME_Link2;
        private DataGridViewTextBoxColumn ME_Link3;
        private DataGridViewTextBoxColumn ME_Visit_Date;
        private DataGridViewTextBoxColumn ME_Visit_Team;
        private Panel panel1;
        private MaterialSkinPlus.Controls.MaterialLabel InfoLable;
        private Panel panel2;
        private MaterialSkinPlus.Controls.MaterialLabel InfoInsideFamilyLable;
        private Panel panel11;
        private MaterialSkinPlus.Controls.MaterialLabel visit_Label;
        private Panel panel12;
        private MaterialSkinPlus.Controls.MaterialLabel VisitInfoLabel;
        private Label VisitNameLabel;
        private TextBox PersonNote_TextBox;
        private Button MaritalHistory_Button;
        private TableLayoutPanel tableLayoutPanel10;
        private Button Update_Button;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField StateAddressNote_TextBox;
        private MaterialSkinPlus.Controls.MaterialLabel StateAddressNote_Lable;
        private ComboBox StateAddress_ComboBox;
    }
}