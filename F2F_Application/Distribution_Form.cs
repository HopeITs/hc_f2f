using F2F_Application.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Distribution_Form : Form
    {
        public Distribution_Form(Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.Distribution_ID = -1;
            UpdateMode = false;
        }

        public Distribution_Form(int Distribution_ID, Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.Distribution_ID = Distribution_ID;
            UpdateMode = true;
        }

        Main_Form main_form;
        Distribution d;
        Categories c;
        int Distribution_ID;
        bool DataApproved = false;
        bool UpdateMode;
        bool UserMode = false;

        string Distribution_Name, Date, Rate;
        int Default, SegmentsGroup_ID, DonorGroup_ID;
        string Group_ComboBox_OriginalText;
        string Donor_ComboBox_OriginalText;


        bool Distribution_Name_IsDirty = false, Rate_IsDirty = false, Group_IsDirty = false,Donor_IsDirty = false, Date_isDirty = false;

        string DistributionName_TextBox_OriginalText, Rate_TextBox_OriginalText;

        private void Distribution_Form_Load(object sender, EventArgs e)
        {
            try
            {
                d = new Distribution();
                c = new Categories();
                Set_Controls();

                if (UpdateMode)
                {
                    Fill_Distribution();
                }

                Bind_Group_ComboBox();
                Bind_Donor_ComboBox();
                if (Distribution_ID != -1)
                    Program.Distribution_Opened.Add(Distribution_ID);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Set_Controls()
        {
            DistributionName_TextBox.Clear();
            Rate_TextBox.Clear();
            dateTimePicker1.Value = DateTime.Now;

            Distribution_Name = Date = Rate = "";
            Default = SegmentsGroup_ID = DonorGroup_ID = - 1;

            Group_ComboBox_OriginalText = "";
            Donor_ComboBox_OriginalText = "";
            Distribution_Name_IsDirty = Rate_IsDirty = Group_IsDirty = Donor_IsDirty = Date_isDirty = false;

            DistributionName_TextBox_OriginalText = Rate_TextBox_OriginalText = "";

            if (!UpdateMode)
            {
                Save_Button.Visible = true;
                Update_Button.Visible = Delete_Button.Visible = false;

            }
            if (UpdateMode)
            {
                Save_Button.Visible = false;
                Update_Button.Visible = Delete_Button.Visible = true;
            }
        }

        private void Fill_Distribution()
        {
            DataTable dt = d.Get_Distribution(Distribution_ID);
            UserMode = false;
            DistributionName_TextBox.Text = dt.Rows[0].Field<string>("name");
            dateTimePicker1.Value = DateTime.Parse(dt.Rows[0].Field<DateTime>("date").ToString("MMMM/yyyy"), CultureInfo.CurrentCulture);
            Rate_TextBox.Text = dt.Rows[0].Field<float>("rate").ToString();
            SegmentsGroup_ID = dt.Rows[0].Field<int>("segmentsgroup_id");
            DonorGroup_ID = dt.Rows[0].Field<int>("donor_id");
            UserMode = true;
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = Save_Button;

                DataApproved = Check_Data();

                if (DataApproved)
                {
                    Get_Data();

                    Distribution_ID = d.Insert_Distribuion(Distribution_Name, Date, Rate, Default, SegmentsGroup_ID, Group_ComboBox.Text,DonorGroup_ID, this.Name);

                    UpdateMode = true;

                    MessageBox.Show("تم إدخال التوزيعة " + Distribution_Name + "  بنجاح", "Confirmation");

                    Set_Controls();

                    Fill_Distribution();
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

        private void Get_Data()
        {
            #region
            if (!UpdateMode)
            {
                Distribution_Name = DistributionName_TextBox.Text;

                var Picked = dateTimePicker1.Value;
                var startOfMonth = new DateTime(Picked.Year, Picked.Month, 1);

                Date = startOfMonth.ToString("dd/MM/yyyy", new CultureInfo("en-GB"));


                Rate = "";
                if (string.IsNullOrWhiteSpace(Rate_TextBox.Text) || float.Parse(Rate_TextBox.Text) == 0)
                {
                    Rate = "1";
                }
                else
                {
                    Rate = Rate_TextBox.Text;
                }

                string SelectedText = "";
                string SelectedDonorText = "";
                dynamic item = Group_ComboBox.SelectedItem;
                if (item != null)
                {
                    SelectedText = item.Text;
                    SegmentsGroup_ID = int.Parse(item.Value);
                }
                dynamic donor = donor_comboBox.SelectedItem;
                if (donor != null)
                {
                    SelectedDonorText = donor.Text;
                    DonorGroup_ID = int.Parse(donor.Value);
                }


                Default = 0;
                if (SelectedText != Group_ComboBox_OriginalText && !SelectedText.StartsWith("Def. | "))
                {

                    DialogResult dialogResult = MessageBox.Show("لقد قمت باختيار مجموعة شرائح غير الافتراضية لهذه التوزيعة .. هل تريد تعيين هذه المجموعة كافتراضية لاستخدامها في التوزيعات القادمة؟؟", "Alert", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Default = 1;
                    }
                    else
                    {
                        Default = 0;
                    }
                }
            }
            #endregion

            #region
            if (UpdateMode)
            {
                if (Distribution_Name_IsDirty)
                    Distribution_Name = DistributionName_TextBox.Text;

                if (Rate_IsDirty)
                {
                    Rate = "";
                    if (string.IsNullOrWhiteSpace(Rate_TextBox.Text) || float.Parse(Rate_TextBox.Text) == 0)
                    {
                        Rate = "1";
                    }
                    else
                    {
                        Rate = Rate_TextBox.Text;
                    }
                }

                if (Group_IsDirty)
                {
                    string SelectedText = "";
                    dynamic item = Group_ComboBox.SelectedItem;
                    if (item != null)
                    {
                        SelectedText = item.Text;

                        SegmentsGroup_ID = int.Parse(item.Value);
                    }
                    Default = 0;
                    if (SelectedText != Group_ComboBox_OriginalText && !SelectedText.StartsWith("Def. | "))
                    {

                        DialogResult dialogResult = MessageBox.Show("لقد قمت باختيار مجموعة شرائح غير الافتراضية لهذه التوزيعة .. هل تريد تعيين هذه المجموعة كافتراضية لاستخدامها في التوزيعات القادمة؟؟", "Alert", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Default = 1;
                        }
                        else
                        {
                            Default = 0;
                        }
                    }
                }

                if (Donor_IsDirty)
                {
                    string SelectedDonorText = "";
                    dynamic donor = donor_comboBox.SelectedItem;
                    if (donor != null)
                    {
                        SelectedDonorText = donor.Text;
                        DonorGroup_ID = int.Parse(donor.Value);
                    }
                }

                if (Date_isDirty)
                {

                    var Picked = dateTimePicker1.Value;
                    var startOfMonth = new DateTime(Picked.Year, Picked.Month, 1);

                    Date = startOfMonth.ToString("dd/MM/yyyy", new CultureInfo("en-GB"));
                }
            }
            #endregion
        }

        private bool Check_Data()
        {
            if (DistributionName_TextBox.Text == "")
            {
                MessageBox.Show("لا يمكن ترك اسم التوزيعة فارغاً", "Error");
                return false;
            }
            if (dateTimePicker1.Value == null)
            {
                MessageBox.Show("الرجاء تحديد تاريخ التوزيعة", "Error");
                return false;
            }
            string Date = dateTimePicker1.Value.ToString("dd/MM/yyyy", new CultureInfo("en-GB"));

            DataTable dt = d.Check_Distribution_Date(Date, Distribution_ID);
            if (dt != null)
            {
                DialogResult dialogResult = MessageBox.Show("يوجد توزيعة ثانية في نفس الموعد !! هل تريد المتابعة؟؟", "Alert", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                }
                else
                {
                    return false;
                }
            }

            if (Group_ComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("الرجاء تحديد مجموعة الشرائح", "Error");
                return false;
            }
            if (donor_comboBox.SelectedIndex < 0)
            {
                MessageBox.Show("الرجاء تحديد الممول", "Error");
                return false;
            }

            if (UpdateMode)
            {
                if (Group_IsDirty)
                {
                    DialogResult dialogResult = MessageBox.Show("إن تغيير المجموعة الخاصة بهذه التوزيعة سيؤدي إلى تغيير المبالغ المحسوبة لجميع العائلات...هل تريد الاستمرار", "Alert", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = Update_Button;

                DataApproved = Check_Data();

               
                if (DataApproved)
                {

                    if (UpdateMode)
                    {
                        if (!Distribution_Name_IsDirty && !Rate_IsDirty && !Group_IsDirty && !Date_isDirty && !Donor_IsDirty)
                        {
                            MessageBox.Show("لا يوجد أي تغييرات لحفظها ", "Error");
                            return;
                        }
                        else
                        {
                            Get_Data();

                            d.Update_Distribution(Distribution_ID, DistributionName_TextBox.Text, Distribution_Name, Date, Rate, Default, SegmentsGroup_ID, Group_ComboBox.Text, DonorGroup_ID, this.Name);

                            MessageBox.Show("تم تعديل معلومات التوزيعة " + DistributionName_TextBox.Text + "  بنجاح", "Confirmation");

                        }
                    }

                    Set_Controls();



                    Fill_Distribution();

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

        private void Bind_Group_ComboBox()
        {
            UserMode = false;
            DataTable dt;
            int Index = -1;
            dt = c.Select_Table("segmentsgroup", "", true, false);
            Group_ComboBox.Items.Clear();
            Group_ComboBox.Text = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Group_ComboBox.DisplayMember = "Text";
                Group_ComboBox.ValueMember = "Value";
                if (dt.Rows[i][2].ToString() == "1")
                {
                    Group_ComboBox.Items.Add(new { Text = "Def. | " + dt.Rows[i][1], Value = dt.Rows[i][0].ToString() });
                    if (!UpdateMode)
                    {
                        Index = Group_ComboBox.Items.Count - 1;
                    }
                }
                else
                {
                    Group_ComboBox.Items.Add(new { Text = dt.Rows[i][1], Value = dt.Rows[i][0].ToString() });
                }
                if (UpdateMode)
                {
                    if (dt.Rows[i][0].ToString() == SegmentsGroup_ID.ToString())
                        Index = Group_ComboBox.Items.Count - 1;
                }
            }
            Group_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);

            Group_ComboBox.SelectedIndex = Index;

            dynamic item = Group_ComboBox.SelectedItem;
            if (item != null)
            {
                Group_ComboBox_OriginalText = item.Text;
            }

            UserMode = true;
        }
        private void Bind_Donor_ComboBox()
        {
            UserMode = false;
            DataTable dt;
            int Index = -1;
            dt = c.Select_Table("donor", "", true, false);
            donor_comboBox.Items.Clear();
            donor_comboBox.Text = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                donor_comboBox.DisplayMember = "Text";
                donor_comboBox.ValueMember = "Value";
                if (dt.Rows[i][2].ToString() == "1")
                {
                    donor_comboBox.Items.Add(new { Text = "Def. | " + dt.Rows[i][1], Value = dt.Rows[i][0].ToString() });
                    if (!UpdateMode)
                    {
                        Index = donor_comboBox.Items.Count - 1;
                    }
                }
                else
                {
                    donor_comboBox.Items.Add(new { Text = dt.Rows[i][1], Value = dt.Rows[i][0].ToString() });
                }
                if (UpdateMode)
                {
                    if (dt.Rows[i][0].ToString() == DonorGroup_ID.ToString())
                        Index = donor_comboBox.Items.Count - 1;
                }
            }
            donor_comboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);

            donor_comboBox.SelectedIndex = Index;

            dynamic item = donor_comboBox.SelectedItem;
            if (item != null)
            {
                Group_ComboBox_OriginalText = item.Text;
            }

            UserMode = true;
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = Delete_Button;
                DialogResult dialogResult = MessageBox.Show("سيتم حذف التوزيعة بشكل كامل!!", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string SelectedText = "";
                    dynamic item = Group_ComboBox.SelectedItem;
                    if (item != null)
                    {
                        SelectedText = item.Text;
                        SegmentsGroup_ID = int.Parse(item.Value); //To be used in log
                    }

                    d.Delete_Distribution(Distribution_ID, SegmentsGroup_ID, DistributionName_TextBox.Text, this.Name);

                    MessageBox.Show("تم حذف التوزيعة " + DistributionName_TextBox.Text + "  بنجاح", "Confirmation");
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
                    MessageBox.Show("لا يمكن حذف هذه التوزيعة بسبب ارتباطها مع شركاء", "Error");
                else
                { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }
            }
        }

        private void Group_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int SegmentGroup_ID = -1;
                dynamic item = Group_ComboBox.SelectedItem;
                if (item != null)
                {
                    SegmentGroup_ID = int.Parse(item.Value);
                }
                Bind_GroupDetails_DataGridView(SegmentGroup_ID);

                if (UserMode)
                    Group_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Distribution_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    this.ActiveControl = Save_Button;

                    if (Distribution_Name_IsDirty || Rate_IsDirty || Group_IsDirty || Date_isDirty)
                    {
                        if (MessageBox.Show("يوجد بعض التعديلات غير المحفوظة، هل تود حفظها قبل إغلاق الصفحة؟؟", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (UpdateMode)
                                Update_Button.PerformClick();
                            else
                                Save_Button.PerformClick();

                            //e.Cancel = true;
                            //return;
                        }
                        else
                        {
                            // continue closing;
                        }
                    }
                }
                Program.Distribution_Opened.Remove(Distribution_ID);

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
                Bind_Group_ComboBox();
                Bind_Donor_ComboBox();

                Set_Controls();

                if (UpdateMode)
                {
                    Fill_Distribution();
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Bind_GroupDetails_DataGridView(int SegmentGroup_ID)
        {
            DataTable dt = c.Select_Table("segmentsgroup_details", " segmentsgroup_id = " + SegmentGroup_ID + "", true, false);

            GroupDetails_DataGridView.ColumnHeadersVisible = false;
            GroupDetails_DataGridView.DataSource = null;
            GroupDetails_DataGridView.Columns.Clear();
            GroupDetails_DataGridView.DataSource = dt;
            GroupDetails_DataGridView.ColumnHeadersVisible = true;

            GroupDetails_DataGridView.Columns["id"].Visible = false;
            GroupDetails_DataGridView.Columns["segmentsgroup_id"].Visible = false;
            GroupDetails_DataGridView.Columns["NumberOfMembers"].HeaderText = "عدد الأشخاص";
            GroupDetails_DataGridView.Columns["amount"].HeaderText = "المبلغ";
        }

        private void Rate_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        #region //IsDirty
        private void DistributionName_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                DistributionName_TextBox_OriginalText = DistributionName_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void DistributionName_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (DistributionName_TextBox_OriginalText != DistributionName_TextBox.Text)
                    Distribution_Name_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Rate_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                Rate_TextBox_OriginalText = Rate_TextBox.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Rate_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Rate_TextBox_OriginalText != Rate_TextBox.Text)
                    Rate_IsDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void donor_comboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void donor_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int DonorGroup_ID = -1;
                dynamic donor = donor_comboBox.SelectedItem;
                if (donor != null)
                {
                    DonorGroup_ID = int.Parse(donor.Value);
                }

                if (UserMode)
                    Donor_IsDirty = true;
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
                if (UserMode)
                    Date_isDirty = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        #endregion

        private void Save_Button_MouseEnter(object sender, EventArgs e)
        {
            Save_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Save_Button_MouseLeave(object sender, EventArgs e)
        {
            Save_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        private void Update_Button_MouseEnter(object sender, EventArgs e)
        {
            Update_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Update_Button_MouseLeave(object sender, EventArgs e)
        {
            Update_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        private void Delete_Button_MouseEnter(object sender, EventArgs e)
        {
            Delete_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Delete_Button_MouseLeave(object sender, EventArgs e)
        {
            Delete_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

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

        private void GroupDetails_DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == GroupDetails_DataGridView.Columns["amount"].Index)
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
