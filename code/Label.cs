using MedicineDonationApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Label
    {
        private System.Windows.Forms.Label notificationLabel;
        private DataGridView dgvMedicines;
        private MedicineRepository medicineRepo;

        public Point Location { get; private set; }
        public Size Size { get; private set; }
        public bool Visible { get; private set; }
        public object Controls { get; private set; }
        public string Text { get; private set; }
        public Color ForeColor { get; private set; }
        public Font Font { get; private set; }

        private System.Windows.Forms.Label GetNotificationLabel()
        {
            return notificationLabel;
        }

        private void InitializeNotificationLabel(System.Windows.Forms.Label notificationLabel)
        {
            notificationLabel = new System.Windows.Forms.Label()
            {
                Location = new Point(300, 400),
                Size = new Size(400, 30),
                ForeColor = Color.Green,
                Font = new Font("Arial", 12),
                Visible = false
            };
            if (this.Controls is Control.ControlCollection controls)
            {
                controls.Add(notificationLabel);
            }
        }

        private void ShowInAppNotification(string message, bool isSuccess)
        {
            notificationLabel.Text = message;
            notificationLabel.ForeColor = isSuccess ? Color.Green : Color.Red;
            notificationLabel.Visible = true;

            // Hide notification after 5 seconds
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += (s, e) =>
            {
                notificationLabel.Visible = false;
                timer.Stop();
            };
            timer.Start();
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgvMedicines?.CurrentCell == null)
            {
                ShowInAppNotification("Please select a medicine to approve.", false);
                return;
            }

            int selectedRowIndex = dgvMedicines.CurrentCell.RowIndex;
            if (selectedRowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvMedicines.Rows[selectedRowIndex];
                int medicineId = Convert.ToInt32(selectedRow.Cells["MedicineId"].Value);
                string medicineName = selectedRow.Cells["MedicineName"].Value?.ToString() ?? "Unknown";

                medicineRepo.UpdateMedicineStatus(medicineId, "Approved");
                ShowInAppNotification($"Medicine '{medicineName}' approved!", true);

                dgvMedicines.DataSource = medicineRepo.GetMedicinesToVerify();
            }
            else
            {
                ShowInAppNotification("Please select a medicine to approve.", false);
            }
        }
    }
}
