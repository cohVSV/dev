<!--ASPX page @1-61964177-->
    <%@ Page language="vb" CodeFile="StudentAmendment.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentAmendment.StudentAmendmentPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentAmendment" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Amendment - Search</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
function OpenPopUpList()
{
        var FieldName;
        FieldName = "TeacherAllocations_Searchs_STUDENT_ID_lowest";
        var win=window.open("popup_SubjectList.aspx?returncontrol="+FieldName, "SubjectList", "left=40,top=10,width=350,height=480,status=no,toolbar=no,menubar=no,location=no,scrollbars=yes");
        win.focus();
}

</script>
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

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @18-109CDAC8
    if (theForm.TeacherAllocations_Searchs_STUDENT_ID_lowest) theForm.TeacherAllocations_Searchs_STUDENT_ID_lowest.focus();
//End Set Focus

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//bind_events @1-B716D3FC
function bind_events() {
    page_OnLoad();
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

  <span id="TeacherAllocations_SearchHolder" runat="server">
    


  <div align="center">
    <table cellspacing="0" cellpadding="0" width="60%" align="center" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
              <th>Student Amendment</th>
 
              <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
            </tr>
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0">
            
  <asp:PlaceHolder id="TeacherAllocations_SearchError" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="2"><asp:Label ID="TeacherAllocations_SearchErrorLabel" runat="server"/></td>
            </tr>
            
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th><strong>Enter lowest Student ID</strong></th>
 
              <td><asp:TextBox id="TeacherAllocations_Searchs_STUDENT_ID_lowest" maxlength="10" Columns="6"	runat="server"/>&nbsp;with 
                <select id="TeacherAllocations_SearchlistRowsPerPage"  runat="server"></select>
 &nbsp;rows</td>
            </tr>
 
            <tr class="Controls">
              <th><strong>&nbsp;<em>Optional Parameters</em></strong></th>
 
              <td>&nbsp;</td>
            </tr>
 
            <tr class="Controls">
              <th><strong>Year Level</strong></th>
 
              <td>
                <select id="TeacherAllocations_Searchs_YEAR_LEVEL"  runat="server"></select>
 (optional)</td>
            </tr>
 
            <tr class="Controls">
              <th><strong>Student</strong></th>
 
              <td>
                <asp:RadioButtonList id="TeacherAllocations_Searchs_SUBJ_ENROL_STATUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th><strong>Enrolment Year</strong></th>
 
              <td><asp:TextBox id="TeacherAllocations_Searchs_ENROLMENT_YEAR" maxlength="4" Columns="4"	runat="server"/></td>
            </tr>
 
            <tr class="Bottom">
              <td align="right" colspan="2">
                <input id='TeacherAllocations_SearchButton_DoSearch' class="Button" type="submit" value="Search" OnServerClick='TeacherAllocations_Search_Search' runat="server"/></td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </div>



  </span>
  <br>

</form>
</body>
</html>

<!--End ASPX page-->

