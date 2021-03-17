using System;
using Enemies;

namespace Defenders
{
    class RatCatcher : IDefender
    {
        protected readonly string name;
        private bool hasRat;

        public RatCatcher(string name)
        {
            this.name = name;
            hasRat=false;
        }

        virtual public int Attack(Giant g)
        {
            return 0;
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