using System;
using System.Collections.Generic;
using System.Web.Caching;
using System.Web.Mvc;

namespace Epic.Utility
{
    public class CachableRazorView : RazorView
    {
        private const string ViewCachePrefix = CacheHtmlHelperExtensions.ViewCachePrefix;

        #region -- Constructors --
        public CachableRazorView(ControllerContext controllerContext, string viewPath, string layoutPath, bool runViewStartPages, IEnumerable<string> viewStartFileExtensions)
            : base(controllerContext, viewPath, layoutPath, runViewStartPages, viewStartFileExtensions)
        {
        }

        public CachableRazorView(ControllerContext controllerContext, string viewPath, string layoutPath, bool runViewStartPages, IEnumerable<string> viewStartFileExtensions, IViewPageActivator viewPageActivator)
            : base(controllerContext, viewPath, layoutPath, runViewStartPages, viewStartFileExtensions, viewPageActivator)
        {
        } 
        #endregion

        protected override void RenderView(ViewContext viewContext, System.IO.TextWriter writer, object instance)
        {
            var appCache = viewContext.HttpContext.Cache;

            var cacheKey = ViewCachePrefix + ViewPath + viewContext.HttpContext.Request.IsSecureConnection;

            // Check if there was a Cache config that had been fully added to the cache
            var cacheConfiguration = appCache[cacheKey] as CacheConfiguration;
            
            if (cacheConfiguration != null && cacheConfiguration.Data != null)
            {
                writer.Write(cacheConfiguration.Data);
                return;
            }

            var trackableTextWriter = new TrackableTextWriter(writer);
            
            base.RenderView(viewContext, trackableTextWriter, instance);

            // Cache config has just been added when the view is rendered the first time thanks to the HtmlHelper
            cacheConfiguration = appCache[cacheKey] as CacheConfiguration;

            if (cacheConfiguration != null)
            {
                var writtenString = trackableTextWriter.GetWrittenString();
                cacheConfiguration.Data = writtenString;
                appCache.Remove(cacheConfiguration.Id);
                appCache.Add(cacheConfiguration.Id,
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