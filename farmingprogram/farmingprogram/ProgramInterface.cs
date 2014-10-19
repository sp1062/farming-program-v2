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
    public partial class ProgramInterface : Form
    {
        public ProgramInterface()
        {
            Thread timeoutThread = new Thread(new ThreadStart(SplashScreen.startSplashScreen));
            timeoutThread.Start();
            Thread.Sleep(SplashScreen.SPLASH_SCREEN_TIMEOUT);
            InitializeComponent();
            timeoutThread.Abort();
        }
    }
}
