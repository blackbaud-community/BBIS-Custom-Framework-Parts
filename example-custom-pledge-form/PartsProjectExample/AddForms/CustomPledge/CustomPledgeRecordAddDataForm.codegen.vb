Option Infer On
Option Strict Off

Imports bbAppFxWebAPI = Blackbaud.AppFx.WebAPI



Namespace AddForms

    Namespace [CustomPledge]
    
		

		

		    ''' <summary>
    ''' Provides WebApi access to the "CustomPledgeRecord Add Data Form" catalog feature.  Add form for custom pledge record of pledges from BBIS custom pledge form
    ''' </summary>
<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2011.8.2.0")> _
        Public NotInheritable Class [CustomPledgeRecordAddDataForm]

            Private Sub New()
            End Sub

            Private Shared ReadOnly _specId As Guid = New Guid("6c932fef-af04-4f9b-8a85-1dd8215fed72")

			''' <summary>
			''' The Spec ID value for the "CustomPledgeRecord Add Data Form" AddForm
			''' </summary>
            Public Shared ReadOnly Property SpecId() As Guid
                Get
                    Return _specId
                End Get
            End Property
 
            Public Shared Function CreateLoadRequest(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider) As bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest
                Return Blackbaud.AppFx.WebAPI.DataFormServices.CreateDataFormLoadRequest(provider, _specId)
            End Function

            ''' <summary>
            ''' Returns an instance of CustomPledgeRecordAddDataFormData with default data form fields populated.
            ''' </summary>
            ''' <returns>An instance of CustomPledgeRecordAddDataFormData with the form field properties that have defaults populated with those default values.</returns>
            ''' <remarks>This function will make a web request to the AppFx WebService DataFormLoad method to obtain the default data form field values.</remarks>
            Public Shared Function LoadData(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider ) As CustomPledgeRecordAddDataFormData

				

                Dim request = CreateLoadRequest(provider)

				
				
				

                Return LoadData(provider, request)

            End Function          

            ''' <summary>
            ''' Returns an instance of CustomPledgeRecordAddDataFormData with default data form fields populated.
            ''' </summary>
            ''' <returns>An instance of CustomPledgeRecordAddDataFormData with the form field properties that have defaults populated with those default values.</returns>
            ''' <remarks>This function will make a web request to the AppFx WebService DataFormLoad method to obtain the default data form field values.</remarks>
            Public Shared Function LoadData(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal request As bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest) As CustomPledgeRecordAddDataFormData
                Return bbAppFxWebAPI.DataFormServices.GetFormData(Of CustomPledgeRecordAddDataFormData)(provider, request)
            End Function
   
        End Class

#Region "Data Class"

        ''' <summary>
        ''' Represents the data form field values in the "CustomPledgeRecord Add Data Form" data form.
        ''' </summary>
		<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2011.8.2.0")> _
	    Public NotInheritable Class CustomPledgeRecordAddDataFormData
			Inherits bbAppFxWebAPI.AddFormData
        
#Region "Constructors"
        
			Public Sub New()
				Mybase.New()
			End Sub

			Friend Sub New(ByVal reply as bbAppFxWebAPI.ServiceProxy.DataFormLoadReply,request as bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest)
				Mybase.New()					
				If (reply IsNot Nothing) AndAlso (reply.DataFormItem IsNot Nothing) Then
					Me.SetValues(reply.DataFormItem)
				End If
			End Sub
        
        	Public Sub New(ByVal dfi as Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
				Mybase.New()					
				Me.SetValues(dfi)
			End Sub
			
			Public Sub New(ByVal dataFormItemXml As String)
                MyBase.New()
                Me.SetValuesFromDataFormItem(dataFormItemXml)
            End Sub

#End Region
        
#Region "Form Field Properties"

Private [_KEYNAME] As String
''' <summary>
''' Last
''' </summary>
Public Property [KEYNAME] As String
    Get
        Return Me.[_KEYNAME]
    End Get
    Set
        Me.[_KEYNAME] = value 
    End Set
End Property

Private [_FIRSTNAME] As String
''' <summary>
''' First
''' </summary>
Public Property [FIRSTNAME] As String
    Get
        Return Me.[_FIRSTNAME]
    End Get
    Set
        Me.[_FIRSTNAME] = value 
    End Set
End Property

Private [_MIDDLENAME] As String
''' <summary>
''' Middle
''' </summary>
Public Property [MIDDLENAME] As String
    Get
        Return Me.[_MIDDLENAME]
    End Get
    Set
        Me.[_MIDDLENAME] = value 
    End Set
End Property

Private [_EDUCATIONALHISTORYLEVELCODEID] As Nullable(of System.Guid)
''' <summary>
''' Educational history level
''' </summary>
Public Property [EDUCATIONALHISTORYLEVELCODEID] As Nullable(of System.Guid)
    Get
        Return Me.[_EDUCATIONALHISTORYLEVELCODEID]
    End Get
    Set
        Me.[_EDUCATIONALHISTORYLEVELCODEID] = value 
    End Set
End Property

Private [_USR_CUSTOMCLASSYEARCODEID] As Nullable(of System.Guid)
''' <summary>
''' Custom class year
''' </summary>
Public Property [USR_CUSTOMCLASSYEARCODEID] As Nullable(of System.Guid)
    Get
        Return Me.[_USR_CUSTOMCLASSYEARCODEID]
    End Get
    Set
        Me.[_USR_CUSTOMCLASSYEARCODEID] = value 
    End Set
