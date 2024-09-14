namespace Masstransit.Publisher.Windows.Forms
{
    public static class Alert
    {
        public static void Show(string message,string title, MessageBoxButtons button, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, button, icon);
        }
    }
}
