#region Copyright © 2014 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using CefSharp;

namespace SlackUI {

    internal class BrowserMenuHandler : IMenuHandler {

        #region Internal Methods

        /*
         * Handler for the browser context menu.
         */
        public bool OnBeforeContextMenu(IWebBrowser browser) {
            // Disable the context menu
            return false;
        }

        #endregion

    }

}
