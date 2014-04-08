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
        public FrmPago()
        {
            InitializeComponent();


        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                WSpvt.PVT ws = new WSpvt.PVT();

                ///////// CONSULATA DE LA TABLA VENTAS /////////////////
                string superStringVenta = ws.getVenta(txtId.Text); //cadena de string seprado por comas
                string[] splitVenta = superStringVenta.Split(new char[] { ',' });
                string idVenta = splitVenta[0];
                string idLote = splitVenta[1];
                string mensualidad = splitVenta[2];
                string fecha_compra = splitVenta[3];
                string fecha_corte = splitVenta[4];
                ////////////////////////////////////////////////////////

                /////// CONSULTA DE LA TABLA PROXIMO PAGO  //////////////
                string superStringProximoPago = ws.getProximoPago(idVenta); //cadena de string separado por comas
                string[] splitProximoPago = superStringProximoPago.Split(new char[] { ',' });
                string proximoPago = splitProximoPago[0];
                string pago_actual = splitProximoPago[1];
                string pago_final = splitProximoPago[2];
                string status_mora = splitProximoPago[3];
                /////////////////////////////////////////////////////////

                /////// CONSULTA PREDIO MANZANA LOTE ////////////////////
                string idManzana = ws.getIdManzanaPkLote(idLote);
                string numeroManzana = ws.getNumeroManzana(idManzana);
                string idPredio = ws.getIdPredioPkLote(idLote);
                string nombrePredio = ws.getNombrePredio(idPredio);
                string numeroLote = ws.getNumeroLote(idLote);

                ///// DATOS PARA LLENAR EL FORMULARIO  ////////
                txtNombre.Text = ws.getComprador(txtId.Text);
                txtDiaCorte.Text = fecha_corte;
                txtAbono.Text = ws.getAbono(txtId.Text);
                txtPagoActual.Text = pago_actual;
                txtPagoFinal.Text = pago_final;
                txtMensualidad.Text = mensualidad;

                cbPredio.Items.Add(nombrePredio);
                cbManzana.Items.Add(numeroManzana);
                cbLote.Items.Add(numeroLote);
                cbPredio.SelectedIndex = 0;
                cbManzana.SelectedIndex = 0;
                cbLote.SelectedIndex = 0;

                Fecha mora = new Fecha();

                Boolean respuesta = mora.estaEnMora(DateTime.Today, Convert.ToDateTime(proximoPago));

                MessageBox.Show(Convert.ToString(respuesta));

               /* DateTime fechaHoy = new DateTime(2014, 04, 2);
                DateTime fechaAnterior = new DateTime(2014, 04, 30);

                DateTime prueba = fechaAnterior.AddDays(5);

                int meses = 0;

                meses = Convert.ToDateTime(proximoPago).Month - fechaHoy.Month;

                MessageBox.Show(prueba.ToString());*/

            }
        }
    }
}
