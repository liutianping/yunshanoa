//function date_compare() {
//    var start = document.getElementById("ContentPlaceHolder6_txtBeginTime").value.toString().replace(/\//, "-");
//    var end = document.getElementById("ContentPlaceHolder6_txtEndTime").value.toString().replace(/\//, "-");
//    
//    if (start == "" || end == "") {
//        alert("日期值输入不能为空！，请重新输入。");
//        return false ;
//    }
//    var a = start.split(" ");
//    var b = a[0].split("-");
//    var c = a[1].split(":");
//    var date_start = new Date(b[0], b[1], b[2], c[0], c[1], c[2]);   //开始日期
//    timestart = b[2] + "-" + b[1] + "-" + b[0] + " " + c[0] + ":" + c[1] + ":" + c[2];
//    a = end.split(" ");
//    b = a[0].split("-");
//    c = a[1].split(":");
//    var date_end = new Date(b[0], b[1], b[2], c[0], c[1], c[2]);     //结束日期
//    timeend = b[2] + "-" + b[1] + "-" + b[0] + " " + c[0] + ":" + c[1] + ":" + c[2];
//    if (date_start > date_end) {
//        alert("开始日期必须小于结束日期！");
//        return false;
//    }
//}


function date_compare() {
    var s = document.getElementById("ContentPlaceHolder6_txtBeginTime").value;
    var s2 = document.getElementById("ContentPlaceHolder6_txtEndTime").value;
    var arr = s.split(/(-|:|(\u0020+))/g);
    var arr2 = s2.split(/(-|:|(\u0020+))/g);
    var d = new Date(arr[0], arr[1] - 1, arr[2], arr[3], arr[4], arr[5]);
    var d2 = new Date(arr2[0], arr2[1] - 1, arr2[2], arr2[3], arr2[4], arr2[5]);

    if (d > d2) {
        alert('会议结束时间不能小于开始时间');
        // document.getElementById("Button1").disabled = true;
    } else {
        // document.getElementById("Button1").disabled = false;
    }
}