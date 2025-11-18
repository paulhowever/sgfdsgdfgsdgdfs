using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Spells;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.SpellsTests;

public sealed class SpellsAndApplierTests
{
    [Fact]
    public void AmuletOfProtection_AddsShield_Stackable()
    {
        ICreature unit = new CreatureBuilder().WithHealth(new Health(5)).WithPower(new Power(1)).Build();
        var spell = new AmuletOfProtection();

        ICreature withSpell = spell.Apply(unit);
        withSpell.TakeDamage(new Power(999));
        Assert.Equal(5, withSpell.Health.Value);

        withSpell.TakeDamage(new Power(1));
        Assert.Equal(4, withSpell.Health.Value);
    }

    [Fact]
    public void PowerPotion_AddsFivePower()
    {
        ICreature unit = new CreatureBuilder().WithHealth(new Health(5)).WithPower(new Power(1)).Build();
        ICreature boosted = new PowerPotion().Apply(unit);
        Assert.Equal(6, boosted.Power.Value);
    }

    [Fact]
    public void StaminaPotion_AddsFiveHealth()
    {
        ICreature unit = new CreatureBuilder().WithHealth(new Health(5)).WithPower(new Power(1)).Build();
        ICreature boosted = new HealthPotion().Apply(unit);
        Assert.Equal(10, boosted.Health.Value);
    }

    [Fact]
    public void MirrorSpell_SwapsStats()
    {
        ICreature unit = new CreatureBuilder().WithHealth(new Health(2)).WithPower(new Power(7)).Build();
        ICreature swapped = new MirrorSpell().Apply(unit);
        Assert.Equal(7, swapped.Health.Value);
        Assert.Equal(2, swapped.Power.Value);
    }
}