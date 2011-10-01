using System;
using System.Collections.Generic;

namespace HKK_Downloader
{
    class Program
    {
        private static string _picturePath = ".\\lapok\\";
        private static string subDir = "";
        private static void WriteAndWait(string _message)
        {
            Console.WriteLine(_message);
            System.Threading.Thread.Sleep(50);
        }


        private static void WriteAndWait(string _format, params object[] args)
        {
            Console.WriteLine(_format, args);
            System.Threading.Thread.Sleep(50);
        }

        static void Main(string[] args)
        {
            List<string> _extracted = new List<string>();
            bool listsOk = false;

            try
            {
                MakeDirectory();
                for (int kiadas = 0; kiadas < 150; ++kiadas)
                    for (int gyakorisag = 0; gyakorisag < 15; ++gyakorisag)
                    {
						for (int szin = 0; szin < 40; ++szin)
                        {
                            string _url = @"http://www.beholder.hu/?m=hkk&in=hkk_lapkereso.php&KERESES=1&adv=1&kiadas1=" + kiadas + "&kiadas2=0&kiadascsak=0&evtol=0&evig=0&szin1=" + szin + "&szin2=0&szin3=0&szin4=0&tipus1=0&tipus2=0&altipus1=0&altipus2=0&egyebtipus=0&gyakorisag=" + gyakorisag + "&nevstr=&szovegstr=&szinesitostr=&idktg11=&idktg12=&idktg13=1&idktg21=&idktg22=&idktg23=1&tamadas1=&tamadas2=&tamadas3=0&vedekezes1=&vedekezes2=&vedekezes3=0&grafikus=0&tervezo=0";
                            GenerateLists(ref kiadas, gyakorisag, szin, _url, ref listsOk, out _extracted);
							if(kiadas == 0)
								break;
                        }
						if(kiadas == 0)
								break;
					}
				for (int kiadas = 0; kiadas < 150; ++kiadas)
                    for (int gyakorisag = 0; gyakorisag < 15; ++gyakorisag)
                        for (int szin = 0; szin < 50; ++szin)
                        {
                            FullFunction(kiadas, gyakorisag, szin, listsOk, ref _extracted );
                        }
				
            }
            catch (Exception _x)
            {
                WriteAndWait("[!error!] --- Something went wrong!");
                WriteAndWait("[message] --- {0}", _x.Message);
            }
            finally
            {
                WriteAndWait("[pending] --- Press a key to exit.");
                Console.ReadKey(true);
                WriteAndWait("[  ok!  ] --- Have a nice day! =)");
            }
        }

        private static void FullFunction(int kiadas, int gyakorisag, int szin, bool listsOk, ref List<string> _extracted)
        {
            if (listsOk)
            {
                WriteAndWait("[pending] --- Preparing to download...");

                System.IO.StreamReader _output = System.IO.File.OpenText("lapok_" + "sz" + szin + "gy" + gyakorisag + "k" + kiadas + ".txt");
                MultiProcessor _proc = new MultiProcessor(10);
                //MultiProcessor.Calculate(_extracted.Count, 10);

                subDir = "sz" + szin.ToString() + "\\gy" + gyakorisag.ToString() + "\\k" + kiadas.ToString() + "\\";
                System.IO.Directory.CreateDirectory(_picturePath + subDir);

                for (int i = 0; i <= (_extracted.Count%10); i++)
                {
                    
                }

                Download(_extracted);
                _output.Close();
                WriteAndWait("[  ok!  ] --- Images downloaded.");
            }
        }

        private static void Download(List<string> _extracted)
        {
            foreach (string item in _extracted)
            {
                string _item = item;
                string[] _parts = _item.Split(new string[] { "'>" }, StringSplitOptions.RemoveEmptyEntries);
                if (DownloadImage.StaticDownloadImage("http://www.beholder.hu/php/hkk_lapkep.php?id=" + _parts[0],
                    _picturePath + subDir + _parts[0] + ".jpeg",
                    System.Drawing.Imaging.ImageFormat.Jpeg))
                {
                    Console.WriteLine("{0} -> {1}", _parts[0], _parts[1]);
                    Console.WriteLine(item);
                }
            }
        }

        private static void MakeDirectory()
        {
            WriteAndWait("[message] --- Enter directory name/path!");
            string _temp = Console.ReadLine();
            if (_temp.Length < 1)
            {
                WriteAndWait("[failed!] --- Invalid directory name/path!");
                WriteAndWait("[message] --- Using defaults...");
            }
            else
                _picturePath = _temp + "\\";
            WriteAndWait("[pending] --- Creating directory...");
            System.IO.Directory.CreateDirectory(_picturePath);
            WriteAndWait("[  ok!  ] --- Directory created.");
        }

        private static void GenerateLists(ref int kiadas, int gyakorisag, int szin, string _url, ref bool listsOk, out List<string> _extracted)
        {
            WriteAndWait("[pending] --- Generating lists...");
            Console.WriteLine("kiadas: {0}, gyakori: {1}, szin: {2}", kiadas.ToString(), gyakorisag.ToString(), szin.ToString());
            _extracted = Extractor.ExtractLinks(Extractor.DownloadData(_url));
            Extractor.CleanUp(ref _extracted, false);
            WriteAndWait("[  ok!  ] --- Lists generated.");
            WriteAndWait("[pending] --- Checking if list is empty...");

            if (_extracted.Count > 0)
            {
                WriteAndWait("[  ok!  ] --- Good! List has items.");
                listsOk = true;
                System.IO.StreamWriter _output = System.IO.File.CreateText(_picturePath + "lapok_" + "sz" + szin + "gy" + gyakorisag + "k" + kiadas + ".txt");
                WriteAndWait("[pending] --- Saving items...");
                foreach (string item in _extracted)
                {
                    string _item = item;
                    string[] _parts = _item.Split(new string[] { "'>" }, StringSplitOptions.RemoveEmptyEntries);
                    _output.WriteLine(item);
                }
                _output.Close();
                WriteAndWait("[  ok!  ] --- Items saved.");
            }
            else
            {
                WriteAndWait("[!error!] --- List is empty! Nothing saved.");
                listsOk = false;
            }
        }
    }
}
