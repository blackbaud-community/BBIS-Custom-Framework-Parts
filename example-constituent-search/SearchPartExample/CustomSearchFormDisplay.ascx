<%@ assembly Name="SearchPartExample"%>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CustomSearchFormDisplay.ascx.vb" Inherits="SearchPartExample.CustomSearchFormDisplay" %>
<%@ import Namespace="SearchPartExample"%>
<style type="text/css">
    .style2
    {
        width: 67px;
    }
    #Button1
    {
        width: 118px;
    }
    .style3
    {
        height: 23px;
    }
    </style>
<asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="red" />
<asp:Panel ID="PanelSearchFormEntry" runat="server" Height="215px" 
    Width="250px">
    <asp:Label ID="LabelConstituency" runat="server" Text="Constituency"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LabelSearchFormEntry" runat="server" Text="Search criteria"></asp:Label>
    <br />
    <table style="width:100%;">
        <tr>
            <td class="style2">
                <asp:Label ID="LabelFirst" runat="server" Text="First"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxFirst" runat="server" Width="165px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="LabelMiddle" runat="server" Text="Middle"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxMiddle" runat="server" Width="165px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="LabelLast" runat="server" Text="Last"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxLast" runat="server" Width="165px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="ButtonSearch" runat="server" Text="Search" />
</asp:Panel>
<asp:Panel ID="PanelSearchFormResults" runat="server" Height="294px" 
    Width="250px">
    <asp:Label ID="LabelResult" runat="server" Text="First result"></asp:Label>
    <br />
    <table style="width:96%;">
        <tr>
            <td class="style3">
                <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelPhone" runat="server" Text="Phone"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="LabelOtherResults" runat="server" Text="All results"></asp:Label>
    <br />
    <asp:ListBox ID="ListBoxOtherResults" runat="server" Height="150px" 
        Width="237px"></asp:ListBox>
    <br />
    <br />
</asp:Panel>
