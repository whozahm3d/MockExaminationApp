using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDonationApp
{
    internal class requestForm
    {
        public class RequestForm : Form
        {
            public RequestForm(string medicineName)
            {
                this.Text = $"Request - {medicineName}";
                this.Size = new Size(350, 200);

                Label lblNote = new Label() { Text = $"Requesting: {medicineName}", Location = new Point(30, 20) };
                TextBox txtNote = new TextBox() { Multiline = true, Width = 250, Height = 60, Location = new Point(30, 50) };
                Button btnSend = new Button() { Text = "Send Request", Location = new Point(100, 130) };

                btnSend.Click += (s, e) =>
                {
                    MessageBox.Show("Request sent successfully!");
                    this.Close();
                };

                this.Controls.Add(lblNote);
                this.Controls.Add(txtNote);
                this.Controls.Add(btnSend);
            }
        }

    }
}
