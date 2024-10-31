<!--ASPX page @1-B09D75F8-->
    <%@ Page language="vb" CodeFile="StudentAmendments_Results.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentAmendments_Results.StudentAmendments_ResultsPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentAmendments_Results" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Amendments - Update</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_UpdateForm_button_DoTeacher_OnClick @64-0B3B32FF
function page_UpdateForm_button_DoTeacher_OnClick()
{
    var result;
//End page_UpdateForm_button_DoTeacher_OnClick

//Validate Required Value @73-B821C3BD
    if(theForm.UpdateFormlistTeacher.value == "") {
        alert("Field - Pastoral Care ID\nOption must be selected from list")
        theForm.UpdateFormlistTeacher.focus();
        return false;
    }
//End Validate Required Value

//Confirmation Message @120-24EC9FA2
    return confirm('Are you Sure you want to Change the Pastoral Care ID?');
//End Confirmation Message

//Close page_UpdateForm_button_DoTeacher_OnClick @64-BC33A33A
    return result;
}
//End Close page_UpdateForm_button_DoTeacher_OnClick

//bind_events @1-896F1782
function bind_events() {
    addEventHandler("UpdateFormbutton_DoTeacher","click",page_UpdateForm_button_DoTeacher_OnClick);
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
<p align="center"><a id="Link1" href="" class="Button" runat="server"  >Return to Student Request</a><a href='<%=PageVariables.Get("Link1_Src")%>'></a></p>
<p>

  <span id="UpdateFormHolder" runat="server">
    


  <div align="center">
    <table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
              <th>Update Form</th>
 
              <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
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
              <p align="right">Lowest Student ID</p>
              </th>
 
              <td><asp:Literal id="UpdateFormlblStudentID" runat="server"/>&nbsp;</td> 
              <td>
                <p align="right">&nbsp;Enrolment Year</p>
              </td> 
              <td>&nbsp;<asp:Literal id="UpdateFormlblEnrolmentYear" runat="server"/></td> 
              <td>
                <p align="right">Rows/Page</p>
              </td> 
              <td><asp:Literal id="UpdateFormlblRowsPerPage" runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>&nbsp;</th>
 
              <td>&nbsp;</td> 
              <td>
                <p align="right">Year Level</p>
              </td> 
              <td>&nbsp;<asp:Literal id="UpdateFormlblYearLevel" runat="server"/></td> 
              <td>
                <p align="right">&nbsp;</p>
              </td> 
              <td>&nbsp;</td>
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
              <p align="right">Pastoral Care Name</p>
              </th>
 
              <td>
                <select id="UpdateFormlistTeacher"  runat="server"></select>
 </td> 
              <td colspan="2">&nbsp; 
                <input id='UpdateFormbutton_DoTeacher' class="Button" type="submit" value="Change Pastoral Care ID" OnServerClick='UpdateForm_button_DoTeacher_OnClick' runat="server"/>&nbsp;</td> 
              <td>&nbsp;&nbsp; </td> 
              <td>&nbsp;</td>
            </tr>
 
            <tr class="Bottom">
              <th align="right" colspan="6"></th>
            </tr>
          </table>
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
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>List of Students</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="7">
            <p align="left">Total Matched Records:&nbsp;<asp:Literal id="GridStudentListSTUD_SUB_INTERIM_STUD_SUB_TotalRecords" runat="server"/></p>
          </td>
        </tr>
 
        <tr class="Caption">
          <th>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# GridStudentListData.SortField.ToString()%>" OwnerDir="<%# GridStudentListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">Student ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# GridStudentListData.SortField.ToString()%>" OwnerDir="<%# GridStudentListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">Surname</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# GridStudentListData.SortField.ToString()%>" OwnerDir="<%# GridStudentListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">First Name</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <p align="center">&nbsp; 
          <CC:Sorter id="Sorter_YEAR_LEVELSorter" field="Sorter_YEAR_LEVEL" OwnerState="<%# GridStudentListData.SortField.ToString()%>" OwnerDir="<%# GridStudentListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_YEAR_LEVELSort" runat="server">Year Level</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></p>
          </th>
 
          <th>
          <p align="center">
          <CC:Sorter id="Sorter_SUBJ_ENROL_STATUSSorter" field="Sorter_SUBJ_ENROL_STATUS" OwnerState="<%# GridStudentListData.SortField.ToString()%>" OwnerDir="<%# GridStudentListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJ_ENROL_STATUSSort" runat="server">Enrolment Status</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></p>
          </th>
 
          <th>
          <p align="center">
          <CC:Sorter id="Sorter_STAFF_IDSorter" field="Sorter_STAFF_ID" OwnerState="<%# GridStudentListData.SortField.ToString()%>" OwnerDir="<%# GridStudentListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STAFF_IDSort" runat="server">Pastoral Care ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></p>
          </th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr  <CC:AttributeBinder runat="server" Name="rowStyle" ContainerId="GridStudentListRepeater"/>>
          <td style="TEXT-ALIGN: right">
            <p align="center"><asp:CheckBox id="GridStudentListcbox" runat="server"/></p>
          </td> 
          <td style="TEXT-ALIGN: right">
            <p align="left"><asp:Literal id="GridStudentListSTUDENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).STUDENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></p>
          </td> 
          <td><asp:Literal id="GridStudentListSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="GridStudentListFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>
            <p align="center"><asp:Literal id="GridStudentListYEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</p>
          </td> 
          <td>
            <div align="center">
              <asp:Literal id="GridStudentListSUBJ_ENROL_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).SUBJ_ENROL_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
            </div>
          </td> 
          <td>
            <div align="center">
              <asp:Literal id="GridStudentListSTAFF_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).STAFF_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
            </div>
          </td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	
        <tr class="Separator">
          <td colspan="7"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
        
  </SeparatorTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="7">No Students found</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="7">
            
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
<p><br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

