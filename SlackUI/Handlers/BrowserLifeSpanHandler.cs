#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System.Diagnostics;
using CefSharp;

namespace SlackUI {

    internal class BrowserLifeSpanHandler : ILifeSpanHandler {

        #region Public Methods

        /*
         * Handler for the browser on before close event.
         */
        public void OnBeforeClose(IWebBrowser browser) {
            // No implementation required
        }

        /*
         * Handler for the browser on before popup event.
         */
        public bool OnBeforePopup(IWebBrowser browser, string url, ref int x, ref int y, ref int width,
            ref int height) {
            // Launch the default system browser for any popup link outside of team domain
            if(!url.Contains(Program.ActiveTeamAddress)) {
                Process.Start(url);
                return true;
            }

            // Let the Chromium web browser handle the event
            return false;
        }

        #endregion

    }

}
