namespace lab_4.Paths;

public class SystemPath
{
    public SystemPath(string rootPath, string path)
    {
        if (path is null) throw new ArgumentNullException(nameof(path));
        Path = PathValidator.CreatePath(rootPath, path);
    }

    public string Path { get; }
}