<!--ASPX page @1-CFF61EAE-->
    <%@ Page language="vb" CodeFile="COMMENT_TYPE_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.COMMENT_TYPE_maint.COMMENT_TYPE_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.COMMENT_TYPE_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta name="description" content="For managing the Comment Types, added to a control table in April 2015 as new types being added all the time."><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>COMMENT TYPE maintenance</title>



<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_COMMENT_TYPE1_OnSubmit @44-5C6EE782
function page_COMMENT_TYPE1_OnSubmit()
{
    var result;
//End page_COMMENT_TYPE1_OnSubmit

//Validate Maximum Length @107-80BABBBD
    if(theForm.COMMENT_TYPE1COMMENT_HELP.value.length > 500) {
        alert("Comment Help must be less than 500 characters in length")
        theForm.COMMENT_TYPE1COMMENT_HELP.focus();
        return false;
    }
//End Validate Maximum Length

//Close page_COMMENT_TYPE1_OnSubmit @44-BC33A33A
    return result;
}
//End Close page_COMMENT_TYPE1_OnSubmit

//page_COMMENT_TYPE1_Button_Cancel_OnClick @48-A007876E
function page_COMMENT_TYPE1_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_COMMENT_TYPE1_Button_Cancel_OnClick

//Handle condition_for_show @59-043B8DF0
function condition_for_show_start(sender) {
//End Handle condition_for_show

//Custom condition_for_show @59-D1791465
    if (true==(params["click"] == "link"))
    {
        DialogPanel1_show(sender);
    } else {
    }
//End Custom condition_for_show

//condition_for_show Tail @59-FCB6E20C
}
//End condition_for_show Tail

//Handle condition_for_hide @64-86D194D0
function condition_for_hide_start(sender) {
//End Handle condition_for_hide

//Custom condition_for_hide @64-A1BE8D38
    if (true==(params["click"] == "submit" && $("#ErrorBlock").length == 0))
    {
        DialogPanel1_hide(sender);
    } else {
    }
//End Custom condition_for_hide

//condition_for_hide Tail @64-FCB6E20C
}
//End condition_for_hide Tail

//Handle ccc_link_Condition @69-BC7B1F19
function ccc_link_Condition_start(sender) {
//End Handle ccc_link_Condition

//Custom ccc_link_Condition @69-3ACAA933
    if (true==(params["click"] = "link"))
    {
    } else {
    }
//End Custom ccc_link_Condition

//ccc_link_Condition Tail @69-FCB6E20C
}
//End ccc_link_Condition Tail

//Handle ccc_submit_Condition @80-D19B1E57
function ccc_submit_Condition_start(sender) {
//End Handle ccc_submit_Condition

//Custom ccc_submit_Condition @80-3B4E074B
    if (true==(params["click"] = "submit"))
    {
    } else {
    }
//End Custom ccc_submit_Condition

//ccc_submit_Condition Tail @80-FCB6E20C
}
//End ccc_submit_Condition Tail

//Handle ccc_others_Condition @95-DDF821BB
function ccc_others_Condition_start(sender) {
//End Handle ccc_others_Condition

//Custom ccc_others_Condition @95-CECB318E
    if (true==(params["click"] = ""))
    {
    } else {
    }
//End Custom ccc_others_Condition

//ccc_others_Condition Tail @95-FCB6E20C
}
//End ccc_others_Condition Tail

