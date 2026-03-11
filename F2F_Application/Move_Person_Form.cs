using F2F_Application.Classes;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class Move_Person_Form : MaterialForm
    {
        public Move_Person_Form(Main_Form main_form, string OldFamilyCode, int OldFamilyID, string PersonName, int PersonID)
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

            this.OldFamilyCode = OldFamilyCode;
            this.OldFamilyID = OldFamilyID;
            this.PersonName = PersonName;
            this.PersonID = PersonID;
        }

        Main_Form main_form;
        Categories c; Person p;
        bool UserMode;
        string OldFamilyCode; int OldFamilyID; string PersonName; int PersonID;

        private void Move_Person_Form_Load(object sender, EventArgs e)
        {
            try
            {
                c = new Categories(); p = new Person();
                FamilyCode_ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
                label1.Text = "نقل " + PersonName + " من العائلة " + OldFamilyCode;
                Bind_Families();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
                MessageBox.Show("لن يتم فتح هذه الصفحة بسبب الخطأ في جلب البيانات، يرجى محاولة إعادة فتحها من جديد", "Error");
                this.Close();

            }
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void Bind_Families()
        {
            UserMode = false;

            DataTable dt = new DataTable();

            dt = c.Select_Table("family", "", false, true);

            FamilyCode_ComboBox.DataSource = dt;
            FamilyCode_ComboBox.DisplayMember = "code";
            FamilyCode_ComboBox.ValueMember = "id";

            FamilyCode_ComboBox.SelectedIndex = -1;
            UserMode = true;
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

        private void FamilyCode_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserMode)
                {
                    if (FamilyCode_ComboBox.SelectedValue == null || FamilyCode_ComboBox.SelectedIndex < 0)
                    {
                        MessageBox.Show("الرجاء تحديد العائلة الجديدة", "Error");
                        return;
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("هل أنت متأكد انك تريد نقل " + PersonName + " إلى العائلة: " + Environment.NewLine + FamilyCode_ComboBox.Text, "Warning", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            p.Move_Person(PersonID, PersonName, OldFamilyID, OldFamilyCode, int.Parse(FamilyCode_ComboBox.SelectedValue.ToString()), FamilyCode_ComboBox.Text, this.Name);
                            MessageBox.Show("تم النقل بنجاح", "Confirmation");
                            this.Close();
                        }
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
    }
}
