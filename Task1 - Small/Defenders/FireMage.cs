using System;
using Enemies;

namespace Defenders
{
    class FireMage : Mage
    {
        private double killChance;
        protected static readonly Random rng = new Random(1597);

        public FireMage(string name, int mana, int manaRegen, int spellPower, double killChance) : base(name, mana, manaRegen, spellPower)
        {
            this.killChance = killChance;
        }

        override protected int Hit(Enemy e)
        {
            mana -= spellPower;
            if (rng.NextDouble() < this.killChance)
            {
                Console.WriteLine($"Mage {name} casts a fire spell at {e.Name} and insta-kills!!!!");
                return 1000000000;
            }
            
            Console.WriteLine($"Mage {name} casts a fire spell at {e.Name} and hits for {spellPower} damage!");
            return spellPower;            
        }
    }
}