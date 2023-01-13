using System;
using System.IO;
using System.Numerics;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;

class Program
{

    public static void Main()
    {
        using (PdfDocument pdfDoc = PdfReader.Open(@"C:\Users\supawit.kho\RiderProjects\SignatureToPdf\SignatureToPdf\input.pdf", PdfDocumentOpenMode.Modify))
        {
            // get the number of pages
            int pageCount = pdfDoc.Pages.Count-1;
            // set max page
            PdfPage page = pdfDoc.Pages[pageCount];
            XGraphics gfx = XGraphics.FromPdfPage(page);
            
            // calculate the width and height of the page
            double width = page.Width;
            double height = page.Height;
            
            DrawSsignature(gfx, @"C:\Users\supawit.kho\RiderProjects\SignatureToPdf\SignatureToPdf\signature\1.jpg",
                width, height, 1);
            
            DrawSsignature(gfx, @"C:\Users\supawit.kho\RiderProjects\SignatureToPdf\SignatureToPdf\signature\2.jpg",
                width, height, 2);
            
            DrawSsignature(gfx, @"C:\Users\supawit.kho\RiderProjects\SignatureToPdf\SignatureToPdf\signature\3.jpg",
                width, height, 3);
            //
            pdfDoc.Save(@"C:\Users\supawit.kho\RiderProjects\SignatureToPdf\SignatureToPdf\output.pdf");
        }
    }

    public static void DrawSsignature(XGraphics gfx, string imagePath, double width, double height, double position)
    {
        // calculate the scale factor
        double desiredWidth = 100;
        double desiredHeight = 100;
        //
        XImage image = XImage.FromFile(imagePath);
        // calculate the position of the image
        double x = (width / 9) * 1.1;
        switch (position)
        {
            case 1:
                x = (width / 9) * 1.1;
                break;
            case 2:
                x = (width / 9) * 3.7;
                break; 
            case 3:
                x = (width / 9) * 6.2;
                break;
            default:
                // code block
                break;
        }
        double y = height - (desiredHeight) - 27;

        // draw the image on the page
        gfx.DrawImage(image, x, y, 100, 63);
    }
}