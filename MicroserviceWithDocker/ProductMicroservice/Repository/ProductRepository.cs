using ProductMicroservice.DatabaseContext;
using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext productContext;

        public ProductRepository(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        public void DeleteProduct(int id)
        {
            var product = productContext.Products.Find(id);
            productContext.Products.Remove(product);
            Save();
        }

        public Product GetProductById(int id)
        {
            return productContext.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productContext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            productContext.Add(product);
            Save();
        }

        public void Save()
        {
            productContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            productContext.Update(product);
            Save();
        }
    }
}
