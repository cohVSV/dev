<!--ASPX page @1-3E54E8C2-->
    <%@ Page language="vb" CodeFile="TeacherAllocations_Results.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.TeacherAllocations_Results.TeacherAllocations_ResultsPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.TeacherAllocations_Results" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Teacher Allocations - Update</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css" />
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_UpdateForm_button_DoTeacher_OnClick @64-0B3B32FF
function page_UpdateForm_button_DoTeacher_OnClick()
{
    var result;
//End page_UpdateForm_button_DoTeacher_OnClick

//Custom Code @132-2A29BDB7
    // -------------------------
    result = true;
    // -------------------------
//End Custom Code



//Validate Required Value @73-1723ED96
    if(theForm.UpdateFormlistTeacher.value == "") {
        alert("Must select a Teacher ID to Allocate New Teacher")
        theForm.UpdateFormlistTeacher.focus();
        return false;
    }
//End Validate Required Value

//Close page_UpdateForm_button_DoTeacher_OnClick @64-BC33A33A
    return result;
}
//End Close page_UpdateForm_button_DoTeacher_OnClick

//page_UpdateForm_button_DoChangeOnvASS_OnClick @80-394B31FB
function page_UpdateForm_button_DoChangeOnvASS_OnClick()
{
    var result;
//End page_UpdateForm_button_DoChangeOnvASS_OnClick

//Custom Code @135-2A29BDB7
    // -------------------------
    result = true;
    // -------------------------
//End Custom Code



//Validate Required Value @82-C1A0A198
    if(theForm.UpdateFormlistappearsVASS.value == "") {
        alert("Must select the Appears on VASS to Allocate to a Student")
        theForm.UpdateFormlistappearsVASS.focus();
        return false;
    }
//End Validate Required Value

//Close page_UpdateForm_button_DoChangeOnvASS_OnClick @80-BC33A33A
    return result;
}
//End Close page_UpdateForm_button_DoChangeOnvASS_OnClick

//page_UpdateForm_button_DoChangeInterimResult_OnClick @78-C140E486
function page_UpdateForm_button_DoChangeInterimResult_OnClick()
{
    var result;
//End page_UpdateForm_button_DoChangeInterimResult_OnClick

//Custom Code @134-2A29BDB7
    // -------------------------
    result = true;
    // -------------------------
//End Custom Code



//Validate Required Value @79-EDC3BB98
    if(theForm.UpdateFormlistInterimResult.value == "") {
        alert("Must select an Interim Progress Code to Allocate a Result")
        theForm.UpdateFormlistInterimResult.focus();
        return false;
    }
//End Validate Required Value

//Close page_UpdateForm_button_DoChangeInterimResult_OnClick @78-BC33A33A
    return result;
}
//End Close page_UpdateForm_button_DoChangeInterimResult_OnClick

//page_UpdateForm_button_DoChangeFinalResult_OnClick @81-BCBB2771
function page_UpdateForm_button_DoChangeFinalResult_OnClick()
{
    var result;
//End page_UpdateForm_button_DoChangeFinalResult_OnClick

//Validate Required Value @83-3D8C8658
    if(theForm.UpdateFormlistFinalResult.value == "") {
        alert("Must select a Final Progress Code to Allocate a Result")
        theForm.UpdateFormlistFinalResult.focus();
        return false;
    }
//End Validate Required Value

//Confirmation Message @127-6DD3E795
    return confirm('Update Final Result for Selected students?');
//End Confirmation Message

//Custom Code @128-2A29BDB7
    // -------------------------
    // ERA:2-Dec-2010|EA| Check if ALL Students were selected (querystring value) and if 's_SUBJ_ENROL_STATUS=[CDEFPW]' (%5b + %5d are [ and ] urlencoded)
        //    and then double confirm Final Result - as it will overwrite Subject Enrol Status.
        if (window.location.href.indexOf('s_SUBJ_ENROL_STATUS=%5bCDEFPW%5d') > 0) {
                result = confirm('This will PERMANENTLY CHANGE any ticked Students to Status [Finished] - including those currently listed [Withdrawn]\n\nSo make sure only those ticked are the ones you want changed and click [Ok], or click [Cancel] and check.');
        }
    // -------------------------
//End Custom Code

//Close page_UpdateForm_button_DoChangeFinalResult_OnClick @81-BC33A33A
    return result;
}
//End Close page_UpdateForm_button_DoChangeFinalResult_OnClick

