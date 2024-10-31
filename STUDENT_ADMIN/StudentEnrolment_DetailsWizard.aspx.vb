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
Imports System.Linq
'End Using Statements

Namespace DECV_PROD2007.StudentEnrolment_DetailsWizard 'Namespace @1-00085B82

'Forms Definition @1-8F7B7787
Public Class [StudentEnrolment_DetailsWizardPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-EDF9F89F
        Protected StudentEnrolment_DetailsWizardContentMeta As String
        Protected tmpNewStudentID As Long
        Protected strCategoryCode As String = ""
        Protected strSubCategoryCode As String = ""

        'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

            'Page_Load Event BeforeIsPostBack @1-F83326CF
            Dim item As PageItem = PageItem.CreateFromHttpRequest()

            ' take all the Form values and update the Confirmation page labels (on every postback)
            With Me
                'Details
                .conf_lblEnrolmentYear.Text = .txtEnrolmentYear.Text
                .conf_lblSurname.Text = .txtSurname.Text ' LN: 28/11/2013 .ToUpper
                .conf_lblFirstName.Text = .txtFirstName.Text ' LN: 28/11/2013 .ToUpper
                .conf_lblPreferredName.Text = .txtPreferredName.Text
                .conf_lblMiddleName.Text = .txtMiddleName.Text ' LN: 28/11/2013 .ToUpper
                .conf_lblyearlevel.Text = .listYearLevel.SelectedValue.ToString
                .conf_lblDOB.Text = Format("dd/MM/yyyy", .txtDateOfBirth.Text)
                .conf_EnrolledBefore.Text = IIf(chkbox_EnrolledBefore.Checked = True, "True", "False")
                .conf_VSN.text = IIf(txtVSN.Text <> "", txtVSN.Text, "Unknown")

                ' LN: 25/11/2013 Commented out.
                'If RB_Discount.SelectedValue = "Y" Then
                '    .conf_lblFunded.Text = "Yes"
                'Else
                '    .conf_lblFunded.Text = "No"
                'End If

                  Dim gender As String = Nothing
                  Dim genderSelfDescribed As String = Nothing
                  If (Not radioPreferredGender.SelectedValue.Equals("")) Then
                     gender = radioPreferredGender.SelectedValue
                     ' We only care about capturing the birth sex if a non-MF preferred gender has been provided.
                     If (radioPreferredGender.SelectedValue.Equals("X")) Then
                        genderSelfDescribed = txtGenderSelfDescribed.Text.Trim()
                     End If
                  Else
                     gender = radioBirthSex.SelectedValue
                  End If

                If gender = "M" Then
                    .conf_lblSex.Text = "Male"
                Else If (gender = "F")
                    .conf_lblSex.Text = "Female"
                Else
                    .conf_lblSex.Text = "Self-described (" & genderSelfDescribed & ")"
                End If

                '******************************
                'Date Modified : 21 July 2009
                'Modified by : Vikas
                'Ref: Unfuddle Ticket No: 57
                'Task: VSN implmentations
                '******************Code Starts Here******************
                If txtVSN.Text <> "" Then
                    'validate VSN Number with weight factor
                    Dim arrVSN(8) As String
                    Dim totalVSN As Integer
                    Dim rmnder As Integer
                    Dim wtFactor() As String = {"1", "4", "3", "7", "5", "8", "6", "9", "10"}

                    For i As Integer = 0 To txtVSN.Text.Length - 1
                        arrVSN(i) = Mid(txtVSN.Text, i + 1, 1)
                    Next

                    For i As Integer = 0 To 8
                        totalVSN = totalVSN + (CInt(arrVSN(i)) * CInt(wtFactor(i)))
                    Next
                    rmnder = totalVSN Mod 11
                    If rmnder > 0 Then
                        Page.RegisterStartupScript("error", "<script language='javascript'>alert('Invalid VSN Number')</script>")
                        Response.Write("Invalid VSN")
                    End If

                End If

                'Validate Emails address
               ' Dim newEmail = StudentEmailNew.Text
               'If Not String.IsNullOrWhiteSpace(newEmail)
               '   dim valid = ValidateEmail()
                  
               'Else
               '   Debug.WriteLine($"Email blank")
               '      Response.Write("Email blank")
               'End If


                '******************Code Ends Here******************
                .conf_lblCategory.Text = "unknown"
                .conf_lblSubCategory.Text = "unknown"
                If Me.listCategory.SelectedValue <> "" Then
                    strCategoryCode = Split(Me.listCategory.SelectedValue, "|")(0)
                    strSubCategoryCode = Split(Me.listCategory.SelectedValue, "|")(1)

                    .conf_lblCategory.Text = strCategoryCode.ToUpper
                    .conf_lblSubCategory.Text = strSubCategoryCode.ToUpper
                End If

                ' school
                .conf_lblAttendingSchoolName.Text = "unknown"
                If (.txtAttendingSchoolID.Text <> "") Then
                    .conf_lblAttendingID.Text = .txtAttendingSchoolID.Text.ToString
                    '******************************
                    'Date Modified : 21 July 2009
                    'Modified by : Vikas
                    'Ref: Unfuddle Ticket No: 57
                    'Task: School Address on New Enrolments
                    '******************Code Starts Here******************
                    If txtAttendingSchoolID_hidden.Value <> "" Then
                        If txtAttendingSchoolID_hidden.Value <> .txtAttendingSchoolID.Text.ToString Then
                            'Get Address id corrosponding to school id selected
                            .chkbox_same_as_attending.Checked = False
                            .txtaddressee_1.Text = ""
                            .txtagent_1.Text = ""
                            .txtaddr1_1.Text = ""
                            .txtaddr2_1.Text = ""
                            .txtcountry_1.Text = ""
                            .txtstate_1.Text = ""
                            .txtsuburb_town_1.Text = ""
                            .txtpostcode_1.Text = ""
                            .txtfax_1.Text = ""
                            .txtphonea_1.Text = ""
                            .txtphoneb_1.Text = ""
                            .txtemail_address_1.Text = ""
                            .txtemail_address_1b.Text = ""
                            txtAttendingSchoolID_hidden.Value = .txtAttendingSchoolID.Text.ToString
                            'Get Address id corrosponding to school id selected
                            txtSchoolAddressId_hidden.Value = GetSchoolAddressId(txtAttendingSchoolID_hidden.Value)

                        End If
                    Else
                        txtAttendingSchoolID_hidden.Value = .txtAttendingSchoolID.Text.ToString
                        'Get Address id corrosponding to school id selected
                        txtSchoolAddressId_hidden.Value = GetSchoolAddressId(txtAttendingSchoolID_hidden.Value)
                    End If
                    '******************Code Ends Here******************
                    .conf_lblAttendingSchoolName.Text = (New TextField("", DECV_PROD2007.Configuration.Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT rtrim(SCHOOL_NAME) as [SCHOOL_NAME]  FROM SCHOOL WHERE SCHOOL_ID = " & .txtAttendingSchoolID.Text.ToString))).GetFormattedValue()
                End If
                .conf_lblHomeSchoolName.Text = "unknown"
                If (.txtHomeSchoolID.Text <> "") Then
                    .conf_lblHomeID.Text = txtHomeSchoolID.Text.ToString
                    .conf_lblHomeSchoolName.Text = (New TextField("", DECV_PROD2007.Configuration.Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT rtrim(SCHOOL_NAME) as [SCHOOL_NAME]  FROM SCHOOL WHERE SCHOOL_ID = " & .txtHomeSchoolID.Text.ToString))).GetFormattedValue()
                End If

                'Enrolment Comments
                .conf_lblComments.Text = .txtareacomments.Text.ToString

                '2-Dec-2011|EA| show the Privacy selection
                'If .radioPrivacyPermission.SelectedValue.ToString = "1" Then
                .conf_lblPrivacyPermission.Text = "I DO give Permission to be recorded."
                'Else
                '.conf_lblPrivacyPermission.Text = "I DO NOT give Permission to be recorded."
                'End If

                ' Student Email and Mobile number, above Postal Address
                .conf_lblStudentEmail.Text = .txtStudentEmail.Text.Replace("'", "''").Trim
                .conf_lblStudentMobile.Text = .txtStudentMobile.Text.Trim

                'Postal Address
                .chkbox_same_as_attending_confirm.Checked = .chkbox_same_as_attending.Checked
                .chkbox_same_as_attending_confirm.Enabled = False
                .conf_lbladdressee_1.Text = .txtaddressee_1.Text.ToUpper
                .conf_lblagent_1.Text = .txtagent_1.Text.ToUpper
                .conf_lbladdr1_1.Text = .txtaddr1_1.Text.ToUpper
                .conf_lbladdr2_1.Text = .txtaddr2_1.Text.ToUpper
                .conf_lblcountry_1.Text = .txtcountry_1.Text.ToUpper
                .conf_lblstate_1.Text = .txtstate_1.Text.ToUpper
                .conf_lblsuburb_town_1.Text = .txtsuburb_town_1.Text.ToUpper
                .conf_lblpostcode_1.Text = .txtpostcode_1.Text.ToUpper
                .conf_lblfax_1.Text = .txtfax_1.Text.ToUpper
                .conf_lblphonea_1.Text = .txtphonea_1.Text.ToUpper
                .conf_lblphoneb_1.Text = .txtphoneb_1.Text.ToUpper
                .conf_lblemail_address_1.Text = .txtemail_address_1.Text.ToString       '10-Sept-2008|EA| no conversion
                .conf_lblemail_address_1b.Text = .txtemail_address_1b.Text.ToString       '29-Jan-2009|EA| added field

            End With

            If Not IsPostBack Then

                Session("WizardCheckCounter") = 0
                Dim PageData As PageDataProvider = New PageDataProvider()
                PageData.FillItem(item)
                'default to first page
                Me.Wizard_AddStudent.ActiveStepIndex = 0

                If Me.Wizard_AddStudent.ActiveStepIndex = 0 Then
                    If (Not IsNothing(Request.QueryString("s_SURNAME"))) Then
                        Me.txtSurname.Text = (Request.QueryString("s_SURNAME").ToString) ' LN: 28/11/2013 .ToUpper)
                    End If
                    If (Not IsNothing(Request.QueryString("s_FIRST_NAME"))) Then
                        Me.txtFirstName.Text = (Request.QueryString("s_FIRST_NAME").ToString) ' LN: 28/11/2013 .ToUpper)
                    End If
                    If (Not IsNothing(Request.QueryString("s_BIRTH_DATE"))) Then
                        Me.txtDateOfBirth.Text = Format("dd/MM/yyyy", Request.QueryString("s_BIRTH_DATE").ToString)
                    Else
                        Me.txtDateOfBirth.Text = ""
                    End If
                    If (Me.txtDateOfBirth.Text = "dd/MM/yyyy") Then
                        Me.txtDateOfBirth.Text = ""
                    End If


                End If

                ''set up the category drop down
                With Me.SqlDataSource_Category
                    .ConnectionString = DECV_PROD2007.Configuration.Settings.connDECVPRODSQL2005Connection.Connection
                    '.ConnectionString = "Password=vikas;Persist Security Info=True;User ID=vblocal;Initial Catalog=STUDENT_ADMIN;Data Source=D760-TECH-VB\MSSQLSERVER_2008"
                    '.ConnectionString = "Password=redr0ck;Persist Security Info=True;User ID=webmaster;Initial Catalog=STUDENT_ADMIN;Data Source=decv-db1"
                    .SelectCommand = "select (rtrim(CATEGORY_CODE) +'|'+ rtrim(SUBCATEGORY_CODE)) as [CATSUBCAT_VALUE], rtrim(SUBCATEGORY_FULL_TITLE) as SUBCATEGORY_FULL_TITLE from ENROLMENT_CATEGORY where STATUS=1 order by rtrim(SUBCATEGORY_FULL_TITLE)"
                    .DataBind()
                End With

                '23-Mar-2009|EA| set up the Regions drop down
                With Me.SqlDataSource_Regions
                    .ConnectionString = DECV_PROD2007.Configuration.Settings.connDECVPRODSQL2005Connection.Connection
                    '.ConnectionString = "Password=vikas;Persist Security Info=True;User ID=vblocal;Initial Catalog=STUDENT_ADMIN;Data Source=D760-TECH-VB\MSSQLSERVER_2008"
                    '.ConnectionString = "Password=redr0ck;Persist Security Info=True;User ID=webmaster;Initial Catalog=STUDENT_ADMIN;Data Source=decv-db1"
                    .SelectCommand = "SELECT REGION_ID, rtrim(REGION_NAME) AS region_name_display FROM REGION ORDER BY REGION_NAME"
                    .DataBind()
                End With

                ' set defaults
                Me.txtEnrolmentDate.Text = Format(DateTime.Today, "dd/MM/yyyy")
                '01-Dec-2008|EA|Auto rollover from 1 Dec to next year's enrolment
                '(IIF((month(now())<=11),(year(now())), (year(now())+1)))  -- code from Codecharge page, alter to work here
                '27-Oct-2017|EA| change to new year in October per 2018 enrolments
                If (DateTime.Today.Month <= 9) Then
                    Me.txtEnrolmentYear.Text = DateTime.Today.Year.ToString
                Else
                    Me.txtEnrolmentYear.Text = (DateTime.Today.Year + 1).ToString
                End If
            End If
            'End Page_Load Event BeforeIsPostBack

            ''If Wizard_AddStudent.WizardSteps(Wizard_AddStudent.ActiveStepIndex).Name = "Address" Then
            ''    div_StudentExist.Style.Add("display", "none")
            'If Session("WizardCheckCounter") = 1 Then
            '    Display_ExistingStudentDiv()
            'Else
            '    div_StudentExist.Style.Add("display", "none")
            'End If


        End Sub 'Page_Load Event tail @1-E31F8E2A

      Private function ValidateEmail() as boolean
         
      End function

      Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

        End Sub 'Page_Unload Event tail @1-E31F8E2A
        '******************************
        'Date Modified : 21 July 2009
        'Modified by : Vikas
        'Ref: Unfuddle Ticket No: 57
        'Task: School Address on New Enrolments
        '******************Code Starts Here******************
        Function GetSchoolAddressId(ByVal SchoolId As String) As String
            Dim strAddressId
            strAddressId = DECV_PROD2007.Configuration.Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select ADDRESS_ID from SCHOOL where SCHOOL_ID=" & SchoolId)
            Return strAddressId
        End Function
        '******************Code Ends Here******************

'OnInit Event @1-9A96B80D
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentEnrolment_DetailsWizardContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
'End OnInit Event

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

        'Protected Sub Wizard_AddStudent_ActiveStepChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Wizard_AddStudent.ActiveStepChanged
        '    If Wizard_AddStudent.WizardSteps(Wizard_AddStudent.ActiveStepIndex).Name = "Address" Then
        '        div_StudentExist.Style.Add("display", "none")
        '    End If
        'End Sub

       

        'Protected Sub Wizard_AddStudent_ActiveStepChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Wizard_AddStudent.ActiveStepChanged
        '    'Set the focus to the first TextBox in the current step
        '    Dim currentWizardStep As WizardStepBase = Wizard_AddStudent.ActiveStep

        '    'Find the first TextBox
        '    Dim firstTextBox As TextBox = FindFirstTextBox(currentWizardStep)

        '    'If we found a TextBox, set the Focus
        '    If Not firstTextBox Is Nothing Then
        '        firstTextBox.Focus()
        '    End If
        'End Sub
'End InitializeComponent Event

'Page class tail @1-DD082417

        Protected Sub Wizard_AddStudent_FinishButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles Wizard_AddStudent.FinishButtonClick
            ' do all the inserting of data and respond with the Student Number
            If (Me.hidden_StudentEnrolled.Value = "0") Then
                ' put some of the values into the database (starts line 666 in add_new_confirm_update.ssc)
                Dim tmpPostalAddressID As Integer = -1
                Dim tmpCurrAddressID As Integer = -1
                Dim tmpOrigAddressID As Integer = -1
                Dim tmpSchoolAddressID As Integer = -1

                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
                'Dim trans As OleDb.OleDbTransaction		'for Live
                'Dim cmd As OleDb.OleDbCommand		'for Live

                Dim trans As SqlClient.SqlTransaction		'for Vikas/Staging
                Dim cmd As SqlClient.SqlCommand		'for Vikas/Staging
                Try
                    ' a little more formal than the Sybase 'begin trans' statement
                    If NewDao.NativeConnection.State <> ConnectionState.Open Then
                        NewDao.NativeConnection.Open()
                        'NewDao.DateFormat = "mdy"
                    End If

                    trans = NewDao.NativeConnection.BeginTransaction()
                    cmd = NewDao.NativeConnection.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.Transaction = trans

                    Dim strSQL As String = ""

                  


                    'Sort out Address depending on checkboxes, and get @@IDENTITY from Address table into tmpPostalAddressID, tmpCurrAddressID, tmpOrigAddressID
                    ' Postal Address if NOT same as Attending School
                    '10-Sept-2008|EA| no conversion of email to upper
                    '29-Jan-2009|EA| added EMAIL_ADDRESS2/ txtemail_address_1b
                    If (Me.chkbox_same_as_attending.Checked = False) Then

                     
                        cmd.Parameters.Clear()
                        strSQL = "insert into ADDRESS(ADDRESSEE, AGENT, ADDR1, ADDR2, COUNTRY, STATE, SUBURB_TOWN, POSTCODE, FAX, PHONE_A, PHONE_B, EMAIL_ADDRESS, EMAIL_ADDRESS2, LAST_ALTERED_BY, LAST_ALTERED_DATE)"
                        strSQL += " values (@ADDRESSEE, @AGENT, @ADDR1, @ADDR2, @COUNTRY, @STATE, @SUBURB_TOWN, @POSTCODE, @FAX, @PHONE_A,"
                        strSQL += " @PHONE_B, @EMAIL_ADDRESS, @EMAIL_ADDRESS2, @LAST_ALTERED_BY, GETDATE())"

                        cmd.CommandText = strSQL
                        cmd.Parameters.AddWithValue("ADDRESSEE", IIf(Me.txtaddressee_1.Text <> "", prepStringForSQL(Me.txtaddressee_1.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("AGENT", IIf(Me.txtagent_1.Text <> "", prepStringForSQL(Me.txtagent_1.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("ADDR1", IIf(Me.txtaddr1_1.Text <> "", prepStringForSQL(Me.txtaddr1_1.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("ADDR2", IIf(Me.txtaddr2_1.Text <> "", prepStringForSQL(Me.txtaddr2_1.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("COUNTRY", IIf(Me.txtcountry_1.Text <> "", prepStringForSQL(Me.txtcountry_1.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("STATE", IIf(Me.txtstate_1.Text <> "", prepStringForSQL(Me.txtstate_1.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("SUBURB_TOWN", IIf(Me.txtsuburb_town_1.Text <> "", prepStringForSQL(Me.txtsuburb_town_1.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("POSTCODE", IIf(Me.txtpostcode_1.Text <> "", prepStringForSQL(Me.txtpostcode_1.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("FAX", IIf(Me.txtfax_1.Text <> "", prepStringForSQL(Me.txtfax_1.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("PHONE_A", IIf(Me.txtphonea_1.Text <> "", prepStringForSQL(Me.txtphonea_1.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("PHONE_B", IIf(Me.txtphoneb_1.Text <> "", prepStringForSQL(Me.txtphoneb_1.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("EMAIL_ADDRESS", IIf(Me.txtemail_address_1.Text <> "", prepStringForSQL(Me.txtemail_address_1.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("EMAIL_ADDRESS2", IIf(Me.txtemail_address_1b.Text <> "", prepStringForSQL(Me.txtemail_address_1b.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("LAST_ALTERED_BY", DBUtility.UserLogin.ToUpper)

                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "SELECT @@IDENTITY "
                        tmpPostalAddressID = CLng(cmd.ExecuteScalar())
                    Else
                        ' get the attending school address ID
                        If (Me.txtAttendingSchoolID.Text <> "") Then
                            tmpSchoolAddressID = (New TextField("", DECV_PROD2007.Configuration.Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT ADDRESS_ID FROM SCHOOL WHERE SCHOOL_ID = " & Me.txtAttendingSchoolID.Text.ToString))).GetFormattedValue()
                            If tmpSchoolAddressID > 0 Then
                                tmpPostalAddressID = tmpSchoolAddressID
                            Else
                                tmpPostalAddressID = -1
                            End If
                        End If

                    End If

                    'Insert Current Residential Address

                    If (Me.chkbox_same_as_postal.Checked) Then
                        tmpCurrAddressID = tmpPostalAddressID
                    Else
                        If (Me.txtaddressee_2.Text.ToString <> "") Then
                      
                            cmd.Parameters.Clear()
                            strSQL = "insert into ADDRESS(ADDRESSEE, AGENT, ADDR1, ADDR2, COUNTRY, STATE, SUBURB_TOWN, POSTCODE, FAX, PHONE_A, PHONE_B, EMAIL_ADDRESS, EMAIL_ADDRESS2, LAST_ALTERED_BY, LAST_ALTERED_DATE)"
                            strSQL += " values (@ADDRESSEE, @AGENT, @ADDR1, @ADDR2, @COUNTRY, @STATE, @SUBURB_TOWN, @POSTCODE, @FAX, @PHONE_A,"
                            strSQL += " @PHONE_B, @EMAIL_ADDRESS, @EMAIL_ADDRESS2, @LAST_ALTERED_BY, GETDATE())"

                            cmd.CommandText = strSQL
                            cmd.Parameters.AddWithValue("ADDRESSEE", IIf(Me.txtaddressee_2.Text <> "", prepStringForSQL(Me.txtaddressee_2.Text), DBNull.Value))
                            cmd.Parameters.AddWithValue("AGENT", IIf(Me.txtagent_2.Text <> "", prepStringForSQL(Me.txtagent_2.Text), DBNull.Value))
                            cmd.Parameters.AddWithValue("ADDR1", IIf(Me.txtaddr1_2.Text <> "", prepStringForSQL(Me.txtaddr1_2.Text), DBNull.Value))
                            cmd.Parameters.AddWithValue("ADDR2", IIf(Me.txtaddr2_2.Text <> "", prepStringForSQL(Me.txtaddr2_2.Text), DBNull.Value))
                            cmd.Parameters.AddWithValue("COUNTRY", IIf(Me.txtcountry_2.Text <> "", prepStringForSQL(Me.txtcountry_2.Text), DBNull.Value))
                            cmd.Parameters.AddWithValue("STATE", IIf(Me.txtstate_2.Text <> "", prepStringForSQL(Me.txtstate_2.Text), DBNull.Value))
                            cmd.Parameters.AddWithValue("SUBURB_TOWN", IIf(Me.txtsuburb_town_2.Text <> "", prepStringForSQL(Me.txtsuburb_town_2.Text), DBNull.Value))
                            cmd.Parameters.AddWithValue("POSTCODE", IIf(Me.txtpostcode_2.Text <> "", prepStringForSQL(Me.txtpostcode_2.Text), DBNull.Value))
                            cmd.Parameters.AddWithValue("FAX", IIf(Me.txtfax_2.Text <> "", prepStringForSQL(Me.txtfax_2.Text), DBNull.Value))
                            cmd.Parameters.AddWithValue("PHONE_A", IIf(Me.txtphonea_2.Text <> "", prepStringForSQL(Me.txtphonea_2.Text), DBNull.Value))
                            cmd.Parameters.AddWithValue("PHONE_B", IIf(Me.txtphoneb_2.Text <> "", prepStringForSQL(Me.txtphoneb_2.Text), DBNull.Value))

                            ' LN: 28/11/2013
                            'cmd.Parameters.AddWithValue("EMAIL_ADDRESS", IIf(Me.txtemail_address_2.Text <> "", prepStringForSQL(Me.txtemail_address_2.Text), DBNull.Value))
                            cmd.Parameters.AddWithValue("EMAIL_ADDRESS", IIf(Me.txtStudentEmail.Text <> "", prepStringForSQL(Me.txtStudentEmail.Text), DBNull.Value))

                            cmd.Parameters.AddWithValue("EMAIL_ADDRESS2", IIf(Me.txtemail_address_2b.Text <> "", prepStringForSQL(Me.txtemail_address_2b.Text), DBNull.Value))
                            cmd.Parameters.AddWithValue("LAST_ALTERED_BY", DBUtility.UserLogin.ToUpper)

                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "SELECT @@IDENTITY"
                            tmpCurrAddressID = CLng(cmd.ExecuteScalar())

                        End If
                    End If

                    '//Insert Original Residential Address
                    ' LN: 28/11/2013
                    If (Me.txtaddressee_3.Text.ToString <> "") Then

                        cmd.Parameters.Clear()
                        strSQL = "insert into ADDRESS(ADDRESSEE, AGENT, ADDR1, ADDR2, COUNTRY, STATE, SUBURB_TOWN, POSTCODE, FAX, PHONE_A, PHONE_B, EMAIL_ADDRESS, EMAIL_ADDRESS2, LAST_ALTERED_BY, LAST_ALTERED_DATE)"
                        strSQL += " values (@ADDRESSEE, @AGENT, @ADDR1, @ADDR2, @COUNTRY, @STATE, @SUBURB_TOWN, @POSTCODE, @FAX, @PHONE_A,"
                        strSQL += " @PHONE_B, @EMAIL_ADDRESS, @EMAIL_ADDRESS2, @LAST_ALTERED_BY, GETDATE())"

                        cmd.CommandText = strSQL
                        cmd.Parameters.AddWithValue("ADDRESSEE", IIf(Me.txtaddressee_3.Text <> "", prepStringForSQL(Me.txtaddressee_3.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("AGENT", IIf(Me.txtagent_3.Text <> "", prepStringForSQL(Me.txtagent_3.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("ADDR1", IIf(Me.txtaddr1_3.Text <> "", prepStringForSQL(Me.txtaddr1_3.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("ADDR2", IIf(Me.txtaddr2_3.Text <> "", prepStringForSQL(Me.txtaddr2_3.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("COUNTRY", IIf(Me.txtcountry_3.Text <> "", prepStringForSQL(Me.txtcountry_3.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("STATE", IIf(Me.txtstate_3.Text <> "", prepStringForSQL(Me.txtstate_3.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("SUBURB_TOWN", IIf(Me.txtsuburb_town_3.Text <> "", prepStringForSQL(Me.txtsuburb_town_3.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("POSTCODE", IIf(Me.txtpostcode_3.Text <> "", prepStringForSQL(Me.txtpostcode_3.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("FAX", IIf(Me.txtfax_3.Text <> "", prepStringForSQL(Me.txtfax_3.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("PHONE_A", IIf(Me.txtphonea_3.Text <> "", prepStringForSQL(Me.txtphonea_3.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("PHONE_B", IIf(Me.txtphoneb_3.Text <> "", prepStringForSQL(Me.txtphoneb_3.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("EMAIL_ADDRESS", IIf(Me.txtemail_address_3.Text <> "", prepStringForSQL(Me.txtemail_address_3.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("EMAIL_ADDRESS2", IIf(Me.txtemail_address_3b.Text <> "", prepStringForSQL(Me.txtemail_address_3b.Text), DBNull.Value))
                        cmd.Parameters.AddWithValue("LAST_ALTERED_BY", DBUtility.UserLogin.ToUpper)

                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "SELECT @@IDENTITY"
                        tmpOrigAddressID = CLng(cmd.ExecuteScalar())
                        'STUDENTlblErrorMessages.Text += "<br> tmpOrigAddressID [" & tmpOrigAddressID.ToString() & "]"
                    End If


                    Dim dob As Date
                    Dim gender As String = Nothing
                    Dim birthSex As String = Nothing
                    Dim genderSelfDescribed As String = Nothing
                    If (Not radioPreferredGender.SelectedValue.Equals("")) Then
                        gender = radioPreferredGender.SelectedValue
                        If (radioPreferredGender.SelectedValue.Equals("X")) Then
                           genderSelfDescribed = txtGenderSelfDescribed.Text.Trim()
                           ' At this time we only care about capturing the birth sex if a non-MF preferred gender has been provided.
                            birthSex = radioBirthSex.SelectedValue
                        End If
                    Else
                        gender = radioBirthSex.SelectedValue
                    End If

                    cmd.Parameters.Clear()
                    strSQL = "INSERT INTO [STUDENT](SURNAME,FIRST_NAME,PREFERRED_NAME,MIDDLE_NAME,BIRTH_DATE,SEX,SEX_SELF_DESCRIBED,SEX_BIRTH,CATEGORY_CODE,SUBCATEGORY_CODE,ATTENDING_SCHOOL_ID,HOME_SCHOOL_ID,POSTAL_ADDRESS_ID,CURR_RESID_ADDRESS_ID,ORIG_RESID_ADDRESS_ID,FULL_TIME,BULLETIN_NUMBER,OS_FULL_FEE_PAYING,ENROLMENT_COMMENTS,VCE_CANDIDATE_NUMBER,ADDRESS_REVIEW_FLAG,LAST_ALTERED_BY,LAST_ALTERED_DATE,PARENT1,PARENT2,REGION,VSN,ENROLLEDBEFORE,VERIFY,DATE_STUDENTFOLDER_CREATED, STUDENT_EMAIL, STUDENT_MOBILE)"
                    strSQL += " VALUES (@SURNAME,@FIRST_NAME,@PREFERRED_NAME,@MIDDLE_NAME,@BIRTH_DATE,@SEX,@SEX_SELF_DESCRIBED,@SEX_BIRTH,@CATEGORY_CODE,@SUBCATEGORY_CODE,@ATTENDING_SCHOOL_ID,@HOME_SCHOOL_ID,@POSTAL_ADDRESS_ID,@CURR_RESID_ADDRESS_ID,@ORIG_RESID_ADDRESS_ID,@FULL_TIME,@BULLETIN_NUMBER,@OS_FULL_FEE_PAYING,@ENROLMENT_COMMENTS,@VCE_CANDIDATE_NUMBER,@ADDRESS_REVIEW_FLAG,@LAST_ALTERED_BY,GetDate(),@PARENT1,@PARENT2,@REGION,@VSN,@ENROLLEDBEFORE,@VERIFY,@DATE_STUDENTFOLDER_CREATED,@STUDENT_EMAIL,@STUDENT_MOBILE)"

                    cmd.CommandText = strSQL
                    cmd.Parameters.AddWithValue("SURNAME", IIf(txtSurname.Text <> "", txtSurname.Text.Trim(), DBNull.Value)) ' LN: 28/11/2013 prepStringForSQLNU
                    cmd.Parameters.AddWithValue("FIRST_NAME", IIf(txtFirstName.Text <> "", txtFirstName.Text.Trim(), DBNull.Value)) ' LN: 28/11/2013 prepStringForSQLNU
                    cmd.Parameters.AddWithNull("PREFERRED_NAME", txtPreferredName.Text.Trim())
                    cmd.Parameters.AddWithValue("MIDDLE_NAME", IIf(txtMiddleName.Text <> "", txtMiddleName.Text.Trim(), DBNull.Value)) ' LN: 28/11/2013 prepStringForSQLNU
                    dob = Date.Parse(Me.txtDateOfBirth.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat)
                    cmd.Parameters.AddWithValue("BIRTH_DATE", dob.ToString("yyyy-MM-dd"))                  
                    cmd.Parameters.AddWithNull("SEX", gender)
                    cmd.Parameters.AddWithNull("SEX_SELF_DESCRIBED", genderSelfDescribed)
                    cmd.Parameters.AddWithNull("SEX_BIRTH", birthSex)
                    cmd.Parameters.AddWithValue("CATEGORY_CODE", strCategoryCode.ToUpper())
                    cmd.Parameters.AddWithValue("SUBCATEGORY_CODE", strSubCategoryCode.ToUpper())
                    cmd.Parameters.AddWithValue("ATTENDING_SCHOOL_ID", Me.txtAttendingSchoolID.Text.ToUpper())
                    cmd.Parameters.AddWithValue("HOME_SCHOOL_ID", Me.txtHomeSchoolID.Text.ToUpper())
                    cmd.Parameters.AddWithValue("POSTAL_ADDRESS_ID", IIf(tmpPostalAddressID < 0, DBNull.Value, tmpPostalAddressID))
                    cmd.Parameters.AddWithValue("CURR_RESID_ADDRESS_ID", IIf(tmpCurrAddressID < 0, DBNull.Value, tmpCurrAddressID))
                    cmd.Parameters.AddWithValue("ORIG_RESID_ADDRESS_ID", IIf(tmpOrigAddressID < 0, DBNull.Value, tmpOrigAddressID))
                    cmd.Parameters.AddWithValue("FULL_TIME", "0")
                    cmd.Parameters.AddWithValue("BULLETIN_NUMBER", DBNull.Value)
                    cmd.Parameters.AddWithValue("OS_FULL_FEE_PAYING", "0")
                    cmd.Parameters.AddWithValue("ENROLMENT_COMMENTS", IIf(Me.txtareacomments.Text <> "", Me.txtareacomments.Text.Trim(), DBNull.Value))
                    cmd.Parameters.AddWithValue("VCE_CANDIDATE_NUMBER", "")
                    cmd.Parameters.AddWithValue("ADDRESS_REVIEW_FLAG", "0")
                    cmd.Parameters.AddWithValue("LAST_ALTERED_BY", DBUtility.UserLogin.ToUpper)
                    cmd.Parameters.AddWithValue("PARENT1", DBNull.Value)
                    cmd.Parameters.AddWithValue("PARENT2", DBNull.Value)
                    cmd.Parameters.AddWithValue("REGION", DBNull.Value)
                    cmd.Parameters.AddWithValue("VSN", IIf(txtVSN.Text <> "", txtVSN.Text, DBNull.Value))

                    ' LN: 28/11/2013 Originally we had e-mail on address entry. 
                    cmd.Parameters.AddWithValue("STUDENT_EMAIL", IIf(Me.txtStudentEmail.Text <> "", Me.txtStudentEmail.Text.Trim(), DBNull.Value))
                    cmd.Parameters.AddWithValue("STUDENT_MOBILE", Me.txtStudentMobile.Text)


                    'If strCategoryCode.ToUpper() = "SCHOOL" Then
                        cmd.Parameters.AddWithValue("ENROLLEDBEFORE", "Y")
                    'Else
                    'cmd.Parameters.AddWithValue("ENROLLEDBEFORE", IIf(txtVSN.Text <> "", "Y", "N"))
                    'End If

                    cmd.Parameters.AddWithValue("VERIFY", "false")
                    cmd.Parameters.AddWithValue("DATE_STUDENTFOLDER_CREATED", DBNull.Value)

                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "SELECT @@IDENTITY"
                    tmpNewStudentID = CLng(cmd.ExecuteScalar())

					'June 2010|EricA| make explicit table column names so it handles changes to table structure
                    If Me.txtareacomments.Text.Trim() <> "" Then
                        cmd.Parameters.Clear()

                        strSQL = "insert into STUDENT_COMMENT ([COMMENT_ID], [STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_ALTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE]) "
                        strSQL += "values ((select (max(COMMENT_ID+1)) from STUDENT_COMMENT), @STUDENT_ID, @COMMENT, @LAST_ALTERED_BY, getdate(), 'A', 'ENROLMENT')"
                        cmd.CommandText = strSQL
                        cmd.Parameters.AddWithValue("STUDENT_ID", tmpNewStudentID.ToString)
                        cmd.Parameters.AddWithValue("COMMENT", txtareacomments.Text.Trim())
                        cmd.Parameters.AddWithValue("LAST_ALTERED_BY", DBUtility.UserLogin.ToUpper)
                        cmd.ExecuteNonQuery()
                    End If



                    cmd.Parameters.Clear()
                    strSQL = "INSERT INTO STUDENT_MEDICAL_DETAILS (STUDENT_ID,IMMUN_CERTIFICATE,IMMUN_DIPTHERIA,IMMUN_TETANUS,IMMUN_POLIO,IMMUN_MEASLES,IMMUN_MUMPS,LAST_ALTERED_BY,LAST_ALTERED_DATE,ALLERGIES_FLAG,ANAPHYLAXIS_FLAG)"
                    strSQL += " VALUES (@STUDENT_ID,@IMMUN_CERTIFICATE,@IMMUN_DIPTHERIA,@IMMUN_TETANUS,@IMMUN_POLIO,@IMMUN_MEASLES,@IMMUN_MUMPS,@LAST_ALTERED_BY,Getdate() ,@ALLERGIES_FLAG,@ANAPHYLAXIS_FLAG)"

                    cmd.CommandText = strSQL
                    cmd.Parameters.AddWithValue("STUDENT_ID", tmpNewStudentID.ToString)
                    cmd.Parameters.AddWithValue("IMMUN_CERTIFICATE", "U")
                    cmd.Parameters.AddWithValue("IMMUN_DIPTHERIA", "U")
                    cmd.Parameters.AddWithValue("IMMUN_TETANUS", "U")
                    cmd.Parameters.AddWithValue("IMMUN_POLIO", "U")
                    cmd.Parameters.AddWithValue("IMMUN_MEASLES", "U")
                    cmd.Parameters.AddWithValue("IMMUN_MUMPS", "U")
                    cmd.Parameters.AddWithValue("LAST_ALTERED_BY", DBUtility.UserLogin.ToUpper)
                    cmd.Parameters.AddWithValue("ALLERGIES_FLAG", "U")
                    cmd.Parameters.AddWithValue("ANAPHYLAXIS_FLAG", "U")

                    cmd.ExecuteNonQuery()


                    Dim enrldate As Date

                    cmd.Parameters.Clear()
                    strSQL = " INSERT INTO STUDENT_ENROLMENT (STUDENT_ID, ENROLMENT_YEAR, CAMPUS, YEAR_LEVEL, RECEIPT_NO, ENROLMENT_DATE, WITHDRAWAL_DATE, ENROLMENT_STATUS, WITHDRAWAL_REASON_ID, ELIGIBLE_FOR_DISCOUNT, PAID_ON_ENROLMENT, SUB_SCHOOL, ELIGIBLE_FOR_FUNDING, DECV_BALANCE, VSL_BALANCE, DOCS_LAST_REVIEWED_DATE, NEW_DOCS_REQUIRED, LAST_ALTERED_BY, LAST_ALTERED_DATE, PASTORAL_CARE_ID, REGION_APPROVAL_NUMBER, SCHOOL_SUPERVISOR_NAME, SCHOOL_SUPERVISOR_PHONE, SCHOOL_SUPERVISOR_EMAIL, ACER_Username, ACER_Password, REGION_ID, WITHDRAWAL_EXIT_DESTINATION, INTAKE_INTERVIEW_DONE, PATHWAY_PROFILE_DONE) "
                    strSQL += " VALUES (@STUDENT_ID,@ENROLMENT_YEAR,@CAMPUS,@YEAR_LEVEL,@RECEIPT_NO,@ENROLMENT_DATE,@WITHDRAWAL_DATE,@ENROLMENT_STATUS,@WITHDRAWAL_REASON_ID,@ELIGIBLE_FOR_DISCOUNT,@PAID_ON_ENROLMENT,@SUB_SCHOOL,@ELIGIBLE_FOR_FUNDING,@DECV_BALANCE,@VSL_BALANCE,Getdate(),@NEW_DOCS_REQUIRED,@LAST_ALTERED_BY,GETDATE(),@PASTORAL_CARE_ID,@REGION_APPROVAL_NUMBER,@SCHOOL_SUPERVISOR_NAME,@SCHOOL_SUPERVISOR_PHONE,@SCHOOL_SUPERVISOR_EMAIL,@ACER_Username,@ACER_Password,@REGION_ID,@WITHDRAWAL_EXIT_DESTINATION,@INTAKE_INTERVIEW_DONE,@PATHWAY_PROFILE_DONE)"

                    cmd.CommandText = strSQL
                    cmd.Parameters.AddWithValue("STUDENT_ID", tmpNewStudentID)
                    cmd.Parameters.AddWithValue("ENROLMENT_YEAR", Me.txtEnrolmentYear.Text)
                    cmd.Parameters.AddWithValue("CAMPUS", "D")
                    cmd.Parameters.AddWithValue("YEAR_LEVEL", Me.listYearLevel.SelectedValue.ToString)
                    cmd.Parameters.AddWithValue("RECEIPT_NO", DBNull.Value)


                    enrldate = Date.Parse(Me.txtEnrolmentDate.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat)
                    cmd.Parameters.AddWithValue("ENROLMENT_DATE", CDate(enrldate).ToString("yyyy-MM-dd"))

                    cmd.Parameters.AddWithValue("WITHDRAWAL_DATE", DBNull.Value)
                    cmd.Parameters.AddWithValue("ENROLMENT_STATUS", "E")
                    cmd.Parameters.AddWithValue("WITHDRAWAL_REASON_ID", DBNull.Value)
                    'cmd.Parameters.AddWithValue("ELIGIBLE_FOR_DISCOUNT", IIf(RB_Discount.SelectedValue = "Y", 1, 0))
                    cmd.Parameters.AddWithValue("ELIGIBLE_FOR_DISCOUNT", 0)   'LN: 25/11/2013
                    cmd.Parameters.AddWithValue("PAID_ON_ENROLMENT", "0")
                    cmd.Parameters.AddWithValue("SUB_SCHOOL", DBNull.Value)
                    ' if Category ='Tafe' and age >21 then 0 else 1
                    If strCategoryCode.ToUpper = "TAFE" Or CDate(dob) < CDate("1/1/" + (Year(Date.Today) - 21).ToString) Then
                        cmd.Parameters.AddWithValue("ELIGIBLE_FOR_FUNDING", "0")
                    Else
                        cmd.Parameters.AddWithValue("ELIGIBLE_FOR_FUNDING", "1")
                    End If

                    cmd.Parameters.AddWithValue("DECV_BALANCE", "0")
                    cmd.Parameters.AddWithValue("VSL_BALANCE", "0")
                    cmd.Parameters.AddWithValue("NEW_DOCS_REQUIRED", "0")
                    cmd.Parameters.AddWithValue("LAST_ALTERED_BY", DBUtility.UserLogin.ToUpper)
                    cmd.Parameters.AddWithValue("PASTORAL_CARE_ID", "N-A")
                    cmd.Parameters.AddWithValue("REGION_APPROVAL_NUMBER", IIf(Me.txtRegionCode.Text.ToString <> "", Me.txtRegionCode.Text.ToString, DBNull.Value))
                    cmd.Parameters.AddWithValue("SCHOOL_SUPERVISOR_NAME", DBNull.Value)
                    cmd.Parameters.AddWithValue("SCHOOL_SUPERVISOR_PHONE", DBNull.Value)
                    cmd.Parameters.AddWithValue("SCHOOL_SUPERVISOR_EMAIL", DBNull.Value)
                    cmd.Parameters.AddWithValue("ACER_Username", DBNull.Value)
                    cmd.Parameters.AddWithValue("ACER_Password", DBNull.Value)
                    cmd.Parameters.AddWithValue("REGION_ID", IIf(Me.listRegion.SelectedValue.Length <= 0, DBNull.Value, Me.listRegion.SelectedValue.ToString))

                    ' LN: 28/11/2013 Originally we had e-mail on address entry. 
                    'If InStr(Me.txtAttendingSchoolID.Text, "16261") Then
                    '    cmd.Parameters.AddWithValue("STUDENT_EMAIL", IIf(Me.txtemail_address_2.Text <> "", Me.txtemail_address_2.Text, DBNull.Value))
                    '    cmd.Parameters.AddWithValue("PARENT_EMAIL", IIf(Me.txtemail_address_2b.Text <> "", Me.txtemail_address_2b.Text, DBNull.Value))
                    'ElseIf Me.txtemail_address_2.Text <> "" Then
                    '    cmd.Parameters.AddWithValue("STUDENT_EMAIL", Me.txtemail_address_2.Text)
                    '    cmd.Parameters.AddWithValue("PARENT_EMAIL", IIf(Me.txtemail_address_2b.Text <> "", Me.txtemail_address_2b.Text, DBNull.Value))
                    'Else
                    '    cmd.Parameters.AddWithValue("STUDENT_EMAIL", IIf(Me.txtemail_address_1.Text <> "", Me.txtemail_address_1.Text, DBNull.Value))
                    '    cmd.Parameters.AddWithValue("PARENT_EMAIL", IIf(Me.txtemail_address_1b.Text <> "", Me.txtemail_address_1b.Text, DBNull.Value))
                    'End If

                    cmd.Parameters.AddWithValue("WITHDRAWAL_EXIT_DESTINATION", DBNull.Value)
                    '17-Dec-2014|EA| should default to 0 (No) for all new Students (unfuddle #684)
                    'cmd.Parameters.AddWithValue("INTAKE_INTERVIEW_DONE", DBNull.Value)
                    'cmd.Parameters.AddWithValue("PATHWAY_PROFILE_DONE", DBNull.Value)
                    cmd.Parameters.AddWithValue("INTAKE_INTERVIEW_DONE", 0)
                    cmd.Parameters.AddWithValue("PATHWAY_PROFILE_DONE", 0)

                    cmd.ExecuteNonQuery()


                    cmd.Parameters.Clear()
                    strSQL = " INSERT INTO STUDENT_EQUIPMENT(STUDENT_ID,HAS_COMPUTER,HAS_VCR,HAS_INTERNET_ACCESS,LAST_ALTERED_BY,LAST_ALTERED_DATE,HAS_DVD,NEWSLETTER_BYMAIL,ACCESS_WORKEXAMPLES,HAS_BROADBAND,SHARES_COMPUTER,LIMITED_INTERNET_ACCESS,HAS_DER_PC,ACCESS_COMPUTER_2010,ACCESS_INTERNET_2010)"
                    strSQL += " VALUES  (@STUDENT_ID,@HAS_COMPUTER,@HAS_VCR,@HAS_INTERNET_ACCESS,@LAST_ALTERED_BY,Getdate(),@HAS_DVD,@NEWSLETTER_BYMAIL,@ACCESS_WORKEXAMPLES,@HAS_BROADBAND,@SHARES_COMPUTER,@LIMITED_INTERNET_ACCESS,@HAS_DER_PC,@ACCESS_COMPUTER_2010,@ACCESS_INTERNET_2010)"

                    cmd.CommandText = strSQL
                    cmd.Parameters.AddWithValue("STUDENT_ID", tmpNewStudentID.ToString)
                    cmd.Parameters.AddWithValue("HAS_COMPUTER", "U")
                    cmd.Parameters.AddWithValue("HAS_VCR", "U")
                    cmd.Parameters.AddWithValue("HAS_INTERNET_ACCESS", "U")
                    cmd.Parameters.AddWithValue("LAST_ALTERED_BY", DBUtility.UserLogin.ToUpper)
                    cmd.Parameters.AddWithValue("HAS_DVD", "U")
                    cmd.Parameters.AddWithValue("NEWSLETTER_BYMAIL", DBNull.Value)
                    cmd.Parameters.AddWithValue("ACCESS_WORKEXAMPLES", DBNull.Value)
                    cmd.Parameters.AddWithValue("HAS_BROADBAND", "U")
                    cmd.Parameters.AddWithValue("SHARES_COMPUTER", "U")
                    cmd.Parameters.AddWithValue("LIMITED_INTERNET_ACCESS", "U")
                    cmd.Parameters.AddWithValue("HAS_DER_PC", DBNull.Value)
                    cmd.Parameters.AddWithValue("ACCESS_COMPUTER_2010", "U")
                    cmd.Parameters.AddWithValue("ACCESS_INTERNET_2010", "U")

                    cmd.ExecuteNonQuery()

                    cmd.Parameters.Clear()
                    strSQL = "INSERT INTO STUDENT_CENSUS_DATA(STUDENT_ID,COUNTRY_OF_BIRTH,MOTHERS_COB,FATHERS_COB,FIRST_HOME_LANGUAGE,OTHER_HOME_LANGUAGE,ALLOWANCE_CODE,KOORITORRESFLAG,DATE_STARTED_IN_AUST,RESIDENTIAL_STATUS,VISA_SUB_CLASS,VISA_STATISTICAL_CODE,DATE_ARRIVED_IN_AUST,PREVIOUS_SCHOOL_ID,FAMILY_OSG,HOUSEHOLD_STATUS,DISABILITY_ID,REPEATING_YEAR,OTHER_SCHOOL_TF,LAST_ALTERED_BY,LAST_ALTERED_DATE,MOTHER_LANGUAGE,MOTHER_EDUCATION_SCHOOL,MOTHER_EDUCATION_NONSCHOOL,MOTHER_OCCUPATIONGROUP,FATHER_LANGUAGE,FATHER_EDUCATION_SCHOOL,FATHER_EDUCATION_NONSCHOOL,FATHER_OCCUPATIONGROUP) "
                    strSQL += " VALUES  (@STUDENT_ID,@COUNTRY_OF_BIRTH,@MOTHERS_COB,@FATHERS_COB,@FIRST_HOME_LANGUAGE,@OTHER_HOME_LANGUAGE,@ALLOWANCE_CODE,@KOORITORRESFLAG,@DATE_STARTED_IN_AUST,@RESIDENTIAL_STATUS,@VISA_SUB_CLASS,@VISA_STATISTICAL_CODE,@DATE_ARRIVED_IN_AUST,@PREVIOUS_SCHOOL_ID,@FAMILY_OSG,@HOUSEHOLD_STATUS,@DISABILITY_ID,@REPEATING_YEAR,@OTHER_SCHOOL_TF,@LAST_ALTERED_BY,Getdate(),@MOTHER_LANGUAGE,@MOTHER_EDUCATION_SCHOOL,@MOTHER_EDUCATION_NONSCHOOL,@MOTHER_OCCUPATIONGROUP,@FATHER_LANGUAGE,@FATHER_EDUCATION_SCHOOL,@FATHER_EDUCATION_NONSCHOOL,@FATHER_OCCUPATIONGROUP)"

                    cmd.CommandText = strSQL
                    cmd.Parameters.AddWithValue("STUDENT_ID", tmpNewStudentID.ToString)
                    cmd.Parameters.AddWithValue("COUNTRY_OF_BIRTH", "1101")
                    cmd.Parameters.AddWithValue("MOTHERS_COB", "1101")
                    cmd.Parameters.AddWithValue("FATHERS_COB", "1101")
                    cmd.Parameters.AddWithValue("FIRST_HOME_LANGUAGE", "1201")
                    cmd.Parameters.AddWithValue("OTHER_HOME_LANGUAGE", DBNull.Value)
                    cmd.Parameters.AddWithValue("ALLOWANCE_CODE", "1")
                    cmd.Parameters.AddWithValue("KOORITORRESFLAG", "N")
                    cmd.Parameters.AddWithValue("DATE_STARTED_IN_AUST", DBNull.Value)
                    cmd.Parameters.AddWithValue("RESIDENTIAL_STATUS", "P")
                    cmd.Parameters.AddWithValue("VISA_SUB_CLASS", DBNull.Value)
                    cmd.Parameters.AddWithValue("VISA_STATISTICAL_CODE", DBNull.Value)
                    cmd.Parameters.AddWithValue("DATE_ARRIVED_IN_AUST", DBNull.Value)
                    cmd.Parameters.AddWithValue("PREVIOUS_SCHOOL_ID", DBNull.Value)
                    cmd.Parameters.AddWithValue("FAMILY_OSG", DBNull.Value)
                    cmd.Parameters.AddWithValue("HOUSEHOLD_STATUS", DBNull.Value)
                    cmd.Parameters.AddWithValue("DISABILITY_ID", DBNull.Value)
                    cmd.Parameters.AddWithValue("REPEATING_YEAR", "0")
                    cmd.Parameters.AddWithValue("OTHER_SCHOOL_TF", "0.0")
                    cmd.Parameters.AddWithValue("LAST_ALTERED_BY", DBUtility.UserLogin.ToUpper)
                    cmd.Parameters.AddWithValue("MOTHER_LANGUAGE", "1201")
                    cmd.Parameters.AddWithValue("MOTHER_EDUCATION_SCHOOL", DBNull.Value)
                    cmd.Parameters.AddWithValue("MOTHER_EDUCATION_NONSCHOOL", DBNull.Value)
                    cmd.Parameters.AddWithValue("MOTHER_OCCUPATIONGROUP", DBNull.Value)
                    cmd.Parameters.AddWithValue("FATHER_LANGUAGE", "1201")
                    cmd.Parameters.AddWithValue("FATHER_EDUCATION_SCHOOL", DBNull.Value)
                    cmd.Parameters.AddWithValue("FATHER_EDUCATION_NONSCHOOL", DBNull.Value)
                    cmd.Parameters.AddWithValue("FATHER_OCCUPATIONGROUP", DBNull.Value)

                    cmd.ExecuteNonQuery()
                    'STUDENTlblErrorMessages.Text += "<br> STUDENT_CENSUS Inserted "

                    '27-Nov-2008|EA| add iAchieve (aka ACER) id if needed, handled by stored proc
                 	  '04 Dec 2020|RW| Removing this SP call, which used to assign the ACER usernames and passwords on the STUDENT_ENROLMENT table
	                 '                Looks like it hasn't been needed since 2010

                    'strSQL = "exec [spu_UpdateACERUserDetails] " & tmpNewStudentID.ToString & "," & Me.txtEnrolmentYear.Text.ToString & " "
                    'cmd.CommandText = strSQL
                    'cmd.ExecuteNonQuery()

                    ' round off with a nice commit()
                    trans.Commit()

                    ' put the student ID onto the Completed page
                    Me.lblNewStudentID.Text = tmpNewStudentID
                    Me.lblNewEnrolmentYear.Text = Me.txtEnrolmentYear.Text
                    ' LN: 28/11/2013 Me.lblNewStudentName.Text = Me.txtFirstName.Text.ToUpper + " " + Me.txtSurname.Text.ToUpper 
                    Me.lblNewStudentName.Text = Me.txtFirstName.Text + " " + Me.txtSurname.Text

                    Me.HyperLink_AddSubjects.NavigateUrl = "~/Student_Subject_maintain.aspx?STUDENT_ID=" & tmpNewStudentID.ToString & "&ENROLMENT_YEAR=" & Me.txtEnrolmentYear.Text & "&YEAR_LEVEL=" & Me.listYearLevel.SelectedValue.ToString
                    Me.HyperLink_AddFinancials.NavigateUrl = "~/FinancialAccounts_maintain.aspx?STUDENT_ID=" & tmpNewStudentID.ToString & "&ENROLMENT_YEAR=" & Me.txtEnrolmentYear.Text
                    Me.HyperLink_AddCensus.NavigateUrl = "~/Student_Census_maintain.aspx?STUDENT_ID=" & tmpNewStudentID.ToString & "&ENROLMENT_YEAR=" & Me.txtEnrolmentYear.Text
                    Me.hidden_StudentEnrolled.Value = "1"
                    Me.Form.Attributes.Add("onsubmit", "return false;")

                Catch ex As Exception
                    trans.Rollback()
                    STUDENTlblErrorMessages.Text += "<br><font color=red>An <b>ERROR</b> occured when setting up this Student. Check the error message below.</font>"
                    STUDENTlblErrorMessages.Text += "<br>Error: " & ex.Message.ToString
                    STUDENTlblErrorMessages.Text += "<br>SQL : " & cmd.CommandText.ToString
                    STUDENTlblErrorMessages.Visible = True

                    Me.HyperLink_AddSubjects.Visible = False
                    Me.HyperLink_AddFinancials.Visible = False
                    Me.HyperLink_AddCensus.Visible = False
                    Me.biggreentick.ImageUrl = "~/images/bignogo.gif"


                Finally
                    If NewDao.NativeConnection.State = ConnectionState.Open Then
                        NewDao.NativeConnection.Close()
                    End If
                End Try
            End If     'If (Me.hidden_StudentEnrolled.Value = "0") Then

        End Sub

        Protected Sub GetTempStudentID()
            ' ERA: collect the studentID from the querystring into the tmpStudentID
            ' If it's empty then create new one from TEMP_STUDENT_ENROLMENT

            Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
            'Dim trans As OleDb.OleDbTransaction		'for Live
            'Dim cmd As OleDb.OleDbCommand              'for Live
            ' LN:14/19/2013
            Dim trans As SqlClient.SqlTransaction       'for Live
            Dim cmd As SqlClient.SqlCommand             'for Live   

            Try
                ' a little more formal than the Sybase 'begin trans' statement
                If NewDao.NativeConnection.State <> ConnectionState.Open Then
                    NewDao.NativeConnection.Open()
                    'NewDao.DateFormat = "mdy"
                End If

                trans = NewDao.NativeConnection.BeginTransaction()
                cmd = NewDao.NativeConnection.CreateCommand

                cmd.CommandType = CommandType.Text
                cmd.Transaction = trans

                Dim strSQL As String = ""
                strSQL = "INSERT TEMP_STUDENT_ENROLMENT(ENROLMENT_YEAR, DECV_BALANCE, NUMBER_OF_FULL_SUBJECTS) " & _
                       "VALUES  (" & NewDao.ToSql(Me.txtEnrolmentYear.Text, FieldType._Integer) & ",0,0)"

                cmd.CommandText = strSQL
                cmd.ExecuteNonQuery()
                cmd.CommandText = "SELECT @@IDENTITY"
                tmpNewStudentID = CLng(cmd.ExecuteScalar())
                STUDENTlblErrorMessages.Text += "<hr> Done retrieval of Student ID [" & tmpNewStudentID.ToString() & "]"

                trans.Commit()

            Catch ex As Exception
                trans.Rollback()
                STUDENTlblErrorMessages.Text += "<br><font color=red>An <b>ERROR</b> occured when setting up this Student. Check the error message below.</font>"
                STUDENTlblErrorMessages.Text += "<br>Error: " & ex.Message.ToString
                STUDENTlblErrorMessages.Visible = True
            Finally
                If NewDao.NativeConnection.State = ConnectionState.Open Then
                    NewDao.NativeConnection.Close()
                End If
            End Try

        End Sub

        Public Function prepStringForSQL(ByVal sValue As String) As String
            Dim sAns As String = ""
            If sValue <> "" Then
                sAns = sValue.ToUpper
            End If
            Return sAns
        End Function


        Private Function FindFirstTextBox(ByVal c As Control) As TextBox
            If c Is Nothing Then Return Nothing
            If TypeOf c Is TextBox Then Return c

            Dim results As Control
            For Each child As Control In c.Controls
                results = FindFirstTextBox(child)

                If results IsNot Nothing AndAlso TypeOf results Is TextBox Then Return results
            Next

            'If we reach here, we didn't find a TextBox
            Return Nothing
        End Function

        Protected Sub txtAttendingSchoolID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAttendingSchoolID.TextChanged
            Me.txtAttendingSchoolName.Text = "unknown"
            If (Me.txtAttendingSchoolID.Text <> "") Then
                Me.txtAttendingSchoolName.Text = (New TextField("", DECV_PROD2007.Configuration.Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT rtrim(SCHOOL_NAME) as [SCHOOL_NAME]  FROM SCHOOL WHERE status=1 and school_type_code!='X' and SCHOOL_ID = " & Me.txtAttendingSchoolID.Text.ToString))).GetFormattedValue()
                If Me.txtAttendingSchoolName.Text = "" Then Me.txtAttendingSchoolName.Text = "unknown - please check ID"
            End If
        End Sub

        Protected Sub txtHomeSchoolID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHomeSchoolID.TextChanged
            Me.txtHomeSchoolName.Text = "unknown"
            If (Me.txtHomeSchoolID.Text <> "") Then
                Me.txtHomeSchoolName.Text = (New TextField("", DECV_PROD2007.Configuration.Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT rtrim(SCHOOL_NAME) as [SCHOOL_NAME] FROM SCHOOL WHERE status=1 and school_type_code!='X' and SCHOOL_ID = " & Me.txtHomeSchoolID.Text.ToString))).GetFormattedValue()
                If Me.txtHomeSchoolName.Text = "" Then Me.txtHomeSchoolName.Text = "unknown - please check ID"
            End If
        End Sub

        Protected Sub btnCheckSchools_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckSchools.Click
            txtAttendingSchoolID_TextChanged(sender, e)
            txtHomeSchoolID_TextChanged(sender, e)
        End Sub

      'Protected Sub Wizard_AddStudent_NextButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles Wizard_AddStudent.NextButtonClick
      '    Dim i As Integer
      '    i = e.NextStepIndex
      '    'If Wizard_AddStudent.WizardSteps(i).Name = "Comment" Then
      '    '    Session("WizardCheckCounter") = 1
      '    'End If
      'End Sub


      'Protected Sub Wizard_AddStudent_PreviousButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles Wizard_AddStudent.PreviousButtonClick
      '    Dim i As Integer
      '    i = e.NextStepIndex
      '    If Wizard_AddStudent.WizardSteps(i).Name = "Address" Then
      '        div_StudentExist.Style.Add("display", "none")
      '    End If
      'End Sub

      'Protected Sub Display_ExistingStudentDiv()

      '    Dim cmd As New SqlClient.SqlCommand
      '    Dim intExistingCount As Integer = -1
      '    Dim strSQL As String
      '    Dim strDivHtml As String = ""
      '    Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
      '    Dim DOB As Date
      '    DOB = Date.Parse(Me.txtDateOfBirth.Text.ToString, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat)
      '    If NewDao.NativeConnection.State <> ConnectionState.Open Then
      '        NewDao.NativeConnection.Open()
      '    End If
      '    cmd = NewDao.NativeConnection.CreateCommand
      '    strSQL = "SELECT STUDENT_ID FROM STUDENT WHERE SURNAME LIKE '" & prepStringForSQL(Me.txtSurname.Text) & "' AND FIRST_NAME LIKE '" & prepStringForSQL(Me.txtFirstName.Text) & "' AND BIRTH_DATE ='" & DOB.ToString() & "'"
      '    cmd.CommandText = strSQL
      '    intExistingCount = CInt(cmd.ExecuteScalar())

      '    If intExistingCount > 0 Then
      '        div_StudentExist.Style.Add("display", "block")
      '        'div_StudentExist.InnerText = "student already exist"
      '        strDivHtml = "Student found with same details :" & intExistingCount & "<br>"
      '        innerDiv_StudentExist2.InnerHtml = strDivHtml
      '    Else
      '        div_StudentExist.Style.Add("display", "none")
      '    End If
      '    Session("WizardCheckCounter") = 0

      'End Sub

      Protected Sub Unnamed_ServerValidate(source As Object, args As ServerValidateEventArgs)
         'Debug.WriteLine($"Validate Email")
         'args.IsValid = StudentEmailNew.Text.Contains("@")
         dim email = args.Value
         'If not email Contains("@")
         '   'Hacky email validation for testing, use a proper validator
         '   Response.Write("emai is invalid1")
         '   Debug.WriteLine("email is invalid1")
         '   EmailValidationMessage.Text = "Email has no @"
         '   args.IsValid = false
         '   Return 
         'End If

         'Lookup if student is already enroled in 2023
         Dim command = new SpCommand("sp_enrol_already_enrolled;1", Settings.connDECVPRODSQL2005DataAccessObject)
         command.Parameters.Clear()
         CType(command, SpCommand).AddParameter("@STUD_EMAIL", email, ParameterType._VarChar, ParameterDirection.Input, 0, 0, 10)
         CType(command, SpCommand).AddParameter("@STUD_VSV_ID", 0, ParameterType._Int, ParameterDirection.Input, 0, 0, 10)
         CType(command, SpCommand).AddParameter("@STUD_ENROLMENT_YEAR", 2023, ParameterType._Int, ParameterDirection.Input, 0, 0, 10) 'TODO Make this dynamic for year

         dim matchesCurrent As DataSet = command.Execute()
         Dim tableCurrent = matchesCurrent.Tables("SourceTable")

         If(tableCurrent.Rows.Count > 0)
            Dim id = tableCurrent.Rows(0).Item(0)
            Response.Write($"emai is in use email {id}")
            Debug.WriteLine($"email is in use {id}")
            dim rl = $"/StudentSummary.aspx?STUDENT_ID={id}&ENROLMENT_YEAR=2023"
            EmailValidationMessage.Text = $"{email} is used by a currently enroled student. <a href=""{rl}"">View Student {id}</a>"

            args.IsValid = false
            Return 
         End If


         'Lookup if student email is in use but not enroled
         dim oldEnrolmentCommand = new SpCommand("sp_get_student_matches;1", Settings.connDECVPRODSQL2005DataAccessObject)
         oldEnrolmentCommand.Parameters.Clear()
         CType(oldEnrolmentCommand, SpCommand).AddParameter("@EMAIL", email, ParameterType._VarChar, ParameterDirection.Input, 0, 0, 10)
         dim matchesOldEnrolment As DataSet = oldEnrolmentCommand.Execute()
         Dim tableOldEnrolment = matchesOldEnrolment.Tables("SourceTable")

         If(tableOldEnrolment.Rows.Count > 0)
            Dim id = tableOldEnrolment.Rows(0).Item(0)
            Response.Write($"emai is in use email {id} for old student")
            Debug.WriteLine($"email is in use {id} for old student")
            dim studentUrl = $"/StudentSummary.aspx?STUDENT_ID={id}"
            dim addYearUrl = $"/StudentEnrolment_AddNewYear.aspx?STUDENT_ID={id}&ENROLMENT_YEAR=2023"
            EmailValidationMessage.Text = $"{email} is used by previously enroled student. <a href=""{addYearUrl}"">Add Year for {id}</a>"
            args.IsValid = false
            
            Return
         End If
         'if matches on three fields but doesn't match email, do show Add new student button but with extrememe warning
         'if email matches can't add new student, do show the row

         args.IsValid = true
      End Sub

      Protected Sub StudentEmailNew_TextChanged(sender As Object, e As EventArgs)
         'Debug.WriteLine($"Eamil changed Email")
      End Sub
   End Class

  
End Namespace
'End Page class tail

