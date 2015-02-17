namespace SlackUI {
    partial class AboutForm {
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.aboutLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.applicationVersionLabel = new System.Windows.Forms.Label();
            this.applicationNameLabel = new System.Windows.Forms.Label();
            this.applicationDescriptionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.openSourceLabel = new SlackUI.LinkLabelEx();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.homepageLabel = new System.Windows.Forms.LinkLabel();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aboutLogoPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.aboutLogoPictureBox);
            this.headerPanel.Controls.Add(this.applicationVersionLabel);
            this.headerPanel.Controls.Add(this.applicationNameLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(404, 64);
            this.headerPanel.TabIndex = 0;
            this.headerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.headerPanel_Paint);
            // 
            // aboutLogoPictureBox
            // 
            this.aboutLogoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.aboutLogoPictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.aboutLogoPictureBox.Image = global::SlackUI.Properties.Resources.AboutLogo;
            this.aboutLogoPictureBox.Location = new System.Drawing.Point(340, 0);
            this.aboutLogoPictureBox.Name = "aboutLogoPictureBox";
            this.aboutLogoPictureBox.Size = new System.Drawing.Size(64, 64);
            this.aboutLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.aboutLogoPictureBox.TabIndex = 1;
            this.aboutLogoPictureBox.TabStop = false;
            // 
            // applicationVersionLabel
            // 
            this.applicationVersionLabel.AutoSize = true;
            this.applicationVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.applicationVersionLabel.Location = new System.Drawing.Point(13, 33);
            this.applicationVersionLabel.Name = "applicationVersionLabel";
            this.applicationVersionLabel.Size = new System.Drawing.Size(59, 13);
            this.applicationVersionLabel.TabIndex = 1;
            this.applicationVersionLabel.Text = "Version {0}";
            // 
            // applicationNameLabel
            // 
            this.applicationNameLabel.AutoSize = true;
            this.applicationNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationNameLabel.Location = new System.Drawing.Point(12, 9);
            this.applicationNameLabel.Name = "applicationNameLabel";
            this.applicationNameLabel.Size = new System.Drawing.Size(175, 24);
            this.applicationNameLabel.TabIndex = 0;
            this.applicationNameLabel.Text = "Application Name";
            // 
            // applicationDescriptionLabel
            // 
            this.applicationDescriptionLabel.AutoSize = true;
            this.applicationDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.applicationDescriptionLabel.Location = new System.Drawing.Point(15, 12);
            this.applicationDescriptionLabel.Name = "applicationDescriptionLabel";
            this.applicationDescriptionLabel.Size = new System.Drawing.Size(374, 13);
            this.applicationDescriptionLabel.TabIndex = 1;
            this.applicationDescriptionLabel.Text = "Application Description";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.applicationDescriptionLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.openSourceLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.copyrightLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.homepageLabel, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(12);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(404, 137);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // openSourceLabel
            // 
            this.openSourceLabel.AutoSize = true;
            this.openSourceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openSourceLabel.Location = new System.Drawing.Point(15, 28);
            this.openSourceLabel.Name = "openSourceLabel";
            this.openSourceLabel.Size = new System.Drawing.Size(374, 13);
            this.openSourceLabel.TabIndex = 4;
            this.openSourceLabel.TabStop = true;
            this.openSourceLabel.Text = "{0} is open-source software, feel free to contribute on GitHub.";
            this.openSourceLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.anyLabel_LinkClicked);
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyrightLabel.Location = new System.Drawing.Point(15, 99);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(374, 13);
            this.copyrightLabel.TabIndex = 5;
            this.copyrightLabel.Text = "Application Copyright";
            this.copyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // homepageLabel
            // 
            this.homepageLabel.AutoSize = true;
            this.homepageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homepageLabel.Location = new System.Drawing.Point(15, 112);
            this.homepageLabel.Name = "homepageLabel";
            this.homepageLabel.Size = new System.Drawing.Size(374, 13);
            this.homepageLabel.TabIndex = 6;
            this.homepageLabel.TabStop = true;
            this.homepageLabel.Text = "http://ricardoamaral.net";
            this.homepageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.homepageLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.anyLabel_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 201);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About {0}";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aboutLogoPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label applicationNameLabel;
        private System.Windows.Forms.Label applicationVersionLabel;
        private System.Windows.Forms.PictureBox aboutLogoPictureBox;
        private System.Windows.Forms.Label applicationDescriptionLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SlackUI.LinkLabelEx openSourceLabel;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.LinkLabel homepageLabel;
    }
}