using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVSDinosaurs
{
    class Dinosaur
    {
        //member vars
        public string type;
        public int health;
        public int energy;
        public int attackPower;

        //constructor
        public Dinosaur(string type, int health, int energy, int attackPower) 
        {
            this.type = type;
            this.health = health;
            this.energy = energy;
            this.attackPower = attackPower;
        }
        //methods
        public void DinoAttackRobot()
        {
            health -= attackPower;
            energy -= 5;
        }        
    }
}
