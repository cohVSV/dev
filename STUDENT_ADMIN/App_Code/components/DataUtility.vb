'DBUtility Class namespaces @0-89637269
Imports System
Imports System.Data
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Globalization
Imports System.IO
Imports System.Configuration
Imports System.Web
Imports System.Web.UI.WebControls
Imports DECV_PROD2007.Configuration
Imports DECV_PROD2007.Security

Namespace DECV_PROD2007.Data
'End DBUtility Class namespaces

'Common enumerations @2-40A87E16
Public Enum FieldType
_Integer
_Float
_Single
_Text
_Memo
_Boolean
_Date
End Enum

Public Enum ParameterType
_BigInt
_Bit
_Char
_Date
_DateTime
_Decimal
_Double
_Int
_TinyInt
_SmallInt
_NChar
_NText
_Numeric
_NVarChar
_Real
_SmallDateTime
_Text
_Time
_VarChar
_RecordSet
End Enum

Public Enum ConnectionStringType
_OleDb
_Sql
_Odbc
_Oracle
_ODP
_DB2
End Enum

Public Enum SortDirections
_Asc
_Desc
End Enum
'End Common enumerations

'IDataItem interface @2a-B3AF4BB8
Public Interface IDataItem
	Default Property Field(ByVal fieldName As String) As FieldBase
End Interface

'End IDataItem interface

'ItemCollection Class @3-043F21C6
Public Class ItemCollection
Inherits NameObjectCollectionBase
Implements ICloneable
    Public Structure ItemValue
        Public Sub New(ByVal text_ As String, ByVal selected_ As Boolean)
            Text = text_
            Selected = selected_
        End Sub

        Public Text As String
        Public Selected As Boolean
        Public Overloads Function ToString() As String
            Return Text
        End Function
    End Structure

    Public Sub Add(ByVal val As String, ByVal text_ As String, ByVal selected_ As Boolean)
        If IsNothing(BaseGet(val)) Then
            BaseAdd(val, New ItemValue(text_, selected_))
        End If
    End Sub

    Public Sub Add(ByVal val As Object, ByVal text_ As Object, ByVal selected_ As Boolean)
    
        if Not(val Is Nothing) Then
            If BaseGet(Convert.ToString(val)) Is Nothing Then BaseAdd(Convert.ToString(val),New ItemValue(Convert.ToString(text_),selected_))
        Else
            If BaseGet(Convert.ToString(val)) Is Nothing Then BaseAdd("",New ItemValue(Convert.ToString(text_),selected_))
        End If
    End Sub

    Public Sub Add(ByVal val_ As String, ByVal text_ As String)
        Add(val_, text_, False)
    End Sub

    Public Sub Add(ByVal val_ As Object, ByVal text_ As Object)
        Add(val_, text_, False)
    End Sub

    Public Sub SetSelection(ByVal val As Object)
        If Not IsNothing(val) Then
            If Not IsNothing(BaseGet(val.ToString())) Then
            Dim v As ItemValue = Me(val.ToString())
            v.Selected = True
            BaseSet(val.ToString(),v)
            End If
        End If
    End Sub

    Public Function GetSelectedItem() As Object
        Dim result As Object = Nothing
        Dim i As Integer = 0
        For i = 0 To Count - 1
            If Me(i).Selected Then
                result = Me(i):Exit For
            End If
        Next
        Return result
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Dim res As New ItemCollection()
        Dim i As Integer
        For i = 0 To Count - 1 
            res.BaseAdd(Me.Keys(i),Me(i))
        Next i
        Return res
    End Function

    Public Sub CopyTo(ByVal col As System.Web.UI.WebControls.ListItemCollection)
        CopyTo(col, False)
    End Sub

    Public Sub CopyTo(ByVal col As System.Web.UI.WebControls.ListItemCollection, encode As Boolean)
        Dim i As Integer
        For i = 0 To Count - 1 
            Dim item As System.Web.UI.WebControls.ListItem
            If encode Then
                item = New System.Web.UI.WebControls.ListItem(HttpContext.Current.Server.HtmlEncode(ItemVal(i).Text), Me.Keys(i))
            Else
                item = New System.Web.UI.WebControls.ListItem(ItemVal(i).Text, Me.Keys(i))
            End If
            item.Selected = ItemVal(i).Selected
            col.Add(item)
        Next i
    End Sub

    Public Sub CopyFrom(ByVal col As System.Web.UI.WebControls.ListItemCollection)
        Clear
        Dim i As Integer
        For i = 0 To col.Count - 1 
            Add(col(i).Value, col(i).Text, col(i).Selected)
        Next i
    End Sub

    Public Sub Remove(ByVal val As String)
        BaseRemove(val)
    End Sub

    Public Sub RemoveAt(ByVal index As Integer)
        BaseRemoveAt(index)
    End Sub

    Public Sub Clear()
        BaseClear()
    End Sub

    Default Public ReadOnly Property ItemVal(ByVal val As String) As ItemValue
        Get
            Return CType(BaseGet(val), ItemValue)
        End Get
    End Property

    Default Public ReadOnly Property ItemVal(ByVal index As Integer) As ItemValue
        get
            Return CType(BaseGet(index), ItemValue)
        End Get
    End Property
