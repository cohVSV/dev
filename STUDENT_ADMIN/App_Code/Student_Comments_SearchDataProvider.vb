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

Namespace DECV_PROD2007.Student_Comments_Search 'Namespace @1-43FFF762

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

'Grid Grid_CommentsResults Item Class @2-B171D6B4
Public Class Grid_CommentsResultsItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Grid1_TotalRecords As TextField
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public COMMENT As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public COMMENT_TYPE As TextField
    Public lblMostRecent50 As TextField
    Public Sub New()
    Grid1_TotalRecords = New TextField("", Nothing)
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    COMMENT = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("d MMM yyyy h\:mm tt", Nothing)
    COMMENT_TYPE = New TextField("", Nothing)
    lblMostRecent50 = New TextField("", "<font color=#cc9966>Your 50 most recent comments this year</font>")
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "Grid1_TotalRecords"
                    Return Me.Grid1_TotalRecords
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "COMMENT"
                    Return Me.COMMENT
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "COMMENT_TYPE"
                    Return Me.COMMENT_TYPE
                Case "lblMostRecent50"
                    Return Me.lblMostRecent50
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Grid1_TotalRecords"
                    Me.Grid1_TotalRecords = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "COMMENT"
                    Me.COMMENT = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "COMMENT_TYPE"
                    Me.COMMENT_TYPE = CType(Value,TextField)
                Case "lblMostRecent50"
                    Me.lblMostRecent50 = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid Grid_CommentsResults Item Class

'Grid Grid_CommentsResults Data Provider Class Header @2-157A7B2A
Public Class Grid_CommentsResultsDataProvider
Inherits GridDataProviderBase
'End Grid Grid_CommentsResults Data Provider Class Header

