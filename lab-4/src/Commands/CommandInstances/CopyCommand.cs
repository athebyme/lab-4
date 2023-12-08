using lab_4.Paths;

namespace lab_4.Commands.CommandInstances;

public class CopyCommand : ICommand
{
    private readonly SystemPath _fromPath;
    private readonly SystemPath _toPath;
    private readonly FileNavigator.FileNavigator _fileNavigator;

    public CopyCommand(SystemPath fromPath, SystemPath toPath, FileNavigator.FileNavigator fileNavigator)
    {
        _fileNavigator = fileNavigator ?? throw new ArgumentNullException(nameof(fileNavigator));
        _fromPath = fromPath ?? throw new ArgumentNullException(nameof(fromPath));
        _toPath = toPath ?? throw new ArgumentNullException(nameof(toPath));
    }

    public void Run()
    {
        if (!_fileNavigator.IsConnected) return;
        if (string.Equals(_fromPath.Path, _toPath.Path, StringComparison.Ordinal))
        {
            _fileNavigator.OutputWrite("Путь копирования не может совпадать с путем объекта");
            return;
        }
        File.Copy(
            _fromPath.Path,
            _toPath.Path);
        _fileNavigator.OutputWrite("Файл успешно скопирован");
    }
}