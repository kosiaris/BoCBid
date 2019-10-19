using BoCBid.ClassHelpers;
using Newtonsoft.Json;
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
            Records response = new Records();

            string URI = "https://data.gov.cy/api/action/datastore/search.json?resource_id=ab9871fe-e7b0-4d4e-bfd5-ab39fed28a28&limit=1";

            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URI);
            myHttpWebRequest.Method = "GET";
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            Stream responseStream = myHttpWebResponse.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();

            //  response = JsonConvert.DeserializeObject<InfoRecords>(pageContent);
            response.MONTH = "01/2017";
            response.DISTRICT = "ΛΕΥΚΩΣΙΑ";
            response.Cases = "146";
            response.Temaxia = "175";
            response.Total_Accepted_Amount = "29449600";
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