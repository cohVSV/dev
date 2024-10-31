'Using Statements @1-ECBA6F53
Imports System
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Data
Imports DECV_PROD2007
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Controls
Imports DECV_PROD2007.Security
Imports DECV_PROD2007.Configuration
'End Using Statements

Namespace DECV_PROD2007.Student_Address_maintain 'Namespace @1-6E8BBD43

'Page Data Class @1-0B77669F
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Sub New()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Set
    End Property

End Class
'End Page Data Class

'Page Data Provider Class @1-E3544B64
Public Class PageDataProvider
Dim j As Integer
'End Page Data Provider Class

'Page Data Provider Class Constructor @1-12B526DF
    Public Sub New()
    End Sub
'End Page Data Provider Class Constructor

'Page Data Provider Class GetResultSet Method @1-F73C4626
    Public Sub FillItem(ByVal item As PageItem)
'End Page Data Provider Class GetResultSet Method

'Page Data Provider Class GetResultSet Method tail @1-E31F8E2A
    End Sub
'End Page Data Provider Class GetResultSet Method tail

'Page Data Provider class Tail @1-A61BA892
End Class
'End Page Data Provider class Tail

'Record viewStudentMaintain_Addre Item Class @5-3B53B9DA
Public Class viewStudentMaintain_AddreItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblMessage As TextField
    Public STUDENT_ID As FloatField
    Public cbox_same_as_school As IntegerField
    Public cbox_same_as_schoolCheckedValue As IntegerField
    Public cbox_same_as_schoolUncheckedValue As IntegerField
    Public PostAdd_ADDRESS_ID As FloatField
    Public Postal_ADDRESSEE As TextField
    Public PostAdd_ADDRESS_ID_orig As FloatField
    Public Postal_AGENT As TextField
    Public Postal_ADDR1 As TextField
    Public Postal_ADDR2 As TextField
    Public Postal_SUBURB_TOWN As TextField
    Public Postal_STATE As TextField
    Public Postal_POSTCODE As TextField
    Public Postal_COUNTRY As TextField
    Public Postal_PHONE_A As TextField
    Public Postal_PHONE_B As TextField
    Public Postal_FAX As TextField
    Public Postal_EMAIL_ADDRESS As TextField
    Public Postal_EMAIL_ADDRESS2 As TextField
    Public Postal_LAST_ALTERED_BY As TextField
    Public Postal_LAST_ALTERED_DATE As DateField
    Public cbox_same_as_postal As IntegerField
    Public cbox_same_as_postalCheckedValue As IntegerField
    Public cbox_same_as_postalUncheckedValue As IntegerField
    Public Curr_ADDRESS_ID As FloatField
    Public Curr_ADDRESSEE As TextField
    Public Curr_ADDRESS_ID_orig As FloatField
    Public Curr_AGENT As TextField
    Public Curr_ADDR1 As TextField
    Public Curr_ADDR2 As TextField
    Public Curr_SUBURB_TOWN As TextField
    Public Curr_STATE As TextField
    Public Curr_POSTCODE As TextField
    Public Curr_COUNTRY As TextField
    Public Curr_PHONE_A As TextField
    Public Curr_PHONE_B As TextField
    Public Curr_FAX As TextField
    Public Curr_EMAIL_ADDRESS As TextField
    Public Curr_EMAIL_ADDRESS2 As TextField
    Public Curr_LAST_ALTERED_BY As TextField
    Public Curr_LAST_ALTERED_DATE As DateField
    Public Orig_ADDRESS_ID As FloatField
    Public Orig_ADDRESSEE As TextField
    Public Orig_ADDRESS_ID_orig As FloatField
    Public Orig_AGENT As TextField
    Public Orig_ADDR1 As TextField
    Public Orig_ADDR2 As TextField
    Public Orig_SUBURB_TOWN As TextField
    Public Orig_STATE As TextField
    Public Orig_POSTCODE As TextField
    Public Orig_COUNTRY As TextField
    Public Orig_PHONE_A As TextField
    Public Orig_PHONE_B As TextField
    Public Orig_FAX As TextField
    Public Orig_EMAIL_ADDRESS As TextField
    Public Orig_EMAIL_ADDRESS2 As TextField
    Public Orig_LAST_ALTERED_BY As TextField
    Public Orig_LAST_ALTERED_DATE As DateField
    Public ATTENDING_SCHOOL_ID As FloatField
    Public CURR_RESID_ADDRESS_ID As FloatField
    Public ORIG_RESID_ADDRESS_ID As FloatField
    Public PostAdd_SCHOOL_ADDRESS_ID_ifknown As FloatField
    Public POSTAL_ADDRESS_ID As FloatField
    Public flag_same_as_school_old As IntegerField
    Public flag_same_as_school As IntegerField
    Public this_LAST_ALTERED_BY As TextField
    Public ajaxBusy As TextField
    Public Sub New()
    lblMessage = New TextField("", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    cbox_same_as_school = New IntegerField("", 0)
    cbox_same_as_schoolCheckedValue = New IntegerField("", 1)
    cbox_same_as_schoolUncheckedValue = New IntegerField("", 0)
    PostAdd_ADDRESS_ID = New FloatField("", Nothing)
    Postal_ADDRESSEE = New TextField("", Nothing)
    PostAdd_ADDRESS_ID_orig = New FloatField("", Nothing)
    Postal_AGENT = New TextField("", Nothing)
    Postal_ADDR1 = New TextField("", Nothing)
    Postal_ADDR2 = New TextField("", Nothing)
    Postal_SUBURB_TOWN = New TextField("", Nothing)
    Postal_STATE = New TextField("", Nothing)
    Postal_POSTCODE = New TextField("", Nothing)
    Postal_COUNTRY = New TextField("", Nothing)
    Postal_PHONE_A = New TextField("", Nothing)
    Postal_PHONE_B = New TextField("", Nothing)
    Postal_FAX = New TextField("", Nothing)
    Postal_EMAIL_ADDRESS = New TextField("", Nothing)
    Postal_EMAIL_ADDRESS2 = New TextField("", Nothing)
    Postal_LAST_ALTERED_BY = New TextField("", Nothing)
    Postal_LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    cbox_same_as_postal = New IntegerField("", 0)
    cbox_same_as_postalCheckedValue = New IntegerField("", 1)
    cbox_same_as_postalUncheckedValue = New IntegerField("", 0)
    Curr_ADDRESS_ID = New FloatField("", Nothing)
    Curr_ADDRESSEE = New TextField("", Nothing)
    Curr_ADDRESS_ID_orig = New FloatField("", Nothing)
    Curr_AGENT = New TextField("", Nothing)
    Curr_ADDR1 = New TextField("", Nothing)
    Curr_ADDR2 = New TextField("", Nothing)
    Curr_SUBURB_TOWN = New TextField("", Nothing)
    Curr_STATE = New TextField("", Nothing)
    Curr_POSTCODE = New TextField("", Nothing)
    Curr_COUNTRY = New TextField("", Nothing)
    Curr_PHONE_A = New TextField("", Nothing)
    Curr_PHONE_B = New TextField("", Nothing)
    Curr_FAX = New TextField("", Nothing)
    Curr_EMAIL_ADDRESS = New TextField("", Nothing)
    Curr_EMAIL_ADDRESS2 = New TextField("", Nothing)
    Curr_LAST_ALTERED_BY = New TextField("", Nothing)
    Curr_LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    Orig_ADDRESS_ID = New FloatField("", Nothing)
    Orig_ADDRESSEE = New TextField("", Nothing)
    Orig_ADDRESS_ID_orig = New FloatField("", Nothing)
    Orig_AGENT = New TextField("", Nothing)
    Orig_ADDR1 = New TextField("", Nothing)
    Orig_ADDR2 = New TextField("", Nothing)
    Orig_SUBURB_TOWN = New TextField("", Nothing)
    Orig_STATE = New TextField("", Nothing)
    Orig_POSTCODE = New TextField("", Nothing)
    Orig_COUNTRY = New TextField("", Nothing)
    Orig_PHONE_A = New TextField("", Nothing)
    Orig_PHONE_B = New TextField("", Nothing)
    Orig_FAX = New TextField("", Nothing)
    Orig_EMAIL_ADDRESS = New TextField("", Nothing)
    Orig_EMAIL_ADDRESS2 = New TextField("", Nothing)
    Orig_LAST_ALTERED_BY = New TextField("", Nothing)
    Orig_LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    ATTENDING_SCHOOL_ID = New FloatField("", Nothing)
    CURR_RESID_ADDRESS_ID = New FloatField("", Nothing)
    ORIG_RESID_ADDRESS_ID = New FloatField("", Nothing)
    PostAdd_SCHOOL_ADDRESS_ID_ifknown = New FloatField("", Nothing)
    POSTAL_ADDRESS_ID = New FloatField("", Nothing)
    flag_same_as_school_old = New IntegerField("", 0)
    flag_same_as_school = New IntegerField("", 0)
    this_LAST_ALTERED_BY = New TextField("", Nothing)
    ajaxBusy = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As viewStudentMaintain_AddreItem
        Dim item As viewStudentMaintain_AddreItem = New viewStudentMaintain_AddreItem()
        If Not IsNothing(DBUtility.GetInitialValue("lblMessage")) Then
        item.lblMessage.SetValue(DBUtility.GetInitialValue("lblMessage"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update1")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel1")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbox_same_as_school")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cbox_same_as_school")) Then
            item.cbox_same_as_school.Value = item.cbox_same_as_schoolCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PostAdd_ADDRESS_ID")) Then
        item.PostAdd_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("PostAdd_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_ADDRESSEE")) Then
        item.Postal_ADDRESSEE.SetValue(DBUtility.GetInitialValue("Postal_ADDRESSEE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PostAdd_ADDRESS_ID_orig")) Then
        item.PostAdd_ADDRESS_ID_orig.SetValue(DBUtility.GetInitialValue("PostAdd_ADDRESS_ID_orig"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_AGENT")) Then
        item.Postal_AGENT.SetValue(DBUtility.GetInitialValue("Postal_AGENT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_ADDR1")) Then
        item.Postal_ADDR1.SetValue(DBUtility.GetInitialValue("Postal_ADDR1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_ADDR2")) Then
        item.Postal_ADDR2.SetValue(DBUtility.GetInitialValue("Postal_ADDR2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_SUBURB_TOWN")) Then
        item.Postal_SUBURB_TOWN.SetValue(DBUtility.GetInitialValue("Postal_SUBURB_TOWN"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_STATE")) Then
        item.Postal_STATE.SetValue(DBUtility.GetInitialValue("Postal_STATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_POSTCODE")) Then
        item.Postal_POSTCODE.SetValue(DBUtility.GetInitialValue("Postal_POSTCODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_COUNTRY")) Then
        item.Postal_COUNTRY.SetValue(DBUtility.GetInitialValue("Postal_COUNTRY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_PHONE_A")) Then
        item.Postal_PHONE_A.SetValue(DBUtility.GetInitialValue("Postal_PHONE_A"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_PHONE_B")) Then
        item.Postal_PHONE_B.SetValue(DBUtility.GetInitialValue("Postal_PHONE_B"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_FAX")) Then
        item.Postal_FAX.SetValue(DBUtility.GetInitialValue("Postal_FAX"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_EMAIL_ADDRESS")) Then
        item.Postal_EMAIL_ADDRESS.SetValue(DBUtility.GetInitialValue("Postal_EMAIL_ADDRESS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_EMAIL_ADDRESS2")) Then
        item.Postal_EMAIL_ADDRESS2.SetValue(DBUtility.GetInitialValue("Postal_EMAIL_ADDRESS2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_LAST_ALTERED_BY")) Then
        item.Postal_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("Postal_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Postal_LAST_ALTERED_DATE")) Then
        item.Postal_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("Postal_LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbox_same_as_postal")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cbox_same_as_postal")) Then
            item.cbox_same_as_postal.Value = item.cbox_same_as_postalCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_ADDRESS_ID")) Then
        item.Curr_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("Curr_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_ADDRESSEE")) Then
        item.Curr_ADDRESSEE.SetValue(DBUtility.GetInitialValue("Curr_ADDRESSEE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_ADDRESS_ID_orig")) Then
        item.Curr_ADDRESS_ID_orig.SetValue(DBUtility.GetInitialValue("Curr_ADDRESS_ID_orig"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_AGENT")) Then
        item.Curr_AGENT.SetValue(DBUtility.GetInitialValue("Curr_AGENT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_ADDR1")) Then
        item.Curr_ADDR1.SetValue(DBUtility.GetInitialValue("Curr_ADDR1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_ADDR2")) Then
        item.Curr_ADDR2.SetValue(DBUtility.GetInitialValue("Curr_ADDR2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_SUBURB_TOWN")) Then
        item.Curr_SUBURB_TOWN.SetValue(DBUtility.GetInitialValue("Curr_SUBURB_TOWN"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_STATE")) Then
        item.Curr_STATE.SetValue(DBUtility.GetInitialValue("Curr_STATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_POSTCODE")) Then
        item.Curr_POSTCODE.SetValue(DBUtility.GetInitialValue("Curr_POSTCODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_COUNTRY")) Then
        item.Curr_COUNTRY.SetValue(DBUtility.GetInitialValue("Curr_COUNTRY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_PHONE_A")) Then
        item.Curr_PHONE_A.SetValue(DBUtility.GetInitialValue("Curr_PHONE_A"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_PHONE_B")) Then
        item.Curr_PHONE_B.SetValue(DBUtility.GetInitialValue("Curr_PHONE_B"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_FAX")) Then
        item.Curr_FAX.SetValue(DBUtility.GetInitialValue("Curr_FAX"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_EMAIL_ADDRESS")) Then
        item.Curr_EMAIL_ADDRESS.SetValue(DBUtility.GetInitialValue("Curr_EMAIL_ADDRESS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_EMAIL_ADDRESS2")) Then
        item.Curr_EMAIL_ADDRESS2.SetValue(DBUtility.GetInitialValue("Curr_EMAIL_ADDRESS2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_LAST_ALTERED_BY")) Then
        item.Curr_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("Curr_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Curr_LAST_ALTERED_DATE")) Then
        item.Curr_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("Curr_LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_ADDRESS_ID")) Then
        item.Orig_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("Orig_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_ADDRESSEE")) Then
        item.Orig_ADDRESSEE.SetValue(DBUtility.GetInitialValue("Orig_ADDRESSEE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_ADDRESS_ID_orig")) Then
        item.Orig_ADDRESS_ID_orig.SetValue(DBUtility.GetInitialValue("Orig_ADDRESS_ID_orig"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_AGENT")) Then
        item.Orig_AGENT.SetValue(DBUtility.GetInitialValue("Orig_AGENT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_ADDR1")) Then
        item.Orig_ADDR1.SetValue(DBUtility.GetInitialValue("Orig_ADDR1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_ADDR2")) Then
        item.Orig_ADDR2.SetValue(DBUtility.GetInitialValue("Orig_ADDR2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_SUBURB_TOWN")) Then
        item.Orig_SUBURB_TOWN.SetValue(DBUtility.GetInitialValue("Orig_SUBURB_TOWN"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_STATE")) Then
        item.Orig_STATE.SetValue(DBUtility.GetInitialValue("Orig_STATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_POSTCODE")) Then
        item.Orig_POSTCODE.SetValue(DBUtility.GetInitialValue("Orig_POSTCODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_COUNTRY")) Then
        item.Orig_COUNTRY.SetValue(DBUtility.GetInitialValue("Orig_COUNTRY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_PHONE_A")) Then
        item.Orig_PHONE_A.SetValue(DBUtility.GetInitialValue("Orig_PHONE_A"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_PHONE_B")) Then
        item.Orig_PHONE_B.SetValue(DBUtility.GetInitialValue("Orig_PHONE_B"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_FAX")) Then
        item.Orig_FAX.SetValue(DBUtility.GetInitialValue("Orig_FAX"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_EMAIL_ADDRESS")) Then
        item.Orig_EMAIL_ADDRESS.SetValue(DBUtility.GetInitialValue("Orig_EMAIL_ADDRESS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_EMAIL_ADDRESS2")) Then
        item.Orig_EMAIL_ADDRESS2.SetValue(DBUtility.GetInitialValue("Orig_EMAIL_ADDRESS2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_LAST_ALTERED_BY")) Then
        item.Orig_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("Orig_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Orig_LAST_ALTERED_DATE")) Then
        item.Orig_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("Orig_LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ATTENDING_SCHOOL_ID")) Then
        item.ATTENDING_SCHOOL_ID.SetValue(DBUtility.GetInitialValue("ATTENDING_SCHOOL_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CURR_RESID_ADDRESS_ID")) Then
        item.CURR_RESID_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("CURR_RESID_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ORIG_RESID_ADDRESS_ID")) Then
        item.ORIG_RESID_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("ORIG_RESID_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PostAdd_SCHOOL_ADDRESS_ID_ifknown")) Then
        item.PostAdd_SCHOOL_ADDRESS_ID_ifknown.SetValue(DBUtility.GetInitialValue("PostAdd_SCHOOL_ADDRESS_ID_ifknown"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("POSTAL_ADDRESS_ID")) Then
        item.POSTAL_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("POSTAL_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("flag_same_as_school_old")) Then
        item.flag_same_as_school_old.SetValue(DBUtility.GetInitialValue("flag_same_as_school_old"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("flag_same_as_school")) Then
        item.flag_same_as_school.SetValue(DBUtility.GetInitialValue("flag_same_as_school"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("this_LAST_ALTERED_BY")) Then
        item.this_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("this_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ajaxBusy")) Then
        item.ajaxBusy.SetValue(DBUtility.GetInitialValue("ajaxBusy"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblMessage"
                    Return lblMessage
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "cbox_same_as_school"
                    Return cbox_same_as_school
                Case "PostAdd_ADDRESS_ID"
                    Return PostAdd_ADDRESS_ID
                Case "Postal_ADDRESSEE"
                    Return Postal_ADDRESSEE
                Case "PostAdd_ADDRESS_ID_orig"
                    Return PostAdd_ADDRESS_ID_orig
                Case "Postal_AGENT"
                    Return Postal_AGENT
                Case "Postal_ADDR1"
                    Return Postal_ADDR1
                Case "Postal_ADDR2"
                    Return Postal_ADDR2
                Case "Postal_SUBURB_TOWN"
                    Return Postal_SUBURB_TOWN
                Case "Postal_STATE"
                    Return Postal_STATE
                Case "Postal_POSTCODE"
                    Return Postal_POSTCODE
                Case "Postal_COUNTRY"
                    Return Postal_COUNTRY
                Case "Postal_PHONE_A"
                    Return Postal_PHONE_A
                Case "Postal_PHONE_B"
                    Return Postal_PHONE_B
                Case "Postal_FAX"
                    Return Postal_FAX
                Case "Postal_EMAIL_ADDRESS"
                    Return Postal_EMAIL_ADDRESS
                Case "Postal_EMAIL_ADDRESS2"
                    Return Postal_EMAIL_ADDRESS2
                Case "Postal_LAST_ALTERED_BY"
                    Return Postal_LAST_ALTERED_BY
                Case "Postal_LAST_ALTERED_DATE"
                    Return Postal_LAST_ALTERED_DATE
                Case "cbox_same_as_postal"
                    Return cbox_same_as_postal
                Case "Curr_ADDRESS_ID"
                    Return Curr_ADDRESS_ID
                Case "Curr_ADDRESSEE"
                    Return Curr_ADDRESSEE
                Case "Curr_ADDRESS_ID_orig"
                    Return Curr_ADDRESS_ID_orig
                Case "Curr_AGENT"
                    Return Curr_AGENT
                Case "Curr_ADDR1"
                    Return Curr_ADDR1
                Case "Curr_ADDR2"
                    Return Curr_ADDR2
                Case "Curr_SUBURB_TOWN"
                    Return Curr_SUBURB_TOWN
                Case "Curr_STATE"
                    Return Curr_STATE
                Case "Curr_POSTCODE"
                    Return Curr_POSTCODE
                Case "Curr_COUNTRY"
                    Return Curr_COUNTRY
                Case "Curr_PHONE_A"
                    Return Curr_PHONE_A
                Case "Curr_PHONE_B"
                    Return Curr_PHONE_B
                Case "Curr_FAX"
                    Return Curr_FAX
                Case "Curr_EMAIL_ADDRESS"
                    Return Curr_EMAIL_ADDRESS
                Case "Curr_EMAIL_ADDRESS2"
                    Return Curr_EMAIL_ADDRESS2
                Case "Curr_LAST_ALTERED_BY"
                    Return Curr_LAST_ALTERED_BY
                Case "Curr_LAST_ALTERED_DATE"
                    Return Curr_LAST_ALTERED_DATE
                Case "Orig_ADDRESS_ID"
                    Return Orig_ADDRESS_ID
                Case "Orig_ADDRESSEE"
                    Return Orig_ADDRESSEE
                Case "Orig_ADDRESS_ID_orig"
                    Return Orig_ADDRESS_ID_orig
                Case "Orig_AGENT"
                    Return Orig_AGENT
                Case "Orig_ADDR1"
                    Return Orig_ADDR1
                Case "Orig_ADDR2"
                    Return Orig_ADDR2
                Case "Orig_SUBURB_TOWN"
                    Return Orig_SUBURB_TOWN
                Case "Orig_STATE"
                    Return Orig_STATE
                Case "Orig_POSTCODE"
                    Return Orig_POSTCODE
                Case "Orig_COUNTRY"
                    Return Orig_COUNTRY
                Case "Orig_PHONE_A"
                    Return Orig_PHONE_A
                Case "Orig_PHONE_B"
                    Return Orig_PHONE_B
                Case "Orig_FAX"
                    Return Orig_FAX
                Case "Orig_EMAIL_ADDRESS"
                    Return Orig_EMAIL_ADDRESS
                Case "Orig_EMAIL_ADDRESS2"
                    Return Orig_EMAIL_ADDRESS2
                Case "Orig_LAST_ALTERED_BY"
                    Return Orig_LAST_ALTERED_BY
                Case "Orig_LAST_ALTERED_DATE"
                    Return Orig_LAST_ALTERED_DATE
                Case "ATTENDING_SCHOOL_ID"
                    Return ATTENDING_SCHOOL_ID
                Case "CURR_RESID_ADDRESS_ID"
                    Return CURR_RESID_ADDRESS_ID
                Case "ORIG_RESID_ADDRESS_ID"
                    Return ORIG_RESID_ADDRESS_ID
                Case "PostAdd_SCHOOL_ADDRESS_ID_ifknown"
                    Return PostAdd_SCHOOL_ADDRESS_ID_ifknown
                Case "POSTAL_ADDRESS_ID"
                    Return POSTAL_ADDRESS_ID
                Case "flag_same_as_school_old"
                    Return flag_same_as_school_old
                Case "flag_same_as_school"
                    Return flag_same_as_school
                Case "this_LAST_ALTERED_BY"
                    Return this_LAST_ALTERED_BY
                Case "ajaxBusy"
                    Return ajaxBusy
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblMessage"
                    lblMessage = CType(value, TextField)
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "cbox_same_as_school"
                    cbox_same_as_school = CType(value, IntegerField)
                Case "PostAdd_ADDRESS_ID"
                    PostAdd_ADDRESS_ID = CType(value, FloatField)
                Case "Postal_ADDRESSEE"
                    Postal_ADDRESSEE = CType(value, TextField)
                Case "PostAdd_ADDRESS_ID_orig"
                    PostAdd_ADDRESS_ID_orig = CType(value, FloatField)
                Case "Postal_AGENT"
                    Postal_AGENT = CType(value, TextField)
                Case "Postal_ADDR1"
                    Postal_ADDR1 = CType(value, TextField)
                Case "Postal_ADDR2"
                    Postal_ADDR2 = CType(value, TextField)
                Case "Postal_SUBURB_TOWN"
                    Postal_SUBURB_TOWN = CType(value, TextField)
                Case "Postal_STATE"
                    Postal_STATE = CType(value, TextField)
                Case "Postal_POSTCODE"
                    Postal_POSTCODE = CType(value, TextField)
                Case "Postal_COUNTRY"
                    Postal_COUNTRY = CType(value, TextField)
                Case "Postal_PHONE_A"
                    Postal_PHONE_A = CType(value, TextField)
                Case "Postal_PHONE_B"
                    Postal_PHONE_B = CType(value, TextField)
                Case "Postal_FAX"
                    Postal_FAX = CType(value, TextField)
                Case "Postal_EMAIL_ADDRESS"
                    Postal_EMAIL_ADDRESS = CType(value, TextField)
                Case "Postal_EMAIL_ADDRESS2"
                    Postal_EMAIL_ADDRESS2 = CType(value, TextField)
                Case "Postal_LAST_ALTERED_BY"
                    Postal_LAST_ALTERED_BY = CType(value, TextField)
                Case "Postal_LAST_ALTERED_DATE"
                    Postal_LAST_ALTERED_DATE = CType(value, DateField)
                Case "cbox_same_as_postal"
                    cbox_same_as_postal = CType(value, IntegerField)
                Case "Curr_ADDRESS_ID"
                    Curr_ADDRESS_ID = CType(value, FloatField)
                Case "Curr_ADDRESSEE"
                    Curr_ADDRESSEE = CType(value, TextField)
                Case "Curr_ADDRESS_ID_orig"
                    Curr_ADDRESS_ID_orig = CType(value, FloatField)
                Case "Curr_AGENT"
                    Curr_AGENT = CType(value, TextField)
                Case "Curr_ADDR1"
                    Curr_ADDR1 = CType(value, TextField)
                Case "Curr_ADDR2"
                    Curr_ADDR2 = CType(value, TextField)
                Case "Curr_SUBURB_TOWN"
                    Curr_SUBURB_TOWN = CType(value, TextField)
                Case "Curr_STATE"
                    Curr_STATE = CType(value, TextField)
                Case "Curr_POSTCODE"
                    Curr_POSTCODE = CType(value, TextField)
                Case "Curr_COUNTRY"
                    Curr_COUNTRY = CType(value, TextField)
                Case "Curr_PHONE_A"
                    Curr_PHONE_A = CType(value, TextField)
                Case "Curr_PHONE_B"
                    Curr_PHONE_B = CType(value, TextField)
                Case "Curr_FAX"
                    Curr_FAX = CType(value, TextField)
                Case "Curr_EMAIL_ADDRESS"
                    Curr_EMAIL_ADDRESS = CType(value, TextField)
                Case "Curr_EMAIL_ADDRESS2"
                    Curr_EMAIL_ADDRESS2 = CType(value, TextField)
                Case "Curr_LAST_ALTERED_BY"
                    Curr_LAST_ALTERED_BY = CType(value, TextField)
                Case "Curr_LAST_ALTERED_DATE"
                    Curr_LAST_ALTERED_DATE = CType(value, DateField)
                Case "Orig_ADDRESS_ID"
                    Orig_ADDRESS_ID = CType(value, FloatField)
                Case "Orig_ADDRESSEE"
                    Orig_ADDRESSEE = CType(value, TextField)
                Case "Orig_ADDRESS_ID_orig"
                    Orig_ADDRESS_ID_orig = CType(value, FloatField)
                Case "Orig_AGENT"
                    Orig_AGENT = CType(value, TextField)
                Case "Orig_ADDR1"
                    Orig_ADDR1 = CType(value, TextField)
                Case "Orig_ADDR2"
                    Orig_ADDR2 = CType(value, TextField)
                Case "Orig_SUBURB_TOWN"
                    Orig_SUBURB_TOWN = CType(value, TextField)
                Case "Orig_STATE"
                    Orig_STATE = CType(value, TextField)
                Case "Orig_POSTCODE"
                    Orig_POSTCODE = CType(value, TextField)
                Case "Orig_COUNTRY"
                    Orig_COUNTRY = CType(value, TextField)
                Case "Orig_PHONE_A"
                    Orig_PHONE_A = CType(value, TextField)
                Case "Orig_PHONE_B"
                    Orig_PHONE_B = CType(value, TextField)
                Case "Orig_FAX"
                    Orig_FAX = CType(value, TextField)
                Case "Orig_EMAIL_ADDRESS"
                    Orig_EMAIL_ADDRESS = CType(value, TextField)
                Case "Orig_EMAIL_ADDRESS2"
                    Orig_EMAIL_ADDRESS2 = CType(value, TextField)
                Case "Orig_LAST_ALTERED_BY"
                    Orig_LAST_ALTERED_BY = CType(value, TextField)
                Case "Orig_LAST_ALTERED_DATE"
                    Orig_LAST_ALTERED_DATE = CType(value, DateField)
                Case "ATTENDING_SCHOOL_ID"
                    ATTENDING_SCHOOL_ID = CType(value, FloatField)
                Case "CURR_RESID_ADDRESS_ID"
                    CURR_RESID_ADDRESS_ID = CType(value, FloatField)
                Case "ORIG_RESID_ADDRESS_ID"
                    ORIG_RESID_ADDRESS_ID = CType(value, FloatField)
                Case "PostAdd_SCHOOL_ADDRESS_ID_ifknown"
                    PostAdd_SCHOOL_ADDRESS_ID_ifknown = CType(value, FloatField)
                Case "POSTAL_ADDRESS_ID"
                    POSTAL_ADDRESS_ID = CType(value, FloatField)
                Case "flag_same_as_school_old"
                    flag_same_as_school_old = CType(value, IntegerField)
                Case "flag_same_as_school"
                    flag_same_as_school = CType(value, IntegerField)
                Case "this_LAST_ALTERED_BY"
                    this_LAST_ALTERED_BY = CType(value, TextField)
                Case "ajaxBusy"
                    ajaxBusy = CType(value, TextField)
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Set
    End Property

    Public Property IsNew() As Boolean
        Get
            Return _isNew
        End Get
        Set
            _isNew = Value
        End Set
    End Property

    Public Property IsDeleted() As Boolean
        Get
            Return _isDeleted
        End Get
        Set
            _isDeleted = Value
        End Set
    End Property

    Public Sub Validate(ByVal provider As viewStudentMaintain_AddreDataProvider)
'End Record viewStudentMaintain_Addre Item Class

'Curr_ADDRESSEE validate @31-ED22CE64
        If IsNothing(Curr_ADDRESSEE.Value) OrElse Curr_ADDRESSEE.Value.ToString() ="" Then
            errors.Add("Curr_ADDRESSEE",String.Format(Resources.strings.CCS_RequiredField,"Current Address ADDRESSEE"))
        End If
'End Curr_ADDRESSEE validate

'Curr_SUBURB_TOWN validate @35-CBE51311
        If IsNothing(Curr_SUBURB_TOWN.Value) OrElse Curr_SUBURB_TOWN.Value.ToString() ="" Then
            errors.Add("Curr_SUBURB_TOWN",String.Format(Resources.strings.CCS_RequiredField,"Current Address SUBURB TOWN"))
        End If
'End Curr_SUBURB_TOWN validate

'Curr_COUNTRY validate @38-DC830474
        If IsNothing(Curr_COUNTRY.Value) OrElse Curr_COUNTRY.Value.ToString() ="" Then
            errors.Add("Curr_COUNTRY",String.Format(Resources.strings.CCS_RequiredField,"Current Address COUNTRY"))
        End If
'End Curr_COUNTRY validate

'Record viewStudentMaintain_Addre Event OnValidate. Action Custom Code @157-73254650
    ' -------------------------
    ' ERA: if the checkbox is NOT checked then validate the Postal Address otherwise dont (as it will have the School details)
'	if (cbox_same_as_school.Value = cbox_same_as_schoolUncheckedValue.value) then
'        If (Postal_ADDRESSEE.Value Is Nothing) OrElse Postal_ADDRESSEE.Value.ToString()="" Then
'            errors.Add("Postal_ADDRESSEE",String.Format(Resources.strings.CCS_RequiredField,"Postal Address ADDRESSEE"))
'        End If
'    	If (Postal_SUBURB_TOWN.Value Is Nothing) OrElse Postal_SUBURB_TOWN.Value.ToString()="" Then
'            'errors.Add("Postal_SUBURB_TOWN",String.Format("The field Postal SUBURB TOWN requires a value.","viewStudentMaintain_Addre"))
'			errors.Add("Postal_SUBURB_TOWN",String.Format(Resources.strings.CCS_RequiredField,"Postal Address SUBURB TOWN"))
'        End If
'		If (Postal_COUNTRY.Value Is Nothing) OrElse Postal_COUNTRY.Value.ToString()="" Then
'            'errors.Add("Postal_COUNTRY",String.Format("The field Postal COUNTRY requires a value.","viewStudentMaintain_Addre"))
'			errors.Add("Postal_COUNTRY",String.Format(Resources.strings.CCS_RequiredField,"Postal Address COUNTRY"))
'        End If
'
'	end if 
    ' -------------------------
'End Record viewStudentMaintain_Addre Event OnValidate. Action Custom Code

'Record viewStudentMaintain_Addre Item Class tail @5-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record viewStudentMaintain_Addre Item Class tail

'Record viewStudentMaintain_Addre Data Provider Class @5-62A9B9F3
Public Class viewStudentMaintain_AddreDataProvider
Inherits RecordDataProviderBase
'End Record viewStudentMaintain_Addre Data Provider Class

'Record viewStudentMaintain_Addre Data Provider Class Variables @5-E4EE4331
    Public ExprKey122 As IntegerParameter
    Public UrlSTUDENT_ID As IntegerParameter
    Public CtrlATTENDING_SCHOOL_ID As IntegerParameter
    Public CtrlPOSTAL_ADDRESS_ID As IntegerParameter
    Public CtrlCURR_RESID_ADDRESS_ID As IntegerParameter
    Public CtrlORIG_RESID_ADDRESS_ID As IntegerParameter
    Public Ctrlflag_same_as_school As IntegerParameter
    Public Ctrlflag_same_as_school_old As IntegerParameter
    Public CtrlPostAdd_ADDRESS_ID As IntegerParameter
    Public CtrlPostal_ADDRESSEE As TextParameter
    Public CtrlPostal_AGENT As TextParameter
    Public CtrlPostal_ADDR1 As TextParameter
    Public CtrlPostal_ADDR2 As TextParameter
    Public CtrlPostal_SUBURB_TOWN As TextParameter
    Public CtrlPostal_POSTCODE As TextParameter
    Public CtrlPostal_STATE As TextParameter
    Public CtrlPostal_COUNTRY As TextParameter
    Public CtrlPostal_PHONE_A As TextParameter
    Public CtrlPostal_PHONE_B As TextParameter
    Public CtrlPostal_FAX As TextParameter
    Public CtrlPostal_EMAIL_ADDRESS As TextParameter
    Public CtrlPostal_EMAIL_ADDRESS2 As TextParameter
    Public Ctrlcbox_same_as_postal As IntegerParameter
    Public Sesflag_same_as_postal_old As IntegerParameter
    Public CtrlCurr_ADDRESS_ID As IntegerParameter
    Public CtrlCurr_ADDRESSEE As TextParameter
    Public CtrlCurr_AGENT As TextParameter
    Public CtrlCurr_ADDR1 As TextParameter
    Public CtrlCurr_ADDR2 As TextParameter
    Public CtrlCurr_SUBURB_TOWN As TextParameter
    Public CtrlCurr_POSTCODE As TextParameter
    Public CtrlCurr_STATE As TextParameter
    Public CtrlCurr_COUNTRY As TextParameter
    Public CtrlCurr_PHONE_A As TextParameter
    Public CtrlCurr_PHONE_B As TextParameter
    Public CtrlCurr_FAX As TextParameter
    Public CtrlCurr_EMAIL_ADDRESS As TextParameter
    Public CtrlCurr_EMAIL_ADDRESS2 As TextParameter
    Public CtrlOrig_ADDRESS_ID As IntegerParameter
    Public CtrlOrig_ADDRESSEE As TextParameter
    Public CtrlOrig_AGENT As TextParameter
    Public CtrlOrig_ADDR1 As TextParameter
    Public CtrlOrig_ADDR2 As TextParameter
    Public CtrlOrig_SUBURB_TOWN As TextParameter
    Public CtrlOrig_POSTCODE As TextParameter
    Public CtrlOrig_STATE As TextParameter
    Public CtrlOrig_COUNTRY As TextParameter
    Public CtrlOrig_PHONE_A As TextParameter
    Public CtrlOrig_PHONE_B As TextParameter
    Public CtrlOrig_FAX As TextParameter
    Public CtrlOrig_EMAIL_ADDRESS As TextParameter
    Public CtrlOrig_EMAIL_ADDRESS2 As TextParameter
    Public SesUserID As TextParameter
    Protected item As viewStudentMaintain_AddreItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record viewStudentMaintain_Addre Data Provider Class Variables

'Record viewStudentMaintain_Addre Data Provider Class Constructor @5-4EF31E6B

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM viewStudentMaintain_AddressList {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID8"},Settings.connDECVPRODSQL2005DataAccessObject )
        Update=new SpCommand("spu_UpdateStudentAddress;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record viewStudentMaintain_Addre Data Provider Class Constructor

'Record viewStudentMaintain_Addre Data Provider Class LoadParams Method @5-A977A0E9

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID))
    End Function
'End Record viewStudentMaintain_Addre Data Provider Class LoadParams Method

'Record viewStudentMaintain_Addre Data Provider Class CheckUnique Method @5-411EDE32

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As viewStudentMaintain_AddreItem) As Boolean
        Return True
    End Function
'End Record viewStudentMaintain_Addre Data Provider Class CheckUnique Method

'Record viewStudentMaintain_Addre Data Provider Class PrepareUpdate Method @5-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record viewStudentMaintain_Addre Data Provider Class PrepareUpdate Method

'DEL      ' -------------------------
'DEL      ' ERA: debug 
'DEL  	viewStudentMaintain_AddreErrors.Add("debug","Same as school flag item: "& item.flag_same_as_school.getformattedValue() )
'DEL  	viewStudentMaintain_AddreErrors.Add("debug","Same as school flag OLD: "& item.flag_same_as_school_old.getformattedValue())
'DEL      ErrorFlag = True
'DEL  	
'DEL      ' -------------------------


'Record viewStudentMaintain_Addre Data Provider Class PrepareUpdate Method tail @5-E31F8E2A
    End Sub
'End Record viewStudentMaintain_Addre Data Provider Class PrepareUpdate Method tail

'Record viewStudentMaintain_Addre Data Provider Class Update Method @5-7484FC53

    Public Function UpdateItem(ByVal item As viewStudentMaintain_AddreItem) As Integer
        Me.item = item
'End Record viewStudentMaintain_Addre Data Provider Class Update Method

'Record viewStudentMaintain_Addre BeforeBuildUpdate @5-0DE93269
        Update.Parameters.Clear()
        CType(Update,SpCommand).AddParameter("@RETURN_VALUE",ExprKey122,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Update,SpCommand).AddParameter("@STUDENT_ID",UrlSTUDENT_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@ATTENDING_SCHOOL_ID",item.ATTENDING_SCHOOL_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@POSTAL_ADDRESS_ID",item.POSTAL_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@CURR_RESID_ADDRESS_ID",item.CURR_RESID_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@ORIG_RESID_ADDRESS_ID",item.ORIG_RESID_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@flag_same_as_school",item.flag_same_as_school,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@flag_same_as_school_old",item.flag_same_as_school_old,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@PostAdd_ADDRESS_ID",item.PostAdd_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@Postal_ADDRESSEE",item.Postal_ADDRESSEE,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Update,SpCommand).AddParameter("@Postal_AGENT",item.Postal_AGENT,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Update,SpCommand).AddParameter("@Postal_ADDR1",item.Postal_ADDR1,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@Postal_ADDR2",item.Postal_ADDR2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@Postal_SUBURB_TOWN",item.Postal_SUBURB_TOWN,ParameterType._Char,ParameterDirection.Input,30,0,10)
        CType(Update,SpCommand).AddParameter("@Postal_POSTCODE",item.Postal_POSTCODE,ParameterType._Char,ParameterDirection.Input,10,0,10)
        CType(Update,SpCommand).AddParameter("@Postal_STATE",item.Postal_STATE,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Update,SpCommand).AddParameter("@Postal_COUNTRY",item.Postal_COUNTRY,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Update,SpCommand).AddParameter("@Postal_PHONE_A",item.Postal_PHONE_A,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@Postal_PHONE_B",item.Postal_PHONE_B,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@Postal_FAX",item.Postal_FAX,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@Postal_EMAIL_ADDRESS",item.Postal_EMAIL_ADDRESS,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@Postal_EMAIL_ADDRESS2",item.Postal_EMAIL_ADDRESS2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@flag_same_as_postal",item.cbox_same_as_postal,ParameterType._Int,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@flag_same_as_postal_old",Sesflag_same_as_postal_old,ParameterType._Int,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_ADDRESS_ID",item.Curr_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_ADDRESSEE",item.Curr_ADDRESSEE,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_AGENT",item.Curr_AGENT,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_ADDR1",item.Curr_ADDR1,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_ADDR2",item.Curr_ADDR2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_SUBURB_TOWN",item.Curr_SUBURB_TOWN,ParameterType._Char,ParameterDirection.Input,30,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_POSTCODE",item.Curr_POSTCODE,ParameterType._Char,ParameterDirection.Input,10,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_STATE",item.Curr_STATE,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_COUNTRY",item.Curr_COUNTRY,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_PHONE_A",item.Curr_PHONE_A,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_PHONE_B",item.Curr_PHONE_B,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_FAX",item.Curr_FAX,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_EMAIL_ADDRESS",item.Curr_EMAIL_ADDRESS,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@Curr_EMAIL_ADDRESS2",item.Curr_EMAIL_ADDRESS2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_ADDRESS_ID",item.Orig_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_ADDRESSEE",item.Orig_ADDRESSEE,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_AGENT",item.Orig_AGENT,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_ADDR1",item.Orig_ADDR1,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_ADDR2",item.Orig_ADDR2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_SUBURB_TOWN",item.Orig_SUBURB_TOWN,ParameterType._Char,ParameterDirection.Input,30,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_POSTCODE",item.Orig_POSTCODE,ParameterType._Char,ParameterDirection.Input,10,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_STATE",item.Orig_STATE,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_COUNTRY",item.Orig_COUNTRY,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_PHONE_A",item.Orig_PHONE_A,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_PHONE_B",item.Orig_PHONE_B,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_FAX",item.Orig_FAX,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_EMAIL_ADDRESS",item.Orig_EMAIL_ADDRESS,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@Orig_EMAIL_ADDRESS2",item.Orig_EMAIL_ADDRESS2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@LAST_ALTERED_BY",SesUserID,ParameterType._Char,ParameterDirection.Input,8,0,10)
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteUpdate()
            ExprKey122 = IntegerParameter.GetParam(CType(Update.Parameters("@RETURN_VALUE"),IDataParameter).Value, CObj(0))
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record viewStudentMaintain_Addre BeforeBuildUpdate

'Record viewStudentMaintain_Addre AfterExecuteUpdate @5-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record viewStudentMaintain_Addre AfterExecuteUpdate

'Record viewStudentMaintain_Addre Data Provider Class GetResultSet Method @5-BCCD35D4

    Public Sub FillItem(ByVal item As viewStudentMaintain_AddreItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record viewStudentMaintain_Addre Data Provider Class GetResultSet Method

'Record viewStudentMaintain_Addre BeforeBuildSelect @5-F73FDD40
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID8",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record viewStudentMaintain_Addre BeforeBuildSelect

'Record viewStudentMaintain_Addre BeforeExecuteSelect @5-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record viewStudentMaintain_Addre BeforeExecuteSelect

'Record viewStudentMaintain_Addre AfterExecuteSelect @5-7445D7E6
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.PostAdd_ADDRESS_ID.SetValue(dr(i)("PostAdd_ADDRESS_ID"),"")
            item.Postal_ADDRESSEE.SetValue(dr(i)("Postal_ADDRESSEE"),"")
            item.PostAdd_ADDRESS_ID_orig.SetValue(dr(i)("PostAdd_ADDRESS_ID"),"")
            item.Postal_AGENT.SetValue(dr(i)("Postal_AGENT"),"")
            item.Postal_ADDR1.SetValue(dr(i)("Postal_ADDR1"),"")
            item.Postal_ADDR2.SetValue(dr(i)("Postal_ADDR2"),"")
            item.Postal_SUBURB_TOWN.SetValue(dr(i)("Postal_SUBURB_TOWN"),"")
            item.Postal_STATE.SetValue(dr(i)("Postal_STATE"),"")
            item.Postal_POSTCODE.SetValue(dr(i)("Postal_POSTCODE"),"")
            item.Postal_COUNTRY.SetValue(dr(i)("Postal_COUNTRY"),"")
            item.Postal_PHONE_A.SetValue(dr(i)("Postal_PHONE_A"),"")
            item.Postal_PHONE_B.SetValue(dr(i)("Postal_PHONE_B"),"")
            item.Postal_FAX.SetValue(dr(i)("Postal_FAX"),"")
            item.Postal_EMAIL_ADDRESS.SetValue(dr(i)("Postal_EMAIL_ADDRESS"),"")
            item.Postal_EMAIL_ADDRESS2.SetValue(dr(i)("Postal_EMAIL_ADDRESS2"),"")
            item.Postal_LAST_ALTERED_BY.SetValue(dr(i)("Postal_LAST_ALTERED_BY"),"")
            item.Postal_LAST_ALTERED_DATE.SetValue(dr(i)("Postal_LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Curr_ADDRESS_ID.SetValue(dr(i)("Curr_ADDRESS_ID"),"")
            item.Curr_ADDRESSEE.SetValue(dr(i)("Curr_ADDRESSEE"),"")
            item.Curr_ADDRESS_ID_orig.SetValue(dr(i)("Curr_ADDRESS_ID"),"")
            item.Curr_AGENT.SetValue(dr(i)("Curr_AGENT"),"")
            item.Curr_ADDR1.SetValue(dr(i)("Curr_ADDR1"),"")
            item.Curr_ADDR2.SetValue(dr(i)("Curr_ADDR2"),"")
            item.Curr_SUBURB_TOWN.SetValue(dr(i)("Curr_SUBURB_TOWN"),"")
            item.Curr_STATE.SetValue(dr(i)("Curr_STATE"),"")
            item.Curr_POSTCODE.SetValue(dr(i)("Curr_POSTCODE"),"")
            item.Curr_COUNTRY.SetValue(dr(i)("Curr_COUNTRY"),"")
            item.Curr_PHONE_A.SetValue(dr(i)("Curr_PHONE_A"),"")
            item.Curr_PHONE_B.SetValue(dr(i)("Curr_PHONE_B"),"")
            item.Curr_FAX.SetValue(dr(i)("Curr_FAX"),"")
            item.Curr_EMAIL_ADDRESS.SetValue(dr(i)("Curr_EMAIL_ADDRESS"),"")
            item.Curr_EMAIL_ADDRESS2.SetValue(dr(i)("Curr_EMAIL_ADDRESS2"),"")
            item.Curr_LAST_ALTERED_BY.SetValue(dr(i)("Curr_LAST_ALTERED_BY"),"")
            item.Curr_LAST_ALTERED_DATE.SetValue(dr(i)("Curr_LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Orig_ADDRESS_ID.SetValue(dr(i)("Orig_ADDRESS_ID"),"")
            item.Orig_ADDRESSEE.SetValue(dr(i)("Orig_ADDRESSEE"),"")
            item.Orig_ADDRESS_ID_orig.SetValue(dr(i)("Orig_ADDRESS_ID"),"")
            item.Orig_AGENT.SetValue(dr(i)("Orig_AGENT"),"")
            item.Orig_ADDR1.SetValue(dr(i)("Orig_ADDR1"),"")
            item.Orig_ADDR2.SetValue(dr(i)("Orig_ADDR2"),"")
            item.Orig_SUBURB_TOWN.SetValue(dr(i)("Orig_SUBURB_TOWN"),"")
            item.Orig_STATE.SetValue(dr(i)("Orig_STATE"),"")
            item.Orig_POSTCODE.SetValue(dr(i)("Orig_POSTCODE"),"")
            item.Orig_COUNTRY.SetValue(dr(i)("Orig_COUNTRY"),"")
            item.Orig_PHONE_A.SetValue(dr(i)("Orig_PHONE_A"),"")
            item.Orig_PHONE_B.SetValue(dr(i)("Orig_PHONE_B"),"")
            item.Orig_FAX.SetValue(dr(i)("Orig_FAX"),"")
            item.Orig_EMAIL_ADDRESS.SetValue(dr(i)("Orig_EMAIL_ADDRESS"),"")
            item.Orig_EMAIL_ADDRESS2.SetValue(dr(i)("Orig_EMAIL_ADDRESS2"),"")
            item.Orig_LAST_ALTERED_BY.SetValue(dr(i)("Orig_LAST_ALTERED_BY"),"")
            item.Orig_LAST_ALTERED_DATE.SetValue(dr(i)("Orig_LAST_ALTERED_DATE"),Select_.DateFormat)
            item.ATTENDING_SCHOOL_ID.SetValue(dr(i)("ATTENDING_SCHOOL_ID"),"")
            item.CURR_RESID_ADDRESS_ID.SetValue(dr(i)("CURR_RESID_ADDRESS_ID"),"")
            item.ORIG_RESID_ADDRESS_ID.SetValue(dr(i)("ORIG_RESID_ADDRESS_ID"),"")
            item.POSTAL_ADDRESS_ID.SetValue(dr(i)("POSTAL_ADDRESS_ID"),"")
        Else
            IsInsertMode = True
        End If
'End Record viewStudentMaintain_Addre AfterExecuteSelect

'Record viewStudentMaintain_Addre AfterExecuteSelect tail @5-E31F8E2A
    End Sub
'End Record viewStudentMaintain_Addre AfterExecuteSelect tail

'Record viewStudentMaintain_Addre Data Provider Class @5-A61BA892
End Class

'End Record viewStudentMaintain_Addre Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

