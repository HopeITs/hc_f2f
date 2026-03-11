using ClosedXML.Excel;
using F2F_Application.Classes;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace F2F_Application
{
    public partial class MarksChart_Form : MaterialForm
    {
        public MarksChart_Form(Main_Form main_form, DataTable Source)
        {
            InitializeComponent();

            this.main_form = main_form;
            this.Source = Source;
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        }

        Main_Form main_form;
        DataTable Source = new DataTable();

        private void MarksChart_Form_Load(object sender, EventArgs e)
        {
            try
            {
                Screen ActiveScreen = Screen.FromControl(this);
                this.Size = new Size(ActiveScreen.WorkingArea.Width * 4 / 5, ActiveScreen.WorkingArea.Height * 4 / 5);

                Fill_Data();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب الخطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();
            }
        }

        private void Fill_Data()
        {
            //Chart chart = new Chart();
            FamilyMarks_chart.DataSource = Source;

            FamilyMarks_chart.Series["Series1"].XValueMember = "رمز العائلة";
            FamilyMarks_chart.Series["Series1"].YValueMembers = "العلامة النهائية";


            FamilyMarks_chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
            FamilyMarks_chart.DataBind();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Image |*.jpeg";
                saveFileDialog1.Title = "Export as Image";
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
                    FamilyMarks_chart.SaveImage(filepath, ChartImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }
    }
}
