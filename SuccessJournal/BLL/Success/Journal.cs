using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Exeption;

namespace BLL.Success
{
    [Serializable]
    public class Journal
    {
        public string Subject { get; set; }
        public List<int> Mark { get; set; } = new List<int>();

        public Journal() { }

        public Journal(string Sub, int mark)
        {
            Subject = Sub;
            Mark.Add(mark);
        }
        public void AddMark(int mark)
        {
            Mark.Add(mark);
        }
        public void EditMark(int ind, int newmark)
        {
            if (ind < 0 || ind > Mark.Count)
                throw new SuccessExeption("Index out of range");
            var a = Mark[ind];
            a = newmark;
            Mark[ind] = a;
        }
    }
}