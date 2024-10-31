'Using Statements @1-82FB19C3
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Diagnostics
Imports System.Web
Imports System.IO
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.Security
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports DECV_PROD2007
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Security
Imports DECV_PROD2007.Configuration
Imports DECV_PROD2007.Controls
'End Using Statements

Namespace DECV_PROD2007.StudentEnrolment_InitialCheck 'Namespace @1-7114D028

'Forms Definition @1-EDBE4F42
Public Class [StudentEnrolment_InitialCheckPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-69942487
    Protected STUDENTSearchData As STUDENTSearchDataProvider
    Protected STUDENTSearchErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENTSearchOperations As FormSupportedOperations
    Protected STUDENTSearchIsSubmitted As Boolean = False
    Protected STUDENTData As STUDENTDataProvider
    Protected STUDENTOperations As FormSupportedOperations
    Protected STUDENTCurrentRowNumber As Integer
    Protected StudentEnrolment_InitialCheckContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-90F47810
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENTSearchShow()
            STUDENTBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENTSearch Parameters @10-4DFC329E

    Protected Sub STUDENTSearchParameters()
        Dim item As new STUDENTSearchItem
        Try
        Catch e As Exception
            STUDENTSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENTSearch Parameters

'Record Form STUDENTSearch Show method @10-CAB5E5FC
    Protected Sub STUDENTSearchShow()
        If STUDENTSearchOperations.None Then
            STUDENTSearchHolder.Visible = False
            Return
        End If
        Dim item As STUDENTSearchItem = STUDENTSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENTSearchOperations.AllowRead
        STUDENTSearchErrors.Add(item.errors)
        If STUDENTSearchErrors.Count > 0 Then
            STUDENTSearchShowErrors()
            Return
        End If
'End Record Form STUDENTSearch Show method

'Record Form STUDENTSearch BeforeShow tail @10-5C794E78
        STUDENTSearchParameters()
        STUDENTSearchData.FillItem(item, IsInsertMode)
        STUDENTSearchHolder.DataBind()
        STUDENTSearchs_SURNAME.Text=item.s_SURNAME.GetFormattedValue()
        STUDENTSearchs_FIRST_NAME.Text=item.s_FIRST_NAME.GetFormattedValue()
        STUDENTSearchs_BIRTH_DATE.Text=item.s_BIRTH_DATE.GetFormattedValue()
        STUDENTSearchs_STUDENT_ID.Text=item.s_STUDENT_ID.GetFormattedValue()
        STUDENTSearchs_Email.Text=item.s_Email.GetFormattedValue()
'End Record Form STUDENTSearch BeforeShow tail

'Record Form STUDENTSearch Show method tail @10-3D876956
        If STUDENTSearchErrors.Count > 0 Then
            STUDENTSearchShowErrors()
        End If
    End Sub
'End Record Form STUDENTSearch Show method tail

'Record Form STUDENTSearch LoadItemFromRequest method @10-A7DD0CF0

    Protected Sub STUDENTSearchLoadItemFromRequest(item As STUDENTSearchItem, ByVal EnableValidation As Boolean)
        item.s_SURNAME.IsEmpty = IsNothing(Request.Form(STUDENTSearchs_SURNAME.UniqueID))
        If ControlCustomValues("STUDENTSearchs_SURNAME") Is Nothing Then
            item.s_SURNAME.SetValue(STUDENTSearchs_SURNAME.Text)
        Else
            item.s_SURNAME.SetValue(ControlCustomValues("STUDENTSearchs_SURNAME"))
        End If
        item.s_FIRST_NAME.IsEmpty = IsNothing(Request.Form(STUDENTSearchs_FIRST_NAME.UniqueID))
        If ControlCustomValues("STUDENTSearchs_FIRST_NAME") Is Nothing Then
            item.s_FIRST_NAME.SetValue(STUDENTSearchs_FIRST_NAME.Text)
        Else
            item.s_FIRST_NAME.SetValue(ControlCustomValues("STUDENTSearchs_FIRST_NAME"))
        End If
        Try
        item.s_BIRTH_DATE.IsEmpty = IsNothing(Request.Form(STUDENTSearchs_BIRTH_DATE.UniqueID))
        If ControlCustomValues("STUDENTSearchs_BIRTH_DATE") Is Nothing Then
            item.s_BIRTH_DATE.SetValue(STUDENTSearchs_BIRTH_DATE.Text)
        Else
            item.s_BIRTH_DATE.SetValue(ControlCustomValues("STUDENTSearchs_BIRTH_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENTSearchErrors.Add("s_BIRTH_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"Birth Date","dd/mm/yyyy"))
        End Try
        item.s_STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENTSearchs_STUDENT_ID.UniqueID))
        If ControlCustomValues("STUDENTSearchs_STUDENT_ID") Is Nothing Then
            item.s_STUDENT_ID.SetValue(STUDENTSearchs_STUDENT_ID.Text)
        Else
            item.s_STUDENT_ID.SetValue(ControlCustomValues("STUDENTSearchs_STUDENT_ID"))
        End If
        item.s_Email.IsEmpty = IsNothing(Request.Form(STUDENTSearchs_Email.UniqueID))
        If ControlCustomValues("STUDENTSearchs_Email") Is Nothing Then
            item.s_Email.SetValue(STUDENTSearchs_Email.Text)
        Else
            item.s_Email.SetValue(ControlCustomValues("STUDENTSearchs_Email"))
        End If
        If EnableValidation Then
            item.Validate(STUDENTSearchData)
        End If
        STUDENTSearchErrors.Add(item.errors)
    End Sub
