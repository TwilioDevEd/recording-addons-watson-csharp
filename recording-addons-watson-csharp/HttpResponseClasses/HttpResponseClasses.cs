using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recording_addons_watson_csharp.HttpResponseClasses
{
    public class HttpResponseClasses
    {
        public class Payload
        {
            public string content_type { get; set; }
            public string url { get; set; }
        }

        public class Links
        {
            public string add_on_result { get; set; }
            public string payloads { get; set; }
            public string recording { get; set; }
        }

        public class IbmWatsonSpeechtotext
        {
            public string request_sid { get; set; }
            public string status { get; set; }
            public object message { get; set; }
            public object code { get; set; }
            public List<Payload> payload { get; set; }
            public Links links { get; set; }
        }

        public class Results
        {
            public IbmWatsonSpeechtotext ibm_watson_speechtotext { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public object message { get; set; }
            public object code { get; set; }
            public Results results { get; set; }
        }

        public class BodyData
        {
            public string AddOns { get; set; }
        }
    }

    public class WatsonResponse {
        public class Alternative
        {
            public List<List<object>> timestamps { get; set; }
            public double confidence { get; set; }
            public string transcript { get; set; }
        }

        public class Result2
        {
            public List<Alternative> alternatives { get; set; }
            public bool final { get; set; }
        }

        public class Result
        {
            public List<Result2> results { get; set; }
            public int result_index { get; set; }
            public List<string> warnings { get; set; }
        }

        public class RootObject
        {
            public string user_token { get; set; }
            public List<Result> results { get; set; }
            public string id { get; set; }
            public string @event { get; set; }
        }
    }
}