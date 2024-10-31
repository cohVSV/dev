'Report Control @0-EB09039D
'Target Framework version is 3.5
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Web
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Configuration
Namespace DECV_PROD2007.Controls

<ParseChildren(True)>  _
Public Class ReportSection
   Inherits Control
   Implements INamingContainer 
   Private itemIndex As Integer
   Private _name As String = ""
   Private _height As Single = 1
   Private _template As ITemplate
   
   
   Public Sub New(itemIndex As Integer)
      Me.itemIndex = itemIndex
   End Sub 'New
   
   Public Sub New()
      Me.itemIndex = 0
   End Sub 
   
   <PersistenceMode(PersistenceMode.Attribute)>  _
   Public Property name() As String
      Get
         Return _name
      End Get
      Set
         _name = value
      End Set
   End Property
   
   <PersistenceMode(PersistenceMode.Attribute)>  _
   Public Property Height() As Single
      Get
         Return _height
      End Get
      Set
         _height = value
      End Set
   End Property
   
   <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(ReportSectionBody))>  _
   Public Property Template() As ITemplate
      Get
         Return _template
      End Get
      Set
         _template = value
      End Set
   End Property
End Class 

Public Class ReportSectionBody
   Inherits Control
   Implements INamingContainer 
   Private _name As String = ""
   Private _height As Single = 1
   Private _dataItem As IDataItem
   
   
   Public Property name() As String
      Get
         Return _name
      End Get
      Set
         _name = value
      End Set
   End Property
   
   Public Property Height() As Single
      Get
         Return _height
      End Get
      Set
         _height = value
      End Set
   End Property
   
   Public Property DataItem() As IDataItem
      Get
         Return _dataItem
      End Get
      Set
         _dataItem = value
      End Set
   End Property
End Class 
 

Public Class BeforeItemDataBoundEventArgs
   Inherits EventArgs
   Public DataItem As IDataItem
   
   Public Sub New(data As IDataItem)
      Me.DataItem = data
   End Sub 'New
End Class 
 

Public Class BeforeShowSectionEventArgs
   Inherits EventArgs
   Public Item As ReportSectionBody
   
   Public Sub New(item As ReportSectionBody)
      Me.Item = item
   End Sub 'New
End Class 
 

Public Class OnCalculateEventArgs
   Inherits EventArgs
   Public DataItem As IDataItem
   Public SectionName As String
   Public Item As ReportSectionBody
   Public TotalValues As Hashtable
   
   Public Sub New(data As IDataItem, sectionName As String, item As ReportSectionBody, totalValues As Hashtable)
      Me.DataItem = data
      Me.SectionName = sectionName
      Me.Item = item
	  Me.TotalValues = totalValues
   End Sub 'New
End Class 'OnCalculateEventArgs


Public Delegate Sub BeforeItemDataBoundHandler(sender As Object, e As BeforeItemDataBoundEventArgs)

Public Delegate Sub OnCalculateHandler(sender As Object, e As OnCalculateEventArgs)

Public Delegate Sub BeforeShowSectionHandler(sender As Object, e As BeforeShowSectionEventArgs)
 

Public Enum ReportViewMode
   Print
   Web
End Enum 

