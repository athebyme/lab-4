using lab_4.Paths;

namespace lab_4.Commands.CommandInstances;

public class RenameCommand : ICommand
{
    private readonly SystemPath _fromPath;
    private readonly string _newName;
    private readonly FileNavigator.FileNavigator _fileNavigator;

    public RenameCommand(SystemPath fromPath, string newName, FileNavigator.FileNavigator fileNavigator)
    {
        _fileNavigator = fileNavigator ?? throw new ArgumentNullException(nameof(fileNavigator));
        _fromPath = fromPath ?? throw new ArgumentNullException(nameof(fromPath));
        _newName = newName ?? throw new ArgumentNullException(nameof(newName));
    }

    public void Run()
    {
        if (Path.Exists(Path.Combine(Path.GetDirectoryName(_fromPath.Path), _newName + Path.GetExtension(_fromPath.Path))))
        {
            _fileNavigator.OutputWrite("Файл с таким именем уже существует");
            return;
        }
        File.Move(
            _fromPath.Path,
            Path.Combine(
                Path.GetDirectoryName(_fromPath.Path) ?? string.Empty,
                _newName + Path.GetExtension(_fromPath.Path)));
    }
}