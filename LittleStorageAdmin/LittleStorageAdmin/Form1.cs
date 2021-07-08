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


            ChashRegisterPanel();
            InventoryPanel();
            ReportsPanel();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetCurrentDateTime();
        }


        public void GetCurrentDateTime() {
            lblDateTime.Text = DateTime.Now.ToString("MMMM dd yyyy, hh:mm:ss tt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _categoryBLL.IntializeCategories();
        }

        private void btnCashRegister_MouseClick(object sender, MouseEventArgs e)
        {
            CashRegister _cashRegisterForm = new CashRegister();
            _cashRegisterForm.Show();
            this.Hide();

        }

        private void btnInventory_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Opening Invetory...");
        }

        private void btnReports_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Opening Reports...");
        }

        public void ChashRegisterPanel()
        {
            pictureBox1.MouseClick += btnCashRegister_MouseClick;
            label6.MouseClick += btnCashRegister_MouseClick;
            panel15.MouseClick += btnCashRegister_MouseClick;
        }


        public void InventoryPanel()
        {
            pictureBox2.MouseClick += btnInventory_MouseClick;
            label7.MouseClick += btnInventory_MouseClick;
            panel10.MouseClick += btnInventory_MouseClick;
        }

        public void ReportsPanel()
        {
            pictureBox3.MouseClick += btnReports_MouseClick;
            label8.MouseClick += btnReports_MouseClick;
            panel12.MouseClick += btnReports_MouseClick;
        }


    }
}
