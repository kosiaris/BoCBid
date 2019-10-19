using BoCBid.ClassHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BoCBid.ApiCalls
{
    public class GetCurrentInfo : ApiController
    {
        // GET api/<controller>
        public static Records Get()
        {
            Records  response = new Records();

            string URI = "https://data.gov.cy/api/action/datastore/search.json?resource_id=ab9871fe-e7b0-4d4e-bfd5-ab39fed28a28&limit=1";

            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URI);
            myHttpWebRequest.Method = "GET";
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            Stream responseStream = myHttpWebResponse.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);
            myHttpWebRequest.ContentType = "application/json";
            string pageContent = myStreamReader.ReadToEnd();

            var test = JObject.Parse(pageContent);
            response.MONTH = test["result"]["records"][0]["MONTH"].ToString();
            response.DISTRICT = test["result"]["records"][0]["DISTRICT"].ToString();
            response.Cases = test["result"]["records"][0]["Cases"].ToString();
            response.Cases = test["result"]["records"][0]["Cases"].ToString();
            response.Temaxia = test["result"]["records"][0]["Temaxia"].ToString();
            response.Total_Accepted_Amount = test["result"]["records"][0]["Total Accepted Amount"].ToString();
         
            return response;
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