//bind_events @1-1F41A8C4
function bind_events() {
    addEventHandler("COMMENT_TYPECOMMENT_TYPE_Insert", "click", ccc_link_Condition_start);
    addEventHandler("COMMENT_TYPEDetail", "click", ccc_link_Condition_start);
    addEventHandler("COMMENT_TYPE1", "submit", ccc_submit_Condition_start);
    addEventHandler("<%= Page.Form.ClientID %>","submit",page_COMMENT_TYPE1_OnSubmit);
    addEventHandler("COMMENT_TYPE1Button_Cancel","click",page_COMMENT_TYPE1_Button_Cancel_OnClick);
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
<p>

	<asp:PlaceHolder id="Panel1" Visible="true" runat="server">
	

  <span id="COMMENT_TYPESearchHolder" runat="server">
    


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
          
  <asp:PlaceHolder id="COMMENT_TYPESearchError" visible="False" runat="server">
  
          <tr id="<%=PageVariables.Get("@error-block")%>" class="Error">
            <td colspan="2"><asp:Label ID="COMMENT_TYPESearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Keyword</th>
 
            <td><asp:TextBox id="COMMENT_TYPESearchs_keyword" maxlength="20" Columns="20"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td><a id="COMMENT_TYPESearchClearParameters" href="" runat="server"  >Clear</a></td> 
            <td style="TEXT-ALIGN: right">
              <input id='COMMENT_TYPESearchButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='COMMENT_TYPESearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="COMMENT_TYPERepeater" OnItemCommand="COMMENT_TYPEItemCommand" OnItemDataBound="COMMENT_TYPEItemDataBound" runat="server">
  <HeaderTemplate>
	
<table id="Panel1COMMENT_TYPE" class="MainTable" cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>List of COMMENT TYPE </th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_COMMENT_TYPESorter" field="Sorter_COMMENT_TYPE" OwnerState="<%# COMMENT_TYPEData.SortField.ToString()%>" OwnerDir="<%# COMMENT_TYPEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_COMMENT_TYPESort" runat="server">COMMENT TYPE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_COMMENT_DESCRIPTIONSorter" field="Sorter_COMMENT_DESCRIPTION" OwnerState="<%# COMMENT_TYPEData.SortField.ToString()%>" OwnerDir="<%# COMMENT_TYPEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_COMMENT_DESCRIPTIONSort" runat="server">COMMENT DESCRIPTION</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_STATUSSorter" field="Sorter_STATUS" OwnerState="<%# COMMENT_TYPEData.SortField.ToString()%>" OwnerDir="<%# COMMENT_TYPEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_STATUSSort" runat="server">STATUS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_PUBLIC_FLAGSorter" field="Sorter_PUBLIC_FLAG" OwnerState="<%# COMMENT_TYPEData.SortField.ToString()%>" OwnerDir="<%# COMMENT_TYPEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_PUBLIC_FLAGSort" runat="server">PUBLIC FLAG</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SPECIAL_FLAGSorter" field="Sorter_SPECIAL_FLAG" OwnerState="<%# COMMENT_TYPEData.SortField.ToString()%>" OwnerDir="<%# COMMENT_TYPEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SPECIAL_FLAGSort" runat="server">SPECIAL FLAG</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>&nbsp; 
          <CC:Sorter id="Sorter_SORT_ORDERSorter" field="Sorter_SORT_ORDER" OwnerState="<%# COMMENT_TYPEData.SortField.ToString()%>" OwnerDir="<%# COMMENT_TYPEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SORT_ORDERSort" runat="server">SORT ORDER</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_COMMENT_HELPSorter" field="Sorter_COMMENT_HELP" OwnerState="<%# COMMENT_TYPEData.SortField.ToString()%>" OwnerDir="<%# COMMENT_TYPEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_COMMENT_HELPSort" runat="server">COMMENT HELP</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# COMMENT_TYPEData.SortField.ToString()%>" OwnerDir="<%# COMMENT_TYPEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# COMMENT_TYPEData.SortField.ToString()%>" OwnerDir="<%# COMMENT_TYPEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="COMMENT_TYPEDetail" href="" runat="server"  >edit</a>&nbsp;</td> 
          <td><asp:Literal id="COMMENT_TYPECOMMENT_TYPE1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COMMENT_TYPEItem)).COMMENT_TYPE1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="COMMENT_TYPECOMMENT_DESCRIPTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COMMENT_TYPEItem)).COMMENT_DESCRIPTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="COMMENT_TYPESTATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COMMENT_TYPEItem)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="COMMENT_TYPEPUBLIC_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COMMENT_TYPEItem)).PUBLIC_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="COMMENT_TYPESPECIAL_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COMMENT_TYPEItem)).SPECIAL_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <%--<td style="TEXT-ALIGN: right"><asp:Literal id="COMMENT_TYPESORT_ORDER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COMMENT_TYPEItem)).SORT_ORDER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>--%> 
          <td><asp:Literal id="COMMENT_TYPECOMMENT_HELP" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COMMENT_TYPEItem)).COMMENT_HELP.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="COMMENT_TYPELAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COMMENT_TYPEItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="COMMENT_TYPELAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COMMENT_TYPEItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="10">No Comment Types found!</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="10"><a id="COMMENT_TYPECOMMENT_TYPE_Insert" href="" runat="server"  >Add New</a>&nbsp; 
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# COMMENT_TYPEData.PagesCount%>" PageSize="<%# COMMENT_TYPEData.RecordsPerPage%>" PageNumber="<%# COMMENT_TYPEData.PageNumber%>" runat="server"><span class="Navigator">Records per page 
            <CC:PageSizer AutoPostBack="true" runat="server" />
 
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
<br>

	<asp:PlaceHolder id="Panel2" Visible="true" runat="server">
	

  <span id="COMMENT_TYPE1Holder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Add/Edit COMMENT TYPE </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="COMMENT_TYPE1Error" visible="False" runat="server">
  
          <tr id="ErrorBlock" class="Error">
            <td colspan="2"><asp:Label ID="COMMENT_TYPE1ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>COMMENT TYPE *</th>
 
            <td>
              <asp:TextBox id="COMMENT_TYPE1COMMENT_TYPE2" maxlength="20" Columns="20"	runat="server"/><asp:Literal id="COMMENT_TYPE1lblCOMMENT_TYPE" runat="server"/>&nbsp;<em>(unique Comment Type)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>COMMENT DESCRIPTION *</th>
 
            <td><asp:TextBox id="COMMENT_TYPE1COMMENT_DESCRIPTION" maxlength="50" Columns="50"	runat="server"/>&nbsp;<em>(Drop-down description)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>PUBLIC FLAG</th>
 
            <td>
              <asp:RadioButtonList id="COMMENT_TYPE1PUBLIC_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><em>(viewable&nbsp;for all users, not Contact type)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>SPECIAL FLAG</th>
 
            <td>
              <asp:RadioButtonList id="COMMENT_TYPE1SPECIAL_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><em>(for Co-Ordinators, Leading, Enrolments etc)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>SORT ORDER&nbsp;</th>
 
            <td><asp:TextBox id="COMMENT_TYPE1SORT_ORDER" maxlength="3" Columns="4"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>STATUS</th>
 
            <td>
              <asp:RadioButtonList id="COMMENT_TYPE1STATUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>COMMENT HELP 
            <div id="maxchar_comment">
              500 characters allowed 
            </div>
            </th>
 
            <td>
