using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Exchange.WebServices.Data.Misc
{
    public class AdjustmentRule
    {
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public TransitionTime DaylightTransitionStart { get; private set; }
        public TransitionTime DaylightTransitionEnd { get; private set; }
        public TimeSpan DaylightDelta { get; private set; }

        internal static AdjustmentRule CreateAdjustmentRule(DateTime date1, DateTime date2, TimeSpan timeSpan, TransitionTime transitionTime1, TransitionTime transitionTime2)
        {
            throw new NotImplementedException();
        }
    }
}
