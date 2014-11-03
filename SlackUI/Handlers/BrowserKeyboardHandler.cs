#region Copyright © 2014 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System.Windows.Forms;
using CefSharp;

namespace SlackUI {

    internal class BrowserKeyboardHandler : IKeyboardHandler {

        #region Public Methods

        /*
         * Handler for the browser on key event.
         */
        public bool OnKeyEvent(IWebBrowser browser, KeyType type, int code, int modifiers, bool isSystemKey) {
            // Let the Chromium web browser handle the key event
            return false;
        }

        /*
         * Handler for the browser on pre key event.
         */
        public bool OnPreKeyEvent(IWebBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, int modifiers, bool isSystemKey, bool isKeyboardShortcut) {
            // Disable the keyboard backspace key
            if(windowsKeyCode == (int)Keys.Back) {
                return true;
            }

            // Let the Chromium web browser handle the pre key event
            return false;
        }

        #endregion

    }

}
