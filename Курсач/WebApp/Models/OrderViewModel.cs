using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPL.Model
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int User { get; set; }

        public string OrderedItems { get; set; }
       
        public string Address { get; set; }

        public string Status { get; set; }
    }
}