'End Record Form STUDENTSearch LoadItemFromRequest method

'Record Form STUDENTSearch GetRedirectUrl method @10-725C1A25

    Protected Function GetSTUDENTSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "StudentEnrolment_InitialCheck.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENTSearch GetRedirectUrl method

'Record Form STUDENTSearch ShowErrors method @10-1C937A91

    Protected Sub STUDENTSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENTSearchErrors.Count - 1
        Select Case STUDENTSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENTSearchErrors(i)
        End Select
        Next i
        STUDENTSearchError.Visible = True
        STUDENTSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENTSearch ShowErrors method

'Record Form STUDENTSearch Insert Operation @10-41CE0F87

    Protected Sub STUDENTSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTSearchItem = New STUDENTSearchItem()
        STUDENTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENTSearch Insert Operation

'Record Form STUDENTSearch BeforeInsert tail @10-90C102AB
    STUDENTSearchParameters()
    STUDENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENTSearch BeforeInsert tail

'Record Form STUDENTSearch AfterInsert tail  @10-66E9745E
        ErrorFlag=(STUDENTSearchErrors.Count > 0)
        If ErrorFlag Then
            STUDENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENTSearch AfterInsert tail 

'Record Form STUDENTSearch Update Operation @10-49C7EA22

    Protected Sub STUDENTSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTSearchItem = New STUDENTSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        STUDENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENTSearch Update Operation

'Record Form STUDENTSearch Before Update tail @10-90C102AB
        STUDENTSearchParameters()
        STUDENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENTSearch Before Update tail

'Record Form STUDENTSearch Update Operation tail @10-66E9745E
        ErrorFlag=(STUDENTSearchErrors.Count > 0)
        If ErrorFlag Then
            STUDENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENTSearch Update Operation tail

'Record Form STUDENTSearch Delete Operation @10-268559B4
    Protected Sub STUDENTSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENTSearchItem = New STUDENTSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENTSearch Delete Operation

'Record Form BeforeDelete tail @10-90C102AB
        STUDENTSearchParameters()
        STUDENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @10-12F51A07
        If ErrorFlag Then
            STUDENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENTSearch Cancel Operation @10-0DAF015A

    Protected Sub STUDENTSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTSearchItem = New STUDENTSearchItem()
        STUDENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENTSearchLoadItemFromRequest(item, True)
