<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Perpus.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-decoration: underline;
            font-size: large;
            text-align: left;
        }
        .style2
        {
            width: 141px;
        }   
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">  
                <caption class="style1">  
                    <strong>Login Form</strong>  
                </caption>  
                <tr>  
                    <td class="style2"></td>  
                    <td></td>  
                    <td></td>  
                </tr>  
                <tr>  
                    <td class="style2">Username:</td>  
                    <td>  
                        <asp:TextBox ID="username" runat="server"></asp:TextBox>  
                    </td>  
                    <td>  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"   
                            ControlToValidate="username" ErrorMessage="Please Enter Your Username"   
                            ForeColor="Red"></asp:RequiredFieldValidator>  
                    </td>  
                </tr>  
                <tr>  
                    <td class="style2">Password:</td>  
                    <td>  
                        <asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox>  
                    </td>  
                    <td>  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"   
                        ControlToValidate="password" ErrorMessage="Please Enter Your Password"   
                        ForeColor="Red"></asp:RequiredFieldValidator>  
                    </td>  
                </tr>  
                <tr>  
                    <td class="style2"></td>  
                    <td></td>  
                    <td></td>  
                </tr>  
                <tr>  
                    <td class="style2"></td>  
                    <td>  
                        <asp:Button ID="Button1" runat="server" Text="Log In" onclick="Button1_Click" />  
                    </td>  
                    <td>  
                        <asp:Label ID="Label1" runat="server"></asp:Label>  
                    </td>  
                </tr>  
            </table>  
        </div>
    </form>
</body>
</html>
