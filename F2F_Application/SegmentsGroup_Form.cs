using F2F_Application.Classes;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class SegmentsGroup_Form : MaterialForm
    {
        public SegmentsGroup_Form(Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            MyDataGridViewInitializationMethod();
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(activeScreenDimensions.Width, activeScreenDimensions.Height);
        }

        Main_Form main_form;
        string SegmentsGroup_Query, GroupName;
        int Default;
        bool DataApproved;
        bool UserMode = false;
        Distribution d; Categories c;

        int Page2Enter = 0;
        string EditSegmentsGroup_Query;
        bool GroupDetails_DataGridView_IsDirty;
        int SegmentGroup_ID;
        int UsedRow = 0;

        private void NewSegmentsGroup_Form_Load(object sender, EventArgs e)
        {
            try
            {
                d = new Distribution();
                c = new Categories();
                Set_Controls();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
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

                    d.Insert_SegmentsGroup(GroupName, Default, SegmentsGroup_Query, this.Name);

                    Set_Controls();
                    MessageBox.Show("تم إدخال المجموعة بنجاح", "Confirmation");
                }
            }
            catch (Exception ex)
            {
                SegmentsGroup_Query = "";
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private bool Check_Data()
        {
            if (materialTabControl1.SelectedTab.Name == "tabPage1")
            {
                if (string.IsNullOrWhiteSpace(Name_textBox.Text))
                {
                    MessageBox.Show("لا يمكن ترك خانة الاسم فارغة", "Error");
                    return false;
                }
                if (Details_DataGridView.Rows.Count <= 1)
                {
                    MessageBox.Show("الرجاء إدخال تفاصيل المجموعة", "Error");
                    return false;
                }
                for (int i = 0; i < Details_DataGridView.Rows.Count - 1; i++)
                {
                    if (Details_DataGridView.Rows[i].Cells["Members"].Value == null || Details_DataGridView.Rows[i].Cells["Members"].Value.ToString() == ""
                        || Details_DataGridView.Rows[i].Cells["amount"].Value == null || Details_DataGridView.Rows[i].Cells["amount"].Value.ToString() == "")
                    {
                        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في جدول الشرائح", "Error");
                        return false;
                    }
                }
                return true;
            }
            else
            {
                int VisibleRows = 0;
                for (int i = 0; i < GroupDetails_DataGridView.Rows.Count - 1; i++)
                {
                    if (GroupDetails_DataGridView.Rows[i].Cells["Member_Edit"].Value == null || GroupDetails_DataGridView.Rows[i].Cells["Member_Edit"].Value.ToString() == ""
                        || GroupDetails_DataGridView.Rows[i].Cells["Amount_Edit"].Value == null || GroupDetails_DataGridView.Rows[i].Cells["Amount_Edit"].Value.ToString() == "")
                    {
                        MessageBox.Show("الرجاء التأكد من إدخال البيانات بشكل صحيح في جدول الشرائح", "Error");
                        return false;
                    }
                    if (GroupDetails_DataGridView.Rows[i].Visible)
                    {
                        VisibleRows++;
                    }
                }
                if (VisibleRows == 0)
                {
                    MessageBox.Show("الرجاء إدخال تفاصيل المجموعة", "Error");
                    return false;
                }
                return true;
            }

        }

        private void Get_Data()
        {
            if (materialTabControl1.SelectedTab.Name == "tabPage1")
            {
                GroupName = Name_textBox.Text;

                for (int i = 0; i < Details_DataGridView.Rows.Count - 1; i++)
                {
                    SegmentsGroup_Query += "(@segmentsgroup_id,'" + Details_DataGridView.Rows[i].Cells["Members"].Value + "', '" + (decimal.Parse(Details_DataGridView.Rows[i].Cells["amount"].Value.ToString())).ToString("G") + "')";
                    if (i < Details_DataGridView.Rows.Count - 2)
                        SegmentsGroup_Query += ",";
                }

                DialogResult dialogResult = MessageBox.Show("هل تريد تعيين هذه المجموعة كمجموعة افتراضية؟", "Alert", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Default = 1;
                }
                else
                {
                    Default = 0;
                }
            }
            else
            {
                for (int i = 0; i < GroupDetails_DataGridView.Rows.Count; i++)
                {
                    if (GroupDetails_DataGridView.Rows[i].Visible == false)
                        EditSegmentsGroup_Query += "DELETE FROM segmentsgroup_details WHERE id = '" + GroupDetails_DataGridView.Rows[i].Cells["InDatabase"].Value + "';";
                    else if (GroupDetails_DataGridView.Rows[i].Cells["IsDirty"].Value != null && (int)GroupDetails_DataGridView.Rows[i].Cells["IsDirty"].Value == 1)
                    {
                        if (GroupDetails_DataGridView.Rows[i].Cells["InDatabase"].Value != null)
                        {
                            EditSegmentsGroup_Query += "UPDATE segmentsgroup_details set NumberOfMembers = '" + GroupDetails_DataGridView.Rows[i].Cells["Member_Edit"].Value.ToString() + "', amount = '" + (decimal.Parse(GroupDetails_DataGridView.Rows[i].Cells["Amount_Edit"].Value.ToString())).ToString("G") + "' where id = '" + GroupDetails_DataGridView.Rows[i].Cells["InDatabase"].Value.ToString() + "';";
                        }
                        else
                        {
                            EditSegmentsGroup_Query += "INSERT INTO segmentsgroup_details (segmentsgroup_id, NumberOfMembers, amount) VALUES ('" + SegmentGroup_ID + "', '" + GroupDetails_DataGridView.Rows[i].Cells["Member_Edit"].Value.ToString() + "', '" + (decimal.Parse(GroupDetails_DataGridView.Rows[i].Cells["Amount_Edit"].Value.ToString())).ToString("G") + "');";
                        }
                    }
                }
            }
        }

        private void Details_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == Details_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == Details_DataGridView.Columns["Delete"].Index)
                {
                    if (e.RowIndex == Details_DataGridView.Rows.Count - 2)
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
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Details_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == Details_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;
                //Check if click is on specific column 
                if (e.ColumnIndex == Details_DataGridView.Columns["Delete"].Index && e.RowIndex == Details_DataGridView.Rows.Count - 2)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Details_DataGridView.Rows.RemoveAt(e.RowIndex);
                        Details_DataGridView.Rows[e.RowIndex].Cells["Members"].Value = e.RowIndex + 1;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Details_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                Details_DataGridView.Rows[e.RowIndex].Cells["Members"].Value = e.RowIndex + 1;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        public void Set_Controls()
        {
            SegmentsGroup_Query = GroupName = "";
            Default = -1;
            DataApproved = false;
            Name_textBox.Clear();
            Details_DataGridView.Rows.Clear();
            Name_textBox.Clear();
            EditSegmentsGroup_Query = "";
            GroupDetails_DataGridView_IsDirty = false;
        }

        private void MyDataGridViewInitializationMethod()
        {
            Details_DataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(MyDataGridView_EditingControlShowing);
            GroupDetails_DataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(MyDataGridView_EditingControlShowing);
        }

        private void MyDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Details_DataGridView.CurrentCellAddress.X == 0 || GroupDetails_DataGridView.CurrentCellAddress.X == 0))
            {
                e.Handled = true;
            }
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && (Details_DataGridView.CurrentCellAddress.X == 1 || GroupDetails_DataGridView.CurrentCellAddress.X == 1))
            {
                e.Handled = true;
            }
        }

        private void Save_Button_MouseEnter(object sender, EventArgs e)
        {
            Save_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Save_Button_MouseLeave(object sender, EventArgs e)
        {
            Save_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        private void Details_DataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            Details_DataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Format = "N0";
            Details_DataGridView.Columns[e.ColumnIndex].ValueType = typeof(Decimal);
        }

        // --------------Edite_TabPage--------------

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            try
            {
                if (Page2Enter == 0)
                {
                    Page2Enter = 1;
                    Bind_Group_ComboBox("");
                    Default_RadioButton.Visible = false;
                    Edit_Button.Visible = false; Delete_Button.Visible = false;
                    Note_Label.Visible = false;
                    GroupDetails_DataGridView.Visible = false;
                    Set_Controls();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            try
            {
                Page2Enter = 0;
                Set_Controls();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Bind_Group_ComboBox(string Group_ID)
        {
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
                    Group_ComboBox.Items.Add(new { Text = "Def. | " + dt.Rows[i][1], Value = dt.Rows[i][0].ToString() });
                else
                    Group_ComboBox.Items.Add(new { Text = dt.Rows[i][1], Value = dt.Rows[i][0].ToString() });

                if (Group_ID != "")
                {
                    if (dt.Rows[i][0].ToString() == Group_ID)
                        Index = Group_ComboBox.Items.Count - 1;
                }
            }
            Group_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            UserMode = true;

            if (Group_ID != "")
                Group_ComboBox.SelectedIndex = Index;
        }

        private void Bind_GroupDetails_DataGridView()
        {
            DataTable dt = c.Select_Table("segmentsgroup_details", " segmentsgroup_id = " + SegmentGroup_ID + "", true, false);

            GroupDetails_DataGridView.Rows.Clear();
            UserMode = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GroupDetails_DataGridView.Rows.Add();
                GroupDetails_DataGridView.Rows[i].Cells["Member_Edit"].Value = dt.Rows[i].Field<int>("NumberOfMembers");
                GroupDetails_DataGridView.Rows[i].Cells["Amount_Edit"].Value = dt.Rows[i].Field<float>("amount");
                GroupDetails_DataGridView.Rows[i].Cells["InDatabase"].Value = dt.Rows[i].Field<int>("id");
            }
            GroupDetails_DataGridView.Rows[GroupDetails_DataGridView.Rows.Count - 1].Cells["Member_Edit"].Value = GroupDetails_DataGridView.Rows.Count;
            UsedRow = GroupDetails_DataGridView.Rows.Count - 2;
            UserMode = true;
        }

        private void GroupDetails_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == GroupDetails_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == Details_DataGridView.Columns["Delete"].Index)
                {
                    if (e.RowIndex == UsedRow)
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
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Group_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    string SelectedText = "";
                    Default_RadioButton.Visible = true;
                    Edit_Button.Visible = true; Delete_Button.Visible = true;
                    Note_Label.Visible = true;
                    GroupDetails_DataGridView.Visible = true;
                    dynamic item = Group_ComboBox.SelectedItem;
                    if (item != null)
                    {
                        SelectedText = item.Text;
                        SegmentGroup_ID = int.Parse(item.Value);
                    }
                    UserMode = false;
                    if (SelectedText.StartsWith("Def. | "))
                        Default_RadioButton.Checked = true;
                    else
                        Default_RadioButton.Checked = false;
                    Bind_GroupDetails_DataGridView();
                    UserMode = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Default_RadioButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (Default_RadioButton.Checked)
                    {
                        MessageBox.Show("تم تعيين هذه المجموعة كمجموعة إفتراضية مسبقاً", "Error");
                    }
                    else if (!Default_RadioButton.Checked)
                    {
                        DialogResult dialogResult1 = MessageBox.Show("هل تريد تعيين هذه المجموعة كمجموعة افتراضية؟", "Alert", MessageBoxButtons.YesNo);
                        if (dialogResult1 == DialogResult.Yes)
                        {
                            d.Update_DefaultGroup(SegmentGroup_ID, Group_ComboBox.Text, 1, this.Name);
                            MessageBox.Show("تم تعيين المحموعة الإقتراضية بنجاح", "Confirmation");

                            Bind_Group_ComboBox(SegmentGroup_ID.ToString());
                            Default_RadioButton.Checked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EditSegmentsGroup_Query = "";
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = Edit_Button;

                DataApproved = Check_Data();

                if (DataApproved)
                {
                    if (!GroupDetails_DataGridView_IsDirty)
                    {
                        MessageBox.Show("لا يوجد أي تغييرات لحفظها ", "Error");
                        return;
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("إن تعديل بيانات المجموعة سيؤدي إلى تغيير المبالغ المحسوبة لجميع التوزيعات التي تستخدم هذه المجموعة...هل تريد المتبعة؟؟", "Warning", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Get_Data();

                            d.Update_SegmentsGroup(EditSegmentsGroup_Query, Group_ComboBox.Text, SegmentGroup_ID, this.Name);

                            MessageBox.Show("تم تعديل القائمة بنجاح", "Confirmation");
                            Set_Controls();
                            Bind_GroupDetails_DataGridView();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EditSegmentsGroup_Query = "";
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void SegmentsGroup_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    this.ActiveControl = Save_Button;

                    if (GroupDetails_DataGridView_IsDirty)
                    {
                        if (MessageBox.Show("يوجد بعض التعديلات غير المحفوظة، هل تود حفظها قبل إغلاق الصفحة؟؟", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Edit_Button.PerformClick();

                            //e.Cancel = true;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void GroupDetails_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex == GroupDetails_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                //Check if click is on specific column 
                if (e.ColumnIndex == GroupDetails_DataGridView.Columns["Delete1"].Index && e.RowIndex == UsedRow)
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (GroupDetails_DataGridView.Rows[e.RowIndex].Cells["InDatabase"].Value != null)
                        {
                            GroupDetails_DataGridView_IsDirty = true;
                            GroupDetails_DataGridView.Rows[e.RowIndex].Cells["IsDirty"].Value = "1";
                            GroupDetails_DataGridView.Rows[e.RowIndex].Visible = false;
                        }
                        else
                        {
                            GroupDetails_DataGridView.Rows.RemoveAt(e.RowIndex);
                        }
                        if (e.RowIndex == 0)
                        {
                            GroupDetails_DataGridView.Rows[GroupDetails_DataGridView.Rows.Count - 1].Cells["Member_Edit"].Value = 1;
                            UsedRow = 0;
                        }
                        else
                        {
                            for (int j = 1; j <= e.RowIndex; j++)
                            {
                                if (GroupDetails_DataGridView.Rows[e.RowIndex - j].Visible == true)
                                {
                                    GroupDetails_DataGridView.Rows[GroupDetails_DataGridView.Rows.Count - 1].Cells["Member_Edit"].Value =
                                        int.Parse(GroupDetails_DataGridView.Rows[e.RowIndex - j].Cells["Member_Edit"].Value.ToString()) + 1;
                                    UsedRow = e.RowIndex - j;
                                    break;
                                }
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

        private void GroupDetails_DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                GroupDetails_DataGridView.Columns["Amount_Edit"].DefaultCellStyle.Format = "N0";

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void GroupDetails_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GroupDetails_DataGridView_IsDirty = true;
                GroupDetails_DataGridView.Rows[e.RowIndex].Cells["IsDirty"].Value = 1;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void GroupDetails_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    for (int j = 1; j <= e.RowIndex; j++)
                    {
                        if (GroupDetails_DataGridView.Rows[e.RowIndex - j].Visible == true)
                        {
                            GroupDetails_DataGridView.Rows[GroupDetails_DataGridView.Rows.Count - 1].Cells["Member_Edit"].Value =
                                int.Parse(GroupDetails_DataGridView.Rows[e.RowIndex - j].Cells["Member_Edit"].Value.ToString()) + 1;
                            break;
                        }
                    }
                    UsedRow = e.RowIndex - 1;
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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (materialTabControl1.SelectedTab.Name == "tabPage1")
                {
                    Set_Controls();
                }
                else if (materialTabControl1.SelectedTab.Name == "tabPage2")
                {
                    string SelectedText = "";
                    Default_RadioButton.Visible = true;
                    Edit_Button.Visible = true; Delete_Button.Visible = true;
                    Note_Label.Visible = true;
                    GroupDetails_DataGridView.Visible = true;
                    dynamic item = Group_ComboBox.SelectedItem;
                    if (item != null)
                    {
                        SelectedText = item.Text;
                        SegmentGroup_ID = int.Parse(item.Value);
                    }
                    UserMode = false;
                    if (SelectedText.StartsWith("Def. | "))
                        Default_RadioButton.Checked = true;
                    else
                        Default_RadioButton.Checked = false;
                    Bind_GroupDetails_DataGridView();
                    UserMode = true;

                    Set_Controls();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Edit_Button_MouseEnter(object sender, EventArgs e)
        {
            Edit_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Edit_Button_MouseLeave(object sender, EventArgs e)
        {
            Edit_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        private void Delete_Button_MouseEnter(object sender, EventArgs e)
        {
            Delete_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Delete_Button_MouseLeave(object sender, EventArgs e)
        {
            Delete_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        private void GroupDetails_DataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            GroupDetails_DataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Format = "N0";
            GroupDetails_DataGridView.Columns[e.ColumnIndex].ValueType = typeof(Decimal);
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = Delete_Button;
                if (Default_RadioButton.Checked)
                {
                    MessageBox.Show("لا يمكن حذف المجموعة الإفتراضية", "Error");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف!!", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        d.Delete_SegmentsGroup(SegmentGroup_ID, Group_ComboBox.Text, this.Name);
                        MessageBox.Show("تم الحذف بنجاح", "Confirmation");
                        Bind_Group_ComboBox("");
                        Default_RadioButton.Visible = false;
                        Edit_Button.Visible = false; Delete_Button.Visible = false;
                        Note_Label.Visible = false;
                        GroupDetails_DataGridView.Visible = false;
                        Set_Controls();
                    }
                }
            }
            catch (Exception ex)
            {
                if (Program.MyConn != null && Program.MyConn.State == ConnectionState.Open)
                {
                    Program.MyConn.Close();
                }
                if (ex.Message.Contains("Cannot delete or update a parent row"))
                    MessageBox.Show("لا يمكن حذف هذا البند بسبب ارتباطه مع معلومات أخرى", "Error");
                else
                { if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); } }

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
    }
}
