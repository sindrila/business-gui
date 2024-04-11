using bussiness_social_media.MVVM.Model.Repository;
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
        private IUserRepository _userRepository;
        private Dictionary<string, DateTime> _sessionTokens;
        private bool _isLoggedIn;
        private Timer _logoutTimer;
        private int _sessionDurationSeconds;
        private Account currentUser;

        public Account CurrentUser 
        { 
            get => currentUser; 
            set
            {
                currentUser = value;
 
            }
        }


        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _sessionTokens = new Dictionary<string, DateTime>();
            _isLoggedIn = false;
            //_logoutTimer = new Timer(LogoutUser, null, Timeout.Infinite, Timeout.Infinite);
            _sessionDurationSeconds = 10;
        }

        public bool getIsLoggedIn()
        {
            return _isLoggedIn;
        }

        public bool AuthenticateUser(string username, string password)
        {
            password = _userRepository.GetMd5Hash(password);

            if (_userRepository.IsCredentialsValid(username, password))
            {
                string sessionToken = Guid.NewGuid().ToString();
                _sessionTokens.Add(sessionToken, DateTime.Now);
                _isLoggedIn = true;

                // Start the logout timer
                _logoutTimer.Change(_sessionDurationSeconds * 1000, Timeout.Infinite);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LogoutUser(object state)
        {
            _isLoggedIn = false;
            Console.WriteLine("\nUser has been logged out automatically.");
        }

        public List<Account> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

    }
}

