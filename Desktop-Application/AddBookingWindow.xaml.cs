using System;
using System.Linq;
using System.Windows;

namespace HotelMS
{
    public partial class AddBookingWindow : Window
    {
        public Booking NewBooking { get; private set; }
        private HotelDbContext _dbContext;

        public AddBookingWindow(HotelDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            LoadAvailableRooms();
            LoadGuests();
        }

        private void LoadAvailableRooms()
        {
            // Load rooms that are not occupied
            var availableRooms = _dbContext.Rooms.Where(r => !r.IsOccupied).ToList();
            RoomComboBox.ItemsSource = availableRooms;
        }

        private void LoadGuests()
        {
            // Load all guests
            var guests = _dbContext.Guests.ToList();
            GuestComboBox.ItemsSource = guests;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            if (RoomComboBox.SelectedItem is not Room selectedRoom ||
                GuestComboBox.SelectedItem is not Guest selectedGuest ||
                CheckInDatePicker.SelectedDate == null ||
                CheckOutDatePicker.SelectedDate == null ||
                !decimal.TryParse(TotalCostTextBox.Text, out decimal totalCost))
            {
                MessageBox.Show("Please enter valid booking details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new booking object
            NewBooking = new Booking
            {
                RoomId = selectedRoom.RoomId,
                GuestId = selectedGuest.GuestId,
                CheckInDate = CheckInDatePicker.SelectedDate.Value,
                CheckOutDate = CheckOutDatePicker.SelectedDate.Value,
                TotalCost = totalCost
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
