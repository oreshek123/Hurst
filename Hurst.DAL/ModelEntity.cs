using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurst.DAL
{
    public class ModelEntity: DbContext
    {
        public ModelEntity() : base("name=DefaultConnection")
        {
        }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
