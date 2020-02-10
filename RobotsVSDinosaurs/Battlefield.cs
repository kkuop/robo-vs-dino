using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVSDinosaurs
{
    class Battlefield
    {
        int attackLowValue = 25;
        int attackHighValue = 75;
        //methods
        public void StartBattle()
        {
            //instantiate the 3 dinos and 3 robots and add them to a list
            Random randomNumber = new Random();
            Dinosaur raptor = new Dinosaur("raptor", 100, 100, randomNumber.Next(attackLowValue, attackHighValue));
            Dinosaur bronto = new Dinosaur("brontosaurus", 100, 80, randomNumber.Next(attackLowValue, attackHighValue));
            Dinosaur stego = new Dinosaur("stegosaurus", 100, 75, randomNumber.Next(attackLowValue,attackHighValue));
            Robot blueRobot = new Robot("caboose", 100, 100, new Weapon("Energy Sword", randomNumber.Next(attackLowValue,attackHighValue)));
            Robot redRobot = new Robot("Sarge", 100, 100, new Weapon("Assault Rifle", randomNumber.Next(attackLowValue,attackHighValue)));
            Robot pinkRobot = new Robot("Simmons", 100, 100, new Weapon("Sniper", randomNumber.Next(attackLowValue,attackHighValue)));
            Herd dinos = new Herd(new List<Dinosaur> { raptor, bronto, stego });
            Fleet robots = new Fleet(new List<Robot> { blueRobot, redRobot, pinkRobot });
            Console.WriteLine("Welcome to Robot VS Dinosaur! \n \n Press enter to begin...\n");
            Console.ReadLine();
            //set the variables for the attackCounter and how many attacks each warrior gets
            int attackCounter = 0;
            int attacksPerFighter = 1;
            bool dinosAreDead = false;
            bool robotsAreDead = false;
            int costOfAttack = 10;
            //while loop that runs while both sides are still alive
            while (dinosAreDead == false && robotsAreDead == false)
            {
                if (dinos.listOfDinos[0].isAlive == false && dinos.listOfDinos[1].isAlive == false && dinos.listOfDinos[2].isAlive == false)
                {
                    dinosAreDead = true;
                    continue;
                }
                if (robots.listOfRobots[0].isAlive == false && robots.listOfRobots[1].isAlive == false && robots.listOfRobots[2].isAlive == false)
                {
                    robotsAreDead = true;
                    continue;
                }
                for (int i=0; i<dinos.listOfDinos.Count;i++)
                {
                    while (attackCounter<attacksPerFighter)
                    {
                        if (dinos.listOfDinos[i].health > 0)
                        {
                            dinos.listOfDinos[i].health -= robots.listOfRobots[i].weapon.attackPower;
                            dinos.listOfDinos[i].energy -= costOfAttack;
                            attackCounter++;
                        }
                        else
                        {
                            dinos.listOfDinos[i].isAlive = false;
                            dinos.listOfDinos[i].health = 0;
                            break;
                            }
                        }
                    attackCounter = 0;
                    if (dinos.listOfDinos[i].health<=0)
                    {
                        dinos.listOfDinos[i].isAlive = false;
                        dinos.listOfDinos[i].health = 0;
                    }
                }
            for (int i=0;i<robots.listOfRobots.Count;i++)
            {
                while (attackCounter<attacksPerFighter)
                {
                        if (robots.listOfRobots[i].health > 0)
                        {
                            robots.listOfRobots[i].health-=dinos.listOfDinos[i].attackPower;
                            robots.listOfRobots[i].powerLevel -= costOfAttack;
                            attackCounter++;
                        }
                        else
                        {
                            robots.listOfRobots[i].isAlive = false;
                            robots.listOfRobots[i].health = 0;
                            break;
                        }
                }
                    attackCounter = 0;
                    if (robots.listOfRobots[i].health<=0)
                    {
                        robots.listOfRobots[i].isAlive = false;
                        robots.listOfRobots[i].health = 0;
                    }
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
            Console.WriteLine("The Dinosaurs\n");
            for (int i=0; i<dinos.listOfDinos.Count; i++)
            {
                Console.WriteLine($"{dinos.listOfDinos[i].type}\nHealth: {dinos.listOfDinos[i].health}\nEnergy: {dinos.listOfDinos[i].energy}\n");               
            }
            Console.WriteLine("The Robots\n");
            for (int i=0; i<robots.listOfRobots.Count; i++)
            {
                Console.WriteLine($"{robots.listOfRobots[i].name}\nHealth: {robots.listOfRobots[i].health}\nPower Level: {robots.listOfRobots[i].powerLevel}\n");
            }
            if (dinosAreDead==true)
            {
                Console.WriteLine("The Robots win the fight!");
            }
            else
            {
                Console.WriteLine("The Dinosaurs win the fight!");
            }
        }
    }
}
