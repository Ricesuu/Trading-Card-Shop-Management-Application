using System;
using System.Collections.Generic;
using System.Linq;

namespace PassTask13{
    /// <summary>
    /// Represents a user.
    /// </summary>
    public abstract class User
    {
        private string _username;
        private string _password;

        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        public User(string username, string password){
            _username = username;
            _password = password;
        }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string Username{
            get { return _username; }
        }

        /// <summary>
        /// Gets the password of the user.
        /// </summary>
        public string Password{
            get { return _password; }
        }
    }
}