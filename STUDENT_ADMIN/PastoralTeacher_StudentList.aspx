<!--ASPX page @1-31BC980E-->
    <%@ Page language="vb" CodeFile="PastoralTeacher_StudentList.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.PastoralTeacher_StudentList.PastoralTeacher_StudentListPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.PastoralTeacher_StudentList" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.01.00.06"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Advisory Group</title>


<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//DEL  </script>
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/ajaxpanel.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">


//page_viewMaintainSearchRequest1_Button_Submit_OnClick @70-1E864796
function page_viewMaintainSearchRequest1_Button_Submit_OnClick()
{
    var result;
//End page_viewMaintainSearchRequest1_Button_Submit_OnClick

//Confirmation Message @71-F1A92402
    return confirm('This will Update the ticked students to [Standard Learning Program] for all their Subjects not already flagged as Custom Learning.');
//End Confirmation Message

//Close page_viewMaintainSearchRequest1_Button_Submit_OnClick @70-BC33A33A
    return result;
}
//End Close page_viewMaintainSearchRequest1_Button_Submit_OnClick

//page_viewMaintainSearchRequest2_Button_Submit_OnClick @177-7A663C68
function page_viewMaintainSearchRequest2_Button_Submit_OnClick()
{
    var result;
//End page_viewMaintainSearchRequest2_Button_Submit_OnClick

//Confirmation Message @283-F1A92402
    return confirm('This will Update the ticked students to [Standard Learning Program] for all their Subjects not already flagged as Custom Learning.');
//End Confirmation Message

//Close page_viewMaintainSearchRequest2_Button_Submit_OnClick @177-BC33A33A
    return result;
}
//End Close page_viewMaintainSearchRequest2_Button_Submit_OnClick

