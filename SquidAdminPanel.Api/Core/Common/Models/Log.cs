namespace SquidAdminPanel.Api.Core.Models
{
    public sealed record Log
    {
        public string Time { get; set; }
        public string User { get; set; }
        public string Address { get; set; }
        public string StatusCode { get; set; }
        public string Description { get; set; }
        public string FromAddress { get; set; }

    }
}
