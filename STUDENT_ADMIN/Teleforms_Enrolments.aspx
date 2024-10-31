<!--ASPX page @1-3D3F15AD-->
    <%@ Page language="vb" CodeFile="Teleforms_Enrolments.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Teleforms_Enrolments.Teleforms_EnrolmentsPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Teleforms_Enrolments" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Teacher Allocations - Update</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//DEL  </script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//DEL    

//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_UpdateForm_button_DoDelete_OnClick @81-E3D25019
function page_UpdateForm_button_DoDelete_OnClick()
{
    var result;
//End page_UpdateForm_button_DoDelete_OnClick

//Confirmation Message @116-FC5E40F4
    return confirm('Sure you want to DELETE the selected Students from Teleforms?\n\n(Student Database will not be affected)');
//End Confirmation Message

//Close page_UpdateForm_button_DoDelete_OnClick @81-BC33A33A
    return result;
}
//End Close page_UpdateForm_button_DoDelete_OnClick

//bind_events @1-611CEA03
function bind_events() {
    addEventHandler("UpdateFormbutton_DoDelete","click",page_UpdateForm_button_DoDelete_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//End CCS script
</script>
<style type="text/css">
<!--
.errorrow  { color: #990000; background-color: #FFC4C4; border-top-color: #FFB4B4; border-right-color: #FFB4B4; border-bottom-color: #FFB4B4; border-left-color: #FFB4B4; }
-->
</style>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center"><a href='<%=PageVariables.Get("Link1_Src")%>'></a>&nbsp;</p>
<p>

  <span id="UpdateFormHolder" runat="server">
    


  <div align="center">
    <table cellspacing="0" cellpadding="0" width="50%" align="center" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
              <th>Update Form</th>
 
              <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            </tr>
 
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0" width="50%">
            
  <asp:PlaceHolder id="UpdateFormError" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="2"><asp:Label ID="UpdateFormErrorLabel" runat="server"/></td> 
            </tr>
 
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <td>&nbsp; 
                <input id='UpdateFormbutton_DoEnrolment' class="Button" type="submit" value="Enrol Selected Students" OnServerClick='UpdateForm_button_DoEnrolment_OnClick' runat="server"/>&nbsp;&nbsp; </td> 
              <td>&nbsp; 
                <input id='UpdateFormbutton_DoDelete' class="Button" type="submit" value="Delete Selected" OnServerClick='UpdateForm_button_DoDelete_OnClick' runat="server"/>&nbsp;</td> 
            </tr>
 
            <tr class="Bottom">
              <th align="right"></th>
 
            </tr>
 
          </table>
 
  <input id="UpdateFormhidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  </td> 
      </tr>
 
    </table>
 
  </div>


<p align="center">&nbsp;<asp:Literal id="UpdateFormlblSelections" runat="server"/>&nbsp;</p>

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
          <th>List of Teleforms Students</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
        </tr>
 
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="8">Total Records:&nbsp;<asp:Literal id="GridStudentListSTUD_SUB_INTERIM_STUD_SUB_TotalRecords" runat="server"/></td> 
        </tr>
 
        <tr class="Caption">
          <th>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_STUDENT_SUBJECT_STUDENT_IDSorter" field="Sorter_STUDENT_SUBJECT_STUDENT_ID" OwnerState="<%# GridStudentListData.SortField.ToString()%>" OwnerDir="<%# GridStudentListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_SUBJECT_STUDENT_IDSort" runat="server">Student ID</asp:LinkButton> 
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
          <p align="center">Date of Birth</p>
 </th>
 
          <th>
          <p align="center">Category</p>
 </th>
 
          <th>
          <p align="center">Scan Date/Time</p>
 </th>
 
          <th>
          <p align="center">Teleform Status</p>
 </th>
 
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr  <CC:AttributeBinder runat="server" Name="rowStyle" ContainerId="GridStudentListRepeater"/>>
          <td style="TEXT-ALIGN: right">
            <p align="center"><asp:CheckBox id="GridStudentListcbox" runat="server"/>&nbsp;</p>
 </td> 
          <td style="TEXT-ALIGN: right">
            <p align="left"><asp:Literal id="GridStudentListSTUDENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).STUDENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</p>
 </td> 
          <td><asp:Literal id="GridStudentListSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="GridStudentListFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>
            <div align="center">
              <asp:Literal id="GridStudentListBIRTH_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).BIRTH_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
            </div>
 </td> 
          <td>
            <div align="center">
              <asp:Literal id="GridStudentListCATEGORY_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).CATEGORY_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
            </div>
 </td> 
          <td>
            <div align="center">
              <asp:Literal id="GridStudentListLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> 
            </div>
 </td> 
          <td>
            <div align="center">
              <asp:Literal id="GridStudentListTELEFORM_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).TELEFORM_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;[<asp:Literal id="GridStudentListhidden_TMP_STUDENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GridStudentListItem)).hidden_TMP_STUDENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>] 
            </div>
 </td> 
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	
        <tr class="Separator">
          <td colspan="8"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
        </tr>
 
  </SeparatorTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="8">No Students found</td> 
        </tr>
 
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="8">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# GridStudentListData.PagesCount%>" PageSize="<%# GridStudentListData.RecordsPerPage%>" PageNumber="<%# GridStudentListData.PageNumber%>" runat="server">
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>&nbsp; 
            
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="6" runat="server">
            <PageOnTemplate><asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
            <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %>&nbsp;</PageOffTemplate></CC:Pager>of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src="Styles/Blueprint/Images/Next.gif" border="0"></asp:LinkButton> </CC:NavigatorItem></CC:Navigator>
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

