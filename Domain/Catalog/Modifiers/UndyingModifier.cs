using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures.CreaturesHeroes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;

public sealed class UndyingModifier : ICreatureModifier
{
    public ICreature Apply(ICreature inner)
    {
        return new UndyingCreature(inner.Health, inner.Power);
    }
}