using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.ModifiersTests;

public sealed class MagicShieldTests
{
    [Fact]
    public void FirstHit_IsIgnored_Second_Passes()
    {
        ICreature unit = new CreatureBuilder()
            .WithHealth(new Health(5)).WithPower(new Power(1))
            .WithModifier(new MagicShieldModifier())
            .Build();

        unit.TakeDamage(new Power(3));
        Assert.Equal(5, unit.Health.Value);

        unit.TakeDamage(new Power(3));
        Assert.Equal(2, unit.Health.Value);
    }

    [Fact]
    public void Shields_IgnoreTwoHits()
    {
        ICreature unit = new CreatureBuilder()
            .WithHealth(new Health(5)).WithPower(new Power(1))
            .WithModifier(new MagicShieldModifier())
            .Build();

        unit.TakeDamage(new Power(3));
        Assert.Equal(5, unit.Health.Value);

        unit.TakeDamage(new Power(3));
        Assert.Equal(2, unit.Health.Value);
    }
}