'LocalesConfigHandler @0-BA0282BB
Imports System
Imports System.Xml
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Globalization

Namespace DECV_PROD2007

   Public Class CCSCultureInfo
      Inherits CultureInfo
      
      Public Sub New(name As String)
         MyBase.New(name)
      End Sub 'New
      Private m_BooleanFormat As String
      Private m_numberZeroFormat As String
      Private m_numberNullFormat As String
	  Private m_weekdayNarrowNames As String()
      Private m_outputEncoding As String
      Private m_defaultCountry As String

      
      Public Property BooleanFormat() As String
         Get
            Return m_BooleanFormat
         End Get
         Set
            m_BooleanFormat = value
         End Set
      End Property 
      
      Public Property NumberZeroFormat() As String
         Get
            Return m_numberZeroFormat
         End Get
         Set
            m_numberZeroFormat = value
         End Set
      End Property 
      Public Property WeekdayNarrowNames As String()
		Get
			Return m_weekdayNarrowNames
		End Get
		Set
			m_weekdayNarrowNames = value
		End Set
	  End Property
      Public Property DefaultCountry As String
         Get
            Return m_defaultCountry
         End Get
         Set
            m_defaultCountry = value
         End Set
      End Property 
      
      Public Property NumberNullFormat() As String
         Get
            Return m_numberNullFormat
         End Get
         Set
            m_numberNullFormat = value
         End Set
      End Property 

      Public Property Encoding() As String
         Get
            Return m_outputEncoding
         End Get
         Set
            m_outputEncoding = value
         End Set
      End Property 

   End Class 'CCSCultureInfo

   Public Class LocalesConfigHandler
      Implements System.Configuration.IConfigurationSectionHandler
      
      Public Sub New()
      End Sub
      
      Public Function Create(parent As Object, configContext As Object, section As XmlNode) As Object Implements System.Configuration.IConfigurationSectionHandler.Create

         Dim locales As New Hashtable()
         Dim node As XmlNode
         For Each node In  section.SelectNodes("*")
            Dim ci As New CCSCultureInfo(node.SelectSingleNode("@name").Value)
            locales.Add(node.SelectSingleNode("@language").Value & CType(IIf(node.SelectSingleNode("@country").Value="","","-" & node.SelectSingleNode("@country").Value), String),ci)
            ci.DefaultCountry = node.SelectSingleNode("@defaultCountry").Value
			ci.BooleanFormat = node.SelectSingleNode("@booleanFormat").Value
            ci.Encoding = node.SelectSingleNode("@encoding").Value
            
            If Not (node.SelectSingleNode("@weekdayShortNames") Is Nothing) Then
               ci.DateTimeFormat.AbbreviatedDayNames = node.SelectSingleNode("@weekdayShortNames").Value.Split(New Char() {";"c})
            End If
            If Not (node.SelectSingleNode("@weekdayNarrowNames") Is Nothing) Then
               ci.WeekdayNarrowNames = node.SelectSingleNode("@weekdayNarrowNames").Value.Split(New Char() {";"c})
            End If
			If Not (node.SelectSingleNode("@weekdayNames") Is Nothing) Then
               ci.DateTimeFormat.DayNames = node.SelectSingleNode("@weekdayNames").Value.Split(New Char() {";"c})
            End If
            If Not (node.SelectSingleNode("@monthShortNames") Is Nothing) Then
               ci.DateTimeFormat.AbbreviatedMonthNames = node.SelectSingleNode("@monthShortNames").Value.Split(New Char() {";"c})
            End If
            If Not (node.SelectSingleNode("@monthNames") Is Nothing) Then
               ci.DateTimeFormat.MonthNames = node.SelectSingleNode("@monthNames").Value.Split(New Char() {";"c})
            End If
            If Not (node.SelectSingleNode("@shortDate") Is Nothing) Then
               ci.DateTimeFormat.ShortDatePattern = node.SelectSingleNode("@shortDate").Value
            End If
            If Not (node.SelectSingleNode("@shortTime") Is Nothing) Then
               ci.DateTimeFormat.ShortTimePattern = node.SelectSingleNode("@shortTime").Value
            End If
            If Not (node.SelectSingleNode("@longDate") Is Nothing) Then
               ci.DateTimeFormat.LongDatePattern = node.SelectSingleNode("@longDate").Value
            End If
            If Not (node.SelectSingleNode("@longTime") Is Nothing) Then
               ci.DateTimeFormat.LongTimePattern = node.SelectSingleNode("@longTime").Value
            End If
            If Not (node.SelectSingleNode("@firstWeekDay") Is Nothing) Then
               ci.DateTimeFormat.FirstDayOfWeek = CType(Int16.Parse(node.SelectSingleNode("@firstWeekDay").Value), System.DayOfWeek)
            End If 
            If Not (node.SelectSingleNode("@decimalDigits") Is Nothing) Then
               ci.NumberFormat.NumberDecimalDigits = Integer.Parse(node.SelectSingleNode("@decimalDigits").Value)
            End If
            If Not (node.SelectSingleNode("@decimalSeparator") Is Nothing) Then
               ci.NumberFormat.NumberDecimalSeparator = node.SelectSingleNode("@decimalSeparator").Value
            End If
            If Not (node.SelectSingleNode("@groupSeparator") Is Nothing) Then
               ci.NumberFormat.NumberGroupSeparator = node.SelectSingleNode("@groupSeparator").Value
            End If 
            If Not (node.SelectSingleNode("@zeroFormat") Is Nothing) Then
               ci.NumberZeroFormat = node.SelectSingleNode("@zeroFormat").Value
            End If
            If Not (node.SelectSingleNode("@nullFormat") Is Nothing) Then
               ci.NumberNullFormat = node.SelectSingleNode("@nullFormat").Value
            End If
         Next node
         Return locales
      End Function 'Create

   End Class 'LocalesConfigHandler


End Namespace
'End LocalesConfigHandler

