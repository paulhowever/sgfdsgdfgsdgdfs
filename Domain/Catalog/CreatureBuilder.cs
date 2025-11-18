using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;

public sealed class CreatureBuilder : ICreatureBuilder
{
    private readonly List<ICreatureModifier> _modifiers = new();

    private Health _health;
    private Power _power;

    public ICreatureBuilder WithHealth(Health health)
    {
        _health = health;
        return this;
    }

    public ICreatureBuilder WithPower(Power power)
    {
        _power = power;
        return this;
    }

    public ICreatureBuilder WithModifier(ICreatureModifier modifier)
    {
        _modifiers.Add(modifier);
        return this;
    }

    public ICreature Build()
    {
        ICreature unit = new Creature(_health, _power);

        foreach (ICreatureModifier modifier in _modifiers)
            unit = modifier.Apply(unit);

        return unit;
    }
}