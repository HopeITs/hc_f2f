namespace F2F_Application
{
    partial class Family_Map
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
            this.FamilyMap = new GMap.NET.WindowsForms.GMapControl();
            this.SuspendLayout();
            // 
            // FamilyMap
            // 
            this.FamilyMap.Bearing = 0F;
            this.FamilyMap.CanDragMap = true;
            this.FamilyMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FamilyMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.FamilyMap.GrayScaleMode = false;
            this.FamilyMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.FamilyMap.LevelsKeepInMemmory = 5;
            this.FamilyMap.Location = new System.Drawing.Point(0, 0);
            this.FamilyMap.MarkersEnabled = true;
            this.FamilyMap.MaxZoom = 2;
            this.FamilyMap.MinZoom = 2;
            this.FamilyMap.MouseWheelZoomEnabled = true;
            this.FamilyMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.FamilyMap.Name = "FamilyMap";
            this.FamilyMap.NegativeMode = false;
            this.FamilyMap.PolygonsEnabled = true;
            this.FamilyMap.RetryLoadTile = 0;
            this.FamilyMap.RoutesEnabled = true;
            this.FamilyMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.FamilyMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.FamilyMap.ShowTileGridLines = false;
            this.FamilyMap.Size = new System.Drawing.Size(1185, 635);
            this.FamilyMap.TabIndex = 17;
            this.FamilyMap.Zoom = 0D;
            // 
            // Family_Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 635);
            this.Controls.Add(this.FamilyMap);
            this.Name = "Family_Map";
            this.Text = "Family_Map";
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl FamilyMap;
    }
}