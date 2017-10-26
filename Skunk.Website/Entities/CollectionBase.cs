using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Skunk.Website.Entities
{
    [Serializable]
    [CollectionDataContract]
    public class CollectionBase<T> : List<T>, IDisposable where T : IDisposable
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
                    for (int index = 0; index <= this.Count - 1; index++)
                    {
                        if (this[index] != null)
                        {
                            this[index].Dispose();
                        }
                    }

                    this.Clear();

                    this.CacheKey = null;
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("This collection contains {0} item(s).", this.Count);
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public void AddRange(List<T> collection)
        {
            foreach (T item in collection)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Pages the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public CollectionBase<T> Page(int page, int pageSize)
        {
            IEnumerable<T> products = this.Skip((page - 1) * pageSize).Take(pageSize);

            CollectionBase<T> collection = new CollectionBase<T>();
            collection.AddRange(products);

            return collection;
        }

        /// <summary>
        /// Gets the sub set.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public CollectionBase<T> GetSubSet(int count)
        {
            CollectionBase<T> collection = new CollectionBase<T>();

            if (this.Count == 0) { return this; }
            if (count > this.Count) { count = base.Count; }

            collection.AddRange(this.Take(count));

            return collection;
        }
    }
}
