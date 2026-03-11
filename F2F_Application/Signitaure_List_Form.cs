using ClosedXML.Excel;
using F2F_Application.Classes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Signitaure_List_Form : MaterialForm
    {
        public Signitaure_List_Form(int Partner_ID,int Donor_ID, string Partner_Name,string Donor_Name, string Month, string Date, int Distribution_ID, int Partner_Distribution_ID, int Approved, Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.Partner_ID = Partner_ID;
            this.Donor_ID = Donor_ID;
            this.Distribution_ID = Distribution_ID;
            this.Partner_Distribution_ID = Partner_Distribution_ID;
            bs.ListChanged += bs_ListChanged;

            Partner_Name_Label.Text = Partner_Name;
            Donor_Name_Label.Text = Donor_Name;
            Month_Label.Text = Month;
            Distribution_Date_Label.Text = Date;

            if (Approved == 0)
            {
                UpdateMode = false;
            }
            else if (Approved == 1)
            {
                UpdateMode = true;
            }
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            System.Drawing.Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(activeScreenDimensions.Width, activeScreenDimensions.Height);

            SignitaureList_DataGridView.DoubleBuffered(true);

        }

        private void bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            NumOfRows1.Text = SignitaureList_DataGridView.Rows.Count.ToString();
        }

        Main_Form main_form;
        int Partner_ID, Distribution_ID, Partner_Distribution_ID,Donor_ID;
        bool UpdateMode;
        Distribution d;
        string Signature_List_Query = "";
        bool SignitaureList_DataGridView_IsDirty;
        CheckBox checkboxHeader = new CheckBox();
        bool UserMode = true;
        BindingSource bs = new BindingSource();
        string Original_Filter_String;

        private void Signitaure_List_Form_Load(object sender, EventArgs e)
        {
            try
            {
                d = new Distribution();
                Set_Controls();
                Bind_SignitaureList_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Signitaure_List_Form_Shown(object sender, EventArgs e)
        {
            SignitaureList_DataGridView.SetFilterAndSortEnabled(SignitaureList_DataGridView.Columns["Delete"], false);
            SignitaureList_DataGridView.SetFilterAndSortEnabled(SignitaureList_DataGridView.Columns["RecievedMoney"], false);
        }

        private void Set_Controls()
        {
            Signature_List_Query = "";
            SignitaureList_DataGridView_IsDirty = false;

            Approve_Button.Visible = true;
            Edit_Button.Visible = false;
            Save_Button.Visible = false;
            Excel_Button.Visible = false;

            if (UpdateMode)
            {
                Approve_Button.Visible = false;
                Edit_Button.Visible = true;
                Save_Button.Visible = true;
                Excel_Button.Visible = true;
            }
        }

        private void Bind_SignitaureList_DataGridView()
        {
            bs.Filter = bs.Sort = Original_Filter_String = "";
            UserMode = false;
            DataTable dt = new DataTable();
            if (UpdateMode)
            {
                dt = d.Get_Approved_Signitaure_List(Partner_ID, Donor_ID, Partner_Distribution_ID);

                bs.DataSource = dt;

                SignitaureList_DataGridView.Columns.Clear();
                SignitaureList_DataGridView.DataSource = null;
                SignitaureList_DataGridView.ColumnHeadersVisible = false;
                SignitaureList_DataGridView.DataSource = bs;
                SignitaureList_DataGridView.ColumnHeadersVisible = true;

                Add_Columns();
            }
            else if (!UpdateMode)
            {
                dt = d.Get_NotApproved_Signitaure_List(Partner_ID,Donor_ID, Partner_Distribution_ID);

                bs.DataSource = dt;

                SignitaureList_DataGridView.Columns.Clear();
                SignitaureList_DataGridView.DataSource = null;
                SignitaureList_DataGridView.ColumnHeadersVisible = false;
                SignitaureList_DataGridView.DataSource = bs;
                SignitaureList_DataGridView.ColumnHeadersVisible = true;
            }


            foreach (DataGridViewColumn C in SignitaureList_DataGridView.Columns)
            {
                if (C.Name != "RecievedMoney")
                    C.ReadOnly = true;
                else
                    C.ReadOnly = false;

                if (C.Name == "Family ID" || C.Name == "ID" || C.Name == "IsDirty")
                    C.Visible = false;
            }
            UserMode = true;


            SignitaureList_DataGridView.ColumnHeadersHeight = 50;
            SignitaureList_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            SignitaureList_DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridView DG = new DataGridView();


            foreach (DataGridViewColumn C in SignitaureList_DataGridView.Columns)
                //if (C.Name != "Delete" && C.Name != "RecievedMoney" && C.Visible == true)
                if (C.Name != "Delete" && C.Visible == true)
                {
                    DataGridViewTextBoxColumn C1 = new DataGridViewTextBoxColumn();
                    C1.Name = C.Name;
                    C1.HeaderText = C.HeaderText;
                    DG.Columns.Add(C1);
                }


            SearchToolBar.SetColumns(DG.Columns);


            NumOfRows1.Text = SignitaureList_DataGridView.Rows.Count.ToString();

            SignitaureList_DataGridView.SetFilterAndSortEnabled(SignitaureList_DataGridView.Columns["Delete"], false);
            SignitaureList_DataGridView.SetFilterAndSortEnabled(SignitaureList_DataGridView.Columns["RecievedMoney"], false);
        }

        private void Add_Columns()
        {
            int RecievedMoneyIndex = SignitaureList_DataGridView.Columns["RecievedMoney"].Index;

            SignitaureList_DataGridView.Columns.RemoveAt(RecievedMoneyIndex);

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = " ";
            chk.Name = "RecievedMoney";
            chk.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            chk.HeaderText = "استلم";
            chk.MinimumWidth = 90;
            chk.Width = 90;
            chk.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            chk.DataPropertyName = "RecievedMoney";

            SignitaureList_DataGridView.Columns.Insert(RecievedMoneyIndex + 1, chk);


            DataGridViewButtonColumn colBC = new DataGridViewButtonColumn();
            colBC.Name = "Delete";
            colBC.HeaderText = "";
            colBC.FlatStyle = FlatStyle.Flat;
            colBC.MinimumWidth = 50;
            colBC.Width = 50;
            colBC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBC.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            SignitaureList_DataGridView.Columns.Add(colBC);

            System.Drawing.Rectangle oRectangle1 = SignitaureList_DataGridView.GetCellDisplayRectangle(RecievedMoneyIndex + 1, -1, false);
            checkboxHeader.Size = new Size(25, 25);
            checkboxHeader.Name = "Check_All";
            checkboxHeader.BackColor = Color.FromArgb(0, 75, 75);
            checkboxHeader.ForeColor = Color.FromArgb(230, 230, 230);
            checkboxHeader.Text = "";
            checkboxHeader.RightToLeft = RightToLeft;
            checkboxHeader.Location = new Point(oRectangle1.X, oRectangle1.Y + 17);

            SignitaureList_DataGridView.Controls.Add(checkboxHeader);
            checkboxHeader.CheckedChanged += this.checkboxHeader_CheckedChanged;


            Loop_Checkboxes();

        }

        private void Loop_Checkboxes()
        {
            //Loop to verify whether all row CheckBoxes are checked or not.
            bool isChecked = true;
            foreach (DataGridViewRow row in SignitaureList_DataGridView.Rows)
            {
                if(SignitaureList_DataGridView.Columns.Contains("RecievedMoney") && Convert.ToBoolean(row.Cells["RecievedMoney"].EditedFormattedValue) == false)
                //if (Convert.ToBoolean(row.Cells["RecievedMoney"].EditedFormattedValue) == false)
                {
                    isChecked = false;
                    break;
                }
            }

            UserMode = false;
            checkboxHeader.Checked = isChecked;
            UserMode = true;
        }

        private void Signitaure_List_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    this.ActiveControl = Approve_Button;

                    if (SignitaureList_DataGridView_IsDirty)
                    {
                        if (MessageBox.Show("يوجد بعض التعديلات غير المحفوظة، هل تود حفظها قبل إغلاق الصفحة؟؟", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Save_Button.PerformClick();
                            //e.Cancel = true;
                            //return;
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Approve_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = Approve_Button;

                if (SignitaureList_DataGridView.Rows.Count <= 0)
                {
                    MessageBox.Show("لا يوجد أي بيانات لحفظها ", "Error");
                    return;
                }
                Get_Data();

                if (!UpdateMode)
                {
                    d.Insert_Signitaure_List(Signature_List_Query, Partner_Distribution_ID, Partner_ID, Distribution_ID, this.Name);

                    UpdateMode = true;
                    MessageBox.Show("تم حفظ القائمة بنجاح", "Confirmation");
                    Set_Controls();
                    Bind_SignitaureList_DataGridView();
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

        private void Save_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = Approve_Button;

                if (UpdateMode)
                {
                    if (!SignitaureList_DataGridView_IsDirty)
                    {
                        MessageBox.Show("لا يوجد أي تغييرات لحفظها ", "Error");
                        return;
                    }
                    else
                    {
                        Get_Data();

                        d.Update_Signitaure_List(Signature_List_Query, Partner_Distribution_ID, Partner_ID, Distribution_ID, this.Name);

                        MessageBox.Show("تم تعديل القائمة بنجاح", "Confirmation");
                        Set_Controls();
                        Bind_SignitaureList_DataGridView();
                    }
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

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Signitaure_List_Edit_Form Signitaure_List_Edit_Form = new Signitaure_List_Edit_Form(Partner_ID, Donor_ID, Distribution_ID, Partner_Distribution_ID, main_form);
                DialogResult dialogResult = Signitaure_List_Edit_Form.ShowDialog();
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show("تم تعديل القائمة بنجاح", "Confirmation");
                    Set_Controls();
                    Bind_SignitaureList_DataGridView();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }

        }

        private void SignitaureList_DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {

                if (e.RowIndex == SignitaureList_DataGridView.NewRowIndex || e.RowIndex < 0)
                    return;

                if (SignitaureList_DataGridView.Columns[e.ColumnIndex].Name == "Delete")
                {
                    System.Drawing.Image image = null;
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

        private void SignitaureList_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Check to ensure that the row CheckBox is clicked.
                if (SignitaureList_DataGridView.Columns.Contains("RecievedMoney"))
                {
                    int RecievedMoneyIndex = SignitaureList_DataGridView.Columns["RecievedMoney"].Index;
                    if (e.RowIndex >= 0 && e.ColumnIndex == RecievedMoneyIndex)
                    {
                        if (UserMode)
                        {
                            SignitaureList_DataGridView.Rows[e.RowIndex].Cells["IsDirty"].Value = 1;
                            SignitaureList_DataGridView_IsDirty = true;
                        }
                        Loop_Checkboxes();
                    }
                    else
                    {
                        //if click is on new row or header row
                        if (e.RowIndex == SignitaureList_DataGridView.NewRowIndex || e.RowIndex < 0)
                            return;

                        //Check if click is on specific column 
                        if (e.ColumnIndex == SignitaureList_DataGridView.Columns["Delete"].Index)
                        {
                            DialogResult dialogResult = MessageBox.Show("تأكيد الحذف", "Warning", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                SignitaureList_DataGridView_IsDirty = true;
                                SignitaureList_DataGridView.Rows[e.RowIndex].Cells["IsDirty"].Value = "1";

                                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[SignitaureList_DataGridView.DataSource];
                                currencyManager1.SuspendBinding();
                                SignitaureList_DataGridView.Rows[e.RowIndex].Visible = false;
                                currencyManager1.ResumeBinding();
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

        private void Get_Data()
        {
            if (!UpdateMode)
            {
                for (int i = 0; i < SignitaureList_DataGridView.Rows.Count; i++)
                {
                    Signature_List_Query += "('" + Partner_Distribution_ID + "', '" + (int)SignitaureList_DataGridView.Rows[i].Cells["Family ID"].Value + "', '" + SignitaureList_DataGridView.Rows[i].Cells["عدد المستفيدين"].Value + "')";
                    if (i < SignitaureList_DataGridView.Rows.Count - 1)
                        Signature_List_Query += ",";
                }
            }
            else if (UpdateMode)
            {
                for (int i = 0; i < SignitaureList_DataGridView.Rows.Count; i++)
                {
                    if (SignitaureList_DataGridView.Rows[i].Visible == false)
                        Signature_List_Query += "DELETE FROM signature_list WHERE id = '" + SignitaureList_DataGridView.Rows[i].Cells["ID"].Value + "';";
                    else if (SignitaureList_DataGridView.Rows[i].Cells["IsDirty"].Value != null && (int)SignitaureList_DataGridView.Rows[i].Cells["IsDirty"].Value == 1)
                    {
                        Signature_List_Query += "UPDATE signature_list set RecievedMoney = '" + (SignitaureList_DataGridView.Rows[i].Cells["RecievedMoney"].Value.ToString() == "1" ? 1 : 0) + "' where id = '" + (int)SignitaureList_DataGridView.Rows[i].Cells["ID"].Value + "';";
                    }
                }
            }
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    SignitaureList_DataGridView_IsDirty = true;

                    //Necessary to end the edit mode of the Cell.
                    SignitaureList_DataGridView.EndEdit();

                    //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
                    foreach (DataGridViewRow row in SignitaureList_DataGridView.Rows)
                    {
                        DataGridViewCheckBoxCell checkBox = (row.Cells["RecievedMoney"] as DataGridViewCheckBoxCell);
                        checkBox.Value = checkboxHeader.Checked;
                        row.Cells["IsDirty"].Value = 1;
                    }
                }
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
                tableLayoutPanel1.Size = new Size(this.Width, 717);
                Set_Controls();
                Bind_SignitaureList_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
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

        private void Approve_Button_MouseEnter(object sender, EventArgs e)
        {
            Approve_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Approve_Button_MouseLeave(object sender, EventArgs e)
        {
            Approve_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        private void Edit_Button_MouseEnter(object sender, EventArgs e)
        {
            Edit_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Edit_Button_MouseLeave(object sender, EventArgs e)
        {
            Edit_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

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

                    dt.Columns.Remove("ID");
                    dt.Columns.Remove("Family ID");

                    //reorder & set this column as the last column
                    dt.Columns["RecievedMoney"].SetOrdinal(dt.Columns.Count - 1);

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

        private void SearchToolBar_Search(object sender, Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventArgs e)
        {

        }

        private void Excel_Button_MouseEnter(object sender, EventArgs e)
        {
            Excel_Button.BackgroundImage = F2F_Application.Properties.Resources.Export_2;

        }

        private void SignitaureList_DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void SignitaureList_DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == SignitaureList_DataGridView.Columns["المبلغ"].Index)
            {
                if (e.Value != null && e.Value != DBNull.Value && e.Value != "")
                {
                    decimal value = decimal.Parse(e.Value.ToString());

                    e.Value = value.ToString("N0");

                    e.FormattingApplied = true;
                }
            }

        }

        private void SignitaureList_DataGridView_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            try
            {
                Original_Filter_String = SignitaureList_DataGridView.FilterString;

                if (SignitaureList_DataGridView_IsDirty)
                    Save_Button.PerformClick();

                timer1.Start();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void SignitaureList_DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            NumOfSelected1.Text = SignitaureList_DataGridView.SelectedRows.Count.ToString();
        }

        private void SignitaureList_DataGridView_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            try
            {
                bs.Sort = SignitaureList_DataGridView.SortString;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Loop_Checkboxes();
            if (SignitaureList_DataGridView.Columns.Contains("RecievedMoney"))
            {
                int RecievedMoneyIndex = SignitaureList_DataGridView.Columns["RecievedMoney"].Index;
                System.Drawing.Rectangle oRectangle1 = SignitaureList_DataGridView.GetCellDisplayRectangle(RecievedMoneyIndex, -1, false);

                checkboxHeader.Location = new Point(oRectangle1.X, oRectangle1.Y + 17);
            }
        }

        private void SignitaureList_DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SignitaureList_DataGridView.Rows[e.RowIndex].Cells["IsDirty"].Value = 1;
        }

        private void SearchToolBar_Search_1(object sender, Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventArgs e)
        {
            try
            {
                if (SignitaureList_DataGridView_IsDirty)
                    Save_Button.PerformClick();

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
                        int FilterableColumnsCount = SignitaureList_DataGridView.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible && c.Name != "RecievedMoney" && c.Name != "Delete");
                        int i = 0;
                        foreach (DataGridViewColumn C in SignitaureList_DataGridView.Columns)
                        {
                            if (C.Visible == true && C.Name != "RecievedMoney" && C.Name != "Delete")
                            {
                                if (e.WholeWord)
                                    NewFilter += "convert(`" + C.Name + "`,'System.String') = '" + e.ValueToSearch + "'";
                                else
                                    NewFilter += "convert(`" + C.Name + "`,'System.String') like '%" + e.ValueToSearch + "%'";

                                if (i < FilterableColumnsCount - 1)
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

        private void Excel_Button_MouseLeave(object sender, EventArgs e)
        {
            Excel_Button.BackgroundImage = F2F_Application.Properties.Resources.Export_1;

        }

    }
}
