<!--ASPX page @1-ED8B154A-->
    <%@ Page language="vb" CodeFile="Student_SubjectStatus_Maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_SubjectStatus_Maintain.Student_SubjectStatus_MaintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_SubjectStatus_Maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Defaulting Students Status</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-092F8E28
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript" charset="utf-8" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Date Picker Object Definitions @1-959AF67C

var Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE = new Object(); 
Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE.format           = "dd/mm/yy";
Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE.style            = "Styles/Blueprint/Style.css";
Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE.relativePathPart = "";
Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE.themeVersion     = "3.0";
//End Date Picker Object Definitions

//page_Student_SubjectStatus_search_List_Staff_ID_OnChange @80-C2404A5F
function page_Student_SubjectStatus_search_List_Staff_ID_OnChange()
{
    var result;
//End page_Student_SubjectStatus_search_List_Staff_ID_OnChange

//Custom Code @109-2A29BDB7
    // -------------------------
   if (document.getElementById('Student_SubjectStatus_searchList_Staff_ID').value!='')
   {
                        document.getElementById('Student_SubjectStatus_searchhidden_Staff_id').value=document.getElementById('Student_SubjectStatus_searchList_Staff_ID').value;
   }
    // -------------------------
//End Custom Code

//Close page_Student_SubjectStatus_search_List_Staff_ID_OnChange @80-BC33A33A
    return result;
}
//End Close page_Student_SubjectStatus_search_List_Staff_ID_OnChange

//DEL        var txtStatusid= this.id.replace('DEFAULTING_STATUS_DATE','DEFAULTING_STATUS_ID');
//DEL        if (document.getElementById(txtStatusid).value=='')
//DEL                  {
//DEL                          alert('Select Defaulting Status first');
//DEL                          document.getElementById(txtStatusid).focus();
//DEL                  }

//page_Student_SubjectStatus_Result_Button_Submit_OnClick @36-B077D20B
function page_Student_SubjectStatus_Result_Button_Submit_OnClick()
{
    var result;
//End page_Student_SubjectStatus_Result_Button_Submit_OnClick

//Confirmation Message @37-257FDD03
    return confirm('Submit records?');
//End Confirmation Message

//Close page_Student_SubjectStatus_Result_Button_Submit_OnClick @36-BC33A33A
    return result;
}
//End Close page_Student_SubjectStatus_Result_Button_Submit_OnClick

//page_Student_SubjectStatus_Result_DEFAULTING_STATUS_ID_OnChange @55-E27A81CB
function page_Student_SubjectStatus_Result_DEFAULTING_STATUS_ID_OnChange()
{
    var result;
//End page_Student_SubjectStatus_Result_DEFAULTING_STATUS_ID_OnChange

//Custom Code @68-2A29BDB7
    // -------------------------
        // set date to today when status changes
     if(this.value == "A" || this.value == "I") 
         {
                  var TodayDate=new Date();
          var tdate = TodayDate.getDate();
          var month = TodayDate.getMonth()+1;
          var yr = TodayDate.getFullYear().toString();
    
                  if (tdate<10)
                      tdate = "0" + tdate;
                  if (month<10)
                      month = "0" + month;
                  yr= yr.substring(2,4);
        
                  var setDateFormat= tdate + "/" +  month + "/" + yr ;
                  var txtdateid= this.id.replace('DEFAULTING_STATUS_ID','DEFAULTING_STATUS_DATE');
          document.getElementById(txtdateid).value=setDateFormat;
    }
        else
        {
                var txtdateid= this.id.replace('DEFAULTING_STATUS_ID','DEFAULTING_STATUS_DATE');
        document.getElementById(txtdateid).value='';
        }
    // -------------------------
//End Custom Code

//Close page_Student_SubjectStatus_Result_DEFAULTING_STATUS_ID_OnChange @55-BC33A33A
    return result;
}
//End Close page_Student_SubjectStatus_Result_DEFAULTING_STATUS_ID_OnChange

