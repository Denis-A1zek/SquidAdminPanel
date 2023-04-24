using SquidAdminPanel.Api.Data;
using SquidAdminPanel.Api.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SquidAdminPanel.Tests.Common;

internal class FileContextFactory
{
    public static string UserNameForSearch = "Ivan";
    public static UserContext CreateUserContext(string path)
    {
        var context = new UserContext(path);
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            writer.WriteLine("Ivan:123\nGena:567\nSome:676\nSanya:6546");
        }
        return context;
    }


    public static void Destroy(string path)
    {
        File.Delete(path);
    }
}
