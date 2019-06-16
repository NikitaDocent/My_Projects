using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDL;
using WebDL.EF;
using WebDL.Interfaces;


namespace WebBL.DTO
{
    public class UsersDTO
    {
        
        public int Id { get; set; }
        public string Type { get; set; }



        public string Name { get; set; }



        public string Surname { get; set; }



        public string Password { get; set; }



        public string Email { get; set; }


        public string TelNumb { get; set; }
    }
}
