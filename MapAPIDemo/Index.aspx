<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MapAPIDemo.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>    
    <link href="CSS/Index.css" rel="stylesheet" />
    <script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=tbBzrgcmvGygB8EpWYr7kgkxi0CShQSM"></script>
    <link href="CSS/PartInfoCSS.css" rel="stylesheet" />
    <title>速泊——你的停车助手</title>
</head>
<body>
<form id="form1" runat="server">
    <header class="header1">
    <div style="float: right;text-align:center;margin-right: 10%;">
        <asp:LinkButton runat="server" Text="登录/注册" OnClick="LoginAndRegister" CssClass="sp1" ID="lkbtn1"></asp:LinkButton>
    </div>
</header>
    <div class="main1">
    <div id="allmap"></div>
    <div class="Info">
        <div class="Find">
            <div id="r-result"><input type="text" id="suggestId"  placeholder="请输入" style="width:80%;height: 30px;margin-top: 25px;" /></div>
            <div id="searchResultPanel" style="border:1px solid #C0C0C0;width:150px;height:auto; display:none;"></div>
        </div>
        
        <div id="ports">
            <div class="partInfo" id="partInfo">
                <div class="partName" id="partName">
                    <p id="pname"></p>
                    <p id="ptime" style="font-size: 10px;"></p>
                </div>
                
                    <div class="partInfo_c">
                        <div class="OhterInfo">
                            <p id="yes"><img class="y" src="Images/yes.png"/>支持分配车位</p>
                            <p id="no"><img class="n" src="Images/no.png"/>暂不支持分配车位</p>
                        </div>
                        <div class="partGrade" id="partGrade">
                            
                        </div>
                    </div>
                    <div class="PriceAndOK">
                        <div class="partPrice" id="partPrice">99</div>
                        <div class="btnOK" id="btnOK">
                            <%--<asp:Button runat="server" ID="start_btn1" OnClientClick="show()" CssClass="btn" Text="开始导航1" UseSubmitBehavior="False"/>--%>
                            <input type="button" id="start_btn" class="btn" value="开始导航"/>
                        </div>
                    </div>
            </div>
        </div>
        <div id="DH"></div>
        <!-- 弹窗内容开始 -->
        <div id="background" class="back">
            <div id="div1" class="content">
                <div id="close">
                    <span id="close-button">×</span>
                    <h2 id="head_h2">最后一步</h2>
                </div>
                <div id="div2">
                    <h3>确定您的信息</h3>
                    <p>选择你的车辆</p>
                    
                    <asp:RadioButtonList ID="rblCarNum" runat="server"></asp:RadioButtonList>
                    <asp:Label runat="server" ID="lbmsgNoCar" Visible="False" Text="未添加车牌号！请添加车牌号:"></asp:Label>
                    <asp:TextBox runat="server" ID="txbNewCar" Visible="False"></asp:TextBox>
                    <asp:Button runat="server" ID="btnAddCar" Visible="False" Text="添加" OnClick="btnAddCar_OnClick"/>
                    <asp:Button runat="server" ID="btnGotoport" Text="立即前往" OnClick="btnGotoport_OnClick"/>
                    <input type="hidden" id="txbPortName" runat="server"/>
                    <input type="hidden" id="txbPrice" runat="server"/>
                    <asp:LinkButton runat="server" ID="gotoLogin" Text="未登录！点击这里去登录！" Visible="False" OnClick="gotoLogin_OnClick"></asp:LinkButton>
                </div>
                <h3 id="foot"></h3>
            </div>
        </div>
        <!-- 弹窗内容结束 -->
    </div>
</div></form>
<footer class="f1">331</footer>

<script src="JS/TC.js" type="text/javascript"></script>
<script src="JS/Index.js" type="text/javascript"></script>
</body>
</html>

