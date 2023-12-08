namespace lab_4.Commands.CommandHandlers;

public abstract class CommandHandlerBase : ICommandHandler
{
    protected ICommandHandler? Next;

    public void SetNext(ICommandHandler nextHandler)
    {
        Next = nextHandler;
    }

    public abstract void Handle(string input);
}