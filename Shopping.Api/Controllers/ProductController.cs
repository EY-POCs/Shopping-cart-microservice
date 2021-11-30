using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Shopping.Api.Models;
using Shopping.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductContext _context;
        public ProductController(ProductContext context, ILogger<ProductController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            // var rnd = new Random();
            // return Enumerable.Range(1, 5).Select(x => new Product 
            // {
            //     Name = "asd"
            // })
            // .ToArray();
            return await _context
                            .Products
                            .Find(x =>true)
                            .ToListAsync();
        }
    }
}
