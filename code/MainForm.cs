using System;
using System.Drawing;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Essential Medicine App";
            this.Size = new Size(400, 300);
            this.BackColor = Color.FromArgb(58, 125, 237);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label titleLabel = new Label()
            {
                Text = "Essential Medicine",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Top = 30,
                Left = 100
            };
            this.Controls.Add(titleLabel);

            Button btnDonate = new Button()
            {
                Text = "Donate Now",
                BackColor = Color.BlueViolet,
                ForeColor = Color.White,
                Width = 120,
                Height = 40,
                Top = 80,
                Left = 50
            };
            btnDonate.Click += BtnDonate_Click;
            this.Controls.Add(btnDonate);

            Button btnOrder = new Button()
            {
                Text = "Order Now",
                BackColor = Color.SkyBlue,
                ForeColor = Color.White,
                Width = 120,
                Height = 40,
                Top = 80,
                Left = 200
            };
            btnOrder.Click += BtnOrder_Click;
            this.Controls.Add(btnOrder);
        }

        private void BtnDonate_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm("donate");
            loginForm.Show();
            this.Hide();
        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm("order");
            loginForm.Show();
            this.Hide();
        }
    }
}
