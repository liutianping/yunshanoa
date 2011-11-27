using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDataAccess;
using System.Configuration;
using System.Reflection;
using YunShanOA.IDataAccess.IDocument;

namespace YunShanOA.DALFactory
{
    public class DocumentInstanceFactory
    {
        private static readonly string PATH = ConfigurationManager.AppSettings["SqlServerDataAccess"];
        private DocumentInstanceFactory() { }
        public static YunShanOA.IDataAccess.IDocument.IDocumentTemplate GetDocumentTemplateInstance()
        {
            string className = PATH + ".DocumentHelper.DocumentTemplateHelper";
            return (IDocumentTemplate)Assembly.Load(PATH).CreateInstance(className);
        }


        public static YunShanOA.IDataAccess.IDocument.IDocument GetDocumentInstance()
        {
            string className = PATH + ".DocumentHelper.DocumentApplyHelper";
            return (IDocument)Assembly.Load(PATH).CreateInstance(className);
        }

    }
}
