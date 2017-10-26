using System;
using System.ServiceModel.Syndication;
using Umbraco.Core.Logging;

namespace Skunk.Website.Helpers
{
    public static class CompetitionHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="competitionFeedUrl"></param>
        /// <returns></returns>
        public static Skunk.Website.Entities.Feed.CompetitionCollection GetCompetitionFeed(string competitionFeedUrl)
        {
            try
            {
                Skunk.Website.Entities.Feed.CompetitionCollection competitionCollection = new Skunk.Website.Entities.Feed.CompetitionCollection();

                SyndicationFeed programFeed = FeedHelper.GetFeed(competitionFeedUrl);

                foreach (System.ServiceModel.Syndication.SyndicationItem item in programFeed.Items)
                {
                    Skunk.Website.Entities.Feed.Competition competition = new Skunk.Website.Entities.Feed.Competition();
                    competition.Title = item.Title.Text;
                    competition.Summary = item.Summary.Text;

                    competitionCollection.Add(competition);
                }

                return competitionCollection;
            }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(CompetitionHelper), "Exception while parsing the competition feed", ex);
                return new Skunk.Website.Entities.Feed.CompetitionCollection();
            }
        }
    }
}