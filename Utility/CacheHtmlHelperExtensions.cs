using System.Web.Caching;
using Epic.Utility;

namespace System.Web.Mvc
{
    public static class CacheHtmlHelperExtensions
    {
        public const string ViewCachePrefix = "ViewCache__";
        public static void OutputCache(this HtmlHelper helper, CacheConfiguration cacheConfiguration)
        {
            var view = helper.ViewContext.View as BuildManagerCompiledView;
            if (view != null && cacheConfiguration.Enabled)
            {
                cacheConfiguration.Id = ViewCachePrefix + view.ViewPath + helper.ViewContext.HttpContext.Request.IsSecureConnection;
                helper.ViewContext.HttpContext.Cache.Add(cacheConfiguration.Id, 
                                                         cacheConfiguration, 
                                                         null, 
                                                         Cache.NoAbsoluteExpiration, 
                                                         TimeSpan.FromSeconds(cacheConfiguration.Duration),
                                                         CacheItemPriority.Default, 
                                                         null);
            }
        }
    }
}