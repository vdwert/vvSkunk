using Umbraco.Core.Models.PublishedContent;

namespace Skunk.Website.Models
{
    public class TeamModel : PublishedContentModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public TeamModel(Umbraco.Core.Models.IPublishedContent content)
            : base(content)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Skunk.Website.Entities.Feed.CompetitionCollection CompetitionCollection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Skunk.Website.Entities.Feed.PositionCollection PositionCollection { get; set; }
    }
}