'End Record Form STUDENTSearch Cancel Operation

'Record Form STUDENTSearch Cancel Operation tail @10-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENTSearch Cancel Operation tail

'Record Form STUDENTSearch Search Operation @10-C6E4BA0C
    Protected Sub STUDENTSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        STUDENTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As STUDENTSearchItem = New STUDENTSearchItem()
        STUDENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENTSearch Search Operation

'Button Button_DoSearch OnClick. @11-E6E12186
        If CType(sender,Control).ID = "STUDENTSearchButton_DoSearch" Then
            RedirectUrl = GetSTUDENTSearchRedirectUrl("", "s_SURNAME;s_FIRST_NAME;s_BIRTH_DATE;s_STUDENT_ID;s_Email")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @11-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form STUDENTSearch Search Operation tail @10-3ABA2575
        ErrorFlag = STUDENTSearchErrors.Count > 0
        If ErrorFlag Then
            STUDENTSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(STUDENTSearchs_SURNAME.Text <> "",("s_SURNAME=" & Server.UrlEncode(STUDENTSearchs_SURNAME.Text) & "&"), "")
            Params = Params & IIf(STUDENTSearchs_FIRST_NAME.Text <> "",("s_FIRST_NAME=" & Server.UrlEncode(STUDENTSearchs_FIRST_NAME.Text) & "&"), "")
            Params = Params & IIf(STUDENTSearchs_BIRTH_DATE.Text <> "",("s_BIRTH_DATE=" & Server.UrlEncode(STUDENTSearchs_BIRTH_DATE.Text) & "&"), "")
            Params = Params & IIf(STUDENTSearchs_STUDENT_ID.Text <> "",("s_STUDENT_ID=" & Server.UrlEncode(STUDENTSearchs_STUDENT_ID.Text) & "&"), "")
            Params = Params & IIf(STUDENTSearchs_Email.Text <> "",("s_Email=" & Server.UrlEncode(STUDENTSearchs_Email.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENTSearch Search Operation tail

'Grid STUDENT Bind @3-98D4AEB3

    Protected Sub STUDENTBind()
        If Not STUDENTOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT",GetType(STUDENTDataProvider.SortFields), 40, 100)
        End If
'End Grid STUDENT Bind

'Grid Form STUDENT BeforeShow tail @3-4C03367A
        STUDENTParameters()
        STUDENTData.SortField = CType(ViewState("STUDENTSortField"),STUDENTDataProvider.SortFields)
        STUDENTData.SortDir = CType(ViewState("STUDENTSortDir"),SortDirections)
        STUDENTData.PageNumber = CInt(ViewState("STUDENTPageNumber"))
        STUDENTData.RecordsPerPage = CInt(ViewState("STUDENTPageSize"))
        STUDENTRepeater.DataSource = STUDENTData.GetResultSet(PagesCount, STUDENTOperations)
        ViewState("STUDENTPagesCount") = PagesCount
        Dim item As STUDENTItem = New STUDENTItem()
        STUDENTRepeater.DataBind
        FooterIndex = STUDENTRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENTRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim STUDENTlink_AddNewStudent As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STUDENTRepeater.Controls(FooterIndex).FindControl("STUDENTlink_AddNewStudent"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STUDENTRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim STUDENTlblWarningExistingStudent As System.Web.UI.WebControls.Literal = DirectCast(STUDENTRepeater.Controls(0).FindControl("STUDENTlblWarningExistingStudent"),System.Web.UI.WebControls.Literal)
        Dim STUDENTLabel1 As System.Web.UI.WebControls.Literal = DirectCast(STUDENTRepeater.Controls(FooterIndex).FindControl("STUDENTLabel1"),System.Web.UI.WebControls.Literal)
        Dim STUDENTlink_AddNewStudent1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STUDENTRepeater.Controls(FooterIndex).FindControl("STUDENTlink_AddNewStudent1"),System.Web.UI.HtmlControls.HtmlAnchor)

        item.link_AddNewStudentHref = "StudentEnrolment_DetailsWizard.aspx"
        item.link_AddNewStudentHrefParameters.Add("s_SURNAME",Request.QueryString,"s_SURNAME")
        item.link_AddNewStudentHrefParameters.Add("s_FIRST_NAME",Request.QueryString,"s_FIRST_NAME")
        item.link_AddNewStudentHrefParameters.Add("s_BIRTH_DATE",Request.QueryString,"s_BIRTH_DATE")
        item.link_AddNewStudent1Href = "StudentEnrolment_DetailsWizard.aspx"
        item.link_AddNewStudent1HrefParameters.Add("s_SURNAME",Request.QueryString,"s_SURNAME")
        item.link_AddNewStudent1HrefParameters.Add("s_FIRST_NAME",Request.QueryString,"s_FIRST_NAME")
        item.link_AddNewStudent1HrefParameters.Add("s_BIRTH_DATE",Request.QueryString,"s_BIRTH_DATE")
        STUDENTlink_AddNewStudent.InnerText += item.link_AddNewStudent.GetFormattedValue().Replace(vbCrLf,"")
        STUDENTlink_AddNewStudent.HRef = item.link_AddNewStudentHref+item.link_AddNewStudentHrefParameters.ToString("None","", ViewState)
        STUDENTlblWarningExistingStudent.Text = Server.HtmlEncode(item.lblWarningExistingStudent.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTLabel1.Text = Server.HtmlEncode(item.Label1.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTlink_AddNewStudent1.InnerText += item.link_AddNewStudent1.GetFormattedValue().Replace(vbCrLf,"")
        STUDENTlink_AddNewStudent1.HRef = item.link_AddNewStudent1Href+item.link_AddNewStudent1HrefParameters.ToString("None","", ViewState)
'End Grid Form STUDENT BeforeShow tail

		DisplayWarningsForPartialMatches(STUDENTLabel1, STUDENTlink_AddNewStudent1)
		
'Link link_AddNewStudent Event BeforeShow. Action Hide-Show Component @36-044DB957
        Dim Urls_SURNAME_36_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_SURNAME"))
        Dim ExprParam2_36_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_SURNAME_36_1, ExprParam2_36_2) Then
            STUDENTlink_AddNewStudent.Visible = False
        End If
'End Link link_AddNewStudent Event BeforeShow. Action Hide-Show Component

	

'Label lblWarningExistingStudent Event BeforeShow. Action Hide-Show Component @42-4D9C1B9B
        Dim IsEmpty_42_1 As BooleanField = New BooleanField(Settings.BoolFormat,STUDENTData.IsEmpty)
        Dim ExprParam2_42_2 As BooleanField = New BooleanField(Settings.BoolFormat, (true))
        If FieldBase.EqualOp(IsEmpty_42_1, ExprParam2_42_2) Then
            STUDENTlblWarningExistingStudent.Visible = False
        End If
'End Label lblWarningExistingStudent Event BeforeShow. Action Hide-Show Component

'Link link_AddNewStudent1 Event BeforeShow. Action Hide-Show Component @191-A674F7D3
        Dim Urls_SURNAME_191_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_SURNAME"))
        Dim ExprParam2_191_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_SURNAME_191_1, ExprParam2_191_2) Then
            STUDENTlink_AddNewStudent.Visible = False
        End If
'End Link link_AddNewStudent1 Event BeforeShow. Action Hide-Show Component

'Grid STUDENT Bind tail @3-E31F8E2A
    End Sub
'End Grid STUDENT Bind tail

Private Sub DisplayWarningsForPartialMatches(ByRef STUDENTLabel1 As Literal, ByRef STUDENTlink_AddNewStudent1 As HtmlAnchor)
         Dim data = STUDENTRepeater.DataSource
         Debug.WriteLine(data)
         Dim list = CType(data, STUDENTItem())
         If list.Count > 0
            'Student match has been found. Run a few checks to check partial matches and display warnings

            Dim student = list(0)
            Dim emailForStudentInDB = student("EMAIL").Value.ToString().Trim()
            Dim emailEntered = STUDENTSearchs_Email.Text.ToString().Trim

            Dim firstNameForStudentInDB = student("FIRST_NAME").Value.ToString().Trim()
            Dim preferredNameForStudentInDB = student("PREFERRED_NAME").Value?.ToString().Trim
            Dim firstNameEntered = STUDENTSearchs_FIRST_NAME.Text.ToString().Trim

            Dim surnameForStudentInDB = student("SURNAME").Value?.ToString().Trim()
            Dim surnameEntered = STUDENTSearchs_Surname.Text.ToString().Trim

            Dim dobForStudentInDB = student("BIRTH_DATE").Value

            Dim dobEntered As DateTime 
            Dim dobValid = DateTime.TryParse(STUDENTSearchs_BIRTH_DATE.Text, dobEntered)

            'Emails Match, but other details don't
            If emailForStudentInDb = emailEntered AndAlso
                 (
                    String.Equals(surnameEntered, surnameForStudentInDB, StringComparison.InvariantCultureIgnoreCase) = False or
                    (String.Equals(firstNameEntered, firstNameForStudentInDB, StringComparison.InvariantCultureIgnoreCase) = False AndAlso String.Equals(firstNameEntered, preferredNameForStudentInDB, StringComparison.InvariantCultureIgnoreCase) = False) or
                    dobEntered <> dobForStudentInDB
                 )
               STUDENTLabel1.Visible = True
               STUDENTlink_AddNewStudent1.Visible = False
               STUDENTLabel1.Text = $"The email address {emailEntered} is already used by a student but the name or date of birth entered do not match. If they are the same student you can add a new year, if it is a different student you need find out their correct email address."

               'Details Match but email is wrong
            elseIf emailForStudentInDb <> emailEntered AndAlso
                 (
                    String.Equals(surnameEntered, surnameForStudentInDB, StringComparison.InvariantCultureIgnoreCase) or
                    (String.Equals(firstNameEntered, firstNameForStudentInDB, StringComparison.InvariantCultureIgnoreCase) Or String.Equals(firstNameEntered, firstNameForStudentInDB, StringComparison.InvariantCultureIgnoreCase)) or
                    String.Equals(dobEntered, dobForStudentInDB, StringComparison.InvariantCultureIgnoreCase)
                 )
               STUDENTLabel1.Visible = True
               STUDENTlink_AddNewStudent1.Visible = True
               STUDENTLabel1.Text = $"The email address entered ({emailEntered}) does not match email in database ({emailForStudentInDB}). Check carefuly if they are the same student, or a different student with the same name. If you are sure they are a new student, you can "

               'No warning, hide label
            else
               STUDENTLabel1.Visible = False
               STUDENTlink_AddNewStudent1.Visible = False
            End If
         Else
            STUDENTlink_AddNewStudent1.Visible = False
            STUDENTLabel1.Visible = False
         End If
End Sub

'Grid STUDENT Table Parameters @3-F2A84521

    Protected Sub STUDENTParameters()
        Try
            STUDENTData.Urls_SURNAME = TextParameter.GetParam("s_SURNAME", ParameterSourceType.URL, "", Nothing, false)
            STUDENTData.Urls_FIRST_NAME = TextParameter.GetParam("s_FIRST_NAME", ParameterSourceType.URL, "", Nothing, false)
            STUDENTData.Urls_BIRTH_DATE = DateParameter.GetParam("s_BIRTH_DATE", ParameterSourceType.URL, Settings.DateFormat, now(), false)
            STUDENTData.Urls_STUDENT_ID = FloatParameter.GetParam("s_STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENTData.Urls_Email = TextParameter.GetParam("s_Email", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENTRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENTRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT Table Parameters

'Grid STUDENT ItemDataBound event @3-C9B31B36

    Protected Sub STUDENTItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENTItem = CType(e.Item.DataItem,STUDENTItem)
        Dim Item as STUDENTItem = DataItem
        Dim FormDataSource As STUDENTItem() = CType(STUDENTRepeater.DataSource, STUDENTItem())
        Dim STUDENTDataRows As Integer = FormDataSource.Length
        Dim STUDENTIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENTCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENTRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENTCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENTLink1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENTLink1"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENTSTUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENTSTUDENT_ID"),System.Web.UI.WebControls.Literal)
            Dim STUDENTSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENTSURNAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENTFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENTFIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENTBIRTH_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENTBIRTH_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENTSEX As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENTSEX"),System.Web.UI.WebControls.Literal)
            Dim STUDENTPREFERRED_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENTPREFERRED_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENTEMAIL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENTEMAIL"),System.Web.UI.WebControls.Literal)
            DataItem.Link1Href = "StudentEnrolment_AddNewYear.aspx"
            DataItem.Link1HrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode((year(now())).ToString()))
            STUDENTLink1.HRef = DataItem.Link1Href & DataItem.Link1HrefParameters.ToString("None","", ViewState)
        End If
'End Grid STUDENT ItemDataBound event

'Grid STUDENT BeforeShowRow event @3-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid STUDENT BeforeShowRow event

'Grid STUDENT Event BeforeShowRow. Action Set Row Style @21-B648EFAB
            Dim styles21 As String() = Regex.Split("Row;AltRow","(?<!\\);")
            Dim styleIndex21 As Integer = (STUDENTCurrentRowNumber - 1) Mod styles21.Length
            Dim rawStyle21 As String = styles21(styleIndex21).Replace("\;",";")
            If rawStyle21.IndexOf("=") = -1 And rawStyle21.IndexOf(":") > -1 Then
                rawStyle21 = "style=""" + rawStyle21 + """"
            ElseIf rawStyle21.IndexOf("=") = -1 And rawStyle21.IndexOf(":") = -1 And rawStyle21 <> "" Then
                rawStyle21 = "class=""" + rawStyle21 + """"
            End If
            CType(Page,CCPage).ControlAttributes.Add(STUDENTRepeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle21), AttributeOption.Multiple)
'End Grid STUDENT Event BeforeShowRow. Action Set Row Style

'Grid STUDENT BeforeShowRow event tail @3-477CF3C9
        End If
'End Grid STUDENT BeforeShowRow event tail

'Grid STUDENT ItemDataBound event tail @3-A42A7367
        If STUDENTIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENTCurrentRowNumber, ListItemType.Item)
            STUDENTRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENTItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT ItemDataBound event tail



'Grid STUDENT ItemCommand event @3-8935F766

    Protected Sub STUDENTItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENTRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENTSortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENTSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENTSortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENTSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENTSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENTDataProvider.SortFields = 0
            ViewState("STUDENTSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENTPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENTPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENTPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENTPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENTBind
        End If
    End Sub
'End Grid STUDENT ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-A1C070BA
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentEnrolment_InitialCheckContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENTSearchData = New STUDENTSearchDataProvider()
        STUDENTSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        STUDENTData = New STUDENTDataProvider()
        STUDENTOperations = New FormSupportedOperations(False, True, False, False, False)
'End OnInit Event Body

'OnInit Event tail @1-BB95D25C
    PageStyleName = Server.UrlEncode(PageStyleName)
    End Sub
'End OnInit Event tail

'InitializeComponent Event @1-EA5E2628
    ' <summary>
    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
    End Sub
    #End Region
'End InitializeComponent Event

'Page class tail @1-DD082417
End Class
End Namespace
'End Page class tail

