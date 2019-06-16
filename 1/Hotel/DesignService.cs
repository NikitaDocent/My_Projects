using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignAgency
{
    [Table("Services")]
    public class DesignService
    {
        public DesignService()
        {
        }
        public DesignService(string tag,string description,string type,int cost)
        {
            this.Tag = tag;
            this.Description = description;
            this.Cost = cost;
            this.Type = type;
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public string Type  { get; set; }
        public int Cost { get; set; }
        public override string ToString()
        {
            return "Type: " + Type + ",\t" +  Tag + "\tCost: " + Cost + " grn,\nDescription: "+ Description + " .";
        }
    }
}
