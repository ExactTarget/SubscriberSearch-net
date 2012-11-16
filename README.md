#[SubscriberSearch-net]
=================

SubscriberSearch-net is an example application which illustrates how to create a Hub Exchange application utilizing Single Sign-on (SSO) for ExactTarget's Interactive Marketing Hub using .NET/C#.

#Requirements
----------
* Access to App Center on http://code.exacttarget.com
* .NET Framework 3.5 or higher
* Web Server that can host .NET Web Sites

#Notes
----------
* Built with .NET Framework 3.5 in Microsoft Visual Web Developer 2010 Express

#Quick start
-----------

1. Clone the repo onto your server and deploy to internet facing location.
2. Create a new Hub Exchange application in App Center naming what you want. 
3. For the Login URL, put the path to Login.aspx.  For the Home URL, put the path to Default.aspx.  For the Logout URL, put the path for Logout.aspx.
4. Open web.config file and update the [applicationSecret] attribute value with the Application Signature that was made available in App Center after creating a Hub Exchange application. 
5. Set up IIS/Web Server to properly host .NET web application. IIS Application pool will be .NET v2.0.
6. Test the web application locally. Since the IMH is not passing the JWT that the application requires you should get a page that simply states "Error Occurred: Object reference not set to an instance of an object." That will let you know the web server is serving the page correctly.
7. Go to https://imh.exacttarget.com and login to your ExactTarget account. Your application created in App Center should be in the IMH menu. Select it and accept any mixed security warnings if you receive them.

For more information about setting up an application in App Center, please see http://code.exacttarget.com/devcenter/????