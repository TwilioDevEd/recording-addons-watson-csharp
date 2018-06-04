using System;
using System.Web.Mvc;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

public class RecordingController : TwilioController
{
    public class BodyData
    {
        public string RecordingUrl { get; set; }
    }

    [HttpPost]
    public ActionResult Index(BodyData bodyData)
    {
        string recordingUrl = bodyData.RecordingUrl;
        Console.WriteLine(recordingUrl);
       
        var response = new VoiceResponse();
        response.Say("Thanks for howling... take a listen to what you howled.");
        response.Play(new Uri(recordingUrl));
        response.Say("Goodbye.");

        return TwiML(response);
    }
}