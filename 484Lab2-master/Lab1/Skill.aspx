<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Skill.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Skill | John Morrissey Lab 2</title>
    
    <link href="Lab2.css" rel="stylesheet" />
</head>
    
<body style="height: 202px">
    <form id="form1" runat="server">
        <h1>Skill</h1>
        <ul>
            <li><a href="Masterpage.aspx">Main Page</a></li>
            <li><a href="Lab1.aspx">Employee</a></li>
            <li><a href="Project.aspx">Project</a></li>
            <li><a class="active" href="Skill.aspx">Skill</a></li>
        </ul>
    <div>
        
    </div>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow ID="row1" runat="server">
                <asp:TableCell >
                    <asp:Label ID="lblSkillID" runat="server" Text="Skill ID:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell >
                    <asp:TextBox CssClass="inputText" ID="txtSkillID" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="row2" runat="server">
                <asp:TableCell >
                    <asp:Label ID="lblSkillName" runat="server" Text="Skill Name:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell >
                    <asp:TextBox CssClass="inputText" ID="txtSkillName" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow >
                <asp:TableCell >
                    <asp:Label ID="lblSkillDescription" runat="server" Text="Skill Description:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell >
                    <asp:TextBox CssClass="inputText" ID="txtSkillDescription" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button CssClass="btn" ID="btnSkillCommit" runat="server" Text="Commit Skill" OnClick="btnSkillCommit_Click" />
    </form>
</body>
</html>
