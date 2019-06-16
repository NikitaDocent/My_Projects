using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace UI.Models
{
    [Table("Clients")]
    public class MClient
    {
        public MClient()
        {
        }
        public MClient(MClient client)
        {
            this.Id = client.Id;
            this.Money = client.Money;
            this.Name = client.Name;
            this.services = client.services;
            this.HasService = client.HasService;
        }
        public MClient(string name, int money)
        {
            this.Money = money;
            this.Name = name;
        }
        public int Id { get; set; }
        public int Money { get; set; }
        public string Name { get; set; }
        public bool HasService { get; set; } = false;
        public string services { get; set; } = "";
        public void BookService(MService service)
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
            return "Name: " + Name + "\tMoney: " + Money + " grn." + "\n" + services;
        }
    }
}