<!--ASPX page @1-E9465A9D-->
    <%@ Page language="vb" CodeFile="StudentEnrolment_InitialCheck.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentEnrolment_InitialCheck.StudentEnrolment_InitialCheckPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentEnrolment_InitialCheck" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Enrolment - Initial Check</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @32-962FD0A0
    if (theForm.STUDENTSearchs_SURNAME) theForm.STUDENTSearchs_SURNAME.focus();
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


<p align="center"><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center">

  <span id="STUDENTSearchHolder" runat="server">
    
<div align="left">
  

    <table cellspacing="0" cellpadding="0" align="center" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
              <th>Search Students</th>
 
              <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            </tr>
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0">
            
  <asp:PlaceHolder id="STUDENTSearchError" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="2"><asp:Label ID="STUDENTSearchErrorLabel" runat="server"/></td>
            </tr>
            
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th>SURNAME</th>
 
              <td><asp:TextBox id="STUDENTSearchs_SURNAME" maxlength="30"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>FIRST NAME</th>
 
              <td><asp:TextBox id="STUDENTSearchs_FIRST_NAME" maxlength="30"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>BIRTH DATE</th>
 
              <td><asp:TextBox id="STUDENTSearchs_BIRTH_DATE" maxlength="10" Columns="10"	runat="server"/><em>(dd/mm/yyyy)</em></td>
            </tr>
 
            <tr class="Controls">
              <th>&nbsp;Email</th>
 
              <td><asp:TextBox id="STUDENTSearchs_Email"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th colspan="2">
              <p align="center"><strong><em>Enter ALL fields ABOVE <br>
              <font color="#ff0000">OR</font> </em></strong></p>
              </th>
            </tr>
 
            <tr class="Controls">
              <th>STUDENT ID&nbsp;</th>
 
              <td><asp:TextBox id="STUDENTSearchs_STUDENT_ID" maxlength="10" Columns="10"	runat="server"/>&nbsp;</td>
            </tr>
 
            <tr class="Bottom">
              <td colspan="2" align="right">
                <input id='STUDENTSearchButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='STUDENTSearch_Search' runat="server"/></td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  

</div>
<div align="left">
</div>

  </span>
  
<p></p>

<asp:repeater id="STUDENTRepeater" OnItemCommand="STUDENTItemCommand" OnItemDataBound="STUDENTItemDataBound" runat="server">
  <HeaderTemplate>
	
<p>
<table cellspacing="0" cellpadding="0" width="50%" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>Existing Students</th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="8"><asp:Literal id="STUDENTlblWarningExistingStudent" runat="server"/></td>
        </tr>
 
        <tr class="Caption">
          <th>&nbsp;</th>
 
          <th>Student ID</th>
 
          <th>SURNAME</th>
 
          <th>FIRST NAME</th>
 
          <th>PREFERRED NAME</th>
 
          <th>BIRTH DATE</th>
 
          <th>&nbsp;EMAIL</th>
 
          <th>GENDER</th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr  <CC:AttributeBinder runat="server" Name="rowStyle" ContainerId="STUDENTRepeater"/>>
          <td style="TEXT-ALIGN: right"><a id="STUDENTLink1" href="" runat="server"  >Add New Year</a>&nbsp;</td> 
          <td style="TEXT-ALIGN: right">
            <div align="left">
              <asp:Literal id="STUDENTSTUDENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENTItem)).STUDENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
            </div>
          </td> 
          <td><asp:Literal id="STUDENTSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENTItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENTFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENTItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENTPREFERRED_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENTItem)).PREFERRED_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><asp:Literal id="STUDENTBIRTH_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENTItem)).BIRTH_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>&nbsp;<asp:Literal id="STUDENTEMAIL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENTItem)).EMAIL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><asp:Literal id="STUDENTSEX" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENTItem)).SEX.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="8">Student Not Previously Enrolled&nbsp;&nbsp;<a id="STUDENTlink_AddNewStudent" href="" runat="server"  >Add New Student</a></td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="8">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STUDENTData.PagesCount%>" PageSize="<%# STUDENTData.RecordsPerPage%>" PageNumber="<%# STUDENTData.PageNumber%>" runat="server">
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img border="0" src="Styles/Blueprint/Images/en/ButtonPrev.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server"><img border="0" src="Styles/Blueprint/Images/en/ButtonPrevOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img border="0" src="Styles/Blueprint/Images/en/ButtonNext.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server"><img border="0" src="Styles/Blueprint/Images/en/ButtonNextOff.gif"></CC:NavigatorItem></CC:Navigator>
</td>
        </tr>
      </table>
 
      <p>&nbsp;</p>
 
      <p><strong style="color: red;"><asp:Literal id="STUDENTLabel1" runat="server"/></strong><a id="STUDENTlink_AddNewStudent1" href="" runat="server"  >Add New Student</a></p>
 
      <p>&nbsp;</p>
    </td>
  </tr>
</table>
&nbsp;L
  </FooterTemplate>
</asp:repeater>
</p>
<p><br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

