using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection.Metadata;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfSharp;

namespace MedicineDonationApp
{
    public partial class MedicineListForm : Form
    {
        private DataGridView dgvMedicines;
        private Button btnExportPdf;

        public MedicineListForm()
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
            this.Text = "Medicine Listings";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            dgvMedicines = new DataGridView()
            {
                Location = new Point(20, 20),
                Size = new Size(540, 250),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgvMedicines.DataSource = GetSampleData(); // Replace with real data source

            btnExportPdf = new Button()
            {
                Text = "Export to PDF",
                Location = new Point(20, 290),
                Size = new Size(150, 30),
                BackColor = Color.Blue,
                ForeColor = Color.White
            };

            btnExportPdf.Click += (s, e) => ExportToPDF();

            this.Controls.Add(dgvMedicines);
            this.Controls.Add(btnExportPdf);
        }

        private DataTable GetSampleData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Medicine Name");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Expiry Date");

            dt.Rows.Add("Paracetamol", "10", "2025-06-30");
            dt.Rows.Add("Ibuprofen", "5", "2024-12-15");

            return dt;
        }

        private void ExportToPDF()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF File|*.pdf";
            saveFile.Title = "Save Medicine Listings";
            saveFile.FileName = "MedicineListings.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
                PdfWriter.GetInstance(doc, new FileStream(saveFile.FileName, FileMode.Create));
                doc.Open();

                PdfPTable table = new PdfPTable(dgvMedicines.Columns.Count);

                foreach (DataGridViewColumn column in dgvMedicines.Columns)
                {
                    table.AddCell(new Phrase(column.HeaderText));
                }

                foreach (DataGridViewRow row in dgvMedicines.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(cell.Value?.ToString());
                        }
                    }
                }

                doc.Add(table);
                doc.Close();

                MessageBox.Show("PDF Exported Successfully!", "Success");
            }
        }
    }
}
