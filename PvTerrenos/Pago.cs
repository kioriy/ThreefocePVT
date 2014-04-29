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
        string mensualidad = "";
        string mensualidad2 = "";
        string fecha_compra = "";
        string[] splitIdMora;
        string[] splitIdLote;
        string[] splitFechaMora;
        int[] arrayMeses;

        public FrmPago()
        {
            InitializeComponent();
            llenarComboComprador();
            //string respuestaNombreComprador =  ws.cargaComprador();
            //string[] splitNombreComprador = respuestaNombreComprador.Split(new char[] { ',' });

            //foreach (string nombreComprador in splitNombreComprador) {

              //  cbComprador.Items.Add(nombreComprador);
           // }
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
            llenarComboLote();
        }

        private void cbLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMesesMora.Items.Clear();

            ///////// CONSULTA DE LA TABLA VENTAS /////////////////
            string superStringVenta = ws.getVentadeIdLote(splitIdLote[cbLote.SelectedIndex]); //cadena de string seprado por comas
            string[] splitVenta = superStringVenta.Split(new char[] { ',' });
            idVenta = splitVenta[0];
            mensualidad = splitVenta[1];
            fecha_compra = splitVenta[2];
            string fecha_corte = splitVenta[3];
            ////////////////////////////////////////////////////////

            /////// CONSULTA DE LA TABLA PROXIMO PAGO  //////////////
            string superStringProximoPago = ws.getProximoPago(idVenta); //cadena de string separado por comas
            string[] splitProximoPago = superStringProximoPago.Split(new char[] { ',' });
            mensualidad2 = splitProximoPago[0];
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
            txtMensualidad.Text = mensualidad2;
            txtProximoPago.Text = Convert.ToDateTime(proximoPago).ToString("d");
            cbPredio.Text = nombrePredio;
            cbManzana.Text = numeroManzana;

            /////// SE REALIZA EL CALCULO DE LOS MESES MORATORIOS  /////////
            string respuestaResgistraMora = f.calculaMesesMorosos(f.estaEnMora(Convert.ToDateTime(proximoPago)), f.statusMora(status_mora), Convert.ToDateTime(proximoPago), idVenta, mensualidad);
            MessageBox.Show(respuestaResgistraMora);

            ////// LLENAR DATOS MORA /////////
            llenarDatosMora();
        } 

        private void cbMesesMora_SelectedIndexChanged(object sender, EventArgs e)
        {
            int distancia = (DateTime.Today.Year * 12 + DateTime.Today.Month) - (Convert.ToDateTime(proximoPago).Year * 12 + Convert.ToDateTime(proximoPago).Month);
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
            }
            int index = Convert.ToInt32(cbMesesMora.SelectedIndex);
            txtIntereses.Text = Convert.ToString((Convert.ToDouble(mensualidad) * 0.06)*(Convert.ToDouble(arrayMeses[index])));
        }
     
        private void cmdPagoMensualidad_Click(object sender, EventArgs e)
        {
            if (txtMensualidad.Text == mensualidad2)
            {
                string registraPago = ws.registraPago(idVenta, mensualidad, Convert.ToString(DateTime.Today), proximoPago, "Mensualidad", pago_actual);
                MessageBox.Show(registraPago);
                ws.updateAbonoMensual(txtId.Text,"0");

                recibo.crearPdfRecibo("abono", pago_actual, txtPagoFinal.Text, cbLote.Text, cbManzana.Text, cbComprador.Text, txtMensualidad.Text, proximoPago, cbPredio.Text, "COYULA", "TONALA", "6", "9");
            }
            if (Convert.ToInt32(txtMensualidad.Text) < Convert.ToInt32(mensualidad2))
            {
                string nuevaMensualidad = Convert.ToString(Convert.ToInt32(mensualidad2) - Convert.ToInt32(txtMensualidad.Text));
                MessageBox.Show(nuevaMensualidad);
                string registraPago = ws.registraPago(idVenta, txtMensualidad.Text, Convert.ToString(DateTime.Today), proximoPago, "abono", pago_actual);
                string respuestaUpdateProximoPago = ws.updateProximoPago(idVenta, nuevaMensualidad);
                MessageBox.Show(respuestaUpdateProximoPago+" proximo pago");
                string respuestaAbonoMensualidad = ws.updateAbonoMensual(txtId.Text, txtMensualidad.Text);
                MessageBox.Show(respuestaAbonoMensualidad+" abono mensualidad");

                recibo.crearPdfRecibo("abono", pago_actual, txtPagoFinal.Text, cbLote.Text, cbManzana.Text, cbComprador.Text, txtMensualidad.Text, proximoPago, cbPredio.Text, "COYULA", "TONALA", "6", "9");
            }
        }

        private void cmdPagoInteres_Click(object sender, EventArgs e)
        {
            ////// LLENAR MENSAJE DE CONFIRMACION  ////////////////
            string mensaje = "¿Realizar pago de intereses?";
            string caption = "Pago interes";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult resultado;
            //////////////////////////////////////////////////////

            if (vacio())
            {
                resultado = MessageBox.Show(mensaje, caption, botones);

                if (resultado == System.Windows.Forms.DialogResult.OK)
                {
                    string respuestaIdMora = ws.getIdMora(idVenta);
                    splitIdMora = respuestaIdMora.Split(new char[] { ',' });
                    MessageBox.Show(respuestaIdMora);

                    double minInteres = Convert.ToDouble(mensualidad) * 0.06;
                    double cuantosPagos = Math.Truncate(Convert.ToDouble(txtTotalIntereses.Text) / minInteres);

                    MessageBox.Show(Convert.ToString(cuantosPagos));

                    double totalInteres = Convert.ToDouble(txtTotalIntereses.Text);

                    pagoAbonoMora(cuantosPagos);
                }
            }
            else
            {
                MessageBox.Show("Favor de Llenar el formulario");
            }
        }

        private void pagoAbonoMora(double cuantosPagos)
        {

            string implodeIdMora = "";
            string idMesActualizar = "";
            int indexIdMora = 0;

            if (cbMesesMora.SelectedIndex != 0)
            {

                for (int i = 0; i < cbMesesMora.SelectedIndex; i++)
                {
                    indexIdMora += arrayMeses[i];
                }
            }

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

                if (cuantosPagos < arrayMeses[cbMesesMora.SelectedIndex] && i == cuantosPagos)
                {
                    idMesActualizar = splitIdMora[indexIdMora + i];
                }
            }
            MessageBox.Show(implodeIdMora);
            MessageBox.Show("id mes actualizar " + idMesActualizar);
            string respuestUpdateMora = ws.updateTablaMora(implodeIdMora, "1", "status");

            MessageBox.Show(respuestUpdateMora);
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

        public string actualizaMesEnMora(int idMesEnMora)
        {


            return "hola";
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
            string[] splitMontoMora = respuestaMontoMora.Split(new char[] { ',' });

            double totalInteres = 0;
         
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
                txtTotalIntereses.Text = Convert.ToString(totalInteres);

            int contador = 0;

            contador = (DateTime.Today.Year * 12 + DateTime.Today.Month) - (Convert.ToDateTime(proximoPago).Year * 12 + Convert.ToDateTime(proximoPago).Month);

            if (Convert.ToDateTime(proximoPago).Day >= DateTime.Today.Day)
            {
                contador -= 1;
            }
            for (int i = 0; i <= contador; i++)
            {
                cbMesesMora.Items.Add(Convert.ToDateTime(proximoPago).AddMonths(i).ToString("MMMM"));
            }
            
            if (cbMesesMora.Items.Count >= 1)
            {
                cbMesesMora.SelectedIndex = 0;
            }
            else {
                cbMesesMora.SelectedIndex = -1;
            }
        }

        public void llenarComboLote() 
        {
            cbLote.Items.Clear();
           
            string respuestaIdLoteDeVenta = ws.getIdLoteDeVenta(txtId.Text);//obtengo la lista de id de lotes
            splitIdLote = respuestaIdLoteDeVenta.Split(new char[] { ',' });//genero un arreglo con esa lista de id de lotes
            int tamañoSplit = splitIdLote.Length;                          //obtengo el tamaño del arreglo
            string[] numeroLotes = new string[splitIdLote.Length];         //creo un arreglo de numeroLotes el tamaño del arreglo es igual
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

        private void lTotalInteres_Click(object sender, EventArgs e)
        {
            int tamaño = splitFechaMora.Length;
            txtTotalIntereses.Text = Convert.ToString(Convert.ToDouble(tamaño) * (Convert.ToDouble(txtMensualidad.Text) * 0.06));
        }

        private void lMensualidad_Click(object sender, EventArgs e)
        {
            txtMensualidad.Text = mensualidad;
        }
    }
}