using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Exchange.WebServices.Data.Misc
{
    public struct TransitionTime
    {
        public int Day { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }
        public bool IsFixedDateRule { get; internal set; }
        public int Month { get; private set; }
        public DateTime TimeOfDay { get; private set; }
        public int Week { get; private set; }

        internal static TransitionTime CreateFixedDateRule(DateTime dateTime, int month, int dayOrder)
        {
            throw new NotImplementedException();
        }

        internal static TransitionTime CreateFloatingDateRule(DateTime dateTime, int month, int dayOrder, DayOfWeek dayOfWeek)
        {
            throw new NotImplementedException();
        }
    }
}
