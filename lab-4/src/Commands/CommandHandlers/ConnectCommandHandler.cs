using lab_4.Commands.CommandInstances;
using lab_4.Paths;

namespace lab_4.Commands.CommandHandlers;

public class ConnectCommandHandler : CommandHandlerBase
{
    private const string Name = "connect";
    private readonly FileNavigator.FileNavigator _fileNavigator;
    public ConnectCommandHandler(
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
            ICommand command = new ConnectCommand(
                new SystemPath(Path.GetPathRoot(args[0]) ?? string.Empty,args[0]),
                    _fileNavigator);
            command.Run();
        }
        else
        {
            Next?.Handle(input);
        }
    }
}