//page_UpdateForm_button_DoTeacherSST_OnClick @129-12707F6F
function page_UpdateForm_button_DoTeacherSST_OnClick()
{
    var result;
//End page_UpdateForm_button_DoTeacherSST_OnClick

//Custom Code @133-2A29BDB7
    // -------------------------
    result = true;
    // -------------------------
//End Custom Code



//Validate Required Value @130-1723ED96
    if(theForm.UpdateFormlistTeacher.value == "") {
        alert("Must select a Teacher ID to Allocate New Teacher")
        theForm.UpdateFormlistTeacher.focus();
        return false;
    }
//End Validate Required Value

//Close page_UpdateForm_button_DoTeacherSST_OnClick @129-BC33A33A
    return result;
}
//End Close page_UpdateForm_button_DoTeacherSST_OnClick

//bind_events @1-DE0EFD97
function bind_events() {
    addEventHandler("UpdateFormbutton_DoTeacherSST","click",page_UpdateForm_button_DoTeacherSST_OnClick);
    addEventHandler("UpdateFormbutton_DoChangeFinalResult","click",page_UpdateForm_button_DoChangeFinalResult_OnClick);
    addEventHandler("UpdateFormbutton_DoChangeInterimResult","click",page_UpdateForm_button_DoChangeInterimResult_OnClick);
    addEventHandler("UpdateFormbutton_DoChangeOnvASS","click",page_UpdateForm_button_DoChangeOnvASS_OnClick);
    addEventHandler("UpdateFormbutton_DoTeacher","click",page_UpdateForm_button_DoTeacher_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

// -------------------------
// ERA: Added bulk toggle as doing other work on page (unfuddle #254)
// Eric Affleck, 4-Mar-2010
// original code from http://mcarthurgfx.com/blog/article/making-a-toggle-all-checkbox
// this done as plain HTML/JS not Codecharge as CC wanted to add too many bits.

function toggle_CheckBoxAllFunction(cbthis) {
        var toggle = document.getElementById(cbthis.id).checked;
        var inputs = document.getElementsByTagName('input');
        for(var i = 0; i < inputs.length ; i++) {
                if(inputs[i].type == 'checkbox') {
                        inputs[i].checked = toggle;
                }
        }
}

//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center"><a id="Link1" href="" class="Button" runat="server"  >Return to Subject Request</a><a href='<%=PageVariables.Get("Link1_Src")%>'></a></p>
<p>

  <span id="UpdateFormHolder" runat="server">
    


  <div align="center">
    <table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
              <th>Update Form</th>
 
              <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            </tr>
 
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0">
            
  <asp:PlaceHolder id="UpdateFormError" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="6"><asp:Label ID="UpdateFormErrorLabel" runat="server"/></td> 
            </tr>
 
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th>
              <p align="right">&nbsp;Subject ID </p>
 </th>
 
              <td><asp:Literal id="UpdateFormlblSubjectID" runat="server"/>&nbsp;</td> 
              <td>
                <p align="right">&nbsp;Subject Title</p>
 </td> 
              <td>&nbsp;<asp:Literal id="UpdateFormlblSubjectTitle" runat="server"/></td> 
              <td>
                <p align="right">&nbsp;Enrolment Year</p>
 </td> 
              <td>&nbsp;<asp:Literal id="UpdateFormlblEnrolmentYear" runat="server"/></td> 
            </tr>
 
            <tr class="Controls">
              <th>
              <p align="right">Teacher ID</p>
 </th>
 
              <td><asp:Literal id="UpdateFormlblTeacherID" runat="server"/>&nbsp;</td> 
              <td>
                <p align="right">&nbsp;Semester</p>
 </td> 
              <td>&nbsp;<asp:Literal id="UpdateFormlblSemester" runat="server"/></td> 
              <td>
                <p align="right">&nbsp;Order By</p>
 </td> 
              <td>&nbsp;<asp:Literal id="UpdateFormlblOrderBy" runat="server"/></td> 
            </tr>
 
            <tr class="Bottom" height="5">
              <td>&nbsp;</td> 
              <td>&nbsp;</td> 
              <td>&nbsp;</td> 
              <td>&nbsp;</td> 
              <td>&nbsp;</td> 
              <td>&nbsp;</td> 
            </tr>
 
            <tr class="Controls">
              <th>
              <p align="right">New Teacher</p>
 </th>
 
              <td>
                <select id="UpdateFormlistTeacher"  runat="server"></select>
 </td> 
              <td>&nbsp; 
                <input id='UpdateFormbutton_DoTeacher' type="submit" class="Button" value="Change SUBJECT Teacher" OnServerClick='UpdateForm_button_DoTeacher_OnClick' runat="server"/>
                <p>&nbsp; 
                <input id='UpdateFormbutton_DoTeacherSST' type="submit" class="Button" value="Change Learning Advisor" OnServerClick='UpdateForm_button_DoTeacherSST_OnClick' runat="server"/></p>
 </td> 
              <td>
                <p align="right">&nbsp; Appears on VASS</p>
 </td> 
              <td>&nbsp; 
                <select id="UpdateFormlistappearsVASS"  runat="server"></select>
 </td> 
              <td>
                <input id='UpdateFormbutton_DoChangeOnvASS' type="submit" class="Button" value="Change Appears on VASS" OnServerClick='UpdateForm_button_DoChangeOnvASS_OnClick' runat="server"/>&nbsp;</td> 
            </tr>
 
            <tr class="Controls">
              <th>
              <p align="right">Interim Result</p>
 </th>
 
              <td>
                <select id="UpdateFormlistInterimResult"  runat="server"></select>
 </td> 
              <td>&nbsp; 
                <input id='UpdateFormbutton_DoChangeInterimResult' type="submit" class="Button" value="Change Int Result" OnServerClick='UpdateForm_button_DoChangeInterimResult_OnClick' runat="server"/></td> 
              <td>
                <p align="right">&nbsp;Final Result</p>
 </td> 
              <td>&nbsp; 
                <select id="UpdateFormlistFinalResult"  runat="server"></select>
 </td> 
              <td>
                <input id='UpdateFormbutton_DoChangeFinalResult' type="submit" class="Button" value="Change Final Result" OnServerClick='UpdateForm_button_DoChangeFinalResult_OnClick' runat="server"/>&nbsp;</td> 
            </tr>
 
            <tr class="Bottom">
              <th colspan="6" align="right"></th>
 
            </tr>
 
          </table>
 
  <input id="UpdateFormhidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  </td> 
      </tr>
 
    </table>
 
  </div>


<p align="center">&nbsp;<asp:Literal id="UpdateFormlblSelections" runat="server"/></p>

  </span>
  
<p>

<asp:repeater id="GridStudentListRepeater" OnItemCommand="GridStudentListItemCommand" OnItemDataBound="GridStudentListItemDataBound" runat="server">
  <HeaderTemplate>
	<br>
<table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>List of Students</th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
        </tr>
 
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="11">Total Records:&nbsp;<asp:Literal id="GridStudentListSTUD_SUB_INTERIM_STUD_SUB_TotalRecords" runat="server"/></td> 
        </tr>
 
        <tr class="Caption">
          <th>&nbsp;<input type="checkbox" onclick="toggle_CheckBoxAllFunction(this);" id="Checkbox_ToggleAll" name="Checkbox_ToggleAll"/>&nbsp;<em>all</em></th>
 
          <th>
          <CC:Sorter id="Sorter_STUDENT_SUBJECT_STUDENT_IDSorter" field="Sorter_STUDENT_SUBJECT_STUDENT_ID" OwnerState="<%# GridStudentListData.SortField.ToString()%>" OwnerDir="<%# GridStudentListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_SUBJECT_STUDENT_IDSort" runat="server">Student ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# GridStudentListData.SortField.ToString()%>" OwnerDir="<%# GridStudentListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">Surname</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# GridStudentListData.SortField.ToString()%>" OwnerDir="<%# GridStudentListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">First Name</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <p align="center">Sem.</p>
 </th>
 
          <th>
          <p align="center">
          <CC:Sorter id="Sorter_SUBJ_ENROL_STATUSSorter" field="Sorter_SUBJ_ENROL_STATUS" OwnerState="<%# GridStudentListData.SortField.ToString()%>" OwnerDir="<%# GridStudentListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJ_ENROL_STATUSSort" runat="server">Subj. Status</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></p>
 </th>
 
          <th>
          <p align="center">Interim Result</p>
 </th>
 
          <th>
          <p align="center">Final Result</p>
 </th>
 
          <th>
          <p align="center">
          <CC:Sorter id="Sorter_STAFF_IDSorter" field="Sorter_STAFF_ID" OwnerState="<%# GridStudentListData.SortField.ToString()%>" OwnerDir="<%# GridStudentListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STAFF_IDSort" runat="server">Teacher ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></p>
 </th>
 
          <th>
          <p align="center">Appears <br>
          on VASS</p>
 </th>
 
          <th>
          <CC:Sorter id="Sorter_ATTENDING_SCHOOL_NAMESorter" field="Sorter_ATTENDING_SCHOOL_NAME" OwnerState="<%# GridStudentListData.SortField.ToString()%>" OwnerDir="<%# GridStudentListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ATTENDING_SCHOOL_NAMESort" runat="server">Attending School</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr  <CC:AttributeBinder runat="server" Name="rowStyle" ContainerId="GridStudentListRepeater"/>>
          <td style="TEXT-ALIGN: right">
            <p align="center"><asp:CheckBox id="GridStudentListcbox" runat="server"/></p>
 </td> 
          <td style="TEXT-ALIGN: right">
            <p align="left"><asp:Literal id="GridStudentListSTUDENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).STUDENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</p>
 </td> 
          <td><asp:Literal id="GridStudentListSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="GridStudentListFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>
            <div align="center">
              <asp:Literal id="GridStudentListSEMESTER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).SEMESTER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
            </div>
 </td> 
          <td>
            <div align="center">
              <asp:Literal id="GridStudentListSUBJ_ENROL_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).SUBJ_ENROL_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
            </div>
 </td> 
          <td>
            <div align="center">
              <asp:Literal id="GridStudentListINTERIM_PROGRESS_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).INTERIM_PROGRESS_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
            </div>
 </td> 
          <td>
            <div align="center">
              <asp:Literal id="GridStudentListFINAL_PROGRESS_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).FINAL_PROGRESS_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
            </div>
 </td> 
          <td>
            <div align="center">
              <asp:Literal id="GridStudentListSTAFF_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).STAFF_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
            </div>
 </td> 
          <td>
            <div align="center">
              <asp:Literal id="GridStudentListAPPEARS_ON_VASS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).APPEARS_ON_VASS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
            </div>
 </td> 
          <td><asp:Literal id="GridStudentListATTENDING_SCHOOL_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).ATTENDING_SCHOOL_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	
        <tr class="Separator">
          <td colspan="11"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
        </tr>
 
  </SeparatorTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="11">No Students found</td> 
        </tr>
 
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="11">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# GridStudentListData.PagesCount%>" PageSize="<%# GridStudentListData.RecordsPerPage%>" PageNumber="<%# GridStudentListData.PageNumber%>" runat="server">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">First</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server">First </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">Prev</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server">Prev </CC:NavigatorItem>&nbsp; 
            
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
            <PageOnTemplate><asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
            <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %>&nbsp;</PageOffTemplate></CC:Pager>of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">Next</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server">Next </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">Last</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server">Last </CC:NavigatorItem></CC:Navigator>
</td> 
        </tr>
 
      </table>
 </td> 
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
</p>
<p><asp:Literal id="lblDEBUG" runat="server"/><br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

