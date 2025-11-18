using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures.CreaturesHeroes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;

public sealed class BrawlerModifier : ICreatureModifier
{
    public ICreature Apply(ICreature inner)
    {
        return new BrawlerCreature(inner.Health, inner.Power);
    }
}