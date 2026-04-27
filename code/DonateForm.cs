using System;
using System.Drawing;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public partial class DonateForm : Form
    {
        public DonateForm()
        {
            InitializeComponent();
            this.Load += DonateForm_Load;
        }

        private void DonateForm_Load(object sender, EventArgs e)
        {
            this.Text = "Donate Medicines";
            this.Size = new Size(400, 500);
            this.BackColor = Color.WhiteSmoke;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label()
            {
                Text = "Donate Unused Medicines",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Top = 20,
                Left = 100
            };
            this.Controls.Add(lblTitle);

            int yOffset = 60;

            Label lblFullName = CreateLabel("Full Name:", yOffset);
            TextBox txtFullName = CreateTextBox(yOffset + 20);

            Label lblEmail = CreateLabel("Email:", yOffset += 60);
            TextBox txtEmail = CreateTextBox(yOffset + 20);

            Label lblPhone = CreateLabel("Phone:", yOffset += 60);
            TextBox txtPhone = CreateTextBox(yOffset + 20);

            Label lblMedicine = CreateLabel("Medicine Name:", yOffset += 60);
            TextBox txtMedicine = CreateTextBox(yOffset + 20);

            Label lblQuantity = CreateLabel("Quantity:", yOffset += 60);
            TextBox txtQuantity = CreateTextBox(yOffset + 20);

            Label lblDate = CreateLabel("Expiration Date:", yOffset += 60);
            DateTimePicker dtpExpiration = new DateTimePicker()
            {
                Top = yOffset + 20,
                Left = 50,
                Width = 250
            };

            Button btnSubmit = new Button()
            {
                Text = "Submit Donation",
                Top = yOffset + 80,
                Left = 50,
                Width = 250,
                BackColor = Color.BlueViolet,
                ForeColor = Color.White
            };
            btnSubmit.Click += (s, ev) => MessageBox.Show("Donation Submitted!");

            this.Controls.Add(lblFullName);
            this.Controls.Add(txtFullName);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblPhone);
            this.Controls.Add(txtPhone);
            this.Controls.Add(lblMedicine);
            this.Controls.Add(txtMedicine);
            this.Controls.Add(lblQuantity);
            this.Controls.Add(txtQuantity);
            this.Controls.Add(lblDate);
            this.Controls.Add(dtpExpiration);
            this.Controls.Add(btnSubmit);
        }

        private Label CreateLabel(string text, int top)
        {
            return new Label()
            {
                Text = text,
                Top = top,
                Left = 50,
                AutoSize = true
            };
        }

        private TextBox CreateTextBox(int top)
        {
            return new TextBox()
            {
                Top = top,
                Left = 50,
                Width = 250
            };
        }
    }
}
