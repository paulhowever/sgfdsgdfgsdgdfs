using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;

public interface ICreature
{
    Health Health { get; }

    Power Power { get; }

    void Attack(ICreature target);

    void TakeDamage(Power amount);

    void UpdateStats(Health health, Power power);

    ICreature Clone();
}