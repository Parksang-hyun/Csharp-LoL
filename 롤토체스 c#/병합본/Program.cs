using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game00
{
    internal static class Program
    {

        public static class SharedData
        {
            public static bool select1 = false;
            public static bool select2 = false;
            public static bool select3 = false;
            public static bool select4 = false;
            public static int image = 0;
            public static int image2 = 0;
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
