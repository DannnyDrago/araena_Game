using System;
using ArenaGame.Weapons;

namespace ArenaGame.Heroes
{
    public class Tank : Hero
    {
        private int hitCount;

        public Tank(string name, double armor, double strength, IWeapon weapon) : base(name, armor, strength, weapon)
        {
            hitCount = 0;
            Health = 150; // Set health higher specifically for the Tank
        }

        public override double Attack()
        {
            double damage = base.Attack();
            return damage * 0.75; // Tanks deal lower damage
        }

        public override double Defend(double damage)
        {
            hitCount++;
            double reducedDamage = damage - (Armor + Weapon.BlockingPower);
            if (hitCount % 5 == 0) // Every 5th hit reduces the damage
            {
                reducedDamage *= 0.5;
            }
            if (reducedDamage < 0)
            {
                reducedDamage = 0;
            }
            Health -= reducedDamage;
            return reducedDamage;
        }
    }
}