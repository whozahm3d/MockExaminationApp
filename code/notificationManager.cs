using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Ensure this is included for MessageBox

namespace MedicineDonationApp
{
    internal class notificationManager
    {
        public static class NotificationManager
        {
            private static List<string> notifications = new List<string>();

            public static void AddNotification(string message)
            {
                notifications.Add(message);
            }

            public static void ShowNotifications()
            {
                string all = string.Join("\n", notifications);
                MessageBox.Show(string.IsNullOrWhiteSpace(all) ? "No notifications." : all, "Notifications");
            }
        }
    }
}
