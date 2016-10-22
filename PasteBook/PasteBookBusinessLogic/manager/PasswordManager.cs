using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace PasteBookBusinessLogic
{
    public class PasswordManager
    {
        HashGenerator hashGenerator = new HashGenerator();

        public string GenerateHashPassword(string password, out string salt)
        {
            salt = SaltGenerator.GetSaltString();
            string newPassword = password + salt;
            return hashGenerator.GetPasswordHash(newPassword);
        }
        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string newPassword = password + salt;
            return hash == hashGenerator.GetPasswordHash(newPassword);
        }





        
    }




}