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
                                    bool mesEnMora)
        {
            string mensualidadLetra = NumeroLetra.NumeroALetras(mensualidad);
            //string mes = Convert.ToDateTime(proximoMes).Month.ToString("MMMM");
            string filename = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            string aunDebe = "";

            if (mesEnMora) {

                aunDebe = "RESTANDO LA CANDIDAD DE " + interes + "CORRESPONDIENTE A LOS INTERESES DEL MES DE" + mes;
            }

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
                            + "                                                         "
                            + "LOTE No " + numeroLote + " MANZANA " + numeroManzana
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + "RECIBI DEL SR(a). " + nombreComprador + ", LA CANTIDAD DE " + mensualidad
                            + " (SON " + mensualidadLetra + " PESOS M.N) POR CONCEPTO DE PAGO DEL MES DE " + mes
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
                            + Chunk.NEWLINE
                            + "RECIBI DEL SR(a). " + nombreComprador + ", LA CANTIDAD DE " + mensualidad
                            + " (SON " + mensualidadLetra + " PESOS M.N) POR CONCEPTO DE ABONO DEL MES DE " + mes
                            + " DEL LOTE No. " + numeroLote + " DE LA MANZANA " + numeroManzana + ", UBICADO EN EL “FRACCIONAMIENTO”, " + predio
                            + " EN "+ colonia +", MUNICIPIO DE "+ ciudad +", JALISCO, DICHO LOTE TIENE UNA MEDIDA DE"
                            + " "+ norte +" POR "+ poniente +" MTS  SIENDO UN TOTAL DE "+(Convert.ToInt32(norte)*Convert.ToInt32(poniente))+" MTS. CUADRADOS. QUEDANDO EN DEUDA UN TOTAL DE "+restoMensualidad
                            + " y "+ interes +" DE INTERES CORRESPONDIENTE DEL MISMO MES"
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + "                                              SR. MOISES SANTIAGO FIGUEROA"
                            + Chunk.NEWLINE
                            + "                                                            VENDEDOR");
            }
            //Añadimos el parrafo al documento
            recibo.Add(parrafo);

            //cerramos la escritura del documento
            recibo.Close();

            Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = filename;
            prc.Start();
        
        }

        public void crearPdfReciboMora(string tipo,
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
                                    bool mesEnMora)
        {
            string interesLetra = NumeroLetra.NumeroALetras(interes);
            //string mes = Convert.ToDateTime(proximoMes).Month.ToString("MMMM");
            string filename = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            string aunDebe = "";

            if (mesEnMora)
            {

                aunDebe = "RESTANDO LA CANDIDAD DE " + interes + "CORRESPONDIENTE A LOS INTERESES DEL MES DE" + mes;
            }

            //Creamos documento con el tamaña de pagina tradicional
            Document recibo = new Document(PageSize.A4, 85, 85, 100, 10);
            //Indicamos la ruta donde se guardara el documento
            PdfWriter escribir = PdfWriter.GetInstance(recibo, new FileStream(filename, FileMode.Create));

            //abrimos archivo
            recibo.Open();

            //creamos el tipo de font que vamos a utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN
                                                                          , 12
                                                                          , iTextSharp.text.Font.BOLD
                                                                          , BaseColor.BLACK);

            //Instanciamos un nuevo parrafo
            Paragraph parrafo = new Paragraph();

            parrafo.Alignment = Element.ALIGN_JUSTIFIED;

            if (tipo == "contado")
            {
                //agregamos texto al parrafo
                parrafo.Add("PAGO No " + pagoActual + " de " + pagoFinal
                            + "                                                         "
                            + "LOTE No " + numeroLote + " MANZANA " + numeroManzana
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + "RECIBI DEL SR(a). " + nombreComprador + ", LA CANTIDAD DE " + interes
                            + " (SON " + interesLetra + " PESOS M.N) POR CONCEPTO DE PAGO DE INTERES DEL MES DE " + mes
                            + " DEL LOTE No. " + numeroLote + " DE LA MANZANA " + numeroManzana + ", UBICADO EN EL “FRACCIONAMIENTO”, " + predio
                            + " EN " + colonia + ", MUNICIPIO DE " + ciudad + ";JALISCO, DICHO LOTE TIENE UNA MEDIDA DE"
                            + "  " + norte + " POR " + poniente + " MTS  SIENDO UN TOTAL DE " + (Convert.ToInt32(norte) * Convert.ToInt32(poniente)) + " MTS. CUADRADOS" + aunDebe
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + "                                                        SR. MOISES SANTIAGO FIGUEROA"
                            + Chunk.NEWLINE
                            + "                                                                     VENDEDOR");
            }
            if (tipo == "abono")
            {
                //agregamos texto al parrafo
                parrafo.Add("PAGO No " + pagoActual + " de " + pagoFinal
                            + "                                                      "
                            + "LOTE No " + numeroLote + " MANZANA " + numeroManzana
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + "RECIBI DEL SR(a). " + nombreComprador + ", LA CANTIDAD DE " + interes
                            + " (SON " + interesLetra + " PESOS M.N) POR CONCEPTO DE ABONO DE INTERESES DEL MES DE " + mes
                            + " DEL LOTE No. " + numeroLote + " DE LA MANZANA " + numeroManzana + ", UBICADO EN EL “FRACCIONAMIENTO”, " + predio
                            + " EN " + colonia + ", MUNICIPIO DE " + ciudad + ", JALISCO, DICHO LOTE TIENE UNA MEDIDA DE"
                            + " " + norte + " POR " + poniente + " MTS  SIENDO UN TOTAL DE " + (Convert.ToInt32(norte) * Convert.ToInt32(poniente)) + " MTS. CUADRADOS. QUEDANDO EN DEUDA UN TOTAL DE " + restoMensualidad
                            + " y " + interes + " DE INTERES CORRESPONDIENTE DEL MISMO MES"
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + Chunk.NEWLINE
                            + "                                                        SR. MOISES SANTIAGO FIGUEROA"
                            + Chunk.NEWLINE
                            + "                                                                      VENDEDOR");
            }
            //Añadimos el parrafo al documento
            recibo.Add(parrafo);

            //cerramos la escritura del documento
            recibo.Close();

            Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = filename;
            prc.Start();

        }

    }
}
