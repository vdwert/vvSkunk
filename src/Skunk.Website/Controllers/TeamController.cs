using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Skunk.Website.Controllers
{
    public class TeamController : RenderMvcController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override ActionResult Index(RenderModel model)
        {
            Skunk.Website.Models.TeamModel teamModel = new Skunk.Website.Models.TeamModel(model.Content);

            string competitionFeedUrl = model.Content.GetPropertyValue<string>("competitionFeed");
            Entities.Feed.CompetitionCollection competitionCollection = this.GetCompetitionFeed(competitionFeedUrl);
            teamModel.CompetitionCollection = competitionCollection;

            string positionFeedUrl = model.Content.GetPropertyValue<string>("positionFeed");
            Entities.Feed.PositionCollection positionCollection = this.GetPositionFeed(positionFeedUrl);
            teamModel.PositionCollection = positionCollection;

            return View(teamModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="competitionFeedUrl"></param>
        /// <returns></returns>
        private Entities.Feed.CompetitionCollection GetCompetitionFeed(string competitionFeedUrl)
        {
            if (string.IsNullOrWhiteSpace(competitionFeedUrl))
            {
                return new Entities.Feed.CompetitionCollection();
            }

            Skunk.Website.Entities.Feed.CompetitionCollection competitionCollection = Skunk.Website.Helpers.CacheHelper.Get<Skunk.Website.Entities.Feed.CompetitionCollection>("CompetitionFeed_" + competitionFeedUrl);
            if (competitionCollection == null)
            {
                competitionCollection = Helpers.CompetitionHelper.GetCompetitionFeed(competitionFeedUrl);
                Skunk.Website.Helpers.CacheHelper.InsertWithAbsoluteExpiration<Skunk.Website.Entities.Feed.CompetitionCollection>(competitionCollection, "CompetitionFeed_" + competitionFeedUrl, 60);
            }

            return competitionCollection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionFeedUrl"></param>
        /// <returns></returns>
        private Entities.Feed.PositionCollection GetPositionFeed(string positionFeedUrl)
        {
            if (string.IsNullOrWhiteSpace(positionFeedUrl))
            {
                return new Entities.Feed.PositionCollection();
            }

            Skunk.Website.Entities.Feed.PositionCollection positionCollection = Skunk.Website.Helpers.CacheHelper.Get<Skunk.Website.Entities.Feed.PositionCollection>("PositionFeed_" + positionFeedUrl);
            if (positionCollection == null)
            {
                positionCollection = Helpers.PositionHelper.GetPositionFeed(positionFeedUrl);
                Skunk.Website.Helpers.CacheHelper.InsertWithAbsoluteExpiration<Skunk.Website.Entities.Feed.PositionCollection>(positionCollection, "PositionFeed_" + positionFeedUrl, 60);
            }

            return positionCollection;
        }
    }
}
