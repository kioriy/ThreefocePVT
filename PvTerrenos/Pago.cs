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

            string respuestaNombreComprador =  ws.cargaComprador();
            string[] splitNombreComprador = respuestaNombreComprador.Split(new char[] { ',' });

            foreach (string nombreComprador in splitNombreComprador) {

                cbComprador.Items.Add(nombreComprador);
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string respuestaIdLoteDeVenta = ws.getIdLoteDeVenta(txtId.Text);
                MessageBox.Show(respuestaIdLoteDeVenta);
                splitIdLote = respuestaIdLoteDeVenta.Split(new char[] { ',' });
                int tamañoSplit = splitIdLote.Length;

                if (tamañoSplit <= 1)
                {
                    ///////// CONSULTA DE LA TABLA VENTAS /////////////////
                    string superStringVenta = ws.getVenta(txtId.Text); //cadena de string seprado por comas
                    string[] splitVenta = superStringVenta.Split(new char[] { ',' });
                    idVenta = splitVenta[0];
                    string idLote = splitVenta[1];
                    string mensualidad = splitVenta[2];
                    string fecha_compra = splitVenta[3];
                    string fecha_corte = splitVenta[4];
                    ////////////////////////////////////////////////////////

                    /////// CONSULTA DE LA TABLA PROXIMO PAGO  //////////////
                    string superStringProximoPago = ws.getProximoPago(idVenta); //cadena de string separado por comas
                    string[] splitProximoPago = superStringProximoPago.Split(new char[] { ',' });
                    proximoPago = splitProximoPago[0];
                    pago_actual = splitProximoPago[1];
                    string pago_final = splitProximoPago[2];
                    string status_mora = splitProximoPago[3];
                    /////////////////////////////////////////////////////////

                    /////// CONSULTA PREDIO MANZANA LOTE ////////////////////
                    string idManzana = ws.getIdManzanaPkLote(idLote);
                    string numeroManzana = ws.getNumeroManzana(idManzana);
                    string idPredio = ws.getIdPredioPkLote(idLote);
                    string nombrePredio = ws.getNombrePredio(idPredio);
                    string numeroLote = ws.getNumeroLote(idLote);

                    ///// AQUI SE LLENAR EL FORMULARIO  ////////
                    cbComprador.Text = ws.getComprador(txtId.Text);
                    txtDiaCorte.Text = fecha_corte;
                    txtAbono.Text = ws.getAbono(txtId.Text);
                    txtPagoActual.Text = pago_actual;
                    txtPagoFinal.Text = pago_final;
                    txtMensualidad.Text = mensualidad;
                    txtProximoPago.Text = Convert.ToDateTime(proximoPago).ToString("d");

                    ///// LLENADO DE COMBOBOX //////////
                    cbPredio.Items.Add(nombrePredio);     
                    cbManzana.Items.Add(numeroManzana);
                    cbLote.Items.Add(numeroLote);
                    cbPredio.SelectedIndex = 0;
                    cbManzana.SelectedIndex = 0;
                    cbLote.SelectedIndex = 0;                           

                    /////// SE REALIZA EL CALCULO DE LOS MESES MORATORIOS  /////////
                    string respuestaResgistraMora = f.calculaMesesMorosos(f.estaEnMora(Convert.ToDateTime(proximoPago)), f.statusMora(status_mora), Convert.ToDateTime(proximoPago), idVenta, mensualidad);
                    MessageBox.Show(respuestaResgistraMora);

                    ////// LLENAR DATOS MORA  ////////////////////////////
                    string respuestaFechaMora = ws.getFechaMora(idVenta);
                    splitFechaMora = respuestaFechaMora.Split(new char[] { ',' });
                    int tamaño = splitFechaMora.Length;

                    txtTotalIntereses.Text = Convert.ToString(Convert.ToDouble(tamaño) * (Convert.ToDouble(txtMensualidad.Text) * 0.06));

                    int contador = 0;
                    
                    contador = (DateTime.Today.Year * 12 + DateTime.Today.Month) - (Convert.ToDateTime(proximoPago).Year * 12 + Convert.ToDateTime(proximoPago).Month);

                    if (Convert.ToDateTime(proximoPago).Day >= DateTime.Today.Day) {

                        contador -= 1;
                    }
                    for (int i = 0; i <= contador; i++) {

                        cbMesesMora.Items.Add(Convert.ToDateTime(proximoPago).AddMonths(i).ToString("MMMM"));
                    }
                }
                else {
                    string[] numeroLotes = new string[splitIdLote.Length];

                    for (int i = 0; i < splitIdLote.Length; i++){

                       numeroLotes[i] = ws.getNumeroLote(splitIdLote[i]);
                    }
                    cbComprador.Text = ws.getComprador(txtId.Text);

                    foreach (string idLotes in numeroLotes) {

                        cbLote.Items.Add(idLotes);
                    }
                    MessageBox.Show("MAS DE DOS");
                }
            }
        }

        private void cbMesesMora_SelectedIndexChanged(object sender, EventArgs e)
        {
//            string respuestaFechaMora = ws.getFechaMora(idVenta);
//            string[] splitFechaMora = respuestaFechaMora.Split(new char[] { ',' });

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

        private void cbLote_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }
    }
}
