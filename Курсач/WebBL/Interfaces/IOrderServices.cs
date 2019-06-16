using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBL.DTO;

namespace WebBL.Interfaces
{
    public interface IOrderServices
    {
        OrderDTO Get(int? id);
        IEnumerable<OrderDTO> Get();
        void Add(OrderDTO c);
        void Delete(int? id);
        void Dispose();
    }
}
