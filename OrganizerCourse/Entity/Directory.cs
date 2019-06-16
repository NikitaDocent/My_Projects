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
    public class Directory : Component
    {
        public string name { get; set; }
        public LinkedList<string> adress = new LinkedList<string>();

        public Directory(string nam)
        {
            this.name = nam;
        }

        public override int GetSomeData()
        {
            return adress.Count;
        }

        public void AddAdress(string name, string adress) => adress.Add("Companion:\t" + name + "\tAdress:\t" + adress);

        public override string Display(int depth)
        {
            return new String('-', depth) + ToString();
        }

        public override string ToString()
        {
            string res = "";
            foreach(string a in adress)
            {
                res += a + ";\n";
            }
            return name + "\n" + res;
        }
    }
}
