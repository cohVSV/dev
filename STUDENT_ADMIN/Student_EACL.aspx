<!--ASPX page @1-0F7E8A4B-->

<%@ Page Language="vb" CodeFile="Student_EACL.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_EACL.Student_EACLPage" ResponseEncoding="windows-1252" %>

<%@ Import Namespace="DECV_PROD2007.Student_EACL" %>
<%@ Import Namespace="DECV_PROD2007.Configuration" %>
<%@ Import Namespace="DECV_PROD2007.Data" %>

<%@ Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx" %>
<%@ Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
   <meta http-equiv="X-UA-Compatible" content="IE=edge">
   <meta name="GENERATOR" content="CodeCharge Studio 5.1.1.18992">
   <meta http-equiv="content-type" content="text/html; charset=windows-1252">

   <title><asp:Literal runat="server" ID="litPageTitle"></asp:Literal></title>


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
         min-width: 120px;
      }


      .ui-datepicker-trigger
      {
         margin-left: 8px;
         vertical-align: text-bottom;
      }


      .MainTable
      {
         margin: 0 auto;
         margin-top: 30px;
         margin-bottom: 100px;
         width: 950px;
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


      tr.Row:nth-child(odd) td, option:nth-child(odd)
      {
         background-color: #ebf2f8;
      }


      .Mandated td, .Mandated th
      {
         border: 1px solid #e5b8b7;
      }


      tr.Header.Mandated th
      {
         color: black;
         background-color: #e5b8b7;
         border: 1px solid #e5b8b7;
         font-size: 90%;
      }


      tr.Row.Mandated:nth-child(odd) td
      {
         background-color: #f8ecec;
      }


      tr.Row.Mandated:nth-child(even) td
      {
         background-color: #f2dbdb;
      }


      tr.VulnerabilityIndicators th
      {
         color: black;
         background-color: #dfdfdf;
         padding-left: 30px;
         padding-top: 15px;
         padding-bottom: 15px;
         font-size: 90%;
      }


      .Learning td, .Learning th
      {
         border: 1px solid #b6dde8;
      }


      tr.Header.Learning th
      {
         color: black;
         background-color: #b6dde8;
         font-size: 90%;
      }


      tr.Row.Learning:nth-child(odd) td
      {
         background-color: #ecf6f9;
      }


      tr.Row.Learning:nth-child(even) td
      {
         background-color: #daeef3;
      }


      .Inclusion td, .Inclusion th
      {
         border: 1px solid #d6e3bc;
      }


      tr.Header.Inclusion th
      {
         color: black;
         background-color: #d6e3bc;
         font-size: 90%;
      }


      tr.Row.Inclusion:nth-child(odd) td
      {
         background-color: #f4f7ee;
      }


      tr.Row.Inclusion:nth-child(even) td
      {
         background-color: #eaf1dd;
      }


      .Engagement td, .Engagement th
      {
         border: 1px solid #fbd4b4;
      }


      tr.Header.Engagement th
      {
         color: black;
         background-color: #fbd4b4;
         font-size: 90%;
      }


      tr.Row.Engagement:nth-child(odd) td
      {
         background-color: #fef4eb;
      }


      tr.Row.Engagement:nth-child(even) td
      {
         background-color: #fde9d9;
      }


      .Wellbeing td, .Wellbeing th
      {
         border: 1px solid #ccc0d9;
      }


      tr.Header.Wellbeing th
      {
         color: black;
         background-color: #ccc0d9;
         font-size: 90%;
      }


      tr.Row.Wellbeing:nth-child(odd) td
      {
         background-color: #f2eff5;
      }


      tr.Row.Wellbeing:nth-child(even) td
      {
         background-color: #e5dfec;
      }


      .Enrolment td, .Enrolment th
      {
         border: 1px solid #c4bc96;
      }


      tr.Header.Enrolment th
      {
         color: black;
         background-color: #c4bc96;
         font-size: 90%;
      }


      tr.Row.Enrolment:nth-child(odd) td
      {
         background-color: #eeebe1;
      }


      tr.Row.Enrolment:nth-child(even) td
      {
         background-color: #ddd9c3;
      }


      .saveSuccess
      {
         display: inline-block;
         background-color: #aff393;
         border: none;
         border-radius: 6px;
         padding: 8px;
         padding-left: 15px;
         padding-right: 15px;
         opacity: 0.0;
      }


      .saveError
      {
         display: none;
         margin-top: 20px;
         background-color: #e5b8b7;
         border: none;
         border-radius: 6px;
         padding: 20px;
         white-space: pre-line;
      }


      .warning
      {
         margin-top: 20px;
         background-color: #fbd4b4;
         border: none;
         border-radius: 6px;
         padding: 20px;
         white-space: pre-line;
      }
   </style>

</head>
<body>
   <form runat="server">

      <p style="margin-top: 20px; margin-left: auto; margin-right: auto;">

	      <asp:PlaceHolder id="Panel_MenuStudentMaintain" Visible="false" runat="server">
	      <DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/>
	      </asp:PlaceHolder>
	      </p>
      <p style="width: 250px; margin-left: auto; margin-right: auto;"><a id="Link_Backtosummary" href="" class="Button" style="padding: 6px 8px 6px 8px;" runat="server">Back to Summary</a></p>

      <asp:ScriptManager runat="server" ID="smStudentEACL">
      </asp:ScriptManager>

      <asp:UpdatePanel runat="server" ID="upStudentEACL">
         <ContentTemplate>

            <table class="MainTable" border="0">
               <tr>
                  <td>
                     <table class="Header" border="0">
                        <tr>
                           <td class="HeaderLeft">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></td>
                           <th>VSV Early Assessment Checklist</th>
                           <th class="HeaderRight">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></th>
                        </tr>
                     </table>
                     <table class="Grid" style="table-layout: fixed;">
                        <colgroup>
                           <col style="width: 300px;" />
                           <col style="width: 100px;" />
                           <col style="width: 550px;" />
                        </colgroup>
                        <tr class="Controls">
                           <td>
                              <strong>Student</strong>
                           </td>
                           <td colspan="2">
                              <asp:Literal runat="server" ID="ltStudentName"></asp:Literal> - <%: Request.QueryString("STUDENT_ID") %>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              <strong>Enrolment year</strong>
                           </td>
                           <td colspan="2">
                              <%: Request.QueryString("ENROLMENT_YEAR") %>
                              <asp:Literal runat="server" ID="ltEnrolmentYearWarning"></asp:Literal>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              <strong>Year level</strong>
                           </td>
                           <td colspan="2">
                              <asp:Literal runat="server" ID="ltYearLevel"></asp:Literal>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              <strong>School(s)</strong>
                           </td>
                           <td colspan="2">
                              <asp:Literal runat="server" ID="ltSchoolsShared"></asp:Literal>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              <strong>Learning Advisor</strong>
                           </td>
                           <td colspan="2">
                              <asp:DropDownList runat="server" ID="ddlLearningAdvisorID" DataSourceID="sqldsLearningAdvisorID" DataValueField="STAFF_ID" DataTextField="StaffName" AppendDataBoundItems="true">
                                 <asp:ListItem Value=""></asp:ListItem>
                              </asp:DropDownList>

                              <asp:Button runat="server" ID="btnUpdateLearningAdvisor" Text="Update Learning Advisor" style="margin-left: 20px; min-width: 180px;" Visible="false"/>

                              <div id="divSaveLearningAdvisorSuccess" class="saveSuccess" style="margin-left: 20px;" >
                              </div>

                              <div id="divSaveLearningAdvisorError" class="saveError">
                              </div>

                              <asp:SqlDataSource runat="server" ID="sqldsLearningAdvisorID" ConnectionString="<%$ appSettings:connDECVPRODSQL2005String %>">
                              </asp:SqlDataSource>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              <strong>SSG Facilitator</strong>
                           </td>
                           <td colspan="2">
                              <asp:DropDownList runat="server" ID="ddlSSGFacilitator" DataSourceID="sqldsSSGFacilitator" DataValueField="STAFF_ID" DataTextField="StaffName" AppendDataBoundItems="true">
                                 <asp:ListItem Value=""></asp:ListItem>
                              </asp:DropDownList>

                              <asp:SqlDataSource runat="server" ID="sqldsSSGFacilitator" ConnectionString="<%$ appSettings:connDECVPRODSQL2005String %>">
                              </asp:SqlDataSource>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              <strong>Risk factor summary</strong>
                           </td>
                           <td colspan="2">
                              <span id="riskFactorSummary"></span>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              <strong>Learning Plan</strong>
                           </td>
                           <td colspan="2">
                              <asp:RadioButtonList runat="server" ID="rblLearningPlan" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                 <asp:ListItem Value="PLP" Text="PLP"></asp:ListItem>
                                 <%--30 Nov 2021|RW| Changed PLSP terminology to "Mandated IEP", per SD 35567--%>
                                 <asp:ListItem Value="PLSP" Text="Mandated IEP"></asp:ListItem>
                              </asp:RadioButtonList>
                              <p id="plspPreselection" style="font-style: italic; display: none;"></p>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              <strong>Notes</strong>
                           </td>
                           <td colspan="2">
                              <asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" Rows="5" MaxLength="480" style="width: 100%;"></asp:TextBox>
                              <p id="notesComment" style="font-style: italic;">Information entered here will be saved as a public comment for this student</p>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              <strong>Early Assessment Checklist created</strong>
                           </td>
                           <td colspan="2">
                              <asp:Literal runat="server" ID="ltEACreatedByDate"></asp:Literal>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td>
                              <strong>Last updated</strong>
                           </td>
                           <td colspan="2">
                              <asp:Literal runat="server" ID="ltEAUpdatedByDate"></asp:Literal>
                           </td>
                        </tr>

                        <tr class="Footer">
                           <td colspan="3" style="border-left: 1px solid #dfdfdf; border-right: 1px solid #dfdfdf;">
                           </td>
                        </tr>

                        <tr class="Header Mandated">
                           <th colspan="3">
                                 <span>Mandated Student Cohorts</span>
                           </th>
                        </tr>
                        <tr class="Row">
                           <td colspan="3" style="border: 1px solid #e5b8b7;">
                              The details below for the student's Out of Home Care, Aboriginal or Torres Islander, PSD and NCCD funding, and Youth Justice status
                              are retrieved from separate areas of the student's record and cannot be updated here. If you believe them to be in error, please contact
                              <a href="mailto:sdetails@vsv.vic.edu.au?Subject=Student Record Amendment Request for ID <%: Request.QueryString("STUDENT_ID") %> ">sdetails@vsv.vic.edu.au</a>.
                           </td>
                        </tr>
                        <tr class="Caption Mandated">
                           <td colspan="2">
                              <strong>Risk Factor</strong>
                           </td>
                           <td>
                              <strong>Actions</strong>
                           </td>
                        </tr>
                        <tr class="Row Mandated">
                           <td colspan="2">
                              <%--18 Nov 2020|RW| As per SD request ID 28062 regarding admin errors, leaving the selections overridable for now --%>
                              <asp:CheckBox runat="server" ID="cbOoHC" TextAlign="Right" Text="Out of Home Care" Enabled="false" onclick="refreshLearningPlanStatus();" />
                              <asp:Literal runat="server" ID="ltOoHCDetails"></asp:Literal>
                           </td>
                           <td>
                              <ul>
                                 <li>
                                    Mandated IEP
                                 </li>
                              </ul>
                           </td>
                        </tr>
                        <tr class="Row Mandated">
                           <td colspan="2">
                              <%--18 Nov 2020|RW| As per SD request ID 28062 regarding admin errors, leaving the selections overridable for now --%>
                              <asp:CheckBox runat="server" ID="cbATSI" TextAlign="Right" Text="Aboriginal or Torres Strait Islander" Enabled="false" onclick="refreshLearningPlanStatus();" />
                           </td>
                           <td>
                              <ul>
                                 <li>
                                    Mandated IEP
                                 </li>
                              </ul>
                           </td>
                        </tr>
                        <tr class="Row Mandated">
                           <td colspan="2">
                              <%--18 Nov 2020|RW| As per SD request ID 28062 regarding admin errors, leaving the selections overridable for now --%>
                              <%--2 Dec 2021|RW| Split PSD and NCCD items. IEP is only to be mandatory for substantive or extensive level NCCD funding: SD ID 35567 --%>
                              <asp:CheckBox runat="server" ID="cbPSDFunded" TextAlign="Right" Text="PSD funded" Enabled="false" onclick="refreshLearningPlanStatus();" />
                              <asp:Literal runat="server" ID="ltPSDDetails"></asp:Literal>
                           </td>
                           <td>
                              <ul>
                                 <li>
                                    Mandated IEP
                                 </li>
                              </ul>
                           </td>
                        </tr>
                        <tr class="Row Mandated">
                           <td colspan="2">
                              <%--18 Nov 2020|RW| As per SD request ID 28062 regarding admin errors, leaving the selections overridable for now --%>
                              <%--2 Dec 2021|RW| Split PSD and NCCD items. IEP is only to be mandatory for substantive or extensive level NCCD funding: SD ID 35567 --%>
                              <asp:CheckBox runat="server" ID="cbNCCDFunded" TextAlign="Right" Text="NCCD funded" Enabled="false" onclick="refreshLearningPlanStatus();" />
                              <asp:Literal runat="server" ID="ltNCCDDetails"></asp:Literal>
                              <asp:HiddenField runat="server" ID="hidNCCDFundingLevel" />
                           </td>
                           <td>
                              <ul>
                                 <li>
                                    Mandated IEP when funding level is substantive or extensive
                                 </li>
                              </ul>
                           </td>
                        </tr>
                        <tr class="Row Mandated">
                           <td colspan="2">
                              <%--5 Feb 2021|RW| Added new mandated item Youth Justice, per Mal M --%>
                              <asp:CheckBox runat="server" ID="cbYouthJustice" TextAlign="Right" Text="Youth Justice" Enabled="false" onclick="refreshLearningPlanStatus();" />
                              <asp:Literal runat="server" ID="ltYouthJusticeDetails"></asp:Literal>
                           </td>
                           <td>
                              <ul>
                                 <li>
                                    Mandated IEP
                                 </li>
                              </ul>
                           </td>
                        </tr>
                        <tr class="Row Mandated">
                           <td colspan="2">
                              <asp:CheckBox runat="server" ID="cbAcademicLag" TextAlign="Right" Text="Assessed as two years or more below expected level" onclick="refreshLearningPlanStatus();" />
                           </td>
                           <td>
                              <ul>
                                 <li>
                                    Mandated IEP
                                 </li>
                              </ul>
                           </td>
                        </tr>

                        <tr class="Header VulnerabilityIndicators">
                           <th colspan="3" style="border-left: 1px solid #dfdfdf;">
                                 <span>Vulnerability Indicators</span>
                           </th>
                        </tr>

                        <asp:Repeater runat="server" ID="rptEACL" ItemType="StudentRiskFactor" ClientIDMode="Predictable">
                           <ItemTemplate>
                              <%# If(Item.IsHeaderRow, GenerateRiskFactorDisplayHeader(Item), "") %>

                              <tr class="Row <%# Item.RiskCategory %>">
                                 <td colspan="2">
                                    <asp:CheckBox runat="server" ID="cbStudentRiskFactor" TextAlign="Right" Text='<%# Item.DisplayText %>'
                                       Checked='<%# Item.IsSelected %>'
                                       data-riskFactorID="<%# Item.RiskFactorID %>" data-riskFactorCategory="<%# Item.RiskCategory %>" onclick="refreshLearningPlanStatus();" />
                                    <%# GenerateListItemsHtml(Item.AdditionalInformation) %>
                                    <%# If(Item.IsPreselected, GeneratePreselectionNoticeHtml(), "") %>
                                 </td>
                                 <td>
                                    <%# GenerateRiskFactorActionsDisplay(Item.Actions) %>
                                 </td>
                              </tr>
                           </ItemTemplate>
                        </asp:Repeater>

                        <tr class="Bottom" style="border: 1px solid #dfdfdf;">
                           <td colspan="3" style="margin-left: auto; border: none;">
                              <div id="divSaveEACLSuccess" class="saveSuccess">
                              </div>
                              <asp:Button runat="server" ID="btnSaveEACL" Text="Save Checklist" style="margin-left: 20px;" Visible="false" />
                           </td>
                        </tr>

                     </table>

                     <div id="divSaveEACLError" class="saveError">
                     </div>
                  </td>
               </tr>
            </table>
         </ContentTemplate>

      </asp:UpdatePanel>

   </form>

   <script type="text/javascript" src="js/jquery_min.js" ></script>
   <script type="text/javascript" src="js/jquery-ui.min.js" ></script>
   <script type="text/javascript">

      var isNewAssessment = <%:If(EarlyAssessmentID.HasValue(), "false", "true") %>;


      function initialisePopulatedFormFields()
      {
         // Initialise textbox fields to the size of their content
         var parent = document.getElementById("<%: upStudentEACL.ClientID %>");
         var textboxFields = parent.getElementsByTagName('textarea');
         for (var elementIndex = 0; elementIndex < textboxFields.length; elementIndex++)
            resizeTextBox(textboxFields[elementIndex]);
      }


      function resizeTextBox(textBox)
      {
         textBox.style.height = 'auto';
         textBox.style.height = textBox.scrollHeight + 'px';
      }


      // Refresh the risk factor summary
      function refreshLearningPlanStatus()
      {
         var riskFactorSummary = "";

         // Inspect the mandated items
         var ooHCElement = document.getElementById("<%= cbOoHC.ClientID %>");
         var atsiElement = document.getElementById("<%= cbATSI.ClientID %>");
         var psdFundedElement = document.getElementById("<%= cbPSDFunded.ClientID %>");
         var nccdFundedElement = document.getElementById("<%= cbNCCDFunded.ClientID %>");
         var nccdFundingLevelElement = document.getElementById("<%= hidNCCDFundingLevel.ClientID %>");
         var academicLagElement = document.getElementById("<%= cbAcademicLag.ClientID %>");
         var youthJusticeElement = document.getElementById("<%= cbYouthJustice.ClientID %>");

         var mandatedRiskCount = 0;
         var mandatedElements = [ooHCElement, atsiElement, psdFundedElement, academicLagElement, youthJusticeElement];
         for (var elementIndex = 0; elementIndex < mandatedElements.length; elementIndex++)
         {
            if (mandatedElements[elementIndex].checked)
               mandatedRiskCount++;
         }

         // 30 Nov 2021|RW| Only count NCCD condition as mandatory when the funding level is substantive or extensive
         if (nccdFundedElement.checked && ((nccdFundingLevelElement.value === "20") || (nccdFundingLevelElement.value === "30")))
            mandatedRiskCount++;

         riskFactorSummary = mandatedRiskCount.toString() + " mandated";

         /* Inspect the non-mandated items
          * Nothing tricky here, just traversing the DOM elements that are tagged with the RiskFactorCategoryAttribute, defined in the code-behind
          * The list of possible non-mandated categories is also defined in the code-behind, as the RiskCategorySortOrder dictionary
          */
         var nonMandatedRiskCount = 0;
         var nonMandatedSummary = "";
         const riskCategories = ['<%= String.Join("', '", RiskCategorySortOrder.Keys.ToArray()) %>'];
         for (var categoryIndex = 0; categoryIndex < riskCategories.length; categoryIndex ++)
         {
            var riskCategory = riskCategories[categoryIndex];
            var querySelector = ".Grid *[<%: RiskFactorCategoryAttribute %>='" + riskCategory + "'] input:checked";
            var categoryRiskFactors = document.querySelectorAll(querySelector).length;
            if (categoryRiskFactors > 0)
            {
               if (nonMandatedSummary !== "")
                  nonMandatedSummary += ", ";
               nonMandatedSummary += (categoryRiskFactors.toString() + " " + riskCategory);

               nonMandatedRiskCount += categoryRiskFactors;
            }
         }

         // Update the risk factor summary
         riskFactorSummary += (" and " + nonMandatedRiskCount.toString() + " non-mandated");
         if (nonMandatedRiskCount > 0)
            riskFactorSummary += (" (" + nonMandatedSummary + ")");

         var riskFactorSummaryElement = document.getElementById("riskFactorSummary");
         riskFactorSummaryElement.innerText = riskFactorSummary;

         if (mandatedRiskCount !== 0)
         {
            // Mandated item selected - lock PLSP as the only option
            setMandatedPLSPSelection(true);
         }
         else
         {
            setMandatedPLSPSelection(false);

            if (isNewAssessment)
            {
               // 5 Feb 2021|RW| Remove the triggering of PLSP for non-mandated items, per Mal M
               //var learningPlanRecommendation = ((mandatedRiskCount === 0) && (nonMandatedRiskCount < 5)) ? "PLP" : "PLSP";
               var learningPlanRecommendation = "PLP";
               setRecommendedLearningPlanSelection(learningPlanRecommendation);
            }
         }
      }


      function setMandatedPLSPSelection(isMandated)
      {
         var plspPreselectionElement = document.getElementById("plspPreselection");

         // Can't visibly disable a span via JS
         var plspElement = document.querySelector("#<%= rblLearningPlan.ClientID %> input[type='radio'][value='PLSP']");
         var plpElement = document.querySelector("#<%= rblLearningPlan.ClientID %> input[type='radio'][value='PLP']");
         if (isMandated)
         {
            plspElement.checked = "true";
            // 18 Nov 2020|RW| As per SD request ID 28062 regarding admin errors, leaving the selections overridable for now
            //plspElement.disabled = plpElement.disabled = "disabled";

            plspPreselectionElement.innerText = "An IEP has been selected for this student based on mandated risk factors"
            plspPreselectionElement.style.display = "block";
         }
         else
         {
            plspElement.removeAttribute("disabled");
            plpElement.removeAttribute("disabled");
            plspPreselectionElement.style.display = "none";
         }
      }


      function setRecommendedLearningPlanSelection(recommendation)
      {
         var plspPreselectionElement = document.getElementById("plspPreselection");

         var learningPlanRecommendationElement = document.querySelector("#<%= rblLearningPlan.ClientID %> input[type='radio'][value='" + recommendation + "']");
         learningPlanRecommendationElement.checked = true;

         if (recommendation === "PLSP")
         {
            plspPreselectionElement.innerText = "A mandated IEP has been preselected for this student based on the selected risk factors"
            plspPreselectionElement.style.display = "block";
         }
         else
            plspPreselectionElement.style.display = "none";
      }


      function learningAdvisorChanged(learningAdvisorSelectElement)
      {
         var canSave = (learningAdvisorSelectElement.value !== "");
         var updateLearningAdvisorElement = document.getElementById("<%: btnUpdateLearningAdvisor.ClientID %>");
         if (canSave)
            updateLearningAdvisorElement.removeAttribute("disabled");
         else
            updateLearningAdvisorElement.setAttribute("disabled", "disabled");
      }



      var postbackElement = null;

      Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequestHandler);
      Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);


      function beginRequestHandler(sender, args)
      {
         postbackElement = args.get_postBackElement();
         postbackElement.value = "Saving...";
         postbackElement.setAttribute("disabled", "disabled");

         hideError(".saveError");
      }


      function endRequestHandler(sender, args)
      {
         if (postbackElement.id === "<%= btnUpdateLearningAdvisor.ClientID %>")
         {
            postbackElement.value = "Update Learning Advisor";
            postbackElement.removeAttribute("disabled");

            if (args.get_error() !== null)
               showError("#divSaveLearningAdvisorError", "An error has occurred:\n\n" + args.get_error().message);
            else
               showFadeoutMessage("#divSaveLearningAdvisorSuccess", "Learning Advisor updated");
         }
         else if (postbackElement.id === "<%= btnSaveEACL.ClientID %>")
         {
            postbackElement.value = "Save Checklist";
            postbackElement.removeAttribute("disabled");

            if (args.get_error() !== null)
               showError("#divSaveEACLError", "An error has occurred:\n\n" + args.get_error().message);
            else
               showFadeoutMessage("#divSaveEACLSuccess", "Early Assessment Checklist saved");
         }

         // Refresh the display
         initialisePopulatedFormFields();
         refreshLearningPlanStatus();
      }


      function hideError(errorMessageSelector)
      {
         var alertElement = $(errorMessageSelector);
         alertElement.hide();
      }


      function showError(errorMessageSelector, message)
      {
         var alertElement = $(errorMessageSelector);
         alertElement.text(message);
         alertElement.show();
      }


      function showFadeoutMessage(alertElementSelector, message)
      {
         var alertElement = $(alertElementSelector);
         alertElement.text(message);
         alertElement.css({ opacity: 1.0 });
         window.setTimeout(function ()
         {
            alertElement.animate({ opacity: 0.0 });
         }, 3000);
      }

      initialisePopulatedFormFields();
      refreshLearningPlanStatus();

   </script>
</body>
</html>

<!--End ASPX page-->

