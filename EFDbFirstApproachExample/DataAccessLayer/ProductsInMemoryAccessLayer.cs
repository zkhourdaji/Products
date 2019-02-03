using EFDbFirstApproachExample.Models;
using System;
using System.Collections.Generic;

namespace EFDbFirstApproachExample.DataAccessLayer
{

    public class ProductsInMemoryAccessLayer
    {
        CategoriesInMemoryAccessLayer categoriesInMemoryAccessLayer = new CategoriesInMemoryAccessLayer();
        BrandsInMemoryAccessLayer brandsInMemoryAccessLayer = new BrandsInMemoryAccessLayer();

        public List<Product> GetProducts()
        {
            return new List<Product>
            {

                new Product
                {
                    ProductID = 1,
                    BrandID = brandsInMemoryAccessLayer.FindBrandByName("Apple").BrandID,
                    Brand = brandsInMemoryAccessLayer.FindBrandByName("Apple"),
                    CategoryID = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics").CategoryID,
                    Category = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics"),
                    AvailabilityStatus = "InStock",
                    Active = true,
                    DateOfPurchase = DateTime.Now,
                    Price = 1200,
                    ProductName = "iPhone"
                },

                new Product
                {
                    ProductID = 2,
                    BrandID = brandsInMemoryAccessLayer.FindBrandByName("Google").BrandID,
                    Brand = brandsInMemoryAccessLayer.FindBrandByName("Google"),
                    CategoryID = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics").CategoryID,
                    Category = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics"),
                    AvailabilityStatus = "Out of Stock",
                    Active = true,
                    DateOfPurchase = DateTime.Now,
                    Price = 1200,
                    ProductName = "Pixel"
                },

                new Product
                {
                    ProductID = 3,
                    BrandID = brandsInMemoryAccessLayer.FindBrandByName("Microsoft").BrandID,
                    Brand = brandsInMemoryAccessLayer.FindBrandByName("Microsoft"),
                    CategoryID = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics").CategoryID,
                    Category = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics"),
                    AvailabilityStatus = "InStock",
                    Active = true,
                    DateOfPurchase = DateTime.Now,
                    Price = 1200,
                    ProductName = "Surface Laptop"
                },

                new Product
                {
                    ProductID = 4,
                    BrandID = brandsInMemoryAccessLayer.FindBrandByName("Microsoft").BrandID,
                    Brand = brandsInMemoryAccessLayer.FindBrandByName("Microsoft"),
                    CategoryID = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics").CategoryID,
                    Category = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics"),
                    AvailabilityStatus = "Out of Stock",
                    Active = true,
                    DateOfPurchase = DateTime.Now,
                    Price = 1200,
                    ProductName = "Surface Book"
                },

                new Product
                {
                    ProductID = 5,
                    BrandID = brandsInMemoryAccessLayer.FindBrandByName("Sony").BrandID,
                    Brand = brandsInMemoryAccessLayer.FindBrandByName("Sony"),
                    CategoryID = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics").CategoryID,
                    Category = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics"),
                    AvailabilityStatus = "InStock",
                    Active = true,
                    DateOfPurchase = DateTime.Now,
                    Price = 1200,
                    ProductName = "Sony Experia"
                },

                new Product
                {
                    ProductID = 6,
                       BrandID = brandsInMemoryAccessLayer.FindBrandByName("Samsung").BrandID,
                    Brand = brandsInMemoryAccessLayer.FindBrandByName("Samsung"),
                    CategoryID = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics").CategoryID,
                    Category = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics"),
                    AvailabilityStatus = "InStock",
                    Active = true,
                    DateOfPurchase = DateTime.Now,
                    Price = 1200,
                    ProductName = "Galaxy Edge"
                },

                new Product
                {
                    ProductID = 7,
                    BrandID = brandsInMemoryAccessLayer.FindBrandByName("HTC").BrandID,
                    Brand = brandsInMemoryAccessLayer.FindBrandByName("HTC"),
                    CategoryID = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics").CategoryID,
                    Category = categoriesInMemoryAccessLayer.FindCategoryByName("Electronics"),
                    AvailabilityStatus = "InStock",
                    Active = true,
                    DateOfPurchase = DateTime.Now,
                    Price = 1200,
                    ProductName = "HTC ONE"
                },

                new Product
                {
                    ProductID = 8,
                    BrandID = brandsInMemoryAccessLayer.FindBrandByName("Sony").BrandID,
                    Brand = brandsInMemoryAccessLayer.FindBrandByName("Sony"),
                    CategoryID = categoriesInMemoryAccessLayer.FindCategoryByName("Applicances").CategoryID,
                    Category = categoriesInMemoryAccessLayer.FindCategoryByName("Applicances"),
                    AvailabilityStatus = "InStock",
                    Active = true,
                    DateOfPurchase = DateTime.Now,
                    Price = 1200,
                    ProductName = "Hyper Dryer"
                }
            };
        }
    }
}