<script type="text/javascript">
    // 百度地图API功能
    var YourLocationPoint;
    var YourCity;
    var map = new BMap.Map("allmap", { minZoom: 8, maxZoom: 18 });    // 创建Map实例
    var geolocation = new BMap.Geolocation();
    geolocation.getCurrentPosition(function (r) {
        if (this.getStatus() == BMAP_STATUS_SUCCESS) {
            var mk = new BMap.Marker(r.point);
            map.addOverlay(mk);
            map.centerAndZoom(r.point, 16);
            YourLocationPoint = r.point;
            GetCity(YourLocationPoint);
        }
        else {
            alert('failed' + this.getStatus());
        }
    }, { enableHighAccuracy: true })
    map.enableScrollWheelZoom(true);     //开启鼠标滚轮缩放

    
    
    // 添加定位控件
    var geolocationControl = new BMap.GeolocationControl();
    geolocationControl.addEventListener("locationSuccess", function (e) {
        // 定位成功事件
        var address = '';
        address += e.addressComponent.province;
        address += e.addressComponent.city;
        address += e.addressComponent.district;
        address += e.addressComponent.street;
        address += e.addressComponent.streetNumber;
        //保存当前位置信息
        //alert("11");
        YourLocationPoint = e.point;
        GetCity(YourLocationPoint);
        map.panTo(e.point);
        var marker = new BMap.Marker(e.point);
        map.addOverlay(marker);
        bdGEO();
    });
    geolocationControl.addEventListener("locationError", function (e) {
        // 定位失败事件
        alert(e.message);
    });
    map.addControl(geolocationControl);

    //定位搜索
    var ac = new BMap.Autocomplete(    //建立一个自动完成的对象
        {"input" : "suggestId"
            ,"location" : map
        });
    ac.addEventListener("onhighlight", function(e) {  //鼠标放在下拉列表上的事件
        var str = "";
        var _value = e.fromitem.value;
        var value = "";
        if (e.fromitem.index > -1) {
            value = _value.province +  _value.city +  _value.district +  _value.street +  _value.business;
        }    
        str = "FromItem<br />index = " + e.fromitem.index + "<br />value = " + value;
    
        value = "";
        if (e.toitem.index > -1) {
            _value = e.toitem.value;
            value = _value.province +  _value.city +  _value.district +  _value.street +  _value.business;
        }    
        str += "<br />ToItem<br />index = " + e.toitem.index + "<br />value = " + value;
        G("searchResultPanel").innerHTML = str;
    });
    var myValue;
    ac.addEventListener("onconfirm", function(e) {    //鼠标点击下拉列表后的事件
        var _value = e.item.value;
        myValue = _value.province +  _value.city +  _value.district +  _value.street +  _value.business;
        G("searchResultPanel").innerHTML ="onconfirm<br />index = " + e.item.index + "<br />myValue = " + myValue;
        
        setPlace();
        
    });

    //读取车库信息集合
    var ListPartInfo = <%=ReturnType()%>;

    // 创建地址解析器实例
    var myGeo = new BMap.Geocoder();
    var addsIndex = 0;
    var Parts = [];
    //创建驾车规划助手
    var driving = new BMap.DrivingRoute(map, { renderOptions: { map: map, autoViewport: true } });
    //读取停车场集合
    for (var i = 0; i < ListPartInfo.length; i++) {
        Parts.push(ListPartInfo[i]);
    }
    bdGEO();

    
    var searchComplete = function (results) {
        if (transit.getStatus() != BMAP_STATUS_SUCCESS) {
            alert('123');
            return;
        }
        var output = '需要时间:';
        var plan = results.getPlan(0);
        output += plan.getDuration(true) + "\n";                //获取时间
        output += "总路程为:";
        output += plan.getDistance(true) + "\n";             //获取距离
        G('ptime').innerText = output;
    }
    var transit = new BMap.DrivingRoute(map, {
        renderOptions: {
            map: map,
            panel: 'DH'
        },
        onSearchComplete: searchComplete
    });

</script>
