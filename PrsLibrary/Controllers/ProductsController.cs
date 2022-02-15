using Microsoft.EntityFrameworkCore;
using PrsLibrary.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Controllers {
    
    public class ProductsController {

        private readonly PrsDbContext _context;

        // Constructor
        public ProductsController(PrsDbContext context) {
            _context = context;
        }

        //// 5 Methods/ Functions
        // 1. Get all Products
        public IEnumerable<Product> GetAll() {
            return _context.Products.Include(x => x.Vendor).ToList();
        }

        // 2. Get Product by Primary Key
        public Product GetByPk(int id) {
            return _context.Products.Include(x => x.Vendor)
                .SingleOrDefault(x => x.Id == id);
        }

        // 3. Insert Statement
        public Product Create(Product product) {
            if (product is null)
            {
                throw new ArgumentNullException("user");
            }
            if (product.Id != 0)
            {
                throw new ArgumentException("Product.Id must be zero!");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        // 4 - Update
        public void Change(Product product) {
            _context.SaveChanges();
        }

        // 5. Delete
        public void Remove(int id) {
            var product = _context.Products.Find(id);
            if (product is null)
            {
                throw new Exception("Product not found!");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

    }
}