End Class

'End ItemCollection Class

'LinkParameterCollection Class @3-8576FA37
Public Class LinkParameterCollection
Inherits NameObjectCollectionBase
    Protected Sub AddUnique(name As String,value As String)
        If BaseGet(name) Is Nothing Then BaseAdd(name,value)
    End Sub
    Public Sub Add(ByVal name As String, ByVal value As String)
        Call BaseAdd(name,value)
    End Sub
    Public Sub Add(name As String, values As NameValueCollection, keyName As string)
        Dim val As String
        If Not values(keyName) Is Nothing Then
            For Each val In values.GetValues(keyName)
                BaseAdd(name,System.Web.HttpUtility.UrlEncode(val))
            Next
        Else
            BaseAdd(name,"")
        End If
    End Sub

    Public Overloads Function ToString(ByVal sPreserve As String, ByVal sRemoveList As String) As String
        Return ToString(sPreserve , sRemoveList, Nothing)
    End Function

    Public Overloads Function ToString(ByVal sPreserve As String, ByVal sRemoveList As String, viewState As System.Web.UI.StateBag) As String
        Dim i As Integer
        Dim Request As HttpRequest = HttpContext.Current.Request
        Dim Server As HttpServerUtility = HttpContext.Current.Server
        Dim List As String()
        Dim val As String
        If sRemoveList = "" Then
            List = New String() {""}
        Else
            List = sRemoveList.Split(New Char() {";"C})
        End If
        If sPreserve = "All" Or sPreserve = "GET" Then
            If Not IsNothing(viewState) Then
                Dim upperBound As Integer = viewState.Count
                Dim keys(upperBound) As String
                Dim values(upperBound) As System.Web.UI.StateItem
                viewState.Keys.CopyTo(keys, 0)
                viewState.Values.CopyTo(values, 0)
                Dim cvalue As String = ""
                For i = 0 To upperBound - 1
                    If Not values(i).Value Is Nothing Then
                        cvalue = values(i).Value.ToString()
                    Else
                        cvalue = ""
                    End If
                    Dim ckey As String = ""
                    If keys(i).EndsWith("SortField") AndAlso cvalue <> "_Default" Then 
                        ckey = keys(i).Replace("SortField","Order")
                    End If
                    If keys(i).EndsWith("SortDir") Then
                        ckey = keys(i).Replace("SortDir","Dir")
                        cvalue = cvalue.TrimStart("_"C)
                    End If
                    If keys(i).EndsWith("PageSize") Then
                        ckey = keys(i)
                    End If
                    If keys(i).EndsWith("PageNumber") Then
                        ckey = keys(i).Replace("PageNumber","Page")
                        If values(i).Value.ToString() = "1" And IsNothing(Request.QueryString(ckey)) Then
                            ckey=""
                        End If
                    End If
                    If ckey <> "" AndAlso Array.IndexOf(List,ckey) < 0 Then
                        If IsNothing(Me(ckey)) Then Add(ckey,cvalue) Else Me(ckey) = cvalue
                    End If
                Next
            End If
        For i = 0 To Request.QueryString.Count - 1
            If Array.IndexOf(List,Request.QueryString.AllKeys(i)) < 0 And BaseGet(Request.QueryString.AllKeys(i)) Is Nothing And Request.QueryString.AllKeys(i) <> "FormFilter" Then
                For Each val In Request.QueryString.GetValues(i)
                    Add(Server.UrlEncode(Request.QueryString.AllKeys(i)),Server.UrlEncode(val))
                Next
            End If
        Next i
        End If
        If sPreserve = "All" Or sPreserve = "POST" Then
            For i = 0 To Request.Form.Count - 1
                If Array.IndexOf(List,Request.Form.AllKeys(i)) < 0 _
                    And Request.Form.AllKeys(i) <> "__EVENTTARGET" _
                    And Request.Form.AllKeys(i) <> "__EVENTARGUMENT" _
                    And Request.Form.AllKeys(i) <> "__VIEWSTATE" _
                    And BaseGet(Request.Form.AllKeys(i)) Is Nothing Then
                    For Each val In Request.Form.GetValues(i)
                        Add(Request.Form.AllKeys(i),Server.UrlEncode(val))
                    Next
                End If
            Next i
        End If
        Return ToString("")
    End Function

    Public Overloads Function ToString() As String
        Return ToString("")
    End Function

    Public Overloads Function ToString(ByVal RemoveList As String) As String
        Dim i As Integer
        Dim Params As String = ""
        Dim List As String()
        If RemoveList = "" Then
            List = New String() {""}
        Else
            List = RemoveList.Split(New Char() {";"C})
        End If
        For i = 0 To Count - 1
            If Array.IndexOf(List,BaseGetKey(i)) < 0 Then
                If Not IsNothing(BaseGet(i)) Then Params = Params & BaseGetKey(i) & "=" & Convert.ToString(BaseGet(i)) & "&"
            End If
        Next i
        Params = Params.TrimEnd(New Char() {"&"C})
        If Params.Length > 0 Then Params = "?" + Params
        Return Params
    End Function

    Default Public Property Item(ByVal val As String) As Object
        Get
            Return BaseGet(val)
        End Get
        Set
            BaseSet(val, Value)
        End Set
    End Property

    Default Public Property Item(ByVal index As Integer) As Object
        Get
            Return BaseGet(index)
        End Get
        Set
            BaseSet(index, Value)
        End Set
    End Property

