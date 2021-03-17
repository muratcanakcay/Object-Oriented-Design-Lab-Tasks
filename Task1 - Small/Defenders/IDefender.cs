using Enemies;

namespace Defenders
{
    interface IDefender
    {
        abstract public int Attack(Rat r);
        abstract public int Attack(Giant g);
        abstract public int Attack(Ogre r);
    }
}