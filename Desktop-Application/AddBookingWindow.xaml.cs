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
            var availableRooms = _dbContext.Rooms.Where(r => !r.IsOccupied).ToList();
            RoomComboBox.ItemsSource = availableRooms;
        }
        private void LoadGuests()
        {
            var guests = _dbContext.Guests.ToList();
            GuestComboBox.ItemsSource = guests;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (RoomComboBox.SelectedItem is not Room selectedRoom ||
                GuestComboBox.SelectedItem is not Guest selectedGuest ||
                CheckInDatePicker.SelectedDate == null ||
                CheckOutDatePicker.SelectedDate == null ||
                !decimal.TryParse(TotalCostTextBox.Text, out decimal totalCost))
            {
                MessageBox.Show("Please enter valid booking details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewBooking = new Booking
            {
                RoomId = selectedRoom.RoomId,
                GuestId = selectedGuest.GuestId,
                CheckInDate = CheckInDatePicker.SelectedDate.Value,
                CheckOutDate = CheckOutDatePicker.SelectedDate.Value,
                TotalCost = totalCost
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
