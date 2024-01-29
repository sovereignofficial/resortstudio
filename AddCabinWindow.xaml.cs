using Newtonsoft.Json;
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
using System.Windows.Shapes;

namespace ResortStudio
{
    /// <summary>
    /// Interaction logic for AddCabinWindow.xaml
    /// </summary>
    public partial class AddCabinWindow : Window
    {
        private Cabin newCabin;
        private CabinService service;
        private Client supabase;

        public AddCabinWindow(Client supabaseClient)
        {
            InitializeComponent();
            newCabin = new Cabin();
            this.DataContext = newCabin;
            supabase = supabaseClient;
            service = new CabinService();
        }


        private async void AddCabin(object sender, RoutedEventArgs e)
        {
            try
            {
                if(newCabin != null)
                {
                    string formattedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffzzz");
                    newCabin.CreatedAt = formattedDate;
                    await service.CreateCabin(supabase, newCabin);
                    MessageBox.Show($"New cabin {newCabin.Name} created successfully.");
                }
                else
                {
                    throw new Exception("Something went wrong!");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
