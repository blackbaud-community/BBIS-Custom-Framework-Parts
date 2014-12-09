<%@ assembly Name="PartsProjectExample"%>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CustomPledgeFormEditor.ascx.vb" Inherits="PartsProjectExample.CustomPledgeFormEditor" %>
<%@ import Namespace="PartsProjectExample"%>
<asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="red" />
<p>
    &nbsp;</p>
<asp:CheckBox ID="CheckBoxOnlyWriteToCustomPledgeRecord" runat="server" 
    Text="Only write to custom pledge record" />
<p>
    When this is selected, any time the Pledge button is clicked, the details will 
    be written to the custom pledge record USR_CUSTOMPLEDGE using the custom pledge 
    Add Data Form accessed through a BBMetalWeb-generated DLL.</p>
<p>
    When this is not selected, for logged in users with linked accounts, the details 
    will be writtten to a new pledge transaction using a DLL to access a web API. 
    For ananonymous users, the information will be writtern to USR_CUSTOMPLEDGE 
    using the cutom pledge Add Data Form accessed through a BBMetalWeb-generated 
    DLL.</p>
