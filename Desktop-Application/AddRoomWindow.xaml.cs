using System;
using System.Windows;

namespace HotelMS
{
    public partial class AddRoomWindow : Window
    {
        public Room? NewRoom { get; private set; }
        public AddRoomWindow()
        {
            InitializeComponent();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RoomNumberTextBox.Text) ||
                RoomTypeComboBox.SelectedValue == null ||
                !decimal.TryParse(PricePerNightTextBox.Text, out decimal pricePerNight))
            {
                MessageBox.Show("Please enter valid room details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewRoom = new Room
            {
                RoomNumber = RoomNumberTextBox.Text,
                RoomType = RoomTypeComboBox.SelectedValue.ToString(), 
                PricePerNight = pricePerNight,
                IsOccupied = false
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