namespace SlackUI {
    partial class TeamPickerForm {
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
            this.teamGroupBox = new System.Windows.Forms.GroupBox();
            this.teamDomainTextBox = new System.Windows.Forms.TextBox();
            this.continueButton = new System.Windows.Forms.Button();
            this.slackDomainLabel = new System.Windows.Forms.Label();
            this.teamGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // teamGroupBox
            // 
            this.teamGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teamGroupBox.Controls.Add(this.teamDomainTextBox);
            this.teamGroupBox.Controls.Add(this.continueButton);
            this.teamGroupBox.Controls.Add(this.slackDomainLabel);
            this.teamGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamGroupBox.Location = new System.Drawing.Point(12, 12);
            this.teamGroupBox.Name = "teamGroupBox";
            this.teamGroupBox.Size = new System.Drawing.Size(331, 137);
            this.teamGroupBox.TabIndex = 0;
            this.teamGroupBox.TabStop = false;
            this.teamGroupBox.Text = "Enter your team\'s Slack domain:";
            // 
            // teamDomainTextBox
            // 
            this.teamDomainTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamDomainTextBox.Location = new System.Drawing.Point(11, 34);
            this.teamDomainTextBox.Margin = new System.Windows.Forms.Padding(8, 12, 0, 3);
            this.teamDomainTextBox.MaxLength = 63;
            this.teamDomainTextBox.Name = "teamDomainTextBox";
            this.teamDomainTextBox.Size = new System.Drawing.Size(200, 38);
            this.teamDomainTextBox.TabIndex = 0;
            this.teamDomainTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.teamDomainTextBox.TextChanged += new System.EventHandler(this.teamTextBox_TextChanged);
            this.teamDomainTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teamTextBox_KeyPress);
            // 
            // continueButton
            // 
            this.continueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.continueButton.Enabled = false;
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(10, 83);
            this.continueButton.Margin = new System.Windows.Forms.Padding(3, 8, 7, 7);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(311, 44);
            this.continueButton.TabIndex = 2;
            this.continueButton.Text = "Continue ▶";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // slackDomainLabel
            // 
            this.slackDomainLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slackDomainLabel.Location = new System.Drawing.Point(214, 34);
            this.slackDomainLabel.Name = "slackDomainLabel";
            this.slackDomainLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.slackDomainLabel.Size = new System.Drawing.Size(107, 38);
            this.slackDomainLabel.TabIndex = 1;
            this.slackDomainLabel.Text = ".slack.com";
            this.slackDomainLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TeamPickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 161);
            this.Controls.Add(this.teamGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeamPickerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign In";
            this.Shown += new System.EventHandler(this.TeamPickerForm_Shown);
            this.teamGroupBox.ResumeLayout(false);
            this.teamGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox teamGroupBox;
        private System.Windows.Forms.Label slackDomainLabel;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.TextBox teamDomainTextBox;

    }
}