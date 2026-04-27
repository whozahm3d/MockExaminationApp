using System;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MedicineDonationApp;
using System.Windows.Forms;

namespace MedicineDonationApp
{
    public class MedicineRepository
    {
        // Replace the old connection string with the new one
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=MedicineDonationDB;Integrated Security=True;";

        public void AddMedicine(string medicineName, int quantity, DateTime expiryDate)
        {
           // using (SqlConnection conn = new SqlConnection(connectionString))
            {
               // conn.Open();
                string query = "INSERT INTO Medicines (MedicineName, Quantity, ExpiryDate) VALUES (@MedicineName, @Quantity, @ExpiryDate)";
               // using (SqlCommand cmd = new SqlCommand(query, conn))
               // {
                    //cmd.Parameters.AddWithValue("@MedicineName", medicineName);
                    //cmd.Parameters.AddWithValue("@Quantity", quantity);
                    //cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                  //  cmd.ExecuteNonQuery();
                //}
            }
        }

        public DataTable GetMedicinesToVerify()
        {
            DataTable dt = new DataTable();
            //using (SqlConnection conn = new SqlConnection(connectionString))
            {
               // conn.Open();
                string query = "SELECT MedicineId, MedicineName, Quantity, ExpiryDate, Status FROM Medicines WHERE Status = 'Pending'";
                //using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                //{
                  //  da.Fill(dt);
                //}
            }
            return dt;
        }

        public void UpdateMedicineStatus(int medicineId, string status)
        {
           // using (SqlConnection conn = new SqlConnection(connectionString))
            {
               // conn.Open();
                string query = "UPDATE Medicines SET Status = @Status WHERE MedicineId = @MedicineId";
                //using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                  //  cmd.Parameters.AddWithValue("@MedicineId", medicineId);
                    //cmd.Parameters.AddWithValue("@Status", status);
                    //cmd.ExecuteNonQuery();
                }
            }
        }
    }
}