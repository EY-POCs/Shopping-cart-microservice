using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Shopping.Api.Models;

namespace Shopping.Api.Repository
{
    public class ProductContext
    {
        private readonly string connectionString;
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            SendData(Products);
        }

        public IMongoCollection<Product> Products { get; }
        
        private  static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "HP lat",
                    Category = "Computer",
                    Description = "Description",
                    ImageFile = "http://images.png",
                    Price = 200.00M,
                },
                 new Product()
                {
                    Name = "HP lat",
                    Category = "Computer",
                    Description = "Description",
                    ImageFile = "http://images.png",
                    Price = 200.00M,
                },
                 new Product()
                {
                    Name = "Dell lat",
                    Category = "Computer",
                    Description = "Description",
                    ImageFile = "http://images.png",
                    Price = 600.00M,
                },
                 new Product()
                {
                    Name = "thinkpad",
                    Category = "Computer",
                    Description = "Description",
                    ImageFile = "http://images.png",
                    Price = 430.00M,
                },
                 new Product()
                {
                    Name = "Macbook Pro",
                    Category = "Computer",
                    Description = "Description",
                    ImageFile = "http://images.png",
                    Price = 1200.00M,
                },
                 new Product()
                {
                    Name = "Ipad 5",
                    Category = "Electronic",
                    Description = "Description",
                    ImageFile = "http://images.png",
                    Price = 100.00M,
                }
            };
        }
        private static void SendData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }

        }
    }
}
