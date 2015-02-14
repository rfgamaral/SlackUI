#region Copyright © 2014-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SlackUI {

    internal static class NativeFontExtension {

        #region Private Fields

        private static bool canRepairFonts = true;
        private static List<string> fontNamesList;

        #endregion

        #region Private Properties

        /*
         * Windows native font property.
         */
        private static Font NativeFont {
            get;
            set;
        }

        #endregion

        #region Constructors

        /*
         * Initialize static data fields as soon as the class is first referenced.
         */
        static NativeFontExtension() {
            // Do not attempt to fix fonts in design mode
            if(Process.GetCurrentProcess().ProcessName.Contains("devenv")) {
                canRepairFonts = false;
                return;
            }

            // Do not fix fonts in Windows 95, 98, NT or similar
            if(Environment.OSVersion.Platform == PlatformID.Win32Windows || Environment.OSVersion.Version.Major < 5) {
                canRepairFonts = false;
                return;
            }

            // Pick the right native font according to the Windows version
            if(Environment.OSVersion.Version.Major < 6) {
                NativeFont = SystemFonts.DialogFont; // Tahoma (hopefully)
            } else {
                NativeFont = SystemFonts.MessageBoxFont; // Segoe UI
            }

            // Initialize the list of fonts to be replaced for the native font
            fontNamesList = new List<string>(new string[] {
                "Microsoft Sans Serif",
                "Tahoma"
            });
        }

        #endregion

        #region Internal Methods

        /*
         * Apply the native font to all controls contained in the referenced form.
         */
        internal static void ApplyNativeFont(this Form form) {
            // Return immediately if fonts cannot be repaired
            if(!canRepairFonts) {
                return;
            }

            // Disable the form auto scale mode
            form.AutoScaleMode = AutoScaleMode.None;

            // Repair the font name on this form
            form.Font = RepairFontName(form.Font);

            // Repair the font name on this form controls
            RepairControlsFontName(form.Controls);
        }

        #endregion

        #region Private Methods

        /*
         * Repair the font name for all controls contained in a control collection.
         */
        private static void RepairControlsFontName(Control.ControlCollection collection) {
            // Loop through all controls and fix the font name recursively
            foreach(Control control in collection) {
                control.Font = RepairFontName(control.Font);
                RepairControlsFontName(control.Controls);
            }
        }

        /*
         * Repair the font name keeping it's formatting (size and style).
         */
        private static Font RepairFontName(Font font) {
            // Should this font be replaced?
            if(fontNamesList.IndexOf(font.Name) > -1) {
                bool useDefaultSize = true, useDefaultStyle = true;

                // Does this font have a special size?
                if(font.Size <= 8 || font.Size >= 9) {
                    useDefaultSize = false;
                }

                // Does this font have any special styles applied?
                if(font.Italic || font.Strikeout || font.Underline || font.Bold) {
                    useDefaultStyle = false;
                }

                // Return the native font if the size and style were not changed
                if(useDefaultSize && useDefaultStyle) {
                    return NativeFont;
                }

                // Initialize the default font style and size
                FontStyle fontStyle = FontStyle.Regular;
                float fontSize = NativeFont.SizeInPoints;

                // Apply custom styles to the font?
                if(!useDefaultStyle) {
                    if(font.Italic) {
                        fontStyle = fontStyle | FontStyle.Italic;
                    }

                    if(font.Strikeout) {
                        fontStyle = fontStyle | FontStyle.Strikeout;
                    }

                    if(font.Underline) {
                        fontStyle = fontStyle | FontStyle.Underline;
                    }

                    if(font.Bold) {
                        fontStyle = fontStyle | FontStyle.Bold;
                    }
                }

                // Apply custom size to the font?
                if(!useDefaultSize) {
                    fontSize = font.SizeInPoints;
                }

                // Return the new repaired font
                return new Font(NativeFont.Name, fontSize, fontStyle, GraphicsUnit.Point);
            }

            // Return the unchanged font
            return font;
        }

        #endregion

    }

}
