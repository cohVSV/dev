<!--ASPX page @1-14E1E867-->
    <%@ Page language="vb" CodeFile="Student_ClassList_Extender.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_ClassList_Extender.Student_ClassList_ExtenderPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_ClassList_Extender" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032"><meta name="description" content="Page similar to the Class List Report, with option to Extend Students in certain subjects. May 2018"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Class List - Extenders</title>



<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_CLASS_LIST_Panel_Button_DoSearch_OnClick @80-645F28F1
function page_CLASS_LIST_Panel_Button_DoSearch_OnClick()
{
    var result;
//End page_CLASS_LIST_Panel_Button_DoSearch_OnClick

//Custom Code @90-2A29BDB7
    // -------------------------
    if (document.getElementById('CLASS_LIST_PanelList_SUBJECT_ID').value=='')
        {
                alert('Select Subject');
                return false;
        }
        else if (document.getElementById('CLASS_LIST_PanelList_SUBJECT_ENROL_STATUS').value=='')
        {
                alert('Select Subject Enrolment Status');
                return false;
}
    // -------------------------
//End Custom Code

//Close page_CLASS_LIST_Panel_Button_DoSearch_OnClick @80-BC33A33A
    return result;
}
//End Close page_CLASS_LIST_Panel_Button_DoSearch_OnClick

//page_EditGrid_ExtendStudents_Button_Submit_OnClick @241-42FD6DA3
function page_EditGrid_ExtendStudents_Button_Submit_OnClick()
{
    var result;
//End page_EditGrid_ExtendStudents_Button_Submit_OnClick

//Confirmation Message @242-D6B66258
    return confirm('Extend Selected Students?');
//End Confirmation Message

//Close page_EditGrid_ExtendStudents_Button_Submit_OnClick @241-BC33A33A
    return result;
}
//End Close page_EditGrid_ExtendStudents_Button_Submit_OnClick

