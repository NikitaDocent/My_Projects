using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBL.DTO;

namespace WebBL.Interfaces
{
    public interface IUserService
    {
        
        UsersDTO GetUser(int? id);
        IEnumerable<UsersDTO> GetAllUsers();
        void Register(UsersDTO u);
        void Delete(int? id);
        void Dispose();
    }
}
