using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using YunShanOA.IDAL.IUseCar;
using System.Reflection;

namespace YunShanOA.DALFactory
{
    public   class UseCarInstanceFactory
    {
        private static readonly string PATH = ConfigurationManager.AppSettings["SqlServerDataAccess"];
        private UseCarInstanceFactory() { }
        public static YunShanOA.IDAL.IUseCar.ICar GetCarInstance()
        {
            string className = PATH + ".UseCar.CarHelp";
            return (ICar)Assembly.Load(PATH).CreateInstance(className);
        }
        public static YunShanOA.IDAL.IUseCar.IUsecarType GetUsecarTypeInstance()
        {
            string className = PATH + ".UseCar.UsecarTypeHelp";
            return (IUsecarType)Assembly.Load(PATH).CreateInstance(className);
        }
        public static YunShanOA.IDAL.IUseCar.IAspnet_User GetAspnet_UsersInstance()
        {
            string className = PATH + ".UseCar.aspnet_UsersHelp";
            return (IAspnet_User)Assembly.Load(PATH).CreateInstance(className);
        }
        public static YunShanOA.IDAL.IUseCar.IArchivUsercarApply GetArchivUsercarApplyInstance()
        {
            string className = PATH + ".UseCar.ArchivUsercarApplyHelp";
            return (IArchivUsercarApply)Assembly.Load(PATH).CreateInstance(className);
        }
        public static YunShanOA.IDAL.IUseCar.IReviewUseCarApplyForm GetReviewUsecarApplyInstance()
        {
            string className = PATH + ".UseCar.ReviewUseCarApplyFormHelp";
            return (IReviewUseCarApplyForm)Assembly.Load(PATH).CreateInstance(className);
        }
        public static YunShanOA.IDAL.IUseCar.IUsecarApplyform GetUsecarApplyformInstance()
        {
            string className = PATH + ".UseCar.UsecarApplyformHelp";
            return (IUsecarApplyform)Assembly.Load(PATH).CreateInstance(className);
        }
        public static YunShanOA.IDAL.IUseCar.IUsecarAndUser GetUsecarAndUserInstance()
        {
            string className = PATH + ".UseCar.UsecarAndUserHelp";
            return (IUsecarAndUser)Assembly.Load(PATH).CreateInstance(className);
        }
    }
}
