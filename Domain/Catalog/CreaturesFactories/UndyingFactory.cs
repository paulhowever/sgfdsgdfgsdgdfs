using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.CreaturesFactories;

public sealed class UndyingFactory : ICreatureFactory
{
    public ICreatureBuilder Create() =>
        new CreatureBuilder()
            .WithHealth(new Health(4)).WithPower(new Power(4))
            .WithModifier(new UndyingModifier());
}