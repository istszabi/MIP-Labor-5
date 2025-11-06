using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_5
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(30)] public string Name { get; set; }

        [MaxLength (500)] public string Description { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int Quantity { get; set; }

        public int IdCategorie { get; set; }
        public CategorieProdus Categorie { get; set; }

    }
    public class ProductDbContext : DbContext
    {

        public ProductDbContext() : base("name=ProductDbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProductDbContext>());
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<CategorieProdus> CategorieProdus { get; set; }
        public DbSet<IstoricVanzari> IstoricVanzari { get; set; }

    }
}
