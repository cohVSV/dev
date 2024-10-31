<!--ASPX page @1-BBA76603-->
    <%@ Page language="vb" CodeFile="StudentEnrolment_AddSubjects.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentEnrolment_AddSubjects.StudentEnrolment_AddSubjectsPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentEnrolment_AddSubjects" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>StudentEnrolment_AddSubjects</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//DEL  </script>
//DEL  <script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
//DEL  <script language="JavaScript" type="text/javascript">
//DEL    

//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_button_PopupSubjectList_OnClick @22-59DB2511
function page_button_PopupSubjectList_OnClick()
{
    var result;
//End page_button_PopupSubjectList_OnClick

//Custom Code @23-2A29BDB7
    // -------------------------
    // ERA: same OpenPopupList code
    var FieldName;
    FieldName = "AddNewSubjects_SUBJECT_ID";        // return field name
        var YearLevel
        YearLevel = document.getElementById('AddNewSubjecthidden_ENROLMENT_YEAR');
    var win=window.open("popup_SubjectList.aspx?returncontrol="+FieldName+"&s_YEAR_LEVEL="+YearLevel, "SubjectList", "left=40,top=10,width=380,height=480,status=no,toolbar=no,menubar=no,location=no,scrollbars=yes");
    win.focus();
    // -------------------------
//End Custom Code

//Close page_button_PopupSubjectList_OnClick @22-BC33A33A
    return result;
}
//End Close page_button_PopupSubjectList_OnClick

//page_AddNewSubject_Button_DoDelete_OnClick @35-0565413E
function page_AddNewSubject_Button_DoDelete_OnClick()
{
    var result;
//End page_AddNewSubject_Button_DoDelete_OnClick

//Confirmation Message @36-BCCE3417
    return confirm('Are you SURE you want to DELETE the selected Subjects from this Student?');
//End Confirmation Message

//Close page_AddNewSubject_Button_DoDelete_OnClick @35-BC33A33A
    return result;
}
//End Close page_AddNewSubject_Button_DoDelete_OnClick

//bind_events @1-50645147
function bind_events() {
    addEventHandler("AddNewSubjectButton_DoDelete","click",page_AddNewSubject_Button_DoDelete_OnClick);
    addEventHandler("button_PopupSubjectList","click",page_button_PopupSubjectList_OnClick);
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


<p align="center"><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center">
<asp:Button id="button_PopupSubjectList" CssClass="Button" Text="Select via Popup List" OnClick="button_PopupSubjectList_OnClick" runat="server"/></p>
<p>

<asp:repeater id="SubjectListRepeater" OnItemCommand="SubjectListItemCommand" OnItemDataBound="SubjectListItemDataBound" runat="server">
  <HeaderTemplate>
	
<table style="WIDTH: 90%" cellspacing="0" cellpadding="0" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>List of New Student's Subjects</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Bottom">
          <td><strong>&nbsp;STUDENT ID</strong></td> 
          <td>
            <p align="left">&nbsp;<asp:Literal id="SubjectListlbldisplay_STUDENTID" runat="server"/></p>
          </td> 
          <td><strong>ENROLMENT YEAR</strong></td> 
          <td>
            <p align="left">&nbsp;<asp:Literal id="SubjectListlbldisplay_ENROL_YEAR" runat="server"/></p>
          </td> 
          <td><strong>YEAR LEVEL</strong></td> 
          <td>
            <p align="left">&nbsp;<asp:Literal id="SubjectListlbldisplay_YEARLEVEL" runat="server"/></p>
          </td>
        </tr>
 
        <tr class="Caption">
          <th>SUBJECT ID</th>
 
          <th>SUBJECT TITLE</th>
 
          <th>COURSE DISTRIBUTION</th>
 
          <th>SEMESTER</th>
 
          <th>ENROLMENT DATE&nbsp;</th>
 
          <th>&nbsp;DELETE</th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><asp:Literal id="SubjectListSUBJECT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SubjectListItem)).SUBJECT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="SubjectListSUBJECT_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SubjectListItem)).SUBJECT_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="SubjectListCOURSE_DISTRIBUTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SubjectListItem)).COURSE_DISTRIBUTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="SubjectListSEMESTER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SubjectListItem)).SEMESTER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>&nbsp;<asp:Literal id="SubjectListENROL_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SubjectListItem)).ENROL_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>
            <p align="center">&nbsp;<asp:CheckBox id="SubjectListcbox" runat="server"/></p>
          </td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
  </asp:PlaceHolder>

      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>

  <span id="AddNewSubjectHolder" runat="server">
    


  <table style="WIDTH: 90%" cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Add New Subject</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="AddNewSubjectError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="6"><asp:Label ID="AddNewSubjectErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Caption">
            <th>SUBJECT ID</th>
 
            <th>SUBJECT TITLE</th>
 
            <th>COURSE DISTRIBUTION</th>
 
            <th>SEMESTER</th>
 
            <th>&nbsp;ENROLMENT DATE&nbsp;</th>
 
            <th>&nbsp;</th>
          </tr>
 
          <tr class="Controls">
            <td><asp:TextBox id="AddNewSubjects_SUBJECT_ID" maxlength="8" Columns="6"	runat="server"/></td> 
            <td><asp:Literal id="AddNewSubjectlbladdSUBJECT_TITLE" runat="server"/>&nbsp;</td> 
            <td>&nbsp; 
              <select id="AddNewSubjectaddCOURSE_DISTRIBUTION"  runat="server"></select>
 </td> 
            <td>&nbsp; 
              <select id="AddNewSubjectaddSEMESTER"  runat="server"></select>
 </td> 
            <td>&nbsp;<asp:TextBox id="AddNewSubjectaddENROL_DATE" maxlength="12" Columns="10"	runat="server"/></td> 
            <td>
              <p align="center">
              <input id='AddNewSubjectButton_DoAdd' class="Button" type="submit" value="Add" OnServerClick='AddNewSubject_Button_DoAdd_OnClick' runat="server"/></p>
            </td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="6"><strong>&nbsp;DELETE CHECKED SUBJECTS: 
              <input id='AddNewSubjectButton_DoDelete' class="Button" type="submit" value="Delete" OnServerClick='AddNewSubject_Button_DoDelete_OnClick' runat="server"/></strong></td>
          </tr>
        </table>
        
  <input id="AddNewSubjecthidden_STUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="AddNewSubjecthidden_ENROLMENT_YEAR" type="hidden"  runat="server"/>
  
  <input id="AddNewSubjecthidden_YEARLEVEL" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>


&nbsp; 
<div align="center">
  <asp:Literal id="AddNewSubjectlblMessages" runat="server"/> 
</div>

  </span>
  
<p></p>
<p></p>
<p></p>

</form>
</body>
</html>

<!--End ASPX page-->

