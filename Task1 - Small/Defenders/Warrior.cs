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

        protected virtual int Hit(Enemy e)
        {
            Console.Write($"Warrior {name} attacks and gives {strength} damage to ");
            return strength;
        }

        protected virtual int Miss(Enemy e)
        {
            Console.Write($"Warrior {name} attacks but misses ");
            return 0;
        }

        public virtual int Attack(Giant g)
        {
            int damage = Hit(g);
            
            // in fact the type could be passed to Hit() as an argument like Hit(g, "Giant") to make it simpler
            // then Hit() would print the following line intead of repeating it in each Attack() method
            // but I'm not sure it it's allowed so I'm leaving it as it is 
            Console.WriteLine($"Giant {g.Name}.");
            return damage;
        }

        public virtual int Attack(Ogre o)
        {
            int damage = Hit(o);
            Console.WriteLine($"Ogre {o.Name}.");
            return damage;
        }

        public virtual int Attack(Rat r)
        {
            int damage = AttackRat(r);
            Console.WriteLine($"Rat {r.Name}.");
            return damage;
        }

        protected int AttackRat(Rat r)
        {
            if (rng.NextDouble() < r.Speed / 100) // miss chance
            {
                return Miss(r);
            }
            else
            {
                return Hit(r);
            }
        }
    }
}