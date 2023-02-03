using OlxCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxCore.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
