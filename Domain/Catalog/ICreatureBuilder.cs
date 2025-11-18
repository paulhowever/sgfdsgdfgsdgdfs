using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;

public interface ICreatureBuilder
{
    ICreatureBuilder WithHealth(Health health);

    ICreatureBuilder WithPower(Power power);

    ICreatureBuilder WithModifier(ICreatureModifier modifier);

    ICreature Build();
}