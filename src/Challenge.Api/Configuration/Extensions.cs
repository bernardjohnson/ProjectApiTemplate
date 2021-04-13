using System;

namespace Template.Api.Configuration
{
    public static class Extensions
    {
        public static string Pais(this String str)
        {
            return str.Split(new char[] { '.', ',', '_' }, StringSplitOptions.RemoveEmptyEntries)[0];
        }
        public static string Regiao(this String str)
        {
            return str.Split(new char[] { '.', ',', '_' }, StringSplitOptions.RemoveEmptyEntries)[1];
        }
        public static string Sensor(this String str)
        {
            return str.Split(new char[] { '.', ',', '_' }, StringSplitOptions.RemoveEmptyEntries)[2];
        }
        public static DateTime UnixToDateTime(this long unix)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unix).DateTime.ToLocalTime();
        }

        public static Int64 DateTimeToUnix(this DateTime date)
        {
            var dateTimeOffset = new DateTimeOffset(date);
            return dateTimeOffset.ToUnixTimeSeconds();
        }
    }
}