<PersistChildren(True)>  _ 
Public Class Report
   Inherits WebControl
   Implements INamingContainer 
   Private _dataSource() As IDataItem
   Private _layoutheader As ITemplate
   Private _layoutfooter As ITemplate
   Private _groups As New NameValueCollection()
   Private _values As New NameValueCollection()
   Private sections As New ArrayList()
   Private navigators As New ArrayList()
   Private specialValues As New ArrayList()
   Private _controls As New ArrayList()
   Private groupsdata As New Hashtable()
   Private isPageCreated As Boolean = False

   Private _viewMode As ReportViewMode = ReportViewMode.Web
   Private _pageSize As Single = 0
   Private _webPageSize As Single = 0
   Private currPageSize As Single = 0
   Private _pageSizeLimit As Single = 0
   Private _currentPageNumber As Integer = 0 
   Private _totalPages As Integer = 0 
   Private _rowNumber As Integer = 0 
    
   
   Public Class TotalValue
      Private firstS As Single
      Public second As Integer
      Private firstD As Double
      Public isDouble As Boolean
	  Private isInitialized As Boolean = False
      Public [source] As String = ""
      Public sourceType As ReportLabelSourceType = ReportLabelSourceType.DBColumn
      Public [function] As TotalFunction = TotalFunction.None
      Public resetAt As String = "Report"
      Public percentOf As String = ""
      Public percentOfService As Boolean = False
      
      
      Public Sub New(func As TotalFunction, isDouble As Boolean)
         [function] = func
         Reset()
         Me.isDouble = isDouble
      End Sub 
      
      
      Public Property Value() As Object
         Get
            If isDouble Then
               Return firstD
            Else
               Return firstS
            End If
         End Get
         Set
            If isDouble Then
               firstD = Convert.ToDouble(value)
            Else
               firstS = Convert.ToSingle(value)
            End If
         End Set
      End Property
      
      Public Function Average() As Object
         If isDouble Then
            Return firstD / second
         Else
            Return firstS / second
         End If
      End Function 
       
      Public Sub AddFirst(val As Object)
         If isDouble Then
			If Not IsInitialized And Not val Is Nothing Then
				IsInitialized = True
				firstD = 0
			End if
            firstD += Convert.ToDouble(val)
         Else
			If Not IsInitialized And Not val Is Nothing Then
				IsInitialized = True
				firstS = 0
			End if
			firstS += Convert.ToSingle(val)
         End If
      End Sub 
       
      Public Sub SetMin(val As Object)
         If isDouble Then
            firstD =CDbl(Iif(Convert.ToDouble(val) < firstD Or Double.IsNaN(firstD),Convert.ToDouble(val),firstD))
         Else
            firstS =CSng(Iif(Convert.ToSingle(val) < firstS Or Single.IsNaN(firstS),Convert.ToSingle(val),firstS))
         End If
      End Sub 
       
      
      Public Sub SetMax(val As Object)
         If isDouble Then
            firstD =CDbl(Iif(Convert.ToDouble(val) > firstD Or Double.IsNaN(firstD),Convert.ToDouble(val),firstD))
         Else
            firstS =CSng(Iif(Convert.ToSingle(val) > firstS Or Single.IsNaN(firstS),Convert.ToSingle(val),firstS))
         End If
      End Sub 
       
      Public Function GetPercent(val As Object) As Object
         If isDouble Then
			If val Is Nothing Or firstD = 0 Then Return Double.NaN
            Return CDbl(val) / firstD *CDbl(Iif([function] = TotalFunction.Avg, second, 1))
         Else
			If val Is Nothing Or firstS = 0 Then Return Single.NaN
			Return CSng(val) / firstS *CSng(Iif([function] = TotalFunction.Avg, second, 1))
         End If 
      End Function 
      
      
      Public Sub Reset()
		 isInitialized = False
         If [function] = TotalFunction.Min Or [function] = TotalFunction.Max Or [function] = TotalFunction.Sum Then
            Me.firstS = Single.NaN
            Me.firstD = Double.NaN
            Me.second = 0
         Else
            Me.firstS = 0
            Me.firstD = 0
            Me.second = 0
         End If
      End Sub 'Reset
   End Class 
   
   Public Event BeforeItemDataBound As BeforeItemDataBoundHandler
   Public Event OnCalculate As OnCalculateHandler
   Public Event ItemCommand As RepeaterCommandEventHandler
   Public Event BeforeShowSection As BeforeShowSectionHandler
   
   Private calculationTable As New Hashtable()
   Private percentValues As New Hashtable()
   Private headersLinks As New Hashtable()
   Private templates As New Hashtable()
   Private minPageSize As Single = 0
   Private maxSectionSize As Single = 0
   
   Public Overridable ReadOnly Property PageNumber() As Integer
      Get
         Return _currentPageNumber
      End Get
   End Property
   
   
   Public Overridable Property PreviewPageNumber() As Integer
      Get
         If Not (ViewState("_pageNumber") Is Nothing) Then
            Return CType(ViewState("_pageNumber"), Integer)
         Else
            Return 1
         End If
      End Get
      Set
         ViewState("_pageNumber") = value
      End Set
   End Property
   
   
   Public Overridable ReadOnly Property TotalPages() As Integer
      Get
         Return _totalPages
      End Get
   End Property

	Private _TotalRecords As Integer
   Public Overridable ReadOnly Property TotalRecords() As Integer
      Get
         Return _TotalRecords
      End Get
   End Property

   
   Public Overridable ReadOnly Property RowNumber() As Integer
      Get
         Return _rowNumber
      End Get
   End Property
   
   
   Public Overridable Property PageSize() As Single
      Get
         Return _pageSize
      End Get
      Set
         _pageSize = value
      End Set
   End Property
   
   
   Public Overridable Property WebPageSize() As Single
      Get
         Return _webPageSize
      End Get
      Set
         _webPageSize = value
      End Set
   End Property

   Public Overridable Property PageSizeLimit() As Single
      Get
         Return _pageSizeLimit
      End Get
      Set
         _pageSizeLimit = value
      End Set
   End Property


	Public Property UseClientPaging() As Boolean
	   Get
		  If Not (ViewState("_ucp") Is Nothing) Then
			 Return CInt(ViewState("_ucp")) = 1
		  Else
			 Return False
		  End If
	   End Get
	   Set
		  If Value Then ViewState("_ucp") = 1
	   End Set
	End Property
   
   Public Overridable Property ViewMode() As ReportViewMode
      Get
         Return _viewMode
      End Get
      Set
         _viewMode = value
      End Set
   End Property
   
   
   Private ReadOnly Property ActivePageSize() As Single
      Get
         If ViewMode = ReportViewMode.Print Then
            Return PageSize
         Else
            Return WebPageSize
         End If
      End Get
   End Property
   
   <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(ReportSectionBody))>  _
   Public Overridable Property Section() As ReportSection
      Get
         Return Nothing
      End Get
      Set
         Dim section As New ReportSection()
         value.Template.InstantiateIn(section)
         If value.Visible And(value.name = "Page_Header" Or value.name = "Page_Footer") Then
            minPageSize += value.Height
         Else
            If value.Visible Then
               If value.Height > maxSectionSize Then
                  maxSectionSize = value.Height
               End If
            End If
         End If
         PopulateCalculationTable(section.Controls, value.name)
         templates.Add(value.name, value)
      End Set
   End Property
   
   <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(ReportSectionBody))>  _
   Public Overridable Property LayoutHeaderTemplate() As ITemplate
      Get
         Return _layoutheader
      End Get
      Set
         _layoutheader = value
      End Set
   End Property
   
   <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(ReportSectionBody))>  _   
   Public Overridable Property LayoutFooterTemplate() As ITemplate
      Get
         Return _layoutfooter
      End Get
      Set
         _layoutfooter = value
      End Set
   End Property
   
   Public Overridable Property DataSource() As IDataItem()
      Get
         Return _dataSource
      End Get
      Set
         _dataSource = value
      End Set
   End Property
   
   
   Public Overridable ReadOnly Property Groups() As NameValueCollection
      Get
         Return _groups
      End Get
   End Property
    
   
   Protected Overrides Function OnBubbleEvent(sender As Object, e As EventArgs) As Boolean '
      RaiseEvent ItemCommand(Me, New RepeaterCommandEventArgs(Nothing, sender, CType(e, CommandEventArgs)))
      Return true
   End Function
   
   
   Protected Sub BindReportLabel(rl As ReportLabel, data As Object)
      Select Case rl.DataType
         Case FieldType._Float, FieldType._Single, FieldType._Integer
			If Not Double.IsNaN(Convert.ToDouble(data)) Then
				rl.Text = DBUtility.FormatNumber(data, rl.Format)
			End If
         Case FieldType._Boolean
            If rl.Format = "" Then
               rl.Format = Settings.BoolFormat
            End If
            rl.Text = DBUtility.FormatBool(data, rl.Format)
         Case FieldType._Date
            If rl.Format = "" Then
               rl.Format = Settings.DateFormat
            End If
            rl.Text = CType(data, DateTime).ToString(rl.Format)
         Case Else
            rl.Text = data.ToString()
      End Select
   End Sub
   
   Protected Sub PopulateCalculationTable(col As ControlCollection, sectionName As String)
      Dim control As Control
      For Each control In  col
         If control.Controls.Count > 0 Then
            PopulateCalculationTable(control.Controls, sectionName)
         End If
         If TypeOf control Is ReportLabel Then
            Dim rl As ReportLabel = CType(control, ReportLabel)
            If rl.[function] <> TotalFunction.None Then
               Dim val As New TotalValue(rl.[function], rl.DataType = FieldType._Float)
               val.source = rl.Source
               val.sourceType = rl.SourceType
               val.resetAt = rl.ResetAt
               val.percentOf = rl.PercentOf
               calculationTable.Add(rl.ID, val)
            End If
            If rl.PercentOf <> "" Then
               Dim val As New TotalValue(iif(rl.[function] <> TotalFunction.None, rl.[function], TotalFunction.Sum), rl.DataType = FieldType._Float)
               val.source = rl.Source
               val.sourceType = rl.SourceType
               val.resetAt = rl.PercentOf
               val.percentOf = rl.PercentOf
               val.percentOfService = True
               calculationTable.Add("__PercentOf" + rl.ID, val)
               percentValues.Add("__PercentOf" + rl.ID, New ArrayList())
            End If
         End If 
      Next control
   End Sub 'PopulateCalculationTable
   
   
   Protected Overrides Sub CreateChildControls()
      MyBase.CreateChildControls()
      Controls.Clear()
      If Not (ViewState("sections") Is Nothing) Then
         
         If Not (LayoutHeaderTemplate Is Nothing) Then
            Dim head As New ReportSectionBody()
            LayoutHeaderTemplate.InstantiateIn(head)
            Controls.Add(head)
         End If
         
         sections = CType(ViewState("sections"), ArrayList)
         Dim name As Object
         For Each name In  sections
            Dim item As New ReportSectionBody()
            CType(templates(name.ToString()), ReportSection).Template.InstantiateIn(item)
            item.name = name.ToString()
            Controls.Add(item)
         Next name
         If Not (LayoutFooterTemplate Is Nothing) Then
            Dim footer As New ReportSectionBody()
            LayoutFooterTemplate.InstantiateIn(footer)
            Controls.Add(footer)
         End If
      End If
   End Sub 
   
   
   Protected Sub CalculateSpecialControls(di As IDataItem, col As ControlCollection, sectionName As String, isHeader As Boolean, isTotalOnly As Boolean)
      Dim control As Control
      For Each control In  col
         If Not TypeOf control Is ReportLabel Then
            GoTo ContinueForEach1
         End If
         Dim rl As ReportLabel = CType(control, ReportLabel)
         If rl.SourceType = ReportLabelSourceType.SpecialValue Then
            specialValues.Add(rl)
            Select Case rl.Source
               Case "RowNumber"
                  BindReportLabel(rl, RowNumber)
               Case "PageNumber"
                  BindReportLabel(rl, PageNumber)
               Case "CurrentDate"
                  rl.DataType = FieldType._Text
                  BindReportLabel(rl, DateTime.Now.ToString("d"))
               Case "CurrentDateTime"
                  rl.DataType = FieldType._Text
                  BindReportLabel(rl, DateTime.Now.ToString("G"))
               Case "CurrentTime"
                  rl.DataType = FieldType._Text
                  BindReportLabel(rl, DateTime.Now.ToString("t"))
            End Select
         End If
      ContinueForEach1:
      Next control 
   End Sub 
   
   
   Protected Sub CalculateControls(di As IDataItem, col As ControlCollection, sectionName As String, isHeader As Boolean, isTotalOnly As Boolean)
      CalculateSpecialControls(di, col, sectionName, isHeader, isTotalOnly)
      Dim control As Control
      For Each control In  col
         If control.Controls.Count > 0 Then
            CalculateControls(di, control.Controls, sectionName, isHeader, isTotalOnly)
         End If 
         If TypeOf control Is Navigator Then
            navigators.Add(control)
         End If 
         If TypeOf control Is ReportLabel Then
            Dim rl As ReportLabel = CType(control, ReportLabel)
            Dim currentValue As Object = Nothing
            If rl.[function] <> TotalFunction.None Then
               If rl.[function] = TotalFunction.Avg Then
                  currentValue = CType(calculationTable(rl.ID), TotalValue).Average()
               Else
                  currentValue = CType(calculationTable(rl.ID), TotalValue).Value
               End If
               If rl.DataType <> FieldType._Float Or rl.DataType <> FieldType._Single Or rl.DataType <> FieldType._Integer Then
                  rl.DataType = FieldType._Float
               End If
               BindReportLabel(rl, currentValue)
            
            Else
               If Not di Is Nothing AndAlso rl.SourceType <> ReportLabelSourceType.SpecialValue And Not isTotalOnly And rl.Source <> "" Then
                  currentValue = di(rl.Source).Value
                  rl.Text = di(rl.Source).GetFormattedValue()
               End If
            End If 
            
            If rl.PercentOf <> "" Then
               CType(percentValues(("__PercentOf" + rl.ID)), ArrayList).Add(New Pair(rl, currentValue))
            End If 
            If rl.HideDuplicates Then
               If Not (_values(rl.ID) Is Nothing) Then
                  rl.Visible = _values(rl.ID) <> rl.Text
                  _values(rl.ID) = rl.Text
               Else
                  _values.Add(rl.ID, rl.Text)
               End If
            End If
         End If
      Next control
   End Sub 
    
   Overloads Private Function InstantiateSection(name As String, isHeader As Boolean, di As IDataItem) As ReportSectionBody
      Return InstantiateSection(name, isHeader, di, False, False, True)
   End Function 
   
   
   Overloads Private Function InstantiateSection(name As String, isHeader As Boolean, di As IDataItem, noRecordsFlag As Boolean) As ReportSectionBody
      Return InstantiateSection(name, isHeader, di, noRecordsFlag, False, True)
   End Function 
   
   
   Overloads Private Function InstantiateSection(name As String, isHeader As Boolean, di As IDataItem, noRecordsFlag As Boolean, lastSection As Boolean, addToCollection As Boolean) As ReportSectionBody
      Dim item As ReportSectionBody = Nothing
      Dim sName As String = name
      Dim sectionHeight As Single = 0
      Dim footerHeight As Single = 0
      If name <> "Detail" Then
         sName +=IIf(isHeader ,"_Header" ,"_Footer")
      End If
      If templates.Contains(sName) AndAlso CType(templates(sName), ReportSection).Visible Then
         sectionHeight = CType(templates(sName), ReportSection).Height
      End If
      If templates.Contains("Page_Footer") AndAlso CType(templates("Page_Footer"), ReportSection).Visible Then
         footerHeight = CType(templates("Page_Footer"), ReportSection).Height
      End If 
      If name = "Page" And isHeader Then
	  	  groupsData("Page") = di
		 _currentPageNumber += 1
         _totalPages += 1
      End If
      If ActivePageSize <> 0 And currPageSize + footerHeight + sectionHeight > ActivePageSize And name <> "Page" And addToCollection Then
         InstantiateSection("Page", False, CType(groupsData("Page"),IDataItem))
		If ViewMode = ReportViewMode.Web And PageNumber <> PreviewPageNumber And Not isPageCreated And (Not lastSection Or name = "Report") Then
			_controls.Clear()
		ElseIf ViewMode = ReportViewMode.Web And PageNumber = PreviewPageNumber Then
			isPageCreated = True
		End If

		 currPageSize = 0
         InstantiateSection("Page", True, di)
      End If
      If addToCollection Then
         currPageSize += sectionHeight
      End If 
      RaiseEvent BeforeItemDataBound(Me, New BeforeItemDataBoundEventArgs(di))

      If name = "Detail" Then
         _rowNumber += 1
         Dim v As DictionaryEntry
         For Each v In  calculationTable
            Dim val As TotalValue = CType(v.Value, TotalValue)
            Select Case val.[function]
               Case TotalFunction.Avg
                  If Not (di(val.source).Value Is Nothing) Then
                     val.AddFirst(di(val.source).Value)
                     val.second += 1
                  End If
               Case TotalFunction.Sum
                  val.AddFirst(di(val.source).Value)
               Case TotalFunction.Min
                  If Not (di(val.source).Value Is Nothing) Then
                     val.SetMin(di(val.source).Value)
                  End If
               Case TotalFunction.Max
                  If Not (di(val.source).Value Is Nothing) Then
                     val.SetMax(di(val.source).Value)
                  End If
               Case TotalFunction.Count
                  If val.source = "" Then
                     val.AddFirst(1)
                  Else
                     val.AddFirst(IIf(di(val.source).Value Is Nothing, 0, 1))
                  End If
            End Select
         Next v
      End If
      
      If templates.Contains(sName) Then
         item = New ReportSectionBody()
         CType(templates(sName), ReportSection).Template.InstantiateIn(item)
         item.name = sName
         item.Visible = CType(templates(sName), ReportSection).Visible
         item.Height = CType(templates(sName), ReportSection).Height
         item.DataItem = di
         CalculateControls(di, item.Controls, name, isHeader, False)
         If _controls.Count > 0 AndAlso CType(_controls(_controls.Count - 1), ReportSectionBody).name = "Detail" AndAlso Not (CType(_controls(_controls.Count - 1), ReportSectionBody).FindControl(ID + "Separator") Is Nothing) Then
            CType(_controls(_controls.Count - 1), ReportSectionBody).FindControl(ID + "Separator").Visible = sName = "Detail"
         End If
         If Not (item.FindControl((ID + "NoRecords")) Is Nothing) Then
            item.FindControl((ID + "NoRecords")).Visible = noRecordsFlag
         End If
         If (lastSection Or ViewMode = ReportViewMode.Web) And Not (item.FindControl((ID + "PageBreak")) Is Nothing) Then
            item.FindControl((ID + "PageBreak")).Visible = False
         End If
         RaiseEvent OnCalculate(Me, New OnCalculateEventArgs(di, sName, item, calculationTable))
         If ViewMode = ReportViewMode.Print Or(ViewMode = ReportViewMode.Web And PageNumber = PreviewPageNumber) Or(sName = "Report_Header" And PreviewPageNumber = 1) Or(sName = "Report_Footer" And PreviewPageNumber = TotalPages) Then
            item.DataBind()
         End If 

		If addToCollection And Not isPageCreated Then
		   _controls.Add(item)
		End If

		 If isHeader Then
            headersLinks.Add(name, item)
         End If
      End If 
      If headersLinks.Contains(name) And Not isHeader Then
         CalculateControls(di, CType(headersLinks(name), ReportSectionBody).Controls, name, isHeader, True)
         headersLinks.Remove(name)
      End If
      If Not isHeader Then
         Dim v As DictionaryEntry
         For Each v In  calculationTable
            Dim val As TotalValue = CType(v.Value, TotalValue)
            If val.percentOf = name And val.percentOfService Then
               Dim p As Pair
               For Each p In  CType(percentValues(v.Key), ArrayList)
                  BindReportLabel(CType(p.First, ReportLabel), val.GetPercent(p.Second))
               Next p
               CType(percentValues(v.Key), ArrayList).Clear()
               If Not(name="Page" And lastSection) Then val.Reset()
            End If
            If val.resetAt = name And name <> "Report" AndAlso Not(name="Page" And lastSection) Then
               val.Reset()
            End If
         Next v
      End If
      Return item
   End Function 
   
   
   Private Sub OpenGroup(name As String, di As IDataItem)
      Dim flag As Boolean = False
      Dim key As String
      For Each key In  Groups.Keys
         If key = name Or flag Then
			groupsData(key) = di
			InstantiateSection(key, True, di)
            flag = True
         End If
      Next key
   End Sub 
    
   Private Sub CloseGroup(name As String, di As IDataItem)
      Dim i As Integer
      For i = Groups.Count - 1 To 0 Step -1
         InstantiateSection(Groups.Keys(i), False, CType(groupsData(Groups.Keys(i)),IDataItem))
         If Groups.Keys(i) = name Then
            Exit For
         End If
      Next i
   End Sub 
    
   Protected Overrides Sub OnInit(e As EventArgs)
      MyBase.OnInit(e)
      minPageSize += maxSectionSize
      If Not (Page.Request("ViewMode") Is Nothing) Then
         ViewMode = CType([Enum].Parse(GetType(ReportViewMode), Page.Request("ViewMode"), True), ReportViewMode)
      End If 
      If Not (Page.Request((ID + "Page")) Is Nothing) Then
         Try
            PreviewPageNumber = Convert.ToInt16(Page.Request((ID + "Page")))
            If PreviewPageNumber <= 0 Then
               PreviewPageNumber = 1
            End If
         Catch
         End Try
      End If 
      If Not (Page.Request((ID + "PageSize")) Is Nothing) Then
         Try
			Dim tempval As Single = Convert.ToSingle(Page.Request((ID + "PageSize")))
			If tempval < 0 Then Return
            If tempval < minPageSize And tempval <>0 Then
               tempval = minPageSize
            End If
            If ViewMode = ReportViewMode.Print Then
               PageSize = tempval
            Else
               WebPageSize = tempval
			   If PageSizeLimit > 0 And WebPageSize > PageSizeLimit Or WebPageSize = 0 Then
					WebPageSize = PageSizeLimit
			   End If
            End If
         Catch
         End Try
      End If
   End Sub 
    
   
   Public Overrides Sub DataBind()
      ClearChildViewState()
      Controls.Clear()
      sections.Clear()
      If Not (LayoutHeaderTemplate Is Nothing) Then
         Dim head As New ReportSectionBody()
         LayoutHeaderTemplate.InstantiateIn(head)
		 head.DataBind()
         Controls.Add(head)
      End If
      Dim di As IDataItem = Nothing
      If DataSource.Length > 0 Then
         di = DataSource(0)
      End If
	  groupsData.Add("Report",di)
	  groupsData.Add("Page",Nothing)
	  Dim ci as Integer
	  For ci = 0 To Groups.Count-1
		groupsData.Add(Groups.Keys(ci),Nothing)
	  Next

      InstantiateSection("Report", True, di)
      InstantiateSection("Page", True, di)
      
      Dim k As Integer
      For k = 0 To DataSource.Length - 1
         Dim i1 As Integer
         For i1 = 0 To Groups.Count - 1
            If k > 0 AndAlso Not DataSource(k)(Groups(i1)).Equals(DataSource((k - 1))(Groups(i1))) Then
               CloseGroup(Groups.Keys(i1), DataSource(k))
               Exit For
            End If
         Next i1 
         For i1 = 0 To Groups.Count - 1
            If k = 0 OrElse Not DataSource(k)(Groups(i1)).Equals(DataSource((k - 1))(Groups(i1))) Then
               OpenGroup(Groups.Keys(i1), DataSource(k))
               Exit For
            End If
         Next i1
         InstantiateSection("Detail", False, DataSource(k), False)
      Next k
      If DataSource.Length > 0 Then
         di = DataSource(DataSource.GetUpperBound(0))
      End If
      If Groups.Count > 0 Then
         CloseGroup(Groups((Groups.Count - 1)), di)
      End If
      Dim lastFooter As ReportSectionBody = InstantiateSection("Page", False,CType(groupsData("Page"),IDataItem), False, True, False)
      InstantiateSection("Report", False, CType(groupsData("Report"),IDataItem), DataSource.Length = 0, True, True)
      If Not lastFooter Is Nothing Then CalculateSpecialControls(di, lastFooter.Controls, "Page", False, True)
 	  If TotalPages < PreviewPageNumber Then PreviewPageNumber = TotalPages
	  If Not (lastFooter Is Nothing) And(ViewMode = ReportViewMode.Print Or(ViewMode = ReportViewMode.Web And PreviewPageNumber = TotalPages)) Then
         _controls.Add(lastFooter)
      End If
		Dim c As ReportSectionBody
		For Each c In  _controls
		   If UseClientPaging And c.name = "Page_Header" Then
			  Controls.Add(c)
			  sections.Add(c.name)
			  Dim c1 As ReportSectionBody
			  For Each c1 In  _controls
				 If c1.name = "Page_Footer" Then
					Controls.Add(c1)
					sections.Add(c1.name)
					Exit For
				 End If
			  Next c1 
		   ElseIf Not( UseClientPaging And c.name = "Page_Footer") Then
				 Controls.Add(c)
				 sections.Add(c.name)
		   End If
		Next c
	  If Not (LayoutFooterTemplate Is Nothing) Then
         Dim footer As New ReportSectionBody()
         LayoutFooterTemplate.InstantiateIn(footer)
         Controls.Add(footer)
		 footer.DataBind()
	  End If
      
      Dim nav As Object
      For Each nav In  navigators
         If ViewMode = ReportViewMode.Print Then
            CType(nav, Navigator).Visible = False
         End If
         CType(nav, Navigator).MaxPage = CInt(TotalPages)
         CType(nav, Navigator).PageNumber = CInt(PreviewPageNumber)
         CType(nav, Navigator).DataBind()
      Next nav
      
      Dim rl As Object
      For Each rl In  specialValues
         If CType(rl, ReportLabel).Source = "TotalPages" Then
            BindReportLabel(CType(rl, ReportLabel), TotalPages)
         End If
      Next rl 
      ChildControlsCreated = True
      ViewState("sections") = sections
      
	 Dim i As Integer
	 _TotalRecords = _rowNumber
	 _rowNumber = 0
	 For i = 0 To Controls.Count - 1
		If TypeOf Controls(i) Is ReportSectionBody Then
			If CType(Controls(i), ReportSectionBody).name="Detail" Then _rowNumber =_rowNumber + 1
		   RaiseEvent BeforeShowSection(Me, New BeforeShowSectionEventArgs(CType(Controls(i), ReportSectionBody)))
		End If
	 Next i
   End Sub 
End Class 
End Namespace


'End Report Control

