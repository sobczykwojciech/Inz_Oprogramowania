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
using Program1; // aby można używać Harmonogram

namespace WindowsFormsApp4
{
    public partial class StartAplikacji : Form
    {
        public StartAplikacji()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        static void UruchomNowyHarmonogramStandard()
        {
            Application.Run(new HarmonogramStandard());
        }
        
        private void UruchomHarmonogram_Click(object sender, EventArgs e)
        {
            Thread X = new Thread(UruchomNowyHarmonogramStandard);
            X.SetApartmentState(ApartmentState.STA);  // w przypadku MTA występował problem z wątkami przy imporcie z excel
            X.Start();
        }
    }
}
