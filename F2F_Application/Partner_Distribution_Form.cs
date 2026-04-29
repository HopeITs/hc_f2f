using ClosedXML.Excel;
using F2F_Application.Classes;
using System;
using System.Data;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;





namespace F2F_Application
{
    public partial class Partner_Distribution_Form : Form
    {

        public Partner_Distribution_Form(Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            MyDataGridViewInitializationMethod();
            CommingDistribution_DataGridView.DoubleBuffered(true);
            NotFinishedDistribution_DataGridView.DoubleBuffered(true);
            DoneDistribution_DataGridView.DoubleBuffered(true);
        }

        bool UserMode;
        Main_Form main_form;
        Categories c;
        Distribution d;
        Partner p;

        private void Partner_Distribution_Form_Load(object sender, EventArgs e)
        {
            try
            {
                c = new Categories(); d = new Distribution(); p = new Partner();
                Bind_Partner_ComboBox();
                Bind_Donor_ComoBox();
                Bind_Distribution_ComboBox();

                Partner_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
                Distribution_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم هذه الصفحة بسبب الخطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Partner_Distribution_Form_Shown(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(this.Width - 10, 1260);

        }

        private void Bind_Partner_ComboBox()
        {
            int SelectedValue = -1;
            if (Partner_ComboBox.SelectedValue != null)
                SelectedValue = int.Parse(Partner_ComboBox.SelectedValue.ToString());

            DataTable dt = c.Select_Table("partner", "", true, false);
            UserMode = false;
            Partner_ComboBox.DataSource = dt;
            Partner_ComboBox.DisplayMember = "name";
            Partner_ComboBox.ValueMember = "id";
            if (SelectedValue != -1)
                Partner_ComboBox.SelectedValue = SelectedValue;
            else
                Partner_ComboBox.SelectedIndex = -1;
            UserMode = true;
        }
        private void Bind_Donor_ComoBox()
        {
            int SelectedDonorValue = 0;
            if (Donor_ComboBox.SelectedValue != null)
                SelectedDonorValue = int.Parse(Donor_ComboBox.SelectedValue.ToString());

            DataTable dt = c.Select_Table("donor", "", true, false);
            UserMode = false;
            Donor_ComboBox.DisplayMember = "name";
            Donor_ComboBox.ValueMember = "id";
            Donor_ComboBox.DataSource = dt;
            
            if (SelectedDonorValue != 0)
                Donor_ComboBox.SelectedValue = SelectedDonorValue;
            else
                Donor_ComboBox.SelectedIndex = 0;
            UserMode = true;
        }

        private void Bind_Distribution_ComboBox()
        {
            int SelectedValue = -1;
            if (Distribution_ComboBox.SelectedValue != null)
                SelectedValue = int.Parse(Distribution_ComboBox.SelectedValue.ToString());

            UserMode = false;
            string Date = dateTimePicker1.Value.ToString("dd/MM/yyyy", new CultureInfo("en-GB"));

            DataTable dt = d.Get_All_Distributions(Date);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("لا يوجد توزيعات لعرضها في هذا العام", "Error");
                Distribution_ComboBox.DataSource = null;
                UserMode = true;
            }
            else
            {
                Distribution_ComboBox.DataSource = null;
                Distribution_ComboBox.DataSource = dt;
                Distribution_ComboBox.DisplayMember = "name";
                Distribution_ComboBox.ValueMember = "id";
                if (SelectedValue != -1)
                    Distribution_ComboBox.SelectedValue = SelectedValue;
                else
                    Distribution_ComboBox.SelectedIndex = -1;
            }
            UserMode = true;
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        public void Bind_Partner_Distribution()
        {
            int Partner_ID = Partner_ComboBox.SelectedIndex == -1 ? -1 : int.Parse(Partner_ComboBox.SelectedValue.ToString());
            int Donor_ID = Donor_ComboBox.SelectedIndex == -1 ? 0 : int.Parse(Donor_ComboBox.SelectedValue.ToString());
            int Distribution_ID = Distribution_ComboBox.SelectedIndex == -1 ? -1 : int.Parse(Distribution_ComboBox.SelectedValue.ToString());
            string Year = dateTimePicker1.Value.ToString("yyyy", new CultureInfo("en-GB"));


            if (Partner_ID == -1 && Distribution_ID == -1 && Donor_ID == 0)
            {
                CommingDistribution_DataGridView.DataSource = null;
                CommingDistribution_DataGridView.Columns.Clear();

                NotFinishedDistribution_DataGridView.DataSource = null;
                NotFinishedDistribution_DataGridView.Columns.Clear();

                DoneDistribution_DataGridView.DataSource = null;
                DoneDistribution_DataGridView.Columns.Clear();
            }
            else
            {
                DataSet ds = d.Get_Partner_Distribution(Partner_ID,Donor_ID, Distribution_ID, Year);

                CommingDistribution_DataGridView.DataSource = null;
                CommingDistribution_DataGridView.Columns.Clear();
                CommingDistribution_DataGridView.DataSource = ds.Tables[0];
                CommingDistribution_DataGridView.ColumnHeadersVisible = true;

                NotFinishedDistribution_DataGridView.DataSource = null;
                NotFinishedDistribution_DataGridView.Columns.Clear();
                NotFinishedDistribution_DataGridView.DataSource = ds.Tables[1];
                NotFinishedDistribution_DataGridView.ColumnHeadersVisible = true;

                DoneDistribution_DataGridView.DataSource = null;
                DoneDistribution_DataGridView.Columns.Clear();
                DoneDistribution_DataGridView.DataSource = ds.Tables[2];
                DoneDistribution_DataGridView.ColumnHeadersVisible = true;

                CommingDistribution_DataGridView.Columns["partner_distribution_id"].Visible = DoneDistribution_DataGridView.Columns["partner_distribution_id"].Visible = NotFinishedDistribution_DataGridView.Columns["partner_distribution_id"].Visible = false;
                CommingDistribution_DataGridView.Columns["distribution_id"].Visible = DoneDistribution_DataGridView.Columns["distribution_id"].Visible = NotFinishedDistribution_DataGridView.Columns["distribution_id"].Visible = false;
                CommingDistribution_DataGridView.Columns["partner_id"].Visible = DoneDistribution_DataGridView.Columns["partner_id"].Visible = NotFinishedDistribution_DataGridView.Columns["partner_id"].Visible = false;
                CommingDistribution_DataGridView.Columns["listapproved"].Visible = DoneDistribution_DataGridView.Columns["listapproved"].Visible = NotFinishedDistribution_DataGridView.Columns["listapproved"].Visible = false;
                CommingDistribution_DataGridView.Columns["donor_id"].Visible = DoneDistribution_DataGridView.Columns["donor_id"].Visible = NotFinishedDistribution_DataGridView.Columns["donor_id"].Visible = false;
                CommingDistribution_DataGridView.Columns["partner_donor_id"].Visible = DoneDistribution_DataGridView.Columns["partner_donor_id"].Visible = NotFinishedDistribution_DataGridView.Columns["partner_donor_id"].Visible = false;


                Add_Columns();

                foreach (DataGridViewColumn C in CommingDistribution_DataGridView.Columns)
                {
                    if (C.Name != "المبالغ الإدارية" && C.Name != "المبلغ المسلم للكنيسة")
                        C.ReadOnly = true;
                    else
                        C.ReadOnly = false;
                }

                foreach (DataGridViewColumn C in NotFinishedDistribution_DataGridView.Columns)
                {
                    if (C.Name != "المبالغ الإدارية" && C.Name != "المبلغ المسلم للكنيسة")
                        C.ReadOnly = true;
                    else
                        C.ReadOnly = false;
                }

                foreach (DataGridViewColumn C in DoneDistribution_DataGridView.Columns)
                {
                    if (C.Name != "المبالغ الإدارية" && C.Name != "المبلغ المسلم للكنيسة")
                        C.ReadOnly = true;
                    else
                        C.ReadOnly = false;
                }

                foreach (DataGridViewRow R in CommingDistribution_DataGridView.Rows)
                {
                    if (float.Parse(R.Cells["الفرق"].Value.ToString()) != 0)
                    {
                        R.Cells["الفرق"].Style.BackColor = Color.Red; //Color.FromArgb(125, 0, 0);
                    }
                }
                foreach (DataGridViewRow R in NotFinishedDistribution_DataGridView.Rows)
                {
                    if (float.Parse(R.Cells["الفرق"].Value.ToString()) != 0)
                    {
                        R.Cells["الفرق"].Style.BackColor = Color.Red; //Color.FromArgb(125, 0, 0);
                    }
                }
                foreach (DataGridViewRow R in DoneDistribution_DataGridView.Rows)
                {
                    if (float.Parse(R.Cells["الفرق"].Value.ToString()) != 0)
                    {
                        R.Cells["الفرق"].Style.BackColor = Color.Red; //Color.FromArgb(125, 0, 0);
                    }
                }
            }

        }

        public void Add_Columns()
        {
            DataGridViewButtonColumn colCB1 = new DataGridViewButtonColumn();
            colCB1.Name = "Comming_Signature_List";
            colCB1.HeaderText = "List";
            colCB1.FlatStyle = FlatStyle.Flat;
            colCB1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colCB1.MinimumWidth = 50;
            colCB1.Width = 50;
            colCB1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CommingDistribution_DataGridView.Columns.Add(colCB1);

            DataGridViewButtonColumn colCB2 = new DataGridViewButtonColumn();
            colCB2.Name = "Comming_Delete";
            colCB2.HeaderText = "Delete";
            colCB2.FlatStyle = FlatStyle.Flat;
            colCB2.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colCB2.MinimumWidth = 50;
            colCB2.Width = 50;
            colCB2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CommingDistribution_DataGridView.Columns.Add(colCB2);

            DataGridViewButtonColumn colCB3 = new DataGridViewButtonColumn();
            colCB3.Name = "Done_Signature_List";
            colCB3.HeaderText = "List";
            colCB3.FlatStyle = FlatStyle.Flat;
            colCB3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colCB3.MinimumWidth = 50;
            colCB3.Width = 50;
            colCB3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NotFinishedDistribution_DataGridView.Columns.Add(colCB3);

            DataGridViewButtonColumn colCB4 = new DataGridViewButtonColumn();
            colCB4.Name = "Done_Delete";
            colCB4.HeaderText = "Delete";
            colCB4.FlatStyle = FlatStyle.Flat;
            colCB4.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colCB4.MinimumWidth = 50;
            colCB4.Width = 50;
            colCB4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NotFinishedDistribution_DataGridView.Columns.Add(colCB4);

            DataGridViewButtonColumn colCB5 = new DataGridViewButtonColumn();
            colCB5.Name = "Done_Signature_List";
            colCB5.HeaderText = "List";
            colCB5.FlatStyle = FlatStyle.Flat;
            colCB5.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colCB5.MinimumWidth = 50;
            colCB5.Width = 50;
            colCB5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DoneDistribution_DataGridView.Columns.Add(colCB5);

            /*
            DataGridViewButtonColumn colCB6 = new DataGridViewButtonColumn();
            colCB6.Name = "Done_Delete";
            colCB6.HeaderText = "Delete";
            colCB6.FlatStyle = FlatStyle.Flat;
            colCB6.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colCB6.MinimumWidth = 50;
            colCB6.Width = 50;
            colCB6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DoneDistribution_DataGridView.Columns.Add(colCB6);
            */
        }

        #region //Cell Painting
        private void CommingDistribution_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == CommingDistribution_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == CommingDistribution_DataGridView.Columns["Comming_Delete"].Index)
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
                else if (e.ColumnIndex == CommingDistribution_DataGridView.Columns["Comming_Signature_List"].Index)
                {
                    Image image = null;
                    image = Properties.Resources.list;
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

        private void NotFinishedDistribution_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == NotFinishedDistribution_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (NotFinishedDistribution_DataGridView.Columns["Done_Delete"] == null ||
                    NotFinishedDistribution_DataGridView.Columns["Done_Signature_List"] == null) return;

                if (e.ColumnIndex == NotFinishedDistribution_DataGridView.Columns["Done_Delete"].Index)
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
                else if (e.ColumnIndex == NotFinishedDistribution_DataGridView.Columns["Done_Signature_List"].Index)
                {
                    Image image = null;
                    image = Properties.Resources.list;
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

        private void DoneDistribution_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == DoneDistribution_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;
                /*
                if (e.ColumnIndex == DoneDistribution_DataGridView.Columns["Done_Delete"].Index)
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
                */
                else if (e.ColumnIndex == DoneDistribution_DataGridView.Columns["Done_Signature_List"].Index)
                {
                    Image image = null;
                    image = Properties.Resources.list;
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
        #endregion

        #region // Cell DoubleClick

        private void CommingDistribution_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == CommingDistribution_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (CommingDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "تاريخ التوزيعة")
                {
                    int Distribution_ID = int.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["distribution_id"].Value.ToString());
                    int Partner_Distribution_ID = int.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_distribution_id"].Value.ToString());
                    int Partner_ID = int.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_id"].Value.ToString());
                    Partner_Distribution_Date_Form Partner_Distribution_Date_Form = new Partner_Distribution_Date_Form(Partner_ID, Distribution_ID, Partner_Distribution_ID, main_form);
                    DialogResult dialogResult = Partner_Distribution_Date_Form.ShowDialog();
                    if (dialogResult == DialogResult.Yes)
                    {
                        Bind_Partner_Distribution();
                    }
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NotFinishedDistribution_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == NotFinishedDistribution_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (NotFinishedDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "تاريخ التوزيعة")
                {
                    int Distribution_ID = int.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["distribution_id"].Value.ToString());
                    int Partner_Distribution_ID = int.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_distribution_id"].Value.ToString());
                    int Partner_ID = int.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_id"].Value.ToString());
                    Partner_Distribution_Date_Form Partner_Distribution_Date_Form = new Partner_Distribution_Date_Form(Partner_ID, Distribution_ID, Partner_Distribution_ID, main_form);
                    DialogResult dialogResult = Partner_Distribution_Date_Form.ShowDialog();
                    if (dialogResult == DialogResult.Yes)
                    {
                        Bind_Partner_Distribution();
                    }
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void DoneDistribution_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == DoneDistribution_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (DoneDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "تاريخ التوزيعة")
                {
                    int Distribution_ID = int.Parse(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["distribution_id"].Value.ToString());
                    int Partner_Distribution_ID = int.Parse(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_distribution_id"].Value.ToString());
                    int Partner_ID = int.Parse(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_id"].Value.ToString());
                    Partner_Distribution_Date_Form Partner_Distribution_Date_Form = new Partner_Distribution_Date_Form(Partner_ID, Distribution_ID, Partner_Distribution_ID, main_form);
                    DialogResult dialogResult = Partner_Distribution_Date_Form.ShowDialog();
                    if (dialogResult == DialogResult.Yes)
                    {
                        Bind_Partner_Distribution();
                    }
                }

                Bind_Partner_Distribution();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        #endregion

        #region // Cell ContentClick
        private void CommingDistribution_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                //Check if click is on specific column 
                if (CommingDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int Distribution_ID = int.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["distribution_id"].Value.ToString());
                        int Partner_Donor_ID = int.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_donor_id"].Value.ToString());
                        p.Delete_Partner_Distribution(Partner_Donor_ID, Distribution_ID, this.Name);
                        MessageBox.Show("تم الحذف بنجاح", "Confirmation");
                        Bind_Partner_Distribution();
                    }
                }
                else if (CommingDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "List")
                {
                    int Distribution_ID = int.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["distribution_id"].Value.ToString());
                    int Approved = int.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["listapproved"].Value.ToString());
                    int Partner_Distribution_ID = int.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_distribution_id"].Value.ToString());
                    int Partner_ID = int.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_id"].Value.ToString());
                    int Donor_ID = int.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["donor_id"].Value.ToString());
                    string Partner_Name = CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["الشريك"].Value.ToString();
                    string Donor_Name = CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["اسم الممول"].Value.ToString();
                    string Month = CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["شهر التوزيعة"].Value.ToString();
                    string Date = CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["تاريخ التوزيعة"].Value.ToString();
                    Signitaure_List_Form Signitaure_List_Form = new Signitaure_List_Form(Partner_ID, Donor_ID, Partner_Name,Donor_Name, Month, Date, Distribution_ID, Partner_Distribution_ID, Approved, main_form);
                    DialogResult dialogResult = Signitaure_List_Form.ShowDialog();
                    if (dialogResult == DialogResult.Yes)
                    {
                        Bind_Partner_Distribution();
                    }
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

        private void NotFinishedDistribution_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                //Check if click is on specific column 
                if (NotFinishedDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int Distribution_ID = int.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["distribution_id"].Value.ToString());
                        int Partner_Donor_ID = int.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_donor_id"].Value.ToString());
                        p.Delete_Partner_Distribution(Partner_Donor_ID, Distribution_ID, this.Name);
                        MessageBox.Show("تم الحذف بنجاح", "Confirmation");
                        Bind_Partner_Distribution();
                    }
                }
                else if (NotFinishedDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "List")
                {
                    int Distribution_ID = int.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["distribution_id"].Value.ToString());
                    int Approved = int.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["listapproved"].Value.ToString());
                    int Partner_Distribution_ID = int.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_distribution_id"].Value.ToString());
                    int Partner_ID = int.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_id"].Value.ToString());
                    int Donor_ID = int.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["donor_id"].Value.ToString());
                    string Partner_Name = NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["الشريك"].Value.ToString();
                    string Donor_Name = NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["اسم الممول"].Value.ToString();
                    string Month = NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["شهر التوزيعة"].Value.ToString();
                    string Date = NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["تاريخ التوزيعة"].Value.ToString();
                    Signitaure_List_Form Signitaure_List_Form = new Signitaure_List_Form(Partner_ID, Donor_ID, Partner_Name, Donor_Name, Month, Date, Distribution_ID, Partner_Distribution_ID, Approved, main_form);
                    DialogResult dialogResult = Signitaure_List_Form.ShowDialog();
                    if (dialogResult == DialogResult.Yes)
                    {
                        Bind_Partner_Distribution();
                    }
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

        private void DoneDistribution_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                //Check if click is on specific column 
                if (DoneDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "List")
                {
                    int Distribution_ID = int.Parse(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["distribution_id"].Value.ToString());
                    int Approved = int.Parse(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["listapproved"].Value.ToString());
                    int Partner_Distribution_ID = int.Parse(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_distribution_id"].Value.ToString());
                    int Partner_ID = int.Parse(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_id"].Value.ToString());
                    int Donor_ID = int.Parse(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["donor_id"].Value.ToString());
                    string Partner_Name = DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["الشريك"].Value.ToString();
                    string Donor_Name = DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["اسم الممول"].Value.ToString();
                    string Month = DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["شهر التوزيعة"].Value.ToString();
                    string Date = DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["تاريخ التوزيعة"].Value.ToString();
                    Signitaure_List_Form Signitaure_List_Form = new Signitaure_List_Form(Partner_ID,Donor_ID, Partner_Name, Donor_Name, Month, Date, Distribution_ID, Partner_Distribution_ID, Approved, main_form);
                    DialogResult dialogResult = Signitaure_List_Form.ShowDialog();
                    if (dialogResult == DialogResult.Yes)
                    {
                        Bind_Partner_Distribution();
                    }
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
        #endregion

        #region // Cell Value Changed
        private void CommingDistribution_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (CommingDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبالغ الإدارية" || CommingDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبلغ المسلم للكنيسة")
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد التعديل", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int Distribution_ID = int.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["distribution_id"].Value.ToString());
                        int Partner_Donor_ID = int.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_donor_id"].Value.ToString());

                        float Admin_Cost = string.IsNullOrWhiteSpace(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["المبالغ الإدارية"].Value.ToString()) ? 0 : float.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["المبالغ الإدارية"].Value.ToString());
                        float Delivered = string.IsNullOrWhiteSpace(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["المبلغ المسلم للكنيسة"].Value.ToString()) ? 0 : float.Parse(CommingDistribution_DataGridView.Rows[e.RowIndex].Cells["المبلغ المسلم للكنيسة"].Value.ToString());
                        p.Update_Partner_Partner_Distribution_AdminCost_Delivered(Partner_Donor_ID, Distribution_ID, Admin_Cost, Delivered, this.Name);
                        MessageBox.Show("تم التعديل بنجاح", "Confirmation");
                    }
                    Bind_Partner_Distribution();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void NotFinishedDistribution_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (NotFinishedDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبالغ الإدارية" || NotFinishedDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبلغ المسلم للكنيسة")
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد التعديل", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int Distribution_ID = int.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["distribution_id"].Value.ToString());
                        int Partner_Donor_ID = int.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_donor_id"].Value.ToString());

                        float Admin_Cost = string.IsNullOrWhiteSpace(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["المبالغ الإدارية"].Value.ToString()) ? 0 : float.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["المبالغ الإدارية"].Value.ToString());
                        float Delivered = string.IsNullOrWhiteSpace(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["المبلغ المسلم للكنيسة"].Value.ToString()) ? 0 : float.Parse(NotFinishedDistribution_DataGridView.Rows[e.RowIndex].Cells["المبلغ المسلم للكنيسة"].Value.ToString());

                        p.Update_Partner_Partner_Distribution_AdminCost_Delivered(Partner_Donor_ID, Distribution_ID, Admin_Cost, Delivered, this.Name);
                        MessageBox.Show("تم التعديل بنجاح", "Confirmation");
                    }
                    Bind_Partner_Distribution();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void DoneDistribution_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if click is on new row or header row
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (DoneDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبالغ الإدارية" || DoneDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبلغ المسلم للكنيسة")
                {
                    DialogResult dialogResult = MessageBox.Show("تأكيد التعديل", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int Distribution_ID = int.Parse(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["distribution_id"].Value.ToString());
                        int Partner_ID = int.Parse(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["partner_id"].Value.ToString());
                        float Admin_Cost = string.IsNullOrWhiteSpace(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["المبالغ الإدارية"].Value.ToString()) ? 0 : float.Parse(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["المبالغ الإدارية"].Value.ToString());
                        float Delivered = string.IsNullOrWhiteSpace(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["المبلغ المسلم للكنيسة"].Value.ToString()) ? 0 : float.Parse(DoneDistribution_DataGridView.Rows[e.RowIndex].Cells["المبلغ المسلم للكنيسة"].Value.ToString());

                        p.Update_Partner_Partner_Distribution_AdminCost_Delivered(Partner_ID, Distribution_ID, Admin_Cost, Delivered, this.Name);
                        MessageBox.Show("تم التعديل بنجاح", "Confirmation");
                    }
                    Bind_Partner_Distribution();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        #endregion

        #region // ToolTip
        private void CommingDistribution_DataGridView_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex == CommingDistribution_DataGridView.NewRowIndex || e.RowIndex < 0)
                return;

            if (CommingDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "List")
            {
                e.ToolTipText = "Signature List";
            }
            else if (CommingDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "تاريخ التوزيعة")
            {
                e.ToolTipText = "نقرتين لعرض وتعديل التواريخ";
            }
            else if (CommingDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبالغ الإدارية" || CommingDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبلغ المسلم للكنيسة")
            {
                e.ToolTipText = "ادخال المبلغ المطلوب";
            }
        }

        private void NotFinishedDistribution_DataGridView_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex == NotFinishedDistribution_DataGridView.NewRowIndex || e.RowIndex < 0)
                return;

            if (NotFinishedDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "List")
            {
                e.ToolTipText = "Signature List";
            }
            else if (NotFinishedDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "تاريخ التوزيعة")
            {
                e.ToolTipText = "نقرتين لعرض وتعديل التواريخ";
            }
            else if (NotFinishedDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبالغ الإدارية" || NotFinishedDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبلغ المسلم للكنيسة")
            {
                e.ToolTipText = "ادخال المبلغ المطلوب";
            }
        }

        private void DoneDistribution_DataGridView_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex == DoneDistribution_DataGridView.NewRowIndex || e.RowIndex < 0)
                return;

            if (DoneDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "List")
            {
                e.ToolTipText = "Signature List";
            }
            else if (DoneDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "تاريخ التوزيعة")
            {
                e.ToolTipText = "نقرتين لعرض وتعديل التواريخ";
            }
            else if (DoneDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبالغ الإدارية" || DoneDistribution_DataGridView.Columns[e.ColumnIndex].HeaderText == "المبلغ المسلم للكنيسة")
            {
                e.ToolTipText = "ادخال المبلغ المطلوب";
            }
        }
        #endregion

        #region // KeyPress
        private void MyDataGridViewInitializationMethod()
        {
            CommingDistribution_DataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(MyDataGridView_EditingControlShowing);
            NotFinishedDistribution_DataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(MyDataGridView_EditingControlShowing);
            DoneDistribution_DataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(MyDataGridView_EditingControlShowing);
        }

        private void MyDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region//CellFormatting
        private void CommingDistribution_DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == CommingDistribution_DataGridView.Columns["المبلغ الموزع للعائلات"].Index
                || e.ColumnIndex == CommingDistribution_DataGridView.Columns["المبلغ الواجب توزيعه للعائلات"].Index
                || e.ColumnIndex == CommingDistribution_DataGridView.Columns["المبلغ الواجب تسليمه للكنيسة"].Index
                || e.ColumnIndex == CommingDistribution_DataGridView.Columns["المبلغ المسلم للكنيسة"].Index
                || e.ColumnIndex == CommingDistribution_DataGridView.Columns["الفرق"].Index
                || e.ColumnIndex == CommingDistribution_DataGridView.Columns["المبالغ الإدارية"].Index
                || e.ColumnIndex == CommingDistribution_DataGridView.Columns["المبلغ المتبقي"].Index)
            {
                if (e.Value != null && e.Value != DBNull.Value && e.Value != "")
                {
                    decimal value = decimal.Parse(e.Value.ToString(), System.Globalization.NumberStyles.Float);

                    e.Value = value.ToString("N2");

                    e.FormattingApplied = true;
                }
            }

        }

        private void NotFinishedDistribution_DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == NotFinishedDistribution_DataGridView.Columns["المبلغ الموزع للعائلات"].Index
                || e.ColumnIndex == NotFinishedDistribution_DataGridView.Columns["المبلغ الواجب توزيعه للعائلات"].Index
                || e.ColumnIndex == NotFinishedDistribution_DataGridView.Columns["المبلغ الواجب تسليمه للكنيسة"].Index
                || e.ColumnIndex == NotFinishedDistribution_DataGridView.Columns["المبلغ المسلم للكنيسة"].Index
                || e.ColumnIndex == NotFinishedDistribution_DataGridView.Columns["الفرق"].Index
                || e.ColumnIndex == NotFinishedDistribution_DataGridView.Columns["المبالغ الإدارية"].Index
                || e.ColumnIndex == NotFinishedDistribution_DataGridView.Columns["المبلغ المتبقي"].Index)
            {
                if (e.Value != null && e.Value != DBNull.Value && e.Value != "")
                {
                    decimal value = decimal.Parse(e.Value.ToString(), System.Globalization.NumberStyles.Float);

                    e.Value = value.ToString("N2");

                    e.FormattingApplied = true;
                }
            }
        }

        private void DoneDistribution_DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == DoneDistribution_DataGridView.Columns["المبلغ الموزع للعائلات"].Index
                || e.ColumnIndex == DoneDistribution_DataGridView.Columns["المبلغ الواجب توزيعه للعائلات"].Index
                || e.ColumnIndex == DoneDistribution_DataGridView.Columns["المبلغ الواجب تسليمه للكنيسة"].Index
                || e.ColumnIndex == DoneDistribution_DataGridView.Columns["المبلغ المسلم للكنيسة"].Index
                || e.ColumnIndex == DoneDistribution_DataGridView.Columns["الفرق"].Index
                || e.ColumnIndex == DoneDistribution_DataGridView.Columns["المبالغ الإدارية"].Index
                || e.ColumnIndex == DoneDistribution_DataGridView.Columns["المبلغ المتبقي"].Index)
            {
                if (e.Value != null && e.Value != DBNull.Value && e.Value != "")
                {
                    decimal value = decimal.Parse(e.Value.ToString(), System.Globalization.NumberStyles.Float);

                    e.Value = value.ToString("N2");

                    e.FormattingApplied = true;
                }
            }
        }
        #endregion

        #region //CellLeave
        private void CommingDistribution_DataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == CommingDistribution_DataGridView.Columns["المبالغ الإدارية"].Index || e.ColumnIndex == CommingDistribution_DataGridView.Columns["المبلغ المسلم للكنيسة"].Index)
            {
                CommingDistribution_DataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Format = "N0";
                CommingDistribution_DataGridView.Columns[e.ColumnIndex].ValueType = typeof(Decimal);
            }

        }

        private void NotFinishedDistribution_DataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == NotFinishedDistribution_DataGridView.Columns["المبالغ الإدارية"].Index || e.ColumnIndex == NotFinishedDistribution_DataGridView.Columns["المبلغ المسلم للكنيسة"].Index)
            {
                NotFinishedDistribution_DataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Format = "N0";
                NotFinishedDistribution_DataGridView.Columns[e.ColumnIndex].ValueType = typeof(Decimal);
            }
        }

        private void DoneDistribution_DataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DoneDistribution_DataGridView.Columns["المبالغ الإدارية"].Index || e.ColumnIndex == DoneDistribution_DataGridView.Columns["المبلغ المسلم للكنيسة"].Index)
            {
                DoneDistribution_DataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Format = "N0";
                DoneDistribution_DataGridView.Columns[e.ColumnIndex].ValueType = typeof(Decimal);
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
                tableLayoutPanel1.Size = new Size(this.Width - 10, 1260);
                Bind_Partner_ComboBox();
                Bind_Donor_ComoBox();
                Bind_Distribution_ComboBox();
                Bind_Partner_Distribution();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void AddDistribution_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Partner_Distribution_Edit_Form Partner_Distribution_Edit_Form = new Partner_Distribution_Edit_Form(main_form);
                DialogResult dialogResult = Partner_Distribution_Edit_Form.ShowDialog();
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show("تم تعديل القائمة بنجاح", "Confirmation");
                    Bind_Partner_Distribution();
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

        private void Partner_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    Bind_Partner_Distribution();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Distribution_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    Bind_Partner_Distribution();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    //Bind_Partner_Distribution();
                    Bind_Distribution_ComboBox();
                    Bind_Partner_Distribution();
                    Bind_Donor_ComoBox();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void AddDistribution_Button_MouseEnter(object sender, EventArgs e)
        {
            AddDistribution_Button.BackgroundImage = F2F_Application.Properties.Resources.button3_1;

        }

        private void AddDistribution_Button_MouseLeave(object sender, EventArgs e)
        {
            AddDistribution_Button.BackgroundImage = F2F_Application.Properties.Resources.button3;

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
                        System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                        filepath = saveFileDialog1.FileName;
                        fs.Close();
                    }
                }

                if (!string.IsNullOrWhiteSpace(filepath))
                {
                    XLWorkbook wb = new XLWorkbook();

                    DataTable dt = ((DataTable)DoneDistribution_DataGridView.DataSource).DefaultView.ToTable();

                    dt.Columns.Remove("partner_distribution_id");
                    dt.Columns.Remove("listapproved");
                    dt.Columns.Remove("distribution_id");
                    dt.Columns.Remove("partner_id");

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

        private void Donor_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    Bind_Partner_Distribution();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
    }
}
