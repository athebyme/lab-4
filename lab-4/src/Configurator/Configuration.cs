using System.Globalization;

namespace lab_4.Configurator;

public class Configuration
{
    public Configuration(
        string textIcon,
        string photoIcon,
        string musicIcon,
        string folderIcon,
        string othersIcon,
        string indent,
        int treeDepth)
    {
        if (treeDepth < 0) throw new ArgumentOutOfRangeException(nameof(treeDepth));
        TextIcon = textIcon ?? throw new ArgumentNullException(nameof(textIcon));
        PhotoIcon = photoIcon ?? throw new ArgumentNullException(nameof(photoIcon));
        MusicIcon = musicIcon ?? throw new ArgumentNullException(nameof(musicIcon));
        OtherFilesIcon = folderIcon ?? throw new ArgumentNullException(nameof(folderIcon));
        FolderIcon = othersIcon ?? throw new ArgumentNullException(nameof(othersIcon));
        Indent = indent ?? throw new ArgumentNullException(nameof(indent));
        TreeDepth = treeDepth;
    }
    
    public string TextIcon { get; }
    public string PhotoIcon { get; }
    public string MusicIcon { get; }
    public string OtherFilesIcon { get; }
    public string FolderIcon { get; }
    public string Indent { get; }
    public int TreeDepth { get; }

    public string ItemIcon(string extension)
    {
        return extension.ToLower(CultureInfo.CurrentCulture) switch
        {
            ".txt" => TextIcon,
            ".jpg" or ".png" or ".gif" => PhotoIcon,
            ".mp3" => MusicIcon,
            _ => OtherFilesIcon,
        };
    }
}