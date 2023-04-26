using System.Globalization;

namespace SquidAdminPanel.Api.Core
{
    public static class Converter
    {

        /// <summary>
        /// Converts seconds from 1970 to the present
        /// </summary>
        /// <param name="value">Seconds since 1970</param>
        /// <returns>Date time</returns>
        public static DateTime SecondsToDateConverter(string value)
        {
            double seconds = Convert.ToDouble(value, new CultureInfo(CultureInfo.InvariantCulture.Name));
            var time = TimeSpan.FromSeconds(seconds);
            return new DateTime(1970, 01, 01).Add(time); ;
        }
    }
}
