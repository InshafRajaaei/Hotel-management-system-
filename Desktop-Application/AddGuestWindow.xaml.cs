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
            if (!int.TryParse(GuestIdTextBox.Text, out int guestId) ||
                string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Please enter valid guest details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewGuest = new Guest
            {
                GuestId = guestId,
                Name = NameTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                Email = EmailTextBox.Text
            };

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