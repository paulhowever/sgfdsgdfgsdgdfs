using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.CreaturesFactories;

public sealed class AmuletMasterFactory : ICreatureFactory
{
    public ICreatureBuilder Create() =>
        new CreatureBuilder()
            .WithHealth(new Health(2)).WithPower(new Power(5))
            .WithModifier(new MagicShieldModifier())
            .WithModifier(new AttackMasteryModifier());
}