using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace HKK_Downloader
{
    public static class Extractor
    {
        public static string DownloadData(string url)
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
            catch (Exception)
            {
                //May not be connected to the internet
                //Or the URL might not exist
                Console.Error.WriteLine("There was an error accessing the URL.");
            }

            //Convert the data into string
            return  Encoding.Default.GetString(downloadedData);
        }

        public static List<string> ExtractLinks(string rawCode)
        {
            List<string> links = new List<string>();

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
                        links.Add(link);
                    }
                }

                //Trim the raw data
                rawCode = rawCode.Substring(end + endSequence.Length);
            }

            return links;
        }

        public static void CleanUp(ref List<string> _links, bool _verbose)
        {
            for (int item = 0; item < _links.Count; ++item )
            {
                int startIndex = _links[item].IndexOf("\' title=");
                int endIndex = _links[item].IndexOf("\">");
                //_links[item].Insert(startIndex, " ");
                _links[item] = _links[item].Remove(startIndex + 1, endIndex - startIndex);
                if (_verbose)
                    Console.WriteLine(_links[item]);
            }
        }
    }
}
