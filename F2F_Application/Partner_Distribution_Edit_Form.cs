using F2F_Application.Classes;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Partner_Distribution_Edit_Form : MaterialForm
    {
        public Partner_Distribution_Edit_Form(Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;

            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(activeScreenDimensions.Width, activeScreenDimensions.Height);
        }

        Main_Form main_form;
        bool UserMode;
        string Distribution_Query; List<int> Distributions_ID = new List<int>();
        CheckBox checkboxHeader = new CheckBox();
        Partner p; Categories c;

        private void Partner_Distribution_Edit_Form_Load(object sender, EventArgs e)
        {
            try
            {
                p = new Partner(); c = new Categories();
                Distribution_Query = ""; Distributions_ID.Clear();
                Bind_Donor_ComboBox();
                Partner_ComboBox.Visible = label1.Visible = false;
                UserMode = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Bind_Partner_ComboBox(int donor_id)
        {
            int SelectedValue = -1;
            if (Partner_ComboBox.SelectedValue != null)
                SelectedValue = int.Parse(Partner_ComboBox.SelectedValue.ToString());

            DataTable dt = c.Select_Table("partner_donor", "partner_donor.donor_id = "+ donor_id + " ", true, false);
            UserMode = false;
            Partner_ComboBox.DataSource = dt;
            Partner_ComboBox.DisplayMember = "name";
            Partner_ComboBox.ValueMember = "id";

            if (SelectedValue != -1)
                Partner_ComboBox.SelectedValue = SelectedValue;
            else
                Partner_ComboBox.SelectedIndex = -1;

            UserMode = true;
            Partner_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
        }

        private void Bind_Donor_ComboBox()
        {
            int SelectedDonorValue = 3;
            if (Donor_ComboBox.SelectedValue != null)
                SelectedDonorValue = int.Parse(Donor_ComboBox.SelectedValue.ToString());

            DataTable dt = c.Select_Table("donor", "", true, false);
            UserMode = false;
            Donor_ComboBox.DataSource = dt;
            Donor_ComboBox.DisplayMember = "name";
            Donor_ComboBox.ValueMember = "id";

            if (SelectedDonorValue != 0)
                Donor_ComboBox.SelectedValue = SelectedDonorValue;
            else
                Donor_ComboBox.SelectedIndex = 0;
            
            UserMode = true;
            Donor_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
        }


        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void Partner_Distribution_Edit_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UserMode)
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    //Necessary to end the edit mode of the Cell.
                    Distribution_DataGridView.EndEdit();

                    //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
                    foreach (DataGridViewRow row in Distribution_DataGridView.Rows)
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

        private void Distribution_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Check to ensure that the row CheckBox is clicked.
                if (e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                    //Loop to verify whether all row CheckBoxes are checked or not.
                    bool isChecked = true;
                    foreach (DataGridViewRow row in Distribution_DataGridView.Rows)
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

        private void Bind_Distribution_DataGridView()
        {
            int Partner_ID = Partner_ComboBox.SelectedIndex == -1 ? -1 : int.Parse(Partner_ComboBox.SelectedValue.ToString());
            int Donor_ID = Donor_ComboBox.SelectedIndex == -1 ? 0 : int.Parse(Donor_ComboBox.SelectedValue.ToString());
            int PartnerDonor_id;
            if (Partner_ID != -1 && Donor_ID != 0)
            {
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                dt = p.Get_Partner_Donor_ID(Partner_ID, Donor_ID);
                PartnerDonor_id = dt.Rows[0].Field<int>("id");
                foreach (DataGridViewColumn C in Distribution_DataGridView.Columns)
                {
                    if (C.Name != "Check")
                        C.ReadOnly = true;
                    else
                        C.ReadOnly = false;
                }
                Distribution_DataGridView.Rows.Clear();
                string Year = dateTimePicker1.Value.ToString("yyyy", new CultureInfo("en-GB"));
                dt1 = p.Get_Partner_Unregistred_Distribution(PartnerDonor_id, Year);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    Distribution_DataGridView.Rows.Add();
                    Distribution_DataGridView.Rows[i].Cells["Distribution"].Value = dt1.Rows[i].Field<string>("name");
                    Distribution_DataGridView.Rows[i].Cells["Distribution_Date"].Value = dt1.Rows[i].Field<string>("date");
                    Distribution_DataGridView.Rows[i].Cells["Distribution_id"].Value = dt1.Rows[i].Field<int>("id");
                    Distribution_DataGridView.Rows[i].Cells["partner_donor_id"].Value = PartnerDonor_id;
                }

                Rectangle oRectangle1 = Distribution_DataGridView.GetCellDisplayRectangle(2, -1, true);
                checkboxHeader.Size = new Size(oRectangle1.Width - 7, oRectangle1.Height - 7);
                checkboxHeader.Name = "Check_All";
                checkboxHeader.BackColor = Color.FromArgb(0, 75, 75);
                checkboxHeader.Location = new Point(oRectangle1.X, oRectangle1.Y + 4);
                Distribution_DataGridView.Controls.Add(checkboxHeader);
                checkboxHeader.CheckedChanged += this.checkboxHeader_CheckedChanged;
            }
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = Add_Button;

                int Last_Checked_Row = -1;

                for (int i = 0; i < Distribution_DataGridView.Rows.Count; i++)
                {
                    if (Distribution_DataGridView.Rows[i].Cells["Check"].Value != null && Distribution_DataGridView.Rows[i].Cells["Check"].Value.ToString() == "True")
                    {
                        Last_Checked_Row = i;
                    }
                }

                if (Last_Checked_Row == -1)
                {
                    Distribution_Query = ""; Distributions_ID.Clear();
                    MessageBox.Show("لا يوجد أي تغييرات لحفظها ", "Error");
                    return;
                }
                if (Partner_ComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("الرجاء تحديد الشريك", "Error");
                    return;
                }
                if (Partner_ComboBox.SelectedIndex == 0)
                {
                    MessageBox.Show("الرجاء تحديد الممول", "Error");
                    return;
                }
                else
                {
                    DataTable dt = new DataTable();
                    int Partner_ID = Partner_ComboBox.SelectedIndex == -1 ? -1 : int.Parse(Partner_ComboBox.SelectedValue.ToString());
                    int Donor_ID = Donor_ComboBox.SelectedIndex == -1 ? 0 : int.Parse(Donor_ComboBox.SelectedValue.ToString());
                    dt = p.Get_Partner_Donor_ID(Partner_ID, Donor_ID);
                    int PartnerDonor_ID = dt.Rows[0].Field<int>("id");
                    Get_Data(Last_Checked_Row , PartnerDonor_ID);
                    dt = p.Get_Partner_Donor_ID(Partner_ID, Donor_ID);
                    p.Add_Partner_Distribution(Distribution_Query, Distributions_ID, PartnerDonor_ID, this.Name);
                    Distribution_Query = ""; Distributions_ID.Clear();
                    this.DialogResult = DialogResult.Yes;
                    UserMode = false;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Distribution_Query = ""; Distributions_ID.Clear();
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Get_Data(int Last_Checked_Row,int PartnerDonor_ID)
        {
            if (PartnerDonor_ID != null)
            {
                for (int i = 0; i < Distribution_DataGridView.Rows.Count; i++)
                {
                    if (Distribution_DataGridView.Rows[i].Cells["Check"].Value != null && Distribution_DataGridView.Rows[i].Cells["Check"].Value.ToString() == "True")
                    {
                        int ID = (int)Distribution_DataGridView.Rows[i].Cells["Distribution_id"].Value;
                        Distribution_Query += "('" + PartnerDonor_ID + "', '" + ID + "')";
                        if (i < Last_Checked_Row)
                            Distribution_Query += ",";

                        Distributions_ID.Add(ID); //To be used in log
                    }
                }
            }
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            try
            {
                Distribution_Query = ""; Distributions_ID.Clear();
                Bind_Distribution_DataGridView();
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
                Distribution_Query = ""; Distributions_ID.Clear();
                Bind_Distribution_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Partner_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    Bind_Distribution_DataGridView();
                }
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

        private void Donor_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    int SelectedDonorValue = int.Parse(Donor_ComboBox.SelectedValue.ToString());
                    Bind_Distribution_DataGridView();
                    Bind_Partner_ComboBox(SelectedDonorValue);
                    Partner_ComboBox.Visible = label1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
    }
}
