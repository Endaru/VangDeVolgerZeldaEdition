using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using VangDeVolger.Objects;

namespace VangDeVolger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //make startscreen and then run it.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartScreen start = new StartScreen();
            Application.Run(start);
        }
    }
}
