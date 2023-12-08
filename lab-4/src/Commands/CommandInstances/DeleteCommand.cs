using lab_4.FileNavigator.Files;
using lab_4.Paths;

namespace lab_4.Commands.CommandInstances;

public class DeleteCommand : ICommand
{
    private readonly IFile _file;
    private readonly FileNavigator.FileNavigator _fileNavigator;

    public DeleteCommand(SystemPath path, FileNavigator.FileNavigator fileNavigator)
    {
        _fileNavigator = fileNavigator ?? throw new ArgumentNullException(nameof(fileNavigator));
        _file = new LocaleFile(path.Path ?? throw new ArgumentNullException(nameof(path)));
    }

    public void Run()
    {
        if (!_fileNavigator.IsConnected) return;
        _file.Delete();
        _fileNavigator.OutputWrite("Файл удален");
    }
}