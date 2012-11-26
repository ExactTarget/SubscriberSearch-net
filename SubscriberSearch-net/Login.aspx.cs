using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace SubscriberSearch_net
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";

                // Input the Application Signature (Secret) from App Center into the web.config file for use here
                string applicationSecret = ConfigurationManager.AppSettings["applicationSecret"].Trim();

                // Signed request posted from IMH
                string encodedJWT = Request.Form["jwt"];
               
                if (encodedJWT.Trim().Length > 0)
                {
                    // Decoded request using JWT.cs in the project that leverages https://github.com/johnsheehan/jwt
                    String decodedJWT = JsonWebToken.Decode(encodedJWT, applicationSecret);

                    // Store encoded and decoded JWT in sesssion variables for step 1 display only
                    Session["EncodedJWT"] = encodedJWT.Trim();
                    Session["DecodedJWT"] = decodedJWT.Trim();

                    // Parsed request into JSON object using Newtonsoft.Json.Linq library in bin folder
                    JObject parsedJWT = JObject.Parse(decodedJWT);
                    Session["internalOauthToken"] = parsedJWT["request"]["user"]["internalOauthToken"].Value<string>().Trim();
                    Session["oauthToken"] = parsedJWT["request"]["user"]["oauthToken"].Value<string>().Trim();

                    // Redirect to the application redirectURL specified in App Center
                    Response.Redirect(parsedJWT["request"]["application"]["redirectUrl"].Value<string>().Trim());
                }
                else
                    lblMessage.Text = "JWT not provided!";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occurred: " + ex.Message;
            }
        }
    }
}