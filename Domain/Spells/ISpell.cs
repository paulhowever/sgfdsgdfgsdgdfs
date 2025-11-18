using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Spells;

public interface ISpell
{
    ICreature Apply(ICreature creature);
}