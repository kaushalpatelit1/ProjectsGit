using CRUDWithRepository.Core;
using CRUDWithRepository.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWithRepository.Infrastructure.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyAppDbContext _context;

        public ProductRepository(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
        public Task<Product> GetById(int productId)
        {
            throw new NotImplementedException();
        }
        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            Save();

        }
        public Task Update(Product product)
        {
            throw new NotImplementedException();
            //Save();
        }
        public Task Delete(int productId)
        {
            throw new NotImplementedException();
            //Save();
        }
        private void Save()
        {
            _context.SaveChanges(); 
        }
    }
}
