<!--ASPX page @1-8806CD9D-->
    <%@ Page language="vb" CodeFile="SCHOOL_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.SCHOOL_maint.SCHOOL_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.SCHOOL_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta name="description" content="Edit main details of School, and access the School Address record"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>SCHOOL - Add/Edit</title>



<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_SCHOOL_SCHOOL_TYPE_CODE_OnChange @8-FFED599D
function page_SCHOOL_SCHOOL_TYPE_CODE_OnChange()
{
    var result;
//End page_SCHOOL_SCHOOL_TYPE_CODE_OnChange

//Custom Code @67-2A29BDB7
    // -------------------------
    // 31-Oct-2018|EA| if 'X' then show certain fields required
    let itemList = document.getElementById("SCHOOLSCHOOL_TYPE_CODE");
        if (itemList.selectedOptions[0].value == "X") {
                alert("VSV Extra Organisations need Name, Principal and 'Active' fields completed\nUse SCHOOL ID starting with 990xx.00\n\n Other fields are optional");
                           document.getElementById("SCHOOLREGION_ID").value ="99" ;
                result = true;
        }
    // -------------------------
//End Custom Code

//Close page_SCHOOL_SCHOOL_TYPE_CODE_OnChange @8-BC33A33A
    return result;
}
//End Close page_SCHOOL_SCHOOL_TYPE_CODE_OnChange

//page_SCHOOL_Button_Delete_OnClick @5-B0AC9B9A
function page_SCHOOL_Button_Delete_OnClick()
{
    disableValidation = true;
}
//End page_SCHOOL_Button_Delete_OnClick

