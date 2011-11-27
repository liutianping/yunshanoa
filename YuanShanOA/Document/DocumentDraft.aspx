<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentDraft.aspx.cs"
    Inherits="YunShanOA.Document.DocumentDraft" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公 文 起 稿 页 ！</title>
    <link rel="Stylesheet" href="_assets/css/progress.css" />
    <link rel="Stylesheet" href="_assets/css/upload.css" />
    <script src="../JS/jquery-1.6.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function checkType() {

            //得到上传文件的值
            var fileName = document.getElementById("FileUpLoad1").value;

            //返回String对象中子字符串最后出现的位置.
            var seat = fileName.lastIndexOf(".");

            //返回位于String对象中指定位置的子字符串并转换为小写.
            var extension = fileName.substring(seat).toLowerCase();
            if (fileName == "") {
                $("#dssd").text("没有选择文件");
                return false;
            }
            //判断允许上传的文件格式
            //if(extension!=".jpg"&&extension!=".jpeg"&&extension!=".gif"&&extension!=".png"&&extension!=".bmp"){
            //alert("不支持"+extension+"文件的上传!");
            //return false;
            //}else{
            //return true;
            //}

            var allowed = [".jpg", ".gif", ".png", ".bmp", ".jpeg", ".mp3", ".doc"];
            for (var i = 0; i < allowed.length; i++) {
                if (!(allowed[i] != extension)) {
                    return true;
                }
            }
            $("#dssd").text("不支持" + extension + "格式");
            //            alert("不支持" + extension + "格式");
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-left: 140px; padding-top: 50px">
        <h3>
            公文模板下载</h3>
        <asp:GridView ID="gvDocumentTemplate" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="ID" AllowSorting="True" OnPageIndexChanging="gvDocumentTemplate_PageIndexChanging"
            PageSize="5" OnRowCommand="gvDocumentTemplate_RowCommand" Width="596px" Style="margin-right: 0px">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="DocumentTemplateName" HeaderText="模板名称" />
                <asp:BoundField DataField="DocumentTemplateDescription" HeaderText="模板描述" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        下载
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDownLoad" OnClick="lbDownLoad_Click" CommandArgument='<%# Eval("DocumentTemplatePath") %>'
                            runat="server">下载该模板</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
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
        <br />
        <table width="600" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="10" style="width: 581px">
                        <tr>
                            <td class="style1">
                                作者：
                            </td>
                            <td>
                                <asp:TextBox ID="txtAuthors" runat="server" Height="18px" Width=" 300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                公文名字：
                            </td>
                            <td>
                                <asp:TextBox ID="txtDocumentName" runat="server" Height="18px" Width=" 300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                通知邮箱：
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Height="18px" Width=" 300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                公文简介：
                            </td>
                            <td>
                                <asp:TextBox ID="txtDes" runat="server" Height="152px" Width="300px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                上传附件:
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpLoad1" runat="server" Width="220px" />
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                                 <tr>
                            <td class="style1">
                               选择公文处理流程:
                            </td>
                            <td>
                               
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Value="true">需要局长</asp:ListItem>
                                    <asp:ListItem Value="false">不需要局长</asp:ListItem>
                                </asp:DropDownList>
                               
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Button ID="btnFileUpload" runat="server" OnClick="btnFileUpload_Click" OnClientClick="return checkType()"
                                    Text="起草上传" />
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="lbMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                <label id="dssd" style="color: Red; font-size: 12px">
                                </label>
                            </td>
                          
                        </tr>
                
                    </table>
                </td>
            </tr>
        </table>
        <div>
            <br />
        </div>
    </div>
    </form>
</body>
</html>
