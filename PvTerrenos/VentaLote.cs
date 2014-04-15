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
    public partial class FrmVentaLote : Form
    {
        DateTime? proximoPago = DateTime.Today;

        public FrmVentaLote()
        {
            InitializeComponent();
            cbFormaPago.Items.Add("Abonos");
            cbFormaPago.Items.Add("Contado");

            llenarCombos();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAltaCliente abrirCliente = new FrmAltaCliente();
            abrirCliente.Show();
        }

        private void predioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAltaPredio abrirPredio = new FrmAltaPredio();
            abrirPredio.Show();
        }

        private void predioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPago abrirPago = new FrmPago();
            abrirPago.Show();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                WSpvt.PVT ws = new WSpvt.PVT();
                string id = txtId.Text;
                string respuestaGetUsuario = ws.getComprador(id);
                cbNombre.Text = respuestaGetUsuario;
            }
        }

        public void limpiar(Form VentaLote) {
            txtId.Text = "";
            cbFormaPago.Text = "";
            txtCostoTerreno.Text = "";
            txtAbono.Text = "";
            txtMensualidad.Text ="";
            txtFechaCorte.Text = "";
            txtPagoActual.Text= "";
            txtPagoFinal.Text = "";
            cbPredio.Text = "";
            cbLotes.Text = "";
            cbManzana.Text = "";
            cbNombre.SelectedIndex = -1;
        }

        public bool vacio;

        private bool validar(Form VentaLote ) {

            String id = txtId.Text;
            String pago = cbFormaPago.Text;
            String terreno = txtCostoTerreno.Text;
            String abono = txtAbono.Text;
            String mensaulidad = txtMensualidad.Text;
            String fechaCorte = txtFechaCorte.Text;
            String pagoActual = txtPagoActual.Text;
            String pagoFinal = txtPagoFinal.Text;
            String predio = cbPredio.Text;
            String lote = cbLotes.Text;
            String manzana = cbManzana.Text;

            if (id.Length == 0 || pago.Length == 0 || terreno.Length == 0 || abono.Length == 0 || mensaulidad.Length == 0 || fechaCorte.Length == 0 || pagoFinal.Length == 0 || pagoActual.Length == 0 || predio.Length == 0 || lote.Length == 0 || manzana.Length == 0)
            {
                MessageBox.Show("Para poder realizar una venta, favor de llenar todos los campos");

                vacio = true;
            }

            else
            {
                vacio = false;
            
            }

            return vacio;
            
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {

            frmMedidaLote MedidaLote = new frmMedidaLote();
            ///llamamos a la funcion que nos valida que el formulario no tenga campos nulos
            validar(this);

            //mostramos una ventana que le pregunte al usuario si en verdad quiere reistrar la venta
            string mensaje = "¿Estas seguro de que quieres registrar esta venta?";
            string caption = "Registro de venta";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult resultado;

            // para agregar las medidas del lote
           // 
           

            if (vacio == false)
            
            {
                resultado = MessageBox.Show(mensaje, caption, botones);

                if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                MedidaLote.Show();
                WSpvt.PVT ws = new WSpvt.PVT();

                string id_comprador = txtId.Text;
                string idLote = ws.getIdLote(ws.getIdManzana(cbManzana.SelectedItem.ToString(), ws.getIdPredio(cbPredio.SelectedItem.ToString())), cbLotes.SelectedItem.ToString());
                string tipo_pago = cbFormaPago.SelectedItem.ToString();
                string monto = txtCostoTerreno.Text;
                string abono = txtAbono.Text;
                string mensualidad = txtMensualidad.Text;
                string fechaCompra = dtpFecha.Value.ToString();
                string fechaCorte = dtpFecha.Value.Day.ToString();

                /// para pasar el id de lote al formulario de medidaLte
                MedidaLote.idLote = idLote;

                string respuestaAltaVenta = ws.registraVenta(id_comprador, idLote, tipo_pago, monto, mensualidad, fechaCompra, fechaCorte);
                MessageBox.Show(respuestaAltaVenta);

                string respuestaStatus = ws.updateStatusLote(idLote);

                string idVenta = ws.getIdVentaPkLote(idLote);

                int pagoActualMasUno = Convert.ToInt32(txtPagoActual.Text) + 1;

                string respuestaProximoPago = ws.registraProximoPago(idVenta, mensualidad, proximoPago.Value.ToString(),"0", Convert.ToString(pagoActualMasUno), txtPagoFinal.Text);
                MessageBox.Show(respuestaProximoPago);
                string registraAbono = ws.registraAbono(id_comprador, abono);

               limpiar(this);
            }
         }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

            
            if (txtPagoActual.Text != "" && txtPagoFinal.Text !="") {

                Fecha obtenerProximoPago = new Fecha();

                proximoPago =  obtenerProximoPago.setProximoPago(dtpFecha.Value, txtPagoActual.Text);

                //MessageBox.Show(resultado.ToString());

            }else{
                MessageBox.Show("es necesario ingresar pagos:   /    ");
            }
        }

        private void llenarCombos() {

            WSpvt.PVT ws = new WSpvt.PVT();

            string respuestaCargaPredio = ws.cargaPredio();

            string[] splitPredios = respuestaCargaPredio.Split(new char[] {','});

            foreach (string cargaCombo in splitPredios) {

                cbPredio.Items.Add(cargaCombo);
            }
            string repuestaNombreComprador = ws.cargaComprador();
            string [] splitNombreComprador = respuestaCargaPredio.Split(new char[] {','});

            foreach (string nombreComprador in splitNombreComprador) {

                cbNombre.Items.Add(nombreComprador);
            }
        }

        private void cbPredio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbManzana.Items.Clear();
            WSpvt.PVT ws = new WSpvt.PVT();

            string idPredio = ws.getIdPredio((string)cbPredio.SelectedItem);
            string respuestaCargaManzana = ws.cargaManzana(idPredio);

            string[] splitCargaManzana = respuestaCargaManzana.Split(new char[] { ',' });

            foreach (string cargaCombo in splitCargaManzana) {

                cbManzana.Items.Add(cargaCombo);
            }
        }

        private void cbManzana_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbLotes.Items.Clear();
            WSpvt.PVT ws = new WSpvt.PVT();

            string idPredio = ws.getIdPredio((string)cbPredio.SelectedItem);
            string idManzana = ws.getIdManzana((string)cbManzana.SelectedItem, idPredio);
            string respuestaCargaLote = ws.cargaLotes(idManzana);

            string[] splitCargaLotes = respuestaCargaLote.Split(new char[] { ',' });

            foreach (string cargaLotes in splitCargaLotes) {

                cbLotes.Items.Add(cargaLotes);
            }
        }
    }
}
