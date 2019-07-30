<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterLoginAndRegister.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MapAPIDemo.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Register.css" rel="stylesheet" />
    <title>注册</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="divContent" runat="server">
    <form  runat="server">
        <div class="mainRegister">
            <div class="div1">
                <p>用户名</p>
                <asp:TextBox runat="server" CssClass="txb" ID="txbUnameRe"></asp:TextBox><br/>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="推荐使用手机号码,12位以下" ControlToValidate="txbUnameRe" ForeColor="Red" ValidationExpression="^\w{0,12}$" Font-Size="15px"></asp:RegularExpressionValidator>
            </div>
            <div class="div2">
                <p>密码</p>
                <asp:TextBox runat="server" CssClass="txb" ID="txbPwdRe" TextMode="Password"></asp:TextBox><br/>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="6~12位仅可使用字母、数字、下划线" ForeColor="Red" ValidationExpression="^\w{6,12}$" ControlToValidate="txbPwdRe" Font-Size="15px"></asp:RegularExpressionValidator>
            </div>
            <div class="div3">
                <p>确认密码</p>
                <asp:TextBox runat="server" CssClass="txb"  ID="txbPwdRe2" TextMode="Password"></asp:TextBox><br/>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txbPwdRe" ControlToValidate="txbPwdRe2" ErrorMessage="两次密码不相同！" ForeColor="Red" Font-Size="15px"></asp:CompareValidator>
            </div>
            <div class="div4">
                <p>手机号码</p>
                <asp:TextBox runat="server" CssClass="txb"  ID="txbPhoneRe"></asp:TextBox><br/>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="11位数" ControlToValidate="txbPhoneRe" ForeColor="Red" ValidationExpression="^1[0-9]{10}$" Font-Size="15px"></asp:RegularExpressionValidator>
            </div>
            <div class="div5">
                <p>车牌号</p>
                <asp:TextBox runat="server" CssClass="txb"  ID="txbCarNumber"></asp:TextBox>
            </div>
            <div class="div6">
                <p><asp:Label runat="server" ID="lbMsg" ForeColor="Red"></asp:Label></p>
                <asp:Button runat="server" CssClass="btn" Text="注 册" OnClick="Unnamed1_Click"/>
            </div>
        </div>
    </form>
</asp:Content>