End Property

Private [_CONSTITUENTID] As Nullable(of System.Guid)
''' <summary>
''' Constituent
''' </summary>
Public Property [CONSTITUENTID] As Nullable(of System.Guid)
    Get
        Return Me.[_CONSTITUENTID]
    End Get
    Set
        Me.[_CONSTITUENTID] = value 
    End Set
End Property

Private [_EMAIL] As String
''' <summary>
''' Email address
''' </summary>
Public Property [EMAIL] As String
    Get
        Return Me.[_EMAIL]
    End Get
    Set
        Me.[_EMAIL] = value 
    End Set
End Property

Private [_AMOUNT] As Nullable(of Decimal) = "0"
''' <summary>
''' Amount
''' </summary>
Public Property [AMOUNT] As Nullable(of Decimal)
    Get
        Return Me.[_AMOUNT]
    End Get
    Set
        Me.[_AMOUNT] = value 
    End Set
End Property

        

#End Region

            Public Overrides ReadOnly Property DataFormInstanceID() As System.Guid
                Get
                    Return AddForms.[CustomPledge].CustomPledgeRecordAddDataForm.SpecId
                End Get
            End Property

            Public Overrides Function ToDataFormItem() As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem
                Return Me.BuildDataFormItemForSave()
            End Function
    
			Friend Sub SetValues(ByVal dfi As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
				
				If dfi Is Nothing Then Exit Sub
	            
				
Dim value As Object = Nothing
Dim dfiFieldValue As Blackbaud.AppFx.XmlTypes.DataForms.DataFormFieldValue = Nothing
Dim stringFieldValue As String = Nothing

Dim guidFieldValue As System.Guid
stringFieldValue = Nothing
If dfi.TryGetValueForPropertyAssignment("KEYNAME", stringFieldValue) Then
Me.[KEYNAME] = stringFieldValue
End If

stringFieldValue = Nothing
If dfi.TryGetValueForPropertyAssignment("FIRSTNAME", stringFieldValue) Then
Me.[FIRSTNAME] = stringFieldValue
End If

stringFieldValue = Nothing
If dfi.TryGetValueForPropertyAssignment("MIDDLENAME", stringFieldValue) Then
Me.[MIDDLENAME] = stringFieldValue
End If

guidFieldValue = System.Guid.Empty
If dfi.TryGetValueForPropertyAssignment("EDUCATIONALHISTORYLEVELCODEID", guidFieldValue) Then
Me.[EDUCATIONALHISTORYLEVELCODEID] = guidFieldValue
End If

guidFieldValue = System.Guid.Empty
If dfi.TryGetValueForPropertyAssignment("USR_CUSTOMCLASSYEARCODEID", guidFieldValue) Then
Me.[USR_CUSTOMCLASSYEARCODEID] = guidFieldValue
End If

guidFieldValue = System.Guid.Empty
If dfi.TryGetValueForPropertyAssignment("CONSTITUENTID", guidFieldValue) Then
Me.[CONSTITUENTID] = guidFieldValue
End If

stringFieldValue = Nothing
If dfi.TryGetValueForPropertyAssignment("EMAIL", stringFieldValue) Then
Me.[EMAIL] = stringFieldValue
End If

value = Nothing
dfiFieldValue = Nothing
If dfi.TryGetValue("AMOUNT", dfiFieldValue) Then
	If dfiFieldValue IsNot Nothing Then
	value = dfiFieldValue.Value
If (value IsNot Nothing) AndAlso (value IsNot System.DBNull.Value) Then
If TypeOf value Is String Then 
Me.[AMOUNT] = Blackbaud.AppFx.DataListUtility.DataListStringValueToDec(value)

Else
Me.[AMOUNT] = value
End If
End If

	End If

End If


	            
			End Sub

			Private Function BuildDataFormItemForSave() As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem
        
				Dim dfi As New Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem	 
	                    
				Dim value As Object = Nothing
value = Me.[KEYNAME]
	dfi.SetValueIfNotNull("KEYNAME",value)
value = Me.[FIRSTNAME]
	dfi.SetValueIfNotNull("FIRSTNAME",value)
value = Me.[MIDDLENAME]
	dfi.SetValueIfNotNull("MIDDLENAME",value)
value = Me.[EDUCATIONALHISTORYLEVELCODEID]
	dfi.SetValueIfNotNull("EDUCATIONALHISTORYLEVELCODEID",value)
value = Me.[USR_CUSTOMCLASSYEARCODEID]
	dfi.SetValueIfNotNull("USR_CUSTOMCLASSYEARCODEID",value)
value = Me.[CONSTITUENTID]
	dfi.SetValueIfNotNull("CONSTITUENTID",value)
value = Me.[EMAIL]
	dfi.SetValueIfNotNull("EMAIL",value)
value = Me.[AMOUNT]
	dfi.SetValueIfNotNull("AMOUNT",value)

	    
				Return dfi	    
	        
			End Function
			
			Public Overrides Sub SetValuesFromDataFormItem(ByVal dataFormItem As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
                Me.SetValues(dataFormItem)
            End Sub
            
			
	 
		End Class
    
#End Region
    
    End Namespace

End Namespace

