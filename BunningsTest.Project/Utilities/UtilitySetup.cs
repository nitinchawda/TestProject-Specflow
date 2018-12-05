using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunningsTest.Project.Utilities
{
    public static class UtilitySetup
    {
        public static string BaseURL => ConfigurationManager.AppSettings["BaseURL"];

        public static object ReportName => ConfigurationManager.AppSettings["ReportName"];
    }
}
