using System;
using Enemies;

namespace Defenders
{
    class Archer : Warrior
    {
        private int arrows;

        public Archer(string name, int strength, int arrows) : base(name, strength)
        {
            this.arrows = arrows;
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