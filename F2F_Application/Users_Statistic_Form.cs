using ClosedXML.Excel;
using F2F_Application.Classes;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Users_Statistic_Form : MaterialForm
    {
        public Users_Statistic_Form(Main_Form main_form)
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
        Log l;
        BindingSource bs = new BindingSource();

        private void Users_Statistic_Form_Load(object sender, EventArgs e)
        {
            try
            {
                l = new Log();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب خطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Go_button_Click(object sender, EventArgs e)
        {
            try
            {
                Fill_Statistic_DataGridView();
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

        private void Fill_Statistic_DataGridView()
        {
            string FromDate = From_dateTimePicker.Value.ToString("dd/MM/yyyy", new CultureInfo("en-GB"));
            string ToDate = To_dateTimePicker.Value.ToString("dd/MM/yyyy", new CultureInfo("en-GB"));
            DataSet ds = l.Get_Users_Statistic(FromDate, ToDate);


            bs.DataSource = ds.Tables[0];
            Statistic_DataGridView.ColumnHeadersVisible = false;
            Statistic_DataGridView.DataSource = null;
            Statistic_DataGridView.Columns.Clear();
            Statistic_DataGridView.DataSource = bs;
            Statistic_DataGridView.ColumnHeadersVisible = true;


            TotalInsertedF_Label.Text = "العائلات المدخلة حديثاً =  " + ds.Tables[1].Rows[0].Field<decimal>("TotalInsertedF").ToString();
            TotalUpdatedF_Label.Text = "العائلات المعدلة =  " + ds.Tables[2].Rows[0].Field<decimal>("TotalUpdatedF").ToString();
            TotalInsertedM_Label.Text = "الأفراد المدخلين حديثاً =  " + ds.Tables[3].Rows[0].Field<decimal>("TotalInsertedM").ToString();
            TotalUpdatedM_Label.Text = "الأفراد المعدلين =  " + ds.Tables[4].Rows[0].Field<decimal>("TotalUpdatedM").ToString();


            TotalF_Label.Text = "مجموع العائلات =  " + (ds.Tables[1].Rows[0].Field<decimal>("TotalInsertedF") + ds.Tables[2].Rows[0].Field<decimal>("TotalUpdatedF")).ToString();
            TotalM_Label.Text = "مجموع الأفراد =  " + (ds.Tables[3].Rows[0].Field<decimal>("TotalInsertedM") + ds.Tables[4].Rows[0].Field<decimal>("TotalUpdatedM")).ToString();

        }

        private void Go_button_MouseEnter(object sender, EventArgs e)
        {
            Go_button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Go_button_MouseLeave(object sender, EventArgs e)
        {
            Go_button.BackgroundImage = F2F_Application.Properties.Resources.button1;

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

                    wb.Worksheets.Add(dt, "Users Statistic Data");
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
    }
}
