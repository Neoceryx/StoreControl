using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LittleStorageAdminRepository
{
    public class DBContext: DbContext
    {
        private static bool _created = false;
        public DBContext() {
            if (!_created)
            {
                _created = true;
                //Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=LittleStorageAdmin.db");
        }

        public DbSet<Category> Categories { get; set; }

    }
    // End class

}
