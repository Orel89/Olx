using OlxCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxCore.Entities
{
    public class Category : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
