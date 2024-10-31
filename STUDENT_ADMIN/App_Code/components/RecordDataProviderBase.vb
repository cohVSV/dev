'RecordDataProvider Class @1-2C99744D
Imports System
Imports System.Data
Imports System.Collections
Imports System.Collections.Specialized

Namespace DECV_PROD2007.Data
Public Class RecordDataProviderBase
    Protected Select_ As DataCommand
    Protected Insert As DataCommand
    Protected Update As DataCommand
    Protected Delete As DataCommand
    Protected IsInsertMode As Boolean
    Protected CmdExecution As Boolean = True
    Protected IsParametersPassed As Boolean = True
    Protected CommonParameters As New Hashtable()

    Protected Overridable Sub PrepareSelect()
    End Sub

    Protected Function ExecuteSelect() As DataSet
    PrepareSelect()
    Return Select_.Execute(0, 1)
    End Function

    Protected Overridable Sub PrepareInsert()
    End Sub

    Protected Function ExecuteInsert() As Object
    Insert.OpType = OperationType.Insert
    PrepareInsert()
    If CmdExecution Then
        Return Insert.ExecuteNonQuery()
    Else
        Return 0
    End If
    End Function

    Protected Overridable Sub PrepareUpdate()
    End Sub

    Protected Function ExecuteUpdate() As Object
    Update.OpType = OperationType.Update
    PrepareUpdate()
    If CmdExecution And IsParametersPassed Then
        Return Update.ExecuteNonQuery()
    Else
        Return 0
    End If
    End Function

    Protected Overridable Sub PrepareDelete()
    End Sub

    Protected Function ExecuteDelete() As Object
    Delete.OpType = OperationType.Delete
    PrepareDelete()
    If CmdExecution And IsParametersPassed Then
        Return Delete.ExecuteNonQuery()
    Else
        Return 0
    End If
    End Function
End Class
End Namespace
'End RecordDataProvider Class

