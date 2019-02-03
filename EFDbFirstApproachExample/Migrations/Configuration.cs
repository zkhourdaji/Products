namespace EFDbFirstApproachExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDbFirstApproachExample.Models.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EFDbFirstApproachExample.Models.CompanyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Brands.AddOrUpdate(
                new Models.Brand { BrandID = 1, BrandName = "Apple" },
                new Models.Brand { BrandID = 2, BrandName = "Google" },
                new Models.Brand { BrandID = 3, BrandName = "Microsoft" },
                new Models.Brand { BrandID = 4, BrandName = "Sony" },
                new Models.Brand { BrandID = 5, BrandName = "Samsung" },
                new Models.Brand { BrandID = 6, BrandName = "HTC" },
                new Models.Brand { BrandID = 7, BrandName = "OnePlus" }

                );

            context.Categories.AddOrUpdate(
                new Models.Category { CategoryID = 1, CategoryName = "Electronics" },
                new Models.Category { CategoryID = 2, CategoryName = "Applicances" },
                new Models.Category { CategoryID = 3, CategoryName = "Sports"}
                );

            context.Products.AddOrUpdate(new Models.Product
            {
                ProductID = 1,
                BrandID = 1,
                CategoryID = 1,
                AvailabilityStatus = "InStock",
                Active = true,
                DateOfPurchase = DateTime.Now,
                Price = 1200,
                ProductName = "iPhone",
                Photo = "https://media.wired.com/photos/5b22c5c4b878a15e9ce80d92/master/w_2400,c_limit/iphonex-TA.jpg"
            });

            context.Products.AddOrUpdate(new Models.Product
            {
                ProductID = 2,
                BrandID = 2,
                CategoryID = 1,
                AvailabilityStatus = "Out of Stock",
                Active = true,
                DateOfPurchase = DateTime.Now,
                Price = 1200,
                ProductName = "Pixel",
                Photo = "https://cdn.images.express.co.uk/img/dynamic/59/590x/Google-Pixel-3-XL-982796.jpg?r=1533126577272"
            });

            context.Products.AddOrUpdate(new Models.Product
            {
                ProductID = 3,
                BrandID = 3,
                CategoryID = 1,
                AvailabilityStatus = "InStock",
                Active = true,
                DateOfPurchase = DateTime.Now,
                Price = 1200,
                ProductName = "Surface Laptop",
                Photo = "https://i.ytimg.com/vi/mAsp7a5uUQI/maxresdefault.jpg"
            });

            context.Products.AddOrUpdate(new Models.Product
            {
                ProductID = 4,
                BrandID = 3,
                CategoryID = 1,
                AvailabilityStatus = "Out of Stock",
                Active = true,
                DateOfPurchase = DateTime.Now,
                Price = 1200,
                ProductName = "Surface Book",
                Photo = "https://assets.pcmag.com/media/images/436222-microsoft-surface-book-2016.jpg?width=810&height=456"
            });

            context.Products.AddOrUpdate(new Models.Product
            {
                ProductID = 5,
                BrandID = 4,
                CategoryID = 1,
                AvailabilityStatus = "InStock",
                Active = true,
                DateOfPurchase = DateTime.Now,
                Price = 1200,
                ProductName = "Sony Experia",
                Photo = "https://cf5.s3.souqcdn.com/item/2015/06/01/84/01/41/1/item_XL_8401411_8090817.jpg"
            });

            context.Products.AddOrUpdate(new Models.Product
            {
                ProductID = 6,
                BrandID = 5,
                CategoryID = 1,
                AvailabilityStatus = "InStock",
                Active = true,
                DateOfPurchase = DateTime.Now,
                Price = 1200,
                ProductName = "Galaxy Edge",
                Photo = "https://www.samsung.com/global/galaxy/galaxys6/galaxy-s6-edge/images/galaxy-s6-edge_gallery_left-perspective_gold.png"
            });

            context.Products.AddOrUpdate(new Models.Product
            {
                ProductID = 7,
                BrandID = 6,
                CategoryID = 1,
                AvailabilityStatus = "InStock",
                Active = true,
                DateOfPurchase = DateTime.Now,
                Price = 1200,
                ProductName = "HTC ONE",
                Photo = "https://images.techhive.com/images/article/2014/03/htcone-100258388-large.jpg"
            });

            context.Products.AddOrUpdate(new Models.Product
            {
                ProductID = 8,
                BrandID = 4,
                CategoryID = 2,
                AvailabilityStatus = "InStock",
                Active = true,
                DateOfPurchase = DateTime.Now,
                Price = 1200,
                ProductName = "Hyper Dryer",
                Photo = "https://images-na.ssl-images-amazon.com/images/I/61WFt3pAZsL._SY450_.jpg"
            });
        }
    }
}
