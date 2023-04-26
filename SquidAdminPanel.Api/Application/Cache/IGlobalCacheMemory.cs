namespace SquidAdminPanel.Api.Application.Cache
{
    public interface IGlobalCacheMemory
    {
        public bool IsExsist(Guid id);
        public string GetLastValue(Guid id);
        public void SetValue(Guid id, string value);
    }
}
