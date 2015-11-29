using iTextSharp.text;
using iTextSharp.text.pdf;
using MVC_NCDAssignment.Misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace MVC_NCDAssignment.Models
{
    public class CriminalInfo
    {
        public enum SexType : byte
        {
            Male = 0,
            Female = 1,
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public SexType Sex { get; set; }
        public short Height { get; set; }
        public short Weight { get; set; }
        public string Nationality { get; set; }



        static Dictionary<int, Object> LockingIds = new Dictionary<int, object>();
        public void GeneratePDF()
        {
            Object lockObject;
            lock (LockingIds)
            {
                if (!LockingIds.TryGetValue(ID, out lockObject))
                {
                    lockObject = "";
                    LockingIds[ID] = lockObject;
                }
            }
            try
            {
                lock (lockObject)
                {
                    string pdfPath = PDFPath;
                    if (File.Exists(pdfPath))
                        return;

                    DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(pdfPath));
                    if (!di.Exists)
                        di.Create();

                    using (FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        Document document = new Document();
                        try
                        {

                            PdfWriter writer = PdfWriter.GetInstance(document, fs);
                            document.Open();
                            document.Add(new Paragraph(string.Format("ID : {0}", ID)));
                            document.Add(new Paragraph(string.Format("Name : {0}", Name)));
                            document.Add(new Paragraph(string.Format("Age : {0} years", Age)));
                            document.Add(new Paragraph(string.Format("Sex : {0}", Sex.ToString())));
                            document.Add(new Paragraph(string.Format("Height : {0} cms", Height)));
                            document.Add(new Paragraph(string.Format("Weight: {0} kgs", Weight)));
                            document.Add(new Paragraph(string.Format("Nationality : {0}", Nationality)));
                        }
                        finally
                        {
                            document.Close();
                        }

                    }

                
                }
            }
            finally
            {
                lock (LockingIds)
                {
                    LockingIds.Remove(ID);//Todo : must only be deleted by last caller, else the locking algorithm will break.
                }
            }
        }

        public string PDFPath
        {
            get
            {
                return CriminalUtils.MapFileName(GetPdfName());
            }
        }

        internal string GetPdfName()
        {
            return ID + ".pdf";
        }
    }
}

