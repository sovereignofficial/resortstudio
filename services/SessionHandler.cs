using Newtonsoft.Json;
using ResortStudio.entity;
using Supabase.Gotrue;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ResortStudio.services
{
    public class ExtendedSession : Supabase.Gotrue.Session
    {
        public DateTime ExtendedExpiresAt { get; set; }
    }

    public class SessionHandler
    {
        public static void CreateNewSession(Supabase.Gotrue.Session session, Supabase.Gotrue.User user)
        {
            var extendedSession = new ExtendedSession
            {
                AccessToken = session.AccessToken,
                RefreshToken = session.RefreshToken,
                CreatedAt = session.CreatedAt,
                ExtendedExpiresAt = session.ExpiresAt(),
                User = session.User
            };
            // Add 30 days to the session expiry date
            extendedSession.ExtendedExpiresAt = session.ExpiresAt().AddDays(30);

            // Serialize and save the updated session
            File.WriteAllText("./session.txt", JsonConvert.SerializeObject(extendedSession));

            // Serialize and save the user
            File.WriteAllText("./user.txt", JsonConvert.SerializeObject(user));
        }
        public static Session RetrieveSession()
        {
            var sessionString = File.ReadAllText("./session.txt");
            var session = JsonConvert.DeserializeObject<ExtendedSession>(sessionString);
            DateTime now = DateTime.Now;
            if (now > session.ExtendedExpiresAt)
            {
                throw new Exception("Session expired.");
            }
            return session;
        }
        public static User RetrieveUser()
        {
            var userString = File.ReadAllText("./user.txt");
            var user = JsonConvert.DeserializeObject<User>(userString);
            return user;
        }
        public static void RemoveSession()
        {
            File.Delete("user.txt");
            File.Delete("session.txt");
        }
        public static void ValidateUserLoggedInAndRedirect(Supabase.Client supabaseClient, ResortStudio.entity.Settings appSettings)
        {
            try
            {
                var session = SessionHandler.RetrieveSession();
                var user = SessionHandler.RetrieveUser();

                if (user != null)
                {
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow.RSContentArea.Content = new ResortStudio.AppView(supabaseClient, appSettings);
                }
                else
                {
                    throw new Exception("User is null!");
                }

            }
            catch (Exception e)
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.RSContentArea.Content = new ResortStudio.LoginView(supabaseClient,appSettings);
            }
        }
    }
}
