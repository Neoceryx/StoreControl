using System;
using System.Collections.Generic;
using System.Text;
using LittleStorageAdminRepository;

namespace LittleStorageAdminServices
{
    public class ProductService
    {
        ProductRepository _productDal;

        public ProductService() {
            _productDal = new ProductRepository();
        }
        

        public ProductInfoViewModel GetProductByBarCodeOrDescription(String ProductValue) {

            ProductInfoViewModel _response = new ProductInfoViewModel();

            Product _productRetreived = _productDal.GetProductByBarCodeOrDescription(ProductValue);


            if (_productRetreived != null)
            {
                if (_productRetreived.IsEnabled == false)
                {
                    _productRetreived = null;
                }

            }

            return _response;
        }

    }
    // End class

}
