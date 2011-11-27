<%@ Page Language="C#" MasterPageFile="~/WebAdmin/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="MeetingEquipmentManager.aspx.cs" Inherits="YunShanOA.WebAdmin.MeetingEquipmentManager" %>

<%@ MasterType VirtualPath="~/WebAdmin/MasterPage.Master" %>
<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder8">
    <script type="text/jscript">

        $(document).ready(function () {
            $('#add,#delete,#edit').hide();
            $('#btnView').click(function () {

                $('#add,#delete,#edit').hide();
                $('#show').show();
            });
            $('#btnAdd').click(function () {

                $('#show,#delete,#edit').hide();
                $('#add').show();
            });
            $('#btnDelete').click(function () {

                $('#add,#show,#edit').hide();
                $('#delete').show();
            });
            $('#btnEdit').click(function () {

                $('#add,#delete,#show').hide();
                $('#edit').show();
            });

        });
        function myKeyDown() {
            var k = window.event.keyCode;
            if ((k == 46) || (k == 8) || (k == 189) || (k == 109) || (k == 190) || (k == 110) || (k >= 48 && k <= 57) || (k >= 96 && k <= 105) || (k >= 37 && k <= 40))
            { }
            else if (k == 13) {
                window.event.keyCode = 9;
            }
            else {
                window.event.returnValue = false;
            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="margin: 50px 0px 0px 100px;">
        <div>
            <b>会议设备管理:</b></div>
            <br />
         
        <div>
            <input type="button" id="btnView" value="查看" class="button" />
            <input type="button" id="btnAdd" value="增加" class="button"/>
            <input type="button" id="btnEdit" value="编辑" class="button"/>
            <input type="button" id="btnDelete" value="删除" class="button"/>
        </div>

            <br />
        <div id="edit">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="MeetingEquipmentID"
                        DataSourceID="SqlDataSource1" AllowPaging="True">
                        <Columns>
                            <asp:CommandField ShowEditButton="True" />
                            <asp:BoundField DataField="EquipmentName" HeaderText="设备名字" SortExpression="EquipmentName" />
                            <asp:BoundField DataField="EquipmentDescription" HeaderText="设备描述" SortExpression="EquipmentDescription" />
                            <asp:BoundField DataField="MeetingEquipmentCount" HeaderText="设备数量" SortExpression="MeetingEquipmentCount" />
                            <asp:BoundField DataField="MeetingEquipmentFreeCount" HeaderText="可用数量" SortExpression="MeetingEquipmentFreeCount" />
                            <asp:BoundField DataField="Comments" HeaderText="备注" SortExpression="Comments" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="add">
            <asp:FormView ID="FormView1" runat="server" DataKeyNames="MeetingEquipmentID" DataSourceID="SqlDataSource1"
                AllowPaging="True" Width="340px" DefaultMode="Insert">
                <EditItemTemplate>
                    MeetingEquipmentID:
                    <asp:Label ID="MeetingEquipmentIDLabel1" runat="server" Text='<%# Eval("MeetingEquipmentID") %>' />
                    
                    EquipmentName:
                    <asp:TextBox ID="EquipmentNameTextBox" runat="server" Text='<%# Bind("EquipmentName") %>'  />
                    
                    EquipmentDescription:
                    <asp:TextBox ID="EquipmentDescriptionTextBox" runat="server" Text='<%# Bind("EquipmentDescription") %>' />
                   
                    Status:
                    <asp:TextBox ID="StatusTextBox" runat="server" Text='<%# Bind("Status") %>' />
                   
                    MeetingEquipmentCount:
                    <asp:TextBox ID="MeetingEquipmentCountTextBox" runat="server" Text='<%# Bind("MeetingEquipmentCount") %>' />
                    
                    MeetingEquipmentFreeCount:
                    <asp:TextBox ID="MeetingEquipmentFreeCountTextBox" runat="server" Text='<%# Bind("MeetingEquipmentFreeCount") %>' />
                    
                    Comments:
                    <asp:TextBox ID="CommentsTextBox" runat="server" Text='<%# Bind("Comments") %>' />
                    
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                        Text="更新" />
                   <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                        CommandName="Cancel" Text="取消" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <table>
                        <tr>
                            <td>
                                设备名字:
                            </td>
                            <td>
                                <asp:TextBox ID="EquipmentNameTextBox" runat="server" Text='<%# Bind("EquipmentName") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                设备描述:
                            </td>
                            <td>
                                <asp:TextBox ID="EquipmentDescriptionTextBox" runat="server" Text='<%# Bind("EquipmentDescription") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                设备数量:
                            </td>
                            <td>
                                <asp:TextBox ID="MeetingEquipmentCountTextBox" runat="server" Text='<%# Bind("MeetingEquipmentCount") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                可用数量:
                            </td>
                            <td>
                                <asp:TextBox ID="MeetingEquipmentFreeCountTextBox" runat="server" Text='<%# Bind("MeetingEquipmentFreeCount") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                设备备注:
                            </td>
                            <td>
                                <asp:TextBox ID="CommentsTextBox" runat="server" Text='<%# Bind("Comments") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                    Text="增加" />
                                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                                    PostBackUrl="~/WebAdmin/Default.aspx" Text="返回" />
                            </td>
                        </tr>
                    </table>
                </InsertItemTemplate>
                <ItemTemplate>
                    MeetingEquipmentID:
                    <asp:Label ID="MeetingEquipmentIDLabel" runat="server" Text='<%# Eval("MeetingEquipmentID") %>' />
                    <br />
                    EquipmentName:
                    <asp:Label ID="EquipmentNameLabel" runat="server" Text='<%# Bind("EquipmentName") %>' />
                    <br />
                    EquipmentDescription:
                    <asp:Label ID="EquipmentDescriptionLabel" runat="server" Text='<%# Bind("EquipmentDescription") %>' />
                    <br />
                    Status:
                    <asp:Label ID="StatusLabel" runat="server" Text='<%# Bind("Status") %>' />
                    <br />
                    MeetingEquipmentCount:
                    <asp:Label ID="MeetingEquipmentCountLabel" runat="server" Text='<%# Bind("MeetingEquipmentCount") %>' />
                    <br />
                    MeetingEquipmentFreeCount:
                    <asp:Label ID="MeetingEquipmentFreeCountLabel" runat="server" Text='<%# Bind("MeetingEquipmentFreeCount") %>' />
                    <br />
                    Comments:
                    <asp:Label ID="CommentsLabel" runat="server" Text='<%# Bind("Comments") %>' />
                    <br />
                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="编辑" />
                    &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="删除" />
                    &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                        Text="新建" />
                </ItemTemplate>
            </asp:FormView>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" DeleteCommand="DELETE FROM [MeetingEquipment] WHERE [MeetingEquipmentID] = @original_MeetingEquipmentID AND [EquipmentName] = @original_EquipmentName AND (([EquipmentDescription] = @original_EquipmentDescription) OR ([EquipmentDescription] IS NULL AND @original_EquipmentDescription IS NULL)) AND (([Status] = @original_Status) OR ([Status] IS NULL AND @original_Status IS NULL)) AND [MeetingEquipmentCount] = @original_MeetingEquipmentCount AND [MeetingEquipmentFreeCount] = @original_MeetingEquipmentFreeCount AND (([Comments] = @original_Comments) OR ([Comments] IS NULL AND @original_Comments IS NULL))"
            InsertCommand="INSERT INTO [MeetingEquipment] ([EquipmentName], [EquipmentDescription], [Status], [MeetingEquipmentCount], [MeetingEquipmentFreeCount], [Comments]) VALUES (@EquipmentName, @EquipmentDescription, @Status, @MeetingEquipmentCount, @MeetingEquipmentFreeCount, @Comments)"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [MeetingEquipment]"
            UpdateCommand="UPDATE [MeetingEquipment] SET [EquipmentName] = @EquipmentName, [EquipmentDescription] = @EquipmentDescription, [Status] = @Status, [MeetingEquipmentCount] = @MeetingEquipmentCount, [MeetingEquipmentFreeCount] = @MeetingEquipmentFreeCount, [Comments] = @Comments WHERE [MeetingEquipmentID] = @original_MeetingEquipmentID AND [EquipmentName] = @original_EquipmentName AND (([EquipmentDescription] = @original_EquipmentDescription) OR ([EquipmentDescription] IS NULL AND @original_EquipmentDescription IS NULL)) AND (([Status] = @original_Status) OR ([Status] IS NULL AND @original_Status IS NULL)) AND [MeetingEquipmentCount] = @original_MeetingEquipmentCount AND [MeetingEquipmentFreeCount] = @original_MeetingEquipmentFreeCount AND (([Comments] = @original_Comments) OR ([Comments] IS NULL AND @original_Comments IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_MeetingEquipmentID" Type="Int32" />
                <asp:Parameter Name="original_EquipmentName" Type="String" />
                <asp:Parameter Name="original_EquipmentDescription" Type="String" />
                <asp:Parameter Name="original_Status" Type="Int32" />
                <asp:Parameter Name="original_MeetingEquipmentCount" Type="Int32" />
                <asp:Parameter Name="original_MeetingEquipmentFreeCount" Type="Int32" />
                <asp:Parameter Name="original_Comments" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="EquipmentName" Type="String" />
                <asp:Parameter Name="EquipmentDescription" Type="String" />
                <asp:Parameter Name="Status" Type="Int32" />
                <asp:Parameter Name="MeetingEquipmentCount" Type="Int32" />
                <asp:Parameter Name="MeetingEquipmentFreeCount" Type="Int32" />
                <asp:Parameter Name="Comments" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="EquipmentName" Type="String" />
                <asp:Parameter Name="EquipmentDescription" Type="String" />
                <asp:Parameter Name="Status" Type="Int32" />
                <asp:Parameter Name="MeetingEquipmentCount" Type="Int32" />
                <asp:Parameter Name="MeetingEquipmentFreeCount" Type="Int32" />
                <asp:Parameter Name="Comments" Type="String" />
                <asp:Parameter Name="original_MeetingEquipmentID" Type="Int32" />
                <asp:Parameter Name="original_EquipmentName" Type="String" />
                <asp:Parameter Name="original_EquipmentDescription" Type="String" />
                <asp:Parameter Name="original_Status" Type="Int32" />
                <asp:Parameter Name="original_MeetingEquipmentCount" Type="Int32" />
                <asp:Parameter Name="original_MeetingEquipmentFreeCount" Type="Int32" />
                <asp:Parameter Name="original_Comments" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <div id="delete">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                AutoGenerateDeleteButton="True" EmptyDataText="暂无内容" OnRowDataBound="GridView1_RowDataBound"
                DataKeyNames="MeetingEquipmentID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="EquipmentName" HeaderText="设备名字" SortExpression="EquipmentName" />
                    <asp:BoundField DataField="EquipmentDescription" HeaderText="设备描述" SortExpression="EquipmentDescription" />
                    <asp:BoundField DataField="MeetingEquipmentCount" HeaderText="设备数量" SortExpression="MeetingEquipmentCount" />
                    <asp:BoundField DataField="MeetingEquipmentFreeCount" HeaderText="可用数量" SortExpression="MeetingEquipmentFreeCount" />
                    <asp:BoundField DataField="Comments" HeaderText="备注" SortExpression="Comments" />
                </Columns>
            </asp:GridView>
        </div>
        <div id="show">
            <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="EquipmentName" HeaderText="设备名字" />
                    <asp:BoundField DataField="EquipmentDescription" HeaderText="设备描述" />
                    <asp:BoundField DataField="MeetingEquipmentCount" HeaderText="设备数量" />
                    <asp:BoundField DataField="MeetingEquipmentFreeCount" HeaderText="可用数量" />
                    <asp:BoundField DataField="Comments" HeaderText="备注" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
