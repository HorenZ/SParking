<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAndRegister.aspx.cs" Inherits="MapAPIDemo.LoginAndRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="CSS/Login.css" rel="stylesheet" />
    <title>登录</title>
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel runat="server" ID="panLogin" Visible="True">
                <table>
                    <tr><th colspan="2">登录</th></tr>
                    <tr>
                        <td>用户名：</td><td><asp:TextBox  ID="txbUName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>密&nbsp;码：</td><td><asp:TextBox ID="txbPWD" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;"><asp:Button runat="server" Text="登录" ID="btnLogin" OnClick="btnLogin_Click"/>
                            &nbsp;&nbsp;<asp:Button runat="server" Text="注册" OnClick="Register" ID="btnRegister"/></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;"><asp:Label runat="server" ID="lbMsg1" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
            </asp:Panel>   
            
            <asp:Panel runat="server" ID="PanRegister" Visible="False">
                <table>
                    <tr><th colspan="2">注册</th></tr>
                    <tr>
                        <td>用户名：</td>
                        <td><asp:TextBox runat="server" ID="txbUnameRe"></asp:TextBox></td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="20位以下，推荐使用手机号码,12位以下" ControlToValidate="txbUnameRe" ForeColor="Red" ValidationExpression="^\w{0,12}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>密&nbsp;码：</td><td><asp:TextBox runat="server" ID="txbPwdRe" TextMode="Password"></asp:TextBox></td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="6~12位仅可使用字母、数字、下划线" ForeColor="Red" ValidationExpression="^\w{6,12}$" ControlToValidate="txbPwdRe"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">确认密码:</td><td class="auto-style1"><asp:TextBox runat="server" ID="txbPwdRe2" TextMode="Password"></asp:TextBox></td>
                        <td class="auto-style1">
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txbPwdRe" ControlToValidate="txbPwdRe2" ErrorMessage="两次密码不相同！" ForeColor="Red"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>手机号码：</td><td><asp:TextBox runat="server" ID="txbPhoneRe"></asp:TextBox></td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="11位数" ControlToValidate="txbPhoneRe" ForeColor="Red" ValidationExpression="^1[0-9]{10}$"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td>车牌号:</td><td><asp:TextBox runat="server" ID="txbCarNumber"></asp:TextBox></td>
                        <td><span style="color: red;">可为空，后面再添加</span></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;"><asp:Button runat="server" Text="注册" ID="btnsubmit" OnClick="btnsubmit_Click"/></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="lbMsg" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:RadioButtonList ID="rblCarNum" runat="server">
                </asp:RadioButtonList>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
