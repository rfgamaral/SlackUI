#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System.Linq;
using CefSharp;

namespace SlackUI {

    internal class BrowserRequestHandler : IRequestHandler {

        #region Private Fields

        private const string SignInUrl = "https://slack.com/signin";

        private readonly string[] InternalLinkKeywords = { "chrome-devtools" };

        #endregion

        #region Public Methods

        /*
         * Handler for the browser get authentication credentials event.
         */
        public bool GetAuthCredentials(IWebBrowser browser, bool isProxy, string host, int port, string realm,
            string scheme, ref string username, ref string password) {
            // Let the Chromium web browser handle the event
            return false;
        }

        /*
         * Handler for the browser on before browse event.
         */
        public bool OnBeforeBrowse(IWebBrowser browser, IRequest request, bool isRedirect) {
            // Disable browser forward/back navigation with keyboard keys
            if((request.TransitionType & TransitionType.ForwardBack) != 0) {
                return true;
            }

            // Let the Chromium web browser handle any internal link
            if(InternalLinkKeywords.Any(request.Url.Contains)) {
                return false;
            }

            // Load the active team address instead of the default sign-in page
            if(request.Url.Equals(SignInUrl)) {
                browser.Load(Program.ActiveTeamAddress);
                return true;
            }

            // Let the Chromium web browser handle the event
            return false;
        }

        /*
         * Handler for the browser on before plugin load event.
         */
        public bool OnBeforePluginLoad(IWebBrowser browser, string url, string policyUrl, IWebPluginInfo info) {
            // Let the Chromium web browser handle the event
            return false;
        }

        /*
         * Handler for the browser on before resource load event.
         */
        public bool OnBeforeResourceLoad(IWebBrowser browser, IRequest request, IResponse response) {
            // Let the Chromium web browser handle the event
            return false;
        }

        /*
         * Handler for the on certificate error event.
         */
        public bool OnCertificateError(IWebBrowser browser, CefErrorCode errorCode, string requestUrl) {
            // Let the Chromium web browser handle the event
            return false;
        }

        /*
         * Handler for the browser on plugin crashed event.
         */
        public void OnPluginCrashed(IWebBrowser browser, string pluginPath) {
            // No implementation required
        }

        /*
         * Handler for the browser on render process terminated event.
         */
        public void OnRenderProcessTerminated(IWebBrowser browser, CefTerminationStatus status) {
            // No implementation required
        }

        #endregion

    }

}
