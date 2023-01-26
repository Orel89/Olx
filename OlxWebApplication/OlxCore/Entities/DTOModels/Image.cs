using OlxCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxCore.Entities.DTOModels
{
    public class Image : EntityBase
    {
        public Image(byte[] photo) 
        { 
            Photo = photo;
        }

        public byte[] Photo { get; set; }
    }
}
