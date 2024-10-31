<!--ASPX page @1-D0252AFC-->
    <%@ Page language="vb" CodeFile="Staff_Inductions_ByCourse.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Staff_Inductions_ByCourse.Staff_Inductions_ByCoursePage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Staff_Inductions_ByCourse" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Staff Inductions - By Course</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-B52976BB
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="utf-8"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Date Picker Object Definitions @1-3A4616CF

var STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED = new Object(); 
STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED.format           = "dd/mm/yyyy";
STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED.style            = "Styles/Blueprint/Style.css";
STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED.relativePathPart = "";
STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED.themeVersion     = "3.0";
//End Date Picker Object Definitions

//page_STAFF_INDUCTIONS_COURSES1_Button_Cancel_OnClick @24-88302EFF
function page_STAFF_INDUCTIONS_COURSES1_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STAFF_INDUCTIONS_COURSES1_Button_Cancel_OnClick

//page_STAFF_INDUCTIONS_PROGRESS_Cancel_OnClick @54-C424F40B
function page_STAFF_INDUCTIONS_PROGRESS_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STAFF_INDUCTIONS_PROGRESS_Cancel_OnClick

//bind_events @1-A433CB67
function bind_events() {
    addEventHandler("STAFF_INDUCTIONS_COURSES1Button_Cancel","click",page_STAFF_INDUCTIONS_COURSES1_Button_Cancel_OnClick);
    addEventHandler("STAFF_INDUCTIONS_PROGRESSCancel","click",page_STAFF_INDUCTIONS_PROGRESS_Cancel_OnClick);
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
<p>&nbsp; 
<table style="WIDTH: 80%" align="center" border="0">
  <tr valign="top">
    <td width="50%">&nbsp; 
      
  <span id="STAFF_INDUCTIONS_COURSESSearchHolder" runat="server">
    
      

        <table cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
                  <th>Search Induction Courses</th>
 
                  <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="STAFF_INDUCTIONS_COURSESSearchError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="STAFF_INDUCTIONS_COURSESSearchErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th>Keyword</th>
 
                  <td><asp:TextBox id="STAFF_INDUCTIONS_COURSESSearchs_keyword" maxlength="50" Columns="30"	runat="server"/></td>
                </tr>
 
                <tr class="Bottom">
                  <td><a id="STAFF_INDUCTIONS_COURSESSearchClearParameters" href="" runat="server"  >Clear</a></td> 
                  <td align="right">
                    <input id='STAFF_INDUCTIONS_COURSESSearchButton_DoSearch' class="Button" type="submit" value="Search" OnServerClick='STAFF_INDUCTIONS_COURSESSearch_Search' runat="server"/></td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      

      
  </span>
  
      <div align="right">
      </div>
 
      <div align="right">
        &nbsp;
      </div>
      <br>
      
<asp:repeater id="STAFF_INDUCTIONS_COURSESRepeater" OnItemCommand="STAFF_INDUCTIONS_COURSESItemCommand" OnItemDataBound="STAFF_INDUCTIONS_COURSESItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
                <th>List of Induction Courses </th>
 
                <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              <tr class="Row">
                <td colspan="3">Total Records:&nbsp;<asp:Literal id="STAFF_INDUCTIONS_COURSESSTAFF_INDUCTIONS_COURSES_TotalRecords" runat="server"/></td>
              </tr>
 
              <tr class="Caption">
                <th>
                <CC:Sorter id="Sorter_idSorter" field="Sorter_id" OwnerState="<%# STAFF_INDUCTIONS_COURSESData.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_idSort" runat="server">Id</asp:LinkButton> 
                <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
                <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
                <th>
                <CC:Sorter id="Sorter_INDUCTION_TITLESorter" field="Sorter_INDUCTION_TITLE" OwnerState="<%# STAFF_INDUCTIONS_COURSESData.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_INDUCTION_TITLESort" runat="server">INDUCTION TITLE</asp:LinkButton> 
                <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
                <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
                <th>
                <CC:Sorter id="Sorter_STATUSSorter" field="Sorter_STATUS" OwnerState="<%# STAFF_INDUCTIONS_COURSESData.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STATUSSort" runat="server">STATUS</asp:LinkButton> 
                <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
                <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
              </tr>
 
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <td style="TEXT-ALIGN: right"><a id="STAFF_INDUCTIONS_COURSESid" href="" runat="server"  ><%#(CType(Container.DataItem,STAFF_INDUCTIONS_COURSESItem)).id.GetFormattedValue()%></a>&nbsp;</td> 
                <td><asp:Literal id="STAFF_INDUCTIONS_COURSESINDUCTION_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSESItem)).INDUCTION_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                <td style="TEXT-ALIGN: right"><asp:Literal id="STAFF_INDUCTIONS_COURSESSTATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSESItem)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="3">No Induction Courses found</td>
              </tr>
              
  </asp:PlaceHolder>

              <tr class="Footer">
                <td colspan="3"><a id="STAFF_INDUCTIONS_COURSESLink1" href="" class="Button" runat="server"  >Add New Course</a> 
                  
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STAFF_INDUCTIONS_COURSESData.PagesCount%>" PageSize="<%# STAFF_INDUCTIONS_COURSESData.RecordsPerPage%>" PageNumber="<%# STAFF_INDUCTIONS_COURSESData.PageNumber%>" runat="server">
                  <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src="Styles/Blueprint/Images/First.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
                  <CC:NavigatorItem type="FirstOff" runat="server"><img src="Styles/Blueprint/Images/FirstOff.gif" border="0"></CC:NavigatorItem>
                  <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
                  <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/PrevOff.gif" border="0"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
                  <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src="Styles/Blueprint/Images/Next.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
                  <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/NextOff.gif" border="0"></CC:NavigatorItem>
                  <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src="Styles/Blueprint/Images/Last.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
                  <CC:NavigatorItem type="LastOff" runat="server"><img src="Styles/Blueprint/Images/LastOff.gif" border="0"></CC:NavigatorItem></CC:Navigator>
