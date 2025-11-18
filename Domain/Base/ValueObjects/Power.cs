namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Base.ValueObjects;

public readonly struct Power
{
    public int Value { get; }

    public Power(int value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        Value = value;
    }
}