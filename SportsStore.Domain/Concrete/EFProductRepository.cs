using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EfProductRepository:IProductRepository
    {
        private readonly EfDbContext _context = new EfDbContext();
        public IEnumerable<Product> Products => _context.Products;
        public void SaveProduct(Product product)
        {
            if(product.Id == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                Product dbEntry = _context.Products.Find(product.Id);
                if(dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            _context.SaveChanges();
        }
    }
}
