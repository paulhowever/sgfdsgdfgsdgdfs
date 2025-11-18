using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures.Decorators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;

public sealed class MagicShieldModifier : ICreatureModifier
{
    public ICreature Apply(ICreature inner)
    {
        return new MagicShieldDecorator(inner);
    }
}