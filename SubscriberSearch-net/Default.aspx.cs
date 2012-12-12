using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SubscriberSearch_net
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // If first time to page make the REST call to get the SOAP end point and post to Session variable.
                if (!Page.IsPostBack)
                {
                    // Get access (oAuth) token store in session from Login page and make REST call (REST.cs).
                    String strAccessToken = System.Web.HttpContext.Current.Session["oauthToken"].ToString();
                    String strSOAPEndPoint = REST.REST_GetSOAPEndpointCall(strAccessToken);

                    // Save SOAP EndPoint to session.
                    System.Web.HttpContext.Current.Session["SOAPEndPoint"] = strSOAPEndPoint.Trim();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}