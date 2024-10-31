<!--ASPX page @1-EB7B9124-->
    <%@ Page language="vb" CodeFile="SUBJECT_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.SUBJECT_list.SUBJECT_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.SUBJECT_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>SUBJECT</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="right"><a id="Link1" href="" class="Button" runat="server"  >Add New Subject</a></p>

  <span id="SUBJECT1Holder" runat="server">
    


  <div align="center">
    <table cellspacing="0" cellpadding="0" align="center" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
              <th>Search Subjects</th>
 
              <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            </tr>
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0">
            
  <asp:PlaceHolder id="SUBJECT1Error" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="2"><asp:Label ID="SUBJECT1ErrorLabel" runat="server"/></td>
            </tr>
            
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th><strong>Keyword</strong></th>
 
              <td><asp:TextBox id="SUBJECT1s_keyword" maxlength="10" Columns="10"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th colspan="2"><em>Any part of Name or Abbrev</em></td>&nbsp; 
          </tr>
 
          <tr class="Controls">
            <th><em>Subject ID</em></th>
 
            <td><asp:TextBox id="SUBJECT1s_subject_id" Columns="10"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td><strong>or</strong>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>Year Level</strong>&nbsp;</th>
 
            <td>
              <select id="SUBJECT1s_yearlevel"  runat="server"></select>
 &nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><em>Status</em></th>
 
            <td>
              <asp:RadioButtonList id="SUBJECT1s_status"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td><a id="SUBJECT1ClearParameters" href="" runat="server"  >Clear</a></td> 
            <td align="right">
              <input id='SUBJECT1Button_DoSearch' type="submit" class="Button" value="Search" OnServerClick='SUBJECT1_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</div>



  </span>
  <br>
<br>

<asp:repeater id="SUBJECTRepeater" OnItemCommand="SUBJECTItemCommand" OnItemDataBound="SUBJECTItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>List of&nbsp;Subjects </th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_SUBJECT_IDSorter" field="Sorter_SUBJECT_ID" OwnerState="<%# SUBJECTData.SortField.ToString()%>" OwnerDir="<%# SUBJECTData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJECT_IDSort" runat="server">Subject ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SUBJECT_ABBREVSorter" field="Sorter_SUBJECT_ABBREV" OwnerState="<%# SUBJECTData.SortField.ToString()%>" OwnerDir="<%# SUBJECTData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJECT_ABBREVSort" runat="server">Subject Abbrev.</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SUBJECT_TITLESorter" field="Sorter_SUBJECT_TITLE" OwnerState="<%# SUBJECTData.SortField.ToString()%>" OwnerDir="<%# SUBJECTData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJECT_TITLESort" runat="server">Subject Title</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_STATUSSorter" field="Sorter_STATUS" OwnerState="<%# SUBJECTData.SortField.ToString()%>" OwnerDir="<%# SUBJECTData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STATUSSort" runat="server">Status</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>&nbsp; 
          <CC:Sorter id="Sorter_YearlevelSorter" field="Sorter_Yearlevel" OwnerState="<%# SUBJECTData.SortField.ToString()%>" OwnerDir="<%# SUBJECTData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_YearlevelSort" runat="server">Year Level</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="SorterCoreSorter" field="SorterCore" OwnerState="<%# SUBJECTData.SortField.ToString()%>" OwnerDir="<%# SUBJECTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="SorterCoreSort" runat="server">Core Yrs</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>&nbsp;&nbsp;Parent/Grouping Subject? 
          <CC:Sorter id="Sorter_DefaultTeacherIDSorter" field="Sorter_DefaultTeacherID" OwnerState="<%# SUBJECTData.SortField.ToString()%>" OwnerDir="<%# SUBJECTData.SortDir%>" runat="server"></CC:Sorter></th>
 
          <th>&nbsp; 
          <CC:Sorter id="Sorter_ALLOCATE_STUDENTS_MAXSorter" field="Sorter_ALLOCATE_STUDENTS_MAX" OwnerState="<%# SUBJECTData.SortField.ToString()%>" OwnerDir="<%# SUBJECTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_ALLOCATE_STUDENTS_MAXSort" runat="server">MAX STUDENTS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>&nbsp;</th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><a id="SUBJECTSUBJECT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,SUBJECTItem)).SUBJECT_ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="SUBJECTSUBJECT_ABBREV" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).SUBJECT_ABBREV.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="SUBJECTSUBJECT_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).SUBJECT_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="SUBJECTSTATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>&nbsp;<asp:Literal id="SUBJECTYEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="SUBJECTCORE_YEARLEVELS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).CORE_YEARLEVELS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="SUBJECTPARENT_SUBJECT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).PARENT_SUBJECT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="SUBJECTALLOCATE_STUDENTS_MAX" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).ALLOCATE_STUDENTS_MAX.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><a id="SUBJECTLink1" href="" target="_blank" runat="server"  >current</a>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <AlternatingItemTemplate>
	
        <tr class="AltRow">
          <td style="TEXT-ALIGN: right"><a id="SUBJECTAlt_SUBJECT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,SUBJECTItem)).Alt_SUBJECT_ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="SUBJECTAlt_SUBJECT_ABBREV" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).Alt_SUBJECT_ABBREV.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="SUBJECTAlt_SUBJECT_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).Alt_SUBJECT_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="SUBJECTAlt_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).Alt_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>&nbsp;<asp:Literal id="SUBJECTYEAR_LEVEL1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).YEAR_LEVEL1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="SUBJECTCORE_YEARLEVELS1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).CORE_YEARLEVELS1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="SUBJECTPARENT_SUBJECT_ID1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).PARENT_SUBJECT_ID1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="SUBJECTALLOCATE_STUDENTS_MAX1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).ALLOCATE_STUDENTS_MAX1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><a id="SUBJECTLink2" href="" target="_blank" runat="server"  >current</a>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="AltIterationContainer" runat="server"/>
  </AlternatingItemTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="9">No Subjects found</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="9"><a id="SUBJECTSUBJECT_Insert" href="" runat="server"  >Add New</a>&nbsp; 
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# SUBJECTData.PagesCount%>" PageSize="<%# SUBJECTData.RecordsPerPage%>" PageNumber="<%# SUBJECTData.PageNumber%>" runat="server">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">|&lt;</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">&lt;&lt;</asp:LinkButton> </CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">&gt;&gt;</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">&gt;|</asp:LinkButton> </CC:NavigatorItem></CC:Navigator>
</td>
        </tr>
      </table>
    </td>
  </tr>
</table>
<p>&nbsp;</p>

  </FooterTemplate>
</asp:repeater>
<br>

</form>
</body>
</html>

<!--End ASPX page-->

