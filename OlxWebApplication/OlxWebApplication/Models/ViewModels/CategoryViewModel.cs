using OlxCore.Entities;
using OlxCore.Interfaces;

namespace OlxWebApplication.Models.ViewModels
{
    public class CategoryViewModel : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
