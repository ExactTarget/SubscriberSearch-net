<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SubscriberSearch_net.Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" class="fuelux">
<!-- Lines above specifies HTML 5 doctype and apply the fuelux class to the entire page -->
<head id="Head1" runat="server">
    <title>SubscriberSearch-net: Default</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <meta name="description" content="DotNet-C# FuelUX based App" />

    <!-- Fuel UX includes and script for the page below -->
    <!-- review code.exacttarget.com/devcenter/fuel-ux and code.exacttarget.com/devcenter/fuel-ux/getting-started -->
    <link href="http://fuelux.exacttargetapps.com/fuelux-imh/2.1/css/fuelux.css" rel="stylesheet" />
    <link href="http://fuelux.exacttargetapps.com/fuelux-imh/2.1/css/fuelux-responsive.css" rel="stylesheet" />

    <script src="datasource.js" type="text/javascript"></script> 

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js" type="text/javascript"></script>
    <script src="http://fuelux.exacttargetapps.com/fuelux-imh/2.1/loader.min.js" type="text/javascript"></script>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/underscore.js/1.3.3/underscore-min.js" type="text/javascript"></script>

    <!-- Logic for Datagrid -->
	<script  type="text/javascript">

		$(document).ready(function () {

		    var dataSource = new SubscriberSearchDataSource({
		        columns: [{
		            property: 'EmailAddress',
		            label: 'Email Address',
		            sortable: false
		        }, {
		            property: 'SubscriberKey',
		            label: 'Subscriber Key',
		            sortable: false
		        }, {
					property: 'ViewDetails',
					label: '',
					sortable: false
				}, {
					property: 'Status',
					label: 'Status',
					sortable: false
				} ],
		        delay: 250
		    });


		    $('#subscriberGrid').datagrid({
		        dataSource: dataSource,
		        renderData: true
		    });

		});	
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <br /><br /><br />
        <!-- DATAGRID MARKUP -->
	    <div id="app-nav" class="navbar navbar-inverse navbar-fixed-top">
		    <div class="navbar-inner">
			    <div class="container-fluid">
				    <a href="/" class="brand">.NET(C#) Version</a>
			    </div>
		    </div>
	    </div>
	    <div id="primary" class="container-fluid"><div class="row-fluid">
		    <div id="subscriberDetailsContainer" class="span3"><div class="well">
			    <h1>Subscriber Details</h1>
			    <p id="detailsMsg" class="text-info">Please search for subscribers, then click the "View Details" button for a subscriber from the grid.</p>
			    <div id="subscriberDetails"></div>
			    </div>
		    </div>
		    <div class="span9"><table id="subscriberGrid" class="table table-bordered datagrid" >
			    <thead>
				    <tr>
					    <th colspan="4">
						    <span class="datagrid-header-title">Subscriber Listings</span>
						    <div class="datagrid-header-left">
						    </div>
						    <div class="datagrid-header-right">
							    <div class="input-append search" id="subscriberSearch">
								    <input type="text" placeholder="Search for subscribers" class="input-medium"><button class="btn"><i class="icon-search"></i></button>
							    </div>
						    </div>
					    </th>
				    </tr>
				    <tfoot>
					    <tr>
						    <th>
							    <div class="datagrid-footer-left" style="display:none;">
								    <div class="grid-controls">
									    <span><span class="grid-start"></span> - <span class="grid-end"></span> of
									    <span class="grid-count"></span></span>
									    <select class="grid-pagesize">
										    <option>10</option>
										    <option>20</option>
										    <option>50</option>
										    <option>100</option>
									    </select>
									    <span>Per Page</span>
								    </div>
							    </div>
							    <div class="datagrid-footer-right" style="display:none;">
								    <div class="grid-pager">
									    <button class="btn grid-prevpage">
										    <i class="icon-chevron-left"></i>
									    </button>
									    <span>Page</span>
									    <div class="input-append dropdown combobox">
										    <input class="span1" type="text">
										    <button class="btn" data-toggle="dropdown">
											    <i class="caret"></i>
										    </button>
										    <ul class="dropdown-menu"></ul>
									    </div>
									    <span>of <span class="grid-pages"></span></span>
									    <button class="btn grid-nextpage">
										    <i class="icon-chevron-right"></i>
									    </button>
								    </div>
							    </div>
						    </th>
					    </tr>
				    </tfoot>
			    </table>
		    </div>
		    </div>
	    </div>	   
	    <!-- END DATAGRID MARKUP -->
        <!--<br /><asp:Label ID="lblMessage" runat="server" Text="testing123" Visible="true"></asp:Label><br />-->
    </form>
</body>
</html>
