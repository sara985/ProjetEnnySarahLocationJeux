using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections;

namespace ProjetEnnySarahLocationJeux.POCO
{
    abstract class User
    {
        private string username;
        private string password;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public void CalculateSHA256()
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] hashValue;
            UTF8Encoding objUtf8 = new UTF8Encoding();
            hashValue = sha256.ComputeHash(objUtf8.GetBytes(Password));
            MessageBox.Show(hashValue.ToString());
            password = Convert.ToBase64String(hashValue);
        }

        public abstract User Login(string email, string password);
    }
}
