namespace F2F_Application
{
    partial class Partner_Distribution_Date_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.materialContextMenuStrip1 = new MaterialSkinPlus.Controls.MaterialContextMenuStrip();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.Insert_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TimePicker = new System.Windows.Forms.DateTimePicker();
            this.Date_DataGridView = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.partner_distribution_date_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.materialContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Date_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.09821F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.90179F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.ContextMenuStrip = this.materialContextMenuStrip1;
            this.tableLayoutPanel1.Controls.Add(this.DatePicker, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Insert_button, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TimePicker, 1, 2);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 160);
            this.tableLayoutPanel1.TabIndex = 499;
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
            // DatePicker
            // 
            this.DatePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DatePicker.CalendarFont = new System.Drawing.Font("Tajawal", 11F);
            this.DatePicker.CalendarForeColor = System.Drawing.Color.Black;
            this.DatePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.DatePicker.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatePicker.Location = new System.Drawing.Point(205, 20);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(181, 30);
            this.DatePicker.TabIndex = 1;
            // 
            // Insert_button
            // 
            this.Insert_button.BackColor = System.Drawing.Color.Transparent;
            this.Insert_button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Insert_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Insert_button.FlatAppearance.BorderSize = 0;
            this.Insert_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Insert_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Insert_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Insert_button.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Insert_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Insert_button.Location = new System.Drawing.Point(205, 113);
            this.Insert_button.Name = "Insert_button";
            this.Insert_button.Size = new System.Drawing.Size(105, 42);
            this.Insert_button.TabIndex = 500;
            this.Insert_button.Text = "INSERT";
            this.Insert_button.UseVisualStyleBackColor = false;
            this.Insert_button.Click += new System.EventHandler(this.Insert_button_Click);
            this.Insert_button.MouseEnter += new System.EventHandler(this.Insert_button_MouseEnter);
            this.Insert_button.MouseLeave += new System.EventHandler(this.Insert_button_MouseLeave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 23);
            this.label1.TabIndex = 501;
            this.label1.Text = "Date:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 23);
            this.label2.TabIndex = 502;
            this.label2.Text = "Time:";
            // 
            // TimePicker
            // 
            this.TimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TimePicker.CalendarForeColor = System.Drawing.Color.Black;
            this.TimePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.TimePicker.CustomFormat = "hh:mm tt";
            this.TimePicker.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePicker.Location = new System.Drawing.Point(205, 70);
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TimePicker.ShowUpDown = true;
            this.TimePicker.Size = new System.Drawing.Size(181, 30);
            this.TimePicker.TabIndex = 2;
            // 
            // Date_DataGridView
            // 
            this.Date_DataGridView.AllowUserToAddRows = false;
            this.Date_DataGridView.AllowUserToDeleteRows = false;
            this.Date_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.Date_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.Date_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Date_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Date_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.Date_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.Date_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tajawal", 11.12727F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Date_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.Date_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Date_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delete,
            this.partner_distribution_date_id,
            this.Time,
            this.Date});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tajawal", 11.12727F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Date_DataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.Date_DataGridView.EnableHeadersVisualStyles = false;
            this.Date_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Date_DataGridView.Location = new System.Drawing.Point(2, 226);
            this.Date_DataGridView.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.Date_DataGridView.MultiSelect = false;
            this.Date_DataGridView.Name = "Date_DataGridView";
            this.Date_DataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tajawal", 11.12727F);
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Date_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.Date_DataGridView.RowHeadersVisible = false;
            this.Date_DataGridView.RowHeadersWidth = 25;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Date_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.Date_DataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Date_DataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_DataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Date_DataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Date_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Date_DataGridView.Size = new System.Drawing.Size(525, 374);
            this.Date_DataGridView.StandardTab = true;
            this.Date_DataGridView.TabIndex = 4;
            this.Date_DataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Date_DataGridView_CellBeginEdit);
            this.Date_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Date_DataGridView_CellContentClick);
            this.Date_DataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.Date_DataGridView_CellPainting);
            this.Date_DataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Date_DataGridView_CellValueChanged);
            this.Date_DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Date_DataGridView_DataError);
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Delete.FillWeight = 50F;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Width = 59;
            // 
            // partner_distribution_date_id
            // 
            this.partner_distribution_date_id.HeaderText = "id";
            this.partner_distribution_date_id.Name = "partner_distribution_date_id";
            this.partner_distribution_date_id.Visible = false;
            // 
            // Time
            // 
            this.Time.FillWeight = 98.94492F;
            this.Time.HeaderText = "الوقت";
            this.Time.Name = "Time";
            this.Time.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Date
            // 
            this.Date.FillWeight = 98.94492F;
            this.Date.HeaderText = "التاريخ";
            this.Date.Name = "Date";
            // 
            // Partner_Distribution_Date_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 600);
            this.ContextMenuStrip = this.materialContextMenuStrip1;
            this.Controls.Add(this.Date_DataGridView);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tajawal", 11.12727F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Partner_Distribution_Date_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Partner_Distribution_Date_Form_FormClosing);
            this.Load += new System.EventHandler(this.Partner_Distribution_Time_Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.materialContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Date_DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.DateTimePicker TimePicker;
        private System.Windows.Forms.DataGridView Date_DataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn partner_distribution_date_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private MaterialSkinPlus.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.Button Insert_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}