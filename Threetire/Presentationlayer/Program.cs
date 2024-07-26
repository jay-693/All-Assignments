using System;
using System.Collections.Generic;
using BusinessLogicLayer;
using DataAccessLayer;

namespace PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductRepository productRepository = new ProductRepository();
            IProductService productService = new ProductService(productRepository);

            // Adding products
            productService.AddProduct(new Product { Id = 1, Name = "Laptop", Price = 999.99m });
            productService.AddProduct(new Product { Id = 2, Name = "Smartphone", Price = 499.99m });

            // Displaying products
            Console.WriteLine("Products:");
            foreach (var product in productService.GetAllProducts())
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }

            // Updating a product
            var productToUpdate = productService.GetProductById(1);
            if (productToUpdate != null)
            {
                productToUpdate.Price = 899.99m;
                productService.UpdateProduct(productToUpdate);
            }

            // Displaying updated products
            Console.WriteLine("\nUpdated Products:");
            foreach (var product in productService.GetAllProducts())
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }

            // Deleting a product
            productService.DeleteProduct(2);

            // Displaying products after deletion
            Console.WriteLine("\nProducts After Deletion:");
            foreach (var product in productService.GetAllProducts())
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
        }
    }
}
