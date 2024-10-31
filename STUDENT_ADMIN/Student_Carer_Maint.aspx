<!--ASPX page @1-A897B7A8-->
    <%@ Page language="vb" CodeFile="Student_Carer_Maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Carer_Maint.Student_Carer_MaintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Carer_Maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Carer Maintenance</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Include User Scripts @1-4397BB47
</script>
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/scriptaculous.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/controls.js" type="text/javascript" charset="windows-1252"></script>
<link href="Student_Carer_Maint_style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//End Include User Scripts

//page_STUDENT_CARER_CONTACT_RELATIONSHIP_OnChange @70-DB3AB3C4
function page_STUDENT_CARER_CONTACT_RELATIONSHIP_OnChange()
{
    var result;
//End page_STUDENT_CARER_CONTACT_RELATIONSHIP_OnChange

//Custom Code @174-2A29BDB7
    // -------------------------
    STUDENT_CARER_CONTACTSURNAMEPTAutocomplete1_start();
    // -------------------------
//End Custom Code

//Close page_STUDENT_CARER_CONTACT_RELATIONSHIP_OnChange @70-BC33A33A
    return result;
}
//End Close page_STUDENT_CARER_CONTACT_RELATIONSHIP_OnChange

//page_STUDENT_CARER_CONTACT_Button_Cancel_OnClick @34-DF954372
function page_STUDENT_CARER_CONTACT_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_CARER_CONTACT_Button_Cancel_OnClick

//Initialize STUDENT_CARER_CONTACTSURNAMEPTAutocomplete1 @116-61FCC95D
function STUDENT_CARER_CONTACTSURNAMEPTAutocomplete1_start() {
        if ( $("STUDENT_CARER_CONTACTRELATIONSHIP").value=='SS')
    if ($("STUDENT_CARER_CONTACTSURNAME"))
        new Ajax.Autocompleter("STUDENT_CARER_CONTACTSURNAME", "STUDENT_CARER_CONTACTSURNAME_choices", "services/Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutocomplete1.aspx", {});
}
//End Initialize STUDENT_CARER_CONTACTSURNAMEPTAutocomplete1

//Handle STUDENT_CARER_CONTACTCondition1 @117-773CF585
function STUDENT_CARER_CONTACTCondition1_start(sender) {
//End Handle STUDENT_CARER_CONTACTCondition1

//Custom STUDENT_CARER_CONTACTCondition1 @117-AD2E363E
    if ($("STUDENT_CARER_CONTACTSURNAME").value !="")
    {
                if ( $("STUDENT_CARER_CONTACTRELATIONSHIP").value=='SS')
                                                {
                                                ResetControls();
                        if ($("STUDENT_CARER_CONTACTSURNAME").value.length>=2)
                                                {
                        STUDENT_CARER_CONTACTPTAutoFill1_start(sender);
                                                }
                                                }
    } else {
    }
//End Custom STUDENT_CARER_CONTACTCondition1

//STUDENT_CARER_CONTACTCondition1 Tail @117-FCB6E20C
}
//End STUDENT_CARER_CONTACTCondition1 Tail
function ResetControls()
{
        $("STUDENT_CARER_CONTACTTITLE").value ='';
        $("STUDENT_CARER_CONTACTFIRST_NAME").value ='';
    $("STUDENT_CARER_CONTACTHOME_PHONE").value ='';
    $("STUDENT_CARER_CONTACTWORK_PHONE").value ='';
    $("STUDENT_CARER_CONTACTMOBILE").value ='';
    $("STUDENT_CARER_CONTACTEMAIL").value ='';
        $("STUDENT_CARER_CONTACTHidden_Carer_ID").value ='';

}
//PTAutoFill1 Loading @122-82BDEEF0
function STUDENT_CARER_CONTACTPTAutoFill1_start(sender) {
                var cid=0;
                if (encodeURI($("STUDENT_CARER_CONTACTSURNAME").value)!='')
                {
                        cid=$("STUDENT_CARER_CONTACTSURNAME").value.split('~')[1];
                }
                else
                {       cid=0;}

        //new Ajax.Request("services/Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutoFill1.aspx?keyword=" + encodeURI($("STUDENT_CARER_CONTACTSURNAME").value), {
    new Ajax.Request("services/Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutoFill1.aspx?keyword=" + encodeURI(cid), {
        method: "get",
        requestHeaders: ['If-Modified-Since', new Date(0)],
        onSuccess: function(transport) {
            var valuesRow = eval(transport.responseText)[0];
<<<<<<< .mine
                    $("STUDENT_CARER_CONTACTTITLE").value = valuesRow["TITLE"];
=======
                                alert(valuesRow);
                    $("STUDENT_CARER_CONTACTTITLE").value = valuesRow["TITLE"];
>>>>>>> .r119
            $("STUDENT_CARER_CONTACTSURNAME").value = valuesRow["SURNAME"];
            $("STUDENT_CARER_CONTACTFIRST_NAME").value = valuesRow["FIRST_NAME"];
            $("STUDENT_CARER_CONTACTRELATIONSHIP").value = valuesRow["RELATIONSHIP"];
            $("STUDENT_CARER_CONTACTHOME_PHONE").value = valuesRow["HOME_PHONE"];
            $("STUDENT_CARER_CONTACTWORK_PHONE").value = valuesRow["WORK_PHONE"];
            $("STUDENT_CARER_CONTACTMOBILE").value = valuesRow["MOBILE"];
            $("STUDENT_CARER_CONTACTEMAIL").value = valuesRow["EMAIL"];
                        $("STUDENT_CARER_CONTACTHidden_Carer_ID").value = valuesRow["CARER_ID"];
        }, 
        onFailure: function(transport) {
            alert(transport.responseText);
        }
    });
}
//End PTAutoFill1 Loading

