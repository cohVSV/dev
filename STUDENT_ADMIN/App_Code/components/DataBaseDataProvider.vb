'DataBaseDataProvider Class @0-BB8BDD0C
Imports System
Imports System.Data
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Text

Namespace DECV_PROD2007.Data
Public Enum OperationType
Select_
Insert
Update
Delete
End Enum

Public Class DataCommand
Protected parameters_ As New ParameterCollection()
Protected m_sql As StringBuilder
Protected m_sql_store As String
Protected orderBy_ As String = ""
Protected m_dao As DataAccessObject
Protected m_operationType As OperationType

    Public Sub New()
    End Sub

    Public Property Parameters As ParameterCollection
        Get
            Return parameters_
        End Get
        Set
            parameters_ = value
        End Set
    End Property

    Public Property SqlQuery As StringBuilder
        Get
            Return m_sql
        End Get
        Set
            m_sql = value
            m_sql_store = value.ToString()
        End Set
    End Property

    Public Property Dao As DataAccessObject
        Get
            Return m_dao
        End Get
        Set
            m_dao = value
        End Set
    End Property

    Public Property OrderBy As String
        Get
            Return orderBy_
        End Get
        Set
            orderBy_ = value
        End Set
    End Property

    Public Property DateFormat As String
        Get
            Return m_dao.DateFormat
        End Get
        Set
            m_dao.DateFormat = value
        End Set
    End Property

    Public Property BoolFormat As String
        Get
            Return m_dao.BoolFormat
        End Get
        Set
            m_dao.BoolFormat = value
        End Set
    End Property

    Public Property OpType As OperationType
        Get
            Return m_operationType
        End Get
        Set
            m_operationType = value
        End Set
    End Property

    Public Sub Reset()
        Parameters.Clear()
        m_sql = New StringBuilder(m_sql_store)
    End Sub

    Public Function Execute() As DataSet
        Return ExecuteImpl()
    End Function

    Public Function Execute(ByVal startRecord As Integer, ByVal maxRecords As Integer) As DataSet
        Return ExecuteImpl(startRecord,maxRecords)
    End Function

    Public Function ExecuteNonQuery() As Object
        Return ExecuteNonQueryImpl()
    End Function

    Public Function ExecuteScalar() As Object
        Return ExecuteScalarImpl()
    End Function

    Protected Overridable Function ExecuteImpl(ByVal startRecord As Integer, ByVal maxRecords As Integer) As DataSet
        Return Nothing
    End Function

    Protected Overridable Function ExecuteImpl() As DataSet
        Return Nothing
    End Function

    Protected Overridable Function ExecuteNonQueryImpl() As Object
        Return 0
    End Function

    Protected Overridable Function ExecuteScalarImpl() As Object
        Return 0
    End Function
End Class
End Namespace
'End DataBaseDataProvider Class

