using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LittleStorageAdminServices;
using LittleStorageAdminRepository;
using System.Linq;

namespace LittleStorageAdmin
{
    public partial class CashRegister : Form
    {
        
        List<ProductSalesViewModel> SoldProducts;
        ProductService _productBLL;

        public CashRegister()
        {
            _productBLL = new ProductService();

            // Initialize the list
            SoldProducts = new List<ProductSalesViewModel>();

            InitializeComponent();
            ClearProductInfo();
            txtProductCode.Focus();
            txtProductCode.Focus();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            CloseSale _closeSaleForm = new CloseSale();
            _closeSaleForm.Show();
        }
        // End function

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
        // End function

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
                case 2:
                    MessageBox.Show("El producto se encuentra Agotado. porfavor considere reabastacer el inventario");
                    break;
            }

            #region DisplayProductInformation
            ClearProductInfo();

            if (ProductInfo.product != null)
            {
                lblProductTitle.Text = ProductInfo.product.Descritpion;
                txtSalePrice.Text = ProductInfo.product.SalesPrice.ToString();

                CreateSoldProductList(ProductInfo.product);
            }    
            #endregion

        }
        // End function

        public void ClearProductInfo() {
            lblProductTitle.Text = "";
            txtSalePrice.Text = "";
        }
        // End function


        public void CreateSoldProductList(Product ProductToStorage) {
            
            // Initialize the Object
            ProductSalesViewModel _product = new ProductSalesViewModel()
            { Producto = ProductToStorage.Descritpion, Precio = ProductToStorage.SalesPrice, Cantidad = 1};
            

            if (SoldProducts.Count == 0)
            {
                SoldProducts.Add(_product);

            }
            else
            {
                var IsInList = SoldProducts.Where(p => p.Producto.Equals(_product.Producto)).FirstOrDefault();

                if (IsInList != null)
                {
                    IsInList.Cantidad += 1;
                }
                else
                {
                    SoldProducts.Add(_product);
                }


            }

            dataGridView1.Refresh();
            dataGridView1.DataSource = SoldProducts;
            dataGridView1.Refresh();

            #region CalculatesTotalToPay
            Decimal TotalToPay = 0;
            foreach (var product in SoldProducts)
            {
                TotalToPay += product.Cantidad * product.Precio;
            }

            txtTotalToPay.Text = TotalToPay.ToString();
            #endregion


        }
        // End function

    }
}
