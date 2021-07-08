using System;
using System.Collections.Generic;
using System.Text;

namespace LittleStorageAdminRepository
{


    public class ProductInfoViewModel {
        public int Code { get; set; }
        public String CodeReason { get; set; }
        public Product product { get; set; }
    }


    public class ProductSalesViewModel {
        public String Producto { get; set; }
        public Decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }



}