//bind_events @1-3319530D
function bind_events() {
    if(typeof(initEditGrid_ExtendStudentsElements) == "function")
        initEditGrid_ExtendStudentsElements();
    if(typeof(EditGrid_ExtendStudentsStaticElementsID) == "object" && typeof(EditGrid_ExtendStudentsStaticElementsID[EditGrid_ExtendStudentsButton_SubmitID]) == "object" && EditGrid_ExtendStudentsStaticElementsID[EditGrid_ExtendStudentsButton_SubmitID]!=null)
        addEventHandler(EditGrid_ExtendStudentsStaticElementsID[EditGrid_ExtendStudentsButton_SubmitID].id, "click", page_EditGrid_ExtendStudents_Button_Submit_OnClick);
    addEventHandler("CLASS_LIST_PanelButton_DoSearch","click",page_CLASS_LIST_Panel_Button_DoSearch_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//End CCS script
</script>
<link rel="stylesheet" type="text/css" href="js/css/ui-lightness/jquery-ui-1.8.8.custom.css">
<style type="text/css">
<!--
.overlay  { background: black no-repeat 50% 50%; background-image: url(images/ajax_loader_bigwhite.gif); display: none; height: 100%; left: 0; opacity: .9; position: absolute; top: 0; width: 100%; }
-->
</style>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
&nbsp;&nbsp; 

  <span id="CLASS_LIST_PanelHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Search My Extending Classes</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="CLASS_LIST_PanelError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="CLASS_LIST_PanelErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>&nbsp;Subject: </th>
 
            <td>&nbsp; 
              <select id="CLASS_LIST_PanelList_Subject_id" style="WIDTH: 313px"  runat="server"></select>
 &nbsp;&nbsp; </td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right"><a id="CLASS_LIST_PanelClearParameters" href="" runat="server"  >Clear</a>&nbsp;&nbsp;&nbsp;&nbsp; 
              <input id='CLASS_LIST_PanelButton_DoSearch' type="submit" class="Button" value="Show My Students" OnServerClick='CLASS_LIST_Panel_Search' runat="server"/></td>
          </tr>
        </table>
        <em>(only your subjects are shown where the Subject allows Extending)</em></td>
    </tr>
  </table>


&nbsp;&nbsp;&nbsp;
  </span>
  
<p></p>
<p>

<asp:repeater id="EditGrid_ExtendStudentsRepeater" OnItemCommand="EditGrid_ExtendStudentsItemCommand" OnItemDataBound="EditGrid_ExtendStudentsItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript" >
	var EditGrid_ExtendStudentsElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initEditGrid_ExtendStudentsElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
  <table class="MainTable" cellspacing="0" cellpadding="0" border="0" align="center">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Extend Students</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
 
          <tr>
            <td colspan="3" style="background-color: white">&nbsp;<em><asp:Literal id="EditGrid_ExtendStudentslblHintExtend" runat="server"/> <asp:Literal id="EditGrid_ExtendStudentslblHintPending" runat="server"/></em></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="EditGrid_ExtendStudentsError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="9"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Caption">
            <th>&nbsp;#</th>
 
            <th>
            <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# EditGrid_ExtendStudentsData.SortField.ToString()%>" OwnerDir="<%# EditGrid_ExtendStudentsData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# EditGrid_ExtendStudentsData.SortField.ToString()%>" OwnerDir="<%# EditGrid_ExtendStudentsData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# EditGrid_ExtendStudentsData.SortField.ToString()%>" OwnerDir="<%# EditGrid_ExtendStudentsData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <!-- BEGIN Sorter Sorter_SUBJECT_ID --><span class="Sorter"><a href='<%#PageVariables.Get("Sort_URL")%>' id="EditGrid_ExtendStudentsSorter_SUBJECT_ID">SUBJECT ID</a> 
            <img src="Styles/Blueprint/Images/Asc.gif">
            <img src="Styles/Blueprint/Images/Desc.gif"></span><!-- END Sorter Sorter_SUBJECT_ID --></th>
 
            <th>
            <CC:Sorter id="Sorter_SUBJ_ENROL_STATUSSorter" field="Sorter_SUBJ_ENROL_STATUS" OwnerState="<%# EditGrid_ExtendStudentsData.SortField.ToString()%>" OwnerDir="<%# EditGrid_ExtendStudentsData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SUBJ_ENROL_STATUSSort" runat="server">SUBJECT STATUS</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_SEMESTERSorter" field="Sorter_SEMESTER" OwnerState="<%# EditGrid_ExtendStudentsData.SortField.ToString()%>" OwnerDir="<%# EditGrid_ExtendStudentsData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SEMESTERSort" runat="server">SEMESTER</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_LAdSorter" field="Sorter_LAd" OwnerState="<%# EditGrid_ExtendStudentsData.SortField.ToString()%>" OwnerDir="<%# EditGrid_ExtendStudentsData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LAdSort" runat="server">LAd</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>Extend?</th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="9"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Row">
            <td>&nbsp;<asp:Literal id="EditGrid_ExtendStudentslblCnt" Text='<%# Server.HtmlEncode((CType(Container.DataItem,EditGrid_ExtendStudentsItem)).lblCnt.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:Literal id="EditGrid_ExtendStudentsSTUDENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,EditGrid_ExtendStudentsItem)).STUDENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:Literal id="EditGrid_ExtendStudentsSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,EditGrid_ExtendStudentsItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:Literal id="EditGrid_ExtendStudentsFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,EditGrid_ExtendStudentsItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><%=PageVariables.Get("SUBJECT_ID")%></td> 
            <td><asp:Literal id="EditGrid_ExtendStudentsSUBJ_ENROL_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,EditGrid_ExtendStudentsItem)).SUBJ_ENROL_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:Literal id="EditGrid_ExtendStudentsSEMESTER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,EditGrid_ExtendStudentsItem)).SEMESTER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:Literal id="EditGrid_ExtendStudentsLAd" Text='<%# Server.HtmlEncode((CType(Container.DataItem,EditGrid_ExtendStudentsItem)).LAd.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td>
              <asp:CheckBox id="EditGrid_ExtendStudentsCheckBox_Delete" Visible = "<%# (CType(Container.DataItem,EditGrid_ExtendStudentsItem)).IsDeleteAllowed %>" runat="server"/>&nbsp;</td>
          </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="9">No Student Details found!</td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Footer">
            <td style="TEXT-ALIGN: right" colspan="9">
              
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# EditGrid_ExtendStudentsData.PagesCount%>" PageSize="<%# EditGrid_ExtendStudentsData.RecordsPerPage%>" PageNumber="<%# EditGrid_ExtendStudentsData.PageNumber%>" runat="server"><span class="Navigator">
              <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src="Styles/Blueprint/Images/First.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="FirstOff" runat="server"><img src="Styles/Blueprint/Images/FirstOff.gif"></CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/PrevOff.gif"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
              <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src="Styles/Blueprint/Images/Next.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/NextOff.gif"></CC:NavigatorItem>
              <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src="Styles/Blueprint/Images/Last.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="LastOff" runat="server"><img src="Styles/Blueprint/Images/LastOff.gif"></CC:NavigatorItem></span></CC:Navigator>

              <asp:Button id="EditGrid_ExtendStudentsButton_Submit" CssClass="Button" Text="Extend Selected" CommandName="Submit" runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </FooterTemplate>
</asp:repeater>
<br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

