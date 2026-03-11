namespace F2F_Application
{
    partial class Signitaure_List_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signitaure_List_Form));
            this.materialContextMenuStrip1 = new MaterialSkinPlus.Controls.MaterialContextMenuStrip();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SignitaureList_DataGridView = new Zuby.ADGV.AdvancedDataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.Partner_Name_Label = new System.Windows.Forms.Label();
            this.Approve_Button = new System.Windows.Forms.Button();
            this.Edit_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Distribution_Date_Label = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchToolBar = new Zuby.ADGV.AdvancedDataGridViewSearchToolBar();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.NumOfRows1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.NumOfSelected1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Excel_Button = new System.Windows.Forms.PictureBox();
            this.Month_Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Donor_Name_Label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialContextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SignitaureList_DataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SearchToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Excel_Button)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.ContextMenuStrip = this.materialContextMenuStrip1;
            this.tableLayoutPanel1.Controls.Add(this.SignitaureList_DataGridView, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label3, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.Partner_Name_Label, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.Approve_Button, 4, 15);
            this.tableLayoutPanel1.Controls.Add(this.Edit_Button, 3, 15);
            this.tableLayoutPanel1.Controls.Add(this.Save_Button, 5, 15);
            this.tableLayoutPanel1.Controls.Add(this.label1, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.Distribution_Date_Label, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Excel_Button, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Month_Label, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Donor_Name_Label, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 17;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(998, 738);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // SignitaureList_DataGridView
            // 
            this.SignitaureList_DataGridView.AllowUserToAddRows = false;
            this.SignitaureList_DataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.SignitaureList_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.SignitaureList_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SignitaureList_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.SignitaureList_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SignitaureList_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SignitaureList_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.SignitaureList_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.SignitaureList_DataGridView, 7);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SignitaureList_DataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.SignitaureList_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SignitaureList_DataGridView.EnableHeadersVisualStyles = false;
            this.SignitaureList_DataGridView.FilterAndSortEnabled = true;
            this.SignitaureList_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.SignitaureList_DataGridView.Location = new System.Drawing.Point(14, 175);
            this.SignitaureList_DataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SignitaureList_DataGridView.Name = "SignitaureList_DataGridView";
            this.SignitaureList_DataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SignitaureList_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SignitaureList_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.SignitaureList_DataGridView.RowHeadersVisible = false;
            this.SignitaureList_DataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tableLayoutPanel1.SetRowSpan(this.SignitaureList_DataGridView, 8);
            this.SignitaureList_DataGridView.RowTemplate.Height = 27;
            this.SignitaureList_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SignitaureList_DataGridView.Size = new System.Drawing.Size(937, 470);
            this.SignitaureList_DataGridView.TabIndex = 7;
            this.SignitaureList_DataGridView.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.SignitaureList_DataGridView_SortStringChanged);
            this.SignitaureList_DataGridView.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.SignitaureList_DataGridView_FilterStringChanged);
            this.SignitaureList_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SignitaureList_DataGridView_CellContentClick);
            this.SignitaureList_DataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.SignitaureList_DataGridView_CellEndEdit);
            this.SignitaureList_DataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.SignitaureList_DataGridView_CellFormatting);
            this.SignitaureList_DataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.SignitaureList_DataGridView_CellPainting);
            this.SignitaureList_DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.SignitaureList_DataGridView_DataError);
            this.SignitaureList_DataGridView.SelectionChanged += new System.EventHandler(this.SignitaureList_DataGridView_SelectionChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(823, 58);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(102, 24);
            this.label3.TabIndex = 504;
            this.label3.Text = "تاريخ التوزيعة:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Partner_Name_Label
            // 
            this.Partner_Name_Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Partner_Name_Label.AutoSize = true;
            this.Partner_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Partner_Name_Label.Location = new System.Drawing.Point(697, 10);
            this.Partner_Name_Label.Name = "Partner_Name_Label";
            this.Partner_Name_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Partner_Name_Label.Size = new System.Drawing.Size(120, 40);
            this.Partner_Name_Label.TabIndex = 503;
            this.Partner_Name_Label.Text = "Partner_Name";
            this.Partner_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Approve_Button
            // 
            this.Approve_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Approve_Button.BackColor = System.Drawing.Color.Transparent;
            this.Approve_Button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Approve_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Approve_Button.FlatAppearance.BorderSize = 0;
            this.Approve_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Approve_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Approve_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Approve_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Approve_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Approve_Button.Location = new System.Drawing.Point(420, 664);
            this.Approve_Button.Name = "Approve_Button";
            this.Approve_Button.Size = new System.Drawing.Size(125, 52);
            this.Approve_Button.TabIndex = 503;
            this.Approve_Button.Text = "APROVE";
            this.Approve_Button.UseVisualStyleBackColor = false;
            this.Approve_Button.Click += new System.EventHandler(this.Approve_Button_Click);
            this.Approve_Button.MouseEnter += new System.EventHandler(this.Approve_Button_MouseEnter);
            this.Approve_Button.MouseLeave += new System.EventHandler(this.Approve_Button_MouseLeave);
            // 
            // Edit_Button
            // 
            this.Edit_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Edit_Button.BackColor = System.Drawing.Color.Transparent;
            this.Edit_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Edit_Button.BackgroundImage")));
            this.Edit_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Edit_Button.FlatAppearance.BorderSize = 0;
            this.Edit_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Edit_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Edit_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Edit_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edit_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Edit_Button.Location = new System.Drawing.Point(285, 664);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(125, 52);
            this.Edit_Button.TabIndex = 504;
            this.Edit_Button.Text = "EDIT";
            this.Edit_Button.UseVisualStyleBackColor = false;
            this.Edit_Button.Click += new System.EventHandler(this.Edit_Button_Click);
            this.Edit_Button.MouseEnter += new System.EventHandler(this.Edit_Button_MouseEnter);
            this.Edit_Button.MouseLeave += new System.EventHandler(this.Edit_Button_MouseLeave);
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Save_Button.BackColor = System.Drawing.Color.Transparent;
            this.Save_Button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Save_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Save_Button.FlatAppearance.BorderSize = 0;
            this.Save_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Save_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Save_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Save_Button.Location = new System.Drawing.Point(555, 664);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(125, 52);
            this.Save_Button.TabIndex = 505;
            this.Save_Button.Text = "SAVE";
            this.Save_Button.UseVisualStyleBackColor = false;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            this.Save_Button.MouseEnter += new System.EventHandler(this.Save_Button_MouseEnter);
            this.Save_Button.MouseLeave += new System.EventHandler(this.Save_Button_MouseLeave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(823, 18);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 502;
            this.label1.Text = "الشريك:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Distribution_Date_Label
            // 
            this.Distribution_Date_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.Distribution_Date_Label, 5);
            this.Distribution_Date_Label.Depth = 0;
            this.Distribution_Date_Label.Enabled = false;
            this.Distribution_Date_Label.Hint = "";
            this.Distribution_Date_Label.Location = new System.Drawing.Point(148, 54);
            this.Distribution_Date_Label.MaxLength = 32767;
            this.Distribution_Date_Label.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.Distribution_Date_Label.Name = "Distribution_Date_Label";
            this.Distribution_Date_Label.PasswordChar = '\0';
            this.Distribution_Date_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Distribution_Date_Label.SelectedText = "";
            this.Distribution_Date_Label.SelectionLength = 0;
            this.Distribution_Date_Label.SelectionStart = 0;
            this.Distribution_Date_Label.Size = new System.Drawing.Size(669, 31);
            this.Distribution_Date_Label.TabIndex = 34;
            this.Distribution_Date_Label.TabStop = false;
            this.Distribution_Date_Label.UseSystemPasswordChar = false;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 7);
            this.panel1.Controls.Add(this.SearchToolBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(13, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 54);
            this.panel1.TabIndex = 507;
            // 
            // SearchToolBar
            // 
            this.SearchToolBar.AllowMerge = false;
            this.SearchToolBar.AutoSize = false;
            this.SearchToolBar.BackColor = System.Drawing.Color.White;
            this.SearchToolBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchToolBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            this.SearchToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SearchToolBar.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.SearchToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.NumOfRows1,
            this.toolStripLabel3,
            this.NumOfSelected1,
            this.toolStripSeparator2,
            this.toolStripSeparator4});
            this.SearchToolBar.Location = new System.Drawing.Point(0, 0);
            this.SearchToolBar.MaximumSize = new System.Drawing.Size(0, 44);
            this.SearchToolBar.MinimumSize = new System.Drawing.Size(0, 44);
            this.SearchToolBar.Name = "SearchToolBar";
            this.SearchToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.SearchToolBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SearchToolBar.Size = new System.Drawing.Size(939, 44);
            this.SearchToolBar.TabIndex = 21;
            this.SearchToolBar.Search += new Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventHandler(this.SearchToolBar_Search_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripSeparator1.Size = new System.Drawing.Size(10, 35);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripLabel2.Size = new System.Drawing.Size(77, 41);
            this.toolStripLabel2.Text = "العدد الكلي:";
            // 
            // NumOfRows1
            // 
            this.NumOfRows1.ForeColor = System.Drawing.Color.Black;
            this.NumOfRows1.Name = "NumOfRows1";
            this.NumOfRows1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.NumOfRows1.Size = new System.Drawing.Size(20, 41);
            this.NumOfRows1.Text = "0";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripLabel3.Size = new System.Drawing.Size(57, 41);
            this.toolStripLabel3.Text = "المحددة:";
            // 
            // NumOfSelected1
            // 
            this.NumOfSelected1.ForeColor = System.Drawing.Color.Black;
            this.NumOfSelected1.Name = "NumOfSelected1";
            this.NumOfSelected1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.NumOfSelected1.Size = new System.Drawing.Size(20, 41);
            this.NumOfSelected1.Text = "0";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripSeparator4.Size = new System.Drawing.Size(10, 35);
            // 
            // Excel_Button
            // 
            this.Excel_Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Excel_Button.BackColor = System.Drawing.Color.Transparent;
            this.Excel_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Excel_Button.BackgroundImage")));
            this.Excel_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Excel_Button.Location = new System.Drawing.Point(13, 56);
            this.Excel_Button.Name = "Excel_Button";
            this.Excel_Button.Size = new System.Drawing.Size(26, 28);
            this.Excel_Button.TabIndex = 506;
            this.Excel_Button.TabStop = false;
            this.toolTip1.SetToolTip(this.Excel_Button, "Exporrt as Excel file");
            this.Excel_Button.Click += new System.EventHandler(this.Excel_Button_Click);
            this.Excel_Button.MouseEnter += new System.EventHandler(this.Excel_Button_MouseEnter);
            this.Excel_Button.MouseLeave += new System.EventHandler(this.Excel_Button_MouseLeave);
            // 
            // Month_Label
            // 
            this.Month_Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Month_Label.AutoSize = true;
            this.Month_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Month_Label.Location = new System.Drawing.Point(79, 18);
            this.Month_Label.Name = "Month_Label";
            this.Month_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Month_Label.Size = new System.Drawing.Size(63, 24);
            this.Month_Label.TabIndex = 504;
            this.Month_Label.Text = "Month";
            this.Month_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(148, 18);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(49, 24);
            this.label2.TabIndex = 503;
            this.label2.Text = "الشهر:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Donor_Name_Label
            // 
            this.Donor_Name_Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Donor_Name_Label.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.Donor_Name_Label, 2);
            this.Donor_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Donor_Name_Label.Location = new System.Drawing.Point(424, 18);
            this.Donor_Name_Label.Name = "Donor_Name_Label";
            this.Donor_Name_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Donor_Name_Label.Size = new System.Drawing.Size(123, 24);
            this.Donor_Name_Label.TabIndex = 509;
            this.Donor_Name_Label.Text = "Donor_Name";
            this.Donor_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(553, 18);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(55, 24);
            this.label4.TabIndex = 508;
            this.label4.Text = "الممول:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripLabel1.Size = new System.Drawing.Size(91, 41);
            this.toolStripLabel1.Text = "العدد الكلي:";
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(1, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(998, 738);
            this.panel2.TabIndex = 2;
            // 
            // Signitaure_List_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.ContextMenuStrip = this.materialContextMenuStrip1;
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Signitaure_List_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Signitaure_List_Form_FormClosing);
            this.Load += new System.EventHandler(this.Signitaure_List_Form_Load);
            this.Shown += new System.EventHandler(this.Signitaure_List_Form_Shown);
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SignitaureList_DataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.SearchToolBar.ResumeLayout(false);
            this.SearchToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Excel_Button)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkinPlus.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField Distribution_Date_Label;
        private System.Windows.Forms.Button Approve_Button;
        private System.Windows.Forms.Button Edit_Button;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Month_Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Partner_Name_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Excel_Button;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private Zuby.ADGV.AdvancedDataGridView SignitaureList_DataGridView;
        private System.Windows.Forms.Panel panel1;
        private Zuby.ADGV.AdvancedDataGridViewSearchToolBar SearchToolBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel NumOfRows1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel NumOfSelected1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Donor_Name_Label;
    }
}