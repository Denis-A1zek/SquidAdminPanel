﻿namespace SquidAdminPanel.Api.Data.Base;

public abstract class FileContext
{
    private string _path = string.Empty;

    /// <summary>
    /// Creates a file context in wich you can make queries
    /// </summary>
    /// <param name="path">Path to file</param>
    /// <exception cref="FileNotFoundException">If file not exsist</exception>
    public FileContext(string path)
    {
        if (File.Exists(path) == false)
            throw new FileNotFoundException($"Файл по пути {path} не был найден");
        _path = path;
    }
    public async Task QueryReadLineAsync(Action<string> action)
    {
        await foreach (var line in File.ReadLinesAsync(_path))
        {
            action(line);
        }
    }
    public async Task<TResult> QueryReadAllLineAsync<TResult>(Func<string[], TResult> action)
    {
        string[] fileText = await File.ReadAllLinesAsync(_path);
        return action(fileText);
    }

}
