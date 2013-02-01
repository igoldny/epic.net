using System;
using System.Configuration;
using System.Web;
using System.Linq;
using System.Collections.Specialized;

namespace Epic.Utility
{
    public static class Configuration
    {
        public static string Name
        {
            get
            {
                return ConfigurationManager.AppSettings["Name"];
            }
        }
    }
}