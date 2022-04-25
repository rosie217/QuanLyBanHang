namespace qlbh
{
    partial class FromCrystal
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
            this.crvHD = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvHD
            // 
            this.crvHD.ActiveViewIndex = -1;
            this.crvHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvHD.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvHD.Location = new System.Drawing.Point(0, 0);
            this.crvHD.Name = "crvHD";
            this.crvHD.Size = new System.Drawing.Size(284, 261);
            this.crvHD.TabIndex = 0;
            // 
            // FromCrystal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.crvHD);
            this.Name = "FromCrystal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FromCrystal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvHD;
    }
}