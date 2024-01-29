using ResortStudio.services;
using Supabase;
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
    public partial class UsersPage : Page
    {
        private Client supabase;
        static readonly Regex emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        static readonly Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$");

        static readonly Regex fullNameRegex = new Regex(@"^[A-Z][a-z]*\s[A-Z][a-z]*$");



        public UsersPage(Client sc)
        {
            InitializeComponent();
            supabase = sc;
        }

        public static bool IsValidFullName(string fullName)
        {
            return fullNameRegex.IsMatch(fullName);
        }

        public static bool IsValidEmail(string email)
        {
            return emailRegex.IsMatch(email);
        }

        public static bool IsValidPassword(string password)
        {
            return passwordRegex.IsMatch(password);
        }

        private void ClearInputs(object sender, RoutedEventArgs e)
        {
            tbEmail.Text = "";
            tbPassword.Password = "";
        }

        private async void CreateUser(object sender, RoutedEventArgs e)
        {
            try
            {
                string password = tbPassword.Password;
                string email = tbEmail.Text;

                if (!IsValidEmail(email))
                {
                    throw new Exception("Please type valid email!");
                }
                if (!IsValidPassword(password))
                {
                    throw new Exception("Invalid password! Password must contain at least one uppercase letter, one digit, one special character, and be at least 8 characters long.");
                }
                await supabase.Auth.SignUp(email, password);
                MessageBox.Show("User created successfully.A confirmation email will be sent to your inbox within a few minutes.Please confirm your email to be signed in!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
