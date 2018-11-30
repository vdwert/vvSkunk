using System.Web.Http;
using Umbraco.Web.WebApi;

namespace Skunk.Website.Controllers
{
    [Route("api/[controller]")]
    public class GoogleHomeApiController : UmbracoApiController
    {
        [HttpPost]
        public IHttpActionResult Heren()
        {
            Rootobject o = new Rootobject();
            o.fulfillmentText = "Frank Haver en Cas de Vreede";

            return Json<Rootobject>(o);
        }
    }


    public class Rootobject
    {
        public string fulfillmentText { get; set; }
        //public Fulfillmentmessage[] fulfillmentMessages { get; set; }
        //public string source { get; set; }
        //public Payload payload { get; set; }
        //public Outputcontext[] outputContexts { get; set; }
        //public Followupeventinput followupEventInput { get; set; }
    }

    public class Payload
    {
        public Google google { get; set; }
        public Facebook facebook { get; set; }
        public Slack slack { get; set; }
    }

    public class Google
    {
        public bool expectUserResponse { get; set; }
        public Richresponse richResponse { get; set; }
    }

    public class Richresponse
    {
        public Item[] items { get; set; }
    }

    public class Item
    {
        public Simpleresponse simpleResponse { get; set; }
    }

    public class Simpleresponse
    {
        public string textToSpeech { get; set; }
    }

    public class Facebook
    {
        public string text { get; set; }
    }

    public class Slack
    {
        public string text { get; set; }
    }

    public class Followupeventinput
    {
        public string name { get; set; }
        public string languageCode { get; set; }
        public Parameters parameters { get; set; }
    }

    public class Parameters
    {
        public string param { get; set; }
    }

    public class Fulfillmentmessage
    {
        public Card card { get; set; }
    }

    public class Card
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public string imageUri { get; set; }
        public Button[] buttons { get; set; }
    }

    public class Button
    {
        public string text { get; set; }
        public string postback { get; set; }
    }

    public class Outputcontext
    {
        public string name { get; set; }
        public int lifespanCount { get; set; }
        public Parameters1 parameters { get; set; }
    }

    public class Parameters1
    {
        public string param { get; set; }
    }

}