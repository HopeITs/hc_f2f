using F2F_Application.Classes;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Signitaure_List_Edit_Form : MaterialForm
    {
        public Signitaure_List_Edit_Form(int Partner_ID, int Donor_ID, int Distribution_ID, int Partner_Distribution_ID, Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.Partner_ID = Partner_ID;
            this.Donor_ID = Donor_ID;
            this.Distribution_ID = Distribution_ID;
            this.Partner_Distribution_ID = Partner_Distribution_ID;

            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(activeScreenDimensions.Width, activeScreenDimensions.Height);

            SignitaureList_DataGridView.DoubleBuffered(true);

        }

        Main_Form main_form;
        int Partner_ID, Donor_ID, Partner_Distribution_ID, Distribution_ID;
        CheckBox checkboxHeader = new CheckBox();
        Distribution d;
        bool UserMode = true;
        string Signature_List_Query;


        private void Signitaure_List_Edit_Form_Load(object sender, EventArgs e)
        {
            try
            {
                d = new Distribution();
                Signature_List_Query = "";
                Bind_SignitaureList_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void SignitaureList_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Check to ensure that the row CheckBox is clicked.
                if (e.RowIndex >= 0 && e.ColumnIndex == 6)
                {
                    //Loop to verify whether all row CheckBoxes are checked or not.
                    bool isChecked = true;
                    foreach (DataGridViewRow row in SignitaureList_DataGridView.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Check"].EditedFormattedValue) == false)
                        {
                            isChecked = false;
                            break;
                        }
                    }
                    UserMode = false;
                    checkboxHeader.Checked = isChecked;
                    UserMode = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    //Necessary to end the edit mode of the Cell.
                    SignitaureList_DataGridView.EndEdit();

                    //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
                    foreach (DataGridViewRow row in SignitaureList_DataGridView.Rows)
                    {
                        DataGridViewCheckBoxCell checkBox = (row.Cells["Check"] as DataGridViewCheckBoxCell);
                        checkBox.Value = checkboxHeader.Checked;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Bind_SignitaureList_DataGridView()
        {
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn C in SignitaureList_DataGridView.Columns)
            {
                if (C.Name != "Check")
                    C.ReadOnly = true;
                else
                    C.ReadOnly = false;
            }
            SignitaureList_DataGridView.Rows.Clear();
            dt = d.Get_AdditionalFamilies_Signitaure_List(Partner_ID, Donor_ID,Partner_Distribution_ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SignitaureList_DataGridView.Rows.Add();
                SignitaureList_DataGridView.Rows[i].Cells["Family_id"].Value = dt.Rows[i].Field<int>("Family ID");
                SignitaureList_DataGridView.Rows[i].Cells["Family_Code"].Value = dt.Rows[i].Field<string>("Family Code");
                SignitaureList_DataGridView.Rows[i].Cells["Reciever_FirstName"].Value = dt.Rows[i].Field<string>("Reciever_FirstName");
                SignitaureList_DataGridView.Rows[i].Cells["Reciever_FatherName"].Value = dt.Rows[i].Field<string>("Reciever_FatherName");
                SignitaureList_DataGridView.Rows[i].Cells["Reciever_LastName"].Value = dt.Rows[i].Field<string>("Reciever_LastName");
                SignitaureList_DataGridView.Rows[i].Cells["National_Number"].Value = dt.Rows[i].Field<string>("National Number");
                SignitaureList_DataGridView.Rows[i].Cells["MembersNumber"].Value = dt.Rows[i].Field<Int64>("NumberOfBeneficiaries");
                SignitaureList_DataGridView.Rows[i].Cells["MobileNumber"].Value = dt.Rows[i].Field<string>("Mobile Number");
                if (dt.Rows[i]["Amount"] != DBNull.Value)
                    SignitaureList_DataGridView.Rows[i].Cells["Amount"].Value = dt.Rows[i].Field<float>("Amount");
                else
                    SignitaureList_DataGridView.Rows[i].Cells["Amount"].Value = 0;
            }

            Rectangle oRectangle1 = SignitaureList_DataGridView.GetCellDisplayRectangle(8, -1, true);
            checkboxHeader.Size = new Size(oRectangle1.Width - 7, oRectangle1.Height - 7);
            checkboxHeader.Name = "Check_All";
            checkboxHeader.BackColor = Color.FromArgb(0, 75, 75);
            checkboxHeader.Location = new Point(oRectangle1.X, oRectangle1.Y + 4);
            SignitaureList_DataGridView.Controls.Add(checkboxHeader);
            checkboxHeader.CheckedChanged += this.checkboxHeader_CheckedChanged;
        }

        private void Signitaure_List_Edit_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UserMode)
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = Add_Button;

                int Last_Checked_Row = -1;

                for (int i = 0; i < SignitaureList_DataGridView.Rows.Count; i++)
                {
                    if (SignitaureList_DataGridView.Rows[i].Cells["Check"].Value != null && SignitaureList_DataGridView.Rows[i].Cells["Check"].Value.ToString() == "True")
                    {
                        Last_Checked_Row = i;
                    }
                }

                if (Last_Checked_Row == -1)
                {
                    Signature_List_Query = "";
                    MessageBox.Show("لا يوجد أي تغييرات لحفظها ", "Error");
                    return;
                }
                else
                {
                    Get_Data(Last_Checked_Row);

                    d.Insert_Signitaure_List(Signature_List_Query, Partner_Distribution_ID, Partner_ID, Distribution_ID, this.Name);

                    Signature_List_Query = "";
                    this.DialogResult = DialogResult.Yes;
                    UserMode = false;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                Signature_List_Query = "";
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Get_Data(int Last_Checked_Row)
        {
            for (int i = 0; i < SignitaureList_DataGridView.Rows.Count; i++)
            {
                if (SignitaureList_DataGridView.Rows[i].Cells["Check"].Value != null && SignitaureList_DataGridView.Rows[i].Cells["Check"].Value.ToString() == "True")
                {
                    Signature_List_Query += "('" + Partner_Distribution_ID + "', '" + (int)SignitaureList_DataGridView.Rows[i].Cells["Family_id"].Value + "', '" + SignitaureList_DataGridView.Rows[i].Cells["MembersNumber"].Value + "')";
                    if (i < Last_Checked_Row)
                        Signature_List_Query += ",";
                }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tableLayoutPanel1.Size = new Size(this.Width, 439);
                Signature_List_Query = "";
                Bind_SignitaureList_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Add_Button_MouseEnter(object sender, EventArgs e)
        {
            Add_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Add_Button_MouseLeave(object sender, EventArgs e)
        {
            Add_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }
    }
}
