using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Spells;

public sealed class PowerPotion : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        Health health = creature.Health;
        var newPower = new Power(creature.Power.Value + 5);

        creature.UpdateStats(health, newPower);
        return creature;
    }
}