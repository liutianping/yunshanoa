<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentExamine.aspx.cs" Inherits="YunShanOA.Document.DocumentExamine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公 文 审 核 页 面</title>
    <style type="text/css">
        .style2
        {
            width: 176px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<div style="padding-left: 140px; padding-top: 50px">
        <asp:GridView ID="gvDocumentTemplate" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="DocumentID" AllowSorting="True" OnPageIndexChanging="gvDocumentTemplate_PageIndexChanging"
            PageSize="5" OnRowCommand="gvDocumentTemplate_RowCommand" Width="596px" 
            style="margin-right: 0px">
            <Columns>
                <asp:BoundField DataField="DocumentID" HeaderText="ID" />
                <asp:BoundField DataField="DocumentName" HeaderText="公文名字" />
                <asp:BoundField DataField="Author" HeaderText="作者" />
                    <asp:TemplateField>
                    <HeaderTemplate>
                       公文文件下载查看
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDownLoad" OnClick="lbDownLoad_Click" CommandArgument='<%# Eval("DocumentPath") %>'
                            runat="server">下载查看</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                       
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lb" OnClick="lbDetails_Click" CommandArgument='<%# Eval("DocumentID") %>'
                            runat="server">详情</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                没 有 需 要 您 审 核 的 公 文！！
            </EmptyDataTemplate>
            <PagerTemplate>
                <br />
                <asp:Label ID="lblPage" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>
                <asp:LinkButton ID="lbnFirst" runat="Server" Text="首页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'
                    CommandName="Page" CommandArgument="First"></asp:LinkButton>
                <asp:LinkButton ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'
                    CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                <asp:LinkButton ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>'
                    CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                <asp:LinkButton ID="lbnLast" runat="Server" Text="尾页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>'
                    CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                到第<asp:TextBox runat="server" ID="inPageNum"></asp:TextBox>页
                <asp:Button ID="Button1" CommandName="go" runat="server" Text="跳转" />
            </PagerTemplate>
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
                &nbsp;<asp:Panel ID="pnlRequests" Visible="false" runat="server">
                    <table border="1" width="600" cellpadding="0" cellspacing="0">
                        <tr >
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="10" style="width: 581px">
                                    <tr>
                                        <td class="style2">
                                            ID：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtID" runat="server" Height="18px" Width="428px" 
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr>
                                         <td class="style2">
                                             WFID： 
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txtWFID" runat="server" Enabled="False" Height="18px" 
                                                 Width="428px"></asp:TextBox>
                                         </td>
                                    </tr>
                                     <tr>
                                        <td class="style2">
                                            公文名字：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" Height="18px" Width="428px" 
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            作者:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAuthor" runat="server" Enabled="False" Height="18px" 
                                                Width="428px"></asp:TextBox>
                                        </td>
                                    </tr>
                                 
                                    <tr>
                                        <td class="style2">
                                            审核:
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;<asp:RadioButton ID="rbtOK" runat="server" Checked="true" 
                                                GroupName="GroupName" />
                                            通过 &nbsp;
                                            <asp:RadioButton ID="rbtReject" runat="server" GroupName="GroupName" />
                                            不通过 &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Button ID="btnSubmit" runat="server" Text="提交审核" 
                                                OnClick="btnSubmit_Click" />
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
    </form>
</body>
</html>
