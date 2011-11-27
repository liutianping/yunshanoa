<%@ Page Language="C#" MasterPageFile="~/UseCarTest/MasterPage.Master"  AutoEventWireup="true" CodeBehind="ApplyUseCar.aspx.cs" Inherits="YunShanOA.UseCarTest.ApplyUseCar"
    MaintainScrollPositionOnPostback="true" %>
<%@ MasterType VirtualPath="~/UseCarTest/MasterPage.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder6">

   
    <script src="../JS/myDate/WdatePicker.js" type="text/javascript"></script>
    <script src="../JS/UseCar.js" type="text/javascript"></script>

    <div style=" padding:20px 0px 0px 60px;">
       
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table>
                <tr><td>你的姓名:</td><td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td></tr>
                <tr><td>出发地点:</td><td><asp:TextBox ID="txtStartDes" runat="server"></asp:TextBox></td></tr>
                <tr><td>目的地点:</td><td><asp:TextBox ID="txtEndDes" runat="server"></asp:TextBox></td></tr>
                <tr><td>用车类型:</td><td><asp:DropDownList ID="ddlCarType" runat="server" Width="155px" Font-Bold="False"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlCarType_SelectedIndexChanged">
                </asp:DropDownList>&nbsp;&nbsp;<asp:Label ID="lblcarCount" runat="server" Font-Bold="True" Text=""></asp:Label>辆空闲</td></tr>
                <tr><td>开始时间:</td><td><asp:TextBox ID="txtBeginTime" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" 
                        ControlToValidate="txtBeginTime" ErrorMessage="不能为空" ForeColor="#FF3300">不能为空</asp:CustomValidator>
                    </td></tr>
                <tr><td>结束时间:</td><td><asp:TextBox ID="txtEndTime" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" 
                        ControlToValidate="txtEndDes" ErrorMessage="不能为空" ForeColor="Red">不能为空</asp:CustomValidator>
                    </td></tr>
                <tr><td>用车原因:</td><td><asp:TextBox ID="txtApplyReason" runat="server" TextMode="MultiLine" Height="100px"
                    Width="550px"></asp:TextBox></td></tr>
                <tr style="height:300px;"><td>相关用车人员：</td><td><asp:GridView ID="gvUser" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    DataKeyNames="UserId" AllowSorting="True" OnDataBinding="gvUser_DataBinding"
                    OnRowDataBound="gvUser_RowDataBound" OnPageIndexChanging="gvUser_PageIndexChanging"
                    PageSize="5" OnRowCommand="gvUser_RowCommand" Width="550px"
                     >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked="false" Text="选中该人" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="名字" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                    </Columns>
                    <PagerTemplate>
                    <div style=" padding-left:50px;">
                        <asp:Label ID="lblPage" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>
                        <asp:LinkButton ID="lbnFirst" runat="Server" Text="首页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'
                            CommandName="Page" CommandArgument="First"></asp:LinkButton>
                        <asp:LinkButton ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'
                            CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                        <asp:LinkButton ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>'
                            CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                        <asp:LinkButton ID="lbnLast" runat="Server" Text="尾页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>'
                            CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                            到第<asp:TextBox runat="server" ID="inPageNum" Width="50"></asp:TextBox>页
                            <asp:Button ID="Button1" CommandName="go" runat="server" Text="跳转" />
                            
                        </div>
                        
                        
                    </PagerTemplate>
                    <RowStyle HorizontalAlign="Center" />
                </asp:GridView></td></tr>
                <tr><td>备注：</td><td><asp:TextBox ID="txtComment" runat="server" Style="margin-bottom: 0px" Height="67px"
                    TextMode="MultiLine" Width="550px"></asp:TextBox></td></tr>
                <tr><td></td><td><asp:Button ID="BtnApply" runat="server" OnClientClick="return date_compare()" Text="申请"
                    OnClick="BtnApply_Click" CssClass="button" /><asp:Button CssClass="button" ID="BtnCause" runat="server" Text="取消" /></td></tr>
                <tr><td colspan="2"><asp:Label ID="lbMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td></tr>
                </table>   
       
            </ContentTemplate>
        </asp:UpdatePanel>
       
    </div>

</asp:Content>