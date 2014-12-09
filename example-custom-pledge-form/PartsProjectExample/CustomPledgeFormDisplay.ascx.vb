Imports BBNCExtensions


Partial Public Class CustomPledgeFormDisplay
    Inherits BBNCExtensions.Parts.CustomPartDisplayBase

    Private mContent As CustomPledgeFormProperties

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        'If there is a login (not ananonymous), get the first and last name for the logged in user.
        'Populate the First and Last fields on the form. Disable the First, Middle,
        'and Last fields. Otherwise, leave the fields enabled and writeable.
        'Also populate the email field. Use the Constituent catalog WebAPIClient DLL from the Infinity SDK.
        If Not API.Users.CurrentUser.IsAnonymous Then
            TextBoxFirst.Text = API.Users.CurrentUser.FirstName
            TextBoxLast.Text = API.Users.CurrentUser.LastName
            TextBoxFirst.Enabled = False
            TextBoxMiddle.Enabled = False
            TextBoxLast.Enabled = False
            If Not IsPostBack And API.Users.CurrentUser.BackOfficeGuid <> System.Guid.Empty Then
                Dim ConstituentSummary As New Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentSummaryProfileViewFormData()
                ConstituentSummary = GetConstituentSummary()
                TextBoxEmail.Text = ConstituentSummary.EMAILADDRESS
            End If
        End If
    End Sub

    Private ReadOnly Property MyContent() As CustomPledgeFormProperties
        'Get the form properties. In this case, there is only one property.
        'It is a boolean which indicates whether to write the pledge information to a
        'Revenue record in Infinity or a custom pledge record in Infinity created with
        'the Infinity SDK. The specs to use to create the custom pledge record are
        'included in this code sample solution.
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

    Private Function GetConstituentSummary()
        'Use the Constituent catalog WebAPIClient DLL to get constituent summary
        'information from Infinity. The create request and load data calls
        'require a sevice provider. The service provider is established by Blackbaud
        'Internet Solutions: Me.AP.AppFxWebServiceProvider. This uses BBNCExtensions.
        'The load data call uses the constituent summary request. Return the summary.
        Dim ConstituentSummary As New Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentSummaryProfileViewFormData()
        Dim ConstituentSummaryReq = Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentSummaryProfileViewForm.CreateRequest(Me.API.AppFxWebServiceProvider)
        ConstituentSummaryReq.RecordID = API.Users.CurrentUser.BackOfficeGuid.ToString
        ConstituentSummary = Blackbaud.AppFx.Constituent.Catalog.WebApiClient.ViewForms.Constituent.ConstituentSummaryProfileViewForm.LoadData(Me.API.AppFxWebServiceProvider, ConstituentSummaryReq)
        Return ConstituentSummary
    End Function

    Private Sub AddAdditionalEmail()
        'Use the Constituent catalog WebAPIClient DLL to add an email address to a
        'constituent in Infinity. Use the email address on the form. Create the Add
        'Form Data and save the data. The Add Form Data is an instance of
        'EmailAddressAddFormData with values assigned from the form and today's
        'date. Call the save for the Add Form Data. The save request requires a
        'service provider. The service provider is established by Blackbaud
        'Internet Solutions: Me.AP.AppFxWebServiceProvider.
        Dim AddAdditionalEmail As New Blackbaud.AppFx.Constituent.Catalog.WebApiClient.AddForms.EmailAddress.EmailAddressAddFormData()
        AddAdditionalEmail.ContextRecordID = API.Users.CurrentUser.BackOfficeGuid.ToString
        AddAdditionalEmail.STARTDATE = System.DateTime.Today
        AddAdditionalEmail.EMAILADDRESS = TextBoxEmail.Text
        AddAdditionalEmail.PRIMARY = False
        AddAdditionalEmail.Save(Me.API.AppFxWebServiceProvider)
    End Sub

    Private Sub AddRevenuePledgeRecord()
        'Instantiate PledgeAddFormData from the Fundraising catalog WebAPIClient DLL.
        Dim RevenuePledgeData As New Blackbaud.AppFx.Fundraising.Catalog.WebApiClient.AddForms.Revenue.PledgeAddFormData()
        'Load the PledgeAddFormData instance with a load data call for PledgeAddForm
        'from the Fundraising catalog WebAPIClient DLL. The load data request requires a
        'service provider. The service provider is established by Blackbaud
        'Internet Solutions: Me.AP.AppFxWebServiceProvider.
        RevenuePledgeData = Blackbaud.AppFx.Fundraising.Catalog.WebApiClient.AddForms.Revenue.PledgeAddForm.LoadData(Me.API.AppFxWebServiceProvider)

        'Populate the PledgeAddDataForm instance with form information, today's date,
        'and hard coded values.

        'Use BackOfficeGuid for the user as Constituent ID. This uses BBNCExtensions.
        RevenuePledgeData.CONSTITUENTID = Me.API.Users.CurrentUser.BackOfficeGuid
        RevenuePledgeData.DATE = DateTime.Today
        RevenuePledgeData.AMOUNT = TextBoxAmount.Text
        RevenuePledgeData.POSTSTATUSCODE = Blackbaud.AppFx.Fundraising.Catalog.WebApiClient.AddForms.Revenue.PledgeAddFormData.POSTSTATUSCODEVALUES.Do_Not_Post
        'RevenuePledgeData.FREQUENCYCODE = Blackbaud.AppFx.Fundraising.Catalog.WebApiClient.AddForms.Revenue.PledgeAddFormData.FREQUENCYCODEVALUES.Single_Installment
        'RevenuePledgeData.NUMBEROFINSTALLMENTS = 1
        RevenuePledgeData.STARTDATE = DateTime.Today
        'RevenuePledgeData.PAYMENTMETHODCODE = Blackbaud.AppFx.Fundraising.Catalog.WebApiClient.AddForms.Revenue.PledgeAddFormData.PAYMENTMETHODCODEVALUES.Credit_Card
        Dim USDollarCurrencyID = New System.Guid("ba9803bc-f104-4150-bd34-d40d0f5b1f27")
        'RevenuePledgeData.TRANSACTIONCURRENCYID = USDollarCurrencyID
        'RevenuePledgeData.SENDPLEDGEREMINDER = False

        Dim sdi As New Blackbaud.AppFx.Fundraising.Catalog.WebApiClient.AddForms.Revenue.PledgeAddFormData.SPLITS_DATAITEM
        sdi.AMOUNT = TextBoxAmount.Text
        sdi.APPLICATIONCODE = 0
        'DesignationExampleID is hard-coded here. But you could use Infinity web API
        'DLLs to get a designation ID.

        'Splits are made of designations (splits data items). So create splits,
        'create the designation, add the designation to the split, and add the split
        'to the pledge data.
        Dim DesignationExampleID = New System.Guid("c622f540-b9d5-40dc-aff8-70f68f24e8fb")
        sdi.DESIGNATIONID = DesignationExampleID
        sdi.TRANSACTIONCURRENCYID = USDollarCurrencyID
        sdi.DECLINESGIFTAID = False
        Dim spl() As Blackbaud.AppFx.Fundraising.Catalog.WebApiClient.AddForms.Revenue.PledgeAddFormData.SPLITS_DATAITEM
        spl = {sdi}
        RevenuePledgeData.SPLITS = spl


        'Installments are made of installments data items. So create installments,
        'add an installment to the installments, and add the installments to the
        'pledge data.
        Dim idi As New Blackbaud.AppFx.Fundraising.Catalog.WebApiClient.AddForms.Revenue.PledgeAddFormData.INSTALLMENTS_DATAITEM
        idi.AMOUNT = TextBoxAmount.Text
        idi.DATE = DateTime.Today
        idi.TRANSACTIONCURRENCYID = USDollarCurrencyID
        idi.SEQUENCE = 1
        Dim ins() As Blackbaud.AppFx.Fundraising.Catalog.WebApiClient.AddForms.Revenue.PledgeAddFormData.INSTALLMENTS_DATAITEM
        ins = {idi}
        RevenuePledgeData.INSTALLMENTS = ins

        'Some other fields you could populate:

        'RevenuePledgeData.AUTOPAY = False
        'Dim GUIDofZeros = New System.Guid("00000000-0000-0000-0000-000000000000")
        'RevenuePledgeData.CREDITCARDTOKEN = GUIDofZeros
        'RevenuePledgeData.REFERENCEDATE = "00000000"
        'RevenuePledgeData.BENEFITSWAIVED = False
        'RevenuePledgeData.GIVENANONYMOUSLY = False
        'RevenuePledgeData.DONOTACKNOWLEDGE = False
        'RevenuePledgeData.STANDINGORDERSETUP = False
        'RevenuePledgeData.EXCHANGERATE = 1.0
        'Dim AccountSystemGUID = New System.Guid("4b121c2c-cce6-440d-894c-ea0def80d50b")
        'RevenuePledgeData.PDACCOUNTSYSTEMID = AccountSystemGUID
        'RevenuePledgeData.GENERATEREFERENCENUMBER = False

        RevenuePledgeData.Save(Me.API.AppFxWebServiceProvider)
    End Sub

    Private Sub AddCustomPledgeRecord()
        'Add a custom pledge record to Infinity. This assumes the custom pledge record
        'catalog items are added to Infinity. You can add custom catalog items to 
        'Infinity using the SDK. This solution contains the necessary items in a
        'separate project. The API for the custom Infinity features is created with
        'BBMetalWeb

        'Create the custom pledge form data.
        Dim CustomPledgeData As New PartsProjectExample.AddForms.CustomPledge.CustomPledgeRecordAddDataFormData()
        'Load default data with a call to load data for the form.
        CustomPledgeData = PartsProjectExample.AddForms.CustomPledge.CustomPledgeRecordAddDataForm.LoadData(Me.API.AppFxWebServiceProvider)
        'Populate CustomPledgeRecordAddDataFormData with fields from the part's
        'UI and with user information. Use BackOfficeGuid for the user as Constituent ID.
        'This uses BBNCExtensions
        CustomPledgeData.AMOUNT = TextBoxAmount.Text
        If Not API.Users.CurrentUser.IsAnonymous Then
            CustomPledgeData.CONSTITUENTID = API.Users.CurrentUser.BackOfficeGuid
        End If
        CustomPledgeData.EMAIL = TextBoxEmail.Text
        CustomPledgeData.FIRSTNAME = TextBoxFirst.Text
        CustomPledgeData.KEYNAME = TextBoxLast.Text
        CustomPledgeData.MIDDLENAME = TextBoxMiddle.Text

        'Save the form data with a save call for the CustomPledgeRecordAddDataFormData.
        'The save data request requires a service provider. The service provider is
        'established by Blackbaud Internet Solutions: Me.AP.AppFxWebServiceProvider.
        CustomPledgeData.Save(Me.API.AppFxWebServiceProvider)

    End Sub

    Protected Sub ButtonPledge_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonPledge.Click
        'Perform different actions upon a button click. Base the decisions on
        'whether the user is ananonymous and whether the content property indicates
        'to save to a custom pledge record or a Revenue record.
        Try
            If Page.IsValid Then
                If MyContent.OnlyWriteToCustomPledgeRecord Then
                    AddCustomPledgeRecord()
                ElseIf API.Users.CurrentUser.IsAnonymous Then
                    AddCustomPledgeRecord()
                Else
                    If API.Users.CurrentUser.BackOfficeGuid = System.Guid.Empty Then
                        AddCustomPledgeRecord()
                    Else
                        AddRevenuePledgeRecord()
                        AddAdditionalEmail()
                    End If
                End If
            End If
            'Add close code and direction to a thank you, etc.
        Catch ex As Blackbaud.AppFx.WebAPI.AppFxWebServiceException When ex.DataFormErrorInfo IsNot Nothing AndAlso ex.DataFormErrorInfo.ErrorCode = Blackbaud.AppFx.WebAPI.ServiceProxy.DataFormErrorCode.RecordNotFound
        End Try
    End Sub
End Class