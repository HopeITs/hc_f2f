namespace F2F_Application
{
    partial class User_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Role_comboBox1 = new System.Windows.Forms.ComboBox();
            this.Username_textBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.Password_textBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.materialContextMenuStrip1 = new MaterialSkinPlus.Controls.MaterialContextMenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProfilePicture_pictureBox = new System.Windows.Forms.PictureBox();
            this.AddImage_button = new System.Windows.Forms.Button();
            this.DeleteImage_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Insert_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.User_DataGridView = new System.Windows.Forms.DataGridView();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pic = new System.Windows.Forms.DataGridViewImageColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.materialContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture_pictureBox)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.User_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Role_comboBox1
            // 
            this.Role_comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Role_comboBox1.BackColor = System.Drawing.Color.White;
            this.Role_comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Role_comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Role_comboBox1.Font = new System.Drawing.Font("Tajawal", 11.12727F);
            this.Role_comboBox1.FormattingEnabled = true;
            this.Role_comboBox1.Location = new System.Drawing.Point(84, 121);
            this.Role_comboBox1.Name = "Role_comboBox1";
            this.Role_comboBox1.Size = new System.Drawing.Size(173, 32);
            this.Role_comboBox1.TabIndex = 3;
            this.Role_comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            // 
            // Username_textBox
            // 
            this.Username_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Username_textBox.Depth = 0;
            this.Username_textBox.Hint = "";
            this.Username_textBox.Location = new System.Drawing.Point(3, 16);
            this.Username_textBox.MaxLength = 32767;
            this.Username_textBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.Username_textBox.Name = "Username_textBox";
            this.Username_textBox.PasswordChar = '\0';
            this.Username_textBox.SelectedText = "";
            this.Username_textBox.SelectionLength = 0;
            this.Username_textBox.SelectionStart = 0;
            this.Username_textBox.Size = new System.Drawing.Size(248, 29);
            this.Username_textBox.TabIndex = 1;
            this.Username_textBox.TabStop = false;
            this.Username_textBox.UseSystemPasswordChar = false;
            // 
            // Password_textBox
            // 
            this.Password_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Password_textBox.Depth = 0;
            this.Password_textBox.Hint = "";
            this.Password_textBox.Location = new System.Drawing.Point(3, 65);
            this.Password_textBox.MaxLength = 32767;
            this.Password_textBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '\0';
            this.Password_textBox.SelectedText = "";
            this.Password_textBox.SelectionLength = 0;
            this.Password_textBox.SelectionStart = 0;
            this.Password_textBox.Size = new System.Drawing.Size(248, 29);
            this.Password_textBox.TabIndex = 2;
            this.Password_textBox.TabStop = false;
            this.Password_textBox.UseSystemPasswordChar = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.42857F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.09524F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.71428F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.142858F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.142858F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.089546F));
            this.tableLayoutPanel1.ContextMenuStrip = this.materialContextMenuStrip1;
            this.tableLayoutPanel1.Controls.Add(this.ProfilePicture_pictureBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.AddImage_button, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.DeleteImage_button, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.Role_comboBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Insert_button, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 66);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.02417F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.65565F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.32018F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 209);
            this.tableLayoutPanel1.TabIndex = 505;
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.materialContextMenuStrip1.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(124, 28);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // ProfilePicture_pictureBox
            // 
            this.ProfilePicture_pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ProfilePicture_pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ProfilePicture_pictureBox.BackgroundImage")));
            this.ProfilePicture_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanel1.SetColumnSpan(this.ProfilePicture_pictureBox, 2);
            this.ProfilePicture_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProfilePicture_pictureBox.InitialImage = null;
            this.ProfilePicture_pictureBox.Location = new System.Drawing.Point(398, 3);
            this.ProfilePicture_pictureBox.Name = "ProfilePicture_pictureBox";
            this.ProfilePicture_pictureBox.Size = new System.Drawing.Size(90, 97);
            this.ProfilePicture_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProfilePicture_pictureBox.TabIndex = 528;
            this.ProfilePicture_pictureBox.TabStop = false;
            // 
            // AddImage_button
            // 
            this.AddImage_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddImage_button.BackColor = System.Drawing.Color.Transparent;
            this.AddImage_button.BackgroundImage = global::F2F_Application.Properties.Resources.Plus_1;
            this.AddImage_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddImage_button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.AddImage_button.FlatAppearance.BorderSize = 0;
            this.AddImage_button.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.AddImage_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AddImage_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AddImage_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddImage_button.ForeColor = System.Drawing.Color.White;
            this.AddImage_button.Location = new System.Drawing.Point(412, 103);
            this.AddImage_button.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.AddImage_button.MaximumSize = new System.Drawing.Size(25, 25);
            this.AddImage_button.MinimumSize = new System.Drawing.Size(25, 25);
            this.AddImage_button.Name = "AddImage_button";
            this.AddImage_button.Size = new System.Drawing.Size(25, 25);
            this.AddImage_button.TabIndex = 5;
            this.toolTip1.SetToolTip(this.AddImage_button, "إضافة صورة المستخدم");
            this.AddImage_button.UseVisualStyleBackColor = false;
            this.AddImage_button.Click += new System.EventHandler(this.AddImage_button_Click);
            this.AddImage_button.MouseEnter += new System.EventHandler(this.AddImage_button_MouseEnter);
            this.AddImage_button.MouseLeave += new System.EventHandler(this.AddImage_button_MouseLeave);
            // 
            // DeleteImage_button
            // 
            this.DeleteImage_button.BackColor = System.Drawing.Color.Transparent;
            this.DeleteImage_button.BackgroundImage = global::F2F_Application.Properties.Resources.Trash_1;
            this.DeleteImage_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeleteImage_button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.DeleteImage_button.FlatAppearance.BorderSize = 0;
            this.DeleteImage_button.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.DeleteImage_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DeleteImage_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DeleteImage_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteImage_button.ForeColor = System.Drawing.Color.White;
            this.DeleteImage_button.Location = new System.Drawing.Point(449, 103);
            this.DeleteImage_button.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.DeleteImage_button.MaximumSize = new System.Drawing.Size(25, 25);
            this.DeleteImage_button.MinimumSize = new System.Drawing.Size(25, 25);
            this.DeleteImage_button.Name = "DeleteImage_button";
            this.DeleteImage_button.Size = new System.Drawing.Size(25, 25);
            this.DeleteImage_button.TabIndex = 6;
            this.toolTip1.SetToolTip(this.DeleteImage_button, "إزالة صورة المستخدم");
            this.DeleteImage_button.UseVisualStyleBackColor = false;
            this.DeleteImage_button.Click += new System.EventHandler(this.DeleteImage_button_Click);
            this.DeleteImage_button.MouseEnter += new System.EventHandler(this.DeleteImage_button_MouseEnter);
            this.DeleteImage_button.MouseLeave += new System.EventHandler(this.DeleteImage_button_MouseLeave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 126);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(44, 23);
            this.label1.TabIndex = 530;
            this.label1.Text = "Role:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Insert_button
            // 
            this.Insert_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Insert_button.BackColor = System.Drawing.Color.Transparent;
            this.Insert_button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Insert_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanel1.SetColumnSpan(this.Insert_button, 2);
            this.Insert_button.FlatAppearance.BorderSize = 0;
            this.Insert_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Insert_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Insert_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Insert_button.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Insert_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Insert_button.Location = new System.Drawing.Point(185, 165);
            this.Insert_button.Name = "Insert_button";
            this.Insert_button.Size = new System.Drawing.Size(105, 41);
            this.Insert_button.TabIndex = 529;
            this.Insert_button.Text = "INSERT";
            this.Insert_button.UseVisualStyleBackColor = false;
            this.Insert_button.Click += new System.EventHandler(this.Insert_button_Click);
            this.Insert_button.MouseEnter += new System.EventHandler(this.Insert_button_MouseEnter);
            this.Insert_button.MouseLeave += new System.EventHandler(this.Insert_button_MouseLeave);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 3);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.5527F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.4473F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.Password_textBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.Username_textBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(389, 97);
            this.tableLayoutPanel3.TabIndex = 499;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(257, 61);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 531;
            this.label2.Text = "كلمة المرور:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(257, 12);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(123, 23);
            this.label3.TabIndex = 532;
            this.label3.Text = "اسم المسختدم:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // User_DataGridView
            // 
            this.User_DataGridView.AllowUserToAddRows = false;
            this.User_DataGridView.AllowUserToDeleteRows = false;
            this.User_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.User_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.User_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.User_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.User_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.User_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.User_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.User_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.User_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.User_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_ID,
            this.Pic,
            this.UserName,
            this.Password,
            this.Role,
            this.Delete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.User_DataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.User_DataGridView.EnableHeadersVisualStyles = false;
            this.User_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.User_DataGridView.Location = new System.Drawing.Point(3, 284);
            this.User_DataGridView.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
            this.User_DataGridView.MultiSelect = false;
            this.User_DataGridView.Name = "User_DataGridView";
            this.User_DataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.User_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.User_DataGridView.RowHeadersVisible = false;
            this.User_DataGridView.RowHeadersWidth = 25;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.User_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.User_DataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.User_DataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_DataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.User_DataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.User_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.User_DataGridView.Size = new System.Drawing.Size(525, 314);
            this.User_DataGridView.StandardTab = true;
            this.User_DataGridView.TabIndex = 8;
            this.User_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.User_DataGridView_CellContentClick);
            this.User_DataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.User_DataGridView_CellDoubleClick);
            this.User_DataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.User_DataGridView_CellMouseEnter);
            this.User_DataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.User_DataGridView_CellPainting);
            this.User_DataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.User_DataGridView_CellValueChanged);
            this.User_DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.User_DataGridView_DataError);
            this.User_DataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.User_DataGridView_EditingControlShowing);
            // 
            // User_ID
            // 
            this.User_ID.HeaderText = "ID";
            this.User_ID.Name = "User_ID";
            this.User_ID.Visible = false;
            // 
            // Pic
            // 
            this.Pic.HeaderText = "";
            this.Pic.Name = "Pic";
            // 
            // UserName
            // 
            this.UserName.HeaderText = "اسم المستخدم";
            this.UserName.Name = "UserName";
            // 
            // Password
            // 
            this.Password.HeaderText = "كلمو المرور";
            this.Password.Name = "Password";
            // 
            // Role
            // 
            this.Role.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Role.HeaderText = "Role";
            this.Role.Name = "Role";
            this.Role.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Role.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Width = 59;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            // 
            // User_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(530, 600);
            this.ContextMenuStrip = this.materialContextMenuStrip1;
            this.Controls.Add(this.User_DataGridView);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "User_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.User_Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.materialContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture_pictureBox)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.User_DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox Role_comboBox1;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField Username_textBox;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField Password_textBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox ProfilePicture_pictureBox;
        private System.Windows.Forms.Button AddImage_button;
        private System.Windows.Forms.Button DeleteImage_button;
        private System.Windows.Forms.DataGridView User_DataGridView;
        private MaterialSkinPlus.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button Insert_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewImageColumn Pic;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewComboBoxColumn Role;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}