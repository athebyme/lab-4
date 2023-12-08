namespace lab_4.FileNavigator.Files;

public class LocaleFile : IFile
{
    public LocaleFile(string path)
    {
        Path = path;
    }

    public string Path { get; }
    public void Delete()
    {
        File.Delete(Path);
    }
}