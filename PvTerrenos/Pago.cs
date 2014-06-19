using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PvTerrenos
{
    public partial class FrmPago : Form
    {
        WSpvt.PVT ws = new WSpvt.PVT();
        Fecha f = new Fecha();
        PdfCreate recibo = new PdfCreate();

        string idVenta = "";
        string pago_actual = "";
        string proximoPago = "";
        string mensualidadDeVentas = "";
        string mensualidadProximoPago = "";
        string fecha_compra = "";
        string idMesActualizar;
        string[] splitIdMora;
        string[] splitIdLote;
        string[] splitFechaMora;
        string[] splitMontoMora;
        int[] arrayMeses;
        double totalInteres = 0;
        double sumaMesMora;
        double diferencia;

        public FrmPago()
        {
            InitializeComponent();
            llenarComboComprador();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cbComprador.Text = ws.getNombreComprador(txtId.Text);
            }
        }

        private void cbComprador_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IdComprador = ws.getIdComprador(cbComprador.SelectedItem.ToString());
            txtId.Text = IdComprador;
            totalInteres = 0;
            llenarComboLote();
        }

        private void cbLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMesesMora.Items.Clear();

            ///////// CONSULTA DE LA TABLA VENTAS /////////////////
            string superStringVenta = ws.getVentadeIdLote(splitIdLote[cbLote.SelectedIndex]); //cadena de string seprado por comas
            string[] splitVenta = superStringVenta.Split(new char[] { ',' });
            idVenta = splitVenta[0];
            mensualidadDeVentas = splitVenta[1];
            fecha_compra = splitVenta[2];
            string fecha_corte = splitVenta[3];
            ////////////////////////////////////////////////////////

            /////// CONSULTA DE LA TABLA PROXIMO PAGO  //////////////
            string superStringProximoPago = ws.getProximoPago(idVenta); //cadena de string separado por comas
            string[] splitProximoPago = superStringProximoPago.Split(new char[] { ',' });
            mensualidadProximoPago = splitProximoPago[0];
            proximoPago = splitProximoPago[1];
            pago_actual = splitProximoPago[2];
            string pago_final = splitProximoPago[3];
            string status_mora = splitProximoPago[4];
            ////////////////////////////////////////////////////////

            /////// CONSULTA PREDIO MANZANA LOTE ////////////////////
            string idManzana = ws.getIdManzanaPkLote(splitIdLote[cbLote.SelectedIndex]);
            string numeroManzana = ws.getNumeroManzana(idManzana);
            string idPredio = ws.getIdPredioPkLote(splitIdLote[cbLote.SelectedIndex]);
            string nombrePredio = ws.getNombrePredio(idPredio);
            string numeroLote = ws.getNumeroLote(splitIdLote[cbLote.SelectedIndex]);

            ///// AQUI SE LLENAR EL FORMULARIO  ////////
            txtDiaCorte.Text = fecha_corte;
            txtAbono.Text = ws.getAbono(txtId.Text);
            txtPagoActual.Text = pago_actual;
            txtPagoFinal.Text = pago_final;
            txtMensualidad.Text = mensualidadProximoPago;
            txtProximoPago.Text = Convert.ToDateTime(proximoPago).ToString("MMMM");
            txtPredio.Text = nombrePredio;
            txtManzana.Text = numeroManzana;

            /////// SE REALIZA EL CALCULO DE LOS MESES MORATORIOS  /////////
            string respuestaResgistraMora = f.calculaMesesMorosos(f.estaEnMora(Convert.ToDateTime(proximoPago)), 
                                                                  f.statusMora(status_mora), 
                                                                  Convert.ToDateTime(proximoPago), 
                                                                  idVenta, 
                                                                  mensualidadProximoPago);
            MessageBox.Show(respuestaResgistraMora);

            ////// LLENAR DATOS MORA /////////
            llenarDatosMora();
        } 

        private void cbMesesMora_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*int distancia = (DateTime.Today.Year * 12 + DateTime.Today.Month) -
                            (Convert.ToDateTime(proximoPago).Year * 12 + Convert.ToDateTime(proximoPago).Month);

            int tamaño = splitFechaMora.Length;
            int contador=0;
            arrayMeses = new int[distancia+1];

            for (int i = 0; i <= distancia; i++) {
                contador = 0;
                
                for (int j = 0; j < tamaño; j++)
                {
                    if (Convert.ToDateTime(splitFechaMora[j]).Month == Convert.ToDateTime(proximoPago).AddMonths(i).Month) {

                        contador++;
                    }
                    arrayMeses[i] = contador;
                }
            }*/
            txtIntereses.Text = obtenerInteresMensual(cbMesesMora.FindString(cbMesesMora.Text));

            //txtIntereses.Text = Convert.ToString((Convert.ToDouble(mensualidadDeVentas) * 0.06)*
           //                                      (Convert.ToDouble(arrayMeses[cbMesesMora.SelectedIndex])));
        }
     

        private void cmdPagoMensualidad_Click(object sender, EventArgs e)
        {
            // MEDIDAS DEL LOTE NORTE Y ESTE 
            string respuestaMedidaLote = ws.getMedidaLote(splitIdLote[cbLote.SelectedIndex]);
            string[] splitMedidaLote = respuestaMedidaLote.Split(new char[] { ',' });
            string norte = splitMedidaLote[0];
            string este = splitMedidaLote[2];
            // FN

            // COLONIA Y MUNICIPIO DEL PREDIO  
            string colonia = ws.getDatoPredio("colonia", "nombre_predio", txtPredio.Text);
            string municipio = ws.getDatoPredio("municipio", "nombre_predio", txtPredio.Text);
            // FIN

            






            /*int mayorQuinientos = esMayorAQuinientos();
            bool yaPagoMes = validarSiYaPagoMes();
            //*********
            
            // ADELANTO AL PAGO DEL MES 
            if (Convert.ToInt32(txtMensualidad.Text) > Convert.ToInt32(mensualidadDeVentas)) {

                double cuantosPagos = Convert.ToDouble(txtMensualidad.Text) / Convert.ToDouble(mensualidadDeVentas);
                pago_actual =  Convert.ToString(cuantosPagos + Convert.ToDouble(pago_actual));

                pagoMensualidad(colonia, municipio, norte, este);


                MessageBox.Show("es mayor");
            }
            // PAGO DE LA MENSUALIDAD 
            if (txtMensualidad.Text == mensualidadProximoPago && !yaPagoMes && mayorQuinientos == 2 || mayorQuinientos == 3)
            {
                pagoMensualidad(colonia, municipio, norte, este);
            }
            // SI EL MES TIENE UNA DEUDA MAYOR A 5OO PESOS
            else if (txtMensualidad.Text == mensualidadProximoPago && !yaPagoMes && mayorQuinientos == 1) 
            {
                MessageBox.Show("tu mora del mes "+Convert.ToDateTime(proximoPago).ToString("MMMM").ToUpper()
                                +" debe ser menor de $500 pesos",
                                 "NO SE PUEDE REALIZAR EL PAGO");
            }
            // YA PAGE EL MES PERO AUN TENGO DEUDA DEL MES ANTERIOR
            else if (txtMensualidad.Text == mensualidadProximoPago && yaPagoMes && mayorQuinientos == 2) {

                MessageBox.Show("page mes pero aun debo");
            }
            // ABONO A LA MENSUALIDAD
            if (Convert.ToInt32(txtMensualidad.Text) < Convert.ToInt32(mensualidadProximoPago))
            {
                abonoMensualidad(colonia, municipio, norte, este);
               
            }*/
        }

        private void cmdPagoInteres_Click(object sender, EventArgs e)
        {
            // LLENAR MENSAJE DE CONFIRMACION  
            string mensaje = "¿Realizar pago de intereses?";
            string caption = "Pago interes";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult resultado;
            // FIN

            if (vacio())
            {
                double minInteres = Convert.ToDouble(mensualidadDeVentas) * 0.06;

                //double totalInteres = Convert.ToDouble(txtTotalIntereses.Text);

                //verifico que el abono de la mora por lo menos cubra un interes
                if (Convert.ToInt32(txtInteresMensual.Text) < Convert.ToInt32(minInteres))
                {
                    MessageBox.Show("El abono minimo es " + minInteres, "NO SE PUEDE REALIZAR EL PAGO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    string respuestaIdMora = ws.getIdMora(idVenta);
                    splitIdMora = respuestaIdMora.Split(new char[] { ',' });
                    MessageBox.Show(respuestaIdMora);

                    // MEDIDAS DEL LOTE NORTE Y ESTE 
                    string respuestaMedidaLote = ws.getMedidaLote(splitIdLote[cbLote.SelectedIndex]);
                    string[] splitMedidaLote = respuestaMedidaLote.Split(new char[] { ',' });
                    string norte = splitMedidaLote[0];
                    string este = splitMedidaLote[2];
                    // FN

                    string colonia = ws.getDatoPredio("colonia", "nombre_predio", txtPredio.Text);
                    string municipio = ws.getDatoPredio("municipio", "nombre_predio", txtPredio.Text);

                    double cuantosPagos = Math.Truncate(Convert.ToDouble(txtInteresMensual.Text) / minInteres);

                    MessageBox.Show(Convert.ToString(cuantosPagos));

                    resultado = MessageBox.Show(mensaje, caption, botones);

                    if (resultado == System.Windows.Forms.DialogResult.OK)
                    {
                        // CUANDO SE REALIZA EL PAGO TOTAL DE LOS INTERESES
                        if (Convert.ToInt32(txtInteresMensual.Text) == Convert.ToInt32(totalInteres))
                        {
                           string respuestaPagoMora =  ws.updateTablaMora(respuestaIdMora, "1", "status");

                           if (respuestaIdMora == "1") 
                           {
                               MessageBox.Show("Pago de mora registrado con EXITO");
                           }
                        }// FIN

                        // CUANDO SE PAGO EL TOTAL DE INTERESES DEL MES EN MORA
                        else if ((Convert.ToInt32(txtInteresMensual.Text) == Convert.ToInt32(obtenerInteresMensual(0))))
                        {
                            pagoMora(cuantosPagos);
                        }
                        // CUANDO SE REALIZA UN ABONO SOBRE EL MES QUE ESTA EN MORA
                        else if (Convert.ToInt32(txtInteresMensual.Text) < Convert.ToInt32(obtenerInteresMensual(0)))
                        {
                           bool actualiza = pagoMora(cuantosPagos);

                           if (actualiza) 
                           {
                               actualizaMesEnMora(idMesActualizar);
                           }
                           
                           string interesMesActual = obtenerInteresMensual(cbMesesMora.FindString(Convert.ToDateTime(proximoPago).ToString("MMMM")));
 
                           //genero el recibo
                           recibo.crearPdfReciboMora("abono",
                                                  pago_actual,
                                                  txtPagoFinal.Text,
                                                  cbLote.Text,
                                                  txtManzana.Text,
                                                  cbComprador.Text,
                                                  txtMensualidad.Text,
                                                  Convert.ToDateTime(proximoPago).ToString("MMMM").ToUpper(),
                                                  txtPredio.Text,
                                                  colonia,
                                                  municipio,
                                                  norte,
                                                  este,
                                                  txtMensualidad.Text,
                                                  interesMesActual,
                                                  false);
                        }
                        cbMesesMora.Items.Clear();
                        totalInteres = 0;
                        llenarDatosMora();
                    }
                }
            }
            else
            {
                MessageBox.Show("Favor de Llenar el formulario");
            }
        }

        private bool validarSiYaPagoMes() {

            bool yaPago = false;
      
            foreach (string fecha in splitFechaMora) {

                if (Convert.ToDateTime(proximoPago).Month > Convert.ToDateTime(fecha).Month) {
                    yaPago = true;
                }
            }
            return yaPago;
        }

        private int esMayorAQuinientos() {

            int existeMes = cbMesesMora.FindString(Convert.ToDateTime(proximoPago).ToString("MMMM"));
            int statusDeuda = 0;

            if (existeMes != -1)
            {
                sumaMesMora = Convert.ToInt32(arrayMeses[existeMes]) * (Convert.ToInt32(mensualidadDeVentas) * 0.06);

                if (sumaMesMora >= 500)
                {
                    return statusDeuda = 1;
                }
                else if (sumaMesMora > 0 && sumaMesMora < 500)
                {
                    return statusDeuda = 2;
                }
                else if (sumaMesMora == 0)
                {
                    return statusDeuda = 3;
                }
            }
           return statusDeuda;   
        }

        private string obtenerInteresMensual(int indexMes) {

            double interesMensual = 0;
            int indexMontoMora = 0;

            for (int i = 0; i < indexMes; i++)
            {
                indexMontoMora += arrayMeses[i];
            }

            for (int i = 0; i < arrayMeses[indexMes]; i++) 
            {
                interesMensual = interesMensual + Convert.ToDouble(splitMontoMora[indexMontoMora + i]);
            }
            return Convert.ToString( interesMensual);
        }

        private void obtenerCantidadMeses() //me dice la cantidad de veces que aparece un mes en mora
        {
            int distancia = (DateTime.Today.Year * 12 + DateTime.Today.Month) -
                            (Convert.ToDateTime(proximoPago).Year * 12 + Convert.ToDateTime(proximoPago).Month);

            int tamaño = splitFechaMora.Length;
            int contador = 0;
            arrayMeses = new int[distancia + 1];

            for (int i = 0; i <= distancia; i++)
            {
                contador = 0;

                for (int j = 0; j < tamaño; j++)
                {
                    if (Convert.ToDateTime(splitFechaMora[j]).Month == Convert.ToDateTime(proximoPago).AddMonths(i).Month)
                    {
                        contador++;
                    }
                    arrayMeses[i] = contador;
                }
            }
        }


        private bool pagoMora(double cuantosPagos)
        {
            string implodeIdMora = "";
            idMesActualizar = "";
            string mes = Convert.ToDateTime(proximoPago).ToString("MMMM");
            int indexIdMora = 0;
            diferencia = 0;
            double pagos = 0;

            for (int i = 0; i < cuantosPagos;i++) 
            {
                pagos += Convert.ToDouble(splitMontoMora[i]);  
            }

            diferencia = Convert.ToDouble(txtInteresMensual.Text) - pagos;

            /*if (cbMesesMora.SelectedIndex != 0)
            {
                for (int i = 0; i < cbMesesMora.SelectedIndex; i++)
                {
                    indexIdMora += arrayMeses[i];
                }
            }*/
            
            for (int i = 0; i <= cuantosPagos; i++)
            {
                if (i < cuantosPagos)
                {
                    implodeIdMora += splitIdMora[indexIdMora + i];
                }

                if (i < cuantosPagos - 1)
                {
                    implodeIdMora += ",";
                }
                 
                if (cuantosPagos < arrayMeses[cbMesesMora.FindString(mes)] && i == cuantosPagos && diferencia != 0 )
                {
                    idMesActualizar = splitIdMora[indexIdMora + i];
                    return true;
                }
            }
            MessageBox.Show(implodeIdMora);
            MessageBox.Show("id mes actualizar " + idMesActualizar);
            string respuestUpdateMora = ws.updateTablaMora(implodeIdMora, "1", "status");

            MessageBox.Show(respuestUpdateMora);
            return false;
            /* string implodeIdMora="";
             int indexMesSeleccionado = cbMesesMora.SelectedIndex;
             int indexMinimo = 0;

             for (int i = 0; i <= indexMesSeleccionado; i++)
             {
                 indexIdMora += arrayMeses[cbMesesMora.SelectedIndex];
                 //MessageBox.Show(Convert.ToString(indexIdMora) + " " + Convert.ToString(arrayMeses[cbMesesMora.SelectedIndex]);
             }
             if (cbMesesMora.SelectedIndex == 0)
             {
                 indexMinimo = 0;
             }
             else {
                 indexMinimo = cbMesesMora.SelectedIndex - 1;
             }

             for (int i = indexMinimo; i < arrayMeses[cbMesesMora.SelectedIndex]; i++)
             {
                  implodeIdMora += splitIdMora[i];

                 if (i < arrayMeses[cbMesesMora.SelectedIndex]-1){  

                     implodeIdMora +=",";
                 }
             }
             MessageBox.Show(implodeIdMora);*/

        }

        public void actualizaMesEnMora(string idMesEnMora)
        {
            ws.updateTablaMora(idMesActualizar,Convert.ToString(diferencia),"monto_mora");
        }


        private void abonoMensualidad(string colonia, string municipio, string norte, string este) {
            
            //obtengo la diferencia del abono con la menusualidad y obtengo la nueva mensualidad para updateProximoPago
            string nuevaMensualidad = Convert.ToString(Convert.ToInt32(mensualidadProximoPago) - 
                                                       Convert.ToInt32(txtMensualidad.Text));
            //registro el pago como abono 
            ws.registraPago(idVenta, 
                            txtMensualidad.Text, 
                            Convert.ToString(DateTime.Today), 
                            proximoPago, 
                            "abono", 
                            pago_actual);

            //actualizo proximoPago con la nueva mensualidad
            ws.updateTablaProximoPago(idVenta, nuevaMensualidad);

            //registro el abono mensual del cliente
            ws.updateAbonoMensual(txtId.Text, txtMensualidad.Text);

            string interesMesActual = obtenerInteresMensual(cbMesesMora.FindString(Convert.ToDateTime(proximoPago).ToString("MMMM")));

            //genero el recibo
            recibo.crearPdfRecibo("abono", 
                                   pago_actual, 
                                   txtPagoFinal.Text, 
                                   cbLote.Text, 
                                   txtManzana.Text, 
                                   cbComprador.Text, 
                                   txtMensualidad.Text, 
                                   Convert.ToDateTime(proximoPago).ToString("MMMM").ToUpper(), 
                                   txtPredio.Text, 
                                   colonia, 
                                   municipio, 
                                   norte, 
                                   este,
                                   nuevaMensualidad,
                                   interesMesActual,
                                   false);
        }

        private void pagoMensualidad(string colonia, string municipio, string norte, string este) {

            bool deudaDeMora = false;
 
            //**la variable sumaMesMora es global y viene del metodo esMayorAQuinientos**
            if (sumaMesMora > 0 && sumaMesMora < 500) //verifico que la deuda del mes sea menor 
            {                                         //a 500 para imprimirla en el recibo 
                deudaDeMora = true;
            }

            // REGISTRO DEL PAGO  
            string registraPago = ws.registraPago(idVenta,                  //id de la venta
                                                  txtMensualidad.Text,      //mensualidad
                                                  DateTime.Today.ToString(),//fecha de pago
                                                  proximoPago,              //fecha de corte pagada
                                                  "Mensualidad",            //concepto del pago
                                                  pago_actual);             //numero de pago
            MessageBox.Show(registraPago);
            // FIN
            
            // CALCULO DE LA PROXIMA FECHA DE PAGO  
            DateTime proximaFechaDePago = f.setProximoPago(Convert.ToDateTime(fecha_compra),                 // fecha de compra          
                                                           Convert.ToString((Convert.ToInt32(pago_actual))));// pago actual
            MessageBox.Show(proximaFechaDePago.ToString());
            // FIN 

            //  REGISTRO DE LOS DATOS DE LA TABLA FECHA DE PROXIMO PAGO 
            string respuetaUpdateProximoPago = ws.updateProximoPago(idVenta,                      //id de la venta
                                                                    mensualidadDeVentas,          //mesualidad del mes
                                                                    proximaFechaDePago.ToString(),//proxime fecha de pago
                                                                    "0",                          //tipo de pago
                                                                    Convert.ToString(Convert.ToInt32(pago_actual)+1),//pago actual
                                                                    "0");                         //status de mora
            // FIN   
           
            // GENERA EL RECIBO  
            recibo.crearPdfRecibo("contado",                                                   //forma de pago
                                   pago_actual,                                                //pago actual            
                                   txtPagoFinal.Text,                                          //ultimo pago
                                   cbLote.Text,                                                //numero de lote
                                   txtManzana.Text,                                            //numero de manzana                                 
                                   cbComprador.Text,                                           //nombre comprador
                                   txtMensualidad.Text,                                        //mensualidad pagada
                                   Convert.ToDateTime(proximoPago).ToString("MMMM").ToUpper(), //nombre de mes
                                   txtPredio.Text,                                             //nombre del predio
                                   colonia,                                                    //nombre de la colonia
                                   municipio,                                                  //municipio
                                   norte,                                                      //medida norte
                                   este,                                                       //medida este
                                   "",                                                         //resto mensualidad
                                   txtIntereses.Text,                                          //deuda de intereses 
                                   deudaDeMora);                                               //si hay mora mensual
            // FIN
        }


        public void llenarComboComprador() { 

            string idComprador = ws.getIdCompradordeVenta();
            string respuestaNombreComprador = ws.getNombreComprador(idComprador);
            string[] splitComprador = respuestaNombreComprador.Split(new char[] { ',' });

            foreach (string comprador in splitComprador) {

                cbComprador.Items.Add(comprador);
            }
        }

        public void llenarDatosMora() {

            bool entra =true;
            string respuestaFechaMora = ws.getFechaMora(idVenta);
            string respuestaMontoMora = ws.getMontoMora(idVenta);

            splitFechaMora = respuestaFechaMora.Split(new char[] { ',' });
            splitMontoMora = respuestaMontoMora.Split(new char[] { ',' });
         
            if (splitFechaMora[0] == ""){
                entra = false;
            }

            if (entra)
            {
                foreach (string MontoMora in splitMontoMora)
                {
                    totalInteres = totalInteres + Convert.ToDouble(MontoMora);
                }
            }
                txtTotalInteres.Text = Convert.ToString(totalInteres);

            int contador = 0;

            contador = (DateTime.Today.Year * 12 + DateTime.Today.Month) - 
                       (Convert.ToDateTime(proximoPago).Year * 12 + Convert.ToDateTime(proximoPago).Month);

            if (Convert.ToDateTime(proximoPago).AddDays(6).Day >= DateTime.Today.Day)
            {
                contador -= 1;
            }
            for (int i = 0; i <= contador; i++)
            {
                cbMesesMora.Items.Add(Convert.ToDateTime(proximoPago).AddMonths(i).ToString("MMMM"));
            }

            obtenerCantidadMeses(); // lleno la variable arrayMeses que contiene la cantidad de veces que un mes entro en mora

            if (cbMesesMora.Items.Count >= 1)
            {
                cbMesesMora.SelectedIndex = 0;
            }
            else {
                cbMesesMora.SelectedIndex = -1;
            }
            txtInteresMensual.Text = obtenerInteresMensual(cbMesesMora.FindString(Convert.ToDateTime(proximoPago).ToString("MMMM")));

            txtTotal.Text = Convert.ToString(Convert.ToInt32(txtMensualidad.Text) + Convert.ToInt32(txtInteresMensual.Text)); 
        }

        public void llenarComboLote() 
        {
            cbLote.Items.Clear();
           
            string respuestaIdLoteDeVenta = ws.getIdLoteDeVenta(txtId.Text);//obtengo la lista de id de lotes
            splitIdLote = respuestaIdLoteDeVenta.Split(new char[] { ',' });//genero un arreglo con esa lista de id de lotes
            int tamañoSplit = splitIdLote.Length;                          //obtengo el tamaño del arreglo
            string[] numeroLotes = new string[splitIdLote.Length];         //creo un arreglo de numeroLotes el tamaño del 
                                                                           //arreglo es igual
                                                                           //al tamaño de id lotes.
            for (int i = 0; i < splitIdLote.Length; i++)
            {
                numeroLotes[i] = ws.getNumeroLote(splitIdLote[i]);//lleno el arreglo con los numeros de lotes
            }
            
            foreach (string idLotes in numeroLotes)
            {
                cbLote.Items.Add(idLotes);//lleno el combobox de Lotes con el numero de lotes
            }
            
            if (tamañoSplit > 1)
                MessageBox.Show("Usuario con mas de una compra");

            cbLote.SelectedIndex = 0;
        }


        private bool vacio() { 
        
          if(txtId.Text.Length == 0 || cbComprador.Text.Length == 0)
          {
              return false;
          }
          else
          {
            return true;
          }
        }

        public string implode(string[] array) 
        {
            string implode= "";
            int tamaño = array.Length;

            for (int i = 0; i <= tamaño; i++)
            {
                if (i < tamaño)
                {
                    implode += array[i];
                }

                if (i < tamaño - 1)
                {
                    implode += ",";
                }
            }
            return implode;
        }
    }
}