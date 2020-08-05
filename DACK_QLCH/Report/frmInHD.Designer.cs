namespace DACK_QLCH.Report
{
    partial class frmInHD
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
            this.rptvInHD = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rptvInHD
            // 
            this.rptvInHD.ActiveViewIndex = -1;
            this.rptvInHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptvInHD.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptvInHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptvInHD.Location = new System.Drawing.Point(0, 0);
            this.rptvInHD.Name = "rptvInHD";
            this.rptvInHD.Size = new System.Drawing.Size(800, 450);
            this.rptvInHD.TabIndex = 0;
            // 
            // frmInHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptvInHD);
            this.Name = "frmInHD";
            this.Text = "frmInHD";
            this.Load += new System.EventHandler(this.frmInHD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptvInHD;
    }
}