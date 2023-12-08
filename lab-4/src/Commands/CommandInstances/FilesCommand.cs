namespace lab_4.Commands.CommandInstances;

public class FilesCommand : ICommand
{
    private readonly FileNavigator.FileNavigator _fileNavigator;

    public FilesCommand(FileNavigator.FileNavigator fileNavigator)
    {
        _fileNavigator = fileNavigator ?? throw new ArgumentNullException(nameof(fileNavigator));
    }

    public void Run()
    {
        if (!_fileNavigator.IsConnected || _fileNavigator.Location == null) return;
        IEnumerable<string> files = _fileNavigator.FilesFromPath(
            _fileNavigator.Configuration.TreeDepth,
            _fileNavigator.Configuration.Indent,
            _fileNavigator.Location.Path);
        foreach (string systemItemName in files)
        {
            _fileNavigator.OutputWrite(systemItemName);
        }

    }
}