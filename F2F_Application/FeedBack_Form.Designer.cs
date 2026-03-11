namespace F2F_Application
{
    partial class FeedBack_Form
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
            this.FeedBack_TextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Send_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FeedBack_TextBox
            // 
            this.FeedBack_TextBox.BackColor = System.Drawing.Color.White;
            this.FeedBack_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.FeedBack_TextBox, 2);
            this.FeedBack_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FeedBack_TextBox.Location = new System.Drawing.Point(3, 3);
            this.FeedBack_TextBox.Multiline = true;
            this.FeedBack_TextBox.Name = "FeedBack_TextBox";
            this.FeedBack_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FeedBack_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.FeedBack_TextBox.Size = new System.Drawing.Size(501, 320);
            this.FeedBack_TextBox.TabIndex = 1;
            this.FeedBack_TextBox.Enter += new System.EventHandler(this.NewIdea_TextBox_Enter);
            this.FeedBack_TextBox.Leave += new System.EventHandler(this.NewIdea_TextBox_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::F2F_Application.Properties.Resources.Idea;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 329);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 160);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FeedBack_TextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Send_Button, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 62);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.46342F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.53659F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 492);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // Send_Button
            // 
            this.Send_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Send_Button.BackColor = System.Drawing.Color.Transparent;
            this.Send_Button.BackgroundImage = global::F2F_Application.Properties.Resources.button1;
            this.Send_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Send_Button.FlatAppearance.BorderSize = 0;
            this.Send_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Send_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Send_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Send_Button.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Send_Button.Location = new System.Drawing.Point(321, 385);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(117, 48);
            this.Send_Button.TabIndex = 500;
            this.Send_Button.Text = "SEND";
            this.Send_Button.UseVisualStyleBackColor = false;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            this.Send_Button.MouseEnter += new System.EventHandler(this.Send_Button_MouseEnter);
            this.Send_Button.MouseLeave += new System.EventHandler(this.Send_Button_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label1.Location = new System.Drawing.Point(165, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "هل لديك فكرة جديدة؟؟ أرسلها لنا";
            // 
            // FeedBack_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 556);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tajawal", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeedBack_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NewIdea_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox FeedBack_TextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Send_Button;
    }
}