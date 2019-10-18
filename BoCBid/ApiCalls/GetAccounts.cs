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
    public class GetAccounts : ApiController
    {
        // GET api/<controller>
        public static List<AccountsResponse> Get()
        {
           List<AccountsResponse> accounts = null;

            var token = "Bearer" + GetToken.GetAsync().access_token;

            //here we go
            var client_id = WebConfigurationManager.AppSettings["client_id"];
            var client_secret = WebConfigurationManager.AppSettings["client_secret"];

            var subscriptionid = "Subid000001-1571396841719";// GetSubscription.GetSubscriptionid(token).subscriptionId;

            var URI = new Uri("https://sandbox-apis.bankofcyprus.com/df-boc-org-sb/sb/psd2/v1/accounts?client_secret=" + client_secret + "&client_id=" + client_id + "");
            //HTTP GET
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URI);
            myHttpWebRequest.Method = "GET";

            //byte[] data = Encoding.ASCII.GetBytes("{}");
            //Stream requestStream = myHttpWebRequest.GetRequestStream();
            //requestStream.Write(data, 0, 2);
            //requestStream.Close();

            myHttpWebRequest.ContentType = "application/json";
            myHttpWebRequest.Headers.Add("Authorization", token);
            myHttpWebRequest.Headers.Add("journeyId", "1");
            myHttpWebRequest.Headers.Add("originUserId", "1");
            myHttpWebRequest.Headers.Add("timeStamp", "1");
            myHttpWebRequest.Headers.Add("subscriptionId", subscriptionid);
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            Stream responseStream = myHttpWebResponse.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();

            accounts = JsonConvert.DeserializeObject<List<AccountsResponse>>(pageContent); 

            myStreamReader.Close();
            responseStream.Close();

            myHttpWebResponse.Close();

            return accounts;
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