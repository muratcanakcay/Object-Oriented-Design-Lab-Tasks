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

        protected virtual int Hit(Enemy e)
        {
            Console.Write($"Mage {name} casts a spell and gives {spellPower} damage to ");
            return spellPower;
        }

        protected virtual int CastSpell(Enemy e)
        {
            if (CanCastSpell()) return Hit(e);
            else return 0;
        }

        public virtual int Attack(Giant g)
        {
            int damage = CastSpell(g);
            if (damage > 0) Console.WriteLine($"Giant {g.Name}.");
            return damage;
        }

        public virtual int Attack(Ogre o)
        {
            int damage = CastSpell(o);
            if (damage > 0) Console.WriteLine($"Ogre {o.Name}.");
            return damage;
        }

        public virtual int Attack(Rat r)
        {
            int damage = CastSpell(r);
            if (damage > 0) Console.WriteLine($"Rat {r.Name}.");
            return damage;
        }
    }
}