using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBL.DTO
{
    public class ItemDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MainPhoto { get; set; }

        public string OtherPhotos { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public int Category { get; set; }
    }
}
