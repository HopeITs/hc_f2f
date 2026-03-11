using F2F_Application.Classes;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace F2F_Application
{
    public partial class FeedBack_Form : MaterialForm
    {
        public FeedBack_Form()
        {
            InitializeComponent();

            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(activeScreenDimensions.Width, activeScreenDimensions.Height);
        }

        User u;

        private void NewIdea_Form_Load(object sender, EventArgs e)
        {
            u = new User();

            FeedBack_TextBox.Text = "أكتب رسالتك هنا";
            FeedBack_TextBox.ForeColor = Color.LightGray;
        }

        private void Send_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FeedBack_TextBox.Text) || FeedBack_TextBox.Text == "أكتب رسالتك هنا")
                {
                    MessageBox.Show("لا يمكن إرسال رسالة فارغة", "Error");

                }
                else
                {
                    string Message = FeedBack_TextBox.Text + Environment.NewLine + "User:" + Properties.Settings.Default.Username + Environment.NewLine + "Date:" + DateTime.Now.ToString();
                    u.Send_FeedBack(Message);
                    MessageBox.Show("تم الإرسال بنجاح", "Confirmation");
                    FeedBack_TextBox.Text = "أكتب رسالتك هنا";
                    FeedBack_TextBox.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }


        private void Send_Button_MouseEnter(object sender, EventArgs e)
        {
            Send_Button.BackgroundImage = F2F_Application.Properties.Resources.button1_1;

        }

        private void Send_Button_MouseLeave(object sender, EventArgs e)
        {
            Send_Button.BackgroundImage = F2F_Application.Properties.Resources.button1;

        }

        private void NewIdea_TextBox_Enter(object sender, EventArgs e)
        {
            if (FeedBack_TextBox.Text == "أكتب رسالتك هنا")
            {
                FeedBack_TextBox.Clear();
                FeedBack_TextBox.ForeColor = Color.Black;
            }
        }

        private void NewIdea_TextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FeedBack_TextBox.Text))
            {
                FeedBack_TextBox.Text = "أكتب رسالتك هنا";
                FeedBack_TextBox.ForeColor = Color.LightGray;
            }
        }
    }
}
