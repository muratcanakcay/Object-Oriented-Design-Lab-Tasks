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
            Console.WriteLine($"{this.name} attacks {g.Name}!");
            return 100;
        }

        virtual public int Attack(Ogre o)
        {
            return 0;
        }

        virtual public int Attack(Rat r)
        {
            return 0;
        }


    }
}