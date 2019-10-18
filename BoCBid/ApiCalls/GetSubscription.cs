using BoCBid.ClassHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Configuration;
using System.Web.Http;

namespace BoCBid.ApiCalls
{
    public class GetSubscription : ApiController
    {

        // GET api/<controller>
        public static SubscriptionResponse GetSubscriptionid(string token)
        {

            SubscriptionResponse SubscriptionResponseResult = new SubscriptionResponse();

            var client_id = WebConfigurationManager.AppSettings["client_id"];
            var client_secret = WebConfigurationManager.AppSettings["client_secret"];

            string URI = "https://sandbox-apis.bankofcyprus.com/df-boc-org-sb/sb/psd2/v1/subscriptions" + "?client_id=" + client_id + "&client_secret=" + client_secret;

            var newlist = new Dictionary<string, string>();
            newlist["journeyId"] = "1";
            newlist["app_name"] = "1";

            newlist["originUserId"] = "1";

            newlist["timeStamp"] = "1";
            newlist["Authorization"] = token;
            newlist["tppId"] = "singpaymentdata";
            newlist["Content-Type"] = "application/json";
            newlist["accept"] = "application/json";



            //tppId = 'singpaymentdata'
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URI);
            myHttpWebRequest.Method = "POST";

            byte[] data = Encoding.ASCII.GetBytes("{}");
            Stream requestStream = myHttpWebRequest.GetRequestStream();
            requestStream.Write(data, 0, 2);
            requestStream.Close();

            myHttpWebRequest.ContentType = "application/json";
            myHttpWebRequest.Accept = "application/json";

            myHttpWebRequest.Headers.Add("journeyId", "1");
            myHttpWebRequest.Headers.Add("app_name", "1");
            myHttpWebRequest.Headers.Add("originUserId", "1");
            myHttpWebRequest.Headers.Add("timeStamp", "1");
            myHttpWebRequest.Headers.Add("Authorization", token);
            myHttpWebRequest.Headers.Add("tppId", "singpaymentdata");

            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            Stream responseStream = myHttpWebResponse.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();

            SubscriptionResponseResult = JsonConvert.DeserializeObject<SubscriptionResponse>(pageContent); ;

            myStreamReader.Close();
            responseStream.Close();

            myHttpWebResponse.Close();

            return SubscriptionResponseResult;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}