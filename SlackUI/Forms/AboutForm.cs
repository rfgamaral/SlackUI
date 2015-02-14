#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace SlackUI {

    [System.ComponentModel.DesignerCategory("Form")]
    internal partial class AboutForm : BaseForm {

        #region Private Fields

        private const string GitHubLink = "https://github.com/rfgamaral/SlackUI";
        private const string GitHubLinkText = "GitHub";
        private const string HomepageLink = "http://ricardoamaral.net";

        #endregion Private Fields

        #region Public Properties

        /*
         * Get the executing assembly copyright attribute.
         */
        public string AssemblyCopyright {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(AssemblyCopyrightAttribute), false);
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        /*
         * Get the executing assembly description attribute.
         */
        public string AssemblyDescription {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(AssemblyDescriptionAttribute), false);
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        #endregion

        #region Public Constructors

        /*
         * Create an about form with application information.
         */
        public AboutForm() {
            InitializeComponent();

            // Format the form title with the application name
            Text = String.Format(Text, Application.ProductName);

            // Fill application name, version, description and copyright labels
            applicationNameLabel.Text = Application.ProductName;
            applicationVersionLabel.Text = String.Format(applicationVersionLabel.Text, Application.ProductVersion);
            applicationDescriptionLabel.Text = AssemblyDescription;
            copyrightLabel.Text = AssemblyCopyright;

            // Fill open-source and homepage labels with clickable links
            openSourceLabel.Text = String.Format(openSourceLabel.Text, Application.ProductName);
            openSourceLabel.Links.Add(openSourceLabel.Text.IndexOf(GitHubLinkText), GitHubLinkText.Length,
                GitHubLink).Enabled = true;
            homepageLabel.Links.Add(0, HomepageLink.Length, HomepageLink);
        }

        #endregion

        #region Private Methods

        /*
         * Any label link clicked event handler.
         */
        private void anyLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(e.Link.LinkData.ToString());
        }

        /*
         * Header panel paint event handler.
         */
        private void headerPanel_Paint(object sender, PaintEventArgs e) {
            ControlPaint.DrawBorder3D(e.Graphics, headerPanel.ClientRectangle, Border3DStyle.Etched, Border3DSide.Bottom);
        }

        #endregion

    }

}
