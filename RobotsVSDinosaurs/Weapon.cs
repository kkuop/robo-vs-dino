using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVSDinosaurs
{
    class Weapon
    {
        //member vars
        public string type;
        public int attackPower;
        //constructor
        public Weapon(string type, int attackPower )
        {
            this.type = type;
            this.attackPower = attackPower;
        }
        //methods
        public void DeployWeapon()
        {
            
        }
    }
}
