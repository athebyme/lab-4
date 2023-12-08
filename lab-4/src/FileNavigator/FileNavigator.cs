using lab_4.Output;
using lab_4.Paths;

namespace lab_4.FileNavigator;

public class FileNavigator
{
    private IOutput _output;
    public FileNavigator(IOutput output, Configurator.Configuration configuration)
    {
        _output = output ?? throw new ArgumentNullException(nameof(output));
        Configuration = configuration;
    }

    public Configurator.Configuration Configuration { get; }
    public SystemPath? Location { get; private set; }
    public bool IsConnected { get; private set; }

    public void SwitchConnection() => IsConnected = !IsConnected;
    public void OutputWrite(string text) => _output.Show(text);

    public void ChangeLocation(SystemPath newPath)
    {
        Location = newPath ?? throw new ArgumentNullException(nameof(newPath));
    }
    
    public IEnumerable<string> FilesFromPath(int depth, string indent, string path)
    {
        var items = new List<string>();
        if (depth > 0 && IsConnected)
        {
            foreach (string folderPath in Directory.EnumerateDirectories(path))
            {
                items.Add(indent + Configuration.FolderIcon + Path.GetFileName(folderPath) + "/");
                items.AddRange(FilesFromPath(depth - 1, indent + "\t", folderPath));
            }
        }

        items.AddRange(Directory.GetFiles(path).Select(filePath => indent + Configuration.ItemIcon(Path.GetExtension(filePath)) + Path.GetFileName(filePath)));

        return items;
    }
}