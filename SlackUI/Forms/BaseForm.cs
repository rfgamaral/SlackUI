#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System;
using System.Windows.Forms;

namespace SlackUI {

    [System.ComponentModel.DesignerCategory("Code")]
    public class BaseForm : Form {

        #region Public Constructors

        /*
         * Create an empty base form with custom icon and native fonts applied.
         */
        public BaseForm()
            : base() {
            Icon = Properties.Resources.Application;
        }

        #endregion Public Constructors

        #region Protected Methods

        /*
         * Handler for the overridden on handle created event.
         */
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);

            // Apply the native font to all controls contained in this form
            this.ApplyNativeFont();
        }

        #endregion

    }

}