<asp:TextBox id="COMMENT_TYPE1COMMENT_HELP" onkeyup="limitMaxLength(this,500,'maxchar_comment');" rows="5" Columns="60" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Bottom">
            <td style="TEXT-ALIGN: right" colspan="2">
              <input id='COMMENT_TYPE1Button_Insert' type="submit" class="Button" value="Add Comment Type" OnServerClick='COMMENT_TYPE1_Insert' runat="server"/>
              <input id='COMMENT_TYPE1Button_Update' type="submit" class="Button" value="Update changes" OnServerClick='COMMENT_TYPE1_Update' runat="server"/>
              <input id='COMMENT_TYPE1Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='COMMENT_TYPE1_Cancel' runat="server"/>
  <input id="COMMENT_TYPE1LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="COMMENT_TYPE1LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  
	</asp:PlaceHolder>
	<br>

	</asp:PlaceHolder>
	</p>
<script language="JavaScript" type="text/javascript">
function limitMaxLength(formitem,maxlength,displaydivname) {
        if (isNaN(maxlength)) {
                return false;
        } else {
                var outputdiv = document.getElementById(displaydivname)
                outputdiv.innerHTML = (maxlength-formitem.value.length) + ' characters allowed';
                if (formitem.value.length+1>maxlength) {
                        formitem.value=formitem.value.substring(0,maxlength);
                }
        }
}
</script>
<p><DECV_PROD2007:Footer id="Footer" runat="server"/></p>

</form>
</body>
</html>

<!--End ASPX page-->

