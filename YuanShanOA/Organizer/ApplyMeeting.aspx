<%@ Page Language="C#" MasterPageFile="~/Organizer/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApplyMeeting.aspx.cs" Inherits="YunShanOA.Meeting.ApplyMeeting" %>
<%@ MasterType VirtualPath="~/Organizer/MasterPage.Master" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">

    <div class="applymetting">
    <div id="l1">
    <div class="scroll">
    <table style=" text-align:right;">
    <tr >
    <td colspan="2" style=" text-align:left;  ">
        <b><asp:Label ID="lblInfo" runat="server" Text="填写会议申请基本信息"></asp:Label></b></td>
     </tr> 
     <tr>
        <td>申请人:</td><td class="right"><asp:TextBox runat="server" ID="txtApplyUserName">刘天平</asp:TextBox></td>
        </tr> 
        <tr><td>会议类型:</td><td class="right"><asp:DropDownList runat="server" Height="19px"  Width="125px" ID="ddlMeetingTypeID" 
            TabIndex="1">
        </asp:DropDownList></td></tr> 
        <tr><td>会议主题:</td><td class="right"><asp:TextBox runat="server" ID="txtMeetingTopic" TabIndex="2">临时介绍</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtMeetingTopic" ErrorMessage=" 会议主题不能为空" ForeColor="Red" 
                ValidationGroup="a">*</asp:RequiredFieldValidator>
            </td></tr> 
        
        <tr><td>开始时间:</td><td class="right"><asp:TextBox runat="server" ID="txtBeginTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
            onblur="compare()" TabIndex="4"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtBeginTime" ErrorMessage="开始时间不能为空" ForeColor="Red" 
                ValidationGroup="a">*</asp:RequiredFieldValidator>
            </td></tr> 
        <tr><td>结束时间:</td><td class="right"><asp:TextBox runat="server" ID="txtEndTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
            onblur="compare()" TabIndex="5"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txtEndTime" ErrorMessage="会议结束时间不能为空" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td></tr> 
            <tr style="height:75px;"><td>会议简介:</td><td class="right">
                <asp:TextBox runat="server" ID="txtMeetingInst" 
                TabIndex="3" TextMode="MultiLine" Height="64px" Width="396px">没有</asp:TextBox></td></tr> 
        <tr style=" height:75px;"><td>备注:</td><td class="right">
            <asp:TextBox runat="server" ID="txtComment" 
                TabIndex="6" TextMode="MultiLine" Height="64px" Width="396px" >唔</asp:TextBox></td></tr>    
        </table>
        </div>
        <input id="btnNext1" type="button" value="下一步" class="button" tabindex="7"  />
    </div>
    <div id="l2">
    <div class="scroll">
        <b><asp:Label ID="lblMeetingRoom" Text="请选择一个会议室" runat="server"></asp:Label></b>
         <br />
         <br />
        
         <div class="ro"></div>
         <div class="error">暂无会议室</div>
        <asp:RadioButtonList ID="rblMeetingRoomList" runat="server" RepeatColumns="3" 
            RepeatDirection="Horizontal">
        </asp:RadioButtonList>
        <br /></div> 
         <input id="btnPre1"  value="上一步" type="button"   class="button"/>
         <input id="btnNext2" value="下一步" type="button" class="button"/>
        
    </div>
    <div id="l3">
  
        <div class="scroll">
        <b><asp:Label ID="lblEquipmentName" runat="server" Text="选择设备名字和数量"></asp:Label></b>
        <br />
        <br />
        
        <asp:GridView ID="gvMeetingEquipment" runat="server" 
            AutoGenerateColumns="False"  
            Width="290px" DataKeyNames="MeetingEquipmentID" 
            onrowdatabound="gvMeetingEquipment_RowDataBound1"
             CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr">
            <Columns>
                <asp:BoundField HeaderText="设备名字" DataField="EquipmentName" />
                <asp:BoundField HeaderText="可用数量" DataField="MeetingEquipmentFreeCount" />
                <asp:TemplateField HeaderText="申请数量">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlFreeCountList" runat="server">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
        <input id="btnPre2" type="button" value="上一步" class="button""/>
        <input  id="btnNext3" type="button"value="下一步" class="button"" />
            
    </div>
  
     <div id="l4" >
    <div class="scroll">
        <b><asp:Label ID="lblMeetingUser" runat="server" Text="选择与会人员:"></asp:Label></b>
        <br />
        <br />
        <asp:CheckBoxList ID="cblMeetingUser" runat="server" Height="29px" Width="461px"
            RepeatColumns="3">
        </asp:CheckBoxList>
        <div runat="server" id="divEquipment" style="display: none">
    </div>
    <div runat="server" id="divMeetingUser" style="display: none">
    </div>
       </div>
        <input id="btnPre3" type="button" value="上一步" class="button"/>
        <asp:Button ID="btnApply" runat="server" Text="申&nbsp;&nbsp;&nbsp;&nbsp;请" OnClick="btnApplyMeeting_Click1" CssClass="button" />
    </div>
   
    
       
  

  </div>
    <script type="text/javascript">
        
        function compare() {
            var s = document.getElementById("ContentPlaceHolder3_txtBeginTime").value;
            var s2 = document.getElementById("ContentPlaceHolder3_txtEndTime").value;
            var arr = s.split(/(-|:|(\u0020+))/g);
            var arr2 = s2.split(/(-|:|(\u0020+))/g);
            var d = new Date(arr[0], arr[1] - 1, arr[2], arr[3], arr[4], arr[5]);
            var d2 = new Date(arr2[0], arr2[1] - 1, arr2[2], arr2[3], arr2[4], arr2[5]);

            if (d > d2) {
                alert('会议结束时间不能小于开始时间');
                // document.getElementById("Button1").disabled = true;
            } else {
                // document.getElementById("Button1").disabled = false;
            }
        }
        $(document).ready(function () {
            $("#l1,#l2,#l3,#l4,#l5").css({ "height": "430px" });
            $("#l2,#l3,#l4,#l5").hide();
            $('#btnNext1').click(function () {
                $('#btnNext2').show();
                $('.error').hide();
                if ($('.ro').html() == "")
                { $('#btnNext2').hide(); $('.error').show(); }
                $('#l1').hide('fast');
                $('#l2').show('fast');
                var beginTime = $('#ContentPlaceHolder3_txtBeginTime').val();
                var endTime = $('#ContentPlaceHolder3_txtEndTime').val();

                $.get(
                "../AJAX/MeetingRoomRadioButtonList.ashx",
                { beginTime: beginTime, endTime: endTime },
                function (html) {
                    $('.ro').html(html);
                }
                );
            });
            $('#btnPre1').click(function () {
                $('#l2').hide('fast');
                $('#l1').show('fast');
            });
            $('#btnNext2').click(function () {
                $('#l2').hide('fast');
                $('#l3').show('fast');
            });
            $('#btnPre2').click(function () {
                $('#l3').hide('fast');
                $('#l2').show('fast');
            });
            $('#btnNext3').click(function () {
                $('#l3').hide('fast');
                $('#l4').show('fast');
            });
            $('#btnPre3').click(function () {
                $('#l4').hide('fast');
                $('#l3').show('fast');
            });
        });
    </script>

</asp:Content>