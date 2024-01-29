using Newtonsoft.Json;
using ResortStudio.entity;
using ResortStudio.services;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {

        Supabase.Client supabase;
        static readonly Regex emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        static readonly Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$");
        private Settings appSettings;

        public LoginView(Supabase.Client sc, Settings settings)
        {
            supabase = sc;
            appSettings = settings;

            InitializeComponent();
        }

        public static bool IsValidEmail(string email)
        {
            return emailRegex.IsMatch(email);
        }

        public static bool IsValidPassword(string password)
        {
            return passwordRegex.IsMatch(password);
        }

        private async void SignInToYourAccount(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = tbEmail.Text;
                string password = tbPassword.Password;

                if (!IsValidEmail(email))
                {
                    throw new Exception("Please type a valid email!");
                }
                if (!IsValidPassword(password))
                {
                    throw new Exception("Invalid password! Password must contain at least one uppercase letter, one digit, one special character, and be at least 8 characters long.");
                }
                await supabase.Auth.SignInWithPassword(email, password);
                var user = supabase.Auth.CurrentUser;
                var session = supabase.Auth.CurrentSession;

                SessionHandler.CreateNewSession(session, user);
                SessionHandler.ValidateUserLoggedInAndRedirect(supabase, appSettings);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
