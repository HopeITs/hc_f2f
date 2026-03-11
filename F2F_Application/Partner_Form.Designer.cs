namespace F2F_Application
{
    partial class Partner_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Partner_Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PartnerName_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.materialContextMenuStrip1 = new MaterialSkinPlus.Controls.MaterialContextMenuStrip();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.PartnerNameEN_TextBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Partnergroup_ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Insert_button = new System.Windows.Forms.Button();
            this.Logo_pictureBox = new System.Windows.Forms.PictureBox();
            this.AddImage_button = new System.Windows.Forms.Button();
            this.DeleteImage_button = new System.Windows.Forms.Button();
            this.Partner_DataGridView = new System.Windows.Forms.DataGridView();
            this.Partner_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Logo = new System.Windows.Forms.DataGridViewImageColumn();
            this.Partner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Partner_EN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.materialContextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Partner_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PartnerName_TextBox
            // 
            this.PartnerName_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PartnerName_TextBox.Depth = 0;
            this.PartnerName_TextBox.Hint = "";
            this.PartnerName_TextBox.Location = new System.Drawing.Point(4, 8);
            this.PartnerName_TextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PartnerName_TextBox.MaxLength = 32767;
            this.PartnerName_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.PartnerName_TextBox.Name = "PartnerName_TextBox";
            this.PartnerName_TextBox.PasswordChar = '\0';
            this.PartnerName_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PartnerName_TextBox.SelectedText = "";
            this.PartnerName_TextBox.SelectionLength = 0;
            this.PartnerName_TextBox.SelectionStart = 0;
            this.PartnerName_TextBox.Size = new System.Drawing.Size(285, 29);
            this.PartnerName_TextBox.TabIndex = 1;
            this.PartnerName_TextBox.TabStop = false;
            this.PartnerName_TextBox.UseSystemPasswordChar = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.42887F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.43731F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.756025F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.37779F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ContextMenuStrip = this.materialContextMenuStrip1;
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Insert_button, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Logo_pictureBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.AddImage_button, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.DeleteImage_button, 4, 1);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(595, 200);
            this.tableLayoutPanel1.TabIndex = 504;
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem1});
            this.materialContextMenuStrip1.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(124, 28);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(123, 24);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.66841F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.33159F));
            this.tableLayoutPanel3.Controls.Add(this.PartnerNameEN_TextBox, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.PartnerName_TextBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.Partnergroup_ComboBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(24, 5);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(428, 140);
            this.tableLayoutPanel3.TabIndex = 499;
            // 
            // PartnerNameEN_TextBox
            // 
            this.PartnerNameEN_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PartnerNameEN_TextBox.Depth = 0;
            this.PartnerNameEN_TextBox.Hint = "";
            this.PartnerNameEN_TextBox.Location = new System.Drawing.Point(4, 101);
            this.PartnerNameEN_TextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PartnerNameEN_TextBox.MaxLength = 32767;
            this.PartnerNameEN_TextBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.PartnerNameEN_TextBox.Name = "PartnerNameEN_TextBox";
            this.PartnerNameEN_TextBox.PasswordChar = '\0';
            this.PartnerNameEN_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PartnerNameEN_TextBox.SelectedText = "";
            this.PartnerNameEN_TextBox.SelectionLength = 0;
            this.PartnerNameEN_TextBox.SelectionStart = 0;
            this.PartnerNameEN_TextBox.Size = new System.Drawing.Size(285, 29);
            this.PartnerNameEN_TextBox.TabIndex = 535;
            this.PartnerNameEN_TextBox.TabStop = false;
            this.PartnerNameEN_TextBox.UseSystemPasswordChar = false;
            this.PartnerNameEN_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PartnerNameEN_TextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 532;
            this.label2.Text = "المجموعة:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(103, 23);
            this.label3.TabIndex = 531;
            this.label3.Text = "اسم الشريك:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Partnergroup_ComboBox
            // 
            this.Partnergroup_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Partnergroup_ComboBox.BackColor = System.Drawing.Color.White;
            this.Partnergroup_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Partnergroup_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Partnergroup_ComboBox.FormattingEnabled = true;
            this.Partnergroup_ComboBox.Location = new System.Drawing.Point(3, 57);
            this.Partnergroup_ComboBox.Name = "Partnergroup_ComboBox";
            this.Partnergroup_ComboBox.Size = new System.Drawing.Size(287, 32);
            this.Partnergroup_ComboBox.TabIndex = 533;
            this.Partnergroup_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 534;
            this.label1.Text = "Partner Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Insert_button
            // 
            this.Insert_button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Insert_button.BackColor = System.Drawing.Color.Transparent;
            this.Insert_button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Insert_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Insert_button.FlatAppearance.BorderSize = 0;
            this.Insert_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Insert_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Insert_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Insert_button.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Insert_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Insert_button.Location = new System.Drawing.Point(226, 155);
            this.Insert_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Insert_button.Name = "Insert_button";
            this.Insert_button.Size = new System.Drawing.Size(105, 40);
            this.Insert_button.TabIndex = 530;
            this.Insert_button.Text = "INSERT";
            this.Insert_button.UseVisualStyleBackColor = false;
            this.Insert_button.Click += new System.EventHandler(this.Insert_button_Click);
            this.Insert_button.MouseEnter += new System.EventHandler(this.Insert_button_MouseEnter);
            this.Insert_button.MouseLeave += new System.EventHandler(this.Insert_button_MouseLeave);
            // 
            // Logo_pictureBox
            // 
            this.Logo_pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.Logo_pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Logo_pictureBox.BackgroundImage")));
            this.Logo_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanel1.SetColumnSpan(this.Logo_pictureBox, 2);
            this.Logo_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Logo_pictureBox.InitialImage = null;
            this.Logo_pictureBox.Location = new System.Drawing.Point(459, 3);
            this.Logo_pictureBox.Name = "Logo_pictureBox";
            this.Logo_pictureBox.Size = new System.Drawing.Size(97, 109);
            this.Logo_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo_pictureBox.TabIndex = 533;
            this.Logo_pictureBox.TabStop = false;
            // 
            // AddImage_button
            // 
            this.AddImage_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.AddImage_button.Location = new System.Drawing.Point(464, 115);
            this.AddImage_button.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.AddImage_button.MaximumSize = new System.Drawing.Size(25, 25);
            this.AddImage_button.MinimumSize = new System.Drawing.Size(25, 25);
            this.AddImage_button.Name = "AddImage_button";
            this.AddImage_button.Size = new System.Drawing.Size(25, 25);
            this.AddImage_button.TabIndex = 531;
            this.toolTip1.SetToolTip(this.AddImage_button, "إضافة صورة المستخدم");
            this.AddImage_button.UseVisualStyleBackColor = false;
            this.AddImage_button.Click += new System.EventHandler(this.AddImage_button_Click);
            this.AddImage_button.MouseEnter += new System.EventHandler(this.AddImage_button_MouseEnter);
            this.AddImage_button.MouseLeave += new System.EventHandler(this.AddImage_button_MouseLeave);
            // 
            // DeleteImage_button
            // 
            this.DeleteImage_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.DeleteImage_button.Location = new System.Drawing.Point(521, 115);
            this.DeleteImage_button.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.DeleteImage_button.MaximumSize = new System.Drawing.Size(25, 25);
            this.DeleteImage_button.MinimumSize = new System.Drawing.Size(25, 25);
            this.DeleteImage_button.Name = "DeleteImage_button";
            this.DeleteImage_button.Size = new System.Drawing.Size(25, 25);
            this.DeleteImage_button.TabIndex = 532;
            this.toolTip1.SetToolTip(this.DeleteImage_button, "إزالة صورة المستخدم");
            this.DeleteImage_button.UseVisualStyleBackColor = false;
            this.DeleteImage_button.Click += new System.EventHandler(this.DeleteImage_button_Click);
            this.DeleteImage_button.MouseEnter += new System.EventHandler(this.DeleteImage_button_MouseEnter);
            this.DeleteImage_button.MouseLeave += new System.EventHandler(this.DeleteImage_button_MouseLeave);
            // 
            // Partner_DataGridView
            // 
            this.Partner_DataGridView.AllowUserToAddRows = false;
            this.Partner_DataGridView.AllowUserToDeleteRows = false;
            this.Partner_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.Partner_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Partner_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Partner_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Partner_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.Partner_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.Partner_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Partner_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Partner_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Partner_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Partner_ID,
            this.Logo,
            this.Partner,
            this.Partner_EN,
            this.Group,
            this.Delete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Partner_DataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.Partner_DataGridView.EnableHeadersVisualStyles = false;
            this.Partner_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Partner_DataGridView.Location = new System.Drawing.Point(3, 264);
            this.Partner_DataGridView.Margin = new System.Windows.Forms.Padding(6, 15, 6, 15);
            this.Partner_DataGridView.MultiSelect = false;
            this.Partner_DataGridView.Name = "Partner_DataGridView";
            this.Partner_DataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Partner_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Partner_DataGridView.RowHeadersVisible = false;
            this.Partner_DataGridView.RowHeadersWidth = 25;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Partner_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Partner_DataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Partner_DataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Partner_DataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Partner_DataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Partner_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Partner_DataGridView.Size = new System.Drawing.Size(595, 333);
            this.Partner_DataGridView.StandardTab = true;
            this.Partner_DataGridView.TabIndex = 6;
            this.Partner_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Partner_DataGridView_CellContentClick);
            this.Partner_DataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Partner_DataGridView_CellDoubleClick);
            this.Partner_DataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Partner_DataGridView_CellMouseEnter);
            this.Partner_DataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.Partner_DataGridView_CellPainting);
            this.Partner_DataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Partner_DataGridView_CellValueChanged);
            this.Partner_DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Partner_DataGridView_DataError);
            // 
            // Partner_ID
            // 
            this.Partner_ID.HeaderText = "ID";
            this.Partner_ID.Name = "Partner_ID";
            this.Partner_ID.Visible = false;
            // 
            // Logo
            // 
            this.Logo.HeaderText = "الشعار";
            this.Logo.Name = "Logo";
            // 
            // Partner
            // 
            this.Partner.HeaderText = "الشريك";
            this.Partner.Name = "Partner";
            // 
            // Partner_EN
            // 
            this.Partner_EN.HeaderText = "Partner";
            this.Partner_EN.Name = "Partner_EN";
            // 
            // Group
            // 
            this.Group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Group.HeaderText = "المجموعة";
            this.Group.Name = "Group";
            this.Group.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Group.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // Partner_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.ContextMenuStrip = this.materialContextMenuStrip1;
            this.Controls.Add(this.Partner_DataGridView);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Partner_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NewPartnerForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Partner_DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField PartnerName_TextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView Partner_DataGridView;
        private MaterialSkinPlus.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button Insert_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddImage_button;
        private System.Windows.Forms.Button DeleteImage_button;
        private System.Windows.Forms.PictureBox Logo_pictureBox;
        private System.Windows.Forms.ComboBox Partnergroup_ComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partner_ID;
        private System.Windows.Forms.DataGridViewImageColumn Logo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partner_EN;
        private System.Windows.Forms.DataGridViewComboBoxColumn Group;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField PartnerNameEN_TextBox;
        private System.Windows.Forms.Label label1;
    }
}