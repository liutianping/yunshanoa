using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model.UseCarModel;

namespace YunShanOA.IDAL.IUseCar
{
    public interface IArchivUsercarApply
    {
        archivusercarapply GetArchivUsercarApplyByID(int id);
        IList<archivusercarapply> GetArchivUsercarList();
        int Save(archivusercarapply archivusercarapply);

    }
}
