using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class ImageManager
    {
        public byte[] ConvertToByte(HttpPostedFileBase file)
        {
            byte[] imageByte = null;
            BinaryReader rdr = new BinaryReader(file.InputStream);
            imageByte = rdr.ReadBytes((int)file.ContentLength);
            return imageByte;
        }
        private bool IsImage(HttpPostedFileBase file)
        {
            string[] formats = new string[] { ".jpg", ".png", ".jpeg" };
            if (file.ContentType.Contains("image"))
            {
                return true;
            }
            foreach (var item in formats)
            {
                if (file.FileName.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }
        public bool IsImageValid(HttpPostedFileBase file)
        {
            if(IsImage(file) && CheckImageSize(file))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckImageSize(HttpPostedFileBase file)
        {
            const int maxImageByte =2000000;
            int byteCount = file.ContentLength;
            if(byteCount > maxImageByte)
            {
                return false;
            }
            else
            {
                return true;
            }


        }
    }
}