namespace MedicineDonationApp
{
    // Example usage in the main application flow
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationManager.AddNotification("New medicine request received.");
            NotificationManager.ShowNotifications();
        }
    }
}
