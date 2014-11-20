#region Copyright © 2014 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using CefSharp;

namespace SlackUI {

    internal class BrowserRequestHandler : IRequestHandler {

        #region Public Methods

        public bool GetAuthCredentials(IWebBrowser browser, bool isProxy, string host, int port, string realm,
            string scheme, ref string username, ref string password) {
            // Let the Chromium web browser handle the event
            return false;
        }

        public ResourceHandler GetResourceHandler(IWebBrowser browser, IRequest request) {
            // Let the Chromium web browser handle the event
            return null;
        }

        public bool OnBeforeBrowse(IWebBrowser browser, IRequest request, bool isRedirect) {
            // Disable browser forward/back navigation with keyboard keys
            if((request.TransitionType & TransitionType.ForwardBack) != 0) {
                return true;
            }

            // Let the Chromium web browser handle the event
            return false;
        }

        public bool OnBeforePluginLoad(IWebBrowser browser, string url, string policyUrl, IWebPluginInfo info) {
            // Let the Chromium web browser handle the event
            return false;
        }

        public bool OnBeforeResourceLoad(IWebBrowser browser, IRequest request, IResponse response) {
            // Let the Chromium web browser handle the event
            return false;
        }

        public void OnPluginCrashed(IWebBrowser browser, string pluginPath) {
            // No implementation required
        }

        public void OnRenderProcessTerminated(IWebBrowser browser, CefTerminationStatus status) {
            // No implementation required
        }

        #endregion

    }

}
