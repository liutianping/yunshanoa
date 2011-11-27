<%@ Page Language="C#" MasterPageFile="~/OfficeAdmin/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="ProcessMeetingEquipmentArr.aspx.cs" Inherits="YunShanOA.OfficeAdmin.ProcessMeetingEquipmentArr" %>

<%@ MasterType VirtualPath="~/OfficeAdmin/MasterPage.Master" %>
<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div style="margin: 50px 0px 0px 150px;">
        <asp:GridView ID="gvMeetingEquipmentArr" runat="server" AutoGenerateColumns="False"
            AutoGenerateSelectButton="True" OnRowDataBound="gvMeetingEquipmentArr_RowDataBound"
            OnSelectedIndexChanged="gvMeetingEquipmentArr_SelectedIndexChanged" Height="121px"
            CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" 
            PagerStyle-CssClass="pgr" AllowPaging="True" 
            onpageindexchanging="gvMeetingEquipmentArr_PageIndexChanging1" PageSize="3">
            <Columns>
                <asp:BoundField DataField="MeetingRoomName" HeaderText="会议室名字" />
                <asp:BoundField DataField="BeginTime" HeaderText="开始时间" />
                <asp:BoundField DataField="EndTime" HeaderText="结束时间" />
                <asp:BoundField DataField="MeetingAndRoomID" HeaderText="唯一标识" />
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
        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
        <div runat="server" id="divDetail">
            <table>
                <tr>
                    <td>
                        会议室名字:
                    </td>
                    <td>
                        <asp:Label ID="lblMeetingRoomName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        开始时间:
                    </td>
                    <td>
                        <asp:Label ID="lblBeginTime" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        结束时间:
                    </td>
                    <td>
                        <asp:Label ID="lblEndTime" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        此会议需要如下设备:
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvEquipment" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvEquipment_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="EquipmentName" HeaderText="设备名字" />
                                <asp:BoundField DataField="EquipmentCount" HeaderText="设备数量" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:RadioButton ID="rbtAgree" runat="server" GroupName="a" Text="同意" />
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="a" Text="不同意" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button CssClass="button" ID="btnCommit" runat="server" OnClick="btnCommit_Click" Text="提交" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:HiddenField ID="hfdMeetingApplyFormID" runat="server" />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</asp:Content>
