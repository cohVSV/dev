<!--ASPX page @1-7B5EBA7A-->
    <%@ Page language="vb" CodeFile="Student_Carer_FamilyGrouping.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Carer_FamilyGrouping.Student_Carer_FamilyGroupingPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Carer_FamilyGrouping" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="StudentNamePlate" Src="StudentNamePlate.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Carer - Family Grouping</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_STUDENT_CARER_CONTACT3_Button_Update_OnClick @6-9E3F4781
function page_STUDENT_CARER_CONTACT3_Button_Update_OnClick()
{
    var result;
//End page_STUDENT_CARER_CONTACT3_Button_Update_OnClick

//Confirmation Message @282-8414BA6D
    return confirm('Update Both to This Carer?');
//End Confirmation Message

//Close page_STUDENT_CARER_CONTACT3_Button_Update_OnClick @6-BC33A33A
    return result;
}
//End Close page_STUDENT_CARER_CONTACT3_Button_Update_OnClick

//page_STUDENT_CARER_CONTACT3_Button_Delete_OnClick @7-A519FDB5
function page_STUDENT_CARER_CONTACT3_Button_Delete_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_CARER_CONTACT3_Button_Delete_OnClick

//page_STUDENT_CARER_CONTACT4_Button_Delete_OnClick @102-8F6CBCE0
function page_STUDENT_CARER_CONTACT4_Button_Delete_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_CARER_CONTACT4_Button_Delete_OnClick

//bind_events @1-17335667
function bind_events() {
    addEventHandler("STUDENT_CARER_CONTACT3Button_Update","click",page_STUDENT_CARER_CONTACT3_Button_Update_OnClick);
    addEventHandler("STUDENT_CARER_CONTACT3Button_Delete","click",page_STUDENT_CARER_CONTACT3_Button_Delete_OnClick);
    addEventHandler("STUDENT_CARER_CONTACT4Button_Delete","click",page_STUDENT_CARER_CONTACT4_Button_Delete_OnClick);
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


<p><DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/></p>
<p><DECV_PROD2007:StudentNamePlate id="StudentNamePlate" runat="server"/></p>
<table border="0" width="70%" align="center">
  <tr>
    <td style="WIDTH: 50%" valign="top" align="right">
      
<asp:repeater id="Grid_FamilyGroupRepeater" OnItemCommand="Grid_FamilyGroupItemCommand" OnItemDataBound="Grid_FamilyGroupItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table id="Grid_FamilyGroup" class="MainTable" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td valign="top">
            <table class="Header" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
                <th>Family Group</th>
 
                <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              
  </HeaderTemplate>
  <ItemTemplate>
              
	<asp:PlaceHolder id="Grid_FamilyGroupRowOpenTag" Visible="true" runat="server">
	
              <tr class="Row">
                
	</asp:PlaceHolder>
	
                <td nowrap>
                  
	<asp:PlaceHolder id="Grid_FamilyGroupRowComponents" Visible="true" runat="server">
	<a id="Grid_FamilyGroupSTUDENT_ID" href="" title="show Student Summary" runat="server"  ><%#(CType(Container.DataItem,Grid_FamilyGroupItem)).STUDENT_ID.GetFormattedValue()%></a>&nbsp;&nbsp;&nbsp;&nbsp;<em><asp:Literal id="Grid_FamilyGrouplast_enrol_year" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_FamilyGroupItem)).last_enrol_year.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></em><br>
                  <asp:Literal id="Grid_FamilyGroupfirst_name" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_FamilyGroupItem)).first_name.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="Grid_FamilyGroupsurname" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_FamilyGroupItem)).surname.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> 
	</asp:PlaceHolder>
	</td> 
                
	<asp:PlaceHolder id="Grid_FamilyGroupRowCloseTag" Visible="true" runat="server">
	
              </tr>
 
	</asp:PlaceHolder>
	
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="<CC:AttributeBinder runat='server' Name='numberOfColumns' ContainerId='Grid_FamilyGroupRepeater'/>">No other Students in this Family Group</td>
              </tr>
              
  </asp:PlaceHolder>

            </table>
          </td>
        </tr>
      </table>
      
  </FooterTemplate>
