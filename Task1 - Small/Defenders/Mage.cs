using System;
using Enemies;

namespace Defenders
{
    class Mage : IDefender
    {
        protected readonly string name;
        protected int mana;
        protected readonly int manaRegen;
        protected readonly int spellPower;

        public Mage(string name, int mana, int manaRegen, int spellPower)
        {
            this.name = name;
            this.mana = mana;
            this.manaRegen = manaRegen;
            this.spellPower = spellPower;
        }

        protected bool CanCastSpell()
        {
            if (mana >= spellPower)
            {
                mana -= spellPower;
                return true;
            }

            Console.WriteLine($"Mage {name} is recharging mana");
            RechargeMana();
            return false;
        }

        private void RechargeMana()
        {
            mana += manaRegen;
        }

        //------------------------------------------

        protected virtual int Hit(Enemy e, string type)
        {
            Console.WriteLine($"Mage {name} casts a spell and gives {spellPower} damage to {type} {e.Name}.");
            return spellPower;
        }

        protected virtual int CastSpell(Enemy e, string type)
        {
            if (CanCastSpell()) return Hit(e, type);
            else return 0;
        }

        public virtual int Attack(Giant g)
        {
            return CastSpell(g, "Giant");
        }

        public virtual int Attack(Ogre o)
        {
            return CastSpell(o, "Ogre");
        }

        public virtual int Attack(Rat r)
        {
            return CastSpell(r, "Rat");
        }
    }
}