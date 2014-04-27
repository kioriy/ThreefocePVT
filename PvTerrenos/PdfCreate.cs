using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PvTerrenos
{
    class PdfCreate
    {
        public void crearPdf ()
        {
            //Creamos documento con el tamaña de pagina tradicional
            Document recibo = new Document(PageSize.LETTER);
            //Indicamos la ruta donde se guardara el documento
            PdfWriter escribir = PdfWriter.GetInstance(recibo, new FileStream(@"C:\Users\Kioriy\Desktop\recibo.pdf", FileMode.Create));

            //abrimos archivo
            recibo.Open();

            //creamos el tipo de font que vamos a utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                                                                          ,8
                                                                          ,iTextSharp.text.Font.NORMAL
                                                                          ,BaseColor.BLACK);

            //Instanciamos un nuevo parrafo
            Paragraph parrafo = new Paragraph();

            //agregamos texto al parrafo
            parrafo.Add("hola mundo desde un pdf creado en c#");

            //Añadimos el parrafo al documento
            recibo.Add(parrafo);

            //cerramos la escritura del documento
            recibo.Close();

            Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = @"C:\Users\Kioriy\Desktop\recibo.pdf";
            prc.Start();
        
        }

    }
}
