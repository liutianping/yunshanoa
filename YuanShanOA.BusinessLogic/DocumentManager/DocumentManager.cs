using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDataAccess.IDocument;
using YunShanOA.Model.DocumentModel;

namespace YunShanOA.BusinessLogic.DocumentManager
{

    public class DocumentManager
    {
        private static readonly YunShanOA.IDataAccess.IDocument.IDocument dal = YunShanOA.DALFactory.DocumentInstanceFactory.GetDocumentInstance();

        public List<DocumentApply> GetList()
        {
            return dal.getList();
        }
        public int Save(YunShanOA.Model.DocumentModel.DocumentApply  DocumentApply) 
        {
            if (DocumentApply != null)
            {
                return dal.Save(DocumentApply);
            }
            return -1;
        }
        public List<YunShanOA.Model.DocumentModel.DocumentApply> getListByStatus(int Status)
        {
            return dal.getListByStatus(Status);
        }
        public DocumentApply getDocumentApplyByid(int id)
        {
            return dal.getDocumentApplybyId(id);
        }

    }
}

