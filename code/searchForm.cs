using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace MedicineDonationApp
{
    public partial class SearchForm : Form
    {
        private List<Medicine> availableMedicines;

        public SearchForm()
        {
            InitializeComponent();
            LoadSearchForm();
            LoadMockMedicines(); // Replace with real data later
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void LoadSearchForm()
        {
            this.Text = "Search Medicines";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label lblFilters = new Label() { Text = "Filters", Location = new Point(20, 20), Font = new Font("Arial", 12, FontStyle.Bold) };

            Label lblFrom = new Label() { Text = "From:", Location = new Point(20, 60) };
            DateTimePicker dtFrom = new DateTimePicker() { Location = new Point(80, 60) };

            Label lblTo = new Label() { Text = "To:", Location = new Point(280, 60) };
            DateTimePicker dtTo = new DateTimePicker() { Location = new Point(330, 60) };

            Label lblAge = new Label() { Text = "Age Group:", Location = new Point(20, 100) };
            ComboBox cmbAge = new ComboBox() { Location = new Point(100, 100), Width = 100 };
            cmbAge.Items.AddRange(new[] { "Any", "0-18", "19-40", "40+" });
            cmbAge.SelectedIndex = 0;

            Label lblGender = new Label() { Text = "Gender:", Location = new Point(220, 100) };
            ComboBox cmbGender = new ComboBox() { Location = new Point(290, 100), Width = 100 };
            cmbGender.Items.AddRange(new[] { "Any", "Male", "Female" });
            cmbGender.SelectedIndex = 0;

            Button btnSearch = new Button() { Text = "Search", Location = new Point(450, 100) };
            btnSearch.Click += (s, e) =>
            {
                DateTime from = dtFrom.Value;
                DateTime to = dtTo.Value;
                string ageGroup = cmbAge.SelectedItem.ToString();
                string gender = cmbGender.SelectedItem.ToString();

                var results = FilterMedicines(from, to, ageGroup, gender);
                ShowResults(results);
            };

            this.Controls.Add(lblFilters);
            this.Controls.Add(lblFrom);
            this.Controls.Add(dtFrom);
            this.Controls.Add(lblTo);
            this.Controls.Add(dtTo);
            this.Controls.Add(lblAge);
            this.Controls.Add(cmbAge);
            this.Controls.Add(lblGender);
            this.Controls.Add(cmbGender);
            this.Controls.Add(btnSearch);
        }

        private void LoadMockMedicines()
        {
            availableMedicines = new List<Medicine>
            {
                new Medicine { Name = "Paracetamol", Date = DateTime.Today.AddDays(-1), AgeGroup = "19-40", Gender = "Any" },
                new Medicine { Name = "Amoxicillin", Date = DateTime.Today.AddDays(-10), AgeGroup = "0-18", Gender = "Any" },
                new Medicine { Name = "Ibuprofen", Date = DateTime.Today, AgeGroup = "40+", Gender = "Female" },
            };
        }

        private List<Medicine> FilterMedicines(DateTime from, DateTime to, string ageGroup, string gender)
        {
            return availableMedicines.Where(m =>
                m.Date >= from && m.Date <= to &&
                (ageGroup == "Any" || m.AgeGroup == ageGroup) &&
                (gender == "Any" || m.Gender == gender)).ToList();
        }

        private void ShowResults(List<Medicine> results)
        {
            string resultText = string.Join("\n", results.Select(m => $"{m.Name} - {m.Date.ToShortDateString()} - {m.AgeGroup} - {m.Gender}"));
            MessageBox.Show(resultText.Length > 0 ? resultText : "No results found.");
        }

        private class Medicine
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public string AgeGroup { get; set; }
            public string Gender { get; set; }
        }
    }
}
