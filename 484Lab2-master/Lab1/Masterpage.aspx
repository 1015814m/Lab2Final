<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Masterpage.aspx.cs" Inherits="_Default"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Page | John Morrissey Lab 2</title>
    <link href="Lab2.css" rel="stylesheet" />
    
    
</head>
<body style="height: 521px">
    <form id="form1" runat="server">
        <h1>Main Page</h1>
        <ul runat="server">
            <li><a class="active" href="Masterpage.aspx" >Main Page</a></li>
            <li><a href="Lab1.aspx">Employee</a></li>
            <li><a href="Project.aspx">Project</a></li>
            <li><a href="Skill.aspx">Skill</a></li>
        </ul>

    <div>
        
    </div>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="employeeAllInformation" Height="118px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="146px" AutoGenerateColumns="False" DataKeyNames="EmployeeID">
            <Columns>
                <asp:BoundField  DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" SortExpression="EmployeeID" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField Visible="false" DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="MI" HeaderText="MI" SortExpression="MI" />
                <asp:BoundField DataField="HouseNumber" HeaderText="HouseNumber" SortExpression="HouseNumber" />
                <asp:BoundField DataField="Street" HeaderText="Street" SortExpression="Street" />
                <asp:BoundField DataField="CityCounty" HeaderText="CityCounty" SortExpression="CityCounty" />
                <asp:BoundField DataField="StateAbb" HeaderText="StateAbb" SortExpression="StateAbb" />
                <asp:BoundField DataField="CountryAbb" HeaderText="CountryAbb" SortExpression="CountryAbb" />
                <asp:BoundField DataField="Zip" HeaderText="Zip" SortExpression="Zip" />
                <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" />
                <asp:BoundField DataField="HireDate" HeaderText="HireDate" SortExpression="HireDate" />
                <asp:BoundField DataField="TerminationDate" HeaderText="TerminationDate" SortExpression="TerminationDate" />
                <asp:BoundField DataField="Salary" HeaderText="Salary" SortExpression="Salary" />
                <asp:BoundField DataField="ManagerID" HeaderText="ManagerID" SortExpression="ManagerID" />
                <asp:BoundField DataField="LastUpdatedBy" HeaderText="LastUpdatedBy" SortExpression="LastUpdatedBy" />
                <asp:BoundField DataField="LastUpdated" HeaderText="LastUpdated" SortExpression="LastUpdated" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource  ID="employeeAllInformation" runat="server" ConnectionString="<%$ ConnectionStrings:Lab2ConnectionString %>" SelectCommand="SELECT * FROM [Employee]"></asp:SqlDataSource>
        <asp:Button CssClass="btn" ID="btnEmployee" runat="server" Text="Display Employee Info" OnClick="btnEmployee_Click" />
        <asp:Button CssClass="btn" ID="btnProject" runat="server" Text="Display Project Info" OnClick="btnProject_Click" />
        <asp:Button CssClass="btn" ID="btnSkill" runat="server" Text="Display Skill Info" OnClick="btnSkill_Click" />
        <p>
            <asp:CheckBox Text="Display All Employee Information" ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />
        </p>
        <asp:Label ID="lblUser" runat="server" Text="User: "></asp:Label>
        <asp:TextBox CssClass="inputText" ID="txtUser" runat="server"></asp:TextBox>
        <p>
        <asp:Button CssClass="btn" ID="btnLogin" runat="server" Text="Login" />
        </p>
    </form>
</body>
</html>
