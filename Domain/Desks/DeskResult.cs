namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Desks;

public abstract record DeskResult
{
    private DeskResult() { }

    public sealed record Success : DeskResult { }

    public sealed record FailureCreatureNotOnDesk : DeskResult { }

    public sealed record FailureDeskIsFull : DeskResult { }
}