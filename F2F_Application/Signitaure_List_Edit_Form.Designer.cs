namespace F2F_Application
{
    partial class Signitaure_List_Edit_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signitaure_List_Edit_Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.materialContextMenuStrip1 = new MaterialSkinPlus.Controls.MaterialContextMenuStrip();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SignitaureList_DataGridView = new System.Windows.Forms.DataGridView();
            this.Add_Button = new System.Windows.Forms.Button();
            this.Family_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reciever_FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reciever_FatherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reciever_LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.National_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MembersNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Family_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.materialContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SignitaureList_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ContextMenuStrip = this.materialContextMenuStrip1;
            this.tableLayoutPanel1.Controls.Add(this.SignitaureList_DataGridView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Add_Button, 3, 7);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
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
            resources.ApplyResources(this.materialContextMenuStrip1, "materialContextMenuStrip1");
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            resources.ApplyResources(this.refreshToolStripMenuItem1, "refreshToolStripMenuItem1");
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // SignitaureList_DataGridView
            // 
            this.SignitaureList_DataGridView.AllowUserToAddRows = false;
            this.SignitaureList_DataGridView.AllowUserToDeleteRows = false;
            this.SignitaureList_DataGridView.AllowUserToResizeRows = false;
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tajawal", 11.12727F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SignitaureList_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.SignitaureList_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SignitaureList_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Family_Code,
            this.Reciever_FirstName,
            this.Reciever_FatherName,
            this.Reciever_LastName,
            this.National_Number,
            this.MembersNumber,
            this.MobileNumber,
            this.Amount,
            this.Check,
            this.Family_id});
            this.tableLayoutPanel1.SetColumnSpan(this.SignitaureList_DataGridView, 5);
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tajawal", 11.12727F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SignitaureList_DataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.SignitaureList_DataGridView, "SignitaureList_DataGridView");
            this.SignitaureList_DataGridView.EnableHeadersVisualStyles = false;
            this.SignitaureList_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.SignitaureList_DataGridView.Name = "SignitaureList_DataGridView";
            this.SignitaureList_DataGridView.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.SignitaureList_DataGridView, 5);
            this.SignitaureList_DataGridView.RowTemplate.Height = 24;
            this.SignitaureList_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SignitaureList_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SignitaureList_DataGridView_CellContentClick);
            // 
            // Add_Button
            // 
            resources.ApplyResources(this.Add_Button, "Add_Button");
            this.Add_Button.BackColor = System.Drawing.Color.Transparent;
            this.Add_Button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Add_Button.FlatAppearance.BorderSize = 0;
            this.Add_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Add_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Add_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.UseVisualStyleBackColor = false;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            this.Add_Button.MouseEnter += new System.EventHandler(this.Add_Button_MouseEnter);
            this.Add_Button.MouseLeave += new System.EventHandler(this.Add_Button_MouseLeave);
            // 
            // Family_Code
            // 
            this.Family_Code.FillWeight = 75.13765F;
            resources.ApplyResources(this.Family_Code, "Family_Code");
            this.Family_Code.Name = "Family_Code";
            // 
            // Reciever_FirstName
            // 
            this.Reciever_FirstName.FillWeight = 102.2038F;
            resources.ApplyResources(this.Reciever_FirstName, "Reciever_FirstName");
            this.Reciever_FirstName.Name = "Reciever_FirstName";
            // 
            // Reciever_FatherName
            // 
            resources.ApplyResources(this.Reciever_FatherName, "Reciever_FatherName");
            this.Reciever_FatherName.Name = "Reciever_FatherName";
            // 
            // Reciever_LastName
            // 
            resources.ApplyResources(this.Reciever_LastName, "Reciever_LastName");
            this.Reciever_LastName.Name = "Reciever_LastName";
            // 
            // National_Number
            // 
            this.National_Number.FillWeight = 118.3407F;
            resources.ApplyResources(this.National_Number, "National_Number");
            this.National_Number.Name = "National_Number";
            // 
            // MembersNumber
            // 
            this.MembersNumber.FillWeight = 184.1591F;
            resources.ApplyResources(this.MembersNumber, "MembersNumber");
            this.MembersNumber.Name = "MembersNumber";
            // 
            // MobileNumber
            // 
            this.MobileNumber.FillWeight = 105.99F;
            resources.ApplyResources(this.MobileNumber, "MobileNumber");
            this.MobileNumber.Name = "MobileNumber";
            // 
            // Amount
            // 
            this.Amount.FillWeight = 88.88754F;
            resources.ApplyResources(this.Amount, "Amount");
            this.Amount.Name = "Amount";
            // 
            // Check
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            this.Check.DefaultCellStyle = dataGridViewCellStyle3;
            this.Check.FillWeight = 50F;
            resources.ApplyResources(this.Check, "Check");
            this.Check.Name = "Check";
            // 
            // Family_id
            // 
            resources.ApplyResources(this.Family_id, "Family_id");
            this.Family_id.Name = "Family_id";
            // 
            // Signitaure_List_Edit_Form
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.materialContextMenuStrip1;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Signitaure_List_Edit_Form";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Signitaure_List_Edit_Form_FormClosing);
            this.Load += new System.EventHandler(this.Signitaure_List_Edit_Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.materialContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SignitaureList_DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView SignitaureList_DataGridView;
        private MaterialSkinPlus.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.DataGridViewTextBoxColumn Family_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reciever_FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reciever_FatherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reciever_LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn National_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn MembersNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn Family_id;
    }
}