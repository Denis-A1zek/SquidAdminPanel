using System.Globalization;

namespace SquidAdminPanel.Api.Core
{
    public static class Converter
    {
        public static DateTime SecondsToDateConverter(string value)
        {
            double seconds = Convert.ToDouble(value, new CultureInfo(CultureInfo.InvariantCulture.Name));
            var time = TimeSpan.FromSeconds(seconds);
            return new DateTime(1970, 01, 01).Add(time); ;
        }
    }
}
