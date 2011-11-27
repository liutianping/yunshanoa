<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="YuanShanOA.Login.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../CSS/login.css"  rel="Stylesheet" />
    <script type="text/javascript" src="/JS/jquery-1.6.1.min.js"></script>
    <script src="JS/Login.js" type="text/javascript"></script>
</head>
<body>
   <form id="form1" runat="server">
   <div class="role">
        <div  id="rtext"></div>
        <div class="r" id="r1"></div>
        <div class="r" id="r2"></div>
        <div class="r" id="r3"></div>
        <div class="r" id="r4"></div>
        <div class="r" id="r5"></div>
   </div>
       
    <div class="main">
        <div class="login">
           <asp:Login ID="lgn" runat="server" onloggedin="lgn_LoggedIn" >
                <LayoutTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0" id="table">
                                    <tr style=" font-weight:bold;">
                                        <td align="right" >
                                            当前角色:
                                         </td>
                                         <td >
                                             &nbsp;&nbsp;<span class="currentrole"></span>
                                         </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="lable">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用户名:</asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="UserName" runat="server" Width="157"></asp:TextBox>
                                            <span style=" color:Red;"><asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                ControlToValidate="UserName" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" 
                                                ValidationGroup="lgn">*</asp:RequiredFieldValidator></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="lable">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密码:</asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="Password" runat="server" TextMode="Password" Width="157"></asp:TextBox>
                                                <span style=" color:Red;"><asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                ControlToValidate="Password" ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" 
                                                ValidationGroup="lgn">*</asp:RequiredFieldValidator></span>
                                        </td>
                                    </tr>
                                   <%-- <tr>
                                        <td align="right" class="lable">
                                            <asp:Label ID="Label1" runat="server" Text="验证码:" ></asp:Label>
                                            
                                        </td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="txtYzm" runat="server" MaxLength="4" Width="50px"></asp:TextBox>
                                            <span style="width:40px;height:20px; cursor:pointer; position:absolute; " onclick="getCode()" id="img"></span>
                                            <span style=" padding-left:60px; font-size:13px; color:White;">点击图片换验证码</span>
                                            </td>
                                    </tr>--%>
                                    <tr>
                                        <td></td>
                                        <td>
                                            &nbsp;<asp:CheckBox ID="RememberMe" runat="server" Text="下次记住我。" /><span class="error"></span>
                                        </td>
                                    </tr>
                                   <%-- <tr>
                                        <td align="center" colspan="2" style="color:Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td></td>
                                        <td align="left">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" CssClass="btn"
                                                ValidationGroup="lgn" onclick="LoginButton_Click1" />
                                        </td>
                                        
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>
        </div>
        <asp:HiddenField ID="hfdRoleID" runat="server" />
    

    </div>

  
    <script type="text/javascript">

//        window.onload = function () {
//            getCode();
//        };
        /*********************************************************获取验证码*/
        //新建一个xmlhttprequest
        function getXmlHttpRequst() {
            if (window.XMLHttpRequest) {
                return new XMLHttpRequest();
            }
            else {
                var MSXML = ['Microsoft.XMLHTTP', 'MSXML2.XMLHTTP.5.0', 'MSXML2.XMLHTTP.4.0', 'MSXML2.XMLHTTP.3.0', 'MSXML2.XMLHTTP'];
                for (var i = 0; i < MSXML.length; i++) {
                    try {
                        var xmlHttp = new ActiveXObject(MSXML[i]);
                        return xmlHttp;
                    }
                    catch (e) { }

                }
            }
        }

        //Ajax掉用httpHandler返回验证码图片
        function getCode() {
            var xmlHttp = getXmlHttpRequst();
            xmlHttp.onreadystatechange = function () {

                if (xmlHttp.readyState == 4) {
                    if (xmlHttp.status == 200) {
                        var obj = document.getElementById("img");

                        obj.innerHTML = '<img src="../AJAX/GetConfirmID.ashx?a=' + Math.random() + '" id="img" onclick="getCode()"/>';
                    }
                }
            }
            //最后为标示为异步请求

            xmlHttp.open("GET", "../AJAX/GetConfirmID.ashx", true);
            xmlHttp.send(null);

        }
        /********************************************************************结束获取验证码*/

        function Code() {
            var code = $('#lgn_txtYzm').val();
            var fade;
            $.get(
            "../AJAX/CheckCode.ashx",
            { code: code },
            function (html) {
                $('.error').text(html);
                alert("html    " + html + $('.error').text());

            }
            );
//            alert(" error1 " + $('.error').text());
//            alert(" error2 " + $('.error').text());
//            if (fade == '0') {
//                return false;
//            }
//            else {
//                return true;
//            }
        }
        function CheckCode() {
            Code();
            var fade = $('.error').text();
            alert("fade="+fade);
//            if (fade == '0') {
//                return false;
//            }
//            else {
//                return true;
//            }
            return false;
         }
    </script>
    

  
    </form>
    </body>
</html>
