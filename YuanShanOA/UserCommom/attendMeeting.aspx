<%@ Page Language="C#" MasterPageFile="~/UserCommom/MasterPage.Master" AutoEventWireup="true" CodeBehind="attendMeeting.aspx.cs" Inherits="YunShanOA.UserCommom.attendMeeting" %>
<%@ MasterType VirtualPath="~/UserCommom/MasterPage.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder7">

    <title></title>

    <div style=" margin:50px 0px 0px 100px;">
    
        <%--<div style="margin:0px 0px 10px 20px;"><b>待参加会议列表</b></div>--%>
    <div>
        <asp:GridView ID="gvAttendMeeting" runat="server" AutoGenerateColumns="False"
         CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr">
            <Columns>
                <asp:BoundField DataField="MeetingRoomName" HeaderText="会议室" />
                <asp:BoundField DataField="BeginTime" HeaderText="开始时间" />
                <asp:BoundField DataField="EndTime" HeaderText="结束时间" />
                <asp:BoundField DataField="MeetingTopic" HeaderText="会议主题" />
                <asp:BoundField DataField="MeetingIntroduction" HeaderText="会议简介" />
            </Columns>
        </asp:GridView>
    </div>
    </div>
    
</asp:Content>
