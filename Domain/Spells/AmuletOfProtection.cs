using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures.Decorators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Spells;

public sealed class AmuletOfProtection : ISpell
{
    public ICreature Apply(ICreature creature) =>
        new MagicShieldDecorator(creature);
}