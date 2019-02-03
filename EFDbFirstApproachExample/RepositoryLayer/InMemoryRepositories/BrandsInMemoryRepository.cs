using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFDbFirstApproachExample.IRepository;
using EFDbFirstApproachExample.Models;
using EFDbFirstApproachExample.DataAccessLayer;

namespace EFDbFirstApproachExample.RepositoryLayer.InMemoryRepositories
{
    public class BrandsInMemoryRepository : IBrandsRepository
    {

        BrandsInMemoryAccessLayer brandsInMemoryAccessLayer = new BrandsInMemoryAccessLayer();

        public Brand FindBrandByName(string name)
        {
            return brandsInMemoryAccessLayer.FindBrandByName(name);
        }

        public Brand GetBrandByID(int id)
        {
            return brandsInMemoryAccessLayer.GetBrandByID(id);
        }

        public List<Brand> GetBrands()
        {
            return brandsInMemoryAccessLayer.GetBrands();
        }


    }
}