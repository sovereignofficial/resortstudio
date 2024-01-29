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
using Supabase;
using ResortStudio.services;
using ResortStudio.entity;
using Newtonsoft.Json;


namespace ResortStudio
{
    public partial class MainWindow : Window
    {
        private Supabase.Client supabaseClient;
        private SupabaseService supabaseService;
        private SettingsService settingsService;
        private Settings appSettings;

        public MainWindow()
        {

            InitializeComponent();
            string supabaseUrl = "YOUR-SUPABASE-URL";
            string supabaseApiKey = "your-supabase-api-key";
            Environment.SetEnvironmentVariable("SUPABASE_URL", supabaseUrl);
            Environment.SetEnvironmentVariable("SUPABASE_KEY", supabaseApiKey);
        }

        private async void OnLoaded (object sender, RoutedEventArgs e)
        {
            try
            {
                supabaseService = new SupabaseService();
                supabaseClient = await supabaseService.InitializeSupabaseClient();
                settingsService = new SettingsService();
                var settingsModels = await settingsService.GetAllSettings(supabaseClient);
                appSettings = settingsModels[0];
                SessionHandler.ValidateUserLoggedInAndRedirect(supabaseClient,appSettings);
               
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
