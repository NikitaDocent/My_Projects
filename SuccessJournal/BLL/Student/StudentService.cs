using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Serialization;
using BLL.Success;
using BLL.Student;
using BLL.Group;
using BLL.Exeption;

namespace BLL.Student
{
    public class StudentService
    {
        List<Students> students { get; set; } = new List<Students>();
        private Serialize<Students> Datbase;

        public StudentService()
        {
            Datbase = new Serialize<Students>("Students");
            try
            {
                var a = Datbase.Load();
                students = a.ToList();
            }
            catch (Exception e)
            {
                Datbase.Save(students.ToArray());
            }
        }
        public int Last
        {
            get { return students.Count; }
        }
        public StudentService(Serialize<Students> sr)
        {
            Datbase = sr;
            try
            {
                var a = Datbase.Load();
                students = a.ToList();
            }
            catch (Exception e)
            {
                Datbase.Save(students.ToArray());
            }
        }
        //Add student
        public void Add(string name, string surname) => students.Add(new Students
        {
            Firstname = String.IsNullOrEmpty(name.Trim()) ? throw new SuccessExeption("Invald name") : name,
            Lastname = String.IsNullOrEmpty(surname.Trim()) ? throw new SuccessExeption("Invalid surname") : surname
        });
        //Remove student
        public void Remove(int ind)
        {
            if (ind < 0 || ind >= students.Count)
                throw new SuccessExeption("Index out of range");
            students.RemoveAt(ind);
        }
        //Edit student
        public void Edit(int ind, string name, string surname)
        {
            if (ind < 0 || ind >= students.Count)
                throw new SuccessExeption("Index out of range");
            var a = students[ind];
            a.Firstname = name;
            a.Lastname = surname;
            students[ind] = a;
        }
        //find by name|surname
        public Students FindByNameSurname(string name,string surname) => students.Find(x => x.Firstname == name & x.Lastname==surname);
        //find by group
        public Students FindByGroup(int numb) => students.Find(x => x.group == numb);
        //find by MidleRange
        public Students FindByMr(int numb) => students.Find(x => x.journal.MidleMark() == numb);
        //find by Mark
        public Students FindByMark() => students.Find(x => x.journal.MidleMark() >= 80);
        //find by Mark and Subject
        public Students FindByMJ(Journal jourl) => students.Find(x => x.journal.MidleMk(jourl) >=80);
        //Get all students
        public string GetAll()
        {
            string list = "";
            foreach (var a in students)
                list += "Name:\t\t" + a.Firstname + "\tSurname:\t\t" + a.Lastname + "\tGroup:\t\t" + a.group + ";\n";
            return list;
        }
        //get needed student
        public Students GetInfo(int ind) => ind < 0 || ind >= students.Count ? null : students[ind];
        //add subject to journal
        public void AddSubject(int ind,Journal journal)
        {
            if (ind < 0 || ind >= students.Count)
                throw new SuccessExeption("Index out of range");
            students[ind].journal.AddSubject(journal);
        }
        //delete subject from student
        public void RemoveSubject(int ind,int index)
        {
            if (ind < 0 || ind >= students.Count)
                throw new SuccessExeption("Index out of range");
            if (index < 0 || index >= students[ind].journal.Jour.Count)
                throw new SuccessExeption("Index out of range");
            students[ind].journal.RemoveSubject(index);

        }
        //Show marks of all Students
        public string ShowMarksAllStudents()
        {
            string el = "";
            foreach(var a in students)
            {
                el +="Name:\t"+a.Firstname+"\tSurname:\t"+a.Lastname+"\tMarks:\n"+ a.journal.GetAllMarks()+"\n";
            }
            return el;
        }

        //save
        public void Save()
        {
            Datbase.Save(students.ToArray());
        }
    }
}
