using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Skunk.Website.Controllers
{
    public class UtilitySurfaceController : SurfaceController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.ActionResult GetRegistrationForm()
        {
            return File(Server.MapPath("~/RegistrationForm.pdf"), "application/pdf", "Aanmeldingsformulier.pdf");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Skunk.Website.Web.Mvc.RssResult GetActivitySyndicationFeed()
        {
            System.ServiceModel.Syndication.SyndicationFeed feed = new System.ServiceModel.Syndication.SyndicationFeed();

            feed.Title = new System.ServiceModel.Syndication.TextSyndicationContent("Activiteiten", System.ServiceModel.Syndication.TextSyndicationContentKind.Plaintext);
            feed.Copyright = new System.ServiceModel.Syndication.TextSyndicationContent("Volleybalvereniging Skunk", System.ServiceModel.Syndication.TextSyndicationContentKind.Plaintext);
            feed.Description = new System.ServiceModel.Syndication.TextSyndicationContent("Alle activiteiten georganiseerd door volleybalvereniging Skunk", System.ServiceModel.Syndication.TextSyndicationContentKind.Plaintext);
            
            var activitySelection = Umbraco
                .TypedContentAtRoot()
                .DescendantsOrSelf("activity")
                .Where(p => DateTime.Parse(p.GetPropertyValue("dateTime").ToString()) >= DateTime.Now)
                .OrderBy(p => DateTime.Parse(p.GetPropertyValue("dateTime").ToString()));

            List<System.ServiceModel.Syndication.SyndicationItem> syndicationItems = new List<System.ServiceModel.Syndication.SyndicationItem>();

            foreach (var activity in activitySelection)
            {
                System.ServiceModel.Syndication.SyndicationItem syndicationItem = new System.ServiceModel.Syndication.SyndicationItem();

                syndicationItem.Id = activity.Id.ToString();
                syndicationItem.LastUpdatedTime = activity.GetPropertyValue<DateTime>("dateTime");
                syndicationItem.PublishDate = activity.GetPropertyValue<DateTime>("dateTime");
                syndicationItem.Title = new System.ServiceModel.Syndication.TextSyndicationContent(activity.GetPropertyValue<string>("title") + " - " + activity.GetPropertyValue<string>("location"), System.ServiceModel.Syndication.TextSyndicationContentKind.Plaintext);
                syndicationItem.Summary = new System.ServiceModel.Syndication.TextSyndicationContent(activity.GetPropertyValue<string>("content"), System.ServiceModel.Syndication.TextSyndicationContentKind.Html);
                syndicationItem.AddPermalink(new Uri(activity.UrlWithDomain()));

                syndicationItems.Add(syndicationItem);
            }

            feed.Items = syndicationItems;


            return new Web.Mvc.RssResult(feed);
        }
    }
}