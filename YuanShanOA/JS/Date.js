﻿function showLocale(objD) {
    var str, colorhead, colorfoot;
    var WW = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"];
    var yy = objD.getYear();
    if (yy < 1900) yy = yy + 1900;
    var MM = objD.getMonth() + 1;
    if (MM < 10) MM = '0' + MM;
    var dd = objD.getDate();
    if (dd < 10) dd = '0' + dd;
    var hh = objD.getHours();
    if (hh < 10) hh = '0' + hh;
    var mm = objD.getMinutes();
    if (mm < 10) mm = '0' + mm;
    var ss = objD.getSeconds();
    if (ss < 10) ss = '0' + ss;
    var ww = objD.getDay();
    if (ww == 0) colorhead = "<font color=\"#FF0000\">";
    if (ww > 0 && ww < 6) colorhead = "<font color=\"#373737\">";
    if (ww == 6) colorhead = "<font color=\"#008000\">";

    colorfoot = "</font>"
    //str = colorhead + yy + "-" + MM + "-" + dd + " " + hh + ":" + mm + ":" + ss + "  " + WW[ww] + colorfoot;
    str = colorhead + yy + "-" + MM + "-" + dd + " "  + WW[ww] + colorfoot;
    return (str);
}