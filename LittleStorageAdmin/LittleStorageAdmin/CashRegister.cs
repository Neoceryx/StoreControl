﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LittleStorageAdmin
{
    public partial class CashRegister : Form
    {
        public CashRegister()
        {
            InitializeComponent();
            txtProductCode.Focus();
            txtProductCode.Focus();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            CloseSale _closeSaleForm = new CloseSale();
            _closeSaleForm.Show();
        }
    }
}
