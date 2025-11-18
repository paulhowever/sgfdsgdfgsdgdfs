using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CreaturesTests;

public sealed class MimicTests
{
    [Fact]
    public void BeforeAttack_SetsMaxStatsWithTarget()
    {
        ICreature mimic = new CreatureBuilder()
            .WithHealth(new Health(1)).WithPower(new Power(1))
            .WithModifier(new MimicModifier())
            .Build();

        ICreature target = new CreatureBuilder().WithHealth(new Health(2)).WithPower(new Power(5)).Build();

        mimic.Attack(target);

        Assert.Equal(5, mimic.Power.Value);
        Assert.Equal(2, mimic.Health.Value);
        Assert.Equal(0, target.Health.Value);
    }
}