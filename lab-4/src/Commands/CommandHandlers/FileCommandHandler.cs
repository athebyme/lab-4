using lab_4.Commands.CommandInstances;

namespace lab_4.Commands.CommandHandlers;

public class FileCommandHandler : CommandHandlerBase
{
    private const string Name = "file print";
    private readonly FileNavigator.FileNavigator _fileNavigator;
    public FileCommandHandler(
        FileNavigator.FileNavigator navigator)
    {
        _fileNavigator = navigator;
    }

    public override void Handle(string input)
    {
        if (input == null || _fileNavigator == null) throw new ArgumentNullException(nameof(input));
        if (input.StartsWith(Name, StringComparison.CurrentCulture))
        {
            ICommand command = new FilesCommand(
                _fileNavigator);
            command.Run();
        }
        else
        {
            Next?.Handle(input);
        }
    }
}