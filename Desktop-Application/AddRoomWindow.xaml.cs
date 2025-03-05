using System;
using System.Windows;

namespace HotelMS
{
    public partial class AddRoomWindow : Window
    {
        public Room NewRoom { get; private set; }

        public AddRoomWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(RoomNumberTextBox.Text) ||
                RoomTypeComboBox.SelectedValue == null ||
                !decimal.TryParse(PricePerNightTextBox.Text, out decimal pricePerNight))
            {
                MessageBox.Show("Please enter valid room details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new room object
            NewRoom = new Room
            {
                RoomNumber = RoomNumberTextBox.Text,
                RoomType = RoomTypeComboBox.SelectedValue.ToString(), // Bind selected room type
                PricePerNight = pricePerNight,
                IsOccupied = false
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