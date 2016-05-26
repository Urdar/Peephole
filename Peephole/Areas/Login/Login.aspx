<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Shared/Site.Master" CodeBehind="Login.aspx.cs" Inherits="Peephole.Areas.Login.WebForm2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Login</h1>

    <asp:Table ID="Table1" runat="server" Width="418px" Height="209px">
        <asp:TableRow>
            <asp:TableCell>  
            User Name  
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>  
            Password  
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>

            <asp:TableCell>
                <asp:Button ID="Button2" runat="server" Text="login" OnClick="login_click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Message_click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
