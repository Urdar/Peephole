<%@ Page Title="SQL Injection" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Peephole.Areas.SQLIinjection.SQL" ValidateRequest="false" %>

<asp:Content ID="SQLTitle" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="SQLMain" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-8 col-md-8 col-lg-8;">

            <!-- START Vulnerability  -->
            <h1>Employees</h1>
            Find your contact person.

            <h3>Search for an employee</h3>


            First- or lastname: 
                    <asp:TextBox ID="input" Width="50%" runat="server"></asp:TextBox>

            <asp:Button ID="buttonSubmit" OnClick="ButtonSubmitClick" runat="server" Text="Search" />
            <asp:Button ID="buttonShowAll" OnClick="ButtonShowAllClick" runat="server" Text="Show all employees" />
            <asp:Label ID="errorLabel" runat="server" Text="" ></asp:Label>


            <asp:GridView ID="userInfo" Width="100%" runat="server" DataKeyNames="ID" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="EmployeeID" />
                    <asp:BoundField DataField="Firstname" HeaderText="Firstname" />
                    <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                </Columns>
            </asp:GridView>

            <!-- END Vulnerability  -->
            <!-- Codebehind sqlString = "SELECT * FROM Users WHERE ((FirstName LIKE '%" + ID + "%') OR (LastName LIKE '%" + ID + "%')) AND UserType = 1"; --!>

        </div>

        <div class="col-sm-4 col-md-4 col-lg-4">


            <input type="checkbox" id="checkbox1" />
            Show/hide hints
            <div class="hidden-content" id="hidden-content">


                <!-- START Solution -->

                <h2>Task</h2>
                <div class="Solution">

                    <ul>
                        <li>This employee-page is really vulnerable. It's to find the password of the employees. 
                With a simple code 
                        </li>
                    </ul>


                    Search by ID
                    <asp:TextBox ID="inputSolution" Width="50%" runat="server"></asp:TextBox>

                    <asp:Button ID="buttonSubmitSolution" OnClick="ButtonSubmitClickSolution" runat="server" Text="Search" />
                    <p><asp:Label ID="errorLabelSol" runat="server" Text="" ></asp:Label></p>



                    <asp:GridView ID="userInfoSolution" Width="100%" runat="server" DataKeyNames="ID" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="EmployeeID" />
                            <asp:BoundField DataField="Firstname" HeaderText="Firstname" />
                            <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                        </Columns>
                    </asp:GridView>




                    <h2>Other solutions</h2>
                    There are a lot of solutions to the SQL-injection problem. The solution above works well if you only want numbers, but in other cases it might not work as well as you want.
            A proper solution which is SQL-injection proof is using <a href="https://en.wikipedia.org/wiki/Object-relational_mapping">ORM (Object relation mapping)</a>.
            Examples of this is the <a href="http://www.asp.net/entity-framework">Entity Framework</a> and <a href="https://msdn.microsoft.com/en-us/library/bb386976(v=vs.110).aspx">LINQ to SQL</a>.

            <p>

                <asp:Button ID="resetDb" OnClick="ButtonResetDatabase" runat="server" Text="Reset database" />
            </p>
                </div>
                <!-- END Solution -->

                <p>
                    What we want you to do here is expoiting the database using an SQL Injection. The code is poorly written on purpose.
                </p>
               
            </div>
        </div>

    </div>

</asp:Content>

