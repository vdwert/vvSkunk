using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;

namespace Skunk.Website.Web.Mvc
{
    public class RssResult : ActionResult
    {
        /// <summary>
        /// Gets or sets the feed.
        /// </summary>
        /// <value>
        /// The feed.
        /// </value>
        public SyndicationFeed Feed { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RssResult"/> class.
        /// </summary>
        public RssResult() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RssResult"/> class.
        /// </summary>
        /// <param name="feed">The feed.</param>
        public RssResult(SyndicationFeed feed)
        {
            this.Feed = feed;
        }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
        /// </summary>
        /// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";

            Rss20FeedFormatter formatter = new Rss20FeedFormatter(this.Feed);

            using (XmlWriter writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                formatter.WriteTo(writer);
            }
        }
    }
}