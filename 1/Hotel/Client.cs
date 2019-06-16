using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignAgency
{
    [Table("Clients")]
    public class Client
    {
        public Client()
        {
        }
        public Client(Client client)
        {
            this.Id = client.Id;
            this.Money = client.Money;
            this.Name = client.Name;
            this.services = client.services;
            this.HasService = client.HasService;
        }
        public Client(string name, int money)
        {
            this.Money = money;
            this.Name = name;
        }
        public int Id { get; set; }
        public int Money { get; set; }
        public string Name { get; set; }
        public bool HasService { get; set; } = false;
        public string services { get; set; } = "";
        public void BookService(DesignService service)
        {
                this.services = services + service.ToString() + "\n";
                Money = Money - service.Cost;
                HasService = true;
        }
        public string Info()
        {
            return "Name: " + Name + "\tMoney: " + Money + " grn.";
        }
        public override string ToString()
        {
            return "Name: " + Name + "\tMoney: " + Money + " grn." +  "\n" + services;
        }
    }
}
