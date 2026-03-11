namespace F2F_Application
{
    partial class DistributionDiffer_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistributionDiffer_Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Excel_Button = new System.Windows.Forms.PictureBox();
            this.materialContextMenuStrip1 = new MaterialSkinPlus.Controls.MaterialContextMenuStrip();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.showCurrent = new System.Windows.Forms.PictureBox();
            this.showPrev = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Donor_ComboBox = new System.Windows.Forms.ComboBox();
            this.Distribution_ComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Partner_ComboBox = new System.Windows.Forms.ComboBox();
            this.materialLabel14 = new MaterialSkinPlus.Controls.MaterialLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.total_current = new System.Windows.Forms.Label();
            this.total_prev = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.total_current_value = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.total_prev_value = new System.Windows.Forms.Label();
            this.Differ_DataGridView = new System.Windows.Forms.DataGridView();
            this.Family_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Family_ID_Prev_Temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Excel_Button)).BeginInit();
            this.materialContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPrev)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Differ_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Excel_Button
            // 
            this.Excel_Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Excel_Button.BackColor = System.Drawing.Color.Transparent;
            this.Excel_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Excel_Button.BackgroundImage")));
            this.Excel_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Excel_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Excel_Button.Location = new System.Drawing.Point(23, 33);
            this.Excel_Button.Name = "Excel_Button";
            this.Excel_Button.Size = new System.Drawing.Size(26, 26);
            this.Excel_Button.TabIndex = 516;
            this.Excel_Button.TabStop = false;
            this.toolTip1.SetToolTip(this.Excel_Button, "Exporrt as Excel file");
            this.Excel_Button.Click += new System.EventHandler(this.Excel_Button_Click);
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
            // 
            // showCurrent
            // 
            this.showCurrent.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.showCurrent.BackgroundImage = global::F2F_Application.Properties.Resources.Group_22__2_;
            this.showCurrent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showCurrent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showCurrent.Location = new System.Drawing.Point(3, 3);
            this.showCurrent.Name = "showCurrent";
            this.showCurrent.Size = new System.Drawing.Size(88, 22);
            this.showCurrent.TabIndex = 524;
            this.showCurrent.TabStop = false;
            this.toolTip1.SetToolTip(this.showCurrent, "رؤية العائلات");
            this.showCurrent.Click += new System.EventHandler(this.showCurrent_Click);
            // 
            // showPrev
            // 
            this.showPrev.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.showPrev.BackgroundImage = global::F2F_Application.Properties.Resources.Group_22__2_;
            this.showPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPrev.Location = new System.Drawing.Point(3, 3);
            this.showPrev.Name = "showPrev";
            this.showPrev.Size = new System.Drawing.Size(85, 22);
            this.showPrev.TabIndex = 525;
            this.showPrev.TabStop = false;
            this.toolTip1.SetToolTip(this.showPrev, "رؤية العائلات");
            this.showPrev.Click += new System.EventHandler(this.showPrev_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(936, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(55, 24);
            this.label3.TabIndex = 509;
            this.label3.Text = "الممول:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1240, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(45, 24);
            this.label1.TabIndex = 37;
            this.label1.Text = "السنة:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 9, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.Donor_ComboBox, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.Distribution_ComboBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.Partner_ComboBox, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.Excel_Button, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel14, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label5, 8, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 8, 4);
            this.tableLayoutPanel1.Controls.Add(this.total_current, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.total_prev, 7, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 6, 4);
            this.tableLayoutPanel1.Controls.Add(this.Differ_DataGridView, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 18;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.46408F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.28809F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.69842F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.38578F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.163619F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1427, 1381);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateTimePicker1.CustomFormat = "yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(1107, 32);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(125, 28);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Donor_ComboBox
            // 
            this.Donor_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Donor_ComboBox.BackColor = System.Drawing.Color.White;
            this.Donor_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Donor_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Donor_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Donor_ComboBox.FormattingEnabled = true;
            this.Donor_ComboBox.Location = new System.Drawing.Point(786, 31);
            this.Donor_ComboBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Donor_ComboBox.Name = "Donor_ComboBox";
            this.Donor_ComboBox.Size = new System.Drawing.Size(140, 29);
            this.Donor_ComboBox.TabIndex = 510;
            this.Donor_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Donor_ComboBox_DrawItem_1);
            this.Donor_ComboBox.VisibleChanged += new System.EventHandler(this.Donor_ComboBox_VisibleChanged);
            this.Donor_ComboBox.Leave += new System.EventHandler(this.Donor_ComboBox_Leave);
            // 
            // Distribution_ComboBox
            // 
            this.Distribution_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Distribution_ComboBox.BackColor = System.Drawing.Color.White;
            this.Distribution_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Distribution_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Distribution_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Distribution_ComboBox.FormattingEnabled = true;
            this.Distribution_ComboBox.Location = new System.Drawing.Point(178, 31);
            this.Distribution_ComboBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Distribution_ComboBox.Name = "Distribution_ComboBox";
            this.Distribution_ComboBox.Size = new System.Drawing.Size(140, 29);
            this.Distribution_ComboBox.TabIndex = 2;
            this.Distribution_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Distribution_ComboBox_DrawItem_1);
            this.Distribution_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Distribution_ComboBox_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 38;
            this.label2.Text = "التوزيعة:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(632, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(58, 24);
            this.label4.TabIndex = 511;
            this.label4.Text = "الشريك:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Partner_ComboBox
            // 
            this.Partner_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Partner_ComboBox.BackColor = System.Drawing.Color.White;
            this.Partner_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Partner_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Partner_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Partner_ComboBox.FormattingEnabled = true;
            this.Partner_ComboBox.Location = new System.Drawing.Point(482, 31);
            this.Partner_ComboBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Partner_ComboBox.Name = "Partner_ComboBox";
            this.Partner_ComboBox.Size = new System.Drawing.Size(140, 29);
            this.Partner_ComboBox.TabIndex = 512;
            this.Partner_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Partner_ComboBox_DrawItem_1);
            this.Partner_ComboBox.Leave += new System.EventHandler(this.Partner_ComboBox_Leave);
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.tableLayoutPanel1.SetColumnSpan(this.materialLabel14, 9);
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialLabel14.Font = new System.Drawing.Font("Tajawal", 11F);
            this.materialLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel14.Location = new System.Drawing.Point(23, 167);
            this.materialLabel14.Margin = new System.Windows.Forms.Padding(3);
            this.materialLabel14.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.materialLabel14.Size = new System.Drawing.Size(1362, 31);
            this.materialLabel14.TabIndex = 515;
            this.materialLabel14.Text = "التعديلات الشهرية على العائلات ضمن الـ Signaturelists";
            this.materialLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label5, 2);
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(1087, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(298, 34);
            this.label5.TabIndex = 518;
            this.label5.Text = "عدد العائلات ضمن التوزيعة";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label6, 2);
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(1087, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(298, 34);
            this.label6.TabIndex = 519;
            this.label6.Text = "عدد العائلات ضمن التوزيعة";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // total_current
            // 
            this.total_current.AutoSize = true;
            this.total_current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.total_current.Location = new System.Drawing.Point(935, 83);
            this.total_current.Name = "total_current";
            this.total_current.Size = new System.Drawing.Size(146, 34);
            this.total_current.TabIndex = 520;
            this.total_current.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // total_prev
            // 
            this.total_prev.AutoSize = true;
            this.total_prev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.total_prev.Location = new System.Drawing.Point(935, 117);
            this.total_prev.Name = "total_prev";
            this.total_prev.Size = new System.Drawing.Size(146, 34);
            this.total_prev.TabIndex = 521;
            this.total_prev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.17544F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.82456F));
            this.tableLayoutPanel2.Controls.Add(this.showCurrent, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.total_current_value, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(795, 86);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(134, 28);
            this.tableLayoutPanel2.TabIndex = 526;
            // 
            // total_current_value
            // 
            this.total_current_value.AutoSize = true;
            this.total_current_value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.total_current_value.Location = new System.Drawing.Point(97, 0);
            this.total_current_value.Name = "total_current_value";
            this.total_current_value.Size = new System.Drawing.Size(34, 28);
            this.total_current_value.TabIndex = 522;
            this.total_current_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.65672F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.34328F));
            this.tableLayoutPanel3.Controls.Add(this.showPrev, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.total_prev_value, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(796, 120);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(133, 28);
            this.tableLayoutPanel3.TabIndex = 527;
            // 
            // total_prev_value
            // 
            this.total_prev_value.AutoSize = true;
            this.total_prev_value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.total_prev_value.Location = new System.Drawing.Point(94, 0);
            this.total_prev_value.Name = "total_prev_value";
            this.total_prev_value.Size = new System.Drawing.Size(36, 28);
            this.total_prev_value.TabIndex = 523;
            this.total_prev_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Differ_DataGridView
            // 
            this.Differ_DataGridView.AllowUserToDeleteRows = false;
            this.Differ_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.Differ_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Differ_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Differ_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Differ_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.Differ_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Differ_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Differ_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Differ_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Differ_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Family_ID,
            this.Family_ID_Prev_Temp});
            this.tableLayoutPanel1.SetColumnSpan(this.Differ_DataGridView, 9);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Differ_DataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.Differ_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Differ_DataGridView.EnableHeadersVisualStyles = false;
            this.Differ_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Differ_DataGridView.Location = new System.Drawing.Point(23, 204);
            this.Differ_DataGridView.Name = "Differ_DataGridView";
            this.Differ_DataGridView.ReadOnly = true;
            this.Differ_DataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Differ_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Differ_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Differ_DataGridView.RowHeadersVisible = false;
            this.Differ_DataGridView.RowHeadersWidth = 51;
            this.tableLayoutPanel1.SetRowSpan(this.Differ_DataGridView, 6);
            this.Differ_DataGridView.RowTemplate.Height = 24;
            this.Differ_DataGridView.Size = new System.Drawing.Size(1362, 613);
            this.Differ_DataGridView.TabIndex = 517;
            this.Differ_DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Differ_DataGridView_DataError);
            // 
            // Family_ID
            // 
            this.Family_ID.FillWeight = 111.9289F;
            this.Family_ID.HeaderText = "موجودة في التوزيعة الحالية وغير موجودة في السابقة";
            this.Family_ID.MinimumWidth = 6;
            this.Family_ID.Name = "Family_ID";
            this.Family_ID.ReadOnly = true;
            this.Family_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Family_ID_Prev_Temp
            // 
            this.Family_ID_Prev_Temp.HeaderText = "موجودة في التوزيعة السابقة وغير موجودة في الحالية";
            this.Family_ID_Prev_Temp.MinimumWidth = 6;
            this.Family_ID_Prev_Temp.Name = "Family_ID_Prev_Temp";
            this.Family_ID_Prev_Temp.ReadOnly = true;
            this.Family_ID_Prev_Temp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DistributionDiffer_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1448, 828);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DistributionDiffer_Form";
            this.Text = "Discrimination";
            this.Load += new System.EventHandler(this.DistributionDiffer_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Excel_Button)).EndInit();
            this.materialContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPrev)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Differ_DataGridView)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Donor_ComboBox;
        private System.Windows.Forms.ComboBox Distribution_ComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Partner_ComboBox;
        private MaterialSkinPlus.Controls.MaterialLabel materialLabel14;
        private System.Windows.Forms.PictureBox Excel_Button;
        private System.Windows.Forms.ToolTip toolTip1;
        private MaterialSkinPlus.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label total_current;
        private System.Windows.Forms.Label total_prev;
        private System.Windows.Forms.Label total_current_value;
        private System.Windows.Forms.Label total_prev_value;
        private System.Windows.Forms.PictureBox showCurrent;
        private System.Windows.Forms.PictureBox showPrev;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView Differ_DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Family_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Family_ID_Prev_Temp;
    }
}