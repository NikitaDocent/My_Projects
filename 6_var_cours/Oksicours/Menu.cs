using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace Oksicours
{
    class Menu
    {
        private Find find;
        private ClientsList clientList;
        private BuildingsList buildingsList;
        public void Run()
        {
            buildingsList = new BuildingsList();
            clientList = new ClientsList();
            find = new Find();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1. Buildings\n2. Client\n3. Find\n0. Exit");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "0":
                        buildingsList.Save();
                        clientList.Save();
                        Environment.Exit(0);
                        break;
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Building();
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Client();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Find();
                        break;
                    default:
                        Console.WriteLine("Wrong input\nPress any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
        #region Client
        private void Client()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1. Add Client\n2. Remove Client\n3. Edit Client\n4. Show Client info\n5. Show list with all\n6. Sort\n7. Offers\n0.Exit");
                string answer = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "0":
                        run = false;
                        clientList.Save();
                        buildingsList.Save();
                        break;
                    case "1":
                        try { }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "2":
                        try { }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "3":
                        try { }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "4":
                        try { }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "5":
                        try { }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "6":
                        try
                        {
                            Console.WriteLine("1. Sort by Name\n2. Sort by Surname\n3. Sort by first digit BankAcc\n0.Exit");
                            string ans = Console.ReadLine();
                            Console.Clear();
                            switch (ans)
                            {
                                case "0":
                                    run = false;
                                    clientList.Save();
                                    buildingsList.Save();
                                    break;
                                case "1":
                                    try { }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                case "2":
                                    try { }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                case "3":
                                    try { }
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
                     case "7":
                        try
                        {
                            Console.WriteLine("1. Add to Offer's\n2. Remove from Offers\n3. Avaible\n0.Exit");
                            string answ = Console.ReadLine();
                            Console.Clear();
                            switch (answ)
                            {
                                case "0":
                                    run = false;
                                    clientList.Save();
                                    buildingsList.Save();
                                    break;
                                case "1":
                                    try { }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                case "2":
                                    try { }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                case "3":
                                    try { }
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

        #region Building
        private void Building()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1. Add Building\n2. Remove Building\n3. Edit Building\n4. Show Building info\n5. Show list with all\n6. Sort\n0.Exit");
                string answer = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "0":
                        run = false;
                        clientList.Save();
                        buildingsList.Save();
                        break;
                    case "1":
                        try { }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "2":
                        try { }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "3":
                        try { }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "4":
                        try { }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "5":
                        try { }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "6":
                        try
                        {
                            Console.WriteLine("1. Sort by type\n2. Sort by cost\n0.Exit");
                            string ans = Console.ReadLine();
                            Console.Clear();
                            switch (ans)
                            {
                                case "0":
                                    run = false;
                                    clientList.Save();
                                    buildingsList.Save();
                                    break;
                                case "1":
                                    try { }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                case "2":
                                    try { }
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
        #region Find
        private void Find()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1. Find for key word in Clients\n2. Find for key word in Buildings\n3. Find for key word in All\n4. Custom find\n0.Exit");
                string answer = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "0":
                        run = false;
                        clientList.Save();
                        buildingsList.Save();
                        break;
                    case "1":
                        try { FindClient(); }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "2":
                        try { FindBuilding(); }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "3":
                        try { FindAll(); }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "4":
                        try { FindCustom(); }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong input\nPress any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void FindClient()
        {
            Console.Write("Controle word ");
            var word = Console.ReadLine();
            Console.WriteLine(find.found_client(clientList, word));
            Console.ReadKey();
        }
        private void FindBuilding()
        {
            Console.Write("Controle word ");
            var word = Console.ReadLine();
            Console.WriteLine(find.found_buildings(buildingsList, word));
            Console.ReadKey();
        }
        private void FindAll()
        {
            Console.Write("Controle word ");
            var word = Console.ReadLine();
            Console.WriteLine(find.found_in_all(clientList, buildingsList, word));
            Console.ReadKey();
        }
        private void FindCustom()
        {
            Console.Write("Controle word's ");
            Console.Write("First: ");
            var word = Console.ReadLine();
            Console.Write("Second: ");
            var wordtwo = Console.ReadLine();
            Console.WriteLine(find.found_custom(clientList, buildingsList, word, wordtwo));
            Console.ReadKey();
        }
        #endregion

    }
}
