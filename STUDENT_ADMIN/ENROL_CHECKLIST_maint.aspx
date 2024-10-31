<!--ASPX page @1-949A4689-->
    <%@ Page language="vb" CodeFile="ENROL_CHECKLIST_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.ENROL_CHECKLIST_maint.ENROL_CHECKLIST_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.ENROL_CHECKLIST_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta name="description" content="Admin page for managing the Enrolment Checklist items. Nov 2018"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>ENROL CHECKLIST maint</title>



<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>

  <span id="ENROL_CHECKLISTSearchHolder" runat="server">
    


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
          
  <asp:PlaceHolder id="ENROL_CHECKLISTSearchError" visible="False" runat="server">
  
          <tr id="<%=PageVariables.Get("@error-block")%>" class="Error">
            <td colspan="2"><asp:Label ID="ENROL_CHECKLISTSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Keyword</th>
 
            <td><asp:TextBox id="ENROL_CHECKLISTSearchs_keyword" maxlength="200"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td><a id="ENROL_CHECKLISTSearchClearParameters" href="" runat="server"  >Clear</a></td> 
            <td style="TEXT-ALIGN: right">
              <input id='ENROL_CHECKLISTSearchButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='ENROL_CHECKLISTSearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>
<br>

<asp:repeater id="ENROL_CHECKLISTRepeater" OnItemCommand="ENROL_CHECKLISTItemCommand" OnItemDataBound="ENROL_CHECKLISTItemDataBound" runat="server">
  <HeaderTemplate>
	
<table id="ENROL_CHECKLIST" class="MainTable" cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>List of ENROL CHECKLIST Items </th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="6">Total Records:&nbsp;<asp:Literal id="ENROL_CHECKLISTENROL_CHECKLIST_TotalRecords" runat="server"/></td>
        </tr>
 
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_IDSorter" field="Sorter_ID" OwnerState="<%# ENROL_CHECKLISTData.SortField.ToString()%>" OwnerDir="<%# ENROL_CHECKLISTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_IDSort" runat="server">ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_DESCRIPTIONSorter" field="Sorter_DESCRIPTION" OwnerState="<%# ENROL_CHECKLISTData.SortField.ToString()%>" OwnerDir="<%# ENROL_CHECKLISTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_DESCRIPTIONSort" runat="server">DESCRIPTION</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_CATEGORIES_REQUIREDSorter" field="Sorter_CATEGORIES_REQUIRED" OwnerState="<%# ENROL_CHECKLISTData.SortField.ToString()%>" OwnerDir="<%# ENROL_CHECKLISTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_CATEGORIES_REQUIREDSort" runat="server">CATEGORIES REQUIRED</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_ACTIVESorter" field="Sorter_ACTIVE" OwnerState="<%# ENROL_CHECKLISTData.SortField.ToString()%>" OwnerDir="<%# ENROL_CHECKLISTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_ACTIVESort" runat="server">ACTIVE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# ENROL_CHECKLISTData.SortField.ToString()%>" OwnerDir="<%# ENROL_CHECKLISTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# ENROL_CHECKLISTData.SortField.ToString()%>" OwnerDir="<%# ENROL_CHECKLISTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><a id="ENROL_CHECKLISTID" href="" runat="server"  ><%#(CType(Container.DataItem,ENROL_CHECKLISTItem)).ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="ENROL_CHECKLISTDESCRIPTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROL_CHECKLISTItem)).DESCRIPTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ENROL_CHECKLISTCATEGORIES_REQUIRED" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROL_CHECKLISTItem)).CATEGORIES_REQUIRED.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ENROL_CHECKLISTACTIVE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROL_CHECKLISTItem)).ACTIVE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ENROL_CHECKLISTLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROL_CHECKLISTItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ENROL_CHECKLISTLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROL_CHECKLISTItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="6">No Enrol Checklist items found!</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="6"><a id="ENROL_CHECKLISTENROL_CHECKLIST_Insert" href="" runat="server"  >Add New</a>&nbsp; 
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# ENROL_CHECKLISTData.PagesCount%>" PageSize="<%# ENROL_CHECKLISTData.RecordsPerPage%>" PageNumber="<%# ENROL_CHECKLISTData.PageNumber%>" runat="server"><span class="Navigator">
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
<br>

  <span id="ENROL_CHECKLIST1Holder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Add/Edit ENROL CHECKLIST Item</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="ENROL_CHECKLIST1Error" visible="False" runat="server">
  
          <tr id="ErrorBlock" class="Error">
            <td colspan="2"><asp:Label ID="ENROL_CHECKLIST1ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>DESCRIPTION</th>
 
            <td><asp:TextBox id="ENROL_CHECKLIST1DESCRIPTION" maxlength="200" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>CATEGORIES REQUIRED</th>
 
            <td><asp:TextBox id="ENROL_CHECKLIST1CATEGORIES_REQUIRED" maxlength="100" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>CATEGORIES OPTIONAL</th>
 
            <td><asp:TextBox id="ENROL_CHECKLIST1CATEGORIES_OPTIONAL" maxlength="100" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>CATEGORIES NOTAPPLICABLE</th>
 
            <td><asp:TextBox id="ENROL_CHECKLIST1CATEGORIES_NOTAPPLICABLE" maxlength="100" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>ACTIVE</th>
 
            <td>
              <asp:RadioButtonList id="ENROL_CHECKLIST1ACTIVE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / WHEN&nbsp;</th>
 
            <td><asp:Literal id="ENROL_CHECKLIST1lblLastAlteredBy" runat="server"/>&nbsp;/ <asp:Literal id="ENROL_CHECKLIST1lblLastAlteredWhen" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td style="TEXT-ALIGN: right" colspan="2">
              <input id='ENROL_CHECKLIST1Button_Insert' type="submit" class="Button" value="Add Item" OnServerClick='ENROL_CHECKLIST1_Insert' runat="server"/>
              <input id='ENROL_CHECKLIST1Button_Update' type="submit" class="Button" value="Update Item" OnServerClick='ENROL_CHECKLIST1_Update' runat="server"/>
              <input id='ENROL_CHECKLIST1Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='ENROL_CHECKLIST1_Cancel' runat="server"/>
  <input id="ENROL_CHECKLIST1LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="ENROL_CHECKLIST1LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>
<br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

