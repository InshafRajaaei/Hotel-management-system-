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
            DataContext = Room; 
            RoomTypeComboBox.SelectedValue = Room.RoomType;
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

            Room.RoomType = RoomTypeComboBox.SelectedValue.ToString();
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