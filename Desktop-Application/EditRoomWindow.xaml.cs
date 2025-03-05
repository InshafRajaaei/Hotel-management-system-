using System.Windows;

namespace HotelMS
{
    public partial class EditRoomWindow : Window
    {
        public Room Room { get; private set; }

        public EditRoomWindow(Room room)
        {
            InitializeComponent();
            Room = room;
            DataContext = Room; // Bind the room data to the UI

            // Set the selected room type in the ComboBox
            RoomTypeComboBox.SelectedValue = Room.RoomType;
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

            // Update the room type
            Room.RoomType = RoomTypeComboBox.SelectedValue.ToString();

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