</asp:repeater>
&nbsp;</td> 
    <td style="WIDTH: 50%" valign="top" align="right">
      
  <span id="STUDENT_CARER_CONTACT3Holder" runat="server">
    
      

        <div align="center">
          <table border="0" cellspacing="0" cellpadding="0" width="50%" align="center">
            <tr>
              <td valign="top">
                <table class="Header" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                    <th>Carer for main Student</th>
 
                    <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                  </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                  
  <asp:PlaceHolder id="STUDENT_CARER_CONTACT3Error" visible="False" runat="server">
  
                  <tr class="Error">
                    <td colspan="2"><asp:Label ID="STUDENT_CARER_CONTACT3ErrorLabel" runat="server"/></td>
                  </tr>
                  
  </asp:PlaceHolder>
  
                  <tr class="Controls">
                    <th>Student Name&nbsp;</th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT3Student_Firstname" runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT3Student_Surname" runat="server"/></td>
                  </tr>
 
                  <tr class="Controls">
                    <th>Carer Name</th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT3FIRST_NAME" runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT3SURNAME" runat="server"/></td>
                  </tr>
 
                  <tr class="Controls">
                    <th>RELATIONSHIP</th>
 
                    <td>
                      <select id="STUDENT_CARER_CONTACT3RELATIONSHIP" disabled  runat="server"></select>
 </td>
                  </tr>
 
                  <tr class="Controls">
                    <th>HOME PHONE</th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT3HOME_PHONE" runat="server"/><em></em></td>
                  </tr>
 
                  <tr class="Controls">
                    <th>WORK PHONE</th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT3WORK_PHONE" runat="server"/></td>
                  </tr>
 
                  <tr class="Controls">
                    <th>MOBILE</th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT3MOBILE" runat="server"/></td>
                  </tr>
 
                  <tr class="Controls">
                    <th>EMAIL ADDRESS</th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT3EMAIL" runat="server"/></td>
                  </tr>
 
                  <tr class="Controls">
                    <th>LAST ALTERED BY</th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT3LAST_ALTERED_BY" runat="server"/> / <asp:Literal id="STUDENT_CARER_CONTACT3LAST_ALTERED_DATE" runat="server"/></td>
                  </tr>
 
                  <tr class="Bottom">
                    <td colspan="2" align="right">
                      <input id='STUDENT_CARER_CONTACT3Button_Insert' type="submit" class="Button" value="Add" OnServerClick='STUDENT_CARER_CONTACT3_Insert' runat="server"/>
                      <input id='STUDENT_CARER_CONTACT3Button_Update' type="submit" class="Button" value="Update BOTH Students to THIS Carer" OnServerClick='STUDENT_CARER_CONTACT3_Update' runat="server"/>
                      <input id='STUDENT_CARER_CONTACT3Button_Delete' type="submit" class="Button" value="Delete" OnServerClick='STUDENT_CARER_CONTACT3_Delete' runat="server"/></td>
                  </tr>
                </table>
                
  <input id="STUDENT_CARER_CONTACT3Hidden_STUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CARER_CONTACT3Hidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CARER_CONTACT3Hidden_STUDENT_ID_OTHER" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CARER_CONTACT3Dupe_CARER_ID" type="hidden"  runat="server"/>
  </td>
            </tr>
          </table>
        </div>
      

      
  </span>
  </td> 
    <td style="WIDTH: 50%" valign="top" align="left">
      
  <span id="viewMaintainSearchRequestSearchHolder" runat="server">
    
      

        <table class="MainTable" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td valign="top">
              <table class="Header" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
                  <th>Search </th>
 
                  <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="viewMaintainSearchRequestSearchError" visible="False" runat="server">
  
                <tr id="<%=PageVariables.Get("@error-block")%>" class="Error">
                  <td colspan="2"><asp:Label ID="viewMaintainSearchRequestSearchErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th>SURNAME</th>
 
                  <td><asp:TextBox id="viewMaintainSearchRequestSearchs_SURNAME" maxlength="30" Columns="30"	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th>STUDENT ID</th>
 
                  <td><asp:TextBox id="viewMaintainSearchRequestSearchs_STUDENT_ID" maxlength="12" Columns="12"	runat="server"/></td>
                </tr>
 
                <tr class="Bottom">
                  <td><a id="viewMaintainSearchRequestSearchClearParameters" href="" runat="server"  >Clear</a></td> 
                  <td style="TEXT-ALIGN: right">
                    <input id='viewMaintainSearchRequestSearchButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='viewMaintainSearchRequestSearch_Search' runat="server"/></td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      

      
  </span>
  <br>
      
