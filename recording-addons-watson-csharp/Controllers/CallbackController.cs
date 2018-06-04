using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Twilio.AspNet.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using recording_addons_watson_csharp.HttpResponseClasses;

public class CallbackController : TwilioController
{
    [HttpPost]
    public ActionResult Index(HttpResponseClasses.BodyData bodyData)
    {
        var data = bodyData.AddOns;
        var addOns = JsonConvert.DeserializeObject<HttpResponseClasses.RootObject>(data);
        if (addOns.results.ibm_watson_speechtotext.ToString() == "")
        {
            return Content("Add Watson Speech to Text add-on in your Twilio console");
        }

        var payloadUrl = addOns.results.ibm_watson_speechtotext.payload[0].url;
        var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
        var apiKey = ConfigurationManager.AppSettings["TwilioAuthToken"];

        var reqCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(accountSid + ":" + apiKey));
        var request = (HttpWebRequest)WebRequest.Create(payloadUrl);
        request.Headers.Add("Authorization", "Basic " + reqCredentials);
        var response = (HttpWebResponse)request.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader streamreader = new StreamReader(stream);
        var responseBody = streamreader.ReadToEnd();

        var results = JsonConvert.DeserializeObject<WatsonResponse.RootObject>(responseBody).results[0].results;
        var transcripts = string.Join("", 
                results.ConvertAll<string>(item => item.alternatives[0].transcript).ToArray()
            );

        return Content(transcripts);
    }
}
