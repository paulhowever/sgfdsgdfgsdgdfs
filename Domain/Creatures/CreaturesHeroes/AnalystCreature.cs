using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures.CreaturesHeroes;

public sealed class AnalystCreature : Creature
{
    private const int PreAttackBuff = 2;

    public AnalystCreature(Health health, Power power)
        : base(health, power)
    {
    }

    public override ICreature Clone()
    {
        return new AnalystCreature(Health, Power);
    }

    public override void Attack(ICreature target)
    {
        if (Health.Value <= 0 || Power.Value <= 0 || target.Health.Value <= 0)
            return;

        var boosted = new Power(Power.Value + PreAttackBuff);
        UpdateStats(Health, boosted);

        base.Attack(target);
    }
}