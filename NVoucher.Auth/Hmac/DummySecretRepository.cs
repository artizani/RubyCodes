using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NVoucher.Auth.Hmac
{
    public class DummySecretRepository : ISecretRepository
    {
        private readonly IDictionary<string, string> _userPasswords
            = new Dictionary<string, string>()
                  {
                      {"username","password"}
                  };

        public string GetSecretForUser(string username)
        {
            if (!this._userPasswords.ContainsKey(username))
            {
                return null;
            }

            var userPassword = this._userPasswords[username];
            var hashed = this.ComputeHash(userPassword, new SHA1CryptoServiceProvider());
            return hashed;
        }

        private string ComputeHash(string inputData, HashAlgorithm algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);
            byte[] hashed = algorithm.ComputeHash(inputBytes);
            return Convert.ToBase64String(hashed);
        }
    }
}