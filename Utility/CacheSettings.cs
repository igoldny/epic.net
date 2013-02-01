using System.Web.Configuration;

namespace Epic.Utility
{
    public static class CacheSettings
    {
        private static OutputCacheSettingsSection outputCacheSettings;
        private static OutputCacheProfile cdnCacheSettings;

        static CacheSettings()
        {
            outputCacheSettings = WebConfigurationManager.GetWebApplicationSection("system.web/caching/outputCacheSettings") as OutputCacheSettingsSection;

            if (outputCacheSettings != null)
            {
                cdnCacheSettings = outputCacheSettings.OutputCacheProfiles["Home_CDN"];
            }
        }

        public static uint Duriation 
        { 
            get 
            {
                if (cdnCacheSettings != null)
                {
                    return (uint)cdnCacheSettings.Duration;
                }

                return 0;
            } 
        }

        public static bool Enabled
        {
            get
            {
                if (cdnCacheSettings != null)
                {
                    return cdnCacheSettings.Enabled;
                }

                return false;
            }
        }
    }
}