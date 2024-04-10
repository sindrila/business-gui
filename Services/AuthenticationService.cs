using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
/*
namespace business_social_media.Services
{

    

    public class AuthenticationService 
    {
        private List<Account> users;
        private Dictionary<string, DateTime> sessionTokens;
        private bool isLoggedIn;
        private Timer logoutTimer;
        private int sessionDurationSeconds;
        private string filePath = "acounts.json";

        public AuthenticationService()
        {
            sessionTokens = new Dictionary<string, DateTime>();
            isLoggedIn = false;
            logoutTimer = new Timer(LogoutUser, null, Timeout.Infinite, Timeout.Infinite);
            sessionDurationSeconds = 10;

        }

        public bool getIsLoggedIn()
        {
            return isLoggedIn;
        }


        public bool AuthenticateUser(string username, string password)
        {
            password = GetMd5Hash(password);

            if (IsCredentialsValid(username, password))
            {
                string sessionToken = Guid.NewGuid().ToString();
                sessionTokens.Add(sessionToken, DateTime.Now);
                isLoggedIn = true;

                // Start the logout timer
                logoutTimer.Change(sessionDurationSeconds * 1000, Timeout.Infinite);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LogoutUser(object state)
        {
            isLoggedIn = false;
            Console.WriteLine("\nUser has been logged out automatically.");
        }

        public List<Account> GetAllUsers()
        {
            return users;
        }

    }

}
*/
