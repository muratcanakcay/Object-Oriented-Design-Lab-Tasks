using System;
using Enemies;

namespace Defenders
{
    class Archer : Warrior
    {
        private int arrows;

        public Archer(string name, int strength, int arrows) : base(name, strength)
        {
            this.arrows = arrows;
        }

        //------------------------------------------

        protected bool CanShoot()
        {
            if (arrows >= 1)
            {
                arrows--;
                return true;
            }

            Console.WriteLine($"Archer {name} does not have any arrows left!");
            return false;
        }

        protected override int Hit(Enemy e, string type)
        {
            Console.WriteLine($"Archer {name} shoots an arrow and gives {strength} damage to {type} {e.Name}.");
            return strength;
        }

        protected override int Miss(Enemy e, string type)
        {
            Console.WriteLine($"Archer {name} shoots an arrow but misses {type} {e.Name}.");
            return 0;
        }

        // generic ShootArrow() method can be used for new enemies that can be added in the future
        // which the archer will attack "normally"  
        protected virtual int ShootArrow(Enemy e, string type)
        {
            if (CanShoot()) return Hit(e, type);
            else return 0;
        }
        
        public override int Attack(Ogre o)
        {
            return ShootArrow(o, "Ogre"); ; 
        }

        // archer CAN shoot at a giant if he has only 1 arrow left!
        public override int Attack(Giant g)
        {
            int damage = 0;
            
            for (int i = 0; i < 2; i++)
                if (CanShoot()) damage += Hit(g, "Giant");

            return damage;
        }

        // archer can also miss a rat since he's a warrior subclass
        // uses AttackRat() method of base Warrior class
        public override int Attack(Rat r) 
        {
            if (CanShoot()) return AttackRat(r);
            else return 0;
        }
    }
}