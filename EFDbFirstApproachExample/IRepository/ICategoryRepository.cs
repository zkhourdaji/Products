using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFDbFirstApproachExample.Models;

namespace EFDbFirstApproachExample.IRepository
{
    public interface ICategoryRepository
    {

        List<Category> GetCategories();
        Category FindCategoryByName(String name);
        Category GetCategoryByID(int id);
    }
}