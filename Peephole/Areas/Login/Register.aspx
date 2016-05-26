<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Shared/Site.Master" CodeBehind="Register.aspx.cs" Inherits="Peephole.Areas.Login.CheckEmail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Register user</h1>

    <asp:Table ID="Table1" runat="server" Width="418px" Height="209px">
        <asp:TableRow>
            <asp:TableCell>  
            First Name  
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>  
            Last Name  
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
                <asp:Label ID="Labelinfo" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>  
            Email  
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBox1" runat="server" type="email"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>  
            Password  
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="Buttonchekexistance" runat="server" Text="Register" OnClick="Buttonchekexistance_Click" />
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
</asp:Content>

