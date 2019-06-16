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
    public class Notes : Component
    {
        public string name { get; set; }

        public Notes(string nam) => this.name = nam;

        public override string Display(int depth)
        {
            return new String('-', depth) + ToString();
        }

        public override int GetSomeData()
        {
            return 0;
        }

        public override string ToString()
        {
            return "New note: " + name + " ;\n";
        }
    }
}
