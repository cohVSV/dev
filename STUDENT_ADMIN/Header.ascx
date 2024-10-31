<!--ASPX page @1-157D88A9-->
    <%@ Control language="vb" CodeFile="Header.ascx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Header.HeaderPage" %>
	
	<%@ Import namespace="DECV_PROD2007.Header" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>




<link rel="stylesheet" type="text/css" href="<CC:AttributeBinder runat='server' Name='pathToRoot' ContainerId='pageAttribute'/>Styles/Blueprint/Style.css">

<link rel="stylesheet" type="text/css" href="<CC:AttributeBinder runat='server' Name='pathToRoot' ContainerId='pageAttribute'/>js/css/jquery.notifyBar.css">
<p align="center"><strong>



<a id="LinkMenu" href="" title="go to Main Menu" runat="server"  >Back to Main Menu</a></strong>&nbsp;&nbsp;<img id="ImageLogo" border="0" name="ImageLogo" alt="VSV Logo" src='<%=CType(Page,CCPage).ControlAttributes.GetAttribute("pageAttribute","pathToRoot") + "images/logosm.gif"%>'>&nbsp;<font color="#ff0000">STAGING</font>&nbsp;<strong></strong></p>
<div style="RIGHT: 4px; POSITION: absolute; TOP: 4px">
<asp:HyperLink id="ImageLink2"  ToolTip="open Reports" target="_blank" style="BORDER-LEFT-WIDTH: 0px; BORDER-RIGHT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-TOP-WIDTH: 0px" Text="open Reports" ImageUrl='images/SQLRS_Report.gif' runat="server"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink id="ImageLink1"  style="BORDER-LEFT-WIDTH: 0px; BORDER-RIGHT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-TOP-WIDTH: 0px" Text="email PC Support about the Database" ImageUrl='images/emailsm.gif' runat="server"/> 
</div>
<div id="notifymessage" style="DISPLAY: none"><asp:Literal id="lblnotifymessage" runat="server"/></div>
<script language="JavaScript" src='<%=CType(Page,CCPage).ControlAttributes.GetAttribute("pageAttribute","pathToRoot") + "js/jquery_min.js"%>' type="text/javascript" charset="utf-8"></script>
<script language="JavaScript" src='<%=CType(Page,CCPage).ControlAttributes.GetAttribute("pageAttribute","pathToRoot") + "js/jquery.notifyBar.js"%>' type="text/javascript" charset="utf-8"></script>
<script language="JavaScript" type="text/javascript">jQuery.noConflict();jQuery(function () {
        var msg = jQuery('div#notifymessage').html();
        if (msg !='') {
        jQuery.notifyBar({html: msg,cssClass:"success",closeOnClick:false});  
        }   });</script>



<!--End ASPX page-->

