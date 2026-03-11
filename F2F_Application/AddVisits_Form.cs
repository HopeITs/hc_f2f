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
    public partial class AddVisits_Form : MaterialForm
    {
        public AddVisits_Form(Main_Form main_form,int Family_ID)
        {
            InitializeComponent();

            this.addvisits_form = addvisits_form;
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(activeScreenDimensions.Width, activeScreenDimensions.Height); 

        }

        AddVisits_Form addvisits_form;
        Main_Form main_form;
        string Selected_Visit;
        Visits v;
        bool DataApproved = false;
        bool UserMode;
        int Family_ID;
        BindingSource bs = new BindingSource();

        private void AddVisits_Form_Load(object sender, EventArgs e)
        {
            try
            {
                //v = new Visits();
                //VisitName_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
                //VisitState_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
                Bind_ComboBoxes(); 

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب الخطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        public void Bind_ComboBoxes()
        {
            UserMode = false; 
            DataTable dt = new DataTable();
            //select from database  
            VisitName_ComboBox.DataSource = dt;
            VisitName_ComboBox.DisplayMember = "Name";
            VisitName_ComboBox.ValueMember = "ID";
            VisitName_ComboBox.SelectedIndex = 0; 
            UserMode = true;
        }
    }
}
