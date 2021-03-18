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
            Console.WriteLine($"Warrior {name} attacks {e.Name} and hits for {strength} damage!");
            return strength;
        }

        protected virtual int Miss(Enemy e)
        {
            Console.WriteLine($"Warrior {name} attacks {e.Name} and misses!");
            return 0;
        }

        virtual public int Attack(Giant g)
        {
            return Hit(g);
        }

        virtual public int Attack(Ogre o)
        {
            return Hit(o);
        }

        virtual public int Attack(Rat r)
        {
            return AttackRat(r);
        }

        protected int AttackRat(Rat r)
        {
            if (rng.NextDouble() < r.Speed / 100)
            {
                return Hit(r);
            }
            else
            {
                return Miss(r);
            }
        }
    }
}