<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lab1.aspx.cs" Inherits="ApplicationDriver"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>John Morrissey Lab 1</title>
    <link href="Lab2.css" rel="stylesheet" />
    
    <style>
        
        #Label1 {
            font-size: 200%;
        }

        .formLabel {

        }

        .longInput {
            width: 30%;
            
        }

        .mediumInput {
            width: 12%;
            
        }

        .shortInput {
            width: 5%;
            
        }

        input[type=text] {
            color: whitesmoke;
            background-color: midnightblue;
            border: none;
            border-radius: 4px;
        }

        .btn {
            margin: 5px;
            border-radius: 4px;
            background-color: midnightblue;
            color: whitesmoke;
        }

        
        .auto-style1 {
            width: 206px;
        }

        
        .auto-style2 {
            width: 1003px;
            margin-right: 81px;
        }
        .auto-style3 {
            width: 744px;
        }

        .required {
            color: red;
        }

        
    </style>
    
    
</head>
<body>
    <!-- John Morrissey Lab 1 -->
    <form id="form1" runat="server">
    <div>
    
        <h1>Employee</h1>
    
    
        <ul>
            <li><a href="Masterpage.aspx">Main Page</a></li>
            <li><a class="active" href="Lab1.aspx">Employee</a></li>
            <li><a href="Project.aspx">Project</a></li>
            <li><a href="Skill.aspx">Skill</a></li>
        </ul>
    
       
    </div>
    <!-- This is the table that contains my user inputs 
        The user information will be seperated into 3 sections-->
    <table class="auto-style2"  >
        <tr>
            <td class="auto-style1">First Name</td>
            <td class="auto-style3"><input id="txtFirstName" runat="server" class="longInput" type="text" maxlength="20"  /></td>
            <td class="required"><asp:RequiredFieldValidator ID="reqFirstNameInput" ControlToValidate="txtFirstName" Text="(Required)" runat="server"  ></asp:RequiredFieldValidator> </td>
        </tr>
        
        <tr>
            <td class="auto-style1">Last Name</td>
            <td class="auto-style3"><input id="txtLastName" runat="server" class="longInput" type="text" maxlength="30"  /></td>
            <td class="required"><asp:RequiredFieldValidator ID="reqLastNameInput" ControlToValidate="txtLastName" Text="(Required)" runat="server" ></asp:RequiredFieldValidator> </td>
        </tr>
        <tr>
            <td class="auto-style1">MI*</td>
            <td class="auto-style3"> <input id="txtMI"  runat="server" class="shortInput" type="text" maxlength="1" /></td>
            <td class="required"><asp:RequiredFieldValidator ID="reqMiddleNameInput" ControlToValidate="txtMI" Text="(Required)" runat="server" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style1">DOB</td>
            <td class="auto-style3"> <input placeholder="YYYY-MM-DD" id="txtDOB" runat="server" class="mediumInput" type="text" maxlength="10" /></td>
            <td class="required"><asp:RequiredFieldValidator ID="reqDateOfBirth" ControlToValidate="txtDOB" Text="(Required)" runat="server" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <!-- Insert a line break between the first section of employee info -->
            <td class="auto-style1"><br /></td>
        </tr>

        <tr>
            <td class="auto-style1">House Number</td>
            <td class="auto-style3"> <input id="txtHouseNum" runat="server" class="mediumInput" type="text" maxlength="10"/></td>
            <td class="required"><asp:RequiredFieldValidator ID="reqHouseNum" ControlToValidate="txtHouseNum" Text="(Required)" runat="server" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style1">Street</td>
            <td class="auto-style3"> <input id="txtStreet" runat="server" class="longInput" type="text" maxlength="20"/></td>
            <td class="required"><asp:RequiredFieldValidator ID="reqStreet" ControlToValidate="txtStreet" Text="(Required)" runat="server" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style1">County/City</td>
            <td class="auto-style3"> <input id="txtCounty" runat="server" class="longInput" type="text" maxlength="25"/></td>
            <td class="required"><asp:RequiredFieldValidator ID="reqCounty" ControlToValidate="txtCounty" Text="(Required)" runat="server" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style1">State Abb*</td>
            <td class="auto-style3"> <input id="txtState" maxlength="2" runat="server" class="shortInput" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style1">Country Abb</td>
            <td class="auto-style3"> <input id="txtCountry" maxlength="2" runat="server" class="shortInput" type="text" /></td>
            <td class="required"><asp:RequiredFieldValidator ID="reqCountry" ControlToValidate="txtCountry" Text="(Required)" runat="server" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style1">Zip Code</td>
            <td class="auto-style3"> <input id="txtZip" runat="server" class="mediumInput" type="text" maxlength="5"/></td>
            <td class="required"><asp:RequiredFieldValidator ID="reqZip" ControlToValidate="txtZip" Text="(Required)" runat="server" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <!-- Insert a line break between the first and second section of employee info -->
            <td class="auto-style1"><br /></td>
        </tr>

        <tr>
            <td class="auto-style1">Hire Date</td>
            <td class="auto-style3"> <input id="txtHireDate" runat="server" placeholder="YYYY-MM-DD" class="mediumInput" type="text" maxlength="10"/></td>
            <td class="required"><asp:RequiredFieldValidator ID="reqHireDate" ControlToValidate="txtHireDate" Text="(Required)" runat="server" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style1">Termination Date*</td>
            <td class="auto-style3"> <input id="txtTerminationDate" runat="server" placeholder="YYYY-MM-DD" class="mediumInput" type="text" maxlength="10"/></td>

        </tr>
        <tr>
            <td class="auto-style1">Salary</td>
            <td class="auto-style3"> <input id="txtSalary" runat="server" placeholder="e.g. 50000" class="mediumInput" type="text" /></td>
            <td class="required"><asp:RequiredFieldValidator ID="reqSalary" ControlToValidate="txtSalary" Text="(Required)" runat="server" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style1">Employee ID</td>
            <td class="auto-style3"> <input id="txtEmployeeID" runat="server" class="shortInput" type="text" /> </td>
            <td class="required"><asp:RequiredFieldValidator ID="reqEmployeeID" ControlToValidate="txtEmployeeID" Text="(Required)" runat="server" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style1">Manager ID*</td>
            <td class="auto-style3"> <input id="txtManagerID" runat="server" class="shortInput" type="text" /></td>
        </tr>
        
        <tr>
            <td class="auto-style1">Skills</td>
            <td class="auto-style3"><asp:DropDownList CssClass="longInput" ID="dropDownSkills" runat="server" >
                </asp:DropDownList >
            </td>
        </tr>
        
    </table>
    <p>*Fields are optional</p>
    <!-- These are the buttons that provide functionality -->
    <section>
        <asp:Button CssClass="btn" ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert"  />
        <asp:Button CssClass="btn" ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
        <asp:Button CssClass="btn" ID="btnCommit" runat="server" OnClick="btnCommit_Click" Text="Employee Commit" />
        <asp:Button CssClass="btn" ID="btnExit" runat="server" OnClick="btnExit_Click" Text="Exit"  formnovalidate=""/>


    </section>
    </form>
    <footer>
        <asp:Label ID="resultMessage" runat="server" visible="false"></asp:Label>
        <asp:Label ID="alertMessage" runat="server" CssClass="required"></asp:Label>
        
    </footer>
</body>

    
</html>
