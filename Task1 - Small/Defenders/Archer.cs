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

        protected override int Hit(Enemy e)
        {
            Console.WriteLine($"Archer {name} shoots an arrow at {e.Name} and hits for {strength} damage!");
            return strength;
        }

        protected override int Miss(Enemy e)
        {
            Console.WriteLine($"Archer {name} shoots an arrow at {e.Name} and misses!");
            return 0;
        }

        protected virtual int NoArrows(Enemy e)
        {
            Console.WriteLine($"Archer {name} cannot shoot an arrow at {e.Name} because he has no arrows left!");
            return 0;

        }
        virtual protected int ShootArrow(Enemy e)
        {
            if (arrows > 0)
            {
                arrows--; 
                return Hit(e);
            }
            else return NoArrows(e);
        }
        
        // can't shoot if only 1 arrow left??
        override public int Attack(Giant g)
        {
            int damage = 0;

            for (int i = 0; i < 2; i++)
            {
                damage += ShootArrow(g);
            }
       
            return damage;
        }

        override public int Attack(Ogre o)
        {
            return ShootArrow(o); 
        }

        override public int Attack(Rat r)
        {
            if (arrows > 0)
            {
                arrows--;
                return AttackRat(r); // can archer can miss a rat because he's a warrior subclass?
            }
            else return NoArrows(r);
        }
    }
}