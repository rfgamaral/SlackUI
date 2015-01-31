#region Copyright © 2014 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp;
using CefSharp.WinForms;


namespace SlackUI {

    [System.ComponentModel.DesignerCategory("Form")]
    internal partial class WrapperForm : BaseForm {

        #region Private Fields

        private const string AboutBlankPage = "about:blank";

        private const uint SYSMENU_DEVTOOLS_ID = 0x1;

        private readonly ChromiumWebBrowser chromium;

        private FormWindowState previousWindowState;

        private readonly Timer timer;

        #endregion

        #region Public Constructors

        /*
         * Create a wrapper form around the chromium web browser.
         */
        public WrapperForm() {
            InitializeComponent();

            // Initializes a new instance of the chromium web browser
            chromium = new ChromiumWebBrowser(AboutBlankPage) {
                Dock = DockStyle.Fill,
                MenuHandler = new BrowserMenuHandler(),
                LifeSpanHandler = new BrowserLifeSpanHandler(),
                ResourceHandler = new BrowserResourceHandler(),
                RequestHandler = new BrowserRequestHandler()
            };

            timer = new Timer {Interval = 1000, Enabled = true};
            timer.Tick += timer_Tick;
            timer.Start();
            

            // Subscribe to multiple chromium web browser events
            chromium.FrameLoadEnd += chromium_FrameLoadEnd;
            chromium.NavStateChanged += chromium_NavStateChanged;

            // Add the chromium web browser to the browser panel
            browserPanel.Controls.Add(chromium);

            // Save the current window state as the previous one
            previousWindowState = WindowState;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            const string js = "(function() { var xx = 0; $('.unread_highlight,.unread_just').each(function(x, e) { xx += + $(e).text(); }); return xx; })()";
            try
            {
                Task<JavascriptResponse> task = chromium.EvaluateScriptAsync(js);
                if (task == null)
                {
                    return;
                }
                task.ContinueWith(t =>
                {
                    if (!t.IsFaulted)
                    {
                        var response = t.Result;
                        if (response.Success && response.Result is int)
                        {
                            UpdateIcon((int)response.Result);
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch
            {
            }
        }

        private int currentCount;
        private void UpdateIcon(int count)
        {
            if (count > currentCount)
            {
                if (Visible)
                {
                    FlashWindow();
                }
                else
                {
                    NotificationContext.Instance.DisplayBalloon(string.Format("You have {0} unread message(s)\r\nClick here to open the main window", count));        
                }
            }

            if (count != currentCount)
            {
                currentCount = count;
                Icon = count > 0 ? Properties.Resources.SlackUI_Unread : Properties.Resources.SlackUI;
                Text = count > 0 ? string.Format("SlackUI [{0} Unread]", count) : "SlackUI";
            }
        }

        #endregion

        #region Private Methods

        /*
         * Chromium web browser frame load end event handler.
         */
        private void chromium_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e) {
            // Was the loaded page the first page load?
            if(!e.Url.Contains(AboutBlankPage)) {
                // Remove the initial load overlay from the form
                this.InvokeOnUiThreadIfRequired(() => {
                    browserPanel.Controls.RemoveByKey("initialLoadOverlay");
                });

                // Unsubscribe the frame load end event
                chromium.FrameLoadEnd -= chromium_FrameLoadEnd;
            }
        }

        /*
         * Chromium web browser navigation state changed event handler.
         */
        private void chromium_NavStateChanged(object sender, CefSharp.NavStateChangedEventArgs e) {
            // Is the browser ready to load a page as the first page load?
            if(!e.CanGoBack && !e.CanGoForward && e.CanReload) {
                // Load the active team domain address
                chromium.Load(Program.ActiveTeamAddress);

                // Unsubscribe the navigation state changed event
                chromium.NavStateChanged -= chromium_NavStateChanged;
            }
        }

        /*
         * Save the wrapper form window location, size and state settings.
         */
        private void SaveWindowProperties() {
            // Update the wrapper form window state setting
            Program.Settings.Data.WindowState = WindowState;

            // Update the wrapper form window location and size settings
            if(WindowState == FormWindowState.Normal) {
                Program.Settings.Data.WindowLocation = Location;
                Program.Settings.Data.WindowSize = Size;
            } else {
                Program.Settings.Data.WindowLocation = RestoreBounds.Location;
                Program.Settings.Data.WindowSize = RestoreBounds.Size;
            }

            // Persist new application settings
            Program.Settings.Save();
        }

        /*
         * Wrapper form closing event handler.
         */
        private void WrapperForm_FormClosing(object sender, FormClosingEventArgs e) {
            // Release all chromium web browser resources
            if(e.CloseReason == CloseReason.ApplicationExitCall) {
                if(chromium != null) {
                    chromium.Dispose();
                }
            }

            // Hide instead of close if the user is closing the form
            if(e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        #endregion

        #region Protected Methods

        /*
         * Handler for the overridden on handle created event.
         */
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);

            // Get this form's system menu handler
            IntPtr systemMenu = NativeMethods.GetSystemMenu(Handle, false);

            // Add a separator followed by the DevTools menu item
            NativeMethods.AppendMenu(systemMenu, NativeMethods.MenuFlags.MF_SEPARATOR, UIntPtr.Zero, String.Empty);
            NativeMethods.AppendMenu(systemMenu, NativeMethods.MenuFlags.MF_STRING, new UIntPtr(SYSMENU_DEVTOOLS_ID),
                "&Show DevTools…");
        }

        /*
         *  Handler for the overridden Windows messages processor.
         */
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);

            // Handles detected Windows messages
            switch(m.Msg) {
                // Show DevTools if the respective item was selected from the system menu
                case (int)NativeMethods.WindowsMessages.WM_SYSCOMMAND:
                    if((int)m.WParam == SYSMENU_DEVTOOLS_ID) {
                        chromium.ShowDevTools();
                    }

                    break;

                // Save the wrapper form window location, size and state
                case (int)NativeMethods.WindowsMessages.WM_EXITSIZEMOVE:
                    SaveWindowProperties();
                    break;

                // Save the wrapper form window location, size and state
                case (int)NativeMethods.WindowsMessages.WM_SIZE:
                    if(previousWindowState != WindowState) {
                        previousWindowState = WindowState;
                        SaveWindowProperties();
                    }

                    break;
            }
        }

        #endregion

    }

}
