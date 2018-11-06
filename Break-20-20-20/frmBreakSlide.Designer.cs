namespace Break_20_20_20
{
    partial class frmBreakSlide
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
            this.components = new System.ComponentModel.Container();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.lblCounter = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.FormLoadTimer = new System.Windows.Forms.Timer(this.components);
            this.progressBarTimer = new System.Windows.Forms.Timer(this.components);
            this.secondCountTimer = new System.Windows.Forms.Timer(this.components);
            this.MainTimeWatcher = new System.Windows.Forms.Timer(this.components);
            this.fadeLblMsg = new Break_20_20_20.FadeLabel();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.fadeLblMsg);
            this.controlPanel.Controls.Add(this.lblCounter);
            this.controlPanel.Controls.Add(this.progressBar1);
            this.controlPanel.Location = new System.Drawing.Point(12, 12);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(1041, 662);
            this.controlPanel.TabIndex = 3;
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCounter.Location = new System.Drawing.Point(488, 55);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(64, 36);
            this.lblCounter.TabIndex = 4;
            this.lblCounter.Text = "60s";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.progressBar1.Location = new System.Drawing.Point(163, 104);
            this.progressBar1.Maximum = 540;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(714, 11);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Value = 540;
            // 
            // FormLoadTimer
            // 
            this.FormLoadTimer.Tick += new System.EventHandler(this.FormLoadTimer_Tick);
            // 
            // progressBarTimer
            // 
            this.progressBarTimer.Tick += new System.EventHandler(this.progressBarTimer_Tick);
            // 
            // secondCountTimer
            // 
            this.secondCountTimer.Interval = 1000;
            this.secondCountTimer.Tick += new System.EventHandler(this.secondCountTimer_Tick);
            // 
            // MainTimeWatcher
            // 
            this.MainTimeWatcher.Enabled = true;
            this.MainTimeWatcher.Interval = 1200000;
            this.MainTimeWatcher.Tick += new System.EventHandler(this.MainTimeWatcher_Tick);
            // 
            // fadeLblMsg
            // 
            this.fadeLblMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fadeLblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fadeLblMsg.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fadeLblMsg.Location = new System.Drawing.Point(163, 250);
            this.fadeLblMsg.Name = "fadeLblMsg";
            this.fadeLblMsg.Size = new System.Drawing.Size(714, 163);
            this.fadeLblMsg.TabIndex = 5;
            this.fadeLblMsg.Text = "20-20-20 Rule";
            this.fadeLblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmBreakSlide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1065, 686);
            this.ControlBox = false;
            this.Controls.Add(this.controlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBreakSlide";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBreakSlide_Load);
            this.ResizeEnd += new System.EventHandler(this.frmBreakSlide_ResizeEnd);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmBreakSlide_KeyPress);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer FormLoadTimer;
        private System.Windows.Forms.Timer progressBarTimer;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Timer secondCountTimer;
        private System.Windows.Forms.Timer MainTimeWatcher;
        private FadeLabel fadeLblMsg;
    }
}

