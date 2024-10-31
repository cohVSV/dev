<!--ASPX page @1-F0D536DB-->
    <%@ Page language="vb" CodeFile="Despatch_UpdatebyYear.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Despatch_UpdatebyYear.Despatch_UpdatebyYearPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Despatch_UpdatebyYear" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Despatch Update by Year</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>&nbsp;</p>
<p align="center">

  <span id="SUBJECTSearchHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>List Subjects</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="SUBJECTSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="SUBJECTSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>YEAR LEVEL</th>
 
            <td>
              <select id="SUBJECTSearchs_YEAR_LEVEL"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='SUBJECTSearchButton_DoSearch' class="Button" type="submit" value="Display Subject List" OnServerClick='SUBJECTSearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  
<p>
<p>

  <span id="UpdateFormHolder" runat="server">
    


  <div align="center">
    <table cellspacing="0" cellpadding="0" align="center" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
              <th>Update Form</th>
 
              <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
            </tr>
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0">
            
  <asp:PlaceHolder id="UpdateFormError" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="2"><asp:Label ID="UpdateFormErrorLabel" runat="server"/></td>
            </tr>
            
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th>
              <p align="right">&nbsp;Year Level</p>
              </th>
 
              <td><asp:Literal id="UpdateFormlblYearLevel2" runat="server"/>&nbsp;</td>
            </tr>
 
            <tr class="Controls">
              <th>
              <p align="right">Despatch Date</p>
              </th>
 
              <td><asp:TextBox id="UpdateFormdespatchdate" maxlength="10" Columns="10"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>
              <p align="right">Book Range</p>
              </th>
 
              <td><asp:TextBox id="UpdateFormbook_range_from" maxlength="2" Columns="2"	runat="server"/>&nbsp;to <asp:TextBox id="UpdateFormbook_range_to" maxlength="2" Columns="2"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>
              <p align="right">&nbsp;Semester</p>
              </th>
 
              <td>1 <asp:CheckBox id="UpdateFormsemester_1" runat="server"/>&nbsp; 2<asp:CheckBox id="UpdateFormsemester_2" runat="server"/>&nbsp;&nbsp;&nbsp;&nbsp; Both<asp:CheckBox id="UpdateFormsemester_both" runat="server"/></td>
            </tr>
 
            <tr class="Bottom">
              <td align="right" colspan="2">
                <input id='UpdateFormButton_DoUpdate' class="Button" type="submit" value="Update" OnServerClick='UpdateForm_Button_DoUpdate_OnClick' runat="server"/></td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </div>
  <p>


<div align="center">
  <asp:Literal id="UpdateFormlblSelections" runat="server"/>
</div>

  </span>
  

<asp:repeater id="SUBJECTRepeater" OnItemCommand="SUBJECTItemCommand" OnItemDataBound="SUBJECTItemDataBound" runat="server">
  <HeaderTemplate>
	
<p>&nbsp;</p>
<table cellspacing="0" cellpadding="0" width="70%" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Grid" cellspacing="0" cellpadding="0" border="0">
        <tr class="Row">
          <td>&nbsp;Despatch Run Update By Year Level <asp:Literal id="SUBJECTlblYearLevel" runat="server"/></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="4">Total Records:&nbsp;<asp:Literal id="SUBJECTSUBJECT_TotalRecords" runat="server"/></td>
        </tr>
 
        <tr class="Caption">
          <th>&nbsp;</th>
 
          <th>Subject ID</th>
 
          <th>Subject Title</th>
 
          <th>Semester</th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr  <CC:AttributeBinder runat="server" Name="rowStyle" ContainerId="SUBJECTRepeater"/>>
          <td style="TEXT-ALIGN: right">&nbsp;<asp:CheckBox id="SUBJECTcbox" runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="SUBJECTSUBJECT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).SUBJECT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="SUBJECTSUBJECT_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).SUBJECT_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="SUBJECTDEFAULT_SEMESTER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).DEFAULT_SEMESTER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="4">No Subjects found</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="4"></td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>

<p></p>
<p><br>
&nbsp;</p>

</form>
</body>
</html>

<!--End ASPX page-->

