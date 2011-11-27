using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDataAccess.IDocument;

namespace YunShanOA.BusinessLogic.DocumentManager
{
    public class DocumentTemplateManager
    {
        private static readonly IDocumentTemplate dal = YunShanOA.DALFactory.DocumentInstanceFactory.GetDocumentTemplateInstance();
        public Model.DocumentModel.documentTemplate GetDocumentTemplateByPath(string Path)
        {
            if (Path != null)
            {
                return dal.GetDocumentTemplateByPath(Path);
            }
            return null;
        }
        public List<Model.DocumentModel.documentTemplate> GetDocumentTemplate()
        {
            return dal.GetDocumentTemplate();
        }
          

    }
}
