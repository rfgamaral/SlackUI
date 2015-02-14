#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System;
using System.Runtime.InteropServices;

namespace SlackUI {

    internal static class NativeMethods {

        #region Internal Enums

        /*
         * Enumerated flags for new menu items.
         */
        [Flags]
        internal enum MenuFlags : uint {
            MF_STRING = 0,
            MF_SEPARATOR = 0x800
        }

        /*
         * Enumerated flags for windows messages.
         */
        [Flags]
        internal enum WindowsMessages : uint {
            WM_EXITSIZEMOVE = 0x0232,
            WM_SIZE = 0x5,
            WM_SYSCOMMAND = 0x112
        }

        #endregion

        #region Internal Methods

        /*
         * Appends a new item to the end of the specified menu bar, drop-down menu, submenu, or shortcut menu.
         */
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool AppendMenu(IntPtr hMenu, MenuFlags uFlags, UIntPtr uIDNewItem, string lpNewItem);

        /*
         * Enables the application to access the window menu for copying and modifying.
         */
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        /*
         * Loads the specified cursor resource from the system.
         */
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr LoadCursor(IntPtr hInstance, IntPtr lpCursorName);

        #endregion

    }

}
