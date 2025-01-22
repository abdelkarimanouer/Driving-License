using DVLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLBusinessLayer
{
    public static class clsErrorLoggerBLL
    {
        public static void EventLogError(string Error)
        {
            clsErrorLoggerDAL.EventLogError(Error);
        }
    }
}
