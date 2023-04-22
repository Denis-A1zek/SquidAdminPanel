namespace SquidAdminPanel.Api.Data;

public class FileContext
{
    public string _path = string.Empty;
    public FileContext(string path) => _path = path;
    
    public async Task<TResult> Query<TResult>(Func<TResult> initializer,Action<TResult> action)
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
}
