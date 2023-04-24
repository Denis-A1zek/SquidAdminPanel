using SquidAdminPanel.Api.Data.Base;

namespace SquidAdminPanel.Api.Data
{
    public class UserContext : FileContext
    {
        public UserContext(string options) : base(options) { }
    }
}
