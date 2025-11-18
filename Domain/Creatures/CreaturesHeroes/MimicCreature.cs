using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures.CreaturesHeroes;

public sealed class MimicCreature : Creature
{
    public MimicCreature(Health health, Power power)
        : base(health, power)
    {
    }

    public override void Attack(ICreature target)
    {
        if (Health.Value <= 0 || Power.Value <= 0 || target.Health.Value <= 0) return;

        int newPower = Math.Max(Power.Value, target.Power.Value);
        int newHealth = Math.Max(Health.Value, target.Health.Value);

        UpdateStats(new Health(newHealth), new Power(newPower));

        base.Attack(target);
    }

    public override ICreature Clone()
    {
        return new MimicCreature(Health, Power);
    }
}