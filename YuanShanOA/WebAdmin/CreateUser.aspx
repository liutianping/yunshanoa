<%@ Page Language="C#" MasterPageFile="~/WebAdmin/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="YunShanOA.WebAdmin.CreateUser" %>
<%@ MasterType  VirtualPath="~/WebAdmin/MasterPage.Master"%>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder8">


    <div style=" margin:80px 0px 0px 250px;">
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
            CancelDestinationPageUrl="~/WebAdmin/Default.aspx" ContinueButtonText="完成" 
            ContinueDestinationPageUrl="~/WebAdmin/Default.aspx" CreateUserButtonText="下一步" 
            DisplayCancelButton="True" FinishCompleteButtonText="创建用户" 
            FinishDestinationPageUrl="~/WebAdmin/Default.aspx">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                </asp:CreateUserWizardStep>
                <asp:WizardStep runat="server" Title="请选择角色">
                    请选择一个角色:<br />
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        DataSourceID="SqlDataSource1" DataTextField="RoleName" DataValueField="RoleId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                        SelectCommand="SELECT [RoleId], [RoleName] FROM [vw_aspnet_Roles]">
                    </asp:SqlDataSource>
                </asp:WizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    
    </div>
    

</asp:Content>