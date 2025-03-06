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
                var bookings = _dbContext.Bookings
                    .Include(b => b.Room) 
                    .Include(b => b.Guest) 
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
            var addBookingWindow = new AddBookingWindow(_dbContext);
            if (addBookingWindow.ShowDialog() == true)
            {
                try
                {
                    _dbContext.Bookings.Add(addBookingWindow.NewBooking);
                    _dbContext.SaveChanges();
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
                var editBookingWindow = new EditBookingWindow(selectedBooking, _dbContext);
                if (editBookingWindow.ShowDialog() == true)
                {
                    _dbContext.SaveChanges();
                    LoadBookingsData();
                }
            }
        }
        private void DeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            if (BookingsGrid.SelectedItem is Booking selectedBooking)
            {
                var result = MessageBox.Show("Are you sure you want to delete this booking?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _dbContext.Bookings.Remove(selectedBooking);
                    _dbContext.SaveChanges();
                    LoadBookingsData();
                }
            }
        }
    }
}