End Class
'End LinkParameterCollection Class

'Connection String Class @4-9B9CF5FA
Public Enum TopRecordsPlace
beforeFrom
afterQuery
addToWhere
None
End Enum
Public NotInheritable Class ConnectionString
    Public Sub New(ByVal Connection As String, ByVal Type As ConnectionStringType)
        Me.Connection = Connection
        Me.Type = Type
    End Sub

    Public Sub New(ByVal Connection As String, ByVal Type As ConnectionStringType,ByVal DateFormat As String,ByVal BoolFormat As String,ByVal DateLeftDelim As String, ByVal DateRightDelim As String, ByVal server As String, ByVal optimized As Boolean)
    Me.Optimized = optimized
    Me.Server = server
    Me.Connection = Connection
    Me.Type = Type 
    Me.DateFormat = DateFormat
    Me.BoolFormat = BoolFormat
    Me.DateLeftDelim = DateLeftDelim
    Me.DateRightDelim = DateRightDelim
    End Sub

    Public Sub New()
    End Sub

    Public Server As String
    Public Optimized As Boolean
    Public Connection As String
    Public Type As ConnectionStringType
    Public ConnectionCommands As New NameValueCollection
    Public DateFormat As String = ""
    Public BoolFormat As String = ""
    Public DateLeftDelim As String = ""
    Public DateRightDelim As String = ""
    Public TopRecordsPlace As TopRecordsPlace = TopRecordsPlace.None
    Public TopRecordsClause As String
End Class
'End Connection String Class

'DBUtility Class @5-39C60F2A
Public Class DBUtility
    Public Shared IsGroupsNested As Boolean = False
'End DBUtility Class

'Authorize user method @6-EF61A181
    Public Shared Function AuthorizeUser(ByVal Groups As String()) As Boolean
        Dim i As Integer
        If IsNothing(HttpContext.Current.Session("UserID")) Then Return False
        If Groups.Length = 0 Then Return False
        Dim GroupId As String = HttpContext.Current.Session("GroupID").ToString()
        For i = 0 To Groups.Length - 1
            If Groups(i) = GroupId Then Return True
        Next i
        Return False
    End Function
