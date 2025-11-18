using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Desks;

public sealed class Desk
{
    private const int Capacity = 7;

    private readonly List<ICreature> _slots = new();

    public int Count => _slots.Count;

    public DeskResult Add(ICreature creature)
    {
        if (_slots.Count >= Capacity)
            return new DeskResult.FailureDeskIsFull();

        _slots.Add(creature.Clone());
        return new DeskResult.Success();
    }

    public DeskResult ApplySpell(ICreature creature, ISpell spell)
    {
        int index = _slots.IndexOf(creature);
        if (index < 0)
            return new DeskResult.FailureCreatureNotOnDesk();

        _slots[index] = spell.Apply(_slots[index]);
        return new DeskResult.Success();
    }

    public Desk CreateBattleCopy()
    {
        var battleDesk = new Desk();
        foreach (ICreature creature in _slots)
            battleDesk._slots.Add(creature.Clone());

        return battleDesk;
    }

    public IReadOnlyList<ICreature> GetAttackers() =>
        _slots
            .Where(c => c.Health.Value > 0 && c.Power.Value > 0)
            .ToList();

    public IReadOnlyList<ICreature> GetDefenders() =>
        _slots
            .Where(c => c.Health.Value > 0)
            .ToList();

    public IReadOnlyList<ICreature> GetCreatures => _slots.AsReadOnly();

    public ICreature this[int index] => _slots[index].Clone();
}