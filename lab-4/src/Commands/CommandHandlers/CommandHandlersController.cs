using lab_4.Commands.CommandHandlers;

namespace lab_4.Commands;

public class CommandHandlersController
{
    private readonly ICommandHandler _firstCommandHandler;
    private readonly FileNavigator.FileNavigator _fileNavigator;
    public CommandHandlersController(
        FileNavigator.FileNavigator navigator,
        ICommandHandler firstCommandHandler)
    {
        _fileNavigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
        _firstCommandHandler = firstCommandHandler ?? throw new ArgumentNullException(nameof(firstCommandHandler));
    }

    public void Run(string input)
    {
        try
        {
            _firstCommandHandler.Handle(input);
        }
        catch (Exception e)
        {
            _fileNavigator.OutputWrite(e.Message);
        }
    }
}