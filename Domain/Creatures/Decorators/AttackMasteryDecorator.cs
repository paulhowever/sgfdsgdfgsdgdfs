using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures.Decorators;

public sealed class AttackMasteryDecorator : CreatureDecorator
{
    public AttackMasteryDecorator(ICreature inner) : base(inner) { }

    public override void Attack(ICreature target)
    {
        base.Attack(target);
        if (Health.Value <= 0 || Power.Value <= 0 || target.Health.Value <= 0) return;
        base.Attack(target);
    }

    protected override ICreature Wrap(ICreature copyOfInner) =>
        new AttackMasteryDecorator(copyOfInner);
}
