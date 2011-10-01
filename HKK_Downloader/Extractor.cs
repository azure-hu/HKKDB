using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace HKK_Downloader
{
    public class Extractor
    {
        private string _url;
        private string _rawdata;
        private List<string> _extracted;

        public Extractor(string p)
        {
            // TODO: Complete member initialization
            this._url = p;
        }

        public string GetRawData { get { return DownloadData(_url); } }
        
        public List<string> GetCleanData (bool _verbose)
        {
            ExtractLinks(this.DownloadData(_url));
            CleanUp(_verbose);
            return _extracted;
        }

        private string DownloadData(string url)
        {
            byte[] downloadedData = new byte[0];
            try
            {
                //Get a data stream from the url
                WebRequest req = WebRequest.Create(url);
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();

                //Download in chuncks
                byte[] buffer = new byte[1024];

                //Get Total Size
                int dataLength = (int)response.ContentLength;

                //Download to memory
                MemoryStream memStream = new MemoryStream();
                while (true)
                {
                    //Try to read the data
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    //Avoid application freezing
                    //Application.DoEvents();

                    if (bytesRead == 0)
                    {
                        //Finished downloading                       
                        break;
                    }
                    else
                    {
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);
                    }
                }

                //Convert the downloaded stream to a byte array
                downloadedData = memStream.ToArray();

                //Clean up
                stream.Close();
                memStream.Close();
            }
            catch (Exception x)
            {
                //May not be connected to the internet
                //Or the URL might not exist
                Console.Error.WriteLine("There was an error accessing the URL.");
                Console.Error.WriteLine(x.Message);
            }

            //Convert the data into string
            _rawdata = Encoding.Default.GetString(downloadedData);
            return _rawdata;
        }

        private List<string> ExtractLinks(string rawCode)
        {
            _extracted = new List<string>();

            string startSquence = "?m=hkk&in=hkk.php&kartya=";
            string endSequence = "</a>";

            rawCode = rawCode.ToLower();

            while (rawCode.IndexOf(startSquence) != -1)
            {
                int start = rawCode.IndexOf(startSquence) + startSquence.Length;
                int end = rawCode.IndexOf(endSequence, start);

                //Extract the link, and add it to the list
                if (end > start)
                {
                    string link = rawCode.Substring(start, end - start);

                    if (link != string.Empty)
                    {
                        _extracted.Add(link);
                    }
                }

                //Trim the raw data
                rawCode = rawCode.Substring(end + endSequence.Length);
            }

            return _extracted;
        }

        public void CleanUp(bool _verbose)
        {
            for (int item = 0; item < _extracted.Count; ++item)
            {
                int startIndex = _extracted[item].IndexOf("\' title=");
                int endIndex = _extracted[item].IndexOf("\">");
                //_extracted[item].Insert(startIndex, " ");
                _extracted[item] = _extracted[item].Remove(startIndex + 1, endIndex - startIndex);
                if (_verbose)
                    Console.WriteLine(_extracted[item]);
            }
        }

        internal void Flush()
        {
            _extracted = null;
        }
    }
}
