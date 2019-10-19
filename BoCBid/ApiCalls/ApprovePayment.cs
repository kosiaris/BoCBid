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
    public class ApprovePayment : ApiController
    {
        // GET api/<controller>
        public static void Get(string paymentid)
        {
            var client_id = WebConfigurationManager.AppSettings["client_id"];
            var client_secret = WebConfigurationManager.AppSettings["client_secret"];
            var subscriptionid = "Subid000001-1571396841719";// GetSubscription.GetSubscriptionid(token).subscriptionId;
            var token = "Bearer" + GetToken.GetAsync().access_token;
            var URI = new Uri("https://sandbox-apis.bankofcyprus.com/df-boc-org-sb/sb/psd2/v1/payments/"+ paymentid + "/authorize?client_secret=" + client_secret + "&client_id=" + client_id + "");

            HttpWebRequest myHttpWebRequesta = (HttpWebRequest)HttpWebRequest.Create(URI);
            myHttpWebRequesta.Method = "POST";

            myHttpWebRequesta.ContentType = "application/json";
            myHttpWebRequesta.Headers.Add("Authorization", token);
            myHttpWebRequesta.Headers.Add("subscriptionId", subscriptionid);
            myHttpWebRequesta.Headers.Add("originUserId", "1");
            myHttpWebRequesta.Headers.Add("tppId", "singpaymentdata");
            myHttpWebRequesta.Headers.Add("journeyId", "1");
            myHttpWebRequesta.Headers.Add("timeStamp", "1");
          
            using (var streamWriter = new StreamWriter(myHttpWebRequesta.GetRequestStream()))
            {
                var postData = "{\"transactionTime\":\"1515051381394\"," +
                                "\"authCode\":\"123456\"}";
                streamWriter.Write(postData);
            }
  

            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequesta.GetResponse();

            Stream responseStream = myHttpWebResponse.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();

            return;
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