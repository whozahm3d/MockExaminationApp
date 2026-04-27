using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MedicineDonationApp
{
    public partial class RegisterForm : Form
    {
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtPassword;
        private Button btnRegister;

        public RegisterForm()
        {
            InitializeComponent();

            // Initialize controls  
            txtName = new TextBox { Name = "txtName", Location = new System.Drawing.Point(100, 50) };
            txtEmail = new TextBox { Name = "txtEmail", Location = new System.Drawing.Point(100, 100) };
            txtPhone = new TextBox { Name = "txtPhone", Location = new System.Drawing.Point(100, 150) };
            txtPassword = new TextBox { Name = "txtPassword", Location = new System.Drawing.Point(100, 200) };
            btnRegister = new Button { Name = "btnRegister", Text = "Register", Location = new System.Drawing.Point(100, 250) };

            // Add controls to the form  
            Controls.Add(txtName);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(txtPassword);
            Controls.Add(btnRegister);

            // ToolTips for better UX  
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(txtEmail, "Enter a valid email address (e.g. example@gmail.com)");
            tooltip.SetToolTip(txtPhone, "Enter your 10-digit phone number");

            // Register button click event  
            btnRegister.Click += btnRegister_Click;

            Button btnSearch = CreateNavButton("Search Medicines", 240);
            btnSearch.Click += (s, e) => new MedicineSearchForm().Show();
            this.Controls.Add(btnSearch);

        }

        private Button CreateNavButton(string v1, int v2)
        {
            throw new NotImplementedException();
        }

        private void InitializeComponent()
        {
            this.Text = "Register Form";
            this.Size = new System.Drawing.Size(400, 400);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!IsValidPhone(phone))
            {
                MessageBox.Show("Please enter a valid 10-digit phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
        }

        private bool IsValidEmail(string email) =>
            Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        private bool IsValidPhone(string phone) =>
            Regex.IsMatch(phone, @"^\d{10}$");

        private void ClearForm()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
            txtName.Focus();
        }
    }
}
