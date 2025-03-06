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
            var addRoomWindow = new AddRoomWindow();
            if (addRoomWindow.ShowDialog() == true)
            {
                try
                {
                    _dbContext.Rooms.Add(addRoomWindow.NewRoom);
                    _dbContext.SaveChanges();
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
                var editRoomWindow = new EditRoomWindow(selectedRoom);
                if (editRoomWindow.ShowDialog() == true)
                {
                    _dbContext.SaveChanges();
                    LoadRoomsData();
                }
            }
        }
        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (RoomsGrid.SelectedItem is Room selectedRoom)
            {
                var result = MessageBox.Show("Are you sure you want to delete this room?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _dbContext.Rooms.Remove(selectedRoom);
                    _dbContext.SaveChanges();
                    LoadRoomsData();
                }
            }
        }
    }
}