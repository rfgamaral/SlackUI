namespace SlackUI {
    partial class WrapperForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.browserPanel = new System.Windows.Forms.Panel();
            this.browserLoadOverlay = new System.Windows.Forms.Panel();
            this.loadingMarquee = new System.Windows.Forms.ProgressBar();
            this.browserPanel.SuspendLayout();
            this.browserLoadOverlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // browserPanel
            // 
            this.browserPanel.BackColor = System.Drawing.Color.White;
            this.browserPanel.Controls.Add(this.browserLoadOverlay);
            this.browserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserPanel.Location = new System.Drawing.Point(0, 0);
            this.browserPanel.Name = "browserPanel";
            this.browserPanel.Size = new System.Drawing.Size(944, 596);
            this.browserPanel.TabIndex = 0;
            // 
            // browserLoadOverlay
            // 
            this.browserLoadOverlay.BackgroundImage = global::SlackUI.Properties.Resources.PanelBackground;
            this.browserLoadOverlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.browserLoadOverlay.Controls.Add(this.loadingMarquee);
            this.browserLoadOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserLoadOverlay.Location = new System.Drawing.Point(0, 0);
            this.browserLoadOverlay.Name = "browserLoadOverlay";
            this.browserLoadOverlay.Size = new System.Drawing.Size(944, 596);
            this.browserLoadOverlay.TabIndex = 0;
            // 
            // loadingMarquee
            // 
            this.loadingMarquee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingMarquee.Location = new System.Drawing.Point(12, 569);
            this.loadingMarquee.MarqueeAnimationSpeed = 5;
            this.loadingMarquee.Name = "loadingMarquee";
            this.loadingMarquee.Size = new System.Drawing.Size(920, 15);
            this.loadingMarquee.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.loadingMarquee.TabIndex = 0;
            // 
            // WrapperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 596);
            this.Controls.Add(this.browserPanel);
            this.MinimumSize = new System.Drawing.Size(960, 635);
            this.Name = "WrapperForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SlackUI";
            this.Activated += new System.EventHandler(this.WrapperForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WrapperForm_FormClosing);
            this.browserPanel.ResumeLayout(false);
            this.browserLoadOverlay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel browserPanel;
        private System.Windows.Forms.Panel browserLoadOverlay;
        private System.Windows.Forms.ProgressBar loadingMarquee;

    }
}

