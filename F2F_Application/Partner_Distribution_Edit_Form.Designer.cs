namespace F2F_Application
{
    partial class Partner_Distribution_Edit_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.materialContextMenuStrip1 = new MaterialSkinPlus.Controls.MaterialContextMenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Distribution_DataGridView = new System.Windows.Forms.DataGridView();
            this.Distribution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partner_donor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distribution_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Distribution_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Add_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Partner_ComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Donor_ComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.materialContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Distribution_DataGridView)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ContextMenuStrip = this.materialContextMenuStrip1;
            this.tableLayoutPanel1.Controls.Add(this.Distribution_DataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.Donor_ComboBox, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Partner_ComboBox, 2, 1);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 65);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(730, 534);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(128, 28);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // Distribution_DataGridView
            // 
            this.Distribution_DataGridView.AllowUserToAddRows = false;
            this.Distribution_DataGridView.AllowUserToDeleteRows = false;
            this.Distribution_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.Distribution_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Distribution_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Distribution_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Distribution_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.Distribution_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Distribution_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Distribution_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Distribution_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Distribution,
            this.partner_donor_id,
            this.Distribution_Date,
            this.Check,
            this.Distribution_id});
            this.tableLayoutPanel1.SetColumnSpan(this.Distribution_DataGridView, 6);
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Distribution_DataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.Distribution_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Distribution_DataGridView.EnableHeadersVisualStyles = false;
            this.Distribution_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Distribution_DataGridView.Location = new System.Drawing.Point(3, 91);
            this.Distribution_DataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Distribution_DataGridView.Name = "Distribution_DataGridView";
            this.Distribution_DataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Distribution_DataGridView.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.Distribution_DataGridView, 6);
            this.Distribution_DataGridView.RowTemplate.Height = 24;
            this.Distribution_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Distribution_DataGridView.Size = new System.Drawing.Size(724, 346);
            this.Distribution_DataGridView.TabIndex = 2;
            this.Distribution_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Distribution_DataGridView_CellContentClick);
            // 
            // Distribution
            // 
            this.Distribution.FillWeight = 75.13765F;
            this.Distribution.HeaderText = "اسم التوزيعة";
            this.Distribution.Name = "Distribution";
            // 
            // partner_donor_id
            // 
            this.partner_donor_id.HeaderText = "partner_donor_id";
            this.partner_donor_id.Name = "partner_donor_id";
            this.partner_donor_id.Visible = false;
            // 
            // Distribution_Date
            // 
            this.Distribution_Date.FillWeight = 102.2038F;
            this.Distribution_Date.HeaderText = "تاريخ التوزيعة";
            this.Distribution_Date.Name = "Distribution_Date";
            // 
            // Check
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            this.Check.DefaultCellStyle = dataGridViewCellStyle3;
            this.Check.FillWeight = 30F;
            this.Check.HeaderText = "";
            this.Check.Name = "Check";
            // 
            // Distribution_id
            // 
            this.Distribution_id.HeaderText = "Distribution_id";
            this.Distribution_id.Name = "Distribution_id";
            this.Distribution_id.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CustomFormat = "yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 44);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(115, 28);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.Leave += new System.EventHandler(this.dateTimePicker1_Leave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 6);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.Controls.Add(this.Add_Button, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 457);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(724, 52);
            this.tableLayoutPanel2.TabIndex = 35;
            // 
            // Add_Button
            // 
            this.Add_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Add_Button.BackColor = System.Drawing.Color.Transparent;
            this.Add_Button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Add_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Add_Button.FlatAppearance.BorderSize = 0;
            this.Add_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Add_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Add_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Add_Button.Location = new System.Drawing.Point(309, 5);
            this.Add_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(105, 42);
            this.Add_Button.TabIndex = 501;
            this.Add_Button.Text = "ADD";
            this.Add_Button.UseVisualStyleBackColor = false;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            this.Add_Button.MouseEnter += new System.EventHandler(this.Add_Button_MouseEnter);
            this.Add_Button.MouseLeave += new System.EventHandler(this.Add_Button_MouseLeave);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 46);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(45, 24);
            this.label2.TabIndex = 41;
            this.label2.Text = "السنة:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 46);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 40;
            this.label1.Text = "الشريك:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Partner_ComboBox
            // 
            this.Partner_ComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Partner_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Partner_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Partner_ComboBox.BackColor = System.Drawing.Color.White;
            this.Partner_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Partner_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            this.Partner_ComboBox.FormattingEnabled = true;
            this.Partner_ComboBox.Location = new System.Drawing.Point(246, 43);
            this.Partner_ComboBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Partner_ComboBox.Name = "Partner_ComboBox";
            this.Partner_ComboBox.Size = new System.Drawing.Size(113, 29);
            this.Partner_ComboBox.TabIndex = 4;
            this.Partner_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            this.Partner_ComboBox.SelectedValueChanged += new System.EventHandler(this.Partner_ComboBox_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 46);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(55, 24);
            this.label3.TabIndex = 42;
            this.label3.Text = "الممول:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Donor_ComboBox
            // 
            this.Donor_ComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Donor_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Donor_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Donor_ComboBox.BackColor = System.Drawing.Color.White;
            this.Donor_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Donor_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F);
            this.Donor_ComboBox.FormattingEnabled = true;
            this.Donor_ComboBox.Location = new System.Drawing.Point(488, 43);
            this.Donor_ComboBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Donor_ComboBox.Name = "Donor_ComboBox";
            this.Donor_ComboBox.Size = new System.Drawing.Size(113, 29);
            this.Donor_ComboBox.TabIndex = 43;
            this.Donor_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Donor_ComboBox_DrawItem);
            this.Donor_ComboBox.SelectedValueChanged += new System.EventHandler(this.Donor_ComboBox_SelectedValueChanged);
            // 
            // Partner_Distribution_Edit_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 600);
            this.ContextMenuStrip = this.materialContextMenuStrip1;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Partner_Distribution_Edit_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Partner_Distribution_Edit_Form_FormClosing);
            this.Load += new System.EventHandler(this.Partner_Distribution_Edit_Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.materialContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Distribution_DataGridView)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView Distribution_DataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MaterialSkinPlus.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ComboBox Partner_ComboBox;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Donor_ComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distribution;
        private System.Windows.Forms.DataGridViewTextBoxColumn partner_donor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distribution_Date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distribution_id;
    }
}