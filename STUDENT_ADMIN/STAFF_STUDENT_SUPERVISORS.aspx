<!--ASPX page @1-3AA142DD-->
    <%@ Page language="vb" CodeFile="STAFF_STUDENT_SUPERVISORS.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.STAFF_STUDENT_SUPERVISORS.STAFF_STUDENT_SUPERVISORSPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.STAFF_STUDENT_SUPERVISORS" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>STAFF_STUDENT_SUPERVISORS</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_STAFF_STUDENT_SUPERVISORS1_Button_Delete_OnClick @43-792DAB00
function page_STAFF_STUDENT_SUPERVISORS1_Button_Delete_OnClick()
{
    var result;
//End page_STAFF_STUDENT_SUPERVISORS1_Button_Delete_OnClick

//Confirmation Message @44-8243B274
    return confirm('Delete record?');
//End Confirmation Message

//Close page_STAFF_STUDENT_SUPERVISORS1_Button_Delete_OnClick @43-BC33A33A
    return result;
}
//End Close page_STAFF_STUDENT_SUPERVISORS1_Button_Delete_OnClick

//page_STAFF_STUDENT_SUPERVISORS1_Button_Cancel_OnClick @45-3E6E2335
function page_STAFF_STUDENT_SUPERVISORS1_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STAFF_STUDENT_SUPERVISORS1_Button_Cancel_OnClick

