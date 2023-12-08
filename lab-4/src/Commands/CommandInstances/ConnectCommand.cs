using lab_4.Paths;

namespace lab_4.Commands.CommandInstances;

public class ConnectCommand : ICommand
{
    private readonly SystemPath _path;
    private readonly FileNavigator.FileNavigator _fileNavigator;

    public ConnectCommand(SystemPath path, FileNavigator.FileNavigator fileNavigator)
    {
        _fileNavigator = fileNavigator ?? throw new ArgumentNullException(nameof(fileNavigator));
        _path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public void Run()
    {
        if (!_fileNavigator.IsConnected)
        {
            _fileNavigator.SwitchConnection();
        }
        _fileNavigator.ChangeLocation(_path);
    }
}