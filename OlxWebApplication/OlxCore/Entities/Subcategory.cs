using OlxCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxCore.Entities
{
    public class Subcategory : EntityBase
    {
        public string Name { get; set; } = null!;

        public string ImageSource { get; set; } = string.Empty;
        public virtual ICollection<Category> Categories { get; set; }
    }
}
