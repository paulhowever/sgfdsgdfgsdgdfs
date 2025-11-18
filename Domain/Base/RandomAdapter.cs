using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;

public sealed class RandomAdapter : IRandom
{
    public int RNext(int minInclusive, int maxExclusive)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(maxExclusive, minInclusive);

        return RandomNumberGenerator.GetInt32(minInclusive, maxExclusive);
    }
}