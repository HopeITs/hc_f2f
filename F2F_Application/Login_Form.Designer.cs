namespace F2F_Application
{
    partial class Login_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Remember_checkBox = new System.Windows.Forms.Button();
            this.Colse_Button = new System.Windows.Forms.Button();
            this.Show_Password = new System.Windows.Forms.Button();
            this.Show_Webpage = new System.Windows.Forms.Button();
            this.Online_checkBox = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ProfilePicture_PictureBox = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.Version_Label = new System.Windows.Forms.Label();
            this.Connect_button = new System.Windows.Forms.Button();
            this.Password_TextBox = new ZBobb.AlphaBlendTextBox();
            this.Username_TextBox = new ZBobb.AlphaBlendTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 0;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 0;
            // 
            // Remember_checkBox
            // 
            this.Remember_checkBox.BackColor = System.Drawing.Color.Transparent;
            this.Remember_checkBox.BackgroundImage = global::F2F_Application.Properties.Resources.remember_me2;
            this.Remember_checkBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Remember_checkBox.FlatAppearance.BorderSize = 0;
            this.Remember_checkBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Remember_checkBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Remember_checkBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Remember_checkBox.Location = new System.Drawing.Point(452, 298);
            this.Remember_checkBox.MaximumSize = new System.Drawing.Size(26, 26);
            this.Remember_checkBox.MinimumSize = new System.Drawing.Size(26, 26);
            this.Remember_checkBox.Name = "Remember_checkBox";
            this.Remember_checkBox.Size = new System.Drawing.Size(26, 26);
            this.Remember_checkBox.TabIndex = 439;
            this.Remember_checkBox.TabStop = false;
            this.toolTip1.SetToolTip(this.Remember_checkBox, "Remember me");
            this.Remember_checkBox.UseVisualStyleBackColor = false;
            this.Remember_checkBox.Click += new System.EventHandler(this.Remember_checkBox_Click);
            // 
            // Colse_Button
            // 
            this.Colse_Button.BackColor = System.Drawing.Color.Transparent;
            this.Colse_Button.BackgroundImage = global::F2F_Application.Properties.Resources.exit;
            this.Colse_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Colse_Button.FlatAppearance.BorderSize = 0;
            this.Colse_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Colse_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Colse_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Colse_Button.Location = new System.Drawing.Point(617, 12);
            this.Colse_Button.Name = "Colse_Button";
            this.Colse_Button.Size = new System.Drawing.Size(30, 30);
            this.Colse_Button.TabIndex = 441;
            this.Colse_Button.TabStop = false;
            this.toolTip1.SetToolTip(this.Colse_Button, "Exit");
            this.Colse_Button.UseVisualStyleBackColor = false;
            this.Colse_Button.Click += new System.EventHandler(this.Colse_Button_Click);
            this.Colse_Button.MouseEnter += new System.EventHandler(this.Colse_Button_MouseEnter);
            this.Colse_Button.MouseLeave += new System.EventHandler(this.Colse_Button_MouseLeave);
            // 
            // Show_Password
            // 
            this.Show_Password.BackColor = System.Drawing.Color.Transparent;
            this.Show_Password.BackgroundImage = global::F2F_Application.Properties.Resources.Password_Show;
            this.Show_Password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Show_Password.FlatAppearance.BorderSize = 0;
            this.Show_Password.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Show_Password.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Show_Password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Show_Password.Location = new System.Drawing.Point(452, 351);
            this.Show_Password.MaximumSize = new System.Drawing.Size(26, 26);
            this.Show_Password.MinimumSize = new System.Drawing.Size(26, 26);
            this.Show_Password.Name = "Show_Password";
            this.Show_Password.Size = new System.Drawing.Size(26, 26);
            this.Show_Password.TabIndex = 442;
            this.Show_Password.TabStop = false;
            this.toolTip1.SetToolTip(this.Show_Password, "Show Password");
            this.Show_Password.UseVisualStyleBackColor = false;
            this.Show_Password.Click += new System.EventHandler(this.Show_Password_Click);
            // 
            // Show_Webpage
            // 
            this.Show_Webpage.BackColor = System.Drawing.Color.Transparent;
            this.Show_Webpage.BackgroundImage = global::F2F_Application.Properties.Resources.F2F_Logo;
            this.Show_Webpage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Show_Webpage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Show_Webpage.FlatAppearance.BorderSize = 0;
            this.Show_Webpage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Show_Webpage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Show_Webpage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Show_Webpage.Location = new System.Drawing.Point(452, 157);
            this.Show_Webpage.Name = "Show_Webpage";
            this.Show_Webpage.Size = new System.Drawing.Size(143, 26);
            this.Show_Webpage.TabIndex = 0;
            this.Show_Webpage.TabStop = false;
            this.toolTip1.SetToolTip(this.Show_Webpage, "Family To Family Webpage");
            this.Show_Webpage.UseVisualStyleBackColor = false;
            this.Show_Webpage.Click += new System.EventHandler(this.Show_Webpage_Click);
            // 
            // Online_checkBox
            // 
            this.Online_checkBox.BackColor = System.Drawing.Color.Transparent;
            this.Online_checkBox.BackgroundImage = global::F2F_Application.Properties.Resources.offline;
            this.Online_checkBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Online_checkBox.FlatAppearance.BorderSize = 0;
            this.Online_checkBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Online_checkBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Online_checkBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Online_checkBox.Location = new System.Drawing.Point(486, 298);
            this.Online_checkBox.MaximumSize = new System.Drawing.Size(26, 26);
            this.Online_checkBox.MinimumSize = new System.Drawing.Size(26, 26);
            this.Online_checkBox.Name = "Online_checkBox";
            this.Online_checkBox.Size = new System.Drawing.Size(26, 26);
            this.Online_checkBox.TabIndex = 451;
            this.Online_checkBox.TabStop = false;
            this.toolTip1.SetToolTip(this.Online_checkBox, "Offline");
            this.Online_checkBox.UseVisualStyleBackColor = false;
            this.Online_checkBox.Click += new System.EventHandler(this.Online_checkBox_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ProfilePicture_PictureBox
            // 
            this.ProfilePicture_PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ProfilePicture_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ProfilePicture_PictureBox.Location = new System.Drawing.Point(79, 241);
            this.ProfilePicture_PictureBox.MaximumSize = new System.Drawing.Size(120, 120);
            this.ProfilePicture_PictureBox.MinimumSize = new System.Drawing.Size(120, 120);
            this.ProfilePicture_PictureBox.Name = "ProfilePicture_PictureBox";
            this.ProfilePicture_PictureBox.Size = new System.Drawing.Size(120, 120);
            this.ProfilePicture_PictureBox.TabIndex = 447;
            this.ProfilePicture_PictureBox.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 700;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Version_Label
            // 
            this.Version_Label.BackColor = System.Drawing.Color.Transparent;
            this.Version_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.Version_Label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Version_Label.Location = new System.Drawing.Point(375, 445);
            this.Version_Label.Name = "Version_Label";
            this.Version_Label.Size = new System.Drawing.Size(272, 24);
            this.Version_Label.TabIndex = 449;
            this.Version_Label.Text = "HOPE CENTER | FAMILY TO FAMILY APP. V";
            // 
            // Connect_button
            // 
            this.Connect_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Connect_button.BackColor = System.Drawing.Color.Transparent;
            this.Connect_button.BackgroundImage = global::F2F_Application.Properties.Resources.Login1;
            this.Connect_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Connect_button.FlatAppearance.BorderSize = 0;
            this.Connect_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Connect_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Connect_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Connect_button.Location = new System.Drawing.Point(240, 88);
            this.Connect_button.Name = "Connect_button";
            this.Connect_button.Size = new System.Drawing.Size(172, 65);
            this.Connect_button.TabIndex = 453;
            this.Connect_button.UseVisualStyleBackColor = false;
            this.Connect_button.Click += new System.EventHandler(this.Connect_button_Click);
            this.Connect_button.MouseEnter += new System.EventHandler(this.Connect_button_MouseEnter);
            this.Connect_button.MouseLeave += new System.EventHandler(this.Connect_button_MouseLeave);
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.BackAlpha = 10;
            this.Password_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Password_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_TextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(56)))));
            this.Password_TextBox.Location = new System.Drawing.Point(231, 346);
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.Size = new System.Drawing.Size(196, 27);
            this.Password_TextBox.TabIndex = 3;
            this.Password_TextBox.Text = "Password";
            this.Password_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Password_TextBox.Enter += new System.EventHandler(this.Password_TextBox_Enter);
            this.Password_TextBox.Leave += new System.EventHandler(this.Password_TextBox_Leave);
            // 
            // Username_TextBox
            // 
            this.Username_TextBox.BackAlpha = 10;
            this.Username_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Username_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Username_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_TextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(56)))));
            this.Username_TextBox.Location = new System.Drawing.Point(231, 289);
            this.Username_TextBox.Name = "Username_TextBox";
            this.Username_TextBox.Size = new System.Drawing.Size(196, 27);
            this.Username_TextBox.TabIndex = 2;
            this.Username_TextBox.Text = "Name";
            this.Username_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Username_TextBox.Enter += new System.EventHandler(this.Username_TextBox_Enter);
            this.Username_TextBox.Leave += new System.EventHandler(this.Username_TextBox_Leave);
            // 
            // Login_Form
            // 
            this.AcceptButton = this.Connect_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::F2F_Application.Properties.Resources.Main1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(668, 468);
            this.ControlBox = false;
            this.Controls.Add(this.Connect_button);
            this.Controls.Add(this.Online_checkBox);
            this.Controls.Add(this.Version_Label);
            this.Controls.Add(this.ProfilePicture_PictureBox);
            this.Controls.Add(this.Password_TextBox);
            this.Controls.Add(this.Username_TextBox);
            this.Controls.Add(this.Show_Webpage);
            this.Controls.Add(this.Show_Password);
            this.Controls.Add(this.Colse_Button);
            this.Controls.Add(this.Remember_checkBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(670, 470);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(670, 470);
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Login_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button Remember_checkBox;
        private System.Windows.Forms.Button Colse_Button;
        private System.Windows.Forms.Button Show_Password;
        private System.Windows.Forms.Button Show_Webpage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox ProfilePicture_PictureBox;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label Version_Label;
        private System.Windows.Forms.Button Online_checkBox;
        private System.Windows.Forms.Button Connect_button;
        private ZBobb.AlphaBlendTextBox Password_TextBox;
        private ZBobb.AlphaBlendTextBox Username_TextBox;
    }
}

