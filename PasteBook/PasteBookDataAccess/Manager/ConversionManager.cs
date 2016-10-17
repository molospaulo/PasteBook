using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PasteBookDataAccess
{
    public static class ConversionManager
    {
        public static string GetStringFromBytes(byte[] input)
        {
            string output;
            output = ASCIIEncoding.ASCII.GetString(input);
            return output;
        }
        public static byte[] GetByteFromString(string input)
        {
            byte[] output;
            output = ASCIIEncoding.ASCII.GetBytes(input);
            return output;
        }
    }
}