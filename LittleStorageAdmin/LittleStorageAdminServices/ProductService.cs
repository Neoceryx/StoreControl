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

            ProductInfoViewModel _response = new ProductInfoViewModel() { Code = -1, CodeReason = "Product was not found", product = null };

            Product _productRetreived = _productDal.GetProductByBarCodeOrDescription(ProductValue);

            if (_productRetreived != null)
            {

                _response.Code = 1;
                _response.CodeReason = "Product Retrieved successfully";
                _response.product = _productRetreived;

                if (_productRetreived.IsEnabled == false)
                {
                    _response.Code = 0;
                    _response.CodeReason = "Product Is Disabled";
                    _response.product = null;
                }

                if (_productRetreived.QtyOnStock == 0)
                {
                    _response.Code = 2;
                    _response.CodeReason = "Does not have Product amount on stock";
                    _response.product = null;

                }

            }

            return _response;
        }

    }
    // End class

}
