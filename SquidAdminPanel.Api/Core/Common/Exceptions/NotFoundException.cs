namespace SquidAdminPanel.Api.Core.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name)
        : base($"Entity \"{name}\" not found.") { }
}
