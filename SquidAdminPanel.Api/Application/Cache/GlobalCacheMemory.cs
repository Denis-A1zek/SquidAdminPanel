namespace SquidAdminPanel.Api.Application.Cache
{
    public class GlobalCacheMemory : IGlobalCacheMemory
    {
        private Dictionary<Guid, string> _lastLogTimeValue = new();

        public bool IsExsist(Guid id) => _lastLogTimeValue.ContainsKey(id);

        public string GetLastValue(Guid id)
        {
            CreateIfNotExsist(id);

            return _lastLogTimeValue[id];
        }

        public void SetValue(Guid id, string value)
        {
            CreateIfNotExsist(id);

            _lastLogTimeValue[id] = value;
        }

        private void CreateIfNotExsist(Guid id)
        {
            if (!IsExsist(id))
            {
                CreateCache(id);
            }
        }

        private bool CreateCache(Guid id)
        {
            if (_lastLogTimeValue.ContainsKey(id))
                return false;

            _lastLogTimeValue.Add(id, "0");
            return true;
        }
    }
}
