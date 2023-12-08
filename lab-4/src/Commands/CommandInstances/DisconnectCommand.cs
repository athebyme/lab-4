namespace lab_4.Commands.CommandInstances;

public class DisconnectCommand : ICommand
{
    private readonly FileNavigator.FileNavigator _fileNavigator;

    public DisconnectCommand(FileNavigator.FileNavigator fileNavigator)
    {
        _fileNavigator = fileNavigator ?? throw new ArgumentNullException(nameof(fileNavigator));
    }
    public void Run()
    {
        if (!_fileNavigator.IsConnected) return;
        _fileNavigator.SwitchConnection();
        _fileNavigator.OutputWrite("Отключено");
    }
}