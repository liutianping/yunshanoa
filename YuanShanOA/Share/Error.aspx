<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="YunShanOA.Share.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>出错了~~~</title>
 
    <script language="javascript" type="text/javascript">        var i = 5;
        var id;
        id = setInterval("fun()", 1000);
        function fun() {
            if (i == 0) {
                window.location = "/Temp.aspx";
                clearInterval(id);
            }
            document.getElementById("mes").innerHTML = i;
            i--;
        }  
    </script>
</head>
<body>
<div  id="error" style=" text-align:center; margin-top:50px;"  >
   
     <h3>系统出错，请联系管理员</h3>
     <p>将在<span id="mes">5</span>秒后跳回<a href="../Temp.aspx">首页</a></p>
     </div>
</body>
</html>
