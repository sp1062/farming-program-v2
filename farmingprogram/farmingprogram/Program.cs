using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmingprogram
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

            SqlConnector.startConnection();
            Application.Run(new LoginInterface());
        }

        private static Staff staff;

        public static void setStaff(Staff s)
        {
            staff = s;
        }

        public static Staff getStaff()
        {
            return staff;
        }
    }
}
