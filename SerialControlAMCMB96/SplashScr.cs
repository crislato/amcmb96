using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialControlAMCMB96
{
    public partial class SplashScr : Form
    {
        public SplashScr()
        {
            InitializeComponent();
        }
        Timer tmr;
        //Valentina se atribuye lo bonito de este Splash Screen.
        private void SplashScr_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            //set time interval 3 sec
            tmr.Interval = 5000;
            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            tmr.Stop();
            //display mainform
            FormMain mf = new FormMain();
            mf.Show();
            //hide this form
            this.Hide();
        }

            
    }
}
