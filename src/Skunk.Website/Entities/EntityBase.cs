using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Skunk.Website.Entities
{
    [Serializable]
    [DataContract]
    public class EntityBase : IDisposable
    {
        private bool disposed = false;

        /// <summary>
        /// Gets or sets the cache key.
        /// </summary>
        /// <value>
        /// The cache key.
        /// </value>
        [DataMember]
        [XmlIgnore]
        public string CacheKey { get; set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.CacheKey = null;
                }
            }
        }
    }
}
