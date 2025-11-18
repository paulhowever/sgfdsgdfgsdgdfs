using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures.CreaturesHeroes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;

public sealed class AnalystModifier : ICreatureModifier
{
    public ICreature Apply(ICreature inner)
    {
        return new AnalystCreature(inner.Health, inner.Power);
    }
}