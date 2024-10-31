'FileUploadControl Class @0-2977935C
Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Collections.Specialized
Imports System.Security.Permissions
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Text.RegularExpressions

Namespace DECV_PROD2007.Controls
    Public Class FileUploadControl
        Inherits WebControl
        Implements INamingContainer 

        Protected Enum FileAllocation
            InputControl
            TemporaryFolder
            FileFolder
            None
        End Enum 'FileAllocation

        Protected delControl As New System.Web.UI.WebControls.CheckBox()
        Protected fileNameLabel As New System.Web.UI.WebControls.Label()
        Protected fileSizeLabel As New System.Web.UI.WebControls.Label()
        Protected labelForInput As New HtmlGenericControl()
        Protected labelForDelete As New HtmlGenericControl()
        Protected literal1 As New System.Web.UI.LiteralControl("&nbsp;")
        Protected literal2 As New System.Web.UI.LiteralControl("&nbsp;")
        Protected fileControl As New HtmlInputFile()

        Public Property AllowedFileMasks() As String 
            Get
                If ViewState("_allowedMasks") Is Nothing Then
                    Return "*"
                Else
                    Return CType(ViewState("_allowedMasks"),String)
                End If
            End Get
            Set
                If value = "" Or value Is Nothing Then
                    ViewState("_allowedMasks") = "*"
                Else
                    ViewState("_allowedMasks") = value
                End If
            End Set
        End Property 

        Public Property DisallowedFileMasks() As String
            Get
                If ViewState("_disallowedMasks") Is Nothing Then
                    Return ""
                Else
                    Return CType(ViewState("_disallowedMasks"),String)
                End If
            End Get
            Set
                ViewState("_disallowedMasks") = value
            End Set
        End Property

        Public Property FileFolder() As String
            Get
                If ViewState("_fileFolder") Is Nothing Or CType(ViewState("_fileFolder"), String) = "" Then
                    Return MapPathSecure(TemplateSourceDirectory).TrimEnd(New Char() {"\"c, "/"c})
                Else
                    Return CType(ViewState("_fileFolder"), String).TrimEnd(New Char() {"\"c, "/"c})
                End If
            End Get
            Set
                Dim tempPath As String = value
                If Not System.IO.Path.IsPathRooted(tempPath) Then tempPath = MapPathSecure(tempPath)
                If Not System.IO.Directory.Exists(tempPath) Then
                    Throw New DirectoryNotFoundException("File folder is not found")
                End If
                Dim fp As new FileIOPermission(FileIOPermissionAccess.Write, tempPath)
                fp.Demand()
                ViewState("_fileFolder") = tempPath
            End Set
        End Property

        Public Property TemporaryFolder() As String
            Get
                If ViewState("_temporaryFolder") Is Nothing Or CType(ViewState("_temporaryFolder"), String) = "" Then
                Return MapPathSecure(TemplateSourceDirectory).TrimEnd(New Char() {"\"c, "/"c})
                Else
                Return CType(ViewState("_temporaryFolder"), String).TrimEnd(New Char() {"\"c, "/"c})
                End If
            End Get
            Set
                If value.StartsWith("%") Then
                    ViewState("_temporaryFolder") = Environment.GetEnvironmentVariable(value.TrimStart(New Char() {"%"c}))
                Else
                    Dim tempPath As String = value
                    If Not System.IO.Path.IsPathRooted(tempPath) Then tempPath = MapPathSecure(tempPath)
                    ViewState("_temporaryFolder") = tempPath
                End If
                If Not System.IO.Directory.Exists(CStr(ViewState("_temporaryFolder"))) Then
                    Throw New DirectoryNotFoundException("Temporary folder is not found")
                End If
                Dim fp As new FileIOPermission(FileIOPermissionAccess.Write, CStr(ViewState("_temporaryFolder")))
                fp.Demand()
            End Set
        End Property 

        Public Property FileSizeLimit() As Int64
            Get
                If ViewState("_fileSizeLimit") Is Nothing Then
                    Return - 1
                Else
                    Return CLng(ViewState("_fileSizeLimit"))
                End If
            End Get
            Set
                ViewState("_fileSizeLimit") = value
            End Set
        End Property

        Public Property Required() As Boolean
            Get
                If ViewState("_required") Is Nothing Then
                    Return False
                Else
                    Return CBool(ViewState("_required"))
                End If
            End Get
            Set
                ViewState("_required") = value
            End Set
        End Property

        Protected ReadOnly Property FileSize() As Long
            Get
                If FileAllocation.FileFolder = Allocation Then
                    Return New FileInfo(FileFolder + "\" + [Text]).Length
                End If
                If FileAllocation.TemporaryFolder = Allocation Then
                    Return New FileInfo(TemporaryFolder + "\" + [Text]).Length
                Else
                    EnsureChildControls()
                    If fileControl.PostedFile Is Nothing Then
                    Return 0
                    Else
                    Return fileControl.PostedFile.ContentLength
                    End If
                End If
            End Get
        End Property

        Protected Property OriginalFileName() As String
            Get
                If FileAllocation.FileFolder = Allocation Then
                    Return [Text].Remove(0, [Text].IndexOf(".") + 1)
                Else
                    Return CType(ViewState("originalFileName"),String)
                End If
            End Get
            Set
                ViewState("originalFileName") = value
            End Set
        End Property

		Private __isEmpty As Boolean = true
		Public ReadOnly Property IsEmpty As Boolean
			Get
				return __isEmpty
			End Get
		End Property

    
        Public Property FileName() As String
            Get
                If Allocation = FileAllocation.InputControl Then
                    EnsureChildControls()
                    Return fileControl.PostedFile.FileName
                End If
                If Allocation = FileAllocation.TemporaryFolder Or Allocation = FileAllocation.FileFolder Then
                    Return CType(ViewState("fileName"),String)
                End If
                Return ""
            End Get
            Set
                ViewState("fileName") = value
            End Set
        End Property

        Protected ReadOnly Property IsFilePosted() As Boolean
            Get
                Return Allocation <> FileAllocation.None
            End Get
        End Property

        Protected Property Allocation() As FileAllocation
            Get
                If Not (ViewState("allocation") Is Nothing) Then
                    Return CType(ViewState("allocation"), FileAllocation)
                Else
                    ViewState("allocation") = FileAllocation.None
                    Return FileAllocation.None
                End If
            End Get
            Set
                ViewState("allocation") = value
            End Set
        End Property

        Public Property [Text]() As String
            Get
                If ViewState("_value") Is Nothing Then
                    Return ""
                Else
                    Return CType(ViewState("_value"),String)
                End If
            End Get
            Set
                If Not IsNothing(value) AndAlso value<>"" AndAlso Allocation = FileAllocation.None AndAlso Not(System.IO.File.Exists(FileFolder + "\" + value)) Then
                    Throw New FileNotFoundException("FileNotFound")
                End If
                ViewState("_value") = value
            End Set
        End Property

        Public Property Caption() As String
        Get
            If ViewState("_caption") Is Nothing Then
                Return ""
            Else
                Return CType(ViewState("_caption"),String)
            End If
        End Get
            Set
                ViewState("_caption") = value
            End Set
        End Property

        Public Property DeleteCaption() As String
        Get
            If ViewState("_deleteCaption") Is Nothing Then
                Return ""
            Else
                Return CType(ViewState("_deleteCaption"),String)
            End If
        End Get
            Set
                ViewState("_deleteCaption") = value
            End Set
        End Property

        Public Event BeforeProcessFile As EventHandler
        Public Event AfterProcessFile As EventHandler
        Public Event BeforeDeleteFile As EventHandler
        Public Event AfterDeleteFile As EventHandler

        Protected Overridable Sub OnBeforeProcessFile(e As EventArgs)
                RaiseEvent BeforeProcessFile(Me, e)
        End Sub 'OnBeforeProcessFile

        Protected Overridable Sub OnAfterProcessFile(e As EventArgs)
                RaiseEvent AfterProcessFile(Me, e)
        End Sub 'OnAfterProcessFile

        Protected Overridable Sub OnBeforeDeleteFile(e As EventArgs)
                RaiseEvent BeforeDeleteFile(Me, e)
        End Sub 'OnBeforeDeleteFile

        Protected Overridable Sub OnAfterDeleteFile(e As EventArgs)
                RaiseEvent AfterDeleteFile(Me, e)
        End Sub 'OnAfterDeleteFile

        Protected Overrides Sub CreateChildControls()
            If [Text] <> "" And Allocation = FileAllocation.None Then
                If System.IO.File.Exists((FileFolder + "\" + [Text])) Then
                    Allocation = FileAllocation.FileFolder
                    FileName = [Text]
                    ViewState("_oldFileName") = [Text]
                Else
                    Throw New FileNotFoundException(String.Format(Resources.strings.CCS_FileNotFound,ID,[Text]),[Text])
                End If
            End If
            delControl.ID = "delControl"
            labelForDelete.InnerText = DeleteCaption
            labelForInput.InnerText = "FileUpload"
            fileNameLabel.ID = "fileName"
            fileSizeLabel.ID = "fileSize"
            fileControl.ID = "file"
            labelForInput.ID = "fileLabel"
            labelForDelete.ID = "delLabel"

            Controls.Add(fileNameLabel)
            Controls.Add(literal1)
            Controls.Add(fileSizeLabel)
            Controls.Add(literal2)
            Controls.Add(labelForDelete)
            Controls.Add(delControl)
            Controls.Add(labelForInput)
            Controls.Add(fileControl)
            labelForDelete.TagName = "label"
            labelForInput.TagName = "label"
            labelForDelete.Attributes.Add("for",delControl.ClientID)
            labelForInput.Attributes.Add("style","display:none")
            labelForInput.Attributes.Add("for",fileControl.ClientID)
        End Sub 'CreateChildControls

        Private Function CompareByMask(value As String, mask As String) As Boolean
            If mask = "*" Then
                Return True
            End If
            mask = (new Regex("([\.\$\^\{\[\(\|\)\+\\])").Replace(mask,"\$1"))
            mask = (new Regex("\?").Replace(mask,"[^\.]"))
            mask = (new Regex("\*").Replace(mask,".+"))
            mask = "^" + mask + "$" 
            Return New Regex(mask, RegexOptions.IgnoreCase).IsMatch(value)
        End Function

        Private Sub CheckConstraints()
            Dim _fileName As String = Path.GetFileName(FileName)
            If AllowedFileMasks <> "*" Then
                Dim masks As String() = AllowedFileMasks.Split(New Char() {";"c})
                Dim result As Boolean = False
                Dim i As Integer
                For i = 0 To masks.Length - 1
                    result = CompareByMask(_fileName, masks(i)) Or result
                Next i
                If Not result Then
                    Allocation = FileAllocation.None
                    Throw New InvalidOperationException("The file type is not allowed.")
                End If
            End If
            If DisallowedFileMasks <> "" Then
                Dim masks As String() = DisallowedFileMasks.Split(New Char() {";"c})
                Dim result As Boolean = False
                Dim i As Integer
                For i = 0 To masks.Length - 1
                    result = CompareByMask(_fileName, masks(i)) Or result
                Next i
                If result Then
                    Allocation = FileAllocation.None
                    Throw New InvalidOperationException("The file type is not allowed.")
                End If
            End If
            If FileSizeLimit <> - 1 Then
                If fileControl.PostedFile.ContentLength > FileSizeLimit Then
                    Allocation = FileAllocation.None
                    Throw New InvalidOperationException("The file is too large.")
                End If
            End If
            Return
        End Sub 'CheckConstraints

        'Perform the file operation and catch the errors
        'mode param - 1 Validate, 2 Save, 3 Delete
        Protected Function ProcessFile(mode As Integer, _fileName As String) As Boolean
            Select Case mode
                Case 1
                    fileControl.PostedFile.SaveAs(_fileName)
                    Allocation = FileAllocation.TemporaryFolder
                    [Text] = FileName
                    __isEmpty = false
                Case 2
                    OnBeforeProcessFile(EventArgs.Empty)
                    System.IO.File.Move(TemporaryFolder + "\" + FileName, FileFolder + "\" + FileName)
                    Allocation = FileAllocation.FileFolder
                    [Text] = FileName
                    __isEmpty = false
                    If Not IsNothing(ViewState("_oldFileName"))
                        System.IO.File.Delete(FileFolder + "\" + CStr(ViewState("_oldFileName")))
                    End If
                    OnAfterProcessFile(EventArgs.Empty)
                Case 3
                    OnBeforeDeleteFile(EventArgs.Empty)
                    If Allocation = FileAllocation.TemporaryFolder Then
                        System.IO.File.Delete((TemporaryFolder + "\" + FileName))
                        Allocation = FileAllocation.None
                        [Text] = ""
                    __isEmpty = false
                    End If
                    If Allocation = FileAllocation.FileFolder Then
                        File.Delete((FileFolder + "\" + FileName))
                        Allocation = FileAllocation.None
                        [Text] = ""
                    __isEmpty = false
                    End If
                    OnAfterDeleteFile(EventArgs.Empty)
            End Select
            Return True
        End Function 'ProcessFile

        Public Function DeleteFile() As Boolean
            Return ProcessFile(3, "")
        End Function 'DeleteFile

        Public Function ValidateFile() As Boolean
            EnsureChildControls()
            If delControl.Checked Then
                DeleteFile()
                delControl.Checked = False
            End If
            If (fileControl.PostedFile Is Nothing Or FileSize = 0) And Allocation <> FileAllocation.FileFolder And Allocation <> FileAllocation.TemporaryFolder Then
                Allocation = FileAllocation.None
                Return False
            Else
                If Not(fileControl.PostedFile Is Nothing) AndAlso fileControl.PostedFile.ContentLength > 0 Then
                If Allocation = FileAllocation.TemporaryFolder Then ProcessFile(3, "")
                    Allocation = FileAllocation.InputControl
                    CheckConstraints()
                    Dim _fileName As String = Path.GetFileName(FileName)
                    OriginalFileName = _fileName
                    Dim timeStamp As String = DateTime.Now.ToString("yyyyMMddHHmmss")
                    Dim i As Integer = 1
                    Dim index As String = ""
                    While System.IO.File.Exists((TemporaryFolder + "\" + timeStamp + index + "." + _fileName ))
                        index = i.ToString()
                        i += 1
                    End While
                    FileName = timeStamp + index + "." + _fileName
                    _fileName = TemporaryFolder + "\" + timeStamp + index + "." + _fileName
                    Return ProcessFile(1, _fileName)
                End If
            End If
            Return True
        End Function 'ValidateFile

        Public Function SaveFile() As Boolean
            EnsureChildControls()
            If delControl.Checked Then
                DeleteFile()
                delControl.Checked = False
            End If
            If Allocation = FileAllocation.InputControl Then
                ValidateFile()
            End If
            If Allocation = FileAllocation.TemporaryFolder Then
                Return ProcessFile(2, "")
            End If
            Return True
        End Function 'SaveFile

        Protected Overrides Sub OnPreRender(e As EventArgs)
            If CssClass <> "" Then
                fileControl.Attributes.Add("class", CssClass)
                delControl.Attributes.Add("class", CssClass)
            End If
            ControlStyle.Reset()

            Dim c As Control
            For Each c In  Page.Controls
                If TypeOf c Is HtmlForm Then
                    CType(c, HtmlForm).Enctype = "multipart/form-data"
                    Exit For
                End If
            Next c
            If IsFilePosted And Not Required Then
                fileNameLabel.Text = OriginalFileName
                fileSizeLabel.Text = FileSize.ToString()
                fileControl.Visible = False
                labelForInput.Visible = False
                delControl.Visible = True
                labelForDelete.Visible = True
                fileNameLabel.Visible = True
                fileSizeLabel.Visible = True
                literal1.Visible = True
                literal2.Visible = True
            ElseIf IsFilePosted And Required Then
                fileNameLabel.Text = OriginalFileName
                fileSizeLabel.Text = FileSize.ToString()
                fileControl.Visible = True
                labelForInput.Visible = True
                delControl.Visible = False
                labelForDelete.Visible = False
                fileNameLabel.Visible = True
                fileSizeLabel.Visible = True
                literal1.Visible = True
                literal2.Visible = True
            Else
                delControl.Visible = False
                labelForDelete.Visible = False
                fileNameLabel.Visible = False
                fileSizeLabel.Visible = False
                fileControl.Visible = True
                labelForInput.Visible = True
                literal1.Visible = False
                literal2.Visible = False
            End If
        End Sub 'OnPreRender 
    End Class 'FileUploadControl
End Namespace 'FileUpload.Controls
'End FileUploadControl Class

