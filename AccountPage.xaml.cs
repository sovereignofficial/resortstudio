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
    /// <summary>
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        Client supabase;

        private Supabase.Gotrue.User user;
        public AccountPage(Client sc)
        {
            InitializeComponent();
            supabase = sc;
            user = SessionHandler.RetrieveUser();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                AvatarImg.Source = new BitmapImage(new Uri(user.UserMetadata["avatar"].ToString()));
                tbAvatarUrl.Text = user.UserMetadata["avatar"].ToString();
                tbName.Text = user.UserMetadata["fullName"].ToString();
                tbEmail.Text = user.Email;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
