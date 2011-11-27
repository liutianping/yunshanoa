using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text;

    public static class RoleManagerOK2
    {
        public static string RoleRemoveOrAddUser(string userName, string roleName)
        {
            if (Roles.IsUserInRole(userName, roleName))
            {
                Roles.RemoveUserFromRole(userName, roleName);
                return (userName + "已经从" + roleName + "移除！");
            }
            else
            {
                Roles.AddUserToRole(userName, roleName);
                return  (userName + "已经添加到" + roleName + "！");
            }
        }

        public static string GetAllUserNameList()
        {

            MembershipUserCollection arrUser = Membership.GetAllUsers();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (0 != arrUser.Count)
            {
                sb.Append("<select id='selectAllUser' onchange='getRoleByUser(this.value)'>");
                foreach (MembershipUser arr in arrUser)
                {
                    sb.Append("<option value='" + arr.UserName + "'>");
                    sb.Append(arr.UserName);
                    sb.Append("</option>");
                }
                sb.Append("</select>");
                return sb.ToString();
            }
            else
            {
                return sb.Append("暂无用户").ToString();
            }
        }

        public static string GetChkBoxRoleByUserName(string userName)
        {
            string[] allRoleName = Roles.GetAllRoles();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < allRoleName.Length; i++)
            {
                //<input type="checkbox" value="zhang" name="n" />
                sb.Append("<input type='checkbox' name='roleNameList' ");
                sb.Append("value='");
                sb.Append(allRoleName[i]);
                sb.Append("' ");
                if (Roles.IsUserInRole(userName, allRoleName[i]))
                {
                    sb.Append("checked ");
                }
                sb.Append("onclick=getRoleName(this.value) />");
                //sb.Append(" onclick=alert(1) />");
                sb.Append(allRoleName[i]);
                sb.Append("&nbsp;&nbsp;&nbsp;");
                if ((1 & i) != 0)
                    sb.Append("<br />");
            }
            return sb.ToString();
        }

        public static string GetAllRole()
        {
            string[] arrRoleList = Roles.GetAllRoles();
            StringBuilder sb = new StringBuilder();
            if (0 != arrRoleList.Length)
            {
                for (int i = 0; i < arrRoleList.Length; i++)
                {
                    sb.Append("<input type='checkbox' name='roleNameList' ");
                    sb.Append("value='");
                    sb.Append(arrRoleList[i]);
                    sb.Append("' ");
                    sb.Append("onclick='deleteRoleName(this.value)' />");
                    sb.Append(arrRoleList[i]);
                    sb.Append("&nbsp;&nbsp;&nbsp;");
                }
                return sb.ToString();
            }
            else
            {
                return "暂无角色！";
            }
        }

        public static string DeleteRole(string[] arrRoleNameList)
        {
            if (0 != arrRoleNameList.Length)
            {
                for (int i = 0; i < arrRoleNameList.Length; i++)
                {
                    if (Roles.RoleExists(arrRoleNameList[i]))
                    {
                        try
                        {
                            Roles.DeleteRole(arrRoleNameList[i]);
                        }
                        catch (Exception)
                        {
                            return GetAllRole()+"<br />要删除的角色: "+arrRoleNameList[i]+"  还有用户，不允许删除！请先删除此角色里的用户，然后重新删除此角色！";
                        }
                    }
                }
                return GetAllRole()+"<br />删除角色成功!";
            }
            else
            {
                return GetAllRole()+"<br />没有选中角色";
            }
        }
    }