&nbsp;</td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
      
  </FooterTemplate>
</asp:repeater>
<br>
    </td> 
    <td width="50%">&nbsp; 
      
  <span id="STAFF_INDUCTIONS_COURSES1Holder" runat="server">
    
      

        <table cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
                  <th>Add/Edit Induction Courses</th>
 
                  <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="STAFF_INDUCTIONS_COURSES1Error" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="STAFF_INDUCTIONS_COURSES1ErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th>TITLE</th>
 
                  <td><asp:TextBox id="STAFF_INDUCTIONS_COURSES1INDUCTION_TITLE" maxlength="50" Columns="50"	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th>DESCRIPTION</th>
 
                  <td>
<asp:TextBox id="STAFF_INDUCTIONS_COURSES1INDUCTION_DESCRIPTION" rows="3" Columns="50" TextMode="MultiLine"	runat="server"/>
</td>
                </tr>
 
                <tr class="Controls">
                  <th>STATUS</th>
 
                  <td>
                    <asp:RadioButtonList id="STAFF_INDUCTIONS_COURSES1STATUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th>LAST ALTERED BY / DATE</th>
 
                  <td><asp:Literal id="STAFF_INDUCTIONS_COURSES1LAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STAFF_INDUCTIONS_COURSES1LAST_ALTERED_DATE" runat="server"/></td>
                </tr>
 
                <tr class="Bottom">
                  <td align="right" colspan="2">
                    <input id='STAFF_INDUCTIONS_COURSES1Button_Insert' class="Button" type="submit" value="Add" OnServerClick='STAFF_INDUCTIONS_COURSES1_Insert' runat="server"/>
                    <input id='STAFF_INDUCTIONS_COURSES1Button_Update' class="Button" type="submit" value="Save" OnServerClick='STAFF_INDUCTIONS_COURSES1_Update' runat="server"/>
                    <input id='STAFF_INDUCTIONS_COURSES1Button_Cancel' class="Button" type="submit" value="Cancel" OnServerClick='STAFF_INDUCTIONS_COURSES1_Cancel' runat="server"/></td>
                </tr>
              </table>
              
  <input id="STAFF_INDUCTIONS_COURSES1Hidden_last_altered_by" type="hidden"  runat="server"/>
  
  <input id="STAFF_INDUCTIONS_COURSES1Hidden_last_altered_date" type="hidden"  runat="server"/>
  </td>
          </tr>
        </table>
      

      
  </span>
  <br>
      
