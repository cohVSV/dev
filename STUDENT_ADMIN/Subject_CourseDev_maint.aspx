<!--ASPX page @1-ADEC8094-->
    <%@ Page language="vb" CodeFile="Subject_CourseDev_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Subject_CourseDev_maint.Subject_CourseDev_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Subject_CourseDev_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta name="description" content="Page to allow AP of similar to manage the Scaffold LMS Course developers. The data is stored with the SUBJECT_TEACHER table for simplicity and to allow switching on/off based on ALLOCATABLE flag. (unfuddle #708)"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Subject Course Developer maintain</title>



<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript" charset="utf-8" src="ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Date Picker Object Definitions @1-746EABC1

var SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1 = new Object(); 
SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1.format           = "d/m/yyyy";
SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1.style            = "Styles/Blueprint/Style.css";
SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1.relativePathPart = "";
SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1.themeVersion     = "3.0";
var SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW = new Object(); 
SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW.format           = "d/m/yyyy";
SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW.style            = "Styles/Blueprint/Style.css";
SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW.relativePathPart = "";
SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW.themeVersion     = "3.0";
var SUBJECT_TEACHERDatePicker_StartDate = new Object(); 
SUBJECT_TEACHERDatePicker_StartDate.format           = "d/m/yyyy";
SUBJECT_TEACHERDatePicker_StartDate.style            = "Styles/Blueprint/Style.css";
SUBJECT_TEACHERDatePicker_StartDate.relativePathPart = "";
SUBJECT_TEACHERDatePicker_StartDate.themeVersion     = "3.0";
var SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATE = new Object(); 
SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATE.format           = "d/m/yyyy";
SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATE.style            = "Styles/Blueprint/Style.css";
SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATE.relativePathPart = "";
SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATE.themeVersion     = "3.0";
//End Date Picker Object Definitions

//page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToNo_OnClick @120-EFA9F11D
function page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToNo_OnClick()
{
    var result;
//End page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToNo_OnClick

//Confirmation Message @122-9357718E
    return confirm('This will reset all the Course Devs to NO?');
//End Confirmation Message

//Close page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToNo_OnClick @120-BC33A33A
    return result;
}
//End Close page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToNo_OnClick

//page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToTeachers_OnClick @121-8723F6A8
function page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToTeachers_OnClick()
{
    var result;
//End page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToTeachers_OnClick

//Confirmation Message @123-F21757F4
    return confirm('Change Devs to match only active Teachers?');
//End Confirmation Message

//Close page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToTeachers_OnClick @121-BC33A33A
    return result;
}
//End Close page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToTeachers_OnClick

//page_SUBJECT_TEACHER_SUBJECT_S_ButtonCancel_OnClick @115-1D7100C9
function page_SUBJECT_TEACHER_SUBJECT_S_ButtonCancel_OnClick()
{
    disableValidation = true;
}
//End page_SUBJECT_TEACHER_SUBJECT_S_ButtonCancel_OnClick

//page_SUBJECT_TEACHER_ButtonCancel_OnClick @112-F607E9C1
function page_SUBJECT_TEACHER_ButtonCancel_OnClick()
{
    disableValidation = true;
}
//End page_SUBJECT_TEACHER_ButtonCancel_OnClick

//bind_events @1-276CB6B4
function bind_events() {
    addEventHandler("SUBJECT_SUBJECT_TEACHERButtonResetDevToTeachers","click",page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToTeachers_OnClick);
    addEventHandler("SUBJECT_SUBJECT_TEACHERButtonResetDevToNo","click",page_SUBJECT_SUBJECT_TEACHER_ButtonResetDevToNo_OnClick);
    addEventHandler("SUBJECT_TEACHER_SUBJECT_SButtonCancel","click",page_SUBJECT_TEACHER_SUBJECT_S_ButtonCancel_OnClick);
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
            <th>Set ALL Course Dev Staff to NO</th>
 
            <td>
              <input id='SUBJECT_SUBJECT_TEACHERButtonResetDevToNo' type="submit" class="Button" value="Reset Course Devs to No" OnServerClick='SUBJECT_SUBJECT_TEACHER_Delete' runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>Set Course Dev to match Subject Teachers only <br>
            <em>reset so only active Subject teachers are Course Devs</em> </th>
 
            <td>
              <input id='SUBJECT_SUBJECT_TEACHERButtonResetDevToTeachers' type="submit" class="Button" value="Set Devs match Teachers" OnServerClick='SUBJECT_SUBJECT_TEACHER_Update' runat="server"/></td>
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
            <td class="th"><strong>Add Subject Course Developer</strong></td> 
            <td class="HeaderRight"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="SUBJECT_TEACHERError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="6"><span id="SUBJECT_TEACHERErrorBlock"><asp:Label ID="SUBJECT_TEACHERErrorLabel" runat="server"/></span></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Caption">
            <th>Subject </th>
 
            <th>&nbsp;Subject Modifier</th>
 
            <th>Staff Name</th>
 
            <th>&nbsp;Course Dev Date FROM</th>
 
            <th>&nbsp;Course Dev Date TO</th>
 
            <th>Course Dev?</th>
          </tr>
 
          <tr class="Controls">
            <td>
              <select id="SUBJECT_TEACHERSUBJECT_ID"  runat="server"></select>
 </td> 
            <td><asp:TextBox id="SUBJECT_TEACHERSCAFFOLD_COURSEDEV_MODIFIER" maxlength="10" Columns="10"	runat="server"/>&nbsp;</td> 
            <td>
              <select id="SUBJECT_TEACHERSTAFF_ID"  runat="server"></select>
 
  <input id="SUBJECT_TEACHERSCAFFOLD_COURSEDEV_UPDATED" type="hidden"  runat="server"/>
  
  <input id="SUBJECT_TEACHERSCAFFOLD_COURSEDEV_FLAG" type="hidden"  runat="server"/>
  </td> 
            <td><asp:TextBox id="SUBJECT_TEACHERSCAFFOLD_COURSEDEV_STARTDATE" Columns="12"	runat="server"/>
              <asp:PlaceHolder id="SUBJECT_TEACHERDatePicker_StartDate" runat="server"><a href="javascript:showDatePicker('<%#SUBJECT_TEACHERDatePicker_StartDateName%>','forms[\''+theForm.id+'\']','<%#SUBJECT_TEACHERDatePicker_StartDateDateControl%>');" id="SUBJECT_TEACHERDatePicker_StartDate_Link"  ><img id="SUBJECT_TEACHERDatePicker_StartDate_Image" border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  &nbsp;</td> 
            <td>&nbsp;<asp:TextBox id="SUBJECT_TEACHERSCAFFOLD_COURSEDEV_ENDDATE" Columns="12"	runat="server"/>
              <asp:PlaceHolder id="SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATE" runat="server"><a href="javascript:showDatePicker('<%#SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATEName%>','forms[\''+theForm.id+'\']','<%#SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATEDateControl%>');" id="SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATE_Link"  ><img id="SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATE_Image" border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  <a href='<%#"javascript:showDatePicker('" + PageVariables.Get("Name") + "','" + PageVariables.Get("FormName") + "','" + PageVariables.Get("DateControl") + "');"%>' id="SUBJECT_TEACHERDatePicker_EndDate"></a></td> 
            <td>Yes</td>
          </tr>
 
          <tr class="Bottom">
            <td style="TEXT-ALIGN: right" colspan="6">
              <input id='SUBJECT_TEACHERButtonInsert' type="submit" class="Button" value="Add Course Developer" OnServerClick='SUBJECT_TEACHER_Insert' runat="server"/>&nbsp;&nbsp; 
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
            <th>Manage Course Developer Staff</th>
 
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
 
            <th>Scaffold Modifier&nbsp;</th>
 
            <th>Staff Name</th>
 
            <th>Date From&nbsp;</th>
 
            <th>Date To&nbsp;</th>
 
            <th>
            <CC:Sorter id="Sorter_SCAFFOLD_COURSEDEV_FLAGSorter" field="Sorter_SCAFFOLD_COURSEDEV_FLAG" OwnerState="<%# SUBJECT_TEACHER_SUBJECT_SData.SortField.ToString()%>" OwnerDir="<%# SUBJECT_TEACHER_SUBJECT_SData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SCAFFOLD_COURSEDEV_FLAGSort" runat="server">COURSE DEV?</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_SCAFFOLD_COURSEDEV_UPDATEDSorter" field="Sorter_SCAFFOLD_COURSEDEV_UPDATED" OwnerState="<%# SUBJECT_TEACHER_SUBJECT_SData.SortField.ToString()%>" OwnerDir="<%# SUBJECT_TEACHER_SUBJECT_SData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SCAFFOLD_COURSEDEV_UPDATEDSort" runat="server">Course Dev Updated</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
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
            <td>&nbsp;<asp:TextBox id="SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_MODIFIER" Text='<%# (CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SCAFFOLD_COURSEDEV_MODIFIER.GetFormattedValue() %>' Columns="10"	runat="server"/></td> 
            <td>
              <p><asp:Literal id="SUBJECT_TEACHER_SUBJECT_SFIRSTNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).FIRSTNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="SUBJECT_TEACHER_SUBJECT_SSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>
  <input id="SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_STAFF_ID"  value='<%# (CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SUBJECT_TEACHER_STAFF_ID.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </p>
            </td> 
            <td nowrap>&nbsp; 
              <asp:TextBox id="SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_STARTDATE" Text='<%# (CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SCAFFOLD_COURSEDEV_STARTDATE.GetFormattedValue() %>' Columns="12"	runat="server"/>
              <asp:PlaceHolder id="SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1" runat="server"><a href="javascript:showDatePicker('<%#SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1Name%>','forms[\''+theForm.id+'\']','<%#SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1DateControl%>');" id="SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1_Link"  ><img id="SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1_Image" border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  </td> 
            <td nowrap>&nbsp; 
              <asp:TextBox id="SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_ENDDATE" Text='<%# (CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SCAFFOLD_COURSEDEV_ENDDATE.GetFormattedValue() %>' Columns="12"	runat="server"/>
              <asp:PlaceHolder id="SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW" runat="server"><a href="javascript:showDatePicker('<%#SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATWName%>','forms[\''+theForm.id+'\']','<%#SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATWDateControl%>');" id="SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW_Link"  ><img id="SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW_Image" border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  </td> 
            <td>
              <asp:RadioButtonList id="SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td nowrap>&nbsp;<asp:Literal id="SUBJECT_TEACHER_SUBJECT_SlblScaffoldLastUpdated" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).lblScaffoldLastUpdated.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>
  <input id="SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_UPDATED"  value='<%# (CType(Container.DataItem,SUBJECT_TEACHER_SUBJECT_SItem)).SCAFFOLD_COURSEDEV_UPDATED.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td>
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
</p>

</form>
</body>
</html>

<!--End ASPX page-->

