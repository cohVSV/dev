<!--ASPX page @1-49F44B43-->

<%@ Page Language="vb" CodeFile="TimetableIntegration.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.TimetableIntegration.TimetableIntegrationPage" ResponseEncoding="windows-1252" %>

<%@ Import Namespace="DECV_PROD2007.TimetableIntegration" %>
<%@ Import Namespace="DECV_PROD2007.Configuration" %>
<%@ Import Namespace="DECV_PROD2007.Data" %>

<%@ Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
   <meta http-equiv="X-UA-Compatible" content="IE=edge">
   <meta name="GENERATOR" content="CodeCharge Studio 5.1.1.18992">
   <meta http-equiv="content-type" content="text/html; charset=windows-1252">

   <title>Timetable Integration - Upload Export File</title>


   <link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
   <link rel="stylesheet" type="text/css" href="js/css/cupertino/jquery-ui.min.css">
   <script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
   </script>

   <style type="text/css">
      ul
      {
         margin-left: 0px;
         padding-left: 20px;
      }

         ul li:not(:last-child)
         {
            margin-bottom: 10px;
         }


      input[type=submit]
      {
         padding: 5px;
         padding-left: 15px;
         padding-right: 15px;
         min-width: 120px;
      }


      input[type=checkbox] + label, input[type=radio] + label
      {
         padding-right: 15px;
      }


      .ui-datepicker-trigger
      {
         margin-left: 8px;
         vertical-align: text-bottom;
      }


      .MainTable
      {
         margin: 0 auto;
         margin-top: 60px;
         margin-bottom: 100px;
         max-width: 1600px;
      }


      .MainTable, .Header, .Grid
      {
         border-collapse: collapse;
         padding: 0px;
      }


         .MainTable td, .MainTable th
         {
            padding: 7px;
            padding-left: 14px;
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


      tr.Row:not(:first-child):hover > td,
      tr.Row:not(:first-child):hover > td.OldValue,
      tr.Row:not(:first-child):hover > td.NewValue
      {
         background-color: lightgoldenrodyellow;
      }


      tr.Row:nth-child(odd) td.OldValue
      {
         background-color: #fde9d9;
      }


      tr.Row:nth-child(even) td.OldValue
      {
         background-color: #fef4eb;
      }


      tr.Row:nth-child(odd) td.NewValue
      {
         background-color: #eaf1dd;
      }


      tr.Row:nth-child(even) td.NewValue
      {
         background-color: #f4f7ee;
      }


      .errorMessage
      {
         display: none;
         margin-top: 20px;
         background-color: #e5b8b7;
         border: none;
         border-radius: 6px;
         padding: 20px;
         white-space: pre-line;
      }

   </style>

</head>
<body>
   <form runat="server">

      <DECV_PROD2007:Header ID="Header" runat="server" />

      <asp:MultiView runat="server" ID="mvTimetableImport" ActiveViewIndex="0">
         <asp:View runat="server" ID="viewUploadFile">

            <table class="MainTable" border="0" style="width: 950px;">
               <tr>
                  <td>
                     <table class="Header" border="0">
                        <tr>
                           <td class="HeaderLeft">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></td>
                           <th>Import From Timetabler to Student Database and VSV Online</th>
                           <th class="HeaderRight">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></th>
                        </tr>
                     </table>
                     <table class="Grid">
                        <colgroup>
                           <col style="width: 300px;" />
                           <col style="width: 650px;" />
                        </colgroup>
                        <tr class="Controls">
                           <td colspan="2" style="padding-bottom: 15px;">
                              <p><strong>Step 1: Upload the exported Timetabler file</strong></p>
                              <p>
                                 The next few pages will step you through the process of allocating teachers and classes to students in the VSV student database
                                 and VSV Online.<br />
                                 An exported Timetabler file is needed to apply the updates.
                              </p>
                              <p>
                                 The file must be a CSV formatted file having no header row, and the following columns in this order:
                              </p>
                              <ul>
                                 <li>VSV Student ID</li>
                                 <li>VSV Subject ID</li>
                                 <li>Class Code</li>
                                 <li>VSV Teacher ID (eg. JSMITH)</li>
                              </ul>
                              <p>
                                 You can go back a step by clicking the "Back" button at any time prior to the final update step, or cancel the process by clicking the
                                 "Cancel Update" button.
                              </p>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>Enrolment year
                           </td>
                           <td>
                              <asp:DropDownList runat="server" ID="ddlEnrolmentYear">
                              </asp:DropDownList>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              Apply the updates to these subject semesters only
                           </td>
                           <td>
                              <asp:RadioButtonList runat="server" ID="rblSemester" ValidationGroup="viewUploadFile" RepeatLayout="Flow">
                                 <asp:ListItem Value="1" Text="1 and B"></asp:ListItem>
                                 <asp:ListItem Value="2" Text="2 and B"></asp:ListItem>
                              </asp:RadioButtonList>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td style="position: relative;">
                              Apply the updates to these subject year levels only
                              <div style="position: absolute; left: 4px; bottom: 4px; right: 4px; font-style: italic">Change this setting if the Timetabler export file includes allocations for subject year levels that need to be excluded from the update. Otherwise, it can be left as-is.</div>
                           </td>
                           <td>
                              <p>
                                 <asp:CheckBox runat="server" ID="cbYearLevelSelectAll" Text="Select/deselect all" Checked="true" onchange="yearLevelSelectAllChanged();" />
                              </p>
                              <asp:CheckBoxList runat="server" ID="cblYearLevels" ValidationGroup="viewUploadFile" RepeatLayout="Flow" RepeatColumns="2">
                              </asp:CheckBoxList>
                              <br /><br />
                              <asp:CustomValidator runat="server" ID="cvcblYearLevels" ValidationGroup="viewUploadFile" ClientValidationFunction="validateYearLevels" ErrorMessage="At least one year level must be selected"></asp:CustomValidator>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>Select the Timetabler export file
                           </td>
                           <td>
                              <asp:FileUpload runat="server" ID="fuTTExportFile" Width="400px" AllowMultiple="false" />
                              <br /><br />
                              <asp:RequiredFieldValidator runat="server" ID="rfvfuTTExportFile" ValidationGroup="viewUploadFile" ControlToValidate="fuTTExportFile" ErrorMessage="The Timetabler export file is required"></asp:RequiredFieldValidator>
                           </td>
                        </tr>

                        <tr class="Bottom">
                           <td colspan="2" style="margin-left: auto;">
                              <asp:Button runat="server" ID="btnUploadExportNext" Text="Check Export File" ValidationGroup="viewUploadFile" OnClientClick="onNextClicked(this, 'viewUploadFile');" />
                              <asp:Button runat="server" ID="btnUploadExportCancel" Text="Cancel Update" CausesValidation="false" Style="margin-left: 20px;" />
                           </td>
                        </tr>

                     </table>

                     <div runat="server" id="divUploadExportError" class="errorMessage">
                     </div>
                  </td>
               </tr>
            </table>

         </asp:View>

         <asp:View runat="server" ID="viewCheckData">
            <table class="MainTable" border="0">
               <tr>
                  <td>
                     <table class="Header" border="0">
                        <tr>
                           <td class="HeaderLeft">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></td>
                           <th>Import From Timetabler to Student Database and VSV Online</th>
                           <th class="HeaderRight">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></th>
                        </tr>
                     </table>
                     <table class="Grid">
                        <tr class="Controls">
                           <td colspan="11" style="padding-bottom: 15px;">
                              <p>
                                 <strong>Step 2: Check here for data issues in the uploaded Timetabler export file before previewing the updates to the student database and VSV Online in the next step</strong>
                              </p>
                              <p>
                                 This page lists any data inconsistencies or other issues between the uploaded CSV file and the student database, for example
                                 student subject enrolments that aren't present in the student database, or missing teacher IDs in the export file.<br />
                                 If you continue, rows that appear here will be excluded during the final process that applies updates to the student database and VSV Online.
                              </p>
                              <p>
                                 Additionally, there are some more regular circumstances under which entries from the Timetabler file will be skipped.<br />
                                 These cases won't be displayed on this page, but you need to be aware of them.<br />
                                 They include:
                              </p>
                              <ul>
                                 <li>
                                    Subject allocations for semesters or year levels other than those selected on the first page
                                 </li>
                                 <li>
                                    Subject allocations where the student is no longer enrolled at the school or in the subject
                                 </li>
                                 <li>
                                    Launch Pad subject allocations
                                 </li>
                              </ul>
                              <p>
                                 Total issues identified: <strong><asp:Literal runat="server" ID="ltTotalIssuesIdentified"></asp:Literal></strong>
                              </p>
                           </td>
                        </tr>
                        <tr class="Row Caption">
                           <th>Student ID</th>
                           <th>Name</th>
                           <th>Student Year Level</th>
                           <th>Subject ID</th>
                           <th>Subject</th>
                           <th>Semester</th>
                           <th>Existing Teacher</th>
                           <th>Existing Class Code</th>
                           <th>Import Teacher</th>
                           <th>Import Class Code</th>
                           <th>Reason For Not Updating</th>
                        </tr>

                        <asp:ListView runat="server" ID="lvCheckData" DataSourceID="sqldsCheckData">
                           <LayoutTemplate>
                              <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                           </LayoutTemplate>
                           <ItemTemplate>
                              <tr class="Row">
                                 <td>
                                    <%# Eval("STUDENT_ID") %>
                                 </td>
                                 <td>
                                    <%# Eval("StudentName") %>
                                 </td>
                                 <td>
                                    <%# Eval("YearLevel") %>
                                 </td>
                                 <td>
                                    <%# Eval("SUBJECT_ID") %>
                                 </td>
                                 <td>
                                    <%# Eval("SubjectTitle") %>
                                 </td>
                                 <td>
                                    <%# Eval("SEMESTER") %>
                                 </td>
                                 <td class="OldValue">
                                    <%# Eval("PreviousStaffID") %>
                                 </td>
                                 <td class="OldValue">
                                    <%# Eval("PreviousClassCode") %>
                                 </td>
                                 <td class="NewValue">
                                    <%# Eval("NewStaffID") %>
                                 </td>
                                 <td class="NewValue">
                                    <%# Eval("NewClassCode") %>
                                 </td>
                                 <td>
                                    <%# Eval("NoUpdateReason") %>
                                 </td>
                              </tr>
                           </ItemTemplate>
                           <EmptyDataTemplate>
                              <tr class="NoRecords">
                                 <td colspan="11">
                                    No data issues found
                                 </td>
                              </tr>
                           </EmptyDataTemplate>
                        </asp:ListView>

                        <asp:SqlDataSource runat="server" ID="sqldsCheckData" ConnectionString="<%$ appSettings:connDECVPRODSQL2005String %>" CancelSelectOnNullParameter="false">
                           <SelectParameters>
                              <asp:ControlParameter ControlID="ddlEnrolmentYear" Name="enrolmentYear" DbType="Int32" ConvertEmptyStringToNull="true" />
                              <asp:ControlParameter ControlID="rblSemester" Name="semester" DbType="String" ConvertEmptyStringToNull="true" />
                           </SelectParameters>
                        </asp:SqlDataSource>

                        <tr class="Footer">
                           <td colspan="11">
                              <asp:DataPager runat="server" ID="dpCheckData" PagedControlID="lvCheckData" PageSize="50">
                                 <Fields>
                                    <asp:NextPreviousPagerField ShowFirstPageButton="true" FirstPageText="First" ShowNextPageButton="false" />
                                    <asp:NumericPagerField  />
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

                        <tr class="Bottom">
                           <td colspan="11" style="margin-left: auto; padding-top: 10px;">
                              <asp:Button runat="server" ID="btnCheckDataBack" Text="Back" CausesValidation="false" CommandArgument="viewUploadFile" CommandName="SwitchViewByID" />
                              <asp:Button runat="server" ID="btnCheckDataPreview" Text="Preview Updates to Student Database" ValidationGroup="viewCheckData" OnClientClick="onNextClicked(this, 'viewCheckData');" style="margin-left: 20px;" />
                              <asp:Button runat="server" ID="btnCheckDataCancel" Text="Cancel Update" CausesValidation="false" Style="margin-left: 20px;" />
                           </td>
                        </tr>

                     </table>
                  </td>
               </tr>
            </table>
         </asp:View>

         <asp:View runat="server" ID="viewPreviewUpdate">
            <table class="MainTable" border="0">
               <tr>
                  <td>
                     <table class="Header" border="0">
                        <tr>
                           <td class="HeaderLeft">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></td>
                           <th>Import From Timetabler to Student Database and VSV Online</th>
                           <th class="HeaderRight">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></th>
                        </tr>
                     </table>
                     <table class="Grid">
                        <tr class="Controls">
                           <td colspan="10" style="padding-bottom: 15px;">
                              <p>
                                 <strong>Step 3: Review the updates (a maximum sample of <%= MaximumUpdatePreviewRows %> will be shown) that will be applied to the student database and VSV Online from the uploaded Timetabler file</strong>
                              </p>
                              <p>
                                 Total updates that will be applied: <strong><asp:Literal runat="server" ID="ltTotalUpdatesPending"></asp:Literal></strong>
                              </p>
                           </td>
                        </tr>
                        <tr class="Row Caption">
                           <th>Student ID</th>
                           <th>Name</th>
                           <th>Student Year Level</th>
                           <th>Subject ID</th>
                           <th>Subject</th>
                           <th>Semester</th>
                           <th>Existing Teacher</th>
                           <th>Existing Class Code</th>
                           <th>Import Teacher</th>
                           <th>Import Class Code</th>
                        </tr>

                        <asp:ListView runat="server" ID="lvPreviewUpdate" DataSourceID="sqldsPreviewUpdate">
                           <LayoutTemplate>
                              <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                           </LayoutTemplate>
                           <ItemTemplate>
                              <tr class="Row">
                                 <td>
                                    <%# Eval("STUDENT_ID") %>
                                 </td>
                                 <td>
                                    <%# Eval("StudentName") %>
                                 </td>
                                 <td>
                                    <%# Eval("YearLevel") %>
                                 </td>
                                 <td>
                                    <%# Eval("SUBJECT_ID") %>
                                 </td>
                                 <td>
                                    <%# Eval("SubjectTitle") %>
                                 </td>
                                 <td>
                                    <%# Eval("SEMESTER") %>
                                 </td>
                                 <td class="OldValue">
                                    <%# Eval("PreviousStaffID") %>
                                 </td>
                                 <td class="OldValue">
                                    <%# Eval("PreviousClassCode") %>
                                 </td>
                                 <td class="NewValue">
                                    <%# Eval("NewStaffID") %>
                                 </td>
                                 <td class="NewValue">
                                    <%# Eval("NewClassCode") %>
                                 </td>
                              </tr>
                           </ItemTemplate>
                           <EmptyDataTemplate>
                              <tr class="NoRecords">
                                 <td colspan="10">
                                    No changes to existing teacher or class codes were identified in the Timetabler file, for the semesters and year levels specified.<br />
                                    No changes will be made.
                                 </td>
                              </tr>
                           </EmptyDataTemplate>
                        </asp:ListView>

                        <asp:SqlDataSource runat="server" ID="sqldsPreviewUpdate" ConnectionString="<%$ appSettings:connDECVPRODSQL2005String %>">
                           <SelectParameters>
                              <asp:ControlParameter ControlID="ddlEnrolmentYear" Name="enrolmentYear" DbType="Int32" ConvertEmptyStringToNull="true" />
                              <asp:ControlParameter ControlID="rblSemester" Name="semester" DbType="String" ConvertEmptyStringToNull="true" />
                           </SelectParameters>
                        </asp:SqlDataSource>

                        <tr class="Footer">
                           <td colspan="10">
                              <asp:DataPager runat="server" ID="dpPreviewUpdate" PagedControlID="lvPreviewUpdate" PageSize="50">
                                 <Fields>
                                    <asp:NextPreviousPagerField ShowFirstPageButton="true" FirstPageText="First" ShowNextPageButton="false" />
                                    <asp:NumericPagerField  />
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

                        <tr class="Bottom">
                           <td colspan="10" style="margin-left: auto; padding-top: 10px;">
                              <asp:Button runat="server" ID="btnPreviewUpdateBack" Text="Back" CausesValidation="false" />
                              <asp:Button runat="server" ID="btnPreviewUpdate" Text="Summary and Confirmation" ValidationGroup="viewPreviewUpdate" style="margin-left: 20px;" />
                              <asp:Button runat="server" ID="btnPreviewUpdateCancel" Text="Cancel Update" CausesValidation="false" Style="margin-left: 20px;" />
                           </td>
                        </tr>

                     </table>
                  </td>
               </tr>
            </table>
         </asp:View>


         <asp:View runat="server" ID="viewSummaryConfirmation">
            <table class="MainTable" border="0">
               <tr>
                  <td>
                     <table class="Header" border="0">
                        <tr>
                           <td class="HeaderLeft">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></td>
                           <th>Import From Timetabler to Student Database and VSV Online</th>
                           <th class="HeaderRight">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></th>
                        </tr>
                     </table>
                     <table class="Grid">
                        <tr class="Controls">
                           <td colspan="2" style="padding-bottom: 15px;">
                              <strong>Final step: Confirm the updates that will be applied to the student database and VSV Online</strong>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              Enrolment year
                           </td>
                           <td>
                              <asp:Literal runat="server" ID="ltEnrolmentYearSummary"></asp:Literal>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              Subject semesters
                           </td>
                           <td>
                              <asp:Literal runat="server" ID="ltSubjectSemestersSummary"></asp:Literal>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              Year levels
                           </td>
                           <td>
                              <asp:Literal runat="server" ID="ltYearLevelsSummary"></asp:Literal>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              Import file
                           </td>
                           <td>
                              <asp:Literal runat="server" ID="ltExportFileSummary"></asp:Literal>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              Total updates that will be applied
                           </td>
                           <td>
                              <asp:Literal runat="server" ID="ltTotalUpdatesPendingSummary"></asp:Literal>
                           </td>
                        </tr>

                        <tr class="Bottom">
                           <td colspan="2" style="margin-left: auto; padding-top: 10px;">
                              <asp:Button runat="server" ID="btnSummaryConfirmationBack" Text="Back" CausesValidation="false" />
                              <asp:Button runat="server" ID="btnSummaryConfirmationApply" Text="Apply Updates" ValidationGroup="viewSummaryConfirmation"
                                 OnClientClick="onNextClicked(this, 'viewSummaryConfirmation');" style="margin-left: 20px; font-weight: bold;" />
                              <asp:Button runat="server" ID="btnSummaryConfirmationCancel" Text="Cancel Update" CausesValidation="false" Style="margin-left: 20px;" />
                           </td>
                        </tr>
                     </table>

                     <div runat="server" id="divSummaryConfirmationError" class="errorMessage">
                     </div>
                  </td>
               </tr>
            </table>
         </asp:View>

         <asp:View runat="server" ID="viewUpdateSummary">
            <table class="MainTable" border="0">
               <tr>
                  <td>
                     <table class="Header" border="0">
                        <tr>
                           <td class="HeaderLeft">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></td>
                           <th>Import From Timetabler to Student Database and VSV Online</th>
                           <th class="HeaderRight">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></th>
                        </tr>
                     </table>
                     <table class="Grid">
                        <tr class="Controls">
                           <td style="padding-bottom: 15px;">
                              <strong>Success: the exported Timetabler updates have been applied to the student database.</strong>
                              <p>
                                 The updates will also sync with VSV Online after a short period of time.
                              </p>
                           </td>
                        </tr>

                        <tr class="Bottom">
                           <td style="margin-left: auto; padding-top: 10px;">
                              <asp:Button runat="server" ID="btnReturnToMainPage" Text="Return to Main Page" CausesValidation="false" />
                           </td>
                        </tr>
                     </table>
                  </td>
               </tr>
            </table>
         </asp:View>

      </asp:MultiView>

   </form>

   <script type="text/javascript">


      function yearLevelSelectAllChanged()
      {
         var yearLevelSelectAllElement = document.querySelector("#<%= cbYearLevelSelectAll.ClientID %>");
         var isChecked = yearLevelSelectAllElement.checked;

         var yearLevelElements = document.querySelectorAll("#<%= cblYearLevels.ClientID %> input[type='checkbox']");
         for (var elementIndex = 0; elementIndex < yearLevelElements.length; elementIndex++)
            yearLevelElements[elementIndex].checked = isChecked;
      }


      function validateYearLevels(source, arguments)
      {
         var yearLevelElements = document.querySelectorAll("#<%= cblYearLevels.ClientID %> input[type='checkbox']");
         for (var elementIndex = 0; elementIndex < yearLevelElements.length; elementIndex++)
         {
            if (yearLevelElements[elementIndex].checked)
               return true;
         }

         arguments.IsValid = false;
      }


      function onNextClicked(buttonElement, validationGroup)
      {
         if (Page_ClientValidate(validationGroup))
            buttonElement.value = "Processing...";
      }
   </script>

</body>
</html>

<!--End ASPX page-->

