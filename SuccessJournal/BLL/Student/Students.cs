using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Group;
using BLL.Success;

namespace BLL.Student
{
    [Serializable]
    public class Students
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int group { get; set; }

        public JournalAccess journal = new JournalAccess();

        public Students(string fn,string ln)
        {
            Firstname = fn;
            Lastname = ln;
            group = 0;//if group == 0, this student without group
            journal = new JournalAccess();
        }

        public Students(string fn, string ln,Groups grp,JournalAccess jour)
        {
            Firstname = fn;
            Lastname = ln;
            grp.AddStudent(new Students(fn, ln));
            group = grp.indGroup;
            journal = jour;
        }
        public Students() { }
        public override string ToString() => "Name:\t\t" + Firstname + "\tSurname:\t\t" + Lastname + "\tGroup:\t\t" + group;
    }
}
