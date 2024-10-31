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

Namespace DECV_PROD2007.Student_Medical_maintain 'Namespace @1-EC9EAE95

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

'Record STUDENT_MEDICAL_DETAILS Item Class @3-FF48FE00
Public Class STUDENT_MEDICAL_DETAILSItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public hidden_LAST_ALTERED_BY As TextField
    Public hidden_LAST_ALTERED_DATE As DateField
    Public hidden_STUDENT_ID As TextField
    Public HEARING As IntegerField
    Public HEARINGItems As ItemCollection
    Public VISION As IntegerField
    Public VISIONItems As ItemCollection
    Public ASDASPERGERS As IntegerField
    Public ASDASPERGERSItems As ItemCollection
    Public INTELLECTUAL As IntegerField
    Public INTELLECTUALItems As ItemCollection
    Public PHYSICAL As IntegerField
    Public PHYSICALItems As ItemCollection
    Public BEHAVIOURAL As IntegerField
    Public BEHAVIOURALItems As ItemCollection
    Public LANGUAGE As IntegerField
    Public LANGUAGEItems As ItemCollection
    Public HASALLERGYHISTORY As IntegerField
    Public HASALLERGYHISTORYItems As ItemCollection
    Public ANAPHYLAXIS As IntegerField
    Public ANAPHYLAXISItems As ItemCollection
    Public HASOTHERCONDITIONS As IntegerField
    Public HASOTHERCONDITIONSItems As ItemCollection
    Public OTHERMEDICALISSUES As TextField
    Public ALLERGYHISTORY As TextField
    Public OTHERCONDITIONS As TextField
    Public MENTALHEALTH As IntegerField
    Public MENTALHEALTHItems As ItemCollection
    Public MENTALHEALTH_HISTORY As TextField
    Public hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES As TextField
    Public cbPSD_FUNDING_CATEGORY As TextField
    Public cbPSD_FUNDING_CATEGORYItems As ItemCollection
    Public PSD_FUNDING_OTHER As TextField
    Public PSD_FUNDING_ELIGIBLE As IntegerField
    Public PSD_FUNDING_ELIGIBLEItems As ItemCollection
    Public hidden_PSD_FUNDING_CATEGORY As TextField
    Public cbRECEIVED_SUPPORT_PROGRAMS_SERVICES As TextField
    Public cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems As ItemCollection
    Public RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER As TextField
    Public ALLERGIES_FLAG As TextField
    Public ALLERGIES_FLAGItems As ItemCollection
    Public ANAPHYLAXIS_FLAG As TextField
    Public ANAPHYLAXIS_FLAGItems As ItemCollection
    Public lbDiagnosedConditions As TextField
    Public lbDiagnosedConditionsItems As ItemCollection
    Public STUDENT_ID As FloatField
    Public Link_DiagnosisConfirmed As TextField
    Public Link_DiagnosisConfirmedHref As Object
    Public Link_DiagnosisConfirmedHrefParameters As LinkParameterCollection
    Public DIAGNOSED_ASTHMA As IntegerField
    Public DIAGNOSED_ASTHMAItems As ItemCollection
    Public MANAGE_PLAN_ASTHMA As IntegerField
    Public MANAGE_PLAN_ASTHMAItems As ItemCollection
    Public DIAGNOSED_DIABETES As IntegerField
    Public DIAGNOSED_DIABETESItems As ItemCollection
    Public MANAGE_PLAN_DIABETES As IntegerField
    Public MANAGE_PLAN_DIABETESItems As ItemCollection
    Public DIAGNOSED_EPILEPSY As IntegerField
    Public DIAGNOSED_EPILEPSYItems As ItemCollection
    Public MANAGE_PLAN_EPILEPSY As IntegerField
    Public MANAGE_PLAN_EPILEPSYItems As ItemCollection
    Public PSD_FUNDING_LEVEL As TextField
    Public PSD_FUNDING_LEVELItems As ItemCollection
    Public PSD_FUNDING_ASSESSED As IntegerField
    Public PSD_FUNDING_ASSESSEDItems As ItemCollection
    Public NCCD_FUNDING_ELIGIBLE As IntegerField
    Public NCCD_FUNDING_ELIGIBLEItems As ItemCollection
    Public NCCD_FUNDING_CATEGORY As IntegerField
    Public NCCD_FUNDING_CATEGORYItems As ItemCollection
    Public NCCD_FUNDING_LEVEL As IntegerField
    Public NCCD_FUNDING_LEVELItems As ItemCollection
    Public DI_ASSESSED As IntegerField
    Public DI_ASSESSEDItems As ItemCollection
    Public DI_APPROVED As IntegerField
    Public DI_APPROVEDItems As ItemCollection
    Public Sub New()
    LAST_ALTERED_BY = New TextField("", DBUtility.UserId.ToUpper())
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    hidden_LAST_ALTERED_BY = New TextField("", DBUtility.UserId.ToUpper())
    hidden_LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    hidden_STUDENT_ID = New TextField("", Nothing)
    HEARING = New IntegerField("", 0)
    HEARINGItems = New ItemCollection()
    VISION = New IntegerField("", 0)
    VISIONItems = New ItemCollection()
    ASDASPERGERS = New IntegerField("", 0)
    ASDASPERGERSItems = New ItemCollection()
    INTELLECTUAL = New IntegerField("", 0)
    INTELLECTUALItems = New ItemCollection()
    PHYSICAL = New IntegerField("", 0)
    PHYSICALItems = New ItemCollection()
    BEHAVIOURAL = New IntegerField("", 0)
    BEHAVIOURALItems = New ItemCollection()
    LANGUAGE = New IntegerField("", 0)
    LANGUAGEItems = New ItemCollection()
    HASALLERGYHISTORY = New IntegerField("", 0)
    HASALLERGYHISTORYItems = New ItemCollection()
    ANAPHYLAXIS = New IntegerField("", 0)
    ANAPHYLAXISItems = New ItemCollection()
    HASOTHERCONDITIONS = New IntegerField("", 0)
    HASOTHERCONDITIONSItems = New ItemCollection()
    OTHERMEDICALISSUES = New TextField("", Nothing)
    ALLERGYHISTORY = New TextField("", Nothing)
    OTHERCONDITIONS = New TextField("", Nothing)
    MENTALHEALTH = New IntegerField("", 0)
    MENTALHEALTHItems = New ItemCollection()
    MENTALHEALTH_HISTORY = New TextField("", Nothing)
    hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES = New TextField("", "0,")
    cbPSD_FUNDING_CATEGORY = New TextField("", "")
    cbPSD_FUNDING_CATEGORYItems = New ItemCollection()
    PSD_FUNDING_OTHER = New TextField("", Nothing)
    PSD_FUNDING_ELIGIBLE = New IntegerField("", Nothing)
    PSD_FUNDING_ELIGIBLEItems = New ItemCollection()
    hidden_PSD_FUNDING_CATEGORY = New TextField("", "0,")
    cbRECEIVED_SUPPORT_PROGRAMS_SERVICES = New TextField("", "")
    cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems = New ItemCollection()
    RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER = New TextField("", Nothing)
    ALLERGIES_FLAG = New TextField("", "U")
    ALLERGIES_FLAGItems = New ItemCollection()
    ANAPHYLAXIS_FLAG = New TextField("", "U")
    ANAPHYLAXIS_FLAGItems = New ItemCollection()
    lbDiagnosedConditions = New TextField("", Nothing)
    lbDiagnosedConditionsItems = New ItemCollection()
    STUDENT_ID = New FloatField("", Nothing)
    Link_DiagnosisConfirmed = New TextField("",Nothing)
    Link_DiagnosisConfirmedHrefParameters = New LinkParameterCollection()
    DIAGNOSED_ASTHMA = New IntegerField("", 0)
    DIAGNOSED_ASTHMAItems = New ItemCollection()
    MANAGE_PLAN_ASTHMA = New IntegerField("", 0)
    MANAGE_PLAN_ASTHMAItems = New ItemCollection()
    DIAGNOSED_DIABETES = New IntegerField("", 0)
    DIAGNOSED_DIABETESItems = New ItemCollection()
    MANAGE_PLAN_DIABETES = New IntegerField("", 0)
    MANAGE_PLAN_DIABETESItems = New ItemCollection()
    DIAGNOSED_EPILEPSY = New IntegerField("", 0)
    DIAGNOSED_EPILEPSYItems = New ItemCollection()
    MANAGE_PLAN_EPILEPSY = New IntegerField("", 0)
    MANAGE_PLAN_EPILEPSYItems = New ItemCollection()
    PSD_FUNDING_LEVEL = New TextField("", "")
    PSD_FUNDING_LEVELItems = New ItemCollection()
    PSD_FUNDING_ASSESSED = New IntegerField("", Nothing)
    PSD_FUNDING_ASSESSEDItems = New ItemCollection()
    NCCD_FUNDING_ELIGIBLE = New IntegerField("", Nothing)
    NCCD_FUNDING_ELIGIBLEItems = New ItemCollection()
    NCCD_FUNDING_CATEGORY = New IntegerField("", Nothing)
    NCCD_FUNDING_CATEGORYItems = New ItemCollection()
    NCCD_FUNDING_LEVEL = New IntegerField("", Nothing)
    NCCD_FUNDING_LEVELItems = New ItemCollection()
    DI_ASSESSED = New IntegerField("", Nothing)
    DI_ASSESSEDItems = New ItemCollection()
    DI_APPROVED = New IntegerField("", Nothing)
    DI_APPROVEDItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_MEDICAL_DETAILSItem
        Dim item As STUDENT_MEDICAL_DETAILSItem = New STUDENT_MEDICAL_DETAILSItem()
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY")) Then
        item.hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE")) Then
        item.hidden_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_STUDENT_ID")) Then
        item.hidden_STUDENT_ID.SetValue(DBUtility.GetInitialValue("hidden_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HEARING")) Then
        item.HEARING.SetValue(DBUtility.GetInitialValue("HEARING"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("VISION")) Then
        item.VISION.SetValue(DBUtility.GetInitialValue("VISION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASDASPERGERS")) Then
        item.ASDASPERGERS.SetValue(DBUtility.GetInitialValue("ASDASPERGERS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("INTELLECTUAL")) Then
        item.INTELLECTUAL.SetValue(DBUtility.GetInitialValue("INTELLECTUAL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PHYSICAL")) Then
        item.PHYSICAL.SetValue(DBUtility.GetInitialValue("PHYSICAL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("BEHAVIOURAL")) Then
        item.BEHAVIOURAL.SetValue(DBUtility.GetInitialValue("BEHAVIOURAL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LANGUAGE")) Then
        item.LANGUAGE.SetValue(DBUtility.GetInitialValue("LANGUAGE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HASALLERGYHISTORY")) Then
        item.HASALLERGYHISTORY.SetValue(DBUtility.GetInitialValue("HASALLERGYHISTORY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ANAPHYLAXIS")) Then
        item.ANAPHYLAXIS.SetValue(DBUtility.GetInitialValue("ANAPHYLAXIS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HASOTHERCONDITIONS")) Then
        item.HASOTHERCONDITIONS.SetValue(DBUtility.GetInitialValue("HASOTHERCONDITIONS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("OTHERMEDICALISSUES")) Then
        item.OTHERMEDICALISSUES.SetValue(DBUtility.GetInitialValue("OTHERMEDICALISSUES"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ALLERGYHISTORY")) Then
        item.ALLERGYHISTORY.SetValue(DBUtility.GetInitialValue("ALLERGYHISTORY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("OTHERCONDITIONS")) Then
        item.OTHERCONDITIONS.SetValue(DBUtility.GetInitialValue("OTHERCONDITIONS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MENTALHEALTH")) Then
        item.MENTALHEALTH.SetValue(DBUtility.GetInitialValue("MENTALHEALTH"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MENTALHEALTH_HISTORY")) Then
        item.MENTALHEALTH_HISTORY.SetValue(DBUtility.GetInitialValue("MENTALHEALTH_HISTORY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES")) Then
        item.hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.SetValue(DBUtility.GetInitialValue("hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbPSD_FUNDING_CATEGORY")) Then
        item.cbPSD_FUNDING_CATEGORY.SetValue(DBUtility.GetInitialValue("cbPSD_FUNDING_CATEGORY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PSD_FUNDING_OTHER")) Then
        item.PSD_FUNDING_OTHER.SetValue(DBUtility.GetInitialValue("PSD_FUNDING_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PSD_FUNDING_ELIGIBLE")) Then
        item.PSD_FUNDING_ELIGIBLE.SetValue(DBUtility.GetInitialValue("PSD_FUNDING_ELIGIBLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_PSD_FUNDING_CATEGORY")) Then
        item.hidden_PSD_FUNDING_CATEGORY.SetValue(DBUtility.GetInitialValue("hidden_PSD_FUNDING_CATEGORY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbRECEIVED_SUPPORT_PROGRAMS_SERVICES")) Then
        item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICES.SetValue(DBUtility.GetInitialValue("cbRECEIVED_SUPPORT_PROGRAMS_SERVICES"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER")) Then
        item.RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER.SetValue(DBUtility.GetInitialValue("RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ALLERGIES_FLAG")) Then
        item.ALLERGIES_FLAG.SetValue(DBUtility.GetInitialValue("ALLERGIES_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ANAPHYLAXIS_FLAG")) Then
        item.ANAPHYLAXIS_FLAG.SetValue(DBUtility.GetInitialValue("ANAPHYLAXIS_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbDiagnosedConditions")) Then
        item.lbDiagnosedConditions.SetValue(DBUtility.GetInitialValue("lbDiagnosedConditions"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link_DiagnosisConfirmed")) Then
        item.Link_DiagnosisConfirmed.SetValue(DBUtility.GetInitialValue("Link_DiagnosisConfirmed"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DIAGNOSED_ASTHMA")) Then
        item.DIAGNOSED_ASTHMA.SetValue(DBUtility.GetInitialValue("DIAGNOSED_ASTHMA"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MANAGE_PLAN_ASTHMA")) Then
        item.MANAGE_PLAN_ASTHMA.SetValue(DBUtility.GetInitialValue("MANAGE_PLAN_ASTHMA"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DIAGNOSED_DIABETES")) Then
        item.DIAGNOSED_DIABETES.SetValue(DBUtility.GetInitialValue("DIAGNOSED_DIABETES"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MANAGE_PLAN_DIABETES")) Then
        item.MANAGE_PLAN_DIABETES.SetValue(DBUtility.GetInitialValue("MANAGE_PLAN_DIABETES"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DIAGNOSED_EPILEPSY")) Then
        item.DIAGNOSED_EPILEPSY.SetValue(DBUtility.GetInitialValue("DIAGNOSED_EPILEPSY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MANAGE_PLAN_EPILEPSY")) Then
        item.MANAGE_PLAN_EPILEPSY.SetValue(DBUtility.GetInitialValue("MANAGE_PLAN_EPILEPSY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PSD_FUNDING_LEVEL")) Then
        item.PSD_FUNDING_LEVEL.SetValue(DBUtility.GetInitialValue("PSD_FUNDING_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PSD_FUNDING_ASSESSED")) Then
        item.PSD_FUNDING_ASSESSED.SetValue(DBUtility.GetInitialValue("PSD_FUNDING_ASSESSED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("NCCD_FUNDING_ELIGIBLE")) Then
        item.NCCD_FUNDING_ELIGIBLE.SetValue(DBUtility.GetInitialValue("NCCD_FUNDING_ELIGIBLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("NCCD_FUNDING_CATEGORY")) Then
        item.NCCD_FUNDING_CATEGORY.SetValue(DBUtility.GetInitialValue("NCCD_FUNDING_CATEGORY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("NCCD_FUNDING_LEVEL")) Then
        item.NCCD_FUNDING_LEVEL.SetValue(DBUtility.GetInitialValue("NCCD_FUNDING_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DI_ASSESSED")) Then
        item.DI_ASSESSED.SetValue(DBUtility.GetInitialValue("DI_ASSESSED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DI_APPROVED")) Then
        item.DI_APPROVED.SetValue(DBUtility.GetInitialValue("DI_APPROVED"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "hidden_LAST_ALTERED_BY"
                    Return hidden_LAST_ALTERED_BY
                Case "hidden_LAST_ALTERED_DATE"
                    Return hidden_LAST_ALTERED_DATE
                Case "hidden_STUDENT_ID"
                    Return hidden_STUDENT_ID
                Case "HEARING"
                    Return HEARING
                Case "VISION"
                    Return VISION
                Case "ASDASPERGERS"
                    Return ASDASPERGERS
                Case "INTELLECTUAL"
                    Return INTELLECTUAL
                Case "PHYSICAL"
                    Return PHYSICAL
                Case "BEHAVIOURAL"
                    Return BEHAVIOURAL
                Case "LANGUAGE"
                    Return LANGUAGE
                Case "HASALLERGYHISTORY"
                    Return HASALLERGYHISTORY
                Case "ANAPHYLAXIS"
                    Return ANAPHYLAXIS
                Case "HASOTHERCONDITIONS"
                    Return HASOTHERCONDITIONS
                Case "OTHERMEDICALISSUES"
                    Return OTHERMEDICALISSUES
                Case "ALLERGYHISTORY"
                    Return ALLERGYHISTORY
                Case "OTHERCONDITIONS"
                    Return OTHERCONDITIONS
                Case "MENTALHEALTH"
                    Return MENTALHEALTH
                Case "MENTALHEALTH_HISTORY"
                    Return MENTALHEALTH_HISTORY
                Case "hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES"
                    Return hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES
                Case "cbPSD_FUNDING_CATEGORY"
                    Return cbPSD_FUNDING_CATEGORY
                Case "PSD_FUNDING_OTHER"
                    Return PSD_FUNDING_OTHER
                Case "PSD_FUNDING_ELIGIBLE"
                    Return PSD_FUNDING_ELIGIBLE
                Case "hidden_PSD_FUNDING_CATEGORY"
                    Return hidden_PSD_FUNDING_CATEGORY
                Case "cbRECEIVED_SUPPORT_PROGRAMS_SERVICES"
                    Return cbRECEIVED_SUPPORT_PROGRAMS_SERVICES
                Case "RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER"
                    Return RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER
                Case "ALLERGIES_FLAG"
                    Return ALLERGIES_FLAG
                Case "ANAPHYLAXIS_FLAG"
                    Return ANAPHYLAXIS_FLAG
                Case "lbDiagnosedConditions"
                    Return lbDiagnosedConditions
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "Link_DiagnosisConfirmed"
                    Return Link_DiagnosisConfirmed
                Case "DIAGNOSED_ASTHMA"
                    Return DIAGNOSED_ASTHMA
                Case "MANAGE_PLAN_ASTHMA"
                    Return MANAGE_PLAN_ASTHMA
                Case "DIAGNOSED_DIABETES"
                    Return DIAGNOSED_DIABETES
                Case "MANAGE_PLAN_DIABETES"
                    Return MANAGE_PLAN_DIABETES
                Case "DIAGNOSED_EPILEPSY"
                    Return DIAGNOSED_EPILEPSY
                Case "MANAGE_PLAN_EPILEPSY"
                    Return MANAGE_PLAN_EPILEPSY
                Case "PSD_FUNDING_LEVEL"
                    Return PSD_FUNDING_LEVEL
                Case "PSD_FUNDING_ASSESSED"
                    Return PSD_FUNDING_ASSESSED
                Case "NCCD_FUNDING_ELIGIBLE"
                    Return NCCD_FUNDING_ELIGIBLE
                Case "NCCD_FUNDING_CATEGORY"
                    Return NCCD_FUNDING_CATEGORY
                Case "NCCD_FUNDING_LEVEL"
                    Return NCCD_FUNDING_LEVEL
                Case "DI_ASSESSED"
                    Return DI_ASSESSED
                Case "DI_APPROVED"
                    Return DI_APPROVED
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "hidden_LAST_ALTERED_BY"
                    hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "hidden_LAST_ALTERED_DATE"
                    hidden_LAST_ALTERED_DATE = CType(value, DateField)
                Case "hidden_STUDENT_ID"
                    hidden_STUDENT_ID = CType(value, TextField)
                Case "HEARING"
                    HEARING = CType(value, IntegerField)
                Case "VISION"
                    VISION = CType(value, IntegerField)
                Case "ASDASPERGERS"
                    ASDASPERGERS = CType(value, IntegerField)
                Case "INTELLECTUAL"
                    INTELLECTUAL = CType(value, IntegerField)
                Case "PHYSICAL"
                    PHYSICAL = CType(value, IntegerField)
                Case "BEHAVIOURAL"
                    BEHAVIOURAL = CType(value, IntegerField)
                Case "LANGUAGE"
                    LANGUAGE = CType(value, IntegerField)
                Case "HASALLERGYHISTORY"
                    HASALLERGYHISTORY = CType(value, IntegerField)
                Case "ANAPHYLAXIS"
                    ANAPHYLAXIS = CType(value, IntegerField)
                Case "HASOTHERCONDITIONS"
                    HASOTHERCONDITIONS = CType(value, IntegerField)
                Case "OTHERMEDICALISSUES"
                    OTHERMEDICALISSUES = CType(value, TextField)
                Case "ALLERGYHISTORY"
                    ALLERGYHISTORY = CType(value, TextField)
                Case "OTHERCONDITIONS"
                    OTHERCONDITIONS = CType(value, TextField)
                Case "MENTALHEALTH"
                    MENTALHEALTH = CType(value, IntegerField)
                Case "MENTALHEALTH_HISTORY"
                    MENTALHEALTH_HISTORY = CType(value, TextField)
                Case "hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES"
                    hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES = CType(value, TextField)
                Case "cbPSD_FUNDING_CATEGORY"
                    cbPSD_FUNDING_CATEGORY = CType(value, TextField)
                Case "PSD_FUNDING_OTHER"
                    PSD_FUNDING_OTHER = CType(value, TextField)
                Case "PSD_FUNDING_ELIGIBLE"
                    PSD_FUNDING_ELIGIBLE = CType(value, IntegerField)
                Case "hidden_PSD_FUNDING_CATEGORY"
                    hidden_PSD_FUNDING_CATEGORY = CType(value, TextField)
                Case "cbRECEIVED_SUPPORT_PROGRAMS_SERVICES"
                    cbRECEIVED_SUPPORT_PROGRAMS_SERVICES = CType(value, TextField)
                Case "RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER"
                    RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER = CType(value, TextField)
                Case "ALLERGIES_FLAG"
                    ALLERGIES_FLAG = CType(value, TextField)
                Case "ANAPHYLAXIS_FLAG"
                    ANAPHYLAXIS_FLAG = CType(value, TextField)
                Case "lbDiagnosedConditions"
                    lbDiagnosedConditions = CType(value, TextField)
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "Link_DiagnosisConfirmed"
                    Link_DiagnosisConfirmed = CType(value, TextField)
                Case "DIAGNOSED_ASTHMA"
                    DIAGNOSED_ASTHMA = CType(value, IntegerField)
                Case "MANAGE_PLAN_ASTHMA"
                    MANAGE_PLAN_ASTHMA = CType(value, IntegerField)
                Case "DIAGNOSED_DIABETES"
                    DIAGNOSED_DIABETES = CType(value, IntegerField)
                Case "MANAGE_PLAN_DIABETES"
                    MANAGE_PLAN_DIABETES = CType(value, IntegerField)
                Case "DIAGNOSED_EPILEPSY"
                    DIAGNOSED_EPILEPSY = CType(value, IntegerField)
                Case "MANAGE_PLAN_EPILEPSY"
                    MANAGE_PLAN_EPILEPSY = CType(value, IntegerField)
                Case "PSD_FUNDING_LEVEL"
                    PSD_FUNDING_LEVEL = CType(value, TextField)
                Case "PSD_FUNDING_ASSESSED"
                    PSD_FUNDING_ASSESSED = CType(value, IntegerField)
                Case "NCCD_FUNDING_ELIGIBLE"
                    NCCD_FUNDING_ELIGIBLE = CType(value, IntegerField)
                Case "NCCD_FUNDING_CATEGORY"
                    NCCD_FUNDING_CATEGORY = CType(value, IntegerField)
                Case "NCCD_FUNDING_LEVEL"
                    NCCD_FUNDING_LEVEL = CType(value, IntegerField)
                Case "DI_ASSESSED"
                    DI_ASSESSED = CType(value, IntegerField)
                Case "DI_APPROVED"
                    DI_APPROVED = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As STUDENT_MEDICAL_DETAILSDataProvider)
'End Record STUDENT_MEDICAL_DETAILS Item Class

'HEARING validate @34-1DF676D6
        If IsNothing(HEARING.Value) OrElse HEARING.Value.ToString() ="" Then
            errors.Add("HEARING",String.Format(Resources.strings.CCS_RequiredField,"Deaf or Hearing Impaired"))
        End If
'End HEARING validate

'VISION validate @35-67989476
        If IsNothing(VISION.Value) OrElse VISION.Value.ToString() ="" Then
            errors.Add("VISION",String.Format(Resources.strings.CCS_RequiredField,"Blind or Vision Impaired"))
        End If
'End VISION validate

'ASDASPERGERS validate @36-40FB0E62
        If IsNothing(ASDASPERGERS.Value) OrElse ASDASPERGERS.Value.ToString() ="" Then
            errors.Add("ASDASPERGERS",String.Format(Resources.strings.CCS_RequiredField,"Diagnosed with ASD/Aspergers"))
        End If
'End ASDASPERGERS validate

'INTELLECTUAL validate @37-C47335BF
        If IsNothing(INTELLECTUAL.Value) OrElse INTELLECTUAL.Value.ToString() ="" Then
            errors.Add("INTELLECTUAL",String.Format(Resources.strings.CCS_RequiredField,"Intellectual Disability"))
        End If
'End INTELLECTUAL validate

'PHYSICAL validate @38-52407137
        If IsNothing(PHYSICAL.Value) OrElse PHYSICAL.Value.ToString() ="" Then
            errors.Add("PHYSICAL",String.Format(Resources.strings.CCS_RequiredField,"Physical Disability"))
        End If
'End PHYSICAL validate

'BEHAVIOURAL validate @39-C50376FB
        If IsNothing(BEHAVIOURAL.Value) OrElse BEHAVIOURAL.Value.ToString() ="" Then
            errors.Add("BEHAVIOURAL",String.Format(Resources.strings.CCS_RequiredField,"Severe Behavioural Disorder"))
        End If
'End BEHAVIOURAL validate

'LANGUAGE validate @40-DECEC8D0
        If IsNothing(LANGUAGE.Value) OrElse LANGUAGE.Value.ToString() ="" Then
            errors.Add("LANGUAGE",String.Format(Resources.strings.CCS_RequiredField,"Severe Language Disorder"))
        End If
'End LANGUAGE validate

'HASALLERGYHISTORY validate @41-97B70C2D
        If IsNothing(HASALLERGYHISTORY.Value) OrElse HASALLERGYHISTORY.Value.ToString() ="" Then
            errors.Add("HASALLERGYHISTORY",String.Format(Resources.strings.CCS_RequiredField,"History of Allergies"))
        End If
'End HASALLERGYHISTORY validate

'ANAPHYLAXIS validate @42-6191BEFF
        If IsNothing(ANAPHYLAXIS.Value) OrElse ANAPHYLAXIS.Value.ToString() ="" Then
            errors.Add("ANAPHYLAXIS",String.Format(Resources.strings.CCS_RequiredField,"Diagnosed at Risk of Anaphylaxis"))
        End If
'End ANAPHYLAXIS validate

'HASOTHERCONDITIONS validate @43-E0B4AED9
        If IsNothing(HASOTHERCONDITIONS.Value) OrElse HASOTHERCONDITIONS.Value.ToString() ="" Then
            errors.Add("HASOTHERCONDITIONS",String.Format(Resources.strings.CCS_RequiredField,"Diagnosed with any other condition"))
        End If
'End HASOTHERCONDITIONS validate

'MENTALHEALTH validate @52-E9E4EE4D
        If IsNothing(MENTALHEALTH.Value) OrElse MENTALHEALTH.Value.ToString() ="" Then
            errors.Add("MENTALHEALTH",String.Format(Resources.strings.CCS_RequiredField,"Mental Health Condition?"))
        End If
'End MENTALHEALTH validate

'ALLERGIES_FLAG validate @21-3C844FB7
        If IsNothing(ALLERGIES_FLAG.Value) OrElse ALLERGIES_FLAG.Value.ToString() ="" Then
            errors.Add("ALLERGIES_FLAG",String.Format(Resources.strings.CCS_RequiredField,"Allergies"))
        End If
'End ALLERGIES_FLAG validate

'ANAPHYLAXIS_FLAG validate @22-54594E88
        If IsNothing(ANAPHYLAXIS_FLAG.Value) OrElse ANAPHYLAXIS_FLAG.Value.ToString() ="" Then
            errors.Add("ANAPHYLAXIS_FLAG",String.Format(Resources.strings.CCS_RequiredField,"Anaphylaxis"))
        End If
'End ANAPHYLAXIS_FLAG validate

'DIAGNOSED_ASTHMA validate @125-67336A44
        If IsNothing(DIAGNOSED_ASTHMA.Value) OrElse DIAGNOSED_ASTHMA.Value.ToString() ="" Then
            errors.Add("DIAGNOSED_ASTHMA",String.Format(Resources.strings.CCS_RequiredField,"Student Diagnosed with Asthma"))
        End If
'End DIAGNOSED_ASTHMA validate

'MANAGE_PLAN_ASTHMA validate @126-2A4ACF72
        If IsNothing(MANAGE_PLAN_ASTHMA.Value) OrElse MANAGE_PLAN_ASTHMA.Value.ToString() ="" Then
            errors.Add("MANAGE_PLAN_ASTHMA",String.Format(Resources.strings.CCS_RequiredField,"Diagnosed Asthma - Management Plan?"))
        End If
'End MANAGE_PLAN_ASTHMA validate

'DIAGNOSED_DIABETES validate @131-815B2375
        If IsNothing(DIAGNOSED_DIABETES.Value) OrElse DIAGNOSED_DIABETES.Value.ToString() ="" Then
            errors.Add("DIAGNOSED_DIABETES",String.Format(Resources.strings.CCS_RequiredField,"Student Diagnosed with Diabetes"))
        End If
'End DIAGNOSED_DIABETES validate

'MANAGE_PLAN_DIABETES validate @133-F5759B0F
        If IsNothing(MANAGE_PLAN_DIABETES.Value) OrElse MANAGE_PLAN_DIABETES.Value.ToString() ="" Then
            errors.Add("MANAGE_PLAN_DIABETES",String.Format(Resources.strings.CCS_RequiredField,"Diagnosed Diabetes - Management Plan?"))
        End If
'End MANAGE_PLAN_DIABETES validate

'DIAGNOSED_EPILEPSY validate @134-F11BA076
        If IsNothing(DIAGNOSED_EPILEPSY.Value) OrElse DIAGNOSED_EPILEPSY.Value.ToString() ="" Then
            errors.Add("DIAGNOSED_EPILEPSY",String.Format(Resources.strings.CCS_RequiredField,"Student Diagnosed with Epilepsy"))
        End If
'End DIAGNOSED_EPILEPSY validate

'MANAGE_PLAN_EPILEPSY validate @136-5C2BFCE8
        If IsNothing(MANAGE_PLAN_EPILEPSY.Value) OrElse MANAGE_PLAN_EPILEPSY.Value.ToString() ="" Then
            errors.Add("MANAGE_PLAN_EPILEPSY",String.Format(Resources.strings.CCS_RequiredField,"Diagnosed Epilepsy - Management Plan?"))
        End If
'End MANAGE_PLAN_EPILEPSY validate

'Record STUDENT_MEDICAL_DETAILS Item Class tail @3-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_MEDICAL_DETAILS Item Class tail

'Record STUDENT_MEDICAL_DETAILS Data Provider Class @3-0F5900EE
Public Class STUDENT_MEDICAL_DETAILSDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_MEDICAL_DETAILS Data Provider Class

'Record STUDENT_MEDICAL_DETAILS Data Provider Class Variables @3-C5947F6E
    Protected NCCD_FUNDING_CATEGORYDataCommand As DataCommand=new SqlCommand("select" & vbCrLf & _
          "   vnfc.NCCDFundingCategoryValue," & vbCrLf & _
          "   vnfc.NCCDFundingCategoryDisplayText" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.vwNCCDFundingCategory as vnfc;",Settings.connDECVPRODSQL2005DataAccessObject)
    Protected NCCD_FUNDING_LEVELDataCommand As DataCommand=new SqlCommand("select" & vbCrLf & _
          "   vnfl.NCCDFundingLevelValue," & vbCrLf & _
          "   vnfl.NCCDFundingLevelDisplayText" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.vwNCCDFundingLevel as vnfl;",Settings.connDECVPRODSQL2005DataAccessObject)
    Public UrlSTUDENT_ID As FloatParameter
    Protected item As STUDENT_MEDICAL_DETAILSItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_MEDICAL_DETAILS Data Provider Class Variables

'Record STUDENT_MEDICAL_DETAILS Data Provider Class Constructor @3-ACE0A3A2

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_MEDICAL_DETAILS {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID128"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_MEDICAL_DETAILS Data Provider Class Constructor

'Record STUDENT_MEDICAL_DETAILS Data Provider Class LoadParams Method @3-A977A0E9

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID))
    End Function
'End Record STUDENT_MEDICAL_DETAILS Data Provider Class LoadParams Method

'Record STUDENT_MEDICAL_DETAILS Data Provider Class CheckUnique Method @3-96E000EB

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_MEDICAL_DETAILSItem) As Boolean
        Return True
    End Function
'End Record STUDENT_MEDICAL_DETAILS Data Provider Class CheckUnique Method

'Record STUDENT_MEDICAL_DETAILS Data Provider Class PrepareUpdate Method @3-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT_MEDICAL_DETAILS Data Provider Class PrepareUpdate Method

'Record STUDENT_MEDICAL_DETAILS Data Provider Class PrepareUpdate Method tail @3-E31F8E2A
    End Sub
'End Record STUDENT_MEDICAL_DETAILS Data Provider Class PrepareUpdate Method tail

'Record STUDENT_MEDICAL_DETAILS Data Provider Class Update Method @3-970AF2F0

    Public Function UpdateItem(ByVal item As STUDENT_MEDICAL_DETAILSItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_MEDICAL_DETAILS SET {Values}", New String(){"STUDENT_ID128"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_MEDICAL_DETAILS Data Provider Class Update Method

'Record STUDENT_MEDICAL_DETAILS Event BeforeBuildUpdate. Action Custom Code @270-73254650
      ' 17 Mar 2022|RW| Force updates for the radio buttons that we may want to be resettable, especially between enrolment years.
      '                 CodeCharge Studio's default behaviour for unselected radio buttons is to skip the update for them instead of updating them to null.
      item.PSD_FUNDING_ASSESSED.IsEmpty = False
      item.PSD_FUNDING_ELIGIBLE.IsEmpty = False
      item.PSD_FUNDING_LEVEL.IsEmpty = False
      item.NCCD_FUNDING_ELIGIBLE.IsEmpty = False
      item.NCCD_FUNDING_CATEGORY.IsEmpty = False
      item.NCCD_FUNDING_LEVEL.IsEmpty = False
'End Record STUDENT_MEDICAL_DETAILS Event BeforeBuildUpdate. Action Custom Code

'Record STUDENT_MEDICAL_DETAILS BeforeBuildUpdate @3-FCDED12F
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID128",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If Not item.hidden_LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.hidden_LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.hidden_STUDENT_ID.IsEmpty Then
        allEmptyFlag = item.hidden_STUDENT_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_ID=" + Update.Dao.ToSql(item.hidden_STUDENT_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.HEARING.IsEmpty Then
        allEmptyFlag = item.HEARING.IsEmpty And allEmptyFlag
        valuesList = valuesList & "HEARING=" + Update.Dao.ToSql(item.HEARING.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.VISION.IsEmpty Then
        allEmptyFlag = item.VISION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "VISION=" + Update.Dao.ToSql(item.VISION.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.ASDASPERGERS.IsEmpty Then
        allEmptyFlag = item.ASDASPERGERS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASDASPERGERS=" + Update.Dao.ToSql(item.ASDASPERGERS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.INTELLECTUAL.IsEmpty Then
        allEmptyFlag = item.INTELLECTUAL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "INTELLECTUAL=" + Update.Dao.ToSql(item.INTELLECTUAL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.PHYSICAL.IsEmpty Then
        allEmptyFlag = item.PHYSICAL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PHYSICAL=" + Update.Dao.ToSql(item.PHYSICAL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.BEHAVIOURAL.IsEmpty Then
        allEmptyFlag = item.BEHAVIOURAL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "BEHAVIOURAL=" + Update.Dao.ToSql(item.BEHAVIOURAL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.LANGUAGE.IsEmpty Then
        allEmptyFlag = item.LANGUAGE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LANGUAGE=" + Update.Dao.ToSql(item.LANGUAGE.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.HASALLERGYHISTORY.IsEmpty Then
        allEmptyFlag = item.HASALLERGYHISTORY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "HASALLERGYHISTORY=" + Update.Dao.ToSql(item.HASALLERGYHISTORY.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.ANAPHYLAXIS.IsEmpty Then
        allEmptyFlag = item.ANAPHYLAXIS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ANAPHYLAXIS=" + Update.Dao.ToSql(item.ANAPHYLAXIS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.HASOTHERCONDITIONS.IsEmpty Then
        allEmptyFlag = item.HASOTHERCONDITIONS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "HASOTHERCONDITIONS=" + Update.Dao.ToSql(item.HASOTHERCONDITIONS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.OTHERMEDICALISSUES.IsEmpty Then
        allEmptyFlag = item.OTHERMEDICALISSUES.IsEmpty And allEmptyFlag
        valuesList = valuesList & "OTHERMEDICALISSUES=" + Update.Dao.ToSql(item.OTHERMEDICALISSUES.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ALLERGYHISTORY.IsEmpty Then
        allEmptyFlag = item.ALLERGYHISTORY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ALLERGYHISTORY=" + Update.Dao.ToSql(item.ALLERGYHISTORY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.OTHERCONDITIONS.IsEmpty Then
        allEmptyFlag = item.OTHERCONDITIONS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "OTHERCONDITIONS=" + Update.Dao.ToSql(item.OTHERCONDITIONS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.MENTALHEALTH.IsEmpty Then
        allEmptyFlag = item.MENTALHEALTH.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MENTALHEALTH=" + Update.Dao.ToSql(item.MENTALHEALTH.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.MENTALHEALTH_HISTORY.IsEmpty Then
        allEmptyFlag = item.MENTALHEALTH_HISTORY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MENTALHEALTH_HISTORY=" + Update.Dao.ToSql(item.MENTALHEALTH_HISTORY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.IsEmpty Then
        allEmptyFlag = item.hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RECEIVED_SUPPORT_PROGRAMS_SERVICES=" + Update.Dao.ToSql(item.hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PSD_FUNDING_OTHER.IsEmpty Then
        allEmptyFlag = item.PSD_FUNDING_OTHER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PSD_FUNDING_OTHER=" + Update.Dao.ToSql(item.PSD_FUNDING_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PSD_FUNDING_ELIGIBLE.IsEmpty Then
        allEmptyFlag = item.PSD_FUNDING_ELIGIBLE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PSD_FUNDING_ELIGIBLE=" + Update.Dao.ToSql(item.PSD_FUNDING_ELIGIBLE.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.hidden_PSD_FUNDING_CATEGORY.IsEmpty Then
        allEmptyFlag = item.hidden_PSD_FUNDING_CATEGORY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PSD_FUNDING_CATEGORY=" + Update.Dao.ToSql(item.hidden_PSD_FUNDING_CATEGORY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER.IsEmpty Then
        allEmptyFlag = item.RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER=" + Update.Dao.ToSql(item.RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ALLERGIES_FLAG.IsEmpty Then
        allEmptyFlag = item.ALLERGIES_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ALLERGIES_FLAG=" + Update.Dao.ToSql(item.ALLERGIES_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ANAPHYLAXIS_FLAG.IsEmpty Then
        allEmptyFlag = item.ANAPHYLAXIS_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ANAPHYLAXIS_FLAG=" + Update.Dao.ToSql(item.ANAPHYLAXIS_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.lbDiagnosedConditions.IsEmpty Then
        allEmptyFlag = item.lbDiagnosedConditions.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DIAGNOSED_CONDITION=" + Update.Dao.ToSql(item.lbDiagnosedConditions.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DIAGNOSED_ASTHMA.IsEmpty Then
        allEmptyFlag = item.DIAGNOSED_ASTHMA.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DIAGNOSED_ASTHMA=" + Update.Dao.ToSql(item.DIAGNOSED_ASTHMA.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.MANAGE_PLAN_ASTHMA.IsEmpty Then
        allEmptyFlag = item.MANAGE_PLAN_ASTHMA.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MANAGE_PLAN_ASTHMA=" + Update.Dao.ToSql(item.MANAGE_PLAN_ASTHMA.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.DIAGNOSED_DIABETES.IsEmpty Then
        allEmptyFlag = item.DIAGNOSED_DIABETES.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DIAGNOSED_DIABETES=" + Update.Dao.ToSql(item.DIAGNOSED_DIABETES.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.MANAGE_PLAN_DIABETES.IsEmpty Then
        allEmptyFlag = item.MANAGE_PLAN_DIABETES.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MANAGE_PLAN_DIABETES=" + Update.Dao.ToSql(item.MANAGE_PLAN_DIABETES.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.DIAGNOSED_EPILEPSY.IsEmpty Then
        allEmptyFlag = item.DIAGNOSED_EPILEPSY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DIAGNOSED_EPILEPSY=" + Update.Dao.ToSql(item.DIAGNOSED_EPILEPSY.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.MANAGE_PLAN_EPILEPSY.IsEmpty Then
        allEmptyFlag = item.MANAGE_PLAN_EPILEPSY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MANAGE_PLAN_EPILEPSY=" + Update.Dao.ToSql(item.MANAGE_PLAN_EPILEPSY.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.PSD_FUNDING_LEVEL.IsEmpty Then
        allEmptyFlag = item.PSD_FUNDING_LEVEL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PSD_FUNDING_LEVEL=" + Update.Dao.ToSql(item.PSD_FUNDING_LEVEL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PSD_FUNDING_ASSESSED.IsEmpty Then
        allEmptyFlag = item.PSD_FUNDING_ASSESSED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PSD_FUNDING_ASSESSED=" + Update.Dao.ToSql(item.PSD_FUNDING_ASSESSED.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.NCCD_FUNDING_ELIGIBLE.IsEmpty Then
        allEmptyFlag = item.NCCD_FUNDING_ELIGIBLE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "NCCD_FUNDING_APPROVED=" + Update.Dao.ToSql(item.NCCD_FUNDING_ELIGIBLE.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.NCCD_FUNDING_CATEGORY.IsEmpty Then
        allEmptyFlag = item.NCCD_FUNDING_CATEGORY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "NCCD_FUNDING_CATEGORY=" + Update.Dao.ToSql(item.NCCD_FUNDING_CATEGORY.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.NCCD_FUNDING_LEVEL.IsEmpty Then
        allEmptyFlag = item.NCCD_FUNDING_LEVEL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "NCCD_FUNDING_LEVEL=" + Update.Dao.ToSql(item.NCCD_FUNDING_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.DI_ASSESSED.IsEmpty Then
        allEmptyFlag = item.DI_ASSESSED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DI_FUNDING_ASSESSED=" + Update.Dao.ToSql(item.DI_ASSESSED.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.DI_APPROVED.IsEmpty Then
        allEmptyFlag = item.DI_APPROVED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DI_FUNDING_APPROVED=" + Update.Dao.ToSql(item.DI_APPROVED.GetFormattedValue(""),FieldType._Integer) & ","
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
             If Not allEmptyFlag Then result = ExecuteUpdate()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record STUDENT_MEDICAL_DETAILS BeforeBuildUpdate

'Record STUDENT_MEDICAL_DETAILS AfterExecuteUpdate @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_MEDICAL_DETAILS AfterExecuteUpdate

'Record STUDENT_MEDICAL_DETAILS Data Provider Class GetResultSet Method @3-042985D0

    Public Sub FillItem(ByVal item As STUDENT_MEDICAL_DETAILSItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_MEDICAL_DETAILS Data Provider Class GetResultSet Method

'Record STUDENT_MEDICAL_DETAILS BeforeBuildSelect @3-E4B5447D
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID128",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_MEDICAL_DETAILS BeforeBuildSelect

'Record STUDENT_MEDICAL_DETAILS BeforeExecuteSelect @3-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_MEDICAL_DETAILS BeforeExecuteSelect

'Record STUDENT_MEDICAL_DETAILS AfterExecuteSelect @3-7E879211
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.hidden_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.hidden_STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.HEARING.SetValue(dr(i)("HEARING"),"")
            item.VISION.SetValue(dr(i)("VISION"),"")
            item.ASDASPERGERS.SetValue(dr(i)("ASDASPERGERS"),"")
            item.INTELLECTUAL.SetValue(dr(i)("INTELLECTUAL"),"")
            item.PHYSICAL.SetValue(dr(i)("PHYSICAL"),"")
            item.BEHAVIOURAL.SetValue(dr(i)("BEHAVIOURAL"),"")
            item.LANGUAGE.SetValue(dr(i)("LANGUAGE"),"")
            item.HASALLERGYHISTORY.SetValue(dr(i)("HASALLERGYHISTORY"),"")
            item.ANAPHYLAXIS.SetValue(dr(i)("ANAPHYLAXIS"),"")
            item.HASOTHERCONDITIONS.SetValue(dr(i)("HASOTHERCONDITIONS"),"")
            item.OTHERMEDICALISSUES.SetValue(dr(i)("OTHERMEDICALISSUES"),"")
            item.ALLERGYHISTORY.SetValue(dr(i)("ALLERGYHISTORY"),"")
            item.OTHERCONDITIONS.SetValue(dr(i)("OTHERCONDITIONS"),"")
            item.MENTALHEALTH.SetValue(dr(i)("MENTALHEALTH"),"")
            item.MENTALHEALTH_HISTORY.SetValue(dr(i)("MENTALHEALTH_HISTORY"),"")
            item.hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.SetValue(dr(i)("RECEIVED_SUPPORT_PROGRAMS_SERVICES"),"")
            item.PSD_FUNDING_OTHER.SetValue(dr(i)("PSD_FUNDING_OTHER"),"")
            item.PSD_FUNDING_ELIGIBLE.SetValue(dr(i)("PSD_FUNDING_ELIGIBLE"),"")
            item.hidden_PSD_FUNDING_CATEGORY.SetValue(dr(i)("PSD_FUNDING_CATEGORY"),"")
            item.RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER.SetValue(dr(i)("RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER"),"")
            item.ALLERGIES_FLAG.SetValue(dr(i)("ALLERGIES_FLAG"),"")
            item.ANAPHYLAXIS_FLAG.SetValue(dr(i)("ANAPHYLAXIS_FLAG"),"")
            item.lbDiagnosedConditions.SetValue(dr(i)("DIAGNOSED_CONDITION"),"")
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.Link_DiagnosisConfirmedHref = "Student_DiagnosisConfirmed_maintain.aspx"
            item.DIAGNOSED_ASTHMA.SetValue(dr(i)("DIAGNOSED_ASTHMA"),"")
            item.MANAGE_PLAN_ASTHMA.SetValue(dr(i)("MANAGE_PLAN_ASTHMA"),"")
            item.DIAGNOSED_DIABETES.SetValue(dr(i)("DIAGNOSED_DIABETES"),"")
            item.MANAGE_PLAN_DIABETES.SetValue(dr(i)("MANAGE_PLAN_DIABETES"),"")
            item.DIAGNOSED_EPILEPSY.SetValue(dr(i)("DIAGNOSED_EPILEPSY"),"")
            item.MANAGE_PLAN_EPILEPSY.SetValue(dr(i)("MANAGE_PLAN_EPILEPSY"),"")
            item.PSD_FUNDING_LEVEL.SetValue(dr(i)("PSD_FUNDING_LEVEL"),"")
            item.PSD_FUNDING_ASSESSED.SetValue(dr(i)("PSD_FUNDING_ASSESSED"),"")
            item.NCCD_FUNDING_ELIGIBLE.SetValue(dr(i)("NCCD_FUNDING_APPROVED"),"")
            item.NCCD_FUNDING_CATEGORY.SetValue(dr(i)("NCCD_FUNDING_CATEGORY"),"")
            item.NCCD_FUNDING_LEVEL.SetValue(dr(i)("NCCD_FUNDING_LEVEL"),"")
            item.DI_ASSESSED.SetValue(dr(i)("DI_FUNDING_ASSESSED"),"")
            item.DI_APPROVED.SetValue(dr(i)("DI_FUNDING_APPROVED"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STUDENT_MEDICAL_DETAILS AfterExecuteSelect

'ListBox HEARING AfterExecuteSelect @34-089F1A9B
        
item.HEARINGItems.Add("0","No")
item.HEARINGItems.Add("1","Yes")
'End ListBox HEARING AfterExecuteSelect

'ListBox VISION AfterExecuteSelect @35-0D3AD418
        
item.VISIONItems.Add("0","No")
item.VISIONItems.Add("1","Yes")
'End ListBox VISION AfterExecuteSelect

'ListBox ASDASPERGERS AfterExecuteSelect @36-215FD634
        
item.ASDASPERGERSItems.Add("0","No")
item.ASDASPERGERSItems.Add("1","Yes")
'End ListBox ASDASPERGERS AfterExecuteSelect

'ListBox INTELLECTUAL AfterExecuteSelect @37-D81FE95E
        
item.INTELLECTUALItems.Add("0","No")
item.INTELLECTUALItems.Add("1","Yes")
'End ListBox INTELLECTUAL AfterExecuteSelect

'ListBox PHYSICAL AfterExecuteSelect @38-D3DE3FFF
        
item.PHYSICALItems.Add("0","No")
item.PHYSICALItems.Add("1","Yes")
'End ListBox PHYSICAL AfterExecuteSelect

'ListBox BEHAVIOURAL AfterExecuteSelect @39-442CEE77
        
item.BEHAVIOURALItems.Add("0","No")
item.BEHAVIOURALItems.Add("1","Yes")
'End ListBox BEHAVIOURAL AfterExecuteSelect

'ListBox LANGUAGE AfterExecuteSelect @40-2077EDB8
        
item.LANGUAGEItems.Add("0","No")
item.LANGUAGEItems.Add("1","Yes")
'End ListBox LANGUAGE AfterExecuteSelect

'ListBox HASALLERGYHISTORY AfterExecuteSelect @41-200AEB43
        
item.HASALLERGYHISTORYItems.Add("0","No")
item.HASALLERGYHISTORYItems.Add("1","Yes")
'End ListBox HASALLERGYHISTORY AfterExecuteSelect

'ListBox ANAPHYLAXIS AfterExecuteSelect @42-98098EB9
        
item.ANAPHYLAXISItems.Add("0","No")
item.ANAPHYLAXISItems.Add("1","Yes")
'End ListBox ANAPHYLAXIS AfterExecuteSelect

'ListBox HASOTHERCONDITIONS AfterExecuteSelect @43-C841355D
        
item.HASOTHERCONDITIONSItems.Add("0","No")
item.HASOTHERCONDITIONSItems.Add("1","Yes")
'End ListBox HASOTHERCONDITIONS AfterExecuteSelect

'ListBox MENTALHEALTH AfterExecuteSelect @52-F5F5CFF7
        
item.MENTALHEALTHItems.Add("0","No")
item.MENTALHEALTHItems.Add("1","Yes")
'End ListBox MENTALHEALTH AfterExecuteSelect

'ListBox cbPSD_FUNDING_CATEGORY AfterExecuteSelect @109-5604626F
        
item.cbPSD_FUNDING_CATEGORYItems.Add("Physical","Physical")
item.cbPSD_FUNDING_CATEGORYItems.Add("Visual Impairment","Visual Impairment")
item.cbPSD_FUNDING_CATEGORYItems.Add("Hearing Impairment","Hearing Impairment")
item.cbPSD_FUNDING_CATEGORYItems.Add("Severe Behaviour disorder","Severe Behaviour disorder")
item.cbPSD_FUNDING_CATEGORYItems.Add("Intellectual disability","Intellectual disability")
item.cbPSD_FUNDING_CATEGORYItems.Add("Autism Spectrum Disorder","Autism Spectrum Disorder")
item.cbPSD_FUNDING_CATEGORYItems.Add("Severe Language disorder","Severe Language disorder")
'End ListBox cbPSD_FUNDING_CATEGORY AfterExecuteSelect

'ListBox PSD_FUNDING_ELIGIBLE AfterExecuteSelect @111-E5621C8C
        
item.PSD_FUNDING_ELIGIBLEItems.Add("0","No")
item.PSD_FUNDING_ELIGIBLEItems.Add("1","Yes")
'End ListBox PSD_FUNDING_ELIGIBLE AfterExecuteSelect

'ListBox cbRECEIVED_SUPPORT_PROGRAMS_SERVICES AfterExecuteSelect @91-5C616EC9
        
item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.Add("PSD","Program for Students with Disabilities (PSD)")
item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.Add("Public Hospital Education","Public Hospital Education Setting")
item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.Add("HBESB","Home Based Education Support Program (HBESB)")
item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.Add("Visiting Teacher","Visiting Teacher Service ")
item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.Add("DHHS","DHHS")
item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.Add("Child First","Child First ")
item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.Add("CAMHS","Child and Adolescent Mental Health Service (CAMHS)")
item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.Add("DET Social","DET Social worker ")
item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.Add("DET Psychologist","DET Psychologist")
item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.Add("DET Speech","DET Speech Pathology ")
item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.Add("Navigator","Navigator")
item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.Add("Lookout Centre","Lookout Centre")
'End ListBox cbRECEIVED_SUPPORT_PROGRAMS_SERVICES AfterExecuteSelect

'ListBox ALLERGIES_FLAG AfterExecuteSelect @21-DAADA680
        
item.ALLERGIES_FLAGItems.Add("Y","Yes")
item.ALLERGIES_FLAGItems.Add("N","No")
item.ALLERGIES_FLAGItems.Add("U","Unknown")
'End ListBox ALLERGIES_FLAG AfterExecuteSelect

'ListBox ANAPHYLAXIS_FLAG AfterExecuteSelect @22-BF96D013
        
item.ANAPHYLAXIS_FLAGItems.Add("Y","Yes")
item.ANAPHYLAXIS_FLAGItems.Add("N","No")
item.ANAPHYLAXIS_FLAGItems.Add("U","Unknown")
'End ListBox ANAPHYLAXIS_FLAG AfterExecuteSelect

'ListBox lbDiagnosedConditions AfterExecuteSelect @26-7FC34724
        
item.lbDiagnosedConditionsItems.Add("ASD","ASD/Aspergers")
item.lbDiagnosedConditionsItems.Add("PDD-NOS","PDD-NOS")
item.lbDiagnosedConditionsItems.Add("Autism","Autism (do not use for new enrolments)")
item.lbDiagnosedConditionsItems.Add("Aspergers","Aspergers (do not use for new enrolments)")
'End ListBox lbDiagnosedConditions AfterExecuteSelect

'ListBox DIAGNOSED_ASTHMA AfterExecuteSelect @125-71CB60A1
        
item.DIAGNOSED_ASTHMAItems.Add("0","No")
item.DIAGNOSED_ASTHMAItems.Add("1","Yes")
'End ListBox DIAGNOSED_ASTHMA AfterExecuteSelect

'ListBox MANAGE_PLAN_ASTHMA AfterExecuteSelect @126-3341F8D0
        
item.MANAGE_PLAN_ASTHMAItems.Add("0","No")
item.MANAGE_PLAN_ASTHMAItems.Add("1","Yes")
'End ListBox MANAGE_PLAN_ASTHMA AfterExecuteSelect

'ListBox DIAGNOSED_DIABETES AfterExecuteSelect @131-C21392B7
        
item.DIAGNOSED_DIABETESItems.Add("0","No")
item.DIAGNOSED_DIABETESItems.Add("1","Yes")
'End ListBox DIAGNOSED_DIABETES AfterExecuteSelect

'ListBox MANAGE_PLAN_DIABETES AfterExecuteSelect @133-E63DEC3F
        
item.MANAGE_PLAN_DIABETESItems.Add("0","No")
item.MANAGE_PLAN_DIABETESItems.Add("1","Yes")
'End ListBox MANAGE_PLAN_DIABETES AfterExecuteSelect

'ListBox DIAGNOSED_EPILEPSY AfterExecuteSelect @134-0CAF519F
        
item.DIAGNOSED_EPILEPSYItems.Add("0","No")
item.DIAGNOSED_EPILEPSYItems.Add("1","Yes")
'End ListBox DIAGNOSED_EPILEPSY AfterExecuteSelect

'ListBox MANAGE_PLAN_EPILEPSY AfterExecuteSelect @136-9F940923
        
item.MANAGE_PLAN_EPILEPSYItems.Add("0","No")
item.MANAGE_PLAN_EPILEPSYItems.Add("1","Yes")
'End ListBox MANAGE_PLAN_EPILEPSY AfterExecuteSelect

'ListBox PSD_FUNDING_LEVEL AfterExecuteSelect @137-13754295
        
item.PSD_FUNDING_LEVELItems.Add("Level 1","Level 1")
item.PSD_FUNDING_LEVELItems.Add("Level 2","Level 2")
item.PSD_FUNDING_LEVELItems.Add("Level 3","Level 3")
item.PSD_FUNDING_LEVELItems.Add("Level 4","Level 4")
item.PSD_FUNDING_LEVELItems.Add("Level 5","Level 5")
item.PSD_FUNDING_LEVELItems.Add("Level 6","Level 6")
'End ListBox PSD_FUNDING_LEVEL AfterExecuteSelect

'ListBox PSD_FUNDING_ASSESSED AfterExecuteSelect @173-83A727BD
        
item.PSD_FUNDING_ASSESSEDItems.Add("0","No")
item.PSD_FUNDING_ASSESSEDItems.Add("1","Yes")
'End ListBox PSD_FUNDING_ASSESSED AfterExecuteSelect

'ListBox NCCD_FUNDING_ELIGIBLE AfterExecuteSelect @174-0EBA177A
        
item.NCCD_FUNDING_ELIGIBLEItems.Add("0","No")
item.NCCD_FUNDING_ELIGIBLEItems.Add("1","Yes")
'End ListBox NCCD_FUNDING_ELIGIBLE AfterExecuteSelect

'ListBox NCCD_FUNDING_CATEGORY Initialize Data Source @175-26E8EE49
        NCCD_FUNDING_CATEGORYDataCommand.Dao._optimized = False
        Dim NCCD_FUNDING_CATEGORYtableIndex As Integer = 0
        NCCD_FUNDING_CATEGORYDataCommand.OrderBy = ""
        NCCD_FUNDING_CATEGORYDataCommand.Parameters.Clear()
'End ListBox NCCD_FUNDING_CATEGORY Initialize Data Source

'ListBox NCCD_FUNDING_CATEGORY BeforeExecuteSelect @175-FCC4958E
        Try
            ListBoxSource=NCCD_FUNDING_CATEGORYDataCommand.Execute().Tables(NCCD_FUNDING_CATEGORYtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox NCCD_FUNDING_CATEGORY BeforeExecuteSelect

'ListBox NCCD_FUNDING_CATEGORY AfterExecuteSelect @175-DE6B33B8
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("NCCDFundingCategoryValue"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("NCCDFundingCategoryDisplayText")
            item.NCCD_FUNDING_CATEGORYItems.Add(Key, Val)
        Next
'End ListBox NCCD_FUNDING_CATEGORY AfterExecuteSelect

'ListBox NCCD_FUNDING_LEVEL Initialize Data Source @176-8AAAF294
        NCCD_FUNDING_LEVELDataCommand.Dao._optimized = False
        Dim NCCD_FUNDING_LEVELtableIndex As Integer = 0
        NCCD_FUNDING_LEVELDataCommand.OrderBy = ""
        NCCD_FUNDING_LEVELDataCommand.Parameters.Clear()
'End ListBox NCCD_FUNDING_LEVEL Initialize Data Source

'ListBox NCCD_FUNDING_LEVEL BeforeExecuteSelect @176-2B632C10
        Try
            ListBoxSource=NCCD_FUNDING_LEVELDataCommand.Execute().Tables(NCCD_FUNDING_LEVELtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox NCCD_FUNDING_LEVEL BeforeExecuteSelect

'ListBox NCCD_FUNDING_LEVEL AfterExecuteSelect @176-8F80F98C
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("NCCDFundingLevelValue"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("NCCDFundingLevelDisplayText")
            item.NCCD_FUNDING_LEVELItems.Add(Key, Val)
        Next
'End ListBox NCCD_FUNDING_LEVEL AfterExecuteSelect

'ListBox DI_ASSESSED AfterExecuteSelect @273-5BE0AF18
        
item.DI_ASSESSEDItems.Add("0","No")
item.DI_ASSESSEDItems.Add("1","Yes")
'End ListBox DI_ASSESSED AfterExecuteSelect

'ListBox DI_APPROVED AfterExecuteSelect @274-4CB7E5FF
        
item.DI_APPROVEDItems.Add("0","No")
item.DI_APPROVEDItems.Add("1","Yes")
'End ListBox DI_APPROVED AfterExecuteSelect

'Record STUDENT_MEDICAL_DETAILS AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record STUDENT_MEDICAL_DETAILS AfterExecuteSelect tail

'Record STUDENT_MEDICAL_DETAILS Data Provider Class @3-A61BA892
End Class

'End Record STUDENT_MEDICAL_DETAILS Data Provider Class

'Record STUDENT_MEDICAL_DETAILS1 Item Class @55-EFEDCFD9
Public Class STUDENT_MEDICAL_DETAILS1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public PRACTITIONER_ORGANISATION As TextField
    Public PRACTITIONER_DISCIPLINE As TextField
    Public PRACTITIONER_DISCIPLINEItems As ItemCollection
    Public PRACTITIONER_DISCIPLINE_OTHER As TextField
    Public PRACTITIONER_PRIMARY_ISSUES As TextField
    Public PRACTITIONER_PRIMARY_ISSUESItems As ItemCollection
    Public PRACTITIONER_PRIMARY_OTHER As TextField
    Public PRACTITIONER_LAST_MODIFIED_BY As TextField
    Public PRACTITIONER_LAST_MODIFIED_DATE As DateField
    Public Hidden_PRIMARY_ISSUES As TextField
    Public lblLAST_MODIFIED_BY As TextField
    Public lblLAST_MODIFIED_DATE As DateField
    Public PRACTITIONER_ORGTYPE As TextField
    Public PRACTITIONER_ORGTYPEItems As ItemCollection
    Public PRACTITIONER_ORGTYPE_OTHER As TextField
    Public Hidden_DISABILITIES As TextField
    Public PRACTITIONER_DISABILITIES As TextField
    Public PRACTITIONER_DISABILITIESItems As ItemCollection
    Public PRACTITIONER_DISABILITY_DETAILS As TextField
    Public PRACTITIONER_REC_CLASS_ATTENDANCE As TextField
    Public PRACTITIONER_REC_CLASS_ATTENDANCEItems As ItemCollection
    Public Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE As TextField
    Public PRACTITIONER_REC_WORKLOAD As TextField
    Public PRACTITIONER_REC_WORKLOADItems As ItemCollection
    Public PRACTITIONER_REC_CARER_AS_SUPERVISOR As IntegerField
    Public PRACTITIONER_REC_CARER_AS_SUPERVISORItems As ItemCollection
    Public Sub New()
    PRACTITIONER_ORGANISATION = New TextField("", Nothing)
    PRACTITIONER_DISCIPLINE = New TextField("", Nothing)
    PRACTITIONER_DISCIPLINEItems = New ItemCollection()
    PRACTITIONER_DISCIPLINE_OTHER = New TextField("", Nothing)
    PRACTITIONER_PRIMARY_ISSUES = New TextField("", Nothing)
    PRACTITIONER_PRIMARY_ISSUESItems = New ItemCollection()
    PRACTITIONER_PRIMARY_OTHER = New TextField("", Nothing)
    PRACTITIONER_LAST_MODIFIED_BY = New TextField("", Nothing)
    PRACTITIONER_LAST_MODIFIED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    Hidden_PRIMARY_ISSUES = New TextField("", "0,")
    lblLAST_MODIFIED_BY = New TextField("", Nothing)
    lblLAST_MODIFIED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    PRACTITIONER_ORGTYPE = New TextField("", "0,")
    PRACTITIONER_ORGTYPEItems = New ItemCollection()
    PRACTITIONER_ORGTYPE_OTHER = New TextField("", Nothing)
    Hidden_DISABILITIES = New TextField("", "0,")
    PRACTITIONER_DISABILITIES = New TextField("", Nothing)
    PRACTITIONER_DISABILITIESItems = New ItemCollection()
    PRACTITIONER_DISABILITY_DETAILS = New TextField("", Nothing)
    PRACTITIONER_REC_CLASS_ATTENDANCE = New TextField("", Nothing)
    PRACTITIONER_REC_CLASS_ATTENDANCEItems = New ItemCollection()
    Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE = New TextField("", "0,")
    PRACTITIONER_REC_WORKLOAD = New TextField("", Nothing)
    PRACTITIONER_REC_WORKLOADItems = New ItemCollection()
    PRACTITIONER_REC_CARER_AS_SUPERVISOR = New IntegerField("", Nothing)
    PRACTITIONER_REC_CARER_AS_SUPERVISORItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_MEDICAL_DETAILS1Item
        Dim item As STUDENT_MEDICAL_DETAILS1Item = New STUDENT_MEDICAL_DETAILS1Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_ORGANISATION")) Then
        item.PRACTITIONER_ORGANISATION.SetValue(DBUtility.GetInitialValue("PRACTITIONER_ORGANISATION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_DISCIPLINE")) Then
        item.PRACTITIONER_DISCIPLINE.SetValue(DBUtility.GetInitialValue("PRACTITIONER_DISCIPLINE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_DISCIPLINE_OTHER")) Then
        item.PRACTITIONER_DISCIPLINE_OTHER.SetValue(DBUtility.GetInitialValue("PRACTITIONER_DISCIPLINE_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_PRIMARY_ISSUES")) Then
        item.PRACTITIONER_PRIMARY_ISSUES.SetValue(DBUtility.GetInitialValue("PRACTITIONER_PRIMARY_ISSUES"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_PRIMARY_OTHER")) Then
        item.PRACTITIONER_PRIMARY_OTHER.SetValue(DBUtility.GetInitialValue("PRACTITIONER_PRIMARY_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_LAST_MODIFIED_BY")) Then
        item.PRACTITIONER_LAST_MODIFIED_BY.SetValue(DBUtility.GetInitialValue("PRACTITIONER_LAST_MODIFIED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_LAST_MODIFIED_DATE")) Then
        item.PRACTITIONER_LAST_MODIFIED_DATE.SetValue(DBUtility.GetInitialValue("PRACTITIONER_LAST_MODIFIED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_PRIMARY_ISSUES")) Then
        item.Hidden_PRIMARY_ISSUES.SetValue(DBUtility.GetInitialValue("Hidden_PRIMARY_ISSUES"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLAST_MODIFIED_BY")) Then
        item.lblLAST_MODIFIED_BY.SetValue(DBUtility.GetInitialValue("lblLAST_MODIFIED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLAST_MODIFIED_DATE")) Then
        item.lblLAST_MODIFIED_DATE.SetValue(DBUtility.GetInitialValue("lblLAST_MODIFIED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_ORGTYPE")) Then
        item.PRACTITIONER_ORGTYPE.SetValue(DBUtility.GetInitialValue("PRACTITIONER_ORGTYPE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_ORGTYPE_OTHER")) Then
        item.PRACTITIONER_ORGTYPE_OTHER.SetValue(DBUtility.GetInitialValue("PRACTITIONER_ORGTYPE_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_DISABILITIES")) Then
        item.Hidden_DISABILITIES.SetValue(DBUtility.GetInitialValue("Hidden_DISABILITIES"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_DISABILITIES")) Then
        item.PRACTITIONER_DISABILITIES.SetValue(DBUtility.GetInitialValue("PRACTITIONER_DISABILITIES"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_DISABILITY_DETAILS")) Then
        item.PRACTITIONER_DISABILITY_DETAILS.SetValue(DBUtility.GetInitialValue("PRACTITIONER_DISABILITY_DETAILS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_REC_CLASS_ATTENDANCE")) Then
        item.PRACTITIONER_REC_CLASS_ATTENDANCE.SetValue(DBUtility.GetInitialValue("PRACTITIONER_REC_CLASS_ATTENDANCE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE")) Then
        item.Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.SetValue(DBUtility.GetInitialValue("Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_REC_WORKLOAD")) Then
        item.PRACTITIONER_REC_WORKLOAD.SetValue(DBUtility.GetInitialValue("PRACTITIONER_REC_WORKLOAD"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRACTITIONER_REC_CARER_AS_SUPERVISOR")) Then
        item.PRACTITIONER_REC_CARER_AS_SUPERVISOR.SetValue(DBUtility.GetInitialValue("PRACTITIONER_REC_CARER_AS_SUPERVISOR"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "PRACTITIONER_ORGANISATION"
                    Return PRACTITIONER_ORGANISATION
                Case "PRACTITIONER_DISCIPLINE"
                    Return PRACTITIONER_DISCIPLINE
                Case "PRACTITIONER_DISCIPLINE_OTHER"
                    Return PRACTITIONER_DISCIPLINE_OTHER
                Case "PRACTITIONER_PRIMARY_ISSUES"
                    Return PRACTITIONER_PRIMARY_ISSUES
                Case "PRACTITIONER_PRIMARY_OTHER"
                    Return PRACTITIONER_PRIMARY_OTHER
                Case "PRACTITIONER_LAST_MODIFIED_BY"
                    Return PRACTITIONER_LAST_MODIFIED_BY
                Case "PRACTITIONER_LAST_MODIFIED_DATE"
                    Return PRACTITIONER_LAST_MODIFIED_DATE
                Case "Hidden_PRIMARY_ISSUES"
                    Return Hidden_PRIMARY_ISSUES
                Case "lblLAST_MODIFIED_BY"
                    Return lblLAST_MODIFIED_BY
                Case "lblLAST_MODIFIED_DATE"
                    Return lblLAST_MODIFIED_DATE
                Case "PRACTITIONER_ORGTYPE"
                    Return PRACTITIONER_ORGTYPE
                Case "PRACTITIONER_ORGTYPE_OTHER"
                    Return PRACTITIONER_ORGTYPE_OTHER
                Case "Hidden_DISABILITIES"
                    Return Hidden_DISABILITIES
                Case "PRACTITIONER_DISABILITIES"
                    Return PRACTITIONER_DISABILITIES
                Case "PRACTITIONER_DISABILITY_DETAILS"
                    Return PRACTITIONER_DISABILITY_DETAILS
                Case "PRACTITIONER_REC_CLASS_ATTENDANCE"
                    Return PRACTITIONER_REC_CLASS_ATTENDANCE
                Case "Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE"
                    Return Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE
                Case "PRACTITIONER_REC_WORKLOAD"
                    Return PRACTITIONER_REC_WORKLOAD
                Case "PRACTITIONER_REC_CARER_AS_SUPERVISOR"
                    Return PRACTITIONER_REC_CARER_AS_SUPERVISOR
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "PRACTITIONER_ORGANISATION"
                    PRACTITIONER_ORGANISATION = CType(value, TextField)
                Case "PRACTITIONER_DISCIPLINE"
                    PRACTITIONER_DISCIPLINE = CType(value, TextField)
                Case "PRACTITIONER_DISCIPLINE_OTHER"
                    PRACTITIONER_DISCIPLINE_OTHER = CType(value, TextField)
                Case "PRACTITIONER_PRIMARY_ISSUES"
                    PRACTITIONER_PRIMARY_ISSUES = CType(value, TextField)
                Case "PRACTITIONER_PRIMARY_OTHER"
                    PRACTITIONER_PRIMARY_OTHER = CType(value, TextField)
                Case "PRACTITIONER_LAST_MODIFIED_BY"
                    PRACTITIONER_LAST_MODIFIED_BY = CType(value, TextField)
                Case "PRACTITIONER_LAST_MODIFIED_DATE"
                    PRACTITIONER_LAST_MODIFIED_DATE = CType(value, DateField)
                Case "Hidden_PRIMARY_ISSUES"
                    Hidden_PRIMARY_ISSUES = CType(value, TextField)
                Case "lblLAST_MODIFIED_BY"
                    lblLAST_MODIFIED_BY = CType(value, TextField)
                Case "lblLAST_MODIFIED_DATE"
                    lblLAST_MODIFIED_DATE = CType(value, DateField)
                Case "PRACTITIONER_ORGTYPE"
                    PRACTITIONER_ORGTYPE = CType(value, TextField)
                Case "PRACTITIONER_ORGTYPE_OTHER"
                    PRACTITIONER_ORGTYPE_OTHER = CType(value, TextField)
                Case "Hidden_DISABILITIES"
                    Hidden_DISABILITIES = CType(value, TextField)
                Case "PRACTITIONER_DISABILITIES"
                    PRACTITIONER_DISABILITIES = CType(value, TextField)
                Case "PRACTITIONER_DISABILITY_DETAILS"
                    PRACTITIONER_DISABILITY_DETAILS = CType(value, TextField)
                Case "PRACTITIONER_REC_CLASS_ATTENDANCE"
                    PRACTITIONER_REC_CLASS_ATTENDANCE = CType(value, TextField)
                Case "Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE"
                    Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE = CType(value, TextField)
                Case "PRACTITIONER_REC_WORKLOAD"
                    PRACTITIONER_REC_WORKLOAD = CType(value, TextField)
                Case "PRACTITIONER_REC_CARER_AS_SUPERVISOR"
                    PRACTITIONER_REC_CARER_AS_SUPERVISOR = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As STUDENT_MEDICAL_DETAILS1DataProvider)
'End Record STUDENT_MEDICAL_DETAILS1 Item Class

'PRACTITIONER_DISCIPLINE validate @61-4E80C719
        If IsNothing(PRACTITIONER_DISCIPLINE.Value) OrElse PRACTITIONER_DISCIPLINE.Value.ToString() ="" Then
            errors.Add("PRACTITIONER_DISCIPLINE",String.Format(Resources.strings.CCS_RequiredField,"PRACTITIONER DISCIPLINE"))
        End If
'End PRACTITIONER_DISCIPLINE validate

'PRACTITIONER_ORGTYPE validate @138-7288FE07
        If IsNothing(PRACTITIONER_ORGTYPE.Value) OrElse PRACTITIONER_ORGTYPE.Value.ToString() ="" Then
            errors.Add("PRACTITIONER_ORGTYPE",String.Format(Resources.strings.CCS_RequiredField,"PRACTITIONER ORGANISATION TYPE"))
        End If
'End PRACTITIONER_ORGTYPE validate

'Record STUDENT_MEDICAL_DETAILS1 Item Class tail @55-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_MEDICAL_DETAILS1 Item Class tail

'Record STUDENT_MEDICAL_DETAILS1 Data Provider Class @55-C9CF4490
Public Class STUDENT_MEDICAL_DETAILS1DataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_MEDICAL_DETAILS1 Data Provider Class

'Record STUDENT_MEDICAL_DETAILS1 Data Provider Class Variables @55-8410C321
    Protected PRACTITIONER_REC_CLASS_ATTENDANCEDataCommand As DataCommand=new TableCommand("SELECT PractitionerRecommendedClassAttendanceID, " & vbCrLf & _
          "PractitionerRecommendedClassAttendance " & vbCrLf & _
          "FROM vwPractitionerRecommendedClassAttendance {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected PRACTITIONER_REC_WORKLOADDataCommand As DataCommand=new TableCommand("SELECT PractitionerRecommendedWorkloadID, " & vbCrLf & _
          "PractitionerRecommendedWorkload " & vbCrLf & _
          "FROM vwPractitionerRecommendedWorkload {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlSTUDENT_ID As FloatParameter
    Protected item As STUDENT_MEDICAL_DETAILS1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_MEDICAL_DETAILS1 Data Provider Class Variables

'Record STUDENT_MEDICAL_DETAILS1 Data Provider Class Constructor @55-C2362022

    Public Sub New()
        Select_=new TableCommand("SELECT PRACTITIONER_LAST_MODIFIED_DATE, PRACTITIONER_LAST_MODIFIED_BY, " & vbCrLf & _
          "PRACTITIONER_ADDITIONAL_OTHER, PRACTITIONER_ADDITIONAL_ISSUES," & vbCrLf & _
          "PRACTITIONER_PRIMARY_OTHER, " & vbCrLf & _
          "PRACTITIONER_PRIMARY_ISSUES, PRACTITIONER_DISCIPLINE_OTHER, " & vbCrLf & _
          "PRACTITIONER_DISCIPLINE, PRACTITIONER_ORGANISATION," & vbCrLf & _
          "PRACTITIONER_ORGTYPE, " & vbCrLf & _
          "PRACTITIONER_ORGTYPE_OTHER, PRACTITIONER_DISABILITIES, PRACTITIONER_DISABILITY_DETAILS, " & vbCrLf & _
          "PRACTITIONER_REC_CLASS_ATTENDANCE," & vbCrLf & _
          "PRACTITIONER_REC_WORKLOAD, " & vbCrLf & _
          "PRACTITIONER_REC_CARER_AS_SUPERVISOR, STUDENT_ID " & vbCrLf & _
          "FROM STUDENT_MEDICAL_DETAILS {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID236"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_MEDICAL_DETAILS1 Data Provider Class Constructor

'Record STUDENT_MEDICAL_DETAILS1 Data Provider Class LoadParams Method @55-A977A0E9

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID))
    End Function
'End Record STUDENT_MEDICAL_DETAILS1 Data Provider Class LoadParams Method

'Record STUDENT_MEDICAL_DETAILS1 Data Provider Class CheckUnique Method @55-BAA22D3F

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_MEDICAL_DETAILS1Item) As Boolean
        Return True
    End Function
'End Record STUDENT_MEDICAL_DETAILS1 Data Provider Class CheckUnique Method

'Record STUDENT_MEDICAL_DETAILS1 Data Provider Class PrepareUpdate Method @55-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT_MEDICAL_DETAILS1 Data Provider Class PrepareUpdate Method

'Record STUDENT_MEDICAL_DETAILS1 Data Provider Class PrepareUpdate Method tail @55-E31F8E2A
    End Sub
'End Record STUDENT_MEDICAL_DETAILS1 Data Provider Class PrepareUpdate Method tail

'Record STUDENT_MEDICAL_DETAILS1 Data Provider Class Update Method @55-08545BA6

    Public Function UpdateItem(ByVal item As STUDENT_MEDICAL_DETAILS1Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_MEDICAL_DETAILS SET {Values}", New String(){"STUDENT_ID236"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_MEDICAL_DETAILS1 Data Provider Class Update Method

'Record STUDENT_MEDICAL_DETAILS1 Event BeforeBuildUpdate. Action Custom Code @271-73254650
      ' 17 Mar 2022|RW| Force updates for the radio buttons that we may want to be resettable, especially between enrolment years.
      '                 CodeCharge Studio's default behaviour for unselected radio buttons is to skip the update for them instead of updating them to null.
      item.PRACTITIONER_REC_WORKLOAD.IsEmpty = False
      item.PRACTITIONER_REC_CARER_AS_SUPERVISOR.IsEmpty = False
'End Record STUDENT_MEDICAL_DETAILS1 Event BeforeBuildUpdate. Action Custom Code

'Record STUDENT_MEDICAL_DETAILS1 BeforeBuildUpdate @55-1DD8B23F
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID236",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If Not item.PRACTITIONER_ORGANISATION.IsEmpty Then
        allEmptyFlag = item.PRACTITIONER_ORGANISATION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_ORGANISATION=" + Update.Dao.ToSql(item.PRACTITIONER_ORGANISATION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRACTITIONER_DISCIPLINE.IsEmpty Then
        allEmptyFlag = item.PRACTITIONER_DISCIPLINE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_DISCIPLINE=" + Update.Dao.ToSql(item.PRACTITIONER_DISCIPLINE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRACTITIONER_DISCIPLINE_OTHER.IsEmpty Then
        allEmptyFlag = item.PRACTITIONER_DISCIPLINE_OTHER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_DISCIPLINE_OTHER=" + Update.Dao.ToSql(item.PRACTITIONER_DISCIPLINE_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRACTITIONER_PRIMARY_OTHER.IsEmpty Then
        allEmptyFlag = item.PRACTITIONER_PRIMARY_OTHER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_PRIMARY_OTHER=" + Update.Dao.ToSql(item.PRACTITIONER_PRIMARY_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRACTITIONER_LAST_MODIFIED_BY.IsEmpty Then
        allEmptyFlag = item.PRACTITIONER_LAST_MODIFIED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_LAST_MODIFIED_BY=" + Update.Dao.ToSql(item.PRACTITIONER_LAST_MODIFIED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRACTITIONER_LAST_MODIFIED_DATE.IsEmpty Then
        allEmptyFlag = item.PRACTITIONER_LAST_MODIFIED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_LAST_MODIFIED_DATE=" + Update.Dao.ToSql(item.PRACTITIONER_LAST_MODIFIED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.Hidden_PRIMARY_ISSUES.IsEmpty Then
        allEmptyFlag = item.Hidden_PRIMARY_ISSUES.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_PRIMARY_ISSUES=" + Update.Dao.ToSql(item.Hidden_PRIMARY_ISSUES.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRACTITIONER_ORGTYPE.IsEmpty Then
        allEmptyFlag = item.PRACTITIONER_ORGTYPE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_ORGTYPE=" + Update.Dao.ToSql(item.PRACTITIONER_ORGTYPE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRACTITIONER_ORGTYPE_OTHER.IsEmpty Then
        allEmptyFlag = item.PRACTITIONER_ORGTYPE_OTHER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_ORGTYPE_OTHER=" + Update.Dao.ToSql(item.PRACTITIONER_ORGTYPE_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_DISABILITIES.IsEmpty Then
        allEmptyFlag = item.Hidden_DISABILITIES.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_DISABILITIES=" + Update.Dao.ToSql(item.Hidden_DISABILITIES.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRACTITIONER_DISABILITY_DETAILS.IsEmpty Then
        allEmptyFlag = item.PRACTITIONER_DISABILITY_DETAILS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_DISABILITY_DETAILS=" + Update.Dao.ToSql(item.PRACTITIONER_DISABILITY_DETAILS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.IsEmpty Then
        allEmptyFlag = item.Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_REC_CLASS_ATTENDANCE=" + Update.Dao.ToSql(item.Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRACTITIONER_REC_WORKLOAD.IsEmpty Then
        allEmptyFlag = item.PRACTITIONER_REC_WORKLOAD.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_REC_WORKLOAD=" + Update.Dao.ToSql(item.PRACTITIONER_REC_WORKLOAD.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRACTITIONER_REC_CARER_AS_SUPERVISOR.IsEmpty Then
        allEmptyFlag = item.PRACTITIONER_REC_CARER_AS_SUPERVISOR.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRACTITIONER_REC_CARER_AS_SUPERVISOR=" + Update.Dao.ToSql(item.PRACTITIONER_REC_CARER_AS_SUPERVISOR.GetFormattedValue(""),FieldType._Integer) & ","
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
             If Not allEmptyFlag Then result = ExecuteUpdate()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record STUDENT_MEDICAL_DETAILS1 BeforeBuildUpdate

'Record STUDENT_MEDICAL_DETAILS1 AfterExecuteUpdate @55-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_MEDICAL_DETAILS1 AfterExecuteUpdate

'Record STUDENT_MEDICAL_DETAILS1 Data Provider Class GetResultSet Method @55-37CA6A91

    Public Sub FillItem(ByVal item As STUDENT_MEDICAL_DETAILS1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_MEDICAL_DETAILS1 Data Provider Class GetResultSet Method

'Record STUDENT_MEDICAL_DETAILS1 BeforeBuildSelect @55-19A33A71
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID236",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_MEDICAL_DETAILS1 BeforeBuildSelect

'Record STUDENT_MEDICAL_DETAILS1 BeforeExecuteSelect @55-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_MEDICAL_DETAILS1 BeforeExecuteSelect

'Record STUDENT_MEDICAL_DETAILS1 AfterExecuteSelect @55-2E75282D
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.PRACTITIONER_ORGANISATION.SetValue(dr(i)("PRACTITIONER_ORGANISATION"),"")
            item.PRACTITIONER_DISCIPLINE.SetValue(dr(i)("PRACTITIONER_DISCIPLINE"),"")
            item.PRACTITIONER_DISCIPLINE_OTHER.SetValue(dr(i)("PRACTITIONER_DISCIPLINE_OTHER"),"")
            item.PRACTITIONER_PRIMARY_OTHER.SetValue(dr(i)("PRACTITIONER_PRIMARY_OTHER"),"")
            item.PRACTITIONER_LAST_MODIFIED_BY.SetValue(dr(i)("PRACTITIONER_LAST_MODIFIED_BY"),"")
            item.PRACTITIONER_LAST_MODIFIED_DATE.SetValue(dr(i)("PRACTITIONER_LAST_MODIFIED_DATE"),Select_.DateFormat)
            item.Hidden_PRIMARY_ISSUES.SetValue(dr(i)("PRACTITIONER_PRIMARY_ISSUES"),"")
            item.lblLAST_MODIFIED_BY.SetValue(dr(i)("PRACTITIONER_LAST_MODIFIED_BY"),"")
            item.lblLAST_MODIFIED_DATE.SetValue(dr(i)("PRACTITIONER_LAST_MODIFIED_DATE"),Select_.DateFormat)
            item.PRACTITIONER_ORGTYPE.SetValue(dr(i)("PRACTITIONER_ORGTYPE"),"")
            item.PRACTITIONER_ORGTYPE_OTHER.SetValue(dr(i)("PRACTITIONER_ORGTYPE_OTHER"),"")
            item.Hidden_DISABILITIES.SetValue(dr(i)("PRACTITIONER_DISABILITIES"),"")
            item.PRACTITIONER_DISABILITY_DETAILS.SetValue(dr(i)("PRACTITIONER_DISABILITY_DETAILS"),"")
            item.Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.SetValue(dr(i)("PRACTITIONER_REC_CLASS_ATTENDANCE"),"")
            item.PRACTITIONER_REC_WORKLOAD.SetValue(dr(i)("PRACTITIONER_REC_WORKLOAD"),"")
            item.PRACTITIONER_REC_CARER_AS_SUPERVISOR.SetValue(dr(i)("PRACTITIONER_REC_CARER_AS_SUPERVISOR"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STUDENT_MEDICAL_DETAILS1 AfterExecuteSelect

'ListBox PRACTITIONER_DISCIPLINE AfterExecuteSelect @61-81468614
        
item.PRACTITIONER_DISCIPLINEItems.Add("Psychologist","Psychologist")
item.PRACTITIONER_DISCIPLINEItems.Add("Psychiatrist","Psychiatrist")
item.PRACTITIONER_DISCIPLINEItems.Add("Paediatrician","Paediatrician")
item.PRACTITIONER_DISCIPLINEItems.Add("Occupational Therapist","Occupational Therapist")
item.PRACTITIONER_DISCIPLINEItems.Add("General Practitioner","General Practitioner")
item.PRACTITIONER_DISCIPLINEItems.Add("Social Worker","Social Worker")
item.PRACTITIONER_DISCIPLINEItems.Add("Counsellor","Counsellor")
item.PRACTITIONER_DISCIPLINEItems.Add("Other","Other - enter below")
'End ListBox PRACTITIONER_DISCIPLINE AfterExecuteSelect

'ListBox PRACTITIONER_PRIMARY_ISSUES AfterExecuteSelect @63-BE3A7EDB
        
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Anxiety","Anxiety")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Depression","Depression")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("School refusal","School refusal")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Bullying","Bullying")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Behavioural issues","Behavioural issues")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("ADD/ADHD","ADD/ADHD")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("ASD","ASD")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Family issues","Family issues")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Trauma","Trauma")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Chronic Fatigue","Chronic Fatigue")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Sleep Disorder","Sleep Disorder")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Gender dysphoria","Gender dysphoria")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Eating disorder","Eating disorder")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Gaming issues","Gaming issues")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Suicide risk","Suicide risk")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Pregnancy/childbirth","Pregnancy/childbirth")
item.PRACTITIONER_PRIMARY_ISSUESItems.Add("Other","Other - enter below")
'End ListBox PRACTITIONER_PRIMARY_ISSUES AfterExecuteSelect

'ListBox PRACTITIONER_ORGTYPE AfterExecuteSelect @138-910FFC6F
        
item.PRACTITIONER_ORGTYPEItems.Add("Psychology service","Psychology service")
item.PRACTITIONER_ORGTYPEItems.Add(" Child & Adolescent Mental Health service","Child & Adolescent Mental Health service")
item.PRACTITIONER_ORGTYPEItems.Add(" Headspace","Headspace")
item.PRACTITIONER_ORGTYPEItems.Add(" Navigator program","Navigator program")
item.PRACTITIONER_ORGTYPEItems.Add(" Private Psychologist","Private Psychologist")
item.PRACTITIONER_ORGTYPEItems.Add(" Paediatric service","Paediatric service")
item.PRACTITIONER_ORGTYPEItems.Add(" Community based service","Community based service")
item.PRACTITIONER_ORGTYPEItems.Add(" Hospital based service","Hospital based service")
item.PRACTITIONER_ORGTYPEItems.Add(" DHHS Child protection","DHHS Child protection")
item.PRACTITIONER_ORGTYPEItems.Add(" Child First","Child First")
item.PRACTITIONER_ORGTYPEItems.Add("NDIS","NDIS")
item.PRACTITIONER_ORGTYPEItems.Add(" Other: Specify","Other: Specify")
'End ListBox PRACTITIONER_ORGTYPE AfterExecuteSelect

'ListBox PRACTITIONER_DISABILITIES AfterExecuteSelect @178-84A99508
        
item.PRACTITIONER_DISABILITIESItems.Add("Physical","Physical")
item.PRACTITIONER_DISABILITIESItems.Add("Visual","Visual impairment")
item.PRACTITIONER_DISABILITIESItems.Add("Hearing","Hearing impairment")
item.PRACTITIONER_DISABILITIESItems.Add("Behaviour","Severe behaviour disorder")
item.PRACTITIONER_DISABILITIESItems.Add("Intellectual","Intellectual disability")
item.PRACTITIONER_DISABILITIESItems.Add("ASD","Autism spectrum disorder")
item.PRACTITIONER_DISABILITIESItems.Add("Language","Severe language disorder")
'End ListBox PRACTITIONER_DISABILITIES AfterExecuteSelect

'ListBox PRACTITIONER_REC_CLASS_ATTENDANCE Initialize Data Source @215-FCAC9C14
        PRACTITIONER_REC_CLASS_ATTENDANCEDataCommand.Dao._optimized = False
        Dim PRACTITIONER_REC_CLASS_ATTENDANCEtableIndex As Integer = 0
        PRACTITIONER_REC_CLASS_ATTENDANCEDataCommand.OrderBy = "PractitionerRecommendedClassAttendanceDisplayOrder"
        PRACTITIONER_REC_CLASS_ATTENDANCEDataCommand.Parameters.Clear()
'End ListBox PRACTITIONER_REC_CLASS_ATTENDANCE Initialize Data Source

'ListBox PRACTITIONER_REC_CLASS_ATTENDANCE BeforeExecuteSelect @215-66944794
        Try
            ListBoxSource=PRACTITIONER_REC_CLASS_ATTENDANCEDataCommand.Execute().Tables(PRACTITIONER_REC_CLASS_ATTENDANCEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox PRACTITIONER_REC_CLASS_ATTENDANCE BeforeExecuteSelect

'ListBox PRACTITIONER_REC_CLASS_ATTENDANCE AfterExecuteSelect @215-C29F80E1
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("PractitionerRecommendedClassAttendanceID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("PractitionerRecommendedClassAttendance")
            item.PRACTITIONER_REC_CLASS_ATTENDANCEItems.Add(Key, Val)
        Next
'End ListBox PRACTITIONER_REC_CLASS_ATTENDANCE AfterExecuteSelect

'ListBox PRACTITIONER_REC_WORKLOAD Initialize Data Source @262-16867823
        PRACTITIONER_REC_WORKLOADDataCommand.Dao._optimized = False
        Dim PRACTITIONER_REC_WORKLOADtableIndex As Integer = 0
        PRACTITIONER_REC_WORKLOADDataCommand.OrderBy = "PractitionerRecommendedWorkloadDisplayOrder"
        PRACTITIONER_REC_WORKLOADDataCommand.Parameters.Clear()
'End ListBox PRACTITIONER_REC_WORKLOAD Initialize Data Source

'ListBox PRACTITIONER_REC_WORKLOAD BeforeExecuteSelect @262-F30960A4
        Try
            ListBoxSource=PRACTITIONER_REC_WORKLOADDataCommand.Execute().Tables(PRACTITIONER_REC_WORKLOADtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox PRACTITIONER_REC_WORKLOAD BeforeExecuteSelect

'ListBox PRACTITIONER_REC_WORKLOAD AfterExecuteSelect @262-082265FA
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("PractitionerRecommendedWorkloadID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("PractitionerRecommendedWorkload")
            item.PRACTITIONER_REC_WORKLOADItems.Add(Key, Val)
        Next
'End ListBox PRACTITIONER_REC_WORKLOAD AfterExecuteSelect

'ListBox PRACTITIONER_REC_CARER_AS_SUPERVISOR AfterExecuteSelect @267-30991DBE
        
item.PRACTITIONER_REC_CARER_AS_SUPERVISORItems.Add("0","No")
item.PRACTITIONER_REC_CARER_AS_SUPERVISORItems.Add("1","Yes")
'End ListBox PRACTITIONER_REC_CARER_AS_SUPERVISOR AfterExecuteSelect

'Record STUDENT_MEDICAL_DETAILS1 AfterExecuteSelect tail @55-E31F8E2A
    End Sub
'End Record STUDENT_MEDICAL_DETAILS1 AfterExecuteSelect tail

'Record STUDENT_MEDICAL_DETAILS1 Data Provider Class @55-A61BA892
End Class

'End Record STUDENT_MEDICAL_DETAILS1 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

