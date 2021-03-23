using System;
using Defenders;

namespace Enemies
{
    class Ogre : Enemy
    {
        public int Armor { get; }

        public Ogre(string name, int hp, int armor) : base(name, hp)
        {
            Armor = armor;
        }

        //-------------------------

        public override void GetAttackedBy(IDefender defender)
        {
            int initDamage = defender.Attack(this);
            
            if (initDamage > 0)
            {
                int finalDamage = initDamage <= Armor ? 1 : initDamage - Armor;
                Console.WriteLine($"----Ogre {Name}'s armor absorbs {initDamage - finalDamage} damage.");
                GetDamage(finalDamage);
            }
        }
    }
}