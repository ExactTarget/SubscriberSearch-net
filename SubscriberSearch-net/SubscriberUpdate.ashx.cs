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
using System.Text;

using SubscriberSearch_net.ExactTargetClient;

namespace SubscriberSearch_net
{
    /// <summary>
    /// Summary description for SubscriberUpdate
    /// </summary>
    public class SubscriberUpdate : IHttpHandler, IReadOnlySessionState 
    {

        public void ProcessRequest(HttpContext context)
        {

            try
            {
                // Local Variables
                string uRequestID = String.Empty;
                string uStatus = String.Empty;
                String SOAPEndPoint = context.Session["SOAPEndPoint"].ToString();
                String internalOauthToken = context.Session["internalOauthToken"].ToString();
                String id = context.Request.QueryString["id"].ToString().Trim();
                String status = context.Request.QueryString["status"].ToString().Trim();

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

                    // Setup Subscriber Object
                    Subscriber sub = new Subscriber();
                    sub.ID = int.Parse(id);
                    sub.IDSpecified = true;
                    if (status.ToLower() == "unsubscribed")
                        sub.Status = SubscriberStatus.Unsubscribed;
                    else
                        sub.Status = SubscriberStatus.Active;
                    sub.StatusSpecified = true;

                    //Call the Update method on the Subscriber object
                    UpdateResult[] uResults = client.Update(new UpdateOptions(), new APIObject[] { sub }, out uRequestID, out uStatus);

                    if (uResults != null && uStatus.ToLower().Equals("ok"))
                    {
                        String strResults = string.Empty;
                        strResults += uResults;
                        context.Response.Write(strResults);
                    }
                    else
                    {
                        context.Response.Write("Not OK!");
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