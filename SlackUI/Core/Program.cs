#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using RA.Library.EasySettings;

namespace SlackUI {

    internal static class Program {

        #region Internal Fields

        internal const string SlackTeamUrl = "https://{0}.slack.com";

        #endregion

        #region Private Fields

        private const string BrowserSubprocessFileName = "CefSharp.BrowserSubprocess.exe";
        private const string CacheFolderName = "Cache";
        private const string CookiesFolderName = "Cookies";
        private const string LogFileName = "Chromium.log";
        private const string SettingsFileName = "settings.xml";

        #endregion

        #region Internal Properties

        /*
         * Active team domain address.
         */
        internal static string ActiveTeamAddress {
            get { return String.Format(SlackTeamUrl, Settings.Data.InitialTeamToLoad); }
        }

        /*
         * Full path for the application data folder.
         */
        internal static string AppDataPath {
            get;
            private set;
        }

        /*
         * EasySettings instance to manage application settings.
         */
        internal static EasySettings<ApplicationSettings> Settings {
            get;
            private set;
        }

        /*
         * Single wrapper form instance for easy access.
         */
        internal static WrapperForm WrapperForm {
            get;
            private set;
        }

        #endregion

        #region Main Entry Point

        /*
         * The main entry point for the SlackUI application.
         */
        [STAThread]
        private static void Main() {
            // Enable visual styles and better text rendering
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            // Get the default local application data path
            AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            AppDataPath = Path.Combine(AppDataPath, Application.ProductName);

            #region --------------------[ DEBUG MODE BLOCK ]--------------------

#if DEBUG
            // Use a proper application data folder for debug mode
            AppDataPath = Path.Combine(AppDataPath, "[DEBUG]");
#endif

            #endregion

            // Create the application data folder if it doesn't exist
            if(!Directory.Exists(AppDataPath)) {
                Directory.CreateDirectory(AppDataPath);
            }

            // Initializes CefSharp with the default settings
            Cef.Initialize(new CefSettings {
                BrowserSubprocessPath = BrowserSubprocessFileName,
                CachePath = Path.Combine(AppDataPath, CacheFolderName),
                LogFile = Path.Combine(AppDataPath, LogFileName)
            });

            // Separate cookies storage location from the cache
            Cef.SetCookiePath(Path.Combine(AppDataPath, CookiesFolderName), false);

            // Initialize a new instance of the wrapper form
            WrapperForm = new WrapperForm();

            // Initialize a new instance of the Easy Settings class
            Settings = new EasySettings<ApplicationSettings>(Path.Combine(AppDataPath, SettingsFileName), "Settings");

            // Run the application with a notification context
            Application.Run(new NotificationContext());
        }

        #endregion

    }

}
