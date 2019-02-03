using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFDbFirstApproachExample.Models;
using EFDbFirstApproachExample.DataAccessLayer;
using EFDbFirstApproachExample.IRepository;

namespace EFDbFirstApproachExample.RepositoryLayer.InMemoryRepositories
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        ProductsInMemoryAccessLayer productsInMemoryAccessLayer = new ProductsInMemoryAccessLayer();

        public List<Product> GetProducts()
        {
            return productsInMemoryAccessLayer.GetProducts();
        }
        
    }
}