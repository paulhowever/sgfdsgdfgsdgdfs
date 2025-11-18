using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.ModifiersTests;

public sealed class AttackMasteryTests
{
    [Fact]
    public void OneExtraStrike_MakesTwoAttacks_StopsWhenTargetDies()
    {
        ICreature unit = new CreatureBuilder()
            .WithHealth(new Health(5)).WithPower(new Power(3))
            .WithModifier(new AttackMasteryModifier())
            .Build();

        ICreature target = new CreatureBuilder().WithHealth(new Health(4)).WithPower(new Power(0)).Build();
        unit.Attack(target);
        Assert.Equal(0, target.Health.Value);
    }
}