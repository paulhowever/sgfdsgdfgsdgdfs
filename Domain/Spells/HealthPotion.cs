using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Spells;

public sealed class HealthPotion : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        var newHealth = new Health(creature.Health.Value + 5);
        Power power = creature.Power;

        creature.UpdateStats(newHealth, power);
        return creature;
    }
}