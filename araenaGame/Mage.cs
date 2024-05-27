using System;


namespace ArenaGame.Heroes
{
    public class Mage : Hero
    {
        public Mage(string name, double armor, double strength, IWeapon weapon) : base(name, armor, strength, weapon)
        {
        }

        public override double Attack()
        {
            double damage = base.Attack();
            double magicMultiplier = random.NextDouble();
            if (magicMultiplier < 0.20) // 20% chance to apply magic multiplier
            {
                damage *= 2.0; // Double the damage
            }
            return damage;
        }

        public override double Defend(double damage)
        {
            // Mages have lower defense capabilities
            double reducedDamage = damage - (Armor * 0.5 + Weapon.BlockingPower * 0.5);
            if (reducedDamage < 0)
            {
                reducedDamage = 0;
            }
            Health -= reducedDamage;
            return reducedDamage;
        }
    }
}