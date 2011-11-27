using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.Model.UseCarModel;
using YunShanOA.Common2;
using System.Configuration;

namespace YunShanOA.Workflow.UseCar
{

    public sealed class SendMailRenew : CodeActivity
    {
        // ����һ���ַ������͵Ļ�������
        public InArgument<ReviewUseCarApplyForm> ReviewUseCarApplyForm { get; set; }
        public InArgument<usecarapplyform> Apply { get; set; }
        // ��������ֵ����� CodeActivity<TResult>
        // �������� Execute �������ظ�ֵ��
        protected override void Execute(CodeActivityContext context)
        {

            // ��ȡ Text �������������ʱֵ
            if (2 == ReviewUseCarApplyForm.Get(context).Agree)
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("��ã���������ɽOA�ó����ŷ�������Ϣ����");
                MailBody.Append(Apply.Get(context).ApplyUserName.ToString() + "�����������룬���ڸ���ԭ����ͨ��������ϸ���ԭ���������룬���������������ϵ���ǣ���");
                MailModel mailModel = new MailModel();
                mailModel.MailBody = MailBody.ToString();
                // mailModel.MailBody
                mailModel.DisplayName = "��ɽ�ó�����";
                mailModel.MailSubject = "�������벻��ͨ������";
                YunShanOA.Common2.SendEmail2.SendEmailToUseCarUsers(new YunShanOA.BusinessLogic.UseCar.UsecarAndUserManager().GetCarAndUserlistByFormID(Apply.Get(context).UseCarApplyFormID), mailModel);
            }
            else
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("��ã���������ɽOA�ó����ŷ�������Ϣ����");
                MailBody.Append(Apply.Get(context).ApplyUserName.ToString() + "�������������Ѿ�ͨ������ʼʱ���ǣ�");
                MailBody.Append(Apply.Get(context).BeginTime.ToString() + ",����ʱ���ǣ�");
                MailBody.Append(Apply.Get(context).EndTime + "����������⣬����ϵ���ǣ�����");
                MailModel mailModel = new MailModel();
                mailModel.MailBody = MailBody.ToString();
                // mailModel.MailBody
                mailModel.DisplayName = "��ɽ�ó�����";
                mailModel.MailSubject = "��������ͨ������";
                YunShanOA.Common2.SendEmail2.SendEmailToUseCarUsers(new YunShanOA.BusinessLogic.UseCar.UsecarAndUserManager().GetCarAndUserlistByFormID(Apply.Get(context).UseCarApplyFormID), mailModel);
            }

        }
    }
}
