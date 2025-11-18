using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures.Decorators;

public abstract class CreatureDecorator : ICreature
{
    public virtual Health Health => Inner.Health;

    public virtual Power Power => Inner.Power;

    public virtual void Attack(ICreature target)
    {
        if (Health.Value <= 0 || Power.Value <= 0 || target.Health.Value <= 0) return;
        Inner.Attack(target);
    }

    public virtual void TakeDamage(Power amount) => Inner.TakeDamage(amount);

    public virtual void UpdateStats(Health health, Power power) =>
        Inner.UpdateStats(health, power);

    public virtual ICreature Clone() => Wrap(Inner.Clone());

    protected CreatureDecorator(ICreature inner)
    {
        Inner = inner;
    }

    protected ICreature Inner { get; }

    protected abstract ICreature Wrap(ICreature copyOfInner);
}