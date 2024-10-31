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

Namespace DECV_PROD2007.Update_Utilities 'Namespace @1-3CBD21D6

'Page Data Class @1-7BD909E8
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblModified As TextField
    Public Sub New()
        lblModified = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.lblModified.SetValue(DBUtility.GetInitialValue("lblModified"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblModified"
                    Return lblModified
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblModified"
                    lblModified = CType(value, TextField)
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

'Record UpdateForm Item Class @53-FB5A21E2
Public Class UpdateFormItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public txtEnrolYear1 As IntegerField
    Public txtEnrolYear2 As IntegerField
    Public semester_1 As BooleanField
    Public semester_1CheckedValue As BooleanField
    Public semester_1UncheckedValue As BooleanField
    Public semester_2 As BooleanField
    Public semester_2CheckedValue As BooleanField
    Public semester_2UncheckedValue As BooleanField
    Public semester_both As BooleanField
    Public semester_bothCheckedValue As BooleanField
    Public semester_bothUncheckedValue As BooleanField
    Public txtGrace As IntegerField
    Public CheckBox0 As BooleanField
    Public CheckBox0CheckedValue As BooleanField
    Public CheckBox0UncheckedValue As BooleanField
    Public CheckBox1 As BooleanField
    Public CheckBox1CheckedValue As BooleanField
    Public CheckBox1UncheckedValue As BooleanField
    Public CheckBox2 As BooleanField
    Public CheckBox2CheckedValue As BooleanField
    Public CheckBox2UncheckedValue As BooleanField
    Public CheckBox3 As BooleanField
    Public CheckBox3CheckedValue As BooleanField
    Public CheckBox3UncheckedValue As BooleanField
    Public CheckBox4 As BooleanField
    Public CheckBox4CheckedValue As BooleanField
    Public CheckBox4UncheckedValue As BooleanField
    Public CheckBox5 As BooleanField
    Public CheckBox5CheckedValue As BooleanField
    Public CheckBox5UncheckedValue As BooleanField
    Public CheckBox6 As BooleanField
    Public CheckBox6CheckedValue As BooleanField
    Public CheckBox6UncheckedValue As BooleanField
    Public CheckBox7 As BooleanField
    Public CheckBox7CheckedValue As BooleanField
    Public CheckBox7UncheckedValue As BooleanField
    Public CheckBox8 As BooleanField
    Public CheckBox8CheckedValue As BooleanField
    Public CheckBox8UncheckedValue As BooleanField
    Public CheckBox9 As BooleanField
    Public CheckBox9CheckedValue As BooleanField
    Public CheckBox9UncheckedValue As BooleanField
    Public CheckBox10 As BooleanField
    Public CheckBox10CheckedValue As BooleanField
    Public CheckBox10UncheckedValue As BooleanField
    Public CheckBox11 As BooleanField
    Public CheckBox11CheckedValue As BooleanField
    Public CheckBox11UncheckedValue As BooleanField
    Public CheckBox12 As BooleanField
    Public CheckBox12CheckedValue As BooleanField
    Public CheckBox12UncheckedValue As BooleanField
    Public CheckBox_All As BooleanField
    Public CheckBox_AllCheckedValue As BooleanField
    Public CheckBox_AllUncheckedValue As BooleanField
    Public lblSelections As TextField
    Public Sub New()
    txtEnrolYear1 = New IntegerField("", year(now()))
    txtEnrolYear2 = New IntegerField("", year(now()))
    semester_1 = New BooleanField(Settings.BoolFormat, true)
    semester_1CheckedValue = New BooleanField(Settings.BoolFormat, true)
    semester_1UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    semester_2 = New BooleanField(Settings.BoolFormat, true)
    semester_2CheckedValue = New BooleanField(Settings.BoolFormat, true)
    semester_2UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    semester_both = New BooleanField(Settings.BoolFormat, true)
    semester_bothCheckedValue = New BooleanField(Settings.BoolFormat, true)
    semester_bothUncheckedValue = New BooleanField(Settings.BoolFormat, false)
    txtGrace = New IntegerField("", 4)
    CheckBox0 = New BooleanField(Settings.BoolFormat, false)
    CheckBox0CheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox0UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    CheckBox1 = New BooleanField(Settings.BoolFormat, false)
    CheckBox1CheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox1UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    CheckBox2 = New BooleanField(Settings.BoolFormat, false)
    CheckBox2CheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox2UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    CheckBox3 = New BooleanField(Settings.BoolFormat, false)
    CheckBox3CheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox3UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    CheckBox4 = New BooleanField(Settings.BoolFormat, false)
    CheckBox4CheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox4UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    CheckBox5 = New BooleanField(Settings.BoolFormat, false)
    CheckBox5CheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox5UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    CheckBox6 = New BooleanField(Settings.BoolFormat, false)
    CheckBox6CheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox6UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    CheckBox7 = New BooleanField(Settings.BoolFormat, false)
    CheckBox7CheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox7UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    CheckBox8 = New BooleanField(Settings.BoolFormat, false)
    CheckBox8CheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox8UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    CheckBox9 = New BooleanField(Settings.BoolFormat, false)
    CheckBox9CheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox9UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    CheckBox10 = New BooleanField(Settings.BoolFormat, false)
    CheckBox10CheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox10UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    CheckBox11 = New BooleanField(Settings.BoolFormat, false)
    CheckBox11CheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox11UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    CheckBox12 = New BooleanField(Settings.BoolFormat, false)
    CheckBox12CheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox12UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    CheckBox_All = New BooleanField(Settings.BoolFormat, False)
    CheckBox_AllCheckedValue = New BooleanField(Settings.BoolFormat, True)
    CheckBox_AllUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    lblSelections = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As UpdateFormItem
        Dim item As UpdateFormItem = New UpdateFormItem()
        If Not IsNothing(DBUtility.GetInitialValue("txtEnrolYear1")) Then
        item.txtEnrolYear1.SetValue(DBUtility.GetInitialValue("txtEnrolYear1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoUpdate1")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoUpdate3")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("txtEnrolYear2")) Then
        item.txtEnrolYear2.SetValue(DBUtility.GetInitialValue("txtEnrolYear2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("semester_1")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("semester_1")) Then
            item.semester_1.Value = item.semester_1CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("semester_2")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("semester_2")) Then
            item.semester_2.Value = item.semester_2CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("semester_both")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("semester_both")) Then
            item.semester_both.Value = item.semester_bothCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("txtGrace")) Then
        item.txtGrace.SetValue(DBUtility.GetInitialValue("txtGrace"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoUpdate2")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox0")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox0")) Then
            item.CheckBox0.Value = item.CheckBox0CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox1")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox1")) Then
            item.CheckBox1.Value = item.CheckBox1CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox2")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox2")) Then
            item.CheckBox2.Value = item.CheckBox2CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox3")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox3")) Then
            item.CheckBox3.Value = item.CheckBox3CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox4")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox4")) Then
            item.CheckBox4.Value = item.CheckBox4CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox5")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox5")) Then
            item.CheckBox5.Value = item.CheckBox5CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox6")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox6")) Then
            item.CheckBox6.Value = item.CheckBox6CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox7")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox7")) Then
            item.CheckBox7.Value = item.CheckBox7CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox8")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox8")) Then
            item.CheckBox8.Value = item.CheckBox8CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox9")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox9")) Then
            item.CheckBox9.Value = item.CheckBox9CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox10")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox10")) Then
            item.CheckBox10.Value = item.CheckBox10CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox11")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox11")) Then
            item.CheckBox11.Value = item.CheckBox11CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox12")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox12")) Then
            item.CheckBox12.Value = item.CheckBox12CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBox_All")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("CheckBox_All")) Then
            item.CheckBox_All.Value = item.CheckBox_AllCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSelections")) Then
        item.lblSelections.SetValue(DBUtility.GetInitialValue("lblSelections"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "txtEnrolYear1"
                    Return txtEnrolYear1
                Case "txtEnrolYear2"
                    Return txtEnrolYear2
                Case "semester_1"
                    Return semester_1
                Case "semester_2"
                    Return semester_2
                Case "semester_both"
                    Return semester_both
                Case "txtGrace"
                    Return txtGrace
                Case "CheckBox0"
                    Return CheckBox0
                Case "CheckBox1"
                    Return CheckBox1
                Case "CheckBox2"
                    Return CheckBox2
                Case "CheckBox3"
                    Return CheckBox3
                Case "CheckBox4"
                    Return CheckBox4
                Case "CheckBox5"
                    Return CheckBox5
                Case "CheckBox6"
                    Return CheckBox6
                Case "CheckBox7"
                    Return CheckBox7
                Case "CheckBox8"
                    Return CheckBox8
                Case "CheckBox9"
                    Return CheckBox9
                Case "CheckBox10"
                    Return CheckBox10
                Case "CheckBox11"
                    Return CheckBox11
                Case "CheckBox12"
                    Return CheckBox12
                Case "CheckBox_All"
                    Return CheckBox_All
                Case "lblSelections"
                    Return lblSelections
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "txtEnrolYear1"
                    txtEnrolYear1 = CType(value, IntegerField)
                Case "txtEnrolYear2"
                    txtEnrolYear2 = CType(value, IntegerField)
                Case "semester_1"
                    semester_1 = CType(value, BooleanField)
                Case "semester_2"
                    semester_2 = CType(value, BooleanField)
                Case "semester_both"
                    semester_both = CType(value, BooleanField)
                Case "txtGrace"
                    txtGrace = CType(value, IntegerField)
                Case "CheckBox0"
                    CheckBox0 = CType(value, BooleanField)
                Case "CheckBox1"
                    CheckBox1 = CType(value, BooleanField)
                Case "CheckBox2"
                    CheckBox2 = CType(value, BooleanField)
                Case "CheckBox3"
                    CheckBox3 = CType(value, BooleanField)
                Case "CheckBox4"
                    CheckBox4 = CType(value, BooleanField)
                Case "CheckBox5"
                    CheckBox5 = CType(value, BooleanField)
                Case "CheckBox6"
                    CheckBox6 = CType(value, BooleanField)
                Case "CheckBox7"
                    CheckBox7 = CType(value, BooleanField)
                Case "CheckBox8"
                    CheckBox8 = CType(value, BooleanField)
                Case "CheckBox9"
                    CheckBox9 = CType(value, BooleanField)
                Case "CheckBox10"
                    CheckBox10 = CType(value, BooleanField)
                Case "CheckBox11"
                    CheckBox11 = CType(value, BooleanField)
                Case "CheckBox12"
                    CheckBox12 = CType(value, BooleanField)
                Case "CheckBox_All"
                    CheckBox_All = CType(value, BooleanField)
                Case "lblSelections"
                    lblSelections = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As UpdateFormDataProvider)
'End Record UpdateForm Item Class

'DEL      ' -------------------------
'DEL      'ERA: better handling of multi select checkbox - SEMESTERS
'DEL  	If ((semester_1.value = false) AND (semester_2.value = false) AND (semester_both.value = false)) Then
'DEL  		errors.Add("semester_both","At least one Semester checkbox must be ticked.")
'DEL      End If
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL      'ERA: better handling of multi select checkbox - Year Levels
'DEL  	If ((checkbox0.value = false) AND (checkbox1.value = false) AND (checkbox2.value = false) AND (checkbox3.value = false) AND (checkbox4.value = false) AND (checkbox5.value = false) AND (checkbox6.value = false) AND (checkbox7.value = false) AND (checkbox8.value = false) AND (checkbox9.value = false) AND (checkbox10.value = false) AND (checkbox11.value = false) AND (checkbox12.value = false)) Then
'DEL  		errors.Add("checkbox0","At least one Year Level checkbox must be ticked.")
'DEL      End If
'DEL      ' -------------------------


'Record UpdateForm Item Class tail @53-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record UpdateForm Item Class tail

'Record UpdateForm Data Provider Class @53-4ED18962
Public Class UpdateFormDataProvider
Inherits RecordDataProviderBase
'End Record UpdateForm Data Provider Class

'Record UpdateForm Data Provider Class Variables @53-11BE28A5
    Protected item As UpdateFormItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record UpdateForm Data Provider Class Variables

'Record UpdateForm Data Provider Class GetResultSet Method @53-6AD78FCC

    Public Sub FillItem(ByVal item As UpdateFormItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record UpdateForm Data Provider Class GetResultSet Method

'Record UpdateForm BeforeBuildSelect @53-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record UpdateForm BeforeBuildSelect

'Record UpdateForm AfterExecuteSelect @53-79426A21
        End If
            IsInsertMode = True
'End Record UpdateForm AfterExecuteSelect

'Record UpdateForm AfterExecuteSelect tail @53-E31F8E2A
    End Sub
'End Record UpdateForm AfterExecuteSelect tail

'Record UpdateForm Data Provider Class @53-A61BA892
End Class

'End Record UpdateForm Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

