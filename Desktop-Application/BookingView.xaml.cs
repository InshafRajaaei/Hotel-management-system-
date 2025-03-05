using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace HotelMS
{
    public partial class BookingsView : UserControl
    {
        private HotelDbContext _dbContext;

        public BookingsView()
        {
            InitializeComponent();
            _dbContext = new HotelDbContext();
            LoadBookingsData();
        }

        private void LoadBookingsData()
        {
            try
            {
                // Load bookings data from the database
                var bookings = _dbContext.Bookings
                    .Include(b => b.Room) // Include related Room data
                    .Include(b => b.Guest) // Include related Guest data
                    .ToList();
                BookingsGrid.ItemsSource = bookings;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddBooking_Click(object sender, RoutedEventArgs e)
        {
            // Open the AddBookingWindow
            var addBookingWindow = new AddBookingWindow(_dbContext);
            if (addBookingWindow.ShowDialog() == true)
            {
                try
                {
                    // Add the new booking to the database
                    _dbContext.Bookings.Add(addBookingWindow.NewBooking);
                    _dbContext.SaveChanges();

                    // Refresh the data
                    LoadBookingsData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving booking: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditBooking_Click(object sender, RoutedEventArgs e)
        {
            if (BookingsGrid.SelectedItem is Booking selectedBooking)
            {
                // Open the EditBookingWindow with the selected booking
                var editBookingWindow = new EditBookingWindow(selectedBooking, _dbContext);
                if (editBookingWindow.ShowDialog() == true)
                {
                    // Save changes to the database
                    _dbContext.SaveChanges();

                    // Refresh the data
                    LoadBookingsData();
                }
            }
        }

        private void DeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            if (BookingsGrid.SelectedItem is Booking selectedBooking)
            {
                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete this booking?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    // Remove the booking from the database
                    _dbContext.Bookings.Remove(selectedBooking);
                    _dbContext.SaveChanges();

                    // Refresh the data
                    LoadBookingsData();
                }
            }
        }
    }
}