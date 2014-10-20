using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace farmingprogram
{

    public partial class SplashScreen : Form
    {        
        public const int SPLASH_SCREEN_TIMEOUT = 5000;
        public static SplashScreen splash;

        public SplashScreen()
        {
            CenterToScreen();
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            Console.WriteLine();
        }


        public static void startSplashScreen()
        {
            splash = new SplashScreen();
            Application.Run(splash);
        }
    }
}
