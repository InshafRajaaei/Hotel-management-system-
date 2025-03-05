using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace HotelMS
{
    public partial class GuestsView : UserControl
    {
        private HotelDbContext _dbContext = new HotelDbContext();

        public GuestsView()
        {
            InitializeComponent();
            LoadGuestsData();
        }

        private void LoadGuestsData()
        {
            // Load guests data from the database
            var guests = _dbContext.Guests.ToList();
            GuestsGrid.ItemsSource = guests;
        }

        private void AddGuest_Click(object sender, RoutedEventArgs e)
        {
            // Open the AddGuestWindow
            var addGuestWindow = new AddGuestWindow();
            if (addGuestWindow.ShowDialog() == true)
            {
                // Add the new guest to the database
                _dbContext.Guests.Add(addGuestWindow.NewGuest);
                _dbContext.SaveChanges();

                // Refresh the data
                LoadGuestsData();
            }
        }

        private void EditGuest_Click(object sender, RoutedEventArgs e)
        {
            if (GuestsGrid.SelectedItem is Guest selectedGuest)
            {
                // Open the EditGuestWindow with the selected guest
                var editGuestWindow = new EditGuestWindow(selectedGuest);
                if (editGuestWindow.ShowDialog() == true)
                {
                    // Save changes to the database
                    _dbContext.SaveChanges();

                    // Refresh the data
                    LoadGuestsData();
                }
            }
        }

        private void DeleteGuest_Click(object sender, RoutedEventArgs e)
        {
            if (GuestsGrid.SelectedItem is Guest selectedGuest)
            {
                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete this guest?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    // Remove the guest from the database
                    _dbContext.Guests.Remove(selectedGuest);
                    _dbContext.SaveChanges();

                    // Refresh the data
                    LoadGuestsData();
                }
            }
        }
    }
}