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

        string idVenta = "";
        string pago_actual = "";
        string proximoPago = "";
        string[] splitFechaMora;
        string[] splitIdLote;
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
                llenarComboLote();
                cbComprador.Text = ws.getComprador(txtId.Text);
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
            string mensualidad = splitVenta[1];
            string fecha_compra = splitVenta[2];
            string fecha_corte = splitVenta[3];
            ////////////////////////////////////////////////////////

            /////// CONSULTA DE LA TABLA PROXIMO PAGO  //////////////
            string superStringProximoPago = ws.getProximoPago(idVenta); //cadena de string separado por comas
            string[] splitProximoPago = superStringProximoPago.Split(new char[] { ',' });
            proximoPago = splitProximoPago[0];
            pago_actual = splitProximoPago[1];
            string pago_final = splitProximoPago[2];
            string status_mora = splitProximoPago[3];
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
            txtMensualidad.Text = mensualidad;
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
            int [] arrayMeses = new int[distancia+1];

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
            txtIntereses.Text = Convert.ToString((Convert.ToDouble(txtMensualidad.Text) * 0.06)*(Convert.ToDouble(arrayMeses[index])));
        }
     
        private void cmdPagoMensualidad_Click(object sender, EventArgs e)
        {
            String registraPago = ws.registraPago(idVenta, "monto", Convert.ToString(DateTime.Today), proximoPago, "abono", pago_actual);
            MessageBox.Show(registraPago);
        }

        public void llenarComboComprador() {

            string idComprador = ws.getIdCompradordeVenta();
            string[] splitIdComprador = idComprador.Split(new char[] { ',' });
            int tamaño = splitIdComprador.Length;
            string[] comprador = new string [tamaño];

            for (int i = 0; i < tamaño; i++) {

                comprador[i] = ws.getNombreComprador(splitIdComprador[i]);
            }

            foreach (string compradorCombo in comprador) {

                cbComprador.Items.Add(compradorCombo);
            }
        }

        public void llenarDatosMora() {

            string respuestaFechaMora = ws.getFechaMora(idVenta);
            splitFechaMora = respuestaFechaMora.Split(new char[] { ',' });
            int tamaño = splitFechaMora.Length;

            txtTotalIntereses.Text = Convert.ToString(Convert.ToDouble(tamaño) * (Convert.ToDouble(txtMensualidad.Text) * 0.06));

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
    }
}