<!--ASPX page @1-7CD45FB7-->
    <%@ Control language="vb" CodeFile="Menu_Student_maintain.ascx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Menu_Student_maintain.Menu_Student_maintainPage" %>
	
	<%@ Import namespace="DECV_PROD2007.Menu_Student_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>





<link rel="stylesheet" type="text/css" href="<CC:AttributeBinder runat='server' Name='pathToRoot' ContainerId='pageAttribute'/>js/css/jquery.notifyBar.css">
<script language="JavaScript" src='<%=CType(Page,CCPage).ControlAttributes.GetAttribute("pageAttribute","pathToRoot") + "js/jquery_min.js"%>' type="text/javascript" charset="utf-8"></script>
<script language="JavaScript" src='<%=CType(Page,CCPage).ControlAttributes.GetAttribute("pageAttribute","pathToRoot") + "js/jquery.notifyBar.js"%>' type="text/javascript" charset="utf-8"></script>
<style type="text/css">
<!--
#menu_maintain a.StrongBold  {font-weight: bold; PADDING: 5px 8px 5px 8px;}
#menu_maintain a.StrongSad  {PADDING: 5px 8px 5px 8px;}
#menu_maintain {display: block}
A:HOVER  { background-color: #D0D0D0; }
-->
</style>

	<asp:PlaceHolder id="Panel1" Visible="true" runat="server">
	
<div align="center">




<a id="LinkMenu" href="" class="Button" style="PADDING: 6px 8px 6px 8px;" title="go to Main Menu" runat="server"  >Back to Main Menu</a>&nbsp;&nbsp;&nbsp; <a id="Link1" href="" class="Button" style="PADDING: 6px 8px 6px 8px;" runat="server"  >Back to Summary</a> 
</div>
<br>
<div id="menu_maintain" align="center">
  Maintain: <a id="Link2" href="" class="Button StrongBold" runat="server"  >Enrolment (All)</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id="Link6" href="" class="Button StrongBold" runat="server"  >Address</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id="Link11" href="" class="Button StrongBold" runat="server"  >Carer</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id="Link12" href="" class="Button StrongBold" runat="server"  >Family Group</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id="Link3" href="" class="Button StrongSad" runat="server"  >Census</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id="Link4" href="" class="Button StrongSad" runat="server"  >Equipment</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id="Link5" href="" class="Button StrongSad" runat="server"  >Medical</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id="Link7" href="" class="Button StrongBold" runat="server"  >Subjects</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id="Link8" href="" class="Button StrongBold" runat="server"  >VSV Financials</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id="Link10" href="" class="Button StrongSad" runat="server"  >SMS</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id="Link9" href="" class="Button StrongBold" runat="server"  >Comments</a>&nbsp; 
</div>
<br>

	</asp:PlaceHolder>
	
<div id="notifymessage" style="DISPLAY: none"><asp:Literal id="lblnotifymessage" runat="server"/></div>
<script language="JavaScript" type="text/javascript">
                jQuery.noConflict();
                jQuery(function () {
                var msg = jQuery('div#notifymessage').html();
                if (msg !='') {
                        jQuery.notifyBar({html: msg,cssClass:"success"});  
                }   
        });
</script>



<!--End ASPX page-->

