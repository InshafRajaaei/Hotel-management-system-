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
            var guests = _dbContext.Guests.ToList();
            GuestsGrid.ItemsSource = guests;
        }
        private void AddGuest_Click(object sender, RoutedEventArgs e)
        {
            var addGuestWindow = new AddGuestWindow();
            if (addGuestWindow.ShowDialog() == true)
            {
                _dbContext.Guests.Add(addGuestWindow.NewGuest);
                _dbContext.SaveChanges();
                LoadGuestsData();
            }
        }
        private void EditGuest_Click(object sender, RoutedEventArgs e)
        {
            if (GuestsGrid.SelectedItem is Guest selectedGuest)
            {
                var editGuestWindow = new EditGuestWindow(selectedGuest);
                if (editGuestWindow.ShowDialog() == true)
                {
                    _dbContext.SaveChanges();
                    LoadGuestsData();
                }
            }
        }
        private void DeleteGuest_Click(object sender, RoutedEventArgs e)
        {
            if (GuestsGrid.SelectedItem is Guest selectedGuest)
            {
                var result = MessageBox.Show("Are you sure you want to delete this guest?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _dbContext.Guests.Remove(selectedGuest);
                    _dbContext.SaveChanges();
                    LoadGuestsData();
                }
            }
        }
    }
}