<asp:repeater id="viewMaintainSearchRequestRepeater" OnItemCommand="viewMaintainSearchRequestItemCommand" OnItemDataBound="viewMaintainSearchRequestItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table id="viewMaintainSearchRequest" class="MainTable" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td valign="top">
            <table class="Header" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
                <th>Other Student to add to Family Group </th>
 
                <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              <tr class="Caption">
                <th>
                <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
                <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
                <th>
                <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
                <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
                <th>
                <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
                <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
                <th>
                <CC:Sorter id="Sorter_YEAR_LEVELSorter" field="Sorter_YEAR_LEVEL" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_YEAR_LEVELSort" runat="server">YEAR LEVEL</asp:LinkButton> 
                <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
                <th>
                <CC:Sorter id="Sorter_ENROLMENT_STATUSSorter" field="Sorter_ENROLMENT_STATUS" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_ENROLMENT_STATUSSort" runat="server">ENROLMENT STATUS</asp:LinkButton> 
                <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
                <th>
                <CC:Sorter id="Sorter_PASTORAL_CARE_IDSorter" field="Sorter_PASTORAL_CARE_ID" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_PASTORAL_CARE_IDSort" runat="server">PASTORAL CARE ID</asp:LinkButton> 
                <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
              </tr>
 
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <td><a id="viewMaintainSearchRequestSTUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,viewMaintainSearchRequestItem)).STUDENT_ID.GetFormattedValue()%></a>&nbsp;</td> 
                <td><asp:Literal id="viewMaintainSearchRequestSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                <td><asp:Literal id="viewMaintainSearchRequestFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                <td style="TEXT-ALIGN: right"><asp:Literal id="viewMaintainSearchRequestYEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                <td><asp:Literal id="viewMaintainSearchRequestENROLMENT_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).ENROLMENT_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                <td><asp:Literal id="viewMaintainSearchRequestPASTORAL_CARE_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).PASTORAL_CARE_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="6">No Student Details found!</td>
              </tr>
              
  </asp:PlaceHolder>

              <tr class="Footer">
                <td colspan="6">
                  
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# viewMaintainSearchRequestData.PagesCount%>" PageSize="<%# viewMaintainSearchRequestData.RecordsPerPage%>" PageNumber="<%# viewMaintainSearchRequestData.PageNumber%>" runat="server"><span class="Navigator">
                  <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">First</asp:LinkButton> </CC:NavigatorItem>
                  <CC:NavigatorItem type="FirstOff" runat="server">First </CC:NavigatorItem>
                  <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">Prev</asp:LinkButton> </CC:NavigatorItem>
                  <CC:NavigatorItem type="PrevOff" runat="server">Prev </CC:NavigatorItem>&nbsp; 
                  
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
                  <PageOnTemplate><asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
                  <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %>&nbsp;</PageOffTemplate></CC:Pager>of &nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
                  <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">Next</asp:LinkButton> </CC:NavigatorItem>
                  <CC:NavigatorItem type="NextOff" runat="server">Next </CC:NavigatorItem>
                  <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">Last</asp:LinkButton> </CC:NavigatorItem>
                  <CC:NavigatorItem type="LastOff" runat="server">Last </CC:NavigatorItem></span></CC:Navigator>
