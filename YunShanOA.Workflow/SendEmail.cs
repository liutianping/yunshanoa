using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using YunShanOA.Model.UseCarModel;

namespace YunShanOA.Common2
{
    public class SendEmail2
    {
        static SMTP smtp = null;
        public static void SendEmailTo(List<Model.UserInfo> userList, MailModel mm)
        {
            Model.UserInfo[] listUserEmail = userList.ToArray();
            string[] arrUserEmail = new string[listUserEmail.Length];
            for (int i = 0; i < listUserEmail.Length; i++)
            {
                arrUserEmail[i] = listUserEmail[i].UserEmail;
            }
            mm.MailTo = arrUserEmail;
            smtp = new SMTP(mm);
            smtp.Send();
        }
        public static void SendEmailToUseCarUsers(List<YunShanOA.Model.UseCarModel.usecaranduser> users, MailModel mm)
        {
            usecaranduser[] listUserEmail = users.ToArray();

            string[] arrUserEmail = new string[listUserEmail.Length];
            for (int i = 0; i < listUserEmail.Length; i++)
            {
                arrUserEmail[i] = listUserEmail[i].Email;
            }
            mm.MailTo = arrUserEmail;
            mm.MailFrom = ConfigurationManager.AppSettings["commomEmail"].ToString();
            mm.Password = ConfigurationManager.AppSettings["emailPassword"].ToString();
            mm.SmtpServer = ConfigurationManager.AppSettings["smtpServer"].ToString();
            mm.SmtpPort = int.Parse(ConfigurationManager.AppSettings["port"].ToString());
            mm.UserName = ConfigurationManager.AppSettings["userName"].ToString();
            mm.MailBcc = null;
            mm.MailCc = null;

            mm.SmtpPort = 25;
            mm.SmtpSsl = false;
            smtp = new SMTP(mm);
            smtp.Send();

        }
        public static void SendEmailToUseCarUsers(List<string> Email, MailModel mm)
        {
            string[] listUserEmail = Email.ToArray();


            mm.MailTo = listUserEmail;
            mm.MailFrom = ConfigurationManager.AppSettings["commomEmail"].ToString();
            mm.Password = ConfigurationManager.AppSettings["emailPassword"].ToString();
            mm.SmtpServer = ConfigurationManager.AppSettings["smtpServer"].ToString();
            mm.SmtpPort = int.Parse(ConfigurationManager.AppSettings["port"].ToString());
            mm.UserName = ConfigurationManager.AppSettings["userName"].ToString();
            mm.MailBcc = null;
            mm.MailCc = null;

            mm.SmtpPort = 25;
            mm.SmtpSsl = false;
            smtp = new SMTP(mm);
            smtp.Send();

        }
    }
}
