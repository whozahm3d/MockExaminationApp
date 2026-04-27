using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicineDonationApp.notificationManager;

namespace MedicineDonationApp
{
    public class AdminPanelForm : Form
    {
        ListBox lstPending = new ListBox();

        public AdminPanelForm()
        {
            this.Text = "Admin Panel";
            this.Size = new Size(400, 300);

            lstPending.Items.Add("Paracetamol - Pending");
            lstPending.Items.Add("Ibuprofen - Pending");
            lstPending.Location = new Point(30, 30);
            lstPending.Size = new Size(300, 120);

            Button btnApprove = new Button() { Text = "Approve", Location = new Point(50, 170) };
            Button btnReject = new Button() { Text = "Reject", Location = new Point(150, 170) };

            btnApprove.Click += (s, e) =>
            {
                if (lstPending.SelectedItem != null)
                {
                    NotificationManager.AddNotification($"{lstPending.SelectedItem} approved.");
                    lstPending.Items.Remove(lstPending.SelectedItem);
                }
            };

            btnReject.Click += (s, e) =>
            {
                if (lstPending.SelectedItem != null)
                {
                    NotificationManager.AddNotification($"{lstPending.SelectedItem} rejected.");
                    lstPending.Items.Remove(lstPending.SelectedItem);
                }
            };

            this.Controls.Add(lstPending);
            this.Controls.Add(btnApprove);
            this.Controls.Add(btnReject);
        }
    }

}
