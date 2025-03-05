using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HotelMS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set the default tab (Rooms)
            TabButton_Click(RoomsButton, new RoutedEventArgs());
        }

        private void TabButton_Click(object sender, RoutedEventArgs? e)
        {
            // Reset the background of all buttons
            RoomsButton.Background = Brushes.Transparent;
            GuestsButton.Background = Brushes.Transparent;
            BookingsButton.Background = Brushes.Transparent;

            // Change the background of the clicked button
            if (sender is Button clickedButton)
            {
                clickedButton.Background = new SolidColorBrush(Color.FromRgb(52, 152, 219)); // Light blue color
            }

            // Load the appropriate content
            if (sender == RoomsButton)
            {
                ContentArea.Content = new RoomsView();
            }
            else if (sender == GuestsButton)
            {
                ContentArea.Content = new GuestsView();
            }
            else if (sender == BookingsButton)
            {
                ContentArea.Content = new BookingsView();
            }
            else
            {
                // Handle the case where sender is not one of the expected buttons
                ContentArea.Content = new UserControl(); // Assign a default or empty control
            }
        }
    }
}