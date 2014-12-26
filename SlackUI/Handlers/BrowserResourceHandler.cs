#region Copyright © 2014 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System.Net;
using System.Text.RegularExpressions;
using CefSharp;

namespace SlackUI {

    internal class BrowserResourceHandler : IResourceHandler {

        #region Public Methods

        /*
         * Handler for the browser get resource handler event.
         */
        public ResourceHandler GetResourceHandler(IWebBrowser browser, IRequest request) {
            System.Diagnostics.Debug.WriteLine(request.Url);
            // Inject custom CSS with overall page style overrides
            if(Regex.Match(request.Url, @"rollup-(plastic|\w+_core)_\d+\.css", RegexOptions.IgnoreCase).Success) {
                using(WebClient webClient = new WebClient()) {
                    return ResourceHandler.FromString(webClient.DownloadString(request.Url) +
                        Properties.Resources.PageStyleOverride, ".css");
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
