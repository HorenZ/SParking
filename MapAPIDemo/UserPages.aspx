<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPages.aspx.cs" Inherits="MapAPIDemo.UserPages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/UserCenter.css" rel="stylesheet" />
    <link href="CSS/TC.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人中心</title>
</head>
<body>
<header class="header1"></header>
<form id="form1" runat="server" method="post">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="father">
        <asp:UpdatePanel ID="up1" runat="server" RenderMode="Inline">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_OnTick" Interval="1000"></asp:Timer>
                <div class="datetimeNow"><asp:Label runat="server" ID="lbTimeNow"></asp:Label></div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="Msg">
            <div class="MsgHead">最新公告</div>
            <div class="MsgText"><asp:Label runat="server" ID="lbMsg"></asp:Label></div>
        </div>
        <div class="SAM">
            <div class="twobox" id="divState">
                <div class="divstate">
                    <span class="WelComeText">欢迎您!
                        <span class="Susername"><asp:Label runat="server" ID="lbUsername"></asp:Label></span>
                    </span><br/>
                    <input type="button" class="btnState1" value="账户状态"/>
                    <asp:Button runat="server" Text="正常" ID="btnStatr2" CssClass="btnState2"/>
                    <input type="button" id="btnManagerCar" value="管理车辆" class="btnManagerCar"/>
                </div>
            </div>
            <div class="twobox" id="divMoney">
                <div class="divmoney">
                    <span class="WelComeText">账号余额</span>
                    <asp:Label runat="server" ID="lbMoney" Text="13￥" CssClass="SMoney1"></asp:Label>
                </div>
                <asp:Button runat="server" Text="充值" ID="btnaddMoney" CssClass="addmoney"/>
                
            </div>
            <br/>
        </div>
        <div class="Updatepwd">
            <div class="Uphead">修改密码</div>
            <div class="upcontent">
                新密码:<asp:TextBox ID="txbOldPwd" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                确认密码:<asp:TextBox runat="server" ID="txbNewPwd"></asp:TextBox>
                
                <asp:Button runat="server" OnClick="btnUpdate_OnClick" ID="btnUpdate" Text="提交"/>
                <br />
                <asp:Label ID="lbUpdataMsg" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>
    <!-- 弹窗内容开始 -->
    <div id="background" class="back">
        <div id="div1" class="content">
            <div id="close">
                <span id="close-button">×</span>
                <h2>弹窗头部</h2>
            </div>
            <div id="div2">
                <asp:UpdatePanel ID="up2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pManager" runat="server">
                            <asp:RadioButtonList runat="server" ID="RBLCarInfo" OnSelectedIndexChanged="RBLCarInfo_SelectedIndexChanged"/>
                            <asp:Button runat="server" ID="btnNewCar" Text="添加" OnClick="btnNewCar_OnClick"/>
                            <asp:Button runat="server" ID="btnUpdatacar" Visible="False" Text="修改" OnClick="btnUpdatacar_OnClick"/>
                            <asp:Button runat="server" ID="btnDelete" Visible="False" Text="删除" OnClick="btnDelete_OnClick" OnClientClick="return confirm('是否确定删除？')"/>
                        </asp:Panel>
                    
                        
                        <asp:Panel runat="server" ID="paddCar" Visible="False">
                            &nbsp;&nbsp;&nbsp; 您所在的省份:<asp:DropDownList runat="server"/>&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" placeholder="车牌号" ID="txbcarNum"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="btnSaveCar" Text="保存" OnClick="btnSaveCar_OnClick"/>
                            &nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="btnExit" Text="取消" OnClick="btnExit_OnClick"/>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pUpdataCar" Visible="False">
                            原来的车牌号：<asp:Label runat="server" ID="lbOldCarNum"></asp:Label><br/>
                            新的车牌号：<asp:TextBox runat="server" ID="txbNewCarNum"></asp:TextBox>
                            <asp:Button runat="server" ID="btnUpdataCarNum" Text="保存" OnClick="btnUpdataCarNum_Click"/>
                            <asp:Button runat="server" ID="btnExit2" Text="取消" OnClick="btnExit2_OnClick"/>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </div>
            <h3 id="foot">底部内容</h3>
        </div>
    </div>
    <!-- 弹窗内容结束 -->
</form>
<footer class="f1" style="display: none;">331</footer> 
</body>
</html>
<script type="text/javascript">
    var btn = document.getElementById('btnManagerCar');
    var div = document.getElementById('background');
    var close = document.getElementById('close-button');

    btn.onclick = function show() {
        div.style.display = "block";
    }

    close.onclick = function close() {
        div.style.display = "none";
    }

    window.onclick = function close(e) {
        if (e.target == div) {
            div.style.display = "none";
        }
    }
</script>