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
            LoadMainUI();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void LoadMainUI()
        {
            this.Text = "Medicine Donation App - Dashboard";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            Button btnOrder = CreateNavButton("Order Medicines", 40);
            btnOrder.Click += (s, e) => new OrderForm().Show();

            Button btnRegister = CreateNavButton("Register User", 90);
            btnRegister.Click += (s, e) => new MedicineDonationApp.RegisterForm().Show(); // Fully qualified to resolve ambiguity

            Button btnList = CreateNavButton("View Medicines", 140);
            btnList.Click += (s, e) => new MedicineListForm().Show(); // Removed incorrect namespace

            Button btnAdmin = CreateNavButton("Admin Panel", 190);
            btnAdmin.Click += (s, e) => new AdminForm().Show();

            Button btnSearch = CreateNavButton("Search Medicines", 240);
            btnSearch.Click += (s, e) => new MedicineDonationApp.MedicineSearchForm().Show(); // Fully qualified to resolve ambiguity
            this.Controls.Add(btnSearch);

            this.Controls.Add(btnOrder);
            this.Controls.Add(btnRegister);
            this.Controls.Add(btnList);
            this.Controls.Add(btnAdmin);
        }

        private Button CreateNavButton(string text, int top)
        {
            return new Button()
            {
                Text = text,
                Location = new Point(100, top),
                Size = new Size(200, 40),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White
            };
        }
    }
}
