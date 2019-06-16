using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBL.DTO;

namespace WebBL.Interfaces
{
    public interface ICategoryService
    {
        CategoryDTO Get(int? id);
        IEnumerable<CategoryDTO> Get();
        void Add(CategoryDTO c);
        void Delete(int? id);
        void Dispose();
    }
}
