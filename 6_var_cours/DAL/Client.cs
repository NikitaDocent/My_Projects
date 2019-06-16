using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class Client
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string bank_account { get; set; }
        public int money { get; set; }
        public List<string> building_Offers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fn"></param>
        /// <param name="ln"></param>
        /// <param name="b_a"></param>
        public Client(string firstname, string lastname, string b_a,int mon, Building_Offers b)
        {
            this.name = firstname;
            this.surname = lastname;
            this.bank_account = b_a;
            this.money = mon;
            this.building_Offers = b.Offer;
        }
        public Client() { }
    }
}
