using PreviewHandlers;
using System.Windows.Forms;

namespace F2F_Application
{
    partial class News_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(News_Form));
            this.previewHandlerHost1 = new PreviewHandlers.PreviewHandlerHost();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // previewHandlerHost1
            // 
            this.previewHandlerHost1.BorderColor = System.Drawing.Color.White;
            this.previewHandlerHost1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.previewHandlerHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewHandlerHost1.Location = new System.Drawing.Point(0, 0);
            this.previewHandlerHost1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.previewHandlerHost1.Name = "previewHandlerHost1";
            this.previewHandlerHost1.Size = new System.Drawing.Size(742, 731);
            this.previewHandlerHost1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.previewHandlerHost1);
            this.panel1.Location = new System.Drawing.Point(3, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 733);
            this.panel1.TabIndex = 1;
            // 
            // News_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 800);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tajawal", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "News_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.News_Form_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private PreviewHandlerHost previewHandlerHost1;
        private Panel panel1;
    }
}