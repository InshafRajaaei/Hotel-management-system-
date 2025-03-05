using System.Windows;

namespace HotelMS
{
    public partial class EditGuestWindow : Window
    {
        public Guest Guest { get; private set; }

        public EditGuestWindow(Guest guest)
        {
            InitializeComponent();
            Guest = guest;
            DataContext = Guest; // Bind the guest data to the UI
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Please enter valid guest details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Close the window and indicate success
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without saving
            DialogResult = false;
            Close();
        }
    }
}