namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

public readonly struct Health
{
    public int Value { get; }

    public Health(int value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        Value = value;
    }
}