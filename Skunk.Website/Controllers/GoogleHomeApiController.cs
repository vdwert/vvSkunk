using System.Web.Http;
using System.Linq;
using Umbraco.Web.WebApi;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Skunk.Website.Controllers
{
    [Route("api/[controller]")]
    public class GoogleHomeApiController : UmbracoApiController
    {
        [HttpPost]
        public IHttpActionResult Heren(JObject text)
        {
            var item = JsonConvert.DeserializeObject<Models.DialogRequest.GoogleDialogRequest>(text.ToString());
            

            var returnValue = item.queryResult.parameters.Team + ", ";
            foreach (var child in Umbraco.TypedContent(1087).Children)
            {
                returnValue = returnValue + child.Name + ", ";
            }

            returnValue = returnValue.Trim();
            returnValue = returnValue.TrimEnd(',');

            Models.DialogResponse.GoogleDialogResponse response = new Models.DialogResponse.GoogleDialogResponse();
            response.fulfillmentText = returnValue;
            response.source = "www.vvskunk.nl";
            response.payload = new Models.DialogResponse.Payload();
            response.payload.google = new Models.DialogResponse.Google();
            response.payload.google.expectUserResponse = false;
            response.payload.google.richResponse = new Models.DialogResponse.Richresponse();
            response.payload.google.richResponse.items = new Models.DialogResponse.Item[1];

            Models.DialogResponse.Simpleresponse simpleresponse = new Models.DialogResponse.Simpleresponse();
            simpleresponse.textToSpeech = returnValue;

            Models.DialogResponse.Item responseItem = new Models.DialogResponse.Item();
            responseItem.simpleResponse = simpleresponse;
            response.payload.google.richResponse.items[0] = responseItem;

            return Json<Models.DialogResponse.GoogleDialogResponse>(response);
        }
    }




}