&nbsp;</td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
      
  </FooterTemplate>
</asp:repeater>

      
  <span id="STUDENT_CARER_CONTACT4Holder" runat="server">
    
      

        <div align="center">
          <table style="WIDTH: 50%" border="0" cellspacing="0" cellpadding="0" align="left">
            <tr>
              <td valign="top">
                <table class="Header" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                    <th>Carer for Other Student</th>
 
                    <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                  </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                  
  <asp:PlaceHolder id="STUDENT_CARER_CONTACT4Error" visible="False" runat="server">
  
                  <tr class="Error">
                    <td colspan="2"><asp:Label ID="STUDENT_CARER_CONTACT4ErrorLabel" runat="server"/></td>
                  </tr>
                  
  </asp:PlaceHolder>
  
                  <tr class="Controls">
                    <th>Student Name </th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT4Student_Firstname" runat="server"/> <asp:Literal id="STUDENT_CARER_CONTACT4Student_Surname" runat="server"/></td>
                  </tr>
 
                  <tr class="Controls">
                    <th>Carer Name</th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT4FIRST_NAME" runat="server"/> <asp:Literal id="STUDENT_CARER_CONTACT4SURNAME" runat="server"/></td>
                  </tr>
 
                  <tr class="Controls">
                    <th>RELATIONSHIP</th>
 
                    <td>
                      <select id="STUDENT_CARER_CONTACT4RELATIONSHIP" disabled  runat="server"></select>
 </td>
                  </tr>
 
                  <tr class="Controls">
                    <th>HOME PHONE</th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT4HOME_PHONE" runat="server"/><em></em></td>
                  </tr>
 
                  <tr class="Controls">
                    <th>WORK PHONE</th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT4WORK_PHONE" runat="server"/></td>
                  </tr>
 
                  <tr class="Controls">
                    <th>MOBILE</th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT4MOBILE" runat="server"/></td>
                  </tr>
 
                  <tr class="Controls">
                    <th>EMAIL ADDRESS</th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT4EMAIL" runat="server"/></td>
                  </tr>
 
                  <tr class="Controls">
                    <th>LAST ALTERED BY</th>
 
                    <td><asp:Literal id="STUDENT_CARER_CONTACT4LAST_ALTERED_BY" runat="server"/> / <asp:Literal id="STUDENT_CARER_CONTACT4LAST_ALTERED_DATE" runat="server"/></td>
                  </tr>
 
                  <tr class="Bottom">
                    <td colspan="2" align="right"><asp:Literal id="STUDENT_CARER_CONTACT4lblNoCarer" runat="server"/> 
                      <input id='STUDENT_CARER_CONTACT4Button_Insert' type="submit" class="Button" value="Add" OnServerClick='STUDENT_CARER_CONTACT4_Insert' runat="server"/>
                      <input id='STUDENT_CARER_CONTACT4Button_Update' type="submit" class="Button" value="Update BOTH Students to THIS Carer" OnServerClick='STUDENT_CARER_CONTACT4_Update' runat="server"/>
                      <input id='STUDENT_CARER_CONTACT4Button_Delete' type="submit" class="Button" value="Delete" OnServerClick='STUDENT_CARER_CONTACT4_Delete' runat="server"/></td>
                  </tr>
                </table>
 
                <p>
  <input id="STUDENT_CARER_CONTACT4Hidden_STUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CARER_CONTACT4Hidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CARER_CONTACT4Hidden_STUDENT_ID_OTHER" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CARER_CONTACT4Dupe_CARER_ID" type="hidden"  runat="server"/>
  </p>
              </td>
            </tr>
          </table>
        </div>
      

      
  </span>
  </td>
  </tr>
 
  <tr>
    <td>&nbsp;</td> 
    <td>&nbsp;</td> 
    <td>&nbsp;</td>
  </tr>
</table>

</form>
</body>
</html>

<!--End ASPX page-->

