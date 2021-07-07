using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittleStorageAdmin
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            GetCurrentDateTime();
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetCurrentDateTime();
        }

        public async void GetCurrentDateTime() {

            DateTime CurrentDateTime = DateTime.Now;

            lblDateTime.Text = CurrentDateTime.ToString("MMM dddd yyyy, h:mm:ss tt");
        }
        // End function

    }
}