'End Authorize user method

'User ID Property @6-1242955D
    Public Shared Property UserId As Object
        Get
            Return HttpContext.Current.Session("UserID")
        End Get
        Set
            HttpContext.Current.Session("UserID") = value
        End Set
    End Property
'End User ID Property

'User login property @6-EAF209DE
    Public Shared Property UserLogin As String
        Get
            Return Convert.ToString(HttpContext.Current.Session("UserLogin"))
        End Get
        Set
            HttpContext.Current.Session("UserLogin") = value
        End Set
    End Property
'End User login property

'User Group property @6-E81AE893
    Public Shared Property UserGroup As String
        Get
            Return CType(HttpContext.Current.Session("GroupID"), String)
        End Get
        Set
            HttpContext.Current.Session("GroupID") = value
        End Set
    End Property
'End User Group property

'AuthorizeUser method @6-E31A66E8
    Public Shared Function AuthorizeUser() As Boolean
        If IsNothing(HttpContext.Current.Session("UserID")) Then Return False
        Return True
    End Function
'End AuthorizeUser method

'Check user method @6-2AEF81EA
    Public Shared Function CheckUser(ByVal UserName As String,ByVal UserPassword As String) As Boolean
        Dim dao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
        Dim password As String = ""
        If ConfigurationManager.AppSettings("ProtectPasswordsMethod") = "DBFunction" Then
            password = ConfigurationManager.AppSettings("ProtectPasswordsExpression").Replace("{password}", dao.ToSql(userPassword,FieldType._Text))
        ElseIf ConfigurationManager.AppSettings("ProtectPasswordsMethod") = "CodeExpression" Then
            password = dao.ToSql(SecurityUtility.MD5(userPassword),FieldType._Text)
        Else
            password = dao.ToSql(userPassword, FieldType._Text)
        End If
        Dim Sql As String = "SELECT STAFF_ID, GROUP_ID FROM STAFF WHERE STAFF_ID=" & dao.ToSql(UserName,FieldType._Text) & " AND PASSWORD_EXTENDED=" & password

        Dim ds As DataSet = dao.RunSql(Sql)
        If ds.Tables(0).Rows.Count > 0 Then
            HttpContext.Current.Session("UserID") = ds.Tables(0).Rows(0)("STAFF_ID")
            HttpContext.Current.Session("GroupID") = ds.Tables(0).Rows(0)("GROUP_ID").ToString()
            HttpContext.Current.Session("UserLogin") = UserName
            Return True
        End If
        Return False
    End Function
'End Check user method

'Get CCS format @6-319D1F33
    Public Shared Function GetCCSFormat(format As String) As String
        Select format
            Case "D"
                Return "LongDate"
            Case "G"
                Return "GeneralDate"
            Case "d"
                Return "ShortDate"
            Case "T"
                Return "LongTime"
            Case "t"
                Return "ShortTime"
        End Select

        format = format.Replace("m", "n")
        format = format.Replace("M", "m")
        format = format.Replace("tt","AM/PM")
        format = format.Replace("t", "M/P")
        format = format.Replace("\/", "/")
        format = format.Replace("\:", ":")

        return format
    End Function
'End Get CCS format

'InitializeGridParameters @6-B757C821
    Public Shared Sub InitializeGridParameters(viewState As System.Web.UI.StateBag, formName As String, sortFields As Type, pageSize As Integer, pageSizeLimit As Integer)
        Dim Request As HttpRequest = HttpContext.Current.Request
        Dim Param As String
        Dim _pageSize As Integer = pageSize
        viewState((formName + "SortField")) = [Enum].Parse(sortFields, "_Default")
        viewState((formName + "PageNumber")) = 1
        Param = Request.QueryString((formName + "Order"))
        If Not (Param Is Nothing) AndAlso Param.Length > 0 Then
            Try
                viewState((formName + "SortField")) = [Enum].Parse(sortFields, Param)
            Catch
            End Try
        End If
        Param = Request.QueryString((formName + "Dir"))
        If Param Is Nothing OrElse Param.Length = 0 OrElse Param.ToLower() = "asc" Then
            viewState((formName + "SortDir")) = SortDirections._Asc
        Else
            viewState((formName + "SortDir")) = SortDirections._Desc
        End If
        Param = Request.QueryString((formName + "Page"))
        Dim PageNumber As Integer
        If Not (Param Is Nothing) AndAlso Param.Length > 0 Then
            Try
                PageNumber = Int32.Parse(Param)
                If PageNumber >= 0 Then viewState((formName + "PageNumber")) = PageNumber
            Catch
            End Try
        End If
        Param = Request.QueryString((formName + "PageSize"))
        If Not (Param Is Nothing) AndAlso Param.Length > 0 Then
            Try
                _pageSize = Int32.Parse(Param)
                If _pageSize <= 0 Then	_pageSize = pageSize
            Catch
            End Try
        End If
        If (_pageSize > pageSizeLimit Or _pageSize = 0) And pageSizeLimit <> - 1 Then
            _pageSize = pageSizeLimit
        End If
        viewState((formName + "PageSize")) = _pageSize
    End Sub 'InitializeGridParameters
