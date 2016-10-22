using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace PasteBookBusinessLogic
{
    public class HashGenerator
    {
        public string GetPasswordHash(string input)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] data = ConversionManager.GetByteFromString(input);
            byte[] resultDataBytes = sha.ComputeHash(data);

            return ConversionManager.GetStringFromBytes(resultDataBytes);

        }


    }
}