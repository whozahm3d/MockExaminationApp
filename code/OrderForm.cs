using System;
using System.Drawing;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class OrderForm : Form
    {
        private FlowLayoutPanel medicinePanel;

        public OrderForm()
        {
            InitializeComponent();
            LoadOrderForm();
        }

        private void LoadOrderForm()
        {
            this.Text = "Order Medicines";
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label lblTitle = new Label()
            {
                Text = "Order Medicines",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Blue,
                AutoSize = true,
                Location = new Point(160, 20)
            };

            Label lblFullName = CreateLabel("Full Name:", 60);
            TextBox txtFullName = CreateTextBox(80, "Your full name");

            Label lblEmail = CreateLabel("Email:", 120);
            TextBox txtEmail = CreateTextBox(140, "Your email");

            Label lblPhone = CreateLabel("Phone Number:", 180);
            TextBox txtPhone = CreateTextBox(200, "Your phone number");

            Label lblMedicineHeader = new Label()
            {
                Text = "Medicines",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Blue,
                AutoSize = true,
                Location = new Point(200, 240)
            };

            medicinePanel = new FlowLayoutPanel()
            {
                Location = new Point(50, 270),
                Size = new Size(400, 100),
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle
            };

            Button btnAddMedicine = new Button()
            {
                Text = "Add Another Medicine",
                BackColor = Color.Blue,
                ForeColor = Color.White,
                Location = new Point(50, 380),
                Size = new Size(200, 30)
            };
            btnAddMedicine.Click += (s, e) => AddMedicineRow();

            Label lblAddress = CreateLabel("Delivery Address:", 420);
            TextBox txtAddress = CreateTextBox(440, "Delivery address");

            Button btnPlaceOrder = new Button()
            {
                Text = "Place Order",
                BackColor = Color.Blue,
                ForeColor = Color.White,
                Location = new Point(50, 480),
                Size = new Size(400, 40)
            };
            btnPlaceOrder.Click += (s, e) => MessageBox.Show("Order Placed Successfully!");

            // Adding Controls to Form
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblFullName);
            this.Controls.Add(txtFullName);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblPhone);
            this.Controls.Add(txtPhone);
            this.Controls.Add(lblMedicineHeader);
            this.Controls.Add(medicinePanel);
            this.Controls.Add(btnAddMedicine);
            this.Controls.Add(lblAddress);
            this.Controls.Add(txtAddress);
            this.Controls.Add(btnPlaceOrder);

            AddMedicineRow();
        }

        private Label CreateLabel(string text, int y)
        {
            return new Label()
            {
                Text = text,
                AutoSize = true,
                Location = new Point(50, y),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
        }

        private TextBox CreateTextBox(int y, string placeholder)
        {
            TextBox textBox = new TextBox()
            {
                Size = new Size(400, 25),
                Location = new Point(50, y),
                ForeColor = Color.Gray,
                Text = placeholder
            };

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };

            return textBox;
        }

        private void AddMedicineRow()
        {
            Panel rowPanel = new Panel() { Size = new Size(380, 30) };

            TextBox txtMedicine = new TextBox() { Width = 180, ForeColor = Color.Gray, Text = "Medicine Name" };
            TextBox txtQuantity = new TextBox() { Width = 80, ForeColor = Color.Gray, Text = "Quantity" };
            Button btnRemove = new Button() { Text = "Remove", BackColor = Color.Red, ForeColor = Color.White, Size = new Size(80, 25) };

            ApplyPlaceholder(txtMedicine, "Medicine Name");
            ApplyPlaceholder(txtQuantity, "Quantity");

            btnRemove.Click += (s, e) =>
            {
                medicinePanel.Controls.Remove(rowPanel);
            };

            rowPanel.Controls.Add(txtMedicine);
            rowPanel.Controls.Add(txtQuantity);
            rowPanel.Controls.Add(btnRemove);

            txtQuantity.Location = new Point(190, 0);
            btnRemove.Location = new Point(280, 0);

            medicinePanel.Controls.Add(rowPanel);
        }

        private void ApplyPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }
    }
}
