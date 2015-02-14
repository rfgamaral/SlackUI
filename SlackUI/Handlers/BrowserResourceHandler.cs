#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using CefSharp;

namespace SlackUI {

    internal class BrowserResourceHandler : IResourceHandler {

        #region Private Fields

        private const int RetryRequestInterval = 500;

        #endregion

        #region Public Methods

        /*
         * Handler for the browser get resource handler event.
         */
        public ResourceHandler GetResourceHandler(IWebBrowser browser, IRequest request) {
            // Inject custom CSS with overall page style overrides
            if(Regex.Match(request.Url, @"rollup-(plastic|\w+_core)_\d+\.css", RegexOptions.IgnoreCase).Success) {
                using(WebClient webClient = new WebClient()) {
                    string pageStyle = string.Empty;
                    int retryCount = 3;

                    // Attempt to download the default page CSS
                    do {
                        try {
                            pageStyle = webClient.DownloadString(request.Url);
                            retryCount = 0;
                        } catch(WebException) {
                            Thread.Sleep(RetryRequestInterval);
                            retryCount--;
                        }
                    } while(retryCount > 0);

                    // Return the custom CSS resource
                    return ResourceHandler.FromString(pageStyle + Properties.Resources.PageStyleOverride, ".css");
                }
            }

            // Let the Chromium web browser handle the event
            return null;
        }

        /*
         * Handler for the browser register handler event.
         */
        public void RegisterHandler(string url, ResourceHandler handler) {
            // No implementation required
        }

        /*
         * Handler for the browser unregister handler event.
         */
        public void UnregisterHandler(string url) {
            // No implementation required
        }

        #endregion

    }

}
