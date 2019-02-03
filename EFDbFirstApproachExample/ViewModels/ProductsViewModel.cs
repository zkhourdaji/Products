using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFDbFirstApproachExample.Models;

namespace EFDbFirstApproachExample.ViewModels
{
    public class ProductsViewModel
    {

        public List<Product> Products { get; }

        public ProductsViewModel(List<Product> products)
        {
            Products = products;
        }

        public Product this[int i]
        {
            get
            {
                return Products.ElementAt(i);
            }
        }
    }
}