using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            LoadRegisterForm();
        }

        private void LoadRegisterForm()
        {
            this.Text = "User Registration";
            this.Size = new Size(350, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGray;

            Label lblUsername = new Label() { Text = "Username:", Top = 30, Left = 50 };
            TextBox txtUsername = new TextBox() { Top = 50, Left = 50, Width = 200 };

            Label lblPassword = new Label() { Text = "Password:", Top = 80, Left = 50 };
            TextBox txtPassword = new TextBox() { Top = 100, Left = 50, Width = 200, PasswordChar = '*' };

            Button btnRegister = new Button() { Text = "Register", Top = 140, Left = 50, Width = 200 };

            btnRegister.Click += (s, ev) => Register(txtUsername.Text, txtPassword.Text);

            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnRegister);
        }

        private void Register(string username, string password)
        {
            string filePath = "users.txt";
            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split(',');
                    if (parts[0] == username)
                    {
                        MessageBox.Show("Username already exists. Choose another.");
                        return;
                    }
                }
            }

            File.AppendAllText(filePath, username + "," + password + Environment.NewLine);
            MessageBox.Show("Registration successful!");
            new LoginForm("donate").Show();
            this.Hide();
        }
    }
}