//page_Student_SubjectStatus_Result_WARNING_LETTER_Id_OnChange @87-9C8E60B3
function page_Student_SubjectStatus_Result_WARNING_LETTER_Id_OnChange()
{
    var result;
//End page_Student_SubjectStatus_Result_WARNING_LETTER_Id_OnChange

//Custom Code @118-2A29BDB7
    // -------------------------
        // set date to today when status changes
     if(this.value == "Y" || this.value == "N") 
         {
                        var TodayDate=new Date();
          var tdate = TodayDate.getDate();
          var month = TodayDate.getMonth()+1;
          var yr = TodayDate.getFullYear().toString();
    
          if (tdate<10)
              tdate = "0" + tdate;
          if (month<10)
              month = "0" + month;
          yr= yr.substring(2,4);
          var setDateFormat= tdate + "/" +  month + "/" + yr ;
          var txtdateid= this.id.replace('WARNING_LETTER_Id','WARNING_SENT_DATE');
          document.getElementById(txtdateid).value=setDateFormat;
    }
        else
        {
        var txtdateid= this.id.replace('WARNING_LETTER_Id','WARNING_SENT_DATE');
        document.getElementById(txtdateid).value='';
        }
    // -------------------------
//End Custom Code

//Close page_Student_SubjectStatus_Result_WARNING_LETTER_Id_OnChange @87-BC33A33A
    return result;
}
//End Close page_Student_SubjectStatus_Result_WARNING_LETTER_Id_OnChange

//DEL      // -------------------------
//DEL            var txtStatusid= this.id.replace('DEFAULTING_STATUS_DATE','DEFAULTING_STATUS_ID');
//DEL        if (document.getElementById(txtStatusid).value=='')
//DEL                  {
//DEL                          alert('Select Defaulting Status first');
//DEL                          document.getElementById(txtStatusid).focus();
//DEL                  }
//DEL      // -------------------------

//page_Student_SubjectStatus_Result_Cancel_OnClick @38-50A32E9D
function page_Student_SubjectStatus_Result_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_Student_SubjectStatus_Result_Cancel_OnClick

