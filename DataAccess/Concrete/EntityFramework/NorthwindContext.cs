using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile proje classlarını bağlamak
    //DbContext:Entityframework kuruncca bu base class gelir.
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\Mssqllocaldb;Database=master;Trusted_Connection=true");//sqlserver a nasıl bağlanacağın yazcak başına "@" koymak \ ı \ olarak algıla NOT optionsBuilder.UseSqlServer(@"Server=175.45.2.12") gerçek projede böyle ip belirtilir.
        }
        //hangi nesnenin hangisine karşılık geleceğini de aşağıdan belirliyoruz DbSet<Product> burası projemde pluşturduğum class
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
