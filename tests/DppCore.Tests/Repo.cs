namespace DppCore.Tests;

/// <summary>Locates the repository root so tests can read fixtures without hard-coded paths.</summary>
public static class Repo
{
    public static string Root()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir is not null)
        {
            if (File.Exists(System.IO.Path.Combine(dir.FullName, "INDEX.md")) ||
                File.Exists(System.IO.Path.Combine(dir.FullName, "AGENTS.md")))
            {
                return dir.FullName;
            }
            dir = dir.Parent;
        }
        throw new DirectoryNotFoundException("Could not locate repository root (looked for INDEX.md / AGENTS.md).");
    }

    public static string Path(string relative) => System.IO.Path.Combine(Root(), relative);
}
