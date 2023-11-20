using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNatur_Biomarkt_GmbH
{
    public partial class LoadingScreen : Form
    {
        private int loadingBarValue;
        public LoadingScreen()  //Konstruktor 
        {
            InitializeComponent();
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            loadingBarTmer.Start();
        }
        private void loadingBarTmer_Tick(object sender, EventArgs e)
        {
            
            loadingBarValue += 1;
            lblLoadingProgress.Text = loadingBarValue.ToString() + "%";
            progressBar1.Value = loadingBarValue;

            if(loadingBarValue >= progressBar1.Maximum)
            {
                loadingBarTmer.Stop();
            }
        }
        //Änderung Test Versionsverwaltung
 
    }
}
