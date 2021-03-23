using Enemies;

namespace Defenders
{
    interface IDefender
    {
        int Attack(Rat r);
        int Attack(Giant g);
        int Attack(Ogre r);
    }
}