using OlxCore.Entities;
using System.Diagnostics.Metrics;

namespace OlxWebApplication.Helpers.MockGenerator
{
    public class EntityGenerator
    {
        public static List<Category> _categories = new();

        public static void InitializeMock()
        {
            _categories = new List<Category>
            {
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Car",
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Fashion",
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Jewelry",
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Garden",
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Nutrition",
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Furniture",
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Computer Equipment",
                },
            };
        }

    }
}
