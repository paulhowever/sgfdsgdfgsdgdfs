using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures.CreaturesHeroes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;

public sealed class MimicModifier : ICreatureModifier
{
    public ICreature Apply(ICreature inner) => new MimicCreature(inner.Health, inner.Power);
}