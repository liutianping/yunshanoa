using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.DataAccess.Mapping;
using System.Data.Linq;
using YunShanOA.Model.DocumentModel;


namespace YunShanOA.DataAccess.DocumentHelper
{
    public class DocumentApplyHelper : YunShanOA.IDataAccess.IDocument.IDocument
    {
        YunShanOADataContext db = new YunShanOADataContext();

        public List<YunShanOA.Model.DocumentModel.DocumentApply> getList()
        {
            var Query = from DocumentApplys in db.Document select DocumentApplys;
            List<YunShanOA.Model.DocumentModel.DocumentApply> resut = new List<Model.DocumentModel.DocumentApply>();
            foreach (var item in Query)
            {
                resut.Add(Fillrecord(item));
            }
            return resut;
        }
        public DocumentApply getDocumentApplybyId(int id)
        {
            var result = (from DocumentApplys in db.Document where DocumentApplys.DocumentID == id select DocumentApplys).FirstOrDefault();
            return Fillrecord(result);
        }
        public List<YunShanOA.Model.DocumentModel.DocumentApply> getListByStatus(int Status)
        {
            var Query = from DocumentApplys in db.Document  where DocumentApplys.Status ==Status select  DocumentApplys;
            List<YunShanOA.Model.DocumentModel.DocumentApply> resut = new List<Model.DocumentModel.DocumentApply>();
            foreach (var item in Query)
            {
                resut.Add(Fillrecord(item));
            }
            return resut;
        }
        public int Save(YunShanOA.Model.DocumentModel.DocumentApply myDocumentApply)
        {

            Document u;
            bool found = false;

            if (myDocumentApply.DocumentID == -1)
            {
                // new record
                u = new Document();
                db.Document.InsertOnSubmit(u);
                found = true;
            }
            else
            {
                // existing record
                u = (from myDocumentApplys in db.Document where myDocumentApplys.DocumentID == myDocumentApply.DocumentID select myDocumentApplys).FirstOrDefault();
                if (u != null)
                {
                    found = true;
                    u.DocumentID = myDocumentApply.DocumentID;
                }
            }
            if (found)
            {
                u.Status = myDocumentApply.Status;
                u.WFID = myDocumentApply.WFID;
                u.DocumentName = myDocumentApply.DocumentName;
                u.DocumentPath = myDocumentApply.DocumentPath;
                u.DocumentAuthor = myDocumentApply.Author;

                try
                {
                    db.SubmitChanges();
                }
                catch (ChangeConflictException)
                {
                    db.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                    db.SubmitChanges();
                }
                return u.DocumentID;
            }
            else
                return -1;
        }
        private Model.DocumentModel.DocumentApply Fillrecord(Document item)
        {
            DocumentApply d = null;
            if (item != null)
            {
                d = new DocumentApply();
                d.DocumentID = item.DocumentID;
                d.Author = item.DocumentAuthor;
                d.DocumentPath = item.DocumentPath;
                d.Status = item.Status;
                d.WFID = item.WFID;
                d.DocumentName = item.DocumentName;
            }
            return d;
        }
    }
}
