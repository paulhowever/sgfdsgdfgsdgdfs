using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CreaturesTests;

public sealed class BrawlerTests
{
    [Fact]
    public void NonLethalDamage_DoublesPower()
    {
        ICreature unit = new CreatureBuilder()
            .WithHealth(new Health(6)).WithPower(new Power(1))
            .WithModifier(new BrawlerModifier())
            .Build();

        unit.TakeDamage(new Power(2));
        Assert.Equal(2, unit.Power.Value);
        Assert.Equal(4, unit.Health.Value);
    }

    [Fact]
    public void LethalDamage_NoDouble_BecauseDies()
    {
        ICreature unit = new CreatureBuilder()
            .WithHealth(new Health(6)).WithPower(new Power(1))
            .WithModifier(new BrawlerModifier())
            .Build();

        unit.TakeDamage(new Power(6));
        Assert.Equal(0, unit.Health.Value);
        Assert.Equal(1, unit.Power.Value);
    }
}