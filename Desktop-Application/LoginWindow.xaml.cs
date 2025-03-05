using System.Windows;

namespace HotelMS
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Validate credentials (you can replace this with a database check)
            if (username == "admin" && password == "1234")
            {
                // Open the MainWindow
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                // Close the LoginWindow
                this.Close();
            }
            else
            {
                // Show error message
                ErrorMessage.Text = "Invalid username or password.";
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}