using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDataAccess.IDocument;
using YunShanOA.DataAccess.Mapping;
using YunShanOA.Model.DocumentModel;

namespace YunShanOA.DataAccess.DocumentHelper
{
    public class DocumentTemplateHelper : IDocumentTemplate
    {
        YunShanOADataContext db = new YunShanOADataContext();
        public Model.DocumentModel.documentTemplate GetDocumentTemplateByPath(string Path)
        {
            DocumentTemplate DocumentTemplate = (from DocumentTemplates in db.DocumentTemplate where DocumentTemplates.DocumentTemplatePath == Path select DocumentTemplates).FirstOrDefault();
            return FillRecored(DocumentTemplate);
        }





        public List<Model.DocumentModel.documentTemplate> GetDocumentTemplate()
        {
            var Query = from DocumentTemplates in db.DocumentTemplate select DocumentTemplates;
            List<Model.DocumentModel.documentTemplate> result = new List<documentTemplate>();
            foreach (var item in Query)
            {
                result.Add(FillRecored(item));
            }
            return result;
        }

        private Model.DocumentModel.documentTemplate FillRecored(DocumentTemplate DocumentTemplate)
        {
            documentTemplate documentTemplate = null;
            if (DocumentTemplate != null)
            {
                documentTemplate = new documentTemplate();
                documentTemplate.ID = DocumentTemplate.DocumentTemplateID;
                documentTemplate.DocumentTemplateDescription = DocumentTemplate.DocumentTemplateDescription;
                documentTemplate.DocumentTemplateName = DocumentTemplate.DocumentTemplateName;
                documentTemplate.DocumentTemplatePath = DocumentTemplate.DocumentTemplatePath;
            }
            return documentTemplate;
        }
    }
}