//bind_events @1-EF265882
function bind_events() {
    addEventHandler("STAFF_STUDENT_SUPERVISORS1Button_Delete","click",page_STAFF_STUDENT_SUPERVISORS1_Button_Delete_OnClick);
    addEventHandler("STAFF_STUDENT_SUPERVISORS1Button_Cancel","click",page_STAFF_STUDENT_SUPERVISORS1_Button_Cancel_OnClick);
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
<p>

  <span id="STAFF_STUDENT_SUPERVISORSSearchHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Search Supervisors</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STAFF_STUDENT_SUPERVISORSSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="STAFF_STUDENT_SUPERVISORSSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Keyword</th>
 
            <td><asp:TextBox id="STAFF_STUDENT_SUPERVISORSSearchs_keyword" maxlength="30" Columns="30"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td><a id="STAFF_STUDENT_SUPERVISORSSearchClearParameters" href="" runat="server"  >Clear</a></td> 
            <td align="right">
              <input id='STAFF_STUDENT_SUPERVISORSSearchButton_DoSearch' class="Button" type="submit" value="Search" OnServerClick='STAFF_STUDENT_SUPERVISORSSearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  </p>
<p align="right"><a id="STAFF_STUDENT_SUPERVISORS_Insert" href="" class="Button" runat="server"  >Add New</a><br>
</p>
<p>

<asp:repeater id="STAFF_STUDENT_SUPERVISORSRepeater" OnItemCommand="STAFF_STUDENT_SUPERVISORSItemCommand" OnItemDataBound="STAFF_STUDENT_SUPERVISORSItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>List of Student&nbsp;Supervisors </th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="8">Total Records:&nbsp;<asp:Literal id="STAFF_STUDENT_SUPERVISORSSTAFF_STUDENT_SUPERVISORS_TotalRecords" runat="server"/></td>
        </tr>
 
        <tr class="Caption">
          <th>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_YEAR_LEVELSorter" field="Sorter_YEAR_LEVEL" OwnerState="<%# STAFF_STUDENT_SUPERVISORSData.SortField.ToString()%>" OwnerDir="<%# STAFF_STUDENT_SUPERVISORSData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_YEAR_LEVELSort" runat="server">YEAR LEVEL</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SUPERVISOR_NAMESorter" field="Sorter_SUPERVISOR_NAME" OwnerState="<%# STAFF_STUDENT_SUPERVISORSData.SortField.ToString()%>" OwnerDir="<%# STAFF_STUDENT_SUPERVISORSData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUPERVISOR_NAMESort" runat="server">SUPERVISOR NAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SUPERVISOR_EMAILSorter" field="Sorter_SUPERVISOR_EMAIL" OwnerState="<%# STAFF_STUDENT_SUPERVISORSData.SortField.ToString()%>" OwnerDir="<%# STAFF_STUDENT_SUPERVISORSData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUPERVISOR_EMAILSort" runat="server">SUPERVISOR EMAIL</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SUPERVISOR_PHONESorter" field="Sorter_SUPERVISOR_PHONE" OwnerState="<%# STAFF_STUDENT_SUPERVISORSData.SortField.ToString()%>" OwnerDir="<%# STAFF_STUDENT_SUPERVISORSData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUPERVISOR_PHONESort" runat="server">SUPERVISOR PHONE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_STATUSSorter" field="Sorter_STATUS" OwnerState="<%# STAFF_STUDENT_SUPERVISORSData.SortField.ToString()%>" OwnerDir="<%# STAFF_STUDENT_SUPERVISORSData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STATUSSort" runat="server">STATUS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# STAFF_STUDENT_SUPERVISORSData.SortField.ToString()%>" OwnerDir="<%# STAFF_STUDENT_SUPERVISORSData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# STAFF_STUDENT_SUPERVISORSData.SortField.ToString()%>" OwnerDir="<%# STAFF_STUDENT_SUPERVISORSData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="STAFF_STUDENT_SUPERVISORSDetail" href="" runat="server"  >edit</a></td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="STAFF_STUDENT_SUPERVISORSYEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_STUDENT_SUPERVISORSItem)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFF_STUDENT_SUPERVISORSSUPERVISOR_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_STUDENT_SUPERVISORSItem)).SUPERVISOR_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFF_STUDENT_SUPERVISORSSUPERVISOR_EMAIL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_STUDENT_SUPERVISORSItem)).SUPERVISOR_EMAIL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFF_STUDENT_SUPERVISORSSUPERVISOR_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_STUDENT_SUPERVISORSItem)).SUPERVISOR_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="STAFF_STUDENT_SUPERVISORSSTATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_STUDENT_SUPERVISORSItem)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFF_STUDENT_SUPERVISORSLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_STUDENT_SUPERVISORSItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFF_STUDENT_SUPERVISORSLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_STUDENT_SUPERVISORSItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="8">No Staff Supervisors found - click 'Add New'</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="8"><a id="STAFF_STUDENT_SUPERVISORSSTAFF_STUDENT_SUPERVISORS_Insert" href="" class="Button" runat="server"  >Add New</a>&nbsp; 
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STAFF_STUDENT_SUPERVISORSData.PagesCount%>" PageSize="<%# STAFF_STUDENT_SUPERVISORSData.RecordsPerPage%>" PageNumber="<%# STAFF_STUDENT_SUPERVISORSData.PageNumber%>" runat="server">
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

  </FooterTemplate>
</asp:repeater>
</p>
<p><br>
</p>
<p>

  <span id="STAFF_STUDENT_SUPERVISORS1Holder" runat="server">
    


  <table cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Add/Edit&nbsp;Student Supervisors </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STAFF_STUDENT_SUPERVISORS1Error" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="STAFF_STUDENT_SUPERVISORS1ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th colspan="2"><em>&nbsp;NOTE: The Name, Email, and Phone will appear on reports and letters to Students</em>&nbsp;</th>
          </tr>
 
          <tr class="Controls">
            <th>YEAR LEVEL</th>
 
            <td>
              <select id="STAFF_STUDENT_SUPERVISORS1YEAR_LEVEL"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>SUPERVISOR NAME</th>
 
            <td><asp:TextBox id="STAFF_STUDENT_SUPERVISORS1SUPERVISOR_NAME" maxlength="30" Columns="30"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>SUPERVISOR EMAIL</th>
 
            <td><asp:TextBox id="STAFF_STUDENT_SUPERVISORS1SUPERVISOR_EMAIL" maxlength="50" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>SUPERVISOR PHONE</th>
 
            <td><asp:TextBox id="STAFF_STUDENT_SUPERVISORS1SUPERVISOR_PHONE" maxlength="20" Columns="20"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>STATUS</th>
 
            <td>
              <asp:RadioButtonList id="STAFF_STUDENT_SUPERVISORS1STATUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE</th>
 
            <td><asp:Literal id="STAFF_STUDENT_SUPERVISORS1LAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STAFF_STUDENT_SUPERVISORS1LAST_ALTERED_DATE" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='STAFF_STUDENT_SUPERVISORS1Button_Insert' class="Button" type="submit" value="Add" OnServerClick='STAFF_STUDENT_SUPERVISORS1_Insert' runat="server"/>
              <input id='STAFF_STUDENT_SUPERVISORS1Button_Update' class="Button" type="submit" value="Save" OnServerClick='STAFF_STUDENT_SUPERVISORS1_Update' runat="server"/>
              <input id='STAFF_STUDENT_SUPERVISORS1Button_Delete' class="Button" type="submit" value="Delete" OnServerClick='STAFF_STUDENT_SUPERVISORS1_Delete' runat="server"/>
              <input id='STAFF_STUDENT_SUPERVISORS1Button_Cancel' class="Button" type="submit" value="Cancel" OnServerClick='STAFF_STUDENT_SUPERVISORS1_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="STAFF_STUDENT_SUPERVISORS1Hidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STAFF_STUDENT_SUPERVISORS1Hidden_LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  </p>
<p><br>
</p>
<p><DECV_PROD2007:Footer id="Footer" runat="server"/></p>

</form>
</body>
</html>

<!--End ASPX page-->