//bind_events @1-A5E27BF0
function bind_events() {
    if(typeof(initviewMaintainSearchRequest1Elements) == "function")
        initviewMaintainSearchRequest1Elements();
    if(typeof(initviewMaintainSearchRequest2Elements) == "function")
        initviewMaintainSearchRequest2Elements();
    if(typeof(viewMaintainSearchRequest2StaticElementsID) == "object" && typeof(viewMaintainSearchRequest2StaticElementsID[viewMaintainSearchRequest2Button_SubmitID]) == "object" && viewMaintainSearchRequest2StaticElementsID[viewMaintainSearchRequest2Button_SubmitID]!=null)
        addEventHandler(viewMaintainSearchRequest2StaticElementsID[viewMaintainSearchRequest2Button_SubmitID].id, "click", page_viewMaintainSearchRequest2_Button_Submit_OnClick);
    if(typeof(viewMaintainSearchRequest1StaticElementsID) == "object" && typeof(viewMaintainSearchRequest1StaticElementsID[viewMaintainSearchRequest1Button_SubmitID]) == "object" && viewMaintainSearchRequest1StaticElementsID[viewMaintainSearchRequest1Button_SubmitID]!=null)
        addEventHandler(viewMaintainSearchRequest1StaticElementsID[viewMaintainSearchRequest1Button_SubmitID].id, "click", page_viewMaintainSearchRequest1_Button_Submit_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//End CCS script
</script>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">

</head>
<body>
<form runat="server">


<p align="center"><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>
<p></p>
<p>

<asp:repeater id="viewMaintainSearchRequest1Repeater" OnItemCommand="viewMaintainSearchRequest1ItemCommand" OnItemDataBound="viewMaintainSearchRequest1ItemDataBound" runat="server">
  <HeaderTemplate>
  


    
	<script language="JavaScript" >
	var viewMaintainSearchRequest1Elements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initviewMaintainSearchRequest1Elements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
    <table cellspacing="0" cellpadding="0" width="96%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" align="center" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Student Advisory Group for Learning Advisor - <asp:Literal id="viewMaintainSearchRequest1lblPastoralID" runat="server"/></th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Grid" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="viewMaintainSearchRequest1Error" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="13"><asp:Label ID="ErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Row">
                        <td colspan="13">Total Records:&nbsp;<asp:Literal id="viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords" runat="server"/></td>
                    </tr>
 
                    <tr class="Caption">
                        <th>&nbsp;</th>
 
                        <th>
                        <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="Sorter_YEAR_LEVELSorter" field="Sorter_YEAR_LEVEL" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_YEAR_LEVELSort" runat="server">YEAR<br>
LEVEL</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="Sorter_ENROLMENT_STATUSSorter" field="Sorter_ENROLMENT_STATUS" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_STATUSSort" runat="server">ENROL<br>
STATUS</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>&nbsp; 
                        <CC:Sorter id="Sorter_ENROLMENT_DATESorter" field="Sorter_ENROLMENT_DATE" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_DATESort" runat="server">ENROL DATE</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>Student <br>
                        Profile?</th>
 
                        <th>Pathways <br>
                        Profile?</th>
 
                        <th>&nbsp;Mandated Cohort&nbsp;<img onclick="javascript:alert('Mandated IEP cohort details where applicable');return false;" id="LAstudentMandatedCohort_icon" title="Mandated IEP cohort details where applicable" border="0" alt="Mandated IEP Cohort" src="images/icon_info.gif"></th>
 
                        <th>Learning Plan&nbsp;<img onclick="javascript:alert('Learning Plan - PLP or Mandated IEP');return false;" id="LAstudentLearningPlan_icon" title="Learning Plan - PLP or Mandated IEP" border="0" alt="Learning Plan - PLP or Mandated IEP" src="images/icon_info.gif"></th>
 
                        <th>Green Letter?&nbsp;&nbsp;<img onclick="javascript:alert('Student 7-10 Green Letter Indicator - Student has Defaulting status in 2 or more Subjects. Added March 2013');return false;" id="LAstudentgreenletter_icon" title="Student F-10 Green Letter Indicator - Student has not received Green Letter or last decision over 7 days ago" border="0" alt="Green Letter" src="images/icon_info.gif"></th>
 
                        <th>Letters Sent and Dates?&nbsp;</th>
                    </tr>
 
                    
  </HeaderTemplate>
  <ItemTemplate>
    
                    
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
                    <tr class="Error">
                        <td colspan="13"><asp:Label ID="ErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>

                    <tr class="Row">
                        <td>&nbsp;<a id="viewMaintainSearchRequest1Link1" href="" title="go to Student Summary" runat="server"  >summary</a></td> 
                        <td><a id="viewMaintainSearchRequest1STUDENT_ID" href="" title="go to Comments" runat="server"  ><%#(CType(Container.DataItem,viewMaintainSearchRequest1Item)).STUDENT_ID.GetFormattedValue()%></a>&nbsp;</td> 
                        <td><asp:Literal id="viewMaintainSearchRequest1SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                        <td><asp:Literal id="viewMaintainSearchRequest1FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                        <td><asp:Literal id="viewMaintainSearchRequest1YEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                        <td><asp:Literal id="viewMaintainSearchRequest1ENROLMENT_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).ENROLMENT_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                        <td nowrap>&nbsp;<asp:Literal id="viewMaintainSearchRequest1ENROLMENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).ENROLMENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="viewMaintainSearchRequest1lblNewStudent" Text='<%# (CType(Container.DataItem,viewMaintainSearchRequest1Item)).lblNewStudent.GetFormattedValue() %>' runat="server"/>
  <input id="viewMaintainSearchRequest1hidden_days_since_enrolment"  value='<%# (CType(Container.DataItem,viewMaintainSearchRequest1Item)).hidden_days_since_enrolment.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
                        <td><a id="viewMaintainSearchRequest1link_IntakeDone" href="" runat="server"  ><%#(CType(Container.DataItem,viewMaintainSearchRequest1Item)).link_IntakeDone.GetFormattedValue()%></a>&nbsp;</td> 
                        <td>&nbsp;<a id="viewMaintainSearchRequest1link_PathwaysDone" href="" runat="server"  ><%#(CType(Container.DataItem,viewMaintainSearchRequest1Item)).link_PathwaysDone.GetFormattedValue()%></a></td> 
                        <td><asp:Literal id="viewMaintainSearchRequest1MandatedCohort" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).MandatedCohort.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                        <td><asp:Literal id="viewMaintainSearchRequest1LearningPlan" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).LearningPlan.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                        <td nowrap>&nbsp; 
                            <asp:RadioButtonList id="viewMaintainSearchRequest1rbGreenLetterSend"  Visible="False" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><asp:Literal id="viewMaintainSearchRequest1lblGreenLetter" runat="server"/></td> 
                        <td nowrap>&nbsp;<span style="BACKGROUND-COLOR: lightgreen"><asp:Literal id="viewMaintainSearchRequest1GREEN_LETTER_SENT_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).GREEN_LETTER_SENT_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="viewMaintainSearchRequest1GREEN_LETTER_SENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).GREEN_LETTER_SENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></span>&nbsp;<span style="BACKGROUND-COLOR: orange"><asp:Literal id="viewMaintainSearchRequest1AMBER_LETTER_SENT_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).AMBER_LETTER_SENT_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="viewMaintainSearchRequest1AMBER_LETTER_SENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).AMBER_LETTER_SENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></span>&nbsp;<span style="BACKGROUND-COLOR: firebrick"><asp:Literal id="viewMaintainSearchRequest1RED_LETTER_SENT_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).RED_LETTER_SENT_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="viewMaintainSearchRequest1RED_LETTER_SENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).RED_LETTER_SENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></span></td>
                    </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
                    
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                    <tr class="NoRecords">
                        <td colspan="13">No Students for this Learning Advisor were found!</td>
                    </tr>
                    
  </asp:PlaceHolder>

                    <tr class="Footer">
                        <td style="TEXT-ALIGN: right" colspan="10">&nbsp;</td> 
                        <td style="TEXT-ALIGN: right">
                            <asp:Button id="viewMaintainSearchRequest1Button_Submit" CssClass="Button" Text="Update Standard Learning Programs" CommandName="Submit" runat="server"/></td> 
                        <td style="TEXT-ALIGN: right">
                            <asp:Button id="viewMaintainSearchRequest1Button_Submit1" CssClass="Button" Text="Update Green Letter" CommandName="Submit" runat="server"/></td> 
                        <td style="TEXT-ALIGN: right">&nbsp;</td>
                    </tr>
                </table>
                <em>Click the Student ID to go to the Comments for that Student</em></td>
        </tr>
    </table>



  </FooterTemplate>