//bind_events @1-64A2253F
function bind_events() {
    if(typeof(initStudent_SubjectStatus_ResultElements) == "function")
        initStudent_SubjectStatus_ResultElements();
    if(typeof(initStudent_SubjectStatus_ResultElements) == "function"){
        for(var i = 0; i < Student_SubjectStatus_ResultElements.length; i++){
            addEventHandler(Student_SubjectStatus_ResultElements[i][Student_SubjectStatus_ResultWARNING_LETTER_IdID].id, "change", page_Student_SubjectStatus_Result_WARNING_LETTER_Id_OnChange);
        }
    }
    if(typeof(initStudent_SubjectStatus_ResultElements) == "function"){
        for(var i = 0; i < Student_SubjectStatus_ResultElements.length; i++){
            addEventHandler(Student_SubjectStatus_ResultElements[i][Student_SubjectStatus_ResultDEFAULTING_STATUS_IDID].id, "change", page_Student_SubjectStatus_Result_DEFAULTING_STATUS_ID_OnChange);
        }
    }
    if(typeof(Student_SubjectStatus_ResultStaticElementsID) == "object" && typeof(Student_SubjectStatus_ResultStaticElementsID[Student_SubjectStatus_ResultButton_SubmitID]) == "object" && Student_SubjectStatus_ResultStaticElementsID[Student_SubjectStatus_ResultButton_SubmitID]!=null)
        addEventHandler(Student_SubjectStatus_ResultStaticElementsID[Student_SubjectStatus_ResultButton_SubmitID].id, "click", page_Student_SubjectStatus_Result_Button_Submit_OnClick);
    addEventHandler("Student_SubjectStatus_searchList_Staff_ID","change",page_Student_SubjectStatus_search_List_Staff_ID_OnChange);
    addEventHandler("Student_SubjectStatus_ResultCancel","click",page_Student_SubjectStatus_Result_Cancel_OnClick);
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
u.fade  { color: #AEAEAE; text-decoration: line-through; }
-->
</style>

</head>
<body>
<form runat="server">


<p align="center"><DECV_PROD2007:Header id="Header" runat="server"/> </p>
<p align="center">

  <span id="Student_SubjectStatus_searchHolder" runat="server">
    


  <table border="0" cellspacing="0" cellpadding="0" align="center">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Search Students Subject Status</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="Student_SubjectStatus_searchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="Student_SubjectStatus_searchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>STAFF ID</th>
 
            <td><asp:Literal id="Student_SubjectStatus_searchs_Staff_ID" runat="server"/> 
              <select id="Student_SubjectStatus_searchList_Staff_ID" style="WIDTH: 200px"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>SUBJECT ID</th>
 
            <td>
              <select id="Student_SubjectStatus_searchs_STAFF_SUBJECT_ID"  runat="server"></select>
 
              <select id="Student_SubjectStatus_searchselected_STAFF_SUBJECT_ID" style="WIDTH: 310px"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>Defaulting?&nbsp;</th>
 
            <td>
              <asp:RadioButtonList id="Student_SubjectStatus_searchs_DefaultingFlag"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td><a id="Student_SubjectStatus_searchClearParameters" href="" runat="server"  >Clear</a></td> 
            <td align="right">
              <input id='Student_SubjectStatus_searchButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='Student_SubjectStatus_search_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
  
  <input id="Student_SubjectStatus_searchhidden_Staff_id" type="hidden"  runat="server"/>
  



  </span>
  </p>
<div align="center">
  
	<asp:PlaceHolder id="Panel1" Visible="false" runat="server">
	
  <div class="wrapperbox" align="left">
    <div class="success">
      Updates saved Successfully! 
    </div>
  </div>
  <div align="left">
    <br>
    &nbsp; 
  </div>
  
	</asp:PlaceHolder>
	
</div>

<asp:repeater id="Student_SubjectStatus_ResultRepeater" OnItemCommand="Student_SubjectStatus_ResultItemCommand" OnItemDataBound="Student_SubjectStatus_ResultItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript" >
	var Student_SubjectStatus_ResultElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initStudent_SubjectStatus_ResultElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
  <table border="0" cellspacing="0" cellpadding="0" align="center">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Change Defaulting Student's Subject Status</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="Student_SubjectStatus_ResultError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="14"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Row">
            <td colspan="14">Total Records:&nbsp;<asp:Literal id="Student_SubjectStatus_ResultStudent_SubjectStatus_TotalRecords" runat="server"/></td>
          </tr>
 
          <tr class="Caption">
            <th>
            <CC:Sorter id="Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_IDSorter" field="Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_ID" OwnerState="<%# Student_SubjectStatus_ResultData.SortField.ToString()%>" OwnerDir="<%# Student_SubjectStatus_ResultData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_IDSort" runat="server">Subject ID</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_ASSIGNMENT_SUBMISSION_STUDENT_IDSorter" field="Sorter_ASSIGNMENT_SUBMISSION_STUDENT_ID" OwnerState="<%# Student_SubjectStatus_ResultData.SortField.ToString()%>" OwnerDir="<%# Student_SubjectStatus_ResultData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ASSIGNMENT_SUBMISSION_STUDENT_IDSort" runat="server">Student ID</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th>&nbsp;Student Name</th>
 
            <th>&nbsp;</th>
 
            <th>
            <CC:Sorter id="Sorter_SUBJ_ENROL_STATUSSorter" field="Sorter_SUBJ_ENROL_STATUS" OwnerState="<%# Student_SubjectStatus_ResultData.SortField.ToString()%>" OwnerDir="<%# Student_SubjectStatus_ResultData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJ_ENROL_STATUSSort" runat="server">Subject Status</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_ASSMT_SUBMISSIONSSorter" field="Sorter_ASSMT_SUBMISSIONS" OwnerState="<%# Student_SubjectStatus_ResultData.SortField.ToString()%>" OwnerDir="<%# Student_SubjectStatus_ResultData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ASSMT_SUBMISSIONSSort" runat="server">Assignments Submitted</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_DEFAULTING_STATUSSorter" field="Sorter_DEFAULTING_STATUS" OwnerState="<%# Student_SubjectStatus_ResultData.SortField.ToString()%>" OwnerDir="<%# Student_SubjectStatus_ResultData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_DEFAULTING_STATUSSort" runat="server">Send Warning Letter?</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th align="center">&nbsp; 
            <CC:Sorter id="Sorter_DEFAULTING_STATUS_DATESorter" field="Sorter_DEFAULTING_STATUS_DATE" OwnerState="<%# Student_SubjectStatus_ResultData.SortField.ToString()%>" OwnerDir="<%# Student_SubjectStatus_ResultData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_DEFAULTING_STATUS_DATESort" runat="server">'Send Warning Letter'<br>
Last changed Date</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_WARNING_LETTERSorter" field="Sorter_WARNING_LETTER" OwnerState="<%# Student_SubjectStatus_ResultData.SortField.ToString()%>" OwnerDir="<%# Student_SubjectStatus_ResultData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_WARNING_LETTERSort" runat="server">Warning Letter Sent?</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th colspan="5">
            <CC:Sorter id="Sorter_Warning_Sent_DateSorter" field="Sorter_Warning_Sent_Date" OwnerState="<%# Student_SubjectStatus_ResultData.SortField.ToString()%>" OwnerDir="<%# Student_SubjectStatus_ResultData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_Warning_Sent_DateSort" runat="server">Warning Sent Date</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="14"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Row">
            <td><asp:Literal id="Student_SubjectStatus_ResultSS_SUBJECT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Student_SubjectStatus_ResultItem)).SS_SUBJECT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><a id="Student_SubjectStatus_ResultSS_STUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,Student_SubjectStatus_ResultItem)).SS_STUDENT_ID.GetFormattedValue()%></a>&nbsp;<asp:Literal id="Student_SubjectStatus_Resultlabel_ALERTS" runat="server"/></td> 
            <td><asp:Literal id="Student_SubjectStatus_Resultlbl_StudentName" runat="server"/><br>
