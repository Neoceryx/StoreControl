using System;
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

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (IsBarCodeValidValue() == true)
                {
                    MessageBox.Show("Busnado producto");
                }
            }
        }


        private Boolean IsBarCodeValidValue() {

            Boolean IsValid = true;

            errorProvider1.SetError(txtProductCode, "");

            if (String.IsNullOrEmpty(txtProductCode.Text))
            {
                errorProvider1.SetError(txtProductCode, "Escane de nuevo el codigo del producto");
                IsValid = false;
            }

            return IsValid;

        }
        // End function

    }
}
