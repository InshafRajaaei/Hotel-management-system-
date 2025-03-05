using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace HotelMS
{
    public partial class RoomsView : UserControl
    {
        private HotelDbContext _dbContext;

        public RoomsView()
        {
            InitializeComponent();
            _dbContext = new HotelDbContext();
            LoadRoomsData();
        }

        private void LoadRoomsData()
        {
            try
            {
                // Load rooms data from the database
                var rooms = _dbContext.Rooms.ToList();
                RoomsGrid.ItemsSource = rooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            // Open the AddRoomWindow
            var addRoomWindow = new AddRoomWindow();
            if (addRoomWindow.ShowDialog() == true)
            {
                try
                {
                    // Add the new room to the database
                    _dbContext.Rooms.Add(addRoomWindow.NewRoom);
                    _dbContext.SaveChanges();

                    // Refresh the data
                    LoadRoomsData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving room: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditRoom_Click(object sender, RoutedEventArgs e)
        {
            if (RoomsGrid.SelectedItem is Room selectedRoom)
            {
                // Open the EditRoomWindow with the selected room
                var editRoomWindow = new EditRoomWindow(selectedRoom);
                if (editRoomWindow.ShowDialog() == true)
                {
                    // Save changes to the database
                    _dbContext.SaveChanges();

                    // Refresh the data
                    LoadRoomsData();
                }
            }
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (RoomsGrid.SelectedItem is Room selectedRoom)
            {
                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete this room?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    // Remove the room from the database
                    _dbContext.Rooms.Remove(selectedRoom);
                    _dbContext.SaveChanges();

                    // Refresh the data
                    LoadRoomsData();
                }
            }
        }
    }
}