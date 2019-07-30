

function G(id) {
    return document.getElementById(id);
}

//获取cookie
function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i].trim();
        if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
    }
    return "";
}

//添加车库地标
function bdGEO() {
    var add = Parts[addsIndex];
    geocodeSearch(add);
    addsIndex++;
}

function geocodeSearch(add) {
    if (addsIndex < Parts.length) {
        setTimeout(window.bdGEO, 400);
    }
    myGeo.getPoint(add.Address, function (point) {
        if (point) {
            var partadd = new BMap.Point(point.lng, point.lat); 
            addMarker(add,partadd, new BMap.Label(add.Name, { offset: new BMap.Size(20, -10) }));
        }
    }, YourCity);
}

// 编写自定义函数,创建标注
function addMarker(part,point, txtadds) {
    var marker = new BMap.Marker(point);
    //注册点击事件
    marker.addEventListener("click", function (event) { ClickMark(event, part, point)});
    map.addOverlay(marker);
    marker.setLabel(txtadds);
}

var MyLoactionAdds;

//获取你的城市q
function GetCity(point) {
    myGeo.getLocation(point, function (rs) {
        MyLoactionAdds = rs.addressComponents;
        YourCity = MyLoactionAdds.city;
        
    })
}

//搜索提示
function setPlace() {
    map.clearOverlays();    //清除地图上所有覆盖物
    function myFun() {
        var pp = local.getResults().getPoi(0).point;    //获取第一个智能搜索的结果
        map.centerAndZoom(pp, 18);
        map.addOverlay(new BMap.Marker(pp));    //添加标注
    }
    var local = new BMap.LocalSearch(map, { //智能搜索
        onSearchComplete: myFun
    });
    local.search(myValue);
}

//地标点击事件
function ClickMark(e,part,point) {
    //1.准备参数

    //2.展示信息
    CountStar(part.Grade);
    GetName(part.Name);
    GetChoose(part.Choose);
    G('partPrice').innerText = part.Price + "/H";
    G('txbPortName').value = part.Name;
    G('txbPrice').value = part.Price;
    G('partPrice').style.visibility = 'visible';
    G('btnOK').style.visibility = 'visible';
    //用cookies存储点击信息
    document.cookie = "endpointlng=" + point.lng;
    document.cookie = 'endpointlat=' + point.lat;
    //创建路线
    transit.search(YourLocationPoint, point);
}

//绘制星星
function CountStar(Grade) {
    //绘制星星
    function drawStar(s0, s1, s2) {
        var Star = G("partGrade");
        //清空原来的
        Star.innerHTML = '';
        var imgHTLM2 = "<img class='Star' src='Images/1.png'/>";
        var imgHTML0 = '<img class="Star" src="Images/0.png"/>';
        var imgHTML1 = '<img class="Star" src="Images/0.5.png"/>';
        for (s2; s2 > 0; s2--) {
            Star.innerHTML += imgHTLM2;
        }
        if (s1 == 1) {
            Star.innerHTML += imgHTML1;
        }
        for (s0; s0 != 0; s0--) {
            Star.innerHTML += imgHTML0;
        }
    }
    var s2;     //星星
    var s1;     //半星
    var s0;     //空星
    //计算星星
    if (parseFloat(Grade) % 1 == 0) {
        s2 = parseFloat(Grade) / 1;
        s1 = 0;
        s0 = 5 - s2;
        //绘制五角星
        
        drawStar(s0, s1, s2);

    } else {
        s2 = parseFloat(Grade) - 0.5 / 1;
        s1 = 1;
        s0 = 5 - s2 - s1;
        //绘制
        drawStar(s0, s1, s2);
    }
}

//获取名字
function GetName(Name) {
    var lbname = G("pname");
    lbname.innerText = Name;
}

//读取是否支持分配车位
function GetChoose(Choose) {
    if (Choose == true) {
        G("yes").style.display = 'inline';
        G("no").style.display = 'none';
    }
    if (Choose == false) {
        G("yes").style.display = 'none';
        G("no").style.display = 'inline';
    }
}

function DHStart() {
    //var l1 = YourLocationPoint;
    //var l2 = new BMap.Point(getCookie('endpointlng'), getCookie('endpointlat'));
    //transit.search(l1, l2);
}