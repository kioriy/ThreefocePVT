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
        WSpvt.PVT ws = new WSpvt.PVT();
        string idPredio;
        string idLote;
        string[] splitIdManzana;

        public FrmVentaLote()
        {
            InitializeComponent();
            cbFormaPago.Items.Add("Abonos");
            cbFormaPago.Items.Add("Contado");

            llenarCombos();
            PdfCreate pdf = new PdfCreate();

            //pdf.crearPdfRecibo("4", "100", "22", "10", "HUGO RAFAEL HERNANDEZ LLAMAS", "2000","ABRIL","SAN ANDRES");

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
                string id = txtId.Text;
                string respuestaGetUsuario = ws.getComprador(id);
                cbNombre.Text = respuestaGetUsuario;
            }
        }

        void cargaVentaDvg(string nombre, string id, string costo, string mensualidad, string predio, string manzana, string lote) 
        {
            this.dataGridView1.Rows.Insert(0, nombre, id, costo, mensualidad, predio, manzana, lote);

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {

            
            ///llamamos a la funcion que nos valida que el formulario no tenga campos nulos

            //mostramos una ventana que le pregunte al usuario si en verdad quiere reistrar la venta
            string mensaje = "¿Estas seguro de que quieres registrar esta venta?";
            string caption = "Registro de venta";
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult resultado;

            if (validar())
            
            {
                resultado = MessageBox.Show(mensaje, caption, botones);

                if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                string idComprador = ws.getIdComprador(cbNombre.SelectedItem.ToString());
                
                string tipo_pago = cbFormaPago.SelectedItem.ToString();
                string monto = txtCostoTerreno.Text;
                string abono = txtAbono.Text;
                string mensualidad = txtMensualidad.Text;
                string fechaCompra = dtpFecha.Value.ToString();
                string diaCorte = dtpFecha.Value.Day.ToString();

                string respuestaAltaVenta = ws.registraVenta(idComprador, idLote, tipo_pago, monto, mensualidad, fechaCompra, diaCorte);
                MessageBox.Show(respuestaAltaVenta+"\n\n Su dias de corte son "+diaCorte+" de cada mes");

                string respuestaStatus = ws.updateStatusLote(idLote);

                string idVenta = ws.getIdVentaPkLote(idLote);

                int pagoActualMasUno = Convert.ToInt32(txtPagoActual.Text) + 1;

                string respuestaProximoPago = ws.registraProximoPago(idVenta, mensualidad, proximoPago.Value.ToString(),"0", Convert.ToString(pagoActualMasUno), txtPagoFinal.Text);
                MessageBox.Show(respuestaProximoPago+"\n\nsu proxima fecha de pago es "+proximoPago.Value.ToString());
                
                string registraAbono = ws.registraAbono(idComprador, abono);

                cargaVentaDvg(cbNombre.SelectedItem.ToString(), idComprador, monto, mensualidad, cbPredio.Text, cbManzana.Text, cbLotes.Text);
                limpiar();
               
               
                
            }
          }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (txtPagoActual.Text != "" && txtPagoFinal.Text != "")
            {

                Fecha obtenerProximoPago = new Fecha();

                proximoPago = obtenerProximoPago.setProximoPago(dtpFecha.Value, txtPagoActual.Text);

                //MessageBox.Show(resultado.ToString());

            }
            else
            {
                MessageBox.Show("es necesario ingresar pagos:   /    ");
            }
        }

        public void llenarCombos() {
            
            string respuestaCargaPredio = ws.cargaColumnaTablaPredio("nombre_predio");
            
            string[] splitPredios = respuestaCargaPredio.Split(new char[] {','});

            foreach (string cargaCombo in splitPredios) {

                cbPredio.Items.Add(cargaCombo);
            }
            string repuestaNombreComprador = ws.cargaComprador();
            string[] splitNombreComprador = repuestaNombreComprador.Split(new char[] { ',' });

            foreach (string nombreComprador in splitNombreComprador) {
                cbNombre.Items.Add(nombreComprador);
            }
        }

        private void cbPredio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbManzana.Items.Clear();

            idPredio = ws.getIdPredio(cbPredio.SelectedItem.ToString());
            string respuestaCargaManzana = ws.cargaColumnaTablaManzana(idPredio,"n_manzana");
            string respuestaIdManzana = ws.cargaColumnaTablaManzana(idPredio, "id_manzana");
            
            splitIdManzana = respuestaIdManzana.Split(new char[] { ',' });
            
            string[] splitCargaManzana = respuestaCargaManzana.Split(new char[] { ',' });

            foreach (string cargaCombo in splitCargaManzana) {

                cbManzana.Items.Add(cargaCombo);
            }
        }

        private void cbManzana_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbLotes.Items.Clear();
            WSpvt.PVT ws = new WSpvt.PVT();

           // string idPredio = ws.getIdPredio((string)cbPredio.SelectedItem);
           //string idManzana = ws.getIdManzana((string)cbManzana.SelectedItem, idPredio);
            string respuestaCargaLote = ws.cargaLotes(splitIdManzana[cbManzana.SelectedIndex]);

            string[] splitCargaLotes = respuestaCargaLote.Split(new char[] { ',' });
            int tamaño = splitCargaLotes.Length;
            foreach (string cargaLotes in splitCargaLotes) {
          
                cbLotes.Items.Add(cargaLotes);
            }
        }

        public void limpiar()
        {
            txtId.Text = "";
            cbFormaPago.Text = "";
            txtCostoTerreno.Text = "";
            txtAbono.Text = "";
            txtMensualidad.Text = "";
            txtPagoActual.Text = "";
            txtPagoFinal.Text = "";
            cbPredio.Text = "";
            cbLotes.Text = "";
            cbManzana.Text = "";
            cbNombre.SelectedIndex = -1;
        }

        private bool validar()
        {

            //String id = txtId.Text;
            String pago = cbFormaPago.Text;
            String terreno = txtCostoTerreno.Text;
            String abono = txtAbono.Text;
            String mensaulidad = txtMensualidad.Text;
            String pagoActual = txtPagoActual.Text;
            String pagoFinal = txtPagoFinal.Text;
            String predio = cbPredio.Text;
            String lote = cbLotes.Text;
            String manzana = cbManzana.Text;

            if (/*id.Length == 0 || */pago.Length == 0 || terreno.Length == 0 || abono.Length == 0 || mensaulidad.Length == 0 || pagoFinal.Length == 0 || pagoActual.Length == 0 || predio.Length == 0 || lote.Length == 0 || manzana.Length == 0)
            {
                MessageBox.Show("Para poder realizar una venta, favor de llenar todos los campos");

                return false;
            }

            else
            {
                return true;
            }
        }

        private void cbLotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            idLote = ws.getIdLote(ws.getIdManzana(cbManzana.SelectedItem.ToString(), ws.getIdPredio(cbPredio.SelectedItem.ToString())), cbLotes.SelectedItem.ToString());
            MedidaLote MedidaLote = new MedidaLote();
            MedidaLote.idLote = idLote;
            MedidaLote.Show();
        }

        private string validaTexBox(object sender, KeyPressEventArgs e) {


            return "hola";
        
        }
    }
}
