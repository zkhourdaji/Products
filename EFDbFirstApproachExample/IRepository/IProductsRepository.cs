using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDbFirstApproachExample.Models;

namespace EFDbFirstApproachExample.IRepository
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();

    }
}
