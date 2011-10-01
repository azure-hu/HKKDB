using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace HKK_Downloader
{
    class ListProperty
    {
        private int kiadas;
        private int gyakorisag;
        private int szin;
        private string url;
        private bool listsOk;
        public List<string> _list;

        public ListProperty(ref int kiadas, ref int gyakorisag, ref int szin, ref string _url, 
            ref bool listsOk, List<string> list)
        {
            // TODO: Complete member initialization
            this.kiadas = kiadas;
            this.gyakorisag = gyakorisag;
            this.szin = szin;
            this.url = _url;
            this.listsOk = listsOk;
            this._list = (list != null ? list : new List<string>());
        }
       
        public int Kiadas { get { return kiadas;} }
        public int Gyakorisag { get { return gyakorisag; } }
        public int Szin { get { return szin; } }
        public string Url { get { return url; } }
        public bool ListsOk { get { return listsOk; } set { listsOk = value;} }

    }
}
