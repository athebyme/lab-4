namespace lab_4.FileNavigator.Files;

public interface IFile
{
    string Path { get; }
    void Delete();
}