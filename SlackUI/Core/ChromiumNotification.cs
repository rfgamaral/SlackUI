using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackUI.Core {
    class ChromiumNotification {

        public void ShowNotification(String title, String body, String icon, String tag) {
            Program.WrapperForm.InvokeOnUiThreadIfRequired(() => {
                Toaster.Toast.ShowNotification(title, body, icon, tag);
            });

            System.Diagnostics.Debug.WriteLine("[Notification] title: '{0}', body: '{1}', icon: '{2}', tag: '{3}'.", title, body, icon, tag);
        }
    }
}
