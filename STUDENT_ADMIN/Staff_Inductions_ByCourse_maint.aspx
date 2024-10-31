<!--ASPX page @1-85736426-->
    <%@ Page language="vb" CodeFile="Staff_Inductions_ByCourse_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Staff_Inductions_ByCourse_maint.Staff_Inductions_ByCourse_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Staff_Inductions_ByCourse_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Staff Inductions - By Course Maintain</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_STAFF_INDUCTIONS_COURSES_Button_Delete_OnClick @6-81F0A513
function page_STAFF_INDUCTIONS_COURSES_Button_Delete_OnClick()
{
    var result;
//End page_STAFF_INDUCTIONS_COURSES_Button_Delete_OnClick

//Confirmation Message @7-8243B274
    return confirm('Delete record?');
//End Confirmation Message

//Close page_STAFF_INDUCTIONS_COURSES_Button_Delete_OnClick @6-BC33A33A
    return result;
}
//End Close page_STAFF_INDUCTIONS_COURSES_Button_Delete_OnClick

//page_STAFF_INDUCTIONS_COURSES_Button_Cancel_OnClick @8-2F488419
function page_STAFF_INDUCTIONS_COURSES_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STAFF_INDUCTIONS_COURSES_Button_Cancel_OnClick

//bind_events @1-6611DF62
function bind_events() {
    addEventHandler("STAFF_INDUCTIONS_COURSESButton_Delete","click",page_STAFF_INDUCTIONS_COURSES_Button_Delete_OnClick);
    addEventHandler("STAFF_INDUCTIONS_COURSESButton_Cancel","click",page_STAFF_INDUCTIONS_COURSES_Button_Cancel_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p><a id="link_backtolist" href="" class="Button noprint" runat="server"  >back to list</a> 

  <span id="STAFF_INDUCTIONS_COURSESHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Add/Edit Staff Induction Course</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STAFF_INDUCTIONS_COURSESError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="STAFF_INDUCTIONS_COURSESErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>INDUCTION TITLE</th>
 
            <td><asp:TextBox id="STAFF_INDUCTIONS_COURSESINDUCTION_TITLE" maxlength="50" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>INDUCTION DESCRIPTION</th>
 
            <td>
<asp:TextBox id="STAFF_INDUCTIONS_COURSESINDUCTION_DESCRIPTION" rows="3" Columns="50" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>STATUS</th>
 
            <td>
              <asp:RadioButtonList id="STAFF_INDUCTIONS_COURSESSTATUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE</th>
 
            <td><asp:Literal id="STAFF_INDUCTIONS_COURSESLAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STAFF_INDUCTIONS_COURSESLAST_ALTERED_DATE" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='STAFF_INDUCTIONS_COURSESButton_Insert' class="Button" type="submit" value="Add" OnServerClick='STAFF_INDUCTIONS_COURSES_Insert' runat="server"/>
              <input id='STAFF_INDUCTIONS_COURSESButton_Update' class="Button" type="submit" value="Save" OnServerClick='STAFF_INDUCTIONS_COURSES_Update' runat="server"/>
              <input id='STAFF_INDUCTIONS_COURSESButton_Delete' class="Button" type="submit" value="Delete" OnServerClick='STAFF_INDUCTIONS_COURSES_Delete' runat="server"/>
              <input id='STAFF_INDUCTIONS_COURSESButton_Cancel' class="Button" type="submit" value="Cancel" OnServerClick='STAFF_INDUCTIONS_COURSES_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="STAFF_INDUCTIONS_COURSEShidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STAFF_INDUCTIONS_COURSEShidden_LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="STAFF_INDUCTIONS_COURSES1Repeater" OnItemCommand="STAFF_INDUCTIONS_COURSES1ItemCommand" OnItemDataBound="STAFF_INDUCTIONS_COURSES1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<p align="right">&nbsp;</p>
<p>
<table cellspacing="0" cellpadding="0" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>List of Staff with this Course</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          
	<asp:PlaceHolder id="STAFF_INDUCTIONS_COURSES1Panel_header_editbutton" Visible="true" runat="server">
	
          <th></th>
 
	</asp:PlaceHolder>
	
          <th>
          <CC:Sorter id="Sorter_staffnameSorter" field="Sorter_staffname" OwnerState="<%# STAFF_INDUCTIONS_COURSES1Data.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSES1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_staffnameSort" runat="server">Staff Name</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_STAFF_INDUCTIONS_PROGRESS_STATUSSorter" field="Sorter_STAFF_INDUCTIONS_PROGRESS_STATUS" OwnerState="<%# STAFF_INDUCTIONS_COURSES1Data.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSES1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STAFF_INDUCTIONS_PROGRESS_STATUSSort" runat="server">Status</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_DATE_COMPLETEDSorter" field="Sorter_DATE_COMPLETED" OwnerState="<%# STAFF_INDUCTIONS_COURSES1Data.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSES1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_DATE_COMPLETEDSort" runat="server">Date Completed</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_INDUCTION_TITLESorter" field="Sorter_INDUCTION_TITLE" OwnerState="<%# STAFF_INDUCTIONS_COURSES1Data.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSES1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_INDUCTION_TITLESort" runat="server">Induction Title</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          
	<asp:PlaceHolder id="STAFF_INDUCTIONS_COURSES1Panel_data_editbutton" Visible="false" runat="server">
	
          <td><a id="STAFF_INDUCTIONS_COURSES1Link1" href="" runat="server"  >show</a>&nbsp;</td> 
	</asp:PlaceHolder>
	
          <td><asp:Literal id="STAFF_INDUCTIONS_COURSES1staffname" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSES1Item)).staffname.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFF_INDUCTIONS_COURSES1STAFF_INDUCTIONS_PROGRESS_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSES1Item)).STAFF_INDUCTIONS_PROGRESS_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFF_INDUCTIONS_COURSES1DATE_COMPLETED" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSES1Item)).DATE_COMPLETED.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFF_INDUCTIONS_COURSES1INDUCTION_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSES1Item)).INDUCTION_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="5">No Staff Inductions found</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="5">&nbsp; 
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STAFF_INDUCTIONS_COURSES1Data.PagesCount%>" PageSize="<%# STAFF_INDUCTIONS_COURSES1Data.RecordsPerPage%>" PageNumber="<%# STAFF_INDUCTIONS_COURSES1Data.PageNumber%>" runat="server">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src="Styles/Blueprint/Images/First.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server"><img src="Styles/Blueprint/Images/FirstOff.gif" border="0"></CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/PrevOff.gif" border="0"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src="Styles/Blueprint/Images/Next.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/NextOff.gif" border="0"></CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src="Styles/Blueprint/Images/Last.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server"><img src="Styles/Blueprint/Images/LastOff.gif" border="0"></CC:NavigatorItem></CC:Navigator>
&nbsp;</td>
        </tr>
      </table>
    </td>
  </tr>
</table>
&nbsp;&nbsp;</p>

  </FooterTemplate>
</asp:repeater>

<p></p>
<p></p>

</form>
</body>
</html>

<!--End ASPX page-->

