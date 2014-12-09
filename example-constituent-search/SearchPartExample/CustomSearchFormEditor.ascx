<%@ assembly Name="SearchPartExample"%>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CustomSearchFormEditor.ascx.vb" Inherits="SearchPartExample.CustomSearchFormEditor" %>
<%@ import Namespace="SearchPartExample"%>
<asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="red" />
<p>
    <asp:RadioButtonList ID="RadioButtonListConstituencies" runat="server">
        <asp:ListItem>Board member</asp:ListItem>
        <asp:ListItem>Donor</asp:ListItem>
        <asp:ListItem>Fundraiser</asp:ListItem>
        <asp:ListItem>Volunteer</asp:ListItem>
        <asp:ListItem>All</asp:ListItem>
    </asp:RadioButtonList>
</p>
<p>
    Select the constituency on which to filter the individual search.</p>
