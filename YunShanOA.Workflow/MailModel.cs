using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Common2
{
    public class MailModel
    {
        string mailFrom;
        /// <summary>
        /// 发件人
        /// </summary>
        public string MailFrom
        {
            get { return mailFrom; }
            set { mailFrom = value; }
        }
        string displayName;
        /// <summary>
        /// 显示的名字
        /// </summary>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
        string[] mailTo;
        /// <summary>
        /// 收件人 是一个数组
        /// </summary>
        public string[] MailTo
        {
            get { return mailTo; }
            set { mailTo = value; }
        }
        string[] mailCc;
        /// <summary>
        /// 抄送 可为空
        /// </summary>
        public string[] MailCc
        {
            get { return mailCc; }
            set { mailCc = value; }
        }
        string[] mailBcc;
        /// <summary>
        /// 附件 可为空
        /// </summary>
        public string[] MailBcc
        {
            get { return mailBcc; }
            set { mailBcc = value; }
        }
        string mailSubject;
        /// <summary>
        /// 邮件主题
        /// </summary>
        public string MailSubject
        {
            get { return mailSubject; }
            set { mailSubject = value; }
        }
        string mailBody;
        /// <summary>
        /// 邮件内容
        /// </summary>
        public string MailBody
        {
            get { return mailBody; }
            set { mailBody = value; }
        }
        string[] attachments;
        /// <summary>
        /// 附件 可为空
        /// </summary>
        public string[] Attachments
        {
            get { return attachments; }
            set { attachments = value; }
        }
        string smtpServer;
        /// <summary>
        /// smtp 服务器
        /// </summary>
        public string SmtpServer
        {
            get { return smtpServer; }
            set { smtpServer = value; }
        }
        int smtpPort;
        /// <summary>
        /// 服务器端口
        /// </summary>
        public int SmtpPort
        {
            get { return smtpPort; }
            set { smtpPort = value; }
        }
        string userName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        string password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        bool smtpSsl;
        /// <summary>
        /// 是否加密
        /// </summary>
        public bool SmtpSsl
        {
            get { return smtpSsl; }
            set { smtpSsl = value; }
        }
    }
}
