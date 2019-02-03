using EFDbFirstApproachExample.Models;
using System.Collections.Generic;

namespace EFDbFirstApproachExample.DataAccessLayer
{
    public class BrandsInMemoryAccessLayer
    {

        List<Brand> brands = new List<Brand>
            {
                new Brand { BrandID = 1, BrandName = "Apple" },
                new Brand { BrandID = 2, BrandName = "Google" },
                new Brand { BrandID = 3, BrandName = "Microsoft" },
                new Brand { BrandID = 4, BrandName = "Sony" },
                new Brand { BrandID = 5, BrandName = "Samsung" },
                new Brand { BrandID = 6, BrandName = "HTC" },
                new Brand { BrandID = 7, BrandName = "OnePlus" },
                new Brand { BrandID = 8, BrandName = "Verizon" },
                new Brand { BrandID = 9, BrandName = "Toyota" },
                new Brand { BrandID = 10, BrandName = "Coca-Cola" },
                new Brand { BrandID = 11, BrandName = "Mercedes-Benz" },
                new Brand { BrandID = 12, BrandName = "IBM" },
                new Brand { BrandID = 13, BrandName = "Nike" }
            };

        public List<Brand> GetBrands()
        {
            return brands;
        }

        public Brand GetBrandByID(int id)
        {
            foreach (Brand brand in brands)
            {
                if (brand.BrandID == id)
                {
                    return brand;
                }
            }
            return null;
        }

        public Brand FindBrandByName(string name)
        {
            foreach (Brand brand in brands)
            {
                if (brand.BrandName == name)
                {
                    return brand;
                }
            }
            return null;
        }

    }
}