//bind_events @1-5D6A5B7F
function bind_events() {
    STUDENT_CARER_CONTACTSURNAMEPTAutocomplete1_start();
    addEventHandler("STUDENT_CARER_CONTACTSURNAME", "keypress", STUDENT_CARER_CONTACTCondition1_start);
    addEventHandler("STUDENT_CARER_CONTACTSURNAME", "change", STUDENT_CARER_CONTACTCondition1_start);
        addEventHandler("STUDENT_CARER_CONTACTSURNAME_choices", "click", STUDENT_CARER_CONTACTCondition1_start);
    addEventHandler("STUDENT_CARER_CONTACTButton_Cancel","click",page_STUDENT_CARER_CONTACT_Button_Cancel_OnClick);
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


<p align="center"><DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/></p>
<p align="center"></p>
<p align="center">
<p></p>
<div align="center">
  &nbsp; 
  
<asp:repeater id="Grid1Repeater" OnItemCommand="Grid1ItemCommand" OnItemDataBound="Grid1ItemDataBound" runat="server">
  <HeaderTemplate>
	
  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>STUDENT CARER'S DETAILS</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          <tr class="Caption">
            <th>&nbsp;</th>
 
            <th>
            <CC:Sorter id="Sorter_TITLESorter" field="Sorter_TITLE" OwnerState="<%# Grid1Data.SortField.ToString()%>" OwnerDir="<%# Grid1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_TITLESort" runat="server">TITLE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# Grid1Data.SortField.ToString()%>" OwnerDir="<%# Grid1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# Grid1Data.SortField.ToString()%>" OwnerDir="<%# Grid1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>&nbsp; 
            <CC:Sorter id="Sorter_RELATIONSHIPSorter" field="Sorter_RELATIONSHIP" OwnerState="<%# Grid1Data.SortField.ToString()%>" OwnerDir="<%# Grid1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_RELATIONSHIPSort" runat="server">RELATIONSHIP</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
            <th>
            <CC:Sorter id="Sorter_HOME_PHONESorter" field="Sorter_HOME_PHONE" OwnerState="<%# Grid1Data.SortField.ToString()%>" OwnerDir="<%# Grid1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_HOME_PHONESort" runat="server">HOME PHONE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_WORK_PHONESorter" field="Sorter_WORK_PHONE" OwnerState="<%# Grid1Data.SortField.ToString()%>" OwnerDir="<%# Grid1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_WORK_PHONESort" runat="server">WORK PHONE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_MOBILESorter" field="Sorter_MOBILE" OwnerState="<%# Grid1Data.SortField.ToString()%>" OwnerDir="<%# Grid1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_MOBILESort" runat="server">MOBILE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_EMAILSorter" field="Sorter_EMAIL" OwnerState="<%# Grid1Data.SortField.ToString()%>" OwnerDir="<%# Grid1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_EMAILSort" runat="server">EMAIL</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
          <tr class="Row">
            <td><a id="Grid1Detail" href="" runat="server"  >edit</a>&nbsp;</td> 
            <td><asp:Literal id="Grid1TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid1Item)).TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="Grid1SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid1Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="Grid1FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid1Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td>&nbsp;<asp:Literal id="Grid1RELATIONSHIP" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid1Item)).RELATIONSHIP.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:Literal id="Grid1HOME_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid1Item)).HOME_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="Grid1WORK_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid1Item)).WORK_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="Grid1MOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid1Item)).MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="Grid1EMAIL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid1Item)).EMAIL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="9">No Carer found</td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Footer">
            <td colspan="9">
              <p align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="Grid1Grid1_AddCarer" href="" class="Button" runat="server"  >Add New</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="Grid1Grid1_AddSuperVisor" href="" class="Button" runat="server"  >Add School SuperVisor</a></p>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
  
  </FooterTemplate>
