using System.Diagnostics;

namespace SquidAdminPanel.Api.Core.Processes.Base
{
    public abstract class ProcessManager
    {
        public async Task ProcessStartAsync(ProcessStartInfo startInfo)
        {
            await Task.Run(() => Process.Start(startInfo));
        }
    }
}
