using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Creatures.Decorators;

public sealed class MagicShieldDecorator : CreatureDecorator
{
    private bool _shieldActive;

    public MagicShieldDecorator(ICreature creature, bool shieldActive = true) : base(creature)
    {
        _shieldActive = shieldActive;
    }

    public override void TakeDamage(Power amount)
    {
        if (_shieldActive)
        {
            _shieldActive = false;
            base.TakeDamage(amount: new Power(0));
            return;
        }

        base.TakeDamage(amount);
    }

    protected override ICreature Wrap(ICreature copyOfInner) => new MagicShieldDecorator(copyOfInner);
}