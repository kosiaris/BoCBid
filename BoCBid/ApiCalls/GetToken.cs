using BoCBid.ClassHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;

namespace BoCBid.ApiCalls
{
    public class GetToken : ApiController
    {
        // GET api/<controller>
        [HttpPost]
        public static TokenResponse GetAsync()
        {
            TokenResponse TokenResponseResult = null;

            using (var client = new HttpClient())
            {
                TokenRequest toknewRequest = new TokenRequest
                {
                    client_id = WebConfigurationManager.AppSettings["client_id"],
                    client_secret = WebConfigurationManager.AppSettings["client_secret"],
                    grant_type = "client_credentials",
                    scope = "TPPOAuth2Security"
                };

                string URI = "https://sandbox-apis.bankofcyprus.com" + "/df-boc-org-sb/sb/psd2/oauth2/token";
                var newlist = new Dictionary<string, string>();
                Dictionary<string, string> item1 = new Dictionary<string, string>();
                newlist["client_id"] = toknewRequest.client_id;
                Dictionary<string, string> item2 = new Dictionary<string, string>();
                newlist["client_secret"] = toknewRequest.client_secret;

                Dictionary<string, string> item3 = new Dictionary<string, string>();
                newlist["grant_type"] = toknewRequest.grant_type;

                Dictionary<string, string> item4 = new Dictionary<string, string>();
                newlist["scope"] = toknewRequest.scope;

                string postData = "";

                foreach (var keys in newlist)
                {
                    postData += keys.Key + "="
                          + keys.Value + "&";
                }


              
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URI);
                myHttpWebRequest.Method = "POST";

                byte[] data = Encoding.ASCII.GetBytes(postData);

                myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
                myHttpWebRequest.ContentLength = data.Length;

                Stream requestStream = myHttpWebRequest.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                Stream responseStream = myHttpWebResponse.GetResponseStream();

                StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

                string pageContent = myStreamReader.ReadToEnd();

                TokenResponseResult = JsonConvert.DeserializeObject<TokenResponse>(pageContent); ;

                myStreamReader.Close();
                responseStream.Close();

                myHttpWebResponse.Close();



            }
            return TokenResponseResult;
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