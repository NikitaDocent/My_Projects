using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Student;
using BLL.Exeption;

namespace BLL.Group
{
    [Serializable]
    public class Groups
    {
        public int indGroup { get; set; }
        public List<Students> Students { get; set; } = new List<Students>();

        public Groups(int ind)
        {
            if (ind <= 0)
                throw new SuccessExeption("Index out of range");
            indGroup = ind;
            Students = new List<Students>();
        }
        //Add student in group
        public void AddStudent(Students student)
        {
            student.group = indGroup;
            Students.Add(student);
        }
        //Remove student from group
        public void RemoveStudent(int ind)
        {
            if (ind < 0 || ind > Students.Count)
                throw new SuccessExeption("Index out of range");
            Students.RemoveAt(ind);
        }

        public Groups() { }
        public override string ToString() => "Group: " + indGroup + "Count of students: " + Students.Count+"\n";
    }
}
