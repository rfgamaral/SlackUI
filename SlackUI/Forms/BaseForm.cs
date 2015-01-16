using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SlackUI {

    [System.ComponentModel.DesignerCategory("Code")]
    public class BaseForm : Form {

        #region Public Constructors

        /*
         * Create an empty base form with native fonts applied.
         */
        public BaseForm()
            : base() {
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

        protected void FlashWindow()
        {
            var fi = new NativeMethods.FLASHWINFO();
            fi.cbSize = Convert.ToUInt32(Marshal.SizeOf(fi));
            fi.hwnd = Handle;
            fi.dwFlags = (uint)(NativeMethods.FlashInfoFlags.FLASHW_ALL | NativeMethods.FlashInfoFlags.FLASHW_TIMERNOFG);
            fi.uCount = uint.MaxValue;
            fi.dwTimeout = 0;

            NativeMethods.FlashWindowEx(ref fi);
        }

        #endregion

    }

}
