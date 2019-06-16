using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("Component")]
    public class Data : Component
    {
        public string name { get; set; }
        public int time { get; set; }

        public Data(int time,string day)
        {
            this.name = day;
            this.time = time;
        }
        public override int GetSomeData()
        {
            return time;
        }

        public override string ToString()
        {
            return " Day on the week: " + name + " Time: " + time;
        }

        public override string Display(int depth)
        {
            return new String('-', depth) + ToString();

        }

    }
}
