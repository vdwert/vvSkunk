using Umbraco.Core.Models.PublishedContent;

namespace Skunk.Website.Models
{
    public class HomeModel : PublishedContentModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public HomeModel(Umbraco.Core.Models.IPublishedContent content)
            : base(content)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Skunk.Website.Entities.Feed.CompetitionCollection CompetitionCollection { get; set; }
    }
}