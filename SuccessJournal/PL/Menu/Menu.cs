using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Student;
using BLL.Group;
using BLL.Success;
using BLL.Exeption;

namespace PL.Menu
{
    public class Menu
    {
        private StudentService students;
        private GroupService groups;

        public void Run()
        {
            students = new StudentService();
            groups = new GroupService();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\tMenu");
                Console.WriteLine("\t\t1. Students\n\t\t2. Groups\n\t\t3. Find\n\t\t0. Exit");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "0":
                        students.Save();
                        groups.Save();
                        Environment.Exit(0);
                        break;
                    case "1":
                        Student();
                        break;
                    case "2":
                        Group();
                        break;
                    case "3":
                        Find();
                        break;
                    default:
                        Console.WriteLine("Wrong input\nPress any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
        #region Student
        private void Student()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1. Add Student\n2. Remove Student\n3. Edit Student\n4. Show Student info\n5. Show list with all Students\n6. Journal\n0.Exit");
                string answer = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "0":
                        run = false;
                        students.Save();
                        groups.Save();
                        break;
                    case "1":
                        try
                        {
                            Console.Write("Write Name: ");
                            string n = Console.ReadLine();
                            Console.Write("Write Surname: ");
                            string sn = Console.ReadLine();
                            students.Add(n, sn);
                            Console.WriteLine(students.GetInfo(students.Last - 1).ToString());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Write ind of student who want delete: ");
                            int ind = Convert.ToInt32(Console.ReadLine());
                            if (ind < 0 || ind >= students.Last)
                                throw new SuccessExeption("Index out of range");
                            students.Remove(ind);
                            Console.WriteLine("Succesfull deleted");
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "3":
                        try
                        {
                            Console.Write("Write ind of Visitor: ");
                            int ind = Convert.ToInt32(Console.ReadLine());
                            if (ind < 0 || ind >= students.Last)
                                throw new SuccessExeption("Index out of range");
                            Console.Write("Write Name: ");
                            string n = Console.ReadLine();
                            Console.Write("Write Surname: ");
                            string sn = Console.ReadLine();
                            students.Edit(ind, n, sn);
                            Console.Write("Succesfull edited!");
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "4":
                        try
                        {
                            Console.Write("Write ind of student: ");
                            int ind = Convert.ToInt16(Console.ReadLine());
                            if (ind < 0 || ind >= students.Last)
                                throw new SuccessExeption("Index out of range");
                            Console.WriteLine(students.GetInfo(ind).ToString());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "5":
                        try
                        {
                            Console.WriteLine(students.GetAll());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "6":
                        try
                        {
                            Console.WriteLine("1. Add Subject\n2. Remove Subject\n3.Show marks of all Students\n4.Marks \n0. Exit");
                            string ans = Console.ReadLine();
                            Console.Clear();
                            switch (ans)
                            {
                                case "0":
                                    students.Save();
                                    groups.Save();
                                    run = false;
                                    break;
                                case "1":
                                    try
                                    {
                                        Console.WriteLine("Write index\t");
                                        int ind = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Write subject\t");
                                        string Sub = Console.ReadLine();
                                        students.AddSubject(ind, new Journal(Sub, 0));
                                        Console.WriteLine("Succesfull");
                                        Console.ReadKey();
                                    }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                case "2":
                                    try
                                    {
                                        Console.WriteLine("Write index of Student\t");
                                        int ind = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Write index of Subject\t");
                                        int index = Convert.ToInt32(Console.ReadLine());
                                        students.RemoveSubject(ind, index);
                                        Console.WriteLine("Succesfull");
                                        Console.ReadKey();
                                    }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                case "3":
                                    try
                                    {
                                        Console.WriteLine(students.ShowMarksAllStudents());
                                        Console.WriteLine("Succesfull");
                                        Console.ReadKey();
                                    }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                case "4":
                                    try
                                    {
                                        Console.WriteLine("1. Add Marks Subjects\n2. Edit mark of Subject\n3.Show marks of all Students\n4. Midle mark\n5. Midle mark by Subject\n0. Exit");
                                        string anss = Console.ReadLine();
                                        Console.Clear();
                                        switch (anss)
                                        {
                                            case "1":
                                                try
                                                {
                                                    Console.WriteLine("Write index of Student\t");
                                                    int ind = Convert.ToInt32(Console.ReadLine());
                                                    Console.WriteLine("Write index of Subject\t");
                                                    int index = Convert.ToInt32(Console.ReadLine());
                                                    Console.WriteLine("Write mark:\t");
                                                    int mark = Convert.ToInt32(Console.ReadLine());
                                                    students.GetInfo(ind).journal.AddMark(index, mark);
                                                    Console.WriteLine("Succesfull");
                                                    Console.ReadKey();
                                                }
                                                catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                                break;
                                            case "2":
                                                try
                                                {
                                                    Console.WriteLine("Write index of Student\t");
                                                    int ind = Convert.ToInt32(Console.ReadLine());
                                                    Console.WriteLine("Write index of Subject\t");
                                                    int index = Convert.ToInt32(Console.ReadLine());
                                                    Console.WriteLine("Write index of mark\t");
                                                    int indx = Convert.ToInt32(Console.ReadLine());
                                                    Console.WriteLine("Write new mark:\t");
                                                    int mark = Convert.ToInt32(Console.ReadLine());
                                                    students.GetInfo(ind).journal.EditMark(index, indx, mark);
                                                    Console.WriteLine("Succesfull");
                                                    Console.ReadKey();
                                                }
                                                catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                                break;
                                            case "3":
                                                try
                                                {
                                                    Console.WriteLine(students.ShowMarksAllStudents());
                                                    Console.WriteLine("Succesfull");
                                                    Console.ReadKey();
                                                }
                                                catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                                break;
                                            case "4":
                                                try
                                                {
                                                    Console.WriteLine("Write index of Student:\t");
                                                    int ind = Convert.ToInt32(Console.ReadLine());
                                                    Console.WriteLine(students.GetInfo(ind).journal.MidleMark());
                                                    Console.WriteLine("Succesfull");
                                                    Console.ReadKey();
                                                }
                                                catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                                break;
                                            case "5":
                                                try
                                                {
                                                    Console.WriteLine("Write index of Student:\t");
                                                    int ind = Convert.ToInt32(Console.ReadLine());
                                                    Console.WriteLine("Write index of Subject:\t");
                                                    int index = Convert.ToInt32(Console.ReadLine());
                                                    Console.WriteLine(students.GetInfo(ind).journal.MidleMk(students.GetInfo(ind).journal.Jour[index]));
                                                    Console.WriteLine("Succesfull");
                                                    Console.ReadKey();
                                                }
                                                catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                                break;
                                            default:
                                                Console.WriteLine("Wrong input\nPress any key to continue");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                default:
                                    Console.WriteLine("Wrong input\nPress any key to continue");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong input\nPress any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }

        #endregion
        #region Group
        private void Group()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1. Add Group\n2. Remove Group\n3. Edit Group\n4. Show Group info\n5. Show list with all Groups\n6. Add Student\n7. Remove Student\n 0.Exit");
                string answer = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "0":
                        run = false;
                        students.Save();
                        groups.Save();
                        break;
                    case "1":
                        try
                        {
                            Console.Write("Write number of group: ");
                            int n = Convert.ToInt32(Console.ReadLine());
                            groups.Add(n);
                            Console.WriteLine("Succesfull");
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Write ind of student who want delete: ");
                            int ind = Convert.ToInt32(Console.ReadLine());
                            if (ind < 0 || ind >= groups.Last)
                                throw new SuccessExeption("Index out of range");
                            groups.Remove(ind);
                            Console.WriteLine("Succesfull deleted");
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "3":
                        try
                        {
                            Console.Write("Write ind of Group: ");
                            int ind = Convert.ToInt32(Console.ReadLine());
                            if (ind < 0 || ind >= students.Last)
                                throw new SuccessExeption("Index out of range");
                            Console.Write("Write number of group: ");
                            int n = Convert.ToInt32(Console.ReadLine());
                            groups.Edit(ind, n);
                            Console.Write("Succesfull edited!");
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "4":
                        try
                        {
                            Console.Write("Write ind of group: ");
                            int ind = Convert.ToInt16(Console.ReadLine());
                            if (ind < 0 || ind >= groups.Last)
                                throw new SuccessExeption("Index out of range");
                            Console.WriteLine(groups.GetInfo(ind).ToString());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "5":
                        try
                        {
                            Console.WriteLine(groups.GetAll());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "6":
                        try
                        {
                            Console.Write("Write ind of group: ");
                            int index = Convert.ToInt16(Console.ReadLine());
                            if (index < 0 || index >= groups.Last)
                                throw new SuccessExeption("Index out of range");
                            Console.Write("Write ind of student: ");
                            int ind = Convert.ToInt16(Console.ReadLine());
                            if (ind < 0 || ind >= students.Last)
                                throw new SuccessExeption("Index out of range");
                            groups.GetInfo(index).AddStudent(students.GetInfo(ind));
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "7":
                        try
                        {
                            Console.Write("Write ind of group: ");
                            int index = Convert.ToInt16(Console.ReadLine());
                            if (index < 0 || index >= groups.Last)
                                throw new SuccessExeption("Index out of range");
                            Console.Write("Write index: ");
                            int ind = Convert.ToInt16(Console.ReadLine());
                            if (ind < 0 || ind >= students.Last)
                                throw new SuccessExeption("Index out of range");
                            groups.GetInfo(index).RemoveStudent(ind);
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong input\nPress any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }

        #endregion
        #region Find
        private void Find()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1. Find by Name/Surname\n2. Find by Group\n3. Find by MidleRange\n4. Find by the Mark\n5. Find by Mark and Subject\n0. Exit");
                string answer = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "0":
                        run = false;
                        students.Save();
                        groups.Save();
                        break;
                    case "1":
                        try
                        {
                            Console.WriteLine("Write name of Student:\t");
                            string name = Console.ReadLine();
                            Console.WriteLine("\nWrite surname of Student:\t");
                            string surname = Console.ReadLine();
                            Console.WriteLine(students.FindByNameSurname(name, surname).ToString());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Write numb of Group:\t");
                            int ind = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(students.FindByGroup(ind).ToString());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine("Write MidleRange of Student:\t");
                            int ind = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(students.FindByMr(ind).ToString());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine("Write index of Student:\t");
                            int ind = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(students.FindByMark().ToString());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "5":
                        try
                        {
                            Console.WriteLine("Write index of Subject:\t");
                            int ind = Convert.ToInt32(Console.ReadLine());
                            students.FindByMJ(students.GetInfo(0).journal.Jour[ind]);
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong input\nPress any key to continue");
                        Console.ReadKey();
                        break;
                }

            }

        }
        #endregion
    }
}
