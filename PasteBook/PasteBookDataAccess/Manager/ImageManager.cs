using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace PasteBookDataAccess
{
    //http://www.codeproject.com/Articles/15460/C-Image-to-Byte-Array-and-Byte-Array-to-Image-Conv
    public static class ImageManager
    {
        public static byte[] imageToBytes(System.Drawing.Image input)
        {
            MemoryStream ms = new MemoryStream();
            input.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public  static Image byteArrayToImage(byte[] input)
        {
            MemoryStream ms = new MemoryStream(input);
            Image OutputImage = Image.FromStream(ms);
            return OutputImage;
        }

    }
}