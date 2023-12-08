namespace lab_4.Paths;

public static class PathValidator
{
    public static string CreatePath(string root, string targetPath)
    {
        if (root == null) throw new ArgumentNullException(nameof(root));
        if (targetPath == null) throw new ArgumentNullException(nameof(targetPath));
        string rootedPath = targetPath;
        if (!Path.IsPathRooted(targetPath))
        {
            rootedPath = Path.Combine(root, targetPath);
        }

        return rootedPath;
    }
}