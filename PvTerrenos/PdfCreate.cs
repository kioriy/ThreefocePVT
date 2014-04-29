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
        public void crearPdfRecibo (string tipo, string pagoActual, string pagoFinal,string numeroLote, string numeroManzana, string nombreComprador, string mensualidad, string proximoMes, string predio,string direccion, string ciudad, string norte, string poniente)
        {
            string mensualidadLetra = NumeroLetra.NumeroALetras(mensualidad);
            string mes = Convert.ToString(Convert.ToDateTime(proximoMes).Month);
           
            //Creamos documento con el tamaña de pagina tradicional
            Document recibo = new Document(PageSize.A4,50,50,100,10);
            //Indicamos la ruta donde se guardara el documento
            PdfWriter escribir = PdfWriter.GetInstance(recibo, new FileStream(@"C:\Users\Kioriy\Desktop\recibo.pdf", FileMode.Create));

            //abrimos archivo
            recibo.Open();

            //creamos el tipo de font que vamos a utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN
                                                                          ,8
                                                                          ,iTextSharp.text.Font.BOLD
                                                                          ,BaseColor.BLACK);

            //Instanciamos un nuevo parrafo
            Paragraph parrafo = new Paragraph();

            parrafo.Alignment = Element.ALIGN_JUSTIFIED;

            if (tipo == "contado")
            {
                //agregamos texto al parrafo
                parrafo.Add("PAGO No " + pagoActual + " de " + pagoFinal
                            + "                                                                         "
                            + "LOTE No " + numeroLote + " MANZANA " + numeroManzana
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + "RECIBI DEL SR(a). " + nombreComprador + ", LA CANTIDAD DE " + mensualidad
                            + " (SON " + mensualidadLetra + " PESOS) POR CONCEPTO DE PAGO DEL MES DE " + mes
                            + " DEL LOTE No. " + numeroLote + " DE LA MANZANA " + numeroManzana + ", UBICADO EN EL “FRACCIONAMIENTO”, " + predio
                            + " EN COYULA , MUNICIPIO DE  TONALA, JALISCO, DICHO LOTE TIENE UNA MEDIDA DE"
                            + " " + norte + " POR " + poniente + " MTS  SIENDO UN TOTAL DE "+(Convert.ToInt32(norte) * Convert.ToInt32(poniente))+" MTS. CUADRADOS");
            }
            if (tipo == "abono")
            {
                //agregamos texto al parrafo
                parrafo.Add("PAGO No " + pagoActual + " de " + pagoFinal
                            + "                                                                         "
                            + "LOTE No " + numeroLote + " MANZANA " + numeroManzana
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + "RECIBI DEL SR(a). " + nombreComprador + ", LA CANTIDAD DE " + mensualidad
                            + " (SON " + mensualidadLetra + " PESOS) POR CONCEPTO DE ABONO DEL MES DE " + proximoMes
                            + " DEL LOTE No. " + numeroLote + " DE LA MANZANA " + numeroManzana + ", UBICADO EN EL “FRACCIONAMIENTO”, " + predio
                            + " EN COYULA , MUNICIPIO DE  TONALA, JALISCO, DICHO LOTE TIENE UNA MEDIDA DE"
                            + " "+norte+" POR "+poniente+" MTS  SIENDO UN TOTAL DE "+(Convert.ToInt32(norte)*Convert.ToInt32(poniente))+" MTS. CUADRADOS. RESTANDO UN TOTAL DE ");
            }
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
