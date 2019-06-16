using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;

namespace OrganizerCourse
{
    public class Menu
    {
        ComponentManagment componentManage = new ComponentManagment();
        Composite composite = new Composite("Composite");
        Сalendar сalendar = new Сalendar("Calendar");
        Notebook notebook = new Notebook("Notebook");
        Directory directory = new Directory("Adress Book");

        public void Run()
        {
           
            while (true)
            {
                componentManage.Load();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Clear();
                string message = "\t\t\tOur Organizer\n1.Add new meet in Calendar\n2.Add new note in Notebook\n3.Add new adress in Directory\n4.Show Notes\n5.Show Meets\n6.Show Companions\n0. Exit";
                Console.WriteLine(message);
                string arg = Console.ReadLine();
                switch (arg)
                {
                    case "0":
                        componentManage.SaveChanges();
                        Environment.Exit(0);
                        break;
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Red;
                        try
                        {
                            AddMeet();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        try
                        {
                            AddNote();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Green;
                        try
                        {
                            AddAdress();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.Green;
                        try
                        {
                            ShowNotes();
                            //services.Find();
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "5":
                        Console.ForegroundColor = ConsoleColor.Green;
                        try
                        {
                            ShowMeets();
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "6":
                        Console.ForegroundColor = ConsoleColor.Green;
                        try
                        {
                            ShowCompanions();
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
        #region Realization
        private void AddMeet()
        {
            Console.WriteLine("Write time:\t");
            int time = Convert.ToInt16(Console.ReadLine());
            \Console.WriteLine("Write day:\")'
            string day =  Console.ReadLine();
            сalendar.AddData(time, day);
        }
        private void AddNote()
        {
            Console.WriteLine("Write your note:\t");
            string a = Console.ReadLine();
            notebook.NewNote(a);
        }
        private void AddAdress()
        {
            Console.WriteLine("Write name of companion:\t");
            string a = Console.ReadLine();
            Console.WriteLine("Write your adress:\t");
            string b = Console.ReadLine();
            directory.AddAdress(a, b);
        }
        private void ShowNotes()
        {
           Console.WriteLine(notebook.Display(1));
        }
        private void ShowMeets()
        {
            Console.WriteLine(calendar.Display(1));
        }
        private void ShowCompanions()
        {
            Console.WriteLine(directory.Display(1));
        }
        #endregion
    }
}
