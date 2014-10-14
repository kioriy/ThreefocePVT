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
        public void crearPdfRecibo (string tipo, 
                                    string pagoActual, 
                                    string pagoFinal,
                                    string numeroLote, 
                                    string numeroManzana, 
                                    string nombreComprador, 
                                    string mensualidad, 
                                    string mes, 
                                    string predio,
                                    string colonia, 
                                    string ciudad, 
                                    string norte, 
                                    string poniente, 
                                    string restoMensualidad, 
                                    string interes,
                                    /*bool mesEnMora <-- lo utilizaba cuando se podia pagar mensualidad antes que intereses*/
                                    int[] quePagueYcuantasVeces)
        {
            string mensualidadLetra = NumeroLetra.NumeroALetras(mensualidad);
            //string mes = Convert.ToDateTime(proximoMes).Month.ToString("MMMM");
            string filename = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            string aunDebe = "";
            string mesMeses = "";
            string abonoPago = " ABONO";

            if (quePagueYcuantasVeces[2] > 1)
            {
                mesMeses = " DE LOS MESES DE ";
            }
            else if(quePagueYcuantasVeces[2] != 0)
            {
                mesMeses = " DEL MES DE";
            }
            if (quePagueYcuantasVeces[2] >= 1)
            {
                abonoPago = " PAGO COMPLETO ";
            }
            else if (quePagueYcuantasVeces[2] == 0 && quePagueYcuantasVeces[3] == 1)
            {
                abonoPago = " ABONO ";
            }


            //if (mesEnMora) {

            //    aunDebe = "RESTANDO LA CANDIDAD DE " + interes + "CORRESPONDIENTE A LOS INTERESES DEL MES DE" + mes;
            //}

            //Creamos documento con el tamaña de pagina tradicional
            Document recibo = new Document(PageSize.A4, 85 , 85, 100, 10);
            //Indicamos la ruta donde se guardara el documento
            PdfWriter escribir = PdfWriter.GetInstance(recibo, new FileStream(filename, FileMode.Create));

            //abrimos archivo
            recibo.Open();

            //creamos el tipo de font que vamos a utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN
                                                                          ,12
                                                                          ,iTextSharp.text.Font.BOLD
                                                                          ,BaseColor.BLACK);

            //Instanciamos un nuevo parrafo
            Paragraph parrafo = new Paragraph();

            parrafo.Alignment = Element.ALIGN_JUSTIFIED;

            if (tipo == "contado")
            {
                //agregamos texto al parrafo
                parrafo.Add("PAGO No " + pagoActual + " de " + pagoFinal
                            + "                                                     "
                            + "LOTE No " + numeroLote + " MANZANA " + numeroManzana
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + "RECIBI DEL SR(a). " + nombreComprador + ", LA CANTIDAD DE " + mensualidad
                            + " (SON " + mensualidadLetra + " PESOS M.N) POR CONCEPTO DE "+abonoPago+" "+mesMeses+" "+ mes
                            + " DEL LOTE No. " + numeroLote + " DE LA MANZANA " + numeroManzana + ", UBICADO EN EL “FRACCIONAMIENTO”, " + predio
                            + " EN " + colonia + ", MUNICIPIO DE " + ciudad + ";JALISCO, DICHO LOTE TIENE UNA MEDIDA DE"
                            + "  " + norte + " POR " + poniente + " MTS  SIENDO UN TOTAL DE " + (Convert.ToInt32(norte) * Convert.ToInt32(poniente)) + " MTS. CUADRADOS"+aunDebe
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + "                                              SR. MOISES SANTIAGO FIGUEROA"
                            + Chunk.NEWLINE
                            + "                                                           VENDEDOR");
            }
            if (tipo == "abono")
            {
                //agregamos texto al parrafo
                parrafo.Add("PAGO No " + pagoActual + " de " + pagoFinal
                            + "                                                      "
                            + "LOTE No " + numeroLote + " MANZANA " + numeroManzana
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + "CLIENTE" + nombreComprador
                            + Chunk.NEWLINE
                            + "FECHA DE PAGO" + mes
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE);
            }
            //Añadimos el parrafo al documento
            recibo.Add(parrafo);

            //creamos la tabla 
            PdfPTable table = new PdfPTable(4);

            table.TotalWidth = 400f;

            table.LockedWidth = true;

            //PdfPCell header = new PdfPCell(new Phrase("Header"));

            //header.Colspan = 4;

            //table.AddCell(header);

            table.AddCell("CONCEPTO");

            table.AddCell("AQUI VA EL CONCEPTO DE PAGO");

            table.AddCell("PAGO");

            table.AddCell("AQUI VA LA CANTIDAD QUE SE ESTA PAGANDO");

            table.AddCell("TOTAL");

            table.AddCell("AQUI VA EL TOTAL DE LO QUE SE PAGO DE LOS CONCEPTOS");

            table.AddCell("RESTAN");

            table.AddCell("AQUI VE EL RESTO DE ADEUDO SI ES QUE EXISTIERA");

            //PdfPTable nested = new PdfPTable(1);

            //nested.AddCell("Nested Row 1");

            //nested.AddCell("Nested Row 2");

            //nested.AddCell("Nested Row 3");

            //PdfPCell nesthousing = new PdfPCell(nested);

            //nesthousing.Padding = 0f;

            //table.AddCell(nesthousing);

            //PdfPCell bottom = new PdfPCell(new Phrase("bottom"));

            //bottom.Colspan = 3;

            //table.AddCell(bottom);

            recibo.Add(table);

            //cerramos la escritura del documento
            recibo.Close();

            Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = filename;
            prc.Start();
        
        }
    }
}
