using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Exeption;

namespace BLL.Success
{[Serializable]
    public class JournalAccess
    {
        public List<Journal> Jour { get; set; } = new List<Journal>();
        public void AddSubject(Journal journal)
        {
            Jour.Add(journal);
        }

        public void RemoveSubject(int ind)
        {
            if (ind < 0)
                throw new SuccessExeption("Index out of range");
            Jour.RemoveAt(ind);
        }
        public void AddMark(int ind,int Mark)
        {
            if (ind < 0 || ind > Jour.Count)
                throw new SuccessExeption("Index out of range");
            Jour[ind].AddMark(Mark);
        }
        public void EditMark(int ind,int index,int newmark)
        {
            if (ind < 0 || ind > Jour.Count)
                throw new SuccessExeption("Index out of range");
            if (index < 0 || index > Jour[ind].Mark.Count)
                throw new SuccessExeption("Index out of range");
            Jour[ind].EditMark(index, newmark);
        }
        public int MidleMark()
        {
            int con = 0;
            int a = 0;
            foreach (var c in Jour)
                foreach (var b in c.Mark)
                { a += b; con++; }
            return a / con;
        }
        public int MidleMk(Journal journal)
        {
            int con = 0;
            int a = 0;
                foreach (var b in journal.Mark)
                { a += b; con++; }
            return a / con;
        }
        public string GetMarkBySubject(int ind)
        {
            string els = $"Subject\t\t{Jour[ind].Subject}\t\tMarks:";
            foreach (var a in Jour[ind].Mark)
                els += $"\t{a},";
            return els;
        }
        public string GetAllMarks()
        {
            string el = "";
            foreach (var a in Jour)
            {
                el += $"Subject\t\t{a.Subject}\t\tMarks:";
                foreach (var b in a.Mark)
                    el += $"\t{b}";
                el += ";\n";
            }
            return el;
        }
    }
}
