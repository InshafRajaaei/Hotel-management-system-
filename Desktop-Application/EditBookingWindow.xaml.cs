using System;
using System.Linq;
using System.Windows;

namespace HotelMS
{
    public partial class EditBookingWindow : Window
    {
        public Booking Booking { get; private set; }
        private HotelDbContext _dbContext;

        public EditBookingWindow(Booking booking, HotelDbContext dbContext)
        {
            InitializeComponent();
            Booking = booking;
            _dbContext = dbContext;
            DataContext = Booking; // Bind the booking data to the UI
            LoadAvailableRooms();
            LoadGuests();
        }
        


        private void LoadAvailableRooms()
        {
            // Load rooms that are not occupied
            var availableRooms = _dbContext.Rooms.Where(r => !r.IsOccupied).ToList();
            RoomComboBox.ItemsSource = availableRooms;
            RoomComboBox.SelectedItem = availableRooms.FirstOrDefault(r => r.RoomId == Booking.RoomId);
        }

        private void LoadGuests()
        {
            // Load all guests
            var guests = _dbContext.Guests.ToList();
            GuestComboBox.ItemsSource = guests;
            GuestComboBox.SelectedItem = guests.FirstOrDefault(g => g.GuestId == Booking.GuestId);
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

            // Update the booking object
            Booking.RoomId = selectedRoom.RoomId;
            Booking.GuestId = selectedGuest.GuestId;
            Booking.CheckInDate = CheckInDatePicker.SelectedDate.Value;
            Booking.CheckOutDate = CheckOutDatePicker.SelectedDate.Value;
            Booking.TotalCost = totalCost;

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