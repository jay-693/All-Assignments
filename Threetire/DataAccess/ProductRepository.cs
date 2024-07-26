using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public IEnumerable<Product> GetAllProducts() => _products;

        public Product GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void AddProduct(Product product) => _products.Add(product);

        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
        }

        public void DeleteProduct(int id) => _products.RemoveAll(p => p.Id == id);
        static void Main(string[] args)
        {

        }
    }
}
