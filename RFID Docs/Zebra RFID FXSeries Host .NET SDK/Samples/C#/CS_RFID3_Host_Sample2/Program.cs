using System;
using System.Collections.Generic;
using System.Windows.Forms;

//namespace RFID3Test_PCApp
namespace CS_RFID3_Host_Sample2
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
            Application.Run(new AppForm());
        }
    }
}