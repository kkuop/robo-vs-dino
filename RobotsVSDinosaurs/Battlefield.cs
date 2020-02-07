using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVSDinosaurs
{
    class Battlefield
    {
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

            int attackCounter = 0;
            while (dinos.listOfDinos[0].health>0&&dinos.listOfDinos[1].health>0&&dinos.listOfDinos[2].health>0 || robots.listOfRobots[0].health>0&&robots.listOfRobots[1].health>0&&robots.listOfRobots[2].health>0){ 
            for (int i=0; i<dinos.listOfDinos.Count;i++)
            {
                while (attackCounter<3)
                {
                    dinos.listOfDinos[i].AttackFromRobot();
                    attackCounter++;
                }
                    attackCounter = 0;
            }
            for (int i=0;i<robots.listOfRobots.Count;i++)
            {
                while (attackCounter<3)
                {
                    robots.listOfRobots[i].AttackFromDino();
                    attackCounter++;
                }
                    attackCounter = 0;
            }
            }
            //for (int i = 0; i < dinos.listOfDinos.Count; i++)
            //{
            //    for (int j = 0; j < robots.listOfRobots.Count; j++)
            //    {
            //        if(dinos.listOfDinos[i].health > 0)
            //        {
            //            while (dinos.listOfDinos[i].health >0) 
            //            {
            //                dinos.listOfDinos[i].DinoAttackRobot();
            //                attackCounter++;
            //            }
            //        }
            //    }
            //}
            Console.WriteLine("The Dinos\n");
            for (int i=0; i<dinos.listOfDinos.Count; i++)
            {
                Console.WriteLine($"{dinos.listOfDinos[i].type}\nHealth: {dinos.listOfDinos[i].health}\nEnergy: {dinos.listOfDinos[i].energy}\n");               
            }
            Console.WriteLine("The Robos\n");
            for (int i=0; i<robots.listOfRobots.Count; i++)
            {
                Console.WriteLine($"{robots.listOfRobots[i].name}\nHealth: {robots.listOfRobots[i].health}\nPower Level: {robots.listOfRobots[i].powerLevel}\n");
            }
        }
    }
}
