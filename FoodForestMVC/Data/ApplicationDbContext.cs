
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace FoodForestMVC.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("FoodforestContext")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<FoodForestMVC.Models.EmployeeVM> EmployeeVMs { get; set; }
    }
}
