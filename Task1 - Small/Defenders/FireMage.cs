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

        // uses all methods from base class Mage
        // overrides Hit() to give a chance for instant kill
        
        protected override int Hit(Enemy e, string type)
        {
            if (rng.NextDouble() < this.killChance) // insta-kill chance
            {
                Console.WriteLine($"Fire Mage {name} casts a fire spell and insta-kills {type} {e.Name}");
                return 1000000000;
            }
            
            Console.WriteLine($"Fire Mage {name} casts a fire spell and gives {spellPower} damage to {type} {e.Name}");
            return spellPower;            
        }
    }
}