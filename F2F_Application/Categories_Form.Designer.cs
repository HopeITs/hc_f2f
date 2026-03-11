namespace F2F_Application
{
    partial class Categories_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Categories_Form));
            this.Name_textBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.Categories_ComboBox = new System.Windows.Forms.ComboBox();
            this.Categories_DataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Partner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Donor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_En = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Additional_Info = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isfatal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isdisability = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AdditionalInfo_ComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.materialContextMenuStrip1 = new MaterialSkinPlus.Controls.MaterialContextMenuStrip();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Donor_button = new System.Windows.Forms.Button();
            this.EName_textBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.AdditionalInfo_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Excel_Button = new System.Windows.Forms.PictureBox();
            this.Insert_button = new System.Windows.Forms.Button();
            this.DiseaseInfo_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.IsDisability_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.IsFatal_RadioButton = new MaterialSkinPlus.Controls.MaterialRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Partner_ComboBox = new System.Windows.Forms.ComboBox();
            this.Donor_ComboBox = new System.Windows.Forms.ComboBox();
            this.Partner_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Categories_DataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.materialContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Excel_Button)).BeginInit();
            this.DiseaseInfo_TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Name_textBox
            // 
            this.Name_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Name_textBox.Depth = 0;
            this.Name_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            this.Name_textBox.Hint = "";
            this.Name_textBox.Location = new System.Drawing.Point(235, 48);
            this.Name_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.Name_textBox.MaxLength = 32767;
            this.Name_textBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.PasswordChar = '\0';
            this.Name_textBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Name_textBox.SelectedText = "";
            this.Name_textBox.SelectionLength = 0;
            this.Name_textBox.SelectionStart = 0;
            this.Name_textBox.Size = new System.Drawing.Size(223, 31);
            this.Name_textBox.TabIndex = 2;
            this.Name_textBox.TabStop = false;
            this.Name_textBox.UseSystemPasswordChar = false;
            // 
            // Categories_ComboBox
            // 
            this.Categories_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Categories_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Categories_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Categories_ComboBox.BackColor = System.Drawing.Color.White;
            this.Categories_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Categories_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Categories_ComboBox.FormattingEnabled = true;
            this.Categories_ComboBox.Location = new System.Drawing.Point(235, 15);
            this.Categories_ComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.Categories_ComboBox.Name = "Categories_ComboBox";
            this.Categories_ComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Categories_ComboBox.Size = new System.Drawing.Size(223, 29);
            this.Categories_ComboBox.TabIndex = 1;
            this.Categories_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            this.Categories_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Categories_ComboBox_SelectedIndexChanged);
            // 
            // Categories_DataGridView
            // 
            this.Categories_DataGridView.AllowUserToAddRows = false;
            this.Categories_DataGridView.AllowUserToDeleteRows = false;
            this.Categories_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.Categories_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Categories_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Categories_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Categories_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.Categories_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.Categories_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Categories_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Categories_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Categories_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Info,
            this.Partner,
            this.Donor,
            this.Name_En,
            this.Additional_Info,
            this.isfatal,
            this.isdisability,
            this.Delete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Categories_DataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.Categories_DataGridView.EnableHeadersVisualStyles = false;
            this.Categories_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Categories_DataGridView.Location = new System.Drawing.Point(3, 280);
            this.Categories_DataGridView.Margin = new System.Windows.Forms.Padding(4, 10, 4, 10);
            this.Categories_DataGridView.MultiSelect = false;
            this.Categories_DataGridView.Name = "Categories_DataGridView";
            this.Categories_DataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Categories_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Categories_DataGridView.RowHeadersVisible = false;
            this.Categories_DataGridView.RowHeadersWidth = 25;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Categories_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Categories_DataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Categories_DataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Categories_DataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Categories_DataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Categories_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Categories_DataGridView.Size = new System.Drawing.Size(695, 320);
            this.Categories_DataGridView.StandardTab = true;
            this.Categories_DataGridView.TabIndex = 6;
            this.Categories_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Categories_DataGridView_CellContentClick);
            this.Categories_DataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.Categories_DataGridView_CellPainting);
            this.Categories_DataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Categories_DataGridView_CellValueChanged);
            this.Categories_DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Categories_DataGridView_DataError);
            this.Categories_DataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Categories_DataGridView_EditingControlShowing);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // Info
            // 
            this.Info.FillWeight = 98.94492F;
            this.Info.HeaderText = "Name";
            this.Info.MinimumWidth = 6;
            this.Info.Name = "Info";
            // 
            // Partner
            // 
            this.Partner.HeaderText = "Partner";
            this.Partner.MinimumWidth = 6;
            this.Partner.Name = "Partner";
            // 
            // Donor
            // 
            this.Donor.HeaderText = "Donor";
            this.Donor.MinimumWidth = 6;
            this.Donor.Name = "Donor";
            // 
            // Name_En
            // 
            this.Name_En.HeaderText = "English Name";
            this.Name_En.MinimumWidth = 6;
            this.Name_En.Name = "Name_En";
            // 
            // Additional_Info
            // 
            this.Additional_Info.FillWeight = 98.94492F;
            this.Additional_Info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Additional_Info.HeaderText = "Additional Info";
            this.Additional_Info.MinimumWidth = 6;
            this.Additional_Info.Name = "Additional_Info";
            this.Additional_Info.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Additional_Info.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // isfatal
            // 
            this.isfatal.HeaderText = "Is Fatal";
            this.isfatal.MinimumWidth = 6;
            this.isfatal.Name = "isfatal";
            // 
            // isdisability
            // 
            this.isdisability.HeaderText = "Is Disability";
            this.isdisability.MinimumWidth = 6;
            this.isdisability.Name = "isdisability";
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Delete.FillWeight = 50F;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.HeaderText = "Delete";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.Width = 69;
            // 
            // AdditionalInfo_ComboBox
            // 
            this.AdditionalInfo_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AdditionalInfo_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.AdditionalInfo_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.AdditionalInfo_ComboBox.BackColor = System.Drawing.Color.White;
            this.AdditionalInfo_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.AdditionalInfo_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            this.AdditionalInfo_ComboBox.FormattingEnabled = true;
            this.AdditionalInfo_ComboBox.Location = new System.Drawing.Point(4, 147);
            this.AdditionalInfo_ComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.AdditionalInfo_ComboBox.Name = "AdditionalInfo_ComboBox";
            this.AdditionalInfo_ComboBox.Size = new System.Drawing.Size(223, 29);
            this.AdditionalInfo_ComboBox.TabIndex = 4;
            this.AdditionalInfo_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ContextMenuStrip = this.materialContextMenuStrip1;
            this.tableLayoutPanel1.Controls.Add(this.Donor_button, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.AdditionalInfo_ComboBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.EName_textBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.AdditionalInfo_label, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Excel_Button, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Insert_button, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.DiseaseInfo_TableLayoutPanel, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.Name_textBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Categories_ComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Partner_ComboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Donor_ComboBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Partner_button, 2, 2);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 65);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(695, 213);
            this.tableLayoutPanel1.TabIndex = 498;
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
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(128, 28);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(127, 24);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // Donor_button
            // 
            this.Donor_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Donor_button.BackColor = System.Drawing.Color.Transparent;
            this.Donor_button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Donor_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Donor_button.FlatAppearance.BorderSize = 0;
            this.Donor_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Donor_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Donor_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Donor_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Donor_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Donor_button.Location = new System.Drawing.Point(282, 113);
            this.Donor_button.Name = "Donor_button";
            this.Donor_button.Size = new System.Drawing.Size(129, 27);
            this.Donor_button.TabIndex = 536;
            this.Donor_button.Text = "Add Donor";
            this.Donor_button.UseVisualStyleBackColor = false;
            this.Donor_button.Click += new System.EventHandler(this.Donor_button_Click);
            this.Donor_button.MouseEnter += new System.EventHandler(this.Donor_button_MouseEnter);
            this.Donor_button.MouseLeave += new System.EventHandler(this.Donor_button_MouseLeave);
            // 
            // EName_textBox
            // 
            this.EName_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EName_textBox.Depth = 0;
            this.EName_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            this.EName_textBox.Hint = "";
            this.EName_textBox.Location = new System.Drawing.Point(466, 81);
            this.EName_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.EName_textBox.MaxLength = 32767;
            this.EName_textBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.EName_textBox.Name = "EName_textBox";
            this.EName_textBox.PasswordChar = '\0';
            this.EName_textBox.SelectedText = "";
            this.EName_textBox.SelectionLength = 0;
            this.EName_textBox.SelectionStart = 0;
            this.EName_textBox.Size = new System.Drawing.Size(225, 31);
            this.EName_textBox.TabIndex = 3;
            this.EName_textBox.TabStop = false;
            this.EName_textBox.UseSystemPasswordChar = false;
            this.EName_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.English_TextBox_KeyPress);
            // 
            // AdditionalInfo_label
            // 
            this.AdditionalInfo_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AdditionalInfo_label.AutoSize = true;
            this.AdditionalInfo_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdditionalInfo_label.Location = new System.Drawing.Point(559, 114);
            this.AdditionalInfo_label.Name = "AdditionalInfo_label";
            this.AdditionalInfo_label.Size = new System.Drawing.Size(133, 24);
            this.AdditionalInfo_label.TabIndex = 503;
            this.AdditionalInfo_label.Text = "Additional Info:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 500;
            this.label1.Text = "Category:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(374, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 24);
            this.label3.TabIndex = 502;
            this.label3.Text = "E-Name:";
            // 
            // Excel_Button
            // 
            this.Excel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Excel_Button.BackColor = System.Drawing.Color.Transparent;
            this.Excel_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Excel_Button.BackgroundImage")));
            this.Excel_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Excel_Button.Location = new System.Drawing.Point(465, 149);
            this.Excel_Button.Name = "Excel_Button";
            this.Excel_Button.Size = new System.Drawing.Size(26, 28);
            this.Excel_Button.TabIndex = 531;
            this.Excel_Button.TabStop = false;
            this.Excel_Button.Click += new System.EventHandler(this.Excel_Button_Click);
            this.Excel_Button.MouseEnter += new System.EventHandler(this.Excel_Button_MouseEnter);
            this.Excel_Button.MouseLeave += new System.EventHandler(this.Excel_Button_MouseLeave);
            // 
            // Insert_button
            // 
            this.Insert_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Insert_button.BackColor = System.Drawing.Color.Transparent;
            this.Insert_button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Insert_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Insert_button.FlatAppearance.BorderSize = 0;
            this.Insert_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Insert_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Insert_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Insert_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Insert_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Insert_button.Location = new System.Drawing.Point(33, 183);
            this.Insert_button.Name = "Insert_button";
            this.Insert_button.Size = new System.Drawing.Size(164, 27);
            this.Insert_button.TabIndex = 499;
            this.Insert_button.Text = "INSERT";
            this.Insert_button.UseVisualStyleBackColor = false;
            this.Insert_button.Click += new System.EventHandler(this.Insert_button_Click);
            this.Insert_button.MouseEnter += new System.EventHandler(this.Insert_button_MouseEnter);
            this.Insert_button.MouseLeave += new System.EventHandler(this.Insert_button_MouseLeave);
            // 
            // DiseaseInfo_TableLayoutPanel
            // 
            this.DiseaseInfo_TableLayoutPanel.ColumnCount = 2;
            this.DiseaseInfo_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DiseaseInfo_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DiseaseInfo_TableLayoutPanel.Controls.Add(this.IsDisability_RadioButton, 0, 0);
            this.DiseaseInfo_TableLayoutPanel.Controls.Add(this.IsFatal_RadioButton, 1, 0);
            this.DiseaseInfo_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiseaseInfo_TableLayoutPanel.Location = new System.Drawing.Point(234, 146);
            this.DiseaseInfo_TableLayoutPanel.Name = "DiseaseInfo_TableLayoutPanel";
            this.DiseaseInfo_TableLayoutPanel.RowCount = 1;
            this.DiseaseInfo_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DiseaseInfo_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.DiseaseInfo_TableLayoutPanel.Size = new System.Drawing.Size(225, 31);
            this.DiseaseInfo_TableLayoutPanel.TabIndex = 532;
            // 
            // IsDisability_RadioButton
            // 
            this.IsDisability_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.IsDisability_RadioButton.AutoCheck = false;
            this.IsDisability_RadioButton.AutoSize = true;
            this.IsDisability_RadioButton.Depth = 0;
            this.IsDisability_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.IsDisability_RadioButton.Location = new System.Drawing.Point(0, 0);
            this.IsDisability_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.IsDisability_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.IsDisability_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.IsDisability_RadioButton.Name = "IsDisability_RadioButton";
            this.IsDisability_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IsDisability_RadioButton.Ripple = true;
            this.IsDisability_RadioButton.Size = new System.Drawing.Size(71, 30);
            this.IsDisability_RadioButton.TabIndex = 13;
            this.IsDisability_RadioButton.Text = "إعاقة";
            this.IsDisability_RadioButton.UseVisualStyleBackColor = true;
            this.IsDisability_RadioButton.Click += new System.EventHandler(this.IsDisability_RadioButton_Click);
            // 
            // IsFatal_RadioButton
            // 
            this.IsFatal_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.IsFatal_RadioButton.AutoCheck = false;
            this.IsFatal_RadioButton.AutoSize = true;
            this.IsFatal_RadioButton.Depth = 0;
            this.IsFatal_RadioButton.Font = new System.Drawing.Font("Tajawal", 11F);
            this.IsFatal_RadioButton.Location = new System.Drawing.Point(112, 0);
            this.IsFatal_RadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.IsFatal_RadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.IsFatal_RadioButton.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.IsFatal_RadioButton.Name = "IsFatal_RadioButton";
            this.IsFatal_RadioButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IsFatal_RadioButton.Ripple = true;
            this.IsFatal_RadioButton.Size = new System.Drawing.Size(77, 30);
            this.IsFatal_RadioButton.TabIndex = 12;
            this.IsFatal_RadioButton.Text = "مميت";
            this.IsFatal_RadioButton.UseVisualStyleBackColor = true;
            this.IsFatal_RadioButton.Click += new System.EventHandler(this.IsFatal_RadioButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(162, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 501;
            this.label2.Text = "Name:";
            // 
            // Partner_ComboBox
            // 
            this.Partner_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Partner_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Partner_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Partner_ComboBox.BackColor = System.Drawing.Color.White;
            this.Partner_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Partner_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Partner_ComboBox.FormattingEnabled = true;
            this.Partner_ComboBox.Location = new System.Drawing.Point(466, 48);
            this.Partner_ComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.Partner_ComboBox.Name = "Partner_ComboBox";
            this.Partner_ComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Partner_ComboBox.Size = new System.Drawing.Size(225, 29);
            this.Partner_ComboBox.TabIndex = 533;
            this.Partner_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Partner_ComboBox_DrawItem);
            // 
            // Donor_ComboBox
            // 
            this.Donor_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Donor_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Donor_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Donor_ComboBox.BackColor = System.Drawing.Color.White;
            this.Donor_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Donor_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Donor_ComboBox.FormattingEnabled = true;
            this.Donor_ComboBox.Location = new System.Drawing.Point(4, 114);
            this.Donor_ComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.Donor_ComboBox.Name = "Donor_ComboBox";
            this.Donor_ComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Donor_ComboBox.Size = new System.Drawing.Size(223, 29);
            this.Donor_ComboBox.TabIndex = 534;
            this.Donor_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Donor_ComboBox_DrawItem);
            // 
            // Partner_button
            // 
            this.Partner_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Partner_button.BackColor = System.Drawing.Color.Transparent;
            this.Partner_button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Partner_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Partner_button.FlatAppearance.BorderSize = 0;
            this.Partner_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Partner_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Partner_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Partner_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Partner_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Partner_button.Location = new System.Drawing.Point(51, 80);
            this.Partner_button.Name = "Partner_button";
            this.Partner_button.Size = new System.Drawing.Size(129, 27);
            this.Partner_button.TabIndex = 535;
            this.Partner_button.Text = "Add Partner";
            this.Partner_button.UseVisualStyleBackColor = false;
            this.Partner_button.Click += new System.EventHandler(this.Partner_button_Click);
            this.Partner_button.MouseEnter += new System.EventHandler(this.PartnerBtn_MouseEnter);
            this.Partner_button.MouseLeave += new System.EventHandler(this.Partner_button_MouseLeave);
            // 
            // Categories_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.ContextMenuStrip = this.materialContextMenuStrip1;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Categories_DataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Categories_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Categories_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Categories_DataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.materialContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Excel_Button)).EndInit();
            this.DiseaseInfo_TableLayoutPanel.ResumeLayout(false);
            this.DiseaseInfo_TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField Name_textBox;
        private System.Windows.Forms.ComboBox Categories_ComboBox;
        private System.Windows.Forms.DataGridView Categories_DataGridView;
        private System.Windows.Forms.ComboBox AdditionalInfo_ComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField EName_textBox;
        private MaterialSkinPlus.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.Button Insert_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AdditionalInfo_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox Excel_Button;
        private System.Windows.Forms.TableLayoutPanel DiseaseInfo_TableLayoutPanel;
        private MaterialSkinPlus.Controls.MaterialRadioButton IsDisability_RadioButton;
        private MaterialSkinPlus.Controls.MaterialRadioButton IsFatal_RadioButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Info;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Donor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_En;
        private System.Windows.Forms.DataGridViewComboBoxColumn Additional_Info;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isfatal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isdisability;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.ComboBox Partner_ComboBox;
        private System.Windows.Forms.ComboBox Donor_ComboBox;
        private System.Windows.Forms.Button Partner_button;
        private System.Windows.Forms.Button Donor_button;
    }
}