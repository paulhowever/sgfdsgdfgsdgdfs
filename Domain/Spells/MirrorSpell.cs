using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Spells;

public sealed class MirrorSpell : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        Health oldHealth = creature.Health;
        Power oldPower = creature.Power;

        creature.UpdateStats(
            health: new Health(oldPower.Value),
            power: new Power(oldHealth.Value));

        return creature;
    }
}