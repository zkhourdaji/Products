using System;
using System.Collections.Generic;
using System.Linq;
using EFDbFirstApproachExample.Models;
using System.Web;

namespace EFDbFirstApproachExample.IRepository
{
    public interface IBrandsRepository
    {

        List<Brand> GetBrands();
        Brand GetBrandByID(int id);
        Brand FindBrandByName(string name);
    }
}