'Grid Grid_CommentsResults Data Provider Class Variables @2-C38F0E12

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_COMMENT
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
        Sorter_COMMENT_TYPE
    End Enum

    Private SortFieldsNames As String() = New String() {"last_altered_date desc","STUDENT_ID","COMMENT","LAST_ALTERED_BY","LAST_ALTERED_DATE","COMMENT_TYPE"}
    Private SortFieldsNamesDesc As String() = New string() {"last_altered_date desc","STUDENT_ID DESC","COMMENT DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC","COMMENT_TYPE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public Expr60  As TextParameter
'End Grid Grid_CommentsResults Data Provider Class Variables

'Grid Grid_CommentsResults Data Provider Class GetResultSet Method @2-11CF681D

    Public Sub New()
        Select_=new SqlCommand("SELECT top 50 *" & vbCrLf & _
          "FROM student_comment" & vbCrLf & _
          "WHERE year(last_altered_date) = year(getdate())" & vbCrLf & _
          "and LAST_ALTERED_BY = '{s_staffid}' {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT top 50 *" & vbCrLf & _
          "FROM student_comment" & vbCrLf & _
          "WHERE year(last_altered_date) = year(getdate())" & vbCrLf & _
          "and LAST_ALTERED_BY = '{s_staffid}') cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid Grid_CommentsResults Data Provider Class GetResultSet Method

'Grid Grid_CommentsResults Data Provider Class GetResultSet Method @2-EED8A468
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As Grid_CommentsResultsItem()
'End Grid Grid_CommentsResults Data Provider Class GetResultSet Method

'Grid Grid_CommentsResults Event BeforeBuildSelect. Action Custom Code @30-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End Grid Grid_CommentsResults Event BeforeBuildSelect. Action Custom Code

'Before build Select @2-ECF17042
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("s_staffid",Expr60, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-1771427B
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As Grid_CommentsResultsItem
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @2-E9793823
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New Grid_CommentsResultsItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-39288D69
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as Grid_CommentsResultsItem = New Grid_CommentsResultsItem()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.STUDENT_IDHref = "Student_Comments_maintain.aspx"
                item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.COMMENT.SetValue(dr(i)("COMMENT"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.COMMENT_TYPE.SetValue(dr(i)("COMMENT_TYPE"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @2-A61BA892
End Class
'End Grid Data Provider tail

'Record Search_Comments Item Class @19-F456CC29
Public Class Search_CommentsItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_keywords As TextField
    Public s_monthsago As IntegerField
    Public s_monthsagoItems As ItemCollection
    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public linkAirHead As TextField
    Public linkAirHeadHref As Object
    Public linkAirHeadHrefParameters As LinkParameterCollection
    Public Sub New()
    s_keywords = New TextField("", Nothing)
    s_monthsago = New IntegerField("", -1)
    s_monthsagoItems = New ItemCollection()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    linkAirHead = New TextField("",Nothing)
    linkAirHeadHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As Search_CommentsItem
        Dim item As Search_CommentsItem = New Search_CommentsItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_keywords")) Then
        item.s_keywords.SetValue(DBUtility.GetInitialValue("s_keywords"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_monthsago")) Then
        item.s_monthsago.SetValue(DBUtility.GetInitialValue("s_monthsago"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("linkAirHead")) Then
        item.linkAirHead.SetValue(DBUtility.GetInitialValue("linkAirHead"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_keywords"
                    Return s_keywords
                Case "s_monthsago"
                    Return s_monthsago
                Case "ClearParameters"
                    Return ClearParameters
                Case "linkAirHead"
                    Return linkAirHead
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_keywords"
                    s_keywords = CType(value, TextField)
                Case "s_monthsago"
                    s_monthsago = CType(value, IntegerField)
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "linkAirHead"
                    linkAirHead = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As Search_CommentsDataProvider)
'End Record Search_Comments Item Class

's_monthsago validate @23-9956E35D
        If IsNothing(s_monthsago.Value) OrElse s_monthsago.Value.ToString() ="" Then
            errors.Add("s_monthsago",String.Format(Resources.strings.CCS_RequiredField,"Months ago"))
        End If
'End s_monthsago validate

'Record Search_Comments Item Class tail @19-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record Search_Comments Item Class tail

'Record Search_Comments Data Provider Class @19-8382CACB
Public Class Search_CommentsDataProvider
Inherits RecordDataProviderBase
'End Record Search_Comments Data Provider Class

'Record Search_Comments Data Provider Class Variables @19-676727C1
    Protected s_monthsagoDataCommand As DataCommand=new SqlCommand("select -1*(MONTH(getdate())) as [value], 'Start of this year' as [display_text] where MONT" & _
          "H(getdate()) >= 6" & vbCrLf & _
          "union" & vbCrLf & _
          "select -3 as [value], '3 months ago' as [display_text] where MONTH(getdate()) >= 4" & vbCrLf & _
          "union" & vbCrLf & _
          "select -1 as [value], '1 month ago' as [display_text] where MONTH(getdate()) >= 2",Settings.connDECVPRODSQL2005DataAccessObject)
    Protected item As Search_CommentsItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record Search_Comments Data Provider Class Variables

'Record Search_Comments Data Provider Class GetResultSet Method @19-9F3D5484

    Public Sub FillItem(ByVal item As Search_CommentsItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record Search_Comments Data Provider Class GetResultSet Method

'Record Search_Comments BeforeBuildSelect @19-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record Search_Comments BeforeBuildSelect

'Record Search_Comments AfterExecuteSelect @19-83591636
        End If
            IsInsertMode = True
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record Search_Comments AfterExecuteSelect

'ListBox s_monthsago Initialize Data Source @23-1297D3D9
        s_monthsagoDataCommand.Dao._optimized = False
        Dim s_monthsagotableIndex As Integer = 0
        s_monthsagoDataCommand.OrderBy = ""
        s_monthsagoDataCommand.Parameters.Clear()
'End ListBox s_monthsago Initialize Data Source

'ListBox s_monthsago BeforeExecuteSelect @23-20533E46
        Try
            ListBoxSource=s_monthsagoDataCommand.Execute().Tables(s_monthsagotableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox s_monthsago BeforeExecuteSelect

'ListBox s_monthsago AfterExecuteSelect @23-332EC89F
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)(0))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)(1)
            item.s_monthsagoItems.Add(Key, Val)
        Next
'End ListBox s_monthsago AfterExecuteSelect

'Record Search_Comments AfterExecuteSelect tail @19-E31F8E2A
    End Sub
'End Record Search_Comments AfterExecuteSelect tail

'Record Search_Comments Data Provider Class @19-A61BA892
End Class

'End Record Search_Comments Data Provider Class

'Grid Grid_CommentsResults1 Item Class @38-02018C5E
Public Class Grid_CommentsResults1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Grid1_TotalRecords As TextField
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public COMMENT As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public COMMENT_TYPE As TextField
    Public Sub New()
    Grid1_TotalRecords = New TextField("", Nothing)
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    COMMENT = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("d MMM yyyy h\:mm tt", Nothing)
    COMMENT_TYPE = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "Grid1_TotalRecords"
                    Return Me.Grid1_TotalRecords
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "COMMENT"
                    Return Me.COMMENT
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "COMMENT_TYPE"
                    Return Me.COMMENT_TYPE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Grid1_TotalRecords"
                    Me.Grid1_TotalRecords = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "COMMENT"
                    Me.COMMENT = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "COMMENT_TYPE"
                    Me.COMMENT_TYPE = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid Grid_CommentsResults1 Item Class

'Grid Grid_CommentsResults1 Data Provider Class Header @38-CAC57E59
Public Class Grid_CommentsResults1DataProvider
Inherits GridDataProviderBase
'End Grid Grid_CommentsResults1 Data Provider Class Header

'Grid Grid_CommentsResults1 Data Provider Class Variables @38-3DAA73F1

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_COMMENT
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
        Sorter_COMMENT_TYPE
    End Enum

    Private SortFieldsNames As String() = New String() {"last_altered_date desc","STUDENT_ID","COMMENT","LAST_ALTERED_BY","LAST_ALTERED_DATE","COMMENT_TYPE"}
    Private SortFieldsNamesDesc As String() = New string() {"last_altered_date desc","STUDENT_ID DESC","COMMENT DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC","COMMENT_TYPE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public Urls_keywords  As TextParameter
    Public Urls_monthsago  As IntegerParameter
    Public Expr67  As TextParameter
'End Grid Grid_CommentsResults1 Data Provider Class Variables

'Grid Grid_CommentsResults1 Data Provider Class GetResultSet Method @38-10F8E038

    Public Sub New()
        Select_=new SqlCommand("SELECT top 200 *" & vbCrLf & _
          "FROM student_comment" & vbCrLf & _
          "WHERE CONTAINS(COMMENT, '""{s_keywords}*""')" & vbCrLf & _
          "and last_altered_date >= DATEADD(mm, {s_monthsago} ,getdate())" & vbCrLf & _
          "and LAST_ALTERED_BY = '{s_staffid}' {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT top 200 *" & vbCrLf & _
          "FROM student_comment" & vbCrLf & _
          "WHERE CONTAINS(COMMENT, '""{s_keywords}*""')" & vbCrLf & _
          "and last_altered_date >= DATEADD(mm, {s_monthsago} ,getdate())" & vbCrLf & _
          "and LAST_ALTERED_BY = '{s_staffid}') cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid Grid_CommentsResults1 Data Provider Class GetResultSet Method

'Grid Grid_CommentsResults1 Data Provider Class GetResultSet Method @38-432A24A7
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As Grid_CommentsResults1Item()
'End Grid Grid_CommentsResults1 Data Provider Class GetResultSet Method

'Grid Grid_CommentsResults1 Event BeforeBuildSelect. Action Custom Code @55-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End Grid Grid_CommentsResults1 Event BeforeBuildSelect. Action Custom Code

'Before build Select @38-33B2CDEB
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("s_keywords",Urls_keywords, "")
        CType(Select_,SqlCommand).AddParameter("s_monthsago",Urls_monthsago, "")
        CType(Select_,SqlCommand).AddParameter("s_staffid",Expr67, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @38-253899A0
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As Grid_CommentsResults1Item
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @38-C4B06200
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New Grid_CommentsResults1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @38-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @38-78EA8235
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as Grid_CommentsResults1Item = New Grid_CommentsResults1Item()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.STUDENT_IDHref = "Student_Comments_maintain.aspx"
                item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.COMMENT.SetValue(dr(i)("COMMENT"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.COMMENT_TYPE.SetValue(dr(i)("COMMENT_TYPE"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @38-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

