using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public string User { get; set; }

        public string OrderedItems { get; set; }
       
        public string Address { get; set; }

        public string Status { get; set; }

        public string DateTime { get; set; }
    }
}
