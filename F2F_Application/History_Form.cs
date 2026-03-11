using F2F_Application.Classes;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class History_Form : MaterialForm
    {
        public History_Form(string ToBind, int ID, Main_Form main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.ToBind = ToBind;
            this.ID = ID;

            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(activeScreenDimensions.Width, activeScreenDimensions.Height);
        }

        Main_Form main_form;
        Person p; Family f;Report r;
        string ToBind; int ID;

        private void History_Form_Load(object sender, EventArgs e)
        {
            try
            {
                p = new Person(); f = new Family(); r = new Report();
                Bind_History_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم هذه الصفحة بسبب الخطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Bind_History_DataGridView()
        {
            if (ToBind == "PersonState")
            {
                DataTable dt = p.Get_PersonState_History(ID);
                History_DataGridView.ColumnHeadersVisible = false;
                History_DataGridView.DataSource = null;
                History_DataGridView.Columns.Clear();
                History_DataGridView.DataSource = dt;
                History_DataGridView.ColumnHeadersVisible = true;
            }
            if (ToBind == "PersonMaritalState")
            {
                DataTable dt = p.Get_PersonMaritalState_History(ID);
                History_DataGridView.ColumnHeadersVisible = false;
                History_DataGridView.DataSource = null;
                History_DataGridView.Columns.Clear();
                History_DataGridView.DataSource = dt;
                History_DataGridView.ColumnHeadersVisible = true;
            }


            if (ToBind == "FamilyMembers")
            {
                DataTable dt = f.Get_FamilyMembers_History(ID);
                History_DataGridView.ColumnHeadersVisible = false;
                History_DataGridView.DataSource = null;
                History_DataGridView.Columns.Clear();
                History_DataGridView.DataSource = dt;
                History_DataGridView.ColumnHeadersVisible = true;
            }

            if (ToBind == "FamilyDistributions")
            {
                DataTable dt = f.Get_Family_Distribution_History(ID);
                History_DataGridView.ColumnHeadersVisible = false;
                History_DataGridView.DataSource = null;
                History_DataGridView.Columns.Clear();
                History_DataGridView.DataSource = dt;
                History_DataGridView.ColumnHeadersVisible = true;
            }
            if (ToBind == "FamilyDistributionsCodes")
            {
                DataTable dt = r.Get_Family_Distribution_Codes(ID);
                History_DataGridView.ColumnHeadersVisible = false;
                History_DataGridView.DataSource = null;
                History_DataGridView.Columns.Clear();
                History_DataGridView.DataSource = dt;
                History_DataGridView.ColumnHeadersVisible = true;
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                p = new Person(); f = new Family();
                Bind_History_DataGridView();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
    }
}
