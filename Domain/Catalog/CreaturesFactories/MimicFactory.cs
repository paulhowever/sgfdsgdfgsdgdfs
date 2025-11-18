using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.CreaturesFactories;

public sealed class MimicFactory : ICreatureFactory
{
    public ICreatureBuilder Create() =>
        new CreatureBuilder()
            .WithHealth(new Health(1)).WithPower(new Power(1))
            .WithModifier(new MimicModifier());
}