'End InitializeGridParameters

'ParseBool @6-A4013374
    Public Shared Function ParseBool(ByVal Value As String, ByVal Format As String) As Boolean
        Dim chDelim As Char() = {";"C}
        Try
        If IsNothing(Format) OrElse Format.Length = 0 Then Format =  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).BooleanFormat
        If IsNothing(Format) OrElse Format.Length = 0 Then Return Boolean.Parse(Value)
        Dim Tokens As String() = Format.Split(chDelim)
        If Value = Tokens(0) Then Return True
        If Value = Tokens(1) Then Return False
        Catch e As Exception
            Throw New Exception("Unable to parse Boolean:" & e.Message)
        End Try
        Return False
    End Function
'End ParseBool

'FormatBool @6-E2F9559C
    Public Shared Function FormatBool(ByVal Value As Object, ByVal Format As String) As String
        Dim chDelim As Char() = {";"C}
        Try
        If IsNothing(Format) OrElse Format.Length = 0 Then Format =  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).BooleanFormat
        If (IsNothing(Format) OrElse Format.Length = 0) AndAlso Not IsNothing(Value) Then
            Return Value.ToString()
        Else
            If (IsNothing(Format) OrElse Format.Length = 0) AndAlso IsNothing(Value) Then Return ""
        End If
        Dim Tokens As String() = Format.Split(chDelim)
        If (IsNothing(Value) Or TypeOf Value Is DBNull) And Tokens.Length > 2 Then Return Tokens(2)
        If IsNothing(Value) Or TypeOf Value Is DBNull Then Return ""
        If CType(Value, Boolean) Then Return Tokens(0)
        If Not CType(Value, Boolean) Then Return Tokens(1)
        Catch e As Exception
            Throw New Exception("Unable to format Boolean:" & e.Message)
        End Try
        Return ""
    End Function
'End FormatBool

'ParseInt @6-BA72DDB3
    Public Shared Function ParseInt(ByVal Value As String, ByVal Format As String) As Int64
        Dim chDelim As Char() = {";"C}
        Try
        Dim nfi As NumberFormatInfo = CType(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.Clone(), System.Globalization.NumberFormatInfo)
        If IsNothing(Format) OrElse Format.Length = 0 Then Return Int64.Parse(Value, NumberStyles.Integer Or NumberStyles.AllowThousands Or NumberStyles.AllowCurrencySymbol, nfi)
        Dim Tokens As String() = Format.Split(chDelim)
        If Tokens.Length > 4 Then
            If Tokens(4).Length > 0 Then
                nfi.NumberDecimalSeparator = Tokens(4)
                nfi.PercentDecimalSeparator = Tokens(4)
            End If
        End If
        If Tokens.Length > 5 Then
            If Tokens(5).Length > 0 Then
                nfi.NumberGroupSeparator = Tokens(5)
                nfi.PercentGroupSeparator = Tokens(5)
            End If
        End If
        Return Int64.Parse(Value, NumberStyles.Integer Or NumberStyles.AllowThousands Or NumberStyles.AllowCurrencySymbol, nfi)
        Catch e As Exception
            Throw New Exception("Unable to parse Integer:" & e.Message)
        End Try
    End Function
'End ParseInt

