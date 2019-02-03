using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFDbFirstApproachExample.IRepository;
using EFDbFirstApproachExample.Models;
using EFDbFirstApproachExample.DataAccessLayer;

namespace EFDbFirstApproachExample.RepositoryLayer.InMemoryRepositories
{
    public class CategoriesInMemoryRepositories : ICategoryRepository
    {
        CategoriesInMemoryAccessLayer categoriesInMemoryAccessLayer = new CategoriesInMemoryAccessLayer();

        public Category FindCategoryByName(string name)
        {
            return categoriesInMemoryAccessLayer.FindCategoryByName(name);
        }

        public List<Category> GetCategories()
        {
            return categoriesInMemoryAccessLayer.GetCategories();
        }

        public Category GetCategoryByID(int id)
        {
            return categoriesInMemoryAccessLayer.GetCategoryByID(id);
        }
    }
}