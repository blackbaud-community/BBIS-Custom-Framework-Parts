Imports BBNCExtensions

Partial Public Class CustomSearchFormEditor
    Inherits BBNCExtensions.Parts.CustomPartEditorBase

    Private mContent As CustomSearchFormProperties

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Public Overrides Sub OnLoadContent()
        Dim ConstituencyAll() As Blackbaud.AppFx.Constituent.Catalog.WebApiClient.DataLists.TopLevel.ConstituencyAllDataListRow
        ConstituencyAll = Blackbaud.AppFx.Constituent.Catalog.WebApiClient.DataLists.TopLevel.ConstituencyAllDataList.GetRows(Me.API.AppFxWebServiceProvider)

        With MyContent
            If Not Page.IsPostBack Then
                RadioButtonListConstituencies.Items.Clear()
                For Each Constituency In ConstituencyAll
                    RadioButtonListConstituencies.Items.Add(Constituency.DISPLAYNAME)
                Next
                RadioButtonListConstituencies.Items.Add("All")
                RadioButtonListConstituencies.SelectedValue = .Constituency
            End If
        End With
    End Sub

    Public Overrides Function OnSaveContent(Optional ByVal bDialogIsClosing As Boolean = True) As Boolean
        Dim ConstituencyAll() As Blackbaud.AppFx.Constituent.Catalog.WebApiClient.DataLists.TopLevel.ConstituencyAllDataListRow
        ConstituencyAll = Blackbaud.AppFx.Constituent.Catalog.WebApiClient.DataLists.TopLevel.ConstituencyAllDataList.GetRows(Me.API.AppFxWebServiceProvider)

        With MyContent
            .Constituency = RadioButtonListConstituencies.SelectedValue
            .SearchAll = False
            If .Constituency = "All" Then
                .SearchAll = True
            Else
                For Each Constituency In ConstituencyAll
                    If Constituency.DESCRIPTION = .Constituency Then
                        .ConstituencyID = Constituency.ID
                    End If
                Next
            End If
        End With
        Me.Content.SaveContent(MyContent)
        Return True
    End Function

    Private ReadOnly Property MyContent() As CustomSearchFormProperties
        Get
            If mContent Is Nothing Then
                mContent = Me.Content.GetContent(GetType(CustomSearchFormProperties))
                If mContent Is Nothing Then
                    mContent = New CustomSearchFormProperties
                End If
            End If
            Return mContent
        End Get
    End Property
End Class