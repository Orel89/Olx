using OlxCore.Entities.DTOModels;
using OlxCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxCore.Entities
{
    public class Announcement : EntityBase
    {
        public string UserName { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public List<Image> Photos { get; set; } = new List<Image>();
        public string Description { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
