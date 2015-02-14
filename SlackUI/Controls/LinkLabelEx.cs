#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System;
using System.Windows.Forms;

namespace SlackUI {

    [System.ComponentModel.DesignerCategory("Code")]
    internal class LinkLabelEx : LinkLabel {

        #region Private Fields

        private readonly static IntPtr IDC_HAND = new IntPtr(32649);

        #endregion

        #region Protected Methods

        /*
         * Handler for the overridden on mouse move event.
         */
        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);

            // Show the system hand cursor if the base class decided to show the ugly one
            if(OverrideCursor == Cursors.Hand) {
                OverrideCursor = new Cursor(NativeMethods.LoadCursor(IntPtr.Zero, IDC_HAND));
            }
        }

        #endregion

    }

}
