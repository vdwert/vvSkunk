using System;
using System.IO;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Skunk.Website.Helpers
{
    public static class FeedHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="feedUrl"></param>
        /// <returns></returns>
        public static SyndicationFeed GetFeed(string feedUrl)
        {
            Uri serviceUri = new Uri(feedUrl);
            WebClient downloader = new WebClient();

            Stream responseStream = downloader.OpenRead(serviceUri);

            XmlReader responseReader = XmlReader.Create(responseStream);
            SyndicationFeed syndicationFeed = SyndicationFeed.Load(responseReader);
            return syndicationFeed;
        }
    }
}