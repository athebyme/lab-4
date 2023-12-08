using lab_4.Commands.CommandInstances;
using lab_4.Paths;

namespace lab_4.Commands.CommandHandlers;

public class RenameCommandHandler : CommandHandlerBase
{
    private const string Name = "file rename";
    private readonly FileNavigator.FileNavigator _fileNavigator;
    public RenameCommandHandler(
        FileNavigator.FileNavigator navigator)
    {
        _fileNavigator = navigator;
    }

    public override void Handle(string input)
    {
        if (input == null || _fileNavigator == null) throw new ArgumentNullException(nameof(input));
        if (input.StartsWith(Name, StringComparison.CurrentCulture))
        {
            string[] args = input[(Name.Length + 1)..].Split();
            ICommand command = new RenameCommand(
                new SystemPath(_fileNavigator.Location.Path,args[0]), 
                args[1],
                _fileNavigator);
            command.Run();
        }
        else
        {
            Next?.Handle(input);
        }
    }
}