<asp:repeater id="STAFF_INDUCTIONS_PROGRESSRepeater" OnItemCommand="STAFF_INDUCTIONS_PROGRESSItemCommand" OnItemDataBound="STAFF_INDUCTIONS_PROGRESSItemDataBound" runat="server">
  <HeaderTemplate>
  
      

        
	<script language="JavaScript" >
	var STAFF_INDUCTIONS_PROGRESSElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initSTAFF_INDUCTIONS_PROGRESSElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
        <table cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
                  <th>Staff Completion of Inductions</th>
 
                  <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
                </tr>
              </table>
 
              <table class="Grid" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="STAFF_INDUCTIONS_PROGRESSError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="5"><asp:Label ID="ErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Row">
                  <td colspan="5">Total Records:&nbsp;<asp:Literal id="STAFF_INDUCTIONS_PROGRESSSTAFF_INDUCTIONS_PROGRESS_TotalRecords" runat="server"/></td>
                </tr>
 
                <tr class="Caption">
                  <th>
                  <CC:Sorter id="Sorter_STAFF_IDSorter" field="Sorter_STAFF_ID" OwnerState="<%# STAFF_INDUCTIONS_PROGRESSData.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_PROGRESSData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STAFF_IDSort" runat="server">STAFF ID</asp:LinkButton> 
                  <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
                  <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
                  <th>
                  <CC:Sorter id="Sorter_STATUSSorter" field="Sorter_STATUS" OwnerState="<%# STAFF_INDUCTIONS_PROGRESSData.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_PROGRESSData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STATUSSort" runat="server">STATUS</asp:LinkButton> 
                  <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
                  <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
                  <th>
                  <CC:Sorter id="Sorter_DATE_COMPLETEDSorter" field="Sorter_DATE_COMPLETED" OwnerState="<%# STAFF_INDUCTIONS_PROGRESSData.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_PROGRESSData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_DATE_COMPLETEDSort" runat="server">DATE COMPLETED</asp:LinkButton> 
                  <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
                  <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
                  <th colspan="2">Delete</th>
                </tr>
 
                
  </HeaderTemplate>
  <ItemTemplate>
    
                
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
                <tr class="Error">
                  <td colspan="5"><asp:Label ID="ErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>

                <tr class="Row">
                  <td>
                    <select id="STAFF_INDUCTIONS_PROGRESSSTAFF_ID"  runat="server"></select>
 </td> 
                  <td>
                    <select id="STAFF_INDUCTIONS_PROGRESSSTATUS"  runat="server"></select>
 </td> 
                  <td><asp:TextBox id="STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED" Text='<%# (CType(Container.DataItem,STAFF_INDUCTIONS_PROGRESSItem)).DATE_COMPLETED.GetFormattedValue() %>' maxlength="100" Columns="10"	runat="server"/>
                    <asp:PlaceHolder id="STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED" runat="server"><a href="javascript:showDatePicker('<%#STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETEDName%>','forms[\''+theForm.id+'\']','<%#STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETEDDateControl%>');" id="STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED_Link"  ><img id="STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED_Image" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" border="0" /></a></asp:PlaceHolder>
  
  <input id="STAFF_INDUCTIONS_PROGRESSinduction_id"  value='<%# (CType(Container.DataItem,STAFF_INDUCTIONS_PROGRESSItem)).induction_id.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
                  <td colspan="2">
                    <asp:CheckBox id="STAFF_INDUCTIONS_PROGRESSCheckBox_Delete" Visible = "<%# (CType(Container.DataItem,STAFF_INDUCTIONS_PROGRESSItem)).IsDeleteAllowed %>" runat="server"/>&nbsp;</td>
                </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
                
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                <tr class="NoRecords">
                  <td colspan="5">No Staff / Induction Details found</td>
                </tr>
                
  </asp:PlaceHolder>

                <tr class="Footer">
                  <td style="TEXT-ALIGN: right" colspan="5">
                    
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STAFF_INDUCTIONS_PROGRESSData.PagesCount%>" PageSize="<%# STAFF_INDUCTIONS_PROGRESSData.RecordsPerPage%>" PageNumber="<%# STAFF_INDUCTIONS_PROGRESSData.PageNumber%>" runat="server">
                    Per page: 
                    <CC:PageSizer AutoPostBack="true" runat="server" />
 
                    <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src="Styles/Blueprint/Images/First.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
                    <CC:NavigatorItem type="FirstOff" runat="server"><img src="Styles/Blueprint/Images/FirstOff.gif" border="0"></CC:NavigatorItem>
                    <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
                    <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/PrevOff.gif" border="0"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
                    <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src="Styles/Blueprint/Images/Next.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
                    <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/NextOff.gif" border="0"></CC:NavigatorItem>
                    <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src="Styles/Blueprint/Images/Last.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
                    <CC:NavigatorItem type="LastOff" runat="server"><img src="Styles/Blueprint/Images/LastOff.gif" border="0"></CC:NavigatorItem></CC:Navigator>

                    <asp:Button id="STAFF_INDUCTIONS_PROGRESSButton_Submit" CssClass="Button" Text="Submit" CommandName="Submit" runat="server"/>
                    <asp:Button id="STAFF_INDUCTIONS_PROGRESSCancel" CssClass="Button" Text="Cancel" runat="server"/></td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      

      
  </FooterTemplate>
</asp:repeater>
<br>
    </td>
  </tr>
</table>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

