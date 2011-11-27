using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model.DocumentModel;


namespace YunShanOA.IDataAccess.IDocument
{
    public interface IDocument
    {
        DocumentApply getDocumentApplybyId(int id);
        List<YunShanOA.Model.DocumentModel.DocumentApply> getList();
        List<YunShanOA.Model.DocumentModel.DocumentApply> getListByStatus(int Status);
        int Save(YunShanOA.Model.DocumentModel.DocumentApply DocumentApply);
    }
}
