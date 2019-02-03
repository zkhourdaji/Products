using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFDbFirstApproachExample.Models;

namespace EFDbFirstApproachExample.DataAccessLayer
{
    public class CategoriesInMemoryAccessLayer
    {

        List<Category> categories = new List<Category>
            {
                new Category { CategoryID = 1, CategoryName = "Electronics" },
                new Category { CategoryID = 2, CategoryName = "Applicances" },
                new Category { CategoryID = 3, CategoryName = "Sports"}
            };


        public List<Category> GetCategories()
        {
            return categories;
        }

        public Category GetCategoryByID(int id)
        {
            foreach (Category category in categories)
            {
                if (category.CategoryID == id)
                {
                    return category;
                }
            }

            return null;
        }

        public Category FindCategoryByName(string name)
        {
            foreach (Category category in categories)
            {
                if (category.CategoryName == name)
                {
                    return category;
                }
            }

            return null;
        }


    }
}