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

        virtual public int Attack(Giant g)
        {
            Console.WriteLine($"Warrior {name} attacks giant {g.Name} and hits for {strength} damage!"); 
            return strength;
        }

        virtual public int Attack(Ogre o)
        {
            Console.WriteLine($"Warrior {name} attacks ogre {o.Name} and hits for {strength} damage!");
            return strength;
        }

        virtual public int Attack(Rat r)
        {
            Console.Write($"Warrior {name} attacks rat {r.Name} and ");
            if (rng.NextDouble() < r.Speed / 100)
            { 
                Console.WriteLine($"hits for {strength} damage!");
                return strength;
            }

            Console.WriteLine($"misses!");
            return 0;
            
        }
    }
}