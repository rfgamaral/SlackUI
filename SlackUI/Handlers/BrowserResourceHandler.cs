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

        #region Private Methods

        /*
         * Download a string resource from the specified URL with multiple retries.
         */
        private string DownloadStringResource(string url) {
            using(WebClient webClient = new WebClient()) {
                string resource = string.Empty;
                double retryInterval = 1000;
                int retryCount = 10;

                // Attempt to download a string with multiple retries
                do {
                    try {
                        resource = webClient.DownloadString(url);
                        retryCount = 0;
                    } catch(WebException) {
                        Thread.Sleep((int)retryInterval);
                        retryInterval *= 1.5;
                        retryCount--;
                    }
                } while(retryCount > 0);

                // Return the downloaded string or an empty one if failed
                return resource;
            }
        }

        #endregion

        #region Public Methods

        /*
         * Handler for the browser get resource handler event.
         */
        public ResourceHandler GetResourceHandler(IWebBrowser browser, IRequest request) {
            // Inject custom CSS with overall page style overrides
            if(Regex.Match(request.Url, @"rollup-(plastic|\w+_core)\.css", RegexOptions.IgnoreCase).Success) {
                return ResourceHandler.FromString(DownloadStringResource(request.Url) +
                    Properties.Resources.PageStyleOverride, ".css");
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
