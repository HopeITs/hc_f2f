using ClosedXML.Excel;
using F2F_Application.Classes;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Categories_Form : MaterialForm
    {
        public Categories_Form(Main_Form main_form)
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

        public Categories_Form(Categories_Form categories_form,string category)
        {
            InitializeComponent();
            this.categories_form = categories_form;
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
             
            Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(activeScreenDimensions.Width, activeScreenDimensions.Height);

            if(category == "partner")
            {
                Selected_Category = "partner";
            }
            else Selected_Category = "donor";

        }

        Categories_Form categories_form;
        Main_Form main_form;
        string Selected_Category;
        Categories c;
        bool DataApproved = false;
        bool UserMode;
        BindingSource bs = new BindingSource();

        private void Categories_Form_Load(object sender, EventArgs e)
        {
            try
            {
                c = new Categories();
                Categories_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
                AdditionalInfo_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);

                Bind_Categories_ComboBox();
                
                //Categories_ComboBox.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب الخطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        public void Bind_Categories_ComboBox()
        {
            if(Selected_Category == "partner")
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("Name");
                dt.Columns.Add("tableName");
                dt.Rows.Add(new object[] { "الشركاء", "partner" });
                UserMode = false;
                Categories_ComboBox.DataSource = dt;
            }
            else if (Selected_Category == "donor")
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("Name");
                dt.Columns.Add("tableName");
                dt.Rows.Add(new object[] { "الممولين", "donor" });
                UserMode = false;
                Categories_ComboBox.DataSource = dt;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("Name");
                dt.Columns.Add("tableName");

                dt.Rows.Add(new object[] { "المساعدات", "aid" });
                dt.Rows.Add(new object[] { "مدة المساعدة", "aidperiod" });
                dt.Rows.Add(new object[] { "مصدر المساعدة", "aidsource" });
                //dt.Rows.Add(new object[] { "الأملاك", "asset" });
                dt.Rows.Add(new object[] { "الأمراض", "disease" });
                dt.Rows.Add(new object[] { "صنف المرض", "diseasecategory" });
                dt.Rows.Add(new object[] { "التحصيل العلمي", "education" });
                dt.Rows.Add(new object[] { "نوع الدراسة", "educationtype" });
                dt.Rows.Add(new object[] { "المصاريف", "expenses" });
                dt.Rows.Add(new object[] { "الدخل", "income" });
                //dt.Rows.Add(new object[] { "الخسارات", "loss" });
                dt.Rows.Add(new object[] { "الحالة الإجتماعية", "maritalstatus" });
                dt.Rows.Add(new object[] { "الجنسية", "nationality" });
                dt.Rows.Add(new object[] { "الطوائف", "parish" });
                dt.Rows.Add(new object[] { "مجموعات الشركاء", "partnergroups" });
                dt.Rows.Add(new object[] { "ممول-شريك", "partner_donor" });
                dt.Rows.Add(new object[] { "حالة الأفراد", "personstate" });
                dt.Rows.Add(new object[] { "الصفة الأسرية", "relation" });
                dt.Rows.Add(new object[] { "موقع المنزل", "street" });
                dt.Rows.Add(new object[] { "العمل", "workexp" });
                dt.Rows.Add(new object[] { "المتطوعين", "visitor" });
                dt.Rows.Add(new object[] { "مكان الإقامة", "stateaddress" });

                UserMode = false;
                Categories_ComboBox.DataSource = dt;
            }
            
            Categories_ComboBox.DisplayMember = "Name";
            Categories_ComboBox.ValueMember = "tableName";
            Categories_ComboBox.SelectedIndex = 0;
            Selected_Category = Categories_ComboBox.SelectedValue.ToString();
            Set_Controls();
            
            UserMode = true;
        }

        private void Bind_ComboBoxes(bool KeepSelection)
        {
            List<string> From_Tables = new List<string> { "partner", "donor" }; 
            DataSet Tables = c.Select_Tables(From_Tables, true);
            Bind_ComboBox(Partner_ComboBox, Tables.Tables[0], KeepSelection);
            Bind_ComboBox(Donor_ComboBox, Tables.Tables[1], KeepSelection);
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

        private void Categories_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    Selected_Category = Categories_ComboBox.SelectedValue.ToString();
                    if(Selected_Category == "partner_donor")
                    {
                        Bind_ComboBoxes(false);
                        label2.Text = "Partner";
                        label3.Text = "Donor";
                        Name_textBox.Visible = false;
                        EName_textBox.Visible = false;
                        Partner_ComboBox.Visible = true;
                        Donor_ComboBox.Visible = true;
                        Partner_button.Visible = true;
                        Donor_button.Visible = true;
                    }
                    else
                    {
                        label2.Text = "Name";
                        label3.Text = "E-Name";
                        Partner_ComboBox.Visible = false;
                        Donor_ComboBox.Visible = false;
                        Name_textBox.Visible = true;
                        EName_textBox.Visible = true;
                        Partner_button.Visible = false;
                        Donor_button.Visible = false;
                    }
                    Set_Controls();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Bind_Categories_DataGridView()
        {
            UserMode = false;
            DataTable dt = c.Select_Table(Selected_Category, "", false, true);
            bs.DataSource = dt;
            Categories_DataGridView.Rows.Clear();
            if (Selected_Category == "disease")
            {
                Categories_DataGridView.Columns["Additional_Info"].HeaderText = "Disease Category";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Categories_DataGridView.Rows.Add();
                    Categories_DataGridView.Rows[i].Cells["id"].Value = dt.Rows[i].Field<int>("id");
                    Categories_DataGridView.Rows[i].Cells["Info"].Value = dt.Rows[i].Field<string>("name");
                    Categories_DataGridView.Rows[i].Cells["Name_En"].Value = dt.Rows[i].Field<string>("name_en");
                    Categories_DataGridView.Rows[i].Cells["Additional_Info"].Value = dt.Rows[i].Field<int>("diseasecategory_id");
                    Categories_DataGridView.Rows[i].Cells["isfatal"].Value = dt.Rows[i].Field<int>("isfatal");
                    Categories_DataGridView.Rows[i].Cells["isdisability"].Value = dt.Rows[i].Field<int>("isdisability");
                }
            }
            else if (Selected_Category == "partner_donor")
            {
                //Categories_DataGridView.Columns["Additional_Info"].HeaderText = "Disease Category";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Categories_DataGridView.Rows.Add();
                    Categories_DataGridView.Rows[i].Cells["id"].Value = dt.Rows[i].Field<int>("id");
                    Categories_DataGridView.Rows[i].Cells["Partner"].Value = dt.Rows[i].Field<string>("Partner");
                    Categories_DataGridView.Rows[i].Cells["Donor"].Value = dt.Rows[i].Field<string>("Donor");
                    
                }
            }
            else if (Selected_Category == "personstate")
            {
                Categories_DataGridView.Columns["Additional_Info"].HeaderText = "Type";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Categories_DataGridView.Rows.Add();
                    Categories_DataGridView.Rows[i].Cells["id"].Value = dt.Rows[i].Field<int>("id");
                    Categories_DataGridView.Rows[i].Cells["Info"].Value = dt.Rows[i].Field<string>("name");
                    Categories_DataGridView.Rows[i].Cells["Name_En"].Value = dt.Rows[i].Field<string>("name_en");
                    Categories_DataGridView.Rows[i].Cells["Additional_Info"].Value = dt.Rows[i].Field<string>("type") == "Active" ? 1 : 0;
                }
            }
            
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Categories_DataGridView.Rows.Add();
                    Categories_DataGridView.Rows[i].Cells["id"].Value = dt.Rows[i].Field<int>("id");
                    Categories_DataGridView.Rows[i].Cells["Info"].Value = dt.Rows[i].Field<string>("name");
                    Categories_DataGridView.Rows[i].Cells["Name_En"].Value = dt.Rows[i].Field<string>("name_en");
                }
            }
            UserMode = true;
        }

        public void Bind_AdditionalInfo_ComboBox()
        {
            AdditionalInfo_label.Visible = AdditionalInfo_ComboBox.Visible = true;
            DataTable dt = new DataTable();
            if (Selected_Category == "disease")
            {
                AdditionalInfo_label.Text = "Disease Category:";
                dt = c.Select_Table("diseasecategory", "", false, true);
            }
            else if (Selected_Category == "personstate")
            {
                AdditionalInfo_label.Text = "Type:";
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("id", typeof(int));

                dt.Rows.Add("active", 1);
                dt.Rows.Add("disactive", 0);
            }
            AdditionalInfo_ComboBox.DataSource = dt;
            AdditionalInfo_ComboBox.DisplayMember = "name";
            AdditionalInfo_ComboBox.ValueMember = "id";
            AdditionalInfo_ComboBox.SelectedIndex = -1;

            this.Additional_Info.DataSource = dt;
            this.Additional_Info.DisplayMember = "name";
            this.Additional_Info.ValueMember = "id";
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void Categories_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private bool Check_Data()
        {
            if (Selected_Category == "" || Categories_ComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("الرجاء تحديد الفئة", "Error");
                return false;
            }
            if (Selected_Category != "partner_donor"){
                if (Name_textBox.Text == "")
                {
                    MessageBox.Show("لا يمكن ترك خانة الاسم فارغة", "Error");
                    return false;
                }
            }
            else
            {
                if( Partner_ComboBox.SelectedValue == null || Donor_ComboBox.SelectedValue == null)
                {
                    MessageBox.Show("الرجاء تحديد الممول والشريك !", "Error");
                    return false;
                }
            }
            if (Selected_Category == "disease")
            {
                if (AdditionalInfo_ComboBox.SelectedValue == null || AdditionalInfo_ComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("الرجاء تحديد فئة المرض", "Error");
                    return false;
                }
            }
            if (Selected_Category == "personstate")
            {
                if (AdditionalInfo_ComboBox.SelectedValue == null || AdditionalInfo_ComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("الرجاء تحديد النوع", "Error");
                    return false;
                }
            }
            return true;
        }

        private void Insert_button_Click(object sender, EventArgs e)
        {
            try
            {
                DataApproved = false;
                DataApproved = Check_Data();
                if (DataApproved)
                {
                    if (Selected_Category == "disease")
                    {
                        int diseasecategory_id = int.Parse(AdditionalInfo_ComboBox.SelectedValue.ToString());
                        int IsFatal = IsFatal_RadioButton.Checked == true ? 1 : 0;
                        int IsDisability = IsDisability_RadioButton.Checked == true ? 1 : 0;
                        c.Insert_Into_Tabel(Selected_Category, Name_textBox.Text, EName_textBox.Text, "", diseasecategory_id, IsFatal, IsDisability, this.Name);
                    }
                    else if (Selected_Category == "personstate")
                    {
                        c.Insert_Into_Tabel(Selected_Category, Name_textBox.Text, EName_textBox.Text, AdditionalInfo_ComboBox.SelectedValue.ToString() == "1" ? "Active" : "disactive", -1, -1, -1, this.Name);
                    }
                    else if (Selected_Category == "partner_donor")
                    {
                        DataSet ds = c.CheckIfExist(Selected_Category, Partner_ComboBox.SelectedValue.ToString(), Donor_ComboBox.SelectedValue.ToString(),this.Name);
                        if(ds.Tables[0].Rows.Count != 0)
                        {
                            MessageBox.Show("هذا الارتباط موجود مسبقاً");
                            return;
                        }
                        else
                        {
                            c.Insert_Into_Tabel(Selected_Category, Partner_ComboBox.SelectedValue.ToString(), Donor_ComboBox.SelectedValue.ToString(), "", -1, -1, -1, this.Name);
                        }
                    }
                    else
                    {
                        c.Insert_Into_Tabel(Selected_Category, Name_textBox.Text, EName_textBox.Text, "", -1, -1, -1, this.Name);
                    }
                    MessageBox.Show("تم الإدخال بنجاح", "Confirmation");
                    Set_Controls();
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

        private void Categories_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == Categories_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == Categories_DataGridView.Columns["Delete"].Index)
                {
                    this.SuspendLayout();
                    Image image = null;
                    image = Properties.Resources.Trash_Small_L;
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                    var size = image.Size;
                    var location = new Point((e.CellBounds.Width - size.Width) / 2, (e.CellBounds.Height - size.Height) / 2);
                    location.Offset(e.CellBounds.Location);
                    e.Graphics.DrawImage(image, location);

                    e.Handled = true;
                    this.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Categories_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                //Check if click is on specific column 
                if (Categories_DataGridView.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    if (Categories_DataGridView.Rows.Count <= 1)
                    {
                        MessageBox.Show("لا يمكن حذف جميع العناصر من هذه الفئة", "Error");
                        Set_Controls();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int ID = int.Parse(Categories_DataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString());
                            if(Selected_Category == "partner_donor")
                            {
                                string Name = Categories_DataGridView.Rows[e.RowIndex].Cells["Partner"].Value.ToString();
                            }
                            else
                            {
                                string Name = Categories_DataGridView.Rows[e.RowIndex].Cells["info"].Value.ToString();
                            }
                            c.Delete_From_table(Selected_Category, ID, Name, this.Name);
                            MessageBox.Show("تم الحذف بنجاح", "Confirmation");
                        }
                        Set_Controls();
                    }
                }
                else if (Categories_DataGridView.Columns[e.ColumnIndex].HeaderText == "Is Fatal" || Categories_DataGridView.Columns[e.ColumnIndex].HeaderText == "Is Disability")
                {
                    Categories_DataGridView.EndEdit();
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

        private void Categories_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    //if click is on new row or header row
                    if (e.RowIndex < 0 || e.ColumnIndex < 0)
                        return;

                    Update_Row(e.RowIndex);
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

        private void Update_Row(int RowIndex)
        {
            DialogResult dialogResult = MessageBox.Show("تأكيد التعديل", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Categories_DataGridView.Rows[RowIndex].Cells["info"].Value == null || string.IsNullOrWhiteSpace(Categories_DataGridView.Rows[RowIndex].Cells["info"].Value.ToString()))
                {
                    if (Selected_Category != "partner_donor")
                    {
                        MessageBox.Show("لا يمكن ترك خانة الاسم فارغة", "Error");
                        return;
                    }
                }
                else
                {
                    int ID = int.Parse(Categories_DataGridView.Rows[RowIndex].Cells["id"].Value.ToString());
                    string Name = Categories_DataGridView.Rows[RowIndex].Cells["info"].Value.ToString();
                    string EName;
                    if (Categories_DataGridView.Rows[RowIndex].Cells["Name_En"].Value == null || string.IsNullOrWhiteSpace(Categories_DataGridView.Rows[RowIndex].Cells["Name_En"].Value.ToString()))
                        EName = "";
                    else
                        EName = Categories_DataGridView.Rows[RowIndex].Cells["Name_En"].Value.ToString();
                    if (Selected_Category == "disease")
                    {
                        int Disease_Category_ID = (int)Categories_DataGridView.Rows[RowIndex].Cells["Additional_Info"].Value;
                        int IsFatal = Categories_DataGridView.Rows[RowIndex].Cells["isfatal"].Value.ToString() == "True" || Categories_DataGridView.Rows[RowIndex].Cells["isfatal"].Value.ToString() == "1" ? 1 : 0;
                        int IsDisability = Categories_DataGridView.Rows[RowIndex].Cells["isdisability"].Value.ToString() == "True" || Categories_DataGridView.Rows[RowIndex].Cells["isdisability"].Value.ToString() == "1" ? 1 : 0;
                        c.Update_Table(Selected_Category, ID, Name, EName, "", Disease_Category_ID, IsFatal, IsDisability, this.Name);
                    }
                    else if (Selected_Category == "personstate")
                    {
                        string Type = (int)Categories_DataGridView.Rows[RowIndex].Cells["Additional_Info"].Value == 1 ? "Active" : "disactive";
                        c.Update_Table(Selected_Category, ID, Name, EName, Type, -1, -1, -1, this.Name);
                    }
                    else
                    {
                        c.Update_Table(Selected_Category, ID, Name, EName, "", -1, -1, -1, this.Name);
                    }
                    MessageBox.Show("تم التعديل بنجاح", "Confirmation");
                }
            }
            Set_Controls();
        }

        private void Set_Controls()
        {
            Name_textBox.Clear(); EName_textBox.Clear();
            IsDisability_RadioButton.Checked = IsFatal_RadioButton.Checked = false;

            Categories_DataGridView.Columns["Additional_Info"].Visible = false;
            Categories_DataGridView.Columns["isdisability"].Visible = false;
            Categories_DataGridView.Columns["Partner"].Visible = false;
            Categories_DataGridView.Columns["Donor"].Visible = false;
            Categories_DataGridView.Columns["isfatal"].Visible = false;
            AdditionalInfo_label.Visible = AdditionalInfo_ComboBox.Visible = false;
            Partner_ComboBox.Visible = false;
            Donor_ComboBox.Visible = false;
            Partner_button.Visible = false;
            Donor_button.Visible = false;
            DiseaseInfo_TableLayoutPanel.Visible = false;

            if (Selected_Category == "disease")
            {
                Categories_DataGridView.Columns["Info"].Visible = true;
                Categories_DataGridView.Columns["Name_En"].Visible = true;
                Categories_DataGridView.Columns["Additional_Info"].Visible = true;
                Categories_DataGridView.Columns["isdisability"].Visible = true;
                Categories_DataGridView.Columns["isfatal"].Visible = true;
                Bind_AdditionalInfo_ComboBox();
                DiseaseInfo_TableLayoutPanel.Visible = true;
            }
            else if (Selected_Category == "personstate")
            {
                Categories_DataGridView.Columns["Additional_Info"].Visible = true;
                Categories_DataGridView.Columns["Info"].Visible = true;
                Categories_DataGridView.Columns["Name_En"].Visible = true;
                Bind_AdditionalInfo_ComboBox();
            }
            else if (Selected_Category == "partner_donor")
            {
                Categories_DataGridView.Columns["Info"].Visible = false;
                Categories_DataGridView.Columns["Name_En"].Visible = false;
                Categories_DataGridView.Columns["Partner"].Visible = true;
                Categories_DataGridView.Columns["Donor"].Visible = true;
                Partner_ComboBox.Visible = true;
                Donor_ComboBox.Visible = true;
                Partner_button.Visible = true;
                Donor_button.Visible = true;
            }
            else
            {
                Categories_DataGridView.Columns["Info"].Visible = true;
                Categories_DataGridView.Columns["Name_En"].Visible = true;
                Partner_ComboBox.Visible = false;
                Donor_ComboBox.Visible = false;
            }


            Bind_Categories_DataGridView();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Selected_Category = Categories_ComboBox.Text.ToString().Replace(" ", String.Empty).ToLower();

                Set_Controls();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Insert_button_MouseEnter(object sender, EventArgs e)
        {
            Insert_button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Insert_button_MouseLeave(object sender, EventArgs e)
        {
            Insert_button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        private void Categories_DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                ComboBox cb = (ComboBox)e.Control;
                cb.DrawMode = DrawMode.OwnerDrawVariable;
                cb.DrawItem -= ComboBox_DrawItem;
                cb.DrawItem += ComboBox_DrawItem;
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

        private void English_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z')) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Excel_Button_MouseEnter(object sender, EventArgs e)
        {
            Excel_Button.BackgroundImage = F2F_Application.Properties.Resources.Export_2;

        }

        private void Excel_Button_MouseLeave(object sender, EventArgs e)
        {
            Excel_Button.BackgroundImage = F2F_Application.Properties.Resources.Export_1;

        }

        private void Excel_Button_Click(object sender, EventArgs e)
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
                        // Saves the Image via a FileStream created by the OpenFile method.  
                        System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                        filepath = saveFileDialog1.FileName;
                        fs.Close();
                    }
                }

                if (!string.IsNullOrWhiteSpace(filepath))
                {

                    XLWorkbook wb = new XLWorkbook();

                    DataTable dt = ((DataTable)bs.DataSource).DefaultView.ToTable();

                    //DataTable dt = SignitaureList_DataGridView.DataSource.ToTable();

                    wb.Worksheets.Add(dt, Categories_ComboBox.Text + "Data");
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

        private void IsDisability_RadioButton_Click(object sender, EventArgs e)
        {
            try
            {
                IsDisability_RadioButton.Checked = !IsDisability_RadioButton.Checked;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void IsFatal_RadioButton_Click(object sender, EventArgs e)
        {
            try
            {
                IsFatal_RadioButton.Checked = !IsFatal_RadioButton.Checked;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void Partner_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void PartnerBtn_MouseEnter(object sender, EventArgs e)
        {
            Partner_button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;
        }

        private void Donor_button_MouseEnter(object sender, EventArgs e)
        {
            Donor_button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;
        }

        private void Partner_button_MouseLeave(object sender, EventArgs e)
        {
            Partner_button.BackgroundImage = F2F_Application.Properties.Resources.button1;
        }

        private void Donor_button_MouseLeave(object sender, EventArgs e)
        {
            Donor_button.BackgroundImage = F2F_Application.Properties.Resources.button1;
        }

        private void Partner_button_Click(object sender, EventArgs e)
        {
            try
            {
                Categories_Form Categories_Form = new Categories_Form(this,"partner");
                Categories_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Donor_button_Click(object sender, EventArgs e)
        {
            try
            {
                Categories_Form Categories_Form = new Categories_Form(this, "donor");
                Categories_Form.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
    }
}
