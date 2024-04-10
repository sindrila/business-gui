using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
/*
namespace bussiness_social_media.MVVM.Model.Repository
{
    public class UserRepository
    {
        private string _xmlFilePath;
        private List<Account> _users;

        public UserRepository(string xmlFilePATH)
        {
            _users = new List<Account>();
            _xmlFilePath = xmlFilePATH;
            LoadUsersFromJson();
        }

        // Some hard coded users
        public void populateRepository()
        {
            Account Account1 = new Account
            (
                "john_doe",
                GetMd5Hash("password123")
            );
            _users.Add(Account1);

            Account Account2 = new Account
            (
                "alice_smith",
                GetMd5Hash("qwerty456")
            );
            _users.Add(Account2);

            Account Account3 = new Account
            (
                "bob_jackson",
                GetMd5Hash("abc123")
            );
            _users.Add(Account3);

            Account Account4 = new Account
            (
                "ana_maria",
                GetMd5Hash("8a8n8a9")
            );
            _users.Add(Account4);

            Account Account5 = new Account
            (
                "kevin_smith",
                GetMd5Hash("k3vin")
            );
            _users.Add(Account5);

        }

        public void AddAccount(Account user)
        {
            _users.Add(user);
        }

        public void DeleteUser(string username)
        {
            Account userToRemove = _users.Find(u => u.Username == username);
            if (userToRemove != null)
            {
                _users.Remove(userToRemove);
                SaveUsersToJson();
            }
        }

        public bool UsernameExists(string username)
        {
            return _users.Exists(u => u.Username == username);
        }

        public bool IsCredentialsValid(string username, string password)
        {
            return _users.Exists(u => u.Username == username && u.Password == password);
        }

        public List<Account> GetAllUsers()
        {
            return _users;
        }

        // Method to compute MD5 hash
        public string GetMd5Hash(string input)
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
*/