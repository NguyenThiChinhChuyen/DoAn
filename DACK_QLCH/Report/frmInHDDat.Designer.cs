namespace DACK_QLCH.Report
{
    partial class frmInHDDAT
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
            this.rptvInHDDAT = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rptvInHDDAT
            // 
            this.rptvInHDDAT.ActiveViewIndex = -1;
            this.rptvInHDDAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptvInHDDAT.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptvInHDDAT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptvInHDDAT.Location = new System.Drawing.Point(0, 0);
            this.rptvInHDDAT.Name = "rptvInHDDAT";
            this.rptvInHDDAT.Size = new System.Drawing.Size(800, 450);
            this.rptvInHDDAT.TabIndex = 0;
            this.rptvInHDDAT.Load += new System.EventHandler(this.rptvInHDDAT_Load);
            // 
            // frmInHDDAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptvInHDDAT);
            this.Name = "frmInHDDAT";
            this.Text = "In Hóa Đơn Đặt";
            this.Load += new System.EventHandler(this.frmInHDDAT_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptvInHDDAT;
    }
}