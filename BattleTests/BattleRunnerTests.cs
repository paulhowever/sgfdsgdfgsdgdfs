using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Battle;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.CommonTests;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.BattleTests;

public sealed class BattleRunnerTests
{
    [Fact]
    public void AttackerExists_TargetAbsent_ActiveSideWins()
    {
        var left = new Domain.Desks.Desk();
        left.Add(new CreatureBuilder().WithHealth(new Health(5)).WithPower(new Power(3)).Build());

        var right = new Domain.Desks.Desk();

        var rng = new DeterministicRandom(0);
        var runner = new BattleRunner(rng);

        BattleResult result = runner.Run(left, right);
        Assert.Equal(BattleResult.LeftWin, result);
    }

    [Fact]
    public void BothSidesCannotAttack_Draw()
    {
        var left = new Domain.Desks.Desk();
        left.Add(new CreatureBuilder().WithHealth(new Health(5)).WithPower(new Power(3)).Build());

        var right = new Domain.Desks.Desk();
        right.Add(new CreatureBuilder().WithHealth(new Health(5)).WithPower(new Power(2)).Build());

        var rng = new DeterministicRandom(0);
        var runner = new BattleRunner(rng);

        BattleResult result = runner.Run(left, right);
        Assert.Equal(BattleResult.LeftWin, result);
    }

    [Fact]
    public void LongButFiniteFight_WithoutTurnLimit_StillTerminates()
    {
        var left = new Domain.Desks.Desk();

        left.Add(new CreatureBuilder().WithHealth(new Health(50)).WithPower(new Power(1)).Build());

        var right = new Domain.Desks.Desk();

        right.Add(new CreatureBuilder().WithHealth(new Health(10)).WithPower(new Power(1)).Build());

        var rng = new DeterministicRandom(0);
        var runner = new BattleRunner(rng);

        BattleResult result = runner.Run(left, right);
        Assert.Equal(BattleResult.LeftWin, result);
    }
}