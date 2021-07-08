using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStorageAdminRepository
{
    public class ProductRepository
    {
        DBContext _context;

        public ProductRepository() {
            _context = new DBContext();
        }

        public Product GetProductByBarCodeOrDescription(String ProductVal) {

            Product _productRetrived = _context.Products.Where(x => x.BarCode == ProductVal).FirstOrDefault();

            return _productRetrived;

        }
        // End function



    }
}
