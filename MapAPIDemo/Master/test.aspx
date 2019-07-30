<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="MapAPIDemo.Master.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
<asp:Button runat="server" Text="123" ID="s23s" OnClick="s23s_OnClick"/>
                    <asp:Panel runat="server" ID="b111" Visible="False"><asp:Button runat="server" ID="b1121" Text="NO" Visible="True"/></asp:Panel>
            
            <asp:Button runat="server" ID="a222" Text="Yes"/>
                </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
    </form>
</body>
</html>
