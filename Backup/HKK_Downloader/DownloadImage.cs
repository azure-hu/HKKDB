using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace HKK_Downloader
{
    public class DownloadImage
    {
        private string imageUrl;
        private Bitmap bitmap;
        public DownloadImage(string imageUrl)
        {
            this.imageUrl = imageUrl;
        }
        public void Download()
        {
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(imageUrl);
                bitmap = new Bitmap(stream);
                stream.Flush();
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Bitmap GetImage()
        {
            return bitmap;
        }
        public void SaveImage(string filename, ImageFormat format)
        {
            if (bitmap != null)
            {
                bitmap.Save(filename, format);
            }
        }

        public static bool StaticDownloadImage(string imageUrl, string filename, ImageFormat format)
        {
            Image _saveThis;
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(imageUrl);
                _saveThis = Image.FromStream(stream);
                stream.Flush();
                stream.Close();

                if (_saveThis != null)
                    _saveThis.Save(filename, format);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return File.Exists(filename);
        }
    }
}
