using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.Menu;
namespace SuccessJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Run();
            Console.ReadKey();
        }
    }
}
