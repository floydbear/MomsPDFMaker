using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MomsPDFMaker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConvertImageToPDF()
        {
            //var sourceFileName = "C:\\Users\\kfloyd\\Pictures\\test\\baylorgamefriends.jpg";

            var buffer = new byte[System.Web.HttpContext.Current.Request.Files[0].InputStream.Length];
            var initialStream = System.Web.HttpContext.Current.Request.Files[0].InputStream;

            initialStream.Read(buffer, 0, (int)System.Web.HttpContext.Current.Request.Files[0].InputStream.Length);
            var fileName = System.Web.HttpContext.Current.Request.Files[0].FileName;
            var fileStream = new MemoryStream(buffer);

            //var fileUpload = fileToConvert.Attachment;
            //var sourceFileName = fileUpload.InputStream;
            //var file = fileUpload;

            iTextSharp.text.Rectangle pageSize = null;


            using (var sourceImage = new Bitmap(fileStream))
            {
                pageSize = new iTextSharp.text.Rectangle(0, 0, sourceImage.Width, sourceImage.Height);

            }
            fileStream.Seek(0, SeekOrigin.Begin);
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(fileStream))
            {
                fileData = binaryReader.ReadBytes(buffer.Length);
            }


            using (var memoryStream = new MemoryStream())
            {
                var document = new iTextSharp.text.Document(pageSize, 0, 0, 0, 0);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, memoryStream).SetFullCompression();
                document.Open();
                var image = iTextSharp.text.Image.GetInstance(fileData);
                document.Add(image);
                document.Close();

                return File(memoryStream.ToArray(), "application/pdf", fileName+".pdf");
            }
            
        }
    }

    public class FileToConvert
    {
        public HttpPostedFileBase Attachment { get; set; } 
    }
}