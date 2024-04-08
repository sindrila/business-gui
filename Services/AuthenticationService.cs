using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

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

            LoadUsersFromJson();
        }

        public bool getIsLoggedIn()
        {
            return isLoggedIn;
        }

        public void AddManagedBusiness(string username, Business business)
        {
            Account user = users.Find(u => u.Username == username);
            if (user != null)
            {
                user.ManagedBusinesses.Add(business);
                SaveUsersToJson();
            }
            else
            {
                Console.WriteLine($"User '{username}' not found.");
            }
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

        private void LoadUsersFromJson()
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<Account>>(jsonData);
            }
            else
            {
                PopulateRepository();
                SaveUsersToJson();
            }
        }

        private void SaveUsersToJson()
        {
            string jsonData = JsonConvert.SerializeObject(users);
            File.WriteAllText(filePath, jsonData);
        }

        private void PopulateRepository()
        {
            users = new List<Account>();

            // Create mock businesses
            Business business1 = new Business(1, "Business 1", "Description 1", "Category 1", "Logo 1", "Banner 1", "123456789", "email@example.com", "www.business1.com", "Address 1", DateTime.Now);
            Business business2 = new Business(2, "Business 2", "Description 2", "Category 2", "Logo 2", "Banner 2", "987654321", "email2@example.com", "www.business2.com", "Address 2", DateTime.Now);

            // Create mock accounts with managed businesses
            Account Account1 = new Account
            {
                Username = "john_doe",
                Password = GetMd5Hash("password123"),
                ManagedBusinesses = new List<Business> { business1, business2 }
            };
            users.Add(Account1);

            Account Account2 = new Account
            {
                Username = "alice_smith",
                Password = GetMd5Hash("qwerty456"),
                ManagedBusinesses = new List<Business> { business1 }
            };
            users.Add(Account2);

            Account Account3 = new Account
            {
                Username = "bob_jackson",
                Password = GetMd5Hash("abc123"),
                ManagedBusinesses = new List<Business> { business2 }
            };
            users.Add(Account3);
        }

        private bool IsCredentialsValid(string username, string password)
        {
            return users.Exists(u => u.Username == username && u.Password == password);
        }

        // Method to compute MD5 hash
        private string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }

}

