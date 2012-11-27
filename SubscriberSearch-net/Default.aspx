<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SubscriberSearch_net.Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" class="fuelux">
<!-- Lines above specifies HTML 5 doctype and apply the fuelux class to the entire page -->
<head id="Head1" runat="server">
    <title>SubscriberSearch-net: Default</title>
    <!-- Fuel UX includes and script for the page below -->
    <!-- review code.exacttarget.com/devcenter/fuel-ux and code.exacttarget.com/devcenter/fuel-ux/getting-started -->
    <link href="http://fuelux.exacttargetapps.com/fuelux-imh/2.1/css/fuelux.css" rel="stylesheet" />
    <link href="http://fuelux.exacttargetapps.com/fuelux-imh/2.1/css/fuelux-responsive.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://fuelux.exacttargetapps.com/fuelux-imh/2.1/loader.min.js" type="text/javascript"></script>
    <script  type="text/javascript">

        $(function () {
            // code in this callback
            // function guaranteed to
            // run after dom is ready
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMessage" runat="server" Text="" Visible="false"></asp:Label>
        <table id="MyGrid" class="table table-bordered datagrid">
 <thead>
 <tr>
  <th>
   <span class="datagrid-header-title">Subscriber Listings</span>
   <div class="datagrid-header-left">
 
   </div>
   <div class="datagrid-header-right">
	<div class="input-append search">
	 <input type="text" class="input-medium" placeholder="Search"><button class="btn"><i class="icon-search"></i></button>
	</div>
   </div>
  </th>
 </tr>
 </thead>
 
 <tfoot>
 <tr>
  <th>
   <div class="datagrid-footer-left" style="display:none;">
	<div class="grid-controls">
	 <span><span class="grid-start"></span> - <span class="grid-end"></span> of <span class="grid-count"></span></span>
	 <select class="grid-pagesize"><option>10</option><option>20</option><option>50</option><option>100</option></select>
	 <span>Per Page</span>
	</div>
   </div>
   <div class="datagrid-footer-right" style="display:none;">
	<div class="grid-pager">
	 <button class="btn grid-prevpage"><i class="icon-chevron-left"></i></button>
	 <span>Page</span>
	 <div class="input-append dropdown combobox">
	  <input class="span1" type="text"><button class="btn" data-toggle="dropdown"><i class="caret"></i></button>
	  <ul class="dropdown-menu"></ul>
	 </div>
	 <span>of <span class="grid-pages"></span></span>
	 <button class="btn grid-nextpage"><i class="icon-chevron-right"></i></button>
	</div>
   </div>
  </th>
 </tr>
 </tfoot>
</table>
        <!-- Step 1 Output 
        <strong>Encoded JWT</strong><br />
        <asp:Label ID="lblEncodedJWT" runat="server" Text=""></asp:Label>
        <br /><br />
        <strong>Decoded JWT</strong><br />
        <asp:Label ID="lblDecodedJWT" runat="server" Text=""></asp:Label> -->
    </div>
    </form>
</body>
</html>
