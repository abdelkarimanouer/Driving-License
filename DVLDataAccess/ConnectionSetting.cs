using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLDataAccess
{
    public static class clsConnectionSetting
    {
        public static string connectionstring = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
    }
}