</asp:repeater>
<br>

<asp:repeater id="viewMaintainSearchRequest2Repeater" OnItemCommand="viewMaintainSearchRequest2ItemCommand" OnItemDataBound="viewMaintainSearchRequest2ItemDataBound" runat="server">
  <HeaderTemplate>
  


    
	<script language="JavaScript" >
	var viewMaintainSearchRequest2Elements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initviewMaintainSearchRequest2Elements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
    <table cellspacing="0" cellpadding="0" width="96%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" align="center" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Single-Subject Students with Subject Teacher - <asp:Literal id="viewMaintainSearchRequest2lblPastoralID" runat="server"/></th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Grid" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="viewMaintainSearchRequest2Error" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="15"><asp:Label ID="ErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Row">
                        <td colspan="15">Total Records:&nbsp;<asp:Literal id="viewMaintainSearchRequest2viewMaintainSearchRequest1_TotalRecords" runat="server"/></td>
                    </tr>
 
                    <tr class="Caption">
                        <th>&nbsp;</th>
 
                        <th>
                        <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="Sorter_YEAR_LEVELSorter" field="Sorter_YEAR_LEVEL" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_YEAR_LEVELSort" runat="server">YEAR<br>
LEVEL</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="Sorter_ENROLMENT_STATUSSorter" field="Sorter_ENROLMENT_STATUS" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_STATUSSort" runat="server">ENROL<br>
STATUS</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>&nbsp; 
                        <CC:Sorter id="Sorter_ENROLMENT_DATESorter" field="Sorter_ENROLMENT_DATE" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_DATESort" runat="server">ENROL DATE</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="Sorter_LADIDSorter" field="Sorter_LADID" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LADIDSort" runat="server">LAd ID</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter>&nbsp;</th>
 
                        <th>
                        <CC:Sorter id="Sorter_CATEGORY_CODESorter" field="Sorter_CATEGORY_CODE" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_CATEGORY_CODESort" runat="server">Enrol Category</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter>&nbsp;</th>
 
                        <th>Student <br>
                        Profile?</th>
 
                        <th>Pathways <br>
                        Profile?</th>
 
                        <th>&nbsp;Mandated Cohort&nbsp;<img onclick="javascript:alert('Mandated IEP cohort details where applicable');return false;" id="SSstudentMandatedCohort_icon" title="Mandated IEP cohort details where applicable" border="0" alt="Mandated IEP Cohort" src="images/icon_info.gif"></th>
 
                        <th>Learning Plan&nbsp;<img onclick="javascript:alert('Learning Plan - PLP or Mandated IEP');return false;" id="SSstudentLearningPlan_icon" title="Learning Plan - PLP or Mandated IEP" border="0" alt="Learning Plan - PLP or Mandated IEP" src="images/icon_info.gif"></th>
 
                        <th>&nbsp;Green Letter?&nbsp;&nbsp;<img onclick="javascript:alert('Student 7-10 Green Letter Indicator - Student has Defaulting status in 2 or more Subjects. Added March 2013');return false;" id="SSstudentgreenletter_icon" title="Student F-10 Green Letter Indicator - Student has not received Green Letter or last decision over 7 days ago" border="0" alt="Green Letter" src="images/icon_info.gif"></th>
 
                        <th>Letters Sent and Dates?&nbsp;&nbsp;</th>
                    </tr>
 
                    
  </HeaderTemplate>
  <ItemTemplate>
    
                    
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
                    <tr class="Error">
                        <td colspan="15"><asp:Label ID="ErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>

                    <tr class="Row">
                        <td>&nbsp;<a id="viewMaintainSearchRequest2Link1" href="" title="go to Student Summary" runat="server"  >summary</a></td> 
                        <td><a id="viewMaintainSearchRequest2STUDENT_ID" href="" title="go to Comments" runat="server"  ><%#(CType(Container.DataItem,viewMaintainSearchRequest2Item)).STUDENT_ID.GetFormattedValue()%></a>&nbsp;</td> 
                        <td><asp:Literal id="viewMaintainSearchRequest2SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                        <td><asp:Literal id="viewMaintainSearchRequest2FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                        <td><asp:Literal id="viewMaintainSearchRequest2YEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                        <td><asp:Literal id="viewMaintainSearchRequest2ENROLMENT_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).ENROLMENT_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                        <td nowrap>&nbsp;<asp:Literal id="viewMaintainSearchRequest2ENROLMENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).ENROLMENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="viewMaintainSearchRequest2lblNewStudent" Text='<%# (CType(Container.DataItem,viewMaintainSearchRequest2Item)).lblNewStudent.GetFormattedValue() %>' runat="server"/>
  <input id="viewMaintainSearchRequest2hidden_days_since_enrolment"  value='<%# (CType(Container.DataItem,viewMaintainSearchRequest2Item)).hidden_days_since_enrolment.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
                        <td>&nbsp;<asp:Literal id="viewMaintainSearchRequest2LAD" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).LAD.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                        <td>&nbsp;<asp:Literal id="viewMaintainSearchRequest2CATEGORY_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).CATEGORY_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                        <td><a id="viewMaintainSearchRequest2link_IntakeDone" href="" runat="server"  ><%#(CType(Container.DataItem,viewMaintainSearchRequest2Item)).link_IntakeDone.GetFormattedValue()%></a>&nbsp;</td> 
                        <td>&nbsp;<a id="viewMaintainSearchRequest2link_PathwaysDone" href="" runat="server"  ><%#(CType(Container.DataItem,viewMaintainSearchRequest2Item)).link_PathwaysDone.GetFormattedValue()%></a></td> 
                        <td><asp:Literal id="viewMaintainSearchRequest2MandatedCohort" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).MandatedCohort.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                        <td><asp:Literal id="viewMaintainSearchRequest2LearningPlan" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).LearningPlan.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                        <td>&nbsp; 
                            <asp:RadioButtonList id="viewMaintainSearchRequest2rbGreenLetterSend"  Visible="False" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><asp:Literal id="viewMaintainSearchRequest2lblGreenLetter" runat="server"/></td> 
                        <td nowrap>&nbsp;<span style="BACKGROUND-COLOR: lightgreen"><asp:Literal id="viewMaintainSearchRequest2GREEN_LETTER_SENT_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).GREEN_LETTER_SENT_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="viewMaintainSearchRequest2GREEN_LETTER_SENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).GREEN_LETTER_SENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></span>&nbsp;<span style="BACKGROUND-COLOR: orange"><asp:Literal id="viewMaintainSearchRequest2AMBER_LETTER_SENT_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).AMBER_LETTER_SENT_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="viewMaintainSearchRequest2AMBER_LETTER_SENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).AMBER_LETTER_SENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></span>&nbsp;<span style="BACKGROUND-COLOR: firebrick"><asp:Literal id="viewMaintainSearchRequest2RED_LETTER_SENT_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).RED_LETTER_SENT_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="viewMaintainSearchRequest2RED_LETTER_SENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).RED_LETTER_SENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></span></td>
                    </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
                    
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                    <tr class="NoRecords">
                        <td colspan="15">No Students with Single Subjects&nbsp;for this Learning Advisor were found!</td>
                    </tr>
                    
  </asp:PlaceHolder>

                    <tr class="Footer">
                        <td style="TEXT-ALIGN: right" colspan="12">&nbsp;</td> 
                        <td style="TEXT-ALIGN: right">
                            <asp:Button id="viewMaintainSearchRequest2Button_Submit" CssClass="Button" Text="Update Standard Learning Programs" CommandName="Submit" runat="server"/></td> 
                        <td style="TEXT-ALIGN: right">&nbsp; 
                            <asp:Button id="viewMaintainSearchRequest2Button_Submit1" CssClass="Button" Text="Update Green Letter" CommandName="Submit" runat="server"/>&nbsp;</td> 
                        <td style="TEXT-ALIGN: right">&nbsp;</td>
                    </tr>
                </table>
                <em>Click the Student ID to go to the Comments for that Student</em></td>
        </tr>
    </table>



  </FooterTemplate>
</asp:repeater>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

