<%@ Page Language="C#" MasterPageFile="~/Director_of_Eduction/MasterPage.Master" AutoEventWireup="true" CodeBehind="MeetingApplyProcess.aspx.cs" Inherits="YunShanOA.Meeting.MeetingApplyProcess" %>
<%@ MasterType VirtualPath="~/Director_of_Eduction/MasterPage.Master"%>
<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

   
    
    <div style="margin-left:60px;">
        <div style="  margin:20px 0px 20px 250px;"></div>
        
          <div style=" text-align:left;  ">          
                    <asp:GridView ID="gvApplyInfo" runat="server" AutoGenerateColumns="False" 
                        AutoGenerateSelectButton="True" AllowPaging="True" 
                        onrowdatabound="gvApplyInfo_RowDataBound" 
                        onselectedindexchanged="gvApplyInfo_SelectedIndexChanged" 
                        CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" 
                        PageSize="5" onpageindexchanging="gvApplyInfo_PageIndexChanging" 
                        onrowcommand="gvApplyInfo_RowCommand">
       
                        <Columns>
                            <asp:BoundField DataField="ApplyUserName" HeaderText="申请者" />
                            <asp:BoundField DataField="MeetingTypeID" HeaderText="会议类型ID" />
                            <asp:BoundField DataField="MeetingTopic" HeaderText="会议主题" />
                            <asp:BoundField DataField="MeetingIntroduction" HeaderText="会议简介" />
                            <asp:BoundField DataField="BeginTime" HeaderText="开始时间" />
                            <asp:BoundField DataField="EndTime" HeaderText="结束时间" />
                            <asp:BoundField DataField="MeetingStatus" HeaderText="会议状态" />
                            <asp:BoundField DataField="Comments" HeaderText="备注" />
                            <asp:BoundField DataField="WFID" HeaderText="唯一标识" />
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
         </div>
                    <asp:Panel ID="pngDetailInfo" runat="server" Height="302px" Visible="False">
                        <table class="">
                            <tr>
                                <td>
                                    <table align="center" cellspacing="1" >
                                        <tr>
                                            <td  class="style2">
                                                审核标识:&nbsp;
                                            </td>
                                            <td  class="right">
                                                <asp:Label ID="lblWfID" runat="server"></asp:Label>
                                              
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                申请者名字:</td>
                                            <td class="right">
                                                <asp:TextBox ID="txtApplyUserName" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                会议类型ID:</td>
                                            <td class="right">
                                                <asp:TextBox ID="txtMeetingTypeID" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                会议主题:</td>
                                            <td class="right">
                                                <asp:TextBox ID="txtMeetingTopic" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                开始时间:</td>
                                            <td class="right">
                                                <asp:TextBox ID="txtBeginTime" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                结束时间:</td>
                                            <td class="right">
                                                <asp:TextBox ID="txtEndTime" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style=" height:75px;">
                                            <td >
                                                会议简介:</td>
                                            <td class="right">
                                                <asp:TextBox ID="txtMeetingInst" runat="server" TextMode="MultiLine" Height="64px" Width="396px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        
                                        <tr style=" height:75px;">
                                            <td >
                                                备注:</td>
                                            <td class="right">
                                                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Height="64px" Width="396px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  colspan="2" style=" padding-left:120px;">
                                                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="1" Text="同意" />
                                                
                                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="1" TabIndex="5" 
                                                    Text="不同意" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left:160px;">
                                                <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" CssClass="button" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <div style=" margin-left:200px; font-size:30px;"><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></div>
        <asp:Literal ID="script" runat="server"></asp:Literal>
    </div>
    </asp:Content>