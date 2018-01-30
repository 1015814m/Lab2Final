<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Project.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project | John Morrissey Lab 2</title>
    <link href="Lab2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Project</h1>
        <ul>
            <li><a href="Masterpage.aspx">Main Page</a></li>
            <li><a href="Lab1.aspx">Employee</a></li>
            <li><a class="active" href="Project.aspx">Project</a></li>
            <li><a href="Skill.aspx">Skill</a></li>
        </ul>

        
    </div>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow >
                <asp:TableCell >
                    <asp:Label ID="lblProjectID" runat="server" Text="Project ID:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell >
                    <asp:TextBox CssClass="inputText" ID="txtProjectID" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow >
                <asp:TableCell >
                    <asp:Label ID="lblProjectName" runat="server" Text="Project Name:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell >
                    <asp:TextBox CssClass="inputText" ID="txtProjectName" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow >
                <asp:TableCell >
                    <asp:Label ID="lblProjectDescription" runat="server" Text="Project Description:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell >
                    <asp:TextBox CssClass="inputText" ID="txtProjectDescription" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>


        </asp:Table>
        <asp:Button CssClass="btn" ID="btnCommitProject" runat="server" Text="Commit Project" />
    </form>
</body>
</html>
