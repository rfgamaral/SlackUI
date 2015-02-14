#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System;
using System.Windows.Forms;

namespace SlackUI {

    internal static class ControlExtension {

        #region Internal Methods

        /*
         * Executes the action asynchronously on the UI thread, without blocking the calling thread.
         */
        internal static void InvokeOnUiThreadIfRequired(this Control control, Action action) {
            if(control.InvokeRequired) {
                control.BeginInvoke(action);
            } else {
                action.Invoke();
            }
        }

        #endregion

    }

}
