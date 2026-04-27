using System;
using System.Data;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class AdminVerificationForm : Form
    {
        private DataGridView dgvMedicines;
        private Button btnApprove;
        private Button btnReject;
        private MedicineRepository medicineRepo;

        public AdminVerificationForm()
        {
            InitializeComponent();
            medicineRepo = new MedicineRepository();
            LoadForm();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void LoadForm()
        {
            this.Text = "Admin - Medicine Verification";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            dgvMedicines = new DataGridView()
            {
                Location = new Point(20, 20),
                Size = new Size(740, 350),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgvMedicines.DataSource = medicineRepo.GetMedicinesToVerify();

            btnApprove = new Button()
            {
                Text = "Approve",
                Location = new Point(20, 380),
                Size = new Size(100, 40),
                BackColor = Color.Green,
                ForeColor = Color.White
            };
            btnApprove.Click += BtnApprove_Click;

            btnReject = new Button()
            {
                Text = "Reject",
                Location = new Point(130, 380),
                Size = new Size(100, 40),
                BackColor = Color.Red,
                ForeColor = Color.White
            };
            btnReject.Click += BtnReject_Click;

            this.Controls.Add(dgvMedicines);
            this.Controls.Add(btnApprove);
            this.Controls.Add(btnReject);
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgvMedicines.CurrentCell?.RowIndex ?? -1;
            if (selectedRowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvMedicines.Rows[selectedRowIndex];
                int medicineId = Convert.ToInt32(selectedRow.Cells["MedicineId"].Value);
                string medicineName = selectedRow.Cells["MedicineName"].Value.ToString();

                medicineRepo.UpdateMedicineStatus(medicineId, "Approved");
                MessageBox.Show($"Medicine '{medicineName}' approved!");
                dgvMedicines.DataSource = medicineRepo.GetMedicinesToVerify();
            }
            else
            {
                MessageBox.Show("Please select a medicine to approve.");
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgvMedicines.CurrentCell?.RowIndex ?? -1;
            if (selectedRowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvMedicines.Rows[selectedRowIndex];
                int medicineId = Convert.ToInt32(selectedRow.Cells["MedicineId"].Value);
                string medicineName = selectedRow.Cells["MedicineName"].Value.ToString();

                medicineRepo.UpdateMedicineStatus(medicineId, "Rejected");
                MessageBox.Show($"Medicine '{medicineName}' rejected.");
                dgvMedicines.DataSource = medicineRepo.GetMedicinesToVerify();
            }
            else
            {
                MessageBox.Show("Please select a medicine to reject.");
            }
        }
    }
}
