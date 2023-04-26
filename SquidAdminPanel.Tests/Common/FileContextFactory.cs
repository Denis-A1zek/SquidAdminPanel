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
    public static int CountOfLogs = 9;
    public static string LogTime = "1681538160.914";


    public static UserContext CreateUserContext(string path)
    {
        
        var context = new UserContext(path);
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            writer.WriteLine("Ivan:123\nGena:567\nSome:676\nSanya:6546");
        }
        return context;
    }

    public static LogsContext CreateLogsContext(string path)
    {
        
        var context = new LogsContext(path);
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            writer.WriteLine("""
                1681538160.479      0 192.168.1.104 TCP_DENIED/407 4128 CONNECT mozilla.cloudflare-dns.com:443 - HIER_NONE/- text/html
                1681538160.479      0 192.168.1.104 TCP_DENIED/407 4128 CONNECT mozilla.cloudflare-dns.com:443 - HIER_NONE/- text/html
                1681538160.762      0 192.168.1.104 TCP_DENIED/407 4128 CONNECT mozilla.cloudflare-dns.com:443 - HIER_NONE/- text/html
                1681538160.847      0 192.168.1.104 TCP_DENIED/407 4449 GET http://detectportal.firefox.com/canonical.html - HIER_NONE/- text/html
                1681538160.914      0 192.168.1.104 TCP_DENIED/407 4186 CONNECT contile.services.mozilla.com:443 - HIER_NONE/- text/html
                1681538161.025      0 192.168.1.104 TCP_DENIED/407 4128 CONNECT mozilla.cloudflare-dns.com:443 - HIER_NONE/- text/html
                1681538161.138      0 192.168.1.104 TCP_DENIED/407 4222 CONNECT firefox.settings.services.mozilla.com:443 - HIER_NONE/- text/html
                1681538161.200      0 192.168.1.104 TCP_DENIED/407 4194 CONNECT incoming.telemetry.mozilla.org:443 - HIER_NONE/- text/html
                1681538161.200      0 192.168.1.104 TCP_DENIED/407 4194 CONNECT incoming.telemetry.mozilla.org:443 - HIER_NONE/- text/html
                """);
        }
        return context; 
    }


    public static void Destroy(string path)
    {
        File.Delete(path);
    }
}
