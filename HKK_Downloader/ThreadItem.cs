using System;
using System.Collections.Generic;
using System.Text;

namespace HKK_Downloader
{
    class ThreadItem
    {
        hkkDataSet _dataset;
        hkkDataSetTableAdapters.lapTableAdapter _adapter;
        String _item;

        public ThreadItem(ref hkkDataSet _ds, ref hkkDataSetTableAdapters.lapTableAdapter _ad, String _it)
        {
            _dataset = _ds;
            _adapter = _ad;
            _item = _it;
        }

        public hkkDataSet getDataSet { get { return _dataset ;} }
        public hkkDataSetTableAdapters.lapTableAdapter getTableAdapter { get { return _adapter; } }
        public String getItem { get { return _item; } }
    }
}
