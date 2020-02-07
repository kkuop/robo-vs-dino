using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVSDinosaurs
{
    class Battlefield
    {
        //member vars

        //constructor

        //methods
        public void startFight()
        {
            Dinosaur raptor = new Dinosaur("raptor", 100, 100, 15);
            Dinosaur brontosaurus = new Dinosaur("bronto", 100, 80, 5);
            Dinosaur stegosaurus = new Dinosaur("stego", 100, 75, 8);
            Robot blueRobot = new Robot("caboose", 100, 100, new Weapon("Energy Sword", 12));
            Robot redRobot = new Robot("Sarge", 100, 100, new Weapon("Assault Rifle", 5));
            Robot pinkRobot = new Robot("Simmons", 100, 100, new Weapon("Sniper", 15));
            Herd dinos = new Herd(new List<Dinosaur> { raptor, brontosaurus, stegosaurus });
            Fleet robots = new Fleet(new List<Robot> { blueRobot, redRobot, pinkRobot });
            Console.WriteLine("Welcome to Robot VS Dinosaur! \n \n Press enter to begin...\n");
            Console.ReadLine();
            for (int i = 0; i < dinos.listOfDinos.Count; i++)
            {
                for (int j = 0; j < robots.listOfRobots.Count; j++)
                {
                    if(dinos.listOfDinos[i].health > 0)
                    {

                    }
                }
            }
        }
    }
}
