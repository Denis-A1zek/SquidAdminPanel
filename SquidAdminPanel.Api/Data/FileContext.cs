namespace SquidAdminPanel.Api.Data;

public class FileContext
{
    public string _path = string.Empty;
    public FileContext(string path) => _path = path;
    
    public async Task<TResult> QueryReadLineAsync<TResult>(Func<TResult> initializer,Action<TResult> action)
    {
        TResult result = initializer();

        string? line;
        using StreamReader streamReader = new(_path);
        while ((line = await streamReader.ReadLineAsync()) is not null)
        {
            action(result);
        }

        return result;
    }

    public async Task<TResult> QueryReadAllLineAsync<TResult>(Func<string[], TResult> action)
    {
        string[] fileText = await File.ReadAllLinesAsync(_path);
        return action(fileText);
    }
}
