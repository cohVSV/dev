<!--ASPX page @1-243CB363-->
    <%@ Page language="vb" CodeFile="Subject_TeacherAllocations_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Subject_TeacherAllocations_maint.Subject_TeacherAllocations_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Subject_TeacherAllocations_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="description" content="Page to allow AP or similar to manage the Teacher Allocations from a single plage instead of checking each subject separately. The data is stored with the SUBJECT_TEACHER table for simplicity and to allow switching on/off based on ALLOCATABLE flag. (unfuddle #708)"><meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Subject Teacher Allocationsmaintain</title>



<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToNo_OnClick @120-EFA9F11D
function page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToNo_OnClick()
{
    var result;
//End page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToNo_OnClick

//Confirmation Message @122-87A028DA
    return confirm('This will reset ALL Teachers in ALL Subjects to [Allocatable] of NO?\n(you must also select 'Yes' on Confirm Reset first)');
//End Confirmation Message

//Close page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToNo_OnClick @120-BC33A33A
    return result;
}
//End Close page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToNo_OnClick

//page_SUBJECT_TEACHER_SUBJECT_S_ButtonCancel_OnClick @115-1D7100C9
function page_SUBJECT_TEACHER_SUBJECT_S_ButtonCancel_OnClick()
{
    disableValidation = true;
}
//End page_SUBJECT_TEACHER_SUBJECT_S_ButtonCancel_OnClick

//page_SUBJECT_SUBJECT_TEACHER_Button_DoSearch_OnClick @42-C422020E
function page_SUBJECT_SUBJECT_TEACHER_Button_DoSearch_OnClick()
{
    disableValidation = true;
}
//End page_SUBJECT_SUBJECT_TEACHER_Button_DoSearch_OnClick

//page_SUBJECT_TEACHER_ButtonCancel_OnClick @112-F607E9C1
function page_SUBJECT_TEACHER_ButtonCancel_OnClick()
{
    disableValidation = true;
}
//End page_SUBJECT_TEACHER_ButtonCancel_OnClick

//bind_events @1-A4AF9233
function bind_events() {
    addEventHandler("SUBJECT_SUBJECT_TEACHERButtonResetDevToNo","click",page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToNo_OnClick);
    addEventHandler("SUBJECT_TEACHER_SUBJECT_SButtonCancel","click",page_SUBJECT_TEACHER_SUBJECT_S_ButtonCancel_OnClick);
    addEventHandler("SUBJECT_SUBJECT_TEACHERButton_DoSearch","click",page_SUBJECT_SUBJECT_TEACHER_Button_DoSearch_OnClick);
    addEventHandler("SUBJECT_TEACHERButtonCancel","click",page_SUBJECT_TEACHER_ButtonCancel_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center">

  <span id="SUBJECT_SUBJECT_TEACHERHolder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Search </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="SUBJECT_SUBJECT_TEACHERError" visible="False" runat="server">
  
          <tr id="<%=PageVariables.Get("@error-block")%>" class="Error">
            <td colspan="2"><asp:Label ID="SUBJECT_SUBJECT_TEACHERErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Get Subject&nbsp;</th>
 
            <td>
              <select id="SUBJECT_SUBJECT_TEACHERs_SUBJECT_ID"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td><em>&nbsp;OR</em></td>
          </tr>
 
          <tr class="Controls">
            <th>Search for...</th>
 
            <td><asp:TextBox id="SUBJECT_SUBJECT_TEACHERs_keyword" maxlength="30" Columns="40"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th colspan="2"><em>(searches on Subject Title, Subject Abbrev, Staff Firstname, Staff Lastname, Staff login)</em></th>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;Show...</th>
 
            <td>&nbsp; 
              <asp:RadioButtonList id="SUBJECT_SUBJECT_TEACHERrbShow"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td><a id="SUBJECT_SUBJECT_TEACHERClearParameters" href="" runat="server"  >Clear</a></td> 
            <td style="TEXT-ALIGN: right">
              <input id='SUBJECT_SUBJECT_TEACHERButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='SUBJECT_SUBJECT_TEACHER_Search' runat="server"/></td>
          </tr>
        </table>
      </td> 
      <td valign="top">&nbsp;</td> 
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Bulk Changes</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          <tr class="Controls">
            <th>&nbsp;Handy for start of Semester or Year resets</th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p>Set ALL Teachers in ALL Subjects&nbsp;'Allocate'&nbsp;to NO?</p>
 
            <p>Confirm Reset:&nbsp;&nbsp; 
            <asp:RadioButtonList id="SUBJECT_SUBJECT_TEACHERrbConfirm"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></p>
            </th>
 
            <td>
              <input id='SUBJECT_SUBJECT_TEACHERButtonResetDevToNo' type="submit" class="Button" value="Reset Allocatable to NO" OnServerClick='SUBJECT_SUBJECT_TEACHER_Delete' runat="server"/></td>
          </tr>
 
          <tr class="Error">
            <td colspan="2">&nbsp;<asp:Literal id="SUBJECT_SUBJECT_TEACHERlblConfirmError" runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>
&nbsp; 

  <span id="SUBJECT_TEACHERHolder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" width="90%" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"></td> 
            <td class="th"><strong>Add Subject Teacher</strong></td> 
            <td class="HeaderRight"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="SUBJECT_TEACHERError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="4"><span id="SUBJECT_TEACHERErrorBlock"><asp:Label ID="SUBJECT_TEACHERErrorLabel" runat="server"/></span></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Caption">
            <th>Subject </th>
 
            <th>Staff</th>
 
            <th>&nbsp;Time Fraction</th>
 
            <th>&nbsp;Allocatable? </th>
          </tr>
 
          <tr class="Controls">
            <td>
              <select id="SUBJECT_TEACHERSUBJECT_ID"  runat="server"></select>
 </td> 
            <td>
              <select id="SUBJECT_TEACHERSTAFF_ID"  runat="server"></select>
 
  <input id="SUBJECT_TEACHERSCAFFOLD_COURSEDEV_UPDATED" type="hidden"  runat="server"/>
  
  <input id="SUBJECT_TEACHERSCAFFOLD_COURSEDEV_FLAG" type="hidden"  runat="server"/>
  </td> 
            <td>&nbsp;<asp:TextBox id="SUBJECT_TEACHERTIME_FRACTION" Columns="6"	runat="server"/></td> 
            <td>
              <asp:RadioButtonList id="SUBJECT_TEACHERrbAllocatable"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td style="TEXT-ALIGN: right" colspan="4">
              <input id='SUBJECT_TEACHERButtonInsert' type="submit" class="Button" value="Add Teacher" OnServerClick='SUBJECT_TEACHER_Insert' runat="server"/>&nbsp;&nbsp; 
              <input id='SUBJECT_TEACHERButtonCancel' type="submit" class="Button" value="Cancel" OnServerClick='SUBJECT_TEACHER_Cancel' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="SUBJECT_TEACHER_SUBJECT_SRepeater" OnItemCommand="SUBJECT_TEACHER_SUBJECT_SItemCommand" OnItemDataBound="SUBJECT_TEACHER_SUBJECT_SItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript" >
	var SUBJECT_TEACHER_SUBJECT_SElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initSUBJECT_TEACHER_SUBJECT_SElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
  <table class="MainTable" cellspacing="0" cellpadding="0" width="90%" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Manage Subject Teachers</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="SUBJECT_TEACHER_SUBJECT_SError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="8"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Row">
            <td colspan="8">Total Records:&nbsp;<asp:Literal id="SUBJECT_TEACHER_SUBJECT_STotalRecords" runat="server"/></td>
          </tr>
 
          <tr class="Caption">
            <th>
            <CC:Sorter id="Sorter_SUBJECT_ABBREVSorter" field="Sorter_SUBJECT_ABBREV" OwnerState="<%# SUBJECT_TEACHER_SUBJECT_SData.SortField.ToString()%>" OwnerDir="<%# SUBJECT_TEACHER_SUBJECT_SData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SUBJECT_ABBREVSort" runat="server">SUBJECT ABBREV</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_SUBJECT_TITLESorter" field="Sorter_SUBJECT_TITLE" OwnerState="<%# SUBJECT_TEACHER_SUBJECT_SData.SortField.ToString()%>" OwnerDir="<%# SUBJECT_TEACHER_SUBJECT_SData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SUBJECT_TITLESort" runat="server">SUBJECT TITLE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>Staff Name</th>
 
            <th>
            <CC:Sorter id="Sorter_SCAFFOLD_COURSEDEV_FLAGSorter" field="Sorter_SCAFFOLD_COURSEDEV_FLAG" OwnerState="<%# SUBJECT_TEACHER_SUBJECT_SData.SortField.ToString()%>" OwnerDir="<%# SUBJECT_TEACHER_SUBJECT_SData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SCAFFOLD_COURSEDEV_FLAGSort" runat="server">COURSE DEV?</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>&nbsp;Time Fraction</th>
 
            <th>Allocatable?&nbsp;</th>
 
            <th>
            <CC:Sorter id="Sorter_SCAFFOLD_COURSEDEV_UPDATEDSorter" field="Sorter_SCAFFOLD_COURSEDEV_UPDATED" OwnerState="<%# SUBJECT_TEACHER_SUBJECT_SData.SortField.ToString()%>" OwnerDir="<%# SUBJECT_TEACHER_SUBJECT_SData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SCAFFOLD_COURSEDEV_UPDATEDSort" runat="server">Allocations Updated</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>&nbsp;<font color="#c0504d">Delete!</font></th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="8"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Row">
            <td><asp:Literal id="SUBJECT_TEACHER_SUBJECT_SSUBJECT_ABBREV" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SUBJECT_ABBREV.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>
  <input id="SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_SUBJECT_ID"  value='<%# (CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SUBJECT_TEACHER_SUBJECT_ID.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
            <td><asp:Literal id="SUBJECT_TEACHER_SUBJECT_SSUBJECT_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SUBJECT_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td>
              <p><asp:Literal id="SUBJECT_TEACHER_SUBJECT_SFIRSTNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).FIRSTNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="SUBJECT_TEACHER_SUBJECT_SSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>
  <input id="SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_STAFF_ID"  value='<%# (CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SUBJECT_TEACHER_STAFF_ID.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </p>
            </td> 
            <td><asp:Literal id="SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SCAFFOLD_COURSEDEV_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>
  <input id="SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_UPDATED"  value='<%# (CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SCAFFOLD_COURSEDEV_UPDATED.GetFormattedValue() %>' type="hidden"  runat="server"/>
  
  <input id="SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_FLAG1"  value='<%# (CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SCAFFOLD_COURSEDEV_FLAG1.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
            <td>&nbsp;<asp:TextBox id="SUBJECT_TEACHER_SUBJECT_STIME_FRACTION" Text='<%# (CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).TIME_FRACTION.GetFormattedValue() %>' Columns="6"	runat="server"/></td> 
            <td>
              <asp:RadioButtonList id="SUBJECT_TEACHER_SUBJECT_SrbAllocatable"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td nowrap>&nbsp;<asp:Literal id="SUBJECT_TEACHER_SUBJECT_SlblLastUpdated" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).lblLastUpdated.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>
  <input id="SUBJECT_TEACHER_SUBJECT_SLAST_UPDATED"  value='<%# (CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).LAST_UPDATED.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
            <td nowrap>&nbsp;<asp:CheckBox id="SUBJECT_TEACHER_SUBJECT_ScheckDelete" Visible = "<%# (CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).IsDeleteAllowed %>" runat="server"/>&nbsp;Delete</td>
          </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="8">No Staff or Subjects Found!</td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Footer">
            <td style="TEXT-ALIGN: right" colspan="8">
              
<CC:Navigator id="Navigator1Navigator" MaxPage="<%# SUBJECT_TEACHER_SUBJECT_SData.PagesCount%>" PageSize="<%# SUBJECT_TEACHER_SUBJECT_SData.RecordsPerPage%>" PageNumber="<%# SUBJECT_TEACHER_SUBJECT_SData.PageNumber%>" runat="server"><span class="Navigator">Records per page 
              <CC:PageSizer AutoPostBack="true" runat="server" />
 
              <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="Navigator1First" runat="server"><img src="Styles/Blueprint/Images/First.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="FirstOff" runat="server"><img src="Styles/Blueprint/Images/FirstOff.gif"></CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="Navigator1Prev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/PrevOff.gif"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %>&nbsp;of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
              <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="Navigator1Next" runat="server"><img src="Styles/Blueprint/Images/Next.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/NextOff.gif"></CC:NavigatorItem>
              <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="Navigator1Last" runat="server"><img src="Styles/Blueprint/Images/Last.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="LastOff" runat="server"><img src="Styles/Blueprint/Images/LastOff.gif"></CC:NavigatorItem></span></CC:Navigator>
&nbsp; 
              <asp:Button id="SUBJECT_TEACHER_SUBJECT_SButtonUpdate" CssClass="Button" Text="Save Changes" CommandName="Submit" runat="server"/>&nbsp;&nbsp; 
              <asp:Button id="SUBJECT_TEACHER_SUBJECT_SButtonCancel" CssClass="Button" Text="Cancel" runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>


&nbsp;
  </FooterTemplate>
</asp:repeater>
<br>
<br>
<br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

