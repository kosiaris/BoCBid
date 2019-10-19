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
    public class SignRequest : ApiController
    {
        // GET api/<controller>
        public static string Get()
        {
            var client_id = WebConfigurationManager.AppSettings["client_id"];
            var client_secret = WebConfigurationManager.AppSettings["client_secret"];
            var subscriptionid = "Subid000001-1571396841719";

            string URI = "https://sandbox-apis.bankofcyprus.com/df-boc-org-sb/sb/jwssignverifyapi/sign";

            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URI);
            myHttpWebRequest.Method = "POST";

            myHttpWebRequest.ContentType = "application/json";
            myHttpWebRequest.Headers.Add("tppId", "singpaymentdata");

            var postData = "{ \"debtor\" : { \"bankId\" : \"\", \"accountId\" : \"351012345671\" }, \"creditor\" : { \"bankId\" : \"\", \"accountId\" : \"351092345671\"  }, \"transactionAmount\" : {  \"amount\": \"2.55\", \"currency\" :  \"EUR\", \"currencyRate\" : \"string\" }, \"endToEndId\" : \"string\" ,  \"paymentDetails\" : \"test sandbox\" ,  \"terminalId\": \"string\", \"branch\" : \"\", \"executionDate\": \"\", \"valueDate\" : \"\"}";

            using (var streamWriter = new StreamWriter(myHttpWebRequest.GetRequestStream()))
            {
          
                streamWriter.Write(postData);
            }
          

            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            Stream responseStream = myHttpWebResponse.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();

            URI = "https://sandbox-apis.bankofcyprus.com/df-boc-org-sb/sb/psd2/v1/payments?client_id=" + client_id + "&client_secret=" + client_secret + "";

            HttpWebRequest myHttpWebRequesta = (HttpWebRequest)HttpWebRequest.Create(URI);
            myHttpWebRequesta.Method = "POST";

            var token = "Bearer" + GetToken.GetAsync().access_token;
            myHttpWebRequesta.ContentType = "application/json";
            myHttpWebRequesta.Headers.Add("Authorization", token);
            myHttpWebRequesta.Headers.Add("subscriptionId", subscriptionid);
            myHttpWebRequesta.Headers.Add("originUserId", "1");
            myHttpWebRequesta.Headers.Add("tppId","singpaymentdata");
            myHttpWebRequesta.Headers.Add("journeyId", "1");
            myHttpWebRequesta.Headers.Add("timeStamp", "1");
            myHttpWebRequesta.Headers.Add("lang", "1");

            using (var streamWriter = new StreamWriter(myHttpWebRequesta.GetRequestStream()))
            {
                streamWriter.Write(pageContent);
            }
            HttpWebResponse myHttpWebResponsea = (HttpWebResponse)myHttpWebRequesta.GetResponse();

            Stream responseStreama = myHttpWebResponsea.GetResponseStream();

            StreamReader myStreamReadera = new StreamReader(responseStreama, Encoding.Default);

             pageContent = myStreamReadera.ReadToEnd();

            var paymentId  = JsonConvert.DeserializeObject<GePayment>(pageContent).payment;
            var res = paymentId.paymentId;
            return res;
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