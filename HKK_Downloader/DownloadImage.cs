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
        private Image _image;

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
                _image = Bitmap.FromStream(stream);
                stream.Flush();
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Image GetImage()
        {
            return _image;
        }

        public void SaveImage(string filename, ImageFormat format)
        {
            if (_image != null)
            {
                _image.Save(filename, format);
            }
        }

        public static bool StaticDownloadImage(string imageUrl, string filename, ImageFormat format)
        {
            try
            {
                Image _saveThis = GetImage(imageUrl);
                if (_saveThis != null)
                    _saveThis.Save(filename, format);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return File.Exists(filename);
        }

        public static Image GetImage(string imageUrl)
        {
            HttpWebRequest _downloadHWRequest = (HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl); 
            _downloadHWRequest.AllowWriteStreamBuffering = true;
            _downloadHWRequest.Timeout = 30000;
            WebResponse _downloadImageResponse = _downloadHWRequest.GetResponse();
            Stream _WebStream = _downloadImageResponse.GetResponseStream();
            Image _downloadedImage = Image.FromStream(_WebStream);

            _WebStream.Flush();
            _WebStream.Close();
            return _downloadedImage;
        }

        public static byte[] ImgToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