'ParseDouble @6-4E18953D
    Public Shared Function ParseDouble(ByVal Value As String, ByVal Format As String) As Double
        Dim chDelim As Char() = {";"C}
        Try
        Dim nfi As NumberFormatInfo = CType(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.Clone(), System.Globalization.NumberFormatInfo)
        If IsNothing(Format) OrElse Format.Length = 0 Then Return Double.Parse(Value, NumberStyles.Any, nfi)
        Dim Tokens As String() = Format.Split(chDelim)
        If Tokens.Length > 4 Then
            If Tokens(4).Length > 0 Then
                nfi.NumberDecimalSeparator = Tokens(4)
                nfi.PercentDecimalSeparator = Tokens(4)
            End If
        End If
        If Tokens.Length > 5 Then
            If Tokens(5).Length > 0 Then
                nfi.NumberGroupSeparator = Tokens(5)
                nfi.PercentGroupSeparator = Tokens(5)
            End If
        End If
        Return Double.Parse(Value,NumberStyles.Any,nfi)
        Catch e As Exception
            Throw New Exception("Unable to parse Float:" & e.Message)
        End Try
    End Function
'End ParseDouble

'ParseSingle @6-763DE5EA
    Public Shared Function ParseSingle(ByVal Value As String, ByVal Format As String) As Single
        Dim chDelim As Char() = {";"C}
        Try
        If IsNothing(Format) Then Return Single.Parse(Value)
        If Format.Length = 0 Then Return Single.Parse(Value)
        Dim nfi As NumberFormatInfo = CType(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.Clone(),System.Globalization.NumberFormatInfo)
        Dim Tokens As String() = Format.Split(chDelim)
        If Tokens.Length > 4 Then
            If Tokens(4).Length > 0 Then
                nfi.NumberDecimalSeparator = Tokens(4)
                nfi.PercentDecimalSeparator = Tokens(4)
            End If
        End If
        If Tokens.Length > 5 Then
            If Tokens(5).Length > 0 Then
                nfi.NumberGroupSeparator = Tokens(5)
                nfi.PercentGroupSeparator = Tokens(5)
            End If
        End If
        Return Single.Parse(Value,NumberStyles.Any,nfi)
        Catch e As Exception
            Throw New Exception("Unable to parse Float:" & e.Message)
        End Try
    End Function
'End ParseSingle

'ParseDate @6-9B65FF57
        Public Shared Function ParseDate(ByVal value As String, ByVal format As String) As DateTime
	 
        Try
            If format Is Nothing Or format.Length = 0 Then
                Return DateTime.Parse(value)
            End If
            Return DateTime.ParseExact(value, format, CultureInfo.CurrentCulture.DateTimeFormat)
        Catch e As Exception
            Throw New Exception("Unable to parse DateTime:" & e.Message)
        End Try
    End Function
'End ParseDate

'FormatNumber @6-6DC359B5
    Public Shared Function FormatNumber(ByVal Value As Object, ByVal Format As String) As String
        Dim chDelim As Char() = {";"C}
        Try
        If IsNothing(Format) Then Return Value.ToString()
        If Format.Length = 0 Then Return Value.ToString()
        Dim nfi As NumberFormatInfo = CType(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.Clone(),System.Globalization.NumberFormatInfo)
        Dim Tokens As String() = Format.Split(chDelim)
        If Tokens.Length > 4 Then
            If Tokens(4).Length > 0 Then
                nfi.NumberDecimalSeparator = Tokens(4)
                nfi.PercentDecimalSeparator = Tokens(4)
            End If
        End If
        If Tokens.Length > 5 Then
            If Tokens(5).Length > 0 Then
                nfi.NumberGroupSeparator = Tokens(5)
                nfi.PercentGroupSeparator = Tokens(5)
            End If
        End If
        If (IsNothing(Value) Or TypeOf Value Is DBNull) And Tokens.Length > 3 Then Return Tokens(3)
        If IsNothing(Value) Or TypeOf Value Is DBNull Then Return "Nothing"
        Dim format_ As String = ""
        If Tokens.Length > 0 Then format_ = format_ & Tokens(0) & ";"
        If Tokens.Length > 1 Then format_ = format_ & Tokens(1) & ";"
        If Tokens.Length > 2 Then format_ = format_ & Tokens(2) & ";"
        If TypeOf Value Is Integer Then Return CType(Value, Integer).ToString(format_,nfi)
        If TypeOf Value Is Int64 Then Return CType(Value,Int64).ToString(format_,nfi)
        If TypeOf Value Is Double Then Return CType(Value,Double).ToString(format_,nfi)
        If TypeOf Value Is Single Then Return CType(Value,Single).ToString(format_,nfi)
        If TypeOf Value Is Decimal Then Return CType(Value,Decimal).ToString(format_,nfi)
        Catch e As Exception
            Throw New Exception("Unable to format Number:" & e.Message)
        End Try
        Return ""
    End Function