//bind_events @1-2556A66F
function bind_events() {
    addEventHandler("SCHOOLSCHOOL_TYPE_CODE","change",page_SCHOOL_SCHOOL_TYPE_CODE_OnChange);
    addEventHandler("SCHOOLButton_Delete","click",page_SCHOOL_Button_Delete_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

//End CCS script
window.onload = bind_events;

</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/> </p>
<p><a id="linkSchoolList" href="" class="Button" runat="server"  >Back to School List</a></p>

  <span id="SCHOOLHolder" runat="server">
    


    <table cellspacing="0" cellpadding="0" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Add/Edit SCHOOL </th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="SCHOOLError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="4"><asp:Label ID="SCHOOLErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th>SCHOOL ID</th>
 
                        <td><asp:TextBox id="SCHOOLSCHOOL_ID" Columns="9"	runat="server"/><asp:Literal id="SCHOOLSchoolID_view" runat="server"/></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>SCHOOL NAME</th>
 
                        <td><asp:TextBox id="SCHOOLSCHOOL_NAME" maxlength="60" Columns="50"	runat="server"/></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>REGION ID</th>
 
                        <td>
                            <select id="SCHOOLREGION_ID"  runat="server"></select>
 </td> 
                        <td>&nbsp;SCHOOL TYPE</td> 
                        <td>
                            <select id="SCHOOLSCHOOL_TYPE_CODE"  runat="server"></select>
 </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>PRINCIPAL</th>
 
                        <td><asp:TextBox id="SCHOOLPRINCIPAL" maxlength="30" Columns="30"	runat="server"/></td> 
                        <td>&nbsp;VBOS NUMBER</td> 
                        <td><asp:TextBox id="SCHOOLVBOSNUMBER" maxlength="12" Columns="12"	runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>METRO CATEGORY</th>
 
                        <td>
                            <asp:RadioButtonList id="SCHOOLMETRO_CATEGORY"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;STATUS</td> 
                        <td>&nbsp;<asp:CheckBox id="SCHOOLSTATUS" runat="server"/>&nbsp;Active/Open?</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>SCHOOL ADDRESS</th>
 
                        <td><a id="SCHOOLADDRESS_ID" href="" class="Button" runat="server"  >Edit Address</a><asp:Literal id="SCHOOLlbl_SaveBeforeAddress" runat="server"/></td> 
                        <td>&nbsp;<asp:Literal id="SCHOOLlblAddressID" runat="server"/></td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>LAST ALTERED BY / DATE</th>
 
                        <td><asp:Literal id="SCHOOLlbl_LAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="SCHOOLlbl_LAST_ALTERED_DATE" runat="server"/></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="4" align="right">
                            <input id='SCHOOLButton_Insert' type="submit" class="Button" value="Add School" OnServerClick='SCHOOL_Insert' runat="server"/>
                            <input id='SCHOOLButton_Update' type="submit" class="Button" value="Update" OnServerClick='SCHOOL_Update' runat="server"/>
                            <input id='SCHOOLButton_Delete' type="submit" class="Button" value="Close this School" OnServerClick='SCHOOL_Delete' runat="server"/></td>
                    </tr>
                </table>
                
  <input id="SCHOOLLAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="SCHOOLLAST_ALTERED_DATE" type="hidden"  runat="server"/>
  
  <input id="SCHOOLHidden_address_id" type="hidden"  runat="server"/>
  </td>
        </tr>
    </table>


&nbsp;<asp:Literal id="SCHOOLlblDebug" runat="server"/>
  </span>
  
<p></p>
<p align="left">

<CC:Report id="ADDRESS_Postal" WebPageSize="40" PageSizeLimit="100" runat="server">
  <LayoutHeaderTemplate>
<div align="left">
    <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>School Address</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Grid" cellspacing="0" cellpadding="0">
                    </LayoutHeaderTemplate>
  <Section name="Report_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Page_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Detail" Visible="True" Height="16"><Template>
                    <tr class="Row">
                        <th>
                        <h4>Postal Address:</h4>
                        </th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Row">
                        <th><strong>ADDRESSEE </strong></th>
 
                        <td><CC:ReportLabel id="ADDRESS_PostalADDRESSEE" DataType="_Text" SourceType="DBColumn" Source="ADDRESSEE" runat="server"/>&nbsp; </td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp; </td>
                    </tr>
 
                    <tr class="Row">
                        <th><strong>AGENT</strong> </th>
 
                        <td><CC:ReportLabel id="ADDRESS_PostalAGENT" DataType="_Text" SourceType="DBColumn" Source="AGENT" runat="server"/>&nbsp; </td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Row">
                        <th><strong>ADDRESS</strong> </th>
 
                        <td><CC:ReportLabel id="ADDRESS_PostalADDR1" DataType="_Text" SourceType="DBColumn" Source="ADDR1" runat="server"/>&nbsp; </td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Row">
                        <th>&nbsp;</th>
 
                        <td><CC:ReportLabel id="ADDRESS_PostalADDR2" DataType="_Text" SourceType="DBColumn" Source="ADDR2" runat="server"/>&nbsp; </td> 
                        <td>&nbsp; </td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Row">
                        <th><strong>SUBURB/TOWN</strong> </th>
 
                        <td><CC:ReportLabel id="ADDRESS_PostalSUBURB_TOWN" DataType="_Text" SourceType="DBColumn" Source="SUBURB_TOWN" runat="server"/>&nbsp; </td> 
                        <td><strong>STATE </strong></td> 
                        <td><CC:ReportLabel id="ADDRESS_PostalSTATE" DataType="_Text" SourceType="DBColumn" Source="STATE" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Row">
                        <th><strong>POSTCODE</strong> </th>
 
                        <td><CC:ReportLabel id="ADDRESS_PostalPOSTCODE" DataType="_Text" SourceType="DBColumn" Source="POSTCODE" runat="server"/>&nbsp;</td> 
                        <td><strong>COUNTRY</strong> </td> 
                        <td><CC:ReportLabel id="ADDRESS_PostalCOUNTRY" DataType="_Text" SourceType="DBColumn" Source="COUNTRY" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Row">
                        <th><strong>PHONE 1</strong></th>
 
                        <td><CC:ReportLabel id="ADDRESS_PostalPHONE_A" DataType="_Text" SourceType="DBColumn" Source="PHONE_A" runat="server"/>&nbsp;&nbsp;</td> 
                        <td><strong>PHONE 2</strong></td> 
                        <td><CC:ReportLabel id="ADDRESS_PostalPHONE_B" DataType="_Text" SourceType="DBColumn" Source="PHONE_B" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Row">
                        <th><strong>FAX</strong> </th>
 
                        <td><CC:ReportLabel id="ADDRESS_PostalFAX" DataType="_Text" SourceType="DBColumn" Source="FAX" runat="server"/>&nbsp; </td> 
                        <td><strong>EMAIL ADDRESS</strong> </td> 
                        <td>&nbsp;<a id="ADDRESS_PostalEMAIL_ADDRESS" href="" runat="server"  ><%#(CType(Container.DataItem,ADDRESS_PostalItem)).EMAIL_ADDRESS.GetFormattedValue()%></a>&nbsp;</td>
                    </tr>
 
                    <tr class="Row">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Row">
                        <th><strong>Billing / Accounts Email</strong>&nbsp;</th>
 
                        <td>&nbsp;<a id="ADDRESS_PostalEMAIL_ADDRESS2" href="" runat="server"  ><%#(CType(Container.DataItem,ADDRESS_PostalItem)).EMAIL_ADDRESS2.GetFormattedValue()%></a>&nbsp;</td> 
                        <td><em>&nbsp;only for Invoices / Accounts</em></td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Row">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Row">
                        <th>LAST_ALTERED_BY / DATE</th>
 
                        <td><CC:ReportLabel id="ADDRESS_PostalLAST_ALTERED_BY" DataType="_Text" SourceType="DBColumn" Source="LAST_ALTERED_BY" runat="server"/> / <CC:ReportLabel id="ADDRESS_PostalLAST_ALTERED_DATE" Format="dd/mm/yyyy H:nn" DataType="_Date" SourceType="DBColumn" Source="LAST_ALTERED_DATE" runat="server"/>&nbsp;</td> 
                        <td>ADDRESS_ID&nbsp;</td> 
                        <td><CC:ReportLabel id="ADDRESS_PostalADDRESS_ID" DataType="_Float" SourceType="DBColumn" Source="ADDRESS_ID" runat="server"/>&nbsp;</td>
                    </tr>
 </Template></Section>
<Section name="Report_Footer" Visible="True" Height="0"><Template>
                    
	<asp:PlaceHolder id="ADDRESS_PostalNoRecords" Visible="true" runat="server">
	
                    <tr class="NoRecords">
                        <td colspan="4">No Postal Address Record</td>
                    </tr>
 
	</asp:PlaceHolder>
	</Template></Section>
<Section name="Page_Footer" Visible="True" Height="0"><Template></Template></Section>

  <LayoutFooterTemplate>
                </table>
            </td>
        </tr>
    </table>
</div>
<div align="left">
</div>
</LayoutFooterTemplate>
</CC:Report>

<p></p>
<p><br>
&nbsp;</p>

</form>
</body>
</html>

<!--End ASPX page-->

