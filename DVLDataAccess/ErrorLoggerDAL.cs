using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DVLDataAccess
{
    public static class clsErrorLoggerDAL
    {
        public static void EventLogError(string Error)
        {
            string sourceName = "DVL";

            // Create the event source if it does not exist.
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            // Log an information event.
            EventLog.WriteEntry(sourceName, Error, EventLogEntryType.Error);
        }
    }
}
