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
    public class Сalendar : Component
    {
        public string name { get; set; }

        public List<Data> datas = new List<Data>();

        public Сalendar(string nam) => this.name = nam;

        public override string Display(int depth)
        {
            return new String('-', depth) + name;
        }

        public void AddData(int time,string day)
        {
            datas.Add(new Data(time, day));
        }

        public override int GetSomeData()
        {
            return datas.Count;
        }

        public override string ToString()
        {
            string res = "";
            foreach (Data a in datas)
                res += a.ToString();
            return name + "\nMy schedule:\n" + res;
        }
    }
}
