Imports BBNCExtensions


Partial Public Class CustomSearchFormDisplay
    Inherits BBNCExtensions.Parts.CustomPartDisplayBase

    Private mContent As CustomSearchFormProperties

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Change the label at the top of the form based on the constituency
        'selected in the part's editor.
        If MyContent.Constituency = "All" Then
            LabelConstituency.Text = "Individual Search"
        Else
            LabelConstituency.Text = "Individual Search: " + MyContent.Constituency + " constituency"
        End If
    End Sub

    Private Function GetConstituentSummary(ByVal ConstituentID As System.Guid)
        'Use the Constituent catalog WebAPIClient DLL to get constituent summary
        'information from Infinity. The create request and load data calls
        'require a sevice provider. The service provider is established by Blackbaud
        'Internet Solutions: Me.AP.AppFxWebServiceProvider. This uses BBNCExtensions.
        'The load data call uses the constituent summary request. Return the summary.
        Dim _ConstituentSummary As New Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentSummaryProfileViewFormData
        Dim ConstituentSummaryReq = Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentSummaryProfileViewForm.CreateRequest(Me.API.AppFxWebServiceProvider)
        ConstituentSummaryReq.RecordID = ConstituentID.ToString
        _ConstituentSummary = Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentSummaryProfileViewForm.LoadData(Me.API.AppFxWebServiceProvider, ConstituentSummaryReq)
        Return _ConstituentSummary
    End Function

    Private Function GetConstituentName(ByVal ConstituentID As System.Guid)
        'Use the Constituent catalog WebAPIClient DLL to get constituent name
        'information from Infinity. The create request and load data calls
        'require a sevice provider. The service provider is established by Blackbaud
        'Internet Solutions: Me.AP.AppFxWebServiceProvider. This uses BBNCExtensions.
        'The load data call uses the constituent name request. Return the name data.
        Dim _ConstituentName As New Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentFirstNameLastNameViewFormData
        Dim ConstituentNameReq = Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentFirstNameLastNameViewForm.CreateRequest(Me.API.AppFxWebServiceProvider)
        ConstituentNameReq.RecordID = ConstituentID.ToString
        _ConstituentName = Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentFirstNameLastNameViewForm.LoadData(Me.API.AppFxWebServiceProvider, ConstituentNameReq)
        Return _ConstituentName
    End Function

    Private Sub DisplayIndividualInformation(ByVal ConstituentSummary As Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentSummaryProfileViewFormData,
                                             ByVal ConstituentName As Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentFirstNameLastNameViewFormData)
        'Display consituent name and summary information. The information is passed
        'to this procedure.
        If ConstituentName.FIRSTNAME <> "" Then
            LabelName.Text = ConstituentName.FIRSTNAME.ToString + " " + ConstituentName.KEYNAME.ToString
        Else
            LabelName.Text = ConstituentName.KEYNAME + " (last name only)"
        End If
        If ConstituentSummary.PHONENUMBER <> "" Then
            LabelPhone.Text = ConstituentSummary.PHONENUMBER.ToString
        Else
            LabelPhone.Text = "No phone number listed"
        End If
        If ConstituentSummary.EMAILADDRESS <> "" Then
            LabelEmail.Text = ConstituentSummary.EMAILADDRESS.ToString
        Else
            LabelEmail.Text = "No email address listed"
        End If

    End Sub

    Private Function ReturnIndividualSearchIDs(ByVal ConstituencyID As System.Guid)
        'This is for the case where a constituency is chosen.
        'Return an array of String that contains IDs for individuals in Infinity.
        'Access an individual search feature in Infinity with the Constituent catalog
        'web API WebAPIClient DLL. Only return results for the constituency chosen
        'in the part's editor. The get IDs request requires a sevice provider. 
        'The service provider is established by Blackbaud Internet Solutions: 
        'Me.AP.AppFxWebServiceProvider. This uses BBNCExtensions.
        Dim IndividualSearchFilter As New Blackbaud.AppFx.Constituent.Catalog.WebApiClient.SearchLists.Constituent.IndividualSearchFilterData
        Dim IndividualIDs As String()
        IndividualSearchFilter.FIRSTNAME = TextBoxFirst.Text
        IndividualSearchFilter.MIDDLENAME = TextBoxMiddle.Text
        IndividualSearchFilter.KEYNAME = TextBoxLast.Text
        IndividualSearchFilter.INCLUDEINDIVIDUALS = True
        IndividualSearchFilter.INCLUDEGROUPS = False
        IndividualSearchFilter.INCLUDEINACTIVE = False
        IndividualSearchFilter.INCLUDENONCONSTITUENTRECORDS = False
        IndividualSearchFilter.INCLUDEORGANIZATIONS = False
        IndividualSearchFilter.CONSTITUENCY = ConstituencyID
        IndividualIDs = Blackbaud.AppFx.Constituent.Catalog.WebApiClient.SearchLists.Constituent.IndividualSearch.GetIDs(Me.API.AppFxWebServiceProvider, IndividualSearchFilter)
        Return IndividualIDs
    End Function

    Private Function ReturnIndividualSearchIDs()
        'This is for the case where a All is chosen for constituency.
        'Return an array of String that contains IDs for individuals in Infinity.
        'Access an individual search feature in Infinity with the Constituent catalog
        'web API WebAPIClient DLL. The get IDs request requires a sevice provider. 
        'The service provider is established by Blackbaud Internet Solutions: 
        'Me.AP.AppFxWebServiceProvider. This uses BBNCExtensions.
        Dim IndividualSearchFilter As New Blackbaud.AppFx.Constituent.Catalog.WebApiClient.SearchLists.Constituent.IndividualSearchFilterData
        Dim IndividualIDs As String()
        IndividualSearchFilter.FIRSTNAME = TextBoxFirst.Text
        IndividualSearchFilter.MIDDLENAME = TextBoxMiddle.Text
        IndividualSearchFilter.KEYNAME = TextBoxLast.Text
        IndividualSearchFilter.INCLUDEINDIVIDUALS = True
        IndividualSearchFilter.INCLUDEGROUPS = False
        IndividualSearchFilter.INCLUDEINACTIVE = False
        IndividualSearchFilter.INCLUDENONCONSTITUENTRECORDS = False
        IndividualSearchFilter.INCLUDEORGANIZATIONS = False
        IndividualIDs = Blackbaud.AppFx.Constituent.Catalog.WebApiClient.SearchLists.Constituent.IndividualSearch.GetIDs(Me.API.AppFxWebServiceProvider, IndividualSearchFilter)
        Return IndividualIDs
    End Function


    Private ReadOnly Property MyContent() As CustomSearchFormProperties
        'Get the form properties related to CustomSearchFormProperties.vb.
        'In this case, there are properties for the
        'constituency name, ID, and whether to search all constituencies.
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

    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonSearch.Click
        Dim IndividualIDs() As String
        Dim ConstituentID As System.Guid
        Dim ConstituentSummary As Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentSummaryProfileViewFormData
        Dim ConstituentName As Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentFirstNameLastNameViewFormData

        ListBoxOtherResults.Items.Clear()

        'ReturnIndividualSearchIDs returns results for all constituencies or 
        'results for just one depending on whether you specify a constituency ID.
        If MyContent.SearchAll Then
            IndividualIDs = ReturnIndividualSearchIDs()
        Else
            IndividualIDs = ReturnIndividualSearchIDs(MyContent.ConstituencyID)
        End If

        'Logic for when the button is clicked.
        If IndividualIDs.Length = 0 Then
            LabelName.Text = "No results"
        ElseIf IndividualIDs.Length = 1 Then
            ConstituentID = New System.Guid(IndividualIDs(0))
            ConstituentSummary = GetConstituentSummary(ConstituentID)
            ConstituentName = GetConstituentName(ConstituentID)
            DisplayIndividualInformation(ConstituentSummary, ConstituentName)
        Else
            ConstituentID = New System.Guid(IndividualIDs(0))
            ConstituentSummary = GetConstituentSummary(ConstituentID)
            ConstituentName = GetConstituentName(ConstituentID)
            DisplayIndividualInformation(ConstituentSummary, ConstituentName)
            For Each IndResult In IndividualIDs
                ConstituentID = New System.Guid(IndResult)
                ConstituentName = GetConstituentName(ConstituentID)
                ListBoxOtherResults.Items.Add(ConstituentName.FIRSTNAME + " " + ConstituentName.KEYNAME)
            Next
        End If

    End Sub

End Class