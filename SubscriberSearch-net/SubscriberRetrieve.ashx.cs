using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.SessionState;

using SubscriberSearch_net.ExactTargetClient;

namespace SubscriberSearch_net
{
    /// <summary>
    /// Summary description for SubscriberRetrieve
    /// </summary>
    public class SubscriberRetrieve : IHttpHandler, IReadOnlySessionState 
    {

        public void ProcessRequest(HttpContext context)
        {

            try
            {
                // Local Variables
                APIObject[] results = null;
                String requestId = null;
                String SOAPEndPoint = context.Session["SOAPEndPoint"].ToString();
                String internalOauthToken = context.Session["internalOauthToken"].ToString();
                String id = context.Request.QueryString["id"].ToString().Trim();

                // Create the binding for using 
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.Name = "UserNameSoapBinding";
                binding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;
                binding.MaxReceivedMessageSize = 2147483647;

                var client = new SoapClient(binding, new EndpointAddress(new Uri(SOAPEndPoint)));
                client.ClientCredentials.UserName.UserName = "*";
                client.ClientCredentials.UserName.Password = "*";

                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    XNamespace ns = "http://exacttarget.com";
                    var oauthElement = new XElement(ns + "oAuthToken", internalOauthToken);
                    var xmlHeader = MessageHeader.CreateHeader("oAuth", "http://exacttarget.com", oauthElement);
                    OperationContext.Current.OutgoingMessageHeaders.Add(xmlHeader);
                
                    // Setup RetrieveRequest
                    RetrieveRequest retrieveRequest = new RetrieveRequest();
                    retrieveRequest.ObjectType = "Subscriber"; //Object Type to retrieve
                    String[] props = { "ID", "EmailAddress", "SubscriberKey", "Status", "CreatedDate" };
                    retrieveRequest.Properties = props;

                    // Query filter using Simplefilter.
                    SimpleFilterPart sfp = new SimpleFilterPart();
                    sfp.Property = "ID";
                    sfp.SimpleOperator = SimpleOperators.equals;
                    sfp.Value = new String[] { id };

                    // Use the SimpleFilter in RetrieveRequest
                    retrieveRequest.Filter = sfp;

                    // Retrieve the subscribers
                    String response = client.Retrieve(retrieveRequest, out requestId, out results);

                    if (response != null && response.ToLower().Equals("ok"))
                    {
                        String strResults = string.Empty;
                        strResults += @"{""subscribers"": [";

                        if (results != null && results.Length > 0)
                        {
                            int i = 1;
                            foreach (Subscriber sub in results)
                            {
                                strResults += @"{""ID"":" + JsonConvert.SerializeObject(sub.ID.ToString()).ToString().Trim() + ", ";
                                strResults += @"""EmailAddress"":" + JsonConvert.SerializeObject(sub.EmailAddress).ToString().Trim() + ", ";
                                strResults += @"""SubscriberKey"":" + JsonConvert.SerializeObject(sub.SubscriberKey).ToString().Trim() + ", ";
                                strResults += @"""Status"":" + JsonConvert.SerializeObject(sub.Status.ToString()).ToString().Trim() + ", ";
                                strResults += @"""CreatedDate"":" + JsonConvert.SerializeObject(sub.CreatedDate.ToString()).ToString().Trim() + " }";
                                if (i < results.Length)
                                    strResults += ", ";
                                i++;
                            }
                            strResults += " ]}";
                            context.Response.Write(strResults);
                        }
                        else
                            context.Response.Write(@"{""subscribers"": []}");
                    }
                    else
                    {
                        context.Response.Write(@"{""subscribers"": []}");
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex);
            }
        } 

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}