using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class AdminForm : Form
    {
        private DataGridView dgvMedicines;
        private Button btnApprove, btnReject, btnRefresh;

        private string connectionString = "Your_Connection_String_Here";

        public AdminForm()
        {
            InitializeComponent();
            LoadAdminForm();
            LoadPendingMedicines();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void LoadAdminForm()
        {
            this.Text = "Admin Verification";
            this.Size = new System.Drawing.Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            dgvMedicines = new DataGridView()
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(740, 350),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            btnApprove = new Button() { Text = "Approve", Location = new System.Drawing.Point(200, 400), Width = 100 };
            btnReject = new Button() { Text = "Reject", Location = new System.Drawing.Point(320, 400), Width = 100 };
            btnRefresh = new Button() { Text = "Refresh", Location = new System.Drawing.Point(440, 400), Width = 100 };

            btnApprove.Click += BtnApprove_Click;
            btnReject.Click += BtnReject_Click;
            btnRefresh.Click += (s, e) => LoadPendingMedicines();
            UpdateMedicineStatus("Approved");
            UpdateMedicineStatus("Rejected");


            this.Controls.Add(dgvMedicines);
            this.Controls.Add(btnApprove);
            this.Controls.Add(btnReject);
            this.Controls.Add(btnRefresh);
        }

        private void LoadPendingMedicines()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MedicineId, MedicineName, Quantity, ExpiryDate, Status FROM Medicines WHERE Status = 'Pending'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvMedicines.DataSource = dt;
            }
        }

        private void UpdateMedicineStatus(string status)
        {
            if (dgvMedicines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a medicine entry.");
                return;
            }

            int selectedId = Convert.ToInt32(dgvMedicines.SelectedRows[0].Cells["MedicineId"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Medicines SET Status = @Status WHERE MedicineId = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Id", selectedId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show($"Medicine has been {status.ToLower()}ed.");
                LoadPendingMedicines();
            }
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            UpdateMedicineStatus("Approved");
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            UpdateMedicineStatus("Rejected");
        }
        string query = "UPDATE Medicines SET Status = @Status WHERE MedicineId = @Id";

    }
}
