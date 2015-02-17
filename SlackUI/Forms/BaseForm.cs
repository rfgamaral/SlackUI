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
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
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
