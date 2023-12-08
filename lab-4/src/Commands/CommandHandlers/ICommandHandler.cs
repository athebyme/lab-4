namespace lab_4.Commands.CommandHandlers;

public interface ICommandHandler
{
    void SetNext(ICommandHandler nextHandler);
    void Handle(string input);
}