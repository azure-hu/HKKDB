﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Form1());
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
