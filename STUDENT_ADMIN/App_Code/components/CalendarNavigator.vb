'Calendar Navigator Control @0-F22A4E17
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.ComponentModel
Imports System.Collections

Namespace DECV_PROD2007.Controls


	Public Enum CalendarNavigatorOrder
	   YearsQuartersMonths
	   YearsMonthsQuarters
	   MonthsQuartersYears
	   MonthsYearsQuarters
	   QuartersYearsMonths
	   QuartersMonthsYears
	End Enum

   Public Class CalendarNavigator
      Inherits WebControl
      Implements INamingContainer 
      
      Private _owner As Calendar
      Private m_footerTemplate As ITemplate
      Private m_headerTemplate As ITemplate
      Private m_prev_YearTemplate As ITemplate
      Private m_prevTemplate As ITemplate
      Private m_next_YearTemplate As ITemplate
      Private m_nextTemplate As ITemplate
      Private m_yearsFooterTemplate As ITemplate
      Private m_yearsHeaderTemplate As ITemplate
      Private m_monthsFooterTemplate As ITemplate
      Private m_monthsHeaderTemplate As ITemplate
      Private m_regularYearTemplate As ITemplate
      Private m_currentYearTemplate As ITemplate
      Private m_regularMonthTemplate As ITemplate
      Private m_currentMonthTemplate As ITemplate
      Private m_quartersFooterTemplate As ITemplate
      Private m_quartersHeaderTemplate As ITemplate
      Private m_regularQuarterTemplate As ITemplate
      Private m_currentQuarterTemplate As ITemplate
      Private m_bodyTemplate As ITemplate
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property HeaderTemplate() As ITemplate
         Get
            Return m_headerTemplate
         End Get
         Set
            m_headerTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property FooterTemplate() As ITemplate
         Get
            Return m_footerTemplate
         End Get
         Set
            m_footerTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property MonthsHeaderTemplate() As ITemplate
         Get
            Return m_monthsHeaderTemplate
         End Get
         Set
            m_monthsHeaderTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property MonthsFooterTemplate() As ITemplate
         Get
            Return m_monthsFooterTemplate
         End Get
         Set
            m_monthsFooterTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property YearsHeaderTemplate() As ITemplate
         Get
            Return m_yearsHeaderTemplate
         End Get
         Set
            m_yearsHeaderTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property YearsFooterTemplate() As ITemplate
         Get
            Return m_yearsFooterTemplate
         End Get
         Set
            m_yearsFooterTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property RegularYearTemplate() As ITemplate
         Get
            Return m_regularYearTemplate
         End Get
         Set
            m_regularYearTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property CurrentYearTemplate() As ITemplate
         Get
            Return m_currentYearTemplate
         End Get
         Set
            m_currentYearTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property QuartersHeaderTemplate() As ITemplate
         Get
            Return m_quartersHeaderTemplate
         End Get
         Set
            m_quartersHeaderTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property QuartersFooterTemplate() As ITemplate
         Get
            Return m_quartersFooterTemplate
         End Get
         Set
            m_quartersFooterTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property RegularQuarterTemplate() As ITemplate
         Get
            Return m_regularQuarterTemplate
         End Get
         Set
            m_regularQuarterTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property CurrentQuarterTemplate() As ITemplate
         Get
            Return m_currentQuarterTemplate
         End Get
         Set
            m_currentQuarterTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property RegularMonthTemplate() As ITemplate
         Get
            Return m_regularMonthTemplate
         End Get
         Set
            m_regularMonthTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property CurrentMonthTemplate() As ITemplate
         Get
            Return m_currentMonthTemplate
         End Get
         Set
            m_currentMonthTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property Prev_YearTemplate() As ITemplate
         Get
            Return m_prev_YearTemplate
         End Get
         Set
            m_prev_YearTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property PrevTemplate() As ITemplate
         Get
            Return m_prevTemplate
         End Get
         Set
            m_prevTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property Next_YearTemplate() As ITemplate
         Get
            Return m_next_YearTemplate
         End Get
         Set
            m_next_YearTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property NextTemplate() As ITemplate
         Get
            Return m_nextTemplate
         End Get
         Set
            m_nextTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CalendarNavigatorItem))>  _
      Public Overridable Property BodyTemplate() As ITemplate
         Get
            Return m_bodyTemplate
         End Get
         Set
            m_bodyTemplate = value
         End Set
      End Property
      
      Public ReadOnly Property Owner() As Calendar 
         Get
            Return _owner
         End Get
      End Property
      
      Public Property YearsRange() As Integer
         Get
            If ViewState("yearsRange") Is Nothing Then
               Return 0
            End If
            Return CInt(ViewState("yearsRange"))
         End Get
         Set
            ViewState("yearsRange") = value
         End Set
      End Property
      
      Public ReadOnly Property [Date]() As DateTime
         Get
            Return owner.Date
         End Get
      End Property
      
      Public ReadOnly Property Month() As Integer
         Get
            Return [Date].Month
         End Get
      End Property
      
      Public ReadOnly Property Year() As Integer
         Get
            Return owner.Year
         End Get
      End Property
      
      Public ReadOnly Property Quarter() As Integer
         Get
            Return(owner.Month - 1) \ 3 + 1
         End Get
      End Property
      
	  
		Public Property Order() As CalendarNavigatorOrder
		   Get
			  If ViewState("order") Is Nothing Then
				 Return CalendarNavigatorOrder.MonthsQuartersYears
			  End If
			  Return CType(ViewState("order"), CalendarNavigatorOrder)
		   End Get
		   Set
			  ViewState("order") = value
		   End Set
		End Property

      Protected Overrides Sub CreateChildControls()
         Controls.Clear()
         
         If Not (ViewState("ItemCount") Is Nothing) Then
            CreateControlHierarchy(False)
         End If
      End Sub 'CreateChildControls


		Private Sub CreateMonths(ByRef index As Integer)
		   If Not (MonthsFooterTemplate Is Nothing) Then
			  CreateItem(index, CalendarNavigatorItemType.MonthsHeader, True, Nothing, [Date])
			  Dim i As Integer
			  For i = 1 To 12
				 If i = Month Then
					CreateItem(index, CalendarNavigatorItemType.CurrentMonth, True, Nothing, [Date])
				 Else
					CreateItem(index, CalendarNavigatorItemType.RegularMonth, True, Nothing, New DateTime(Year, i, 1))
				 End If
			  Next i
			  CreateItem(index, CalendarNavigatorItemType.MonthsFooter, True, Nothing, [Date])
		   End If
		End Sub 
		 

		Private Sub CreateYears(ByRef index As Integer)
		   If Not (YearsFooterTemplate Is Nothing) Then
			  CreateItem(index, CalendarNavigatorItemType.YearsHeader, True, Nothing, [Date])
			  Dim i As Integer
			  For i = Year - YearsRange To Year + YearsRange
				 If i = Year Then
					CreateItem(index, CalendarNavigatorItemType.CurrentYear, True, Nothing, [Date])
				 Else
					CreateItem(index, CalendarNavigatorItemType.RegularYear, True, Nothing, New DateTime(i, Month, 1))
				 End If
			  Next i
			  CreateItem(index, CalendarNavigatorItemType.YearsFooter, True, Nothing, [Date])
		   End If
		End Sub 


		Private Sub CreateQuarters(ByRef index As Integer)
		   If Not (QuartersFooterTemplate Is Nothing) Then
			  CreateItem(index, CalendarNavigatorItemType.QuartersHeader, True, Nothing, [Date])
			  Dim i As Integer
			  For i = 1 To 4
				 If i = Quarter Then
					CreateItem(index, CalendarNavigatorItemType.CurrentQuarter, True, Nothing, New DateTime(Year,(i - 1) * 3 + 1, 1))
				 Else
					CreateItem(index, CalendarNavigatorItemType.RegularQuarter, True, Nothing, New DateTime(Year,(i - 1) * 3 + 1, 1))
				 End If
			  Next i
			  CreateItem(index, CalendarNavigatorItemType.QuartersFooter, True, Nothing, [Date])
		   End If
		End Sub 	  
      
      Private Sub CreateControlHierarchy(useDataSource As Boolean)
         Dim index As Integer = 0
         CreateItem(index, CalendarNavigatorItemType.Header, True, Nothing, [Date])
         CreateItem(index, CalendarNavigatorItemType.Prev_Year, True, Nothing, [Date].AddYears(- 1))
		 If Owner.Mode <> CalendarMode.Full Then
			 If Owner.Mode = CalendarMode.Quarter Then
				CreateItem(index, CalendarNavigatorItemType.Prev, True, Nothing, [Date].AddMonths(-([Date].Month-1) Mod 3 - 3))
			 Else
				CreateItem(index, CalendarNavigatorItemType.Prev, True, Nothing, [Date].AddMonths(-1))
			 End If
		End If

		Select Case Order
		   Case CalendarNavigatorOrder.YearsQuartersMonths
			  CreateYears(index)
			  CreateQuarters(index)
			  CreateMonths(index)
		   Case CalendarNavigatorOrder.YearsMonthsQuarters
			  CreateYears(index)
			  CreateMonths(index)
			  CreateQuarters(index)
		   Case CalendarNavigatorOrder.MonthsQuartersYears
			  CreateMonths(index)
			  CreateQuarters(index)
			  CreateYears(index)
		   Case CalendarNavigatorOrder.MonthsYearsQuarters
			  CreateMonths(index)
			  CreateYears(index)
			  CreateQuarters(index)
		   Case CalendarNavigatorOrder.QuartersYearsMonths
			  CreateQuarters(index)
			  CreateYears(index)
			  CreateMonths(index)
		   Case CalendarNavigatorOrder.QuartersMonthsYears
			  CreateQuarters(index)
			  CreateMonths(index)
			  CreateYears(index)
		End Select         

         CreateItem(index, CalendarNavigatorItemType.Body, True, Nothing, [Date])
		 If Owner.Mode <> CalendarMode.Full Then
			 If Owner.Mode = CalendarMode.Quarter Then
				CreateItem(index, CalendarNavigatorItemType.Next, True, Nothing, [Date].AddMonths(3-([Date].Month-1) Mod 3))
			 Else
				CreateItem(index, CalendarNavigatorItemType.Next, True, Nothing, [Date].AddMonths(1))
			 End If
		 End If
		 CreateItem(index, CalendarNavigatorItemType.Next_Year, True, Nothing, [Date].AddYears(1))
         CreateItem(index, CalendarNavigatorItemType.Footer, True, Nothing, [Date])
      End Sub
       
      
      Private Function CreateItem(ByRef itemIndex As Integer, itemType As CalendarNavigatorItemType, dataBind As Boolean, dataItem As Object, [date] As DateTime) As CalendarNavigatorItem
         Dim item As New CalendarNavigatorItem(itemIndex, itemType, Me)
         item.EnableViewState = False
         item.Date = [date]
         Select Case itemType
            Case CalendarNavigatorItemType.Header
               If Not (headerTemplate Is Nothing) Then
                  HeaderTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.Footer
               If Not (FooterTemplate Is Nothing) Then
                  FooterTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.CurrentMonth
               If Not (CurrentMonthTemplate Is Nothing) Then
                  CurrentMonthTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.CurrentYear
               If Not (CurrentYearTemplate Is Nothing) Then
                  CurrentYearTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.CurrentQuarter
               If Not (CurrentQuarterTemplate Is Nothing) Then
                  CurrentQuarterTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
			Case CalendarNavigatorItemType.Prev
               If Not (PrevTemplate Is Nothing) Then
                  PrevTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.MonthsFooter
               If Not (MonthsFooterTemplate Is Nothing) Then
                  MonthsFooterTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.MonthsHeader
               If Not (MonthsHeaderTemplate Is Nothing) Then
                  MonthsHeaderTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.QuartersFooter
               If Not (QuartersFooterTemplate Is Nothing) Then
                  QuartersFooterTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.QuartersHeader
               If Not (QuartersHeaderTemplate Is Nothing) Then
                  QuartersHeaderTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
			Case CalendarNavigatorItemType.Next
               If Not (NextTemplate Is Nothing) Then
                  NextTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.Prev_Year
               If Not (Prev_YearTemplate Is Nothing) Then
                  Prev_YearTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.RegularMonth
               If Not (RegularMonthTemplate Is Nothing) Then
                  RegularMonthTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.RegularYear
               If Not (RegularYearTemplate Is Nothing) Then
                  RegularYearTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.RegularQuarter
               If Not (RegularQuarterTemplate Is Nothing) Then
                  RegularQuarterTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
			Case CalendarNavigatorItemType.Next_Year
               If Not (Next_YearTemplate Is Nothing) Then
                  Next_YearTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.YearsFooter
               If Not (YearsFooterTemplate Is Nothing) Then
                  YearsFooterTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.YearsHeader
               If Not (YearsHeaderTemplate Is Nothing) Then
                  YearsHeaderTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CalendarNavigatorItemType.Body
               If Not (BodyTemplate Is Nothing) Then
                  BodyTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
         End Select
         Controls.Add(item)
         item.DataBind()
		 Return item
      End Function
      
      
      
      Public Overrides Sub DataBind()
         MyBase.OnDataBinding(EventArgs.Empty)
         
         Controls.Clear()
         If HasChildViewState Then
            ClearChildViewState()
         End If 
         CreateControlHierarchy(True)
         ChildControlsCreated = True
      End Sub
      
      
      Protected Overrides Sub OnInit(e As EventArgs)
         MyBase.OnInit(e)
         Dim par As Control = Parent
         While Not TypeOf par Is Calendar AndAlso Not TypeOf par Is System.Web.UI.Page
            par = par.Parent
         End While
         If TypeOf par Is System.Web.UI.Page Then
            Throw New ApplicationException("CalendarNavigator can be placed only inside Calendar component")
         End If
         _owner = CType(par, Calendar)
      End Sub
   End Class
    
   Public Enum CalendarNavigatorItemType
      Header
      Footer
      Prev_Year
      Prev
      YearsHeader
      RegularYear
      CurrentYear
      YearsFooter
      MonthsHeader
      RegularMonth
      CurrentMonth
      MonthsFooter
      QuartersHeader
      RegularQuarter
      CurrentQuarter
      QuartersFooter
      [Next]
      Next_Year
      Body 
   End Enum 

	
   Public Class CalendarNavigatorItem
      Inherits Control
      Implements INamingContainer
      Private _itemIndex As Integer
      Private _itemType As CalendarNavigatorItemType
      Private [_date] As DateTime
      Private _owner As CalendarNavigator
      
      
      Public Sub New(itemIndex As Integer, itemType As CalendarNavigatorItemType, owner As CalendarNavigator)
         Me._itemIndex = itemIndex
         Me._itemType = itemType
         Me._owner = owner
      End Sub 'New
      
      
      Public ReadOnly Property Owner() As CalendarNavigator
         Get
            Return _owner
         End Get
      End Property
      
      
      Public ReadOnly Property CalendarName() As String
         Get
            Return Owner.Owner.ID
         End Get
      End Property
      
      
      Public Overridable ReadOnly Property ItemIndex() As Integer
         Get
            Return _itemIndex
         End Get
      End Property
      
      
      Public Overridable Property [Date]() As DateTime
         Get
            Return [_date]
         End Get
         Set
            [_date] = value
         End Set
      End Property
      
      Public Overridable ReadOnly Property Quarter() As Integer
         Get
            Return([Date].Month - 1) \ 3 + 1
         End Get
      End Property
      
      Public Overridable ReadOnly Property Action() As String
         Get
            Dim result As String = Page.Request.Url.AbsolutePath.Substring(Page.Request.Url.AbsolutePath.LastIndexOf("/"c) + 1) + "?"
            Dim id As String = Owner.Owner.ID
            Dim query As System.Collections.Specialized.NameValueCollection = HttpContext.Current.Request.QueryString
            Dim i As Integer
            For i = 0 To query.Count - 1
               If query.AllKeys(i) <> id + "Year" AndAlso query.AllKeys(i) <> id + "Month" AndAlso query.AllKeys(i) <> id + "Date" Then
                  If Not (query.AllKeys(i) Is Nothing) Then
                     result += query.AllKeys(i) + "=" + HttpContext.Current.Server.UrlEncode(query(i)) + "&"
                  Else
                     result += HttpContext.Current.Server.UrlEncode(query(i)) + "&"
                  End If
               End If
            Next i
            Return result
         End Get
      End Property
      
      Public Overridable ReadOnly Property Url() As String
         Get
            Return Action + Owner.Owner.ID + "Date=" + [Date].ToString("yyyy-MM")
         End Get
      End Property
      
      Public Overridable ReadOnly Property ItemType() As CalendarNavigatorItemType
         Get
            Return _itemType
         End Get
      End Property
      
      Friend Sub SetItemType(itemType As CalendarNavigatorItemType)
         Me._itemType = itemType
      End Sub
   End Class
End Namespace

'End Calendar Navigator Control

