<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="Peephole.Areas.LoanApplication.Upload" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row col-sm-12 col-md-12 col-lg-12">
        <div class="col-sm-8 col-md-8 col-lg-8">
            <h1>Loan Application</h1>

            <div>
                <br />
                <asp:Literal ID="label" Text="Amount" runat="server" />
                <asp:TextBox ID="dummyTextbox" runat="server" />
                <br />
                <br />
                <asp:Literal ID="Literal1" Text="Please supply attachment (Proofe of income, real estate information, driver licence, passport..)" runat="server" />
                <asp:FileUpload ID="LoanApplicationToServer" Width="300px" runat="server" />

                <asp:Button ID="btnUpload" runat="server" Text="Apply For Loan" OnClick="btnUpload_Click"
                    ValidationGroup="vg" /><br />
                <br />
                <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Text=""></asp:Label>
                <br />

            </div>
        </div>
        <div class="col-sm-4 col-md-4 col-lg-4">


            <input type="checkbox" id="checkbox1" />
            Show/hide hints
        <div class="hidden-content" id="hidden-content">
            <!-- START hidden content -->

            <!-- YOUR CODE/CONTENT HERE-->
            <h1>Uploaded File Details
            </h1>
            <asp:GridView ID="GridViewUploadedFile" runat="server" EmptyDataText="No files found!"
                AutoGenerateColumns="False" Font-Names="Verdana" AllowPaging="true" PageSize="5"
                Width="50%" OnPageIndexChanging="GridViewUploadedFile_PageIndexChanging" BorderColor="#CCCCCC"
                BorderStyle="Solid" BorderWidth="1px">
                <AlternatingRowStyle BackColor="#FFD4BA" />
                <HeaderStyle Height="30px" BackColor="#FF9E66" Font-Size="15px" BorderColor="#CCCCCC"
                    BorderStyle="Solid" BorderWidth="1px" />
                <RowStyle Height="20px" Font-Size="13px" BorderColor="#CCCCCC" BorderStyle="Solid"
                    BorderWidth="1px" />
                <Columns>
                    <asp:BoundField DataField="rowid" HeaderText="#" HeaderStyle-Width="10%" />
                    <asp:TemplateField HeaderText="List of Files" HeaderStyle-Width="90%">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" Text='<%# Eval("filenameName") %>'
                                NavigateUrl='<%# Eval("filePath") %>'>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <!-- END hidden content -->

        </div>
        </div>
    </div>
</asp:Content>


