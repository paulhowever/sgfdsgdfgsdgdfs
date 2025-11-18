using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Desks;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Battle;

public sealed class BattleRunner
{
    private readonly IRandom _rng;

    public BattleRunner(IRandom rng)
    {
        _rng = rng;
    }

    public BattleResult Run(Desk left, Desk right)
    {
        Desk leftBattle = left.CreateBattleCopy();
        Desk rightBattle = right.CreateBattleCopy();

        Desk currentAttacker = leftBattle;
        Desk currentDefender = rightBattle;

        while (true)
        {
            IReadOnlyList<ICreature> attackers = currentAttacker.GetAttackers();
            IReadOnlyList<ICreature> defenders = currentDefender.GetDefenders();

            if (attackers.Count == 0 && defenders.Count == 0)
            {
                return BattleResult.Draw;
            }

            if (attackers.Count > 0 && defenders.Count == 0)
            {
                return currentAttacker == leftBattle ? BattleResult.LeftWin : BattleResult.RightWin;
            }

            if (attackers.Count > 0)
            {
                ICreature attacker = attackers[_rng.RNext(0, attackers.Count)];
                ICreature defender = defenders[_rng.RNext(0, defenders.Count)];

                attacker.Attack(defender);
            }

            (currentAttacker, currentDefender) = (currentDefender, currentAttacker);
        }
    }
}
