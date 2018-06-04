using System;
using System.Web.Mvc;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

public class VoiceController : TwilioController
{
  
    [HttpPost]
    public ActionResult Index()
    {
        var response = new VoiceResponse();
        response.Say("Hi! I want to know what do you think about coding.");
        response.Record(maxLength: 10, action: new Uri("/recording", UriKind.Relative));
        response.Hangup();

        return TwiML(response);
    }
}