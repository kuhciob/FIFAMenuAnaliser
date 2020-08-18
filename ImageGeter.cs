using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FIFAImageAnaliser
{
    static class ImageGeter
    {
        public static Image GetByFilePath(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    Image img = Image.FromFile(filePath);
                    return img;
                }
                catch (OutOfMemoryException ex)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static Image GetFromServer(string Url)
        {
            try
            {
                WebRequest request = WebRequest.Create(Url);
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
            catch
            {
                return null;
            }
            
        }
    }
}
