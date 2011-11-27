using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model.DocumentModel;

namespace YunShanOA.IDataAccess.IDocument
{
    public interface IDocumentTemplate
    {
        documentTemplate GetDocumentTemplateByPath(string Path);
        List<documentTemplate> GetDocumentTemplate();
    }
}
