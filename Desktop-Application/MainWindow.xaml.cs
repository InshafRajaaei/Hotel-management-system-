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
            TabButton_Click(RoomsButton, new RoutedEventArgs());
        }
        private void TabButton_Click(object sender, RoutedEventArgs? e)
        {
            RoomsButton.Background = Brushes.Transparent;
            GuestsButton.Background = Brushes.Transparent;
            BookingsButton.Background = Brushes.Transparent;

            if (sender is Button clickedButton)
            {
                clickedButton.Background = new SolidColorBrush(Color.FromRgb(52, 152, 219));
            }
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
                ContentArea.Content = new UserControl(); 
            }
        }
    }
}