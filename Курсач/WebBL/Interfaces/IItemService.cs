using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBL.DTO;

namespace WebBL.Interfaces
{
    public interface IItemService
    {
        ItemDTO Get(int? id);
        IEnumerable<ItemDTO> Get();
        void Add(ItemDTO i);
        void Delete(int? id);
        void Dispose();
    }
}
