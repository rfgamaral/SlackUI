﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SlackUI.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SlackUI.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap AboutLogo {
            get {
                object obj = ResourceManager.GetObject("AboutLogo", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap MenuAboutIcon {
            get {
                object obj = ResourceManager.GetObject("MenuAboutIcon", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap MenuSettingsIcon {
            get {
                object obj = ResourceManager.GetObject("MenuSettingsIcon", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /* Clean up unnecessary elements from &apos;Sign In&apos; pages. */
        ///
        ///header .header_links {
        ///    display: none !important;
        ///}
        ///
        ///#page {
        ///    min-height: 0 !important;
        ///}
        ///
        ///#page_contents {
        ///    padding-bottom: 0 !important;
        ///}
        ///
        ///#page_contents &gt; .align_center:last-child {
        ///    display: none !important;
        ///}
        ///
        ////* Remove Switch Team &amp; Logout menu items. */
        ///
        ///#menu #add_team {
        ///    display: none !important;
        ///}
        ///
        ///#menu #logout {
        ///    display: none !important;
        ///}
        ///
        ///#menu_items &gt; .divider:nth-last-child(2) {
        ///    di [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string PageStyleOverride {
            get {
                return ResourceManager.GetString("PageStyleOverride", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap PanelBackground {
            get {
                object obj = ResourceManager.GetObject("PanelBackground", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon SlackUI {
            get {
                object obj = ResourceManager.GetObject("SlackUI", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon SlackUI_Unread {
            get {
                object obj = ResourceManager.GetObject("SlackUI_Unread", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon SlackUI16 {
            get {
                object obj = ResourceManager.GetObject("SlackUI16", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon SlackUI16White {
            get {
                object obj = ResourceManager.GetObject("SlackUI16White", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
    }
}
