Imports BBNCExtensions

Partial Public Class CustomPledgeFormEditor
    Inherits BBNCExtensions.Parts.CustomPartEditorBase

    Private mContent As CustomPledgeFormProperties

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Public Overrides Sub OnLoadContent()
        If Not Page.IsPostBack Then
            With MyContent
                'When loading the content:
                'Change the editor form checkbox to match the boolean content property related to 
                'CustomPledgeFormProperties.vb().
                CheckBoxOnlyWriteToCustomPledgeRecord.Checked = .OnlyWriteToCustomPledgeRecord
            End With
        End If
    End Sub


    Public Overrides Function OnSaveContent(Optional ByVal bDialogIsClosing As Boolean = True) As Boolean
        'When saving the content:
        'Change the boolean content property related to 
        'CustomPledgeFormProperties.vb() based on the editor form checkbox.
        With MyContent
            .OnlyWriteToCustomPledgeRecord = CheckBoxOnlyWriteToCustomPledgeRecord.Checked
        End With
        Me.Content.SaveContent(MyContent)
        Return True
    End Function

    Private ReadOnly Property MyContent() As CustomPledgeFormProperties
        'For getting content
        Get
            If mContent Is Nothing Then
                mContent = Me.Content.GetContent(GetType(CustomPledgeFormProperties))
                If mContent Is Nothing Then
                    mContent = New CustomPledgeFormProperties
                End If
            End If
            Return mContent
        End Get
    End Property


End Class