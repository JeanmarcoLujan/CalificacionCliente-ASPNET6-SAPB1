using CalificationAppWeb.Models;
using Newtonsoft.Json;
using System.Net;

namespace CalificationAppWeb.Helpers
{
    public class LoginHelper
    {
        public static B1Session LoginB(User datosLoguo, string ip)
        {

            string data = "{    \"CompanyDB\": \"" + datosLoguo.CompanyDB.ToString() + "\",    \"UserName\": \"" + datosLoguo.UserName.ToString() + "\",       \"Password\": \"" + datosLoguo.Password.ToString() + "\", \"Language\":\"23\"}";

            B1Session obj = null;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ip + "Login");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                httpWebRequest.Headers.Add("B1S-WCFCompatible", "true");
                httpWebRequest.Headers.Add("B1S-MetadataWithoutSession", "true");
                httpWebRequest.Accept = "*/*";
                httpWebRequest.ServicePoint.Expect100Continue = false;
                httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                { streamWriter.Write(data); }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();



                var result = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                    obj = JsonConvert.DeserializeObject<B1Session>(result);
                }
            }
            catch (Exception e)
            {
                obj = JsonConvert.DeserializeObject<B1Session>("");
            }


            return obj;
        }
    }
}
