using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.Modifiers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CreaturesTests;

public sealed class AnalystTests
{
    [Fact]
    public void BeforeEachAttack_PowerIncreasesBy2_UntilBattleEnds()
    {
        ICreature analyst = new CreatureBuilder()
            .WithHealth(new Health(4)).WithPower(new Power(2))
            .WithModifier(new AnalystModifier())
            .Build();

        ICreature target = new CreatureBuilder().WithHealth(new Health(5)).WithPower(new Power(1)).Build();

        analyst.Attack(target);
        Assert.Equal(4, analyst.Power.Value);

        analyst.Attack(target);
        Assert.Equal(6, analyst.Power.Value);
    }
}