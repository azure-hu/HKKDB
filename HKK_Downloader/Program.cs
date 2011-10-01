using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;

namespace HKK_Downloader
{
    class Program
    {
        private static string _picturePath = ".\\lapok\\";
        private static string subDir = "";
        private static hkkDataSet _dataset = new hkkDataSet();
        private static hkkDataSetTableAdapters.lapTableAdapter _adapter = new hkkDataSetTableAdapters.lapTableAdapter();
        private static ReaderWriterLock _lock = new ReaderWriterLock();    
            

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
            bool listsOk = false;

            try
            {
                int kiadas = 0;
                int gyakorisag = 0;
                int szin = 0;

                MakeDirectory();

                while (kiadas < 150)
	            {
                
                    if (kiadas < 1)
	                {
                        string _url = @"http://www.beholder.hu/?m=hkk&in=hkk_lapkereso.php&KERESES=1&adv=1&kiadas1=" 
                                + kiadas + "&kiadas2=0&kiadascsak=0&evtol=0&evig=0&szin1=" + szin 
                                + "&szin2=0&szin3=0&szin4=0&tipus1=0&tipus2=0&altipus1=0&altipus2=0&egyebtipus=0&gyakorisag=" 
                                + gyakorisag + "&nevstr=&szovegstr=&szinesitostr=&idktg11=&idktg12=&idktg13=1&idktg21=&idktg22=&idktg23=1&tamadas1=&tamadas2=&tamadas3=0&vedekezes1=&vedekezes2=&vedekezes3=0&grafikus=0&tervezo=0";

                        List<string> _extracted = new List<string>();
                        ListProperty _prop = new ListProperty(ref kiadas, ref gyakorisag, ref szin, ref _url,
                                ref listsOk, _extracted);
                        GenerateLists(_prop);                            
                        FullFunction(kiadas, gyakorisag, szin, _prop.ListsOk, ref _prop._list);
                    }
                    else
                	{
                        for (gyakorisag = 0; gyakorisag < 15; ++gyakorisag)
                        {
                            Thread[] _threads = new Thread[40];
                            for (szin = 0; szin < 40; ++szin)
                            {
                                string _url = @"http://www.beholder.hu/?m=hkk&in=hkk_lapkereso.php&KERESES=1&adv=1&kiadas1="
                                + kiadas + "&kiadas2=0&kiadascsak=0&evtol=0&evig=0&szin1=" + szin
                                + "&szin2=0&szin3=0&szin4=0&tipus1=0&tipus2=0&altipus1=0&altipus2=0&egyebtipus=0&gyakorisag="
                                + gyakorisag + "&nevstr=&szovegstr=&szinesitostr=&idktg11=&idktg12=&idktg13=1&idktg21=&idktg22=&idktg23=1&tamadas1=&tamadas2=&tamadas3=0&vedekezes1=&vedekezes2=&vedekezes3=0&grafikus=0&tervezo=0";

                                ListProperty _prop = new ListProperty(ref kiadas, ref gyakorisag, ref szin, ref _url,
                                ref listsOk, null);
                                
                                _threads[szin] = new Thread(GenerateLists);
                                _threads[szin].Start( _prop );

                            }
                            for (int l = 0; l < 40; ++l)
                            {
                                _threads[l].Join();                                
                            }

                            Console.WriteLine("[ sleep ] --- Sleeping for 3 seconds ...");
                            Thread.Sleep(3000);
                        }
                        
	                }

	                ++kiadas;
	            }
                /*
				for (int kiadas = 0; kiadas < 150; ++kiadas)
                    for (int gyakorisag = 0; gyakorisag < 15; ++gyakorisag)
                        for (int szin = 0; szin < 50; ++szin)
                        {
                            FullFunction(kiadas, gyakorisag, szin, listsOk, ref _extracted );
                        }
				*/
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


                //subDir = "sz" + szin.ToString() + "\\gy" + gyakorisag.ToString() + "\\k" + kiadas.ToString() + "\\";
                //System.IO.Directory.CreateDirectory(_picturePath + subDir);
                System.IO.StreamReader _output = System.IO.File.OpenText(_picturePath +
                    "lapok_" + "k" + kiadas + "gy" + gyakorisag + "sz" + szin + ".txt");


                //Download(_extracted);
                DownloadToDB(_extracted);
                _output.Close();
                WriteAndWait("[  ok!  ] --- Images downloaded.");
            }
        }