'End FormatNumber

'GetInitialValue @6-22946234
    Public Shared Function GetInitialValue(ByVal Name_ As String, ByVal Default_ As Object) As Object
        Dim Value As String = Nothing
        If Not IsNothing(HttpContext.Current.Request.QueryString(Name_)) Then
            Value = HttpContext.Current.Request.QueryString.GetValues(Name_)(0)
        Else
            If Not IsNothing(HttpContext.Current.Request.Form(Name_)) Then
                Value = HttpContext.Current.Request.Form.GetValues(Name_)(0)
            End If
        End If

        If IsNothing(Value) Then
            Return Default_
        Else
            Return Value
        End If
    End Function

    Public Shared Function GetInitialValue(ByVal Name_ As String) As Object
        Return GetInitialValue(Name_, Nothing)
    End Function
'End GetInitialValue

'GetValue @6-2CC207F0
    Public Shared Function GetValue(ByVal Name_ As String, ByVal Default_ As Object) As Object
        Dim Value As String = Nothing
        If Not IsNothing(HttpContext.Current.Request.QueryString(Name_)) Then
            Value = HttpContext.Current.Request.QueryString.GetValues(Name_)(0)
        Else
            If Not IsNothing(HttpContext.Current.Request.Form(Name_)) Then
                Value = HttpContext.Current.Request.Form.GetValues(Name_)(0)
            End If
        End If

        If IsNothing(Value) Then
            Return Default_
        Else
            Return Value
        End If
    End Function
'End GetValue

'ManageAdvancedSearch @6-39117CDC
    Public Shared Sub ManageAdvancedSearch(ByRef selectCommand As DataCommand, fields As String(), searchCondition As String, keyword As String)
        If IsNothing(searchCondition) Or IsNothing(keyword) Then Return
        Dim wt As ArrayList = New ArrayList(CType(selectCommand,TableCommand).WhereTemplate)
        Dim notEmptyWhere As Boolean = wt.Count <> 0
        Dim isMultipleFields As Boolean = fields.Length > 1
        Dim keywords As String() = { }
        Dim op As String = ""
        Select Case searchCondition
            case "1":
                op = "Or"
                keywords = keyword.Trim().Split(New char() { " "c }, StringSplitOptions.RemoveEmptyEntries)
            case "2":
                op = "And"
                keywords = keyword.Trim().Split(new char() { " "c }, StringSplitOptions.RemoveEmptyEntries)
            case "3":
                keywords = new String() { keyword }
            Case Else:
                Return
        End Select
        If notEmptyWhere Then
            wt.Add("And")
            wt.Add("(")
        End If
        For i As Integer = 0 To fields.Length - 1
            If (isMultipleFields) Then wt.Add("(")
            For j As Integer = 0 To keywords.Length - 1
                wt.Add(keywords(j) + i.ToString() + j.ToString())
                wt.Add(op)
                CType(selectCommand, TableCommand).AddParameter(keywords(j) + i.ToString() + j.ToString(), New TextField("", keywords(j)), "", fields(i), Condition.Contains, False)
            Next j
            wt.RemoveAt(wt.Count - 1)
            If isMultipleFields Then wt.Add(")")
            wt.Add("Or")
        Next i
        wt.RemoveAt(wt.Count - 1)
        If notEmptyWhere Then wt.Add(")")
        CType(selectCommand, TableCommand).WhereTemplate = CType(Array.CreateInstance(Type.GetType("System.String"), wt.Count), String())
        wt.CopyTo(CType(selectCommand, TableCommand).WhereTemplate)
    End Sub
'End ManageAdvancedSearch

'DBUtility Class tail @6-DD082417
End Class
End Namespace
'End DBUtility Class tail

