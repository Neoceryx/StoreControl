using System;
using System.Collections.Generic;
using System.Text;

namespace LittleStorageAdminRepository
{
    public class CategoryRepository
    {
        DBContext _context;

        public CategoryRepository() {
            _context = new DBContext();
        }

        public void InitializeCategories() {

            _context.Categories.Add(new Category() { CategoryName = "Clothing", RegisterDate = DateTime.Now });
            _context.Categories.Add(new Category() { CategoryName = "Footwear", RegisterDate = DateTime.Now });
            _context.Categories.Add(new Category() { CategoryName = "Accessories", RegisterDate = DateTime.Now });

            _context.SaveChanges();

        }


    }


}
