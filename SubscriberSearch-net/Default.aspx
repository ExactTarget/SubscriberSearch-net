<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SubscriberSearch_net.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head id="Head1" runat="server">
    <title>SubscriberSearch-net: Default</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Label ID="lblMessage" runat="server" Text="" Visible="false"></asp:Label>
        <strong>Encoded JWT</strong><br />
        <asp:Label ID="lblEncodedJWT" runat="server" Text=""></asp:Label>
        <br /><br />
        <strong>Decoded JWT</strong><br />
        <asp:Label ID="lblDecodedJWT" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
