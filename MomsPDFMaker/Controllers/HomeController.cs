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

        public ActionResult  ConvertImageToPDF()
        {
            var sourceFileName = "C:\\Users\\kfloyd\\Pictures\\test\\baylorgamefriends.jpg";
            
            iTextSharp.text.Rectangle pageSize = null;

            using (var sourceImage = new Bitmap(sourceFileName))
            {
                pageSize = new iTextSharp.text.Rectangle(0, 0, sourceImage.Width, sourceImage.Height);
            }
            using (var memoryStream = new MemoryStream())
            {
                var document = new iTextSharp.text.Document(pageSize, 0, 0, 0, 0);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, memoryStream).SetFullCompression();
                document.Open();
                var image = iTextSharp.text.Image.GetInstance(sourceFileName);
                document.Add(image);
                document.Close();
                
                //System.IO.File.WriteAllBytes(destinationFileName, memoryStream.ToArray());
                return File(memoryStream.ToArray(), "application/pdf", "ConvertedImage.pdf");
            }

            
        }
    }
}