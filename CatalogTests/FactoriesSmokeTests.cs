using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog.CreaturesFactories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CatalogTests;

public sealed class FactoriesSmokeTests
{
    [Fact]
    public void AmuletMasterFactory_BuildsShieldAndMastery()
    {
        ICreature unit = new AmuletMasterFactory().Create().Build();
        int hpBefore = unit.Health.Value;
        unit.TakeDamage(new Power(999));
        Assert.Equal(hpBefore, unit.Health.Value);
    }

    [Fact]
    public void AnalystFactory_BuildsAnalyst()
    {
        ICreature unit = new AnalystFactory().Create().Build();
        int p0 = unit.Power.Value;
        unit.Attack(new CreatureBuilder().WithHealth(new Health(10)).WithPower(new Power(0)).Build());
        Assert.Equal(p0 + 2, unit.Power.Value);
    }
}