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
                lblMessage.Visible = false;
                lblMessage.Text = "";
                lblMessage.ForeColor = System.Drawing.Color.Black;

                /************************************************************************************
                // Step 1 code only to show JWT
                // Get the SOAP EndPoint
                String decodedJWT = Session["DecodedJWT"].ToString();

                // Parse decoded JWT into JSON object string using Newtonsoft.Json.Linq library in bin folder
                string parsedJWT = JObject.Parse(decodedJWT).ToString(Newtonsoft.Json.Formatting.Indented);
                parsedJWT = parsedJWT.Replace(System.Environment.NewLine, "<br>");

                // Output the encoded and decoded JWT
                lblEncodedJWT.Text = Session["EncodedJWT"].ToString().Trim();
                lblDecodedJWT.Text = parsedJWT;
                *************************************************************************************/

                // Get access (oAuth) token store in session from Login page and make REST call (REST.cs)
                String strAccessToken = System.Web.HttpContext.Current.Session["oauthToken"].ToString();
                String strSOAPEndPoint = REST.REST_GetSOAPEndpointCall(strAccessToken); 

                // Save SOAP EndPoint to session
                Session["SOAPEndPoint"] = strSOAPEndPoint.Trim();
                lblMessage.Visible = true;
                lblMessage.Text = strSOAPEndPoint.Trim();

            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occurred: " + ex.Message;
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}