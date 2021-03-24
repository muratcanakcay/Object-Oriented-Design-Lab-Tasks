using System;
using Enemies;

namespace Defenders
{
    class Warrior : IDefender
    {
        protected readonly string name;
        protected readonly int strength;
        protected static readonly Random rng = new Random(1597);

        public Warrior(string name, int strength)
        {
            this.name = name;
            this.strength = strength;
        }

        //------------------------------------------

        // this is the simpler version which I mentioned in the version in master branch.
        // since I'm defining the "type" argument from inside the visitor methods I guess it should 
        // not be a problem. 
        
        protected virtual int Hit(Enemy e, string type)
        {
            Console.WriteLine($"Warrior {name} attacks and gives {strength} damage to {type} {e.Name}.");
            return strength;
        }

        protected virtual int Miss(Enemy e, string type)
        {
            Console.WriteLine($"Warrior {name} attacks but misses {type} {e.Name}");
            return 0;
        }

        public virtual int Attack(Giant g)
        {
            int damage = Hit(g, "Giant");            
            return damage;
        }

        public virtual int Attack(Ogre o)
        {
            int damage = Hit(o, "Ogre");
            return damage;
        }

        public virtual int Attack(Rat r)
        {
            int damage = AttackRat(r);
            return damage;
        }

        protected int AttackRat(Rat r)
        {
            if (rng.NextDouble() < r.Speed / 100) // miss chance
            {
                return Miss(r, "Rat");
            }
            else
            {
                return Hit(r, "Rat");
            }
        }
    }
}