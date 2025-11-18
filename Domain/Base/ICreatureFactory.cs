using Itmo.ObjectOrientedProgramming.Lab3.Domain.Catalog;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Base;

public interface ICreatureFactory
{
    ICreatureBuilder Create();
}