        private static void DownloadToDB(List<string> _extracted)
        {
            #region multithread test
            
            int constant = 2;
            int processing = constant;

            for (int j = 0; j < _extracted.Count; j+=processing)
            {
                if ((processing = (_extracted.Count - j) % constant) == 0)
                    processing = constant;
                //Console.WriteLine("processed set to {0}", processing);
                System.Threading.Thread[] _threads = new System.Threading.Thread[processing];
                for (int i = 0; i < processing; i++)
			    {
                    _threads[i] = new System.Threading.Thread(GetImageToDB);
                    _threads[i].Start(_extracted[j + i]);
			    }
                for (int i = 0; i < processing; i++)
                {
                    _threads[i].Join();
                }
                
                //Console.WriteLine("[ sleep ] --- Sleeping for 1 second ...");
                //Thread.Sleep(1000);
            }
            
            #endregion

            #region without multithreading
            /*
            for (int i = 0; i < _extracted.Count; i++)
            {
                GetImageToDB(_extracted[i]);                
            }
            */
            #endregion
        }



        private static void GetImageToDB(object data)
        {
            string _item = (string)data;
            string[] _parts = _item.Split(new string[] { "'>" }, StringSplitOptions.RemoveEmptyEntries);
            System.Drawing.Image _img = DownloadImage.GetImage("http://www.beholder.hu/php/hkk_lapkep.php?id=" + _parts[0]);

            try
            {
                _lock.AcquireWriterLock(180000);
                if (_img != null)
                {
                    hkkDataSet.lapRow _row = _dataset.lap.NewlapRow();
                    _row.id = int.Parse(_parts[0]);
                    _row.nev = _parts[1];
                    _row.kep = DownloadImage.ImgToByteArray(_img);
                    _dataset.lap.AddlapRow(_row);

                    switch (_parts[0].Length)
                    {
                        case 1: _parts[0] = "   " + _parts[0]; break;
                        case 2: _parts[0] = "  " + _parts[0]; break;
                        case 3: _parts[0] = " " + _parts[0]; break;
                        default:
                            break;
                    }
                    Console.WriteLine("{0} -> {1}", _parts[0], _parts[1]);
                    //Console.WriteLine(item);
                    _adapter.Update(_dataset.lap);
                }
            }
            catch (Exception x)
            {
                Console.Error.WriteLine(x.Message);
            }
            finally
            {
                _lock.ReleaseWriterLock();
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

        private static void GenerateLists(object data)
        {
            ListProperty _p = (ListProperty)data;
            WriteAndWait("[pending] --- Generating lists...");
            Console.WriteLine("kiadas: {0}, gyakori: {1}, szin: {2}", _p.Kiadas.ToString(), _p.Gyakorisag.ToString(),
                _p.Szin.ToString());

            /*_lock.AcquireWriterLock(180000);*/

            Extractor _ext = new Extractor(_p.Url);
            _p._list = _ext.GetCleanData(false);
            _ext.Flush();

            WriteAndWait("[  ok!  ] --- Lists generated.");
            WriteAndWait("[pending] --- Checking if list is empty...");

            if (_p._list.Count > 0)
            {
                WriteAndWait("[  ok!  ] --- Good! List has items.");
                _p.ListsOk = true;
                System.IO.StreamWriter _output = System.IO.File.CreateText(_picturePath + "lapok_" + "k" + _p.Kiadas
                    + "gy" + _p.Gyakorisag + "sz" + _p.Szin + ".txt");
                WriteAndWait("[pending] --- Saving items...");
                foreach (string item in _p._list)
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
                _p.ListsOk = false;
            }
            /*_lock.ReleaseWriterLock();

            Thread.Sleep(3000);*/
        }
    }
}