</asp:repeater>
<br>
  
  <span id="STUDENT_CARER_CONTACTHolder" runat="server">
    
  

    <table cellspacing="0" cellpadding="0" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
              <th>Add/Edit STUDENT <asp:Literal id="STUDENT_CARER_CONTACTLabel_MESSAGE" runat="server"/> CONTACT </th>
 
              <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
            </tr>
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0">
            
  <asp:PlaceHolder id="STUDENT_CARER_CONTACTError" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="2"><asp:Label ID="STUDENT_CARER_CONTACTErrorLabel" runat="server"/></td>
            </tr>
            
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th>TITLE</th>
 
              <td>
                <select id="STUDENT_CARER_CONTACTTITLE"  runat="server"></select>
 </td>
            </tr>
 
            <tr class="Controls">
              <th>SURNAME</th>
 
              <td>
                <asp:TextBox id="STUDENT_CARER_CONTACTSURNAME" maxlength="30" Columns="30" autocomplete="off"	runat="server"/>
                <!-- BEGINF PTAutocomplete PTAutocomplete1 -->
                <div id="STUDENT_CARER_CONTACTSURNAME_choices">
                </div>
                <!-- ENDF PTAutocomplete PTAutocomplete1 --></td>
            </tr>
 
            <tr class="Controls">
              <th>FIRST NAME</th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACTFIRST_NAME" maxlength="30" Columns="30"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>RELATIONSHIP</th>
 
              <td>
                <select id="STUDENT_CARER_CONTACTRELATIONSHIP"  runat="server"></select>
 </td>
            </tr>
 
            <tr class="Controls">
              <th>HOME PHONE</th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACTHOME_PHONE" maxlength="20" Columns="20"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>WORK PHONE</th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACTWORK_PHONE" maxlength="20" Columns="20"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>MOBILE</th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACTMOBILE" maxlength="20" Columns="20"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>EMAIL</th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACTEMAIL" maxlength="250" Columns="50"	runat="server"/></td>
            </tr>
 
            <tr class="Bottom">
              <td align="right" colspan="2">
                <input id='STUDENT_CARER_CONTACTButton_Insert' class="Button" type="submit" value="Add" OnServerClick='STUDENT_CARER_CONTACT_Insert' runat="server"/>
                <input id='STUDENT_CARER_CONTACTButton_Update' class="Button" type="submit" value="Update" OnServerClick='STUDENT_CARER_CONTACT_Update' runat="server"/>
                <input id='STUDENT_CARER_CONTACTButton_Cancel' class="Button" type="submit" value="Cancel" OnServerClick='STUDENT_CARER_CONTACT_Cancel' runat="server"/>
  <input id="STUDENT_CARER_CONTACTLAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CARER_CONTACTLAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
            </tr>
          </table>
          
  <input id="STUDENT_CARER_CONTACTHidden_Surname" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CARER_CONTACTHidden_Carer_ID" type="hidden"  runat="server"/>
  </td>
      </tr>
    </table>
  

  
  </span>
  <br>
</div>

</form>
</body>
</html>

<!--End ASPX page-->

