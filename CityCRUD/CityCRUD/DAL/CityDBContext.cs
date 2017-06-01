using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CityCRUD.DAL
{
    public class CityDBContext : DbContext
    {
        public CityDBContext() : base("CityDBConnection")
        {

        }

        public static CityDBContext Create()
        {
            return new CityDBContext();
        }

        public DbSet<Building> Buildings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}