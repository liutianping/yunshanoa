<%@ Page Language="C#" MasterPageFile="~/WebAdmin/MasterPage.Master" AutoEventWireup="true" CodeBehind="MeetingTypeManager.aspx.cs"
    Inherits="YunShanOA.WebAdmin.MeetingTypeManager" %>

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
    </script>
    <div style="margin: 50px 0px 0px 100px;">
        <div>
            <b>会议设备管理:</b></div>
            <br />
        <div>
            <input type="button" id="btnView" value="查看" class="button"/>
            <input type="button" id="btnAdd" value="增加" class="button"/>
            <input type="button" id="btnEdit" value="编辑" class="button"/>
            <input type="button" id="btnDelete" value="删除" class="button"/>
        </div><br />
        <div id="add">
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="MeetingTypeID" DataSourceID="SqlDataSource1"
            DefaultMode="Insert">
            <EditItemTemplate>
                会议类型名字:
                <asp:TextBox ID="MeetingTypeNameTextBox" runat="server" Text='<%# Bind("MeetingTypeName") %>' />
                <br />
                会议类型描述:
                <asp:TextBox ID="MeetingTypeDescriptionTextBox" runat="server" Text='<%# Bind("MeetingTypeDescription") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Text="更新" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                    CommandName="Cancel" Text="取消" />
            </EditItemTemplate>
            <InsertItemTemplate>
                会议类型名字:
                <asp:TextBox ID="MeetingTypeNameTextBox" runat="server" Text='<%# Bind("MeetingTypeName") %>' />
                <br /><br />
                会议类型描述:
                <asp:TextBox ID="MeetingTypeDescriptionTextBox" runat="server" Text='<%# Bind("MeetingTypeDescription") %>' />
                <br /><br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                    Text="增加" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                    PostBackUrl="~/WebAdmin/Default.aspx" Text="返回" />
            </InsertItemTemplate>
            <ItemTemplate>
                会议类型名字:
                <asp:Label ID="MeetingTypeNameLabel" runat="server" Text='<%# Bind("MeetingTypeName") %>' />
                <br />
                会议类型描述:
                <asp:Label ID="MeetingTypeDescriptionLabel" runat="server" Text='<%# Bind("MeetingTypeDescription") %>' />
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
        <div id="delete">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MeetingTypeID"
            DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="MeetingTypeName" HeaderText="会议类型名字" SortExpression="MeetingTypeName" />
                <asp:BoundField DataField="MeetingTypeDescription" HeaderText="会议类型描述" SortExpression="MeetingTypeDescription" />
            </Columns>
        </asp:GridView>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="edit">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="MeetingTypeID"
                    DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:BoundField DataField="MeetingTypeName" HeaderText="会议类型名字" SortExpression="MeetingTypeName" />
                        <asp:BoundField DataField="MeetingTypeDescription" HeaderText="会议类型名字" SortExpression="MeetingTypeDescription" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        <div id="show">
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="MeetingTypeID"
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="MeetingTypeName" HeaderText="会议类型名字" SortExpression="MeetingTypeName" />
                <asp:BoundField DataField="MeetingTypeDescription" HeaderText="会议类型描述" SortExpression="MeetingTypeDescription" />
            </Columns>
        </asp:GridView>
        </div>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>"
        SelectCommand="SELECT * FROM [MeetingType]" ConflictDetection="CompareAllValues"
        DeleteCommand="DELETE FROM [MeetingType] WHERE [MeetingTypeID] = @original_MeetingTypeID AND [MeetingTypeName] = @original_MeetingTypeName AND (([MeetingTypeDescription] = @original_MeetingTypeDescription) OR ([MeetingTypeDescription] IS NULL AND @original_MeetingTypeDescription IS NULL))"
        InsertCommand="INSERT INTO [MeetingType] ([MeetingTypeName], [MeetingTypeDescription]) VALUES (@MeetingTypeName, @MeetingTypeDescription)"
        OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [MeetingType] SET [MeetingTypeName] = @MeetingTypeName, [MeetingTypeDescription] = @MeetingTypeDescription WHERE [MeetingTypeID] = @original_MeetingTypeID AND [MeetingTypeName] = @original_MeetingTypeName AND (([MeetingTypeDescription] = @original_MeetingTypeDescription) OR ([MeetingTypeDescription] IS NULL AND @original_MeetingTypeDescription IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_MeetingTypeID" Type="Int32" />
            <asp:Parameter Name="original_MeetingTypeName" Type="String" />
            <asp:Parameter Name="original_MeetingTypeDescription" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="MeetingTypeName" Type="String" />
            <asp:Parameter Name="MeetingTypeDescription" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="MeetingTypeName" Type="String" />
            <asp:Parameter Name="MeetingTypeDescription" Type="String" />
            <asp:Parameter Name="original_MeetingTypeID" Type="Int32" />
            <asp:Parameter Name="original_MeetingTypeName" Type="String" />
            <asp:Parameter Name="original_MeetingTypeDescription" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </div>
</asp:Content>