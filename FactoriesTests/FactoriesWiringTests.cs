using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.CreaturesFactories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.FactoriesTests;

public sealed class FactoriesWiringTests
{
    [Fact]
    public void BrawlerFactory_CreateBuilder_LethalHitDoesNotDoubleBecauseDead()
    {
        var factory = new BrawlerFactory();

        ICreature brawler = factory.Create().Build();
        int power0 = brawler.Power.Value;

        brawler.TakeDamage(new Power(brawler.Health.Value));
        Assert.Equal(0, brawler.Health.Value);
        Assert.Equal(power0, brawler.Power.Value);
    }

    [Fact]
    public void UndyingFactory_CreateBuilder_FirstLethalLeavesOneSecondKills()
    {
        var factory = new UndyingFactory();

        ICreature unit = factory.Create().Build();

        unit.TakeDamage(new Power(unit.Health.Value + 999));
        Assert.Equal(1, unit.Health.Value);

        unit.TakeDamage(new Power(1));
        Assert.Equal(0, unit.Health.Value);
    }

    [Fact]
    public void AnalystFactory_CreateBuilder_PowerGrowsBeforeEachAttack()
    {
        var factory = new AnalystFactory();

        ICreature analyst = factory.Create().Build();

        ICreature target = new CreatureBuilder()
            .WithHealth(new Health(1000)).WithPower(new Power(0))
            .Build();

        int p1Before = analyst.Power.Value;
        analyst.Attack(target);
        int p1After = analyst.Power.Value;

        int p2Before = analyst.Power.Value;
        analyst.Attack(target);
        int p2After = analyst.Power.Value;

        Assert.True(p1After > p1Before);
        Assert.True(p2After > p2Before);
        Assert.True(p2After >= p1After);
    }

    [Fact]
    public void AmuletMasterFactory_CreateBuilder_ShieldAbsorbsAndExtraStrikesApply()
    {
        var factory = new AmuletMasterFactory();

        ICreature am = factory.Create().Build();

        int h0 = am.Health.Value;
        am.TakeDamage(new Power(h0 + 100));
        Assert.True(am.Health.Value > 0);
        ICreature victim = new CreatureBuilder()
            .WithHealth(new Health(10)).WithPower(new Power(0))
            .Build();

        am.Attack(victim);
        Assert.Equal(0, victim.Health.Value);
    }
}
