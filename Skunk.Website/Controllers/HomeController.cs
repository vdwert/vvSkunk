using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Skunk.Website.Controllers
{
    public class HomeController : RenderMvcController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override ActionResult Index(RenderModel model)
        {
            Skunk.Website.Models.HomeModel teamModel = new Skunk.Website.Models.HomeModel(model.Content);

            string competitionFeedUrl = model.Content.GetPropertyValue<string>("competitionFeed");

            Entities.Feed.CompetitionCollection competitionCollection = this.GetCompetitionFeed(competitionFeedUrl);

            teamModel.CompetitionCollection = competitionCollection;

            return View(teamModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="competitionFeedUrl"></param>
        /// <returns></returns>
        private Entities.Feed.CompetitionCollection GetCompetitionFeed(string competitionFeedUrl)
        {
            Skunk.Website.Entities.Feed.CompetitionCollection competitionCollection = Skunk.Website.Helpers.CacheHelper.Get<Skunk.Website.Entities.Feed.CompetitionCollection>("CompetitionFeed_" + competitionFeedUrl);
            if (competitionCollection == null)
            {
                competitionCollection = Helpers.CompetitionHelper.GetCompetitionFeed(competitionFeedUrl);
                Skunk.Website.Helpers.CacheHelper.InsertWithAbsoluteExpiration<Skunk.Website.Entities.Feed.CompetitionCollection>(competitionCollection, "CompetitionFeed_" + competitionFeedUrl, 60);
            }

            return competitionCollection;
        }
    }
}
