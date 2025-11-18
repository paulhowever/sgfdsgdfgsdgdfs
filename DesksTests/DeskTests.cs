using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Desks;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Spells;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.DesksTests;

public sealed class DeskTests
{
    [Fact]
    public void Add_UntilCapacity_ThenOneMore_ReturnsDeskIsFull()
    {
        var desk = new Desk();

        for (int i = 0; i < 7; i++)
        {
            ICreature unit = new CreatureBuilder()
                .WithHealth(new Health(3))
                .WithPower(new Power(1))
                .Build();

            DeskResult res = desk.Add(unit);

            Assert.IsType<DeskResult.Success>(res);
            Assert.Equal(i + 1, desk.Count);
        }

        ICreature extra = new CreatureBuilder()
            .WithHealth(new Health(2))
            .WithPower(new Power(2))
            .Build();

        DeskResult overflow = desk.Add(extra);

        Assert.IsType<DeskResult.FailureDeskIsFull>(overflow);
        Assert.Equal(7, desk.Count);
    }

    [Fact]
    public void ApplySpell_ChangesOnlyCreatureOnDesk_SourceObjectStaysUntouched()
    {
        var desk = new Desk();

        ICreature source = new CreatureBuilder()
            .WithHealth(new Health(3))
            .WithPower(new Power(1))
            .Build();

        int srcHpBefore = source.Health.Value;
        int srcPowBefore = source.Power.Value;

        DeskResult addRes = desk.Add(source);
        Assert.IsType<DeskResult.Success>(addRes);

        ICreature creatureOnDesk = desk.GetCreatures.Single();

        var spell = new PowerPotion();
        DeskResult applyRes = desk.ApplySpell(creatureOnDesk, spell);
        Assert.IsType<DeskResult.Success>(applyRes);

        ICreature updated = desk.GetCreatures.Single();
        Assert.Equal(srcPowBefore + 5, updated.Power.Value);
        Assert.Equal(srcHpBefore,       updated.Health.Value);

        Assert.Equal(srcPowBefore, source.Power.Value);
        Assert.Equal(srcHpBefore,  source.Health.Value);
    }

    [Fact]
    public void BattleCopy_NotAffectedByOriginalDeskChanges()
    {
        var desk = new Desk();

        ICreature unit = new CreatureBuilder()
            .WithHealth(new Health(5))
            .WithPower(new Power(3))
            .Build();

        DeskResult addRes = desk.Add(unit);
        Assert.IsType<DeskResult.Success>(addRes);

        Desk battleCopy = desk.CreateBattleCopy();
        IReadOnlyList<ICreature> snapshot = battleCopy.GetCreatures;

        Assert.Single(snapshot);
        Assert.Equal(5, snapshot[0].Health.Value);
        Assert.Equal(3, snapshot[0].Power.Value);

        ICreature creatureOnDesk = desk.GetCreatures.Single();
        _ = desk.ApplySpell(creatureOnDesk, new PowerPotion());

        Assert.Equal(3, snapshot[0].Power.Value);
        Assert.Equal(5, snapshot[0].Health.Value);

        ICreature updated = desk.GetCreatures.Single();
        Assert.Equal(8, updated.Power.Value);
        Assert.Equal(5,  updated.Health.Value);
    }
}
