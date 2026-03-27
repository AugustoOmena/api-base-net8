using System;
using System.IO;

namespace WebAppBase.Persistence;

public static class SqliteConnectionResolver
{
    private const string SolutionFileName = "WebAppBase.sln";
    private const string DefaultDatabaseFileName = "basen.api.db";

    public static string BuildConnectionString(string? configuredConnectionString = null)
    {
        var databaseFileName = ExtractDatabaseFileName(configuredConnectionString);
        var dataDirectory = Path.Combine(GetSolutionRootDirectory(), "data");
        Directory.CreateDirectory(dataDirectory);

        var databasePath = Path.Combine(dataDirectory, databaseFileName);
        return $"Data Source={databasePath}";
    }

    private static string ExtractDatabaseFileName(string? configuredConnectionString)
    {
        const string dataSourcePrefix = "Data Source=";

        if (string.IsNullOrWhiteSpace(configuredConnectionString))
        {
            return DefaultDatabaseFileName;
        }

        if (!configuredConnectionString.StartsWith(dataSourcePrefix, StringComparison.OrdinalIgnoreCase))
        {
            return DefaultDatabaseFileName;
        }

        var value = configuredConnectionString[dataSourcePrefix.Length..].Trim().Trim('"');
        if (string.IsNullOrWhiteSpace(value))
        {
            return DefaultDatabaseFileName;
        }

        var fileName = Path.GetFileName(value);
        return string.IsNullOrWhiteSpace(fileName) ? DefaultDatabaseFileName : fileName;
    }

    private static string GetSolutionRootDirectory()
    {
        var fromCurrentDirectory = TryFindSolutionRoot(Directory.GetCurrentDirectory());
        if (fromCurrentDirectory is not null)
        {
            return fromCurrentDirectory;
        }

        var fromBaseDirectory = TryFindSolutionRoot(AppContext.BaseDirectory);
        if (fromBaseDirectory is not null)
        {
            return fromBaseDirectory;
        }

        return Directory.GetCurrentDirectory();
    }

    private static string? TryFindSolutionRoot(string startDirectory)
    {
        var directory = new DirectoryInfo(startDirectory);

        while (directory is not null)
        {
            var solutionPath = Path.Combine(directory.FullName, SolutionFileName);
            if (File.Exists(solutionPath))
            {
                return directory.FullName;
            }

            directory = directory.Parent;
        }

        return null;
    }
}
