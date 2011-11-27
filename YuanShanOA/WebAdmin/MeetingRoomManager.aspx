<%@ Page Language="C#" MasterPageFile="~/WebAdmin/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="MeetingRoomManager.aspx.cs" Inherits="YunShanOA.WebAdmin.MeetingRoomManager" %>

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
    <div style="margin: 50px 0px 0px 100px;">
       <div>
            <b>会议室资料维护:</b></div>
        <div>
            <input type="button" id="btnView" value="查看" class="button" />
            <input type="button" id="btnAdd" value="增加" class="button"/>
            <input type="button" id="btnEdit" value="编辑" class="button"/>
            <input type="button" id="btnDelete" value="删除" class="button"/>
        </div>
    <div id="add">
    <table>
    <tr><td>会议室名字:</td><td><asp:TextBox ID="txtMeetingRoomName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMeetingRoomName"
            ErrorMessage="会议室名字是必填项" ForeColor="Red">*</asp:RequiredFieldValidator></td></tr>
    <tr><td>会议室容量:</td><td><asp:TextBox ID="txtCap" runat="server" onkeydown="myKeyDown()"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="会议室容量是必填项"
            ForeColor="Red" ControlToValidate="txtCap">*</asp:RequiredFieldValidator></td></tr>
    <tr><td>会议室类型:</td><td><asp:DropDownList ID="ddlType" runat="server"  Width="142px" DataSourceID="SqlDataSource1"
            DataTextField="MeetingTypeName" DataValueField="MeetingTypeID">
        </asp:DropDownList></td></tr>
    <tr><td colspan="2"><asp:Button ID="btnTrue" runat="server" CssClass="button" OnClick="btnTrue_Click" Text="确认" /></td></tr>
   
    </table>
        
    </div>
    <div id="divDelete">
        <br />
        <br />
        <div id="show">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2"
           DataKeyNames="MeetingRoomID">
            <Columns>
                <asp:BoundField DataField="MeetingRoomName" HeaderText="会议室名字" SortExpression="MeetingRoomName" />
                <asp:BoundField DataField="MeetingRoomCapacity" HeaderText="会议室容量" SortExpression="MeetingRoomCapacity" />
            </Columns>
        </asp:GridView>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="edit">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3"
                    DataKeyNames="MeetingRoomID">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:BoundField DataField="MeetingRoomName" HeaderText="会议室名字" SortExpression="MeetingRoomName" />
                        <asp:BoundField DataField="MeetingRoomCapacity" HeaderText="会议室容量" SortExpression="MeetingRoomCapacity" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        <div id="delete">
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3"
        OnRowDataBound="GridView1_RowDataBound1"   DataKeyNames="MeetingRoomID">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="MeetingRoomName" HeaderText="会议室名字" SortExpression="MeetingRoomName" />
                <asp:BoundField DataField="MeetingRoomCapacity" HeaderText="会议室容量" SortExpression="MeetingRoomCapacity" />
            </Columns>
        </asp:GridView>
        </div>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConflictDetection="CompareAllValues" 
            ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
            DeleteCommand="DELETE FROM [MeetingRoom] WHERE [MeetingRoomID] = @original_MeetingRoomID AND [MeetingRoomName] = @original_MeetingRoomName AND [MeetingRoomCapacity] = @original_MeetingRoomCapacity AND (([MeetingRoomStatus] = @original_MeetingRoomStatus) OR ([MeetingRoomStatus] IS NULL AND @original_MeetingRoomStatus IS NULL)) AND [MeetingTypeID] = @original_MeetingTypeID" 
            InsertCommand="INSERT INTO [MeetingRoom] ([MeetingRoomName], [MeetingRoomCapacity], [MeetingRoomStatus], [MeetingTypeID]) VALUES (@MeetingRoomName, @MeetingRoomCapacity, @MeetingRoomStatus, @MeetingTypeID)" 
            OldValuesParameterFormatString="original_{0}" 
            SelectCommand="SELECT * FROM [MeetingRoom]" 
            UpdateCommand="UPDATE [MeetingRoom] SET [MeetingRoomName] = @MeetingRoomName, [MeetingRoomCapacity] = @MeetingRoomCapacity, [MeetingRoomStatus] = @MeetingRoomStatus, [MeetingTypeID] = @MeetingTypeID WHERE [MeetingRoomID] = @original_MeetingRoomID AND [MeetingRoomName] = @original_MeetingRoomName AND [MeetingRoomCapacity] = @original_MeetingRoomCapacity AND (([MeetingRoomStatus] = @original_MeetingRoomStatus) OR ([MeetingRoomStatus] IS NULL AND @original_MeetingRoomStatus IS NULL)) AND [MeetingTypeID] = @original_MeetingTypeID">
            <DeleteParameters>
                <asp:Parameter Name="original_MeetingRoomID" Type="Int32" />
                <asp:Parameter Name="original_MeetingRoomName" Type="String" />
                <asp:Parameter Name="original_MeetingRoomCapacity" Type="Int32" />
                <asp:Parameter Name="original_MeetingRoomStatus" Type="Int32" />
                <asp:Parameter Name="original_MeetingTypeID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="MeetingRoomName" Type="String" />
                <asp:Parameter Name="MeetingRoomCapacity" Type="Int32" />
                <asp:Parameter Name="MeetingRoomStatus" Type="Int32" />
                <asp:Parameter Name="MeetingTypeID" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="MeetingRoomName" Type="String" />
                <asp:Parameter Name="MeetingRoomCapacity" Type="Int32" />
                <asp:Parameter Name="MeetingRoomStatus" Type="Int32" />
                <asp:Parameter Name="MeetingTypeID" Type="Int32" />
                <asp:Parameter Name="original_MeetingRoomID" Type="Int32" />
                <asp:Parameter Name="original_MeetingRoomName" Type="String" />
                <asp:Parameter Name="original_MeetingRoomCapacity" Type="Int32" />
                <asp:Parameter Name="original_MeetingRoomStatus" Type="Int32" />
                <asp:Parameter Name="original_MeetingTypeID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <br />
    </div>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>"
        SelectCommand="SELECT [MeetingRoomName], [MeetingRoomCapacity], [MeetingRoomID] FROM [MeetingRoom]"
        ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [MeetingRoom] WHERE [MeetingRoomID] = @original_MeetingRoomID AND [MeetingRoomName] = @original_MeetingRoomName AND [MeetingRoomCapacity] = @original_MeetingRoomCapacity"
        InsertCommand="INSERT INTO [MeetingRoom] ([MeetingRoomName], [MeetingRoomCapacity]) VALUES (@MeetingRoomName, @MeetingRoomCapacity)"
        OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [MeetingRoom] SET [MeetingRoomName] = @MeetingRoomName, [MeetingRoomCapacity] = @MeetingRoomCapacity WHERE [MeetingRoomID] = @original_MeetingRoomID AND [MeetingRoomName] = @original_MeetingRoomName AND [MeetingRoomCapacity] = @original_MeetingRoomCapacity">
        <DeleteParameters>
            <asp:Parameter Name="original_MeetingRoomID" Type="Int32" />
            <asp:Parameter Name="original_MeetingRoomName" Type="String" />
            <asp:Parameter Name="original_MeetingRoomCapacity" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="MeetingRoomName" Type="String" />
            <asp:Parameter Name="MeetingRoomCapacity" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="MeetingRoomName" Type="String" />
            <asp:Parameter Name="MeetingRoomCapacity" Type="Int32" />
            <asp:Parameter Name="original_MeetingRoomID" Type="Int32" />
            <asp:Parameter Name="original_MeetingRoomName" Type="String" />
            <asp:Parameter Name="original_MeetingRoomCapacity" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>"
        SelectCommand="SELECT [MeetingTypeID], [MeetingTypeName] FROM [MeetingType]">
    </asp:SqlDataSource>
    </div>
</asp:Content>
