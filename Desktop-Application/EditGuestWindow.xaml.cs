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
            DataContext = Guest; 
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Please enter valid guest details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
            Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}