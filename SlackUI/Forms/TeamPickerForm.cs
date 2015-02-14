#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace SlackUI {

    [System.ComponentModel.DesignerCategory("Form")]
    internal partial class TeamPickerForm : BaseForm {

        #region Internal Properties

        /*
         * Slack team domain typed by the user.
         */
        internal string SlackTeamDomain {
            get;
            private set;
        }

        #endregion

        #region Private Fields

        private const string FindYourTeamUrl = "http://slack.com/signin/find";

        #endregion

        #region Public Constructors

        /*
         * Create a team picker form to pick and validate a new team domain.
         */
        internal TeamPickerForm() {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        /*
         * Continue button click event handler.
         */
        private void continueButton_Click(object sender, EventArgs e) {
            // Save team domain if valid otherwise show team not found information dialog
            if(IsTeamDomainValid()) {
                SlackTeamDomain = teamDomainTextBox.Text.ToLowerInvariant();
                DialogResult = DialogResult.OK;
                Close();
            } else {
                TaskDialog noTeamDialog = new TaskDialog() {
                    Caption = Application.ProductName,
                    HyperlinksEnabled = true,
                    Icon = TaskDialogStandardIcon.Information,
                    InstructionText = "We couldn't find your team.",
                    OwnerWindowHandle = Handle,
                    StandardButtons = TaskDialogStandardButtons.Ok,
                    Text = "If you can't remember your team's address, Slack can <a href=\"#\">send you a reminder</a>."
                };

                noTeamDialog.HyperlinkClick += delegate { Process.Start(FindYourTeamUrl); };

                // Workaround for a bug in the Windows TaskDialog API
                noTeamDialog.Opened += (td, ev) => {
                    TaskDialog taskDialog = td as TaskDialog;
                    taskDialog.Icon = noTeamDialog.Icon;
                    taskDialog.InstructionText = noTeamDialog.InstructionText;
                };

                noTeamDialog.Show();
            }
        }

        /*
         * Check if the picked team domain is valid (if it exists).
         */
        private bool IsTeamDomainValid() {
            HttpStatusCode statusCode = default(HttpStatusCode);

            // Create HEAD request for the picked team domain
            WebRequest request = HttpWebRequest.Create(String.Format(Program.SlackTeamUrl, teamDomainTextBox.Text));
            request.Method = "HEAD";

            // Change the form state to "wait mode"
            Cursor.Current = Cursors.WaitCursor;
            teamGroupBox.Enabled = false;

            // Make the request and get the response status code
            try {
                using(HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
                    if(response != null) {
                        statusCode = response.StatusCode;
                    }
                }
            } catch(WebException ex) {
                using(HttpWebResponse response = ex.Response as HttpWebResponse) {
                    if(response != null) {
                        statusCode = response.StatusCode;
                    }
                }
            }

            // Change the form state to "default mode"
            Cursor.Current = Cursors.Default;
            teamGroupBox.Enabled = true;

            // Return true if team domain was found or false otherwise
            return statusCode == HttpStatusCode.OK;
        }

        /*
         * Team picker form shown event handler.
         */
        private void TeamPickerForm_Shown(object sender, EventArgs e) {
            // Make sure the form is focused when shown
            Activate();
        }

        /*
         * Team text box key press event handler.
         */
        private void teamTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
            // Virtually click the continue button if the return key was pressed
            if(e.KeyChar == Convert.ToChar(Keys.Return, CultureInfo.InvariantCulture) && teamDomainTextBox.TextLength > 0) {
                continueButton_Click(sender, null);
                e.Handled = true;
                return;
            }

            // Ignore the key press if it's an invalid character
            if(!Char.IsControl(e.KeyChar) && !Regex.Match(e.KeyChar.ToString(), @"[a-z0-9\-]",
                RegexOptions.IgnoreCase).Success) {
                e.Handled = true;
            }
        }

        /*
         * Team text box text changed event handler.
         */
        private void teamTextBox_TextChanged(object sender, System.EventArgs e) {
            // Validate the team text input and enable/disable the continue button accordingly
            continueButton.Enabled = !(teamDomainTextBox.Text.Equals(String.Empty)) && Regex.Match(teamDomainTextBox.Text,
                @"^[a-z0-9]([a-z0-9\-]*[a-z0-9]|[a-z0-9])?$", RegexOptions.IgnoreCase).Success;
        }

        #endregion

    }

}