<a id="Student_SubjectStatus_Resultlbl_StudentEmail" href="" title="create an email to this Student." runat="server"  ><%#(CType(Container.DataItem,Student_SubjectStatus_ResultItem)).lbl_StudentEmail.GetFormattedValue()%></a></td> 
            <td>&nbsp;</td> 
            <td>
              <div align="center">
                <asp:Literal id="Student_SubjectStatus_ResultSUBJ_ENROL_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Student_SubjectStatus_ResultItem)).SUBJ_ENROL_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> 
              </div>
              &nbsp;</td> 
            <td>
              <div align="center">
                <asp:Literal id="Student_SubjectStatus_ResultNUM_OF_ASSIGNMENTS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Student_SubjectStatus_ResultItem)).NUM_OF_ASSIGNMENTS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> <br>
                <asp:Literal id="Student_SubjectStatus_ResultLIST_OF_ASSIGNMENTS" runat="server"/> 
              </div>
              &nbsp;</td> 
            <td>
              <select id="Student_SubjectStatus_ResultDEFAULTING_STATUS_ID"  runat="server"></select>
 
  <input id="Student_SubjectStatus_ResultHidden_DefaultingStatus"  value='<%# (CType(Container.DataItem,Student_SubjectStatus_ResultItem)).Hidden_DefaultingStatus.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
            <td><asp:Literal id="Student_SubjectStatus_ResultlblDefaultingStatusDate" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Student_SubjectStatus_ResultItem)).lblDefaultingStatusDate.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>
  <input id="Student_SubjectStatus_ResultDEFAULTING_STATUS_DATE"  value='<%# (CType(Container.DataItem,Student_SubjectStatus_ResultItem)).DEFAULTING_STATUS_DATE.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
            <td align="center"><asp:Literal id="Student_SubjectStatus_ResultLbl_Warning_Letter" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Student_SubjectStatus_ResultItem)).Lbl_Warning_Letter.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> 
              <select id="Student_SubjectStatus_ResultWARNING_LETTER_Id"  runat="server"></select>
 </td> 
            <td colspan="5" align="center"><asp:Literal id="Student_SubjectStatus_ResultLbl_Warning_Sent_Date" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Student_SubjectStatus_ResultItem)).Lbl_Warning_Sent_Date.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/><asp:TextBox id="Student_SubjectStatus_ResultWARNING_SENT_DATE" Text='<%# (CType(Container.DataItem,Student_SubjectStatus_ResultItem)).WARNING_SENT_DATE.GetFormattedValue() %>' maxlength="100" Columns="10"	runat="server"/>&nbsp; 
              <asp:PlaceHolder id="Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE" runat="server"><a href="javascript:showDatePicker('<%#Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATEName%>','forms[\''+theForm.id+'\']','<%#Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATEDateControl%>');" id="Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE_Link"  ><img id="Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE_Image" border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  </td>
          </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="14">No Defaulting Students found.</td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Footer">
            <td colspan="13">
              
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# Student_SubjectStatus_ResultData.PagesCount%>" PageSize="<%# Student_SubjectStatus_ResultData.RecordsPerPage%>" PageNumber="<%# Student_SubjectStatus_ResultData.PageNumber%>" runat="server">
              Per page: 
              <CC:PageSizer AutoPostBack="true" runat="server" />
 
              <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img border="0" src="Styles/Blueprint/Images/First.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="FirstOff" runat="server"><img border="0" src="Styles/Blueprint/Images/FirstOff.gif"></CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img border="0" src="Styles/Blueprint/Images/Prev.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOff" runat="server"><img border="0" src="Styles/Blueprint/Images/PrevOff.gif"></CC:NavigatorItem><%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
              <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img border="0" src="Styles/Blueprint/Images/Next.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="NextOff" runat="server"><img border="0" src="Styles/Blueprint/Images/NextOff.gif"></CC:NavigatorItem>
              <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img border="0" src="Styles/Blueprint/Images/Last.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="LastOff" runat="server"><img border="0" src="Styles/Blueprint/Images/LastOff.gif"></CC:NavigatorItem></CC:Navigator>
</td> 
            <td>
              <asp:Button id="Student_SubjectStatus_ResultButton_Submit" CssClass="Button" Text="Submit" CommandName="Submit" runat="server"/>
              <asp:Button id="Student_SubjectStatus_ResultCancel" CssClass="Button" Text="Cancel" runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </FooterTemplate>
</asp:repeater>
<DECV_PROD2007:Footer id="Footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

