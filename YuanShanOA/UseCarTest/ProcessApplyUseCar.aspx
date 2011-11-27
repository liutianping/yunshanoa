<%@ Page Language="C#" MasterPageFile="~/UseCarTest/MasterPage.Master" AutoEventWireup="true"CodeBehind="ProcessApplyUseCar.aspx.cs"Inherits="YunShanOA.UseCarTest.ProcessApplyUseCar"MaintainScrollPositionOnPostback="true" %>
<%@ MasterType VirtualPath="~/UseCarTest/MasterPage.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder6">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div style="padding:50px 0px 0px 100px;">
        <div style="padding:0px 0px 10px 60px;">
            <asp:Button ID="btn0" runat="server" OnClick="btn0_Click" Text="未处理的申请" CssClass="btnCar" />
            <asp:Button ID="btn1" runat="server" OnClick="btn1_Click" Text="已经同意的申请" CssClass="btnCar" />
            <asp:Button ID="btn2" runat="server" OnClick="btn2_Click" Text="已经拒绝的申请" CssClass="btnCar" />
            </div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
                <asp:View ID="View1" runat="server">
                    <asp:GridView ID="gvSelectAll" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" DataKeyNames="UseCarApplyFormID" OnPageIndexChanging="gvSelectAll_PageIndexChanging"
                        OnRowCommand="gvSelectAll_RowCommand" PageSize="5" Width="496px"
                         CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr">
                        <Columns>
                            <asp:BoundField DataField="UseCarApplyFormID" HeaderText="编号" />
                            <asp:BoundField DataField="WFID" HeaderText="工作流编号" />
                            <asp:BoundField DataField="ApplyUserName" HeaderText="申请者" />
                            <asp:TemplateField HeaderText="详情">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtSelect" OnClick="lbtSelect_Click" CommandArgument='<%# Eval("UseCarApplyFormID") %>'
                                        runat="server">详情</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            暂 时 没 有 您 需 要 审 批 的 用 车 申 请!
                        </EmptyDataTemplate>
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
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:GridView ID="gvOK" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        DataKeyNames="UseCarApplyFormID" OnPageIndexChanging="gvOK_PageIndexChanging"
                        OnRowCommand="gvOK_RowCommand" PageSize="5" Width="496px"
                         CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr">
                        <Columns>
                            <asp:BoundField DataField="UseCarApplyFormID" HeaderText="编号" />
                            <asp:BoundField DataField="WFID" HeaderText="工作流编号" />
                            <asp:BoundField DataField="ApplyUserName" HeaderText="申请者" />
                            <asp:TemplateField HeaderText="详情">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtSelect" OnClick="lbtSelect_Click" CommandArgument='<%# Eval("UseCarApplyFormID") %>'
                                        runat="server">详情</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            暂 时 没 有 您 同 意 过 的 用 车 申 请!
                        </EmptyDataTemplate>
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
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <asp:GridView ID="gvReject" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" DataKeyNames="UseCarApplyFormID" OnPageIndexChanging="gvReject_PageIndexChanging"
                        OnRowCommand="gvReject_RowCommand" PageSize="5" Width="600px"
                        CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr">
                        <Columns>
                            <asp:BoundField DataField="UseCarApplyFormID" HeaderText="编号" />
                            <asp:BoundField DataField="WFID" HeaderText="工作流编号" />
                            <asp:BoundField DataField="ApplyUserName" HeaderText="申请者" />
                            <asp:TemplateField HeaderText="详情">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtSelect" OnClick="lbtSelect_Click" CommandArgument='<%# Eval("UseCarApplyFormID") %>'
                                        runat="server">详情</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            暂 时 没 有 您 拒 绝 过 的 用 车 申 请!
                        </EmptyDataTemplate>
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
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                    <br />
                </asp:View>
            </asp:MultiView>
            <div>
                <asp:Panel ID="pnlRequests" Visible="false" runat="server">
                    &nbsp;&nbsp;&nbsp;
                    <table border="1"  cellpadding="0" cellspacing="0" width="585px;">
                        <tr bgcolor="#003366">
                            <td>
                                <font color="#ffffff">处理该请求 : </font>
                                <asp:Label ID="lblQC" runat="server" Width="397px" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="10" width="585pxpx">
                                    <tr>
                                        <td>
                                            ID:
                                        </td>
                                        <td>
                                            <asp:Label ID="LblID" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            申请者姓名:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" Enabled="False" Width="400px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            用车类型:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUseCarType" runat="server" Enabled="False" Width="400px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            开始时间:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStartTIme" runat="server" Enabled="False" Width="400px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            结束时间:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEndTime" runat="server" Enabled="False" Width="400px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            出发地点:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStartDes" runat="server" Width="400px" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            终点地址 ：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEndDes" runat="server" Width="400px" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            相关人员 ：
                                        </td>
                                        <td>
                                            <asp:GridView ID="gvUsers" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                PageSize="5"
                                                 CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            ID
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="txtSelected" Text='<%# (Container.DisplayIndex+1).ToString() %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Name" HeaderText="名字" SortExpression="Name" />
                                                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                                </Columns>
                                                <RowStyle HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            申请理由：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtApplyReason" runat="server" Height="144px" TextMode="MultiLine"
                                                Width="397px" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            备注：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtApplyComment" runat="server" Height="128px" TextMode="MultiLine"
                                                Width="400px" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            你的姓名 ：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtYName" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            审核 ：
                                        </td>
                                        <td>
                                            &nbsp;&nbsp<asp:RadioButton ID="rbtOK" runat="server" Checked="true" GroupName="GroupName" />同意
                                            &nbsp;
                                            <asp:RadioButton ID="rbtReject" runat="server" GroupName="GroupName" />不同意
                                            <asp:Label ID="lbMsg0" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSubmit" CssClass="button" runat="server" Text="提交" OnClick="btnSubmit_Click" />
                                            &nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="lbMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
