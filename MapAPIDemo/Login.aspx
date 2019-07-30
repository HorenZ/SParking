<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterLoginAndRegister.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MapAPIDemo.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Login.css" rel="stylesheet" />
    <title>登入</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="divContent" runat="server">
    <form  runat="server">
        <div class="mainLogin">
            <div class="div1">
                <p>UserName</p>
                <asp:TextBox runat="server" ID="txbUserName" CssClass="txb"></asp:TextBox>
            </div>
            <div class="div2">
                <p>PassWord</p>
                <asp:TextBox runat="server" ID="txbPWD" CssClass="txb" TextMode="Password"></asp:TextBox>
            </div>
            <div class="div3">
                <asp:Label runat="server" ID="lbMsg" ForeColor="Red"></asp:Label><br/>
                <asp:Button runat="server" ID="btnpost" Text="登录" OnClick="btnpost_OnClick"/>
            </div>
            <hr/>
            <div class="div4">
                <p><small>没有账号？</small></p>
                <asp:Button runat="server" ID="btnRegister" Text="马上注册新账号" OnClick="btnRegister_OnClick"/>
            </div>
        </div>
    </form>
</asp:Content>
