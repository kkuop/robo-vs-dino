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
        int attackLowValue = 15;
        int attackHighValue = 50;
        //methods
        public void StartBattle()
        {
            //instantiate the 3 dinos and 3 robots and add them to a list
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
                    continue;
                }
                if (robots.listOfRobots[0].isAlive == false && robots.listOfRobots[1].isAlive == false && robots.listOfRobots[2].isAlive == false)
                {
                    robotsAreDead = true;
                    continue;
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
