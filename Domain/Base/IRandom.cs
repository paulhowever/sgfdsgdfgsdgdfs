namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;

public interface IRandom
{
    int RNext(int minInclusive, int maxExclusive);
}