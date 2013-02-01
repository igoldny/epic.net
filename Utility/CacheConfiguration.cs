
namespace Epic.Utility
{
    public class CacheConfiguration
    {
        /// <summary>
        /// Gets or sets the id for the cache item
        /// In this demo, it's the combination of "ViewCache__" and the View path
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public string Id { get; set; }
        
        /// <summary>
        /// Gets or sets the duration in second;
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public uint Duration { get; set; }

        /// <summary>
        /// Gets or sets the cache data.
        /// The Data is null when the view content was not set to this cache item
        /// After Data has the value, there should be a mechanism to remove it from your cache store when it's expired
        /// Now it's automatically done by Http Cache
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the Enabled cache.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public bool Enabled { get; set; }
    }
}