#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System;
using System.Diagnostics;
using System.Windows.Forms;
using CefSharp;
using wyDay.Controls;

namespace SlackUI {

    internal class NotificationContext : ApplicationContext {

        #region Private Fields

        private NotifyIcon notifyIcon;

        #endregion

        #region Internal Constructors

        /*
         * Create a notification context with an icon and menu.
         */
        internal NotificationContext() {
            // Create a VistaMenu control to stylize context menus
            VistaMenu vistaMenu = new VistaMenu();

            // Create menu items for the notification icon context menu
            MenuItem menuItemShow = new MenuItem("Show " + Application.ProductName, menuItemShow_Click);
            MenuItem menuItemSettings = new MenuItem("Settings…", menuItemSettings_Click);
            MenuItem menuItemAbout = new MenuItem("About…", menuItemAbout_Click);
            MenuItem menuItemExit = new MenuItem("Exit", menuItemExit_Click);

            // Add icons to the notification icon context menu items
            vistaMenu.SetImage(menuItemSettings, Properties.Resources.MenuSettingsIcon);
            vistaMenu.SetImage(menuItemAbout, Properties.Resources.MenuAboutIcon);

            // Set the show menu entry as default (bold)
            menuItemShow.DefaultItem = true;

            // Add the menu items to the notify icon context menu
            ContextMenu contextMenuNotifyIcon = new ContextMenu(new MenuItem[] {
                menuItemShow,
                menuItemSettings,
                new MenuItem("-"),
                menuItemAbout,
                new MenuItem("-"),
                menuItemExit
            });

            // This needs to be called or the context menu will not have icons
            ((System.ComponentModel.ISupportInitialize)(vistaMenu)).EndInit();

            // Create a new instance of the notify icon
            notifyIcon = new NotifyIcon() {
                ContextMenu = contextMenuNotifyIcon,
                Icon = Program.Settings.Data.WhiteNotificationIcon ?
                    Properties.Resources.SlackUI16White : Properties.Resources.SlackUI16,
                Text = Application.ProductName,
                Visible = true,
            };

            // Assign a click and double click event handler for the notification icon
            notifyIcon.Click += notifyIcon_Click;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;

            // Show the wrapper form on startup?
            if(Program.Settings.Data.ShowOnStartup) {
                DisplayWrapperForm();
            }
        }

        #endregion

        #region Private Methods

        /*
         * Displays the wrapper form to the user.
         */
        private static void DisplayWrapperForm() {
            // Focus the wrapper form or display it to the user
            if(Program.WrapperForm.Visible) {
                // Restore normal window state if form is minimized
                if(Program.WrapperForm.WindowState == FormWindowState.Minimized) {
                    Program.WrapperForm.WindowState = FormWindowState.Normal;
                }

                // Activates the wrapper form and gives it focus
                Program.WrapperForm.Activate();
            } else {
                // Prompt for initial team domain to load or shows the wrapper form
                if(Program.Settings.Data.InitialTeamToLoad.Equals(String.Empty)) {
                    using(TeamPickerForm teamPickerForm = new TeamPickerForm()) {
                        if(teamPickerForm.ShowDialog() == DialogResult.OK) {
                            Program.Settings.Data.InitialTeamToLoad = teamPickerForm.SlackTeamDomain;
                            Program.WrapperForm.Show();
                        }
                    }
                } else {
                    // Displays the wrapper form to the user and gives it focus
                    Program.WrapperForm.Show();
                    Program.WrapperForm.Activate();
                }
            }
        }

        /*
         * Context menu open about form item click event handler.
         */
        private void menuItemAbout_Click(object sender, EventArgs e) {
            AboutForm aboutForm = Application.OpenForms["AboutForm"] as AboutForm;

            // Focus the about form if opened or create and show a new instance
            if(aboutForm != null) {
                aboutForm.Activate();
            } else {
                new AboutForm().Show();
            }
        }

        /*
         * Context menu exit item click event handler.
         */
        private void menuItemExit_Click(object sender, EventArgs e) {
            // Persist all application settings
            Program.Settings.Save();

            // Shuts down CefSharp and the underlying CEF infrastructure
            Cef.Shutdown();

            // Release all notify icon resources
            notifyIcon.Dispose();

            // Terminate the application
            Application.Exit();
        }

        /*
         * Context menu open settings location item click event handler.
         */
        private void menuItemSettings_Click(object sender, EventArgs e) {
            Process.Start(@Program.AppDataPath);
        }

        /*
         * Context menu show item click event handler.
         */
        private void menuItemShow_Click(object sender, EventArgs e) {
            DisplayWrapperForm();
        }

        /*
         * Notification icon single click event handler.
         */
        private void notifyIcon_Click(object sender, EventArgs e) {
            // Show the wrapper form only if single click is enabled
            if(Program.Settings.Data.ShowWithSingleClick) {
                DisplayWrapperForm();
            }
        }

        /*
         * Notification icon double click event handler.
         */
        private void notifyIcon_DoubleClick(object sender, EventArgs e) {
            // Show the wrapper form only if single click is disabled
            if(!Program.Settings.Data.ShowWithSingleClick) {
                DisplayWrapperForm();
            }
        }

        #endregion

    }

}
