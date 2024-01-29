using ResortStudio.entity;
using ResortStudio.services;
using Supabase;
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

    public partial class SettingsPage : Page
    {
        private Client supabase;
        private Settings appSettings;
        private SettingsService settingsService;

        public SettingsPage(Client sc, Settings settings)
        {
            InitializeComponent();
            supabase = sc;
            appSettings = settings;
            settingsService = new SettingsService();
            this.DataContext = appSettings;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Settings newSettings = new Settings
            {
                Id = appSettings.Id,
                CreatedAt = appSettings.CreatedAt,
                MinBookingLength = Int32.Parse(tbMinBookingLength.Text),
                MaxBookingLength = Int32.Parse(tbMaxBookingLength.Text),
                MaxGuestsPerBooking = Int32.Parse(tbMaxGuests.Text),
                BreakfastPrice = Int32.Parse(tbBreakfastPrice.Text),
            };
            try
            {
                await settingsService.UpdateSetting(supabase, newSettings);
                MessageBox.Show("Settings updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
