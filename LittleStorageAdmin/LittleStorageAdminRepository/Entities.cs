using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LittleStorageAdminRepository
{

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual Product Product { get; set; }

    }

    public class Product {
        public int ProductID { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public String Descritpion { get; set; }
        public Decimal SalesPrice { get; set; }
        public int QtyOnStock { get; set; }
        public int MinQtyOnStock { get; set; }
        public int MaxQtyOnStock { get; set; }
        public Boolean IsEnabled { get; set; }
        public DateTime RegisterDate { get; set; }

        // Foreign Key 1-1
        public virtual Category Category { get; set; }

        // foreign Key 1-Many
        public ICollection<Movement> Movements { get; set; }

    }


    public class Movement {
        public int MovementID { get; set; }
        public int ProductID { get; set; }
        public Boolean IsASale { get; set; }
        public int QTY { get; set; }
        public Decimal BuyPrice { get; set; }
        public String Commentary { get; set; }
        public DateTime RegisterDate { get; set; }

        // foreign Key 1-Many
        public Product Product { get; set; }

    }


}
