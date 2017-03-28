using System;

namespace ICEWebSiteTestAutomationBase.Utils
{
    public static class DateTimeUtils
    {
        private static readonly DateTime Jan1St1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long CurrentTimeMillis(DateTime d)
        {
            return (long) (DateTime.UtcNow - Jan1St1970).TotalMilliseconds;
        }

        public static long CurrentTimeMillis()
        {
            var jan1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var javaSpan = DateTime.UtcNow - jan1970;
            return (long) javaSpan.TotalMilliseconds;
        }
    }
}