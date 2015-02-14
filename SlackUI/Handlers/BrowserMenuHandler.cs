#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using CefSharp;

namespace SlackUI {

    internal class BrowserMenuHandler : IMenuHandler {

        #region Public Methods

        /*
         * Handler for the browser on before context menu event.
         */
        public bool OnBeforeContextMenu(IWebBrowser browser) {
            // Disable the context menu
            return false;
        }

        #endregion

    }

}
