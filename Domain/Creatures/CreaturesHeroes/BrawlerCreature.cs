using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures.CreaturesHeroes;

public sealed class BrawlerCreature : Creature
{
    public BrawlerCreature(Health health, Power power)
        : base(health, power)
    {
    }

    public override void TakeDamage(Power amount)
    {
        int before = Health.Value;

        base.TakeDamage(amount);

        int after = Health.Value;

        if (before > after && after > 0)
        {
            var boosted = new Power(Power.Value * 2);
            UpdateStats(Health, boosted);
        }
    }

    public override ICreature Clone()
    {
        return new BrawlerCreature(Health, Power);
    }
}