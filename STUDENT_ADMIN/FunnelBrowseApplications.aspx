<!--ASPX page @1-26F70F21-->

<%@ Page Language="vb" CodeFile="FunnelBrowseApplications.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.FunnelBrowseApplications.FunnelBrowseApplicationsPage" %>

<%@ Import Namespace="DECV_PROD2007.FunnelBrowseApplications" %>
<%@ Import Namespace="DECV_PROD2007.Configuration" %>
<%@ Import Namespace="DECV_PROD2007.Data" %>

<%@ Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>

<html lang="en-au">
<head>
   <meta http-equiv="X-UA-Compatible" content="IE=edge">
   <meta charset="utf-8" />
   <meta name="viewport" content="width=device-width, initial-scale=1.0" />

   <title>Online Enrolments - Browse and Import Enrolment Applications from Funnel</title>

</head>
<body>
   <form runat="server">

      <DECV_PROD2007:Header ID="Header" runat="server" />

<%--  Including the header component above will also include CSS that would override our own in the HTML header section,
      so we need to apply the custom styling here.--%>

      <link rel="stylesheet" type="text/css" href="js/css/cupertino/jquery-ui.min.css">

      <style type="text/css">
         input[type=submit], input[type=button]
         {
            padding: 5px;
            padding-left: 15px;
            padding-right: 15px;
            min-width: 120px;
         }

         .TableContainer
         {
            margin: 0 auto;
            margin-top: 60px;
            max-width: 1800px;
         }


            .TableContainer td, .TableContainer th
            {
               padding: 7px;
               padding-left: 14px;
            }


         .Header, .Grid
         {
            border-collapse: collapse;
            padding: 0px;
         }


         td.HeaderLeft
         {
            padding: 0px;
         }


         tr.Row:nth-child(odd) > td,
         option:nth-child(odd)
         {
            background-color: #ebf2f8;
         }


         tr.Row:not(.selectedItem):hover > td
         {
            background-color: lightgoldenrodyellow;
         }


         tr.Row.selectedItem > td
         {
            background-color: khaki;
         }


         .successMessage
         {
            display: inline-block;
            background-color: #bff7a7;
            border: none;
            border-radius: 6px;
            padding: 8px;
            padding-left: 15px;
            padding-right: 15px;
         }


         .warningMessage
         {
            background-color: #fbd4b4;
            border: none;
            border-radius: 6px;
            padding: 8px;
            padding-left: 15px;
            padding-right: 15px;
         }


         .ui-icon
         {
            transform: scale(1.5);
         }

         .no-close .ui-dialog-titlebar-close
         {
            display: none;
         }
      </style>


      <asp:ScriptManager runat="server" ID="smFunnelApplications">
         <Scripts>
            <asp:ScriptReference Path="~/js/jquery_min.js" />
            <asp:ScriptReference Path="~/js/jquery-ui.min.js" />
         </Scripts>
      </asp:ScriptManager>

      <asp:UpdatePanel runat="server" ID="upFunnelApplications" UpdateMode="Conditional" style="margin-bottom: 100px;">
         <ContentTemplate>

            <div class="TableContainer" style="width: 950px;">

               <table class="Header" border="0">
                  <tr>
                     <td class="HeaderLeft">
                        <img src="Styles/Blueprint/Images/Spacer.gif">
                     </td>
                     <th>Online Enrolments - Process Enrolment Applications from Funnel
                     </th>
                     <th class="HeaderRight">
                        <img src="Styles/Blueprint/Images/Spacer.gif">
                     </th>
                  </tr>
               </table>
               <table class="Grid" style="table-layout: fixed;">
                  <colgroup>
                     <col style="width: 300px;" />
                     <col style="width: 650px;" />
                  </colgroup>
                  <tr class="Controls">
                     <td>
                        <strong>Enrolment year for current applications</strong>
                     </td>
                     <td>
                        <%= CurrentEnrolmentYear %>
                     </td>
                  </tr>
                  <tr class="Controls">
                     <td>Show applications for enrolment year
                     </td>
                     <td>
                        <asp:DropDownList runat="server" ID="ddlEnrolmentYear" AutoPostBack="true">
                        </asp:DropDownList>
                     </td>
                  </tr>
                  <tr class="Controls">
                     <td>Application stage
                     </td>
                     <td>
                        <asp:DropDownList runat="server" ID="ddlPipelineStage" DataSourceID="sqldsPipelineStage" DataValueField="Value" DataTextField="Label"
                           AppendDataBoundItems="true" AutoPostBack="true">
                           <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource runat="server" ID="sqldsPipelineStage" ConnectionString="<%$ appSettings:connDECVPRODSQL2005String %>"></asp:SqlDataSource>
                     </td>
                  </tr>
                  <tr class="Controls">
                     <td>Enrolment form
                     </td>
                     <td>
                        <asp:DropDownList runat="server" ID="ddlEnrolmentForm" DataSourceID="sqldsEnrolmentForm" DataValueField="Value" DataTextField="Label"
                           AppendDataBoundItems="true" AutoPostBack="true">
                           <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource runat="server" ID="sqldsEnrolmentForm" ConnectionString="<%$ appSettings:connDECVPRODSQL2005String %>"></asp:SqlDataSource>
                     </td>
                  </tr>
                  <tr class="Controls">
                     <td>Direct enrolment category
                     </td>
                     <td>
                        <asp:DropDownList runat="server" ID="ddlEnrolmentCategory" DataSourceID="sqldsEnrolmentCategory" DataValueField="Value" DataTextField="Label"
                           AppendDataBoundItems="true" AutoPostBack="true">
                           <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource runat="server" ID="sqldsEnrolmentCategory" ConnectionString="<%$ appSettings:connDECVPRODSQL2005String %>"></asp:SqlDataSource>
                     </td>
                  </tr>
                  <tr class="Controls">
                     <td>Shared or full enrolments
                     </td>
                     <td>
                        <asp:DropDownList runat="server" ID="ddlIsSharedEnrolment" AutoPostBack="true">
                           <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                     </td>
                  </tr>
                  <tr class="Controls">
                     <td>Year level
                     </td>
                     <td>
                        <asp:DropDownList runat="server" ID="ddlYearLevel" DataSourceID="sqldsYearLevel" DataValueField="Value" DataTextField="Label"
                           AppendDataBoundItems="true" AutoPostBack="true">
                           <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource runat="server" ID="sqldsYearLevel" ConnectionString="<%$ appSettings:connDECVPRODSQL2005String %>"></asp:SqlDataSource>
                     </td>
                  </tr>
                  <tr class="Controls">
                     <td>Applicant first name or surname starts with
                     </td>
                     <td>
                        <asp:TextBox runat="server" ID="txtApplicantNameStartsWith" Width="150px" type="search"></asp:TextBox>
                     </td>
                  </tr>
                  <tr class="Controls">
                     <td>School
                     </td>
                     <td>
                        <asp:TextBox runat="server" ID="txtHomeSchool" Width="350px" type="search"></asp:TextBox>
                        <asp:HiddenField runat="server" ID="hidHomeSchoolID" />
                     </td>
                  </tr>
                  <tr class="Controls">
                     <td>Application status
                     </td>
                     <td>
                        <asp:DropDownList runat="server" ID="ddlStatus" AutoPostBack="true">
                           <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                     </td>
                  </tr>

                  <tr class="Bottom">
                     <td colspan="2" style="margin-left: auto;">
                        <asp:Button runat="server" ID="btnResetFilters" Text="Reset" UseSubmitBehavior="false" />
                     </td>
                  </tr>
               </table>
            </div>

            <div class="TableContainer">

               <table class="Header" border="0">
                  <tr>
                     <td class="HeaderLeft">
                        <img src="Styles/Blueprint/Images/Spacer.gif"></td>
                     <th>Matching Applications</th>
                     <th class="HeaderRight">
                        <img src="Styles/Blueprint/Images/Spacer.gif"></th>
                  </tr>
               </table>
               <table class="Grid">
                  <tr class="Caption">
                     <th>Applicant</th>
                     <th>Status</th>
                     <th>Comment</th>
                     <th>Application Stage</th>
                     <th>Enrolment Form</th>
                     <th>Direct Enrolment Category</th>
                     <th>Year Level</th>
                     <th>Home School</th>
                     <th>Application Created</th>
                     <th>Application Last Updated</th>
                  </tr>
                  <asp:ListView runat="server" ID="lvFunnelApplications" DataSourceID="sqldsFunnelApplications">
                     <LayoutTemplate>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                     </LayoutTemplate>
                     <ItemTemplate>
                        <tr class="Row">
                           <td>
                              <%# GenerateFunnelApplicantOutput(Eval("FunnelLeadUUID"), Eval("FirstName").ToString(), Eval("Surname").ToString()) %>
                           </td>
                           <td>
                              <%# GenerateStatusOutput(Eval("FunnelLeadUUID").ToString(), Eval("Status").ToString(), Eval("ActionedBy").ToString(),
                                               Common.GetDateTimeDisplay(Eval("ActionedDate"), True), Eval("AcceptedStudentID").ToString(),
                                               Eval("FunnelTargetEnrolmentYear").ToString()) %>
                           </td>
                           <td>
                              <asp:LinkButton runat="server" ID="lbApplicationComment" CommandName="EditApplicationComment" data-LeadUUID='<%# Eval("FunnelLeadUUID") %>'
                                 CssClass="ui-icon ui-icon-clipboard" />
                              <%# GenerateApplicationCommentOutput(Eval("Comment").ToString(), Eval("CommentLastUpdatedByDisplayName").ToString(),
                                                                   Common.GetDateTimeDisplay(Eval("CommentLastUpdatedDate"), True)) %>
                           </td>
                           <td>
                              <%# Eval("FunnelPipelineStage") %>
                           </td>
                           <td>
                              <%# Eval("FunnelEnrolmentForm") %>
                           </td>
                           <td>
                              <%# Eval("FunnelEnrolmentCategory") %>
                           </td>
                           <td>
                              <%# Eval("FunnelYearLevel") %>
                           </td>
                           <td>
                              <%# Eval("HomeSchool") %>
                           </td>
                           <td>
                              <%# Common.GetDateTimeDisplay(Eval("FunnelCreatedDate")) %>
                           </td>
                           <td>
                              <%# Common.GetDateTimeDisplay(Eval("FunnelUpdatedDate")) %>
                           </td>
                        </tr>
                     </ItemTemplate>
                  </asp:ListView>

                  <tr class="Footer">
                     <td colspan="10">
                        <asp:DataPager runat="server" ID="dpFunnelApplications" PagedControlID="lvFunnelApplications" PageSize="1">
                           <Fields>
                              <asp:NextPreviousPagerField ShowFirstPageButton="true" FirstPageText="First" ShowNextPageButton="false" />
                              <asp:NumericPagerField />
                              <asp:TemplatePagerField>
                                 <PagerTemplate>
                                    of <%# (Container.TotalRowCount + (Container.PageSize - 1)) \ Container.PageSize %>
                                 </PagerTemplate>
                              </asp:TemplatePagerField>
                              <asp:NextPreviousPagerField ShowLastPageButton="true" LastPageText="Last" ShowPreviousPageButton="false" />
                           </Fields>
                        </asp:DataPager>
                     </td>
                  </tr>

               </table>
            </div>

            <asp:SqlDataSource runat="server" ID="sqldsFunnelApplications" ConnectionString="<%$ appSettings:connDECVPRODSQL2005String %>"
               CancelSelectOnNullParameter="false" SelectCommand="">
               <SelectParameters>
                  <asp:ControlParameter Name="enrolmentYear" Type="Decimal" ControlID="ddlEnrolmentYear" PropertyName="SelectedValue" />
                  <asp:ControlParameter Name="pipelineStageID" DbType="Guid" ControlID="ddlPipelineStage" PropertyName="SelectedValue" />
                  <asp:ControlParameter Name="enrolmentFormID" Type="String" ControlID="ddlEnrolmentForm" PropertyName="SelectedValue" />
                  <asp:ControlParameter Name="enrolmentCategoryID" Type="String" ControlID="ddlEnrolmentCategory" PropertyName="SelectedValue" />
                  <asp:ControlParameter Name="isSharedEnrolmentID" Type="String" ControlID="ddlIsSharedEnrolment" PropertyName="SelectedValue" />
                  <asp:ControlParameter Name="yearLevelID" DbType="Guid" ControlID="ddlYearLevel" PropertyName="SelectedValue" />
                  <asp:ControlParameter Name="homeSchoolID" Type="Decimal" ControlID="hidHomeSchoolID" PropertyName="Value" ConvertEmptyStringToNull="true" />
                  <asp:ControlParameter Name="nameStartsWith" Type="String" ControlID="txtApplicantNameStartsWith" PropertyName="Text" />
                  <asp:ControlParameter Name="status" Type="String" ControlID="ddlStatus" PropertyName="SelectedValue" />
               </SelectParameters>
            </asp:SqlDataSource>

            <div id="divApplicationCommentDialog" title="Application Comment" style="display: none;">
               <table class="Header" border="0" style="width: 550px;">
                  <tr>
                     <td class="HeaderLeft">
                        <img src="Styles/Blueprint/Images/Spacer.gif"></td>
                     <th>Comment for
                        <asp:Literal runat="server" ID="litApplicationCommentApplicantName"></asp:Literal></th>
                     <th class="HeaderRight">
                        <img src="Styles/Blueprint/Images/Spacer.gif"></th>
                  </tr>
               </table>
               <table class="Grid" style="width: 550px;">
                  <tr class="Controls">
                     <td>
                        <asp:TextBox runat="server" ID="txtApplicationComment" TextMode="MultiLine" Rows="8" MaxLength="480" Style="width: 100%; resize: none;"></asp:TextBox>
                     </td>
                  </tr>
                  <tr class="Controls">
                     <td>
                        <asp:Literal runat="server" ID="litApplicationCommentLastUpdated"></asp:Literal>
                     </td>
                  </tr>
                  <tr class="Bottom">
                     <td style="margin-left: auto;">
                        <asp:Button runat="server" ID="btnSaveComment" Text="Save" UseSubmitBehavior="false" />
                        <asp:Button runat="server" ID="btnCancelComment" Text="Cancel" UseSubmitBehavior="false" Style="margin-left: 10px;" />
                     </td>
                  </tr>
               </table>

               <asp:HiddenField runat="server" ID="hidApplicationCommentLeadUUID" />
            </div>
         </ContentTemplate>
         <Triggers>
            <asp:AsyncPostBackTrigger ControlID="tmFunnelApplicationsRefresh" EventName="Tick" />
         </Triggers>
      </asp:UpdatePanel>

      <asp:Timer runat="server" ID="tmFunnelApplicationsRefresh" Interval="300000"></asp:Timer>

   </form>


   <script type="text/javascript">
      //$(".datepicker").datepicker({
      //   inline: false,
      //   dateFormat: "d M yy",
      //   changeMonth: true,
      //   changeYear: true,
      //   yearRange: "1940: " + (new Date().getFullYear() + 1)
      //   //showOn: "both",
      //   //buttonImage: "Styles/Blueprint/Images/DatePicker.gif",
      //   //buttonImageOnly: true
      //});


      function initialisePage()
      {
         var pageRequestManager = Sys.WebForms.PageRequestManager.getInstance();
         pageRequestManager.add_endRequest(EndRequest);

         initialiseControls();
      }


      function initialiseControls()
      {
         initialiseStudentName();
         initialiseHomeSchoolAutoComplete();
         initialiseHomeSchoolOnClear();
      }


      function EndRequest(sender, args)
      {
         // Re-initialise the events after update occurs on the UpdatePanel
         initialiseControls();
      }


      function initialiseStudentName()
      {
         document.getElementById("<%= txtApplicantNameStartsWith.ClientID %>").addEventListener("keyup", function (event)
         {
            event.preventDefault();
            if (event.keyCode === 13)
            {
               __doPostBack('<%= upFunnelApplications.ClientID %>', null);
               return false;
            }
         });
      }

      function initialiseHomeSchoolAutoComplete()
      {
         // Set up the jQuery UI autocomplete on the school field
         $("#<%= txtHomeSchool.ClientID %>").autocomplete({
            minLength: 3,
            source: function (request, response)
            {
               var schoolFilter = { schoolName: request.term };
               $.ajax({
                  type: "POST",
                  contentType: "application/json; charset=utf-8",
                  url: '<%=ResolveUrl("FunnelBrowseApplications.aspx/GetMatchingSchools") %>',
                  dataType: "json",
                  data: JSON.stringify(schoolFilter),
                  success: function (data)
                  {
                     // Translate the objects returned from the web method to the format that jQuery UI's autocomplete function expects
                     var transformedData = data.d.map(function (item)
                     {
                        return {
                           label: item.SchoolName,
                           value: item.SchoolID
                        };
                     });
                     response(transformedData);
                  },
                  error: function (result)
                  {
                     alert(response.responseText);
                  },
                  failure: function ()
                  {
                     response.responseText
                  }
               });
            },
            select: function (e, i)
            {
               document.getElementById("<%= txtHomeSchool.ClientID %>").value = i.item.label;
               document.getElementById("<%= hidHomeSchoolID.ClientID %>").value = i.item.value;

               __doPostBack('<%= upFunnelApplications.ClientID %>', null);

               // Prevent the event default behaviour, which will overwrite the text label with the value
               return false;
            },
            change: function (e, i)
            {
               if (i.item === null)
               {
                  document.getElementById("<%= txtHomeSchool.ClientID %>").value = "";
                  document.getElementById("<%= hidHomeSchoolID.ClientID %>").value = "";
               }
            }
         });
      }


      function initialiseHomeSchoolOnClear()
      {
         // Convenience function for immediately applying the filter if the field is cleared via the search clear box
         document.getElementById('<%= txtHomeSchool.ClientID %>').addEventListener('input', function (e)
         {
            if (e.target.value.length === 0)
            {
               document.getElementById("<%= hidHomeSchoolID.ClientID %>").value = "";
               __doPostBack('<%= upFunnelApplications.ClientID %>', null);
            }
         })
      }


      function initialiseApplicationCommentDialog()
      {
         $("#divApplicationCommentDialog").dialog({
            appendTo: "#<%= upFunnelApplications.ClientID %>",
            modal: true,
            width: "auto",
            resizable: false,
            closeOnEscape: false,
            dialogClass: "no-close",
            autoOpen: false
         });
      }


      function showApplicationCommentDialog()
      {
         initialiseApplicationCommentDialog();
         $("#divApplicationCommentDialog").dialog("open");
      }

      initialisePage();
   </script>

</body>
</html>

<!--End ASPX page-->
