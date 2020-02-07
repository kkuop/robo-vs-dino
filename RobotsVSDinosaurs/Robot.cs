using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVSDinosaurs
{
    class Robot
    {
        //member vars
        public string name;
        public int health;
        public int powerLevel;
        public Weapon weapon;


        //constructor
        public Robot(string name, int health, int powerLevel, Weapon weapon)
        {
            this.name = name;
            this.health = health;
            this.powerLevel = powerLevel;
            this.weapon = weapon;
        }
        //methods
        public void RobotAttackDino()
        {
            health -= weapon.attackPower;
            powerLevel -= 10;
        }
    }
}
