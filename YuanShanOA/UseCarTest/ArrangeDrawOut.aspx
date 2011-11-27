<%@ Page Language="C#" MasterPageFile="~/UseCarTest/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArrangeDrawOut.aspx.cs"Inherits="YunShanOA.UseCarTest.ArrangeDrawOut"MaintainScrollPositionOnPostback="true" %>
<%@ MasterType VirtualPath="~/UseCarTest/MasterPage.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder6">

    <title>用车安排页面</title>
    <script src="../JS/myDate/WdatePicker.js" type="text/javascript"></script>
    <script src="../JS/UseCar.js" type="text/javascript"></script>

    <style type="text/css">
        .m_table
        {
            border-collapse: collapse;
            border: 2px solid #000000;
            width: 600px;
            padding: 0;
        }
        .m_table th, .m_table td
        {
            border: 1px solid #CECFCE;
            text-align: center;
        }
        .m_table .xuhao
        {
            width: 60px;
        }
        .m_table .del
        {
            width: 50px;
        }
        .m_table th
        {
            background-color: #003366;
        }
        .font_color
        {
            color: #ffffff;
            margin-left: 70px;
            margin-bottom: 20px;
        }
        .style1
        {
            width: 173px;
        }
        .style2
        {
            width: 173px;
            height: 105px;
        }
        .style3
        {
            height: 105px;
        }
    </style>

    <div style="padding-left: 50px; padding-top: 50px">
       

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvSelectAll" runat="server" AllowPaging="True" AllowSorting="True"    AutoGenerateColumns="False" DataKeyNames="UseCarApplyFormID"   PageSize="5"
                    onpageindexchanging="gvSelectAll_PageIndexChanging1" 
                    onrowcommand="gvSelectAll_RowCommand1"
                     CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr">
                         <Columns>
                            <asp:BoundField DataField="UseCarApplyFormID" HeaderText="ID" />
                            <asp:TemplateField HeaderText="出行人数">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Usecaranduser.Count")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BeginTime" HeaderText=" 开始时间" />
                            <asp:BoundField DataField="EndTime" HeaderText="  结束时间" />
                            <asp:TemplateField HeaderText="用车类型">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("usecartype.UseCarTypeName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="StartDestination" HeaderText="  起点" />
                            <asp:BoundField DataField="EndDestination" HeaderText="  终点" />
                            <asp:TemplateField>
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtArange" OnClick="lbtArange_Click" CommandArgument='<%# Eval("UseCarApplyFormID") %>'
                                        runat="server">安排</asp:LinkButton>
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
                        <RowStyle HorizontalAlign="Center" />
                </asp:GridView>
&nbsp;<asp:Panel ID="pnlRequests" Visible="false" runat="server">
                    <table border="1" width="660" cellpadding="0" cellspacing="0">
                        <tr bgcolor="#003366">
                            <td>
                                <font color="#ffffff">安排该请求 : </font>
                                <asp:Label ID="lblApplyUseCarFromID" runat="server" Width="397px" ForeColor="White"
                                    Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="10" width="600">
                                    <tr>
                                        <td class="style1">
                                            工作流ID：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtWFID" runat="server" Height="18px" Width="428px" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            申请者名字：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" Enabled="False" Height="18px" Width="428px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            需要的类型：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCarType" runat="server" Height="18px" Width="428px" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            选择安排的车:
                                        </td>
                                        <td class="style3">
                                            <br />
                                            该类别下空闲的车(
                                            <asp:Label ID="lblType" runat="server" Font-Bold="True"></asp:Label>
                                            ):<br />
                                            <br />
                                            <asp:GridView ID="gvCarInf" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" DataKeyNames="CarId" OnDataBinding="gvCarInf_DataBinding"
                                                OnPageIndexChanging="gvCarInf_PageIndexChanging" OnRowCommand="gvCarInf_RowCommand"
                                                OnRowDataBound="gvCarInf_RowDataBound" PageSize="5" Width="448px"
                                                 CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                          
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server" Checked="false" Text="选中该车" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="CarId" HeaderText="CarID" />
                                                    <asp:BoundField DataField="LicenseNumber" HeaderText="车牌" />
                                                    <asp:BoundField DataField="ModelNumber" HeaderText="型号" />
                                                    <asp:BoundField DataField="seatingNumber" HeaderText="座位数" />
                                                    <asp:BoundField DataField="LoadCapacity" HeaderText="载重" />
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
                                                <RowStyle HorizontalAlign="Center" />
                                            </asp:GridView>
                                            
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            通知总结信息：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMessage" runat="server" Height="128px" TextMode="MultiLine" Width="428px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            <asp:Button ID="btnSubmit" CssClass="button" runat="server" Text="提交安排" OnClick="btnSubmit_Click" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
     
        
    </div>
<hr />
</asp:Content>