<%@ Page Language="C#" MasterPageFile="~/OfficeAdmin/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="AchiveMeeting.aspx.cs" Inherits="YunShanOA.OfficeAdmin.AchiveMeeting" %>

<%@ MasterType VirtualPath="~/OfficeAdmin/MasterPage.Master" %>
<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div id="divDetail" runat="server" style="margin: 50px 0px 0px 200px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gvStyle"
            AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" 
            AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="ApplyUserName" HeaderText="申请者名字" />
                <asp:BoundField DataField="MeetingTopic" HeaderText="会议主题" />
                <asp:BoundField DataField="MeetingIntroduction" HeaderText="会议简介" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("MeetingApplyFormID") %>'
                            OnClick="Button1_Click1">完成</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
                <br />
                <asp:Label ID="lblPage" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>
                <asp:LinkButton ID="lbnFirst" runat="Server" CommandArgument="First" CommandName="Page"
                    Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>" Text="首页"></asp:LinkButton>
                <asp:LinkButton ID="lbnPrev" runat="server" CommandArgument="Prev" CommandName="Page"
                    Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>" Text="上一页"></asp:LinkButton>
                <asp:LinkButton ID="lbnNext" runat="Server" CommandArgument="Next" CommandName="Page"
                    Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>"
                    Text="下一页"></asp:LinkButton>
                <asp:LinkButton ID="lbnLast" runat="Server" CommandArgument="Last" CommandName="Page"
                    Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>"
                    Text="尾页"></asp:LinkButton>
                到第<asp:TextBox ID="inPageNum" runat="server" Width="50px"></asp:TextBox>
                页
                <asp:Button ID="Button1" runat="server" CommandName="go" Text="跳转" />
            </PagerTemplate>
        </asp:GridView>
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <br />
</asp:Content>
