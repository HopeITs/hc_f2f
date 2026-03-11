using F2F_Application.Classes;
using MaterialSkinPlus;
using MaterialSkinPlus.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace F2F_Application
{
    public partial class Login_Form : Form
    {
        public Login_Form(Main_Form main_form, bool ChangeUser)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.ChangeUser = ChangeUser;
            if (ChangeUser) { Old_UserID = Properties.Settings.Default.User_ID; }
            Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(activeScreenDimensions.Width, activeScreenDimensions.Height);

        }

        Main_Form main_form;
        bool connection = false;
        User u;
        byte[] PicArr;
        int tick1 = 0, tick2 = 0;
        DataTable dt = new DataTable();
        bool User_Mode = true;
        bool ChangeUser; int Old_UserID = 0;

        DataTable User_info = new DataTable();

        List<string> Centers = new List<string> { "Aleppo","J&M" };

        List<string> User_In_Database = new List<string>();

        private void Login_Form_Load(object sender, EventArgs e)
        {
            try
            {
                u = new User();
                Connect_button.NotifyDefault(false);
                Version_Label.Text += Application.ProductVersion;
                Password_TextBox.PasswordChar = '•';
                Show_Password.BackgroundImage = F2F_Application.Properties.Resources.Password_Show;
                toolTip1.SetToolTip(Show_Password, "Show Password");


                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string specificFolder = Path.Combine(folder, "Family To Family", "Team");

                if (Directory.Exists(specificFolder).Equals(false))
                {
                    Directory.CreateDirectory(specificFolder);
                }

                connection = false;
                Properties.Settings.Default.LogedIn = false;
                User_In_Database.Clear();

                if (Properties.Settings.Default.Online)
                    Online_checkBox.BackgroundImage = Properties.Resources.online;
                else
                    Online_checkBox.BackgroundImage = Properties.Resources.offline;

                if (Properties.Settings.Default.RememberMe)
                {
                    Remember_checkBox.BackgroundImage = Properties.Resources.remember_me1;

                    if (Properties.Settings.Default.Username != "" && Properties.Settings.Default.Password != "")
                    {
                        Username_TextBox.Text = Properties.Settings.Default.Username;
                        Password_TextBox.Text = Properties.Settings.Default.Password;

                        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Family To Family\Team\" + Properties.Settings.Default.Username + ".png";

                        FileInfo file = new FileInfo(path);

                        if (file.Exists.Equals(true))
                        {

                            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                            {
                                ProfilePicture_PictureBox.BackgroundImage = Image.FromStream(stream);
                            }

                        }
                        else
                        {
                            ProfilePicture_PictureBox.BackgroundImage = Properties.Resources.Default_Profile;
                        }
                    }
                }
                else
                {
                    Remember_checkBox.BackgroundImage = Properties.Resources.remember_me2;
                    Username_TextBox.Text = "Name";
                    Password_TextBox.PasswordChar = '\0';
                    Password_TextBox.Text = "Password";
                    Show_Password.BackgroundImage = F2F_Application.Properties.Resources.Password_Hide;
                    toolTip1.SetToolTip(Show_Password, "Hide Password");
                    ProfilePicture_PictureBox.BackgroundImage = Properties.Resources.Default_Profile;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Connect_button_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < Centers.Count; i++)
                {
                    Properties.Settings.Default.Selected_F2F = Centers[i].ToString();

                    Program.set_ConnectionString();

                    if (Program.firstbuildConnection())
                    {
                        connection = true;

                        dt = u.Get_Version();

                        var version1 = new Version(Application.ProductVersion.ToString());
                        var version2 = new Version(dt.Rows[0].Field<string>("l_version"));

                        var result = version1.CompareTo(version2);
                        if (result > 0)
                        {
                            u.Update_Version(Application.ProductVersion.ToString());

                            
                        }
                        else if (result < 0)
                        {
                            // Using old version
                            MessageBox.Show("أنت تستخدم نسخة قديمة من البرنامج" + Environment.NewLine + "الرجاء التحديث إلى النسخة ذات الرقم" + Environment.NewLine + version2.ToString(), "Error");
                            return;

                            //Edited By Mai
                            //Do nothing
                        }
                        else
                        {
                            // Versions are equal - Do nothing
                        }

                        dt = u.Check_User(Username_TextBox.Text, Password_TextBox.Text);
                        if (dt.Rows.Count == 1) //user exsist
                        {
                            User_In_Database.Add(Centers[i].ToString());
                            User_info = dt;
                        }
                    }
                }

                if (!connection)
                {
                    Properties.Settings.Default.Selected_F2F = "";

                    Program.set_ConnectionString();

                    MessageBox.Show("please check your network connection and try again", "Login Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (User_In_Database.Count < 1)
                {
                    Properties.Settings.Default.Selected_F2F = "";
                    Program.set_ConnectionString();

                    MessageBox.Show("please check Username or Password", "Login Faild", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (User_In_Database.Count >= 1)
                {
                    if (User_info.Rows[0].Field<int>("islogedin") == 0 || User_info.Rows[0].Field<string>("pc_name") == SystemInformation.ComputerName)
                    {
                        User_Mode = false;

                        Program.set_ConnectionString();
                        Program.User_In_Database = User_In_Database;

                        Set_Properties();

                        Set_User_Image();
                        int User_ID = User_info.Rows[0].Field<int>("ID");

                        if (ChangeUser)
                            u.Update_Logedin(User_ID, Old_UserID, 1, SystemInformation.ComputerName);
                        else
                            u.Update_Logedin(User_ID, 0, 1, SystemInformation.ComputerName);

                        timer1.Start();
                        timer2.Start();

                    }
                    else
                    {
                        MessageBox.Show("يجب تسجيل الخروج أولاً من " + Environment.NewLine + User_info.Rows[0].Field<string>("pc_name") + Environment.NewLine + "حتى تستطيع تسجيل الدخول من جهاز آخر", "Error");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL"))
                { MessageBox.Show("please check your network and try again", "Login Faild", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else if (ex.Message.Contains("host"))
                { MessageBox.Show("please check the server or your network connection and try again", "Login Faild", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Set_Properties()
        {
            int User_ID = User_info.Rows[0].Field<int>("ID");
            string Role = User_info.Rows[0].Field<string>("Role");
            string UsedDatbase = User_In_Database[User_In_Database.Count - 1];
            if (Properties.Settings.Default.RememberMe)
            {
                //save properties settings
                Properties.Settings.Default.RememberMe = true;
                Properties.Settings.Default.Username = Username_TextBox.Text;
                Properties.Settings.Default.Password = Password_TextBox.Text;
                Properties.Settings.Default.Role = Role;
                Properties.Settings.Default.User_ID = User_ID;
                Properties.Settings.Default.Selected_F2F = UsedDatbase;
                if (Properties.Settings.Default.Online)
                    Properties.Settings.Default.Online = true;
                else
                    Properties.Settings.Default.Online = false;

                Properties.Settings.Default.Save();
            }
            else
            {
                //clear properties settings
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.Username = Username_TextBox.Text;
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Role = Role;
                Properties.Settings.Default.User_ID = User_ID;
                Properties.Settings.Default.Selected_F2F = UsedDatbase;
                Properties.Settings.Default.Online = false;

                Properties.Settings.Default.Save();
            }
            Properties.Settings.Default.LogedIn = true;
            Program.set_ConnectionString();
        }

        private void Show_Password_Click(object sender, EventArgs e)
        {
            if (Password_TextBox.PasswordChar == '•')
            {
                Password_TextBox.PasswordChar = '\0';
                string Pass = Password_TextBox.Text;
                Password_TextBox.Clear();
                Password_TextBox.Text = Pass;
                Show_Password.BackgroundImage = F2F_Application.Properties.Resources.Password_Hide;
                toolTip1.SetToolTip(Show_Password, "Hide Password");
            }
            else if (Password_TextBox.PasswordChar == '\0')
            {
                Password_TextBox.PasswordChar = '•';
                string Pass = Password_TextBox.Text;
                Password_TextBox.Clear();
                Password_TextBox.Text = Pass;
                Show_Password.BackgroundImage = F2F_Application.Properties.Resources.Password_Show;
                toolTip1.SetToolTip(Show_Password, "Show Password");
            }
        }

        private void Connect_button_MouseEnter(object sender, EventArgs e)
        {
            if (User_Mode)
                Connect_button.BackgroundImage = F2F_Application.Properties.Resources.Login2;
        }

        private void Connect_button_MouseLeave(object sender, EventArgs e)
        {
            if (User_Mode)
                Connect_button.BackgroundImage = F2F_Application.Properties.Resources.Login1;
        }

        private void Remember_checkBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.RememberMe)
                {
                    Properties.Settings.Default.RememberMe = false;
                    Remember_checkBox.BackgroundImage = Properties.Resources.remember_me2;
                }
                else
                {
                    Properties.Settings.Default.RememberMe = true;
                    Remember_checkBox.BackgroundImage = Properties.Resources.remember_me1;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Online_checkBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.Online)
                {
                    Properties.Settings.Default.Online = false;
                    Online_checkBox.BackgroundImage = Properties.Resources.offline;
                    toolTip1.SetToolTip(Online_checkBox, "Offline");
                }
                else
                {
                    Properties.Settings.Default.Online = true;
                    Online_checkBox.BackgroundImage = Properties.Resources.online;
                    toolTip1.SetToolTip(Online_checkBox, "Online");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Colse_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Show_Webpage_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://hcsyria.org/projects/family-to-family");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Username_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                if (Username_TextBox.Text == "Name")
                {
                    Username_TextBox.Clear();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Username_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Username_TextBox.Text))
                {
                    Username_TextBox.Text = "Name";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Password_TextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                if (Password_TextBox.Text == "Password")
                {
                    Password_TextBox.Clear();
                    Password_TextBox.PasswordChar = '•';
                    Show_Password.BackgroundImage = F2F_Application.Properties.Resources.Password_Show;
                    toolTip1.SetToolTip(Show_Password, "Show Password");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void Password_TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Password_TextBox.Text))
                {
                    Password_TextBox.PasswordChar = '\0';
                    Password_TextBox.Text = "Password";
                    Show_Password.BackgroundImage = F2F_Application.Properties.Resources.Password_Hide;
                    toolTip1.SetToolTip(Show_Password, "Hide Password");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MySql") || ex.Message.Contains("MySQL")) { MessageBox.Show("please check your network and try again", "Error"); } else if (ex.Message.Contains("host")) { MessageBox.Show("please check the server or your network connection and try again", "Error"); } else { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tick1 == 0)
            {
                tick1++;
                this.SuspendLayout();

                this.Cursor = Cursors.WaitCursor;

                this.BackgroundImage = F2F_Application.Properties.Resources.Main2;

                Connect_button.BackgroundImage = F2F_Application.Properties.Resources.Login3;

                this.ResumeLayout();
            }
            else
                timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (tick2 == 0)
            {
                tick2++;

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            else
                timer2.Stop();
        }

        private void Colse_Button_MouseEnter(object sender, EventArgs e)
        {
            Colse_Button.BackgroundImage = F2F_Application.Properties.Resources.exit_1;

        }

        private void Colse_Button_MouseLeave(object sender, EventArgs e)
        {
            Colse_Button.BackgroundImage = F2F_Application.Properties.Resources.exit;

        }

        private void Set_User_Image()
        {
            FileInfo file;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Family To Family\Team\" + Properties.Settings.Default.Username + ".png";

            //GET IMAGE IF NOT EXIST
            file = new FileInfo(path);
            if (file.Exists.Equals(false))
            {
                PicArr = u.Select_ProfilePicture(dt.Rows[0].Field<int>("ID"));

                if (PicArr != null && PicArr.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(PicArr);

                    using (FileStream file2 = new FileStream(path, FileMode.Create, System.IO.FileAccess.Write))
                        ms.CopyTo(file2);
                }
            }

            //SET IMAGE
            file = new FileInfo(path);
            if (file.Exists.Equals(true))
            {

                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    ProfilePicture_PictureBox.BackgroundImage = Image.FromStream(stream);
                }

            }
            else
                ProfilePicture_PictureBox.BackgroundImage = Properties.Resources.Default_Profile;

            //DELETE IMAGE FILE
            file = new FileInfo(path);
            if (file.Exists.Equals(true) && !Properties.Settings.Default.RememberMe)
            {
                file.Delete();
            }
        }
    }
}