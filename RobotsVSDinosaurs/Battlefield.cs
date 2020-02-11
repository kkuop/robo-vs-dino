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
        Random randomNumber = new Random();
        int attackLowValue = 5;
        int attackHighValue = 50;
        string firstChoice = "Energy Sword";
        string secondChoice = "Assault Rifle";
        string thirdChoice = "Sniper Rifle";
        ConsoleKeyInfo blueChoice;
        ConsoleKeyInfo redChoice;
        ConsoleKeyInfo pinkChoice;
        int blueWeaponChoice;
        int redWeaponChoice;
        int pinkWeaponChoice;
        int attackCounter = 0;
        bool dinosAreDead = false;
        bool robotsAreDead = false;
        int costOfAttack = 10;

        //methods
        public void StartBattle()        
        {
            //introduce the dinosaurs and create the objects
            Console.WriteLine("Welcome to the battle of the Robots and Dinosaurs.\n");
            Console.WriteLine("Let's introduce the dinosaurs... press enter to continue");
            Console.ReadLine();
            Dinosaur raptor = new Dinosaur("Raptor", 100, 100, randomNumber.Next(attackLowValue, attackHighValue));            
            Console.WriteLine($"\n{raptor.type}\nHealth: {raptor.health}\nEnergy: {raptor.energy}");
            Console.ReadLine();
            Dinosaur bronto = new Dinosaur("Brontosaurus", 100, 100, randomNumber.Next(attackLowValue, attackHighValue));
            Console.WriteLine($"\n{bronto.type}\nHealth: {bronto.health}\nEnergy: {bronto.energy}");
            Console.ReadLine();
            Dinosaur stego = new Dinosaur("Stegosaurus", 100, 100, randomNumber.Next(attackLowValue, attackHighValue));
            Console.WriteLine($"\n{stego.type}\nHealth: {stego.health}\nEnergy: {stego.energy}");
            Console.ReadLine();

            // create the weapon objects and assign them to the variable for each robot
            Weapon firstChoice = new Weapon(this.firstChoice, randomNumber.Next(attackLowValue, attackHighValue));
            Weapon secondChoice = new Weapon(this.secondChoice, randomNumber.Next(attackLowValue, attackHighValue));
            Weapon thirdChoice = new Weapon(this.thirdChoice, randomNumber.Next(attackLowValue, attackHighValue));
            Weapons weapons = new Weapons(new List<Weapon> {firstChoice,secondChoice,thirdChoice});
            Console.WriteLine($"\nWhich weapon would you like the blue robot to use?\na) {weapons.listOfWeapons[0].type}\nb) {weapons.listOfWeapons[1].type}\nc) {weapons.listOfWeapons[2].type}");
            for (int i = 0; i < 1000; i++)
            {            
                blueChoice = Console.ReadKey();
                if (blueChoice.Key == ConsoleKey.A)
                {
                    blueWeaponChoice = 0;
                    break;
                }
                else if(blueChoice.Key == ConsoleKey.B )
                {
                    blueWeaponChoice = 1;
                    break;
                }
                else if (blueChoice.Key == ConsoleKey.C)
                {
                    blueWeaponChoice = 2;
                    break;
                }
                else
                {
                    Console.WriteLine("\nThat is not a valid choice... try again.");
                }
            }
            Console.WriteLine($"\n\nWhich weapon would you like the red robot to use?\na) {weapons.listOfWeapons[0].type}\nb) {weapons.listOfWeapons[1].type}\nc) {weapons.listOfWeapons[2].type}");
            for (int i = 0; i < 1000; i++)
            {
                redChoice = Console.ReadKey();
                if (redChoice.Key == ConsoleKey.A)
                {
                    redWeaponChoice = 0;
                    break;
                }
                else if (redChoice.Key == ConsoleKey.B)
                {
                    redWeaponChoice = 1;
                    break;
                }
                else if (redChoice.Key == ConsoleKey.C)
                {
                    redWeaponChoice = 2;
                    break;
                }
                else
                {
                    Console.WriteLine("\nThat is not a valid choice... try again.");
                }
            }
            Console.WriteLine($"\n\nWhich weapon would you like the pink robot to use?\na) {weapons.listOfWeapons[0].type}\nb) {weapons.listOfWeapons[1].type}\nc) {weapons.listOfWeapons[2].type}");
            for (int i = 0; i < 1000; i++)
            {
                pinkChoice = Console.ReadKey();
                if (pinkChoice.Key == ConsoleKey.A)
                {
                    pinkWeaponChoice = 0;
                    break;
                }
                else if (pinkChoice.Key == ConsoleKey.B)
                {
                    pinkWeaponChoice = 1;
                    break;
                }
                else if (pinkChoice.Key == ConsoleKey.C)
                {
                    pinkWeaponChoice = 2;
                    break;
                }
                else
                {
                    Console.WriteLine("\nThat is not a valid choice... try again.");
                }
            }

            //create the robot objects and use the weapon variable to pass a weapon in as a parameter
            Console.WriteLine("Now introducing the robots...");
            Console.ReadLine();
            Robot blueRobot = new Robot("Caboose", 100, 100, weapons.listOfWeapons[blueWeaponChoice]);
            Console.WriteLine($"{blueRobot.name} (Blue)\nHealth: {blueRobot.health}\nPower Level: {blueRobot.powerLevel}\nWeapon: {blueRobot.weapon.type}");
            Console.ReadLine();
            Robot redRobot = new Robot("Sarge", 100, 100, weapons.listOfWeapons[redWeaponChoice]);
            Console.WriteLine($"{redRobot.name} (Red)\nHealth: {redRobot.health}\nPower Level: {redRobot.powerLevel}\nWeapon: {redRobot.weapon.type}");
            Console.ReadLine();
            Robot pinkRobot = new Robot("Simmons", 100, 100, weapons.listOfWeapons[pinkWeaponChoice]);
            Console.WriteLine($"{pinkRobot.name} (Pink)\nHealth: {pinkRobot.health}\nPower Level: {pinkRobot.powerLevel}\nWeapon: {pinkRobot.weapon.type}");
            Console.ReadLine();

            // add them to their respective lists
            Herd dinos = new Herd(new List<Dinosaur> { raptor, bronto, stego });
            Fleet robots = new Fleet(new List<Robot> { blueRobot, redRobot, pinkRobot });
            
            Console.WriteLine("\nLet the fight begin...\n");
            Console.ReadLine();

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
                    //each robot gets to attack the number of times as defined by the random number generator
                    while (attackCounter < randomNumber.Next(1, 5))
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
                    //each dino gets to attack the number of times as defined by the random number generator
                    while (attackCounter<randomNumber.Next(1,5))
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
