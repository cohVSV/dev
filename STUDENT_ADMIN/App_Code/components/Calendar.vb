'Calendar Control @0-780C6B8B
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.ComponentModel
Imports System.Collections
Imports DECV_PROD2007.Data

Namespace DECV_PROD2007.Controls

   Public Enum WeekDayFormat
      Full
      [Short]
      Narrow
   End Enum 'WeekDayFormat
    _
   Public Enum CalendarMode
      Full
      Quarter
      ThreeMonth
      OneMonth
   End Enum 'CalendarMode

   Public Enum ExtendWeeksMode 
		Never
		Always
		[Auto]
	End Enum

   <DefaultProperty("DataSource")>  _
   Public Class Calendar
      Inherits WebControl
      Implements INamingContainer
      
	Private Class DateComparer
	   Implements IComparer 
	   
	   Function Compare(x As [Object], y As [Object]) As Integer Implements IComparer.Compare
		  Dim fDate As IComparable = CType(CType(x, ICalendarDataItem).EventDateCalendarField.Value, IComparable)
		  Dim fTime As IComparable = CType(CType(x, ICalendarDataItem).EventTimeCalendarField.Value, IComparable)
		  Dim sDate As IComparable = CType(CType(y, ICalendarDataItem).EventDateCalendarField.Value, IComparable)
		  Dim sTime As IComparable = CType(CType(y, ICalendarDataItem).EventTimeCalendarField.Value, IComparable)
		  
		  Dim result As Integer = 0
		  If fDate Is Nothing And sDate Is Nothing Then
			 Return 0
		  End If
		  If fDate Is Nothing And Not (sDate Is Nothing) Then
			 Return - 1
		  End If
		  If Not (fDate Is Nothing) And sDate Is Nothing Then
			 Return 1
		  End If 
		  If CType(x, ICalendarDataItem).IsEventTimeExists Then
			 fDate = CType(fDate, DateTime).Date
			 sDate = CType(sDate, DateTime).Date
		  End If
		  
		  result = fDate.CompareTo(sDate)
		  If result = 0 And CType(x, ICalendarDataItem).IsEventTimeExists Then
			 If fTime Is Nothing And sTime Is Nothing Then
				Return 0
			 End If
			 If fTime Is Nothing And Not (sTime Is Nothing) Then
				Return - 1
			 End If
			 If Not (fTime Is Nothing) And sTime Is Nothing Then
				Return 1
			 End If
			 fTime = CType(fTime, DateTime).TimeOfDay
			 sTime = CType(sTime, DateTime).TimeOfDay
			 
			 result = fTime.CompareTo(sTime)
		  End If
		  Return result
	   End Function 
	End Class

	  Private _dataSource As IEnumerable
      Private innerDataSource As ArrayList
      Private nextMonthDataSource As ArrayList
      Private m_footerTemplate As ITemplate 
      Private m_headerTemplate As ITemplate
      Private m_monthHeaderTemplate As ITemplate
      Private m_monthFooterTemplate As ITemplate
      Private m_weekDaysTemplate As ITemplate
      Private m_weekDaySeparatorTemplate As ITemplate
	  Private m_weekDaysFooterTemplate As ITemplate
	  Private m_weekHeaderTemplate As ITemplate
      Private m_weekFooterTemplate As ITemplate
      Private m_dayHeaderTemplate As ITemplate
      Private m_dayFooterTemplate As ITemplate
      Private m_eventSeparatorTemplate As ITemplate
      Private m_daySeparatorTemplate As ITemplate
      Private m_weekSeparatorTemplate As ITemplate
      Private m_monthSeparatorTemplate As ITemplate
      Private m_monthsRowSeparatorTemplate As ITemplate
      Private m_noEventsTemplate As ITemplate
      Private m_emptyDayTemplate As ITemplate
      Private m_eventRowTemplate As ITemplate
	  
	  <Bindable(True), Category("Data"), Description("The data source used to build up the control."), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
      Public Property DataSource() As IEnumerable
         Get
            Return _dataSource
         End Get
         Set
            _dataSource = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property HeaderTemplate() As ITemplate
         Get
            Return m_headerTemplate
         End Get
         Set
            m_headerTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property FooterTemplate() As ITemplate
         Get
            Return m_footerTemplate
         End Get
         Set
            m_footerTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property MonthHeaderTemplate() As ITemplate
         Get
            Return m_monthHeaderTemplate
         End Get
         Set
            m_monthHeaderTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property MonthFooterTemplate() As ITemplate
         Get
            Return m_monthFooterTemplate
         End Get
         Set
            m_monthFooterTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property WeekHeaderTemplate() As ITemplate
         Get
            Return m_weekHeaderTemplate
         End Get
         Set
            m_weekHeaderTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property WeekFooterTemplate() As ITemplate
         Get
            Return m_weekFooterTemplate
         End Get
         Set
            m_weekFooterTemplate = value
         End Set
      End Property


	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property DayHeaderTemplate() As ITemplate
         Get
            Return m_dayHeaderTemplate
         End Get
         Set
            m_dayHeaderTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property DayFooterTemplate() As ITemplate
         Get
            Return m_dayFooterTemplate
         End Get
         Set
            m_dayFooterTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property WeekDaysTemplate() As ITemplate
         Get
            Return m_weekDaysTemplate
         End Get
         Set
            m_weekDaysTemplate = value
         End Set
      End Property

	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property WeekDaySeparatorTemplate() As ITemplate
         Get
            Return m_weekDaySeparatorTemplate
         End Get
         Set
            m_weekDaySeparatorTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property WeekDaysFooterTemplate() As ITemplate
         Get
            Return m_weekDaysFooterTemplate
         End Get
         Set
            m_weekDaysFooterTemplate = value
         End Set
      End Property

	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property EventRowTemplate() As ITemplate
         Get
            Return m_eventRowTemplate
         End Get
         Set
            m_eventRowTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property EventSeparatorTemplate() As ITemplate
         Get
            Return m_eventSeparatorTemplate
         End Get
         Set
            m_eventSeparatorTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property DaySeparatorTemplate() As ITemplate
         Get
            Return m_daySeparatorTemplate
         End Get
         Set
            m_daySeparatorTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property WeekSeparatorTemplate() As ITemplate
         Get
            Return m_weekSeparatorTemplate
         End Get
         Set
            m_weekSeparatorTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property MonthSeparatorTemplate() As ITemplate
         Get
            Return m_monthSeparatorTemplate
         End Get
         Set
            m_monthSeparatorTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property MonthsRowSeparatorTemplate() As ITemplate
         Get
            Return m_monthsRowSeparatorTemplate
         End Get
         Set
            m_monthsRowSeparatorTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property NoEventsTemplate() As ITemplate
         Get
            Return m_noEventsTemplate
         End Get
         Set
            m_noEventsTemplate = value
         End Set
      End Property
	  
	  <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCCalendarItem))>  _
      Public Overridable Property EmptyDayTemplate() As ITemplate
         Get
            Return m_emptyDayTemplate
         End Get
         Set
            m_emptyDayTemplate = value
         End Set
      End Property
      Public Property MonthStyle() As HtmlGenericControl 
         Get
            Return CType(ViewState("MonthStyle"), HtmlGenericControl)
         End Get
         Set
            ViewState("MonthStyle") = value
         End Set
      End Property
      
      Public Property CurrentMonthStyle() As HtmlGenericControl
         Get
            Return CType(ViewState("CurrentMonthStyle"), HtmlGenericControl)
         End Get
         Set
            ViewState("CurrentMonthStyle") = value
         End Set
      End Property
      
      Public Property WeekdayNameStyle() As HtmlGenericControl
         Get
            Return CType(ViewState("WeekdayNameStyle"), HtmlGenericControl)
         End Get
         Set
            ViewState("WeekdayNameStyle") = value
         End Set
      End Property
      
      Public Property WeekendNameStyle() As HtmlGenericControl
         Get
            Return CType(ViewState("WeekendNameStyle"), HtmlGenericControl)
         End Get
         Set
            ViewState("WeekendNameStyle") = value
         End Set
      End Property
      
      Public Property DayStyle() As HtmlGenericControl
         Get
            Return CType(ViewState("DayStyle"), HtmlGenericControl)
         End Get
         Set
            ViewState("DayStyle") = value
         End Set
      End Property
      
      Public Property WeekendStyle() As HtmlGenericControl
         Get
            Return CType(ViewState("WeekendStyle"), HtmlGenericControl)
         End Get
         Set
            ViewState("WeekendStyle") = value
         End Set
      End Property
      
      Public Property TodayStyle() As HtmlGenericControl
         Get
            Return CType(ViewState("TodayStyle"), HtmlGenericControl)
         End Get
         Set
            ViewState("TodayStyle") = value
         End Set
      End Property
      
      Public Property WeekendTodayStyle() As HtmlGenericControl
         Get
            Return CType(ViewState("WeekendTodayStyle"), HtmlGenericControl)
         End Get
         Set
            ViewState("WeekendTodayStyle") = value
         End Set
      End Property
      
      Public Property OtherMonthDayStyle() As HtmlGenericControl
         Get
            Return CType(ViewState("OtherMonthDayStyle"), HtmlGenericControl)
         End Get
         Set
            ViewState("OtherMonthDayStyle") = value
         End Set
      End Property
      
      Public Property OtherMonthTodayStyle() As HtmlGenericControl
         Get
            Return CType(ViewState("OtherMonthTodayStyle"), HtmlGenericControl)
         End Get
         Set
            ViewState("OtherMonthTodayStyle") = value
         End Set
      End Property
      
      Public Property OtherMonthWeekendStyle() As HtmlGenericControl
         Get
            Return CType(ViewState("OtherMonthWeekendStyle"), HtmlGenericControl)
         End Get
         Set
            ViewState("OtherMonthWeekendStyle") = value
         End Set
      End Property
      
      Public Property OtherMonthWeekendTodayStyle() As HtmlGenericControl
         Get
            Return CType(ViewState("OtherMonthWeekendTodayStyle"), HtmlGenericControl)
         End Get
         Set
            ViewState("OtherMonthWeekendTodayStyle") = value
         End Set
      End Property 

      
      Public Property Mode() As CalendarMode
         Get
            Return CType(ViewState("_mode"), CalendarMode)
         End Get
         Set
            ViewState("_mode") = value
         End Set
      End Property
      
      
      Public Property [Date]() As DateTime
         Get
            Return CType(ViewState("_date"), DateTime)
         End Get
         Set
            ViewState("_date") = value
         End Set
      End Property
      
      
      Public Property CurrentDate() As DateTime
         Get
            If ViewState("_currentDate") Is Nothing Then
               ViewState("_currentDate") = DateTime.Now
            End If 
            Return CType(ViewState("_currentDate"), DateTime)
         End Get
         Set
            ViewState("_currentDate") = value
            Me.OnInit(New EventArgs())
         End Set
      End Property
      
      
      Public Property Month() As Integer
         Get
            Return [Date].Month
         End Get
         Set
            [Date] = [Date].AddMonths((value - [Date].Month))
         End Set
      End Property
      
      
      Public Property Day() As Integer
         Get
            Return [Date].Day
         End Get
         Set
            [Date] = [Date].AddDays((value - [Date].Day))
         End Set
      End Property
      
      Public Property Year() As Integer
         Get
            Return [Date].Year
         End Get
         Set
            [Date] = [Date].AddYears((value - [Date].Year))
         End Set
      End Property
      
	  Private _startDate As DateTime

		Public ReadOnly Property StartDate() As DateTime
		   Get
			  Return _startDate
		   End Get
		End Property

		Private _endDate As DateTime

		Public ReadOnly Property EndDate() As DateTime
		   Get
			  Return _endDate
		   End Get
		End Property


		Public ReadOnly Property DateRange() As DateTime()
		   Get
			  Return New DateTime() {_startDate, _endDate}
		   End Get
		End Property
      
      Public Property MonthsInRow() As Integer
         Get
			Dim result As Integer = 0
			If CalendarMode.OneMonth = Mode Then Return 1
            If Not (ViewState("_monthsInRow") Is Nothing) Then
               result = CInt(ViewState("_monthsInRow"))
            Else
               result = 12
            End If
			If (CalendarMode.Quarter = Mode Or CalendarMode.ThreeMonth = Mode) And result > 3 Then
				result = 3
			End If
			Return result
         End Get
         Set
            ViewState("_monthsInRow") = value
         End Set
      End Property
      
      
      Public Property ShowOtherMonthsDays() As Boolean
         Get
            If Not (ViewState("_showOtherMonthsDays") Is Nothing) Then
               Return CBool(ViewState("_showOtherMonthsDays"))
            Else
               Return False
            End If
         End Get
         Set
            ViewState("_showOtherMonthsDays") = value
         End Set
      End Property
      
      Public Property WeekDayFormat() As WeekDayFormat
         Get
            If Not (ViewState("WeekdayFormat") Is Nothing) Then
               Return CType(ViewState("WeekdayFormat"), WeekDayFormat)
            Else
               Return WeekDayFormat.Full
            End If
         End Get
         Set
            ViewState("WeekdayFormat") = value
         End Set
      End Property
      
      Protected Overridable Sub OnItemCommand(e As CCCalendarCommandEventArgs)
		RaiseEvent ItemCommand(Me, e)
      End Sub 
       
      Protected Overridable Sub OnItemCreated(e As CCCalendarItemEventArgs)
		RaiseEvent ItemCreated(Me, e)
      End Sub 
       
      Protected Overridable Sub OnItemDataBound(e As CCCalendarItemEventArgs)
		RaiseEvent ItemDataBound(Me, e)
      End Sub 
      
	  <Category("Action"), Description("Raised when a CommandEvent occurs within an item.")>  _
      Public Event ItemCommand As CCCalendarCommandEventHandler
      
      <Category("Behavior"), Description("Raised when an item is created and is ready for customization.")>  _
      Public Event ItemCreated As CCCalendarItemEventHandler
      
      <Category("Behavior"), Description("Raised when an item is data-bound.")>  _
      Public Event ItemDataBound As CCCalendarItemEventHandler

      Protected Overrides Sub CreateChildControls()
         Controls.Clear()
         
         If Not (ViewState("ItemCount") Is Nothing) Then
            CreateControlHierarchy(False)
         End If
      End Sub 'CreateChildControls
      

		Private Function GetNumOfDay(val As DateTime) As Integer
		   Dim i As Integer = CInt(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
		   If i = 0 Then
			  i = CInt(val.DayOfWeek)
		   Else
			  i = CInt(val.DayOfWeek) - i
			  If i < 0 Then
				 i += 7
			  End If
		   End If
		   Return i
		End Function 'GetNumOfDay

	   Private m_ExtendWeeks As ExtendWeeksMode = ExtendWeeksMode.Auto
	   Public Property ExtendWeeks() As ExtendWeeksMode
         Get
            Return m_ExtendWeeks
         End Get
         Set
            m_ExtendWeeks = value
         End Set
      End Property

	  Private Sub CreateControlHierarchy(useDataSource As Boolean)
         Dim monthStart, monthEnd As DateTime
		 Dim IsExtendWeeks As Boolean = (ExtendWeeksMode.Always = ExtendWeeks)
         Select Case Mode
            Case CalendarMode.Full
               monthStart = New DateTime(Year, 1, 1)
               monthEnd = monthStart.AddMonths(12)
            Case CalendarMode.Quarter
               monthStart = New DateTime(Year,((Month - 1) \ 3) * 3 + 1, 1)
               monthEnd = monthStart.AddMonths(3)
            Case CalendarMode.ThreeMonth
               monthStart = New DateTime(Year, Month, 1).AddMonths(- 1)
               monthEnd = monthStart.AddMonths(3)
            Case CalendarMode.OneMonth
               monthStart = New DateTime(Year, Month, 1)
               monthEnd = monthStart.AddMonths(1)
            Case Else
               monthStart = New DateTime(Year, 1, 1)
               monthEnd = monthStart.AddMonths(1)
         End Select
         Dim index As Integer = 0
         Dim style As HtmlGenericControl = Nothing
         Dim currDate As DateTime = monthStart

		 While Not (innerDataSource Is Nothing) AndAlso innerDataSource.Count > 0 AndAlso CType(innerDataSource(0), ICalendarDataItem).EventDateCalendarField.Value Is Nothing
		   innerDataSource.RemoveAt(0)
  		 End While

		 CreateItem(index, CCCalendarItemType.Header, True, Nothing, [Date], Nothing)
         Dim currMonth As Integer = 0
         
         While currDate < monthEnd
			If CalendarMode.OneMonth <> Mode And EventRowTemplate Is Nothing And currMonth Mod MonthsInRow = 0 Then
			   IsExtendWeeks = (ExtendWeeksMode.Always = ExtendWeeks)
			   Dim monthStep As DateTime = currDate.AddMonths(MonthsInRow)
			   Dim checkDate As DateTime = currDate
			   
			   While checkDate < monthStep And checkDate < monthEnd
				  If DateTime.DaysInMonth(checkDate.Year, checkDate.Month) + GetNumOfDay(checkDate) > 35 Then
					 IsExtendWeeks = (ExtendWeeksMode.Always = ExtendWeeks Or ExtendWeeksMode.Auto = ExtendWeeks)
					 Exit While
				  End If
				  checkDate = checkDate.AddMonths(1)
			   End While
			End If
            If CurrentDate.Month = currDate.Month Then
               style = CurrentMonthStyle
            Else
               style = MonthStyle
            End If
            CreateItem(index, CCCalendarItemType.MonthHeader, True, Nothing, currDate, style)
            currMonth += 1
            Dim w As Integer
            Dim startDate As New DateTime(Year, currDate.Month, 1)
            startDate = startDate.AddDays(-GetNumOfDay(startDate))
            Dim endDate As New DateTime(Year, currDate.Month, DateTime.DaysInMonth(Year, currDate.Month))
            endDate = endDate.AddDays(6 - GetNumOfDay(endDate))
			Dim offset As Integer = DateTime.op_Subtraction(endDate, startDate).Days
			If offset < 29 Then
			   endDate = endDate.AddDays(7)
			End If
			If IsExtendWeeks And offset < 36 Then
			   endDate = endDate.AddDays(7)
			End If
			Dim dow As DateTime = startDate

			For w = 0 To 6
               If w = CInt(DayOfWeek.Sunday) Or w = CInt(DayOfWeek.Saturday) Then
                  style = WeekendNameStyle
               Else
                  style = WeekdayNameStyle
               End If
               Dim item As CCCalendarItem = CreateItem(index, CCCalendarItemType.WeekDays, True, Nothing, dow, style)
               If Not (item Is Nothing) Then
                  Dim weekDay As Literal = CType(item.FindControl("WeekDay"), Literal)
                  
                  If Not (weekDay Is Nothing) Then
                     Select Case WeekDayFormat
                        Case WeekDayFormat.Full
                           weekDay.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(CType(w, DayOfWeek))
                        Case WeekDayFormat.Short
                           weekDay.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(CType(w, DayOfWeek))
                        Case WeekDayFormat.Narrow
                           weekDay.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(CType(w, DayOfWeek)).Substring(0, 1)
                     End Select
                  End If
               End If 
			   If w <> 6 Then
				CreateItem(index, CCCalendarItemType.WeekDaySeparator, True, Nothing, dow, style)
			   End If
			   dow = dow.AddDays(1)
            Next w 

            CreateItem(index, CCCalendarItemType.WeekDaysFooter, True, Nothing, currDate, style)

			
            
            Dim d As DateTime = startDate
            
            While d <= endDate
               If CInt(d.DayOfWeek) = CInt(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek) Then
                  CreateItem(index, CCCalendarItemType.WeekHeader, True, Nothing, d, style)
               End If

			   If d.DayOfWeek = DayOfWeek.Sunday Or d.DayOfWeek = DayOfWeek.Saturday Then
                  If d.Date = CurrentDate.Date AndAlso d.Month = currDate.Month Then
                     style = WeekendTodayStyle
                  Else
                     If d.Month = currDate.Month Then
                        style = WeekendStyle
                     Else
                        If d.Date = CurrentDate.Date AndAlso d.Month <> currDate.Month Then
                           style = OtherMonthWeekendTodayStyle
                        Else
                           style = OtherMonthWeekendStyle
                        End If
                     End If
                  End If
               Else
                  If d.Date = CurrentDate.Date AndAlso d.Month = currDate.Month Then
                     style = TodayStyle
                  Else
                     If d.Month = currDate.Month Then
                        style = DayStyle
                     Else
                        If d.Date = CurrentDate.Date AndAlso d.Month <> currDate.Month Then
                           style = OtherMonthTodayStyle
                        Else
                           style = OtherMonthDayStyle
                        End If
                     End If
                  End If
               End If

			   If d.Month = currDate.Month Or ShowOtherMonthsDays Then
				  Dim hasEvents As Boolean = False
						
				  While Not (innerDataSource Is Nothing) AndAlso innerDataSource.Count > 0 AndAlso CType(CType(innerDataSource(0), ICalendarDataItem).EventDateCalendarField.Value, DateTime) < d
				   innerDataSource.RemoveAt(0)
				  End While
				  If (Not IsNothing(nextMonthDataSource) _
				   AndAlso nextMonthDataSource.Count > 0 _
				   AndAlso CType(CType(nextMonthDataSource(0),ICalendarDataItem).EventDateCalendarField.Value,DateTime).Day = d.Day _
				   AndAlso CType(CType(nextMonthDataSource(0),ICalendarDataItem).EventDateCalendarField.Value,DateTime).Year = d.Year _
				   AndAlso CType(CType(nextMonthDataSource(0),ICalendarDataItem).EventDateCalendarField.Value,DateTime).Month = d.Month _
				   OrElse _
				   Not IsNothing(innerDataSource) _
				   AndAlso innerDataSource.Count > 0 _
				   AndAlso CType(CType(innerDataSource(0),ICalendarDataItem).EventDateCalendarField.Value,DateTime).Day = d.Day _
				   AndAlso CType(CType(innerDataSource(0),ICalendarDataItem).EventDateCalendarField.Value,DateTime).Year = d.Year _
				   AndAlso CType(CType(innerDataSource(0),ICalendarDataItem).EventDateCalendarField.Value,DateTime).Month = d.Month) Then hasEvents = True
				  CreateItem(index, CCCalendarItemType.DayHeader, True, Nothing, d, style, hasEvents)
				  Dim eventsExists As Boolean = False
				  
				  While Not (nextMonthDataSource Is Nothing) AndAlso nextMonthDataSource.Count > 0 AndAlso CType(CType(nextMonthDataSource(0), ICalendarDataItem).EventDateCalendarField.Value, DateTime).Day = d.Day AndAlso CType(CType(nextMonthDataSource(0), ICalendarDataItem).EventDateCalendarField.Value, DateTime).Year = d.Year AndAlso CType(CType(nextMonthDataSource(0), ICalendarDataItem).EventDateCalendarField.Value, DateTime).Month = d.Month
					 If eventsExists Then
						CreateItem(index, CCCalendarItemType.EventSeparator, True, nextMonthDataSource(0), d, style)
					 End If
                     CreateItem(index, CCCalendarItemType.EventRow, True, nextMonthDataSource(0), d, style)
                     nextMonthDataSource.RemoveAt(0)
					 eventsExists = True
                  End While
				  If d.Day = 15 And Not (nextMonthDataSource Is Nothing) Then nextMonthDataSource.Clear()
				  While Not (innerDataSource Is Nothing) AndAlso innerDataSource.Count > 0 AndAlso CType(CType(innerDataSource(0), ICalendarDataItem).EventDateCalendarField.Value, DateTime).Day = d.Day AndAlso CType(CType(innerDataSource(0), ICalendarDataItem).EventDateCalendarField.Value, DateTime).Year = d.Year AndAlso CType(CType(innerDataSource(0), ICalendarDataItem).EventDateCalendarField.Value, DateTime).Month = d.Month
					 If eventsExists Then
						CreateItem(index, CCCalendarItemType.EventSeparator, True, innerDataSource(0), d, style)
					 End If
                     CreateItem(index, CCCalendarItemType.EventRow, True, innerDataSource(0), d, style)
					 nextMonthDataSource.Insert(nextMonthDataSource.Count,innerDataSource(0))
                     innerDataSource.RemoveAt(0)
					 eventsExists = True
                  End While
				  If Not eventsExists Then
					  CreateItem(index, CCCalendarItemType.NoEvents, True, Nothing, d, style)
				  End If
                  CreateItem(index, CCCalendarItemType.DayFooter, True, Nothing, d, style, hasEvents)
                  style = Nothing
               Else
  				  If style Is OtherMonthWeekendTodayStyle Then style = OtherMonthWeekendStyle
				  If style Is OtherMonthTodayStyle Then style = OtherMonthDayStyle
                  CreateItem(index, CCCalendarItemType.EmptyDay, True, Nothing, d, style)
               End If
               If GetNumOfDay(d) = 6 Then
                  CreateItem(index, CCCalendarItemType.WeekFooter, True, Nothing, d, style)
				   If d <> endDate Then
					  CreateItem(index, CCCalendarItemType.WeekSeparator, True, Nothing, d, style)
				   End if
               ElseIf d < endDate Then
				  CreateItem(index, CCCalendarItemType.DaySeparator, True, Nothing, d, style)
			   End If
               d = d.AddDays(1)
            End While
            
            CreateItem(index, CCCalendarItemType.MonthFooter, True, Nothing, New DateTime(Year, currDate.Month, 1), style)

            If currMonth Mod MonthsInRow = 0 AndAlso currDate.AddMonths(1) < monthEnd Then
               CreateItem(index, CCCalendarItemType.MonthsRowSeparator, True, Nothing, New DateTime(Year, currDate.Month, 1), style)
            ElseIf currDate.AddMonths(1) < monthEnd Then
				CreateItem(index, CCCalendarItemType.MonthSeparator, True, Nothing, New DateTime(Year, currDate.Month, 1), style)
            End If
            currDate = currDate.AddMonths(1)
         End While
         
         
         CreateItem(index, CCCalendarItemType.Footer, True, Nothing, New DateTime(Year, 12, 31), style)
      End Sub 'CreateControlHierarchy
       
      Private Function CreateItem(ByRef itemIndex As Integer, itemType As CCCalendarItemType, dataBind As Boolean, dataItem As Object, [date] As DateTime, styleControl As HtmlGenericControl) As CCCalendarItem
		Return CreateItem(itemIndex, itemType, dataBind, dataItem, [date], styleControl, False)
      End Function
      
      Private Function CreateItem(ByRef itemIndex As Integer, itemType As CCCalendarItemType, dataBind As Boolean, dataItem As Object, [date] As DateTime, styleControl As HtmlGenericControl, hasEvents As Boolean) As CCCalendarItem
         Dim item As New CCCalendarItem(itemIndex, itemType, Me, hasEvents)
         item.EnableViewState = False
         If Not (styleControl Is Nothing) Then
            'item.Style = styleControl.Attributes
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            Dim sw As System.IO.StringWriter = New System.IO.StringWriter(sb)
            Dim tw As HtmlTextWriter = New HtmlTextWriter(sw)
            styleControl.Attributes.Render(tw)
            item.StyleString = sb.ToString()
         End If 
         Select Case itemType
            Case CCCalendarItemType.Header
               If Not (m_headerTemplate Is Nothing) Then
                  HeaderTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.Footer
               If Not (FooterTemplate Is Nothing) Then
                  FooterTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.DayFooter
               If Not (DayFooterTemplate Is Nothing) Then
                  DayFooterTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.DayHeader
               If Not (DayHeaderTemplate Is Nothing) Then
                  DayHeaderTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.EventRow
               If Not (EventRowTemplate Is Nothing) Then
                  EventRowTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.EventSeparator
               If Not (EventSeparatorTemplate Is Nothing) Then
                  EventSeparatorTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
			Case CCCalendarItemType.MonthFooter
               If Not (MonthFooterTemplate Is Nothing) Then
                  MonthFooterTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.MonthHeader
               If Not (MonthHeaderTemplate Is Nothing) Then
                  MonthHeaderTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.WeekDays
               If Not (WeekDaysTemplate Is Nothing) Then
                  WeekDaysTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.WeekDaySeparator
               If Not (WeekDaySeparatorTemplate Is Nothing) Then
                  WeekDaySeparatorTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
			Case CCCalendarItemType.WeekDaysFooter
               If Not (WeekDaysFooterTemplate Is Nothing) Then
                  WeekDaysFooterTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
			Case CCCalendarItemType.WeekFooter
               If Not (WeekFooterTemplate Is Nothing) Then
                  WeekFooterTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.WeekHeader
               If Not (WeekHeaderTemplate Is Nothing) Then
                  WeekHeaderTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.DaySeparator
               If Not (DaySeparatorTemplate Is Nothing) Then
                  DaySeparatorTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.MonthSeparator
               If Not (MonthSeparatorTemplate Is Nothing) Then
                  MonthSeparatorTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.MonthsRowSeparator
               If Not (MonthsRowSeparatorTemplate Is Nothing) Then
                  MonthsRowSeparatorTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.WeekSeparator
               If Not (WeekSeparatorTemplate Is Nothing) Then
                  WeekSeparatorTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.NoEvents
               If Not (NoEventsTemplate Is Nothing) Then
                  NoEventsTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCCalendarItemType.EmptyDay
               If Not (EmptyDayTemplate Is Nothing) Then
                  EmptyDayTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
         End Select
         Dim e As New CCCalendarItemEventArgs(item)
         If dataBind Then
            item.DataItem = CType(dataItem, ICalendarDataItem)
         End If
         item.CurrentProcessingDate = [date]
         OnItemCreated(e)
         Controls.Add(item)
         
         
         If dataBind Then
            item.DataBind()
         End If
         OnItemDataBound(e)
         
         Return item
      End Function 'CreateItem
      
      
      Protected Overrides Sub OnInit(e As EventArgs)
		MyBase.OnInit(e)
		Dim d As String = ""
		Dim isFormPresent As Boolean =  Not (Page.Request.Form((ID + "Date")) Is Nothing) Or Not (Page.Request.Form((ID + "Month")) Is Nothing) Or Not (Page.Request.Form((ID + "Year")) Is Nothing)
		If Not (Page.Request.QueryString((ID + "Date")) Is Nothing) And Not isFormPresent Then
		   d = Page.Request.QueryString((ID + "Date"))
		Else
		   If Not (Page.Request.Form((ID + "Date")) Is Nothing) Then
			  d = Page.Request.Form((ID + "Date"))
		   End If 
		End If
		If d <> "" Then
		   Try
			  Dim parts As String() = d.Split("-"c)
			  Try
				 DateTime.ParseExact(parts(0), "yyyy", System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat)
			  Catch
				 parts(0) = CurrentDate.Year.ToString("0000")
			  End Try
			  Try
				 [Date] = DateTime.ParseExact(parts(1), "MM", System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat)
			  Catch
			     parts(1) = CurrentDate.Month.ToString("00")
			  End Try
			  [Date] = DateTime.ParseExact(parts(0) + "-" + parts(1), "yyyy-MM", System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat)
		   Catch
		   End Try
		Else
		   [Date] = CurrentDate
		   Dim val As Integer = 0
		   Try
			  If Not (Page.Request.QueryString((ID + "Month")) Is Nothing) Then
				 val = Integer.Parse(Page.Request.QueryString((ID + "Month")))
			  Else
				 If Not (Page.Request.Form((ID + "Month")) Is Nothing) Then
					Month = Integer.Parse(Page.Request.Form((ID + "Month")))
				 End If
			  End If
			  If val > 0 And val < 13 Then
				 Month = val
			  End If
		   Catch
		   End Try
		   
		   Try
			  val = 0
			  If Not (Page.Request.QueryString((ID + "Year")) Is Nothing) Then
				 val = Integer.Parse(Page.Request.QueryString((ID + "Year")))
			  Else
				 If Not (Page.Request.Form((ID + "Year")) Is Nothing) Then
					Year = Integer.Parse(Page.Request.Form((ID + "Year")))
				 End If
			  End If
			  If val > 0 And val < 10000 Then
				 Year = val
			  End If
		   Catch
		   End Try
		End If

		Select Case Mode
		   Case CalendarMode.Full
			  _startDate = New DateTime(Year, 1, 1)
			  _endDate = _startDate.AddMonths(11)
		   Case CalendarMode.Quarter
			  _startDate = New DateTime(Year,(Month - 1) / 3 * 3 + 1, 1)
			  _endDate = _startDate.AddMonths(2)
		   Case CalendarMode.ThreeMonth
			  _startDate = New DateTime(Year, Month, 1).AddMonths(- 1)
			  _endDate = _startDate.AddMonths(2)
		   Case CalendarMode.OneMonth
			  _startDate = New DateTime(Year, Month, 1)
			  _endDate = _startDate
		   Case Else
			  _startDate = New DateTime(Year, 1, 1)
			  _endDate = _startDate
		End Select
		_startDate = _startDate.Date
		_endDate = New DateTime(_endDate.Year, _endDate.Month, DateTime.DaysInMonth(_endDate.Year, _endDate.Month), 23, 59, 59)

		If ShowOtherMonthsDays Then

		   Dim IsExtendWeeks As Boolean = (ExtendWeeksMode.Always = ExtendWeeks)
		   If CalendarMode.OneMonth <> Mode And EventRowTemplate Is Nothing And _endDate.Month Mod MonthsInRow = 0 Then
			  IsExtendWeeks = (ExtendWeeks = ExtendWeeksMode.Always)
			  Dim monthStep As DateTime = _endDate.AddMonths(MonthsInRow)
			  Dim checkDate As DateTime
			  
			  While checkDate < monthStep AndAlso checkDate < _endDate.AddMonths(1)
				 If DateTime.DaysInMonth(checkDate.Year, checkDate.Month) + GetNumOfDay(checkDate) > 35 Then
					IsExtendWeeks = (ExtendWeeksMode.Always = ExtendWeeks OrElse ExtendWeeksMode.Auto = ExtendWeeks)
					Exit While
				 End If
				 checkDate = checkDate.AddMonths(1)
			  End While
		   End If
		   
		   _startDate = _startDate.AddDays(- GetNumOfDay(_startDate))
		   _endDate = _endDate.AddDays((6 - GetNumOfDay(_endDate)))
		   If IsExtendWeeks Then
			  _endDate = _endDate.AddDays(7)
		   End If 
		End If
	  End Sub 'OnInit
      
      
      Public Overrides Sub DataBind()
         MyBase.OnDataBinding(EventArgs.Empty)
         
         If Not (DataSource Is Nothing) AndAlso DataSource.GetEnumerator().MoveNext() Then
            innerDataSource = New ArrayList()
			nextMonthDataSource = New ArrayList()
            Dim item As ICalendarDataItem
            For Each item In  DataSource
               innerDataSource.Add(item)
            Next item
            innerDataSource.Sort(New DateComparer())
         End If
         
         
         
         Controls.Clear()
         If HasChildViewState Then
            ClearChildViewState()
         End If 
         CreateControlHierarchy(True)
         ChildControlsCreated = True
      End Sub 'DataBind
      
      
      Protected Overrides Function OnBubbleEvent([source] As Object, e As EventArgs) As Boolean
         
         Dim handled As Boolean = False
         
         If TypeOf e Is CCCalendarCommandEventArgs Then
            Dim ce As CCCalendarCommandEventArgs = CType(e, CCCalendarCommandEventArgs)
            
            OnItemCommand(ce)
            handled = True
         End If 
         
         Return handled
      End Function 'OnBubbleEvent
   End Class 'Calendar

   Public Enum CCCalendarItemType
      Header
      Footer
      MonthHeader
      MonthFooter
      WeekDays
      WeekDaySeparator
	  WeekDaysFooter
	  WeekHeader
      WeekFooter
      DayHeader
      DayFooter
      EventRow
      EventSeparator
      DaySeparator
      WeekSeparator
      MonthSeparator
      MonthsRowSeparator
      NoEvents
      EmptyDay 
   End Enum 'CCCalendarItemType
    
   Public Class CCCalendarItem
      Inherits Control
      Implements INamingContainer 
      Private _itemIndex As Integer
      Private _itemType As CCCalendarItemType
      Private _dataItem As Object
      Private _date As DateTime
      Private _owner As Calendar
      Private _hasEvents As Boolean = False
      Private _style As String
      
      Public Sub New(itemIndex As Integer, itemType As CCCalendarItemType, owner As Calendar)
         Me._itemIndex = itemIndex
         Me._itemType = itemType
         Me._owner = owner
      End Sub 'New
      
      Public Sub New(itemIndex As Integer, itemType As CCCalendarItemType, owner As Calendar, hasEvents As Boolean)
         Me.New(itemIndex, itemType, owner)
         Me._hasEvents = hasEvents
      End Sub 'New
      
      
      Public ReadOnly Property Owner() As Calendar
         Get
            Return _owner
         End Get
      End Property
      
      
      Public Shadows ReadOnly Property HasEvents() As Boolean
         Get
            Return _hasEvents
         End Get
      End Property
      
      
      Public Property StyleString() As String
         Get
            Return _style
         End Get
         Set
            _style = value
         End Set
      End Property
      
      
      Public Overridable Property DataItem() As Object
         Get
            Return _dataItem
         End Get
         Set
            _dataItem = value
         End Set
      End Property
      
      
      Public Overridable ReadOnly Property ItemIndex() As Integer
         Get
            Return _itemIndex
         End Get
      End Property
      
      
      Public Overridable Property CurrentProcessingDate() As DateTime
         Get
            Return _date
         End Get
         Set
            _date = value
         End Set
      End Property
      
      
      Public Overridable ReadOnly Property NextProcessingDate() As DateTime
         Get
            Select Case ItemType
               Case CCCalendarItemType.DayFooter, CCCalendarItemType.DayHeader, CCCalendarItemType.DaySeparator, CCCalendarItemType.EmptyDay, CCCalendarItemType.EventRow, CCCalendarItemType.EventSeparator, CCCalendarItemType.NoEvents, CCCalendarItemType.WeekFooter, CCCalendarItemType.WeekHeader, CCCalendarItemType.WeekSeparator
                     Return CurrentProcessingDate.AddDays(1)
               Case CCCalendarItemType.MonthFooter, CCCalendarItemType.MonthHeader, CCCalendarItemType.MonthsRowSeparator, CCCalendarItemType.MonthSeparator
                     Return CurrentProcessingDate.AddMonths(1)
               Case CCCalendarItemType.Footer, CCCalendarItemType.Header
                     Return CurrentProcessingDate.AddYears(1)
            End Select 
            Return CurrentProcessingDate.AddDays(1)
         End Get
      End Property 
      
      
      Public Overridable ReadOnly Property PrevProcessingDate() As DateTime
         Get
            Select Case ItemType
               Case CCCalendarItemType.DayFooter, CCCalendarItemType.DayHeader, CCCalendarItemType.DaySeparator, CCCalendarItemType.EmptyDay, CCCalendarItemType.EventRow, CCCalendarItemType.EventSeparator, CCCalendarItemType.NoEvents, CCCalendarItemType.WeekFooter, CCCalendarItemType.WeekHeader, CCCalendarItemType.WeekSeparator
                     Return CurrentProcessingDate.AddDays(- 1)
               Case CCCalendarItemType.MonthFooter, CCCalendarItemType.MonthHeader, CCCalendarItemType.MonthsRowSeparator, CCCalendarItemType.MonthSeparator
                     Return CurrentProcessingDate.AddMonths(- 1)
               Case CCCalendarItemType.Footer, CCCalendarItemType.Header
                     Return CurrentProcessingDate.AddYears(- 1)
            End Select
            Return CurrentProcessingDate.AddDays(- 11)
         End Get
      End Property 
      
      
      
      Public Overridable ReadOnly Property ItemType() As CCCalendarItemType
         Get
            Return _itemType
         End Get
      End Property
      
      
      Protected Overrides Function OnBubbleEvent([source] As Object, e As EventArgs) As Boolean
         If TypeOf e Is CommandEventArgs Then
            
            Dim args As New CCCalendarCommandEventArgs(Me, [source], CType(e, CommandEventArgs))
            
            RaiseBubbleEvent(Me, args)
            Return True
         End If
         Return False
      End Function 'OnBubbleEvent
      
      
      Friend Sub SetItemType(itemType As CCCalendarItemType)
         Me._itemType = itemType
      End Sub 'SetItemType 
   End Class 'CCCalendarItem
    
   
   NotInheritable Public Class CCCalendarCommandEventArgs
      Inherits CommandEventArgs
      
      Private _item As CCCalendarItem
      Private _commandSource As Object
      
      
      Public Sub New(item As CCCalendarItem, commandSource As Object, originalArgs As CommandEventArgs)
         MyBase.New(originalArgs)
         Me._item = item
         Me._commandSource = commandSource
      End Sub 'New
      
      
      Public ReadOnly Property Item() As CCCalendarItem
         Get
            Return _item
         End Get
      End Property
      
      
      Public ReadOnly Property CommandSource() As Object
         Get
            Return _commandSource
         End Get
      End Property
   End Class 'CCCalendarCommandEventArgs
   
   
   Public Delegate Sub CCCalendarCommandEventHandler(sender As Object, e As CCCalendarCommandEventArgs)
    
   NotInheritable Public Class CCCalendarItemEventArgs
      Inherits EventArgs
      
      Private _item As CCCalendarItem
      
      
      Public Sub New(item As CCCalendarItem)
         Me._item = item
      End Sub 'New
      
      
      Public ReadOnly Property Item() As CCCalendarItem
         Get
            Return _item
         End Get
      End Property
   End Class 'CCCalendarItemEventArgs
   
   
   Public Delegate Sub CCCalendarItemEventHandler(sender As Object, e As CCCalendarItemEventArgs)
    
   Public Interface ICalendarDataItem
      
	  Property IsEventTimeExists As Boolean

      Property EventDateCalendarField As DateField
      
      Property EventTimeCalendarField As DateField

   End Interface 
End Namespace 

'End Calendar Control

