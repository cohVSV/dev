'GridDataProvider Class @1-1B175396
Imports System
Imports System.Data
Imports System.Collections
Imports System.Collections.Specialized

Namespace DECV_PROD2007.Data
Public Class GridDataProviderBase
    Protected Select_ As DataCommand
    Protected Count As DataCommand
    Protected Parameters As New Hashtable()
    Protected m_recordCount As Integer
    Protected m_pagesCount As Integer

    Public ReadOnly Property RecordCount As Integer
        Get
            Return m_recordCount
        End Get
    End Property

    Public ReadOnly Property PagesCount As Integer
        Get
            Return m_pagesCount
        End Get
    End Property

    Protected Overridable Sub PrepareSelect()
    End Sub

    Protected _isEmpty As Boolean = True
    
    Public ReadOnly Property IsEmpty() As Boolean
        Get
            Return _isEmpty
        End Get
    End Property

    Protected Function ExecuteSelect() As DataSet
    Return Select_.Execute()
    End Function

    Protected Function ExecuteSelect(ByVal startRecord As Integer, ByVal maxRecords As Integer) As DataSet
    Return Select_.Execute(startRecord,maxRecords)
    End Function

    Protected Function ExecuteCount() As Integer
    Return Convert.ToInt32(Count.ExecuteScalar())
    End Function
End Class

    Public Delegate Sub ItemUpdatedEventHandler(sender As Object, e As ItemUpdatedEventArgs)
    Public Enum EditableGridOperation
        Insert
        Update
        Delete
    End Enum 'EditableGridOperation
    Public Class ItemUpdatedEventArgs
        Public Operation As EditableGridOperation
        Public Item As Object
        Public Sub New(operation As EditableGridOperation, dataItem As Object)
            Operation = operation
            Item = dataItem
        End Sub 'New
    End Class 'ItemUpdatedEventArgs
    Public Class EditableGridDataProviderBase
        Inherits GridDataProviderBase

        Public Event ItemUpdated As ItemUpdatedEventHandler
        Protected Overridable Sub OnItemUpdated(e As ItemUpdatedEventArgs)
                RaiseEvent ItemUpdated(Me, e)
        End Sub 
    End Class 
End Namespace
'End GridDataProvider Class

