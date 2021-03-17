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

        // all 3 needed???

        override public int Attack(Giant g)
        {
            return 0;
        }

        override public int Attack(Ogre o)
        {
            return 0;
        }

        override public int Attack(Rat r)
        {
            return 0;
        }
    }
}