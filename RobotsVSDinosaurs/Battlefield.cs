using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVSDinosaurs
{
    class Battlefield
    {
        Random randomNumber = new Random();
        int attackLowValue = 5;
        int attackHighValue = 50;
        string firstChoice = "Energy Sword";
        string secondChoice = "Assault Rifle";
        string thirdChoice = "Sniper Rifle";
        string blueChoice;
        string redChoice;
        string pinkChoice;

        //methods
        public void StartBattle()
        {
            Console.WriteLine("Please choose a weapon for the Blue Robot: \n a) Energy Sword \n b) Assault Rifle \n c) Sniper Rifle");
            ConsoleKeyInfo keyCapture = Console.ReadKey();
            if (keyCapture.Key == ConsoleKey.A)
            {
                blueChoice = firstChoice;
            }
            else if (keyCapture.Key == ConsoleKey.B)
            {
                blueChoice = secondChoice;
            }
            else if (keyCapture.Key == ConsoleKey.C)
            {
                blueChoice = thirdChoice;
            }
            else
            {
                Console.WriteLine("That was not a valid option.");
            }
            Console.WriteLine("\nPlease choose a weapon for the Red Robot: \n a) Energy Sword \n b) Assault Rifle \n c) Sniper Rifle\n");
            ConsoleKeyInfo keyCaptureTwo = Console.ReadKey();
            if (keyCaptureTwo.Key == ConsoleKey.A)
            {
                redChoice = firstChoice;
            }
            else if (keyCaptureTwo.Key == ConsoleKey.B)
            {
                redChoice = secondChoice;
            }
            else if (keyCaptureTwo.Key == ConsoleKey.C)
            {
                redChoice = thirdChoice;
            }
            else
            {
                Console.WriteLine("That was not a valid option.");
            }
            Console.WriteLine("\nPlease choose a weapon for the Pink Robot: \n a) Energy Sword \n b) Assault Rifle \n c) Sniper Rifle\n");
            ConsoleKeyInfo keyCaptureThree = Console.ReadKey();
            if (keyCaptureThree.Key == ConsoleKey.A)
            {
                pinkChoice = firstChoice;
            }
            else if (keyCaptureThree.Key == ConsoleKey.B)
            {
                pinkChoice = secondChoice;
            }
            else if (keyCaptureThree.Key == ConsoleKey.C)
            {
                pinkChoice = thirdChoice;
            }
            else
            {
                Console.WriteLine("That was not a valid option.");
            }
            //instantiate the 3 dinos and 3 robots and add them to a list
            Dinosaur raptor = new Dinosaur("raptor", 100, 100, randomNumber.Next(attackLowValue, attackHighValue));            
            Dinosaur bronto = new Dinosaur("brontosaurus", 100, 100, randomNumber.Next(attackLowValue, attackHighValue));            
            Dinosaur stego = new Dinosaur("stegosaurus", 100, 100, randomNumber.Next(attackLowValue,attackHighValue));            
            Robot blueRobot = new Robot("caboose", 100, 100, new Weapon(blueChoice, randomNumber.Next(attackLowValue,attackHighValue)));            
            Robot redRobot = new Robot("Sarge", 100, 100, new Weapon(redChoice, randomNumber.Next(attackLowValue,attackHighValue)));            
            Robot pinkRobot = new Robot("Simmons", 100, 100, new Weapon(pinkChoice, randomNumber.Next(attackLowValue,attackHighValue)));
            Herd dinos = new Herd(new List<Dinosaur> { raptor, bronto, stego });
            Fleet robots = new Fleet(new List<Robot> { blueRobot, redRobot, pinkRobot });
            Console.WriteLine("\nWelcome to Robot VS Dinosaur! \n \n Press enter to begin...\n");
            Console.ReadLine();
            //set the member variables 
            int attackCounter = 0;
            int attacksPerFighter = 1;
            bool dinosAreDead = false;
            bool robotsAreDead = false;
            int costOfAttack = 10;
            //while loop that runs while both sides are still alive
            while (dinosAreDead == false && robotsAreDead == false)
            {
                //before we attack we will check to see if either side is completely dead
                if (dinos.listOfDinos[0].isAlive == false && dinos.listOfDinos[1].isAlive == false && dinos.listOfDinos[2].isAlive == false)
                {
                    dinosAreDead = true;                    
                }
                if (robots.listOfRobots[0].isAlive == false && robots.listOfRobots[1].isAlive == false && robots.listOfRobots[2].isAlive == false)
                {
                    robotsAreDead = true;                    
                }
                //since neither side is dead, we will begin with the robots attacking first                
                for (int i=0; i<dinos.listOfDinos.Count;i++)
                {
                    //each robot gets to attack the number of times as defined by the variable attacksPerFighter
                    while (attackCounter<attacksPerFighter)
                    {
                        //attack only occurs if the dinos health is above zero
                        if (dinos.listOfDinos[i].health > 0)
                        {
                            dinos.listOfDinos[i].health -= robots.listOfRobots[i].weapon.attackPower;
                            robots.listOfRobots[i].powerLevel -= costOfAttack;
                            attackCounter++;
                        }
                        //if the health is at or below zero the variable isAlive is set to false
                        //health is set to zero since a negative health doesn't make sense
                        else
                        {
                            dinos.listOfDinos[i].isAlive = false;
                            dinos.listOfDinos[i].health = 0;
                            break;
                            }
                        }
                    //i have this here to check if the opponent is dead just in case the fighter doesn't have any more attacks left
                    attackCounter = 0;
                    if (dinos.listOfDinos[i].health<=0)
                    {
                        dinos.listOfDinos[i].isAlive = false;
                        dinos.listOfDinos[i].health = 0;
                    }
                }
                //a quick check in between switching sides to see if it is necessary to continue the battle
                if (dinosAreDead == true)
                {
                    break;
                }
                //loop through the robots for the dinos to attack
                for (int i=0;i<robots.listOfRobots.Count;i++)
                {
                    //each dino gets to attack the number of times as defined by the variable attacksPerFighter
                    while (attackCounter<attacksPerFighter)
                    {
                        //attack only occurs if the robots health is above zero
                        if (robots.listOfRobots[i].health > 0)
                        {
                            robots.listOfRobots[i].health-=dinos.listOfDinos[i].attackPower;
                            dinos.listOfDinos[i].energy -= costOfAttack;
                            attackCounter++;
                        }
                        //if the robots health is below zero, they are declared dead and health set to zero
                        else
                        {
                            robots.listOfRobots[i].isAlive = false;
                            robots.listOfRobots[i].health = 0;
                            break;
                        }
                    }
                // this is here just in case the above while loop doesn't run due to the number of attacks reaching the limit
                attackCounter = 0;
                if (robots.listOfRobots[i].health<=0)
                    {
                        robots.listOfRobots[i].isAlive = false;
                        robots.listOfRobots[i].health = 0;
                    }
                }
            }
            //write the results to the console
            Console.WriteLine("The Dinosaurs\n");
            for (int i=0; i<dinos.listOfDinos.Count; i++)
            {
                Console.WriteLine($"{dinos.listOfDinos[i].type}\nHealth: {dinos.listOfDinos[i].health}\nEnergy: {dinos.listOfDinos[i].energy}\n");               
            }
            Console.WriteLine("The Robots\n");
            for (int i=0; i<robots.listOfRobots.Count; i++)
            {
                Console.WriteLine($"{robots.listOfRobots[i].name}\nHealth: {robots.listOfRobots[i].health}\nPower Level: {robots.listOfRobots[i].powerLevel}\nWeapon: {robots.listOfRobots[i].weapon.type}\n");
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
