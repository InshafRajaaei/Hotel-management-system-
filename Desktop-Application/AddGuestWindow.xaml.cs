using System;
using System.Windows;

namespace HotelMS
{
    public partial class AddGuestWindow : Window
    {
        public Guest NewGuest { get; private set; }

        public AddGuestWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            if (!int.TryParse(GuestIdTextBox.Text, out int guestId) ||
                string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Please enter valid guest details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new guest object
            NewGuest = new Guest
            {
                GuestId = guestId,
                Name = NameTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                Email = EmailTextBox.Text
            };

            // Close the window
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