using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DesignAgency;

namespace _1
{
    public class Menu
    {
        ServicesManagment services = new ServicesManagment();
        ClientsManagment clients = new ClientsManagment();
        public void Run()
        {
            while(true)
            {
                SaveIt();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Clear();
                string message = "\t\t\tMenu\n1.Add Client\t2.Choose Client\n3.Add Service\n4.Show Portfolio\n5.Show Clients\n0. Exit";
                Console.WriteLine(message);
                string arg = Console.ReadLine();
                switch (arg)
                {
                    case "0":
                        services.SaveChanges();
                        clients.SaveChanges();
                        Environment.Exit(0);
                        break;
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Red;
                        try
                        {
                            AddClient();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        try
                        {
                            SaveIt();
                            ChooseCLient();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Green;
                        try
                        {
                            AddService();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.Green;
                        try
                        {
                            ShowPortfolio();
                            //services.Find();
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "5":
                        Console.ForegroundColor = ConsoleColor.Green;
                        try
                        {
                            ShowClients();
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
        #region Client
        private void AddClient()
        {
            Console.Clear();
            Console.WriteLine("Write Name below:\n");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Write money below:\n");
            try
            {
                int money = Convert.ToInt32(Console.ReadLine());
                clients.Insert(new Client(name, money));
            }
            catch (Exception e) { Console.WriteLine($"{e.Message}\nError money..."); Console.ReadKey(); }
            SaveIt();
        }
        private void ShowClients()
        {
            Console.Clear();
            int i = 1;
            foreach (var a in clients.GetList())
            { Console.WriteLine(i + " " + a.ToString());
            i++; }

        }
        private void GetInfoAboughtClient()
        {
            ShowClients();
            Console.WriteLine("Write your choose below:\n");
            int ind = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(clients.GetItem(ind).ToString());
        }
        private void BookService(int indofclient)
        {
            ShowPortfolio();
            Console.WriteLine("Write your choose below:\n");
            int index = Convert.ToInt16(Console.ReadLine());
            if (clients.GetItem(indofclient).Money >= services.GetItem(index).Cost)
            {
                clients.GetItem(indofclient).BookService(services.GetItem(index));
                Console.WriteLine("Success book a service");
            }
            else Console.WriteLine("Not Enought money");
            clients.SaveChanges();
            clients.Update(clients.GetItem(indofclient));
            Console.ReadKey();
        }
        private void ChooseCLient()
        {
            ShowClients();
            Console.WriteLine("Write your choose below:\n");
            int incd = Convert.ToInt16(Console.ReadLine());
            Console.Clear();
            SecondMenu(incd);
        }
        #endregion
        private void SaveIt()
        {
            clients.SaveChanges();
            clients.Load();
            services.SaveChanges();
            services.Load();
        }
        private void SecondMenu(int ind)
        {
            bool anh = true;
            SaveIt();        
            while(anh)
            {
                Console.WriteLine($"\t\t\tMenu\n{clients.GetItem(ind).ToString()}\n0.Choose other Client\n1.Book from Portfolio\n2.Book for <<key>>\ne. Exit");
                string ans = Console.ReadLine();
                switch (ans)
                {
                    case "0":
                        try
                        {
                            Console.Clear();
                            ShowClients();
                            SaveIt();
                            Console.WriteLine("Choose Client: ");
                            int index = Convert.ToInt16(Console.ReadLine());
                            Console.Clear();
                            SecondMenu(index);
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "1":
                        try
                        {
                            Console.Clear();
                            Console.WriteLine(clients.GetItem(ind).Info());
                            BookService(ind);
                            Console.Clear();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.Clear();
                            Console.WriteLine(clients.GetItem(ind).ToString());
                            AddService();
                            if (clients.GetItem(ind).Money >= services.GetList().Last().Cost)
                            {
                                clients.GetItem(ind).BookService(services.GetList().Last());
                                Console.WriteLine("Success book new service ");
                                Console.WriteLine(clients.GetItem(ind).ToString());
                            }
                            SaveIt();
                            Console.WriteLine("Not enought money");
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "e":
                        try
                        {
                            Console.Clear();
                            anh = false;
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
        #region DesignService
        private void AddService()
        {
            Console.Clear();
            Console.WriteLine("Choose type\n0. Web\n1. Home\n2. Office\n");
            int type = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Write TAG below:\n");
            string tag = Console.ReadLine();
            Console.WriteLine("Write description abought design:\n");
            string description = Console.ReadLine();
            Console.WriteLine("How many cost?\n");
            int cost = Convert.ToInt32(Console.ReadLine());
            if(type == 0)
            services.Insert(new DesignService(tag, description, "Web", cost));
            else if (type == 1)
                services.Insert(new DesignService(tag, description, "Home", cost));
            else if (type == 2)
                services.Insert(new DesignService(tag, description, "Office", cost));
            else
                services.Insert(new DesignService(tag, description, "WithOutType", cost));
            SaveIt();
            Console.Clear();
            Console.WriteLine("Success");
            Console.ReadKey();
        }
        private void DeleteService()
        {
            ShowPortfolio();
            Console.WriteLine("Write index Design what you'e want delete:\n");
            int ind = Convert.ToInt16(Console.ReadLine());
            services.Delete(services.GetItem(ind));
            SaveIt();
            Console.Clear();
            Console.WriteLine("Success");
            Console.ReadKey();
        }
        private void ShowPortfolio()
        {
            Console.Clear();
            int i = 1;
            foreach (var a in services.GetList())
            {
                Console.WriteLine(i + ". " + a.ToString());
                i++;
            }
        }
        #endregion
    }
}
