using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LittleStorageAdminServices;
using LittleStorageAdminRepository;

namespace LittleStorageAdmin
{
    public partial class CashRegister : Form
    {
        ProductService _productBLL;

        public CashRegister()
        {
            _productBLL = new ProductService();

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
                    GetProductInformation();
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


        private void GetProductInformation() {

            ProductInfoViewModel ProductInfo = _productBLL.GetProductByBarCodeOrDescription(txtProductCode.Text);

            switch (ProductInfo.Code)
            {
                case -1:
                    MessageBox.Show("Producto no encontrado");
                    break;
                case 0:
                    MessageBox.Show("El producto se encuentra deshabilidado del sistema");
                    break;
            }

            #region DisplayProductInformation
            lblProductTitle.Text = ProductInfo.product.Descritpion;
            txtSalePrice.Text = ProductInfo.product.SalesPrice.ToString();            
            #endregion


        }
        // End function

    }
}
