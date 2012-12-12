using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace SubscriberSearch_net
{
    public class REST
    {
        // Call REST Platform Endpoint Service to get SOAP Endpoint URL for SOAP calls.
        public static String REST_GetSOAPEndpointCall(String accessToken)
        {
            try
            {
                String strSOAPEndPoint = String.Empty;

                // Set REST URL and make call documented at code.exacttarget.com/devcenter/fuel-api-family/platform/endpoints/retrieveendpointsbytype.
                string strURL = "https://www.exacttargetapis.com/platform/v1/endpoints/soap?access_token=" + accessToken.Trim();
                string strResponse = PerformRESTCall_Get(strURL);

                // Parse response into JSON object using Newtonsoft.Json.Linq library in bin folder and get SOAP URL.
                JObject parsedResponse = JObject.Parse(strResponse);
                strSOAPEndPoint = parsedResponse["url"].Value<string>().Trim();

                return strSOAPEndPoint;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message.Trim();
            }
        }

        // Create a request using a URL that can receive a post. 
        static string PerformRESTCall_Get(string strURL)
        {
            try
            {
                // Build the request.
                WebRequest request = WebRequest.Create(strURL.Trim());
                request.Method = "GET";
                request.ContentType = "application/json";

                // Get the response.
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();

                // Return the response.
                return responseFromServer.Trim();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message.Trim();
            }
        }
    }
}