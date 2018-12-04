using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skunk.Website.Models.DialogRequest
{
    public class GoogleDialogRequest
    {
        public string responseId { get; set; }
        public Queryresult queryResult { get; set; }
        public Originaldetectintentrequest originalDetectIntentRequest { get; set; }
        public string session { get; set; }
    }

    public class Queryresult
    {
        public string queryText { get; set; }
        public Parameters parameters { get; set; }
        public bool allRequiredParamsPresent { get; set; }
        public Fulfillmentmessage[] fulfillmentMessages { get; set; }
        public Intent intent { get; set; }
        public int intentDetectionConfidence { get; set; }
        public string languageCode { get; set; }
    }

    public class Parameters
    {
        public string Team { get; set; }
        public string language { get; set; }
    }

    public class Intent
    {
        public string name { get; set; }
        public string displayName { get; set; }
    }

    public class Fulfillmentmessage
    {
        public Text text { get; set; }
    }

    public class Text
    {
        public string[] text { get; set; }
    }

    public class Originaldetectintentrequest
    {
        public Payload payload { get; set; }
    }

    public class Payload
    {
    }

}