using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures.CreaturesHeroes;

public sealed class UndyingCreature : Creature
{
    private bool _used;

    public UndyingCreature(Health health, Power power)
        : this(health, power, false)
    {
    }

    private UndyingCreature(Health health, Power power, bool used)
        : base(health, power)
    {
        _used = used;
    }

    public override void TakeDamage(Power amount)
    {
        if (Health.Value <= 0) return;

        if (!_used && amount.Value >= Health.Value)
        {
            UpdateStats(new Health(1), Power);
            _used = true;
        }
        else
        {
            base.TakeDamage(amount);
        }
    }

    public override ICreature Clone()
    {
        return new UndyingCreature(Health, Power, _used);
    }
}