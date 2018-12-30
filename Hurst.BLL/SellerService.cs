using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hurst.DAL;

namespace Hurst.BLL
{
    public class SellerService
    {
        public bool CreateSeller(Seller seller)
        {
            using (ModelEntity db = new ModelEntity())
            {
                db.Sellers.Add(seller);
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
        public bool EditSeller(Seller seller)
        {
            using (ModelEntity db = new ModelEntity())
            {
                db.Entry(seller).State = EntityState.Modified;
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
        public List<Seller> GetSellers()
        {
            using (ModelEntity db = new ModelEntity())
            {
                return  db.Sellers.ToList();
            }
        }

        public bool Login(string login, string password)
        {
            using (ModelEntity db = new ModelEntity())
            {
                var exists = db.Sellers.ToList().Exists(t => t.Email ==login && t.Password == password);
                if (exists)
                return true;
            }

            return false;
        }
    }
}
