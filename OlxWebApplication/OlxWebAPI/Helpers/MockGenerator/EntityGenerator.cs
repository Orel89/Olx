using OlxCore.Entities;
using System.Diagnostics.Metrics;

namespace OlxWebAPI.Helpers.MockGenerator
{
    public class EntityGenerator
    {
        public static List<Category> _categories = new();
        public static List<Subcategory> _subcategories = new();

        public static void InitializeMock()
        {

            #region -- Subcategories --

            _subcategories = new List<Subcategory>
            {
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Sport",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Retro",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Sofas",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Tables",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Chairs",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Flowers",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Fertilizer",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Ground",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Footwear",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Jackets",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "T-shirts",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Sportswear",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Rings",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Necklaces",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Bracelets",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptops",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Processors",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "RAM",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Keyboards",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Speakers",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Vitamins",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Protein",
                },
                new Subcategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Drinks",
                },

                #endregion

            };

            #region -- Categories --

            _categories = new List<Category>
            {
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Car",
                    Subcategories = _subcategories.Where(s => s.Name == "Sport"
                    || s.Name == "Retro").ToList(),
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Motorcycles",
                    Subcategories = _subcategories.Where(s => s.Name == "Sport"
                    || s.Name == "Retro").ToList(),
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Fashion",
                    Subcategories = _subcategories.Where(s => s.Name == "Footwear"
                    || s.Name == "Jackets"
                    || s.Name == "T-shirts"
                    | s.Name == "Sportswear").ToList(),
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Jewelry",
                    Subcategories = _subcategories.Where(s => s.Name == "Rings"
                    || s.Name == "Necklaces"
                    || s.Name == "Bracelets").ToList(),
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Garden",
                    Subcategories = _subcategories.Where(s => s.Name == "Flowers"
                    || s.Name == "Fertilizer"
                    || s.Name == "Ground").ToList(),
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Nutrition",
                    Subcategories = _subcategories.Where(s => s.Name == "Vitamins"
                    || s.Name == "Protein"
                    || s.Name == "Drinks").ToList(),
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Furniture",
                    Subcategories = _subcategories.Where(s => s.Name == "Sofas"
                    || s.Name == "Tables"
                    || s.Name == "Chairs").ToList(),
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Computer Equipment",
                    Subcategories = _subcategories.Where(s => s.Name == "Laptops"
                    || s.Name == "Processors"
                    || s.Name == "Keyboards"
                    || s.Name == "Speakers").ToList(),
                },
            };

            #endregion

        }
    }
}
