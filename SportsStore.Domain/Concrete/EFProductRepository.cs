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
    }
}
