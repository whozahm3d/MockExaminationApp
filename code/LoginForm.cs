using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class LoginForm : Form
    {
        private string action;

        public LoginForm(string action)
        {
            InitializeComponent();
            this.action = action;
            LoadLoginForm();
        }

        private void LoadLoginForm()
        {
            this.Text = "User Login";
            this.Size = new Size(350, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(200, 220, 255);

            Label lblUsername = new Label() { Text = "Username:", Top = 30, Left = 50 };
            TextBox txtUsername = new TextBox() { Top = 50, Left = 50, Width = 200 };

            Label lblPassword = new Label() { Text = "Password:", Top = 80, Left = 50 };
            TextBox txtPassword = new TextBox() { Top = 100, Left = 50, Width = 200, PasswordChar = '*' };

            Button btnLogin = new Button() { Text = "Login", Top = 140, Left = 50, Width = 100 };
            Button btnRegister = new Button() { Text = "Register", Top = 140, Left = 160, Width = 100 };

            btnLogin.Click += (s, ev) => Login(txtUsername.Text, txtPassword.Text);
            btnRegister.Click += (s, ev) => OpenRegister();

            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnRegister);
        }

        private void Login(string username, string password)
        {
            string filePath = "users.txt";
            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split(',');
                    if (parts[0] == username && parts[1] == password)
                    {
                        MessageBox.Show("Login successful!");
                        this.Hide();
                        if (action == "donate")
                            new DonateForm().Show();
                        else
                            new OrderForm().Show();
                        return;
                    }
                }
            }
            MessageBox.Show("Invalid credentials!");
        }

        private void OpenRegister()
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }
    }
}
