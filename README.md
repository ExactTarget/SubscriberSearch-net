#[SubscriberSearch-net]
=================

SubscriberSearch-net is an example application which illustrates how to create a Hub Exchange application utilizing Single Sign-on (SSO) for ExactTarget's Interactive Marketing Hub using .NET/C#.


#Requirements
----------
* Access to App Center on http://code.exacttarget.com
* Built with .NET Framework 3.5


#Quick start
-----------

1. Clone the repo onto your server and deploy internet facing.
2. Create a new Hub Exchange application in App Center
3. For the Login URL, put the path to Login.aspx.  For the Home URL, put the path to Default.aspx.  For the Logout URL, put the path for Logout.aspx.
4. Open web.config file and update the Application Secret attribute value with the Application Signature that was made available in App Center after creating a Hub Exchange application. 

For more information about setting up an application in App Center, please see http://code.exacttarget.com/devcenter/????