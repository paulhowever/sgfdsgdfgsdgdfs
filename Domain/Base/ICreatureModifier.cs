namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;

public interface ICreatureModifier
{
    ICreature Apply(ICreature inner);
}
