using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.Model.UseCarModel;

namespace YunShanOA.Workflow.UseCar
{
    public sealed class UpdateCarState : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数     
        public InArgument<ArrangeDrawOutFrom> UpdateApplyInfo { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 派生并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            ArrangeDrawOutFrom From = UpdateApplyInfo.Get(context);
            YunShanOA.BusinessLogic.UseCar.CarManager Manager = new BusinessLogic.UseCar.CarManager();
            foreach (string id in From.CarIDList)
            {
                car car = Manager.GetCarByid(int.Parse(id));
                car.Status = 1;
                Manager.Save(car);
            }
            YunShanOA.Model.UseCarModel.usecarapplyform f = new usecarapplyform();
            YunShanOA.BusinessLogic.UseCar.UsecarApplyformManager m = new BusinessLogic.UseCar.UsecarApplyformManager();
            f = m.GetusecarapplyformById(int.Parse(From.UseCarInfromID));
            f.ApplyStatus = 4;
            m.Sava(f);
        }
    }
}
