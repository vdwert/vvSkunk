using Examine;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace Skunk.Website.Models
{
    public class SearchModel : PublishedContentModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public SearchModel(Umbraco.Core.Models.IPublishedContent content)
            : base(content)
        {
        }

        public IEnumerable<SearchResult> SearchResults { get; set; }
    }
}