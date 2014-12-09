<%@ assembly Name="PartsProjectExample"%>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CustomPledgeFormDisplay.ascx.vb" Inherits="PartsProjectExample.CustomPledgeFormDisplay" %>
<%@ import Namespace="PartsProjectExample"%>
<style type="text/css">
    .style1
    {
        width: 91px;
    }
</style>
<asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="red" />
<asp:ValidationSummary ID="ValidationSummaryTop" runat="server" />
<p>
    &nbsp;</p>
<asp:Panel ID="PanelPledgeForm" runat="server" Height="311px" Width="300px">
    <asp:Label ID="LabelPledgeForm" runat="server" 
    Text="Make a pledge"></asp:Label>
    <br />
    <table style="width:100%;">
        <tr>
            <td class="style1">
                <asp:Label ID="LabelFirst" runat="server" Text="First"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" ControlToValidate="TextBoxFirst" runat="server" ErrorMessage="First name required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="TextBoxFirst" runat="server" Width="195px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">

                <asp:Label ID="LabelMiddle" runat="server" Text="Middle"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxMiddle" runat="server" Width="195px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="LabelLast" runat="server" Text="Last"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" ControlToValidate="TextBoxLast" runat="server" ErrorMessage="Last name required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="TextBoxLast" runat="server" Width="195px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="LabelEmail" runat="server" Text="Email address"></asp:Label>
    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" 
        ControlToValidate="TextBoxEmail" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        runat="server" ErrorMessage=" Invalid email address"></asp:RegularExpressionValidator>
    <br />
    <asp:TextBox ID="TextBoxEmail" runat="server" Width="200px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Amount" runat="server" Text="Amount"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAmount" ControlToValidate="TextBoxAmount" runat="server" ErrorMessage=" Amount required">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidatorAmount" ControlToValidate="TextBoxAmount" ValidationExpression="^\d+(\.\d\d)?$" runat="server" ErrorMessage="Invalid amount"></asp:RegularExpressionValidator>
    <br />
    <asp:TextBox ID="TextBoxAmount" runat="server" Width="200px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="ButtonPledge" runat="server" Text="Pledge" />
</asp:Panel>
