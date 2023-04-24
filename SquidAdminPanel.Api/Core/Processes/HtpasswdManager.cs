using SquidAdminPanel.Api.Core.Processes.Base;

namespace SquidAdminPanel.Api.Core.Processes
{
    public class HtpasswdManager : ProcessManager
    {
        private readonly string _pathToUserFile;
        public HtpasswdManager(IConfiguration configuration) =>
            _pathToUserFile = configuration[nameof(HtpasswdManager)]!;

        public async Task CreateNewUserAsync(string userName, string password)
        {
            await ProcessStartAsync(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "htpasswd",
                Arguments = $"-b {_pathToUserFile} {userName} {password}"
            });
        }

        public async Task UpdateExistingUser(string userName, string password)
        {
            await ProcessStartAsync(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "htpasswd",
                Arguments = $"-b {_pathToUserFile} {userName} {password}"
            });
        }

        public async Task DeleteUser(string username)
        {
            await ProcessStartAsync(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "htpasswd",
                Arguments = $"-D {_pathToUserFile} {username}"
            });
        }
    }
}

