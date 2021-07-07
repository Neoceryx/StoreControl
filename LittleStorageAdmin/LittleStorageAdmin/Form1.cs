using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LittleStorageAdminServices;

namespace LittleStorageAdmin
{
    public partial class Form1 : Form
    {
        CategoryService _categoryBLL;

        public Form1()
        {
            InitializeComponent();

            _categoryBLL = new CategoryService();

            GetCurrentDateTime();
            timer1.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _categoryBLL.IntializeCategories();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetCurrentDateTime();
        }


        public void GetCurrentDateTime() {
            lblDateTime.Text = DateTime.Now.ToString("MMMM dd yyyy, hh:mm:ss tt");
        }


    }
}
