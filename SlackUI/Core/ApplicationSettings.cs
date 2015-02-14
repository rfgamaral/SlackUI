#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using RA.Library.EasySettings;

namespace SlackUI {

    internal class ApplicationSettings {

        #region Private Fields

        private const string StartupRegistryKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";

        private readonly static string StartupRegistryName = Application.ProductName;

        private bool startWithWindows;
        private Point windowLocation;
        private Size windowSize;
        private FormWindowState windowState;

        #endregion

        #region Internal Properties

        /*
         * The initial team domain to load on startup.
         */
        [EasySettingsAttribute("General", "")]
        internal string InitialTeamToLoad {
            get;
            set;
        }

        /*
         * Show the application on startup.
         */
        [EasySettingsAttribute("UserInterface", false)]
        internal bool ShowOnStartup {
            get;
            set;
        }

        /*
         * Show the application with a single click on the notification icon.
         */
        [EasySettingsAttribute("UserInterface", false)]
        internal bool ShowWithSingleClick {
            get;
            set;
        }

        /*
         * Start the application when windows is started.
         */
        [EasySettingsAttribute("General", false)]
        internal bool StartWithWindows {
            get {
                return startWithWindows;
            }

            set {
                startWithWindows = value;

                // Gets the specified startup sub-key with write access
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(StartupRegistryKey, true);

                // Add or delete the startup value to the registry?
                if(startWithWindows) {
#if !DEBUG
                    registryKey.SetValue(StartupRegistryName, Application.ExecutablePath, RegistryValueKind.String);
#endif
                } else {
                    if(registryKey.GetValue(StartupRegistryName) != null) {
#if !DEBUG
                        registryKey.DeleteValue(StartupRegistryName);
#endif
                    }
                }
            }
        }

        /*
         * Use the alternative white notification icon.
         */
        [EasySettingsAttribute("Appearance", false)]
        internal bool WhiteNotificationIcon {
            get;
            set;
        }

        /*
         * Wrapper form window location to restore window properties.
         */
        [EasySettingsAttribute("WrapperForm", null)]
        internal Point WindowLocation {
            get {
                return windowLocation;
            }

            set {
                windowLocation = value;

                // Set the wrapper form window location
                Program.WrapperForm.Location = windowLocation;
            }
        }

        /*
         * Wrapper form window size to restore window properties.
         */
        [EasySettingsAttribute("WrapperForm", null)]
        internal Size WindowSize {
            get {
                return windowSize;
            }

            set {
                windowSize = value;

                // Prevent the window width be less than the minimum allowed
                if(Program.WrapperForm.MinimumSize.Width > windowSize.Width) {
                    windowSize = new Size(Program.WrapperForm.MinimumSize.Width, windowSize.Height);
                }

                // Prevent the window height be less than the minimum allowed
                if(Program.WrapperForm.MinimumSize.Height > windowSize.Height) {
                    windowSize = new Size(windowSize.Width, Program.WrapperForm.MinimumSize.Height);
                }

                // Set the wrapper form window size
                Program.WrapperForm.Size = windowSize;
            }
        }

        /*
         * Wrapper form window state to restore window properties.
         */
        [EasySettingsAttribute("WrapperForm", typeof(FormWindowState), FormWindowState.Normal)]
        internal FormWindowState WindowState {
            get {
                // Prevent the window state to be minimized
                return (windowState == FormWindowState.Minimized ? FormWindowState.Normal : windowState);
            }

            set {
                windowState = value;

                // Set the wrapper form window state
                Program.WrapperForm.WindowState = windowState;
            }
        }

        #endregion

        #region Internal Classes

        internal static class Defaults {

            #region Private Properties

            /*
             * Wrapper form window location default dynamic value.
             */
            private static Point WindowLocation {
                get {
                    // Find the middle point in the primary monitor resolution
                    int hMiddlePoint = SystemInformation.WorkingArea.Width / 2;
                    int vMiddlePoint = SystemInformation.WorkingArea.Height / 2;

                    // Return the centered wrapper form window
                    return new Point(
                        hMiddlePoint - (Program.WrapperForm.Size.Width / 2),
                        vMiddlePoint - (Program.WrapperForm.Size.Height / 2)
                    );
                }
            }

            /*
             * Wrapper form window size default dynamic value.
             */
            private static Size WindowSize {
                get {
                    return Program.WrapperForm.Size;
                }
            }

            #endregion

        }

        #endregion

    }

}
