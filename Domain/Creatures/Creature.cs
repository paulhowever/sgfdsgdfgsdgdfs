using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures;

public class Creature : ICreature
{
    public Health Health { get; private set; }

    public Power Power { get; private set; }

    public Creature(Health health, Power power)
    {
        if (health.Value < 0) throw new ArgumentOutOfRangeException(nameof(health));
        if (power.Value < 0) throw new ArgumentOutOfRangeException(nameof(power));

        Health = health;
        Power = power;
    }

    public virtual void Attack(ICreature target)
    {
        if (Health.Value <= 0 || Power.Value <= 0 || target.Health.Value <= 0)
            return;

        target.TakeDamage(Power);
    }

    public virtual void TakeDamage(Power amount)
    {
        int dmg = Math.Max(0, amount.Value);
        int newHealth = Health.Value - dmg;
        if (newHealth < 0) newHealth = 0;

        Health = new Health(newHealth);
    }

    public virtual ICreature Clone() => new Creature(Health, Power);

    public void UpdateStats(Health health, Power power)
    {
        Health = health;
        Power = power;
    }
}