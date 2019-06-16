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
    public class Notebook : Component
    {
        public string name { get; set; }

        public List<Notes> notes = new List<Notes>();

        public Notebook(string nam)
        {
            this.name = nam;
        }

        public override int GetSomeData()
        {
           return notes.Count;
        }

        public void NewNote(string str)
        {
            notes.Add(new Notes(str));
        }

        public override string Display(int depth)
        {
            return new String('-', depth) + ToString();
        }

        public override string ToString()
        {
            string res = "";
            foreach(Notes a in notes)
            {
                res += a.ToString();
            }
            return name + "\nMy notes:\n" + res;
        }
    }
}
