using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CreaturesTests;

public sealed class UndyingTests
{
    [Fact]
    public void FirstLethal_SetsHealthTo1_SecondLethal_Kills()
    {
        ICreature unit = new CreatureBuilder()
            .WithHealth(new Health(5)).WithPower(new Power(1))
            .WithModifier(new UndyingModifier())
            .Build();

        unit.TakeDamage(new Power(10));
        Assert.Equal(1, unit.Health.Value);

        unit.TakeDamage(new Power(1));
        Assert.Equal(0, unit.Health.Value);
    }
}