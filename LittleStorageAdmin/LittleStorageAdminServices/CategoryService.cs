using System;
using System.Collections.Generic;
using System.Text;
using LittleStorageAdminRepository;

namespace LittleStorageAdminServices
{
    public class CategoryService
    {
        CategoryRepository _categoryDAL;
        public CategoryService() {
            _categoryDAL = new CategoryRepository();
        }

        public void IntializeCategories() {
            _categoryDAL.InitializeCategories();
        }

    }

}
