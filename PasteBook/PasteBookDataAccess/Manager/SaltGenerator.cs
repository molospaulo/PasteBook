using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace PasteBookDataAccess
{
    public  class SaltGenerator
    {
        private static RNGCryptoServiceProvider cryptoProvider = null;
        private const int SaltSize = 18;

        static SaltGenerator()
        {
            cryptoProvider = new RNGCryptoServiceProvider();
        }

        public static string GetSaltString()
        {
            byte[] saltBytes = new byte[SaltSize];
            cryptoProvider.GetNonZeroBytes(saltBytes);
            string saltString = ConversionManager.GetStringFromBytes(saltBytes);
            return saltString;
        }
    }
}