using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hurst.DAL;

namespace Hurst.BLL
{
    public class ProductService
    {
        public List<Product> GetProducts()
        {
            using (ModelEntity db = new ModelEntity())
            {
                return db.Products.ToList();
            }
        }
        public bool AddProduct(Product product)
        {
            using (ModelEntity db = new ModelEntity())
            {
                db.Products.Add(product);
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool EditProduct(Product product)
        {
            using (ModelEntity db = new ModelEntity())
            {
                db.Entry(product).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        public bool DeleteProduct(Product product)
        {
            using (ModelEntity db = new ModelEntity())
            {
                Product pr = db.Products.FirstOrDefault(p => p.Id == product.Id);
                db.Products.Remove(pr ?? throw new InvalidOperationException());
                try
                {                    
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

    }
}
