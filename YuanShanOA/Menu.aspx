<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="YuanShanOA.Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="JS/jquery-1.6.1.min.js" type="text/javascript"></script>
</head>
<body>
    <div class=".toggle">
        <dl>
            <dt>公文管理</dt>
            <dd>
                <ul>
                    <li><a href="#">公文发起</a></li>
                    <li><a href="#">公文审核</a></li>
                    <li><a href="#">公文审批</a></li>
                    <li><a href="#">公文发送和接收</a></li>
                    <li><a href="#">公文归档</a></li>
                </ul>
            </dd>
            <dt>会议管理</dt>
            <dd>
                <ul>
                    <li><a href="#">会议申请</a></li>
                    <li><a href="#">会议批审</a></li>
                    <li><a href="#">安排会议室和会议设备</a></li>
                    <li><a href="#">会议通知下达</a></li>
                    <li><a href="#">会议记录及归档</a></li>
                </ul>
            </dd>
             <dt>用车管理</dt>
            <dd>
                <ul>
                    <li><a href="#">用车申请</a></li>
                    <li><a href="#">用车批审</a></li>
                    <li><a href="#">安排出车</a></li>
                    <li><a href="#">出车通知</a></li>
                    <li><a href="#">交车</a></li>
                    <li><a href="#">续车申请</a></li>
                </ul>
            </dd>
             <dt>消息管理</dt>
            <dd>
                <ul>
                    <li><a href="#">发送邮件</a></li>
                    <li><a href="#">接收邮件</a></li>
                </ul>
            </dd>
             <dt>个人事务管理</dt>
            <dd>
                <ul>
                    <li><a href="#">待参加会议</a></li>
                    <li><a href="#">带乘车出行信息</a></li>
                    <li><a href="#">待审批用车申请</a></li>
                    <li><a href="#">待审批会议申请</a></li>
                    <li><a href="#">待审批公文</a></li> 
                </ul>
            </dd>
             <dt>移动办公</dt>
            <dd>
                <ul>
                    <li><a href="#">待参加会议</a></li>
                    <li><a href="#">待乘车出行</a></li>
                    <li><a href="#">用车申请</a></li>
                    <li><a href="#">公文审批</a></li>
                </ul>
            </dd>
             <dt>系统管理</dt>
            <dd>
                <ul>
                    <li><a href="#">用户登录</a></li>
                    <li><a href="#">用户注销</a></li>
                    <li><a href="#">用户角色维护</a></li>
                    <li><a href="#">用户账号维护</a></li>
                    <li><a href="#">公文模板资料维护</a></li>
                    <li><a href="#">自定义公文处理流程</a></li>
                    <li><a href="#">会议资料维护</a></li>
                    <li><a href="#">会议设备资料维护</a></li>
                    <li><a href="#">汽车资料管理</a></li>
                </ul>
            </dd>
        </dl>
    </div>
    
    <script type="text/javascript" >
        $(document).ready(function () {
            $(".toggle dl dd").hide();
            $(".toggle dl dt").click(function () {
                $(".toggle dl dd").not($(this).next()).slideUp('500');
               
                $(this).next().slideToggle("500");
            });
        });
    </script>
</body>
</html>
