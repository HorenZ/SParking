var btn = document.getElementById('start_btn');
var div = document.getElementById('background');
var close = document.getElementById('close-button');

btn.onclick = function show() {
    div.style.display = "block";
    //var manager = '<%=Session["UserInfo"]%>';
    //alert(manager.UserName);
    //if (manager == null) {
    //    alert('请先登录！');
    //    return;
    //}
    
}

close.onclick = function close() {
    div.style.display = "none";
}

window.onclick = function close(e) {
    if (e.target == div) {
        div.style.display = "none";
    }
}