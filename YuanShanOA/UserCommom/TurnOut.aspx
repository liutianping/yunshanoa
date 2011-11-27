<%@ Page Language="C#" MasterPageFile="~/UserCommom/MasterPage.Master" AutoEventWireup="true" CodeBehind="TurnOut.aspx.cs" Inherits="YunShanOA.UserCommom.TurnOut" %>
<%@ MasterType VirtualPath="~/UserCommom/MasterPage.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder7">

    <div style=" margin:50px 0px 0px 200px;">
       
        <div style=" color:Red; font-size:16px; margin-left:60px;"><asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label></div>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="BeginTime" HeaderText="开始时间" />
                <asp:BoundField DataField="EndTime" HeaderText="结束时间" />
                <asp:BoundField DataField="StartDes" HeaderText="起点" />
                <asp:BoundField DataField="EndDes" HeaderText="终点" />
            </Columns>
        </asp:GridView>
        
    </div>
</asp:Content>