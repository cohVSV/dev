<!--ASPX page @1-BA1810F5-->
    <%@ Page language="vb" CodeFile="FutureEnrol_searchlist.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.FutureEnrol_searchlist.FutureEnrol_searchlistPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.FutureEnrol_searchlist" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="description" content="Search and List of Future enrolments to find existing and links to the student special Future admin page. Nov 2018"><meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Future Enrol - Search and List</title>



<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_STUDENT_ENROLMENT_STUDENT1_OnLoad @38-A138F3FB
function page_STUDENT_ENROLMENT_STUDENT1_OnLoad(form)
{
    var result;
//End page_STUDENT_ENROLMENT_STUDENT1_OnLoad

//Set Focus @73-39A1CE4D
    if (theForm.STUDENT_ENROLMENT_STUDENT1s_SURNAME) theForm.STUDENT_ENROLMENT_STUDENT1s_SURNAME.focus();
//End Set Focus

//Close page_STUDENT_ENROLMENT_STUDENT1_OnLoad @38-BC33A33A
    return result;
}
//End Close page_STUDENT_ENROLMENT_STUDENT1_OnLoad

//bind_events @1-0E32D934
function bind_events() {
    if(document.getElementById("STUDENT_ENROLMENT_STUDENT1Holder"))
    addEventHandler("STUDENT_ENROLMENT_STUDENT1","load",page_STUDENT_ENROLMENT_STUDENT1_OnLoad);
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
<table class="MainTable" cellspacing="0" cellpadding="0" width="90%" border="0">
  <tr>
    <td valign="top">
      
  <span id="STUDENT_ENROLMENT_STUDENT1Holder" runat="server">
    
      

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
                
  <asp:PlaceHolder id="STUDENT_ENROLMENT_STUDENT1Error" visible="False" runat="server">
  
                <tr id="<%=PageVariables.Get("@error-block")%>" class="Error">
                  <td colspan="2"><asp:Label ID="STUDENT_ENROLMENT_STUDENT1ErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th>NAME<em>(any part)</em></th>
 
                  <td><asp:TextBox id="STUDENT_ENROLMENT_STUDENT1s_SURNAME" maxlength="30"	runat="server"/>&nbsp;<em>or</em></td>
                </tr>
 
                <tr class="Controls">
                  <th>STUDENT ID</th>
 
                  <td><asp:TextBox id="STUDENT_ENROLMENT_STUDENT1s_STUDENT_ID" maxlength="12" Columns="12"	runat="server"/></td>
                </tr>
 
                <tr class="Bottom">
                  <td><a id="STUDENT_ENROLMENT_STUDENT1ClearParameters" href="" runat="server"  >Clear</a></td> 
                  <td style="TEXT-ALIGN: right">
                    <input id='STUDENT_ENROLMENT_STUDENT1Button_DoSearch' type="submit" class="Button" value="Search" OnServerClick='STUDENT_ENROLMENT_STUDENT1_Search' runat="server"/></td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      

      
  </span>
  <br>
    </td> 
    <td valign="top">
      
  <span id="STUDENTSearchHolder" runat="server">
    
      <div align="left">
        

          <table cellspacing="0" cellpadding="0" align="center" border="0">
            <tr>
              <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                  <tr>
                    <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                    <th>Search and Add&nbsp;Student</th>
 
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
                    <th>Enrol Year&nbsp;</th>
 
                    <td><asp:TextBox id="STUDENTSearchs_ENROL_YEAR" Columns="5"	runat="server"/>&nbsp;</td>
                  </tr>
 
                  <tr class="Controls">
                    <th colspan="2">
                    <p align="center"><strong><em>Enter ALL fields ABOVE </em></strong></p>
                    </th>
                  </tr>
 
                  <tr class="Bottom">
                    <td colspan="2" align="right">
                      <input id='STUDENTSearchButton_DoSearch' type="submit" class="Button" value="Search and Add" OnServerClick='STUDENTSearch_Insert' runat="server"/></td>
                  </tr>
                </table>
                
  <input id="STUDENTSearchHidden_NewStudentID" type="hidden"  runat="server"/>
  </td>
            </tr>
          </table>
        

      </div>
 
      <div align="left">
      </div>
      
  </span>
  </td>
  </tr>
</table>
</p>
<p align="center">&nbsp;</p>
<p align="center">

<asp:repeater id="STUDENT_ENROLMENT_STUDENTRepeater" OnItemCommand="STUDENT_ENROLMENT_STUDENTItemCommand" OnItemDataBound="STUDENT_ENROLMENT_STUDENTItemDataBound" runat="server">
  <HeaderTemplate>
	
<table id="STUDENT_ENROLMENT_STUDENT" class="MainTable" cellspacing="0" cellpadding="0" width="80%" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>List of Future Student Enrolments </th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="6">Total Records:&nbsp;<asp:Literal id="STUDENT_ENROLMENT_STUDENTSTUDENT_ENROLMENT_STUDENT_TotalRecords" runat="server"/></td> 
          <td></td>
        </tr>
 
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_STUDENT_STUDENT_IDSorter" field="Sorter_STUDENT_STUDENT_ID" OwnerState="<%# STUDENT_ENROLMENT_STUDENTData.SortField.ToString()%>" OwnerDir="<%# STUDENT_ENROLMENT_STUDENTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_STUDENT_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# STUDENT_ENROLMENT_STUDENTData.SortField.ToString()%>" OwnerDir="<%# STUDENT_ENROLMENT_STUDENTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# STUDENT_ENROLMENT_STUDENTData.SortField.ToString()%>" OwnerDir="<%# STUDENT_ENROLMENT_STUDENTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_CATEGORY_CODESorter" field="Sorter_CATEGORY_CODE" OwnerState="<%# STUDENT_ENROLMENT_STUDENTData.SortField.ToString()%>" OwnerDir="<%# STUDENT_ENROLMENT_STUDENTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_CATEGORY_CODESort" runat="server">CATEGORY CODE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_YEAR_LEVELSorter" field="Sorter_YEAR_LEVEL" OwnerState="<%# STUDENT_ENROLMENT_STUDENTData.SortField.ToString()%>" OwnerDir="<%# STUDENT_ENROLMENT_STUDENTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_YEAR_LEVELSort" runat="server">YEAR LEVEL</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_ENROLMENT_DATESorter" field="Sorter_ENROLMENT_DATE" OwnerState="<%# STUDENT_ENROLMENT_STUDENTData.SortField.ToString()%>" OwnerDir="<%# STUDENT_ENROLMENT_STUDENTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_ENROLMENT_DATESort" runat="server">ENROLMENT DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_ENROLMENT_YEARSorter" field="Sorter_ENROLMENT_YEAR" OwnerState="<%# STUDENT_ENROLMENT_STUDENTData.SortField.ToString()%>" OwnerDir="<%# STUDENT_ENROLMENT_STUDENTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_ENROLMENT_YEARSort" runat="server">ENROLMENT YEAR</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="STUDENT_ENROLMENT_STUDENTSTUDENT_STUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,STUDENT_ENROLMENT_STUDENTItem)).STUDENT_STUDENT_ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_ENROLMENT_STUDENTFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_ENROLMENT_STUDENTItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_ENROLMENT_STUDENTSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_ENROLMENT_STUDENTItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_ENROLMENT_STUDENTCATEGORY_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_ENROLMENT_STUDENTItem)).CATEGORY_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="STUDENT_ENROLMENT_STUDENTYEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_ENROLMENT_STUDENTItem)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_ENROLMENT_STUDENTENROLMENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_ENROLMENT_STUDENTItem)).ENROLMENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_ENROLMENT_STUDENTENROLMENT_YEAR" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_ENROLMENT_STUDENTItem)).ENROLMENT_YEAR.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="7">No Future Students found!</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="7">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STUDENT_ENROLMENT_STUDENTData.PagesCount%>" PageSize="<%# STUDENT_ENROLMENT_STUDENTData.RecordsPerPage%>" PageNumber="<%# STUDENT_ENROLMENT_STUDENTData.PageNumber%>" runat="server"><span class="Navigator">Records per page 
            <CC:PageSizer AutoPostBack="true" runat="server" />
 
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src="Styles/Blueprint/Images/First.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server"><img src="Styles/Blueprint/Images/FirstOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/PrevOff.gif"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src="Styles/Blueprint/Images/Next.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/NextOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src="Styles/Blueprint/Images/Last.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server"><img src="Styles/Blueprint/Images/LastOff.gif"></CC:NavigatorItem></span></CC:Navigator>
&nbsp;</td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
</p>
<p align="center"><br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

