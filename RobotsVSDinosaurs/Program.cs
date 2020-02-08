using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVSDinosaurs
{
    class Program
    {
        static void Main(string[] args)
        {
            Battlefield initialize = new Battlefield();
            initialize.StartBattle();
            Console.ReadLine();
        }
    }
}
