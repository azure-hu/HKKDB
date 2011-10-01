using System;
using System.Collections.Generic;
using System.Text;

namespace HKK_Downloader
{
    class MultiProcessor
    {
        int _procCount;
        //int _procMax;
        List<System.Threading.Thread> _procList;

        internal static int Calculate(int p, int rest)
        {
            int _procCount = p;
            for (int i = 2; i < rest; i++)
            {
                if ((p % i) < _procCount)
                    _procCount = i;
            }
            return _procCount;
        }

        public void ProcessAll(object _param)
        {
            for (int i = 0; i < _procCount; i++)
            {
                _procList[i].Start(((List<object>)_param)[i]);
                _procList[i].Join();
            }
            _procList.Clear();
        }

        public MultiProcessor(int Processes)
        {
            _procCount = Processes;
            _procList = new List<System.Threading.Thread>();
        }

        public void FillUp(System.Threading.ParameterizedThreadStart startDelegate)
        {
            for (int i = 0; i < _procCount; i++)
            {
                _procList.Add(new System.Threading.Thread(startDelegate));
                _procList[i].IsBackground = true;
            }
        }
    }
}
