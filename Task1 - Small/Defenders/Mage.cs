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

        virtual protected int Hit(Enemy e)
        {
            mana -= spellPower;
            Console.WriteLine($"Mage {name} casts a spell at {e.Name} and hits for {spellPower} damage!");
            return spellPower;
        }

        virtual protected int CastSpell(Enemy e)
        {
            if (CanCastSpell()) return Hit(e);
            else return 0;
        }

        virtual public int Attack(Giant g)
        {
            return CastSpell(g);
        }

        virtual public int Attack(Ogre o)
        {
            return CastSpell(o);
        }

        virtual public int Attack(Rat r)
        {
            return CastSpell(r);
        }
    }
}