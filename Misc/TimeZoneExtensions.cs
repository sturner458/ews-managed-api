using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Exchange.WebServices.Data.Misc
{
    public static class TimeZoneExtensions
    {
        public static TimeZoneInfo CreateCustomTimeZone(string id, TimeSpan baseOffsetToUtc, string name, string standardDisplayName)
        {
            throw new NotImplementedException();
        }

        public static TimeZoneInfo CreateCustomTimeZone(string id, TimeSpan baseOffsetToUtc, string name, string standardDisplayName, 
            string daylightDisplayName, AdjustmentRule[] adjustmentRule)
        {
            throw new NotImplementedException();
        }

        public static AdjustmentRule[] GetAdjustmentRules(this TimeZoneInfo tz)
        {
            throw new NotImplementedException();
        }
    }
}
