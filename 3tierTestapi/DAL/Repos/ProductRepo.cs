using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductRepo
    {

        ProductContext db;
        public ProductRepo()
        {
            db = new ProductContext();
        }
        public void Create(Product s)
        {
            db.Products.Add(s);
            db.SaveChanges();
        }
        public List<Product> Get()
        {
            return db.Products.ToList();
        }
        public void Update(Product s)
        {
            var exobj = Get(s.Id);
            db.Entry(exobj).CurrentValues.SetValues(s);
            db.SaveChanges(); ;
        }
        public void Delete(int id)
        {
            var exobj = Get(id);
            db.Products.Remove(exobj);

        }
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }
    }
}
