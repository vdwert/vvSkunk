using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Xml.Serialization;
using Umbraco.Core.Logging;

namespace Skunk.Website.Helpers
{
    public static class PositionHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionFeedUrl"></param>
        /// <returns></returns>
        public static Skunk.Website.Entities.Feed.PositionCollection GetPositionFeed(string positionFeedUrl)
        {
            try
            {
                Skunk.Website.Entities.Feed.PositionCollection positionCollection = new Skunk.Website.Entities.Feed.PositionCollection();

                SyndicationFeed programFeed = FeedHelper.GetFeed(positionFeedUrl);

                SyndicationFeed feed = Helpers.FeedHelper.GetFeed(positionFeedUrl);
                if (feed.Items.Count() >= 1)
                {
                    SyndicationItem item = feed.Items.ElementAt(0);
                    if (item != null)
                    {
                        string positionsText = item.Summary.Text;
                        positionsText = item.Summary.Text.Replace("\t", string.Empty);
                        positionsText = positionsText.Replace("\n", string.Empty);

                        foreach (string positionItem in positionsText.Split(new string[] { "<br />" }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (positionItem == "# Team") { continue; }

                            Skunk.Website.Entities.Feed.Position position = new Skunk.Website.Entities.Feed.Position();
                            position.Description = positionItem;

                            positionCollection.Add(position);
                        }
                    }
                }

                //System.Collections.ObjectModel.Collection<Stand> oo = programFeed.ElementExtensions.ReadElementExtensions<Stand>("ranking", "http://www.nevobo.nl/competitie/");

                return positionCollection;
            }
            catch (Exception ex)
            {
                LogHelper.Error(typeof(PositionHelper), "Exception while parsing the competition feed", ex);
                return new Skunk.Website.Entities.Feed.PositionCollection();
            }
        }
    }

    [Serializable]
    [XmlSerializerFormat]
    [DataContract(Name = "stand", Namespace = "http://www.nevobo.nl/competitie/")]
    [XmlRoot(ElementName = "stand", Namespace = "http://www.nevobo.nl/competitie/")]
    public class Stand
    {
        public Stand()
        {
        }

        [DataMember(Name = "nummer")]
        [XmlElement("nummer")]
        public string Nummer { get; set; }

        [DataMember(Name = "team")]
        [XmlElement("team")]
        public Team Team { get; set; }

        [DataMember(Name = "wedstrijden")]
        [XmlElement("wedstrijden")]
        public string Wedstrijden { get; set; }

        [DataMember(Name = "punten")]
        [XmlElement("punten")]
        public string Punten { get; set; }

        [DataMember(Name = "setsvoor")]
        [XmlElement("setsvoor")]
        public string Setsvoor { get; set; }

        [DataMember(Name = "setstegen")]
        [XmlElement("setstegen")]
        public string Setstegen { get; set; }

        [DataMember(Name = "puntenvoor")]
        [XmlElement("puntenvoor")]
        public string Puntenvoor { get; set; }

        [DataMember(Name = "puntentegen")]
        [XmlElement("puntentegen")]
        public string Puntentegen { get; set; }



        //<stand:team id = "7224DS 2" >...</ stand:team>
    }

    [Serializable]
    //[XmlSerializerFormat]
    //[DataContract(Name = "team")]
    [DataContract(Name = "team", Namespace = "http://www.nevobo.nl/competitie/")]
    //[XmlRoot(ElementName = "team", Namespace = "http://www.nevobo.nl/competitie/")]
    //[System.Xml.Serialization.XmlType(AnonymousType = true)]
    public class Team
    {
        public Team()
        {
        }

        [DataMember(Name = "id")]
        [XmlAttribute(AttributeName ="id")]
        public string Id { get; set; }

        [DataMember]
        [XmlText]
        public string Text { get; set; }
    }
}