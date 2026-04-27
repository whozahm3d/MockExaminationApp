using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class MedicineSearchForm : Form
    {
        private DataGridView dgvSearchResults;
        private DateTimePicker dtStartDate, dtEndDate;
        private NumericUpDown numAge;
        private ComboBox cmbGender;
        private Button btnSearch;

        public MedicineSearchForm()
        {
            InitializeComponent();
            LoadForm();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void LoadForm()
        {
            this.Text = "Search Medicines";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblDateRange = new Label() { Text = "Expiry Date Range:", Location = new Point(20, 20), Width = 120 };
            dtStartDate = new DateTimePicker() { Location = new Point(150, 20), Width = 120 };
            dtEndDate = new DateTimePicker() { Location = new Point(280, 20), Width = 120 };

            Label lblAge = new Label() { Text = "Recipient Age:", Location = new Point(420, 20), Width = 100 };
            numAge = new NumericUpDown() { Location = new Point(530, 20), Width = 60, Minimum = 1, Maximum = 100 };

            Label lblGender = new Label() { Text = "Gender:", Location = new Point(610, 20), Width = 60 };
            cmbGender = new ComboBox() { Location = new Point(670, 20), Width = 80 };
            cmbGender.Items.AddRange(new string[] { "Any", "Male", "Female" });
            cmbGender.SelectedIndex = 0;

            btnSearch = new Button() { Text = "Search", Location = new Point(350, 60), Width = 100 };
            btnSearch.Click += BtnSearch_Click;

            dgvSearchResults = new DataGridView()
            {
                Location = new Point(20, 100),
                Size = new Size(740, 330),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            this.Controls.Add(lblDateRange);
            this.Controls.Add(dtStartDate);
            this.Controls.Add(dtEndDate);
            this.Controls.Add(lblAge);
            this.Controls.Add(numAge);
            this.Controls.Add(lblGender);
            this.Controls.Add(cmbGender);
            this.Controls.Add(btnSearch);
            this.Controls.Add(dgvSearchResults);

            dgvSearchResults.DataSource = GetAllMedicines(); // Initial full list
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DateTime start = dtStartDate.Value.Date;
            DateTime end = dtEndDate.Value.Date;
            int age = (int)numAge.Value;
            string gender = cmbGender.SelectedItem.ToString();

            DataTable filtered = GetAllMedicines().Clone();

            foreach (DataRow row in GetAllMedicines().Rows)
            {
                DateTime expiryDate = DateTime.Parse(row["Expiry Date"].ToString());
                int medAge = Convert.ToInt32(row["Age"]);
                string medGender = row["Gender"].ToString();

                if (expiryDate >= start && expiryDate <= end &&
                    medAge == age &&
                    (gender == "Any" || gender == medGender))
                {
                    filtered.ImportRow(row);
                }
            }

            dgvSearchResults.DataSource = filtered;
        }

        // Replace this with actual database or list retrieval in production
        private DataTable GetAllMedicines()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Medicine Name");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Expiry Date");
            dt.Columns.Add("Age");
            dt.Columns.Add("Gender");

            dt.Rows.Add("Panadol", "10", "2025-05-01", 25, "Male");
            dt.Rows.Add("Aspirin", "15", "2024-12-10", 25, "Female");
            dt.Rows.Add("Vitamin C", "20", "2025-02-20", 30, "Male");
            dt.Rows.Add("Calpol", "5", "2024-11-05", 25, "Male");

            return dt;
        }
    }
}
