namespace F2F_Application
{
    partial class Visitor_Form
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
            this.Visitor_DataGridView = new System.Windows.Forms.DataGridView();
            this.VisitorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisitorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Partner = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.VisitorName_textBox = new MaterialSkinPlus.Controls.MaterialSingleLineTextField();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Insert_button = new System.Windows.Forms.Button();
            this.Partner_ComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Visitor_DataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Visitor_DataGridView
            // 
            this.Visitor_DataGridView.AllowUserToAddRows = false;
            this.Visitor_DataGridView.AllowUserToDeleteRows = false;
            this.Visitor_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.Visitor_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Visitor_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Visitor_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Visitor_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.Visitor_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.Visitor_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tajawal", 11.12727F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Visitor_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Visitor_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Visitor_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VisitorID,
            this.VisitorName,
            this.Partner,
            this.Delete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tajawal", 11.12727F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Visitor_DataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.Visitor_DataGridView.EnableHeadersVisualStyles = false;
            this.Visitor_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Visitor_DataGridView.Location = new System.Drawing.Point(2, 232);
            this.Visitor_DataGridView.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
            this.Visitor_DataGridView.MultiSelect = false;
            this.Visitor_DataGridView.Name = "Visitor_DataGridView";
            this.Visitor_DataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tajawal", 11.12727F);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Visitor_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Visitor_DataGridView.RowHeadersVisible = false;
            this.Visitor_DataGridView.RowHeadersWidth = 25;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Visitor_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Visitor_DataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Visitor_DataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Visitor_DataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Visitor_DataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Visitor_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Visitor_DataGridView.Size = new System.Drawing.Size(525, 367);
            this.Visitor_DataGridView.StandardTab = true;
            this.Visitor_DataGridView.TabIndex = 9;
            this.Visitor_DataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Visitor_DataGridView_EditingControlShowing);
            // 
            // VisitorID
            // 
            this.VisitorID.HeaderText = "ID";
            this.VisitorID.Name = "VisitorID";
            this.VisitorID.Visible = false;
            // 
            // VisitorName
            // 
            this.VisitorName.HeaderText = "الاسم";
            this.VisitorName.Name = "VisitorName";
            // 
            // Partner
            // 
            this.Partner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Partner.HeaderText = "الشريك";
            this.Partner.Name = "Partner";
            this.Partner.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Partner.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Width = 59;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.52892F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.47107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.VisitorName_textBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Partner_ComboBox, 1, 1);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 61);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 167);
            this.tableLayoutPanel1.TabIndex = 506;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(342, 71);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 530;
            this.label1.Text = "الشريك";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(342, 16);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 532;
            this.label3.Text = "الاسم:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VisitorName_textBox
            // 
            this.VisitorName_textBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.VisitorName_textBox.Depth = 0;
            this.VisitorName_textBox.Hint = "";
            this.VisitorName_textBox.Location = new System.Drawing.Point(88, 13);
            this.VisitorName_textBox.MaxLength = 32767;
            this.VisitorName_textBox.MouseState = MaterialSkinPlus.MouseState.HOVER;
            this.VisitorName_textBox.Name = "VisitorName_textBox";
            this.VisitorName_textBox.PasswordChar = '\0';
            this.VisitorName_textBox.SelectedText = "";
            this.VisitorName_textBox.SelectionLength = 0;
            this.VisitorName_textBox.SelectionStart = 0;
            this.VisitorName_textBox.Size = new System.Drawing.Size(248, 29);
            this.VisitorName_textBox.TabIndex = 1;
            this.VisitorName_textBox.TabStop = false;
            this.VisitorName_textBox.UseSystemPasswordChar = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.Insert_button, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(23, 113);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(473, 51);
            this.tableLayoutPanel2.TabIndex = 533;
            // 
            // Insert_button
            // 
            this.Insert_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Insert_button.BackColor = System.Drawing.Color.Transparent;
            this.Insert_button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Insert_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Insert_button.FlatAppearance.BorderSize = 0;
            this.Insert_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Insert_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Insert_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Insert_button.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Insert_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Insert_button.Location = new System.Drawing.Point(183, 5);
            this.Insert_button.Name = "Insert_button";
            this.Insert_button.Size = new System.Drawing.Size(105, 41);
            this.Insert_button.TabIndex = 529;
            this.Insert_button.Text = "INSERT";
            this.Insert_button.UseVisualStyleBackColor = false;
            // 
            // Partner_ComboBox
            // 
            this.Partner_ComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Partner_ComboBox.BackColor = System.Drawing.Color.White;
            this.Partner_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Partner_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Partner_ComboBox.Font = new System.Drawing.Font("Tajawal", 11.12727F);
            this.Partner_ComboBox.FormattingEnabled = true;
            this.Partner_ComboBox.Location = new System.Drawing.Point(88, 66);
            this.Partner_ComboBox.Name = "Partner_ComboBox";
            this.Partner_ComboBox.Size = new System.Drawing.Size(248, 32);
            this.Partner_ComboBox.TabIndex = 3;
            this.Partner_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            // 
            // Visitor_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(530, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Visitor_DataGridView);
            this.Font = new System.Drawing.Font("Tajawal", 11.12727F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Visitor_Form";
            this.Text = "Visitors_Form";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Visitors_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Visitor_DataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Visitor_DataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private MaterialSkinPlus.Controls.MaterialSingleLineTextField VisitorName_textBox;
        private System.Windows.Forms.ComboBox Partner_ComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Insert_button;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisitorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisitorName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Partner;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}