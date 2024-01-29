using ResortStudio.entity;
using ResortStudio.services;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ResortStudio
{
    /// <summary>
    /// Interaction logic for AppView.xaml
    /// </summary>
    public partial class AppView : UserControl
    {
        private Supabase.Client supabaseClient;
        private Settings appSettings;

        public AppView(Supabase.Client sc, Settings settings)
        {
            InitializeComponent();
            supabaseClient = sc;
            appSettings = settings;
            MainFrame.Navigate(new DashboardPage(supabaseClient));
        }

        private void NavigateToDashboard(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DashboardPage(supabaseClient));
        }

        private void NavigateToBookings(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BookingsPage(supabaseClient, appSettings));

        }

        private void NavigateToCabins(object sender, RoutedEventArgs e)
        {

            MainFrame.Navigate(new CabinsPage(supabaseClient));

        }

        private void NavigateToUsers(object sender, RoutedEventArgs e)
        {

            MainFrame.Navigate(new UsersPage(supabaseClient));

        }

        private void NavigateToSettings(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SettingsPage(supabaseClient, appSettings));

        }

        private void NavigateToGuests(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GuestsPage(supabaseClient));

        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scrollViewer = (ScrollViewer)sender;
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void NavigateToAccount(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AccountPage(supabaseClient));
        }

        private void HandleLogOut(object sender, RoutedEventArgs e)
        {
            SessionHandler.RemoveSession();
            SessionHandler.ValidateUserLoggedInAndRedirect(supabaseClient, appSettings);
        }
    }
}
