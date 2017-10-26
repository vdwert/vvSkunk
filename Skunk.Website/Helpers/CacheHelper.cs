using System;
using System.Collections;
using System.Collections.Specialized;

namespace Skunk.Website.Helpers
{
    public class ObjectContainer<T>
    {
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public T Item { get; set; }
    }

    public static class CacheHelper
    {
        /// <summary>
        /// Gets the web cache.
        /// </summary>
        public static System.Web.Caching.Cache WebCache
        {
            get
            {
                return (System.Web.HttpContext.Current == null) ? System.Web.HttpRuntime.Cache : System.Web.HttpContext.Current.Cache;
            }
        }

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="o">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="durationInMinutes">The duration in minutes</param>
        public static void InsertWithAbsoluteExpiration<T>(T o, string key, int durationInMinutes) where T : class
        {
            if (o == null) { return; }

            WebCache.Insert(
                key,
                o,
                null,
                DateTime.Now.AddMinutes(
                    durationInMinutes),
                System.Web.Caching.Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="o">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="durationInMinutes">The duration in minutes</param>
        public static void InsertWithSlidingExpiration<T>(T o, string key, int durationInMinutes) where T : class
        {
            if (o == null) { return; }

            WebCache.Insert(
                key,
                o,
                null,
                System.Web.Caching.Cache.NoAbsoluteExpiration,
                TimeSpan.FromMinutes(durationInMinutes));
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public static void Clear()
        {
            IDictionaryEnumerator enumerator = WebCache.GetEnumerator();
            StringCollection keys = new StringCollection();

            while (enumerator.MoveNext())
            {
                keys.Add(enumerator.Key.ToString());
            }

            foreach (string key in keys)
            {
                WebCache.Remove(key);
            }
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="key">The key.</param>
        public static void RemoveItem(string key)
        {
            WebCache.Remove(key);
        }

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            return WebCache[key] != null;
        }

        /// <summary>
        /// Gets the number of items stored in the cache.
        /// </summary>
        /// <value>The count.</value>
        public static int Count
        {
            get
            {
                return WebCache.Count;
            }
        }


        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public static T Get<T>(string key) where T : class
        {
            return (T)WebCache[key];
        }
    }
}
