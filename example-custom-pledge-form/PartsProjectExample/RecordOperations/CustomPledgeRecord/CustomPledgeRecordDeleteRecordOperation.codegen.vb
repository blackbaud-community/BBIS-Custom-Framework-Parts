Option Infer On
Option Strict Off

Imports bbAppFxWebAPI = Blackbaud.AppFx.WebAPI



Namespace RecordOperations

	Namespace [CustomPledgeRecord]
			
			'<@ENUMS@>

    ''' <summary>
    ''' Provides WebApi access to the "CustomPledgeRecord Delete Record Operation" catalog feature.  Delete record operation for custom pledge record of pledges from BBIS custom pledge form
    ''' </summary>
<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2011.8.2.0")> _
		Public NotInheritable Class [CustomPledgeRecordDeleteRecordOperation]

			Private Sub New()
			End Sub

			Private Shared _specId As Guid = New Guid("410ed14f-7c50-4258-b7de-a54f45214b37")

			''' <summary>
			''' The Spec ID value for the "CustomPledgeRecord Delete Record Operation" record operation
			''' </summary>
			Public Shared ReadOnly Property SpecId() As Guid
				Get
					Return _specId
				End Get
			End Property
			
			Public Shared Function CreateRequest(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider) As bbAppFxWebAPI.ServiceProxy.RecordOperationPerformRequest
                Return bbAppFxWebAPI.RecordOpServices.CreateRecordOperationPerformRequest(provider, [CustomPledgeRecordDeleteRecordOperation].SpecId)
            End Function			

			Public Shared Sub ExecuteOperation(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider , ByVal recordID As String)
			
				Dim request = CreateRequest(provider)
				
				request.ID = recordID
				
				ExecuteOperation(provider, request)
			End Sub
			
 #If 0 Then    			
			Public Shared Sub ExecuteOperation(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider , ByVal recordID As String )
				Dim request = CreateRequest(provider)
				
				request.ID = recordID
			
				 
			
				ExecuteOperation(provider, request)
			End Sub
 #End If			
			
			Public Shared Sub ExecuteOperation(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal request As bbAppFxWebAPI.ServiceProxy.RecordOperationPerformRequest)
				bbAppFxWebAPI.RecordOpServices.ExecuteOperation(provider, request)
			End Sub
			
			Public Shared Function GetPrompt(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider , ByVal recordID As String) As String
			
				Dim request = bbAppFxWebAPI.RecordOpServices.CreateGetPromptRequest(provider, [CustomPledgeRecordDeleteRecordOperation].SpecId)
				
				request.ID = recordID
			
				Return bbAppFxWebAPI.RecordOpServices.GetPrompt(provider, request)
			End Function
			
		End Class
		


	End Namespace
	
End Namespace


