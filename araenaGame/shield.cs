using System;

namespace ArenaGame.Weapons
{
    public class Shield : IWeapon
    {
        public string Name { get; set; }
        public double AttackDamage { get; private set; }
        public double BlockingPower { get; private set; }

        public Shield(string name)
        {
            Name = name;
            AttackDamage = 10;
            BlockingPower = 20;
        }
    }
}