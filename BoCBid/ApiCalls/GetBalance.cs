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
    public class GetBalance : ApiController
    {
        // GET api/<controller>
        public static string Get(string accountno)
        {
            var token = "Bearer" + GetToken.GetAsync().access_token;
            var client_id = WebConfigurationManager.AppSettings["client_id"];
            var client_secret = WebConfigurationManager.AppSettings["client_secret"];
            var subscriptionid = "Subid000001-1571396841719";

            string URI = "https://sandbox-apis.bankofcyprus.com/df-boc-org-sb/sb/psd2/v1/accounts/"+accountno+"/balance?client_id=" + client_id + "&client_secret=" + client_secret;

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

           List<AccountsResponse> bal = new List<AccountsResponse>();
            bal = JsonConvert.DeserializeObject<List<AccountsResponse>>(pageContent);
            //    var availableamt = bal.Where(o => o.Balances.BalanceType == "AVAILABLE").FirstOrDefault();
            Balances availableamt = new Balances();
            foreach (var item in bal)
            {
                foreach(var bala in item.Balances)
                {
                    if(bala.BalanceType== "AVAILABLE")
                    {
                        availableamt.Amount = bala.Amount;
                    }
                }
            }
            myStreamReader.Close();
            responseStream.Close();

            myHttpWebResponse.Close();
            return availableamt.Amount;
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